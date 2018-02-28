'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】包材出庫引当処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310202
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
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim dtmNow As Date = Now                '現在日時
        Try


            '*****************************************************
            'ﾒｲﾝ処理(包材出庫処理)
            '*****************************************************
            Call ExecCmd01()


            '*****************************************************
            'ﾒｲﾝ処理(D45包材出庫処理)
            '*****************************************************
            Call ExecCmd02()


            '*****************************************************
            'ﾒｲﾝ処理(1F包材出庫処理)
            '*****************************************************
            Call ExecCmd03()

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


#Region "  ﾒｲﾝ処理(   包材出庫処理)                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ExecCmd01() As RetCode
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '************************************************
        '生産入庫設定状態               取得
        '************************************************
        Dim strSQL As String = ""
        Dim objAryXSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XPROGRESS = " & TO_STRING(XPROGRESS_START)
        strSQL &= vbCrLf & "  "
        objAryXSTS_WRAPPING_MATERIAL.USER_SQL = strSQL                          'SQL文
        intRet = objAryXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL_USER() '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXSTS_WRAPPING_MATERIAL As TBL_XSTS_WRAPPING_MATERIAL In objAryXSTS_WRAPPING_MATERIAL.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                Try


                    '************************************************
                    '計画数量、実績数量         ﾁｪｯｸ
                    '************************************************
                    If 0 <= objXSTS_WRAPPING_MATERIAL.XPLAN_NUM Then
                        '(空PL出庫以外の場合)
                        If objXSTS_WRAPPING_MATERIAL.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL.XRESULT_NUM Then
                            '(計画数量 <= 実績数量 の場合)
                            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                             FLOG_DATA_TRN_SEND_NORMAL _
                                             & "計画数量に達した為、出庫しない。" _
                                             & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO) & "][計画数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL.XPLAN_NUM) & "][実績数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) & "]" _
                                             )
                            Continue For
                        End If
                    End If


                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK.GET_TMST_TRK()                                          '取得


                    '************************************************
                    '設備状況           取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_OUT_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '入庫要求前 設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_OUT_YOUKYU, objTMST_TRK.XEQ_ID_OUT_YOUKYU)     '出庫要求   設備ID


                    '************************************************
                    '要求状態           ﾁｪｯｸ
                    '************************************************
                    If Not ( _
                               objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
                           ) _
                        Then
                        '(既に何かしらの作業が行われていた場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "要求ﾌﾗｸﾞがOFFでない為、作業は行わない。" _
                                         & "[設備ID(出庫要求):" & TO_STRING(objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS & "]" _
                                         )
                        Continue For
                    End If


                    '************************************************
                    '出庫要求       ﾁｪｯｸ
                    '************************************************
                    If Not (objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048406) Then
                        If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS <> FLAG_ON Then
                            '(出庫要求が立っていない場合)
                            Continue For
                        End If
                    Else
                        If 5 <= objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS Then
                            '(ﾊﾟﾚｯﾄ数が0以外の場合)
                            Continue For
                        End If
                    End If


                    '************************************************
                    '現在出庫しているﾄﾗｯｷﾝｸﾞ数を確認
                    '************************************************
                    Dim intCount As Integer
                    Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_Check.FTR_TO = objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO        '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCount = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT                     '取得
                    If 1 <= intCount Then
                        '(既に何かしら出庫している場合)
                        Continue For
                    End If


                    '************************************************
                    '品目ﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objXSTS_WRAPPING_MATERIAL.FHINMEI_CD '品目ｺｰﾄﾞ
                    objTMST_ITEM.GET_TMST_ITEM()


                    '************************************************
                    '引当ﾊﾟﾚｯﾄ数        設定
                    '************************************************
                    Dim intPltNum As Integer = 1
                    If (objXSTS_WRAPPING_MATERIAL.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) = 1 Then
                        intPltNum = 1
                    Else
                        intPltNum = 2
                    End If


                    '************************************************
                    '出庫設定処理
                    '************************************************
                    intRet = SyukkoSetteiProcess(objTMST_ITEM _
                                               , objTMST_TRK _
                                               , intPltNum _
                                               , objXSTS_WRAPPING_MATERIAL.XMAKER_CD _
                                               , objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO _
                                               , Nothing _
                                               )


                    ' '' ''↓↓↓↓↓↓************************************************************************************************************
                    ' '' ''JobMate:S.Ouchi 2013/10/29 包材出庫登録(D41/D42)特殊供給
                    '' '' '' ''If intRet = RetCode.OK Then Exit For
                    '' ''If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048406 Then
                    '' ''    If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS = 0 Then

                    '' ''        '    ↓↓↓↓↓↓************************************************************************************************************
                    '' ''        'JobMate:S.Ouchi 2013/11/21 包材出庫登録(D41/D42)特殊供給
                    '' ''        If (objXSTS_WRAPPING_MATERIAL.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) > 2 Then
                    '' ''            If (objXSTS_WRAPPING_MATERIAL.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) = 3 Then
                    '' ''                intPltNum = 1
                    '' ''            Else
                    '' ''                intPltNum = 2
                    '' ''            End If
                    '' ''            'JobMate:S.Ouchi 2013/11/21 包材出庫登録(D41/D42)特殊供給
                    '' ''            '↑↑↑↑↑↑************************************************************************************************************

                    '' ''            Dim inFlg As Integer                                                        '特殊供給ﾌﾗｸﾞ
                    '' ''            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
                    '' ''            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_JGJ310030_001                         '変数ID
                    '' ''            objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                                      '取得
                    '' ''            inFlg = TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT)                              '特殊供給ﾌﾗｸﾞ

                    '' ''            If inFlg = FLAG_ON Then
                    '' ''                '************************************************
                    '' ''                '出庫設定処理
                    '' ''                '************************************************
                    '' ''                intRet = SyukkoSetteiProcess(objTMST_ITEM _
                    '' ''                                           , objTMST_TRK _
                    '' ''                                           , intPltNum _
                    '' ''                                           , objXSTS_WRAPPING_MATERIAL.XMAKER_CD _
                    '' ''                                           , objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO _
                    '' ''                                           , Nothing _
                    '' ''                                           )
                    '' ''                If intRet = RetCode.OK Then Exit For
                    '' ''            Else
                    '' ''                If intRet = RetCode.OK Then Exit For
                    '' ''            End If

                    '' ''            '↓↓↓↓↓↓************************************************************************************************************
                    '' ''            'JobMate:S.Ouchi 2013/11/21 包材出庫登録(D41/D42)特殊供給
                    '' ''        Else
                    '' ''            If intRet = RetCode.OK Then Exit For
                    '' ''        End If
                    '' ''        '    JobMate:S.Ouchi 2013/11/21 包材出庫登録(D41/D42)特殊供給
                    '' ''        '↑↑↑↑↑↑************************************************************************************************************

                    '' ''    Else
                    '' ''        If intRet = RetCode.OK Then Exit For
                    '' ''    End If
                    '' ''Else
                    '' ''    If intRet = RetCode.OK Then Exit For
                    '' ''End If
                    ' '' ''JobMate:S.Ouchi 2013/10/29 包材出庫登録(D41/D42)特殊供給
                    ' '' ''↑↑↑↑↑↑************************************************************************************************************


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/29 包材出庫登録(D41/D42)特殊供給
                    If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048405 Or objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID = FEQ_ID_JOTHY04_X048406 Then
                        If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS = 0 Then

                            Dim inFlg As Integer                                                        '特殊供給ﾌﾗｸﾞ
                            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
                            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_JGJ310030_001                         '変数ID
                            objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                                      '取得
                            inFlg = TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT)                              '特殊供給ﾌﾗｸﾞ

                            If inFlg = FLAG_ON Then
                                For iii As Integer = 1 To 3
                                    Dim intTO_CNT As Integer = 0
                                    Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                                    objTPRG_TRK_BUF_TO.FTR_TO = objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO       '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                                    objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_TR_TO()                             '取得
                                    If IsNothing(objTPRG_TRK_BUF_TO.ARYME) = True Then
                                        Exit For
                                    Else
                                        intTO_CNT = TO_INTEGER(objTPRG_TRK_BUF_TO.ARYME.Length)
                                    End If

                                    If intTO_CNT >= 4 Then Exit For

                                    If (objXSTS_WRAPPING_MATERIAL.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) > intTO_CNT Then
                                        If (objXSTS_WRAPPING_MATERIAL.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL.XRESULT_NUM) - intTO_CNT = 1 Or _
                                           intTO_CNT = 3 Then
                                            intPltNum = 1
                                        Else
                                            intPltNum = 2
                                        End If

                                        '************************************************
                                        '出庫設定処理
                                        '************************************************
                                        intRet = SyukkoSetteiProcess(objTMST_ITEM _
                                                                   , objTMST_TRK _
                                                                   , intPltNum _
                                                                   , objXSTS_WRAPPING_MATERIAL.XMAKER_CD _
                                                                   , objXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO _
                                                                   , Nothing _
                                                                   )
                                        If intRet <> RetCode.OK Then Exit For
                                    Else
                                        Exit For
                                    End If
                                Next iii

                                Exit For

                            Else
                                If intRet = RetCode.OK Then Exit For
                            End If

                    Else
                        If intRet = RetCode.OK Then Exit For
                    End If
                    Else
                        If intRet = RetCode.OK Then Exit For
                    End If
                    'JobMate:S.Ouchi 2013/11/29 包材出庫登録(D41/D42)特殊供給
                    '↑↑↑↑↑↑************************************************************************************************************


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
        End If


    End Function
#End Region
#Region "  ﾒｲﾝ処理(D45包材出庫処理)                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ExecCmd02() As RetCode
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '************************************************
        '生産入庫設定状態               取得
        '************************************************
        Dim strSQL As String = ""
        Dim objAryXSTS_WRAPPING_MATERIAL_D45 As New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45 "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XPROGRESS = " & TO_STRING(XPROGRESS_START)
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPROD_LINE "
        strSQL &= vbCrLf & "  "
        objAryXSTS_WRAPPING_MATERIAL_D45.USER_SQL = strSQL                              'SQL文
        intRet = objAryXSTS_WRAPPING_MATERIAL_D45.GET_XSTS_WRAPPING_MATERIAL_D45_USER() '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXSTS_WRAPPING_MATERIAL_D45 As TBL_XSTS_WRAPPING_MATERIAL_D45 In objAryXSTS_WRAPPING_MATERIAL_D45.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                Try


                    '************************************************
                    '計画数量、実績数量         ﾁｪｯｸ
                    '************************************************
                    If objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM Then
                        '(計画数量 <= 実績数量 の場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "計画数量に達した為、出庫しない。" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO) & "][計画数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM) & "][実績数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM) & "]" _
                                         )
                        Continue For
                    End If


                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK.GET_TMST_TRK()                                              '取得


                    '************************************************
                    '設備状況           取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_OUT_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '出庫要求   出庫要求設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_OUT_YOUKYU, objTMST_TRK.XEQ_ID_OUT_YOUKYU)     '出庫要求   出庫要求設備ID


                    '************************************************
                    '要求状態           ﾁｪｯｸ
                    '************************************************
                    If Not ( _
                               objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
                           ) _
                        Then
                        '(既に何かしらの作業が行われていた場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "要求ﾌﾗｸﾞがOFFでない為、作業は行わない。" _
                                         & "[設備ID(出庫要求):" & TO_STRING(objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS & "]" _
                                         )
                        Continue For
                    End If


                    ' '' ''************************************************
                    ' '' ''出庫要求       ﾁｪｯｸ
                    ' '' ''************************************************
                    '' ''If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS <> FLAG_ON Then
                    '' ''    '(出庫要求が立っていない場合)
                    '' ''    Continue For
                    '' ''End If


                    '************************************************
                    '現在出庫しているﾄﾗｯｷﾝｸﾞ数を確認
                    '************************************************
                    Dim intCount As Integer
                    Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_Check.FTR_TO = objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO    '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCount = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT                     '取得
                    If 1 <= intCount Then
                        '(既に何かしら出庫している場合)
                        Continue For
                    End If


                    '************************************************
                    '品目ﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objXSTS_WRAPPING_MATERIAL_D45.FHINMEI_CD '品目ｺｰﾄﾞ
                    objTMST_ITEM.GET_TMST_ITEM()


                    '************************************************
                    '引当ﾊﾟﾚｯﾄ数        設定
                    '************************************************
                    Dim intPltNum As Integer = 1
                    If (objXSTS_WRAPPING_MATERIAL_D45.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL_D45.XRESULT_NUM) = 1 Then
                        intPltNum = 1
                    Else
                        intPltNum = 2
                    End If


                    '************************************************
                    '出庫設定処理
                    '************************************************
                    intRet = SyukkoSetteiProcess(objTMST_ITEM _
                                               , objTMST_TRK _
                                               , intPltNum _
                                               , objXSTS_WRAPPING_MATERIAL_D45.XMAKER_CD _
                                               , objXSTS_WRAPPING_MATERIAL_D45.FTRK_BUF_NO _
                                               , objXSTS_WRAPPING_MATERIAL_D45.FPLAN_KEY _
                                               )
                    If intRet = RetCode.OK Then Exit For


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
        End If


    End Function
#End Region


#Region "  ﾒｲﾝ処理(1F包材出庫処理)                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function ExecCmd03() As RetCode
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '************************************************
        '生産入庫設定状態               取得
        '************************************************
        Dim strSQL As String = ""
        Dim objAryXSTS_WRAPPING_MATERIAL_1F As New TBL_XSTS_WRAPPING_MATERIAL_1F(Owner, ObjDb, ObjDbLog)
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_WRAPPING_MATERIAL_1F "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XPROGRESS = " & TO_STRING(XPROGRESS_START)
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPROD_LINE "
        strSQL &= vbCrLf & "  "
        objAryXSTS_WRAPPING_MATERIAL_1F.USER_SQL = strSQL                              'SQL文
        intRet = objAryXSTS_WRAPPING_MATERIAL_1F.GET_XSTS_WRAPPING_MATERIAL_1F_USER() '取得
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXSTS_WRAPPING_MATERIAL_1F As TBL_XSTS_WRAPPING_MATERIAL_1F In objAryXSTS_WRAPPING_MATERIAL_1F.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                Try

                    '’↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                    '’2017/08/03 複数同時出庫対応　YAMMAOTO
                    '************************************************
                    '計画数量、実績数量         ﾁｪｯｸ
                    '************************************************
                    'If objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM Then
                    '    '(計画数量 <= 実績数量 の場合)
                    '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                    '                     FLOG_DATA_TRN_SEND_NORMAL _
                    '                     & "計画数量に達した為、出庫しない。" _
                    '                     & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO) & "][計画数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM) & "][実績数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM) & "]" _
                    '                     )
                    '    Continue For
                    'End If
                    '************************************************
                    '計画数量、引当数量         ﾁｪｯｸ
                    '************************************************
                    If objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM <= objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL Then
                        '(要求数量 <= 引当数量 の場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "要求数量に達した為、出庫しない。" _
                                         & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO) & "][要求数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM) & "][引当数量:" & TO_STRING(objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM) & "]" _
                                         )
                        Continue For
                    End If
                    '’↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK.GET_TMST_TRK()                                              '取得


                    '************************************************
                    '設備状況           取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_OUT_YOUKYU As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '出庫要求   出庫要求設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_OUT_YOUKYU, objTMST_TRK.XEQ_ID_OUT_YOUKYU)     '出庫要求   出庫要求設備ID


                    '************************************************
                    '要求状態           ﾁｪｯｸ
                    '************************************************
                    If Not ( _
                               objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
                           ) _
                        Then
                        '(既に何かしらの作業が行われていた場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                         FLOG_DATA_TRN_SEND_NORMAL _
                                         & "要求ﾌﾗｸﾞがOFFでない為、作業は行わない。" _
                                         & "[設備ID(出庫要求):" & TO_STRING(objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_REQ_STS & "]" _
                                         )
                        Continue For
                    End If


                    '************************************************
                    '出庫要求       ﾁｪｯｸ
                    '************************************************
                    'If objTSTS_EQ_CTRL_OUT_YOUKYU.FEQ_STS <> FLAG_ON Then
                    '    '(出庫要求が立っていない場合)
                    '    Continue For
                    'End If


                    '************************************************
                    '現在出庫しているﾄﾗｯｷﾝｸﾞ数を確認
                    '************************************************
                    Dim intCount As Integer
                    Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTPRG_TRK_BUF_Check.FTR_TO = objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO    '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTPRG_TRK_BUF_Check.WHERE = " AND FPALLET_ID IS NOT NULL"

                    intCount = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT                     '取得

                    ''2017/07/13 YAMAMOTO Mod
                    ''同時出庫数をSTマスタから取得する
                    Dim objTMST_ST As New TBL_TMST_ST(Owner, ObjDb, ObjDbLog)
                    objTMST_ST.FTRK_BUF_NO = objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_ST.GET_TMST_ST()                                              '取得

                    ''2017/07/13 YAMAMOTO Mod
                    If objTMST_ST.FINOUT_MAX <= intCount + (objXSTS_WRAPPING_MATERIAL_1F.XOUT_PALLET_NUM - 1) Then
                        'If 1 <= intCount Then
                        '(既に何かしら出庫している場合)
                        Continue For
                    End If


                    '************************************************
                    '品目ﾏｽﾀ            取得
                    '************************************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.FHINMEI_CD = objXSTS_WRAPPING_MATERIAL_1F.FHINMEI_CD '品目ｺｰﾄﾞ
                    objTMST_ITEM.GET_TMST_ITEM()


                    '************************************************
                    '引当ﾊﾟﾚｯﾄ数        設定
                    '************************************************
                    Dim intPltNum As Integer = 1
                    If (objXSTS_WRAPPING_MATERIAL_1F.XPLAN_NUM - objXSTS_WRAPPING_MATERIAL_1F.XRESULT_NUM) = 1 Then
                        intPltNum = 1
                    Else
                        intPltNum = 2
                    End If
                    'intPltNum = objXSTS_WRAPPING_MATERIAL_1F.XOUT_PALLET_NUM

                    ''入出庫ﾓｰﾄﾞﾁｪｯｸ
                    Dim strEQID As String = GetOutModeID(objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO)
                    If strEQID <> "" Then
                        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                        objTSTS_EQ_CTRL.FEQ_ID = strEQID
                        objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
                        If objTSTS_EQ_CTRL.FEQ_STS = FLAG_OFF Then
                            AddToMsgLog(Now, FMSG_ID_S9000, "入庫ﾓｰﾄﾞ状態で包材出庫要求が行われました", objTMST_TRK.FBUF_NAME)
                        End If
                    End If


                    '************************************************
                    '出庫設定処理
                    '************************************************
                    intRet = SyukkoSetteiProcess(objTMST_ITEM _
                                                   , objTMST_TRK _
                                                   , intPltNum _
                                                   , objXSTS_WRAPPING_MATERIAL_1F.XMAKER_CD _
                                                   , objXSTS_WRAPPING_MATERIAL_1F.FTRK_BUF_NO _
                                                   , objXSTS_WRAPPING_MATERIAL_1F.FPLAN_KEY _
                                                   )


                    If intRet = RetCode.OK Then
                        '引当数量更新
                        objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL = objXSTS_WRAPPING_MATERIAL_1F.FTR_RES_VOL + intPltNum
                        objXSTS_WRAPPING_MATERIAL_1F.UPDATE_XSTS_WRAPPING_MATERIAL_1F()

                        Exit For
                    End If



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
        End If

        'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

    End Function

    Private Function GetOutModeID(ByVal intBufNo As Integer)
        Select Case intBufNo
            Case 1171 : Return "JOTHY03_X048294_4"
            Case 1172 : Return "JOTHY03_X048294_5"
            Case 1173 : Return "JOTHY03_X048294_6"
            Case 1174 : Return "JOTHY03_X048294_7"

            Case 2037 : Return "JOTHY04_X048294_0"

            Case 2909 : Return "JOTHY06_X048294_0"
            Case 2908 : Return "JOTHY06_X048294_1"
            Case 2907 : Return "JOTHY06_X048294_2"
            Case 2906 : Return "JOTHY06_X048294_3"
            Case 2905 : Return "JOTHY06_X048294_4"
            Case Else : Return ""

        End Select

    End Function
#End Region

#Region "  出庫設定処理                                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="objTMST_ITEM">受信電文</param>
    ''' <param name="objTMST_TRK">送信電文</param>
    ''' <param name="intPltNum">受信電文</param>
    ''' <param name="strXMAKER_CD">送信電文</param>
    ''' <param name="intFTRK_BUF_NO">受信電文</param>
    ''' <param name="strFPLAN_KEY">計画ｷｰ</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Function SyukkoSetteiProcess(ByVal objTMST_ITEM As TBL_TMST_ITEM _
                                       , ByVal objTMST_TRK As TBL_TMST_TRK _
                                       , ByVal intPltNum As Integer _
                                       , ByVal strXMAKER_CD As String _
                                       , ByVal intFTRK_BUF_NO As Integer _
                                       , ByVal strFPLAN_KEY As String _
                                       ) _
                                       As RetCode
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '************************************************
        '初期設定
        '************************************************
        Dim strAryFinalPALLET_ID(intPltNum - 1) As String           '引当てたﾊﾟﾚｯﾄID


        '************************************************
        '在庫引当
        '************************************************
        Dim blnFind As Boolean = False              '在庫存在
        Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)             '在庫引当ｸﾗｽ
        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                           'ﾊﾞｯﾌｧ№
        objSVR_100202.INTMaxPlt = intPltNum                                     '最大引当ﾊﾟﾚｯﾄ数
        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE          '更新ﾓｰﾄﾞ(通常)
        objSVR_100202.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                      '品目ｺｰﾄﾞ
        objSVR_100202.FHORYU_KUBUN = FHORYU_KUBUN_SNORMAL                       '保留区分
        objSVR_100202.XMAKER_CD = strXMAKER_CD                                  'ﾒｰｶ-ｺｰﾄﾞ
        intRet = objSVR_100202.FIND_STOCK(objTMST_ITEM.FNUM_IN_PALLET * 10)     '在庫引当(×2で大丈夫だけど、念のため×10にしておく)
        If intRet = RetCode.OK Or intRet = RetCode.NotEnough Then
            '(見つかった場合)


            '************************************************************************************************
            '在庫引当処理(ﾌﾞﾛｯｸ単位で引当てて、かつ手前棚から引当てる)
            '************************************************************************************************
            Dim objDummy As New ArrayList                           '必要ないけど、一応ｾｯﾄしておく
            intRet = ZaikoHikiateNormal(objSVR_100202 _
                                      , strAryFinalPALLET_ID _
                                      , objTMST_ITEM _
                                      , True _
                                      , True _
                                      , True _
                                      , objDummy _
                                      )
            If IsNotNull(strAryFinalPALLET_ID(0)) Then
                '(見つかった場合)
                blnFind = True
            End If


        End If


        ReDim Preserve strAryFinalPALLET_ID(1)
        If blnFind = True Then
            '(在庫が存在していた場合)


            If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then
                '(予定数を設定する場合)


                '************************************************
                '予定数、ﾊﾟﾚｯﾄ数の0ﾁｪｯｸ
                '************************************************
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
                'Call CheckYoteiPalletNum(objTMST_TRK)

                ''2017/08/08 包材出庫では不要の為ｺﾒﾝﾄｱｳﾄ　YAMAMOTO
                'Try
                '    Call CheckYoteiPalletNum(objTMST_TRK)
                'Catch ex As Exception
                '    Return RetCode.NG
                'End Try

                'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

                '************************************************
                '安川         到着予定数
                '************************************************
                Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                'objSVR_190001.FEQ_ID = strFEQ_ID                                '設備ID
                objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№



                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
                'Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                '                                      , strAryFinalPALLET_ID.Length _
                ' 

                '2017/08/27　@現地 一旦加算しないように修正する
                '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                '@@TODO　加算数を設定するように修正する　YAMAMOTO                                     )
                Dim intNowCount As Integer = 0
                'Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                'Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_YOTEI01, objTMST_TRK.XADRS_YOTEI01)

                'intNowCount = TO_INTEGER(objTSTS_EQ_CTRL_YOTEI01.FEQ_STS)

                '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

                Dim intCnt As Integer = 0
                For i As Integer = 0 To strAryFinalPALLET_ID.Length - 1
                    If IsNothing(strAryFinalPALLET_ID(i)) = False Then
                        intCnt += 1
                    End If
                Next

                Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK.FTRK_BUF_NO _
                                                      , intCnt + intNowCount _
                                                      )

                'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************


            End If


            '************************************************************************************************
            '親子判定
            '************************************************************************************************
            Dim blnOyako As Boolean = False
            If 1 <= UBound(strAryFinalPALLET_ID) Then
                intRet = HanteiOyakoFPALLET_ID(strAryFinalPALLET_ID(0), strAryFinalPALLET_ID(1))
                If intRet = RetCode.OK Then
                    blnOyako = True
                End If
            End If



            '************************************************************************
            '************************************************************************
            '出庫設定
            '************************************************************************
            '************************************************************************
            For ii As Integer = 1 To 2
                '(ﾙｰﾌﾟ:ﾍﾟｱ搬送)


                '************************************
                '作業種別       設定
                '************************************
                Dim intFSAGYOU_KIND As Integer          '作業種別
                Dim intXOYAKO_KUBUN As Integer          '親子区分
                Dim strFPALLET_ID As String = ""        '出庫ﾊﾟﾚｯﾄID
                Dim strXPALLET_ID_AITE As String = ""   '相手ﾊﾟﾚｯﾄID
                If ii = 1 Then
                    '(1PL目の場合)
                    intFSAGYOU_KIND = FSAGYOU_KIND_J58                      '作業種別
                    intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA                     '親子区分
                    strFPALLET_ID = strAryFinalPALLET_ID(0)                 '出庫ﾊﾟﾚｯﾄID
                    If blnOyako = True Then
                        strXPALLET_ID_AITE = strAryFinalPALLET_ID(1)        '相手ﾊﾟﾚｯﾄID
                    End If
                ElseIf ii = 2 Then
                    '(2PL目の場合)
                    If IsNotNull(strAryFinalPALLET_ID(1)) Then
                        '(2PL目の出庫がある場合)

                        intFSAGYOU_KIND = FSAGYOU_KIND_J58                  '作業種別
                        strFPALLET_ID = strAryFinalPALLET_ID(1)             '出庫ﾊﾟﾚｯﾄID
                        If blnOyako = True Then
                            '(親子関係の場合)
                            intXOYAKO_KUBUN = XOYAKO_KUBUN_JKO              '親子区分
                            strXPALLET_ID_AITE = strAryFinalPALLET_ID(0)    '相手ﾊﾟﾚｯﾄID
                        Else
                            '(親子関係じゃないの場合)
                            intXOYAKO_KUBUN = XOYAKO_KUBUN_JOYA             '親子区分
                        End If

                    Else
                        '(2PL目の出庫がない場合)


                        ''************************************************
                        ''ﾒｯｾｰｼﾞﾛｸﾞ出力
                        ''************************************************
                        'Call AddToMsgLog(Now, FMSG_ID_S0101, "[品目ｺｰﾄﾞ:" & objSVR_100202.FHINMEI_CD & "]" _
                        '                                   & "[保留区分:" & objSVR_100202.FHORYU_KUBUN & "]" _
                        '                                   & "[ﾒｰｶｰｺｰﾄﾞ:" & objSVR_100202.XMAKER_CD & "]" _
                        '                                   )


                        Exit For
                    End If
                End If


                '************************************
                '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
                '************************************
                Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
                objSVR_100501.FTRK_BUF_NO_TO = intFTRK_BUF_NO                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
                objSVR_100501.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
                objSVR_100501.FSAGYOU_KIND = intFSAGYOU_KIND                                '作業種別
                objSVR_100501.FTERM_ID = FTERM_ID_SKOTEI                                    '端末ID
                objSVR_100501.FUSER_ID = FUSER_ID_SKOTEI                                    'ﾕｰｻﾞｰID
                If IsNotNull(strFPLAN_KEY) Then
                    objSVR_100501.FPLAN_KEY = strFPLAN_KEY                                  '計画ｷｰ
                End If
                objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義


                '************************
                '搬送指示QUEの特定
                '************************
                Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)         '搬送指示QUE
                objTPLN_CARRY_QUE.FPALLET_ID = strFPALLET_ID                                    'ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE()                                          '特定


                '************************
                '搬送指示QUEの更新
                '************************
                objTPLN_CARRY_QUE.XOYAKO_KUBUN = intXOYAKO_KUBUN            '親子区分
                objTPLN_CARRY_QUE.XPALLET_ID_AITE = strXPALLET_ID_AITE      '相手ﾊﾟﾚｯﾄID
                objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                   '更新


            Next


            Return RetCode.OK
        Else
            '(在庫が存在していない場合)


            '************************************************
            'ﾒｯｾｰｼﾞﾛｸﾞ出力
            '************************************************
            Call AddToMsgLog(Now, FMSG_ID_S0101, "[品目ｺｰﾄﾞ:" & objSVR_100202.FHINMEI_CD & "]" _
                                               & "[保留区分:" & objSVR_100202.FHORYU_KUBUN & "]" _
                                               & "[ﾒｰｶｰｺｰﾄﾞ:" & objSVR_100202.XMAKER_CD & "]" _
                                               )


            Return RetCode.NotFound
        End If


    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
