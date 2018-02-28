'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】通信ﾌｫｰﾑ                 (KSH用ﾃﾞﾊﾞｯｸﾞﾂｰﾙです)
' 【作成】2006/05/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports  "
Imports JOBCommon
Imports MateCommon.clsConst
Imports MateCommon
Imports UserProcess
#End Region

Public Class frmMCIDummyToServer

    '***********************************************
    '↓↓↓↓↓↓毎回必要
#Region "  共通変数             "

    Private mobjDb As clsConn                       'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
    Private mobjMCIMain As CtrlMCIC.clsMCIMain      '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

    '出庫計画明細用構造体
    Private mudtBZPLN_OUT_DTL(33) As BZPLN_OUT_DTL
    Private mintDTL_CNT As Integer
    Private mintDTL_CNT_MAX As Integer = 33

#End Region
#Region "  構造体定義           "
    ''' <summary>出庫計画明細</summary>
    Private Structure BZPLN_OUT_DTL
        Dim BZOUT_REQUEST_NO As String  '出庫指示№
        Dim BZOUT_PLAN_DT As String     '出庫予定日
        Dim BZCASE_NO As String         'ｹｰｽ№
        Dim BZNOUNYU_CD As String       '納入先ｺｰﾄﾞ
        Dim BZNOUNYU_NM As String       '納入先名
        Dim BZTUMI_JUN As String        '積順
        Dim BZSOUKO As String           '倉庫区分
        Dim BZSPARE_14 As String        '予備(16)
    End Structure
#End Region
#Region "　列挙体　             "
#End Region
#Region "  ｲﾍﾞﾝﾄ                "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim objConfig = New clsConnectConfig(CONFIG_MCIA_DUMMY)                     'Configﾌｧｲﾙ接続ｸﾗｽ生成

            '************************************
            '色々初期化
            '************************************
            Me.Text = TO_STRING(objConfig.GET_INFO(GKEY_MCI_FORM_NAME))                 'ﾌｫｰﾑ名ｾｯﾄ
            Me.Text &= "ﾀﾞﾐｰ送信"                                                       'ﾌｫｰﾑ名ｾｯﾄ
            NotifyIcon1.Text = Me.Text                                                  'ｱｲｺﾝ名ｾｯﾄ
            NotifyIcon1.Visible = False                                                 'ｱｲｺﾝ非表示
            mobjMCIMain = New CtrlMCIC.clsMCIMain(Nothing, Nothing, Nothing)            '本当の通信ﾌﾟﾛｸﾞﾗﾑｸﾗｽ

            '--------------------------
            'DB接続開始
            '--------------------------
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            mobjDb = New clsConn                                'ｵﾗｸﾙ接続ｵﾌﾞｼﾞｪｸﾄ
            mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            While True
                '(接続するまでﾙｰﾌﾟ)
                Dim blnRet As Boolean = False
                blnRet = mobjDb.Connect()
                If blnRet = True Then Exit While
            End While


            ''************************************
            ''ｱｲｺﾝ化
            ''************************************
            'Call cmdIcon_ClickProcess()


            '**********************************************************************************************************************
            '↓↓↓↓固有部分


            '↑↑↑↑固有部分
            '**********************************************************************************************************************


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Closeｸﾘｯｸ    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Closeｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Me.Close()

        Catch ex As Exception
            '何もしない

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ化               ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ化 ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcon.Click
        Try

            Call cmdIcon_ClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ｱｲｺﾝ                 ﾀﾞﾌﾞﾙｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try

            Call NotifyIcon1_MouseDoubleClickProcess()

        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ｱｲｺﾝ関係             "
#Region "  ｱｲｺﾝ化       処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ化 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cmdIcon_ClickProcess()

        '自身ﾌｫｰﾑ
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.NotifyIcon1.Visible = True
        Me.Hide()

    End Sub
#End Region
#Region "  ｱｲｺﾝ         ﾀﾞﾌﾞﾙｸﾘｯｸ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱｲｺﾝ ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub NotifyIcon1_MouseDoubleClickProcess()

        '自身ﾌｫｰﾑ
        Me.Show()
        Me.Opacity = 100
        Me.ShowInTaskbar = True
        Me.NotifyIcon1.Visible = False

    End Sub
#End Region
#End Region
#Region "  Boolean型→Integer型に変換"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Boolean型→Integer型に変換
    ''' </summary>
    ''' <param name="blnBoolean"></param>
    ''' <returns></returns>
    ''' *******************************************************************************************************************
    ''' <remarks></remarks>
    Private Function ChangeBooleanToInteger(ByVal blnBoolean As Boolean) As Integer
        Dim intReturn As Integer

        intReturn = IIf(blnBoolean, 1, 0)

        Return intReturn
    End Function
#End Region

#Region "  ｴﾗｰ処理              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">Exceptionｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            gobjMCI.ComError(objException)
            MsgBox(objException)
        Catch ex As Exception
            'NOP
        End Try
    End Sub
#End Region
    '↑↑↑↑↑↑毎回必要
    '***********************************************

#Region "  ｲﾍﾞﾝﾄ                "
#End Region


    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd01.Click
        Try


            '****************************************************
            '送信用文字列       作成
            'ﾊﾞｲﾅﾘﾃﾞｰﾀを16進数のｶﾝﾏ区切りで作成
            '****************************************************
            Dim bytSyaryou() As Byte = System.Text.Encoding.GetEncoding(20290).GetBytes(txtSend002.Text)        '車輌№を取得
            Dim strSendStringLength As String = ""        '送信電文用文字列
            '前半
            strSendStringLength &= txtSend001.Text
            '車輌№
            For ii As Integer = 0 To UBound(bytSyaryou)
                strSendStringLength &= "," & Change10To16(bytSyaryou(ii), 2).ToUpper
            Next
            '後半
            strSendStringLength &= "," & txtSend003.Text


            '****************************************************
            'ﾊﾞｲﾄ配列に変換
            '****************************************************
            Dim strSendString() As String       '送信電文の16進配列
            Dim bytSendString() As Byte         '送信電文の16進配列
            strSendString = Split(strSendStringLength, ",")
            ReDim bytSendString(UBound(strSendString))
            For ii As Integer = LBound(strSendString) To UBound(strSendString)
                '(ﾙｰﾌﾟ:配列数)
                If Change16To10(strSendString(ii)) < 0 Or 255 < Change16To10(strSendString(ii)) Then Throw New Exception("テキストボックスには、カンマ区切りで00～FFの数値を設定して下さい。")
                bytSendString(ii) = Change16To10(strSendString(ii))
            Next


            '****************************************************
            '電文送信
            '****************************************************
            gobjMain.SendDataVClient(bytSendString)             '送信電文


        Catch ex As Exception
            Call ComError(ex)

        End Try
    End Sub
End Class