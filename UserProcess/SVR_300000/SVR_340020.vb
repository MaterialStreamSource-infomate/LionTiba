'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】検査結果登録更新（定周期処理版）
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_340020
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義      "
    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPPALLET_ID As Integer = 3           'ﾊﾟﾚｯﾄID
    Private Const DSPLOT_NO_STOCK As Integer = 4        '在庫ﾛｯﾄ№
    Private Const DSPHORYU_KUBUN As Integer = 5         '保留区分
    Private Const XDSPKENSA_KUBUN As Integer = 6        '検査区分                                                          "
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
        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ

        Try
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
            Dim dtmNow01 As Date = Now
            'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ取得
            '************************
            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(Owner, ObjDb, ObjDbLog) 'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ
            objTPRG_PARAM_TBL.ORDER_BY = " FENTRY_DT,FPARA_EDA_NO "
            intRet = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_ANY                '全件取得

            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTPRG_PARAM_TBL.ARYME) To UBound(objTPRG_PARAM_TBL.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    ''枝番１は画面IFで処理するためここではスキップする
                    'If objTPRG_PARAM_TBL.ARYME(ii).FPARA_EDA_NO = 1 Then
                    '    'パラメータテーブルを削除する
                    '    objTPRG_PARAM_TBL.ARYME(ii).DELETE_TPRG_PARAM_TBL()
                    '    Continue For
                    'End If


                    Dim objTel As New clsTelegram(CONFIG_TELEGRAM_DSP)                      '受信用電文
                    objTel.FORMAT_ID = "DSP_400402"                                         'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                    objTel.TELEGRAM_PARTITION = objTPRG_PARAM_TBL.ARYME(ii).FSEND_DATA      '分割する電文ｾｯﾄ
                    objTel.PARTITION()                                                      '電文分割

                    '検査結果登録以外のコマンドIDはスキップする
                    If objTel.SELECT_HEADER("DSPCMD_ID") <> "400402" Then Continue For


                    '************************
                    '在庫情報ﾃｰﾌﾞﾙ特定
                    '************************
                    Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
                    objTRST_STOCK.FPALLET_ID = Trim(objTel.SELECT_DATA("DSPPALLET_ID"))             'ﾊﾟﾚｯﾄID
                    objTRST_STOCK.FLOT_NO_STOCK = Trim(objTel.SELECT_DATA("DSPLOT_NO_STOCK"))       '在庫ﾛｯﾄ№
                    intRet = objTRST_STOCK.GET_TRST_STOCK(False)
                    If intRet = RetCode.NotFound Then
                        '(在庫情報が存在しない場合)
                        strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[ﾊﾟﾚｯﾄID:" & TO_STRING(objTRST_STOCK.FPALLET_ID) & "][在庫ﾛｯﾄ№:" & objTRST_STOCK.FLOT_NO_STOCK & "]"
                        Throw New UserException(strMsg)
                    End If

                    '************************
                    '在庫情報更新
                    '************************

                    If Trim(objTel.SELECT_DATA("XDSPKENSA_KUBUN")) <> "" Then
                        objTRST_STOCK.XKENSA_KUBUN = Trim(objTel.SELECT_DATA("XDSPKENSA_KUBUN"))         '出荷可否
                    End If

                    '’不具合修正 2017/09/08 YAMAMOTO
                    If Trim(objTel.SELECT_DATA("DSPHORYU_KUBUN")) <> "" Then
                        objTRST_STOCK.FHORYU_KUBUN = Trim(objTel.SELECT_DATA("DSPHORYU_KUBUN"))         '保留区分
                    End If


                    Call objTRST_STOCK.UPDATE_TRST_STOCK()

                    'パラメータテーブルを削除する
                    objTPRG_PARAM_TBL.ARYME(ii).DELETE_TPRG_PARAM_TBL()

                    '1周期あたり500件でSTOP
                    If ii = 500 Then Exit For

                Next

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)

                Dim objDiff As TimeSpan = Now - dtmNow01
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                     FLOG_DATA_TRN_SEND_NORMAL _
                     & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                     )
                'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
                '↑↑↑↑↑↑************************************************************************************************************

            End If







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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
