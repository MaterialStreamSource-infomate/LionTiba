'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産ﾗｲﾝ別入庫実績問合せ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304060


#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XPROD_LINE          '生産実績詳細.         生産ﾗｲﾝ№
        XPROD_LINE_DSP      '生産実績詳細.         生産ﾗｲﾝ№(表示用)
        XHINMEI_CD          '生産実績詳細.         品名ｺｰﾄﾞ
        FHINMEI_CD          '生産実績詳細.         品名記号
        FHINMEI             '生産実績詳細.         品名
        JISSEKI_VOL         '生産実績詳細.         実績数
        PL_VOL              '生産実績詳細.         PL数

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click                 '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSOUGYOU_DT As String           '操業日
    End Structure
#End Region

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
        cboFRESULT_DT.cmpMDateTimePicker_D.Value = Now       '出荷日

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
        cboFRESULT_DT.Dispose()              '出荷日
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
#Region "  F4(印刷)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()


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

            Case menmCheckCase.Print_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

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
        If cboFRESULT_DT.userDispChecked = True Then
            mudtSEARCH_ITEM.XSOUGYOU_DT = Mid(cboFRESULT_DT.userDateTimeText, 1, 10)       '出荷日
        Else
            mudtSEARCH_ITEM.XSOUGYOU_DT = ""
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

        Dim strSQL As String                    'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XRST_PRODUCT_IN.XPROD_LINE "                         '生産実績詳細   .生産ﾗｲﾝNo
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME "                     '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝ名
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                               '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XRST_PRODUCT_IN.FHINMEI_CD "                         '生産実績詳細   .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                                  '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , SUM(XRST_PRODUCT_IN.FTR_VOL) AS FTR_VOL_SUM  "       '生産実績詳細   .実績数
        strSQL &= vbCrLf & "     , Count(0) AS XRST_PRODUCT_IN_COUNT  "                 '生産実績詳細   .PL数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XRST_PRODUCT_IN "                  '【生産実績詳細】
        strSQL &= vbCrLf & "   , TMST_ITEM "                        '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "   , XMST_PROD_LINE "                   '【生産ﾗｲﾝﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XRST_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
        strSQL &= vbCrLf & "    AND XRST_PRODUCT_IN.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE "
        strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE IN ( " & XARTICLE_TYPE_CODE_J01 & "," & XARTICLE_TYPE_CODE_J02 & ") "      '商品区分が　製品　中間品　だけを集計


        '----------------------------
        '生産日
        '----------------------------
        If mudtSEARCH_ITEM.XSOUGYOU_DT <> "" Then
            strSQL &= vbCrLf & "      AND TO_DATE(TO_CHAR(XRST_PRODUCT_IN.XSOUGYOU_DT, 'YYYY/MM/DD')) = TO_DATE('" & mudtSEARCH_ITEM.XSOUGYOU_DT & "', 'YYYY/MM/DD')"
        End If

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY  "
        strSQL &= vbCrLf & "    XRST_PRODUCT_IN.XPROD_LINE "                '生産実績詳細   .生産ﾗｲﾝNo
        strSQL &= vbCrLf & "  , XRST_PRODUCT_IN.FHINMEI_CD "                '生産実績詳細   .品名記号
        strSQL &= vbCrLf & "  , XMST_PROD_LINE.XPROD_LINE_NAME "            '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝNo
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                      '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                         '品目ﾏｽﾀ        .品名

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
        Call grdListSetup()                 'ｸﾞﾘｯﾄﾞ表示設定
        Call Set_Goukei()                   '合計数表示

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

    End Sub
#End Region

#Region "　合計数計算　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 合計数計算
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Set_Goukei()

        Dim i As Integer

        Dim JISSEKI_VOL As Integer = 0
        Dim PL_VOL As Integer = 0

        For i = 0 To grdList.RowCount - 1
            JISSEKI_VOL = JISSEKI_VOL + TO_INTEGER(grdList.Item(menmListCol.JISSEKI_VOL, i).Value)    '実績数
            PL_VOL = PL_VOL + TO_INTEGER(grdList.Item(menmListCol.PL_VOL, i).Value)                   'PL数
        Next

        lblJISSEKI_VOL.Text = TO_STRING(JISSEKI_VOL)
        lblPL_VOL.Text = TO_STRING(PL_VOL)

    End Sub
#End Region

#Region "　印刷処理　                           "
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
        Dim objCR As New PRT_304060_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try
            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '発行日時
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM.XSOUGYOU_DT)                    '生産日

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '*明細項目(表示)  
                objDataRow.Data00 = grdList.Item(menmListCol.XPROD_LINE, ii).FormattedValue             '生産ﾗｲﾝNo.

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/27 生産ライン別入庫実績リストで生産ﾗｲﾝ(表示用)を追加する
                objDataRow.Data06 = grdList.Item(menmListCol.XPROD_LINE_DSP, ii).FormattedValue         '生産ﾗｲﾝ№(表示用)
                'JobMate:S.Ouchi 2013/11/27 生産ライン別入庫実績リストで生産ﾗｲﾝ(表示用)を追加する
                '↑↑↑↑↑↑************************************************************************************************************

                objDataRow.Data01 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue             '品名ｺｰﾄﾞ
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue             '品名記号
                objDataRow.Data03 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue                '品名
                objDataRow.Data04 = grdList.Item(menmListCol.JISSEKI_VOL, ii).FormattedValue            '数量
                objDataRow.Data05 = "(" + grdList.Item(menmListCol.PL_VOL, ii).FormattedValue + ")"     'PL数

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next


            ' ''For ii As Integer = 0 To 100
            ' ''    Dim objDataRow As clsPrintDataSet.DataTable01Row
            ' ''    objDataRow = objDataSet.DataTable01.NewRow

            ' ''    objDataRow.BeginEdit()

            ' ''    '*明細項目(表示)  
            ' ''    objDataRow.Data00 = TO_STRING((ii * 10) + 1)             '生産ﾗｲﾝNo.
            ' ''    objDataRow.Data01 = TO_STRING((ii * 10) + 2)
            ' ''    objDataRow.Data02 = TO_STRING((ii * 10) + 3)
            ' ''    objDataRow.Data03 = TO_STRING((ii * 10) + 4)
            ' ''    objDataRow.Data04 = TO_STRING((ii * 10) + 5)
            ' ''    objDataRow.Data05 = TO_STRING((ii * 10) + 6)

            ' ''    objDataRow.EndEdit()

            ' ''    objDataSet.DataTable01.Rows.Add(objDataRow)

            ' ''Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' ﾌｯﾀｰ部分作成
            '***********************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", lblJISSEKI_VOL.Text)                '実績数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", "(" + lblPL_VOL.Text + ")")         'PL数

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
