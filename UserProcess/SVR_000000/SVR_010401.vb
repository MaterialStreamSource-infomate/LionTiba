'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】手動搬送処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_010401
    Inherits clsTemplateServer

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
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            '************************
            '搬送ﾙｰﾄﾏｽﾀ取得
            '************************
            Dim objTMST_ROUTE As New TBL_TMST_ROUTE(Owner, ObjDb, ObjDbLog)     '搬送ﾙｰﾄﾏｽﾀ
            objTMST_ROUTE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SMOVE_MANUAL        '指示区分
            intRet = objTMST_ROUTE.GET_TMST_ROUTE_ANY()                         '取得
            If intRet = RetCode.OK Then
                For ii As Integer = LBound(objTMST_ROUTE.ARYME) To UBound(objTMST_ROUTE.ARYME)
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                    Try

                        '************************
                        'ﾄﾗｷﾝｸﾞ移動処理
                        '************************
                        Call MoveTrk(objTMST_ROUTE.ARYME(ii))


                    Catch ex As ContinueForException
                        ObjDb.RollBack()        'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()      'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Catch ex As UserException
                        Call ComUser(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Catch ex As Exception
                        Call ComError(ex, MeSyoriID)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        ObjDb.RollBack()                                    'ﾛｰﾙﾊﾞｯｸ
                        ObjDb.BeginTrans()                                  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    Finally
                        ObjDb.Commit()      'ｺﾐｯﾄ
                        ObjDb.BeginTrans()  'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                    End Try

                Next
            End If


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
#Region "  ﾄﾗｷﾝｸﾞ移動処理                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｷﾝｸﾞ移動処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MoveTrk(ByVal objTMST_ROUTE As TBL_TMST_ROUTE)
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            ''************************
            ''搬送条件
            ''************************
            'If 1 <> 1 Then
            'ElseIf objTMST_ROUTE.FBUF_FM = FTRK_BUF_NO_191 And objTMST_ROUTE.FBUF_TO = FTRK_BUF_NO_J101 Then
            'ElseIf objTMST_ROUTE.FBUF_FM = FTRK_BUF_NO_291 And objTMST_ROUTE.FBUF_TO = FTRK_BUF_NO_J201 Then
            'Else
            '    Throw New ContinueForException
            'End If


            '************************
            '搬送元ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTMST_ROUTE.FBUF_FM                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_FM.FTR_TO = objTMST_ROUTE.FBUF_TO                               '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF_FIFO()                             '取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Throw New ContinueForException
            End If


            '************************
            '搬送先ﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTMST_ROUTE.FBUF_NEXT                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF_AKI_HIRA()                         '取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                Throw New ContinueForException
            End If


            '************************
            '在庫引当情報の特定
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog) '在庫引当情報ｸﾗｽ
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID          'ﾊﾟﾚｯﾄID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[ﾊﾟﾚｯﾄID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            'ﾙｰﾄ設備ﾁｪｯｸ(From - To)
            '************************
            Dim objSVR_100203 As New SVR_100203(Owner, ObjDb, ObjDbLog)
            objSVR_100203.FBUF_FM = objTMST_ROUTE.FBUF_FM                   '元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FBUF_TO = objTMST_ROUTE.FBUF_TO                   '先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objSVR_100203.FEQ_ID_CRANE_FM = objTMST_ROUTE.FEQ_ID_CRANE_FM   '元ｸﾚｰﾝ設備ID
            objSVR_100203.FEQ_ID_CRANE_TO = objTMST_ROUTE.FEQ_ID_CRANE_TO   '先ｸﾚｰﾝ設備ID
            intRet = objSVR_100203.CHECK_ROUTE(objTSTS_HIKIATE)
            If intRet = RetCode.NG Then
                '(ｴﾗｰの場合)
                Exit Sub
            End If


            '************************
            '特殊処理02
            'ﾌﾟﾛﾊﾟﾃｨｺﾋﾟｰ
            '************************
            Call Special02(objTPRG_TRK_BUF_FM, objTPRG_TRK_BUF_TO)


            '************************
            '在庫移動
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '在庫移動ｸﾗｽ
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_FM       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(FM)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_TO       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(TO)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_FM.FPALLET_ID    'ﾊﾟﾚｯﾄID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SIN_UKETUKE_IDOU       'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '作業種別
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '搬送元ｸﾘｱﾌﾗｸﾞ
            objSVR_100103.STOCK_TRNS()                                  '移動


            '************************
            '指示送信待ち理由のｸﾘｱ
            '************************
            objTSTS_HIKIATE.FWAIT_REASON = DEFAULT_STRING
            objTSTS_HIKIATE.FUPDATE_DT = Now
            objTSTS_HIKIATE.UPDATE_TSTS_HIKIATE()


            '************************
            '正常終了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL _
                             & "  [ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_TO.FPALLET_ID & "]" _
                             & "  [搬送元:" & objTPRG_TRK_BUF_FM.FTRK_BUF_NO & "]" _
                             & "  [搬送先:" & objTPRG_TRK_BUF_TO.FTRK_BUF_NO & "]" _
                              )


        Catch ex As ContinueForException
            Throw New ContinueForException()
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
#Region "  特殊処理01                                                                        "
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' 特殊処理01
    '''' </summary>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Public Sub Special01(ByRef objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
    '                   , ByRef objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
    '                   )
    '    Dim intRet As RetCode                   '戻り値
    '    Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try


    '        '************************
    '        '倉庫ﾊﾞｯﾌｧの特定
    '        '************************
    '        Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FRSV_BUF_TO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    '        intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF()
    '        If intRet = RetCode.NotFound Then
    '            '(見つからない場合)
    '            strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO) & "  ,ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & TO_STRING(objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY) & "]"
    '            Throw New UserException(strMsg)
    '        End If


    '        '************************
    '        'ｸﾚｰﾝﾏｽﾀの特定
    '        '************************
    '        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog)     'ｸﾚｰﾝﾏｽﾀｸﾗｽ
    '        objTMST_CRANE.FTRK_BUF_NO = objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO        'ﾊﾞｯﾌｧ№
    '        objTMST_CRANE.INTCHECK_ROW = objTPRG_TRK_BUF_ASRS.FRAC_RETU         '列
    '        intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                           '特定
    '        If intRet = RetCode.NotFound Then
    '            '(見つからない場合)
    '            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[ﾊﾞｯﾌｧ№:" & TO_STRING(objTMST_CRANE.FTRK_BUF_NO) & "  ,列:" & TO_STRING(objTMST_CRANE.INTCHECK_ROW) & "]"
    '            Throw New UserException(strMsg)
    '        End If


    '        '************************
    '        '作業種別毎制御情報の特定
    '        '************************
    '        Dim intFPRIORITY As Integer = FPRIORITY_SLOW
    '        Dim objTMST_SAGYO As New TBL_TMST_SAGYO(Owner, ObjDb, ObjDbLog)
    '        objTMST_SAGYO.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND
    '        objTMST_SAGYO.FEQ_ID = KOTEI_EQ_ID
    '        intRet = objTMST_SAGYO.GET_TMST_SAGYO()
    '        If intRet = RetCode.OK Then
    '            intFPRIORITY = objTMST_SAGYO.FPRIORITY
    '        End If


    '        '************************
    '        '搬送指示QUEの登録
    '        '************************
    '        Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '搬送指示QUEｸﾗｽ
    '        objTPLN_CARRY_QUE.FCARRYQUE_D = Now                                     '搬送指示日
    '        objTPLN_CARRY_QUE.FEQ_ID = objTMST_CRANE.FEQ_ID                         '設備ID
    '        objTPLN_CARRY_QUE.FPRIORITY = intFPRIORITY                              'ﾌﾟﾗｲｵﾘﾃｨ区分
    '        objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_TO.FPALLET_ID            'ﾊﾟﾚｯﾄID
    '        objTPLN_CARRY_QUE.FCARRYQUE_KUBUN = FCARRYQUE_KUBUN_SIN                  '搬送区分
    '        objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '搬送指示状況
    '        objTPLN_CARRY_QUE.FENTRY_DT = Now                                       '登録日時
    '        objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '更新日時
    '        objTPLN_CARRY_QUE.ADD_TPLN_CARRY_QUE_ORDER()                            '登録


    '        '*********** ↓↓↓ｼｽﾃﾑ固有 N.Dounoshita 2011/09/14
    '        '*******************************************************************************************************************************************************************

    '        '************************
    '        '次処理起動
    '        '************************
    '        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)     '定周期管理ｸﾗｽ
    '        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                            '起動

    '        '*******************************************************************************************************************************************************************
    '        '*********** ↑↑↑ｼｽﾃﾑ固有 N.Dounoshita 2011/09/14


    '    Catch ex As ContinueForException
    '        Throw New ContinueForException()
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Throw ex
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Throw ex
    '    End Try
    'End Sub
#End Region
#Region "  特殊処理02                                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理02
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Special02(ByRef objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                       , ByRef objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                       )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            objTPRG_TRK_BUF_TO.FRSV_PALLET = objTPRG_TRK_BUF_FM.FRSV_PALLET         '仮引当ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF_TO.FTR_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO              '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTR_TO = objTPRG_TRK_BUF_FM.FTR_TO                   '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTR_IDOU = objTPRG_TRK_BUF_FM.FTR_IDOU               '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRNS_FM               '搬送指令用FM
            objTPRG_TRK_BUF_TO.FTRNS_TO = objTPRG_TRK_BUF_FM.FTRNS_TO               '搬送指令用TO
            objTPRG_TRK_BUF_TO.FRSV_BUF_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_NO         'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FRSV_ARRAY_FM = objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY    'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            objTPRG_TRK_BUF_TO.FRSV_BUF_TO = objTPRG_TRK_BUF_FM.FRSV_BUF_TO         'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_TO.FRSV_ARRAY_TO = objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO     'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
            objTPRG_TRK_BUF_TO.FDISP_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS          'FM表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_TO.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO       'TO表記用ｱﾄﾞﾚｽ
            objTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM = objTPRG_TRK_BUF_FM.FDISP_ADDRESS       'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_TO = objTPRG_TRK_BUF_FM.FDISPLOG_ADDRESS_TO 'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            objTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()


        Catch ex As ContinueForException
            Throw New ContinueForException()
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
