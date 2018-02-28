'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞ強制完了
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200501
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPTRK_BUF_NO As Integer = 3      'ﾊﾞｯﾌｧ№
    Private Const DSPTRK_BUF_ARRAY As Integer = 4   'ﾊﾞｯﾌｧ配列№
    Private Const DSPPALLET_ID As Integer = 5       'ﾊﾟﾚｯﾄID

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  構造体定義                                                                           "
    ''' <summary>電文内容</summary>
    Private Structure DENBUN_DTL
        Dim DSPTERM_ID As String            '端末ID
        Dim DSPUSER_ID As String            'ﾕｰｻﾞｰID
        Dim DSPTRK_BUF_NO As String         'ﾊﾞｯﾌｧ№
        Dim DSPTRK_BUF_ARRAY As String      'ﾊﾞｯﾌｧ配列№
        Dim DSPPALLET_ID As String          'ﾊﾟﾚｯﾄID
    End Structure
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String          '電文分解配列
        Dim strDenbunDtlName(0) As String      '電文分解名称配列
        Dim strDenbunInfo As String = ""       '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                  '戻り値
        'Dim strMsg As String                   'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '↓↓↓↓↓↓************************************************************************************************************
            'JobmMate:N.Dounoshita 2013/04/02  ﾍﾟｱ搬送の場合は、相方のﾊﾟﾚｯﾄも強制完了させる。


            '************************
            '搬送指示QUE    取得
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) 'ｲﾝｽﾀﾝｽ化
            objTPLN_CARRY_QUE.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)               'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                             '取得


            Select Case TO_INTEGER(strDenbunDtl(DSPTRK_BUF_NO))
                Case FTRK_BUF_NO_J3401 _
                   , FTRK_BUF_NO_J3402
                    '(出庫搬送中の場合)


                    '***********************************************
                    '予定数ﾏｲﾅｽ1
                    '***********************************************
                    Call UpdateYoteiNumMinus1(TO_INTEGER(strDenbunDtl(DSPTRK_BUF_NO)), strDenbunDtl(DSPPALLET_ID), IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE))


            End Select


            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = strDenbunDtl(DSPTRK_BUF_NO)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№の初期化
            '************************
            Dim intBufNo As Integer
            intBufNo = strDenbunDtl(DSPTRK_BUF_NO)

           
            '************************
            'ﾄﾗｯｷﾝｸﾞ強制完了
            '************************
            Dim objSVR_100301 As New SVR_100301(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞ強制完了ｸﾗｽ
            objSVR_100301.FTRK_BUF_NO = intBufNo                        'ﾊﾞｯﾌｧ№
            objSVR_100301.FPALLET_ID = strDenbunDtl(DSPPALLET_ID)       'ﾊﾟﾚｯﾄID
            objSVR_100301.MENTE_FINISH()                                'ﾄﾗｯｷﾝｸﾞ強制完了


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/02  ﾍﾟｱ搬送の場合は、相方のﾊﾟﾚｯﾄも強制完了させる。


            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(相方がいる場合)


                '************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ       取得
                '************************
                Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                objTPRG_TRK_BUF_RELAY.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE        'ﾊﾟﾚｯﾄID
                objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF()                                    '取得
                If objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intBufNo Then
                    '(同じ場所のﾄﾗｯｷﾝｸﾞだった場合)


                    '************************
                    'ﾄﾗｯｷﾝｸﾞ強制完了
                    '************************
                    Dim objSVR_100301_Aite As New SVR_100301(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞ強制完了ｸﾗｽ
                    objSVR_100301_Aite.FTRK_BUF_NO = intBufNo                           'ﾊﾞｯﾌｧ№
                    objSVR_100301_Aite.FPALLET_ID = objTPLN_CARRY_QUE.XPALLET_ID_AITE   'ﾊﾟﾚｯﾄID
                    objSVR_100301_Aite.MENTE_FINISH()                                   'ﾄﾗｯｷﾝｸﾞ強制完了


                End If


            End If


            '↑↑↑↑↑↑************************************************************************************************************


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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '戻り値
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
            ElseIf strDenbunDtl(DSPTRK_BUF_NO) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPTRK_BUF_ARRAY) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾊﾞｯﾌｧ配列№]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPPALLET_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾊﾟﾚｯﾄID]"
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

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
