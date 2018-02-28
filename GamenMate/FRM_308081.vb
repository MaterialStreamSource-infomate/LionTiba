'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】品質ｽﾃｰﾀｽ登録子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308081

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrFPALLET_ID() As String       'ﾊﾟﾚｯﾄID
    Public mstrFLOT_NO_STOCK() As String    '在庫ﾛｯﾄ№

#End Region
#Region "  構造体定義                               "
    ''ｿｹｯﾄ送信情報
    'Private Structure STOCK_DATA
    '    Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
    '    Dim DSPLOT_NO_STOCK As String   'ﾛｯﾄ№
    '    Dim DSPHORYU_KUBUN As String    '保留区分
    '    Dim DSPHORYU_NO As String       '保留№
    '    Dim DSPHORYU_REASON As String   '保留理由
    'End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userPALLET_ID() As String()
        Get
            Return mstrFPALLET_ID
        End Get
        Set(ByVal value As String())
            mstrFPALLET_ID = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>在庫ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFLOT_NO_STOCK() As String()
        Get
            Return mstrFLOT_NO_STOCK
        End Get
        Set(ByVal value As String())
            mstrFLOT_NO_STOCK = value
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
    Private Sub FRM_308081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_308081_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXHINSHITU_STS, True)     '品質ｽﾃｰﾀｽ

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
        cboXHINSHITU_STS.Dispose()
     
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
        If SendSocket02() = False Then
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
                '品質ｽﾃｰﾀｽ  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboXHINSHITU_STS.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboXHINSHITU_STS.SelectedValue.ToString)) = True Then
                    '(品質ｽﾃｰﾀｽが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308081_03, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                If gobjComFuncFRM.KariHikiate_Syukko_Chk() = False Then
                    '(仮引当処理中の時)
                    blnCheckErr = True
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

#Region "  ｿｹｯﾄ送信02                             　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308081_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        Dim strXHINSHITU_STS As String = TO_STRING(cboXHINSHITU_STS.SelectedValue)    '品質ｽﾃｰﾀｽ
   

        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
            '(展開元画面の行分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strDSPPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID
            Dim strDSPLOT_NO_STOCK As String = ""            '在庫ﾛｯﾄ№


            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400402       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strDSPPALLET_ID = mstrFPALLET_ID(ii)                                'ﾊﾟﾚｯﾄID
            strDSPLOT_NO_STOCK = mstrFLOT_NO_STOCK(ii)                          '在庫ﾛｯﾄ№

            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPLOT_NO_STOCK", strDSPLOT_NO_STOCK)    '在庫ﾛｯﾄ№

            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        Next


        '*******************************************************
        ' 電文作成
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strPARA_ID As String = ""

        Dim strXDSPHINSHITU_STS As String = ""                           '品質ｽﾃｰﾀｽ

        strXDSPHINSHITU_STS = strXHINSHITU_STS                           '品質ｽﾃｰﾀｽ

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400402       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPHINSHITU_STS", strXHINSHITU_STS)     '品質ｽﾃｰﾀｽ
        objTelegram.SETIN_DATA("XDSPSYUKKA_KAHI", "")                    '出荷可否
        objTelegram.SETIN_DATA("DSPHORYU_KUBUN", "")                     '保留区分
        objTelegram.SETIN_DATA("XDSPHORYU_NO", "")                       '保留№
        objTelegram.SETIN_DATA("XDSPHORYU_REASON", "")                   '保留理由

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM308081_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnReturn = True
            End If
        End If

        Return blnReturn

    End Function
#End Region

End Class
