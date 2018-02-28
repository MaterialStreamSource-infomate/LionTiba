'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】棚卸し作業実施確認画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305012

#Region "  共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrHINMEI_CD_SRCH As String   '検索条件品名ｺｰﾄﾞ
    Public mstrTR_TO As String            '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
    Public mstrFPALLET_ID() As String     'ﾊﾟﾚｯﾄID
    Public mstrBUF_NO() As String         'ﾊﾞｯﾌｬ№
    Public mstrBUF_ARRAY() As String      'ﾊﾞｯﾌｬ配列№

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>検索条件品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userHINMEI_CD_SRCH() As String
        Get
            Return mstrHINMEI_CD_SRCH
        End Get
        Set(ByVal value As String)
            mstrHINMEI_CD_SRCH = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userTR_TO() As String
        Get
            Return mstrTR_TO
        End Get
        Set(ByVal value As String)
            mstrTR_TO = value
        End Set
    End Property

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
    ''' <summary>ﾊﾞｯﾌｬ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userBUF_NO() As String()
        Get
            Return mstrBUF_NO
        End Get
        Set(ByVal value As String())
            mstrBUF_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾞｯﾌｬ配列№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userBUF_ARRAY() As String()
        Get
            Return mstrBUF_ARRAY
        End Get
        Set(ByVal value As String())
            mstrBUF_ARRAY = value
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
    Private Sub FRM_305012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_305012_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

        '↓↓↓↓ 2012.12.19 14:30 H.Morita 出庫ﾊﾟﾚｯﾄ数表示対応 
        '出庫ﾊﾟﾚｯﾄ数の設定
        lblSYUKO_PALLET_SU.Text = UBound(mstrFPALLET_ID) + 1
        '↑↑↑↑ 2012.12.19 14:30 H.Morita 出庫ﾊﾟﾚｯﾄ数表示対応 

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
        chkAUTO_NYUKO_FLAG.Dispose()

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

        Me.DialogResult = Windows.Forms.DialogResult.OK

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

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

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

        ''**********************************************************
        '' 確認ﾒｯｾｰｼﾞ表示 CHKBOX有り
        ''**********************************************************
        'Dim udtRet As RetPopup
        'Dim strMessage As String
        'strMessage = ""
        'strMessage &= FRM_MSG_FRM305010_01
        'udtRet = gobjComFuncFRM.DisplayChckBoxPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest, "自動入庫", mFlag_AUTO_NYUUKO, , "棚卸し作業実施確認")
        'If udtRet <> RetPopup.OK Then
        '    Exit Function
        'End If

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
            Dim strDSPTRK_BUF_NO As String = ""              'ﾊﾞｯﾌｬ№
            Dim strDSPTRK_BUF_ARRAY As String = ""           'ﾊﾞｯﾌｬ配列№
            Dim strDSPPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400301       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strDSPTRK_BUF_NO = mstrBUF_NO(ii)                                   'ﾊﾞｯﾌｬ№
            strDSPTRK_BUF_ARRAY = mstrBUF_ARRAY(ii)                             'ﾊﾞｯﾌｬ配列№
            strDSPPALLET_ID = mstrFPALLET_ID(ii)                                'ﾊﾟﾚｯﾄID

            objTelegramSub.SETIN_DATA("DSPTRK_BUF_NO", strDSPTRK_BUF_NO)        'ﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("DSPTRK_BUF_ARRAY", strDSPTRK_BUF_ARRAY)  'ﾊﾞｯﾌｬ配列№
            objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID

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

        Dim strXDSPTANA_DT As String = TO_STRING(System.DateTime.Now)          '棚卸し日時
        Dim strDSPTR_TO As String = mstrTR_TO                                  '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strDSPAUTO_NYUKO_FLAG As String = ""                               '自動入庫ﾌﾗｸﾞ

        If chkAUTO_NYUKO_FLAG.Checked = False Then
            strDSPAUTO_NYUKO_FLAG = TO_STRING(XAUTO_NYUKO_FLAG_JOFF)    '自動入庫ﾌﾗｸﾞ(OFF)
        Else
            strDSPAUTO_NYUKO_FLAG = TO_STRING(XAUTO_NYUKO_FLAG_JON)     '自動入庫ﾌﾗｸﾞ(ON)
        End If

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400301      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPTANA_DT", strXDSPTANA_DT)                 '棚卸し日時
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", "")                           'ﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", "")                        'ﾊﾞｯﾌｬ配列№
        objTelegram.SETIN_DATA("DSPTR_TO", strDSPTR_TO)                       '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objTelegram.SETIN_DATA("DSPPALLET_ID", "")                            'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("XDSPAUTO_NYUKO_FLAG", strDSPAUTO_NYUKO_FLAG)  '自動入庫ﾌﾗｸﾞ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM305010_02
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
