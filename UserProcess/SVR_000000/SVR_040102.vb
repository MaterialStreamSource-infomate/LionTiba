'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾃﾞｰﾀﾍﾞｰｽﾊﾞｯｸｱｯﾌﾟ処理2
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_040102

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
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '************************
            '初期設定
            '************************
            Dim objTPRG_SYS_HEN As TBL_TPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            ''*********************************************************************************************************************
            ''*********************************************************************************************************************
            ''DBﾊﾞｯｸﾞｱｯﾌﾟ2
            ''*********************************************************************************************************************
            ''*********************************************************************************************************************
            ''**************************************
            ''DBﾊﾞｯｸﾞｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ取得
            ''**************************************
            'Dim strBatPath01 As String = objTPRG_SYS_HEN.SS040102_001


            ''**************************************
            ''DBﾊﾞｯｸﾞｱｯﾌﾟ可能かどうかを判断する
            ''**************************************
            'Dim objSR01 As New System.IO.StreamReader(strBatPath01, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            'objSR01.ReadLine()    '一行取得
            'objSR01.ReadLine()    '一行取得
            'Dim strDBBackupPath As String = Trim(Mid(objSR01.ReadLine(), 4))
            'If System.IO.Directory.Exists(strDBBackupPath) = False Then
            '    '(ﾌｫﾙﾀﾞが存在しない場合)
            '    Call AddToMsgLog(Now, FMSG_ID_S9002, "外付けHDDのﾊﾞｯｸｱｯﾌﾟ先が認識出来ません。", "「" & strDBBackupPath & "」が見つかりません")
            '    Return RetCode.OK
            'End If


            ''**************************************
            ''DBﾊﾞｯｸﾞｱｯﾌﾟ
            ''**************************************
            'System.Diagnostics.Process.Start(strBatPath01)


            '*********************************************************************************************************************
            '*********************************************************************************************************************
            'ﾌﾟﾛｸﾞﾗﾑﾊﾞｯｸｱｯﾌﾟ
            '*********************************************************************************************************************
            '*********************************************************************************************************************
            '**************************************
            'DBﾊﾞｯｸﾞｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ取得
            '**************************************
            Dim strBatPath02 As String = objTPRG_SYS_HEN.SS040102_002


            '**************************************
            'DBﾊﾞｯｸﾞｱｯﾌﾟ可能かどうかを判断する
            '**************************************
            Dim objSR02 As New System.IO.StreamReader(strBatPath02, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            objSR02.ReadLine()    '一行取得
            Dim strString As String = Trim(objSR02.ReadLine())
            Dim intStartPos As Integer = InStr(1, strString, " ")
            Dim intEndPos As Integer = InStr(intStartPos + 2, strString, " ")
            Dim strProgramBackupPath As String = Mid(strString, intStartPos + 1, intEndPos - intStartPos - 1)
            If System.IO.Directory.Exists(strProgramBackupPath) = False Then
                '(ﾌｫﾙﾀﾞが存在しない場合)
                Call AddToMsgLog(Now, FMSG_ID_S9002, "外付けHDDのﾊﾞｯｸｱｯﾌﾟ先が認識出来ません。", "「" & strProgramBackupPath & "」が見つかりません")
                Return RetCode.OK
            End If


            '**************************************
            'DBﾊﾞｯｸﾞｱｯﾌﾟ
            '**************************************
            Call Shell(strBatPath02, AppWinStyle.Hide)
            'System.Diagnostics.Process.Start(strBatPath02)


            '************************************************
            '正常完了
            '************************************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
