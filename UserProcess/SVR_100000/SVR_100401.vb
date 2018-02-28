'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100401
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
    Private mFTRK_BUF_NO_TO As Nullable(Of Integer)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(入庫先ﾄﾗｯｷﾝｸﾞ)
    Private mFPALLET_ID As String                       'ﾊﾟﾚｯﾄID
    Private mobjTPRG_TRK_BUF_IN As TBL_TPRG_TRK_BUF     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ(入庫ﾄﾗｯｷﾝｸﾞ作成場所)
    Private mFSAGYOU_KIND As Nullable(Of Integer)       '作業種別
    Private mFTERM_ID As String                         '端末ID
    Private mFUSER_ID As String                         'ﾕｰｻﾞｰID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(入庫先ﾄﾗｯｷﾝｸﾞ)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO_TO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO_TO = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙ(入庫ﾄﾗｯｷﾝｸﾞ作成場所)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF_IN() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_IN
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_IN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>作業種別</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>端末ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTERM_ID() As String
        Get
            Return mFTERM_ID
        End Get
        Set(ByVal Value As String)
            mFTERM_ID = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FUSER_ID() As String
        Get
            Return mFUSER_ID
        End Get
        Set(ByVal Value As String)
            mFUSER_ID = Value
        End Set
    End Property

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
#Region "  入庫ﾄﾗｯｷﾝｸﾞ定義                                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫ﾄﾗｯｷﾝｸﾞ定義
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_IN_BUF()
        '' ''Dim intRet As RetCode                   '戻り値
        '' ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '在庫引当情報の登録
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FSAGYOU_KIND = mFSAGYOU_KIND                        '作業区分(JOB固有定数)
            objTSTS_HIKIATE.FPLAN_KEY = FPLAN_KEY_SKOTEI                        '計画ｷｰ
            objTSTS_HIKIATE.FPALLET_ID = mFPALLET_ID                            'ﾊﾟﾚｯﾄID
            objTSTS_HIKIATE.FLOT_NO_STOCK = FLOT_NO_STOCK_SKOTEI                '在庫ﾛｯﾄ№
            objTSTS_HIKIATE.FTR_VOL = FTR_VOL_SKOTEI                            '搬送管理量
            objTSTS_HIKIATE.FTERM_ID = mFTERM_ID                                '端末ID
            objTSTS_HIKIATE.FUSER_ID = mFUSER_ID                                'ﾕｰｻﾞｰID
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING                       '指示送信待ﾁ理由
            objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '搬送開始日時
            objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '搬送完了日時
            objTSTS_HIKIATE.FUPDATE_DT = Now                                    '更新日時
            objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '登録


            '************************
            'ﾊﾞｯﾌｧの更新
            '************************
            '↓↓↓　ｼｽﾃﾑ固有　搬送引当て処理にて予約する
            'mobjTPRG_TRK_BUF_IN.FRSV_PALLET = mFPALLET_ID                               '仮引当ﾊﾟﾚｯﾄID
            '↑↑↑　ｼｽﾃﾑ固有　搬送引当て処理にて予約する
            mobjTPRG_TRK_BUF_IN.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT                      '引当状態(搬送予約)
            mobjTPRG_TRK_BUF_IN.FTR_FM = mobjTPRG_TRK_BUF_IN.FTRK_BUF_NO                '搬送FMﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_IN.FTR_TO = mFTRK_BUF_NO_TO                                '搬送TOﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_IN.FTR_IDOU = DEFAULT_INTEGER                              '搬送TO移動ﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_IN.FTRNS_FM = DEFAULT_STRING                               '搬送指令用FM
            mobjTPRG_TRK_BUF_IN.FTRNS_TO = DEFAULT_STRING                               '搬送指令用TO
            mobjTPRG_TRK_BUF_IN.FRSV_BUF_FM = mobjTPRG_TRK_BUF_IN.FTRK_BUF_NO           'FM引当ﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_IN.FRSV_ARRAY_FM = mobjTPRG_TRK_BUF_IN.FTRK_BUF_ARRAY      'FM引当配列№
            mobjTPRG_TRK_BUF_IN.FRSV_BUF_TO = DEFAULT_INTEGER                           'TO引当ﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_IN.FRSV_ARRAY_TO = DEFAULT_INTEGER                         'TO引当配列№
            mobjTPRG_TRK_BUF_IN.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF_IN.FDISP_ADDRESS    'FM表記用ｱﾄﾞﾚｽ
            mobjTPRG_TRK_BUF_IN.FDISP_ADDRESS_TO = DEFAULT_STRING                       'TO表記用ｱﾄﾞﾚｽ
            mobjTPRG_TRK_BUF_IN.FBUF_IN_DT = Now                                        'ﾊﾞｯﾌｧ入日時
            mobjTPRG_TRK_BUF_IN.UPDATE_TPRG_TRK_BUF()                                   '更新


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub

#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有


#Region "  入庫先ﾄﾗｯｷﾝｸﾞ指定                                                                    "
    '''**********************************************************************************************
    ''' <summary>
    ''' 入庫先ﾄﾗｯｷﾝｸﾞ指定
    ''' </summary>
    ''' <returns>入庫先の予約あり:OK なし:NotFound</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function UPDATE_IN_BUF_SET_TO_BUF() As RetCode
        Dim intRet As RetCode                   '戻り値
        '' ''Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '入庫先の予約検索
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
            objTPRG_TRK_BUF_TO.FRSV_PALLET = mFPALLET_ID                                '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = mFTRK_BUF_NO_TO                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_RSV_PALLET()                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [仮引当ﾊﾟﾚｯﾄID]
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Return RetCode.NotFound
            End If

            '************************
            '入庫ﾄﾗｯｷﾝｸﾞ更新
            '************************
            OBJTPRG_TRK_BUF_IN.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO             'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            OBJTPRG_TRK_BUF_IN.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY        'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            OBJTPRG_TRK_BUF_IN.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS      'TO表記用ｱﾄﾞﾚｽ
            OBJTPRG_TRK_BUF_IN.FBUF_IN_DT = Now                                         'ﾊﾞｯﾌｧ入り日時

            OBJTPRG_TRK_BUF_IN.UPDATE_TPRG_TRK_BUF()                                    '更新

            Return RetCode.OK

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


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
