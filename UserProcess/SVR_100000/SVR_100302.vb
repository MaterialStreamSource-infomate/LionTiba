'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.  
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞ削除ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100302
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFPALLET_ID As String                   'ﾊﾟﾚｯﾄID
    Private mFTERM_ID As String                     '端末ID
    Private mFUSER_ID As String                     'ﾕｰｻﾞｰID
    Private mFINOUT_STS As Integer = FINOUT_STS_SMENTE_DELETE    'IN/OUT
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Integer
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Integer)
            mFTRK_BUF_NO = Value
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
    ''' <summary>IN/OUT</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FINOUT_STS() As Integer
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Integer)
            mFINOUT_STS = Value
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
#Region "  ﾄﾗｯｷﾝｸﾞ削除                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞ削除
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_DELETE()
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '特定


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/03 予定数ﾏｲﾅｽ1


            ''*********************************************
            ''予定数ﾏｲﾅｽ1
            ''*********************************************
            'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


            'Call Special31()
            '↑↑↑↑↑↑************************************************************************************************************


            '************************
            'ﾄﾗｯｷﾝｸﾞ削除
            '************************
            Call DeleteTrkBuf(mFPALLET_ID, mFTRK_BUF_NO)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞ,在庫情報,その他ﾊﾟﾚｯﾄに関係する情報全て削除
    ''' </summary>
    ''' <param name="strPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intTRK_BUF_NO">ﾊﾞｯﾌｧ№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DeleteTrkBuf(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)

        Try
            Dim intRet As RetCode                   '戻り値
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '************************
            '在庫ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FTRK_BUF_NO = intTRK_BUF_NO                             'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                         '特定


            '************************
            '在庫引当情報の特定
            '************************
            Dim intSAGYOU_KIND As Integer       '作業種別
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '在庫引当情報
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '特定
            If intRet = RetCode.OK Then
                intSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                       '作業種別

                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  混載の削除に対応

                ''************************
                ''在庫引当情報の削除
                ''************************
                'objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
                'objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
                'objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除

                '↑↑↑↑↑↑************************************************************************************************************

            Else
                '(見つからない場合)

                intSAGYOU_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON                 '作業種別

            End If


            '************************
            '在庫情報の取得
            '************************
            Dim objTRST_STOCK_BASE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)        '在庫情報ｸﾗｽ
            objTRST_STOCK_BASE.FPALLET_ID = mFPALLET_ID                                 'ﾊﾟﾚｯﾄID
            objTRST_STOCK_BASE.GET_TRST_STOCK_KONSAI(False)


            '**************************************
            '保管出納記録追加
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF.FTRK_BUF_NO _
                                   , DEFAULT_INTEGER _
                                   , intSAGYOU_KIND _
                                   , mFTERM_ID _
                                   , mFUSER_ID _
                                   , DEFAULT_STRING _
                                   , DEFAULT_STRING _
                                   , objTRST_STOCK_BASE _
                                    )


            '************************
            '在庫削除
            '************************
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/04/25  混載の削除に対応

            For Each objTRST_STOCK As TBL_TRST_STOCK In objTRST_STOCK_BASE.ARYME
                Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
                objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                objSVR_100102.FPALLET_ID = strPALLET_ID                     'ﾊﾟﾚｯﾄID
                objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '在庫ﾛｯﾄ№
                objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT(ﾒﾝﾃﾅﾝｽ登録)
                objSVR_100102.FSAGYOU_KIND = intSAGYOU_KIND                 '作業種別
                objSVR_100102.STOCK_DELETE()                                '削除
            Next


            '************************
            '在庫引当情報の削除
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '削除


            'Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '在庫削除ｸﾗｽ
            'objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            'objSVR_100102.FPALLET_ID = strPALLET_ID                     'ﾊﾟﾚｯﾄID
            'objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT(ﾒﾝﾃﾅﾝｽ登録)
            'objSVR_100102.FSAGYOU_KIND = intSAGYOU_KIND                 '作業種別
            'objSVR_100102.STOCK_DELETE()                                '削除

            '↑↑↑↑↑↑************************************************************************************************************


            '**************************************
            '配列解放
            '**************************************
            objTRST_STOCK_BASE.ARYME_CLEAR()


            '************************
            '予約ﾊﾞｯﾌｧの解放
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '解放


            '************************
            '搬送指示QUEの削除
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                    '特定
            If intRet = RetCode.OK Then
                '(見つかった場合)
                objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE()   '削除
            End If


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            'ｼﾘｱﾙ関連付け削除
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       'ｼﾘｱﾙ関連付けｸﾗｽ
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                'ﾊﾟﾚｯﾄID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '削除



            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


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
