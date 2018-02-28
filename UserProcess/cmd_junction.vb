'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾕｰｻﾞ処理分岐
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports System.Threading
Imports MateCommon
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
Imports JobCommon
#End Region

Public Class cmd_junction

#Region "  共通変数"
    Private Owner As Object             'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ

    Private mObjDb As clsConn            'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ

    Private mObjDbLog As clsConn         'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅーｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DB接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DB接続ｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        Try
            'ｵｰﾅｵﾌﾞｼﾞｪｸﾄ定義
            Owner = objOwner
            mObjDb = objDb
            mObjDbLog = objDbLog
        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "  ﾃﾞｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        Close()
    End Sub
#End Region

#Region "  ｸﾛｰｽﾞ処理              (Public  Close)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Close()
        Try
            'ｵﾌﾞｼﾞｪｸﾄ開放
            Owner = Nothing
            mObjDb = Nothing
            mObjDbLog = Nothing
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  ｺﾏﾝﾄﾞ分岐処理          (Public  ExecCmd)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾏﾝﾄﾞ分岐処理
    ''' </summary>
    ''' <param name="msgRecv">受信ﾒｯｾｰｼﾞ</param>
    ''' <param name="msgSend">返答ﾒｯｾｰｼﾞ</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As Integer
        Try
            Dim requestInitialOwnership As Boolean = True
            Dim strCMD_ID As String = ""
            Dim rtn As Integer = RetCode.NG


            '************************
            'ﾒｯｾｰｼﾞ設定
            '************************
            objTelegramRecvDSP.FORMAT_ID = "DSP_000000"                 'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramRecvDSP.TELEGRAM_PARTITION = msgRecv             '分割する電文ｾｯﾄ
            objTelegramRecvDSP.PARTITION()                              '電文分割


            '************************
            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '************************
            mObjDb.BeginTrans()


            Try

                '************************
                'ｺﾏﾝﾄﾞIDの特定
                '************************
                strCMD_ID = objTelegramRecvDSP.SELECT_HEADER("DSPCMD_ID")
                strCMD_ID = Trim(strCMD_ID)


                '************************
                'ｺﾏﾝﾄﾞ処理
                '************************
                Select Case strCMD_ID
                    Case FSYORI_ID_S010001
                        'AddToLog("■受付:搬送指示引当処理", "", LogType.INFO)
                        Dim objCmd As New SVR_010001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S010002
                        'AddToLog("■受付:搬送指示引当処理(出庫指示用)", "", LogType.INFO)
                        Dim objCmd As New SVR_010002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S010101
                        'AddToLog("■受付:入庫指示処理", "", LogType.INFO)
                        Dim objCmd As New SVR_010101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S010201
                        'AddToLog("■受付:出庫指示処理", "", LogType.INFO)
                        Dim objCmd As New SVR_010201(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S010301
                        'AddToLog("■受付:搬送指示処理", "", LogType.INFO)
                        Dim objCmd As New SVR_010301(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)


                    Case FSYORI_ID_S020101, FSYORI_ID_S210001
                        'AddToLog("■受付:搬送制御受信読込み", "", LogType.INFO)
                        Dim objCmd As New SVR_020101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S020151, FSYORI_ID_S210002
                        'AddToLog("■受付:搬送制御送信読込み", "", LogType.INFO)
                        Dim objCmd As New SVR_020151(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)


                    Case FSYORI_ID_S030101
                        'AddToLog("■受付:ﾎｽﾄ受信処理", "", LogType.INFO)
                        Dim objCmd As New SVR_030101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)


                    Case FSYORI_ID_S040001
                        AddToLog("■受付:ﾃｰﾌﾞﾙ削除処理", "", LogType.INFO)
                        Dim objCmd As New SVR_040001(Owner, Nothing, Nothing)
                        rtn = objCmd.ExecThreadStart()
                    Case FSYORI_ID_S040101
                        AddToLog("■受付:ﾃﾞｰﾀﾍﾞｰｽﾊﾞｯｸｱｯﾌﾟ処理", "", LogType.INFO)
                        Dim objCmd As New SVR_040101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S040102
                        AddToLog("■受付:ﾃﾞｰﾀﾍﾞｰｽﾊﾞｯｸｱｯﾌﾟ処理2", "", LogType.INFO)
                        Dim objCmd As New SVR_040102(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_S200001
                        AddToLog("■受付:ﾊﾟﾗﾒｰﾀ通知", "", LogType.INFO)
                        Dim objCmd As New SVR_200001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200002
                        AddToLog("■受付:ﾛｸﾞｲﾝ判定", "", LogType.INFO)
                        Dim objCmd As New SVR_200002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200003
                        AddToLog("■受付:ﾊﾟｽﾜｰﾄﾞ変更", "", LogType.INFO)
                        Dim objCmd As New SVR_200003(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200004
                        AddToLog("■受付:ﾛｸﾞｵﾌ", "", LogType.INFO)
                        Dim objCmd As New SVR_200004(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200005
                        AddToLog("■受付:離席", "", LogType.INFO)
                        Dim objCmd As New SVR_200005(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200006
                        AddToLog("■受付:強制ﾛｸﾞｵﾌ", "", LogType.INFO)
                        Dim objCmd As New SVR_200006(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200007
                        AddToLog("■受付:ﾊﾟｽﾜｰﾄﾞ確認", "", LogType.INFO)
                        Dim objCmd As New SVR_200007(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200101
                        AddToLog("■受付:ﾒｯｾｰｼﾞ確認", "", LogType.INFO)
                        Dim objCmd As New SVR_200101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200201
                        AddToLog("■受付:設備切離し", "", LogType.INFO)
                        Dim objCmd As New SVR_200201(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200202
                        AddToLog("■受付:代替棚指示要求", "", LogType.INFO)
                        Dim objCmd As New SVR_200202(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200301
                        AddToLog("■受付:設備ｵﾝﾗｲﾝ設定", "", LogType.INFO)
                        Dim objCmd As New SVR_200301(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200302
                        AddToLog("■受付:設備ﾓｰﾄﾞ切替設定", "", LogType.INFO)
                        Dim objCmd As New SVR_200302(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200401
                        AddToLog("■受付:在庫ﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_200401(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200501
                        AddToLog("■受付:ﾄﾗｯｷﾝｸﾞ強制完了", "", LogType.INFO)
                        Dim objCmd As New SVR_200501(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200502
                        AddToLog("■受付:ﾄﾗｯｷﾝｸﾞ削除", "", LogType.INFO)
                        Dim objCmd As New SVR_200502(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200503
                        AddToLog("■受付:ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ", "", LogType.INFO)
                        Dim objCmd As New SVR_200503(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200601
                        AddToLog("■受付:ｼｽﾃﾑ定数変更", "", LogType.INFO)
                        Dim objCmd As New SVR_200601(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200701
                        AddToLog("■受付:ﾕｰｻﾞｰﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_200701(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200702
                        AddToLog("■受付:ﾊﾟｽﾜｰﾄﾞﾘｾｯﾄ", "", LogType.INFO)
                        Dim objCmd As New SVR_200702(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200801
                        AddToLog("■受付:操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_200801(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S200901
                        AddToLog("■受付:理由ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_200901(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S201001
                        AddToLog("■受付:理由ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_201001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S201401
                        AddToLog("■受付:棚卸し作業登録", "", LogType.INFO)
                        Dim objCmd As New SVR_201401(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                    Case FSYORI_ID_S201801
                        AddToLog("■受付:製品品番ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_201801(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_S201901
                        AddToLog("■受付:品名ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_201901(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_S202001
                        AddToLog("■受付:製品構成ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_202001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_S010401
                        'AddToLog("■受付:手動搬送処理", "", LogType.INFO)
                        Dim objCmd As New SVR_010401(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)


                        '**********************************************************************************************
                        '↓↓↓ｼｽﾃﾑ固有

                    Case FSYORI_ID_J310101
                        'AddToLog("■受付:入庫要求受付", "", LogType.INFO)
                        Dim objCmd As New SVR_310101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310102
                        'AddToLog("■受付:入庫自動設定", "", LogType.INFO)
                        Dim objCmd As New SVR_310102(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310103
                        'AddToLog("■受付:入棚要求受信", "", LogType.INFO)
                        Dim objCmd As New SVR_310103(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case 310104
                        'AddToLog("■受付:入庫要求受付(BCR)", "", LogType.INFO)
                        Dim objCmd As New SVR_310104(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310201
                        'AddToLog("■受付:出荷引当処理", "", LogType.INFO)
                        Dim objCmd As New SVR_310201(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310202
                        'AddToLog("■受付:包材出庫引当処理", "", LogType.INFO)
                        Dim objCmd As New SVR_310202(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310301
                        'AddToLog("■受付:ﾊﾞｰｽ引当処理", "", LogType.INFO)
                        Dim objCmd As New SVR_310301(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310304
                        'AddToLog("■受付:出庫順制御処理", "", LogType.INFO)
                        Dim objCmd As New SVR_310304(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J310305
                        'AddToLog("■受付:出庫棚前後入替", "", LogType.INFO)
                        Dim objCmd As New SVR_310305(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J340001
                        'AddToLog("■受付:日替検知", "", LogType.INFO)
                        Dim objCmd As New SVR_340001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J340002
                        'AddToLog("■受付:日締め処理", "", LogType.INFO)
                        Dim objCmd As New SVR_340002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J340011
                        'AddToLog("■受付:異常ﾋﾞｯﾄ更新処理", "", LogType.INFO)
                        Dim objCmd As New SVR_340011(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J340020
                        'AddToLog("■受付:検査結果登録更新（定周期処理版）", "", LogType.INFO)
                        Dim objCmd As New SVR_340020(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J390001
                        'AddToLog("■受付:出庫指示引当(ｸﾚｰﾝ毎)", "", LogType.INFO)
                        Dim objCmd As New SVR_390001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:Dou 2014/08/04 入庫設定並列処理を行う為の改造

                    Case FSYORI_ID_J390002
                        'AddToLog("■受付:画面ｲﾝﾀｰﾌｪｰｽ一時保管監視処理", "", LogType.INFO)
                        Dim objCmd As New SVR_390002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                        '↑↑↑↑↑↑************************************************************************************************************


                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:S.Ouchi 2016/08/04 ｻｰﾊﾞﾌﾟﾛｾｽﾒﾓﾘ監視を行う為の改造 ↓↓↓↓↓↓
                    Case FSYORI_ID_J390003
                        'AddToLog("■受付:ｻｰﾊﾞﾌﾟﾛｾｽﾒﾓﾘ監視処理", "", LogType.INFO)
                        Dim objCmd As New SVR_390003(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:S.Ouchi 2016/08/04 ｻｰﾊﾞﾌﾟﾛｾｽﾒﾓﾘ監視を行う為の改造 ↑↑↑↑↑↑
                        '↑↑↑↑↑↑************************************************************************************************************


                        '↑↑↑ｼｽﾃﾑ固有
                        '**********************************************************************************************


                        '**********************************************************************************************
                        '↓↓↓画面ｿｹｯﾄ受信(ｼｽﾃﾑ固有)

                    Case FSYORI_ID_S201601
                        'AddToLog("■受付:問合せ出庫", "", LogType.INFO)
                        Dim objCmd As New SVR_201601(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400001
                        'AddToLog("■受付:入庫設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400002
                        AddToLog("■受付:生産入庫設定受付", "", LogType.INFO)
                        Dim objCmd As New SVR_400002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400003
                        AddToLog("■受付:緊急時入庫設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400003(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400101
                        AddToLog("■受付:出荷指示更新処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400101(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400102
                        AddToLog("■受付:車両受付処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400102(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400103
                        AddToLog("■受付:出荷指示処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400103(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400104
                        AddToLog("■受付:優先設定受付", "", LogType.INFO)
                        Dim objCmd As New SVR_400104(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400106
                        AddToLog("■受付:出荷強制完了処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400106(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400107
                        AddToLog("■受付:出荷作業終了受付処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400107(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400108
                        AddToLog("■受付:再引当処理", "", LogType.INFO)
                        Dim objCmd As New SVR_400108(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400201
                        AddToLog("■受付:包材出庫設定受付", "", LogType.INFO)
                        Dim objCmd As New SVR_400201(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400202
                        AddToLog("■受付:ｺﾝﾍﾞﾔ用途設定受付", "", LogType.INFO)
                        Dim objCmd As New SVR_400202(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400203
                        AddToLog("■受付:包材出庫設定受付(D45)", "", LogType.INFO)
                        Dim objCmd As New SVR_400203(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400204
                        AddToLog("■受付:ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400204(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:YAMAMOTO 2017/04/08 1F包材出庫追加
                    Case FSYORI_ID_J400205
                        AddToLog("■受付:包材出庫設定受付(1F)", "", LogType.INFO)
                        Dim objCmd As New SVR_400205(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:YAMAMOTO 2017/04/08 1F包材出庫追加
                        '↑↑↑↑↑↑************************************************************************************************************

                    Case FSYORI_ID_J400401
                        AddToLog("■受付:禁止棚一括設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400401(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400402
                        AddToLog("■受付:在庫ﾒﾝﾃﾅﾝｽ一括設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400402(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400501
                        AddToLog("■受付:倉替え出庫", "", LogType.INFO)
                        Dim objCmd As New SVR_400501(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400502
                        AddToLog("■受付:倉替え入庫", "", LogType.INFO)
                        Dim objCmd As New SVR_400502(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400601
                        AddToLog("■受付:車輌ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400601(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400602
                        AddToLog("■受付:物流業者ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400602(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400603
                        AddToLog("■受付:輸送手段ﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400603(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400604
                        AddToLog("■受付:包装材料ﾒｰｶｰﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400604(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400605
                        AddToLog("■受付:生産ﾗｲﾝﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400605(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400606
                        AddToLog("■受付:生産ﾗｲﾝﾏｽﾀ(D45)ﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400606(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↓↓↓↓↓↓
                    Case FSYORI_ID_J400607
                        AddToLog("■受付:ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400607(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400608
                        AddToLog("■受付:ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀﾒﾝﾃﾅﾝｽ", "", LogType.INFO)
                        Dim objCmd As New SVR_400608(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↑↑↑↑↑↑
                        '↑↑↑↑↑↑************************************************************************************************************

                    Case FSYORI_ID_J400701
                        AddToLog("■受付:PLCﾒﾝﾃﾅﾝｽ(ﾄﾗｯｷﾝｸﾞ)", "", LogType.INFO)
                        Dim objCmd As New SVR_400701(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400702
                        AddToLog("■受付:PLCﾒﾝﾃﾅﾝｽ(予定数)", "", LogType.INFO)
                        Dim objCmd As New SVR_400702(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:YAMAMOTO 2017/04/08 1F包材出庫追加
                    Case FSYORI_ID_J400703
                        AddToLog("■受付:PLCﾒﾝﾃﾅﾝｽ( 1F包材出庫)", "", LogType.INFO)
                        Dim objCmd As New SVR_400703(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:YAMAMOTO 2017/04/08 1F包材出庫追加
                        '↑↑↑↑↑↑************************************************************************************************************

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:YAMAMOTO 2017/07/08 1F包材出庫追加
                    Case FSYORI_ID_J400704
                        AddToLog("■受付:PLCﾒﾝﾃﾅﾝｽ(BCR)", "", LogType.INFO)
                        Dim objCmd As New SVR_400704(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case FSYORI_ID_J400705
                        AddToLog("■受付:生産入庫登録(BCR)", "", LogType.INFO)
                        Dim objCmd As New SVR_400705(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:YAMAMOTO 2017/07/08 1F包材出庫追加
                        '↑↑↑↑↑↑************************************************************************************************************

                        '↓↓↓↓↓↓************************************************************************************************************
                        'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↓↓↓↓↓↓
                    Case FSYORI_ID_J400901
                        AddToLog("■受付:生産ﾗｲﾝﾓﾆﾀ運転設定", "", LogType.INFO)
                        Dim objCmd As New SVR_400901(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)
                        'JobMate:S.Ouchi 2015/07/04 CW6追加対応 ↑↑↑↑↑↑
                        '↑↑↑↑↑↑************************************************************************************************************


                        '↑↑↑画面ｿｹｯﾄ受信(ｼｽﾃﾑ固有)
                        '**********************************************************************************************

                    Case "999001"
                        AddToLog("■受付:搬送起動判定ﾏｽﾀ作成", "", LogType.INFO)
                        Dim objCmd As New SVR_999001(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999002"
                        AddToLog("■受付:MCIｲﾍﾞﾝﾄ通知ﾏｽﾀ作成", "", LogType.INFO)
                        Dim objCmd As New SVR_999002(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999801"
                        AddToLog("■受付:Melsecﾛｸﾞの日付変換", "", LogType.INFO)
                        Dim objCmd As New SVR_999801(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999802"
                        AddToLog("■受付:Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする01", "", LogType.INFO)
                        Dim objCmd As New SVR_999802(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999803"
                        AddToLog("■受付:Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする02(書込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999803(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999804"
                        AddToLog("■受付:Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする03(読込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999804(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999805"
                        AddToLog("■受付:Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする04(読書込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999805(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999806"
                        AddToLog("■受付:Melsec電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする05", "", LogType.INFO)
                        Dim objCmd As New SVR_999806(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999901"
                        AddToLog("■受付:一晩放置して収集したﾛｸﾞの日付変換", "", LogType.INFO)
                        Dim objCmd As New SVR_999901(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999902"
                        AddToLog("■受付:電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする01", "", LogType.INFO)
                        Dim objCmd As New SVR_999902(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999903"
                        AddToLog("■受付:電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする02(書込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999903(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999904"
                        AddToLog("■受付:電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする03(読込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999904(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999905"
                        AddToLog("■受付:電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする04(読込用)", "", LogType.INFO)
                        Dim objCmd As New SVR_999905(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999906"
                        AddToLog("■受付:電文解析後、他ﾌｨｰﾙﾄﾞにﾃﾞｰﾀをｾｯﾄする05", "", LogType.INFO)
                        Dim objCmd As New SVR_999906(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    Case "999998"
                        AddToLog("■受付:ﾃｽﾄ01", "", LogType.INFO)
                        Dim objCmd As New SVR_999998(Owner, mObjDb, mObjDbLog)
                        rtn = objCmd.ExecCmd(msgRecv, msgSend)

                    


                    Case Else

                End Select


            Catch ex As Exception
                ComError(ex)
                Throw New System.Exception(ex.Message)


            Finally
                If rtn = RetCode.NG Then
                    '(異常終了の場合)
                    '************************
                    'ﾛｰﾙﾊﾞｯｸ
                    '************************
                    mObjDb.RollBack()
                    AddToLog("cmdNo=[" & strCMD_ID & "] 異常終了", "", LogType.INFO)


                ElseIf rtn = RetCode.RollBack Then
                    '(ﾛｰﾙﾊﾞｯｸしたい場合)
                    '************************
                    'ﾛｰﾙﾊﾞｯｸ
                    '************************
                    mObjDb.RollBack()

                Else
                    '(正常終了の場合)
                    '************************
                    'ｺﾐｯﾄ
                    '************************
                    Try
                        mObjDb.Commit()
                    Catch ex As Exception
                        Throw New Exception("【ｺﾐｯﾄ失敗】" & ex.Message)
                    End Try
                    AddToLog("cmdNo=[" & strCMD_ID & "] 正常終了", "", LogType.INFO)
                End If
            End Try


            Return rtn
        Catch ex As Exception
            ComError(ex)
            Return RetCode.NG
        End Try
    End Function
#End Region

#Region "  ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ       (Private ComError)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ時 共通ﾓｼﾞｭｰﾙ
    ''' </summary>
    ''' <param name="e">例外の基本ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strFunc"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal e As Exception, Optional ByVal strFunc As String = "")
        Try
            Dim strMsg As String = ""
            Dim strProd As String = ""
            strProd &= "Src=[" & CType(CType(e.TargetSite, System.Reflection.MethodBase).ReflectedType, System.Type).FullName
            strProd &= "." & CType(e.TargetSite, System.Reflection.MethodBase).Name & "]"
            If strFunc <> "" Then
                strProd &= " Fnc=[" & strFunc & "]"
            End If
            strMsg &= "Msg=[" & e.Message & "]"
            AddToLog(strMsg, strProd, LogType.SERR)
        Catch ex As Exception
            'NOP(Error 処理中の Error 回避)
        End Try
    End Sub
#End Region

#Region "  ﾛｸﾞ書込み処理          (Public  AddToLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込み処理
    ''' </summary>
    ''' <param name="strMsg">ﾛｸﾞ書込ﾒｯｾｰｼﾞ</param>
    ''' <param name="strProd"></param>
    ''' <param name="intType">ﾒｯｾｰｼﾞ区分    0:情報 1:ユーザエラー 2:システムエラー</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal strMsg As String, ByVal strProd As String, ByVal intType As LogType)
        Try
            If Owner Is Nothing = False Then
                Owner.AddToLog(strMsg, strProd, intType)
            End If
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
