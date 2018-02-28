'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫要求受付(生産入庫BCR設定)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310104
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
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Dim dtmNow As Date = Now                '現在日時
        Dim strST As String
        Dim strEQ_ID_RMV As String = "" '切り離し設備ID

        Try


            '************************************************
            '生産入庫設定状態               取得
            '************************************************

            Dim intBufNo As Integer

            For i As Integer = 1 To 2
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)
                Try


                    intBufNo = IIf(i = 1, 2051, 2901)
                    strST = IIf(i = 1, "D43", "D93")
                    strEQ_ID_RMV = IIf(i = 1, "JSTN2051", "JSTN2901")

                    '************************************************
                    '切り離し確認
                    '************************************************
                    Dim objTSTS_EQ_CTRL_RMV As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                    objTSTS_EQ_CTRL_RMV.FEQ_ID = strEQ_ID_RMV
                    objTSTS_EQ_CTRL_RMV.GET_TSTS_EQ_CTRL()
                    If objTSTS_EQ_CTRL_RMV.FEQ_CUT_STS = FLAG_ON Then
                        Continue For
                    End If

                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(FM)            取得
                    '************************************************
                    Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    objTMST_TRK_FM.FTRK_BUF_NO = intBufNo   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    objTMST_TRK_FM.GET_TMST_TRK()                                  '取得


                    '************************************************
                    '設備状況           取得
                    '************************************************
                    Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求前 設備ID
                    Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求後 設備ID


                    Dim strITF1 As String = ""
                    Dim strITF2 As String = ""

                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objTMST_TRK_FM.XEQ_ID_IN_FR)               '入庫要求前 設備ID
                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objTMST_TRK_FM.XEQ_ID_IN_BK)               '入庫要求後 設備ID

                    If i = 1 Then
                        Call GetITF(XMAINTE_KUBUN_D43_ITF1, XMAINTE_KUBUN_D43_ITF2, strITF1, strITF2)
                    Else
                        Call GetITF(XMAINTE_KUBUN_D93_ITF1, XMAINTE_KUBUN_D93_ITF2, strITF1, strITF2)
                    End If




                    '************************************************
                    '入庫するﾄﾗｯｷﾝｸﾞ数を確認
                    '************************************************
                    Dim intInCount As Integer
                    If objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON _
                       And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON _
                    Then
                        '(2件入庫する場合)
                        intInCount = 2
                    Else
                        '(入庫設定不可の場合)
                        Continue For
                    End If


                    '************************************************
                    'ﾄﾗｯｷﾝｸﾞ            ﾁｪｯｸ
                    '************************************************
                    Dim intCountZaiko As Integer = 0
                    Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)

                    '=======================================
                    '入庫要求部分ﾄﾗｯｷﾝｸﾞ
                    '=======================================
                    objTPRG_TRK_BUF_Check.FTRK_BUF_NO = objTMST_TRK_FM.FTRK_BUF_NO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intCountZaiko = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT_ZAIKO()        '取得
                    If intCountZaiko <> 0 Then
                        '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                        Continue For
                    End If

                    ''=======================================
                    ''一時置場部分ﾄﾗｯｷﾝｸﾞ
                    ''=======================================
                    'objTPRG_TRK_BUF_Check.CLEAR_PROPERTY()
                    'objTPRG_TRK_BUF_Check.FTRK_BUF_NO = objTMST_TRK_FM.XTRK_BUF_NO_CONV         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'intCountZaiko = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT_ZAIKO()        '取得
                    'If intCountZaiko <> 0 Then
                    '    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
                    '    Continue For
                    'End If


                    ''************************************************
                    ''予定数                 ｾｯﾄ
                    ''************************************************
                    'If IsNotNull(objXSTS_PRODUCT_IN.XKINKYU_BUF_TO) Then
                    '    '(緊急時入庫設定の場合)

                    '    '=======================================
                    '    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)            取得
                    '    '=======================================
                    '    Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                    '    objTMST_TRK_TO.FTRK_BUF_NO = objXSTS_PRODUCT_IN.XKINKYU_BUF_TO  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    '    objTMST_TRK_TO.GET_TMST_TRK()                                   '取得
                    '    If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
                    '        '(予定数が存在している場合)

                    '        '=======================================
                    '        '予定数、ﾊﾟﾚｯﾄ数の0ﾁｪｯｸ
                    '        '=======================================
                    '        Call CheckYoteiPalletNum(objTMST_TRK_TO)

                    '        '=======================================
                    '        '安川         到着予定数
                    '        '=======================================
                    '        Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
                    '        objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
                    '        objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
                    '        Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                    '                                              , 2 _
                    '                                              )

                    '    End If

                    'End If

                    If strITF1 = "00000000000000" Then Continue For
                    If strITF2 = "00000000000000" Then Continue For

                    '************************************************
                    '品目ﾏｽﾀ                取得
                    '************************************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.XITF_CD = strITF1         'ITFｺｰﾄﾞ

                    Try
                        intRet = objTMST_ITEM.GET_TMST_ITEM(False)                                    '取得
                    Catch ex As Exception
                        AddToMsgLog(Now, "8000", "ITFコードが品目マスタから複数抽出されました", strST, strITF1)
                        Continue For
                    End Try


                    If intRet = RetCode.NotFound Then
                        AddToMsgLog(Now, "8000", "ITFコードが品目マスタに存在しません", strST, strITF1)
                        Continue For
                    End If

                    If strITF1 <> strITF2 Then
                        AddToMsgLog(Now, "8000", "ITFコードが一致しません", strST, "前:" & strITF1, "後:" & strITF2)
                        Continue For
                    End If


                    '************************************************
                    '在庫発生日時           取得
                    '************************************************
                    Dim strDSPARRIVE_DT As String = Format(Now, GAMEN_DATE_FORMAT_02)


                    '***********************************************
                    '入庫設定用配列作成
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
                    Dim DSPARRIVE_DT As Integer = 12          '在庫発生日時
                    Dim XDSPPROD_LINE As Integer = 13         '生産ﾗｲﾝ№
                    Dim XDSPMAKER_CD As Integer = 14          'ﾒｰｶｺｰﾄﾞ
                    Dim XDSPKENSA_KUBUN As Integer = 15       '検査区分
                    Dim DSPHORYU_KUBUN As Integer = 16        '保留区分
                    Dim DSPIN_KUBUN As Integer = 17           '入庫区分
                    Dim XDSPKENPIN_KUBUN As Integer = 18      '検品区分
                    Dim XDSPPALLET_ID_KO As Integer = 19      'ﾊﾟﾚｯﾄID(子)
                    Dim XDSPTR_VOL_KO As Integer = 20         '搬送管理量(子)
                    Dim XDSPTANA_BLOCK As Integer = 21        '棚ﾌﾞﾛｯｸ
                    Dim XDSPST_TO_ARRAY01 As Integer = 22     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
                    Dim XDSPST_TO_ARRAY02 As Integer = 23     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02
                    Dim strDenbunDtl(23) As String
                    strDenbunDtl(DSPTERM_ID) = FTERM_ID_SKOTEI                                      '端末ID
                    strDenbunDtl(DSPUSER_ID) = FUSER_ID_SKOTEI                                      'ﾕｰｻﾞｰID
                    strDenbunDtl(DSPREASON) = ""                                                    '理由
                    strDenbunDtl(DSPST_FM) = TO_STRING(intBufNo)             '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    strDenbunDtl(DSPST_TO) = TO_STRING(FTRK_BUF_NO_J9000)                           '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    strDenbunDtl(DSPPALLET_ID) = ""                                                 'ﾊﾟﾚｯﾄID
                    strDenbunDtl(DSPLOT_NO_STOCK) = ""                                              '在庫ﾛｯﾄ№
                    strDenbunDtl(DSPSAGYOU_KIND) = TO_STRING(IIf(i = 1, "81", "82"))                      '作業種別
                    strDenbunDtl(DSPHINMEI_CD) = TO_STRING(objTMST_ITEM.FHINMEI_CD)           '品名ｺｰﾄﾞ
                    strDenbunDtl(DSPTR_VOL) = TO_STRING(objTMST_ITEM.FNUM_IN_PALLET)                '搬送管理量
                    strDenbunDtl(XDSPIN_KIND) = TO_STRING(XDSPIN_KIND_PAIR)                         '入庫種別
                    strDenbunDtl(XDSPIN_SITEI) = TO_STRING(XDSPIN_SITEI_NON)                        '入庫指定
                    strDenbunDtl(DSPARRIVE_DT) = strDSPARRIVE_DT                                    '在庫発生日時
                    strDenbunDtl(XDSPPROD_LINE) = TO_STRING(IIf(i = 1, "D43_IN", "D93_IN"))          '生産ﾗｲﾝ№
                    strDenbunDtl(XDSPMAKER_CD) = TO_STRING(objTMST_ITEM.XMAKER_CD)            'ﾒｰｶｺｰﾄﾞ
                    strDenbunDtl(XDSPKENSA_KUBUN) = TO_STRING(XKENSA_KUBUN_J_MI)      '検査区分
                    strDenbunDtl(DSPHORYU_KUBUN) = TO_STRING("0")       '保留区分
                    strDenbunDtl(DSPIN_KUBUN) = TO_STRING(FIN_KUBUN_J01)             '入庫区分
                    strDenbunDtl(XDSPKENPIN_KUBUN) = TO_STRING(XKENPIN_KUBUN_J_MI)    '検品区分
                    strDenbunDtl(XDSPTR_VOL_KO) = TO_STRING(objTMST_ITEM.FNUM_IN_PALLET)            '搬送管理量(子)
                    strDenbunDtl(XDSPTANA_BLOCK) = ""                                               '棚ﾌﾞﾛｯｸ
                    strDenbunDtl(XDSPST_TO_ARRAY01) = ""                                            '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
                    strDenbunDtl(XDSPST_TO_ARRAY02) = ""                                            '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02



                    '************************************************************************************************
                    '入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
                    '************************************************************************************************
                    intRet = SVR_400001_Process(strDenbunDtl, "", "")


                    ''***********************************************
                    ''設備状況     要求状態設定
                    ''***********************************************
                    'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_FR, FEQ_REQ_STS_JIN_SEISAN_ON)
                    'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_BK, FEQ_REQ_STS_JIN_SEISAN_ON)
                    'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_FR, FEQ_REQ_STS_JIN_SEISAN_ON)
                    'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_BK, FEQ_REQ_STS_JIN_SEISAN_ON)


                    '生産入庫登録（BCR）追加更新
                    Dim objXSTS_BCR As New TBL_XSTS_BCR(Owner, ObjDb, ObjDbLog)
                    objXSTS_BCR.FTRK_BUF_NO = intBufNo
                    objXSTS_BCR.FHINMEI_CD = TO_STRING(objTMST_ITEM.FHINMEI_CD)
                    intRet = objXSTS_BCR.GET_XSTS_BCR(False)
                    If intRet = RetCode.OK Then
                        '更新
                        objXSTS_BCR.XCOUNT_PL_IN = objXSTS_BCR.XCOUNT_PL_IN + 2
                        objXSTS_BCR.XCOUNT_IN = objXSTS_BCR.XCOUNT_IN + objTMST_ITEM.FNUM_IN_PALLET * 2
                        objXSTS_BCR.FLAST_DT = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        objXSTS_BCR.UPDATE_XSTS_BCR()
                    End If

                    If intRet = RetCode.NotFound Then
                        '追加
                        objXSTS_BCR.XCOUNT_PL_IN = 2
                        objXSTS_BCR.XCOUNT_IN = objTMST_ITEM.FNUM_IN_PALLET * 2
                        objXSTS_BCR.XSTART_DT = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        objXSTS_BCR.FLAST_DT = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        objXSTS_BCR.XITF_CD = strITF1
                        objXSTS_BCR.ADD_XSTS_BCR()
                    End If


                    '************************
                    '正常完了
                    '************************
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "[搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_TRK_FM.XTRK_BUF_NO_CONV) & "]" _
                                     )


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



#Region "  ﾒｲﾝ処理                                                                              _20130521"
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
    '    'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Dim dtmNow As Date = Now                '現在日時
    '    Try


    '        '************************************************
    '        '生産入庫設定状態               取得
    '        '************************************************
    '        Dim strSQL As String = ""
    '        Dim objAryXSTS_PRODUCT_IN As New TBL_XSTS_PRODUCT_IN(Owner, ObjDb, ObjDbLog)
    '        strSQL &= vbCrLf & " SELECT "
    '        strSQL &= vbCrLf & "    * "
    '        strSQL &= vbCrLf & " FROM "
    '        strSQL &= vbCrLf & "    XSTS_PRODUCT_IN "
    '        strSQL &= vbCrLf & " WHERE "
    '        strSQL &= vbCrLf & "    XPROGRESS = " & TO_STRING(XPROGRESS_START)
    '        strSQL &= vbCrLf & "  "
    '        objAryXSTS_PRODUCT_IN.USER_SQL = strSQL                     'SQL文
    '        intRet = objAryXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN_USER()   '取得
    '        If intRet = RetCode.OK Then
    '            '(見つかった場合)
    '            For Each objXSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN In objAryXSTS_PRODUCT_IN.ARYME
    '                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


    '                '************************************************
    '                '設備状況           取得
    '                '************************************************
    '                Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
    '                objTMST_TRK.FTRK_BUF_NO = objXSTS_PRODUCT_IN.FTRK_BUF_NO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                objTMST_TRK.GET_TMST_TRK()                                  '取得


    '                '************************************************
    '                '設備状況           取得
    '                '************************************************
    '                Dim objTSTS_EQ_CTRL_IN_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求前 設備ID
    '                Dim objTSTS_EQ_CTRL_IN_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)           '入庫要求後 設備ID
    '                Dim objTSTS_EQ_CTRL_HASU_FR As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数前     設備ID
    '                Dim objTSTS_EQ_CTRL_HASU_BK As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)         '端数後     設備ID
    '                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_FR, objTMST_TRK.XEQ_ID_IN_FR)               '入庫要求前 設備ID
    '                Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_IN_BK, objTMST_TRK.XEQ_ID_IN_BK)               '入庫要求後 設備ID
    '                If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_FR, objTMST_TRK.XEQ_ID_HASU_FR)       '端数前     設備ID
    '                Else
    '                    objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = 0
    '                End If
    '                If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then
    '                    Call IniTSTS_EQ_CTRL(objTSTS_EQ_CTRL_HASU_BK, objTMST_TRK.XEQ_ID_HASU_BK)       '端数後     設備ID
    '                Else
    '                    objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = 0
    '                End If


    '                ''************************************************
    '                ''要求状態           ﾁｪｯｸ
    '                ''************************************************
    '                'If Not ( _
    '                '           objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
    '                '       And objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
    '                '       And objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
    '                '       And objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS = FEQ_REQ_STS_SOFF _
    '                '       ) _
    '                '    Then
    '                '    '(既に何かしらの作業が行われていた場合)
    '                '    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                '                     FLOG_DATA_TRN_SEND_NORMAL _
    '                '                     & "要求ﾌﾗｸﾞがOFFでない為、作業は行わない。" _
    '                '                     & "[設備ID(入庫要求前):" & TO_STRING(objTSTS_EQ_CTRL_IN_FR.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_IN_FR.FEQ_REQ_STS & "]" _
    '                '                     & "[設備ID(入庫要求後):" & TO_STRING(objTSTS_EQ_CTRL_IN_BK.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_IN_BK.FEQ_REQ_STS & "]" _
    '                '                     & "[設備ID(端数前):" & TO_STRING(objTSTS_EQ_CTRL_HASU_FR.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_HASU_FR.FEQ_REQ_STS & "]" _
    '                '                     & "[設備ID(端数後):" & TO_STRING(objTSTS_EQ_CTRL_HASU_BK.FEQ_ID) & "   要求状態:" & objTSTS_EQ_CTRL_HASU_BK.FEQ_REQ_STS & "]" _
    '                '                     )
    '                '    Continue For
    '                'End If


    '                '************************************************
    '                '入庫するﾄﾗｯｷﾝｸﾞ数を確認
    '                '************************************************
    '                Dim intInCount As Integer
    '                If (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
    '                Or (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
    '                Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_IN_BK.FEQ_STS = FLAG_ON) _
    '                Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON And objTSTS_EQ_CTRL_HASU_BK.FEQ_STS = FLAG_ON) _
    '                Then
    '                    '(2件入庫する場合)
    '                    intInCount = 2
    '                ElseIf (objTSTS_EQ_CTRL_IN_FR.FEQ_STS = FLAG_ON) _
    '                    Or (objTSTS_EQ_CTRL_HASU_FR.FEQ_STS = FLAG_ON) _
    '                    Then
    '                    '(1件入庫する場合)
    '                    Continue For
    '                    'intInCount = 1
    '                Else
    '                    '(入庫設定不可の場合)
    '                    Continue For
    '                End If


    '                '************************************************
    '                'ﾄﾗｯｷﾝｸﾞ            ﾁｪｯｸ
    '                '************************************************
    '                Dim intCountZaiko As Integer = 0
    '                Dim objTPRG_TRK_BUF_Check As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)

    '                '=======================================
    '                '入庫要求部分ﾄﾗｯｷﾝｸﾞ
    '                '=======================================
    '                objTPRG_TRK_BUF_Check.FTRK_BUF_NO = objTMST_TRK.FTRK_BUF_NO             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                intCountZaiko = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT_ZAIKO()    '取得
    '                If intCountZaiko <> 0 Then
    '                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
    '                    Continue For
    '                End If

    '                '=======================================
    '                '一時置場部分ﾄﾗｯｷﾝｸﾞ
    '                '=======================================
    '                objTPRG_TRK_BUF_Check.CLEAR_PROPERTY()
    '                objTPRG_TRK_BUF_Check.FTRK_BUF_NO = objTMST_TRK.XTRK_BUF_NO_CONV        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                intCountZaiko = objTPRG_TRK_BUF_Check.GET_TPRG_TRK_BUF_COUNT_ZAIKO()    '取得
    '                If intCountZaiko <> 0 Then
    '                    '(何かしらのﾄﾗｯｷﾝｸﾞがある場合)
    '                    Continue For
    '                End If



    '                '************************************************
    '                '品目ﾏｽﾀ                取得
    '                '************************************************
    '                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
    '                objTMST_ITEM.FHINMEI_CD = objXSTS_PRODUCT_IN.FHINMEI_CD         '品名ｺｰﾄﾞ
    '                objTMST_ITEM.GET_TMST_ITEM()                                    '取得


    '                '***********************************************
    '                '入庫設定用配列作成
    '                '***********************************************
    '                Dim DSPTERM_ID As Integer = 0             '端末ID
    '                Dim DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    '                Dim DSPREASON As Integer = 2              '理由
    '                Dim DSPST_FM As Integer = 3               '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                Dim DSPST_TO As Integer = 4               '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                Dim DSPPALLET_ID As Integer = 5           'ﾊﾟﾚｯﾄID
    '                Dim DSPLOT_NO_STOCK As Integer = 6        '在庫ﾛｯﾄ№
    '                Dim DSPSAGYOU_KIND As Integer = 7         '作業種別
    '                Dim DSPHINMEI_CD As Integer = 8           '品名ｺｰﾄﾞ
    '                Dim DSPTR_VOL As Integer = 9              '搬送管理量
    '                Dim XDSPIN_KIND As Integer = 10           '入庫種別
    '                Dim XDSPIN_SITEI As Integer = 11          '入庫指定
    '                Dim DSPARRIVE_DT As Integer = 12          '在庫発生日時
    '                Dim XDSPPROD_LINE As Integer = 13         '生産ﾗｲﾝ№
    '                Dim XDSPMAKER_CD As Integer = 14          'ﾒｰｶｺｰﾄﾞ
    '                Dim XDSPKENSA_KUBUN As Integer = 15       '検査区分
    '                Dim DSPHORYU_KUBUN As Integer = 16        '保留区分
    '                Dim DSPIN_KUBUN As Integer = 17           '入庫区分
    '                Dim XDSPKENPIN_KUBUN As Integer = 18      '検品区分
    '                Dim XDSPTR_VOL_KO As Integer = 19         '搬送管理量(子)
    '                Dim XDSPTANA_BLOCK As Integer = 20        '棚ﾌﾞﾛｯｸ
    '                Dim XDSPST_TO_ARRAY01 As Integer = 21     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
    '                Dim XDSPST_TO_ARRAY02 As Integer = 22     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02
    '                Dim strDenbunDtl(22) As String
    '                strDenbunDtl(DSPTERM_ID) = FTERM_ID_SKOTEI                              '端末ID
    '                strDenbunDtl(DSPUSER_ID) = FUSER_ID_SKOTEI                              'ﾕｰｻﾞｰID
    '                strDenbunDtl(DSPREASON) = ""                                            '理由
    '                strDenbunDtl(DSPST_FM) = TO_STRING(objTMST_TRK.XTRK_BUF_NO_CONV)        '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                strDenbunDtl(DSPST_TO) = TO_STRING(FTRK_BUF_NO_J9000)                   '搬送先STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '                strDenbunDtl(DSPPALLET_ID) = ""                                         'ﾊﾟﾚｯﾄID
    '                strDenbunDtl(DSPLOT_NO_STOCK) = ""                                      '在庫ﾛｯﾄ№
    '                strDenbunDtl(DSPSAGYOU_KIND) = TO_STRING(FSAGYOU_KIND_J51)              '作業種別
    '                strDenbunDtl(DSPHINMEI_CD) = TO_STRING(objXSTS_PRODUCT_IN.FHINMEI_CD)   '品名ｺｰﾄﾞ
    '                strDenbunDtl(DSPTR_VOL) = TO_STRING(objTMST_ITEM.FNUM_IN_PALLET)        '搬送管理量
    '                strDenbunDtl(XDSPIN_KIND) = TO_STRING(XDSPIN_KIND_PAIR)                 '入庫種別
    '                strDenbunDtl(XDSPIN_SITEI) = TO_STRING(XDSPIN_SITEI_NON)                '入庫指定
    '                strDenbunDtl(DSPARRIVE_DT) = Format(dtmNow, GAMEN_DATE_FORMAT_02)       '在庫発生日時
    '                strDenbunDtl(XDSPPROD_LINE) = TO_STRING(objXSTS_PRODUCT_IN.XPROD_LINE)  '生産ﾗｲﾝ№
    '                strDenbunDtl(XDSPMAKER_CD) = ""                                         'ﾒｰｶｺｰﾄﾞ
    '                strDenbunDtl(XDSPKENSA_KUBUN) = TO_STRING(XKENSA_KUBUN_J_MI)            '検査区分
    '                strDenbunDtl(DSPHORYU_KUBUN) = TO_STRING(FHORYU_KUBUN_SNORMAL)          '保留区分
    '                strDenbunDtl(DSPIN_KUBUN) = TO_STRING(FIN_KUBUN_J01)                    '入庫区分
    '                strDenbunDtl(XDSPKENPIN_KUBUN) = TO_STRING(XKENPIN_KUBUN_J_MI)          '検品区分
    '                strDenbunDtl(XDSPTR_VOL_KO) = TO_STRING(objTMST_ITEM.FNUM_IN_PALLET)    '搬送管理量(子)
    '                strDenbunDtl(XDSPTANA_BLOCK) = ""                                       '棚ﾌﾞﾛｯｸ
    '                strDenbunDtl(XDSPST_TO_ARRAY01) = ""                                    '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№01
    '                strDenbunDtl(XDSPST_TO_ARRAY02) = ""                                    '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№02


    '                '************************************************************************************************
    '                '入庫設定(SVR_400001)STに一度ﾄﾗｯｷﾝｸﾞだけを作成するﾊﾞｰｼﾞｮﾝ
    '                '************************************************************************************************
    '                intRet = SVR_400001_Process(strDenbunDtl, "", "")


    '                ''***********************************************
    '                ''設備状況     要求状態設定
    '                ''***********************************************
    '                'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_FR, FEQ_REQ_STS_JIN_SEISAN_ON)
    '                'Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_IN_BK, FEQ_REQ_STS_JIN_SEISAN_ON)
    '                'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_FR) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_FR, FEQ_REQ_STS_JIN_SEISAN_ON)
    '                'If IsNotNull(objTMST_TRK.XEQ_ID_HASU_BK) Then Call Set_FEQ_REQ_STS(objTMST_TRK.XEQ_ID_HASU_BK, FEQ_REQ_STS_JIN_SEISAN_ON)


    '                '************************
    '                '正常完了
    '                '************************
    '                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '                                 FLOG_DATA_TRN_SEND_NORMAL _
    '                                 & "[搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_TRK.XTRK_BUF_NO_CONV) & "]" _
    '                                 )


    '            Next
    '        End If


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
#Region "  ﾒｲﾝ処理                                                                              _old"
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

    Private Sub GetITF(ByVal strXMAINTE_KUBUN1 As String, ByVal strXMAINTE_KUBUN2 As String, ByRef strITF1 As String, ByRef strITF2 As String)

        Dim strSQL As String                            'SQL文
        Dim objDataSet As New DataSet
        Dim strDataSetName As String

        '********************************************************************
        ' DB情報取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "      A.XMAINTE_NAME "
        strSQL &= vbCrLf & "     ,A.FEQ_ID01 "
        strSQL &= vbCrLf & "     ,B01.FEQ_STS "
        strSQL &= vbCrLf & "     ,A.XMAINTE_ORDER "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "      (SELECT XDSP_PLC_MAINTE.XEQ_ID_MAINTE  "
        strSQL &= vbCrLf & "             ,SUBSTR(XDSP_PLC_MAINTE.XEQ_ID_MAINTE,0,18) AS FEQ_ID01  "
        strSQL &= vbCrLf & "             ,XDSP_PLC_MAINTE.XMAINTE_NAME "
        strSQL &= vbCrLf & "             ,XDSP_PLC_MAINTE.XMAINTE_ORDER "
        strSQL &= vbCrLf & "       FROM XDSP_PLC_MAINTE "
        strSQL &= vbCrLf & "       WHERE XDSP_PLC_MAINTE.XMAINTE_KUBUN = '" & strXMAINTE_KUBUN1 & "'" & "OR XDSP_PLC_MAINTE.XMAINTE_KUBUN = '" & strXMAINTE_KUBUN2 & "'"
        strSQL &= vbCrLf & "      ) A "
        strSQL &= vbCrLf & "      ,TSTS_EQ_CTRL B01 "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "       1 = 1"
        strSQL &= vbCrLf & "   AND A.FEQ_ID01 = B01.FEQ_ID "
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "       A.FEQ_ID01"


        '-----------------------
        '抽出
        '-----------------------
        ObjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "ITF_DATA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)


        Dim strITF As String
        Dim txtITF1_1 As String
        Dim txtITF1_2 As String
        Dim txtITF1_3 As String
        Dim txtITF1_4 As String
        Dim txtITF2_1 As String
        Dim txtITF2_2 As String
        Dim txtITF2_3 As String
        Dim txtITF2_4 As String
        Dim txtITF1_1F As String
        Dim txtITF1_2F As String
        Dim txtITF1_3F As String
        Dim txtITF1_4F As String
        Dim txtITF2_1F As String
        Dim txtITF2_2F As String
        Dim txtITF2_3F As String
        Dim txtITF2_4F As String


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then



            If strXMAINTE_KUBUN1 = XMAINTE_KUBUN_D43_ITF1 Then
                txtITF1_1 = Hex(objDataSet.Tables(strDataSetName).Rows(0).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_2 = Hex(objDataSet.Tables(strDataSetName).Rows(1).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_3 = Hex(objDataSet.Tables(strDataSetName).Rows(2).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_4 = Hex(objDataSet.Tables(strDataSetName).Rows(3).Item("FEQ_STS")).PadLeft(4, "0"c)

                txtITF1_1 = txtITF1_1.Substring(txtITF1_1.Length - 4, 4)
                txtITF1_2 = txtITF1_2.Substring(txtITF1_2.Length - 4, 4)
                txtITF1_3 = txtITF1_3.Substring(txtITF1_3.Length - 4, 4)
                txtITF1_4 = txtITF1_4.Substring(txtITF1_4.Length - 4, 4)

                strITF = ""
                strITF &= txtITF1_4.PadLeft(4, "0"c)
                strITF &= txtITF1_3.PadLeft(4, "0"c)
                strITF &= txtITF1_2.PadLeft(4, "0"c)
                strITF &= txtITF1_1.PadLeft(4, "0"c)

                strITF = Mid(strITF, 3)

                strITF2 = strITF

            ElseIf strXMAINTE_KUBUN1 = XMAINTE_KUBUN_D93_ITF1 Then
                txtITF2_1 = Hex(objDataSet.Tables(strDataSetName).Rows(0).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_2 = Hex(objDataSet.Tables(strDataSetName).Rows(1).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_3 = Hex(objDataSet.Tables(strDataSetName).Rows(2).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_4 = Hex(objDataSet.Tables(strDataSetName).Rows(3).Item("FEQ_STS")).PadLeft(4, "0"c)

                txtITF2_1 = txtITF2_1.Substring(txtITF2_1.Length - 4, 4)
                txtITF2_2 = txtITF2_2.Substring(txtITF2_2.Length - 4, 4)
                txtITF2_3 = txtITF2_3.Substring(txtITF2_3.Length - 4, 4)
                txtITF2_4 = txtITF2_4.Substring(txtITF2_4.Length - 4, 4)

                strITF = ""
                strITF &= txtITF2_4.PadLeft(2, "0"c)
                strITF &= txtITF2_3.PadLeft(4, "0"c)
                strITF &= txtITF2_2.PadLeft(4, "0"c)
                strITF &= txtITF2_1.PadLeft(4, "0"c)

                strITF = Mid(strITF, 3)

                strITF2 = strITF
            End If


            If strXMAINTE_KUBUN2 = XMAINTE_KUBUN_D43_ITF2 Then

                txtITF1_1F = Hex(objDataSet.Tables(strDataSetName).Rows(4).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_2F = Hex(objDataSet.Tables(strDataSetName).Rows(5).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_3F = Hex(objDataSet.Tables(strDataSetName).Rows(6).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF1_4F = Hex(objDataSet.Tables(strDataSetName).Rows(7).Item("FEQ_STS")).PadLeft(4, "0"c)

                txtITF1_1F = txtITF1_1F.Substring(txtITF1_1F.Length - 4, 4)
                txtITF1_2F = txtITF1_2F.Substring(txtITF1_2F.Length - 4, 4)
                txtITF1_3F = txtITF1_3F.Substring(txtITF1_3F.Length - 4, 4)
                txtITF1_4F = txtITF1_4F.Substring(txtITF1_4F.Length - 4, 4)

                strITF = ""
                strITF &= txtITF1_4F.PadLeft(4, "0"c)
                strITF &= txtITF1_3F.PadLeft(4, "0"c)
                strITF &= txtITF1_2F.PadLeft(4, "0"c)
                strITF &= txtITF1_1F.PadLeft(4, "0"c)

                strITF = Mid(strITF, 3)

                strITF1 = strITF

            ElseIf strXMAINTE_KUBUN2 = XMAINTE_KUBUN_D93_ITF2 Then
                txtITF2_1F = Hex(objDataSet.Tables(strDataSetName).Rows(4).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_2F = Hex(objDataSet.Tables(strDataSetName).Rows(5).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_3F = Hex(objDataSet.Tables(strDataSetName).Rows(6).Item("FEQ_STS")).PadLeft(4, "0"c)
                txtITF2_4F = Hex(objDataSet.Tables(strDataSetName).Rows(7).Item("FEQ_STS")).PadLeft(4, "0"c)

                txtITF2_1F = txtITF2_1F.Substring(txtITF2_1F.Length - 4, 4)
                txtITF2_2F = txtITF2_2F.Substring(txtITF2_2F.Length - 4, 4)
                txtITF2_3F = txtITF2_3F.Substring(txtITF2_3F.Length - 4, 4)
                txtITF2_4F = txtITF2_4F.Substring(txtITF2_4F.Length - 4, 4)

                strITF = ""
                strITF &= txtITF2_4F.PadLeft(2, "0"c)
                strITF &= txtITF2_3F.PadLeft(4, "0"c)
                strITF &= txtITF2_2F.PadLeft(4, "0"c)
                strITF &= txtITF2_1F.PadLeft(4, "0"c)

                strITF = Mid(strITF, 3)

                strITF1 = strITF
            End If
        Else


        End If

    End Sub




    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
