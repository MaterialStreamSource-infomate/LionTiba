'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷在庫確認画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports GamenCommon
#End Region

Public Class FRM_311060

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private Const STOCK_STS_OK As String = "○"         '状態
    Private Const STOCK_STS_NG As String = "欠品"       '状態

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        FSTS_NAME               '                   状態
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD              '品目ﾏｽﾀ.           品名記号
        FHINMEI_CD              '品目ﾏｽﾀ.           品名コード
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI                 '品目ﾏｽﾀ.           品名
        XSYUKKA_KON_PLAN        '出荷指示詳細.      出荷予定梱包数(集計)
        FTR_VOL                 '在庫情報.          搬送管理量

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_D As String                         '出荷日
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
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
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '出荷日                ｾｯﾄ
        '===================================
        cboXSYUKKA_D.cmpMDateTimePicker_D.Value = Now       '出荷日

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboXSYUKKA_D.Dispose()              '出荷日
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)


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
#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        If cboXSYUKKA_D.userDispChecked = True Then
            mudtSEARCH_ITEM.XSYUKKA_D = Mid(cboXSYUKKA_D.userDateTimeText, 1, 10)       '出荷日
        Else
            mudtSEARCH_ITEM.XSYUKKA_D = ""
        End If

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                            'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    CASE "
        strSQL &= vbCrLf & "        WHEN SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_PLAN,0))-SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESULT,0)) > NVL(STOCK_SUM.FTR_VOL_SUM,0) THEN '" & STOCK_STS_NG & "' "
        strSQL &= vbCrLf & "        WHEN SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_PLAN,0))-SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESULT,0)) <= NVL(STOCK_SUM.FTR_VOL_SUM,0) THEN '" & STOCK_STS_OK & "' "
        strSQL &= vbCrLf & "    END AS STS "                                                            '状態
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                                  '品名ﾏｽﾀ.           品名記号
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI_CD "                                                  '品名ﾏｽﾀ.           品名コード
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                                     '品名ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "  , SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_PLAN,0))-SUM(NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESULT,0))    AS XSYUKKA_KON_PLAN "           '出荷指示詳細.      出荷予定梱数
        strSQL &= vbCrLf & "  , NVL(STOCK_SUM.FTR_VOL_SUM,0)          AS FTR_VOL "                      '在庫情報.          搬送管理量合計

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL "                                      '【出荷指示詳細】
        ''strSQL &= vbCrLf & "  , TRST_STOCK "                                        '【在庫情報】
        strSQL &= vbCrLf & "  , TMST_ITEM "                                         '【品名ﾏｽﾀ】
        strSQL &= vbCrLf & "  , ( "                                                 '【在庫情報】在庫数毎
        strSQL &= vbCrLf & "     SELECT     "
        strSQL &= vbCrLf & "         FHINMEI_CD  "
        strSQL &= vbCrLf & "       , SUM(FTR_VOL) AS FTR_VOL_SUM  "
        strSQL &= vbCrLf & "     FROM "
        strSQL &= vbCrLf & "         TRST_STOCK "
        strSQL &= vbCrLf & "     GROUP BY "
        strSQL &= vbCrLf & "         FHINMEI_CD "
        strSQL &= vbCrLf & "    ) STOCK_SUM "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD "
        ''strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD  = TRST_STOCK.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD  = STOCK_SUM.FHINMEI_CD(+) "

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        strSQL &= vbCrLf & "     AND TO_DATE(TO_CHAR(XPLN_OUT_DTL.XSYUKKA_D, 'YYYY/MM/DD')) = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY  "
        strSQL &= vbCrLf & "    TMST_ITEM.FHINMEI_CD "                      '品名ﾏｽﾀ.           品名コード
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                      '品名ﾏｽﾀ.           品名記号
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                         '品名ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "  , STOCK_SUM.FTR_VOL_SUM "                         '品名ﾏｽﾀ.           品名


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        '************************************************
        '色変更 
        '************************************************
        For rowCnt As Integer = 0 To grdList.RowCount - 1
            If grdList.Item(menmListCol.FSTS_NAME, rowCnt).Value.ToString = STOCK_STS_NG Then
                '(欠品の場合)
                grdList.Item(menmListCol.FSTS_NAME, rowCnt).Style.ForeColor = Color.Red
            End If
        Next


    End Sub
#End Region


End Class
