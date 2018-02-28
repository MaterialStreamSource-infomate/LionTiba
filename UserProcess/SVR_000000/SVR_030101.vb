'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾎｽﾄ受信処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports System.IO
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_030101
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ｸﾗｽ変数定義                                                                          "
    Private mintReadCnt As Integer                      '読込件数
    Private mintExecCnt As Integer                      '処理件数

    '指示内容
    Private Structure DIR_MSG
        Dim STRDATA_KIND As String          'ﾃﾞｰﾀ種別
        Dim STREDIT_KBN As String           '編集区分
        Dim STRINPUT_PLACE As String        'ｲﾝﾌﾟｯﾄ場所
        Dim STRINPUT_DT As String           'ｲﾝﾌﾟｯﾄ日付
        Dim STRINPUT_NO As String           'ｲﾝﾌﾟｯﾄNo
        Dim STRBUNRUI_NO As String          '分類No
        Dim STRDENPYOU_NO As String         '伝票No
        Dim STRDATA_DT As String            'ﾃﾞｰﾀ日付
        Dim STRSYUKKA_D As String           '出荷日
        Dim STRHENSEI_NO As String          '編成No
        Dim STRSOUKO_CD As String           '倉庫ｺｰﾄﾞ
        Dim STRTOU_NO As String             '棟ｺｰﾄﾞ
        Dim STRTORIHIKI_KBN As String       '取引区分
        Dim STRDATA_SYORI As String         'ﾃﾞｰﾀ処理
        Dim STRGYOUSYA_CD As String         '物流業者ｺｰﾄﾞ
        Dim STRGYOUSYA_KBN As String        '業者区分
        Dim STRSYARYOU_NO As String         '車輌No
        Dim STRUNKOU_NO As String           '倉庫別運行No
        Dim STRTUMI_HOUKOU As String        '積付方向区分
        Dim STRTUMI_HOUHOU As String        '出荷区分
        Dim STRSYASYU_KBN As String         '車輌区分
        Dim STRHENSEI_NO_OYA As String      '親編成No
        Dim STRSEND_NAME As String          '届け先名称
        Dim STRSEND_ADDRESS As String       '届け先住所
        Dim STRHINMEI_CD() As String        '品名ｺｰﾄﾞ
        Dim STRSYUKKA_KON_PLAN() As String  '出荷梱数
        Dim STRSAIMOKU() As String          '取引区分細目
        Dim STRZAIKO_KBN() As String        '在庫区分
        Dim STRIDOU_KBN() As String         '移動区分
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>読込件数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property ReadCnt() As Integer
        Get
            Return mintReadCnt
        End Get
        Set(ByVal Value As Integer)
            mintReadCnt = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>処理件数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property ExecCnt() As Integer
        Get
            Return mintExecCnt
        End Get
        Set(ByVal Value As Integer)
            mintExecCnt = Value
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
#Region "  ﾒｲﾝ処理                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intOPEN_FLAG As Integer = FLAG_OFF  'ﾌｧｲﾙｵｰﾌﾟﾝﾌﾗｸﾞ
        Dim dtmACTION_DATE As Date = Now        '動作日時
        Dim ii As Integer                       'ｶｳﾝﾀ
        'Dim intRet As RetCode                   '戻り値
        Try
            '-------------------
            '出荷指示ﾌｧｲﾙの検知
            '-------------------
            If Dir(FILE_SYUKKA_PATH & FILE_SYUKKA_NAME) = "" Then
                '(見つからない場合)
                Return RetCode.OK
            End If


            Dim intFILE_NO As Integer = FreeFile()  'ﾌｧｲﾙ番号
            Try
                '-------------------
                '出荷指示ﾌｧｲﾙの読込
                '-------------------
                Dim strLINE_DATA(0) As String       '1行ﾃﾞｰﾀ(配列)
                Dim jj As Integer = 0               'ｶｳﾝﾀ
                FileOpen(intFILE_NO, FILE_SYUKKA_PATH & FILE_SYUKKA_NAME, OpenMode.Input)
                intOPEN_FLAG = FLAG_ON
                If EOF(intFILE_NO) = True Then
                    '(ﾌｧｲﾙ情報が見つからない場合)
                    FileClose(intFILE_NO)
                    intOPEN_FLAG = FLAG_OFF
                    Return RetCode.OK
                End If
                Do Until EOF(intFILE_NO)
                    '(ﾙｰﾌﾟ:ﾌｧｲﾙ情報が終端に達するまで)
                    Dim strTEMP As String
                    strTEMP = LineInput(intFILE_NO)
                    If GET_BYTE_LENGTH_STRING(strTEMP) <> FILE_DIR_SIZE Then
                        '(指示ﾃﾞｰﾀｻｲｽﾞが仕様と異なる場合)
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "[指示ﾃﾞｰﾀｻｲｽﾞ不正]")
                        Continue Do
                    End If
                    ReDim Preserve strLINE_DATA(jj)
                    strLINE_DATA(jj) = strTEMP
                    jj = jj + 1
                Loop
                FileClose(intFILE_NO)
                intOPEN_FLAG = FLAG_OFF


                For ii = LBound(strLINE_DATA) To UBound(strLINE_DATA)
                    '(ﾙｰﾌﾟ:指示数)

                    '-------------------
                    '指示分解
                    '-------------------
                    Dim udtDIR_MSG As New DIR_MSG   '指示内容
                    Try
                        If Trim(strLINE_DATA(ii)) <> "" Then
                            Call Div_Direction(udtDIR_MSG, strLINE_DATA(ii))
                        Else
                            Continue For
                        End If
                    Catch ex As Exception
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
                        Continue For
                    End Try


                    '-------------------
                    '棟ｺｰﾄﾞの判定
                    '-------------------
                    If TO_NUMBER(udtDIR_MSG.STRTOU_NO) = 1 Then
                        '-------------------
                        'ﾃﾞｰﾀ種類の判定
                        '-------------------
                        If TO_NUMBER(udtDIR_MSG.STRDATA_KIND) = 20 Then
                            ' '' ''-------------------
                            ' '' ''既存出荷指示の削除
                            ' '' ''-------------------
                            '' ''Call Delete_PLN_OUT(TO_DATE(udtDIR_MSG.STRSYUKKA_D), udtDIR_MSG.STRHENSEI_NO, udtDIR_MSG.STRDENPYOU_NO)


                            ' '' ''-----------------------
                            ' '' ''既存出荷指示詳細の削除
                            ' '' ''-----------------------
                            '' ''Call Delete_PLN_OUT_DTL(TO_DATE(udtDIR_MSG.STRSYUKKA_D), udtDIR_MSG.STRHENSEI_NO, udtDIR_MSG.STRDENPYOU_NO)

                            '取消処理は行わないように変更
                            Call AddToMsgLog(Now, FMSG_ID_J7001, "取消要求を受信しました。 ﾃﾞｰﾀ種類=[" & udtDIR_MSG.STRDATA_KIND & "]")
                            Return RetCode.NG
                        Else
                            '-------------------
                            '倉庫ｺｰﾄﾞの判定
                            '-------------------
                            If TO_NUMBER(udtDIR_MSG.STRSOUKO_CD) <> 482 And _
                               TO_NUMBER(udtDIR_MSG.STRSOUKO_CD) <> 488 Then
                                Call AddToMsgLog(Now, FMSG_ID_J7001, "異常ﾃﾞｰﾀ受信 倉庫ｺｰﾄﾞ=[" & udtDIR_MSG.STRSOUKO_CD & "]", _
                                                                     "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                     "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                     "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                                Return RetCode.NG
                            End If

                            '-------------------
                            '出荷指示の登録
                            '-------------------
                            Dim intRetPln As RetCode                                                '戻り値
                            Dim objPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)              '出荷指示ｸﾗｽ
                            objPLN_OUT.XSYUKKA_D = TO_DATE(udtDIR_MSG.STRSYUKKA_D)                  '出荷日
                            objPLN_OUT.XHENSEI_NO = udtDIR_MSG.STRHENSEI_NO                         '編成No.
                            objPLN_OUT.XDENPYOU_NO = udtDIR_MSG.STRDENPYOU_NO                       '伝票No.
                            intRetPln = objPLN_OUT.GET_XPLN_OUT(False)                              '既存ﾃﾞｰﾀ読込
                            If intRetPln = RetCode.NotFound Then
                                '(輸送手段ﾏｽﾀ)
                                Dim intRetCode_SYASYU As RetCode                                    '戻り値
                                Dim objMST_SYASYU As New TBL_XMST_SYASYU(Owner, ObjDb, ObjDbLog)    '輸送手段ﾏｽﾀｸﾗｽ
                                objMST_SYASYU.XSYASYU_KBN = udtDIR_MSG.STRSYASYU_KBN                '車種区分
                                intRetCode_SYASYU = objMST_SYASYU.GET_XMST_SYASYU(False)            '既存ﾃﾞｰﾀ読込
                                If intRetCode_SYASYU = RetCode.NotFound Then
                                    Call AddToMsgLog(Now, FMSG_ID_J7001, "輸送手段ﾏｽﾀ該当ﾃﾞｰﾀ無し 車種区分=[" & objMST_SYASYU.XSYASYU_KBN & "]", _
                                                                         "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                         "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                         "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                                    Return RetCode.NG
                                End If

                                '(業者ﾏｽﾀ)
                                Dim intRetCode_GYOUSYA As RetCode                                   '戻り値
                                Dim objMST_GYOUSYA As New TBL_XMST_GYOUSYA(Owner, ObjDb, ObjDbLog)  '業者ﾏｽﾀｸﾗｽ
                                objMST_GYOUSYA.XGYOUSYA_CD = udtDIR_MSG.STRGYOUSYA_CD               '物流業者ｺｰﾄﾞ
                                intRetCode_GYOUSYA = objMST_GYOUSYA.GET_XMST_GYOUSYA(False)         '既存ﾃﾞｰﾀ読込
                                If intRetCode_GYOUSYA = RetCode.NotFound Then
                                    Call AddToMsgLog(Now, FMSG_ID_J7001, "業者ﾏｽﾀ該当ﾃﾞｰﾀ無し 業者ｺｰﾄﾞ=[" & udtDIR_MSG.STRGYOUSYA_CD & "]", _
                                                                         "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                         "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                         "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                                    Return RetCode.NG
                                End If

                                '(車輌ﾏｽﾀ)
                                Dim intRetCode_SYARYOU As RetCode                                   '戻り値
                                Dim objMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)  '車輌ﾏｽﾀｸﾗｽ
                                objMST_SYARYOU.XSYARYOU_NO = TO_NUMBER(udtDIR_MSG.STRSYARYOU_NO)    '車輌番号
                                intRetCode_SYARYOU = objMST_SYARYOU.GET_XMST_SYARYOU(False)         '既存ﾃﾞｰﾀ読込
                                If intRetCode_SYARYOU = RetCode.NotFound Then
                                    '' ''Call AddToMsgLog(Now, FMSG_ID_J7001, "車輌ﾏｽﾀ該当ﾃﾞｰﾀ無し 車輌番号=[" & udtDIR_MSG.STRSYARYOU_NO & "]", _
                                    '' ''                                     "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                    '' ''                                     "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                    '' ''                                     "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                                End If

                                '(出荷指示)
                                objPLN_OUT.XDATA_KIND = udtDIR_MSG.STRDATA_KIND                     'ﾃﾞｰﾀ種類
                                objPLN_OUT.XEDIT_KBN = udtDIR_MSG.STREDIT_KBN                       '編集区分
                                objPLN_OUT.XINPUT_PLACE = udtDIR_MSG.STRINPUT_PLACE                 'ｲﾝﾌﾟｯﾄ場所
                                objPLN_OUT.XINPUT_DT = TO_DATE(udtDIR_MSG.STRINPUT_DT)              'ｲﾝﾌﾟｯﾄ日付
                                objPLN_OUT.XINPUT_NO = udtDIR_MSG.STRINPUT_NO                       'ｲﾝﾌﾟｯﾄNo.
                                objPLN_OUT.XBUNRUI_NO = udtDIR_MSG.STRBUNRUI_NO                     '分類No.
                                objPLN_OUT.XDATA_DT = TO_DATE(udtDIR_MSG.STRDATA_DT)                'ﾃﾞｰﾀ日付
                                objPLN_OUT.XSOUKO_CD = udtDIR_MSG.STRSOUKO_CD                       '倉庫ｺｰﾄﾞ
                                objPLN_OUT.XTOU_NO = udtDIR_MSG.STRTOU_NO                           '棟ｺｰﾄﾞ
                                objPLN_OUT.XTORIHIKI_KBN = udtDIR_MSG.STRTORIHIKI_KBN               '取引区分
                                objPLN_OUT.XDATA_SYORI = udtDIR_MSG.STRDATA_SYORI                   'ﾃﾞｰﾀ処理
                                objPLN_OUT.XGYOUSYA_CD = udtDIR_MSG.STRGYOUSYA_CD                   '物流業者ｺｰﾄﾞ
                                objPLN_OUT.XGYOUSYA_KBN = udtDIR_MSG.STRGYOUSYA_KBN                 '業者区分
                                objPLN_OUT.XSYARYOU_NO = TO_NUMBER(udtDIR_MSG.STRSYARYOU_NO)        '車輌番号
                                objPLN_OUT.XUNKOU_NO = udtDIR_MSG.STRUNKOU_NO                       '倉庫別運行No.
                                objPLN_OUT.XTUMI_HOUKOU = TO_NUMBER(udtDIR_MSG.STRTUMI_HOUKOU)      '積込方向
                                If udtDIR_MSG.STRTUMI_HOUHOU = "X" Then
                                    objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JL                       '積込方法((P)ﾊﾟﾚｯﾄ積)
                                Else
                                    If intRetCode_SYARYOU = RetCode.OK Then
                                        If objMST_SYARYOU.XTUMI_HOUHOU = XTUMI_HOUHOU_JL Then
                                            objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JP               '積込方法
                                        Else
                                            objPLN_OUT.XTUMI_HOUHOU = objMST_SYARYOU.XTUMI_HOUHOU   '積込方法
                                        End If
                                    Else
                                        objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JB                   '積込方法((B)ﾊﾞﾗ積)
                                    End If
                                End If
                                If objPLN_OUT.XTUMI_HOUHOU <> XTUMI_HOUHOU_JP And _
                                   objPLN_OUT.XTUMI_HOUHOU <> XTUMI_HOUHOU_JB And _
                                   objPLN_OUT.XTUMI_HOUHOU <> XTUMI_HOUHOU_JL Then
                                    objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JB                       '積込方法((B)ﾊﾞﾗ積)
                                End If
                                objPLN_OUT.XSYASYU_KBN = udtDIR_MSG.STRSYASYU_KBN                   '車種区分
                                objPLN_OUT.XHENSEI_NO_OYA = udtDIR_MSG.STRHENSEI_NO_OYA             '親編成No.
                                objPLN_OUT.XSEND_NAME = udtDIR_MSG.STRSEND_NAME                     '届け先名称
                                objPLN_OUT.XSEND_ADDRESS = udtDIR_MSG.STRSEND_ADDRESS               '届け先住所
                                objPLN_OUT.XBERTH_NO = DEFAULT_STRING                               'ﾊﾞｰｽNo.
                                objPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF                           '緊急出荷区分
                                objPLN_OUT.XKINKYU_LEVEL = 0                                        '緊急度
                                objPLN_OUT.XSYARYOU_ENTRY_DT = DEFAULT_DATE                         '車輌受付日時
                                objPLN_OUT.XSYUKKA_DIR_DT = DEFAULT_DATE                            '出荷指示日時
                                objPLN_OUT.XOUT_START_DT = DEFAULT_DATE                             '出庫開始日時
                                objPLN_OUT.XOUT_END_DT = DEFAULT_DATE                               '出庫完了日時
                                objPLN_OUT.XTUMI_END_DT = DEFAULT_DATE                              '積込完了日時
                                objPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JNON                           '出荷状況
                                objPLN_OUT.XIKKATU_SYUKKO = FLAG_OFF                                '一括出庫指定
                                objPLN_OUT.ADD_XPLN_OUT()
                            End If


                            '-------------------
                            '出荷指示詳細の登録
                            '-------------------
                            Dim kk As Integer
                            For kk = LBound(udtDIR_MSG.STRHINMEI_CD) To UBound(udtDIR_MSG.STRHINMEI_CD)

                                '(ﾙｰﾌﾟ:品名数)
                                If udtDIR_MSG.STRHINMEI_CD(kk) <> DEFAULT_STRING Then
                                    Dim intRetCode As RetCode                   '戻り値
                                    Dim objMST_HINMEI As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)      '品名ﾏｽﾀｸﾗｽ
                                    objMST_HINMEI.XHINMEI_CD = udtDIR_MSG.STRHINMEI_CD(kk)              '品名ｺｰﾄﾞ
                                    intRetCode = objMST_HINMEI.GET_TMST_ITEM(False)                     '特定
                                    If intRetCode = RetCode.NotFound Then
                                        Call AddToMsgLog(Now, FMSG_ID_J7001, "品名ﾏｽﾀ該当ﾃﾞｰﾀ無し 品名ｺｰﾄﾞ=[" & udtDIR_MSG.STRHINMEI_CD(kk) & "]", _
                                                                             "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                             "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                             "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                                        Return RetCode.NG
                                    Else
                                        '物流ｼｽﾃﾑ取扱い品目
                                        '↓↓↓↓↓↓************************************************************************************************************
                                        'JobMate:S.Ouchi 2013/10/30 取引区分細目142対応
                                        If TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) = 142 Then
                                            udtDIR_MSG.STRSAIMOKU(kk) = TO_STRING(XSAIMOKU_JHAISOU)
                                        End If
                                        'JobMate:S.Ouchi 2013/10/30 取引区分細目142対応
                                        '↑↑↑↑↑↑************************************************************************************************************

                                        '-------------------
                                        '取引区分細目の判定
                                        '-------------------
                                        If TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) <> XSAIMOKU_JISOU And _
                                           TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) <> XSAIMOKU_JIDOU And _
                                           TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) <> XSAIMOKU_JHOKYUU And _
                                           TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) <> XSAIMOKU_JTENSOU And _
                                           TO_NUMBER(udtDIR_MSG.STRSAIMOKU(kk)) <> XSAIMOKU_JHAISOU Then
                                            Call AddToMsgLog(Now, FMSG_ID_J7001, "異常ﾃﾞｰﾀ受信 取引区分細目=[" & udtDIR_MSG.STRSAIMOKU(kk) & "]", _
                                                                                 "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                                 "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                                 "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]", _
                                                                                 "品名ｺｰﾄﾞ=[" & udtDIR_MSG.STRHINMEI_CD(kk) & "]")
                                            Return RetCode.NG
                                        End If


                                        '↓↓↓↓↓↓************************************************************************************************************
                                        'JobMate:N.Dounoshita 2013/08/19 数量ﾁｪｯｸ


                                        If TO_NUMBER(udtDIR_MSG.STRSYUKKA_KON_PLAN(kk)) <= 0 Then
                                            '(数量ﾁｪｯｸ)

                                            Call AddToMsgLog(Now, FMSG_ID_J7001, "異常ﾃﾞｰﾀ受信 出荷予定梱数=[" & udtDIR_MSG.STRSYUKKA_KON_PLAN(kk) & "]", _
                                                                                 "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                                                 "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                                                 "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]", _
                                                                                 "品名ｺｰﾄﾞ=[" & udtDIR_MSG.STRHINMEI_CD(kk) & "]")
                                            '↓↓↓↓↓↓************************************************************************************************************
                                            'JobMate:S.Ouchi 2013/10/30 出荷予定数0対応
                                            '' ''Return RetCode.NG
                                            'JobMate:S.Ouchi 2013/10/30 出荷予定数0対応
                                            '↑↑↑↑↑↑************************************************************************************************************
                                        End If


                                        '↑↑↑↑↑↑************************************************************************************************************


                                        '(品名ｺｰﾄﾞが存在する場合)
                                        Dim intRet As RetCode                                                   '戻り値
                                        Dim objPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)      '出荷指示詳細ｸﾗｽ
                                        objPLN_OUT_DTL.XSYUKKA_D = TO_DATE(udtDIR_MSG.STRSYUKKA_D)              '出荷日
                                        objPLN_OUT_DTL.XHENSEI_NO = udtDIR_MSG.STRHENSEI_NO                     '編成No.
                                        objPLN_OUT_DTL.XDENPYOU_NO = udtDIR_MSG.STRDENPYOU_NO                   '伝票No.
                                        objPLN_OUT_DTL.FHINMEI_CD = objMST_HINMEI.FHINMEI_CD                    '品目ｺｰﾄﾞ
                                        intRet = objPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)                         '既存ﾃﾞｰﾀ読込
                                        If intRet = RetCode.NotFound Then
                                            '(既存ﾃﾞｰﾀ無し)
                                            If objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JL Then
                                                objPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J57                  '作業種別(ﾛｰﾀﾞ出庫)
                                            ElseIf objPLN_OUT.XTUMI_HOUHOU = XTUMI_HOUHOU_JP Then
                                                objPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J55                  '作業種別(ﾊﾟﾚｯﾄ出庫)
                                            Else
                                                objPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_J56                  '作業種別(ﾊﾞﾗ出庫)
                                            End If
                                            objPLN_OUT_DTL.FPLAN_KEY = Format(TO_DATE(udtDIR_MSG.STRSYUKKA_D), "yyyyMMdd") & _
                                                                       udtDIR_MSG.STRHENSEI_NO & _
                                                                       udtDIR_MSG.STRDENPYOU_NO & _
                                                                       udtDIR_MSG.STRHINMEI_CD(kk)              '計画ｷｰ
                                            objPLN_OUT_DTL.XOUT_ORDER = DEFAULT_INTEGER                         '車輌内出荷品目順
                                            objPLN_OUT_DTL.XSYUKKA_KON_PLAN = TO_NUMBER(udtDIR_MSG.STRSYUKKA_KON_PLAN(kk))  '出荷予定梱数
                                            objPLN_OUT_DTL.XSYUKKA_KON_RESERVE = 0                              '出荷引当梱数
                                            objPLN_OUT_DTL.XSYUKKA_KON_RESULT = 0                               '出荷実績梱数
                                            objPLN_OUT_DTL.XSYUKKA_KON_H_RESULT = 0                             '出荷実績梱数(平置)
                                            objPLN_OUT_DTL.XSAIMOKU = udtDIR_MSG.STRSAIMOKU(kk)                 '取引区分細目
                                            objPLN_OUT_DTL.FZAIKO_KUBUN = udtDIR_MSG.STRZAIKO_KBN(kk)           '在庫区分
                                            objPLN_OUT_DTL.XIDOU_KBN = udtDIR_MSG.STRIDOU_KBN(kk)               '移動区分
                                            objPLN_OUT_DTL.XHENSEI_NO_OYA = udtDIR_MSG.STRHENSEI_NO_OYA         '親編成No.
                                            objPLN_OUT_DTL.XTORIKIRI = FLAG_OFF                                 '取り切り指定
                                            objPLN_OUT_DTL.XOUT_START_DT = DEFAULT_DATE                         '出庫開始日時
                                            objPLN_OUT_DTL.XOUT_END_DT = DEFAULT_DATE                           '出庫完了日時
                                            objPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JNON               '出荷状況詳細
                                            objPLN_OUT_DTL.ADD_XPLN_OUT_DTL()
                                        Else
                                            objPLN_OUT_DTL.XSYUKKA_KON_PLAN += TO_NUMBER(udtDIR_MSG.STRSYUKKA_KON_PLAN(kk)) '出荷予定梱数
                                            objPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                                '更新
                                        End If

                                    End If
                                End If

                            Next


                            '----------------------
                            '車輌内出荷品目順更新
                            '----------------------
                            Call Update_OUT_ORDER(udtDIR_MSG.STRSYUKKA_D, udtDIR_MSG.STRHENSEI_NO_OYA)

                        End If
                    Else
                        Call AddToMsgLog(Now, FMSG_ID_J7001, "異常ﾃﾞｰﾀ受信 棟ｺｰﾄﾞ=[" & udtDIR_MSG.STRTOU_NO & "]", _
                                                             "出荷日=[" & udtDIR_MSG.STRSYUKKA_D & _
                                                             "] 編成№=[" & udtDIR_MSG.STRHENSEI_NO & _
                                                             "] 伝票№=[" & udtDIR_MSG.STRDENPYOU_NO & "]")
                        Return RetCode.NG
                    End If
                Next


                '-------------------
                '正常完了
                '-------------------
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_NORMAL)
                Return RetCode.OK

            Catch ex As Exception
                '--------------------
                '異常処理
                '--------------------
                Call ComError(ex, MeSyoriID)
                Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")

            Finally
                '-------------------
                'ﾌｧｲﾙのｸﾛｰｽﾞ
                '-------------------
                If intOPEN_FLAG = FLAG_ON Then
                    '(ﾌｧｲﾙが閉じられていない場合)
                    FileClose(intFILE_NO)
                    intOPEN_FLAG = FLAG_OFF
                End If

                '-------------------
                '出荷指示ﾌｧｲﾙの退避
                '-------------------
                'Rename(FILE_SYUKKA_PATH & FILE_SYUKKA_NAME, FILE_BACKUP_PATH & Format(Now, "yyyyMMddHHmmss") & FILE_SYUKKA_NAME)
                File.Move(FILE_SYUKKA_PATH & FILE_SYUKKA_NAME, FILE_BACKUP_PATH & Format(Now, "yyyyMMddHHmmss") & "_" & FILE_SYUKKA_NAME)
            End Try


        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  指示分解                 (Private Div_Direction)"
    '==============================================================================================
    '【機能】指示分解
    '【引数】[OUT] udtDIR_MSG       :分割先構造体
    '        [IN ] strMSG_RECV      :受信電文
    '【戻値】無し
    '==============================================================================================
    Private Sub Div_Direction(ByRef udtDIR_MSG As DIR_MSG, _
                              ByVal strMSG_RECV As String)
        Try
            Dim strMsg As String        'ﾒｯｾｰｼﾞ


            '-----------------
            '指示内容→構造体
            '-----------------
            ReDim Preserve udtDIR_MSG.STRHINMEI_CD(7)
            ReDim Preserve udtDIR_MSG.STRSYUKKA_KON_PLAN(7)
            ReDim Preserve udtDIR_MSG.STRSAIMOKU(7)
            ReDim Preserve udtDIR_MSG.STRZAIKO_KBN(7)
            ReDim Preserve udtDIR_MSG.STRIDOU_KBN(7)
            udtDIR_MSG.STRDATA_KIND = Trim(MID_SJIS(strMSG_RECV, 1, 2))             'ﾃﾞｰﾀ種別
            udtDIR_MSG.STREDIT_KBN = Trim(MID_SJIS(strMSG_RECV, 3, 2))              '編集区分
            udtDIR_MSG.STRINPUT_PLACE = Trim(MID_SJIS(strMSG_RECV, 5, 3))           'ｲﾝﾌﾟｯﾄ場所
            udtDIR_MSG.STRINPUT_DT = Trim(MID_SJIS(strMSG_RECV, 8, 6))              'ｲﾝﾌﾟｯﾄ日付
            udtDIR_MSG.STRINPUT_NO = Trim(MID_SJIS(strMSG_RECV, 14, 5))             'ｲﾝﾌﾟｯﾄNo
            udtDIR_MSG.STRBUNRUI_NO = Trim(MID_SJIS(strMSG_RECV, 19, 2))            '分類No
            udtDIR_MSG.STRDENPYOU_NO = Trim(MID_SJIS(strMSG_RECV, 21, 7))           '伝票No
            udtDIR_MSG.STRDATA_DT = Trim(MID_SJIS(strMSG_RECV, 28, 6))              'ﾃﾞｰﾀ日付
            udtDIR_MSG.STRSYUKKA_D = Trim(MID_SJIS(strMSG_RECV, 34, 6))             '出荷日
            udtDIR_MSG.STRHENSEI_NO = Trim(MID_SJIS(strMSG_RECV, 40, 4))            '編成No
            udtDIR_MSG.STRSOUKO_CD = Trim(MID_SJIS(strMSG_RECV, 44, 3))             '倉庫ｺｰﾄﾞ
            udtDIR_MSG.STRTOU_NO = Trim(MID_SJIS(strMSG_RECV, 47, 2))               '棟ｺｰﾄﾞ
            udtDIR_MSG.STRTORIHIKI_KBN = Trim(MID_SJIS(strMSG_RECV, 49, 2))         '取引区分
            udtDIR_MSG.STRDATA_SYORI = Trim(MID_SJIS(strMSG_RECV, 51, 2))           'ﾃﾞｰﾀ処理
            udtDIR_MSG.STRGYOUSYA_CD = Trim(MID_SJIS(strMSG_RECV, 55, 4))           '物流業者ｺｰﾄﾞ
            udtDIR_MSG.STRGYOUSYA_KBN = ""          '業者区分
            udtDIR_MSG.STRSYARYOU_NO = Trim(MID_SJIS(strMSG_RECV, 59, 4))           '車輌No
            udtDIR_MSG.STRUNKOU_NO = Trim(MID_SJIS(strMSG_RECV, 63, 2))             '倉庫別運行No
            udtDIR_MSG.STRTUMI_HOUKOU = ""          '積付方向区分
            udtDIR_MSG.STRTUMI_HOUHOU = Trim(MID_SJIS(strMSG_RECV, 65, 1))          '出荷区分
            udtDIR_MSG.STRSYASYU_KBN = Trim(MID_SJIS(strMSG_RECV, 53, 2))           '車輌区分
            udtDIR_MSG.STRHENSEI_NO_OYA = ""       '親編成No
            udtDIR_MSG.STRSEND_NAME = Trim(MID_SJIS(strMSG_RECV, 66, 35))           '届け先名称
            udtDIR_MSG.STRSEND_ADDRESS = Trim(MID_SJIS(strMSG_RECV, 101, 34))       '届け先住所
            udtDIR_MSG.STRHINMEI_CD(0) = Trim(MID_SJIS(strMSG_RECV, 135, 6))        '品名ｺｰﾄﾞ1
            udtDIR_MSG.STRSYUKKA_KON_PLAN(0) = Trim(MID_SJIS(strMSG_RECV, 141, 4))  '出荷梱数1
            udtDIR_MSG.STRSAIMOKU(0) = Trim(MID_SJIS(strMSG_RECV, 145, 3))          '取引区分細目1
            udtDIR_MSG.STRZAIKO_KBN(0) = Trim(MID_SJIS(strMSG_RECV, 148, 1))        '在庫区分1
            udtDIR_MSG.STRIDOU_KBN(0) = Trim(MID_SJIS(strMSG_RECV, 149, 1))         '移動区分1
            udtDIR_MSG.STRHINMEI_CD(1) = Trim(MID_SJIS(strMSG_RECV, 150, 6))        '品名ｺｰﾄﾞ2
            udtDIR_MSG.STRSYUKKA_KON_PLAN(1) = Trim(MID_SJIS(strMSG_RECV, 156, 4))  '出荷梱数2
            udtDIR_MSG.STRSAIMOKU(1) = Trim(MID_SJIS(strMSG_RECV, 160, 3))          '取引区分細目2
            udtDIR_MSG.STRZAIKO_KBN(1) = Trim(MID_SJIS(strMSG_RECV, 163, 1))        '在庫区分2
            udtDIR_MSG.STRIDOU_KBN(1) = Trim(MID_SJIS(strMSG_RECV, 164, 1))         '移動区分2
            udtDIR_MSG.STRHINMEI_CD(2) = Trim(MID_SJIS(strMSG_RECV, 165, 6))        '品名ｺｰﾄﾞ3
            udtDIR_MSG.STRSYUKKA_KON_PLAN(2) = Trim(MID_SJIS(strMSG_RECV, 171, 4))  '出荷梱数3
            udtDIR_MSG.STRSAIMOKU(2) = Trim(MID_SJIS(strMSG_RECV, 175, 3))          '取引区分細目3
            udtDIR_MSG.STRZAIKO_KBN(2) = Trim(MID_SJIS(strMSG_RECV, 178, 1))        '在庫区分3
            udtDIR_MSG.STRIDOU_KBN(2) = Trim(MID_SJIS(strMSG_RECV, 179, 1))         '移動区分3
            udtDIR_MSG.STRHINMEI_CD(3) = Trim(MID_SJIS(strMSG_RECV, 180, 6))        '品名ｺｰﾄﾞ4
            udtDIR_MSG.STRSYUKKA_KON_PLAN(3) = Trim(MID_SJIS(strMSG_RECV, 186, 4))  '出荷梱数4
            udtDIR_MSG.STRSAIMOKU(3) = Trim(MID_SJIS(strMSG_RECV, 190, 3))          '取引区分細目4
            udtDIR_MSG.STRZAIKO_KBN(3) = Trim(MID_SJIS(strMSG_RECV, 193, 1))        '在庫区分4
            udtDIR_MSG.STRIDOU_KBN(3) = Trim(MID_SJIS(strMSG_RECV, 194, 1))         '移動区分4
            udtDIR_MSG.STRHINMEI_CD(4) = Trim(MID_SJIS(strMSG_RECV, 195, 6))        '品名ｺｰﾄﾞ5
            udtDIR_MSG.STRSYUKKA_KON_PLAN(4) = Trim(MID_SJIS(strMSG_RECV, 201, 4))  '出荷梱数5
            udtDIR_MSG.STRSAIMOKU(4) = Trim(MID_SJIS(strMSG_RECV, 205, 3))          '取引区分細目5
            udtDIR_MSG.STRZAIKO_KBN(4) = Trim(MID_SJIS(strMSG_RECV, 208, 1))        '在庫区分5
            udtDIR_MSG.STRIDOU_KBN(4) = Trim(MID_SJIS(strMSG_RECV, 209, 1))         '移動区分5
            udtDIR_MSG.STRHINMEI_CD(5) = Trim(MID_SJIS(strMSG_RECV, 210, 6))        '品名ｺｰﾄﾞ6
            udtDIR_MSG.STRSYUKKA_KON_PLAN(5) = Trim(MID_SJIS(strMSG_RECV, 216, 4))  '出荷梱数6
            udtDIR_MSG.STRSAIMOKU(5) = Trim(MID_SJIS(strMSG_RECV, 220, 3))          '取引区分細目6
            udtDIR_MSG.STRZAIKO_KBN(5) = Trim(MID_SJIS(strMSG_RECV, 223, 1))        '在庫区分6
            udtDIR_MSG.STRIDOU_KBN(5) = Trim(MID_SJIS(strMSG_RECV, 224, 1))         '移動区分6
            udtDIR_MSG.STRHINMEI_CD(6) = Trim(MID_SJIS(strMSG_RECV, 225, 6))        '品名ｺｰﾄﾞ7
            udtDIR_MSG.STRSYUKKA_KON_PLAN(6) = Trim(MID_SJIS(strMSG_RECV, 231, 4))  '出荷梱数7
            udtDIR_MSG.STRSAIMOKU(6) = Trim(MID_SJIS(strMSG_RECV, 235, 3))          '取引区分細目7
            udtDIR_MSG.STRZAIKO_KBN(6) = Trim(MID_SJIS(strMSG_RECV, 238, 1))        '在庫区分7
            udtDIR_MSG.STRIDOU_KBN(6) = Trim(MID_SJIS(strMSG_RECV, 239, 1))         '移動区分7
            udtDIR_MSG.STRHINMEI_CD(7) = Trim(MID_SJIS(strMSG_RECV, 240, 6))        '品名ｺｰﾄﾞ8
            udtDIR_MSG.STRSYUKKA_KON_PLAN(7) = Trim(MID_SJIS(strMSG_RECV, 246, 4))  '出荷梱数8
            udtDIR_MSG.STRSAIMOKU(7) = Trim(MID_SJIS(strMSG_RECV, 250, 3))          '取引区分細目8
            udtDIR_MSG.STRZAIKO_KBN(7) = Trim(MID_SJIS(strMSG_RECV, 253, 1))        '在庫区分8
            udtDIR_MSG.STRIDOU_KBN(7) = Trim(MID_SJIS(strMSG_RECV, 254, 1))         '移動区分8


            '-----------------
            '値漏れﾁｪｯｸ
            '-----------------
            If udtDIR_MSG.STRDATA_KIND = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ﾃﾞｰﾀ種別]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STREDIT_KBN = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[編集区分]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRINPUT_PLACE = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ｲﾝﾌﾟｯﾄ場所]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRINPUT_DT = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ｲﾝﾌﾟｯﾄ日付]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRINPUT_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ｲﾝﾌﾟｯﾄ場所No]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRBUNRUI_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[分類No]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRDENPYOU_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[伝票No]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRDATA_DT = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ﾃﾞｰﾀ日付]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRSYUKKA_D = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[出荷日]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRHENSEI_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[編成No]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRSOUKO_CD = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[倉庫ｺｰﾄﾞ]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRTOU_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[棟ｺｰﾄﾞ]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRTORIHIKI_KBN = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[取引区分]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRDATA_SYORI = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[ﾃﾞｰﾀ処理]"
                Throw New System.Exception(strMsg)
            ElseIf udtDIR_MSG.STRGYOUSYA_CD = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_REQ_OUT & "[物流業者ｺｰﾄﾞ]"
                Throw New System.Exception(strMsg)
            End If


            udtDIR_MSG.STRINPUT_DT = Format(TO_DATE(Mid(udtDIR_MSG.STRINPUT_DT, 1, 2) & "/" & Mid(udtDIR_MSG.STRINPUT_DT, 3, 2) & "/" & Mid(udtDIR_MSG.STRINPUT_DT, 5, 2)), "yyyy/MM/dd")
            udtDIR_MSG.STRDATA_DT = Format(TO_DATE(Mid(udtDIR_MSG.STRDATA_DT, 1, 2) & "/" & Mid(udtDIR_MSG.STRDATA_DT, 3, 2) & "/" & Mid(udtDIR_MSG.STRDATA_DT, 5, 2)), "yyyy/MM/dd")
            udtDIR_MSG.STRSYUKKA_D = Format(TO_DATE(Mid(udtDIR_MSG.STRSYUKKA_D, 1, 2) & "/" & Mid(udtDIR_MSG.STRSYUKKA_D, 3, 2) & "/" & Mid(udtDIR_MSG.STRSYUKKA_D, 5, 2)), "yyyy/MM/dd")

            '親編成No
            If udtDIR_MSG.STRHENSEI_NO_OYA Is Nothing Then
                udtDIR_MSG.STRHENSEI_NO_OYA = udtDIR_MSG.STRHENSEI_NO
            ElseIf Trim(udtDIR_MSG.STRHENSEI_NO_OYA) = "" Then
                udtDIR_MSG.STRHENSEI_NO_OYA = udtDIR_MSG.STRHENSEI_NO
            End If

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "  既存出荷指示削除         (Private Delete_PLN_OUT)"
    '==============================================================================================
    '【機能】既存出荷指示削除
    '【引数】[IN ] dtmSYUKKA_D       :出荷日
    '        [IN ] strHENSEI_NO      :編成No
    '        [IN ] strDENPYOU_NO     :伝票No
    '【戻値】無し
    '==============================================================================================
    Private Sub Delete_PLN_OUT(ByVal dtmSYUKKA_D As Date, ByVal strHENSEI_NO As String, ByVal strDENPYOU_NO As String)
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '-----------------------
            '削除SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"  '出荷日
            strSQL &= vbCrLf & "    AND XHENSEI_NO = '" & strHENSEI_NO & "'"        '編成No
            strSQL &= vbCrLf & "    AND XDENPYOU_NO = '" & strDENPYOU_NO & "'"      '伝票No
            strSQL &= vbCrLf


            '-----------------
            '削除
            '-----------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_DELETE & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "  既存出荷指示詳細削除     (Private Delete_PLN_OUT_DTL)"
    '==============================================================================================
    '【機能】既存出荷指示詳細削除
    '【引数】[IN ] dtmSYUKKA_D       :出荷日
    '        [IN ] strHENSEI_NO      :編成No
    '        [IN ] strDENPYOU_NO     :伝票No
    '【戻値】無し
    '==============================================================================================
    Private Sub Delete_PLN_OUT_DTL(ByVal dtmSYUKKA_D As Date, ByVal strHENSEI_NO As String, ByVal strDENPYOU_NO As String)
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '-----------------------
            '削除SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"  '出荷日
            strSQL &= vbCrLf & "    AND XHENSEI_NO = '" & strHENSEI_NO & "'"        '編成No
            strSQL &= vbCrLf & "    AND XDENPYOU_NO = '" & strDENPYOU_NO & "'"      '伝票No
            strSQL &= vbCrLf


            '-----------------
            '削除
            '-----------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_DELETE & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "  車輌内出荷品目順更新     (Private Update_OUT_ORDER)"
    '==============================================================================================
    '【機能】車輌内出荷品目順更新
    '【引数】[IN ] dtmSYUKKA_D          :出荷日
    '        [IN ] strHENSEI_NO_OYA     :親編成No
    '【戻値】無し
    '==============================================================================================
    Private Sub Update_OUT_ORDER(ByVal dtmSYUKKA_D As Date, ByVal strHENSEI_NO_OYA As String)
        Try
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim ii As Integer                   'ｶｳﾝﾀ
            Dim intRet As RetCode               '戻り値
            Dim strMsg As String                'ﾒｯｾｰｼﾞ


            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"       '出荷指示詳細
            strSQL &= vbCrLf & "   ,TMST_ITEM"          '品名ﾏｽﾀ
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        XPLN_OUT_DTL.XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')" '出荷日
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & TO_STRING(strHENSEI_NO_OYA) & "'"    '親編成No
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD"                         '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TMST_ITEM.XHEIGHT_IN_PALLET DESC"   '荷高
            strSQL &= vbCrLf & "   ,TMST_ITEM.XHINMEI_CD"               '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "   ,XPLN_OUT_DTL.XHENSEI_NO"        '編成No
            strSQL &= vbCrLf & "   ,XPLN_OUT_DTL.XDENPYOU_NO"       '伝票No
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "PLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)


                    '-----------------------
                    '出荷指示詳細の特定
                    '-----------------------
                    Dim objPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)  '出荷指示詳細ｸﾗｽ
                    objPLN_OUT_DTL.XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))             '出荷日
                    objPLN_OUT_DTL.XHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))         '編成No.
                    objPLN_OUT_DTL.XDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))       '伝票No.
                    objPLN_OUT_DTL.FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))         '品目ｺｰﾄﾞ
                    intRet = objPLN_OUT_DTL.GET_XPLN_OUT_DTL()                          '既存データ読込
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_PLN_OUT_DTL & "[出荷日:" & objPLN_OUT_DTL.XSYUKKA_D & _
                                                               "  ,編成No:" & objPLN_OUT_DTL.XHENSEI_NO & _
                                                               "  ,伝票No:" & objPLN_OUT_DTL.XDENPYOU_NO & _
                                                               "  ,品名ｺｰﾄﾞ:" & objPLN_OUT_DTL.FHINMEI_CD & "]"
                        Throw New System.Exception(strMsg)
                    End If


                    '-----------------------
                    '出荷指示詳細の更新
                    '-----------------------
                    objPLN_OUT_DTL.XOUT_ORDER = ii + 1      '車輌内出荷品目順
                    objPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()    '更新

                Next
            End If


        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
