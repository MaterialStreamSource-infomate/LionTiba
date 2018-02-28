'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ子画面 計画数変更
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307102

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrPLC_STNO As String                    'ST№
    Protected mstrPLC_FEQ_ID01 As String                '設備ID(設定数)
    Protected mstrPLC_FEQ_ID_VOL01 As String            '設定数
    Protected mstrPLC_FEQ_ID02 As String                '設備ID(現在数)
    Protected mstrPLC_FEQ_ID_VOL02 As String            '現在数

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ST№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_STNO() As String
        Get
            Return mstrPLC_STNO
        End Get
        Set(ByVal value As String)
            mstrPLC_STNO = value
        End Set
    End Property


    ''' =======================================
    ''' <summary>設備ID(設定数)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FEQ_ID01() As String
        Get
            Return mstrPLC_FEQ_ID01
        End Get
        Set(ByVal value As String)
            mstrPLC_FEQ_ID01 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>設定数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FEQ_ID_VOL01() As String
        Get
            Return mstrPLC_FEQ_ID_VOL01
        End Get
        Set(ByVal value As String)
            mstrPLC_FEQ_ID_VOL01 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>設備ID(現在数)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FEQ_ID02() As String
        Get
            Return mstrPLC_FEQ_ID02
        End Get
        Set(ByVal value As String)
            mstrPLC_FEQ_ID02 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>現在数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FEQ_ID_VOL02() As String
        Get
            Return mstrPLC_FEQ_ID_VOL02
        End Get
        Set(ByVal value As String)
            mstrPLC_FEQ_ID_VOL02 = value
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
    Private Sub FRM_307101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_307081_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  送信ﾎﾞﾀﾝｸﾘｯｸ                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Try

            Call cmdSend_ClickProcess()

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


        '**********************************************************
        ' ﾗﾍﾞﾙ                 ｾｯﾄ
        '**********************************************************
        lblPLC_STNo.Text = mstrPLC_STNO                     'ST№


        '**********************************************************
        ' ﾃｷｽﾄ                ｾｯﾄ
        '**********************************************************
        txtGENZAI_VOL.Text = mstrPLC_FEQ_ID_VOL02             '現在数


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
        txtGENZAI_VOL.Dispose()                         '現在数

    End Sub
#End Region
#Region "  送信         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSend_ClickProcess()

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
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

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
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        'Dim intRet As RetCode
        'Dim strMsg As String = ""


        Select Case "a"
            Case "a"
                '(修正の場合)

                '========================================
                '現在値
                '========================================
                If txtGENZAI_VOL.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307102_01, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                If TO_INTEGER(txtGENZAI_VOL.Text) > MAX_BIT Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307102_02, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

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
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "送信" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400702    'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        ''objTelegram.SETIN_DATA("XDSPSETTEI_EQ_ID", mstrPLC_FEQ_ID01)                        '設備ID
        ''objTelegram.SETIN_DATA("XDSPTEXT_ID", FTEXT_ID_JW_MAINTE_YOTEI)                     'ﾃｷｽﾄID
        ' ''objTelegram.SETIN_DATA("XDSPSETTEI_NUM", "")                                        '設定数
        objTelegram.SETIN_DATA("XDSPGENZAI_EQ_ID", mstrPLC_FEQ_ID02)                        '設備ID
        objTelegram.SETIN_DATA("XDSPTEXT_ID02", FTEXT_ID_JW_MAINTE_GENZAI)                  'ﾃｷｽﾄID02
        objTelegram.SETIN_DATA("XDSPGENZAI_NUM", txtGENZAI_VOL.Text)                        '現在数


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = "送信" & FRM_MSG_FRM200000_14
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
