'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷指示更新処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_400101
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0                 '端末ID
    Private Const DSPUSER_ID As Integer = 1                 'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2                  '理由
    Private Const DSPDIR_KUBUN As Integer = 3               '処理区分
    Private Const XDSPDATA_KIND As Integer = 4              'ﾃﾞｰﾀ種類
    Private Const XDSPEDIT_KBN As Integer = 5               '編集区分
    Private Const XDSPINPUT_PLACE As Integer = 6            'ｲﾝﾌﾟｯﾄ場所
    Private Const XDSPINPUT_DT As Integer = 7               'ｲﾝﾌﾟｯﾄ日付
    Private Const XDSPINPUT_NO As Integer = 8               'ｲﾝﾌﾟｯﾄNo.
    Private Const XDSPBUNRUI_NO As Integer = 9              '分類№
    Private Const XDSPDENPYOU_NO As Integer = 10            '伝票№
    Private Const XDSPDATA_DT As Integer = 11               'ﾃﾞｰﾀ日付
    Private Const XDSPSYUKKA_D As Integer = 12              '出荷日
    Private Const XDSPHENSEI_NO As Integer = 13             '編成№
    Private Const XDSPSOUKO_CD As Integer = 14              '倉庫ｺｰﾄﾞ
    Private Const XDSPTOU_NO As Integer = 15                '棟ｺｰﾄﾞ
    Private Const XDSPTORIHIKI_KBN As Integer = 16          '取引区分
    Private Const XDSPDATA_SYORI As Integer = 17            'ﾃﾞｰﾀ処理
    Private Const XDSPSYASYU_KBN As Integer = 18            '車種区分
    Private Const XDSPGYOUSYA_CD As Integer = 19            '物流業者ｺｰﾄﾞ
    Private Const XDSPSYARYOU_NO As Integer = 20            '車輌番号
    Private Const XDSPUNKOU_NO As Integer = 21              '倉庫別運行No.
    Private Const XDSPTUMI_HOUHOU As Integer = 22           '積込方法
    Private Const XDSPSEND_NAME As Integer = 23             '届け先名称
    Private Const XDSPSEND_ADDRESS As Integer = 24          '届け先住所
    Private Const XDSPHENSEI_NO_OYA As Integer = 25         '親編成№
    Private Const XDSPBERTH_NO As Integer = 26              'ﾊﾞｰｽ№
    Private Const XDSPKINKYU_KBN As Integer = 27            '緊急出荷区分
    Private Const XDSPKINKYU_LEVEL As Integer = 28          '緊急度
    Private Const XDSPTUMI_HOUKOU As Integer = 29           '積込方向
    Private Const XDSPHINMEI_CD01 As Integer = 30           '品目ｺｰﾄﾞ01
    Private Const XDSPSYUKKA_KON_PLAN01 As Integer = 31     '出荷予定梱数01
    Private Const XDSPSAIMOKU01 As Integer = 32             '取引区分細目01
    Private Const DSPZAIKO_KUBUN01 As Integer = 33          '在庫区分01
    Private Const XDSPIDOU_KBN01 As Integer = 34            '移動区分01
    Private Const XDSPHINMEI_CD02 As Integer = 35           '品目ｺｰﾄﾞ02
    Private Const XDSPSYUKKA_KON_PLAN02 As Integer = 36     '出荷予定梱数02
    Private Const XDSPSAIMOKU02 As Integer = 37             '取引区分細目02
    Private Const DSPZAIKO_KUBUN02 As Integer = 38          '在庫区分02
    Private Const XDSPIDOU_KBN02 As Integer = 39            '移動区分02
    Private Const XDSPHINMEI_CD03 As Integer = 40           '品目ｺｰﾄﾞ03
    Private Const XDSPSYUKKA_KON_PLAN03 As Integer = 41     '出荷予定梱数03
    Private Const XDSPSAIMOKU03 As Integer = 42             '取引区分細目03
    Private Const DSPZAIKO_KUBUN03 As Integer = 43          '在庫区分03
    Private Const XDSPIDOU_KBN03 As Integer = 44            '移動区分03
    Private Const XDSPHINMEI_CD04 As Integer = 45           '品目ｺｰﾄﾞ04
    Private Const XDSPSYUKKA_KON_PLAN04 As Integer = 46     '出荷予定梱数04
    Private Const XDSPSAIMOKU04 As Integer = 47             '取引区分細目04
    Private Const DSPZAIKO_KUBUN04 As Integer = 48          '在庫区分04
    Private Const XDSPIDOU_KBN04 As Integer = 49            '移動区分04
    Private Const XDSPHINMEI_CD05 As Integer = 50           '品目ｺｰﾄﾞ05
    Private Const XDSPSYUKKA_KON_PLAN05 As Integer = 51     '出荷予定梱数05
    Private Const XDSPSAIMOKU05 As Integer = 52             '取引区分細目05
    Private Const DSPZAIKO_KUBUN05 As Integer = 53          '在庫区分05
    Private Const XDSPIDOU_KBN05 As Integer = 54            '移動区分05
    Private Const XDSPHINMEI_CD06 As Integer = 55           '品目ｺｰﾄﾞ06
    Private Const XDSPSYUKKA_KON_PLAN06 As Integer = 56     '出荷予定梱数06
    Private Const XDSPSAIMOKU06 As Integer = 57             '取引区分細目06
    Private Const DSPZAIKO_KUBUN06 As Integer = 58          '在庫区分06
    Private Const XDSPIDOU_KBN06 As Integer = 59            '移動区分06
    Private Const XDSPHINMEI_CD07 As Integer = 60           '品目ｺｰﾄﾞ07
    Private Const XDSPSYUKKA_KON_PLAN07 As Integer = 61     '出荷予定梱数07
    Private Const XDSPSAIMOKU07 As Integer = 62             '取引区分細目07
    Private Const DSPZAIKO_KUBUN07 As Integer = 63          '在庫区分07
    Private Const XDSPIDOU_KBN07 As Integer = 64            '移動区分07
    Private Const XDSPHINMEI_CD08 As Integer = 65           '品目ｺｰﾄﾞ08
    Private Const XDSPSYUKKA_KON_PLAN08 As Integer = 66     '出荷予定梱数08
    Private Const XDSPSAIMOKU08 As Integer = 67             '取引区分細目08
    Private Const DSPZAIKO_KUBUN08 As Integer = 68          '在庫区分08
    Private Const XDSPIDOU_KBN08 As Integer = 69            '移動区分08


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
        Dim objTelegramSend As New clsTelegram(CONFIG_TELEGRAM_DSP) '送信用電文
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP) '受信用電文
        Dim strDenbunDtl(0) As String         '電文分解配列
        Dim strDenbunDtlName(0) As String     '電文分解名称配列
        Dim strDenbunInfo As String = ""      '電文ﾊﾟﾗﾒｰﾀﾛｸﾞ用文字列
        '' ''Dim intRet As Integer                 '戻り値
        '' ''Dim strMsg As String                  'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call DivDenbun(strDenbunDtl, strDenbunDtlName, strMSG_RECV, strMSG_SEND, objTelegramRecv, objTelegramSend)
            Call MakeLogDataDenbun(strDenbunDtl, strDenbunDtlName, strDenbunInfo)
            Call AddToTrnLog(strDenbunDtl(DSPUSER_ID), strDenbunDtl(DSPTERM_ID), MeSyoriID, FLOG_DATA_TRN_SSTART & strDenbunInfo)
            Call CheckBeforeAct(strDenbunDtl)


            '************************
            '出荷指示
            '************************
            Select Case strDenbunDtl(DSPDIR_KUBUN)
                Case FORMAT_DSP_DSPDIR_KUBUN_INSERT
                    '(追加)
                    Call Mente_ADD(strDenbunDtl)

                Case FORMAT_DSP_DSPDIR_KUBUN_UPDATE
                    '(更新)
                    Call Mente_UPDATE(strDenbunDtl)

                Case FORMAT_DSP_DSPDIR_KUBUN_DELETE
                    '(削除)
                    Call Mente_DELETE(strDenbunDtl)

            End Select



            '************************
            '正常完了
            '************************
            Call MakeMessageGamenOK(objTelegramSend, strMSG_SEND)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_NORMAL)
            Return RetCode.OK


        Catch ex As UserException
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ex.Message)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call MakeMessageGamenNG(objTelegramSend, strMSG_SEND, ERRMSG_DISP_ERR)
            Call AddToOpeLog(strDenbunDtl, strDenbunDtlName, MeSyoriID, FLOG_DATA_OPE_SEND_ERR & "  [" & ex.Message & "]")
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function

#End Region
#Region "  事前ﾁｪｯｸ                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 事前ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文内容構造体</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub CheckBeforeAct(ByVal strDenbunDtl() As String)
        Try
            'Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '************************
            '値漏れﾁｪｯｸ
            '************************
            If 1 = 1 Then
            ElseIf strDenbunDtl(DSPTERM_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[端末ID]"
                Throw New UserException(strMsg)
            ElseIf strDenbunDtl(DSPUSER_ID) = DEFAULT_STRING Then
                strMsg = ERRMSG_DISP_SOCKET & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

#Region "  追加ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 追加ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_ADD(ByVal strDenbunDtl() As String)
        Try
            Dim intRet As RetCode                 '戻り値
            Dim strMsg As String                  'ﾒｯｾｰｼﾞ

            '-------------------
            '出荷指示の登録
            '-------------------
            Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)                         '出荷指示ｸﾗｽ
            objXPLN_OUT.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))                         '出荷日
            objXPLN_OUT.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                                '編成No
            objXPLN_OUT.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)                              '伝票No
            objXPLN_OUT.XBUNRUI_NO = strDenbunDtl(XDSPBUNRUI_NO)                                '分類No
            objXPLN_OUT.XGYOUSYA_CD = strDenbunDtl(XDSPGYOUSYA_CD)                              '物流業者ｺｰﾄﾞ
            objXPLN_OUT.XSYARYOU_NO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSYARYOU_NO))         '車輌番号
            objXPLN_OUT.XTUMI_HOUKOU = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTUMI_HOUKOU))       '積込方向
            objXPLN_OUT.XTUMI_HOUHOU = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTUMI_HOUHOU))       '積込方法
            objXPLN_OUT.XHENSEI_NO_OYA = strDenbunDtl(XDSPHENSEI_NO_OYA)                        '親編成No
            objXPLN_OUT.XSEND_NAME = strDenbunDtl(XDSPSEND_NAME)                                '届け先名称
            objXPLN_OUT.XSEND_ADDRESS = strDenbunDtl(XDSPSEND_ADDRESS)                          '届け先住所
            objXPLN_OUT.XBERTH_NO = strDenbunDtl(XDSPBERTH_NO)                                  'ﾊﾞｰｽ指定
            If IsNull(strDenbunDtl(XDSPKINKYU_KBN)) = True Then
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF                                      '緊急出荷区分
            ElseIf TO_INTEGER(strDenbunDtl(XDSPKINKYU_KBN)) = 0 Then
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF                                      '緊急出荷区分
            Else
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JON                                       '緊急出荷区分
            End If
            If objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF Then
                objXPLN_OUT.XKINKYU_LEVEL = 0                                                   '緊急度
            ElseIf TO_INTEGER(strDenbunDtl(XDSPKINKYU_LEVEL)) = 0 Then
                objXPLN_OUT.XKINKYU_LEVEL = 1                                                   '緊急度
            Else
                objXPLN_OUT.XKINKYU_LEVEL = TO_INTEGER(strDenbunDtl(XDSPKINKYU_LEVEL))          '緊急度
            End If
            objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JNON                                          '出荷状況
            objXPLN_OUT.ADD_XPLN_OUT()                                                          '登録



            Dim strHINMEI_CD_Ary(7) As String           '品目ｺｰﾄﾞ配列
            Dim strSYUKKA_KON_PLAN_Ary(7) As String     '出荷予定梱数配列
            Dim strSAIMOKU_Ary(7) As String             '取引区分細目配列
            Dim strPIDOU_KBN_Ary(7) As String           '移動区分配列

            strHINMEI_CD_Ary(0) = strDenbunDtl(XDSPHINMEI_CD01)                 '品名ｺｰﾄﾞ1
            strSYUKKA_KON_PLAN_Ary(0) = strDenbunDtl(XDSPSYUKKA_KON_PLAN01)     '出荷梱数1
            strSAIMOKU_Ary(0) = strDenbunDtl(XDSPSAIMOKU01)                     '取引区分細目1
            strPIDOU_KBN_Ary(0) = strDenbunDtl(XDSPIDOU_KBN01)                  '移動区分配列1
            strHINMEI_CD_Ary(1) = strDenbunDtl(XDSPHINMEI_CD02)                 '品名ｺｰﾄﾞ2
            strSYUKKA_KON_PLAN_Ary(1) = strDenbunDtl(XDSPSYUKKA_KON_PLAN02)     '出荷梱数2
            strSAIMOKU_Ary(1) = strDenbunDtl(XDSPSAIMOKU02)                     '取引区分細目2
            strPIDOU_KBN_Ary(1) = strDenbunDtl(XDSPIDOU_KBN02)                  '移動区分配列2
            strHINMEI_CD_Ary(2) = strDenbunDtl(XDSPHINMEI_CD03)                 '品名ｺｰﾄﾞ3
            strSYUKKA_KON_PLAN_Ary(2) = strDenbunDtl(XDSPSYUKKA_KON_PLAN03)     '出荷梱数3
            strSAIMOKU_Ary(2) = strDenbunDtl(XDSPSAIMOKU03)                     '取引区分細目3
            strPIDOU_KBN_Ary(2) = strDenbunDtl(XDSPIDOU_KBN03)                  '移動区分配列3
            strHINMEI_CD_Ary(3) = strDenbunDtl(XDSPHINMEI_CD04)                 '品名ｺｰﾄﾞ4
            strSYUKKA_KON_PLAN_Ary(3) = strDenbunDtl(XDSPSYUKKA_KON_PLAN04)     '出荷梱数4
            strSAIMOKU_Ary(3) = strDenbunDtl(XDSPSAIMOKU04)                     '取引区分細目4
            strPIDOU_KBN_Ary(3) = strDenbunDtl(XDSPIDOU_KBN04)                  '移動区分配列4
            strHINMEI_CD_Ary(4) = strDenbunDtl(XDSPHINMEI_CD05)                 '品名ｺｰﾄﾞ5
            strSYUKKA_KON_PLAN_Ary(4) = strDenbunDtl(XDSPSYUKKA_KON_PLAN05)     '出荷梱数5
            strSAIMOKU_Ary(4) = strDenbunDtl(XDSPSAIMOKU05)                     '取引区分細目5
            strPIDOU_KBN_Ary(4) = strDenbunDtl(XDSPIDOU_KBN05)                  '移動区分配列5
            strHINMEI_CD_Ary(5) = strDenbunDtl(XDSPHINMEI_CD06)                 '品名ｺｰﾄﾞ6
            strSYUKKA_KON_PLAN_Ary(5) = strDenbunDtl(XDSPSYUKKA_KON_PLAN06)     '出荷梱数6
            strSAIMOKU_Ary(5) = strDenbunDtl(XDSPSAIMOKU06)                     '取引区分細目6
            strPIDOU_KBN_Ary(5) = strDenbunDtl(XDSPIDOU_KBN06)                  '移動区分配列6
            strHINMEI_CD_Ary(6) = strDenbunDtl(XDSPHINMEI_CD07)                 '品名ｺｰﾄﾞ7
            strSYUKKA_KON_PLAN_Ary(6) = strDenbunDtl(XDSPSYUKKA_KON_PLAN07)     '出荷梱数7
            strSAIMOKU_Ary(6) = strDenbunDtl(XDSPSAIMOKU07)                     '取引区分細目7
            strPIDOU_KBN_Ary(6) = strDenbunDtl(XDSPIDOU_KBN07)                  '移動区分配列7
            strHINMEI_CD_Ary(7) = strDenbunDtl(XDSPHINMEI_CD08)                 '品名ｺｰﾄﾞ8
            strSYUKKA_KON_PLAN_Ary(7) = strDenbunDtl(XDSPSYUKKA_KON_PLAN08)     '出荷梱数8
            strSAIMOKU_Ary(7) = strDenbunDtl(XDSPSAIMOKU08)                     '取引区分細目8
            strPIDOU_KBN_Ary(7) = strDenbunDtl(XDSPIDOU_KBN08)                  '移動区分配列8


            '-------------------
            '出荷指示詳細の登録
            '-------------------
            Dim intII As Integer
            For intII = LBound(strHINMEI_CD_Ary) To UBound(strHINMEI_CD_Ary)
                '(ﾙｰﾌﾟ:品名数)

                If strHINMEI_CD_Ary(intII) <> DEFAULT_STRING Then
                    '(品名ｺｰﾄﾞが存在する場合)
                    '************************
                    '品目ﾏｽﾀ
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.XHINMEI_CD = strHINMEI_CD_Ary(intII)           '品目ｺｰﾄﾞ
                    intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
                    If intRet <> RetCode.OK Then
                        '(見つからない場合)
                        Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
                        strMsg = ERRMSG_NOTFOUND_TMST_ITEM
                        Throw New UserException(strMsg, False)
                    End If

                    '************************
                    '出荷指示詳細
                    '************************
                    Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)                     '出荷指示詳細ｸﾗｽ
                    objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))                         '出荷日
                    objXPLN_OUT_DTL.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                                '編成No
                    objXPLN_OUT_DTL.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                                    '品名ｺｰﾄﾞ
                    objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_SOUT                                        '作業種別
                    objXPLN_OUT_DTL.FPLAN_KEY = Format(TO_DATE(strDenbunDtl(XDSPSYUKKA_D)), "yyyyMMdd") & _
                                                strDenbunDtl(XDSPHENSEI_NO) & _
                                                strDenbunDtl(XDSPDENPYOU_NO) & _
                                                strHINMEI_CD_Ary(intII)                                     '計画KEY
                    objXPLN_OUT_DTL.XOUT_ORDER = DEFAULT_INTEGER                                            '車輌内出荷品目順
                    objXPLN_OUT_DTL.XSYUKKA_KON_PLAN = TO_INTEGER_NULLABLE(strSYUKKA_KON_PLAN_Ary(intII))   '出荷予定梱数
                    objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE = 0                                                 '出荷引当梱数
                    objXPLN_OUT_DTL.XSYUKKA_KON_RESULT = 0                                                  '出荷実績梱数
                    objXPLN_OUT_DTL.XSYUKKA_KON_H_RESULT = 0                                                '出荷実績梱数(平置)
                    objXPLN_OUT_DTL.XSAIMOKU = strSAIMOKU_Ary(intII)                                        '取引区分細目
                    objXPLN_OUT_DTL.XIDOU_KBN = strPIDOU_KBN_Ary(intII)                                     '移動区分
                    objXPLN_OUT_DTL.XHENSEI_NO_OYA = strDenbunDtl(XDSPHENSEI_NO_OYA)                        '親編成No
                    objXPLN_OUT_DTL.XTORIKIRI = FLAG_OFF                                                    '取切り指定
                    objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JNON                                  '出荷状況詳細
                    objXPLN_OUT_DTL.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)                              '伝票No
                    objXPLN_OUT_DTL.ADD_XPLN_OUT_DTL()                                                      '登録

                End If

            Next


            '----------------------
            '車輌内出荷品目順更新
            '----------------------
            Call Update_OUT_ORDER(strDenbunDtl(XDSPSYUKKA_D), strDenbunDtl(XDSPHENSEI_NO_OYA))



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  更新ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_UPDATE(ByVal strDenbunDtl() As String)
        Try

            Dim intRet As Integer                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '-------------------
            '出荷指示の特定
            '-------------------
            Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)     '出荷指示ｸﾗｽ
            objXPLN_OUT.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))     '出荷日
            objXPLN_OUT.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)            '編成No
            objXPLN_OUT.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)          '伝票No
            intRet = objXPLN_OUT.GET_XPLN_OUT                               '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objXPLN_OUT.XSYUKKA_D & "  ,編成No:" & objXPLN_OUT.XHENSEI_NO & "  ,伝票№:" & objXPLN_OUT.XDENPYOU_NO & "]"
                Throw New System.Exception(strMsg)
            End If


            '-------------------
            '親編成Noの記憶
            '-------------------
            Dim strHENSEI_NO_OYA_FM As String                       '元親編成No
            Dim strHENSEI_NO_OYA_TO As String                       '先親編成No
            strHENSEI_NO_OYA_FM = objXPLN_OUT.XHENSEI_NO_OYA        '元親編成No
            strHENSEI_NO_OYA_TO = strDenbunDtl(XDSPHENSEI_NO_OYA)   '先親編成No


            '-------------------
            '出荷指示の更新
            '-------------------
            objXPLN_OUT.XBUNRUI_NO = strDenbunDtl(XDSPBUNRUI_NO)                                '分類No
            objXPLN_OUT.XGYOUSYA_CD = strDenbunDtl(XDSPGYOUSYA_CD)                              '物流業者ｺｰﾄﾞ
            objXPLN_OUT.XSYARYOU_NO = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSYARYOU_NO))         '車輌番号
            objXPLN_OUT.XTUMI_HOUKOU = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTUMI_HOUKOU))       '積込方向
            objXPLN_OUT.XTUMI_HOUHOU = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPTUMI_HOUHOU))       '積込方法
            objXPLN_OUT.XHENSEI_NO_OYA = strDenbunDtl(XDSPHENSEI_NO_OYA)                        '親編成No
            objXPLN_OUT.XSEND_NAME = strDenbunDtl(XDSPSEND_NAME)                                '届け先名称
            objXPLN_OUT.XSEND_ADDRESS = strDenbunDtl(XDSPSEND_ADDRESS)                          '届け先住所
            objXPLN_OUT.XBERTH_NO = strDenbunDtl(XDSPBERTH_NO)                                  'ﾊﾞｰｽ指定
            If IsNull(strDenbunDtl(XDSPKINKYU_KBN)) = True Then
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF                                      '緊急出荷区分
            ElseIf TO_INTEGER(strDenbunDtl(XDSPKINKYU_KBN)) = 0 Then
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF                                      '緊急出荷区分
            Else
                objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JON                                       '緊急出荷区分
            End If
            If objXPLN_OUT.XKINKYU_KBN = XKINKYU_KBN_JOFF Then
                objXPLN_OUT.XKINKYU_LEVEL = 0                                                   '緊急度
            ElseIf TO_INTEGER(strDenbunDtl(XDSPKINKYU_LEVEL)) = 0 Then
                objXPLN_OUT.XKINKYU_LEVEL = 1                                                   '緊急度
            Else
                objXPLN_OUT.XKINKYU_LEVEL = TO_INTEGER(strDenbunDtl(XDSPKINKYU_LEVEL))          '緊急度
            End If
            objXPLN_OUT.XSYUKKA_STS = XSYUKKA_STS_JNON                                          '出荷状況
            objXPLN_OUT.UPDATE_XPLN_OUT()                                                          '登録

            '出荷指示品名取得
            Dim strHin() As String                                              '品名ｺｰﾄﾞ
            Erase strHin                                                        '品名ｺｰﾄﾞ初期化
            Call XPLN_OUT_DTL_HIN(strDenbunDtl(XDSPSYUKKA_D), strDenbunDtl(XDSPHENSEI_NO), strDenbunDtl(XDSPDENPYOU_NO), strHin)

            '出荷指示品名目数
            Dim intHinCnt As Integer
            If strHin Is Nothing Then
                intHinCnt = 0
            Else
                intHinCnt = UBound(strHin)
            End If

            '削除品名ﾌﾗｸﾞ
            Dim blnHin() As Boolean                                             '品名ｺｰﾄﾞ
            ReDim blnHin(intHinCnt)
            For i As Integer = 1 To intHinCnt
                blnHin(i) = False
            Next




            Dim strHINMEI_CD_Ary(7) As String           '品目ｺｰﾄﾞ配列
            Dim strSYUKKA_KON_PLAN_Ary(7) As String     '出荷予定梱数配列
            Dim strSAIMOKU_Ary(7) As String             '取引区分細目配列
            Dim strPIDOU_KBN_Ary(7) As String           '移動区分配列

            strHINMEI_CD_Ary(0) = strDenbunDtl(XDSPHINMEI_CD01)                 '品名ｺｰﾄﾞ1
            strSYUKKA_KON_PLAN_Ary(0) = strDenbunDtl(XDSPSYUKKA_KON_PLAN01)     '出荷梱数1
            strSAIMOKU_Ary(0) = strDenbunDtl(XDSPSAIMOKU01)                     '取引区分細目1
            strPIDOU_KBN_Ary(0) = strDenbunDtl(XDSPIDOU_KBN01)                  '移動区分配列1
            strHINMEI_CD_Ary(1) = strDenbunDtl(XDSPHINMEI_CD02)                 '品名ｺｰﾄﾞ2
            strSYUKKA_KON_PLAN_Ary(1) = strDenbunDtl(XDSPSYUKKA_KON_PLAN02)     '出荷梱数2
            strSAIMOKU_Ary(1) = strDenbunDtl(XDSPSAIMOKU02)                     '取引区分細目2
            strPIDOU_KBN_Ary(1) = strDenbunDtl(XDSPIDOU_KBN02)                  '移動区分配列2
            strHINMEI_CD_Ary(2) = strDenbunDtl(XDSPHINMEI_CD03)                 '品名ｺｰﾄﾞ3
            strSYUKKA_KON_PLAN_Ary(2) = strDenbunDtl(XDSPSYUKKA_KON_PLAN03)     '出荷梱数3
            strSAIMOKU_Ary(2) = strDenbunDtl(XDSPSAIMOKU03)                     '取引区分細目3
            strPIDOU_KBN_Ary(2) = strDenbunDtl(XDSPIDOU_KBN03)                  '移動区分配列3
            strHINMEI_CD_Ary(3) = strDenbunDtl(XDSPHINMEI_CD04)                 '品名ｺｰﾄﾞ4
            strSYUKKA_KON_PLAN_Ary(3) = strDenbunDtl(XDSPSYUKKA_KON_PLAN04)     '出荷梱数4
            strSAIMOKU_Ary(3) = strDenbunDtl(XDSPSAIMOKU04)                     '取引区分細目4
            strPIDOU_KBN_Ary(3) = strDenbunDtl(XDSPIDOU_KBN04)                  '移動区分配列4
            strHINMEI_CD_Ary(4) = strDenbunDtl(XDSPHINMEI_CD05)                 '品名ｺｰﾄﾞ5
            strSYUKKA_KON_PLAN_Ary(4) = strDenbunDtl(XDSPSYUKKA_KON_PLAN05)     '出荷梱数5
            strSAIMOKU_Ary(4) = strDenbunDtl(XDSPSAIMOKU05)                     '取引区分細目5
            strPIDOU_KBN_Ary(4) = strDenbunDtl(XDSPIDOU_KBN05)                  '移動区分配列5
            strHINMEI_CD_Ary(5) = strDenbunDtl(XDSPHINMEI_CD06)                 '品名ｺｰﾄﾞ6
            strSYUKKA_KON_PLAN_Ary(5) = strDenbunDtl(XDSPSYUKKA_KON_PLAN06)     '出荷梱数6
            strSAIMOKU_Ary(5) = strDenbunDtl(XDSPSAIMOKU06)                     '取引区分細目6
            strPIDOU_KBN_Ary(5) = strDenbunDtl(XDSPIDOU_KBN06)                  '移動区分配列6
            strHINMEI_CD_Ary(6) = strDenbunDtl(XDSPHINMEI_CD07)                 '品名ｺｰﾄﾞ7
            strSYUKKA_KON_PLAN_Ary(6) = strDenbunDtl(XDSPSYUKKA_KON_PLAN07)     '出荷梱数7
            strSAIMOKU_Ary(6) = strDenbunDtl(XDSPSAIMOKU07)                     '取引区分細目7
            strPIDOU_KBN_Ary(6) = strDenbunDtl(XDSPIDOU_KBN07)                  '移動区分配列7
            strHINMEI_CD_Ary(7) = strDenbunDtl(XDSPHINMEI_CD08)                 '品名ｺｰﾄﾞ8
            strSYUKKA_KON_PLAN_Ary(7) = strDenbunDtl(XDSPSYUKKA_KON_PLAN08)     '出荷梱数8
            strSAIMOKU_Ary(7) = strDenbunDtl(XDSPSAIMOKU08)                     '取引区分細目8
            strPIDOU_KBN_Ary(7) = strDenbunDtl(XDSPIDOU_KBN08)                  '移動区分配列8


            Dim intII As Integer
            For intII = LBound(strHINMEI_CD_Ary) To UBound(strHINMEI_CD_Ary)
                '(ﾙｰﾌﾟ:品名数)

                If strHINMEI_CD_Ary(intII) <> DEFAULT_STRING Then
                    '(品名ｺｰﾄﾞが存在する場合)

                    '************************
                    '品目ﾏｽﾀ
                    '************************
                    Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                    objTMST_ITEM.XHINMEI_CD = strHINMEI_CD_Ary(intII)           '品目ｺｰﾄﾞ
                    intRet = objTMST_ITEM.GET_TMST_ITEM(False)                  '取得
                    If intRet <> RetCode.OK Then
                        '(見つからない場合)
                        Call AddToMsgLog(Now, FMSG_ID_S0201, objTMST_ITEM.FHINMEI_CD)
                        strMsg = ERRMSG_NOTFOUND_TMST_ITEM
                        Throw New UserException(strMsg, False)
                    End If

                    '-------------------
                    '出荷指示詳細の特定
                    '-------------------
                    Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)         '出荷指示詳細ｸﾗｽ
                    objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))             '出荷日
                    objXPLN_OUT_DTL.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                    '編成№
                    objXPLN_OUT_DTL.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)                  '伝票№
                    objXPLN_OUT_DTL.FHINMEI_CD = objTMST_ITEM.FHINMEI_CD                        '品名ｺｰﾄﾞ
                    intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL(False)                            '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_SOUT                                        '作業種別
                        objXPLN_OUT_DTL.FPLAN_KEY = Format(TO_DATE(strDenbunDtl(XDSPSYUKKA_D)), "yyyyMMdd") & _
                                                    strDenbunDtl(XDSPHENSEI_NO) & _
                                                    strDenbunDtl(XDSPDENPYOU_NO) & _
                                                    strHINMEI_CD_Ary(intII)                                     '計画KEY
                        objXPLN_OUT_DTL.XOUT_ORDER = DEFAULT_INTEGER                                            '車輌内出荷品目順
                        objXPLN_OUT_DTL.XSYUKKA_KON_PLAN = TO_INTEGER_NULLABLE(strSYUKKA_KON_PLAN_Ary(intII))   '出荷予定梱数
                        objXPLN_OUT_DTL.XSYUKKA_KON_RESERVE = 0                                                 '出荷引当梱数
                        objXPLN_OUT_DTL.XSYUKKA_KON_RESULT = 0                                                  '出荷実績梱数
                        objXPLN_OUT_DTL.XSYUKKA_KON_H_RESULT = 0                                                '出荷実績梱数(平置)
                        objXPLN_OUT_DTL.XSAIMOKU = strSAIMOKU_Ary(intII)                                        '取引区分細目
                        objXPLN_OUT_DTL.XIDOU_KBN = strPIDOU_KBN_Ary(intII)                                     '移動区分
                        objXPLN_OUT_DTL.XHENSEI_NO_OYA = strDenbunDtl(XDSPHENSEI_NO_OYA)                        '親編成No
                        objXPLN_OUT_DTL.XTORIKIRI = FLAG_OFF                                                    '取切り指定
                        objXPLN_OUT_DTL.XSYUKKA_STS_DTL = XSYUKKA_STS_DTL_JNON                                  '出荷状況詳細
                        objXPLN_OUT_DTL.ADD_XPLN_OUT_DTL()                                                      '追加
                    Else
                        '(見つかった場合)
                        '-------------------
                        '出荷指示詳細の更新
                        '-------------------
                        objXPLN_OUT_DTL.FSAGYOU_KIND = FSAGYOU_KIND_SOUT                                        '作業種別
                        objXPLN_OUT_DTL.XSYUKKA_KON_PLAN = TO_INTEGER_NULLABLE(strSYUKKA_KON_PLAN_Ary(intII))   '出荷予定梱数
                        objXPLN_OUT_DTL.XSAIMOKU = strSAIMOKU_Ary(intII)                                        '取引区分細目
                        objXPLN_OUT_DTL.XIDOU_KBN = strPIDOU_KBN_Ary(intII)                                     '移動区分
                        objXPLN_OUT_DTL.XHENSEI_NO_OYA = strDenbunDtl(XDSPHENSEI_NO_OYA)                        '親編成No
                        objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()                                                   '更新

                    End If


                    '-------------------
                    '既存指示の存在確認
                    '-------------------
                    For i As Integer = 1 To intHinCnt
                        If objTMST_ITEM.FHINMEI_CD = strHin(i) Then
                            blnHin(i) = True
                            Exit For
                        End If
                    Next

                End If
            Next


            '-------------------
            '削除ﾃﾞｰﾀ処理
            '-------------------
            For i As Integer = 1 To intHinCnt
                If blnHin(i) = False Then
                    Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)         '出荷指示詳細
                    objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))             '出荷日
                    objXPLN_OUT_DTL.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                    '編成№
                    objXPLN_OUT_DTL.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)                  '伝票№
                    objXPLN_OUT_DTL.FHINMEI_CD = strHin(i)                                      '品名ｺｰﾄﾞ
                    objXPLN_OUT_DTL.DELETE_XPLN_OUT_DTL()                                       '削除
                End If
            Next


            '----------------------
            '元車輌内出荷品目順更新
            '----------------------
            Call Update_OUT_ORDER(strDenbunDtl(XDSPSYUKKA_D), strHENSEI_NO_OYA_FM)


            '----------------------
            '先車輌内出荷品目順更新
            '----------------------
            Call Update_OUT_ORDER(strDenbunDtl(XDSPSYUKKA_D), strHENSEI_NO_OYA_TO)



        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  削除ﾒﾝﾃﾅﾝｽ                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 削除ﾒﾝﾃﾅﾝｽ
    ''' </summary>
    ''' <param name="strDenbunDtl">電文分解配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_DELETE(ByVal strDenbunDtl() As String)
        Try

            Dim intRet As RetCode
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '-------------------
            '出荷指示の特定
            '-------------------
            Dim objXPLN_OUT_FM As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)     '出荷指示ｸﾗｽ
            objXPLN_OUT_FM.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))     '出荷日
            objXPLN_OUT_FM.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)            '編成No
            objXPLN_OUT_FM.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)          '伝票No
            intRet = objXPLN_OUT_FM.GET_XPLN_OUT                               '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_XPLN_OUT & "[出荷日:" & objXPLN_OUT_FM.XSYUKKA_D & "  ,編成No:" & objXPLN_OUT_FM.XHENSEI_NO & "  ,伝票№:" & objXPLN_OUT_FM.XDENPYOU_NO & "]"
                Throw New System.Exception(strMsg)
            End If


            '-------------------
            '親編成Noの記憶
            '-------------------
            Dim strHENSEI_NO_OYA_FM As String                           '元親編成No
            strHENSEI_NO_OYA_FM = objXPLN_OUT_FM.XHENSEI_NO_OYA         '元親編成No


            '-------------------
            '出荷指示の削除
            '-------------------
            Dim objXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)         '出荷指示ｸﾗｽ
            objXPLN_OUT.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))         '出荷日
            objXPLN_OUT.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                '編成№
            objXPLN_OUT.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)              '伝票№
            objXPLN_OUT.DELETE_XPLN_OUT()                                       '削除


            '-------------------
            '出荷指示詳細の削除
            '-------------------
            Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)     '出荷指示詳細ｸﾗｽ
            objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(strDenbunDtl(XDSPSYUKKA_D))         '出荷日
            objXPLN_OUT_DTL.XHENSEI_NO = strDenbunDtl(XDSPHENSEI_NO)                '編成No
            objXPLN_OUT_DTL.XDENPYOU_NO = strDenbunDtl(XDSPDENPYOU_NO)              '伝票№
            objXPLN_OUT_DTL.DELETE_XPLN_OUT_DTL_HENSEI()                            '削除


            '----------------------
            '元車輌内出荷品目順更新
            '----------------------
            Call Update_OUT_ORDER(strDenbunDtl(XDSPSYUKKA_D), strHENSEI_NO_OYA_FM)



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
#Region "  車輌内出荷品目順更新                                                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 車輌内出荷品目順更新
    ''' </summary>
    ''' <param name="dtmSYUKKA_D">出荷日</param>
    ''' <param name="strHENSEI_NO_OYA">親編成№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Update_OUT_ORDER(ByVal dtmSYUKKA_D As Date, ByVal strHENSEI_NO_OYA As String)
        Try
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intII As Integer                'ｶｳﾝﾀ
            Dim intRet As RetCode               '戻り値
            Dim strMsg As String                'ﾒｯｾｰｼﾞ


            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"           '出荷指示詳細
            strSQL &= vbCrLf & "   ,TMST_ITEM"              '品名ﾏｽﾀ
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        XPLN_OUT_DTL.XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd") & "','YYYY/MM/DD')"   '出荷日
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & TO_STRING(strHENSEI_NO_OYA) & "'"    '親編成No
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD"                         '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TMST_ITEM.XHEIGHT_IN_PALLET DESC"       '荷高
            strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI_CD"                   '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "   ,XPLN_OUT_DTL.XHENSEI_NO"                '編成No
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For intII = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                    objRow = objDataSet.Tables(strDataSetName).Rows(intII)

                    '-----------------------
                    '出荷指示詳細の特定
                    '-----------------------
                    Dim objXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)     '出荷指示詳細ｸﾗｽ
                    objXPLN_OUT_DTL.XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))                '出荷日
                    objXPLN_OUT_DTL.XHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))            '編成No
                    objXPLN_OUT_DTL.XDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))          '伝票№
                    objXPLN_OUT_DTL.FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))            '品名ｺｰﾄﾞ
                    intRet = objXPLN_OUT_DTL.GET_XPLN_OUT_DTL()                             '特定
                    If intRet = RetCode.NotFound Then
                        '(見つからない場合)
                        strMsg = ERRMSG_NOTFOUND_XPLN_OUT_DTL & "[出荷日:" & objXPLN_OUT_DTL.XSYUKKA_D & "  ,親編成No:" & objXPLN_OUT_DTL.XHENSEI_NO_OYA & "  ,品名ｺｰﾄﾞ:" & objXPLN_OUT_DTL.FHINMEI_CD & "]"
                        Throw New System.Exception(strMsg)
                    End If


                    '-----------------------
                    '出荷指示詳細の更新
                    '-----------------------
                    objXPLN_OUT_DTL.XOUT_ORDER = intII + 1          '車輌内出荷品目順
                    objXPLN_OUT_DTL.UPDATE_XPLN_OUT_DTL()           '更新

                Next
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  出荷指示品名取得                                                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷指示品名取得
    ''' </summary>
    ''' <param name="dtmSYUKKA_D">出荷日</param>
    ''' <param name="strXHENSEI_NO">編成№</param>
    ''' <param name="strXDENPYOU_NO">伝票№</param>
    ''' <param name="strHin">品名ｺｰﾄﾞ配列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub XPLN_OUT_DTL_HIN(ByVal dtmSYUKKA_D As Date, ByVal strXHENSEI_NO As String, ByVal strXDENPYOU_NO As String, ByRef strHin() As String)
        Try
            Dim intCnt As Integer
            Dim strSQL As String            'SQL文
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のデータ


            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_D = TO_DATE('" & Format(dtmSYUKKA_D, "yyyy/MM/dd") & "','YYYY/MM/DD')"                       '出荷日
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XHENSEI_NO = '" & TO_STRING(strXHENSEI_NO) & "'"         '編成№
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XDENPYOU_NO = '" & TO_STRING(strXDENPYOU_NO) & "'"      '伝票№
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            intCnt = 0
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows
                    intCnt += 1
                    ReDim Preserve strHin(intCnt)
                    strHin(intCnt) = TO_STRING(objRow("FHINMEI_CD"))           '品名ｺｰﾄﾞ
                Next
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
