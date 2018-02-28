'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷引当て画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308050

#Region "　共通変数　                               "

    'Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mstrXHIKIATE_DT As String                   '出荷引当日時

    Private mblnNodata As Boolean                       'ﾉｰﾃﾞｰﾀ時MSG表示有無

    Private mblnKARICHU_BLINK As Boolean                '「仮引当中処理中」ﾌﾞﾘﾝｸ用

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        FHINMEI_CD                          '引当情報.      品名ｺｰﾄﾞ
        FHINMEI                             '品目ﾏｽﾀ.       品名
        XSEIZOU_DT                          '引当情報.      製造年月日
        XHINSHITU_STS                       '引当情報.      品質ｽﾃｰﾀｽ(非表示)
        ASOUKO_ZAIKO_SU                     '在庫情報.      在庫数
        ASOUKO_HIKIATE_SU                   '引当情報.      引当数
        HIRA_ZAIKO_SU                       '在庫情報.      在庫数
        HIRA_HIKIATE_SU                     '引当情報.      引当数
        GAIBU_ZAIKO_SU                      '在庫情報.      在庫数
        GAIBU_HIKIATE_SU                    '引当情報.      引当数

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum


    'ｸﾞﾘｯﾄﾞ項目(欠品ﾘｽﾄ)
    Enum menmListCol2

        XSYUKKA_DT                          '仮引当欠品情報.      出荷日
        XSYUKKA_DT_DSP                      '仮引当欠品情報.      出荷日(表示用)
        XORDER_NO                           '仮引当欠品情報.      発注№
        XNYUKA_JIGYOU_NM                    '仮引当欠品情報.      配送先
        FHINMEI_CD                          '仮引当欠品情報.      品目ｺｰﾄﾞ
        FHINMEI                             '仮引当欠品情報.      品名
        XSEIZOU_DT                          '仮引当欠品情報.      製造年月日
        XSEIZOU_DT_DSP                      '仮引当欠品情報.      製造年月日(表示用)
        XHIDUKE_SITEI_KUBUN                 '仮引当欠品情報.      日付指定区分
        XHIDUKE_SITEI_KUBUN_DSP             '仮引当欠品情報.      日付指定区分(表示用)
        XHINSHITU_STS                       '仮引当欠品情報.      品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP                   '仮引当欠品情報.      品質ｽﾃｰﾀｽ(表示用)
        XSYUKKA_VOL                         '仮引当欠品情報.      出荷数
        XKEPPIN_VOL                         '仮引当欠品情報.      欠品数
        XHORYU_FLAG                         '仮引当欠品情報.      保留ﾌﾗｸﾞ
        XHORYU_FLAG_DSP                     '仮引当欠品情報.      保留ﾌﾗｸﾞ(表示用)

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum



    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        Kari_HikiateBtn_Click       '仮引当てﾎﾞﾀﾝｸﾘｯｸ時
        DtlBtn_Click                '引当詳細ﾎﾞﾀﾝｸﾘｯｸ
        ConfirmBtn_Click            '引当確定ﾎﾞﾀﾝｸﾘｯｸ
        ReleaseBtn_Click            '引当解除ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  構造体定義                               "
    ''検索条件
    'Protected Structure stcSEARCH_ITEM
    '    Dim XSYUKKA_NO As String                         '出荷№
    '    Dim XSYUKKA_DT As String                         '出荷日
    '    Dim XNYUKA_JIGYOU_CD As String                   '入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
    '    Dim XIDOU_CD As String                           '移動手段ｺｰﾄﾞ
    '    Dim XGYOSHA_CD As String                         '業者ｺｰﾄﾞ
    'End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　表示更新    ﾀｲﾏ(ｸﾞﾘｯﾄﾞ表示)              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新    ﾀｲﾏ(ｸﾞﾘｯﾄﾞ表示)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308050_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr308050.Tick
        Try

            '**************************************************
            ' 表示更新処理
            '**************************************************
            Call tmr308050_TickProcess(0)

        Catch ex As Exception
            ComError(ex)

        Finally

        End Try
    End Sub
#End Region
#Region "　表示更新    ﾀｲﾏ(仮引当処理中)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新    ﾀｲﾏ(仮引当処理中)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308050_2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr308050_2.Tick
        Try

            '**************************************************
            ' 表示更新処理
            '**************************************************
            Call tmr308050_2_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally

        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr308050.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS308050_001))
        tmr308050.Enabled = False

        tmr308050_2.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS308050_002))
        tmr308050_2.Enabled = False


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblHIKIATE_ORDER_SU.Text = ""       '引当出荷ｵｰﾀﾞ数

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        mFlag_Form_Load = False


        '**************************************************
        ' 表示更新処理
        '**************************************************
        Call tmr308050_TickProcess(1)


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        lblHIKIATE_ORDER_SU.Dispose()    '引当出荷ｵｰﾀﾞ数
        grdList.Dispose()                'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(仮引当て)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Kari_HikiateBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If Socket01_KariHikiate() = False Then                   '仮引当て
            Exit Sub
        End If


        '**************************************************
        ' 表示更新処理
        '**************************************************
        Call tmr308050_TickProcess(2)

    End Sub
#End Region
#Region "  F4(引当詳細)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.DtlBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308051) = False Then
            gobjFRM_308051.Close()
            gobjFRM_308051.Dispose()
            gobjFRM_308051 = Nothing
        End If

        '********************************************************************
        ' 詳細画面ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_308051 = New FRM_308051                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308051, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308051.ShowDialog()        '画面表示


        '**********************************************************
        ' 引当出荷ｵｰﾀﾞ数 表示
        '**********************************************************
        Call Hikiate_Order_SU_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        mblnNodata = True
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F5(引当確定)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.ConfirmBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If Socket01_HikiateKakutei() = False Then                   '引当確定
            Exit Sub
        End If


        '*********************************************
        ' 出荷予定ﾘｽﾄ出力
        '*********************************************
        Call printOut()


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblHIKIATE_ORDER_SU.Text = ""       '引当出荷ｵｰﾀﾞ数

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

    End Sub
#End Region
#Region "  F6(引当解除)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.ReleaseBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If Socket01_HikiateKaijyo() = False Then                   '引当解除
            Exit Sub
        End If

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblHIKIATE_ORDER_SU.Text = ""       '引当出荷ｵｰﾀﾞ数

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        Me.tmr308050.Dispose()
        Me.tmr308050_2.Dispose()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)

    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        ''********************************************************************
        ''構造体に値をｾｯﾄ
        ''********************************************************************
        'mudtSEARCH_ITEM.XSYUKKA_NO = TO_STRING(cboXSYUKKA_NO.SelectedValue)                        '出荷№
        'mudtSEARCH_ITEM.XSYUKKA_DT = TO_STRING(cboXSYUKKA_DT.SelectedValue)                        '出荷日
        'mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD = cboXNYUKA_JIGYOU_CD.Text                                '入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        'mudtSEARCH_ITEM.XIDOU_CD = TO_STRING(cboXIDOU_CD.SelectedValue)                            '移動手段ｺｰﾄﾞ
        'mudtSEARCH_ITEM.XGYOSHA_CD = TO_STRING(cboXGYOSHA_CD.SelectedValue)                        '業者ｺｰﾄﾞ

    End Sub
#End Region
#Region "　引当出荷ｵｰﾀﾞ数ｾｯﾄ                        "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Hikiate_Order_SU_Set()


        lblHIKIATE_ORDER_SU.Text = ""


        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     COUNT(0) AS HIKIATE_ORDER_SU "
        'strSQL &= vbCrLf & " FROM "
        'strSQL &= vbCrLf & "     XPLN_OUT_DTL "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_OUT "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE_DUMMY
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            lblHIKIATE_ORDER_SU.Text = TO_STRING(TO_DECIMAL(objRow("HIKIATE_ORDER_SU")))
        Else
            '(見つからない場合)
            lblHIKIATE_ORDER_SU.Text = ""
        End If

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
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     C.FHINMEI_CD "                                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , C.FHINMEI "                                    '品名
        strSQL &= vbCrLf & "   , C.XSEIZOU_DT "                                 '製造年月日
        strSQL &= vbCrLf & "   , C.XHINSHITU_STS "                              '品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , C.ZAIKO_ASOUKO "                               '自動倉庫・在庫数
        strSQL &= vbCrLf & "   , C.HIKIATE_ASOUKO "                             '自動倉庫・引当数
        strSQL &= vbCrLf & "   , C.ZAIKO_HIRA "                                 '平置き・在庫数
        strSQL &= vbCrLf & "   , C.HIKIATE_HIRA "                               '平置き・引当数
        strSQL &= vbCrLf & "   , C.ZAIKO_GAIBU "                                '外部倉庫・在庫数
        strSQL &= vbCrLf & "   , C.HIKIATE_GAIBU "                              '外部倉庫・引当数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   ( "


        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     B.FHINMEI_CD "                                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , B.FHINMEI "                                    '品名
        strSQL &= vbCrLf & "   , B.XSEIZOU_DT "                                 '製造年月日
        strSQL &= vbCrLf & "   , B.XHINSHITU_STS "                              '品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , TRUNC(B.ZAIKO_ASOUKO   / TMST_ITEM.FNUM_IN_PALLET) AS ZAIKO_ASOUKO "   '自動倉庫・在庫数
        strSQL &= vbCrLf & "   , TRUNC(B.HIKIATE_ASOUKO / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_ASOUKO " '自動倉庫・引当数
        strSQL &= vbCrLf & "   , TRUNC(B.ZAIKO_HIRA     / TMST_ITEM.FNUM_IN_PALLET) AS ZAIKO_HIRA "     '平置き・在庫数
        strSQL &= vbCrLf & "   , TRUNC(B.HIKIATE_HIRA   / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_HIRA "   '平置き・引当数
        strSQL &= vbCrLf & "   , TRUNC(B.ZAIKO_GAIBU    / TMST_ITEM.FNUM_IN_PALLET) AS ZAIKO_GAIBU "    '外部倉庫・在庫数
        strSQL &= vbCrLf & "   , TRUNC(B.HIKIATE_GAIBU  / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU "  '外部倉庫・引当数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   TMST_ITEM "      '品名ﾏｽﾀ
        strSQL &= vbCrLf & " , ( "

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     A.FHINMEI_CD "                                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , A.FHINMEI "                                    '品名
        strSQL &= vbCrLf & "   , A.XSEIZOU_DT "                                 '製造年月日
        strSQL &= vbCrLf & "   , A.XHINSHITU_STS "                              '品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , SUM(A.ZAIKO_ASOUKO)   AS ZAIKO_ASOUKO "        '自動倉庫・在庫数
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_ASOUKO) AS HIKIATE_ASOUKO "      '自動倉庫・引当数
        strSQL &= vbCrLf & "   , SUM(A.ZAIKO_HIRA)     AS ZAIKO_HIRA "          '平置き・在庫数
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_HIRA)   AS HIKIATE_HIRA "        '平置き・引当数
        strSQL &= vbCrLf & "   , SUM(A.ZAIKO_GAIBU)    AS ZAIKO_GAIBU "         '外部倉庫・在庫数
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU)  AS HIKIATE_GAIBU "       '外部倉庫・引当数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   ( "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , SUM(FTR_VOL)       AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "      , 0                  AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "      , 0                  AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "      , 0                  AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "      , 0                  AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "      , 0                  AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        TRST_STOCK "
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "      , TMST_ITEM "
        strSQL &= vbCrLf & "      , TMST_CRANE "                          'ｸﾚｰﾝﾏｽﾀ
        strSQL &= vbCrLf & "      , TSTS_EQ_CTRL "                        '設備状況

        strSQL &= vbCrLf & "    WHERE "
        strSQL &= vbCrLf & "          TRST_STOCK.FPALLET_ID    = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND TRST_STOCK.FHINMEI_CD    = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND NVL(TRST_STOCK.FHASU_FLAG, 0) = " & FHASU_FLAG_SMANSU     '満数
        strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID NOT IN(SELECT FPALLET_ID FROM XSTS_HIKIATE_K2 WHERE FSAGYOU_KIND = 51) "
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000          '自動倉庫
        strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID NOT IN( "                           '在庫棚(未引当)
        strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                      ) "
        strSQL &= vbCrLf & "      AND TRST_STOCK.FPALLET_ID NOT IN( "                           '在庫棚(未引当)
        strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                      ) "
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "       '列1
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "       '列2
        strSQL &= vbCrLf & "      AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "          '設備ID
        strSQL &= vbCrLf & "      AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF              '切離状態 = 通常

        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "

        strSQL &= vbCrLf & "    UNION "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "      , SUM(XSTS_HIKIATE_K2.FTR_VOL)   AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        XSTS_HIKIATE_K2 "       '在庫引当情報_仮２
        strSQL &= vbCrLf & "      , XRST_STOCK_K2 "         '在庫情報_仮２
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "      , TMST_ITEM "             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "    WHERE 1 = 1"
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = XRST_STOCK_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XRST_STOCK_K2.FHINMEI_CD     = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FSAGYOU_KIND = " & FSAGYOU_KIND_SOUT            '計画出庫
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO     = " & FTRK_BUF_NO_J9000            '自動倉庫
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "

        strSQL &= vbCrLf & "    UNION "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    SELECT  "
        strSQL &= vbCrLf & "         H2.FHINMEI_CD "
        strSQL &= vbCrLf & "       , H2.FHINMEI "
        strSQL &= vbCrLf & "       , H2.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , H2.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , 0                               	 AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "       , 0                                   AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "       , (H2.FTR_VOL - H2.ZAIKO_HIKIATEZUMI) AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "       , 0                                   AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "       , 0                                   AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "       , 0                                   AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    ( "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "         H1.FHINMEI_CD "
        strSQL &= vbCrLf & "       , H1.FHINMEI "
        strSQL &= vbCrLf & "       , H1.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , H1.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , MAX(H1.FTR_VOL)       AS FTR_VOL "
        strSQL &= vbCrLf & "       , SUM(NVL(XRST_OUT.FTR_VOL, 0)) AS ZAIKO_HIKIATEZUMI "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "      ("
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        'strSQL &= vbCrLf & "      , 0         	 AS ZAIKO_ASOUKO "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_ASOUKO "
        'strSQL &= vbCrLf & "      , SUM(FTR_VOL) AS ZAIKO_HIRA "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_HIRA "
        'strSQL &= vbCrLf & "      , 0            AS ZAIKO_GAIBU "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "      , SUM(TRST_STOCK.FTR_VOL) AS FTR_VOL "
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        TRST_STOCK "
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "      , TMST_ITEM "
        strSQL &= vbCrLf & "    WHERE "
        strSQL &= vbCrLf & "           TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND  NVL(TRST_STOCK.FHASU_FLAG, 0) = " & FHASU_FLAG_SMANSU      '満数
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN(SELECT FPALLET_ID FROM XSTS_HIKIATE_K2 WHERE FSAGYOU_KIND = 51) "
        strSQL &= vbCrLf & "      AND  TPRG_TRK_BUF.FTRK_BUF_NO      = " & FTRK_BUF_NO_J8001      '1F平置き
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                   (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                       ) "
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                   (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                       ) "
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "      ) H1 "
        strSQL &= vbCrLf & "      LEFT JOIN "
        strSQL &= vbCrLf & "        XRST_OUT "
        strSQL &= vbCrLf & "    ON 1 = 1 "
        strSQL &= vbCrLf & "        AND XRST_OUT.FTRK_BUF_NO     = " & FTRK_BUF_NO_J8001          '1F平置き
        strSQL &= vbCrLf & "        AND XRST_OUT.XPALLET_ID_KARI = '###' "
        strSQL &= vbCrLf & "        AND XRST_OUT.FHINMEI_CD      = H1.FHINMEI_CD "
        strSQL &= vbCrLf & "        AND XRST_OUT.XSEIZOU_DT      = H1.XSEIZOU_DT "
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "         H1.FHINMEI_CD "
        strSQL &= vbCrLf & "       , H1.FHINMEI "
        strSQL &= vbCrLf & "       , H1.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , H1.XHINSHITU_STS "
        strSQL &= vbCrLf & "    ) H2 "
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        strSQL &= vbCrLf & "    UNION "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "      , SUM(XSTS_HIKIATE_K2.FTR_VOL)   AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        XSTS_HIKIATE_K2 "       '在庫引当情報_仮２
        strSQL &= vbCrLf & "      , XRST_STOCK_K2 "         '在庫情報_仮２
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "      , TMST_ITEM "             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "    WHERE 1 = 1"
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = XRST_STOCK_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XRST_STOCK_K2.FHINMEI_CD     = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FSAGYOU_KIND = " & FSAGYOU_KIND_SOUT           '計画出庫
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO     = " & FTRK_BUF_NO_J8001           '1F平置き
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "

        strSQL &= vbCrLf & "    UNION "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    SELECT  "
        strSQL &= vbCrLf & "        G2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , G2.FHINMEI "
        strSQL &= vbCrLf & "      , G2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , G2.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , 0                               	 AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "      , 0                                   AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "      , 0                                   AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "      , 0                                   AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "      , (G2.FTR_VOL - G2.ZAIKO_HIKIATEZUMI) AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "      , 0                                   AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "     ( "
        strSQL &= vbCrLf & "      SELECT "
        strSQL &= vbCrLf & "          G1.FHINMEI_CD "
        strSQL &= vbCrLf & "        , G1.FHINMEI "
        strSQL &= vbCrLf & "        , G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "        , G1.XHINSHITU_STS "
        strSQL &= vbCrLf & "        , MAX(G1.FTR_VOL)              AS FTR_VOL "
        strSQL &= vbCrLf & "        , SUM(NVL(XRST_OUT.FTR_VOL,0)) AS ZAIKO_HIKIATEZUMI "
        strSQL &= vbCrLf & "      FROM "
        strSQL &= vbCrLf & "     ("
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        'strSQL &= vbCrLf & "      , 0         	 AS ZAIKO_ASOUKO "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_ASOUKO "
        'strSQL &= vbCrLf & "      , 0            AS ZAIKO_HIRA "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_HIRA "
        'strSQL &= vbCrLf & "      , SUM(FTR_VOL) AS ZAIKO_GAIBU "
        'strSQL &= vbCrLf & "      , 0            AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "      , SUM(TRST_STOCK.FTR_VOL) AS FTR_VOL "
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        TRST_STOCK "
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "      , TMST_ITEM "
        strSQL &= vbCrLf & "    WHERE "
        strSQL &= vbCrLf & "           TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND  NVL(TRST_STOCK.FHASU_FLAG, 0) = " & FHASU_FLAG_SMANSU          '満数
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN(SELECT FPALLET_ID FROM XSTS_HIKIATE_K2 WHERE FSAGYOU_KIND = 51) "
        strSQL &= vbCrLf & "      AND  TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J8100 & ", " _
                                                                      & FTRK_BUF_NO_J8101 & ", " _
                                                                      & FTRK_BUF_NO_J8102 & ", " _
                                                                      & FTRK_BUF_NO_J8103 & ", " _
                                                                      & FTRK_BUF_NO_J8104 & ", " _
                                                                      & FTRK_BUF_NO_J8105 & ", " _
                                                                      & FTRK_BUF_NO_J8106 & ", " _
                                                                      & FTRK_BUF_NO_J8107 & ", " _
                                                                      & FTRK_BUF_NO_J8108 & ", " _
                                                                      & FTRK_BUF_NO_J8109 & ") "      '外部倉庫
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN( "                                '在庫棚(未引当)
        strSQL &= vbCrLf & "                   (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                       ) "
        strSQL &= vbCrLf & "      AND  TRST_STOCK.FPALLET_ID NOT IN( "                                '在庫棚(未引当)
        strSQL &= vbCrLf & "                   (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                       ) "
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , TRST_STOCK.XHINSHITU_STS "
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        strSQL &= vbCrLf & "    ) G1 "
        strSQL &= vbCrLf & "      LEFT JOIN "
        strSQL &= vbCrLf & "      XRST_OUT "
        strSQL &= vbCrLf & "    ON 1 = 1 "
        strSQL &= vbCrLf & "       AND  XRST_OUT.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J8100 & ", " _
                                                                   & FTRK_BUF_NO_J8101 & ", " _
                                                                   & FTRK_BUF_NO_J8102 & ", " _
                                                                   & FTRK_BUF_NO_J8103 & ", " _
                                                                   & FTRK_BUF_NO_J8104 & ", " _
                                                                   & FTRK_BUF_NO_J8105 & ", " _
                                                                   & FTRK_BUF_NO_J8106 & ", " _
                                                                   & FTRK_BUF_NO_J8107 & ", " _
                                                                   & FTRK_BUF_NO_J8108 & ", " _
                                                                   & FTRK_BUF_NO_J8109 & ") "      '外部倉庫
        strSQL &= vbCrLf & "       AND XRST_OUT.XPALLET_ID_KARI = '###' "
        strSQL &= vbCrLf & "       AND XRST_OUT.FHINMEI_CD      = G1.FHINMEI_CD "
        strSQL &= vbCrLf & "       AND XRST_OUT.XSEIZOU_DT      = G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "       G1.FHINMEI_CD "
        strSQL &= vbCrLf & "     , G1.FHINMEI "
        strSQL &= vbCrLf & "     , G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "     , G1.XHINSHITU_STS "
        strSQL &= vbCrLf & "   ) G2 "
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        strSQL &= vbCrLf & "    UNION "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI AS FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_ASOUKO "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_HIRA "
        strSQL &= vbCrLf & "      , 0                              AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "      , 0                              AS ZAIKO_GAIBU "
        strSQL &= vbCrLf & "      , SUM(XSTS_HIKIATE_K2.FTR_VOL)   AS HIKIATE_GAIBU "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "        XSTS_HIKIATE_K2 "       '在庫引当情報_仮２
        strSQL &= vbCrLf & "      , XRST_STOCK_K2 "         '在庫情報_仮２
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "      , TMST_ITEM "             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "    WHERE 1 = 1"
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = XRST_STOCK_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FPALLET_ID   = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "      AND XRST_STOCK_K2.FHINMEI_CD     = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "      AND XSTS_HIKIATE_K2.FSAGYOU_KIND = " & FSAGYOU_KIND_SOUT              '計画出庫
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J8100 & ", " _
                                                                     & FTRK_BUF_NO_J8101 & ", " _
                                                                     & FTRK_BUF_NO_J8102 & ", " _
                                                                     & FTRK_BUF_NO_J8103 & ", " _
                                                                     & FTRK_BUF_NO_J8104 & ", " _
                                                                     & FTRK_BUF_NO_J8105 & ", " _
                                                                     & FTRK_BUF_NO_J8106 & ", " _
                                                                     & FTRK_BUF_NO_J8107 & ", " _
                                                                     & FTRK_BUF_NO_J8108 & ", " _
                                                                     & FTRK_BUF_NO_J8109 & ") "         '外部倉庫
        strSQL &= vbCrLf & "    GROUP BY "
        strSQL &= vbCrLf & "        XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , TMST_ITEM.FHINMEI "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_STOCK_K2.XHINSHITU_STS "

        strSQL &= vbCrLf & "   ) A "

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     FHINMEI_CD "
        strSQL &= vbCrLf & "   , FHINMEI "
        strSQL &= vbCrLf & "   , XSEIZOU_DT "
        strSQL &= vbCrLf & "   , XHINSHITU_STS "

        strSQL &= vbCrLf & "   ) B "
        '============================================================
        'WHERE 
        '============================================================
        strSQL &= vbCrLf & " WHERE  1 = 1 "
        strSQL &= vbCrLf & "   AND  B.FHINMEI_CD   = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "   ) C "

        '============================================================
        'WHERE 
        '============================================================
        strSQL &= vbCrLf & " WHERE  1 = 1 "
        strSQL &= vbCrLf & "   AND  ((C.HIKIATE_ASOUKO > 0) "        '自動倉庫・引当数 > 0
        strSQL &= vbCrLf & "      OR (C.HIKIATE_HIRA   > 0) "        '平置き・引当数   > 0
        strSQL &= vbCrLf & "      OR (C.HIKIATE_GAIBU  > 0)) "       '外部倉庫・引当数 > 0

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        If mblnNodata = False Then
            '(ﾉｰﾃﾞｰﾀの時、MSG無し)
            Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                    strSQL, _
                                    False)
        Else
            '(ﾉｰﾃﾞｰﾀの時、MSGあり)
            Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                    strSQL, _
                                    True)
        End If

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
        'grdList.AllowUserToResizeColumns = False
   
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

        Select Case udtCheck_Case
            Case menmCheckCase.Kari_HikiateBtn_Click
                '(仮引当てﾎﾞﾀﾝｸﾘｯｸ時)

                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                Dim intSYS061 As Integer = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_061))

                If intSYS061 = FLAG_ON Then
                    '(仮引当ﾎﾞﾀﾝ押下ﾌﾗｸﾞが押されている時[処理中])
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_13, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '==========================
                '仮引当中 ﾁｪｯｸ  ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ表示のみ
                '==========================
                Dim objXPLN_OUT As TBL_XPLN_OUT                           '出荷計画
                objXPLN_OUT = New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
                objXPLN_OUT.XPROGRESS_OUT = XPROGRESS_OUT_JHIKIATE_DUMMY  '進捗状態 = 仮引当(1)
                If objXPLN_OUT.GET_XPLN_OUT_COUNT > 0 Then
                    '(仮引当されている時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_11, PopupFormType.Ok, PopupIconType.Information)
                    'blnCheckErr = True
                    'Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.DtlBtn_Click
                '(詳細ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.ConfirmBtn_Click
                '(引当確定ﾎﾞﾀﾝｸﾘｯｸ時)

                ''==========================
                ''ﾘｽﾄ表示ﾁｪｯｸ
                ''==========================
                'If grdList.Rows.Count = 0 Then
                '    '(ﾘｽﾄ表示ない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_07, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select

                'End If

                '==========================
                '引当出荷ｵｰﾀﾞ数ﾁｪｯｸ
                '==========================
                If TO_INTEGER(lblHIKIATE_ORDER_SU.Text) = 0 Then
                    '(引当出荷ｵｰﾀﾞ数がない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_07, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.ReleaseBtn_Click
                '(引当解除ﾎﾞﾀﾝｸﾘｯｸ時)

                ' ''==========================
                ' ''ﾘｽﾄ表示ﾁｪｯｸ
                ' ''==========================
                ''If grdList.Rows.Count = 0 Then
                ''    '(ﾘｽﾄ表示ない場合)
                ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_07, PopupFormType.Ok, PopupIconType.Information)
                ''    blnCheckErr = True
                ''    Exit Select

                ''End If


                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                Dim intSYS061 As Integer = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_061))

                If intSYS061 = FLAG_ON Then
                    '(仮引当ﾎﾞﾀﾝ押下ﾌﾗｸﾞが押されている時[処理中])
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_15, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If



                '==========================
                '引当ﾁｪｯｸ
                '==========================
                Dim objXPLN_OUT_DTL_1 As TBL_XPLN_OUT_DTL                           '出荷計画詳細
                objXPLN_OUT_DTL_1 = New TBL_XPLN_OUT_DTL(gobjOwner, gobjDb, Nothing)
                objXPLN_OUT_DTL_1.XPROGRESS_OUT = XPROGRESS_OUT_JHIKIATE_DUMMY      '進捗状態 = 仮引当(1)

                Dim objXPLN_OUT_DTL_2 As TBL_XPLN_OUT_DTL                           '出荷計画詳細
                objXPLN_OUT_DTL_2 = New TBL_XPLN_OUT_DTL(gobjOwner, gobjDb, Nothing)
                objXPLN_OUT_DTL_2.XPROGRESS_OUT = XPROGRESS_OUT_JHIKIATE            '進捗状態 = 引当(2)


                If (objXPLN_OUT_DTL_1.GET_XPLN_OUT_DTL_COUNT = 0) And _
                   (objXPLN_OUT_DTL_2.GET_XPLN_OUT_DTL_COUNT = 0) Then
                    '(仮引当、引当がない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_12, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(引当詳細)                     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_308051, ByVal enmCheckCase As menmCheckCase)

        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)             '品名ｺｰﾄﾞ
        objForm.userFHINMEI = TO_STRING(grdList.Item(menmListCol.FHINMEI, grdList.SelectedRows(0).Index).Value)                   '品名
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)             '製造年月日
        objForm.userXHINSHITU_STS = TO_STRING(grdList.Item(menmListCol.XHINSHITU_STS, grdList.SelectedRows(0).Index).Value)       '品質ｽﾃｰﾀｽ

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信(仮引当て)                     　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Socket01_KariHikiate() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        ''********************************************************************
        '' ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400603

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))          'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                                 '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                                 '担当者ｺｰﾄﾞ


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308050_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308050_02
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "  ｿｹｯﾄ送信(引当確定)                     　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Socket01_HikiateKakutei() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '********************************************************************
        ' 出荷引当日時ｾｯﾄ
        '********************************************************************
        Dim datTODAY As Date = Now
        mstrXHIKIATE_DT = Format(datTODAY, "yyyy/MM/dd") & " " & Format(datTODAY, "HH:mm:ss")  '出荷引当日時


        '********************************************************************
        ' ﾃﾞｰﾀｾｯﾄ
        '********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400601

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))          'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                                 '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                                 '担当者ｺｰﾄﾞ

        objTelegram.SETIN_DATA("XDSPHIKIATE_DT", mstrXHIKIATE_DT)                                             '出荷引当日時

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ


        strErrMsg = FRM_MSG_FRM308050_04
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308050_04
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "  ｿｹｯﾄ送信(引当解除)                     　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Socket01_HikiateKaijyo() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_05, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        ''********************************************************************
        '' ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400602

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))          'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                                 '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                                 '担当者ｺｰﾄﾞ


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308050_06
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308050_06
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "  ｿｹｯﾄ送信(仮引当ｷｬﾝｾﾙ)                  　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Socket01_KariHikiCancel() As Boolean

        Dim blnRet As Boolean = False

        ''*******************************************************
        ''確認ﾒｯｾｰｼﾞ
        ''*******************************************************
        'Dim udtRet As RetPopup
        'udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_05, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        'If udtRet <> RetPopup.OK Then
        '    Exit Function
        'End If


        ''********************************************************************
        '' ﾃﾞｰﾀｾｯﾄ
        ''********************************************************************

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram = New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400605

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))          'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                                 '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                                 '担当者ｺｰﾄﾞ


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                        'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM308050_16
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            Else
                '(処理が異常終了した場合)
                strErrMsg = FRM_MSG_FRM308050_16
                Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
            End If
        End If

        Return blnRet

    End Function
#End Region

#Region "　印刷処理  (出荷予定ﾘｽﾄ)                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub printOut()

        ''*******************************************************
        ''確認ﾒｯｾｰｼﾞ
        ''*******************************************************
        'Dim udeRet As PopupFormType
        'udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        'If udeRet <> PopupFormType.Ok Then
        '    Exit Sub
        'End If

        '*******************************************************
        '印刷処理  (出荷予定ﾘｽﾄ)
        '*******************************************************
        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308100) = False Then
            gobjFRM_308100.Close()
            gobjFRM_308100.Dispose()
            gobjFRM_308100 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_308100 = New FRM_308100         'ｵﾌﾞｼﾞｪｸﾄ作成

        'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_308100.mstrXHIKIATE_DT = mstrXHIKIATE_DT   '出荷引当日時

        Call gobjFRM_308100.SearchItem_Set3()   '構造体ｾｯﾄ
        Call gobjFRM_308100.printOut()          '印刷処理


    End Sub
#End Region

#Region "  印刷処理(欠品ﾘｽﾄ)                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印刷処理(欠品ﾘｽﾄ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub printOut_KeppinList()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub2(grdList2)

        '*********************************************
        ' ﾘｽﾄ出力
        '*********************************************
        If grdList2.RowCount > 0 Then
            '(印刷ﾃﾞｰﾀありの時)
            Call printOut01_KeppinList()       '欠品ﾘｽﾄ

            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_09, PopupFormType.Ok, PopupIconType.Information)

        End If

    End Sub
#End Region
#Region "　ﾘｽﾄ表示(欠品ﾘｽﾄ)                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示(欠品ﾘｽﾄ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild2()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_HIKIATE_KEPPIN.XSYUKKA_DT "                  '仮引当欠品情報.      出荷日
        strSQL &= vbCrLf & "   , TO_CHAR(TO_DATE(XPLN_HIKIATE_KEPPIN.XSYUKKA_DT, 'YYYY/MM/DD'), 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "  '仮引当欠品情報.      出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XORDER_NO "                   '仮引当欠品情報.      発注№
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XNYUKA_JIGYOU_NM "            '仮引当欠品情報.      配送先
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.FHINMEI_CD "                  '仮引当欠品情報.      品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.FHINMEI "                     '仮引当欠品情報.      品名
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XSEIZOU_DT "                  '仮引当欠品情報.      製造年月日
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_HIKIATE_KEPPIN.XSEIZOU_DT, 'YYYY/MM/DD') AS XSEIZOU_DT_DSP "  '仮引当欠品情報.      製造年月日(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHIDUKE_SITEI_KUBUN "         '仮引当欠品情報.      日付指定区分
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XHIDUKE_SITEI_KUBUN_DSP "   '仮引当欠品情報.      日付指定区分(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHINSHITU_STS "               '仮引当欠品情報.      品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "         '仮引当欠品情報.      品質ｽﾃｰﾀｽ(表示用)

        'strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XSYUKKA_VOL "                 '仮引当欠品情報.      出荷数
        'strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XKEPPIN_VOL "                 '仮引当欠品情報.      欠品数
        strSQL &= vbCrLf & "   , SUM(XPLN_HIKIATE_KEPPIN.XSYUKKA_VOL) AS XSYUKKA_VOL "  '仮引当欠品情報.      出荷数
        strSQL &= vbCrLf & "   , SUM(XPLN_HIKIATE_KEPPIN.XKEPPIN_VOL) AS XKEPPIN_VOL "  '仮引当欠品情報.      欠品数

        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHORYU_FLAG "                 '仮引当欠品情報.      保留ﾌﾗｸﾞ
        strSQL &= vbCrLf & "   , (CASE XPLN_HIKIATE_KEPPIN.XHORYU_FLAG "
        strSQL &= vbCrLf & "        WHEN " & XHORYU_FLAG_JOFF & " THEN '　' "
        strSQL &= vbCrLf & "        WHEN " & XHORYU_FLAG_JON & " THEN '★' "
        strSQL &= vbCrLf & "        ELSE '　' "
        strSQL &= vbCrLf & "      END) AS XHORYU_FLAG_DSP "                        '仮引当欠品情報.      保留ﾌﾗｸﾞ(表示用)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_HIKIATE_KEPPIN "                             '仮引当欠品情報
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_HIKIATE_KEPPIN", "XHIDUKE_SITEI_KUBUN")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_HIKIATE_KEPPIN", "XHINSHITU_STS")
  
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_HIKIATE_KEPPIN", "XHIDUKE_SITEI_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_HIKIATE_KEPPIN", "XHINSHITU_STS")
 

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     XPLN_HIKIATE_KEPPIN.XSYUKKA_DT "                  '仮引当欠品情報.      出荷日
        'strSQL &= vbCrLf & "   , XSYUKKA_DT_DSP "                                  '仮引当欠品情報.      出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XORDER_NO "                   '仮引当欠品情報.      発注№
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XNYUKA_JIGYOU_NM "            '仮引当欠品情報.      配送先
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.FHINMEI_CD "                  '仮引当欠品情報.      品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.FHINMEI "                     '仮引当欠品情報.      品名
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XSEIZOU_DT "                  '仮引当欠品情報.      製造年月日
        'strSQL &= vbCrLf & "   , XSEIZOU_DT_DSP "                                  '仮引当欠品情報.      製造年月日(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHIDUKE_SITEI_KUBUN "         '仮引当欠品情報.      日付指定区分
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP "                              '仮引当欠品情報.      日付指定区分(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHINSHITU_STS "               '仮引当欠品情報.      品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP "                              '仮引当欠品情報.      品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHORYU_FLAG "                 '仮引当欠品情報.      保留ﾌﾗｸﾞ
        'strSQL &= vbCrLf & "   , XHORYU_FLAG_DSP "                                 '仮引当欠品情報.      保留ﾌﾗｸﾞ(表示用)


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_HIKIATE_KEPPIN.XSYUKKA_DT "                  '仮引当欠品情報.     出荷日
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XORDER_NO "                   '仮引当欠品情報.     発注№
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.FHINMEI_CD "                  '仮引当欠品情報.     品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XSEIZOU_DT "                  '仮引当欠品情報.     製造年月日
        strSQL &= vbCrLf & "   , XPLN_HIKIATE_KEPPIN.XHINSHITU_STS "               '仮引当欠品情報.     品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncFRM.GridSelect(grdList2, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(欠品ﾘｽﾄ)                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定(欠品ﾘｽﾄ) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList2)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(欠品ﾘｽﾄ）                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut01_KeppinList()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_308050_02          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList2.Rows.Count - 1

                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", grdList2.Item(menmListCol2.XSYUKKA_DT_DSP, ii).FormattedValue)  '出荷日


                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data00 = grdList2.Item(menmListCol2.XORDER_NO, ii).FormattedValue                '発注№
                objDataRow.Data01 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_NM, ii).FormattedValue         '配送先
                objDataRow.Data02 = grdList2.Item(menmListCol2.FHINMEI_CD, ii).FormattedValue               '品名ｺｰﾄﾞ
                objDataRow.Data03 = grdList2.Item(menmListCol2.FHINMEI, ii).FormattedValue                  '品名
                objDataRow.Data04 = grdList2.Item(menmListCol2.XSEIZOU_DT_DSP, ii).FormattedValue           '製造年月日
                objDataRow.Data05 = grdList2.Item(menmListCol2.XHIDUKE_SITEI_KUBUN_DSP, ii).FormattedValue  '日付指定区分
                objDataRow.Data06 = grdList2.Item(menmListCol2.XHINSHITU_STS_DSP, ii).FormattedValue        '品質ｽﾃｰﾀｽ
                objDataRow.Data07 = grdList2.Item(menmListCol2.XSYUKKA_VOL, ii).FormattedValue              '出荷数(C/S)
                objDataRow.Data08 = grdList2.Item(menmListCol2.XKEPPIN_VOL, ii).FormattedValue              '欠品数(C/S)
                objDataRow.Data09 = grdList2.Item(menmListCol2.XHORYU_FLAG_DSP, ii).FormattedValue          '★

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

#Region "  表示更新ﾀｲﾏｰ処理(ｸﾞﾘｯﾄﾞ表示)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新ﾀｲﾏｰ処理(ｸﾞﾘｯﾄﾞ表示)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308050_TickProcess(ByVal intMode As Integer)

        '**********************************************************
        ' 引当処理中確認
        '**********************************************************
        Dim intSYS061 As Integer = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JSJ000000_061))

        If intSYS061 = FLAG_ON Then
            '(仮引当ﾎﾞﾀﾝ押下ﾌﾗｸﾞが押されている時[処理中])

            lblKARICHU.Visible = True          '仮引当処理中 表示あり
            tmr308050.Enabled = True
            tmr308050_2.Enabled = True

            Select Case intMode
                Case 0
                    '(ﾀｲﾏｲﾍﾞﾝﾄ時)
                    Exit Select
                Case 1
                    '(ﾌｫｰﾑﾛｰﾄﾞ時)
                    mblnKARICHU_BLINK = True
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_13, PopupFormType.Ok, PopupIconType.Information)
                Case 2
                    '(F1押下時)
                    '*********************************************
                    ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
                    '*********************************************
                    lblHIKIATE_ORDER_SU.Text = ""       '引当出荷ｵｰﾀﾞ数

                    '*********************************************
                    ' ﾘｽﾄ表示
                    '*********************************************
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup2()

                    mblnKARICHU_BLINK = True

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308050_14, PopupFormType.Ok, PopupIconType.Information)
            End Select

        Else
            '(仮引当ﾎﾞﾀﾝ押下ﾌﾗｸﾞが押されていない時[処理未または処理完了])

            lblKARICHU.Visible = False          '仮引当処理中 表示なし
            tmr308050.Enabled = False
            tmr308050_2.Enabled = False

            '**********************************************************
            ' 引当出荷ｵｰﾀﾞ数 表示
            '**********************************************************
            Call Hikiate_Order_SU_Set()

            '**********************************************************
            ' ﾘｽﾄ表示
            '**********************************************************
            mblnNodata = False
            Call grdListDisplaySub(grdList)

            '*******************************************************
            '印刷処理  (欠品ﾘｽﾄ)
            '*******************************************************
            Call printOut_KeppinList()

            '*********************************************
            ' 仮引当ｷｬﾝｾﾙ送信(欠品ﾘｽﾄ削除)
            '*********************************************
            Dim objXPLN_HIKIATE_KEPPIN As TBL_XPLN_HIKIATE_KEPPIN     '仮引当欠品情報
            objXPLN_HIKIATE_KEPPIN = New TBL_XPLN_HIKIATE_KEPPIN(gobjOwner, gobjDb, Nothing)
            If objXPLN_HIKIATE_KEPPIN.GET_XPLN_HIKIATE_KEPPIN_COUNT() > 0 Then
                '(欠品ﾘｽﾄの明細がある時)
                Call Socket01_KariHikiCancel()
            End If

        End If

    End Sub
#End Region
#Region "  表示更新ﾀｲﾏｰ処理(仮引当処理中)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新ﾀｲﾏｰ処理(仮引当処理中) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr308050_2_TickProcess()

        '**********************************************************
        ' 仮引当処理中ﾌﾞﾘﾝｸ
        '**********************************************************
        If mblnKARICHU_BLINK = True Then
            '(仮引当処理中が消えている時)
            mblnKARICHU_BLINK = False
            lblKARICHU.Visible = True          '仮引当処理中 表示あり
        Else
            '(仮引当処理中が表示されている時)
            mblnKARICHU_BLINK = True
            lblKARICHU.Visible = False         '仮引当処理中 表示なし
        End If

    End Sub
#End Region

End Class
