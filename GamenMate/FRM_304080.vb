'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】棚卸しリスト
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304080


#Region "　共通変数　                               "


    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XHINMEI_CD                  '品名コード
        FHINMEI_CD                  '品名記号
        FHINMEI                     '品名
        FNUM_IN_PALLET              'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        SOUKOPL_VOL                 '自動倉庫PL数
        SOUKO_VOL                   '自動倉庫梱数
        HIRAOKI_VOL                 '平置き梱数
        KENPIN_VOL                  '検品エリア梱数
        SUM_VOL                     '合計梱数

        DATA09                      '未使用
        DATA10                      '未使用

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click                 '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim XARTICLE_TYPE_CODE As String    '商品区分
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
        '商品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXARTICLE_TYPE_CODE, True)


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
        cboXARTICLE_TYPE_CODE.Dispose()     '商品区分
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
        Call Set_Goukei()


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
        mudtSEARCH_ITEM.XARTICLE_TYPE_CODE = TO_STRING(cboXARTICLE_TYPE_CODE.SelectedValue.ToString)

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

        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objRow2 As DataRow                          '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName2 As String                   'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet2 As New DataSet                  'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable10      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        Dim strSQL As String                    'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     TMST_ITEM.XHINMEI_CD "                                 '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI_CD "                                 '品目記号
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                                    '品名_正式名
        strSQL &= vbCrLf & "   , TMST_ITEM.FNUM_IN_PALLET "                             'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TMST_ITEM "                                            '品名ﾏｽﾀ
       
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "                                              '必ず通る条件
       
        '----------------------------
        '商品区分
        '----------------------------
        If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TMST_ITEM.XHINMEI_CD"                                   '品名ｺｰﾄﾞ

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TANAOROSHI"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim XHINMEI_CD As String = ""                   '品名コード
                Dim FHINMEI_CD As String = ""                   '品名記号
                Dim FHINMEI As String = ""                      '品名
                Dim FNUM_IN_PALLET As String = ""               'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
               
                XHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
                FHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                FHINMEI = TO_STRING(objRow("FHINMEI"))
                FNUM_IN_PALLET = TO_STRING(objRow("FNUM_IN_PALLET"))

                '********************************************************************
                ' SQL文作成
                '********************************************************************

                Dim strBindField(0) As String
                Dim objBindValue(0) As Object
                Dim strBindType(0) As String

                strBindField = Nothing
                objBindValue = Nothing
                strBindType = Nothing

                Dim objParameter(1, 0) As Object
                ReDim Preserve strBindField(0)
                ReDim Preserve objBindValue(0)
                ReDim Preserve strBindType(0)


                '============================================================
                'SELECT
                '============================================================
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "     TPRG_TRK_BUF.FTRK_BUF_NO"                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                strSQL &= vbCrLf & "   , COUNT(TRST_STOCK.FPALLET_ID) PL"                       '自動倉庫PL数
                strSQL &= vbCrLf & "   , SUM(TRST_STOCK.FTR_VOL) SUM"                           '自動倉庫梱数


                '============================================================
                'FROM
                '============================================================
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TRST_STOCK "                                            '在庫情報
                strSQL &= vbCrLf & "   , TPRG_TRK_BUF "                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ

                '============================================================
                'WHERE
                '============================================================
                strSQL &= vbCrLf & " WHERE 1 = 1 "          '必ず通る条件
                strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
                'strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & FHINMEI_CD & "' "

                If IsNull(FHINMEI_CD) = False Then
                    ReDim Preserve strBindField(UBound(strBindField) + 1)
                    ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                    strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                    objBindValue(UBound(objBindValue)) = FHINMEI_CD
                    strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ"
                End If


                '============================================================
                'GROUP BY
                '============================================================
                strSQL &= vbCrLf & " GROUP BY  "
                strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO "                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

                '============================================================
                'ORDER BY
                '============================================================
                strSQL &= vbCrLf & " ORDER BY "
                strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO "                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.


                '***********************
                'ﾊﾞｲﾝﾄﾞ変数定義
                '***********************
                objParameter = Nothing
                ReDim Preserve objParameter(2, UBound(strBindField) - 1)
                Dim ii As Integer
                For ii = LBound(strBindField) + 1 To UBound(strBindField)
                    objParameter(0, ii - 1) = strBindField(ii)
                    objParameter(1, ii - 1) = objBindValue(ii)
                Next ii

      
                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet2.Clear()
                gobjDb.Parameter = objParameter
                strDataSetName2 = "TANAOROSHI2"
                gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                Dim SOUKOPL_VOL As Long = 0                  '自動倉庫PL数
                Dim SOUKO_VOL As Long = 0                    '自動倉庫梱数
                Dim HIRAOKI_VOL As Long = 0                  '平置き梱数
                Dim KENPIN_VOL As Long = 0                   '検品エリア梱数
                Dim SUM_VOL As Long = 0                      '合計梱数

                If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                    For Each objRow2 In objDataSet2.Tables(strDataSetName2).Rows

                        '********************************************************************
                        ' ﾃﾞｰﾀ取得
                        '********************************************************************
                        Dim FTRK_BUF_NO As String = ""
                        Dim PL As String = ""
                        Dim SUM As String = ""

                        FTRK_BUF_NO = TO_STRING(objRow2("FTRK_BUF_NO"))


                        '-----------------------
                        '振り分け
                        '-----------------------

                        Select Case FTRK_BUF_NO

                            Case FTRK_BUF_NO_J9000
                                SOUKOPL_VOL = objRow2("PL")
                                SOUKO_VOL = objRow2("SUM")

                            Case FTRK_BUF_NO_J9100
                                HIRAOKI_VOL = objRow2("SUM")

                            Case FTRK_BUF_NO_J9200
                                KENPIN_VOL = objRow2("SUM")

                        End Select

                        
                    Next
                End If

                SUM_VOL = SUM_VOL + SOUKO_VOL + HIRAOKI_VOL + KENPIN_VOL


                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '******************************************************************** 
                objDataTable.userAddRowDataSet(XHINMEI_CD, _
                                               FHINMEI_CD, _
                                               FHINMEI, _
                                               FNUM_IN_PALLET, _
                                               TO_STRING(SOUKOPL_VOL), _
                                               TO_STRING(SOUKO_VOL), _
                                               TO_STRING(HIRAOKI_VOL), _
                                               TO_STRING(KENPIN_VOL), _
                                               TO_STRING(SUM_VOL), _
                )


            Next
        End If

                '********************************************************************
                ' ｸﾞﾘｯﾄﾞへ出力
                '********************************************************************
                Call gobjComFuncFRM.GridDisplay(objDataTable, _
                                                grdList _
                                                )
                objDataTable = Nothing


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

        Dim SOUKOPL_VOL As Integer = 0
        Dim SOUKO_VOL As Integer = 0
        Dim HIRAOKI_VOL As Integer = 0
        Dim KENPIN_VOL As Integer = 0
        Dim SUM_VOL As Integer = 0

        For i = 0 To grdList.RowCount - 1
            SOUKOPL_VOL = SOUKOPL_VOL + TO_INTEGER(grdList.Item(menmListCol.SOUKOPL_VOL, i).Value)    '自動倉庫PL数
            SOUKO_VOL = SOUKO_VOL + TO_INTEGER(grdList.Item(menmListCol.SOUKO_VOL, i).Value)          '自動倉庫梱数
            HIRAOKI_VOL = HIRAOKI_VOL + TO_INTEGER(grdList.Item(menmListCol.HIRAOKI_VOL, i).Value)     '平置き梱数
            KENPIN_VOL = KENPIN_VOL + TO_INTEGER(grdList.Item(menmListCol.KENPIN_VOL, i).Value)        '検品エリア梱数
        Next

        SUM_VOL = SOUKO_VOL + HIRAOKI_VOL + KENPIN_VOL                                                '合計梱数

        lblSOUKOPL_SUM_VOL.Text = TO_STRING(SOUKOPL_VOL)
        lblSOUKO_SUM_VOL.Text = TO_STRING(SOUKO_VOL)
        lblHIRAOKI_SUM_VOL.Text = TO_STRING(HIRAOKI_VOL)
        lblKENPIN_SUM_VOL.Text = TO_STRING(KENPIN_VOL)
        lblAll_SUM_VOL.Text = TO_STRING(SUM_VOL)

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
        Dim objCR As New PRT_304080_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try
            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '発行日時
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", cboXARTICLE_TYPE_CODE.Text)                '商品区分

            '-----------------------
            '全品目棚卸し
            '-----------------------
            If cboXARTICLE_TYPE_CODE.Text = "" Then
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", "全品目")                '商品区分
            End If


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

              

                '*明細項目(表示)        
                objDataRow.Data00 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue              '品名ｺｰﾄﾞ
                objDataRow.Data01 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue              '品名記号
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue                 '品名
                objDataRow.Data03 = grdList.Item(menmListCol.FNUM_IN_PALLET, ii).FormattedValue          'ﾊﾟﾚｯﾄ毎積載数
                objDataRow.Data04 = grdList.Item(menmListCol.SOUKOPL_VOL, ii).FormattedValue             '自動倉庫PL数
                objDataRow.Data05 = grdList.Item(menmListCol.SOUKO_VOL, ii).FormattedValue               '自動倉庫梱数
                objDataRow.Data06 = grdList.Item(menmListCol.HIRAOKI_VOL, ii).FormattedValue             '平置き梱数
                objDataRow.Data07 = grdList.Item(menmListCol.KENPIN_VOL, ii).FormattedValue              '検品ｴﾘｱ梱数
                objDataRow.Data08 = grdList.Item(menmListCol.SUM_VOL, ii).FormattedValue                 '合計梱数
                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)


               
            Next


           

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' ﾌｯﾀｰ部分作成
            '***********************************************
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", lblSOUKOPL_SUM_VOL.Text)              '自動倉庫PL合計数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", lblSOUKO_SUM_VOL.Text)                '自動倉庫合計梱数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", lblHIRAOKI_SUM_VOL.Text)              '平置き合計梱数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", lblKENPIN_SUM_VOL.Text)               '検品エリア合計梱数
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", lblAll_SUM_VOL.Text)              '合計梱数

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
