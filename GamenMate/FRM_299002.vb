'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｿｹｯﾄ送信ﾂｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_299002

#Region "　共通変数　                               "

    '================================================
    '定数
    '================================================
    'ｸﾞﾘｯﾄﾞ
    Private Const GRIDHEADER_ROW_DSPCMD_ID As Integer = 0        'ﾍｯﾀﾞｰｸﾞﾘｯﾄﾞ    ｺﾏﾝﾄﾞID     行位置
    Private Const GRIDHEADER_ROW_DSPTERM_ID As Integer = 1       'ﾍｯﾀﾞｰｸﾞﾘｯﾄﾞ    端末ID      行位置
    Private Const GRIDHEADER_ROW_DSPUSER_ID As Integer = 2        'ﾍｯﾀﾞｰｸﾞﾘｯﾄﾞ    ﾕｰｻﾞｰID  行位置
    Private Const GRIDCONFIG_ROW_SOCK_SEND_ADDRESS As Integer = 0       '設定情報ｸﾞﾘｯﾄﾞ 送信先ｱﾄﾞﾚｽ 行位置
    Private Const GRIDCONFIG_ROW_SOCK_SEND_PORT As Integer = 1          '設定情報ｸﾞﾘｯﾄﾞ ﾎﾟｰﾄNo      行位置
    Private Const GRIDCONFIG_ROW_SOCK_SEND_TIME_OUT As Integer = 2      '設定情報ｸﾞﾘｯﾄﾞ ﾀｲﾑｱｳﾄ      行位置

    '================================================
    '列挙体
    '================================================
    ''' <summary>ｿｹｯﾄﾃﾞｰﾀｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        ItemName        'ｱｲﾃﾑ名称
        Data            'ﾃﾞｰﾀ
        Item            'ｱｲﾃﾑ名
        Size            'ｻｲｽﾞ
        Data04          'ﾃﾞｰﾀ4(空)
        Data05          'ﾃﾞｰﾀ5(空)
    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  表示ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisp.Click
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  送信ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendFormatSock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendFormatSock.Click
        Try
            Call cmdSendFormatSockProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ASCII変換ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ASCII変換ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdASCII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASCII.Click
        Try
            Call cmdASCIIProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  読込ﾌｧｲﾙｺﾝﾎﾞﾎﾞｯｸｽ選択変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 読込ﾌｧｲﾙｺﾝﾎﾞﾎﾞｯｸｽ選択変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFile_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFile.SelectedIndexChanged
        Try
            Call cboFileSelChange()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  送信ﾃｷｽﾄﾎﾞｯｸｽﾃｷｽﾄ変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾃｷｽﾄﾎﾞｯｸｽﾃｷｽﾄ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtSendText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSendText.TextChanged
        Try
            Call txtSendTextTextChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()


        '*************************************************
        'ﾌｧｲﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ作成
        '*************************************************
        Dim aryData As ArrayList = New ArrayList
        aryData.Add(New GamenCommon.clsCboData("画面用", CONFIG_TELEGRAM_DSP))
        'aryData.Add(New clsCboData("PLC用", CONFIG_TELEGRAM_PLC))
        aryData.Add(New GamenCommon.clsCboData("HDT用", CONFIG_TELEGRAM_HDT))
        cboFile.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboFile.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboFile.DataSource = aryData
        cboFile.SelectedIndex = 0


        '*************************************************
        '設定情報ｸﾞﾘｯﾄﾞ作成
        '*************************************************
        Call grdListSockConfigMake()


        '*************************************************
        'ｺﾏﾝﾄﾞ選択ｺﾝﾎﾞﾎﾞｯｸｽ作成
        '*************************************************
        Call cboCommandNoMake()


    End Sub
#End Region
#Region "  表示ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDispProcess()


        '*************************************************
        'Config取得
        '*************************************************
        Dim strItemName As String = ""      'ｱｲﾃﾑ名称
        Dim strData As String = ""          'ﾃﾞｰﾀ
        Dim strItem As String = ""          'ｱｲﾃﾑ名
        Dim strSize As String = ""          'ｻｲｽﾞ
        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ﾃﾞｰﾀﾃｰﾌﾞﾙ
        Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
        Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
        objDocument.Load(cboFile.SelectedValue)             'ﾃﾞｰﾀﾛｰﾄﾞ

        For Each objNode In objDocument(XML_NODE_CONFIG)(cboCommandID.SelectedValue)
            '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

            If objNode.Name = XML_NODE_ADD Then
                '(ﾃﾞｰﾀ定義の場合)
                strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                strSize = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
            End If
            If objNode.NodeType = Xml.XmlNodeType.Comment Then
                strItemName = objNode.Value
                objDataTable.userAddRowDataSet(strItemName _
                                             , "" _
                                             , strItem _
                                             , strSize _
                                             )
            End If

        Next


        '*************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '*************************************************
        grdSockData.DataSource = objDataTable


        '*************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '*************************************************
        Call grdListSetup(grdSockData)


        '*************************************************
        'ｸﾞﾘｯﾄﾞﾃﾞｰﾀｾｯﾄ
        '*************************************************
        grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPCMD_ID).Value = Microsoft.VisualBasic.Right(cboCommandID.SelectedValue, 6) 'ｺﾏﾝﾄﾞID


    End Sub
#End Region
#Region "  送信ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSendFormatSockProcess()


        '***************************************************
        ' Waitﾌｫｰﾑ表示
        '***************************************************
        Call gobjComFuncFRM.WaitFormShow()


        '*************************************************
        '電文作成
        '*************************************************
        Dim objTelegramSend As New clsTelegram(cboFile.SelectedValue)
        objTelegramSend.FORMAT_ID = Replace(cboCommandID.SelectedValue, XML_NODE_ID_PREFIX, "")     'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        'ﾃﾞｰﾀ部分作成
        For ii As Integer = 0 To grdSockData.RowCount - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)
            objTelegramSend.SETIN_DATA(grdSockData.Item(menmListCol.Item, ii).Value _
                                     , grdSockData.Item(menmListCol.Data, ii).Value _
                                      )
        Next
        'ﾍｯﾀﾞｰ部分作成
        For ii As Integer = 0 To grdSockHeader.RowCount - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)
            objTelegramSend.SETIN_HEADER(grdSockHeader.Item(menmListCol.Item, ii).Value _
                                       , grdSockHeader.Item(menmListCol.Data, ii).Value _
                                        )
        Next
        '電文作成
        objTelegramSend.MAKE_TELEGRAM()


        '***************************************************
        ' ｿｹｯﾄ送信
        '***************************************************
        Dim objSocketSend As New clsSocketClientGamen(gobjOwner)
        objSocketSend.strAddress = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_ADDRESS).Value         '送信先ｱﾄﾞﾚｽ
        objSocketSend.intPortNo = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_PORT).Value             'ﾎﾟｰﾄNo
        objSocketSend.intTimeOut = grdSockConfig.Item(menmListCol.Data, GRIDCONFIG_ROW_SOCK_SEND_TIME_OUT).Value        'ﾀｲﾑｱｳﾄ
        If txtSendText.Text = "" Then
            objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '送信ﾃｷｽﾄ
        Else
            objSocketSend.strSendText = txtSendText.Text                    '送信ﾃｷｽﾄ
        End If
        objSocketSend.blnReceiveFlag = True                             '応答ｿｹｯﾄ待機
        objSocketSend.SendSock()                                        'ｿｹｯﾄ送信


        '***************************************************
        ' Waitﾌｫｰﾑ削除
        '***************************************************
        Call gobjComFuncFRM.WaitFormClose()


        '***************************************************
        ' ｿｹｯﾄ送信正常終了ﾁｪｯｸ
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_01, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_02, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ConnectError
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_SOCKSENDSERVER_03, PopupFormType.Ok, PopupIconType.Err)

        End Select


        '***************************************************
        ' 受信ｿｹｯﾄ解析
        '***************************************************
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strRET_STATE As String                  '応答ｽﾃｰﾀｽ
        Dim strRET_MESSAGE_EXIST As String          '応答ﾒｯｾｰｼﾞ有無
        Dim strRET_MESSAGE As String                '応答ﾒｯｾｰｼﾞ
        Dim strRET_DATA_SYUBETU As String           '応答ﾃﾞｰﾀ種別
        Dim strRET_DATA As String                   '応答ﾃﾞｰﾀ

        objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText                  '分割する電文ｾｯﾄ
        objTelegramRecv.PARTITION()                                                     '電文分割
        strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                      '応答ｽﾃｰﾀｽ
        strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")      '応答ﾒｯｾｰｼﾞ有無
        strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))            '応答ﾒｯｾｰｼﾞ
        strRET_DATA_SYUBETU = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU"))  '応答ﾃﾞｰﾀ種別
        strRET_DATA = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA"))                  '応答ﾃﾞｰﾀ


        '---------------------------------
        'ﾒｯｾｰｼﾞ表示
        '---------------------------------
        If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then

            Select Case Trim(strRET_STATE)
                Case ID_RETURN_RET_STATE_OK
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Information, "", FRM_MSG_SOCKSENDSERVER_91)
                Case ID_RETURN_RET_STATE_NG
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                Case Else
                    Call gobjComFuncFRM.DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
            End Select

        End If


    End Sub
#End Region
#Region "  ASCII変換ﾎﾞﾀﾝｸﾘｯｸ処理                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ASCII変換ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' *******************************************************************************************************************
    ''' <remarks></remarks>
    Private Sub cmdASCIIProcess()


        '***************************************************
        '色々ﾁｪｯｸ
        '***************************************************
        Dim strASCII As String = txtASCII.Text
        If IsNumeric(strASCII) = False Then Throw New Exception("テキストボックスには、カンマ区切りで0～255の数値を設定して下さい。")
        If CInt(strASCII) < 0 Or 255 < CInt(strASCII) Then Throw New Exception("テキストボックスには、カンマ区切りで0～255の数値を設定して下さい。")


        '***************************************************
        '文字列追加
        '***************************************************
        txtSendText.Text &= Chr(CInt(strASCII))


    End Sub
#End Region
#Region "  読込ﾌｧｲﾙｺﾝﾎﾞﾎﾞｯｸｽ選択変更処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 読込ﾌｧｲﾙｺﾝﾎﾞﾎﾞｯｸｽ選択変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFileSelChange()


        '*************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '*************************************************
        '=========================================
        'Config取得
        '=========================================
        Dim strItemName As String = ""      'ｱｲﾃﾑ名称
        Dim strData As String = ""          'ﾃﾞｰﾀ
        Dim strItem As String = ""          'ｱｲﾃﾑ名
        Dim strSize As String = ""          'ｻｲｽﾞ
        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ﾃﾞｰﾀﾃｰﾌﾞﾙ
        Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
        Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
        objDocument.Load(cboFile.SelectedValue)             'ﾃﾞｰﾀﾛｰﾄﾞ

        For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
            '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

            If objNode.Name = XML_NODE_ADD Then
                '(ﾃﾞｰﾀ定義の場合)
                strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                strSize = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
            End If
            If objNode.NodeType = Xml.XmlNodeType.Comment Then
                strItemName = objNode.Value
                objDataTable.userAddRowDataSet(strItemName _
                                             , "" _
                                             , strItem _
                                             , strSize _
                                             )
            End If

        Next

        '=========================================
        'ｸﾞﾘｯﾄﾞ表示
        '=========================================
        grdSockHeader.DataSource = objDataTable

        '=========================================
        'ｸﾞﾘｯﾄﾞ表示設定
        '=========================================
        Call grdListSetup(grdSockHeader)


        '*************************************************
        'ｸﾞﾘｯﾄﾞﾃﾞｰﾀｾｯﾄ
        '*************************************************
        If cboFile.SelectedValue = CONFIG_TELEGRAM_DSP Then
            '(画面用ｿｹｯﾄの場合)
            grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPTERM_ID).Value = gcstrFTERM_ID       '端末ID
            grdSockHeader.Item(menmListCol.Data, GRIDHEADER_ROW_DSPUSER_ID).Value = gcstrFUSER_ID         'ﾕｰｻﾞｰID
        End If



        '*************************************************
        'ｺﾏﾝﾄﾞ選択ｺﾝﾎﾞﾎﾞｯｸｽ作成
        '*************************************************
        Call cboCommandNoMake()


    End Sub
#End Region
#Region "  送信ﾃｷｽﾄﾎﾞｯｸｽﾃｷｽﾄ変更処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信ﾃｷｽﾄﾎﾞｯｸｽﾃｷｽﾄ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtSendTextTextChangedProcess()

        If txtSendText.Text = "" Then
            grdSockData.Visible = True
            grdSockHeader.Visible = True
        Else
            grdSockData.Visible = False
            grdSockHeader.Visible = False
        End If

    End Sub
#End Region

#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <param name="objGrid">設定するｸﾞﾘｯﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup(ByRef objGrid As DataGridView)

        '***********************
        '初期設定
        '***********************
        objGrid.RowHeadersVisible = False                                   '行ﾍｯﾀﾞｰ表示        許可設定
        objGrid.AllowUserToResizeColumns = False                            '列のｻｲｽﾞ変更       許可設定
        objGrid.MultiSelect = False                                         '複数ｾﾙ同時選択     許可設定
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '選択ﾓｰﾄﾞ
        objGrid.AllowUserToAddRows = False                                  '行追加             許可設定
        objGrid.AllowUserToDeleteRows = False                               '行削除             許可設定
        objGrid.AllowUserToResizeRows = False                               '行ｻｲｽﾞ変更         許可設定
        objGrid.AllowUserToOrderColumns = False                             '列移動             許可設定
        For Each objColum As DataGridViewColumn In objGrid.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '列の並替禁止
        Next

        '***********************
        'ﾍｯﾀﾞｰ表示変更
        '***********************
        objGrid.Columns(menmListCol.ItemName).HeaderText = "ｱｲﾃﾑ名称"
        objGrid.Columns(menmListCol.Data).HeaderText = "ﾃﾞｰﾀ"
        objGrid.Columns(menmListCol.Item).HeaderText = "ｱｲﾃﾑ名"
        objGrid.Columns(menmListCol.Size).HeaderText = "ｻｲｽﾞ"


        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        objGrid.Columns(menmListCol.ItemName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Data).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Item).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        objGrid.Columns(menmListCol.Size).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        '***********************
        '非表示
        '***********************
        objGrid.Columns(menmListCol.Data04).Visible = False
        objGrid.Columns(menmListCol.Data05).Visible = False


        '***********************
        '列幅調整
        '***********************
        objGrid.Columns(menmListCol.ItemName).Width = 150
        objGrid.Columns(menmListCol.Data).Width = 150
        objGrid.Columns(menmListCol.Item).Width = 150
        objGrid.Columns(menmListCol.Size).Width = 40


        '***********************
        '編集ﾛｯｸ
        '***********************
        objGrid.Columns(menmListCol.ItemName).ReadOnly = True
        objGrid.Columns(menmListCol.Data).ReadOnly = False
        objGrid.Columns(menmListCol.Item).ReadOnly = True
        objGrid.Columns(menmListCol.Size).ReadOnly = True


        '***********************
        '初期選択
        '***********************
        Try
            'ﾃﾞｰﾀが表示されない場合もある為
            objGrid(-1, -1).Selected = True
        Catch ex As Exception
        End Try

    End Sub
#End Region
#Region "　ｺﾏﾝﾄﾞ選択ｺﾝﾎﾞﾎﾞｯｸｽ作成                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ選択ｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboCommandNoMake()
        Dim strDisp As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ表示ﾃﾞｰﾀ
        Dim strData As String = ""                          'ｺﾝﾎﾞﾎﾞｯｸｽ内部ﾃﾞｰﾀ
        Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
        Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
        Dim aryData As ArrayList = New ArrayList


        '***********************
        'XML読込
        '***********************
        objDocument.Load(cboFile.SelectedValue)             'ﾃﾞｰﾀﾛｰﾄﾞ
        cboCommandID.DataSource = Nothing
        For Each objNode In objDocument(XML_NODE_CONFIG).ChildNodes
            '(ﾙｰﾌﾟ:定義されたﾉｰﾄﾞ数)

            If IsNull(objNode.Value) = False Then
                strDisp = objNode.Value  'ｺﾒﾝﾄ文取得
            End If
            strData = objNode.Name       'ﾉｰﾄﾞ名取得
            If 1 <= InStr(strData, XML_NODE_ID_PREFIX) Then
                aryData.Add(New GamenCommon.clsCboData(strDisp, strData))
            End If

        Next
        cboCommandID.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboCommandID.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboCommandID.DataSource = aryData
        cboCommandID.SelectedIndex = 0


        '*************************************************
        '表示ﾎﾞﾀﾝｸﾘｯｸ処理
        '*************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "　設定情報ｸﾞﾘｯﾄﾞ作成                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設定情報ｸﾞﾘｯﾄﾞ作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSockConfigMake()


        '*************************************************
        'ﾃﾞｰﾀをｾｯﾄ
        '*************************************************
        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ﾃﾞｰﾀﾃｰﾌﾞﾙ
        objDataTable.userAddRowDataSet("送信先ｱﾄﾞﾚｽ", gcstrSOCK_SEND_ADDRESS)
        objDataTable.userAddRowDataSet("ﾎﾟｰﾄNo", gcstrSOCK_SEND_PORT)
        objDataTable.userAddRowDataSet("ﾀｲﾑｱｳﾄ", gcstrSOCK_SEND_TIME_OUT)


        '*************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '*************************************************
        grdSockConfig.DataSource = objDataTable


        '*************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '*************************************************
        Call grdListSetup(grdSockConfig)
        grdSockConfig.Columns(menmListCol.ItemName).Width = 90
        grdSockConfig.Columns(menmListCol.Data).Width = 131
        grdSockConfig.Columns(menmListCol.Item).Visible = False
        grdSockConfig.Columns(menmListCol.Size).Visible = False


    End Sub
#End Region
#Region "　ｴﾗｰ処理                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴｸｾﾌﾟｼｮﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            Call gobjComFuncFRM.ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class