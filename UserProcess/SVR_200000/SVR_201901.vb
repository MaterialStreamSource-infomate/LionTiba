'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】品名ﾏｽﾀﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_201901
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "

    '電文分解用
    Private Const DSPTERM_ID As Integer = 0             '端末ID
    Private Const DSPUSER_ID As Integer = 1             'ﾕｰｻﾞｰID
    Private Const DSPREASON As Integer = 2              '理由
    Private Const DSPDIR_KUBUN As Integer = 3           '処理区分
    Private Const DSPHINMEI_CD As Integer = 4           '品名ｺｰﾄﾞ
    Private Const DSPHINMEI As Integer = 5              '品名
    Private Const DSPNUM_IN_CASE As Integer = 6         'ｹｰｽ入数
    Private Const DSPTANI As Integer = 7                '単位
    Private Const DSPDECIMAL_POINT As Integer = 8       '小数点桁数
    Private Const DSPNUM_IN_PALLET As Integer = 9       'PL毎積載数
    Private Const DSPZAIKO_KUBUN As Integer = 10        '在庫区分
    Private Const DSPRAC_FORM As Integer = 11           '棚形状種別
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/06/26 ｱｲﾃﾑ追加
    Private Const XDSPATRICLE_TYPE_CODE As Integer = 12         '品目種別
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:K.Kobayashi 2013/04/13 ｱｲﾃﾑ追加
    Private Const XDSPHINMEI_CD As Integer = 13                 '品目記号
    Private Const XDSPPLANE_PACK_NUMBER As Integer = 14         '平面梱数
    Private Const XDSPWEIGHT_IN_CASE As Integer = 15            '梱重量
    Private Const XDSPHEIGHT_IN_CASE As Integer = 16            '梱高さ
    Private Const XDSPWEIGHT_IN_PALLET As Integer = 17          'ﾊﾟﾚｯﾄあたりの重量
    Private Const XDSPDAN_IN_PALLET As Integer = 18             '1ﾊﾟﾚｯﾄの段数
    Private Const XDSPHEIGHT_IN_PALLET As Integer = 19          'ﾊﾟﾚｯﾄ高さ
    Private Const XDSPSUB_CD As Integer = 20                    'ｻﾌﾞｺｰﾄﾞ
    Private Const XDSPITF_CD As Integer = 21                    'ITFｺｰﾄﾞ
    Private Const XDSPJAN_CD As Integer = 22                    'JANｺｰﾄﾞ
    Private Const XDSPMAKER_CD As Integer = 23                  'ﾒｰｶｺｰﾄﾞ
    '↑↑↑↑↑↑************************************************************************************************************
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
    'Private Const DSPRAC_BUNRUI As Integer = 24                 '棚分類
    Private Const XDSPIN_RES_TYPE As Integer = 24               '空棚引当ﾀｲﾌﾟ
    '↑↑↑↑↑↑************************************************************************************************************

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
            '品名ﾏｽﾀﾒﾝﾃﾅﾝｽ
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
            Dim intRet As RetCode
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '**************************************
            'ﾕｰｻﾞﾏｽﾀ取得
            '**************************************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                'ﾕｰｻﾞID
            If objTMST_USER.FUSER_ID <> "" Then
                Call objTMST_USER.GET_TMST_USER(False)
            End If

            '**************************************
            '品名ﾏｽﾀ存在ﾁｪｯｸ
            '**************************************
            Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)    '品名ｺｰﾄﾞ
            intRet = objTMST_ITEM_Before.GET_TMST_ITEM(False)
            If intRet <> RetCode.NotFound Then
                '(品名ﾏｽﾀが存在した場合)
                strMsg = FRM_MSG_FHINMEI_CD_MSG_03 & "[品名:" & objTMST_ITEM_Before.FHINMEI & "]"
                Throw New System.Exception(strMsg)
                Exit Sub
            End If
            Dim intCount As Integer = 0
            objTMST_ITEM_Before.CLEAR_PROPERTY()
            objTMST_ITEM_Before.XHINMEI_CD = strDenbunDtl(XDSPHINMEI_CD)    '品目記号
            intCount = objTMST_ITEM_Before.GET_TMST_ITEM_COUNT
            If 0 < intCount Then
                '(品名ﾏｽﾀが存在した場合)
                strMsg = "既に同じ品名記号が登録されています。[品名記号:" & objTMST_ITEM_Before.XHINMEI_CD & "]"
                Throw New System.Exception(strMsg)
                Exit Sub
            End If
            objTMST_ITEM_Before.CLEAR_PROPERTY()


            '**************************************
            '品名ﾏｽﾀの追加
            '**************************************
            Dim objTMST_ITEM_After As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_After.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                      '品名ｺｰﾄﾞ
            objTMST_ITEM_After.FHINMEI = strDenbunDtl(DSPHINMEI)                                            '品名
            objTMST_ITEM_After.FNUM_IN_CASE = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPNUM_IN_CASE))             'ｹｰｽ入数
            objTMST_ITEM_After.FTANI = strDenbunDtl(DSPTANI)                                                '単位
            objTMST_ITEM_After.FDECIMAL_POINT = TO_INTEGER_NULLABLE(strDenbunDtl(DSPDECIMAL_POINT))         '小数点桁数
            objTMST_ITEM_After.FNUM_IN_PALLET = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPNUM_IN_PALLET))         'PL毎積載数
            objTMST_ITEM_After.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))             '在庫区分
            objTMST_ITEM_After.FRAC_FORM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPRAC_FORM))                   '棚形状種別
            '**********************************************************************************************
            '↓↓↓ｼｽﾃﾑ固有
            objTMST_ITEM_After.XARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPATRICLE_TYPE_CODE))        '品目種別
            '↑↑↑ｼｽﾃﾑ固有
            '**********************************************************************************************
            '**********************************************************************************************
            '↓↓↓ｼｽﾃﾑ固有
            'JobMate:K.Kobayashi 2013/04/13 ｱｲﾃﾑ追加
            objTMST_ITEM_After.XHINMEI_CD = strDenbunDtl(XDSPHINMEI_CD)                                     '品目記号
            objTMST_ITEM_After.XPLANE_PACK_NUMBER = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPPLANE_PACK_NUMBER))                     '平面梱数
            objTMST_ITEM_After.XWEIGHT_IN_CASE = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPWEIGHT_IN_CASE))                           '梱重量
            objTMST_ITEM_After.XHEIGHT_IN_CASE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPHEIGHT_IN_CASE))                           '梱高さ
            objTMST_ITEM_After.XWEIGHT_IN_PALLET = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPWEIGHT_IN_PALLET))                       'ﾊﾟﾚｯﾄあたりの重量
            objTMST_ITEM_After.XDAN_IN_PALLET = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPDAN_IN_PALLET))                             '1ﾊﾟﾚｯﾄの段数
            objTMST_ITEM_After.XHEIGHT_IN_PALLET = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPHEIGHT_IN_PALLET))                       'ﾊﾟﾚｯﾄ高さ
            objTMST_ITEM_After.XSUB_CD = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSUB_CD))                                           'ｻﾌﾞｺｰﾄﾞ
            objTMST_ITEM_After.XITF_CD = strDenbunDtl(XDSPITF_CD)                                           'ITFｺｰﾄﾞ
            objTMST_ITEM_After.XJAN_CD = strDenbunDtl(XDSPJAN_CD)                                           'JANｺｰﾄﾞ
            'objTMST_ITEM_After.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                       'ﾒｰｶｺｰﾄﾞ
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
            'objTMST_ITEM_After.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)                                    '棚分類
            objTMST_ITEM_After.XIN_RES_TYPE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPIN_RES_TYPE))             '空棚引当ﾀｲﾌﾟ
            '↑↑↑↑↑↑************************************************************************************************************
            '↑↑↑ｼｽﾃﾑ固有
            '**********************************************************************************************
            objTMST_ITEM_After.FENTRY_DT = Now                                                              '登録日時
            objTMST_ITEM_After.FENTRY_USER_ID = strDenbunDtl(DSPUSER_ID)                                    '登録ﾕｰｻﾞｰID
            objTMST_ITEM_After.FENTRY_USER_NAME = objTMST_USER.FUSER_NAME                                   '登録ﾕｰｻﾞｰ名
            objTMST_ITEM_After.FENTRY_TERM_ID = strDenbunDtl(DSPTERM_ID)                                    '登録端末ID
            objTMST_ITEM_After.FUPDATE_DT = Now                                                             '更新日時
            objTMST_ITEM_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                                   '更新ﾕｰｻﾞｰID
            objTMST_ITEM_After.FUPDATE_USER_NAME = objTMST_USER.FUSER_NAME                                  '更新ﾕｰｻﾞｰ名
            objTMST_ITEM_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                                   '更新端末ID
            Call objTMST_ITEM_After.ADD_TMST_ITEM()                                                         '追加

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TMST_ITEM(strDenbunDtl _
            '                                   , MeSyoriID _
            '                                   , objTMST_ITEM_Before _
            '                                   , objTMST_ITEM_After _
            '                                   )
            '↑↑↑↑↑↑************************************************************************************************************

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
            Dim intRet As RetCode
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '**************************************
            'ﾕｰｻﾞﾏｽﾀ取得
            '**************************************
            Dim objTMST_USER As New TBL_TMST_USER(Owner, ObjDb, ObjDbLog)
            objTMST_USER.FUSER_ID = strDenbunDtl(DSPUSER_ID)                'ﾕｰｻﾞID
            If objTMST_USER.FUSER_ID <> "" Then
                Call objTMST_USER.GET_TMST_USER(False)
            End If

            '**************************************
            '品名ﾏｽﾀ存在ﾁｪｯｸ
            '**************************************
            Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)    '品名ｺｰﾄﾞ
            intRet = objTMST_ITEM_Before.GET_TMST_ITEM(True)

            '**************************************
            '品名ﾏｽﾀの更新
            '**************************************
            Dim objTMST_ITEM_After As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_After.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)                                      '品名ｺｰﾄﾞ
            objTMST_ITEM_After.GET_TMST_ITEM(False)
            objTMST_ITEM_After.FHINMEI = strDenbunDtl(DSPHINMEI)                                            '品名
            objTMST_ITEM_After.FNUM_IN_CASE = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPNUM_IN_CASE))             'ｹｰｽ入数
            objTMST_ITEM_After.FTANI = strDenbunDtl(DSPTANI)                                                '単位
            objTMST_ITEM_After.FDECIMAL_POINT = TO_INTEGER_NULLABLE(strDenbunDtl(DSPDECIMAL_POINT))         '小数点桁数
            objTMST_ITEM_After.FNUM_IN_PALLET = TO_DECIMAL_NULLABLE(strDenbunDtl(DSPNUM_IN_PALLET))         'PL毎積載数
            objTMST_ITEM_After.FZAIKO_KUBUN = TO_INTEGER_NULLABLE(strDenbunDtl(DSPZAIKO_KUBUN))             '在庫区分
            objTMST_ITEM_After.FRAC_FORM = TO_INTEGER_NULLABLE(strDenbunDtl(DSPRAC_FORM))                   '棚形状種別
            '**********************************************************************************************
            '↓↓↓ｼｽﾃﾑ固有
            objTMST_ITEM_After.XARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPATRICLE_TYPE_CODE))    '品目種別
            '↑↑↑ｼｽﾃﾑ固有
            '**********************************************************************************************
            '**********************************************************************************************
            '↓↓↓ｼｽﾃﾑ固有
            'JobMate:K.Kobayashi 2013/04/13 ｱｲﾃﾑ追加
            objTMST_ITEM_After.XHINMEI_CD = strDenbunDtl(XDSPHINMEI_CD)                                         '品目記号
            objTMST_ITEM_After.XPLANE_PACK_NUMBER = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPPLANE_PACK_NUMBER))    '平面梱数
            objTMST_ITEM_After.XWEIGHT_IN_CASE = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPWEIGHT_IN_CASE))          '梱重量
            objTMST_ITEM_After.XHEIGHT_IN_CASE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPHEIGHT_IN_CASE))          '梱高さ
            objTMST_ITEM_After.XWEIGHT_IN_PALLET = TO_DECIMAL_NULLABLE(strDenbunDtl(XDSPWEIGHT_IN_PALLET))      'ﾊﾟﾚｯﾄあたりの重量
            objTMST_ITEM_After.XDAN_IN_PALLET = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPDAN_IN_PALLET))            '1ﾊﾟﾚｯﾄの段数
            objTMST_ITEM_After.XHEIGHT_IN_PALLET = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPHEIGHT_IN_PALLET))      'ﾊﾟﾚｯﾄ高さ
            objTMST_ITEM_After.XSUB_CD = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPSUB_CD))                          'ｻﾌﾞｺｰﾄﾞ
            objTMST_ITEM_After.XITF_CD = strDenbunDtl(XDSPITF_CD)                                               'ITFｺｰﾄﾞ
            objTMST_ITEM_After.XJAN_CD = strDenbunDtl(XDSPJAN_CD)                                               'JANｺｰﾄﾞ
            'objTMST_ITEM_After.XMAKER_CD = strDenbunDtl(XDSPMAKER_CD)                                           'ﾒｰｶｺｰﾄﾞ
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
            'objTMST_ITEM_After.FRAC_BUNRUI = strDenbunDtl(DSPRAC_BUNRUI)                                       '棚分類
            objTMST_ITEM_After.XIN_RES_TYPE = TO_INTEGER_NULLABLE(strDenbunDtl(XDSPIN_RES_TYPE))                '空棚引当ﾀｲﾌﾟ
            '↑↑↑↑↑↑************************************************************************************************************
            '↑↑↑ｼｽﾃﾑ固有
            '**********************************************************************************************
            objTMST_ITEM_After.FUPDATE_DT = Now                                                             '更新日時
            objTMST_ITEM_After.FUPDATE_USER_ID = strDenbunDtl(DSPUSER_ID)                                   '更新ﾕｰｻﾞｰID
            objTMST_ITEM_After.FUPDATE_USER_NAME = objTMST_USER.FUSER_NAME                                  '更新ﾕｰｻﾞｰ名
            objTMST_ITEM_After.FUPDATE_TERM_ID = strDenbunDtl(DSPTERM_ID)                                   '更新端末ID
            Call objTMST_ITEM_After.UPDATE_TMST_ITEM()                                    '更新

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TMST_ITEM(strDenbunDtl _
            '                                   , MeSyoriID _
            '                                   , objTMST_ITEM_Before _
            '                                   , objTMST_ITEM_After _
            '                                   )
            '↑↑↑↑↑↑************************************************************************************************************

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
            'Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '**************************************
            '品名ﾏｽﾀ存在ﾁｪｯｸ
            '**************************************
            Dim objTMST_ITEM_Before As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
            objTMST_ITEM_Before.FHINMEI_CD = strDenbunDtl(DSPHINMEI_CD)    '品名ｺｰﾄﾞ
            intRet = objTMST_ITEM_Before.GET_TMST_ITEM(True)


            '**************************************
            '品名ﾏｽﾀの削除
            '**************************************
            Call objTMST_ITEM_Before.DELETE_TMST_ITEM()                      '削除


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:A.Noto 2013/03/26 変更履歴未使用
            ''**************************************
            ''削除後の品名ﾏｽﾀをﾀﾞﾐｰで作成
            ''**************************************
            'Dim objTMST_ITEM_After As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)

            ''**************************************
            ''変更履歴詳細追加
            ''**************************************
            'Call Add_TEVD_TBLCHANGE_DTL_TMST_ITEM(strDenbunDtl _
            '                                   , MeSyoriID _
            '                                   , objTMST_ITEM_Before _
            '                                   , objTMST_ITEM_After _
            '                                   )
            '↑↑↑↑↑↑************************************************************************************************************

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
