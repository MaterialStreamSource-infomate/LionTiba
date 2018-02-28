'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾊﾟﾗﾒｰﾀ通知
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_200001
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0         '端末ID
    Private Const DSPUSER_ID As Integer = 1         'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2          '理由
    Private Const DSPPARA_ID As Integer = 3         'ﾊﾟﾗﾒｰﾀID

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
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
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        Dim intRet As Integer                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim strSQL As String
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "   * "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "   TPRG_PARAM_TBL "
            strSQL &= vbCrLf & "WHERE "
            strSQL &= vbCrLf & "       FPARA_ID = '" & strDenbunDtl(DSPPARA_ID) & "'"   'ﾊﾟﾗﾒｰﾀID
            strSQL &= vbCrLf & "ORDER BY "
            strSQL &= vbCrLf & "   FPARA_EDA_NO "                                       'ﾊﾟﾗﾒｰﾀ枝番
            strSQL &= vbCrLf
            objTPRG_PARAM_TBL.USER_SQL = strSQL                  'SQL文設定
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_USER()    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_PARAM_TBL
                strMsg &= "[ﾊﾟﾗﾒｰﾀID:" & strDenbunDtl(DSPPARA_ID) & "]"
                Throw New UserException(strMsg)
            End If

        
           

            For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                '(取得したﾚｺｰﾄﾞ数)

                Dim msgRecv As String = ""
                Dim msgSend As String = ""
                Try
                    Dim rtn As Integer = RetCode.OK
                    Dim rtn2 As Integer = RetCode.OK


                    '************************
                    'ﾒｯｾｰｼﾞ設定
                    '************************
                    objTelegramRecvDSP.FORMAT_ID = "DSP_000000"                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTelegramRecvDSP.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                    objTelegramRecvDSP.PARTITION()                              '電文分割


                    '************************
                    'ｺﾏﾝﾄﾞIDの特定
                    '************************
                    Dim strCMD_ID As String
                    strCMD_ID = objTelegramRecvDSP.SELECT_HEADER("DSPCMD_ID")
                    strCMD_ID = Trim(strCMD_ID)


                    '************************
                    'ｺﾏﾝﾄﾞ処理
                    '************************
                    msgRecv = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA
                    msgSend = objTPRG_PARAM_TBL.ARYME(ii).FRECV_DATA
                    Select Case strCMD_ID
                        Case FSYORI_ID_S201601
                            '問合せ出庫
                            '↓↓↓↓↓↓************************************************************************************************************
                            'SystemMate:N.Dounoshita 2013/04/01  出庫時には予定数を設定しなければならないので、全ての処理が完了してからｺﾐｯﾄorﾛｰﾙﾊﾞｯｸする
                            'Dim objCmd As New SVR_201601(Owner, ObjDb, ObjDbLog)
                            'rtn = objCmd.ExecCmd(msgRecv, msgSend)
                            '↑↑↑↑↑↑************************************************************************************************************


                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:N.Dounoshita 2012/04/24 ﾊﾟﾗﾒｰﾀ通知


                            'Case FSYORI_ID_J400501
                            '    '倉替え登録
                            '    Dim objCmd As New SVR_400501(Owner, ObjDb, ObjDbLog)
                            '    rtn = objCmd.ExecCmd(msgRecv, msgSend)


                            '↑↑↑↑↑↑************************************************************************************************************

                        Case Else

                    End Select

                    '************************
                    'ｴﾗｰﾁｪｯｸ
                    '************************
                    If rtn = RetCode.NG Or rtn2 = RetCode.NG Then
                        '(異常終了の場合)
                        strMsg = ERRMSG_DISP_PARAM
                        Throw New UserException(strMsg)
                    End If


                Catch ex As UserException
                    Call ComUser(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始

                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                    ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                Finally
                    objTPRG_PARAM_TBL.ARYME(ii).FRECV_DATA = msgSend     '受信電文
                    objTPRG_PARAM_TBL.ARYME(ii).FUPDATE_DT = Now         '更新日時
                    objTPRG_PARAM_TBL.ARYME(ii).UPDATE_TPRG_PARAM_TBL()  '更新
                    ObjDb.Commit()      'ｺﾐｯﾄ
                    ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                End Try
            Next
            objTPRG_PARAM_TBL.ARYME_CLEAR()

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
            ElseIf strDenbunDtl(DSPPARA_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾊﾟﾗﾒｰﾀID]"
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
