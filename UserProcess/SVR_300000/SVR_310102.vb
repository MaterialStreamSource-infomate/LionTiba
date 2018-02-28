'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫自動設定
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310102
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
            '************************************************
            Dim strSQL As String = ""
            Dim objAryTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TMST_TRK "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        XTRK_BUF_NO_CONV IS NOT NULL "
            strSQL &= vbCrLf & "    AND XEQ_ID_IN_FR     IS NOT NULL "
            strSQL &= vbCrLf & "    AND XEQ_ID_IN_BK     IS NOT NULL "
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    FTRK_BUF_NO "
            strSQL &= vbCrLf & "  "
            objAryTMST_TRK.USER_SQL = strSQL
            objAryTMST_TRK.GET_TMST_TRK_USER()               '取得
            For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                '************************************************
                '設備状況           取得
                '************************************************
                Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求前設備ID
                Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求後設備ID
                Dim objTSTS_EQ_CTRL_HASU_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数前設備ID
                Dim objTSTS_EQ_CTRL_HASU_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数後設備ID
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objTMST_TRK.XEQ_ID_IN_FR)           '入庫要求前設備ID
                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objTMST_TRK.XEQ_ID_IN_BK)           '入庫要求後設備ID
                If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_FR, objTMST_TRK.XEQ_ID_HASU_FR)   '端数前設備ID
                Else
                    objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = 0
                End If
                If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_BK, objTMST_TRK.XEQ_ID_HASU_BK)   '端数後設備ID
                Else
                    objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = 0
                End If


                '************************************************
                '要求状態           ﾁｪｯｸ
                '************************************************
                If Not ( _
                           (objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF) _
                       And (objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF) _
                       And (objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF) _
                       And (objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF) _
                       ) _
                    Then
                    'If Not ( _
                    '           (objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF Or objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS = FEQ_REQ_STS_JIN_SEISAN_ON) _
                    '       And (objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF Or objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS = FEQ_REQ_STS_JIN_SEISAN_ON) _
                    '       And (objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF Or objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS = FEQ_REQ_STS_JIN_SEISAN_ON) _
                    '       And (objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF Or objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS = FEQ_REQ_STS_JIN_SEISAN_ON) _
                    '       ) _
                    '    Then
                    '(既に何かしらの作業が行われていた場合)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "要求ﾌﾗｸﾞが「要求なし」or「生産入庫要求」でない為、作業は行わない。" _
                                     & "[設備ID(入庫要求前):" & TO_STRING(objTSTS_EQ_CTRL_IN_FR.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS & "]" _
                                     & "[設備ID(入庫要求後):" & TO_STRING(objTSTS_EQ_CTRL_IN_BK.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS & "]" _
                                     & "[設備ID(端数前):" & TO_STRING(objTSTS_EQ_CTRL_HASU_FR.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS & "]" _
                                     & "[設備ID(端数後):" & TO_STRING(objTSTS_EQ_CTRL_HASU_BK.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS & "]" _
                                     )
                    Continue For
                End If


                '************************************************
                '入庫するﾄﾗｯｷﾝｸﾞ数を確認
                '************************************************
                Dim intInCount As Integer = 0
                If (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
                Or (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
                Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
                Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
                Then
                    '(2件入庫する場合)

                    intInCount = 2

                Else
                    '(1件入庫する場合、もしくは入庫設定不可の場合)

                    If objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2041 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2043 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2055 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2057 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2067 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2065 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2053 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2049 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2045 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2913 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2915 _
                       Or objTMST_TRK.FTRK_BUF_NO = FTRK_BUF_NO_J2916 _
                       Then
                        '(生産入庫の場合)

                        If (objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
                        Or (objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
                        Then
                            '(1件入庫する場合)
                            intInCount = 1
                        End If

                    Else
                        '(その他入庫の場合)

                        If (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON) _
                        Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON) _
                        Then
                            '(1件入庫する場合)
                            intInCount = 1
                        End If

                    End If

                End If
                If intInCount = 0 Then Continue For


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FMｺﾝﾍﾞｱ)      取得
                '************************************************
                Dim objTPRG_TRK_BUF_ST_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ST_FM.FTRK_BUF_NO = objTMST_TRK.XTRK_BUF_NO_CONV      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                intRet = objTPRG_TRK_BUF_ST_FM.GET_TPRG_TRK_BUF_FIFO(True)            '取得
                If intRet <> RetCode.OK Then
                    '(見つからなかった場合)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "載荷ONを検知したが、入庫可能なﾄﾗｯｷﾝｸﾞがない為、入庫しない。" _
                                     & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM):" & objTPRG_TRK_BUF_ST_FM.FTRK_BUF_NO & "]" _
                                     )
                    Continue For
                End If
                If objTPRG_TRK_BUF_ST_FM.ARYME.Length < intInCount Then
                    '(ﾄﾗｯｷﾝｸﾞ数 < 載荷数 の場合)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "載荷ONを検知したが、入庫可能なﾄﾗｯｷﾝｸﾞの数が足りない為、入庫しない。" _
                                     & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM):" & TO_STRING(objTPRG_TRK_BUF_ST_FM.FTRK_BUF_NO) & "]" _
                                     & "[ﾄﾗｯｷﾝｸﾞ数(FM):" & TO_STRING(objTPRG_TRK_BUF_ST_FM.ARYME.Length) & "]" _
                                     & "[載荷数:" & TO_STRING(intInCount) & "]" _
                                     )
                    Continue For
                End If
                If intInCount = 1 Then
                    '(1件入庫の場合)
                    If objTPRG_TRK_BUF_ST_FM.ARYME.Length <> 1 Then
                        '(ﾄﾗｯｷﾝｸﾞ数が1じゃない場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "1件の載荷ONを検知したが、入庫可能なﾄﾗｯｷﾝｸﾞの数が1件じゃない為、入庫しない。(2件の載荷ON待ち)" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM):" & TO_STRING(objTPRG_TRK_BUF_ST_FM.FTRK_BUF_NO) & "]" _
                                         & "[ﾄﾗｯｷﾝｸﾞ数(FM):" & TO_STRING(objTPRG_TRK_BUF_ST_FM.ARYME.Length) & "]" _
                                         & "[載荷数:" & TO_STRING(intInCount) & "]" _
                                         )
                        Continue For
                    End If
                End If
                If intInCount = 2 Then
                    '(2件入庫の場合)
                    If objTPRG_TRK_BUF_ST_FM.ARYME(0).FRSV_BUF_TO = FTRK_BUF_NO_J9000 Then
                        '(緊急時入庫登録じゃない場合)
                        intRet = HanteiOyakoFRSV_PALLET(objTPRG_TRK_BUF_ST_FM.ARYME(0).FPALLET_ID, objTPRG_TRK_BUF_ST_FM.ARYME(1).FPALLET_ID)
                        If intRet <> RetCode.OK Then
                            strMsg = "先端の二つが親子関係にない為、ｴﾗｰとします。"
                            strMsg &= "[元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF_ST_FM.ARYME(0).FTRK_BUF_NO & "][表記用ｱﾄﾞﾚｽ:" & objTPRG_TRK_BUF_ST_FM.ARYME(0).FDISP_ADDRESS & "]"
                            strMsg &= "[ﾊﾟﾚｯﾄID01:" & objTPRG_TRK_BUF_ST_FM.ARYME(0).FPALLET_ID & "][ﾊﾟﾚｯﾄID02:" & objTPRG_TRK_BUF_ST_FM.ARYME(1).FPALLET_ID & "]"
                            Throw New UserException(strMsg)
                        End If
                    End If
                End If


                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TOｺﾝﾍﾞｱ)      取得
                '************************************************
                Dim intCountAki As Integer
                Dim objTPRG_TRK_BUF_ST_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_ST_TO.FRES_KIND = FRES_KIND_SAKI                    '引当状態
                intCountAki = objTPRG_TRK_BUF_ST_TO.GET_TPRG_TRK_BUF_COUNT          '取得


                ''特殊処理　出荷コンベアと兼用の為　2017/07/31 infomate
                If objTMST_TRK.FTRK_BUF_NO = 1158 Or _
                   objTMST_TRK.FTRK_BUF_NO = 1159 Or _
                   objTMST_TRK.FTRK_BUF_NO = 1161 Or _
                   objTMST_TRK.FTRK_BUF_NO = 1162 Then
                    If intCountAki < 2 Then
                        '(ﾄﾗｯｷﾝｸﾞ数 < 載荷数 の場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "載荷ONを検知したが、入庫STが全て空きじゃない為、入庫しない。" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO):" & TO_STRING(objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO) & "]" _
                                         & "[ﾄﾗｯｷﾝｸﾞ数(TO):" & TO_STRING(intCountAki) & "]" _
                                         & "[載荷数:" & TO_STRING(intInCount) & "]" _
                                         )
                        Continue For
                    End If
                Else
                    If intCountAki <> 2 Then
                        '(ﾄﾗｯｷﾝｸﾞ数 < 載荷数 の場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "載荷ONを検知したが、入庫STが全て空きじゃない為、入庫しない。" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO):" & TO_STRING(objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO) & "]" _
                                         & "[ﾄﾗｯｷﾝｸﾞ数(TO):" & TO_STRING(intCountAki) & "]" _
                                         & "[載荷数:" & TO_STRING(intInCount) & "]" _
                                         )
                        Continue For
                    End If
                End If



                '************************************************************************************************
                '行先                           取得
                '************************************************************************************************
                Dim intST_TO As Integer = 0                         '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                If TO_INTEGER(objTPRG_TRK_BUF_ST_FM.ARYME(0).FRSV_BUF_TO) = FTRK_BUF_NO_J9000 Then
                    '(行先が自動倉庫の場合)

                    '===========================================
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(自動倉庫)         取得
                    '===========================================
                    Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_ST_FM.ARYME(0).FRSV_BUF_TO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_ST_FM.ARYME(0).FRSV_ARRAY_TO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
                    objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()                                                 '取得

                    '===========================================
                    'ｸﾚｰﾝﾏｽﾀ                        取得
                    '===========================================
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)
                    objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU     'ﾁｪｯｸ列
                    intRet = objTMST_CRANE.GET_TMST_CRANE_ROW()
                    If intRet <> RetCode.OK Then
                        '(見つからなかった場合)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                        Throw New UserException(strMsg)
                    End If

                    '===========================================
                    '搬送ﾙｰﾄﾏｽﾀ                     取得
                    '===========================================
                    Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)
                    objTMST_ROUTE.FBUF_FM = objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO   '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_ROUTE.FBUF_TO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO    '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_ROUTE.FEQ_ID_CRANE_TO = objTMST_CRANE.FEQ_ID        '先ｸﾚｰﾝ設備ID
                    objTMST_ROUTE.GET_TMST_ROUTE()                              '取得
                    intST_TO = objTMST_ROUTE.FBUF_TO                            '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

                Else
                    '(行先が自動倉庫以外の場合)

                    '===========================================
                    '行先                           設定
                    '===========================================
                    intST_TO = objTPRG_TRK_BUF_ST_FM.ARYME(0).FRSV_BUF_TO       'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

                End If


                '************************************************
                '在庫情報               取得
                '************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                objTRST_STOCK.FPALLET_ID = objTPRG_TRK_BUF_ST_FM.ARYME(0).FPALLET_ID    'ﾊﾟﾚｯﾄID
                objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)                               '取得


                '************************************************
                '在庫引当情報           取得
                '************************************************
                Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_ST_FM.ARYME(0).FPALLET_ID  'ﾊﾟﾚｯﾄID
                objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET()                               '取得


                '************************************************
                'ﾊﾟﾚｯﾄID                取得
                '在庫移動してしまうとややこしくなるので、ここで設定する
                '************************************************
                Dim strAryXOYAKO_KUBUN(1) As String         '親子区分
                Dim strAryXPALLET_ID_AITE(1) As String      '相手ﾊﾟﾚｯﾄID
                strAryXOYAKO_KUBUN(0) = XOYAKO_KUBUN_JOYA
                strAryXOYAKO_KUBUN(1) = XOYAKO_KUBUN_JKO
                If intInCount = 2 And 2 <= objTPRG_TRK_BUF_ST_FM.ARYME.Length Then
                    strAryXPALLET_ID_AITE(0) = objTPRG_TRK_BUF_ST_FM.ARYME(1).FPALLET_ID
                End If
                strAryXPALLET_ID_AITE(1) = objTPRG_TRK_BUF_ST_FM.ARYME(0).FPALLET_ID


                For ii As Integer = 0 To intInCount - 1
                    '(ﾙｰﾌﾟ:入庫するﾄﾗｯｷﾝｸﾞ件数)


                    '***********************************************
                    '親子区分、相手ﾊﾟﾚｯﾄID      設定
                    '***********************************************
                    Dim strXOYAKO_KUBUN As String = strAryXOYAKO_KUBUN(ii)          '親子区分
                    Dim strXPALLET_ID_AITE As String = strAryXPALLET_ID_AITE(ii)    '相手ﾊﾟﾚｯﾄID


                    '***********************************************
                    '空ﾊﾞｯﾌｧ                    取得
                    '***********************************************
                    objTPRG_TRK_BUF_ST_TO.CLEAR_PROPERTY()
                    objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_ST_TO.GET_TPRG_TRK_BUF_AKI_HIRA()


                    '************************
                    '在庫移動
                    '************************
                    Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
                    objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_ST_FM.ARYME(ii)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)
                    objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ST_TO                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)
                    objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_ST_FM.ARYME(ii).FPALLET_ID   'ﾊﾟﾚｯﾄID
                    objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_UKETUKE                           'INOUT
                    objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                   '作業種別
                    objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                                    '搬送元ｸﾘｱﾌﾗｸﾞ
                    objSVR_100103.STOCK_TRNS()                                                  '移動


                    '***********************************************
                    '直行設定
                    '***********************************************
                    Dim DSPTERM_ID As Integer = 0             '端末ID
                    Dim DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
                    Dim DSPREASON As Integer = 2              '理由
                    Dim DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Dim DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    Dim DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
                    Dim DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
                    Dim DSPSAGYOU_KIND As Integer = 7         '作業種別
                    Dim DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
                    Dim DSPTR_VOL As Integer = 9              '搬送管理量
                    Dim XDSPIN_KIND As Integer = 10           '入庫種別
                    Dim XDSPIN_SITEI As Integer = 11          '入庫指定
                    Dim XDSPPROD_LINE As Integer = 12         '生産ﾗｲﾝ№
                    Dim XDSPKENSA_KUBUN As Integer = 13       '検査区分
                    Dim DSPHORYU_KUBUN As Integer = 14        '保留区分
                    Dim XDSPTR_VOL_KO As Integer = 15         '搬送管理量(子)
                    Dim XDSPKENSA_KUBUN_KO As Integer = 16    '検査区分(子)
                    Dim XDSPHORYU_KUBUN_KO As Integer = 17    '保留区分(子)
                    Dim XDSPST_TO_ARRAY01 As Integer = 18     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
                    Dim XDSPST_TO_ARRAY02 As Integer = 19     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02
                    Dim strDenbunDtl(16) As String
                    strDenbunDtl(DSPTERM_ID) = FTERM_ID_SKOTEI                  '端末ID
                    strDenbunDtl(DSPUSER_ID) = FUSER_ID_SKOTEI                  'ﾕｰｻﾞｰID
                    strDenbunDtl(DSPREASON) = ""                                '理由
                    strDenbunDtl(DSPST_FM) = objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    strDenbunDtl(DSPST_TO) = intST_TO                           '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'strDenbunDtl(DSPPALLET_ID) =                'ﾊﾟﾚｯﾄID
                    'strDenbunDtl(DSPLOT_NO_STOCK) =             '在庫ﾛｯﾄ№
                    strDenbunDtl(DSPSAGYOU_KIND) = objTSTS_HIKIATE.FSAGYOU_KIND         '作業種別
                    strDenbunDtl(DSPHINMEI_CD) = objTRST_STOCK.ARYME(0).FHINMEI_CD      '品名ｺｰﾄﾞ
                    'strDenbunDtl(DSPTR_VOL) =                   '搬送管理量
                    'strDenbunDtl(XDSPIN_KIND) =                 '入庫種別
                    'strDenbunDtl(XDSPIN_SITEI) =                '入庫指定
                    'strDenbunDtl(XDSPPROD_LINE) =               '生産ﾗｲﾝ№
                    'strDenbunDtl(XDSPKENSA_KUBUN) =             '検査区分
                    'strDenbunDtl(DSPHORYU_KUBUN) =              '保留区分
                    'strDenbunDtl(XDSPTR_VOL_KO) =               '搬送管理量(子)
                    'strDenbunDtl(XDSPKENSA_KUBUN_KO) =          '検査区分(子)
                    'strDenbunDtl(XDSPHORYU_KUBUN_KO) =          '保留区分(子)
                    'strDenbunDtl(XDSPST_TO_ARRAY01) =           '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
                    'strDenbunDtl(XDSPST_TO_ARRAY02) =           '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02
                    intRet = SVR_499999_Process(strDenbunDtl _
                                              , strMSG_RECV _
                                              , strMSG_SEND _
                                              , objTPRG_TRK_BUF_ST_TO.FPALLET_ID _
                                              , Nothing _
                                              , Nothing _
                                              , strXOYAKO_KUBUN _
                                              , strXPALLET_ID_AITE _
                                              )


                    '***********************************************
                    '正常完了
                    '***********************************************
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(FM):" & TO_STRING(objTPRG_TRK_BUF_ST_FM.FTRK_BUF_NO) & "]" _
                                     & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO):" & TO_STRING(objTPRG_TRK_BUF_ST_TO.FTRK_BUF_NO) & "]" _
                                     )


                Next


            Next


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region

#Region "  ﾒｲﾝ処理                                                                          _old"
    ''''**********************************************************************************************
    '''' <summary>
    '''' ﾒｲﾝ処理
    '''' </summary>
    '''' <param name="strMSG_RECV">受信電文</param>
    '''' <param name="strMSG_SEND">送信電文</param>
    '''' <returns>OK/NG</returns>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Dim intRet As RetCode                   '戻り値
    '    Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************************************
    '        'ｺﾝﾍﾞｱ関連付けﾏｽﾀ           取得
    '        '************************************************
    '        Dim objAryXMST_CONN_CONV As New TBL_XMST_CONN_CONV(Owner, ObjDb, ObjDbLog)
    '        objAryXMST_CONN_CONV.GET_XMST_CONN_CONV_ANY()           '取得
    '        For Each objXMST_CONN_CONV As TBL_XMST_CONN_CONV In objAryXMST_CONN_CONV.ARYME
    '            '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


    '            ''************************************************
    '            ''入庫STか否か判断
    '            ''************************************************
    '            'Select Case objXMST_CONN_CONV.FTRK_BUF_NO
    '            '    Case FTRK_BUF_NO_J2038
    '            '        'Case FTRK_BUF_NO_J2041
    '            '        'Case FTRK_BUF_NO_J2043
    '            '        'Case FTRK_BUF_NO_J2045
    '            '        'Case FTRK_BUF_NO_J2047
    '            '        'Case FTRK_BUF_NO_J2049
    '            '        'Case FTRK_BUF_NO_J2053
    '            '        'Case FTRK_BUF_NO_J2055
    '            '        'Case FTRK_BUF_NO_J2057
    '            '        'Case FTRK_BUF_NO_J2065
    '            '        'Case FTRK_BUF_NO_J2067
    '            '        'Case FTRK_BUF_NO_J
    '            '        'Case FTRK_BUF_NO_J
    '            '        'Case FTRK_BUF_NO_J
    '            '    Case Else : Continue For
    '            'End Select


    '            '************************************************
    '            '設備状況           取得
    '            '************************************************
    '            Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求前設備ID
    '            Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求後設備ID
    '            Dim objTSTS_EQ_CTRL_HASU_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数前設備ID
    '            Dim objTSTS_EQ_CTRL_HASU_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数後設備ID
    '            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objXMST_CONN_CONV.XEQ_ID_IN_FR)         '入庫要求前設備ID
    '            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objXMST_CONN_CONV.XEQ_ID_IN_BK)         '入庫要求後設備ID
    '            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_FR, objXMST_CONN_CONV.XEQ_ID_HASU_FR)     '端数前設備ID
    '            Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_BK, objXMST_CONN_CONV.XEQ_ID_HASU_BK)     '端数後設備ID


    '            '************************************************
    '            'ｺﾝﾍﾞｱ関連付けﾏｽﾀ           ﾁｪｯｸ
    '            '************************************************
    '            If (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
    '            Or (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
    '            Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON) _
    '            Then
    '                '(入庫設定可能する場合)
    '                'NOP
    '            Else
    '                '(入庫設定不可の場合)
    '                Continue For
    '            End If


    '            '************************************************
    '            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ           取得
    '            '************************************************
    '            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '            objTPRG_TRK_BUF.FTRK_BUF_NO = objXMST_CONN_CONV.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_NOT_AKI(True)         '取得
    '            If intRet <> RetCode.OK Then
    '                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                                 FLOG_DATA_TRN_SEND_NORMAL _
    '                                 & "載荷ONだけど、入庫可能なﾄﾗｯｷﾝｸﾞがない為、入庫しない。" _
    '                                 & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "]" _
    '                                 )
    '                Continue For
    '            End If


    '            '    '************************************************
    '            '    '入庫設定可能かﾁｪｯｸ
    '            '    '************************************************
    '            '    If (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
    '            '    Or (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
    '            '    Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
    '            '    Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
    '            '    Then
    '            '        '(2件入庫する場合)

    '            '        If 1 <= UBound(objTPRG_TRK_BUF.ARYME) Then
    '            '            '(何かしらのﾄﾗｯｷﾝｸﾞが2件以上存在していた場合)

    '            '            If IsNotNull(objTPRG_TRK_BUF.ARYME(0).FPALLET_ID) And objTPRG_TRK_BUF.ARYME(0).FRES_KIND = FRES_KIND_SZAIKO _
    '            '               And IsNotNull(objTPRG_TRK_BUF.ARYME(1).FPALLET_ID) And objTPRG_TRK_BUF.ARYME(1).FRES_KIND = FRES_KIND_SZAIKO _
    '            '               Then
    '            '                '(1ﾄﾗｯｷﾝｸﾞ目も2ﾄﾗｯｷﾝｸﾞ目も通常在庫だった場合)
    '            '                'NOP
    '            '            Else
    '            '                '(1ﾄﾗｯｷﾝｸﾞ目も2ﾄﾗｯｷﾝｸﾞ目も通常在庫じゃない場合)
    '            '                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '            '                                 FLOG_DATA_TRN_SEND_NORMAL _
    '            '                                 & "載荷ONだけど、先端ﾄﾗｯｷﾝｸﾞが入庫不可の為、入庫しない。" _
    '            '                                 & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "]" _
    '            '                                 )
    '            '                Continue For
    '            '            End If

    '            '        Else
    '            '            '(2件のﾄﾗｯｷﾝｸﾞが存在しない場合)
    '            '            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '            '                             FLOG_DATA_TRN_SEND_NORMAL _
    '            '                             & "2件の載荷ONだけど、入庫可能なﾄﾗｯｷﾝｸﾞが2件存在しない為、入庫しない。" _
    '            '                             & "[ﾊﾟﾚｯﾄID (前):" & objTPRG_TRK_BUF.ARYME(0).FPALLET_ID & "]" _
    '            '                             & "[引当状態(前):" & objTPRG_TRK_BUF.ARYME(0).FRES_KIND & "]" _
    '            '                             & "[ﾊﾟﾚｯﾄID (後):" & objTPRG_TRK_BUF.ARYME(1).FPALLET_ID & "]" _
    '            '                             & "[引当状態(後):" & objTPRG_TRK_BUF.ARYME(1).FRES_KIND & "]" _
    '            '                             )
    '            '            Continue For
    '            '        End If


    '            '    Else
    '            '        '(入庫設定不可の場合)
    '            '        Continue For
    '            '    End If


    '            '    '***********************************************
    '            '    '入庫設定
    '            '    '***********************************************
    '            '    intRet = SVR_400001_Process(strDenbunDtl, strMSG_RECV, strMSG_SEND, strDenbunDtl(DSPPALLET_ID))

    '        Next








    '        ''************************
    '        ''正常完了
    '        ''************************
    '        'Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '        '                 FLOG_DATA_TRN_SEND_NORMAL _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 & "[ｱｲﾃﾑ名:" &                 & "]" _
    '        '                 )


    '        Return RetCode.OK
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
