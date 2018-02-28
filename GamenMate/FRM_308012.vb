'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾊﾞｰｽﾓﾆﾀｰ子画面(ﾊﾞｰｽ指定)
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308012

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrXCAR_NO_WARITUKE As String        '受付車番(代表車番)
    Public mstrXCAR_NO_EDA_WARITUKE As String    '受付車番枝番(代表車番枝番)
    Public mstrXBERTH_SITEI As String            'ﾊﾞｰｽ指定

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>受付車番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_WARITUKE() As String
        Get
            Return mstrXCAR_NO_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_WARITUKE = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>受付車番枝番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_EDA_WARITUKE() As String
        Get
            Return mstrXCAR_NO_EDA_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA_WARITUKE = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾞｰｽ指定</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXBERTH_SITEI() As String
        Get
            Return mstrXBERTH_SITEI
        End Get
        Set(ByVal value As String)
            mstrXBERTH_SITEI = value
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
    Private Sub FRM_308012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_308012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " 実行ﾎﾞﾀﾝｸﾘｯｸ                              "
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
#Region " ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                        "
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
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboXBERTH_SITEI, True, mstrXBERTH_SITEI)   'ﾊﾞｰｽ指定

        '**********************************************************
        'ﾃｷｽﾄﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        lblXCAR_NO_WARITUKE.Text = mstrXCAR_NO_WARITUKE & "-" & mstrXCAR_NO_EDA_WARITUKE   '受付車番

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
        cboXBERTH_SITEI.Dispose()
        lblXCAR_NO_WARITUKE.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
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
        If SendSocket01() = False Then
            Exit Sub
        End If

        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case "a"
            Case "a"

                '==========================
                'ﾊﾞｰｽ指定  選択ﾁｪｯｸ
                '==========================
                'If TO_STRING(cboXBERTH_SITEI.SelectedValue.ToString) = CBO_ALL_VALUE _
                '        Or IsNull(TO_STRING(cboXBERTH_SITEI.SelectedValue.ToString)) = True Then
                '    '(ﾊﾞｰｽ指定が選択されていない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_01, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If
                
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

#Region "  ｿｹｯﾄ送信01                             　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket01() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308012_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        ''********************************************************************
        '' ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strXDSPCAR_NO As String = ""                              '車番
        Dim strXDSPCAR_NO_EDA As String = ""                          '車番枝番
        Dim strXDSPBERTH_SITEI As String = ""                         'ﾊﾞｰｽ指定

        strXDSPCAR_NO = mstrXCAR_NO_WARITUKE                          '車番
        strXDSPCAR_NO_EDA = mstrXCAR_NO_EDA_WARITUKE                  '車番枝番

        If TO_STRING(cboXBERTH_SITEI.SelectedValue.ToString) = CBO_ALL_VALUE _
                Or IsNull(TO_STRING(cboXBERTH_SITEI.SelectedValue.ToString)) = True Then
            '(ﾊﾞｰｽ指定が選択されていない場合)
            strXDSPBERTH_SITEI = "0"                                      'ﾊﾞｰｽ指定(取消)
        Else
            '(ﾊﾞｰｽ指定が選択されている場合)
            strXDSPBERTH_SITEI = TO_STRING(cboXBERTH_SITEI.SelectedValue) 'ﾊﾞｰｽ指定
        End If

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400701       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", FORMAT_DSP_DSPDIR_KUBUN_UPDATE)          '処理区分  
        'objTelegram.SETIN_DATA("XDSPCAR_NO", strXDSPCAR_NO)                             '車番
        'objTelegram.SETIN_DATA("XDSPCAR_NO_EDA", strXDSPCAR_NO_EDA)                     '車番枝番
        objTelegram.SETIN_DATA("XDSPBERTH_SITEI", strXDSPBERTH_SITEI)                   'ﾊﾞｰｽ指定

        objTelegram.SETIN_DATA("XDSPCAR_NO_DAIHYOU", strXDSPCAR_NO)                     '代表車番
        objTelegram.SETIN_DATA("XDSPCAR_NO_EDA_DAIHYOU", strXDSPCAR_NO_EDA)             '代表車番枝番

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308012_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308012_02
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region

End Class
