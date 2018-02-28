'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫ﾄﾗｯｷﾝｸﾞ定義ｸﾗｽ(ﾊﾟﾚｯﾄID,在庫ﾛｯﾄ№指定)
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100502
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
    Private mFTRK_BUF_NO_TO As Nullable(Of Integer)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ)
    Private mFPALLET_ID As String                       'ﾊﾟﾚｯﾄID
    Private mFLOT_NO_STOCK() As String                  '在庫ﾛｯﾄ№
    Private mFSAGYOU_KIND As Nullable(Of Integer)       '作業種別
    Private mFTERM_ID As String                         '端末ID
    Private mFUSER_ID As String                         'ﾕｰｻﾞｰID
    Private mFCARRYQUE_KUBUN As Integer = FCARRYQUE_KUBUN_SOUT    '指示区分
    Private mFPLAN_KEY() As String                      '計画ｷｰ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "

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
    ''' <summary>在庫ﾛｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FLOT_NO_STOCK() As String()
        Get
            Return mFLOT_NO_STOCK
        End Get
        Set(ByVal Value() As String)
            mFLOT_NO_STOCK = Value
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
    Public Property FPLAN_KEY() As String()
        Get
            Return mFPLAN_KEY
        End Get
        Set(ByVal Value() As String)
            mFPLAN_KEY = Value
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
#Region "  出庫ﾄﾗｯｷﾝｸﾞ定義                                                                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' 出庫ﾄﾗｯｷﾝｸﾞ定義
    ''' </summary>
    ''' <param name="decReqNum">引当要求数</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_OUT_BUF(ByVal decReqNum() As Decimal)
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期ﾁｪｯｸ
            '************************
            If mFLOT_NO_STOCK.Length <> decReqNum.Length Then
                Throw New UserException(ERRMSG_ERR_PROPERTY & "[配列要素数が違います。]")
            End If


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定(棚)
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID                                'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                         '特定


            '************************
            '棚かﾁｪｯｸ
            '************************
            Dim objTMST_TRK_Check As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK_Check.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK_Check.GET_TMST_TRK(True)                           '特定
            If objTMST_TRK_Check.FBUF_KIND <> FBUF_KIND_SASRS Then
                '(自動倉庫以外の場合)
                strMsg = "ﾊﾞｯﾌｧ種別 <> 自動倉庫" & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTMST_TRK_Check.FTRK_BUF_NO) & "]"
                Throw New UserException(strMsg)
            End If


            For ii As Integer = 0 To mFLOT_NO_STOCK.Length - 1
                '(ﾙｰﾌﾟ:混載数)


                '**********************************
                '計画ｷｰ取得
                '**********************************
                Dim strFLOT_NO_STOCK As String
                If IsNull(mFPLAN_KEY) Then
                    strFLOT_NO_STOCK = FPLAN_KEY_SKOTEI
                Else
                    strFLOT_NO_STOCK = mFPLAN_KEY(ii)
                End If


                '**********************************
                '在庫引当
                '**********************************
                If ii = 0 Then
                    Dim objSVR_100202 As New SVR_100202(Owner, ObjDb, ObjDbLog)     '在庫引当ｸﾗｽ
                    objSVR_100202.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO         'ﾊﾞｯﾌｧ№
                    objSVR_100202.INTMaxPlt = KOTEI_MAX_PLT                         '最大引当ﾊﾟﾚｯﾄ数
                    objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.CHANGE_ALL  '更新ﾓｰﾄﾞ(通常)
                    objSVR_100202.FPALLET_ID = mFPALLET_ID                          'ﾊﾟﾚｯﾄID
                    objSVR_100202.FLOT_NO_STOCK = mFLOT_NO_STOCK(ii)                '在庫ﾛｯﾄ№
                    objSVR_100202.FBUF_TO = mFTRK_BUF_NO_TO                         '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    intRet = objSVR_100202.FIND_STOCK(decReqNum(ii))                '在庫引当
                    If intRet <> RetCode.OK Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_SYS_100202 & "[ﾊﾟﾚｯﾄID:" & objSVR_100202.FPALLET_ID & "]"
                        Throw New UserException(strMsg)
                    End If
                End If


                '************************
                '在庫引当情報の登録
                '************************
                Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
                objTSTS_HIKIATE.FSAGYOU_KIND = mFSAGYOU_KIND                        '作業種別
                objTSTS_HIKIATE.FPLAN_KEY = strFLOT_NO_STOCK                        '計画ｷｰ
                objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID             'ﾊﾟﾚｯﾄID
                objTSTS_HIKIATE.FLOT_NO_STOCK = mFLOT_NO_STOCK(ii)                  '在庫ﾛｯﾄ№
                objTSTS_HIKIATE.FTR_VOL = FTR_VOL_SKOTEI                            '搬送管理量
                objTSTS_HIKIATE.FTERM_ID = mFTERM_ID                                '端末ID
                objTSTS_HIKIATE.FUSER_ID = mFUSER_ID                                'ﾕｰｻﾞｰID
                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/11/07  指示待ち理由の初期値設定
                objTSTS_HIKIATE.FWAIT_REASON = FWAIT_REASON_SOUT_DEFAULT            '指示待ち理由
                '↑↑↑↑↑↑************************************************************************************************************
                objTSTS_HIKIATE.FTRNS_START_DT = DEFAULT_DATE                       '搬送開始日時
                objTSTS_HIKIATE.FTRNS_END_DT = DEFAULT_DATE                         '搬送完了日時
                objTSTS_HIKIATE.FUPDATE_DT = Now                                    '更新日時
                objTSTS_HIKIATE.ADD_TSTS_HIKIATE()                                  '登録


            Next


            '***************************************************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新(棚)  在庫引当処理で在庫引当状態が更新されている為、再取得が必要
            '***************************************************************************************
            objTPRG_TRK_BUF.CLEAR_PROPERTY()                    'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
            objTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID            'ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)     '特定


            '************************
            'ｸﾚｰﾝﾏｽﾀの特定
            '************************
            Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) 'ｸﾚｰﾝﾏｽﾀｸﾗｽ
            objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO         'ﾊﾞｯﾌｧ№
            objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF.FRAC_RETU          '列
            intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                       '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '出庫先ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO_TO                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                                     '特定


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの更新(棚)
            '************************
            objTPRG_TRK_BUF.FRSV_PALLET = objTPRG_TRK_BUF.FPALLET_ID            '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF.FTR_FM = objTPRG_TRK_BUF.FTRK_BUF_NO                '搬送FMﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF.FTR_TO = mFTRK_BUF_NO_TO                            '搬送TOﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF.FTR_IDOU = DEFAULT_INTEGER                          '搬送TO移動ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF.FTRNS_FM = DEFAULT_STRING                           '搬送指令用FM
            objTPRG_TRK_BUF.FTRNS_TO = DEFAULT_STRING                           '搬送指令用TO
            objTPRG_TRK_BUF.FRSV_BUF_FM = objTPRG_TRK_BUF.FTRK_BUF_NO           'FM引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF.FRSV_ARRAY_FM = objTPRG_TRK_BUF.FTRK_BUF_ARRAY      'FM引当配列№
            objTPRG_TRK_BUF.FRSV_BUF_TO = DEFAULT_INTEGER                       'TO引当ﾄﾗｯｷﾝｸﾞ№
            objTPRG_TRK_BUF.FRSV_ARRAY_TO = DEFAULT_INTEGER                     'TO引当配列№
            objTPRG_TRK_BUF.FDISP_ADDRESS_FM = objTPRG_TRK_BUF.FDISP_ADDRESS    'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF.FDISP_ADDRESS_TO = objTMST_TRK.FBUF_NAME            'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF.FBUF_IN_DT = Now                                    'ﾊﾞｯﾌｧ入日時
            objTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                               '更新


            '************************
            '作業種別毎制御情報の特定
            '************************
            Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
            objTMST_SAGYO.FSAGYOU_KIND = mFSAGYOU_KIND
            objTMST_SAGYO.FEQ_ID = FEQ_ID_SKOTEI
            objTMST_SAGYO.GET_TMST_SAGYO()


            '************************
            '出庫指示QUEの登録
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUEｸﾗｽ
            objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
            objTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                         '設備ID
            objTPLN_CARRY_QUE.FPRIORITY = objTMST_SAGYO.FPRIORITY                   '優先ﾚﾍﾞﾙ
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID               'ﾊﾟﾚｯﾄID
            objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = mFCARRYQUE_KUBUN                    '指示区分
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況
            objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '登録日時
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '更新日時
            objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '登録


            '************************
            '次処理起動
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫先ﾄﾗｯｷﾝｸﾞ):" & mFTRK_BUF_NO_TO & "]" _
                             & "[ﾊﾟﾚｯﾄID:" & mFPALLET_ID & "]" _
                             & "[作業種別:" & mFSAGYOU_KIND & "]" _
                             & "[端末ID:" & mFTERM_ID & "]" _
                             & "[ﾕｰｻﾞｰID:" & mFUSER_ID & "]" _
                             & "[指示区分:" & mFCARRYQUE_KUBUN & "]" _
                             & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(出庫元ﾄﾗｯｷﾝｸﾞ):" & objTPRG_TRK_BUF.FDISP_ADDRESS & "]" _
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
    End Sub

#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
