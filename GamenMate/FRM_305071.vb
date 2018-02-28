'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】緊急時入庫登録 子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305071
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFTRK_BUF_NO As String                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    Protected mblnSET_FLAG As Boolean                   '登録済ﾌﾗｸﾞ

    Private mstrFTRK_BUF_NO_Disp As String            '入庫ST
    Private mstrFHINMEI_CD As String                  '品名記号
    Private mstrFHINMEI As String                     '品名
    Private mstrXPROD_LINE As String                  '生産ﾗｲﾝNo.
    Private mstrXPROD_LINE_NAME As String             '生産ﾗｲﾝ名
    Private mstrXKINKYU_BUF_TO As String              '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mstrXKINKYU_BUF_TO_Disp As String         '出庫ST



    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        StartBtn_Click               '登録
        EndBtn_Click                 '解除
        CancelBtn_Click              'ｷｬﾝｾﾙ
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

    '''''' =======================================
    '''''' <summary>入庫ST</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFTRK_BUF_NO_Disp() As String
    ' ''    Get
    ' ''        Return mstrFTRK_BUF_NO_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFTRK_BUF_NO_Disp = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>品名ｺｰﾄﾞ</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHINMEI_CD() As String
    ' ''    Get
    ' ''        Return mstrFHINMEI_CD
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFHINMEI_CD = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>品名</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userFHINMEI() As String
    ' ''    Get
    ' ''        Return mstrFHINMEI
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrFHINMEI = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>生産ﾗｲﾝNo.</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROD_LINE() As String
    ' ''    Get
    ' ''        Return mstrXPROD_LINE
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXPROD_LINE = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>生産ﾗｲﾝ名</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXPROD_LINE_NAME() As String
    ' ''    Get
    ' ''        Return mstrXPROD_LINE_NAME
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXPROD_LINE_NAME = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKINKYU_BUF_TO() As String
    ' ''    Get
    ' ''        Return mstrXKINKYU_BUF_TO
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKINKYU_BUF_TO = value
    ' ''    End Set
    ' ''End Property

    '''''' =======================================
    '''''' <summary>出庫ST</summary>
    '''''' <remarks></remarks>
    '''''' =======================================
    ' ''Public Property userXKINKYU_BUF_TO_Disp() As String
    ' ''    Get
    ' ''        Return mstrXKINKYU_BUF_TO_Disp
    ' ''    End Get
    ' ''    Set(ByVal value As String)
    ' ''        mstrXKINKYU_BUF_TO_Disp = value
    ' ''    End Set
    ' ''End Property

    ''' =======================================
    ''' <summary>登録済ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userSET_FLAG() As Boolean
        Get
            Return mblnSET_FLAG
        End Get
        Set(ByVal value As Boolean)
            mblnSET_FLAG = value
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
    Private Sub FRM_305071_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_305071_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub cmdStartBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Try

            Call cmdStartBtn_ClickProcess()


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
    Private Sub cmdEndBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try

            Call cmdEndBtn_ClickProcess()


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
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        '生産入庫設定状態取得
        '===================================
        Dim strSQL As String                        'SQL文
        Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet               'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_PRODUCT_IN.FTRK_BUF_NO"                 '生産入庫設定状態      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME"                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ       .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(表示用)
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHINMEI_CD "                 '生産入庫設定状態      .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                          '品目ﾏｽﾀ               .品名
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XPROD_LINE"                  '生産入庫設定状態      .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.XKINKYU_BUF_TO "             '生産入庫設定状態      .緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_PRODUCT_IN "                               '【生産入庫設定状態】
        strSQL &= vbCrLf & "  , TMST_TRK "                                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TMST_ITEM "                                     '【品目ﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_PRODUCT_IN.FTRK_BUF_NO = '" & mstrFTRK_BUF_NO & "' "       '生産入庫設定状態 を ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo. で特定
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XSTS_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_PRODUCT_IN"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                mstrFTRK_BUF_NO_Disp = TO_STRING(objRow("FBUF_NAME"))                       '入庫ST
                mstrFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))                            '品名記号
                mstrFHINMEI = TO_STRING(objRow("FHINMEI"))                                  '品名
                mstrXPROD_LINE = TO_STRING(objRow("XPROD_LINE"))                            '生産ﾗｲﾝNo.
                mstrXKINKYU_BUF_TO = TO_STRING(objRow("XKINKYU_BUF_TO"))                    '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№

            Next
        End If



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

        '===================================
        '生産ﾗｲﾝNo. ｾｯﾄ
        '===================================
        lblXPROD_LINE.Text = mstrXPROD_LINE

        '===================================
        '出庫ST ｾｯﾄ
        '===================================
        If mblnSET_FLAG = False Then
            '(未登録の場合)
            Call gobjComFuncFRM.cboSetup(Me.Name, cboXKINKYU_BUF_TO, False)
            cboXKINKYU_BUF_TO.SelectedIndex = -1
        Else
            '(登録済の場合)
            Call gobjComFuncFRM.cboSetup(Me.Name, cboXKINKYU_BUF_TO, False, mstrXKINKYU_BUF_TO)
            cboXKINKYU_BUF_TO.Enabled = False
        End If


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
        lblXPROD_LINE.Dispose()
        cboXKINKYU_BUF_TO.Dispose()

    End Sub
#End Region

#Region "　登録    ﾎﾞﾀﾝ押下処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 登録 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdStartBtn_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.StartBtn_Click) = False Then
            Exit Sub
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
#Region "　解除    ﾎﾞﾀﾝ押下処理                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 解除 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdEndBtn_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.EndBtn_Click) = False Then
            Exit Sub
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
#Region "　ｷｬﾝｾﾙ   ﾎﾞﾀﾝ押下処理                     "
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
            Case menmCheckCase.StartBtn_Click
                '(登録の場合)

                '========================================
                '緊急時入庫状況
                '========================================
                If mblnSET_FLAG = True Then
                    '（登録済の場合）
                    Call gobjComFuncFRM.DisplayPopup("既に登録済のため、緊急時入庫の登録は出来ません。", _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '出庫ST
                '========================================
                If cboXKINKYU_BUF_TO.Text = "" Then
                    '（未選択の場合）
                    Call gobjComFuncFRM.DisplayPopup("出庫STを選択してください。", _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If




                blnCheckErr = False

            Case menmCheckCase.EndBtn_Click
                '(解除の場合)

                '========================================
                '緊急時入庫状況
                '========================================
                If mblnSET_FLAG = False Then
                    '（未登録の場合）
                    Call gobjComFuncFRM.DisplayPopup("未登録状態のため、緊急時入庫の解除は出来ません。", _
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

#Region "  ｿｹｯﾄ送信(登録)                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(登録)
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
        strMessage &= "緊急時入庫を登録" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400003    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                                    'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", TO_STRING(cboXKINKYU_BUF_TO.SelectedValue))     '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "0")                                               '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "0")                                          '緊急時実績数(梱数)
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
#Region "  ｿｹｯﾄ送信(解除)                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(解除)
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
        strMessage &= "緊急時入庫を解除" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400003    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", mstrFTRK_BUF_NO)                                    'ﾊﾞｯﾌｧNo.
        objTelegram.SETIN_DATA("XDSPKINKYU_BUF_TO", "")                                             '緊急時搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        objTelegram.SETIN_DATA("XDSPRESULT_NUM", "")                                                '緊急時実績数
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/23 生産入庫実績梱数追加
        objTelegram.SETIN_DATA("XDSPRESULT_NUM_CASE", "")                                           '緊急時実績数(梱数)
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
