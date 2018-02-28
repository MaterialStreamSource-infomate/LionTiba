'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】搬送指示引当処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010001
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
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
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010002)                           '


            '************************
            '搬送指示QUEの検知
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '搬送指示QUE
            intRet = GetRecordQue(objTPLN_CARRY_QUE)
            If intRet = RetCode.NotFound Then
                '(搬送指示QUEにﾚｺｰﾄﾞがなかった場合)
                Return RetCode.OK
            End If


            '************************
            '初期処理
            '************************
            Dim dtmNow01 As Date = Now
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)

            For ii As Integer = LBound(objTPLN_CARRY_QUE.ARYME) To UBound(objTPLN_CARRY_QUE.ARYME)
                '(ﾙｰﾌﾟ:搬送指示QUE数)

                Try


                    '************************
                    '指示分岐処理
                    '************************
                    intRet = JunctionDir(objTPLN_CARRY_QUE.ARYME(ii))
                    If intRet = RetCode.OK Then
                        '(正常終了した場合)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
                        intRet = objTPLN_CARRY_QUE.ARYME(ii).GET_TPLN_CARRY_QUE(False)
                        If intRet = RetCode.OK Then
                            '↑↑↑↑↑↑************************************************************************************************************
                            objTPLN_CARRY_QUE.ARYME(ii).FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SEND
                            objTPLN_CARRY_QUE.ARYME(ii).UPDATE_TPLN_CARRY_QUE()
                            '↓↓↓↓↓↓************************************************************************************************************
                            'SystemMate:N.Dounoshita 2012/08/15  完了報告が受信しない場合、自動で完了させるが、自動で完了させると搬送指示QUEにﾚｺｰﾄﾞがなくなり、ｴﾗｰとなるのでその対策
                        End If
                        '↑↑↑↑↑↑************************************************************************************************************

                    End If


                Catch ex As ContinueForException
                    ObjDb.RollBack()        'ﾛｰﾙﾊﾞｯｸ
                    ObjDb.BeginTrans()      'ﾄﾗﾝｻﾞｸｼｮﾝ開始
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
                    ObjDb.Commit()      'ｺﾐｯﾄ
                    ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                End Try
            Next
            objTPLN_CARRY_QUE.ARYME_CLEAR()


            '************************
            '正常完了
            '************************
            Dim objDiff As TimeSpan = Now - dtmNow01
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                             )


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  搬送指示QUEの読み込み                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送指示QUEの読み込み
    ''' </summary>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUEﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GetRecordQue(ByRef objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE) As RetCode
        Try
            Dim intReturn As RetCode = RetCode.NG   '自身関数戻り値
            Dim strSQL As String                    'SQL文
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値

            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"                                              '搬送指示QUE
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"                                 '搬送指示QUE
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""      '搬送指示QUE    .搬送指示状況
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/11/06  出庫指示が大量にｾｯﾄされると、処理に時間がかかる為、出庫指示処理は別にした。
            '                                    搬送指示QUEﾃｰﾌﾞﾙのﾚｺｰﾄﾞ1件に対し、0.1秒かかる。
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN NOT IN (" & FCARRYQUE_KUBUN_SOUT & ")"   '搬送指示QUE    .指示区分
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FPRIORITY DESC"                  '搬送指示QUE  .ﾌﾟﾗｲｵﾘﾃｨ区分
            strSQL &= vbCrLf & "  , TPLN_CARRY_QUE.FCARRYQUE_D "                    '搬送指示QUE  .搬送指示日
            strSQL &= vbCrLf & "  , TPLN_CARRY_QUE.FCARRYQUE_ORDER "                '搬送指示QUE  .搬送順№
            strSQL &= vbCrLf

            '***********************
            '抽出
            '***********************
            objTPLN_CARRY_QUE.USER_SQL = strSQL
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE_USER()
            If intRet = RetCode.OK Then
                '(ﾚｺｰﾄﾞが見つかった場合)
                intReturn = RetCode.OK
            Else
                '(ﾚｺｰﾄﾞが一件もない場合)
                intReturn = RetCode.NotFound
            End If


            Return (intReturn)
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region
#Region "  指示分岐処理                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指示分岐処理
    ''' </summary>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUE</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function JunctionDir(ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE) As Integer
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                   'ﾒｯｾｰｼﾞ
        Try
            '************************
            '搬送指示分岐処理
            '************************
            Select Case TO_INTEGER(objTPLN_CARRY_QUE.FCARRYQUE_KUBUN)
                Case FCARRYQUE_KUBUN_SIN                                        '入庫指示
                    Dim objSVR_010101 As New SVR_010101(Owner, ObjDb, ObjDbLog) '入庫指示ｸﾗｽ
                    objSVR_010101.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
                    intRet = objSVR_010101.ExecCmdFunction()

                    '↓↓↓↓↓↓************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/11/06  出庫指示が大量にｾｯﾄされると、処理に時間がかかる為、出庫指示処理は別にした。
                    '                                    搬送指示QUEﾃｰﾌﾞﾙのﾚｺｰﾄﾞ1件に対し、0.1秒かかる。

                    'Case FCARRYQUE_KUBUN_SOUT                                       '出庫指示(棚間搬送も含む)
                    'Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '出庫指示ｸﾗｽ
                    'objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
                    'intRet = objSVR_010201.ExecCmdFunction()

                    '↑↑↑↑↑↑************************************************************************************************************

                Case FCARRYQUE_KUBUN_STANA_MOVE                                 '棚間搬送指示
                    Dim objSVR_010201 As New SVR_010201(Owner, ObjDb, ObjDbLog) '出庫指示ｸﾗｽ
                    objSVR_010201.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
                    intRet = objSVR_010201.ExecCmdFunction_Tana()

                Case FCARRYQUE_KUBUN_SMOVE                                      '搬送指示
                    Dim objSVR_010301 As New SVR_010301(Owner, ObjDb, ObjDbLog) '搬送指示ｸﾗｽ
                    objSVR_010301.TPLN_CARRY_QUE = objTPLN_CARRY_QUE            '搬送指示QUE
                    intRet = objSVR_010301.ExecCmdFunction()

                Case FCARRYQUE_KUBUN_SBUNKI                                     '分岐指示処理
                    'NOP

                Case Else
                    intRet = RetCode.NG
            End Select


            Return intRet
        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
