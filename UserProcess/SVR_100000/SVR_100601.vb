'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】棚間移動ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)(空棚はｸﾗｽ外部で設定)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100601
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
    Private mobjTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)
    Private mobjTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)
    Private mobjTRST_STOCK As TBL_TRST_STOCK                            '在庫情報(FM)
    Private mFTRK_BUF_NO_TO As Nullable(Of Integer)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
    Private mFSAGYOU_KIND As Nullable(Of Integer)                       '作業種別
    Private mFTERM_ID As String                                         '端末ID
    Private mFUSER_ID As String                                         'ﾕｰｻﾞｰID
    Private mFCARRYQUE_KUBUN As Integer = FCARRYQUE_KUBUN_STANA_MOVE    '指示区分
    Private mFPLAN_KEY As String = FPLAN_KEY_SKOTEI                     '計画ｷｰ
    Private mblnTanaManpaiErr As Boolean = True                         '棚満杯時のｴﾗｰ判定
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objTPRG_TRK_BUF_FM() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_FM
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_FM = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objTPRG_TRK_BUF_TO() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_TO
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_TO = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫情報(FM)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objTRST_STOCK() As TBL_TRST_STOCK
        Get
            Return mobjTRST_STOCK
        End Get
        Set(ByVal Value As TBL_TRST_STOCK)
            mobjTRST_STOCK = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)</summary>
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

    ''' =======================================
    ''' <summary>指示区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FCARRYQUE_KUBUN() As Integer
        Get
            Return mFCARRYQUE_KUBUN
        End Get
        Set(ByVal Value As Integer)
            mFCARRYQUE_KUBUN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>計画ｷｰ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPLAN_KEY() As String
        Get
            Return mFPLAN_KEY
        End Get
        Set(ByVal Value As String)
            mFPLAN_KEY = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>棚満杯時のｴﾗｰ判定</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property blnTanaManpaiErr() As Boolean
        Get
            Return mblnTanaManpaiErr
        End Get
        Set(ByVal Value As Boolean)
            mblnTanaManpaiErr = Value
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
#Region "  棚間搬送ﾄﾗｯｷﾝｸﾞ定義                                                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' 棚間搬送ﾄﾗｯｷﾝｸﾞ定義
    ''' </summary>
    ''' <param name="decReqNum">引当要求数</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_MOVE_BUF(ByVal decReqNum As Decimal)
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************************
            '出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)
            '************************************
            Dim objSVR_100501 As New SVR_100501(Owner, ObjDb, ObjDbLog)
            objSVR_100501.FTRK_BUF_NO_TO = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
            objSVR_100501.FPALLET_ID = mobjTPRG_TRK_BUF_FM.FPALLET_ID                   'ﾊﾟﾚｯﾄID
            objSVR_100501.FSAGYOU_KIND = mFSAGYOU_KIND                                  '作業種別
            objSVR_100501.FTERM_ID = mFTERM_ID                                          '端末ID
            objSVR_100501.FUSER_ID = mFUSER_ID                                          'ﾕｰｻﾞｰID
            objSVR_100501.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_STANA_MOVE                  '指示区分
            objSVR_100501.UPDATE_OUT_BUF(FTR_VOL_SFULL)                                 '定義

            '更新されているので再取得
            mobjTPRG_TRK_BUF_FM.CLEAR_PROPERTY()                                        'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
            mobjTPRG_TRK_BUF_FM.FPALLET_ID = mobjTRST_STOCK.ARYME(0).FPALLET_ID         'ﾊﾟﾚｯﾄID
            intRet = mobjTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                         '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FROM)の更新
            '************************
            mobjTPRG_TRK_BUF_FM.FRSV_BUF_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO         'TO引当ﾄﾗｯｷﾝｸﾞ№
            mobjTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY    'TO引当配列№
            mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS 'FM表記用ｱﾄﾞﾚｽ
            mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_TO.FDISP_ADDRESS  'TO表記用ｱﾄﾞﾚｽ
            mobjTPRG_TRK_BUF_FM.FBUF_IN_DT = Now                                     'ﾊﾞｯﾌｧ入日時
            mobjTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()                                '更新


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)の更新
            '************************
            mobjTPRG_TRK_BUF_TO.FRSV_PALLET = mobjTPRG_TRK_BUF_FM.FPALLET_ID         '仮引当ﾊﾟﾚｯﾄID
            mobjTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                   '引当状態 = 搬入予約
            mobjTPRG_TRK_BUF_TO.FRSV_BUF_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO        'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            mobjTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY   'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            mobjTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                '更新


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

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
