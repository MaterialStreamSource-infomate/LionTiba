'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】入庫設定画面 子画面 連続入庫設定
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303012
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mstrFTRK_BUF_NO_Disp As String            '入庫ST
    Protected mstrFHINMEI_CD As String                  '品名記号
    Protected mstrFHINMEI As String                     '品名
    Protected mstrXPROD_LINE As String                  '生産ﾗｲﾝNo.
    Protected mstrXPROD_LINE_Disp As String             '生産ﾗｲﾝNo.(表示用)
    Protected mintXPROGRESS As Integer                  '進捗状況
    Protected mstrFEQ_ID As String                      '設備ID
    Protected mintDSPGRID_DISPLAYINDEX As Integer       '表示順序

    Protected mstrFARRIVE_DT As String                  '在庫発生日時
    Protected mintFIN_KUBUN As Integer                  '入庫区分
    Protected mstrFIN_KUBUN_Disp As String              '入庫区分(表示用)
    Protected mintFHORYU_KUBUN As Integer               '保留区分
    Protected mstrFHORYU_KUBUN_Disp As String           '保留区分(表示用)
    Protected mstrXKENSA_KUBUN As String                '検査区分
    Protected mstrXKENSA_KUBUN_Disp As String           '検査区分(表示用)
    Protected mstrXKENPIN_KUBUN As String               '検品区分
    Protected mstrXKENPIN_KUBUN_Disp As String          '検品区分(表示用)
    Protected mstrXMAKER_CD As String                   'ﾒｰｶｰｺｰﾄﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        IN_StartBtn_Click               '生産開始
        IN_EndBtn_Click                 '生産終了
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
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>生産ﾗｲﾝNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>生産ﾗｲﾝNo.(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXPROD_LINE_Disp() As String
        Get
            Return mstrXPROD_LINE_Disp
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>進捗状況</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXPROGRESS() As Integer
        Get
            Return mintXPROGRESS
        End Get
        Set(ByVal value As Integer)
            mintXPROGRESS = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFEQ_ID() As String
        Get
            Return mstrFEQ_ID
        End Get
        Set(ByVal value As String)
            mstrFEQ_ID = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>表示順序</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userDSPGRID_DISPLAYINDEX() As Integer
        Get
            Return mintDSPGRID_DISPLAYINDEX
        End Get
        Set(ByVal value As Integer)
            mintDSPGRID_DISPLAYINDEX = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫発生日時</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFARRIVE_DT() As String
        Get
            Return mstrFARRIVE_DT
        End Get
        Set(ByVal value As String)
            mstrFARRIVE_DT = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFIN_KUBUN() As Integer
        Get
            Return mintFIN_KUBUN
        End Get
        Set(ByVal value As Integer)
            mintFIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFIN_KUBUN_Disp() As String
        Get
            Return mstrFIN_KUBUN_Disp
        End Get
        Set(ByVal value As String)
            mstrFIN_KUBUN_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>保留区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHORYU_KUBUN() As Integer
        Get
            Return mintFHORYU_KUBUN
        End Get
        Set(ByVal value As Integer)
            mintFHORYU_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>保留区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHORYU_KUBUN_Disp() As String
        Get
            Return mstrFHORYU_KUBUN_Disp
        End Get
        Set(ByVal value As String)
            mstrFHORYU_KUBUN_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検査区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENSA_KUBUN() As String
        Get
            Return mstrXKENSA_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXKENSA_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検査区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENSA_KUBUN_Disp() As String
        Get
            Return mstrXKENSA_KUBUN_Disp
        End Get
        Set(ByVal value As String)
            mstrXKENSA_KUBUN_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENPIN_KUBUN() As String
        Get
            Return mstrXKENPIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXKENPIN_KUBUN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>検品区分(表示用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXKENPIN_KUBUN_Disp() As String
        Get
            Return mstrXKENPIN_KUBUN_Disp
        End Get
        Set(ByVal value As String)
            mstrXKENPIN_KUBUN_Disp = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXMAKER_CD() As String
        Get
            Return mstrXMAKER_CD
        End Get
        Set(ByVal value As String)
            mstrXMAKER_CD = value
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
    Private Sub FRM_303012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_303012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　連続入庫開始   　ﾎﾞﾀﾝ押下                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdIN_StartBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIN_Start.Click
        Try

            Call cmdIN_StartBtn_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　連続入庫終了   　ﾎﾞﾀﾝ押下                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdIN_EndBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIN_End.Click
        Try

            Call cmdIN_EndBtn_ClickProcess()


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
    Private Sub FRM_303012_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        '品名ｺｰﾄﾞ ｾｯﾄ
        '===================================
        lblFHINMEI_CD.Text = mstrFHINMEI_CD

        '===================================
        '品名 ｾｯﾄ
        '===================================
        lblFHINMEI.Text = mstrFHINMEI


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
        lblFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()

    End Sub
#End Region

#Region "　連続入庫開始    ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 連続入庫開始 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIN_StartBtn_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.IN_StartBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = mstrFHINMEI_CD
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket01() = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　連続入庫終了    ﾎﾞﾀﾝ押下処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 連続入庫終了 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIN_EndBtn_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.IN_EndBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = mstrFHINMEI_CD
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02() = False Then
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
            Case menmCheckCase.IN_StartBtn_Click
                '(連続入庫開始の場合)

                '========================================
                '進捗状況
                '========================================
                If mintXPROGRESS = XPROGRESS_START Then
                    '（開始状態の場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303012_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.IN_EndBtn_Click
                '(連続入庫終了の場合)

                '========================================
                '進捗状況
                '========================================
                If mintXPROGRESS = XPROGRESS_NON Or mintXPROGRESS = XPROGRESS_END Then
                    '（終了状態の場合）
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303012_02, _
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

#Region "  ｿｹｯﾄ送信(連続入庫開始)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(連続入庫開始)
    ''' </summary>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01() As Boolean

        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "連続入庫を開始" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If





        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400002    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                            'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                      '設備ID
        objTelegram.SETIN_DATA("XDSPPROD_LINE", TO_STRING(mstrXPROD_LINE))                  '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPHINMEI_CD", TO_STRING(mstrFHINMEI_CD))                   '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))       '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", "")                                            '終了日時
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_START))                  '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mintDSPGRID_DISPLAYINDEX)) '表示順序
        If mstrFARRIVE_DT <> "" Then                                                        '在庫発生日時
            '(入力有り)
            objTelegram.SETIN_DATA("DSPARRIVE_DT", mstrFARRIVE_DT)
        Else
            '(入力なし)
            objTelegram.SETIN_DATA("DSPARRIVE_DT", "")
        End If
        objTelegram.SETIN_DATA("DSPIN_KUBUN", TO_STRING(mintFIN_KUBUN))                         '入庫区分
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", TO_STRING(mintFHORYU_KUBUN))                   '保留区分
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", TO_STRING(mstrXKENSA_KUBUN))                  '検査区分
        objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", TO_STRING(mstrXKENPIN_KUBUN))                '検品区分
        objTelegram.SETIN_DATA("XDSPMAKER_CD", mstrXMAKER_CD)                                   'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", "")                                         '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "0")                                           '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "0")                                      '緊急時実績数(梱数)
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
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
#Region "  ｿｹｯﾄ送信(生産入庫終了)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(生産入庫終了)
    ''' </summary>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "生産入庫を終了" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400002    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                            'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("DSPEQ_ID", mstrFEQ_ID)                                      '設備ID
        objTelegram.SETIN_DATA("XDSPPROD_LINE", "")                                         '生産ﾗｲﾝNo. 
        objTelegram.SETIN_DATA("DSPHINMEI_CD", "")                                          '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSTART_DT", "")                                          '開始日時
        objTelegram.SETIN_DATA("XDSPEND_DT", Format(datNow, "yyyy/MM/dd HH:mm:ss"))         '終了日時
        objTelegram.SETIN_DATA("XDSPPROGRESS", TO_STRING(XPROGRESS_END))                    '進捗状況
        objTelegram.SETIN_DATA("DSPGRID_DISPLAYINDEX", TO_STRING(mintDSPGRID_DISPLAYINDEX)) '表示順序
        objTelegram.SETIN_DATA("DSPARRIVE_DT", "")                                          '在庫発生日時
        objTelegram.SETIN_DATA("DSPIN_KUBUN", "")                                           '入庫区分
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", "")                                        '保留区分
        objTelegram.SETIN_DATA("XDSPKENSA_KUBUN", "")                                       '検査区分
        objTelegram.SETIN_DATA("XDSPKENPIN_KUBUN", "")                                      '検品区分
        objTelegram.SETIN_DATA("XDSPMAKER_CD", "")                                          'ﾒｰｶｰｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", "")                                     '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "")                                        '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "")                                   '緊急時実績数(梱数)
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        '↑↑↑↑↑↑************************************************************************************************************

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
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
