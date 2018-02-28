'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾎﾟｯﾌﾟｱｯﾌﾟ画面親ﾌｫｰﾑ
' 【作成】SIT
'**********************************************************************************************

#Region "Imports                    "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_100101

#Region "  共通変数             定義"

    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mudtFormRet As RetPopup             '何のﾎﾞﾀﾝが押されたかの、ﾌｫｰﾑの戻値
    Private mudtIconType As PopupIconType       '表示ｱｲｺﾝのﾀｲﾌﾟ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ              定義"

    Public ReadOnly Property userRet() As RetPopup
        Get
            Return mudtFormRet
        End Get
    End Property

    Public Property userIconType() As PopupIconType
        Get
            Return mudtIconType
        End Get
        Set(ByVal Value As PopupIconType)

            mudtIconType = Value

        End Set
    End Property

#End Region
#Region "  「ＯＫ」ﾎﾞﾀﾝｸﾘｯｸ     処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「ＯＫ」ﾎﾞﾀﾝｸﾘｯｸ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub cmdOKProc()
        Try

            mudtFormRet = RetPopup.OK
            Me.DialogResult = Windows.Forms.DialogResult.OK   '自身非表示（非表示しているだけ）

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  「ｷｬﾝｾﾙ」ﾎﾞﾀﾝｸﾘｯｸ    処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「ｷｬﾝｾﾙ」ﾎﾞﾀﾝｸﾘｯｸ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Sub cmdCancelProc()
        Try

            mudtFormRet = RetPopup.Cancel
            Me.DialogResult = Windows.Forms.DialogResult.Cancel   '自身非表示（非表示しているだけ）

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ             処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Friend Sub frmLoad()
        Try
            '**************************************************
            'ｺﾝﾄﾛｰﾙｾｯﾄ
            '**************************************************
            '--------------------------------
            'ﾋﾟｸﾁｬｰﾎﾞｯｸｽ    ｾｯﾄ
            '--------------------------------
            Select Case mudtIconType
                Case PopupIconType.Information
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_INFOR)
                Case PopupIconType.Quest
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_QUEST)
                Case PopupIconType.Err
                    pctIcon.Image = Image.FromFile(POPUP_IMAGE_ERROR)
            End Select


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ｲﾍﾞﾝﾄ                    "

#Region "  ﾌｫｰﾑﾛｰﾄﾞ             ｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmPopup_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/07/25  定周期で自ﾌｫｰﾑを一番手前で表示させる。数十秒間の待機状態中にｸﾘｯｸされるとShowDialogしているにもかかわらず、ﾌｫｰﾑが後ろに表示されてしまうのでその対応
#Region "  ﾀｲﾏｰ1(定周期で自身を一番手前に表示)  "
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.Focus()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#End Region
#Region "  自身ｵｰﾌﾟﾝ処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自身ｵｰﾌﾟﾝ処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeOpen()

        '*************************************************
        ' 画面初期化（各画面処理）
        '*************************************************
        Call frmLoad()

        '*************************************************
        ' 見える
        '*************************************************
        Me.Opacity = 100


    End Sub
#End Region
#Region "  自身ｸﾛｰｽﾞ処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 自身ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeClose()

        '*************************************************
        ' ﾗﾍﾞﾙ初期化
        '*************************************************
        lblMsg.Text = ""


        '*************************************************
        ' 消える
        '*************************************************
        Me.Opacity = 0

    End Sub
#End Region

End Class
