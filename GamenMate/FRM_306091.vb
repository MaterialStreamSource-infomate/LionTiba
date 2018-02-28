'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産ﾗｲﾝﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_306091

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrXDPL_PL_NO As String                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private mstrFHINMEI_CD As String                '品名ｺｰﾄﾞ
    Private mstrXDPL_PL_PTN As String               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    Private mstrXDPL_PL_PTN_COMMENT As String       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ' ﾎﾞﾀﾝﾓｰﾄﾞ
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
        End Set
    End Property

    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Public Property userXDPL_PL_NO() As String
        Get
            Return mstrXDPL_PL_NO
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_NO = value
        End Set
    End Property

    '品名ｺｰﾄﾞ
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    Public Property userXDPL_PL_PTN() As String
        Get
            Return mstrXDPL_PL_PTN
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_PTN = value
        End Set
    End Property

    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ
    Public Property userXDPL_PL_PTN_COMMENT() As String
        Get
            Return mstrXDPL_PL_PTN_COMMENT
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_PTN_COMMENT = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
        '*******************************************************************************************************************
        '【機能】同上
        '【引数】
        '【戻値】

    Private Sub FRM_306091_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_306091_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                   "
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
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub LoadProcess()


        '**********************************************************
        ' 実行ﾎﾞﾀﾝ                  ｾｯﾄ
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                cmdZikkou.Text = "追加"
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                cmdZikkou.Text = "変更"
            Case BUTTONMODE_DELETE
                '(削除の場合)
                cmdZikkou.Text = "削除"
        End Select


        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_DPL_PL", "XDPL_PL_NO", "XDPL_PL_NAME", "XDPL_PL_NO", cboXDPL_PL_NO, True, mstrXDPL_PL_NO, "")

        '===================================
        ' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = mstrFHINMEI_CD
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXDPL_PL_PTN.Text = TO_STRING(mstrXDPL_PL_PTN)                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        txtXDPL_PL_PTN_COMMENT.Text = TO_STRING(mstrXDPL_PL_PTN_COMMENT)    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ


        '===================================
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '===================================
        Call ControlEnable()


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboXDPL_PL_NO.Dispose()
        cboFHINMEI_CD.Dispose()
        txtXDPL_PL_PTN.Dispose()
        txtXDPL_PL_PTN_COMMENT.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                '========================================
                '設備名称
                '========================================
                If cboXDPL_PL_NO.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品目ｺｰﾄﾞ
                '========================================
                If cboFHINMEI_CD.Text <> "" Then
                    If cboFHINMEI_CD.FIND_FLAG = False Then
                        '(該当品目なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                Else
                    '(選択なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                '========================================
                If txtXDPL_PL_PTN.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                Else
                    If TO_INTEGER(txtXDPL_PL_PTN.Text) <= 0 Or _
                       TO_INTEGER(txtXDPL_PL_PTN.Text) > 99 Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_04, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                End If

                '========================================
                'ｷｰ重複ﾁｪｯｸ
                '========================================
                Dim objXMST_DPL_PL_PTN As New TBL_XMST_DPL_PL_PTN(gobjOwner, gobjDb, Nothing)   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
                Dim intRet As Integer
                objXMST_DPL_PL_PTN.XDPL_PL_NO = TO_INTEGER(cboXDPL_PL_NO.SelectedValue)         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↓↓↓↓↓↓
                '' ''objXMST_DPL_PL_PTN.FHINMEI_CD = cboFHINMEI_CD.Text                              '品目ｺｰﾄﾞ
                '********************************************************************
                ' 品名記号取得
                '********************************************************************
                Dim strFHINMEI_CD As String = ""            '品目ｺｰﾄﾞ
                If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
                    '(品名ｺｰﾄﾞの場合)
                    Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                    If intRet = RetCode.OK Then
                        '(値がある時)
                        strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
                    Else
                        '(該当品目なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                Else
                    '(品名記号の場合)
                    strFHINMEI_CD = cboFHINMEI_CD.Text
                End If
                objXMST_DPL_PL_PTN.FHINMEI_CD = strFHINMEI_CD                                   '品目ｺｰﾄﾞ
                'JobMate:S.Ouchi 2015/08/24 CW6追加対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************
                objXMST_DPL_PL_PTN.XDPL_PL_PTN = TO_INTEGER(txtXDPL_PL_PTN.Text)                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                intRet = objXMST_DPL_PL_PTN.GET_XMST_DPL_PL_PTN(False)                          '特定
                If intRet = RetCode.OK Then
                    '(入力されたﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号が登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_05, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                '========================================
                '設備名称
                '========================================
                If cboXDPL_PL_NO.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '品目ｺｰﾄﾞ
                '========================================
                If cboFHINMEI_CD.Text <> "" Then
                    If cboFHINMEI_CD.FIND_FLAG = False Then
                        '(該当品目なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                Else
                    '(選択なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                '========================================
                If txtXDPL_PL_PTN.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                Else
                    If TO_INTEGER(txtXDPL_PL_PTN.Text) <= 0 Or _
                       TO_INTEGER(txtXDPL_PL_PTN.Text) > 99 Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM306091_04, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If
                End If

                blnCheckErr = False


            Case BUTTONMODE_DELETE
                '(削除の場合)


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
#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                      "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                cboXDPL_PL_NO.Enabled = True                    '設備名称:
                cboFHINMEI_CD.Enabled = True                    '品名ｺｰﾄﾞ
                txtXDPL_PL_PTN.Enabled = True                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                txtXDPL_PL_PTN_COMMENT.Enabled = True           'ﾊﾟﾀｰﾝｺﾒﾝﾄ

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                cboXDPL_PL_NO.Enabled = False                   '設備名称:
                cboFHINMEI_CD.Enabled = False                   '品名ｺｰﾄﾞ
                txtXDPL_PL_PTN.Enabled = False                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                txtXDPL_PL_PTN_COMMENT.Enabled = True           'ﾊﾟﾀｰﾝｺﾒﾝﾄ

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                cboXDPL_PL_NO.Enabled = False                   '設備名称:
                cboFHINMEI_CD.Enabled = False                   '品名ｺｰﾄﾞ
                txtXDPL_PL_PTN.Enabled = False                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
                txtXDPL_PL_PTN_COMMENT.Enabled = False          'ﾊﾟﾀｰﾝｺﾒﾝﾄ

                Exit Select

        End Select

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub SendSocket01()


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDIR_KUBUN As String = ""             '処理区分
        Dim strXDPL_PL_NO As String                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        Dim strFHINMEI_CD As String = ""            '品目ｺｰﾄﾞ
        Dim strXDPL_PL_PTN As String                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        Dim strXDPL_PL_PTN_COMMENT As String        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        '********************************************************************
        ' 品名記号取得
        '********************************************************************
        If cboFHINMEI_CD.Text = "" Then

        ElseIf IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            Dim intRet As Integer
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
            objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD        '品名記号
            End If

        Else
            '(品名記号の場合)
            strFHINMEI_CD = cboFHINMEI_CD.Text

        End If


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400608      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strXDPL_PL_NO = TO_STRING(cboXDPL_PL_NO.SelectedValue)          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        strXDPL_PL_PTN = TO_STRING(txtXDPL_PL_PTN.Text)                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        strXDPL_PL_PTN_COMMENT = TO_STRING(txtXDPL_PL_PTN_COMMENT.Text) 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_ADD)            '指示区分
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_UPDATE)         '指示区分
            Case BUTTONMODE_DELETE
                '(削除の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_DELETE)         '指示区分
        End Select

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                        '指示区分
        objTelegram.SETIN_DATA("XDSPDPL_PL_NO", strXDPL_PL_NO)                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strFHINMEI_CD)                       '品目ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPDPL_PL_PTN", strXDPL_PL_PTN)                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        objTelegram.SETIN_DATA("XDSPDPL_PL_PTN_COMMENT", strXDPL_PL_PTN_COMMENT)    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                   'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = cmdZikkou.Text & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            End If
        End If

    End Sub
#End Region

End Class
