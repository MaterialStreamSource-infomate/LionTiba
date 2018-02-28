'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports System.Text
Imports System.Xml
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
Imports System.Net
Imports UserProcess
#End Region

Public Class clsComFuncPDA
    Inherits GamenCommon.clsComFuncGMN

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾞﾛｰﾊﾞﾙ変数                          "
    '**********************************************************************************************
    '　ｸﾞﾛｰﾊﾞﾙ変数
    '**********************************************************************************************
    Protected Friend Shared gobjComFuncPDA As New clsComFuncPDA   '共通関数ｵﾌﾞｼﾞｪｸﾄ

    Public Shared gobjPDA_100001 As PDA_100001          'ﾛｸﾞｲﾝ
    Public Shared gobjPDA_100004 As PDA_100004          'Wait画面
    Public Shared gobjPDA_100005 As PDA_100005          '離席ﾛｸﾞｲﾝ
    Public Shared gobjPDA_100007 As PDA_100007          'ﾊﾟｽﾜｰﾄﾞ確認画面
    Public Shared gobjPDA_100102 As PDA_100102          '確認画面1
    Public Shared gobjPDA_100103 As PDA_100103          '確認画面2
    Public Shared gobjPDA_100201 As PDA_100201          'ﾊﾞｰｺｰﾄﾞNG
    Public Shared gobjPDA_201000 As PDA_201000          '車輌№入力

    Public Shared gcintAfkAutoFlg As Integer                '自動離席処理有効               ﾌﾗｸﾞ

    '品名毎積み数合計 用構造体
    Public Shared gudtHINMEI_SUM() As HINMEI_SUM

    ''' <summary>品名毎積み数合計</summary>
    Public Structure HINMEI_SUM
        Dim HINMEI_CD As String         '品名ｺｰﾄﾞ
        Dim KENPIN_VOL As Decimal       '検品数

    End Structure

    ''' <summary>出庫ﾓｰﾄﾞ</summary>
    Public Enum OutMode
        OUT_MODE = 0                    '出庫ﾓｰﾄﾞ
        PICK_MODE = 1                   'ﾋﾟｯｷﾝｸﾞﾓｰﾄﾞ
    End Enum

#End Region
#Region "  ﾛｸﾞｵﾌ  ﾎﾞﾀﾝ押下処理　                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｵﾌ  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function cmdClose_ClickProccess() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim udeRet As RetPopup

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> RetPopup.OK Then
            Return blnReturn
            Exit Function
        End If


        '*******************************************************
        'ｼｬｯﾄﾀﾞｳﾝor画面ｸﾛｰｽﾞ処理
        '*******************************************************
        Dim intShutDownFlg As Integer
        Try
            intShutDownFlg = TO_INTEGER(gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_001))
        Catch ex As Exception
            '(ｼｽﾃﾑ変数取得でｴﾗｰが出た場合)
            gobjComFuncPDA.ComError_frm(ex)
            intShutDownFlg = FLAG_OFF
        End Try

        If intShutDownFlg = FLAG_ON Then
            '(ｼｬｯﾄﾀﾞｳﾝﾌﾗｸﾞがONの場合)

            '----------------------------------------
            ' ｼｬｯﾄﾀﾞｳﾝ
            '----------------------------------------
            Call PubF_ShutDown()            ' ｼｬｯﾄﾀﾞｳﾝ

        Else
            '(ｼｬｯﾄﾀﾞｳﾝﾌﾗｸﾞがON以外の場合)

            '----------------------------------------
            ' 画面ｸﾛｰｽﾞ
            '----------------------------------------
            If IsNull(gobjPDA_201000) = False Then
                gobjPDA_201000.Close()
                gobjPDA_201000.Dispose()
                gobjPDA_201000 = Nothing
            End If

        End If

        blnReturn = True
        Return blnReturn


    End Function
#End Region
#Region "  ｼｬｯﾄﾀﾞｳﾝ         処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｬｯﾄﾀﾞｳﾝ処理
    ''' </summary>
    ''' <returns>正常：True     異常：False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function PubF_ShutDown() As Boolean
        Dim flags As PDA_logoff.ShutdownFlag

        PubF_ShutDown = False

        Try

            flags = PDA_logoff.ShutdownFlag.LogOff

            '' EWX_FORCEIFHUNG
            ''ハングアップしたプログラムも終了
            'flags = flags Or _
            '            Shutdown.ShutdownFlag.ForceIfHung

            ' ﾛｸﾞｵﾌを実行
            PDA_logoff.ExitWindows(flags)

            PubF_ShutDown = True

        Catch ex As Exception
            Throw ex
        Finally
            If IsNull(flags) = False Then
                flags = Nothing
            End If
            If IsNull(flags) = False Then
                flags = Nothing
            End If
        End Try
    End Function
#End Region
#Region "  場所切替  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 場所切替  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub PlaceChangeProccess(ByVal objFRM As Object)
        Try
            ''Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_202000, objFRM)
        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓PDA共通 ｵｰﾊﾞｰﾛｰﾄﾞ
#Region "  Waitﾌｫｰﾑ         Show、Close処理     "
    Public Overrides Sub WaitFormShow()

        '***************************************************
        ' ﾒｯｾｰｼﾞ表示
        '***************************************************
        If IsNull(gobjPDA_100004) = False Then
            gobjPDA_100004.Close()
            gobjPDA_100004.Dispose()
            gobjPDA_100004 = Nothing
        End If
        gobjPDA_100004 = New PDA_100004
        gobjPDA_100004.Show()
        gobjPDA_100004.Refresh()

    End Sub

    Public Overrides Sub WaitFormClose()

        '***************************************************
        ' ﾒｯｾｰｼﾞ削除
        '***************************************************
        If IsNull(gobjPDA_100004) = False Then
            gobjPDA_100004.Close()
            gobjPDA_100004.Dispose()
            gobjPDA_100004 = Nothing
        End If

    End Sub

#End Region
#Region "  ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ        表示処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ 表示処理
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtFormType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="udtIconType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾃﾞﾌｫﾙﾄﾎﾟｯﾌﾟｱｯﾌﾟ表示名</param>
    ''' <param name="blnAddLog"></param>
    ''' <returns>ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ戻値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayPopup(ByVal strMessage As String _
                                              , ByVal udtFormType As PopupFormType _
                                              , ByVal udtIconType As PopupIconType _
                                              , Optional ByVal strSupplement As String = "" _
                                              , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                              , Optional ByVal blnAddLog As Boolean = True _
                                                ) As RetPopup

        strTitle = GAMEN_POPUPFORM_TITLE_PDA

        '***********************************************************
        ' ﾛｸﾞ書込み処理
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncPDA.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ表示
        '***********************************************************
        Dim udtPopupRet As RetPopup
        Select Case udtFormType
            Case PopupFormType.Ok
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ﾌｫｰﾑ

            Case PopupFormType.Ok_Cancel
                udtPopupRet = Display_frmPopup_02(strMessage, udtIconType, strSupplement, strTitle)       'OK/CANCEL      ﾌｫｰﾑ

            Case Else
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ﾌｫｰﾑ

        End Select


        Return (udtPopupRet)
    End Function

#Region "  frmPopup_01          表示処理"
    Private Function Display_frmPopup_01(ByVal strMessage As String _
                                                      , ByVal udtIconType As PopupIconType _
                                                      , ByVal strSupplement As String _
                                                      , ByVal strTitle As String _
                                                        ) _
                                                        As RetPopup
        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjPDA_100102) = False Then
            gobjPDA_100102.Close()
            gobjPDA_100102.Dispose()
            gobjPDA_100102 = Nothing
        End If
        gobjPDA_100102 = New PDA_100102

        gobjPDA_100102.lblTitle.Text = strTitle                            'ﾌｫｰﾑﾀｲﾄﾙ
        gobjPDA_100102.userIconType = udtIconType                          'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjPDA_100102.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjPDA_100102.ShowDialog()                                        '表示

        udtRet = gobjPDA_100102.userRet                                    '戻り値設定

        If IsNull(gobjPDA_100102) = False Then
            gobjPDA_100102.Dispose()
            gobjPDA_100102 = Nothing
        End If

        Return (udtRet)
    End Function
#End Region
#Region "  frmPopup_02          表示処理"
    Private Function Display_frmPopup_02(ByVal strMessage As String _
                                                      , ByVal udtIconType As PopupIconType _
                                                      , ByVal strSupplement As String _
                                                      , ByVal strTitle As String _
                                                        ) _
                                                        As RetPopup

        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjPDA_100103) = False Then
            gobjPDA_100103.Close()
            gobjPDA_100103.Dispose()
            gobjPDA_100103 = Nothing
        End If
        gobjPDA_100103 = New PDA_100103

        gobjPDA_100103.lblTitle.Text = strTitle                            'ﾌｫｰﾑﾀｲﾄﾙ
        gobjPDA_100103.userIconType = udtIconType                          'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjPDA_100103.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjPDA_100103.ShowDialog()                                        '表示

        udtRet = gobjPDA_100103.userRet                                    '戻り値設定

        If IsNull(gobjPDA_100103) = False Then
            gobjPDA_100103.Dispose()
            gobjPDA_100103 = Nothing
        End If

        Return (udtRet)
    End Function
#End Region

#End Region
#Region "  画面遷移（画面IDで遷移）             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移（画面IDで遷移）
    ''' </summary>
    ''' <param name="strDISP_ID">画面ID</param>
    ''' <param name="objFormNow">ﾓｰﾀﾞﾙに遷移するかどうか（ﾃﾞﾌｫﾙﾄではﾓｰﾀﾞﾚｽ）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub FormMoveSelect(ByVal strDISP_ID As String _
                                           , ByRef objFormNow As Object _
                                           )



    End Sub
#End Region
#Region "　画面離席処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面離席処理
    ''' </summary>
    ''' <param name="objForm"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub AfkProc(ByRef objForm As Form)

        '****************************************************
        '離席ﾛｸﾞｲﾝ設定画面表示
        '****************************************************
        gobjPDA_100005 = Nothing
        gobjPDA_100005 = New PDA_100005     '離席ﾛｸﾞｲﾝ設定画面

        Try

            '*******************************************************
            'ｿｹｯﾄ送信処理
            '*******************************************************
            Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200005           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            Call gobjComFuncPDA.SockSendServer01(objTelegram)                                  'ｿｹｯﾄ送信


            '****************************************************
            '画面表示
            '****************************************************
            gobjPDA_100005.ShowDialog()


            '****************************************************
            'ﾛｸﾞｲﾝ/ﾛｸﾞｵﾌﾁｪｯｸ
            '****************************************************
            Dim udtAFKFrmRet As AFKFrmRetType
            udtAFKFrmRet = gobjPDA_100005.AFKFORMRET

            '===============================
            'ﾛｸﾞｲﾝ/ﾛｸﾞｵﾌﾁｪｯｸ
            '===============================
            If udtAFKFrmRet = AFKFrmRetType.LogOff Then
                '(強制ﾛｸﾞｵﾌの場合)

                '***************************************************************
                'ﾛｸﾞｲﾝ画面表示
                '***************************************************************
                If gblnLogoff = False Then
                    gblnLogoff = True
                    Call gobjComFuncPDA.PubF_ShellExe(System.Reflection.Assembly.GetExecutingAssembly().Location)
                End If

                '***************************************************************
                '自分自身のﾌﾟﾛｾｽ情報取得
                '***************************************************************
                Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                '======================================
                '自分自身を終了
                '======================================
                hProcess.Kill()

            End If

        Catch ex As Exception
            Call gobjComFuncPDA.ComError_frm(ex)
            Throw ex

        Finally

            '===============================
            'ｵﾌﾞｼﾞｪｸﾄ開放
            '===============================
            If IsNull(gobjPDA_100005) = False Then
                gobjPDA_100005.Dispose()
                gobjPDA_100005 = Nothing
            End If

        End Try
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ確認処理                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ確認処理
    ''' </summary>
    ''' <param name="strFDISP_ID">画面ID</param>
    ''' <param name="strFCTRL_ID">ｺﾝﾄﾛｰﾙID</param>
    ''' <returns>True:ﾊﾟｽﾜｰﾄﾞ確認成功    False:ﾊﾟｽﾜｰﾄﾞ確認失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overrides Function PassWordCheck(ByVal strFDISP_ID As String _
                                               , ByVal strFCTRL_ID As String _
                                                 ) _
                                                 As Boolean
        Dim intRet As RetCode
        Dim blnReturn As Boolean = True     '戻り値(基本OKにしておく)


        '******************************************
        ' 画面ﾏｽﾀ取得
        '******************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objTDSP_NAME.FDISP_ID = strFDISP_ID        '画面ID
        objTDSP_NAME.FCTRL_ID = strFCTRL_ID        'ｺﾝﾄﾛｰﾙID
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            blnReturn = True
            Return blnReturn
        End If


        '******************************************
        ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
        '******************************************
        If objTDSP_NAME.FPASS_CHECK_FLAG = FPASS_CHECK_FLAG_SON Then
            '(ﾊﾟｽﾜｰﾄﾞﾁｪｯｸありの場合)

            '***********************************************************
            ' ﾊﾟｽﾜｰﾄﾞ確認画面表示
            '***********************************************************
            Dim udtRet As RetPopup
            If IsNull(gobjPDA_100007) = False Then
                gobjPDA_100007.Close()
                gobjPDA_100007.Dispose()
                gobjPDA_100007 = Nothing
            End If
            gobjPDA_100007 = New PDA_100007
            gobjPDA_100007.ShowDialog()                                        '表示
            udtRet = gobjPDA_100007.userRet                                    '戻り値設定
            If udtRet = RetPopup.OK Then
                '(ﾊﾟｽﾜｰﾄﾞ認証OKの場合)
                blnReturn = True
            Else
                '(ﾊﾟｽﾜｰﾄﾞ認証NGの場合)
                blnReturn = False
            End If

            If IsNull(gobjPDA_100007) = False Then
                gobjPDA_100007.Dispose()
                gobjPDA_100007 = Nothing
            End If

        Else
            '(ﾊﾟｽﾜｰﾄﾞﾁｪｯｸなしの場合)
            blnReturn = True
        End If


        Return blnReturn
    End Function
#End Region
    '↑↑↑PDA共通 ｵｰﾊﾞｰﾛｰﾄﾞ
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有 ｵｰﾊﾞｰﾛｰﾄﾞ

    '↑↑↑ｼｽﾃﾑ固有 ｵｰﾊﾞｰﾛｰﾄﾞ
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "　ｸﾞﾘｯﾄﾞ初期設定処理(選択用)           "
    ''' ******************************************************************************
    ''' <summary>ｸﾞﾘｯﾄﾞ初期設定処理(BC用) </summary>
    ''' <param name="objGrid">     FlexGridｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intRowsCount">行数</param>
    ''' <param name="intColsCount">列数</param>
    ''' ******************************************************************************
    Public Sub FlexGridInitialize02(ByRef objGrid As GamenCommon.cmpMDataGrid, _
                                         ByVal intRowsCount As Integer, _
                                         ByVal intColsCount As Integer)


        '=========================================
        'ｸﾞﾘｯﾄﾞ初期設定
        '=========================================
        objGrid.DataSource = Nothing
        objGrid.ColumnCount = intColsCount                    '列数

        '=========================================
        'ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ値設定
        '=========================================
        Call gobjComFuncPDA.FlexGridInitialize02(objGrid)


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ処理(選択用)             "
    ''' ******************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ処理(BC用)
    ''' </summary>
    ''' <param name="objGrid">FlexGridｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************
    Public Sub FlexGridInitialize02(ByRef objGrid As GamenCommon.cmpMDataGrid)

        '=========================================
        'ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ値設定
        '=========================================
        objGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing        '列ﾍｯﾀﾞｻｲｽﾞ変更     許可設定
        objGrid.ColumnHeadersHeight = GRID_HEIGHT_TITLE_DBL                             'ﾍｯﾀﾞｰ2行表示のｾﾙの高さ
        objGrid.ReadOnly = True                                                         'ｾﾙの編集           許可設定
        objGrid.RowHeadersVisible = False                                               '行ﾍｯﾀﾞ             表示設定
        objGrid.AllowUserToResizeRows = False                                           '行のｻｲｽﾞ変更       許可設定
        objGrid.MultiSelect = False                                                     '複数ｾﾙ同時選択     許可設定
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect                 '選択ﾓｰﾄﾞ
        objGrid.AllowUserToAddRows = False                                              '行追加             許可設定
        objGrid.AllowUserToDeleteRows = False                                           '行削除             許可設定
        objGrid.AllowUserToOrderColumns = False                                         '列移動             許可設定
        objGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue           '列ﾍｯﾀﾞ色調整

        For Each objColum As DataGridViewColumn In objGrid.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

        objGrid.Font = New Font("ＭＳ ゴシック", 16.25, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        objGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Yellow                  'ﾌｫﾝﾄ設定



        objGrid.AllowUserToResizeColumns = False                        'ﾍｯﾀﾞｰ幅変更不可
        objGrid.RowTemplate.Height = GRID_HEIGHT_TITLE_DBL


    End Sub
#End Region
#Region "  小数点以下桁数取得                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 小数点以下桁数取得
    ''' </summary>
    ''' <param name="intValue">対象の数値</param>
    ''' <returns>小数点以下桁数</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetPrecision(ByVal intValue As Decimal) As Integer

        GetPrecision = (intValue - CInt(intValue)).ToString().TrimEnd("0"c).Replace("0.", String.Empty).Replace("-", String.Empty).Length
        Return GetPrecision

    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************



End Class
