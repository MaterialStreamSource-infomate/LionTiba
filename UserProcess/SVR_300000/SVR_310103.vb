'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入棚要求受信
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310103
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
        'Dim intRet As RetCode                   '戻り値
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
            strSQL &= vbCrLf & "    XEQ_ID_IRI_YOUKYU IS NOT NULL 
            strSQL &= vbCrLf & "  "
            objAryTMST_TRK.USER_SQL = strSQL        'SQL文ｾｯﾄ
            objAryTMST_TRK.GET_TMST_TRK_USER()      '取得
            For Each objTMST_TRK As TBL_TMST_TRK In objAryTMST_TRK.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                Try


                    '************************************************
                    '設備ID(入棚入庫指示)       取得
                    '************************************************
                    Dim strAryFEQ_ID() As String = Split(objTMST_TRK.XADRS_IN, ",")


                    '************************************************
                    '設備状況                   取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_IRI_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)          '入棚入庫要求設備ID
                    Dim objTSTS_EQ_CTRL_IRI_SIZI(5) As TBL_TSTS_EQ_CTRL                                     '入棚入庫指示設備ID
                    objTSTS_EQ_CTRL_IRI_SIZI(0) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID00
                    objTSTS_EQ_CTRL_IRI_SIZI(1) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID01
                    objTSTS_EQ_CTRL_IRI_SIZI(2) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID02
                    objTSTS_EQ_CTRL_IRI_SIZI(3) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID03
                    objTSTS_EQ_CTRL_IRI_SIZI(4) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID04
                    objTSTS_EQ_CTRL_IRI_SIZI(5) = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)              '入棚入庫指示設備ID05
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_YOUKYU, objTMST_TRK.XEQ_ID_IRI_YOUKYU)         '入棚入庫要求設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(0), strAryFEQ_ID(0))                      '入棚入庫指示設備ID00
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(1), strAryFEQ_ID(1))                      '入棚入庫指示設備ID01
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(2), strAryFEQ_ID(2))                      '入棚入庫指示設備ID02
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(3), strAryFEQ_ID(3))                      '入棚入庫指示設備ID03
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(4), strAryFEQ_ID(4))                      '入棚入庫指示設備ID04
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IRI_SIZI(5), strAryFEQ_ID(5))                      '入棚入庫指示設備ID05


                    '************************************************
                    'ﾁｪｯｸ
                    '************************************************
                    If objTSTS_EQ_CTRL_IRI_YOUKYU.FEQ_STS <> FLAG_ON Then
                        '(要求が立っていない場合)
                        Continue For
                    ElseIf objTSTS_EQ_CTRL_IRI_YOUKYU.FEQ_REQ_STS <> FEQ_REQ_STS_SOFF Then
                        '(既に処理済の場合)
                        Continue For
                    ElseIf objTSTS_EQ_CTRL_IRI_SIZI(0).FEQ_STS = FLAG_OFF _
                        Or objTSTS_EQ_CTRL_IRI_SIZI(1).FEQ_STS = FLAG_OFF _
                        Or objTSTS_EQ_CTRL_IRI_SIZI(2).FEQ_STS = FLAG_OFF _
                        Then
                        '(入棚入庫指示にﾃﾞｰﾀが入っていない場合)
                        Continue For
                    End If


                    '************************************************
                    '搬送ﾃﾞｰﾀ           取得
                    '************************************************
                    Dim strFEQ_STS(5) As String
                    strFEQ_STS(0) = objTSTS_EQ_CTRL_IRI_SIZI(0).FEQ_STS     '入棚入庫指示設備ID00
                    strFEQ_STS(1) = objTSTS_EQ_CTRL_IRI_SIZI(1).FEQ_STS     '入棚入庫指示設備ID01
                    strFEQ_STS(2) = objTSTS_EQ_CTRL_IRI_SIZI(2).FEQ_STS     '入棚入庫指示設備ID02
                    strFEQ_STS(3) = objTSTS_EQ_CTRL_IRI_SIZI(3).FEQ_STS     '入棚入庫指示設備ID03
                    strFEQ_STS(4) = objTSTS_EQ_CTRL_IRI_SIZI(4).FEQ_STS     '入棚入庫指示設備ID04
                    strFEQ_STS(5) = objTSTS_EQ_CTRL_IRI_SIZI(5).FEQ_STS     '入棚入庫指示設備ID05
                    Dim intAryHansouSiziData() As Integer = Nothing         '搬送指示ﾃﾞｰﾀ配列
                    Call GetHansouSiziData(strFEQ_STS, intAryHansouSiziData)


                    '************************************************
                    '搬送完了処理(親子同時)
                    '************************************************
                    For ii As Integer = 0 To 1
                        '(ﾙｰﾌﾟ:1件 or 2件)


                        '*****************************************************
                        'ﾁｪｯｸ
                        '*****************************************************
                        If ii = 1 _
                       And objTSTS_EQ_CTRL_IRI_SIZI(3).FEQ_STS = FLAG_OFF _
                       And objTSTS_EQ_CTRL_IRI_SIZI(4).FEQ_STS = FLAG_OFF _
                       And objTSTS_EQ_CTRL_IRI_SIZI(5).FEQ_STS = FLAG_OFF _
                       Then
                            Continue For
                        End If


                        '*****************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(自動倉庫)             取得
                        '*****************************************************
                        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = FTRK_BUF_NO_J9000        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        Select Case ii
                            Case 0
                                objTPRG_TRK_BUF_ASRS.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryHansouSiziData(HansouSiziArray.Retu_01), intAryHansouSiziData(HansouSiziArray.Gouki_01))     '列
                                objTPRG_TRK_BUF_ASRS.FRAC_REN = intAryHansouSiziData(HansouSiziArray.Ren_01)            '連
                                objTPRG_TRK_BUF_ASRS.FRAC_DAN = intAryHansouSiziData(HansouSiziArray.Dan_01)            '段
                                objTPRG_TRK_BUF_ASRS.FRAC_EDA = intAryHansouSiziData(HansouSiziArray.DoubleReach_01)    '枝
                            Case 1
                                objTPRG_TRK_BUF_ASRS.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryHansouSiziData(HansouSiziArray.Retu_02), intAryHansouSiziData(HansouSiziArray.Gouki_02))     '列
                                objTPRG_TRK_BUF_ASRS.FRAC_REN = intAryHansouSiziData(HansouSiziArray.Ren_02)            '連
                                objTPRG_TRK_BUF_ASRS.FRAC_DAN = intAryHansouSiziData(HansouSiziArray.Dan_02)            '段
                                objTPRG_TRK_BUF_ASRS.FRAC_EDA = intAryHansouSiziData(HansouSiziArray.DoubleReach_02)    '枝
                        End Select
                        objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()     '取得
                        If objTPRG_TRK_BUF_ASRS.FRAC_EDA = FRAC_EDA_OKU _
                           And IsNotNull(objTPRG_TRK_BUF_ASRS.FPALLET_ID) _
                           Then
                            '(到着したﾄﾗｯｷﾝｸﾞの入庫予定棚が奥棚で、かつ在庫が存在している場合)
                            '(手前棚と奥棚の予約が入れ替わったと過程して、手前棚をﾁｪｯｸしてみる)

                            '手前の棚をもう一度取得
                            Dim intFRAC_RETU As Integer = objTPRG_TRK_BUF_ASRS.FRAC_RETU    '列
                            Dim intFRAC_REN As Integer = objTPRG_TRK_BUF_ASRS.FRAC_REN      '連
                            Dim intFRAC_DAN As Integer = objTPRG_TRK_BUF_ASRS.FRAC_DAN      '段
                            objTPRG_TRK_BUF_ASRS.CLEAR_PROPERTY()           'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
                            objTPRG_TRK_BUF_ASRS.FRAC_RETU = intFRAC_RETU   '列
                            objTPRG_TRK_BUF_ASRS.FRAC_REN = intFRAC_REN     '連
                            objTPRG_TRK_BUF_ASRS.FRAC_DAN = intFRAC_DAN     '段
                            objTPRG_TRK_BUF_ASRS.FRAC_EDA = FRAC_EDA_MAE    '枝
                            objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()         '取得

                        End If
                        If IsNull(objTPRG_TRK_BUF_ASRS.FRSV_PALLET) Then
                            '(棚に予約がかかっていない場合)
                            strMsg = "入棚の入庫行先指示のﾄﾗｯｷﾝｸﾞから予約ﾊﾟﾚｯﾄIDを取得出来ません。[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "][ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & TO_STRING(TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY)) & "]"
                            Throw New UserException(strMsg)
                        End If
                        If IsNotNull(objTPRG_TRK_BUF_ASRS.FPALLET_ID) Then
                            '(棚に別の在庫が存在している場合)
                            strMsg = "入棚の入庫行先指示のﾄﾗｯｷﾝｸﾞの予約棚に既に在庫が存在しています。[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "][ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & TO_STRING(TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY)) & "]"
                            Throw New UserException(strMsg)
                        End If


                        '*****************************************************
                        '搬送指示QUE        取得
                        '*****************************************************
                        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                        objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FRSV_PALLET     'ﾊﾟﾚｯﾄID
                        objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                              '取得
                        If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) _
                           And objTSTS_EQ_CTRL_IRI_SIZI(3).FEQ_STS = FLAG_OFF _
                           And objTSTS_EQ_CTRL_IRI_SIZI(4).FEQ_STS = FLAG_OFF _
                           And objTSTS_EQ_CTRL_IRI_SIZI(5).FEQ_STS = FLAG_OFF _
                        Then
                            '(ﾍﾟｱ搬送なのに1つしか完了ﾃﾞｰﾀがない場合)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                             FLOG_DATA_TRN_SEND_NORMAL _
                                             & "入棚入庫要求ONを検知したが、ﾍﾟｱ搬送なのに1つしか完了ﾃﾞｰﾀがない為、搬送完了しない。" _
                                             & "[検知した表記用ｱﾄﾞﾚｽ:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & "]" _
                                             & "[検知したﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_ASRS.FPALLET_ID & "]" _
                                             )
                            Continue For
                        End If


                        '*****************************************************
                        '親子ﾁｪｯｸ
                        '*****************************************************
                        If ii = 1 Then
                            '(1回目の場合)
                            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                                '(相方がいる場合)

                                '相方のﾄﾗｯｷﾝｸﾞを取得
                                Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                                objTPRG_TRK_BUF_Check.FTRK_BUF_NO = FTRK_BUF_NO_J9000                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                                objTPRG_TRK_BUF_Check.FRAC_RETU = GetFRAC_RETUFromPLCRetu(intAryHansouSiziData(HansouSiziArray.Retu_01), intAryHansouSiziData(HansouSiziArray.Gouki_01))     '列
                                objTPRG_TRK_BUF_Check.FRAC_REN = intAryHansouSiziData(HansouSiziArray.Ren_01)           '連
                                objTPRG_TRK_BUF_Check.FRAC_DAN = intAryHansouSiziData(HansouSiziArray.Dan_01)           '段
                                objTPRG_TRK_BUF_Check.FRAC_EDA = intAryHansouSiziData(HansouSiziArray.DoubleReach_01)   '枝
                                objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF()                                                '取得
                                If objTPRG_TRK_BUF_Check.FRAC_EDA = FRAC_EDA_OKU _
                                   And IsNotNull(objTPRG_TRK_BUF_Check.FPALLET_ID) _
                                   Then
                                    '(到着したﾄﾗｯｷﾝｸﾞの入庫予定棚が奥棚で、かつ在庫が存在している場合)
                                    '(手前棚と奥棚の予約が入れ替わったと過程して、手前棚をﾁｪｯｸしてみる)

                                    '手前の棚をもう一度取得
                                    Dim intFRAC_RETU As Integer = objTPRG_TRK_BUF_Check.FRAC_RETU    '列
                                    Dim intFRAC_REN As Integer = objTPRG_TRK_BUF_Check.FRAC_REN      '連
                                    Dim intFRAC_DAN As Integer = objTPRG_TRK_BUF_Check.FRAC_DAN      '段
                                    objTPRG_TRK_BUF_Check.CLEAR_PROPERTY()           'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
                                    objTPRG_TRK_BUF_Check.FRAC_RETU = intFRAC_RETU   '列
                                    objTPRG_TRK_BUF_Check.FRAC_REN = intFRAC_REN     '連
                                    objTPRG_TRK_BUF_Check.FRAC_DAN = intFRAC_DAN     '段
                                    objTPRG_TRK_BUF_Check.FRAC_EDA = FRAC_EDA_MAE    '枝
                                    objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF()         '取得

                                End If
                                If objTPLN_CARRY_QUE.XPALLET_ID_AITE <> objTPRG_TRK_BUF_Check.FRSV_PALLET Then
                                    '(ﾊﾟﾚｯﾄIDが違う場合)
                                    strMsg = "PLCから受信したﾄﾗｯｷﾝｸﾞが、親子関係になっていません。[ﾊﾟﾚｯﾄID01(正):" & objTPLN_CARRY_QUE.FPALLET_ID & "][ﾊﾟﾚｯﾄID02(正):" & objTPLN_CARRY_QUE.XPALLET_ID_AITE & "]" _
                                                                                               & "[ﾊﾟﾚｯﾄID01(誤):" & objTPLN_CARRY_QUE.FPALLET_ID & "][ﾊﾟﾚｯﾄID02(誤):" & objTPRG_TRK_BUF_Check.FRSV_PALLET & "]"
                                    Throw New UserException(strMsg)
                                End If

                            End If
                        End If


                        '*****************************************************
                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(搬送中)           ﾁｪｯｸ
                        '*****************************************************
                        Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        objTPRG_TRK_BUF_RELAY.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FRSV_PALLET     'ﾊﾟﾚｯﾄID
                        objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF()                                '取得
                        If Not ( _
                                  (intAryHansouSiziData(HansouSiziArray.LSNo_01) = 1 And objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = FTRK_BUF_NO_J3301) _
                               Or (intAryHansouSiziData(HansouSiziArray.LSNo_01) = 2 And objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = FTRK_BUF_NO_J3302) _
                               ) _
                           Then
                            '(もう既に搬送済の場合)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                             FLOG_DATA_TRN_SEND_NORMAL _
                                             & "入棚入庫要求ONを検知したが、搬送完了可能なﾄﾗｯｷﾝｸﾞがない為、搬送完了しない。" _
                                             & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO & "]" _
                                             & "[表記用ｱﾄﾞﾚｽ:" & objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS & "]" _
                                             & "[ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]" _
                                             )
                            Continue For
                        End If


                        '*****************************************************
                        '搬送完了処理
                        '*****************************************************
                        Dim objSVR_010302 As New SVR_010302(Owner, ObjDb, ObjDbLog) '搬送完了ｸﾗｽ
                        objSVR_010302.FPALLET_ID = objTPRG_TRK_BUF_ASRS.FRSV_PALLET 'ﾊﾟﾚｯﾄID
                        objSVR_010302.FINOUT_STS = FINOUT_STS_SRELAY_END            'IN/OUT
                        Call objSVR_010302.ExecCmdFunction()


                        '*****************************************************
                        '設備状況       要求状態更新
                        '*****************************************************
                        Call Set_FEQ_REQ_STS(objTSTS_EQ_CTRL_IRI_YOUKYU.FEQ_ID, FEQ_REQ_STS_JIN_TRNS_END_ON)


                        '************************
                        '次処理起動
                        '************************
                        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010101)                           '起動


                        '************************
                        '正常完了
                        '************************
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(TO):" & objTMST_TRK.FTRK_BUF_NO & "]" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(TO):" & objTMST_TRK.FBUF_NAME & "]" _
                                         & "[ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_ASRS.FRSV_PALLET & "]" _
                                         )


                    Next


                Catch ex As RollBackException
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                Finally
                    ObjDb.Commit()      'ｺﾐｯﾄ
                    ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                End Try
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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
