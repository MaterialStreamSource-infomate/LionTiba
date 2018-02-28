'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾃﾞｰﾀﾍﾞｰｽﾊﾞｯｸｱｯﾌﾟ処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_040101
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
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART)


            '**************************************
            'DBﾊﾞｯｸﾞｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ取得
            '**************************************
            Dim objTPRG_SYS_HEN As TBL_TPRG_SYS_HEN = New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS040101_001
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)


            '**************************************
            'DBﾊﾞｯｸﾞｱｯﾌﾟ起動
            '**************************************
            Dim strPath As String = objTPRG_SYS_HEN.FHENSU_CHAR
            Call Shell(strPath, AppWinStyle.Hide)
            'System.Diagnostics.Process.Start(strPath)

            '終了まで待機する
            'p.WaitForExit()
            'ここを次のようにすると最大10秒間だけ待機する
            'p.WaitForExit(10000)


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
