'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】棚間移動ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID指定)(自動的に棚を引当てる)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100602
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
    Private mobjTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)
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
    ''' <returns>正常終了or異常終了</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function UPDATE_MOVE_BUF(ByVal decReqNum As Decimal) As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
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
            '搬送先ｸﾚｰﾝID取得
            '************************
            Dim objTMST_CRANE_TO As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)             'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE_TO.FTRK_BUF_NO = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO                 'ﾊﾞｯﾌｧ№
            intRet = objTMST_CRANE_TO.GET_TMST_CRANE_ANY                                   '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE_TO.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE_TO.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If
            Dim strEQ_ID(UBound(objTMST_CRANE_TO.ARYME)) As String      'ｸﾚｰﾝID
            For jj As Integer = LBound(objTMST_CRANE_TO.ARYME) To UBound(objTMST_CRANE_TO.ARYME)
                strEQ_ID(jj) = objTMST_CRANE_TO.ARYME(jj).FEQ_ID        '設備ID
            Next


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/04  在庫の棚形状種別を取得

            '************************************************
            '引当ﾀｲﾌﾟ特定ﾏｽﾀ        取得
            '************************************************
            Dim objTMST_SP_RES_TYPE As New TBL_TMST_SP_RES_TYPE(Owner, ObjDb, ObjDbLog)

            '↓↓↓↓↓↓************************************************************************************************************
            'CommentMate:A.Noto 2012/06/26 後で設定必須
            ''objTMST_SP_RES_TYPE.FCONDITION01 = GetFRAC_FORMFromXRACK_RESERVED_CD(objTRST_STOCK.ARYME(0).XRACK_RESERVED_CD)      '条件01(棚形状種別)
            '↑↑↑↑↑↑************************************************************************************************************
            '↓↓↓↓↓↓************************************************************************************************************
            'CommentMate:A.Noto 2012/07/07 後で設定必須
            ''objTMST_SP_RES_TYPE.FCONDITION02 = XRAC_PRIORITY_JPRIORITY                                      '条件02(棚優先)
            '↑↑↑↑↑↑************************************************************************************************************
            objTMST_SP_RES_TYPE.GET_TMST_SP_RES_TYPE()

            ''************************
            ''品目ﾏｽﾀの特定
            ''************************
            'Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            'objTMST_ITEM.FHINMEI_CD = mobjTRST_STOCK.ARYME(0).FHINMEI_CD        '品目ｺｰﾄﾞ
            'intRet = objTMST_ITEM.GET_TMST_ITEM(True)                           '特定

            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            '移動先ﾊﾞｯﾌｧの空棚引当
            '************************
            Dim objSVR_100201 As New SVR_100201(Owner, ObjDb, ObjDbLog)         '空棚引当ｸﾗｽ
            objSVR_100201.FTRK_BUF_NO = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO         'ﾊﾞｯﾌｧ№
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2012/04/04  在庫の棚形状種別を取得
            objSVR_100201.FRES_TYPE = objTMST_SP_RES_TYPE.FRES_TYPE             '引当ﾀｲﾌﾟ
            'objSVR_100201.FRAC_FORM = objTMST_ITEM.FRAC_FORM                    '棚形状種別
            '↑↑↑↑↑↑************************************************************************************************************
            objSVR_100201.FEQ_ID_CRANE = strEQ_ID                               'ｸﾚｰﾝID
            objSVR_100201.FPALLET_ID = mobjTPRG_TRK_BUF_FM.FPALLET_ID           'ﾊﾟﾚｯﾄID
            intRet = objSVR_100201.FIND_TANA_AKI                                '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)

                If mblnTanaManpaiErr = True Then
                    '(棚満杯時ｴﾗｰの場合)

                    Select Case objSVR_100201.FTRK_BUF_NO
                        Case FTRK_BUF_NO_J9000 : Call AddToMsgLog(Now, FMSG_ID_S0102)
                        Case Else : Call AddToMsgLog(Now, FMSG_ID_S0102)
                    End Select

                    strMsg = ERRMSG_NOTFOUND_AKI
                    Throw New UserException(strMsg)

                Else
                    '(棚満杯時ﾉｰｴﾗｰの場合)
                    Return RetCode.NotFound
                End If

            End If
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objSVR_100201.FTRK_BUF_NO          'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objSVR_100201.FTRK_BUF_ARRAY    '配列№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(False)                 '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_BUF_AKI & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_NO) & "  ,配列№:" & TO_STRING(objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If


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
            objTPRG_TRK_BUF_TO.FRSV_PALLET = mobjTPRG_TRK_BUF_FM.FPALLET_ID         '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SRSV_TRNS_IN                    '引当状態 = 搬入予約
            objTPRG_TRK_BUF_TO.FRSV_BUF_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO        'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY   'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                                '更新


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

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
