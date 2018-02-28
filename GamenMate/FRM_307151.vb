'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ(BCR)子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307151

#Region "  共通変数　                               "

    Public userPLC_STNO As String
    Public userPLC_ITFVAL As String

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXMAINTE_KUBUN As String     'ﾒﾝﾃﾅﾝｽ区分


#End Region
    '#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    '    ''' =======================================
    '    ''' <summary>ﾒﾝﾃﾅﾝｽ区分</summary>
    '    ''' <remarks></remarks>
    '    ''' =======================================
    '    Public Property userXMAINTE_KUBUN() As String
    '        Get
    '            Return mstrXMAINTE_KUBUN
    '        End Get
    '        Set(ByVal value As String)
    '            mstrXMAINTE_KUBUN = value
    '        End Set
    '    End Property
    '#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_307092_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_307092_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCorrection.Click
        Try
            Dim strITF(3) As String
            Dim strFEQID(3) As String
            Dim strWORK As String

            If txtSTNo.Text = "D43(後)" Then
                strFEQID(0) = "JOTHY04_X041361"
                strFEQID(1) = "JOTHY04_X041362"
                strFEQID(2) = "JOTHY04_X041363"
                strFEQID(3) = "JOTHY04_X041364"
            ElseIf txtSTNo.Text = "D93(後)" Then
                strFEQID(0) = "JOTHY06_X041361"
                strFEQID(1) = "JOTHY06_X041362"
                strFEQID(2) = "JOTHY06_X041363"
                strFEQID(3) = "JOTHY06_X041364"
            ElseIf txtSTNo.Text = "D43(前)" Then
                strFEQID(0) = "JOTHY04_X041365"
                strFEQID(1) = "JOTHY04_X041366"
                strFEQID(2) = "JOTHY04_X041367"
                strFEQID(3) = "JOTHY04_X041368"
            ElseIf txtSTNo.Text = "D93(前)" Then
                strFEQID(0) = "JOTHY06_X041365"
                strFEQID(1) = "JOTHY06_X041366"
                strFEQID(2) = "JOTHY06_X041367"
                strFEQID(3) = "JOTHY06_X041368"
            End If

            strWORK = txtITF.Text.PadLeft(14, "0"c)

            strITF(3) = Convert.ToInt16(strWORK.Substring(0, 2), 16).ToString
            strITF(2) = Convert.ToInt16(strWORK.Substring(2, 4), 16).ToString
            strITF(1) = Convert.ToInt16(strWORK.Substring(6, 4), 16).ToString
            strITF(0) = Convert.ToInt16(strWORK.Substring(10, 4), 16).ToString

            '********************************************************************
            'ｿｹｯﾄ送信処理
            '********************************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:IKEDA 2017/07/12 包材出荷登録(ボタン要求)コンボボックス追加対応 ↓↓↓↓↓↓
            If SendSocket01(strFEQID(0), strITF(0), True) = True Then
                Call SendSocket01(strFEQID(1), strITF(1), False)
                Call SendSocket01(strFEQID(2), strITF(2), False)
                Call SendSocket01(strFEQID(3), strITF(3), False)
            End If
            'JobMate:IKEDA 2017/07/12 包材出荷登録(ボタン要求)コンボボックス追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
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
    ''' ﾌｫｰﾑﾛｰﾄﾞ     処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()


        txtSTNo.Text = userPLC_STNO
        txtITF.Text = userPLC_ITFVAL

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
        'cboXMAINTE_KUBUN.Dispose()
        'cboXMAINTE_KUBUN = Nothing


    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｸﾛｰｽﾞ
        '********************************************************************
        userPLC_ITFVAL = txtITF.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>入力ﾁｪｯｸ判別</returns>
    ''' <remarks>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = False       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '==========================
        '数値ﾁｪｯｸ
        '==========================
        If IsNumeric(txtITF.Text) = False Then
            Call gobjComFuncFRM.DisplayPopup("ITF情報は数値で入力してください", PopupFormType.Ok, PopupIconType.Information)
            blnCheckErr = True
        End If

        '==========================
        '数値ﾁｪｯｸ
        '==========================
        If txtITF.Text.Length > 14 Then
            Call gobjComFuncFRM.DisplayPopup("ITF情報は14桁以内で入力してください", PopupFormType.Ok, PopupIconType.Information)
            blnCheckErr = True
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

#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01(ByVal strFEQ_ID As String, ByVal strITFVAL As String, ByVal blnMsg As Boolean) As Boolean


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        If blnMsg Then
            Dim udtRet As RetPopup
            Dim strMessage As String
            strMessage = ""
            strMessage &= "送信" & FRM_MSG_FRM200000_01
            udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udtRet <> RetPopup.OK Then
                Return False
            End If
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400704    'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        objTelegram.SETIN_DATA("XDSPSETTEI_EQ_ID", strFEQ_ID)                        '設備ID
        objTelegram.SETIN_DATA("XDSPTEXT_ID", FTEXT_ID_JW_MAINTE_YOTEI)                     'ﾃｷｽﾄID
        objTelegram.SETIN_DATA("XDSPSETTEI_NUM2", strITFVAL)   '設定数


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

        Return True
    End Function
#End Region
End Class
