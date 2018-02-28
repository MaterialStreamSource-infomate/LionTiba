'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】倉替出庫設定子画面
' 【作成】SIT
'**********************************************************************************************
#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303041
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrFTRK_BUF_NO_Disp As String            '出庫ST

    Protected mstrFPALLET_ID_Front_Pare() As String         'ﾊﾟﾚｯﾄID 手前 ﾍﾟｱ
    Protected mstrFPALLET_ID_Front_Single() As String       'ﾊﾟﾚｯﾄID 手前 ｼﾝｸﾞﾙ
    Protected mstrFPALLET_ID_Back_Pare() As String          'ﾊﾟﾚｯﾄID 奥 ﾍﾟｱ
    Protected mstrFPALLET_ID_Back_Single() As String        'ﾊﾟﾚｯﾄID 奥 ｼﾝｸﾞﾙ

    ' ''Protected mstrFHINMEI_CD As String                  '品名記号
    ' ''Protected mstrFHINMEI As String                     '品名
    ' ''Protected mstrXKENPIN_KUBUN As String               '検品区分
    ' ''Protected mstrXKENPIN_KUBUN_Disp As String          '検品区分(表示用)
    ' ''Protected mblnXKENPIN_Flag As Boolean               '検品ｴﾘｱ ﾌﾗｸﾞ
    ' ''Protected mstrXPROD_LINE As String                  '生産ﾗｲﾝNo.
    ' ''Protected mstrXPROD_LINE_Disp As String             '生産ﾗｲﾝNo.(表示用)
    ' ''Protected mintFPROGRESS As Integer                  '進捗状況
    ' ''Protected mstrFEQ_ID As String                      '設備ID
    ' ''Protected mintDSPGRID_DISPLAYINDEX As Integer       '表示順序

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        KurakaeSet_Click                '倉替設定
        CancelBtn_Click                 'ｷｬﾝｾﾙ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ST</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFTRK_BUF_NO_Disp() As String
        Get
            Return mstrFTRK_BUF_NO_Disp
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID 手前 ﾍﾟｱ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID_Front_Pare() As String()
        Get
            Return mstrFPALLET_ID_Front_Pare
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID_Front_Pare = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID 手前 ｼﾝｸﾞﾙ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID_Front_Single() As String()
        Get
            Return mstrFPALLET_ID_Front_Single
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID_Front_Single = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID 奥 ﾍﾟｱ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID_Back_Pare() As String()
        Get
            Return mstrFPALLET_ID_Back_Pare
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID_Back_Pare = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID 奥 ｼﾝｸﾞﾙ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFPALLET_ID_Back_Single() As String()
        Get
            Return mstrFPALLET_ID_Back_Single
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID_Back_Single = value
        End Set
    End Property

#End Region

#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_310011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　倉替設定   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdKurakaeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKurakaeSet.Click
        Try

            Call cmdKurakaeSet_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_303041_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '===================================
        '入庫ST ｾｯﾄ
        '===================================
        lblIN_ST.Text = mstrFTRK_BUF_NO_Disp

        '===================================
        '倉替先ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_Kurakae, False, -1)


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        lblIN_ST.Dispose()
        cboFTRK_BUF_NO_Kurakae.Dispose()

    End Sub
#End Region
#Region "　倉替設定        ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 倉替設定 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdKurakaeSet_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KurakaeSet_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If InquiryOut() = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ           ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CancelBtn_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.KurakaeSet_Click
                '(倉替設定の場合)

                '========================================
                '倉替先
                '========================================
                If cboFTRK_BUF_NO_Kurakae.Text = "" Then
                    '（入力無しの場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303041_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False


            Case menmCheckCase.CancelBtn_Click
                '(ｷｬﾝｾﾙの場合)

                blnCheckErr = False

        End Select


        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If


        Return blnReturn

    End Function
#End Region

#Region "  ｿｹｯﾄ送信02   倉替出庫処理            　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02   倉替出庫処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InquiryOut() As Boolean
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303041_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '********************************************************************
        ' 出庫在庫ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        'Dim udtOUT_STOCK() As STOCK_DATA = Nothing      '出庫在庫ﾃﾞｰﾀ用構造体
        Dim strSndTlgrm() As String = Nothing           '送信電文文字列
        Dim intHairetu As Integer = 0                   '配列数
        'Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim strXADRS_YOTEI = ""                         '予定数ｱﾄﾞﾚｽ
        Dim strOUTST_NO As String = ""                  'ｽﾃｰｼｮﾝID
        Dim blnPareFlag As Boolean = False              'ﾍﾟｱ出庫ﾌﾗｸﾞ

        Dim strDSPPALLET_ID = ""                        'ﾊﾟﾚｯﾄID
        Dim strXDSPPALLET_ID_KO = ""                    'ﾊﾟﾚｯﾄID(子)
        Dim strFTR_IDOU = ""                            '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        strOUTST_NO = mstrFTRK_BUF_NO                   '出庫先ST

        '********************************************************************
        '予定設備IDの取得
        '********************************************************************
        Dim intRet As RetCode
        Dim objTBL_TMST_TRK As TBL_TMST_TRK                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTBL_TMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)

        objTBL_TMST_TRK.FTRK_BUF_NO = mstrFTRK_BUF_NO   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        intRet = objTBL_TMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(値がある時)
            If Not objTBL_TMST_TRK.XADRS_YOTEI01 Is Nothing Then
                strXADRS_YOTEI = objTBL_TMST_TRK.XADRS_YOTEI01                  '予定数ｱﾄﾞﾚｽ
            Else
                strXADRS_YOTEI = ""
            End If

        Else
            '(読めなかった時)
            strXADRS_YOTEI = ""
        End If

        '********************************************************************
        '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.の取得
        '********************************************************************
        strFTR_IDOU = TO_STRING(cboFTRK_BUF_NO_Kurakae.SelectedValue)                         '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        '********************************************************************
        '予定数の計算
        '********************************************************************
        Dim intYOTEI_NUM As Integer = 0     '予定数

        If Not mstrFPALLET_ID_Front_Pare Is Nothing Then                        '手前 ﾍﾟｱ
            intYOTEI_NUM = intYOTEI_NUM + UBound(mstrFPALLET_ID_Front_Pare) + 1
        End If
        If Not mstrFPALLET_ID_Front_Single Is Nothing Then                      '手前 ｼﾝｸﾞﾙ
            intYOTEI_NUM = intYOTEI_NUM + UBound(mstrFPALLET_ID_Front_Single) + 1
        End If
        If Not mstrFPALLET_ID_Back_Pare Is Nothing Then                         '奥 ﾍﾟｱ
            intYOTEI_NUM = intYOTEI_NUM + UBound(mstrFPALLET_ID_Back_Pare) + 1
        End If
        If Not mstrFPALLET_ID_Back_Single Is Nothing Then                       '奥 ｼﾝｸﾞﾙ
            intYOTEI_NUM = intYOTEI_NUM + UBound(mstrFPALLET_ID_Back_Single) + 1
        End If


        '********************************************************************
        ' 倉替出庫予約用 電文作成
        '********************************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))    'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        objTelegram.SETIN_DATA("DSPPALLET_ID", "")                                                      'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                '出庫先ST
        objTelegram.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                  'ﾊﾟﾚｯﾄID(子)
        objTelegram.SETIN_DATA("XDSPYOTEI_NUM", TO_STRING(intYOTEI_NUM))                                '予定数
        objTelegram.SETIN_DATA("XDSPYOTEI_EQ_ID", strXADRS_YOTEI)                                       '予定設備ID
        objTelegram.SETIN_DATA("XDSPTR_IDOU", strFTR_IDOU)                                              '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        '送信電文
        ReDim strSndTlgrm(0)
        objTelegram.MAKE_TELEGRAM()
        strSndTlgrm(0) = objTelegram.TELEGRAM_MAKED

        '********************************************************************
        ' 倉替出庫用 電文作成(手前 ﾍﾟｱ)
        '********************************************************************
        If Not mstrFPALLET_ID_Front_Pare Is Nothing Then
            For ii As Integer = 0 To mstrFPALLET_ID_Front_Pare.Length - 1 Step 2
                '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)

                If ii + 1 <= mstrFPALLET_ID_Front_Pare.Length - 1 Then
                    blnPareFlag = True

                    strDSPPALLET_ID = mstrFPALLET_ID_Front_Pare(ii)
                    strXDSPPALLET_ID_KO = mstrFPALLET_ID_Front_Pare(ii + 1)
                Else
                    blnPareFlag = False

                    strDSPPALLET_ID = mstrFPALLET_ID_Front_Pare(ii)
                End If

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                                          'ﾊﾟﾚｯﾄID(親)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST
                If blnPareFlag = True Then
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", strXDSPPALLET_ID_KO)                              'ﾊﾟﾚｯﾄID(子)
                Else
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")                                               'ﾊﾟﾚｯﾄID(子)
                End If
                objTelegramSub.SETIN_DATA("XDSPTR_IDOU", strFTR_IDOU)                                               '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                             '送信電文

            Next
        End If

        '********************************************************************
        ' 倉替出庫用 電文作成(手前 ｼﾝｸﾞﾙ)
        '********************************************************************
        If Not mstrFPALLET_ID_Front_Single Is Nothing Then
            For ii As Integer = 0 To mstrFPALLET_ID_Front_Single.Length - 1

                strDSPPALLET_ID = mstrFPALLET_ID_Front_Single(ii)

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                                          'ﾊﾟﾚｯﾄID(親)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST
                objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                   'ﾊﾟﾚｯﾄID(子)
                objTelegramSub.SETIN_DATA("XDSPTR_IDOU", strFTR_IDOU)                                               '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                             '送信電文
            Next
        End If

        '********************************************************************
        ' 倉替出庫用 電文作成(奥 ﾍﾟｱ)
        '********************************************************************
        If Not mstrFPALLET_ID_Back_Pare Is Nothing Then
            For ii As Integer = 0 To mstrFPALLET_ID_Back_Pare.Length - 1 Step 2
                '(ﾊﾟﾚｯﾄ数分ﾙｰﾌﾟ)

                If ii + 1 <= mstrFPALLET_ID_Back_Pare.Length - 1 Then
                    blnPareFlag = True

                    strDSPPALLET_ID = mstrFPALLET_ID_Back_Pare(ii)
                    strXDSPPALLET_ID_KO = mstrFPALLET_ID_Back_Pare(ii + 1)
                Else
                    blnPareFlag = False

                    strDSPPALLET_ID = mstrFPALLET_ID_Back_Pare(ii)
                End If

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                                          'ﾊﾟﾚｯﾄID(親)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST
                If blnPareFlag = True Then
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", strXDSPPALLET_ID_KO)                              'ﾊﾟﾚｯﾄID(子)
                Else
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")                                               'ﾊﾟﾚｯﾄID(子)
                End If
                objTelegramSub.SETIN_DATA("XDSPTR_IDOU", strFTR_IDOU)                                               '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                             '送信電文

            Next
        End If

        '********************************************************************
        ' 倉替出庫用 電文作成(奥 ｼﾝｸﾞﾙ)
        '********************************************************************
        If Not mstrFPALLET_ID_Back_Single Is Nothing Then
            For ii As Integer = 0 To mstrFPALLET_ID_Back_Single.Length - 1

                strDSPPALLET_ID = mstrFPALLET_ID_Back_Single(ii)

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列

                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)                                          'ﾊﾟﾚｯﾄID(親)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST
                objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                   'ﾊﾟﾚｯﾄID(子)
                objTelegramSub.SETIN_DATA("XDSPTR_IDOU", strFTR_IDOU)                                               '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                             '送信電文
            Next
        End If

        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400501

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303041_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If


        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region

End Class
