'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷作業終了受付処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400107
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            If IsNull(strDenbunDtl(DSPUSER_ID)) Then strDenbunDtl(DSPUSER_ID) = FUSER_ID_SKOTEI
            If IsNull(strDenbunDtl(DSPTERM_ID)) Then strDenbunDtl(DSPTERM_ID) = FTERM_ID_SKOTEI
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            '追加SQL作成
            '************************
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値
            strSQL = ""
            strSQL &= vbCrLf & " INSERT INTO"
            strSQL &= vbCrLf & "    XRST_OUT"
            strSQL &= vbCrLf & " ("
            strSQL &= vbCrLf & " SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XRST_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    NOT EXISTS("
            strSQL &= vbCrLf & "               SELECT"
            strSQL &= vbCrLf & "                  *"
            strSQL &= vbCrLf & "               FROM"
            strSQL &= vbCrLf & "                  XRST_OUT"
            strSQL &= vbCrLf & "               WHERE"
            strSQL &= vbCrLf & "                      XRST_OUT.XSYUKKA_D         = XRST_OUT_DTL.XSYUKKA_D"              '出荷日
            strSQL &= vbCrLf & "                  AND XRST_OUT.XHENSEI_NO        = XRST_OUT_DTL.XHENSEI_NO"             '編成No.
            strSQL &= vbCrLf & "                  AND XRST_OUT.XDENPYOU_NO       = XRST_OUT_DTL.XDENPYOU_NO"            '伝票No.
            strSQL &= vbCrLf & "                  AND XRST_OUT.XSYUKKA_RESULT_DT = XRST_OUT_DTL.XSYUKKA_RESULT_DT"      '出荷実績日時
            strSQL &= vbCrLf & "                  AND XRST_OUT.FPALLET_ID        = XRST_OUT_DTL.FPALLET_ID"             'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "              )"
            strSQL &= vbCrLf & " )"
            strSQL &= vbCrLf


            '************************
            '追加
            '************************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_ADD & "  " & strMsg
                Throw New System.Exception(strMsg)
            End If


            '************************************************
            '操業履歴                   更新
            '************************************************
            Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)
            objXRST_SOUGYOU.GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX()     '取得
            If IsNull(objXRST_SOUGYOU.XSYUKKA_END_DT) Then
                objXRST_SOUGYOU.XSYUKKA_END_DT = Now                '出荷終了日時
                objXRST_SOUGYOU.UPDATE_XRST_SOUGYOU()               '更新
            End If


            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Return RetCode.OK


        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  事前ﾁｪｯｸ                                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '値漏れﾁｪｯｸ
            '************************
            If 1 = 1 Then
            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  既存出荷実績削除                                 "
    '==============================================================================================
    '【機能】既存出荷実績削除
    '【引数】[IN ] dtmSOUGYOU_D         :操業日
    '【戻値】無し
    '==============================================================================================
    Private Sub Delete_XRST_OUT(ByVal dtmSOUGYOU_D As Date)
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '-----------------------
            '削除SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XRST_OUT"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_D >= TO_DATE('" & Format(dtmSOUGYOU_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"   '出荷日
            strSQL &= vbCrLf


            '-----------------
            '削除
            '-----------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_DELETE & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  出荷実績登録                                     "
    '==============================================================================================
    '【機能】出荷実績登録
    '【引数】[IN ] dtmSOUGYOU_D         :操業日
    '【戻値】無し
    '==============================================================================================
    Private Sub Add_RST_OUT(ByVal dtmSOUGYOU_D As Date)
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '-----------------------
            '追加SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "INSERT INTO"
            strSQL &= vbCrLf & "    XRST_OUT"
            strSQL &= vbCrLf & " ("
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XRST_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XRST_OUT_DTL.XSYUKKA_D >= TO_DATE('" & Format(dtmSOUGYOU_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"   '出荷日
            strSQL &= vbCrLf & " )"
            strSQL &= vbCrLf


            '-------------------
            '追加
            '-------------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_ADD & "  " & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
