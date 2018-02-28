'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷残問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports GamenCommon
#End Region

Public Class FRM_311070

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mintSAIMOKU_COUNT As Integer = 8    '取引区分細目の配列用（8種類の細目）
    Private mintCNT As String                   '取引区分細目の下記定数取得
    Private mintCNT0 As String = 0              '取引区分細目の移送
    Private mintCNT1 As String = 1              '取引区分細目の移動
    Private mintCNT2 As String = 2              '取引区分細目の補給
    Private mintCNT3 As String = 3              '取引区分細目の転送
    Private mintCNT4 As String = 4              '取引区分細目の配送
    Private mintCNT5 As String = 5              '取引区分細目の移動-1
    Private mintCNT6 As String = 6              '取引区分細目の中間品
    Private mintCNT7 As String = 7              '取引区分細目の合計

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSAIMOKU                '出荷指示詳細.      細目区分
        XSYUKKA_KON_PLAN        '出荷指示詳細.      出荷予定梱包数(集計)
        FPALLET                 '                   パレット数(出荷予定梱包数/PL毎積載数)

        DATA03                  '未使用
        DATA04                  '未使用
        DATA05                  '未使用

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
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        Dim intKON(mintSAIMOKU_COUNT) As Integer
        Dim intPLNUM(mintSAIMOKU_COUNT) As Integer
        Dim strYUSOU(mintSAIMOKU_COUNT) As String
        Dim mintKON As Integer

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    SUM(XPLN_OUT_DTL.XSYUKKA_KON_PLAN)   AS XSYUKKA_KON_PLAN"               '出荷指示詳細.      出荷予定梱数
        strSQL &= vbCrLf & "  , SUM(XPLN_OUT_DTL.XSYUKKA_KON_RESULT) AS XSYUKKA_KON_RESULT "            '出荷指示詳細.      出荷実績詳細
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSAIMOKU "                                                 '出荷指示詳細.      取引区分細目
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN "                                                '出荷指示詳細.      移動区分
        strSQL &= vbCrLf & "  , TMST_ITEM.XARTICLE_TYPE_CODE "                                          '品名ﾏｽﾀ.           商品区分
        strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET "                                              '品名ﾏｽﾀ.           PL毎積載数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL "                                      '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TMST_ITEM "                                         '【品名ﾏｽﾀ】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD "

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        strSQL &= vbCrLf & "     AND TO_DATE(TO_CHAR(XPLN_OUT_DTL.XSYUKKA_D, 'YYYY/MM/DD')) = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY  "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSAIMOKU"                      '出荷指示詳細.      取引区分細目
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN"                     '出荷指示詳細.      移動区分
        strSQL &= vbCrLf & "  , TMST_ITEM.XARTICLE_TYPE_CODE"               '品名ﾏｽﾀ.           商品区分
        strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET"                   '品名ﾏｽﾀ.           PL毎積載数

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSAIMOKU"                      '出荷指示詳細.      取引区分細目
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN"                     '出荷指示詳細.      移動区分
        strSQL &= vbCrLf & "  , TMST_ITEM.XARTICLE_TYPE_CODE"               '品名ﾏｽﾀ.           商品区分
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '取引区分細目及び移動区分、商品区分別の選択
        ' ''取引区分細目：移送=161、移動=162、補給=163、転送=164、配送=173
        ' ''移動区分：移動=1以外、移動-1=1
        ' ''商品区分：中間品=2
        '********************************************************************
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                If (TO_STRING(objRow("XIDOU_KBN")) <> TO_STRING(XIDOU_KBN_JIDOU)) _
                    And (TO_STRING(objRow("XARTICLE_TYPE_CODE")) <> TO_STRING(XARTICLE_TYPE_CODE_J02)) Then

                    Select Case TO_STRING(objRow("XSAIMOKU"))
                        Case TO_STRING(XSAIMOKU_JISOU)     '移送
                            mintCNT = mintCNT0

                        Case TO_STRING(XSAIMOKU_JIDOU)     '移動
                            mintCNT = mintCNT1

                        Case TO_STRING(XSAIMOKU_JHOKYUU)   '補給
                            mintCNT = mintCNT2

                        Case TO_STRING(XSAIMOKU_JTENSOU)   '転送
                            mintCNT = mintCNT3

                        Case TO_STRING(XSAIMOKU_JHAISOU)   '配送
                            mintCNT = mintCNT4

                    End Select

                ElseIf (TO_STRING(objRow("XIDOU_KBN")) = TO_STRING(XIDOU_KBN_JIDOU)) _
                    And (TO_STRING(objRow("XARTICLE_TYPE_CODE")) <> TO_STRING(XARTICLE_TYPE_CODE_J02)) Then

                    mintCNT = mintCNT5                        '移動-1

                Else

                    mintCNT = mintCNT6                        '中間品

                End If

                '-----------------------
                'ﾊﾟﾚｯﾄ数及び梱数算出
                '-----------------------
                Dim intXSYUKKA_KON_PLAN As Integer = 0          '出荷予定梱数
                Dim intXSYUKKA_KON_RESULT As Integer = 0        '出荷実績梱数
                Dim intFNUM_IN_PALLET As Integer = 0            'PL毎積載数

                If TO_STRING(objRow("XSYUKKA_KON_PLAN")) <> "" Then
                    intXSYUKKA_KON_PLAN = TO_NUMBER(objRow("XSYUKKA_KON_PLAN"))
                End If

                If TO_STRING(objRow("XSYUKKA_KON_RESULT")) <> "" Then
                    intXSYUKKA_KON_RESULT = TO_NUMBER(objRow("XSYUKKA_KON_RESULT"))
                End If

                If TO_STRING(objRow("FNUM_IN_PALLET")) <> "" Then
                    intFNUM_IN_PALLET = TO_NUMBER(objRow("FNUM_IN_PALLET"))
                End If

                mintKON = intXSYUKKA_KON_PLAN - intXSYUKKA_KON_RESULT                           '出荷予定梱数-出荷実績梱数
                If mintKON <= 0 Then                                                            'ﾊﾟﾚｯﾄ数算出
                    '(残り梱数)
                    intPLNUM(mintCNT) += 0
                ElseIf mintKON Mod intFNUM_IN_PALLET = 0 Then
                    '(余りなし)
                    intPLNUM(mintCNT) += mintKON / intFNUM_IN_PALLET
                Else
                    '(余りあり)
                    intPLNUM(mintCNT) += (Fix(mintKON / intFNUM_IN_PALLET)) + 1
                End If

                intKON(mintCNT) += mintKON                                                                      '梱数算出

            Next

        End If

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        Dim jj As Integer

        strYUSOU(mintCNT0) = "移送"                   '移送
        strYUSOU(mintCNT1) = "移動"                   '移動
        strYUSOU(mintCNT2) = "補給"                   '補給
        strYUSOU(mintCNT3) = "転送"                   '転送
        strYUSOU(mintCNT4) = "配送"                   '配送
        strYUSOU(mintCNT5) = "移動-1"                 '移動-1
        strYUSOU(mintCNT6) = "中間品"                 '中間品
        strYUSOU(mintCNT7) = "合計"                   '合計

        intKON(mintCNT7) = intKON(mintCNT0) + intKON(mintCNT1) + intKON(mintCNT2) + intKON(mintCNT3) + intKON(mintCNT4) + intKON(mintCNT5) + intKON(mintCNT6)
        intPLNUM(mintCNT7) = intPLNUM(mintCNT0) + intPLNUM(mintCNT1) + intPLNUM(mintCNT2) + intPLNUM(mintCNT3) + intPLNUM(mintCNT4) + intPLNUM(mintCNT5) + intPLNUM(mintCNT6)

        For jj = 0 To mintCNT7
            objDataTable.userAddRowDataSet(TO_STRING(strYUSOU(jj)), _
                                                    TO_STRING(intKON(jj)), _
                                                        TO_STRING(intPLNUM(jj)))
        Next



        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.Columns.Clear()
        grdList.DataSource = objDataTable

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
        'ｸﾞﾘｯﾄﾞ 行の高さ
        '************************************************
        For rowCnt As Integer = 0 To grdList.RowCount - 1
            grdList.Rows(rowCnt).Height = 37
        Next

        '************************************************
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)

    End Sub
#End Region



End Class
