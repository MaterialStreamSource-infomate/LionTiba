'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】操業開始処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_340003
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
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
        'Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If mDTMACTION_DATE = DEFAULT_DATE Then
                strMsg = ERRMSG_ERR_PROPERTY & "[動作日時]"
                Throw New System.Exception(strMsg)
            End If


            '************************
            '初期設定
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)


            '************************
            'ｼｽﾃﾑ変数の特定
            '************************
            Dim dtmStart As Date
            dtmStart = Format(Now, "yyyy/MM/dd") & " " & Format(objTPRG_SYS_HEN.SJ000000_013, "HH:mm:ss")


            '************************
            '操業履歴の登録
            '************************
            Dim objXRST_SOUGYOU As New TBL_XRST_SOUGYOU(Owner, ObjDb, ObjDbLog)     '操業履歴ｸﾗｽ
            objXRST_SOUGYOU.XSOUGYOU_DT = mXSOUGYOU_DT                              '操業日
            objXRST_SOUGYOU.XSTART_DT = dtmStart                                    '操業開始日時
            objXRST_SOUGYOU.XEND_DT = DEFAULT_DATE                                  '操業終了日時
            objXRST_SOUGYOU.ADD_XRST_SOUGYOU()                                      '登録


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[動作日時:" & Format(mDTMACTION_DATE, DATE_FORMAT_03) & "]" _
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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義"

    Private mDTMACTION_DATE As Date                 '動作日時
    Private mXSOUGYOU_DT As Date                    '操業日

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"

    '動作日時
    Public Property DTMACTION_DATE() As Date
        Get
            Return mDTMACTION_DATE
        End Get
        Set(ByVal Value As Date)
            mDTMACTION_DATE = Value
        End Set
    End Property

    '操業日
    Public Property XSOUGYOU_DT() As Date
        Get
            Return mXSOUGYOU_DT
        End Get
        Set(ByVal Value As Date)
            mXSOUGYOU_DT = Value
        End Set
    End Property

#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
