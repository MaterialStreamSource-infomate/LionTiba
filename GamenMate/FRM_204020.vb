'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫詳細問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204020

#Region "　共通変数　                               "

    Private mstrFPLACE_CD As String                     '保管場所
    Private mstrFPLACE_NM As String                     '保管場所名
    Private mstrFHINMEI_CD As String                    '品名ｺｰﾄﾞ
    Private mstrFHINMEI As String                       '品名
    Private mstrXPROD_LINE As String                    '生産ﾗｲﾝ№
    Private mstrXPROD_LINE_NM As String                 '生産ﾗｲﾝ№名称
    Private mstrFEQ_ID_CRANE As String                  'ｸﾚｰﾝ設備ID
    Private mstrXARTICLE_TYPE_CODE As String            '商品区分
    Private mstrXARTICLE_TYPE_CODE_NM As String         '商品区分名称
    Private mstrXKENSA_KUBUN As String                  '検査区分
    Private mstrXKENSA_KUBUN_NM As String               '検査区分名称
    Private mstrFHORYU_KUBUN As String                  '保留区分
    Private mstrFHORYU_KUBUN_NM As String               '保留区分名称
    Private mstrFARRIVE_DT_FROM As String               '入庫日(FROM)
    Private mstrFARRIVE_DT_TO As String                 '入庫日(TO)
    Private mstrCRANE As String                         'ｸﾚｰﾝ名
    Private mstrXKENPIN_KUBUN As String                 '検品区分
    Private mstrFIN_KUBUN As String                     '入庫区分

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mobjOwner As FRM_204010      'ｵｰﾅｰﾌｫｰﾑ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/01 在庫詳細問合せ画面 ﾒｰｶｰｺｰﾄﾞ移動
        ' '' ''FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        ' '' ''FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        '' '' ''↓↓↓↓↓↓************************************************************************************************************
        '' '' ''JobMate:H.Okumura 2013/06/05 順番変更
        ' '' ''XHINMEI_CD                  '在庫情報       .品目ｺｰﾄﾞ
        ' '' ''FHINMEI_CD                  '在庫情報       .品名ｺｰﾄﾞ(品名記号)
        '' '' ''↑↑↑↑↑↑************************************************************************************************************
        ' '' ''FHINMEI                     '品目ﾏｽﾀ        .品名
        ' '' ''XPROD_LINE                  '在庫情報       .生産ﾗｲﾝ№
        ' '' ''XPROD_LINE_DSP              '在庫情報       .生産ﾗｲﾝ№(表示用)
        ' '' ''FTR_VOL                     '在庫情報       .搬送管理量(積込数)
        ' '' ''FDISP_ADDRESS               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        ' '' ''FARRIVE_DT                  '在庫情報       .在庫発生日時
        ' '' ''XARTICLE_TYPE_CODE          '在庫情報       .商品区分
        ' '' ''XARTICLE_TYPE_CODE_DSP      '在庫情報       .商品区分(表示用)
        ' '' ''XKENSA_KUBUN                '在庫情報       .検査区分
        ' '' ''XKENSA_KUBUN_DSP            '在庫情報       .検査区分(表示用)
        ' '' ''FHORYU_KUBUN                '在庫情報       .保留区分
        ' '' ''FHORYU_KUBUN_DSP            '在庫情報       .保留区分(表示用)
        ' '' ''XKENPIN_KUBUN               '在庫情報       .検品区分
        ' '' ''XKENPIN_KUBUN_DSP           '在庫情報       .検品区分(表示用)
        ' '' ''FIN_KUBUN                   '在庫情報       .入庫区分
        ' '' ''FIN_KUBUN_DSP               '在庫情報       .入庫区分(表示用)
        ' '' ''XMAKER_CD                   '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        ' '' ''FLOT_NO                     '在庫情報       .ﾛｯﾄ№
        ' '' ''FPALLET_ID                  '在庫情報       .ﾊﾟﾚｯﾄID

        ' '' ''MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        XHINMEI_CD                  '在庫情報       .品目ｺｰﾄﾞ
        FHINMEI_CD                  '在庫情報       .品名ｺｰﾄﾞ(品名記号)
        FHINMEI                     '品目ﾏｽﾀ        .品名
        XPROD_LINE                  '在庫情報       .生産ﾗｲﾝ№
        XPROD_LINE_DSP              '在庫情報       .生産ﾗｲﾝ№(表示用)
        XMAKER_CD                   '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        FTR_VOL                     '在庫情報       .搬送管理量(積込数)
        FDISP_ADDRESS               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        FARRIVE_DT                  '在庫情報       .在庫発生日時
        XARTICLE_TYPE_CODE          '在庫情報       .商品区分
        XARTICLE_TYPE_CODE_DSP      '在庫情報       .商品区分(表示用)
        XKENSA_KUBUN                '在庫情報       .検査区分
        XKENSA_KUBUN_DSP            '在庫情報       .検査区分(表示用)
        FHORYU_KUBUN                '在庫情報       .保留区分
        FHORYU_KUBUN_DSP            '在庫情報       .保留区分(表示用)
        XKENPIN_KUBUN               '在庫情報       .検品区分
        XKENPIN_KUBUN_DSP           '在庫情報       .検品区分(表示用)
        FIN_KUBUN                   '在庫情報       .入庫区分
        FIN_KUBUN_DSP               '在庫情報       .入庫区分(表示用)
        FLOT_NO                     '在庫情報       .ﾛｯﾄ№
        FPALLET_ID                  '在庫情報       .ﾊﾟﾚｯﾄID
        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値
        'JobMate:S.Ouchi 2013/11/01 在庫詳細問合せ画面 ﾒｰｶｰｺｰﾄﾞ移動
        '↑↑↑↑↑↑************************************************************************************************************

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        Print_Click                 '印刷ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' ｵｰﾅｰﾌｫｰﾑ
    '======================================
    Public Property userOWNER() As FRM_204010
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_204010)
            mobjOwner = Value
        End Set
    End Property
    '======================================
    ' 保管場所ｺｰﾄﾞ
    '======================================
    Public Property userFPLACE_CD() As String
        Get
            Return mstrFPLACE_CD
        End Get
        Set(ByVal value As String)
            mstrFPLACE_CD = value
        End Set
    End Property
    '======================================
    ' 保管場所名
    '======================================
    Public Property userFPLACE_NM() As String
        Get
            Return mstrFPLACE_NM
        End Get
        Set(ByVal value As String)
            mstrFPLACE_NM = value
        End Set
    End Property
    '======================================
    ' 品名ｺｰﾄﾞ
    '======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property
    '======================================
    ' 品名
    '======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property
    '======================================
    ' 生産ﾗｲﾝ№
    '======================================
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
        End Set
    End Property
    '======================================
    ' 生産ﾗｲﾝ№名称
    '======================================
    Public Property userXPROD_LINE_NM() As String
        Get
            Return mstrXPROD_LINE_NM
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE_NM = value
        End Set
    End Property
    '======================================
    ' ｸﾚｰﾝ
    '======================================
    Public Property userFEQ_ID_CRANE() As String
        Get
            Return mstrFEQ_ID_CRANE
        End Get
        Set(ByVal value As String)
            mstrFEQ_ID_CRANE = value
        End Set
    End Property
    '======================================
    ' 商品区分
    '======================================
    Public Property userXARTICLE_TYPE_CODE() As String
        Get
            Return mstrXARTICLE_TYPE_CODE
        End Get
        Set(ByVal value As String)
            mstrXARTICLE_TYPE_CODE = value
        End Set
    End Property
    '======================================
    ' 商品区分名称
    '======================================
    Public Property userXARTICLE_TYPE_CODE_NM() As String
        Get
            Return mstrXARTICLE_TYPE_CODE_NM
        End Get
        Set(ByVal value As String)
            mstrXARTICLE_TYPE_CODE_NM = value
        End Set
    End Property
    '======================================
    ' 検査区分
    '======================================
    Public Property userXKENSA_KUBUN() As String
        Get
            Return mstrXKENSA_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXKENSA_KUBUN = value
        End Set
    End Property
    '======================================
    ' 検査区分名称
    '======================================
    Public Property userXKENSA_KUBUN_NM() As String
        Get
            Return mstrXKENSA_KUBUN_NM
        End Get
        Set(ByVal value As String)
            mstrXKENSA_KUBUN_NM = value
        End Set
    End Property
    '======================================
    ' 保留区分
    '======================================
    Public Property userFHORYU_KUBUN() As String
        Get
            Return mstrFHORYU_KUBUN
        End Get
        Set(ByVal value As String)
            mstrFHORYU_KUBUN = value
        End Set
    End Property
    '======================================
    ' 保留区分名称
    '======================================
    Public Property userFHORYU_KUBUN_NM() As String
        Get
            Return mstrFHORYU_KUBUN_NM
        End Get
        Set(ByVal value As String)
            mstrFHORYU_KUBUN_NM = value
        End Set
    End Property
    '======================================
    ' 入庫日(FROM)
    '======================================
    Public Property userFARRIVE_DT_FROM() As String
        Get
            Return mstrFARRIVE_DT_FROM
        End Get
        Set(ByVal value As String)
            mstrFARRIVE_DT_FROM = value
        End Set
    End Property
    '======================================
    ' 入庫日(TO)
    '======================================
    Public Property userFARRIVE_DT_TO() As String
        Get
            Return mstrFARRIVE_DT_TO
        End Get
        Set(ByVal value As String)
            mstrFARRIVE_DT_TO = value
        End Set
    End Property
    '======================================
    ' ｸﾚｰﾝ名
    '======================================
    Public Property userCRANE() As String
        Get
            Return mstrCRANE
        End Get
        Set(ByVal value As String)
            mstrCRANE = value
        End Set
    End Property
    '======================================
    ' 検品区分
    '======================================
    Public Property userXKENPIN_KUBUN() As String
        Get
            Return mstrXKENPIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXKENPIN_KUBUN = value
        End Set
    End Property
    '======================================
    ' 入庫区分
    '======================================
    Public Property userFIN_KUBUN() As String
        Get
            Return mstrFIN_KUBUN
        End Get
        Set(ByVal value As String)
            mstrFIN_KUBUN = value
        End Set
    End Property

#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ


        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F6(印刷)         ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call printOut()


    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        Me.Close()

    End Sub
#End Region
#Region "　ﾘｽﾄ表示　                                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()


        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/01 在庫詳細問合せ画面 ﾒｰｶｰｺｰﾄﾞ移動
        '' ''strSQL &= vbCrLf & " SELECT "
        '' ''strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '' ''strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                             'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        ' '' ''↓↓↓↓↓↓************************************************************************************************************
        ' '' ''SystemMate:H.Okumura 2013/06/05 ｸﾞﾘｯﾄﾞ項目変更
        '' ''strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                           '品目ﾏｽﾀ        .品名記号
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                          '在庫情報       .品名ｺｰﾄﾞ
        ' '' ''↑↑↑↑↑↑************************************************************************************************************
        '' ''strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                              '品目ﾏｽﾀ        .品名
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                          '在庫情報       .生産ﾗｲﾝ№
        '' ''strSQL &= vbCrLf & "     , HASH01.XPROD_LINE_NAME AS XPROD_LINE_DSP "       '在庫情報       .生産ﾗｲﾝ№(表示用)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                             '在庫情報       .搬送管理量(積込数)
        '' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                          '在庫情報       .在庫発生日時
        ' '' ''↓↓↓↓↓↓************************************************************************************************************
        ' '' ''SystemMate:H.Okumura 2013/06/11 ｸﾞﾘｯﾄﾞ項目変更
        '' ''strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                   '品目ﾏｽﾀ        .商品区分
        '' ''strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "   '品目ﾏｽﾀ        .商品区分(表示用)
        ' '' ''↑↑↑↑↑↑************************************************************************************************************
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                        '在庫情報       .検査区分
        '' ''strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "         '在庫情報       .検査区分(表示用)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                        '在庫情報       .保留区分
        '' ''strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "         '在庫情報       .保留区分(表示用)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                       '在庫情報       .検品区分
        '' ''strSQL &= vbCrLf & "     , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "        '在庫情報       .検品区分(表示用)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FIN_KUBUN "                           '在庫情報       .入庫区分
        '' ''strSQL &= vbCrLf & "     , HASH06.FGAMEN_DISP AS FIN_KUBUN_DSP "            '在庫情報       .入庫区分(表示用)
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.XMAKER_CD "                           '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                             '在庫情報       .ﾛｯﾄ№
        '' ''strSQL &= vbCrLf & "     , TRST_STOCK.FPALLET_ID "                          '在庫情報       .ﾊﾟﾚｯﾄID

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                             'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                           '品目ﾏｽﾀ        .品名記号
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                          '在庫情報       .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                              '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                          '在庫情報       .生産ﾗｲﾝ№
        strSQL &= vbCrLf & "     , HASH01.XPROD_LINE_NAME AS XPROD_LINE_DSP "       '在庫情報       .生産ﾗｲﾝ№(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XMAKER_CD "                           '在庫情報       .ﾒｰｶｰｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                             '在庫情報       .搬送管理量(積込数)
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                          '在庫情報       .在庫発生日時
        strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                   '品目ﾏｽﾀ        .商品区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "   '品目ﾏｽﾀ        .商品区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                        '在庫情報       .検査区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENSA_KUBUN_DSP "         '在庫情報       .検査区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                        '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS FHORYU_KUBUN_DSP "         '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                       '在庫情報       .検品区分
        strSQL &= vbCrLf & "     , HASH05.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "        '在庫情報       .検品区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FIN_KUBUN "                           '在庫情報       .入庫区分
        strSQL &= vbCrLf & "     , HASH06.FGAMEN_DISP AS FIN_KUBUN_DSP "            '在庫情報       .入庫区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                             '在庫情報       .ﾛｯﾄ№
        strSQL &= vbCrLf & "     , TRST_STOCK.FPALLET_ID "                          '在庫情報       .ﾊﾟﾚｯﾄID
        'JobMate:S.Ouchi 2013/11/01 在庫詳細問合せ画面 ﾒｰｶｰｺｰﾄﾞ移動
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "     , TRST_STOCK "
        strSQL &= vbCrLf & "     , TMST_ITEM "
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom02("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "FIN_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                 '引当状態：在庫
        strSQL &= vbCrLf & "     AND TO_CHAR(TPRG_TRK_BUF.FPALLET_ID) = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TO_NUMBER(TPRG_TRK_BUF.FTRK_BUF_NO) = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND TO_CHAR(TRST_STOCK.FHINMEI_CD) = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02_TO_CHAR("HASH01", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01_TO_NUMBER("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01_TO_CHAR("HASH03", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01_TO_NUMBER("HASH04", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01_TO_CHAR("HASH05", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01_TO_NUMBER("HASH06", "TRST_STOCK", "FIN_KUBUN")

        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        If mstrFPLACE_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mstrFPLACE_CD
        Else
            '(全検索の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J9000 & "," & FTRK_BUF_NO_J9100 & "," & FTRK_BUF_NO_J9200 & ") "
        End If
        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mstrFHINMEI_CD <> "" Then
            If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞ)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mstrFHINMEI_CD & "' "
            Else
                '(品名記号)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & mstrFHINMEI_CD & "' "
            End If

        End If

        '----------------------------
        '入庫日
        '----------------------------
        If mstrFARRIVE_DT_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mstrFARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mstrFARRIVE_DT_TO <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mstrFARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------
        '生産ﾗｲﾝNo.
        '----------------------------
        If mstrXPROD_LINE <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mstrXPROD_LINE & "' "
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/11 ｸﾚｰﾝ追加
        '----------------------------
        'ｸﾚｰﾝ
        '----------------------------
        If mstrFEQ_ID_CRANE <> "" Then
            '(全検索以外の場合)

            '**********************************************************
            ' 対象列の特定
            '**********************************************************
            Dim objTBL_TMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)
            objTBL_TMST_CRANE.FEQ_ID = mstrFEQ_ID_CRANE   '設備ID
            objTBL_TMST_CRANE.GET_TMST_CRANE(False)

            Dim strRETU1 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW1)   '列1
            Dim strRETU2 As String = TO_STRING(objTBL_TMST_CRANE.FCRANE_ROW2)   '列2

            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU IN ( " & strRETU1 & ", " & strRETU2 & ") "

            objTBL_TMST_CRANE.Close()

        End If
        '↑↑↑↑↑↑************************************************************************************************************




        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 商品区分追加
        '----------------------------
        '商品区分
        '----------------------------
        If mstrXARTICLE_TYPE_CODE <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mstrXARTICLE_TYPE_CODE
        End If
        '↑↑↑↑↑↑************************************************************************************************************

        '----------------------------
        '検査区分
        '----------------------------
        If mstrXKENSA_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = '" & mstrXKENSA_KUBUN & "' "
        End If

        '----------------------------------------------
        '保留区分
        '----------------------------------------------
        If mstrFHORYU_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mstrFHORYU_KUBUN
        End If

        '----------------------------------------------
        '検品区分
        '----------------------------------------------
        If mstrXKENPIN_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.XKENPIN_KUBUN = '" & mstrXKENPIN_KUBUN & "' "
        End If

        '----------------------------------------------
        '入庫区分
        '----------------------------------------------
        If mstrFIN_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FIN_KUBUN = " & mstrFIN_KUBUN
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf

        '2013/08/22
        gobjComFuncFRM.AddToLog_frm(strSQL, AddToLog_D_ErrorType.USER_LOG, "")

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                True)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定　                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.Print_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
                End If


                blnCheckErr = False

        End Select

        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region
#Region "　印刷処理　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_204020_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀ取得
            '================================
            Dim strFHINMEI_CD As String = ""                    '品名記号
            Dim strXHINMEI_CD As String = ""                    '品名ｺｰﾄﾞ
            Dim objTBL_TMST_ITEM As TBL_TMST_ITEM = Nothing     '品名ﾏｽﾀ
            Dim intRet As Integer

            If mstrFHINMEI_CD <> "" Then
                If IsNumeric(mstrFHINMEI_CD.Substring(0, 1)) Then
                    '(品名ｺｰﾄﾞの場合)
                    strXHINMEI_CD = mstrFHINMEI_CD

                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.XHINMEI_CD = strXHINMEI_CD
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                    If intRet = RetCode.OK Then
                        strFHINMEI_CD = objTBL_TMST_ITEM.FHINMEI_CD
                    End If

                Else
                    '(品名記号の場合)
                    strFHINMEI_CD = mstrFHINMEI_CD

                    objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                    objTBL_TMST_ITEM.FHINMEI_CD = strFHINMEI_CD
                    intRet = objTBL_TMST_ITEM.GET_TMST_ITEM()
                    If intRet = RetCode.OK Then
                        strXHINMEI_CD = objTBL_TMST_ITEM.XHINMEI_CD
                    End If
                End If

            End If

            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))     '発行日時

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '' ''Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mstrFPLACE_NM)                  '在庫ｴﾘｱ
            If mstrFPLACE_NM = "" Then
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", "自動倉庫、平置、検品エリア")   '在庫ｴﾘｱ
            Else
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mstrFPLACE_NM)                  '在庫ｴﾘｱ
            End If
            'JobMate:S.Ouchi 2013/11/06 在庫ﾘｽﾄでの在庫ｴﾘｱの表示
            '↑↑↑↑↑↑************************************************************************************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", strXHINMEI_CD)                  '品名ｺｰﾄﾞ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", mstrFHINMEI)                    '品名
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", strFHINMEI_CD)                  '品名記号
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", mstrFARRIVE_DT_FROM)            '在庫発生日時
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", mstrFARRIVE_DT_TO)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText07", mstrXPROD_LINE)                 '生産ﾗｲﾝNo.
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText08", mstrCRANE)                      'ｸﾚｰﾝ
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText09", mstrXARTICLE_TYPE_CODE_NM)      '商品区分
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText10", mstrXKENSA_KUBUN_NM)            '検査区分
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText11", mstrFHORYU_KUBUN_NM)            '保留区分

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
            Dim intNumber As Integer = 0                                                        '№
            'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
            '↑↑↑↑↑↑************************************************************************************************************

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
                intNumber += 1                                                                      '№
                'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
                '↑↑↑↑↑↑************************************************************************************************************

                '*明細項目(表示)
                objDataRow.Data10 = grdList.Item(menmListCol.FBUF_NAME, ii).FormattedValue          '在庫ｴﾘｱ
                objDataRow.Data11 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue         '品名ｺｰﾄﾞ
                objDataRow.Data12 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue         '品名記号
                objDataRow.Data13 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue            '品名
                objDataRow.Data14 = grdList.Item(menmListCol.FLOT_NO, ii).FormattedValue            'ﾛｯﾄ№
                objDataRow.Data15 = grdList.Item(menmListCol.XPROD_LINE_DSP, ii).FormattedValue     '生産ﾗｲﾝ№
                objDataRow.Data16 = grdList.Item(menmListCol.FARRIVE_DT, ii).FormattedValue         '在庫発生日時
                objDataRow.Data17 = grdList.Item(menmListCol.FTR_VOL, ii).FormattedValue            '数量
                objDataRow.Data18 = grdList.Item(menmListCol.XKENSA_KUBUN_DSP, ii).FormattedValue   '検査区分
                objDataRow.Data19 = grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).FormattedValue   '保留区分
                objDataRow.Data20 = grdList.Item(menmListCol.XKENPIN_KUBUN_DSP, ii).FormattedValue  '検品区分
                objDataRow.Data21 = grdList.Item(menmListCol.FIN_KUBUN_DSP, ii).FormattedValue      '入庫区分
                objDataRow.Data22 = grdList.Item(menmListCol.XMAKER_CD, ii).FormattedValue          'ﾒｰｶｰｺｰﾄﾞ
                objDataRow.Data23 = grdList.Item(menmListCol.FDISP_ADDRESS, ii).FormattedValue         'ﾛｹｰｼｮﾝ
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
                objDataRow.Data24 = TO_STRING(intNumber)                                            '№
                'JobMate:S.Ouchi 2013/11/06 在庫詳細ﾘｽﾄでの№表示
                '↑↑↑↑↑↑************************************************************************************************************

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
