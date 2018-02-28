'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出庫棚前後入替
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310305
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
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '****************************************
            '搬送指示QUE(ﾀｰｹﾞｯﾄ)            取得
            '****************************************
            Dim objAryTPLN_CARRY_QUE_Target As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
            objAryTPLN_CARRY_QUE_Target.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON        '搬送指示状況
            intRet = objAryTPLN_CARRY_QUE_Target.GET_TPLN_CARRY_QUE_ANY()                 '取得
            If intRet = RetCode.OK Then
                For Each objTPLN_CARRY_QUE_Target As TBL_TPLN_CARRY_QUE In objAryTPLN_CARRY_QUE_Target.ARYME
                    '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)


                    '****************************************
                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(奥棚)         取得
                    '****************************************
                    Dim objTrkFind As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    objTrkFind.FPALLET_ID = objTPLN_CARRY_QUE_Target.FPALLET_ID        'ﾊﾟﾚｯﾄID
                    objTrkFind.GET_TPRG_TRK_BUF()                                      '取得
                    If objTrkFind.FRAC_EDA = FLAG_OFF Then Continue For


                    '***********************************************
                    '関連するﾌﾞﾛｯｸ棚の取得
                    '***********************************************
                    Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
                    Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '在庫情報
                    Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '在庫情報
                    Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)


                    '****************************************
                    '関連する棚ﾌﾞﾛｯｸの取得(在庫引当情報、搬送指示QUE)
                    '****************************************
                    Dim objHikiateFind As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)      '在庫引当情報
                    Dim objHikiateRelation() As TBL_TSTS_HIKIATE = Nothing                  '在庫引当情報
                    Dim objQueFind As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)        '搬送指示QUE
                    Dim objQueRelation() As TBL_TPLN_CARRY_QUE = Nothing                    '搬送指示QUE
                    Call GetInfor_Relation(objTrkFind, objTrkRelation, objHikiateFind, objHikiateRelation, objQueFind, objQueRelation)


                    '***********************************************
                    '前棚が蓋をしているかﾁｪｯｸ
                    '***********************************************
                    Dim intRet01 As RetCode                   '戻り値
                    Dim intRet02 As RetCode                   '戻り値
                    '前棚奇数
                    intRet01 = Check01(objTrkRelation(RelationArray.MAE_ODD))
                    '前棚偶数
                    intRet02 = Check01(objTrkRelation(RelationArray.MAE_EVN))
                    If intRet01 <> RetCode.OK And intRet02 <> RetCode.OK Then
                        '(両方とも蓋をしていない場合)
                        Continue For
                    End If


                    '***********************************************
                    '
                    '***********************************************
                    Dim objTPRG_TRK_BUF_Irekae As TBL_TPRG_TRK_BUF          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(入替前棚)
                    Dim objTSTS_HIKIATE_Irekae As TBL_TSTS_HIKIATE          '在庫引当情報(入替前棚)
                    Dim objTPLN_CARRY_QUE_Irekae As TBL_TPLN_CARRY_QUE      '搬送指示QUE(入替前棚)
                    If objTrkFind.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD And IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) Then
                        '(奥棚奇数 と 前棚奇数 が入替可能な場合)

                        objTPRG_TRK_BUF_Irekae = objTrkRelation(RelationArray.MAE_ODD)
                        objTSTS_HIKIATE_Irekae = objHikiateRelation(RelationArray.MAE_ODD)
                        objTPLN_CARRY_QUE_Irekae = objQueRelation(RelationArray.MAE_ODD)

                    ElseIf objTrkFind.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN And IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
                        '(奥棚偶数 と 前棚偶数 が入替可能な場合)

                        objTPRG_TRK_BUF_Irekae = objTrkRelation(RelationArray.MAE_EVN)
                        objTSTS_HIKIATE_Irekae = objHikiateRelation(RelationArray.MAE_EVN)
                        objTPLN_CARRY_QUE_Irekae = objQueRelation(RelationArray.MAE_EVN)

                    ElseIf intRet01 = RetCode.OK Then
                        '(前棚奇数が蓋をしている場合)

                        objTPRG_TRK_BUF_Irekae = objTrkRelation(RelationArray.MAE_ODD)
                        objTSTS_HIKIATE_Irekae = objHikiateRelation(RelationArray.MAE_ODD)
                        objTPLN_CARRY_QUE_Irekae = objQueRelation(RelationArray.MAE_ODD)

                    ElseIf intRet02 = RetCode.OK Then
                        '(前棚偶数が蓋をしている場合)

                        objTPRG_TRK_BUF_Irekae = objTrkRelation(RelationArray.MAE_EVN)
                        objTSTS_HIKIATE_Irekae = objHikiateRelation(RelationArray.MAE_EVN)
                        objTPLN_CARRY_QUE_Irekae = objQueRelation(RelationArray.MAE_EVN)

                    Else
                        '(それ以外の場合は入替を行わない)
                        Continue For
                    End If


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/12/24 奥棚と手前棚の数量を比較
                    ' '' ''↓↓↓↓↓↓************************************************************************************************************
                    ' '' ''JobMate:S.Ouchi 2013/11/14 奥棚と手前棚の数量を比較
                    '' ''If objTrkFind.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_ODD And IsNotNull(objTrkRelation(RelationArray.MAE_ODD).FPALLET_ID) Then
                    '' ''    If TO_DECIMAL(objStockFind.FTR_VOL) <> TO_DECIMAL(objStockRelation(RelationArray.MAE_ODD).FTR_VOL) Then
                    '' ''        '(数量が違う場合は入替を行わない)
                    '' ''        Continue For
                    '' ''    End If
                    '' ''ElseIf objTrkFind.XTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN And IsNotNull(objTrkRelation(RelationArray.MAE_EVN).FPALLET_ID) Then
                    '' ''    If TO_DECIMAL(objStockFind.FTR_VOL) <> TO_DECIMAL(objStockRelation(RelationArray.MAE_EVN).FTR_VOL) Then
                    '' ''        '(数量が違う場合は入替を行わない)
                    '' ''        Continue For
                    '' ''    End If
                    '' ''End If
                    ' '' ''JobMate:S.Ouchi 2013/11/14 奥棚と手前棚の数量を比較
                    ' '' ''↑↑↑↑↑↑************************************************************************************************************
                    Dim blnSkipFlg As Boolean = False
                    For Each objStockRelationWK As TBL_TRST_STOCK In objStockRelation
                        If IsNull(objStockRelationWK) = False Then
                            If TO_DECIMAL(objStockFind.ARYME(0).FTR_VOL) <> TO_DECIMAL(objStockRelationWK.ARYME(0).FTR_VOL) Then
                                blnSkipFlg = True
                            End If
                        End If
                    Next
                    If blnSkipFlg = True Then
                        Continue For
                    End If
                    'JobMate:S.Ouchi 2013/12/24 奥棚と手前棚の数量を比較
                    '↑↑↑↑↑↑************************************************************************************************************


                    '***********************************************
                    '出庫ﾄﾗｯｷﾝｸﾞの入替
                    '***********************************************
                    Call Irekae(objTrkFind, objTPRG_TRK_BUF_Irekae, objHikiateFind, objTSTS_HIKIATE_Irekae, objQueFind, objTPLN_CARRY_QUE_Irekae)


                    '***********************************************
                    'もう一回ﾃﾞｰﾀを取り直す
                    '***********************************************
                    Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)
                    Call GetInfor_Relation(objTrkFind, objTrkRelation, objHikiateFind, objHikiateRelation, objQueFind, objQueRelation)


                    '***********************************************
                    'ﾌﾞﾛｯｸ内の親子関係を振り直す
                    '***********************************************
                    Call OyakoHurinaoshi(objTrkRelation, objHikiateRelation, objQueRelation)


                    '************************
                    '正常完了
                    '************************
                    Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                                     FLOG_DATA_TRN_SEND_NORMAL _
                                     & "[ﾊﾟﾚｯﾄID(前):" & objTPRG_TRK_BUF_Irekae.FPALLET_ID & "]" _
                                     & "[ﾊﾟﾚｯﾄID(奥):" & objTrkFind.FPALLET_ID & "]" _
                                     & "[出庫先(前):" & objTPRG_TRK_BUF_Irekae.FTR_TO & "]" _
                                     & "[出庫先(奥):" & objTrkFind.FTR_TO & "]" _
                                     )















                    ''****************************************
                    ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ               入替
                    ''****************************************
                    ''一時保管
                    'Dim objTPRG_TRK_BUF_Temp As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    'objTPRG_TRK_BUF_Temp.COPY_PROPERTY(objTrkRelation(RelationArray.OKU_ODD))
                    ''奥→前
                    'objTrkRelation(RelationArray.MAE_ODD).FTR_TO = objTrkFind.FTR_TO                         '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'objTrkRelation(RelationArray.MAE_ODD).FDISP_ADDRESS_TO = objTrkFind.FDISP_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
                    'objTrkRelation(RelationArray.MAE_ODD).UPDATE_TPRG_TRK_BUF()                              '更新
                    ''前→奥
                    'objTrkFind.FTR_TO = objTPRG_TRK_BUF_Temp.FTR_TO                          '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'objTrkFind.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_Temp.FDISP_ADDRESS_TO      'TO表記用ｱﾄﾞﾚｽ
                    'objTrkFind.UPDATE_TPRG_TRK_BUF()                                         '更新


                    ''****************************************
                    ''在庫引当情報               入替
                    ''****************************************
                    ''一旦削除
                    'objHikiateFind.DELETE_TSTS_HIKIATE()
                    'objHikiateRelation(RelationArray.MAE_ODD).DELETE_TSTS_HIKIATE()
                    ''一時保管
                    'Dim objTSTS_HIKIATE_Temp As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    'objTSTS_HIKIATE_Temp.COPY_PROPERTY(objHikiateFind)
                    ''奥→前
                    'objHikiateRelation(RelationArray.MAE_ODD).FPALLET_ID = objHikiateFind.FPALLET_ID        'ﾊﾟﾚｯﾄID
                    'objHikiateRelation(RelationArray.MAE_ODD).ADD_TSTS_HIKIATE()                            '追加
                    ''前→奥
                    'objHikiateFind.FPALLET_ID = objTSTS_HIKIATE_Temp.FPALLET_ID         'ﾊﾟﾚｯﾄID
                    'objHikiateFind.ADD_TSTS_HIKIATE()                                   '追加


                    ''****************************************
                    ''搬送指示QUE                入替
                    ''****************************************
                    ''一旦削除
                    'objQueFind.DELETE_TPLN_CARRY_QUE()
                    'objQueRelation(RelationArray.MAE_ODD).DELETE_TPLN_CARRY_QUE()
                    ''一時保管
                    'Dim objTPLN_CARRY_QUE_Temp As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    'objTPLN_CARRY_QUE_Temp.COPY_PROPERTY(objHikiateFind)
                    ''奥→前
                    'objQueRelation(RelationArray.MAE_ODD).FPALLET_ID = objHikiateFind.FPALLET_ID        'ﾊﾟﾚｯﾄID
                    'objQueRelation(RelationArray.MAE_ODD).ADD_TPLN_CARRY_QUE()                          '追加
                    ''前→奥
                    'objQueFind.FPALLET_ID = objTSTS_HIKIATE_Temp.FPALLET_ID         'ﾊﾟﾚｯﾄID
                    'objQueFind.ADD_TPLN_CARRY_QUE()                                 '追加


                    ''****************************************
                    ''
                    ''****************************************















                    ''****************************************
                    ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(奥棚)         取得
                    ''****************************************
                    'Dim objTPRG_TRK_BUF_Oku As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    'objTPRG_TRK_BUF_Oku.FPALLET_ID = objTPLN_CARRY_QUE_Target.FPALLET_ID        'ﾊﾟﾚｯﾄID
                    'objTPRG_TRK_BUF_Oku.GET_TPRG_TRK_BUF()                                      '取得
                    'If objTPRG_TRK_BUF_Oku.FRAC_EDA = FLAG_OFF Then Continue For


                    ''****************************************
                    ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(前棚)         取得
                    ''****************************************
                    'Dim objTPRG_TRK_BUF_Mae As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    'objTPRG_TRK_BUF_Mae.FRAC_RETU = objTPRG_TRK_BUF_Oku.FRAC_RETU       '列
                    'objTPRG_TRK_BUF_Mae.FRAC_REN = objTPRG_TRK_BUF_Oku.FRAC_REN         '連
                    'objTPRG_TRK_BUF_Mae.FRAC_DAN = objTPRG_TRK_BUF_Oku.FRAC_DAN         '段
                    'objTPRG_TRK_BUF_Mae.FRAC_EDA = objTPRG_TRK_BUF_Oku.FRAC_EDA         '枝
                    'objTPRG_TRK_BUF_Mae.GET_TPRG_TRK_BUF()                              '取得
                    'If IsNull(objTPRG_TRK_BUF_Mae.FPALLET_ID) Then Continue For


                    ''****************************************
                    ''搬送指示QUE(前棚)          取得
                    ''****************************************
                    'Dim objTPLN_CARRY_QUE_Mae As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
                    'objTPLN_CARRY_QUE_Mae.FPALLET_ID = objTPRG_TRK_BUF_Mae.FPALLET_ID       'ﾊﾟﾚｯﾄID
                    'objTPLN_CARRY_QUE_Mae.GET_TPLN_CARRY_QUE()                              '取得
                    'If objTPLN_CARRY_QUE_Mae.FCARRYQUE_DIR_STS <> FCARRYQUE_DIR_STS_JTAIKI Then Continue For


                    ''****************************************
                    ''在庫引当情報(奥棚)          取得
                    ''****************************************
                    'Dim objTSTS_HIKIATE_Oku As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    'objTSTS_HIKIATE_Oku.FPALLET_ID = objTPRG_TRK_BUF_Oku.FPALLET_ID     'ﾊﾟﾚｯﾄID
                    'objTSTS_HIKIATE_Oku.GET_TSTS_HIKIATE_PALLET()                       '取得


                    ''****************************************
                    ''在庫引当情報(前棚)          取得
                    ''****************************************
                    'Dim objTSTS_HIKIATE_Mae As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
                    'objTSTS_HIKIATE_Mae.FPALLET_ID = objTPRG_TRK_BUF_Mae.FPALLET_ID     'ﾊﾟﾚｯﾄID
                    'objTSTS_HIKIATE_Mae.GET_TSTS_HIKIATE_PALLET()                       '取得


                    ''****************************************
                    ''ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ               入替
                    ''****************************************
                    ''一時保管
                    'Dim intFTR_TO As Integer = objTPRG_TRK_BUF_Mae.FTR_TO                           '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'Dim strFDISP_ADDRESS_TO As String = objTPRG_TRK_BUF_Mae.FDISP_ADDRESS_TO        'TO表記用ｱﾄﾞﾚｽ
                    ''奥→前
                    'objTPRG_TRK_BUF_Mae.FTR_TO = objTPRG_TRK_BUF_Oku.FTR_TO                         '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'objTPRG_TRK_BUF_Mae.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_Oku.FDISP_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
                    'objTPRG_TRK_BUF_Mae.UPDATE_TPRG_TRK_BUF()                                       '更新
                    ''前→奥
                    'objTPRG_TRK_BUF_Oku.FTR_TO = intFTR_TO                                          '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                    'objTPRG_TRK_BUF_Oku.FDISP_ADDRESS_TO = strFDISP_ADDRESS_TO                      'TO表記用ｱﾄﾞﾚｽ
                    'objTPRG_TRK_BUF_Oku.UPDATE_TPRG_TRK_BUF()                                       '更新


                    ''****************************************
                    ''在庫引当情報               入替
                    ''****************************************
                    ''一旦削除
                    'objTSTS_HIKIATE_Mae.DELETE_TSTS_HIKIATE()
                    'objTSTS_HIKIATE_Oku.DELETE_TSTS_HIKIATE()
                    ''一時保管
                    'Dim strFPALLET_ID As String = objTSTS_HIKIATE_Mae.FPALLET_ID            'ﾊﾟﾚｯﾄID
                    ''奥→前
                    'objTSTS_HIKIATE_Mae.FPALLET_ID = objTSTS_HIKIATE_Oku.FPALLET_ID         'ﾊﾟﾚｯﾄID
                    'objTSTS_HIKIATE_Mae.ADD_TSTS_HIKIATE()                                  '更新
                    ''前→奥
                    'objTSTS_HIKIATE_Oku.FPALLET_ID = strFPALLET_ID                          'ﾊﾟﾚｯﾄID
                    'objTSTS_HIKIATE_Oku.ADD_TSTS_HIKIATE()                                  '更新


                Next
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
#Region "  前棚が蓋をしているかﾁｪｯｸ                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 前棚が蓋をしているかﾁｪｯｸ
    ''' </summary>
    ''' <param name="objTrkRelation">ﾁｪｯｸするﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ</param>
    ''' <remarks>
    ''' OK       :蓋をしている
    ''' NotEnough:蓋はされていない
    ''' </remarks>
    ''' *******************************************************************************************************************
    Private Function Check01(ByVal objTrkRelation As TBL_TPRG_TRK_BUF) As RetCode
        Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '****************************************
        '在庫                   ﾁｪｯｸ
        '****************************************
        If IsNull(objTrkRelation.FPALLET_ID) Then Return RetCode.NotEnough


        '****************************************
        '蓋しているか           ﾁｪｯｸ
        '****************************************
        Dim objTPLN_CARRY_QUE_Check As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objTPLN_CARRY_QUE_Check.FPALLET_ID = objTrkRelation.FPALLET_ID      'ﾊﾟﾚｯﾄID
        intRet = objTPLN_CARRY_QUE_Check.GET_TPLN_CARRY_QUE(False)          '取得
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            '本来発生しない事だが、万一発生しても何もしない
            Return RetCode.NotEnough
        ElseIf objTPLN_CARRY_QUE_Check.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_JTAIKI Then
            '(待機の場合)
            Return RetCode.OK
        Else
            '(在庫が動く状態の場合)
            Return RetCode.NotEnough
        End If


    End Function
#End Region
#Region "  出庫ﾄﾗｯｷﾝｸﾞの入替                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫ﾄﾗｯｷﾝｸﾞの入替
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' *******************************************************************************************************************
    Private Function Irekae(ByRef objTPRG_TRK_BUF_Oku As TBL_TPRG_TRK_BUF _
                          , ByRef objTPRG_TRK_BUF_Mae As TBL_TPRG_TRK_BUF _
                          , ByRef objTSTS_HIKIATE_Oku As TBL_TSTS_HIKIATE _
                          , ByRef objTSTS_HIKIATE_Mae As TBL_TSTS_HIKIATE _
                          , ByRef objTPLN_CARRY_QUE_Oku As TBL_TPLN_CARRY_QUE _
                          , ByRef objTPLN_CARRY_QUE_Mae As TBL_TPLN_CARRY_QUE _
                          ) _
                          As RetCode
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        '****************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ               入替
        '****************************************
        '一時保管
        Dim objTPRG_TRK_BUF_Temp As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF_Temp.COPY_PROPERTY(objTPRG_TRK_BUF_Mae)
        '奥→前
        objTPRG_TRK_BUF_Mae.FTR_TO = objTPRG_TRK_BUF_Oku.FTR_TO                         '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_Mae.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_Oku.FDISP_ADDRESS_TO     'TO表記用ｱﾄﾞﾚｽ
        objTPRG_TRK_BUF_Mae.UPDATE_TPRG_TRK_BUF()                                       '更新
        '前→奥
        objTPRG_TRK_BUF_Oku.FTR_TO = objTPRG_TRK_BUF_Temp.FTR_TO                          '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTPRG_TRK_BUF_Oku.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_Temp.FDISP_ADDRESS_TO      'TO表記用ｱﾄﾞﾚｽ
        objTPRG_TRK_BUF_Oku.UPDATE_TPRG_TRK_BUF()                                         '更新


        '****************************************
        '在庫引当情報               入替
        '****************************************
        '一旦削除
        objTSTS_HIKIATE_Oku.DELETE_TSTS_HIKIATE()
        objTSTS_HIKIATE_Mae.DELETE_TSTS_HIKIATE()
        '一時保管
        Dim objTSTS_HIKIATE_Temp As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)
        objTSTS_HIKIATE_Temp.COPY_PROPERTY(objTSTS_HIKIATE_Mae)
        '奥→前
        objTSTS_HIKIATE_Mae.FPALLET_ID = objTSTS_HIKIATE_Oku.FPALLET_ID     'ﾊﾟﾚｯﾄID
        objTSTS_HIKIATE_Mae.ADD_TSTS_HIKIATE()                              '追加
        '前→奥
        objTSTS_HIKIATE_Oku.FPALLET_ID = objTSTS_HIKIATE_Temp.FPALLET_ID    'ﾊﾟﾚｯﾄID
        objTSTS_HIKIATE_Oku.ADD_TSTS_HIKIATE()                              '追加


        '****************************************
        '搬送指示QUE                入替
        '****************************************
        '一旦削除
        objTPLN_CARRY_QUE_Oku.DELETE_TPLN_CARRY_QUE()
        objTPLN_CARRY_QUE_Mae.DELETE_TPLN_CARRY_QUE()
        '一時保管
        Dim objTPLN_CARRY_QUE_Temp As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)
        objTPLN_CARRY_QUE_Temp.COPY_PROPERTY(objTPLN_CARRY_QUE_Mae)
        '奥→前
        objTPLN_CARRY_QUE_Mae.FPALLET_ID = objTPLN_CARRY_QUE_Oku.FPALLET_ID     'ﾊﾟﾚｯﾄID
        objTPLN_CARRY_QUE_Mae.ADD_TPLN_CARRY_QUE()                              '追加
        '前→奥
        objTPLN_CARRY_QUE_Oku.FPALLET_ID = objTSTS_HIKIATE_Temp.FPALLET_ID      'ﾊﾟﾚｯﾄID
        objTPLN_CARRY_QUE_Oku.ADD_TPLN_CARRY_QUE()                              '追加


        Return RetCode.OK
    End Function
#End Region
#Region "  ﾌﾞﾛｯｸ内の親子関係の振り直し                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌﾞﾛｯｸ内の親子関係の振り直し
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' *******************************************************************************************************************
    Private Function OyakoHurinaoshi(ByRef objTrkRelation() As TBL_TPRG_TRK_BUF _
                                   , ByRef objHikiateRelation() As TBL_TSTS_HIKIATE _
                                   , ByRef objQueRelation() As TBL_TPLN_CARRY_QUE _
                                   ) _
                                   As RetCode
        'Dim intRet As RetCode                 '戻り値
        'Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Dim blnOyako As Boolean = False         '親子ﾌﾗｸﾞ


        '****************************************
        '前棚判定
        '****************************************
        blnOyako = False
        If IsNotNull(objHikiateRelation(RelationArray.MAE_ODD)) And IsNotNull(objHikiateRelation(RelationArray.MAE_EVN)) Then
            '(両方とも、在庫引当情報が入っている場合)
            If objTrkRelation(RelationArray.MAE_ODD).FTR_TO = objTrkRelation(RelationArray.MAE_EVN).FTR_TO _
               And objHikiateRelation(RelationArray.MAE_ODD).FPLAN_KEY = objHikiateRelation(RelationArray.MAE_EVN).FPLAN_KEY _
               Then
                '(親子の場合)
                blnOyako = True
            End If
        End If


        '****************************************
        '前棚更新
        '****************************************
        If blnOyako = True Then
            '(親子の場合)

            If IsNotNull(objQueRelation(RelationArray.MAE_EVN)) Then
                objQueRelation(RelationArray.MAE_EVN).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.MAE_EVN).XPALLET_ID_AITE = objQueRelation(RelationArray.MAE_ODD).FPALLET_ID
                objQueRelation(RelationArray.MAE_EVN).UPDATE_TPLN_CARRY_QUE()
            End If

            If IsNotNull(objQueRelation(RelationArray.MAE_ODD)) Then
                objQueRelation(RelationArray.MAE_ODD).XOYAKO_KUBUN = XOYAKO_KUBUN_JKO
                objQueRelation(RelationArray.MAE_ODD).XPALLET_ID_AITE = objQueRelation(RelationArray.MAE_EVN).FPALLET_ID
                objQueRelation(RelationArray.MAE_ODD).UPDATE_TPLN_CARRY_QUE()
            End If

        Else
            '(親子じゃないの場合)

            If IsNotNull(objQueRelation(RelationArray.MAE_EVN)) Then
                objQueRelation(RelationArray.MAE_EVN).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.MAE_EVN).XPALLET_ID_AITE = Nothing
                objQueRelation(RelationArray.MAE_EVN).UPDATE_TPLN_CARRY_QUE()
            End If

            If IsNotNull(objQueRelation(RelationArray.MAE_ODD)) Then
                objQueRelation(RelationArray.MAE_ODD).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.MAE_ODD).XPALLET_ID_AITE = Nothing
                objQueRelation(RelationArray.MAE_ODD).UPDATE_TPLN_CARRY_QUE()
            End If

        End If


        '****************************************
        '奥棚判定
        '****************************************
        blnOyako = False
        If IsNotNull(objHikiateRelation(RelationArray.OKU_ODD)) And IsNotNull(objHikiateRelation(RelationArray.OKU_EVN)) Then
            '(両方とも、在庫引当情報が入っている場合)

            If objTrkRelation(RelationArray.OKU_ODD).FTR_TO = objTrkRelation(RelationArray.OKU_EVN).FTR_TO _
               And objHikiateRelation(RelationArray.OKU_ODD).FPLAN_KEY = objHikiateRelation(RelationArray.OKU_EVN).FPLAN_KEY _
               Then
                '(親子の場合)
                blnOyako = True
            End If

        End If


        '****************************************
        '奥棚更新
        '****************************************
        If blnOyako = True Then
            '(親子の場合)

            If IsNotNull(objQueRelation(RelationArray.OKU_EVN)) Then
                objQueRelation(RelationArray.OKU_EVN).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.OKU_EVN).XPALLET_ID_AITE = objQueRelation(RelationArray.OKU_ODD).FPALLET_ID
                objQueRelation(RelationArray.OKU_EVN).UPDATE_TPLN_CARRY_QUE()
            End If

            If IsNotNull(objQueRelation(RelationArray.OKU_ODD)) Then
                objQueRelation(RelationArray.OKU_ODD).XOYAKO_KUBUN = XOYAKO_KUBUN_JKO
                objQueRelation(RelationArray.OKU_ODD).XPALLET_ID_AITE = objQueRelation(RelationArray.OKU_EVN).FPALLET_ID
                objQueRelation(RelationArray.OKU_ODD).UPDATE_TPLN_CARRY_QUE()
            End If

        Else
            '(親子じゃないの場合)

            If IsNotNull(objQueRelation(RelationArray.OKU_EVN)) Then
                objQueRelation(RelationArray.OKU_EVN).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.OKU_EVN).XPALLET_ID_AITE = Nothing
                objQueRelation(RelationArray.OKU_EVN).UPDATE_TPLN_CARRY_QUE()
            End If

            If IsNotNull(objQueRelation(RelationArray.OKU_ODD)) Then
                objQueRelation(RelationArray.OKU_ODD).XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA
                objQueRelation(RelationArray.OKU_ODD).XPALLET_ID_AITE = Nothing
                objQueRelation(RelationArray.OKU_ODD).UPDATE_TPLN_CARRY_QUE()
            End If

        End If


        Return RetCode.OK
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
