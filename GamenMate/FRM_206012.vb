'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】品名ﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region
Public Class FRM_206012

#Region "  共通変数　                           "

    Private mFlag_Form_Load As Boolean = True       '画面展開ﾌﾗｸﾞ

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjTMST_ITEM As TBL_TMST_ITEM              '品名ﾏｽﾀ

    'ﾌﾟﾛﾊﾟﾃｨ
    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ
    Private mstrFHINMEI_CD As String                '品名ｺｰﾄﾞ

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

    '品名ｺｰﾄﾞ
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_206012_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub FRM_206012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  変更ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHenkou.Click
        Try

            Call cmdHenkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  削除ﾎﾞﾀﾝｸﾘｯｸ                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSakujo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSakujo.Click
        Try

            Call cmdSakujo_ClickProcess()

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

        '===================================
        '品名ﾗﾍﾞﾙ  ｾｯﾄ
        '===================================
        lblFHINMEI.Text = ""


        '===================================
        '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

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
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()

    End Sub
#End Region
#Region "  変更         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdHenkou_ClickProcess()

        Dim intRet As RetCode

        mstrFHINMEI_CD = ""
        mobjTMST_ITEM = Nothing
        mintButtonMode = 0

        If cboFHINMEI_CD.Text = "" Then
            '（入力無しの場合）
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Exit Sub
        End If

        If cboFHINMEI_CD.FIND_FLAG = False Then
            '(該当品目なしの場合)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Exit Sub
        End If

        If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            mobjTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            mobjTMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = mobjTMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = mobjTMST_ITEM.FHINMEI_CD
                mintButtonMode = BUTTONMODE_UPDATE

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            Else
                '(該当品目なしの場合)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Information)
                Exit Sub
            End If

        Else
            '(品名記号の場合)
            mobjTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            mobjTMST_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text
            intRet = mobjTMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = mobjTMST_ITEM.FHINMEI_CD
                mintButtonMode = BUTTONMODE_UPDATE

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            Else
                '(該当品目なしの場合)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Information)
                Exit Sub
            End If
        End If

    End Sub
#End Region
#Region "  削除         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSakujo_ClickProcess()

        Dim intRet As RetCode

        mstrFHINMEI_CD = ""
        mobjTMST_ITEM = Nothing
        mintButtonMode = 0

        If cboFHINMEI_CD.Text = "" Then
            '（入力無しの場合）
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD_MSG_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Exit Sub
        End If

        If cboFHINMEI_CD.FIND_FLAG = False Then
            '(該当品目なしの場合)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Exit Sub
        End If

        If IsNumeric(cboFHINMEI_CD.Text.Substring(0, 1)) Then
            '(品名ｺｰﾄﾞの場合)
            mobjTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            mobjTMST_ITEM.XHINMEI_CD = cboFHINMEI_CD.Text
            intRet = mobjTMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = mobjTMST_ITEM.FHINMEI_CD
                mintButtonMode = BUTTONMODE_DELETE

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            Else
                '(該当品目なしの場合)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Information)
                Exit Sub
            End If

        Else
            '(品名記号の場合)
            mobjTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
            mobjTMST_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text
            intRet = mobjTMST_ITEM.GET_TMST_ITEM(False)
            If intRet = RetCode.OK Then
                '(値がある時)
                mstrFHINMEI_CD = mobjTMST_ITEM.FHINMEI_CD
                mintButtonMode = BUTTONMODE_DELETE

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            Else
                '(該当品目なしの場合)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FHINMEI_CD, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Information)
                Exit Sub
            End If
        End If

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        mstrFHINMEI_CD = ""
        mobjTMST_ITEM = Nothing
        mintButtonMode = 0

        Me.Close()

    End Sub
#End Region

End Class