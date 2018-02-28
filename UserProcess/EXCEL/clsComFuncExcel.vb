'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ機能
' 【機能】Excel帳票関数
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              　　"
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

Public Class clsComFuncExcel
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    '------------------------------------
    ' 帳票定義
    '------------------------------------
    Private mRPRT_EXCEL_EXT As String = "xls"                           '拡張子
    Private mRPRT_EXCEL_FILTER As String = "Microsoft Excel ブック (*.xls)|*.xls|All files (*.*)|*.*"   'ﾌｨﾙﾀｰ
    Private mRPRT_EXCEL_TITLE As String = "Microsoft Excel - "          'プロセスのタイトル(固定部分)

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

#Region "　日報印刷処理　                      　　 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 日報印刷処理
    ''' </summary>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <param name="strFilePath">作成ﾌｧｲﾙﾊﾟｽ</param>
    ''' <param name="strFileName">作成ﾌｧｲﾙ名</param>
    ''' <param name="strCSVFileName">作成CSVﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function makeReportNippo(ByVal dtSearchDate As Date _
                                  , ByVal strFilePath As String _
                                  , ByVal strFileName As String _
                                  , ByVal strCSVFileName As String _
                                  ) _
                                  As Boolean

        Dim blnResult As Boolean = True     ' 戻り値
        'Excelｵﾌﾞｼﾞｪｸﾄ操作ｸﾗｽ
        Dim objExcelCtl As clsExcelAppCtl = New clsExcelAppCtl(Owner, ObjDb, ObjDbLog)

        Try
            '***********************
            '初期設定
            '***********************
            '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
            Dim strFilePathName As String = ""
            strFilePathName &= strFilePath
            strFilePathName &= strFileName

            ' ''***********************************************
            ' '' configﾌｧｲﾙから取得
            ' ''***********************************************
            ''Dim strPrtNM As String = gobjComFuncGMN.GET_CONFIG_INFO()
            ' Temp帳票ﾌｧｲﾙ名
            Dim strDirectory As String = "..\Excel\Temp"

            '*============================
            '* ファイルのコピー
            '*============================
            Dim tempFilePath As String = strDirectory & "\" & "日報Temp.xls"
            ' ファイルの存在確認
            'If File.Exists(strFilePathName) = False Then
            '    '(ファイルがないとき)
            '    'ファイルをコピーする
            '    System.IO.File.Copy(tempFilePath, strFilePathName)
            'End If
            'ファイルをコピーする(上書き)
            System.IO.File.Copy(tempFilePath, strFilePathName, True)
            
            'Excelｵﾌﾞｼﾞｪｸﾄ作成
            strFilePathName = System.IO.Path.GetFullPath(strFilePathName)
            objExcelCtl.ExcelOpen(strFilePathName)

            '--------------------
            'ﾃﾞｰﾀｾｯﾄ
            '--------------------
            'ｼｰﾄへﾃﾞｰﾀをｾｯﾄ
            If SetDatasNippo(objExcelCtl, dtSearchDate) = False Then
                Throw New UserException("ﾃﾞｰﾀのｾｯﾄに失敗しました。")
                blnResult = False
            End If

            '--------------------
            'CSVﾌｧｲﾙ出力
            '--------------------
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
            'Dim strCSVFilePath As String = "..\Excel\"
            Dim strCSVFilePath As String = objTPRG_SYS_HEN.SJ000000_023
            If MakeCSVNippo(objExcelCtl, strCSVFilePath, strCSVFileName) = False Then
                Throw New UserException("CSVﾌｧｲﾙの作成に失敗しました。")
                blnResult = False
            End If

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            blnResult = False
            Throw ex

        Finally
            'Excelｵﾌﾞｼﾞｪｸﾄ解放
            objExcelCtl.ExcelClose(blnResult)
        End Try

        Return blnResult

    End Function
#End Region
#Region "  Excelｼｰﾄへのﾃﾞｰﾀｾｯﾄ処理(日報)            "
#Region " Excelｼｰﾄへのﾃﾞｰﾀｾｯﾄ処理(日報)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelｼｰﾄﾍのﾃﾞｰﾀｾｯﾄ処理(日報)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippo(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True

        Try

            'ﾃﾞｰﾀｾｯﾄｼｰﾄ取得
            Call objExcel.SheetOpen(1)

            '作成日付設定
            Dim strSerchDate = Format(dtSearchDate, "  yyyy年  MM月  dd日 （ddd）  ")
            Call objExcel.SetCellValue("N4", strSerchDate)

            '----------------------------
            ' 2.入庫実績
            '----------------------------
            If SetDatasNippoRstIN(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 3.出荷状況
            '----------------------------
            If SetDatasNippoRstOUT(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 4.終了日時
            '----------------------------
            If SetDatasNippoEndTime(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 5.ﾗｯｸ内在庫状況
            '----------------------------
            If SetDatasNippoZaiko(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '----------------------------
            ' 6.設備稼働状況()
            '----------------------------
            If SetDatasNippoEqRun(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 6.設備ﾄﾗﾌﾞﾙ状況
            '----------------------------
            If SetDatasNippoEqError(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If

            'Excelﾌｧｲﾙ保存
            objExcel.ExcelSave()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_入庫実績)                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_入庫実績)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoRstIN(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '----------------------------
            ' 入庫実績
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        TMST_ITEM.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "      , COUNT(XRST_PRODUCT_IN.FPALLET_ID) AS PALLET_CNT "
            strSQL &= vbCrLf & "      , SUM(XRST_PRODUCT_IN.FTR_VOL) AS KONSU "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "      XRST_PRODUCT_IN "
            strSQL &= vbCrLf & "    , TMST_ITEM "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRST_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            strSQL &= vbCrLf & "AND   XRST_PRODUCT_IN.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & "AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XARTICLE_TYPE_CODE_J03 & "' )"
            strSQL &= vbCrLf & "GROUP BY   XRST_PRODUCT_IN.XSOUGYOU_DT "
            strSQL &= vbCrLf & "         , TMST_ITEM.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "ORDER BY TMST_ITEM.XARTICLE_TYPE_CODE "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_PRODUCT_IN"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                        Case XARTICLE_TYPE_CODE_J01
                            '(製品)
                            Call objExcel.SetCellValue("G15", TO_STRING(objRow("KONSU")))           '紺数
                            Call objExcel.SetCellValue("G16", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XARTICLE_TYPE_CODE_J02
                            '(中間品)
                            Call objExcel.SetCellValue("L15", TO_STRING(objRow("KONSU")))           '紺数
                            Call objExcel.SetCellValue("L16", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XARTICLE_TYPE_CODE_J03
                            '(包材)
                            Call objExcel.SetCellValue("W15", TO_STRING(objRow("KONSU")))           '紺数
                            Call objExcel.SetCellValue("W16", TO_STRING(objRow("PALLET_CNT")))      'PL数
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_出荷状況)                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_出荷状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoRstOUT(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '----------------------------
            ' 出荷状況
            '----------------------------
            '----------------------------
            ' 積別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XTUMI_HOUKOU "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   XRST_OUT.XSYUKKA_D = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUKOU IN ('" & XTUMI_HOUKOU_JBACK & "' "
            strSQL &= vbCrLf & "                                       ,'" & XTUMI_HOUKOU_JWING & "' "
            strSQL &= vbCrLf & "                                       ,'" & XTUMI_HOUKOU_JSIDE & "' ) "
            strSQL &= vbCrLf & " GROUP BY   XRST_OUT.XSYUKKA_D "
            strSQL &= vbCrLf & "          , XRST_OUT.XTUMI_HOUKOU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUKOU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XTUMI_HOUKOU"))
                        Case XTUMI_HOUKOU_JBACK
                            '(後積み)
                            Call objExcel.SetCellValue("G20", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUKOU_JWING
                            '(両横積み)
                            Call objExcel.SetCellValue("K20", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUKOU_JSIDE
                            '(片横積み)
                            Call objExcel.SetCellValue("O20", TO_STRING(objRow("NUM")))           '数量
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '----------------------------
            ' 手段別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XTUMI_HOUHOU "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   XRST_OUT.XSYUKKA_D = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUHOU IN ('" & XTUMI_HOUHOU_JP & "' "
            strSQL &= vbCrLf & "                                       ,'" & XTUMI_HOUHOU_JB & "' "
            strSQL &= vbCrLf & "                                       ,'" & XTUMI_HOUHOU_JL & "' ) "
            strSQL &= vbCrLf & " GROUP BY   XRST_OUT.XSYUKKA_D "
            strSQL &= vbCrLf & "          , XRST_OUT.XTUMI_HOUHOU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUHOU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XTUMI_HOUHOU"))
                        Case XTUMI_HOUHOU_JP
                            '(PL積み)
                            Call objExcel.SetCellValue("G22", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ積み)
                            Call objExcel.SetCellValue("K22", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUHOU_JL
                            '(ﾛｰﾀﾞｰ積み)
                            Call objExcel.SetCellValue("O22", TO_STRING(objRow("NUM")))           '数量
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '----------------------------
            ' 手段別
            '----------------------------
            For ii As Integer = XTUMI_HOUHOU_JP To XTUMI_HOUHOU_JL
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "       COUNT(XRST_OUT.XHENSEI_NO_OYA) AS NUM "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "       XRST_OUT "
                strSQL &= vbCrLf & " WHERE 1=1 "
                strSQL &= vbCrLf & " AND   XRST_OUT.XSYUKKA_D = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
                strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUHOU =" & TO_STRING(ii)
                strSQL &= vbCrLf & " GROUP BY   XRST_OUT.XSYUKKA_D "
                strSQL &= vbCrLf & "          , XRST_OUT.XHENSEI_NO_OYA "
                strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUHOU "

                ObjDb.SQL = strSQL
                strDataSetName = "XRST_OUT"
                ObjDb.GetDataSet(strDataSetName, objData)
                intRecCnt = objData.Tables(strDataSetName).Rows.Count
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case ii
                        Case XTUMI_HOUHOU_JP
                            '(PL積み)
                            Call objExcel.SetCellValue("G24", TO_STRING(intRecCnt))             '数量

                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ積み)
                            Call objExcel.SetCellValue("K24", TO_STRING(intRecCnt))             '数量

                        Case XTUMI_HOUHOU_JL
                            '(ﾛｰﾀﾞｰ積み)
                            Call objExcel.SetCellValue("O24", TO_STRING(intRecCnt))             '数量
                    End Select
                Next

                'ﾃﾞｰﾀｾｯﾄｸﾘｱ
                objData.Reset()
            Next ii
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 輸送別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XSAIMOKU "
            strSQL &= vbCrLf & "       , COUNT(XRST_OUT.FPALLET_ID) AS PALLET_CNT "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   XRST_OUT.XSYUKKA_D = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & " AND   XRST_OUT.XSAIMOKU IN ('" & XSAIMOKU_JISOU & "' "
            strSQL &= vbCrLf & "                                       ,'" & XSAIMOKU_JHOKYUU & "' "
            strSQL &= vbCrLf & "                                       ,'" & XSAIMOKU_JIDOU & "' "
            strSQL &= vbCrLf & "                                       ,'" & XSAIMOKU_JHAISOU & "' ) "
            strSQL &= vbCrLf & " GROUP BY   XRST_OUT.XSYUKKA_D "
            strSQL &= vbCrLf & "          , XRST_OUT.XSAIMOKU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XSAIMOKU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XSAIMOKU"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/12 日報変更
                        '' ''Case XSAIMOKU_JISOU
                        '' ''    '(移送)
                        '' ''    Call objExcel.SetCellValue("K24", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("K25", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JHOKYUU
                        '' ''    '(補給)
                        '' ''    Call objExcel.SetCellValue("O24", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("O25", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JIDOU
                        '' ''    '(移動)
                        '' ''    Call objExcel.SetCellValue("S24", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("S25", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JHAISOU
                        '' ''    '(配送(直送))
                        '' ''    Call objExcel.SetCellValue("W24", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("W25", TO_STRING(objRow("PALLET_CNT")))      'PL数
                        Case XSAIMOKU_JISOU
                            '(移送)
                            Call objExcel.SetCellValue("K26", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("K27", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JHOKYUU
                            '(補給)
                            Call objExcel.SetCellValue("O26", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("O27", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JIDOU
                            '(移動)
                            Call objExcel.SetCellValue("S26", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("S27", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JHAISOU
                            '(配送(直送))
                            Call objExcel.SetCellValue("W26", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("W27", TO_STRING(objRow("PALLET_CNT")))      'PL数
                            'JobMate:S.Ouchi 2013/11/12 日報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_終了時間)                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_終了時間)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoEndTime(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '----------------------------
            ' 終了時間
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        TO_CHAR(XRST_SOUGYOU.XSYUKKO_END_DT,'HH24:MI') AS XSYUKKO_END_DT "
            strSQL &= vbCrLf & "      , TO_CHAR(XRST_SOUGYOU.XSYUKKA_END_DT,'HH24:MI') AS XSYUKKA_END_DT "
            strSQL &= vbCrLf & "      , TO_CHAR(XRST_SOUGYOU.XDATA_TENSOU_DT,'HH24:MI') AS XDATA_TENSOU_DT "
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 日報変更
            strSQL &= vbCrLf & "      , XRST_SOUGYOU.XTANA_BLOCK_AKI "
            'JobMate:S.Ouchi 2013/11/13 日報変更
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "      XRST_SOUGYOU "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRST_SOUGYOU.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_PRODUCT_IN"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Call objExcel.SetCellValue("AK19", TO_STRING(objRow("XSYUKKO_END_DT")))         '出庫終了
                    Call objExcel.SetCellValue("AK20", TO_STRING(objRow("XSYUKKA_END_DT")))         '出荷終了
                    Call objExcel.SetCellValue("AK21", TO_STRING(objRow("XDATA_TENSOU_DT")))        '翌日ﾃﾞｰﾀ転送
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/13 日報変更
                    Call objExcel.SetCellValue("AL32", TO_STRING(TO_INTEGER(objRow("XTANA_BLOCK_AKI"))))    '空棚ﾌﾞﾛｯｸ数
                    'JobMate:S.Ouchi 2013/11/13 日報変更
                    '↑↑↑↑↑↑************************************************************************************************************
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_ﾗｯｸ内在庫状況)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_ﾗｯｸ内在庫状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoZaiko(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '----------------------------
            ' ﾗｯｸ内在庫状況
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        TMST_ITEM.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "      , SUM(XRPT_ZAIKO.XSTOCK_PL) AS PALLET_CNT "
            strSQL &= vbCrLf & "      , SUM(XRPT_ZAIKO.XSTOCK_KOSOU) AS KONSU "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "      XRPT_ZAIKO "
            strSQL &= vbCrLf & "    , TMST_ITEM "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRPT_ZAIKO.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            strSQL &= vbCrLf & "AND   XRPT_ZAIKO.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & "AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XARTICLE_TYPE_CODE_J03 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XARTICLE_TYPE_CODE_J00 & "' )"
            strSQL &= vbCrLf & "GROUP BY   XRPT_ZAIKO.XSOUGYOU_DT "
            strSQL &= vbCrLf & "         , TMST_ITEM.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "ORDER BY TMST_ITEM.XARTICLE_TYPE_CODE "

            ObjDb.SQL = strSQL
            strDataSetName = "XRPT_ZAIKO"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/12 日報変更
                        '' ''Case XARTICLE_TYPE_CODE_J01
                        '' ''    '(製品)
                        '' ''    Call objExcel.SetCellValue("H29", TO_STRING(objRow("KONSU")))           '紺数
                        '' ''    Call objExcel.SetCellValue("H30", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XARTICLE_TYPE_CODE_J02
                        '' ''    '(中間品)
                        '' ''    Call objExcel.SetCellValue("M29", TO_STRING(objRow("KONSU")))           '紺数
                        '' ''    Call objExcel.SetCellValue("M30", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XARTICLE_TYPE_CODE_J03
                        '' ''    '(包材)
                        '' ''    Call objExcel.SetCellValue("R29", TO_STRING(objRow("KONSU")))           '紺数
                        '' ''    Call objExcel.SetCellValue("R30", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XARTICLE_TYPE_CODE_J00
                        '' ''    '(空ﾊﾟﾚｯﾄ)
                        '' ''    Call objExcel.SetCellValue("W29", TO_STRING(objRow("KONSU")))           '紺数
                        '' ''    Call objExcel.SetCellValue("W30", TO_STRING(objRow("PALLET_CNT")))      'PL数
                        Case XARTICLE_TYPE_CODE_J01
                            '(製品)
                            Call objExcel.SetCellValue("H31", TO_STRING(objRow("KONSU")))           '梱数
                            Call objExcel.SetCellValue("H32", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XARTICLE_TYPE_CODE_J02
                            '(中間品)
                            Call objExcel.SetCellValue("M31", TO_STRING(objRow("KONSU")))           '梱数
                            Call objExcel.SetCellValue("M32", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XARTICLE_TYPE_CODE_J03
                            '(包材)
                            Call objExcel.SetCellValue("R31", TO_STRING(objRow("KONSU")))           '梱数
                            Call objExcel.SetCellValue("R32", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XARTICLE_TYPE_CODE_J00
                            '(空ﾊﾟﾚｯﾄ)
                            Call objExcel.SetCellValue("W31", TO_STRING(objRow("KONSU")))           '梱数
                            Call objExcel.SetCellValue("W32", TO_STRING(objRow("PALLET_CNT")))      'PL数
                            'JobMate:S.Ouchi 2013/11/12 日報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '' '' ''↓↓↓↓↓↓************************************************************************************************************
            '' '' ''JobMate:S.Ouchi 2013/11/12 日報変更
            ' '' ''Dim intAKI_BLK As Integer
            ' '' ''intAKI_BLK = akiTanaDisplay()
            ' '' ''Call objExcel.SetCellValue("AL32", TO_STRING(intAKI_BLK))                               'ﾌﾞﾛｯｸ数
            '' '' ''JobMate:S.Ouchi 2013/11/12 日報変更
            '' '' ''↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_設備ﾄﾗﾌﾞﾙ状況)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_設備ﾄﾗﾌﾞﾙ状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoEqError(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '----------------------------
            ' 設備ﾄﾗﾌﾞﾙ状況
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "
            strSQL &= vbCrLf & "      , COUNT(XRST_EQ_ERROR.FLOG_NO) AS LOG_CNT "
            strSQL &= vbCrLf & "      , SUM(XRST_EQ_ERROR.XTEISI_JIKAN) AS XTEISI_JIKAN "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "        XRST_EQ_ERROR "     '【設備異常ログ】
            strSQL &= vbCrLf & "      , TSTS_EQ_CTRL "     '【設備状況】
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRST_EQ_ERROR.FEQ_ID = TSTS_EQ_CTRL.FEQ_ID "
            strSQL &= vbCrLf & "AND   XRST_EQ_ERROR.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & "AND   TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 IN ('" & XEQ_RPT_KUBUN01_STC01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_RTN01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_TKR01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_TANA01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_CV01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_RTN02 & "' )"
            strSQL &= vbCrLf & "GROUP BY   XRST_EQ_ERROR.XSOUGYOU_DT "
            strSQL &= vbCrLf & "         , TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "
            strSQL &= vbCrLf & "ORDER BY TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_EQ_ERROR"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XEQ_RPT_KUBUN01"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/12 日報変更
                        '' ''Case XEQ_RPT_KUBUN01_STC01
                        '' ''    '(1階_STC)
                        '' ''    Call objExcel.SetCellValue("H37", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("H38", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_RTN01
                        '' ''    '(1階_RTN)
                        '' ''    Call objExcel.SetCellValue("L37", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("L38", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_TKR01
                        '' ''    '(1階_TKR)
                        '' ''    Call objExcel.SetCellValue("P37", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("P38", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_TANA01
                        '' ''    '(1階_入出棚)
                        '' ''    Call objExcel.SetCellValue("T37", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("T38", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_CV01
                        '' ''    '(1階_出庫CV)
                        '' ''    Call objExcel.SetCellValue("X37", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("X38", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_RTN02
                        '' ''    '(2階_RTN)
                        '' ''    Call objExcel.SetCellValue("AB44", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("AB45", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)
                        Case XEQ_RPT_KUBUN01_STC01
                            '(1階_STC)
                            Call objExcel.SetCellValue("H48", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("H49", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_RTN01
                            '(1階_RTN)
                            Call objExcel.SetCellValue("L48", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("L49", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_TKR01
                            '(1階_TKR)
                            Call objExcel.SetCellValue("P48", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("P49", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_TANA01
                            '(1階_入出棚)
                            Call objExcel.SetCellValue("T48", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("T49", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_CV01
                            '(1階_出庫CV)
                            Call objExcel.SetCellValue("X48", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("X49", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_RTN02
                            '(2階_RTN)
                            Call objExcel.SetCellValue("AB55", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("AB56", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)
                            'JobMate:S.Ouchi 2013/11/12 日報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/12 日報変更
#Region " ﾃﾞｰﾀｾｯﾄ処理(日報_設備稼働状況)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_設備稼働状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasNippoEqRun(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            Dim strDt As String = dtSearchDate.ToString("yyyy/MM/dd")

            '1F運転時間 ( 1号機～14号機 , 時/分/秒 )
            Dim strEQ_ID_1F(,) As String = {{"JOTHY01_X048601", "JOTHY01_X048602", "JOTHY01_X048603"}, _
                                            {"JOTHY01_X048604", "JOTHY01_X048605", "JOTHY01_X048606"}, _
                                            {"JOTHY01_X048607", "JOTHY01_X048608", "JOTHY01_X048609"}, _
                                            {"JOTHY01_X048610", "JOTHY01_X048611", "JOTHY01_X048612"}, _
                                            {"JOTHY01_X048613", "JOTHY01_X048614", "JOTHY01_X048615"}, _
                                            {"JOTHY01_X048616", "JOTHY01_X048617", "JOTHY01_X048618"}, _
                                            {"JOTHY01_X048619", "JOTHY01_X048620", "JOTHY01_X048621"}, _
                                            {"JOTHY01_X048622", "JOTHY01_X048623", "JOTHY01_X048624"}, _
                                            {"JOTHY01_X048625", "JOTHY01_X048626", "JOTHY01_X048627"}, _
                                            {"JOTHY01_X048628", "JOTHY01_X048629", "JOTHY01_X048630"}, _
                                            {"JOTHY01_X048631", "JOTHY01_X048632", "JOTHY01_X048633"}, _
                                            {"JOTHY01_X048634", "JOTHY01_X048635", "JOTHY01_X048636"}, _
                                            {"JOTHY01_X048637", "JOTHY01_X048638", "JOTHY01_X048639"}, _
                                            {"JOTHY01_X048640", "JOTHY01_X048641", "JOTHY01_X048642"}}
            '2F運転時間 ( 1号機～14号機 , 時/分/秒 )
            Dim strEQ_ID_2F(,) As String = {{"JOTHY05_X048601", "JOTHY05_X048602", "JOTHY05_X048603"}, _
                                            {"JOTHY05_X048604", "JOTHY05_X048605", "JOTHY05_X048606"}, _
                                            {"JOTHY05_X048607", "JOTHY05_X048608", "JOTHY05_X048609"}, _
                                            {"JOTHY05_X048610", "JOTHY05_X048611", "JOTHY05_X048612"}, _
                                            {"JOTHY05_X048613", "JOTHY05_X048614", "JOTHY05_X048615"}, _
                                            {"JOTHY05_X048616", "JOTHY05_X048617", "JOTHY05_X048618"}, _
                                            {"JOTHY05_X048619", "JOTHY05_X048620", "JOTHY05_X048621"}, _
                                            {"JOTHY05_X048622", "JOTHY05_X048623", "JOTHY05_X048624"}, _
                                            {"JOTHY05_X048625", "JOTHY05_X048626", "JOTHY05_X048627"}, _
                                            {"JOTHY05_X048628", "JOTHY05_X048629", "JOTHY05_X048630"}, _
                                            {"JOTHY05_X048631", "JOTHY05_X048632", "JOTHY05_X048633"}, _
                                            {"JOTHY05_X048634", "JOTHY05_X048635", "JOTHY05_X048636"}, _
                                            {"JOTHY05_X048637", "JOTHY05_X048638", "JOTHY05_X048639"}, _
                                            {"JOTHY05_X048640", "JOTHY05_X048641", "JOTHY05_X048642"}}

            '1F RTN運転時間 ( 時/分/秒 )
            Dim strEQ_ID_RTN_1F() As String = {"JOTHY02_X048601", "JOTHY02_X048602", "JOTHY02_X048603"}

            '2F RTN運転時間 ( 時/分/秒 )
            Dim strEQ_ID_RTN_2F() As String = {"JOTHY04_X048601", "JOTHY04_X048602", "JOTHY04_X048603"}

            '運転算出用基本時間
            Dim dtmBASE As Date = TO_DATE("00:00:00")

            '----------------------------
            ' ｸﾚｰﾝ運転状況
            '----------------------------
            '2F運転時間 ( 1号機～14号機 , 時/分/秒 )
            Dim strRun(14) As String
            Dim str1F_H As String   '1F_時
            Dim str1F_M As String   '1F_分
            Dim str1F_S As String   '1F_秒
            Dim str2F_H As String   '2F_時
            Dim str2F_M As String   '2F_分
            Dim str2F_S As String   '2F_秒

            For ii As Integer = 1 To 14
                Dim dtmRUN As TimeSpan
                Dim dtmRUN_1F As Date
                Dim dtmRUN_2F As Date
                Dim tmsRUN_1F As TimeSpan
                Dim tmsRUN_2F As TimeSpan

                str1F_H = "0"       '1F_時
                str1F_M = "00"      '1F_分
                str1F_S = "00"      '1F_秒
                str2F_H = "0"       '2F_時
                str2F_M = "00"      '2F_分
                str2F_S = "00"      '2F_秒

                '----------------------------
                ' 運転状況SQL
                '----------------------------
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "        XRST_EQ_RUN.FEQ_ID"
                strSQL &= vbCrLf & "       ,XRST_EQ_RUN.FEQ_STS"
                strSQL &= vbCrLf & "FROM "
                strSQL &= vbCrLf & "        XRST_EQ_RUN "
                strSQL &= vbCrLf & "WHERE 1=1 "
                strSQL &= vbCrLf & "AND   XRST_EQ_RUN.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
                strSQL &= vbCrLf & "AND   XRST_EQ_RUN.FEQ_ID IN ('" & strEQ_ID_1F(ii - 1, 0) & "' "
                strSQL &= vbCrLf & "                            ,'" & strEQ_ID_1F(ii - 1, 1) & "' "
                strSQL &= vbCrLf & "                            ,'" & strEQ_ID_1F(ii - 1, 2) & "' "
                strSQL &= vbCrLf & "                            ,'" & strEQ_ID_2F(ii - 1, 0) & "' "
                strSQL &= vbCrLf & "                            ,'" & strEQ_ID_2F(ii - 1, 1) & "' "
                strSQL &= vbCrLf & "                            ,'" & strEQ_ID_2F(ii - 1, 2) & "' )"
                strSQL &= vbCrLf & "ORDER BY XRST_EQ_RUN.FEQ_ID "

                ObjDb.SQL = strSQL
                strDataSetName = "XRST_EQ_ERROR"
                ObjDb.GetDataSet(strDataSetName, objData)
                intRecCnt = objData.Tables(strDataSetName).Rows.Count
                If intRecCnt > 0 Then
                    For Each objRow In objData.Tables(strDataSetName).Rows
                        Select Case TO_STRING(objRow("FEQ_ID"))
                            Case strEQ_ID_1F(ii - 1, 0)
                                '1F_時
                                str1F_H = TO_STRING(objRow("FEQ_STS"))          '1F_時

                            Case strEQ_ID_1F(ii - 1, 1)
                                '1F_分
                                str1F_M = TO_STRING(objRow("FEQ_STS"))          '1F_分

                            Case strEQ_ID_1F(ii - 1, 2)
                                '1F_秒
                                str1F_S = TO_STRING(objRow("FEQ_STS"))          '1F_秒

                            Case strEQ_ID_2F(ii - 1, 0)
                                '2F_時
                                str2F_H = TO_STRING(objRow("FEQ_STS"))          '2F_時

                            Case strEQ_ID_2F(ii - 1, 1)
                                '2F_分
                                str2F_M = TO_STRING(objRow("FEQ_STS"))          '2F_分

                            Case strEQ_ID_2F(ii - 1, 2)
                                '2F_秒
                                str2F_S = TO_STRING(objRow("FEQ_STS"))          '2F_秒

                        End Select
                    Next
                End If

                'ﾃﾞｰﾀｾｯﾄｸﾘｱ
                objData.Reset()

                dtmRUN_1F = TO_DATE(str1F_H & ":" & str1F_M & ":" & str1F_S)
                dtmRUN_2F = TO_DATE(str2F_H & ":" & str2F_M & ":" & str2F_S)
                tmsRUN_1F = dtmRUN_1F.Subtract(dtmBASE)
                tmsRUN_2F = dtmRUN_2F.Subtract(dtmBASE)

                dtmRUN = tmsRUN_1F.Add(tmsRUN_2F)
                strRun(ii) = Int(dtmRUN.TotalHours) & ":" & Right("00" & dtmRUN.Minutes, 2)

            Next ii


            '合計時間
            Dim strRun_ALL As String = ""
            Dim tmsRUN_ALL As TimeSpan
            For ii As Integer = 1 To 14
                Dim dtmRUN As Date
                Dim tmsRUN As TimeSpan
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2016/07/21 日報異常の回避
                '' ''dtmRUN = strRun(ii) & ":00"
                '' ''tmsRUN = dtmRUN.Subtract(dtmBASE)
                '' ''tmsRUN_ALL = tmsRUN_ALL.Add(tmsRUN)
                Try
                    Dim strH As String
                    Dim strM As String
                    strH = Mid(strRun(ii), 1, TO_INTEGER(strRun(ii).IndexOf(":")))
                    strM = Right(strRun(ii), 2)
                    dtmRUN = dtmBASE
                    dtmRUN = DateAdd(DateInterval.Hour, TO_INTEGER(strH), dtmRUN)
                    dtmRUN = DateAdd(DateInterval.Minute, TO_INTEGER(strM), dtmRUN)
                    tmsRUN = dtmRUN.Subtract(dtmBASE)
                    tmsRUN_ALL = tmsRUN_ALL.Add(tmsRUN)
                Catch ex As Exception
                    Call ComError(ex, MeSyoriID)
                    Throw ex
                End Try
                'JobMate:S.Ouchi 2016/07/21 日報異常の回避
                '↑↑↑↑↑↑************************************************************************************************************
            Next ii
            strRun_ALL = Int(tmsRUN_ALL.TotalHours) & ":" & Right("00" & tmsRUN_ALL.Minutes, 2)


            '----------------------------
            ' RTN運転状況
            '----------------------------
            Dim strRun1F_RTN As String = ""     '1F RTN 運転時間
            Dim strRun2F_RTN As String = ""     '2F RTN 運転時間
            Dim str1F_RTN_H As String = "0"     '1F_時
            Dim str1F_RTN_M As String = "00"    '1F_分
            Dim str1F_RTN_S As String = "00"    '1F_秒
            Dim str2F_RTN_H As String = "0"     '2F_時
            Dim str2F_RTN_M As String = "00"    '2F_分
            Dim str2F_RTN_S As String = "00"    '2F_秒

            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        XRST_EQ_RUN.FEQ_ID"
            strSQL &= vbCrLf & "       ,XRST_EQ_RUN.FEQ_STS"
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "        XRST_EQ_RUN "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRST_EQ_RUN.XSOUGYOU_DT = TO_DATE('" & strDt & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & "AND   XRST_EQ_RUN.FEQ_ID IN ('" & strEQ_ID_RTN_1F(0) & "' "
            strSQL &= vbCrLf & "                            ,'" & strEQ_ID_RTN_1F(1) & "' "
            strSQL &= vbCrLf & "                            ,'" & strEQ_ID_RTN_1F(2) & "' "
            strSQL &= vbCrLf & "                            ,'" & strEQ_ID_RTN_2F(0) & "' "
            strSQL &= vbCrLf & "                            ,'" & strEQ_ID_RTN_2F(1) & "' "
            strSQL &= vbCrLf & "                            ,'" & strEQ_ID_RTN_2F(2) & "' )"
            strSQL &= vbCrLf & "ORDER BY XRST_EQ_RUN.FEQ_ID "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_EQ_ERROR"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_STRING(objRow("FEQ_ID"))
                        Case strEQ_ID_RTN_1F(0)
                            '1F_時
                            str1F_RTN_H = TO_STRING(objRow("FEQ_STS"))      '1F_時

                        Case strEQ_ID_RTN_1F(1)
                            '1F_分
                            str1F_RTN_M = TO_STRING(objRow("FEQ_STS"))      '1F_分

                        Case strEQ_ID_RTN_1F(2)
                            '1F_秒
                            str1F_RTN_S = TO_STRING(objRow("FEQ_STS"))      '1F_秒

                        Case strEQ_ID_RTN_2F(0)
                            '2F_時
                            str2F_RTN_H = TO_STRING(objRow("FEQ_STS"))      '2F_時

                        Case strEQ_ID_RTN_2F(1)
                            '2F_分
                            str2F_RTN_M = TO_STRING(objRow("FEQ_STS"))      '2F_分

                        Case strEQ_ID_RTN_2F(2)
                            '2F_秒
                            str2F_RTN_S = TO_STRING(objRow("FEQ_STS"))      '2F_秒

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            strRun1F_RTN = str1F_RTN_H & ":" & Right("00" & str1F_RTN_M, 2)     '1F RTN 運転時間
            strRun2F_RTN = str2F_RTN_H & ":" & Right("00" & str2F_RTN_M, 2)     '2F RTN 運転時間

            '----------------------------
            ' Excelｼｰﾄに書込
            '----------------------------
            Call objExcel.SetCellValue("G38", strRun1F_RTN)                     '1F RTN 運転時間
            Call objExcel.SetCellValue("K38", strRun2F_RTN)                     '2F RTN 運転時間

            Call objExcel.SetCellValue("G41", strRun(1))                        '1号機
            Call objExcel.SetCellValue("K41", strRun(2))                        '2号機
            Call objExcel.SetCellValue("O41", strRun(3))                        '3号機
            Call objExcel.SetCellValue("S41", strRun(4))                        '4号機
            Call objExcel.SetCellValue("W41", strRun(5))                        '5号機
            Call objExcel.SetCellValue("AA41", strRun(6))                       '6号機
            Call objExcel.SetCellValue("AE41", strRun(7))                       '7号機
            Call objExcel.SetCellValue("AI41", strRun(8))                       '8号機
            Call objExcel.SetCellValue("AM41", strRun(9))                       '9号機
            Call objExcel.SetCellValue("G43", strRun(10))                        '10号機
            Call objExcel.SetCellValue("K43", strRun(11))                       '11号機
            Call objExcel.SetCellValue("O43", strRun(12))                       '12号機
            Call objExcel.SetCellValue("S43", strRun(13))                       '13号機
            Call objExcel.SetCellValue("W43", strRun(14))                       '14号機

            Call objExcel.SetCellValue("AM43", strRun_ALL)                      '合計

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/12 日報変更
    '↑↑↑↑↑↑************************************************************************************************************

#End Region
#Region "  日報CSV作成処理                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''日報CSV作成処理
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strFilePath">作成ﾌｧｲﾙﾊﾟｽ</param>
    ''' <param name="strFileName">作成ﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function MakeCSVNippo(ByRef objExcel As clsExcelAppCtl _
                                          , ByVal strFilePath As String _
                                          , ByVal strFileName As String _
                                          ) As Boolean
        Dim blnRet As Boolean = True
        Dim lstData As List(Of String()) = Nothing
        Dim strData() As String
        Try
            '***********************
            '初期設定
            '***********************
            '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
            Dim strFilePathName As String = ""
            strFilePathName &= strFilePath
            strFilePathName &= strFileName

            'ﾃﾞｰﾀｾｯﾄｼｰﾄ取得
            Call objExcel.SheetOpen(1)
            lstData = New List(Of String())
            '----------------------------
            ' 入庫実績
            '----------------------------
            '紺数
            ReDim strData(3)
            strData(0) = objExcel.GetCellValue("G15")    '(製品)
            strData(1) = objExcel.GetCellValue("L15")    '(中間品)
            strData(2) = objExcel.GetCellValue("Q15")    '(合計)
            strData(3) = objExcel.GetCellValue("W15")    '(包材)
            lstData.Add(strData)

            'PL数
            ReDim strData(3)
            strData(0) = objExcel.GetCellValue("G16")    '(製品)
            strData(1) = objExcel.GetCellValue("L16")    '(中間品)
            strData(2) = objExcel.GetCellValue("Q16")    '(合計)
            strData(3) = objExcel.GetCellValue("W16")    '(包材)
            lstData.Add(strData)

            '----------------------------
            ' 出荷状況
            '----------------------------
            '----------------------------
            ' 積別
            '----------------------------
            '数量
            ReDim strData(3)
            strData(0) = objExcel.GetCellValue("G20")    '(後積み)
            strData(1) = objExcel.GetCellValue("K20")    '(両横積み)
            strData(2) = objExcel.GetCellValue("O20")    '(片横積み)
            strData(3) = objExcel.GetCellValue("S20")    '(合計)
            lstData.Add(strData)

            '----------------------------
            ' 手段別
            '----------------------------
            '数量
            ReDim strData(3)
            strData(0) = objExcel.GetCellValue("G22")    '(PL積み)
            strData(1) = objExcel.GetCellValue("K22")    '(ﾊﾞﾗ積み)
            strData(2) = objExcel.GetCellValue("O22")    '(ﾛｰﾀﾞｰ積み)
            strData(3) = objExcel.GetCellValue("S22")    '(合計)
            lstData.Add(strData)


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '----------------------------
            ' 手段別(台数)
            '----------------------------
            '数量
            ReDim strData(3)
            strData(0) = objExcel.GetCellValue("G24")    '(PL積み)
            strData(1) = objExcel.GetCellValue("K24")    '(ﾊﾞﾗ積み)
            strData(2) = objExcel.GetCellValue("O24")    '(ﾛｰﾀﾞｰ積み)
            strData(3) = objExcel.GetCellValue("S24")    '(合計)
            lstData.Add(strData)
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 輸送別
            '----------------------------
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            ' '' ''数量
            '' ''ReDim strData(4)
            '' ''strData(0) = objExcel.GetCellValue("K24")    '(移送)
            '' ''strData(1) = objExcel.GetCellValue("O24")    '(補給)
            '' ''strData(2) = objExcel.GetCellValue("S24")    '(移動)
            '' ''strData(3) = objExcel.GetCellValue("W24")    '(配送(直送))
            '' ''strData(4) = objExcel.GetCellValue("AE24")   '(合計)
            '' ''lstData.Add(strData)

            ' '' ''PL数
            '' ''ReDim strData(4)
            '' ''strData(0) = objExcel.GetCellValue("K25")    '(移送)
            '' ''strData(1) = objExcel.GetCellValue("O25")    '(補給)
            '' ''strData(2) = objExcel.GetCellValue("S25")    '(移動)
            '' ''strData(3) = objExcel.GetCellValue("W25")    '(配送(直送))
            '' ''strData(4) = objExcel.GetCellValue("AE25")   '(合計)
            '' ''lstData.Add(strData)
            '数量
            ReDim strData(4)
            strData(0) = objExcel.GetCellValue("K26")    '(移送)
            strData(1) = objExcel.GetCellValue("O26")    '(補給)
            strData(2) = objExcel.GetCellValue("S26")    '(移動)
            strData(3) = objExcel.GetCellValue("W26")    '(配送(直送))
            strData(4) = objExcel.GetCellValue("AE26")   '(合計)
            lstData.Add(strData)

            'PL数
            ReDim strData(4)
            strData(0) = objExcel.GetCellValue("K27")    '(移送)
            strData(1) = objExcel.GetCellValue("O27")    '(補給)
            strData(2) = objExcel.GetCellValue("S27")    '(移動)
            strData(3) = objExcel.GetCellValue("W27")    '(配送(直送))
            strData(4) = objExcel.GetCellValue("AE27")   '(合計)
            lstData.Add(strData)
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************

            '----------------------------
            ' 終了時間
            '----------------------------
            Dim dtTemp As Date
            ReDim strData(0)
            dtTemp = objExcel.GetCellDateValue("AK19")    '(出庫終了)
            If IsNull(dtTemp) = False Then
                strData(0) = dtTemp.ToString("HH:mm")
            Else
                strData(0) = ""
            End If
            lstData.Add(strData)
            ReDim strData(0)
            dtTemp = objExcel.GetCellDateValue("AK20")    '(出荷終了)
            If IsNull(dtTemp) = False Then
                strData(0) = dtTemp.ToString("HH:mm")
            Else
                strData(0) = ""
            End If
            lstData.Add(strData)
            ReDim strData(0)
            dtTemp = objExcel.GetCellDateValue("AK21")    '(翌日ﾃﾞｰﾀ転送)
            If IsNull(dtTemp) = False Then
                strData(0) = dtTemp.ToString("HH:mm")
            Else
                strData(0) = ""
            End If
            lstData.Add(strData)

            '----------------------------
            ' ﾗｯｸ内在庫状況
            '----------------------------
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            ' '' ''紺数
            '' ''ReDim strData(4)
            '' ''strData(0) = objExcel.GetCellValue("H29")    '(製品)
            '' ''strData(1) = objExcel.GetCellValue("M29")    '(中間品)
            '' ''strData(2) = objExcel.GetCellValue("R29")    '(包材)
            '' ''strData(3) = objExcel.GetCellValue("W29")    '(空ﾊﾟﾚｯﾄ)
            '' ''strData(4) = objExcel.GetCellValue("AB29")   '(合計)
            '' ''lstData.Add(strData)

            ' '' ''PL数
            '' ''ReDim strData(5)
            '' ''strData(0) = objExcel.GetCellValue("H30")    '(製品)
            '' ''strData(1) = objExcel.GetCellValue("M30")    '(中間品)
            '' ''strData(2) = objExcel.GetCellValue("R30")    '(包材)
            '' ''strData(3) = objExcel.GetCellValue("W30")    '(空ﾊﾟﾚｯﾄ)
            '' ''strData(4) = objExcel.GetCellValue("AB30")   '(合計)
            '' ''strData(5) = objExcel.GetCellValue("AG30")   '(空棚数)
            '' ''lstData.Add(strData)

            ' '' ''PL数
            '' ''ReDim strData(3)
            '' ''strData(0) = objExcel.GetCellValue("H32")    '(製品・中間品)
            '' ''strData(1) = objExcel.GetCellValue("R32")    '(包材)
            '' ''strData(2) = objExcel.GetCellValue("W32")    '(空ﾊﾟﾚｯﾄ)
            '' ''strData(3) = objExcel.GetCellValue("AB32")   '(合計)
            '' ''lstData.Add(strData)
            '梱数
            ReDim strData(4)
            strData(0) = objExcel.GetCellValue("H31")    '(製品)
            strData(1) = objExcel.GetCellValue("M31")    '(中間品)
            strData(2) = objExcel.GetCellValue("R31")    '(包材)
            strData(3) = objExcel.GetCellValue("W31")    '(空ﾊﾟﾚｯﾄ)
            strData(4) = objExcel.GetCellValue("AB31")   '(合計)
            lstData.Add(strData)

            'PL数
            ReDim strData(6)
            strData(0) = objExcel.GetCellValue("H32")    '(製品)
            strData(1) = objExcel.GetCellValue("M32")    '(中間品)
            strData(2) = objExcel.GetCellValue("R32")    '(包材)
            strData(3) = objExcel.GetCellValue("W32")    '(空ﾊﾟﾚｯﾄ)
            strData(4) = objExcel.GetCellValue("AB32")   '(合計)
            strData(5) = objExcel.GetCellValue("AG32")   '(空棚数)
            strData(6) = objExcel.GetCellValue("AL32")   '空ﾌﾞﾛｯｸ数
            lstData.Add(strData)

            '在庫率
            ReDim strData(3)
            strData(0) = Format(TO_DECIMAL(objExcel.GetCellValue("H34")) * 100, "###0.0")   '(製品・中間品)
            strData(1) = Format(TO_DECIMAL(objExcel.GetCellValue("R34")) * 100, "###0.0")   '(包材)
            strData(2) = Format(TO_DECIMAL(objExcel.GetCellValue("W34")) * 100, "###0.0")   '(空ﾊﾟﾚｯﾄ)
            strData(3) = Format(TO_DECIMAL(objExcel.GetCellValue("AB34")) * 100, "###0.0")  '(合計)
            lstData.Add(strData)
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/14 日報CSV
            '----------------------------
            ' 設備稼働状況
            '----------------------------
            '件数
            ReDim strData(1)
            strData(0) = objExcel.GetCellValue("G38")    '(1階_RTN)
            strData(1) = objExcel.GetCellValue("K38")    '(2階_RTN)
            lstData.Add(strData)

            'STC-1～STC-9
            ReDim strData(8)
            strData(0) = objExcel.GetCellValue("G41")    '(STC-1)
            strData(1) = objExcel.GetCellValue("K41")    '(STC-2)
            strData(2) = objExcel.GetCellValue("O41")    '(STC-3)
            strData(3) = objExcel.GetCellValue("S41")    '(STC-4)
            strData(4) = objExcel.GetCellValue("W41")    '(STC-5)
            strData(5) = objExcel.GetCellValue("AA41")   '(STC-6)
            strData(6) = objExcel.GetCellValue("AE41")   '(STC-7)
            strData(7) = objExcel.GetCellValue("AI41")   '(STC-8)
            strData(8) = objExcel.GetCellValue("AM41")   '(STC-9)
            lstData.Add(strData)

            'STC-10～STC-14 , 合計
            ReDim strData(5)
            strData(0) = objExcel.GetCellValue("G43")    '(STC-10)
            strData(1) = objExcel.GetCellValue("K43")    '(STC-11)
            strData(2) = objExcel.GetCellValue("O43")    '(STC-12)
            strData(3) = objExcel.GetCellValue("S43")    '(STC-13)
            strData(4) = objExcel.GetCellValue("W43")    '(STC-14)
            strData(5) = objExcel.GetCellValue("AM43")   '(合計)
            lstData.Add(strData)
            'JobMate:S.Ouchi 2013/11/14 日報CSV
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 設備ﾄﾗﾌﾞﾙ状況
            '----------------------------
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/12 日報変更
            ' '' ''件数
            '' ''ReDim strData(4)
            '' ''strData(0) = objExcel.GetCellValue("H37")    '(1階_STC)
            '' ''strData(1) = objExcel.GetCellValue("L37")    '(1階_RTN)
            '' ''strData(2) = objExcel.GetCellValue("P37")    '(1階_TKR)
            '' ''strData(3) = objExcel.GetCellValue("T37")    '(1階_入出梱)
            '' ''strData(4) = objExcel.GetCellValue("X37")    '(1階_出庫CV)
            '' ''lstData.Add(strData)

            ' '' ''時間(分)
            '' ''ReDim strData(4)
            '' ''strData(0) = objExcel.GetCellValue("H38")    '(1階_STC)
            '' ''strData(1) = objExcel.GetCellValue("L38")    '(1階_RTN)
            '' ''strData(2) = objExcel.GetCellValue("P38")    '(1階_TKR)
            '' ''strData(3) = objExcel.GetCellValue("T38")    '(1階_入出梱)
            '' ''strData(4) = objExcel.GetCellValue("X38")    '(1階_出庫CV)
            '' ''lstData.Add(strData)

            ' '' ''件数
            '' ''ReDim strData(0)
            '' ''strData(0) = objExcel.GetCellValue("AB44")    '(2階_RTN)
            '' ''lstData.Add(strData)

            ' '' ''時間(分)
            '' ''ReDim strData(0)
            '' ''strData(0) = objExcel.GetCellValue("AB45")    '(2階_RTN)
            '' ''lstData.Add(strData)
            '件数
            ReDim strData(4)
            strData(0) = objExcel.GetCellValue("H48")    '(1階_STC)
            strData(1) = objExcel.GetCellValue("L48")    '(1階_RTN)
            strData(2) = objExcel.GetCellValue("P48")    '(1階_TKR)
            strData(3) = objExcel.GetCellValue("T48")    '(1階_入出梱)
            strData(4) = objExcel.GetCellValue("X48")    '(1階_出庫CV)
            lstData.Add(strData)

            '時間(分)
            ReDim strData(4)
            strData(0) = objExcel.GetCellValue("H49")    '(1階_STC)
            strData(1) = objExcel.GetCellValue("L49")    '(1階_RTN)
            strData(2) = objExcel.GetCellValue("P49")    '(1階_TKR)
            strData(3) = objExcel.GetCellValue("T49")    '(1階_入出梱)
            strData(4) = objExcel.GetCellValue("X49")    '(1階_出庫CV)
            lstData.Add(strData)

            '件数
            ReDim strData(0)
            strData(0) = objExcel.GetCellValue("AB55")    '(2階_RTN)
            lstData.Add(strData)

            '時間(分)
            ReDim strData(0)
            strData(0) = objExcel.GetCellValue("AB56")    '(2階_RTN)
            lstData.Add(strData)
            'JobMate:S.Ouchi 2013/11/12 日報変更
            '↑↑↑↑↑↑************************************************************************************************************

            '----------------------------
            ' CSV作成
            '----------------------------
            Call MakeCSV(lstData, strFilePath, strFileName)

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        End Try

        Return blnRet
    End Function
#End Region
#Region "　月報印刷処理　                      　　 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 月報印刷処理
    ''' </summary>
    ''' <param name="strSrcDateY">作成日付(年)</param>
    ''' <param name="strSrcDateM">作成日付(月)</param>
    ''' <param name="strFilePath">作成ﾌｧｲﾙﾊﾟｽ</param>
    ''' <param name="strFileName">作成ﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function makeReportGeppo(ByVal strSrcDateY As String _
                                          , ByVal strSrcDateM As String _
                                          , ByVal strFilePath As String _
                                          , ByVal strFileName As String _
                                          ) As Boolean

        Dim blnResult As Boolean = True     ' 戻り値
        'Excelｵﾌﾞｼﾞｪｸﾄ操作ｸﾗｽ
        Dim objExcelCtl As clsExcelAppCtl = New clsExcelAppCtl(Owner, ObjDb, ObjDbLog)

        Try
            '***********************
            '初期設定
            '***********************
            '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
            Dim strFilePathName As String = ""
            strFilePathName &= strFilePath
            strFilePathName &= strFileName

            ' ''***********************************************
            ' '' configﾌｧｲﾙから取得
            ' ''***********************************************
            ''Dim strPrtNM As String = gobjComFuncGMN.GET_CONFIG_INFO(GKEY_LBL_PRINTER)
            ' Temp帳票ﾌｧｲﾙ名
            Dim strDirectory As String = "..\Excel\Temp"

            '*============================
            '* ファイルのコピー
            '*============================
            Dim tempFilePath As String = strDirectory & "\" & "月報Temp.xls"
            ' ファイルの存在確認
            'If File.Exists(strFilePathName) = False Then
            '    '(ファイルがないとき)
            '    'ファイルをコピーする
            '    System.IO.File.Copy(tempFilePath, strFilePathName)
            'End If
            'ファイルをコピーする(上書き)
            System.IO.File.Copy(tempFilePath, strFilePathName, True)


            'Excelｵﾌﾞｼﾞｪｸﾄ作成
            strFilePathName = System.IO.Path.GetFullPath(strFilePathName)
            objExcelCtl.ExcelOpen(strFilePathName)

            '--------------------
            'ﾃﾞｰﾀｾｯﾄ
            '--------------------
            'ｼｰﾄへﾃﾞｰﾀをｾｯﾄ
            If SetDatasGeppo(objExcelCtl, strSrcDateY, strSrcDateM) = False Then
                Throw New UserException("ﾃﾞｰﾀのｾｯﾄに失敗しました。")
                blnResult = False
            End If

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnResult = False
            Throw ex

        Finally
            'Excelｵﾌﾞｼﾞｪｸﾄ解放
            objExcelCtl.ExcelClose(blnResult)
        End Try

        Return blnResult

    End Function
#End Region
#Region "  Excelｼｰﾄへのﾃﾞｰﾀｾｯﾄ処理(月報)            "
#Region " Excelｼｰﾄへのﾃﾞｰﾀｾｯﾄ処理(月報)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelｼｰﾄﾍのﾃﾞｰﾀｾｯﾄ処理(月報)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strSrcDateY">作成日付(年)</param>
    ''' <param name="strSrcDateM">作成日付(月)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasGeppo(ByRef objExcel As clsExcelAppCtl _
                                   , ByVal strSrcDateY As String _
                                   , ByVal strSrcDateM As String _
                                   ) _
                                   As Boolean
        Dim blnRet As Boolean = True

        Try

            'ﾃﾞｰﾀｾｯﾄｼｰﾄ取得
            Call objExcel.SheetOpen(1)

            'タイトル設定
            Dim strTitle As String = ""
            strTitle = ZERO_PAD(strSrcDateM, 2) & "月度千葉中央倉庫月報"

            Call objExcel.SetCellValue("B2", strTitle)

            Dim strSrcDt As String = strSrcDateY & ZERO_PAD(strSrcDateM, 2)
            '生成日付設定
            Dim strNow = Format(Now, "  yyyy年  MM月  dd日 （ddd）  ")
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '' ''Call objExcel.SetCellValue("AF3", strNow)
            Call objExcel.SetCellValue("AF9", strNow)
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '↑↑↑↑↑↑************************************************************************************************************

            '----------------------------
            ' 1.入出庫実績
            '----------------------------
            If SetDatasGeppoRstINOUT(objExcel, strSrcDt) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 2.出荷状況
            '----------------------------
            If SetDatasGeppoRstOUT(objExcel, strSrcDt) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 3.ﾗｯｸ在庫状況
            '----------------------------
            If SetDatasGeppoZaiko(objExcel, strSrcDt) = False Then
                blnRet = False
                Exit Try
            End If

            '----------------------------
            ' 5.設備ﾄﾗﾌﾞﾙ状況
            '----------------------------
            If SetDatasGeppoEqError(objExcel, strSrcDt) = False Then
                blnRet = False
                Exit Try
            End If

            'Excelﾌｧｲﾙ保存
            objExcel.ExcelSave()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(月報_入出庫実績)              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(月報_入出庫実績)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strSrcDt">作成日付(YYYYMM)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasGeppoRstINOUT(ByRef objExcel As clsExcelAppCtl, ByVal strSrcDt As String) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strSubSQL As String = ""                '合計取得ｻﾌﾞSQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer

        Dim decKONSU As Decimal = 0.0           ' 梱数(平均合計計算用)
        Dim decPL_CNT As Decimal = 0.0          ' PL数(平均合計計算用)

        Try

            '----------------------------
            ' 生産入庫
            '----------------------------
            '日単位での集計
            strSubSQL = ""
            strSubSQL &= vbCrLf & "		SELECT "
            strSubSQL &= vbCrLf & "		        XRST_PRODUCT_IN.XSOUGYOU_DT "                       ' 日付
            strSubSQL &= vbCrLf & "		      , TMST_ITEM.XARTICLE_TYPE_CODE  "                     ' 商品区分
            strSubSQL &= vbCrLf & "		      , SUM(XRST_PRODUCT_IN.FTR_VOL) AS KONSU  "            ' 紺数
            strSubSQL &= vbCrLf & "		      , COUNT(XRST_PRODUCT_IN.FPALLET_ID) AS PALLET_CNT  "  ' PL数
            strSubSQL &= vbCrLf & "		FROM "
            strSubSQL &= vbCrLf & "		      XRST_PRODUCT_IN "
            strSubSQL &= vbCrLf & "		    , TMST_ITEM "
            strSubSQL &= vbCrLf & "		WHERE 1=1 "
            strSubSQL &= vbCrLf & "		AND   XRST_PRODUCT_IN.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRST_PRODUCT_IN.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "
            strSubSQL &= vbCrLf & "		AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' "
            strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J03 & "' ) "
            strSubSQL &= vbCrLf & "		GROUP BY   XRST_PRODUCT_IN.XSOUGYOU_DT "
            strSubSQL &= vbCrLf & "		         , TMST_ITEM.XARTICLE_TYPE_CODE "

            '月単位での集計
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        PRD_IN.XARTICLE_TYPE_CODE  "            ' 商品区分
            strSQL &= vbCrLf & "      , SUM(PRD_IN.KONSU ) AS KONSU "           ' 紺数
            strSQL &= vbCrLf & "      , SUM(PRD_IN.PALLET_CNT) AS PL_CNT "      ' PL数
            strSQL &= vbCrLf & "      , MAX(PRD_IN.KONSU) AS MAX_KONSU "        ' MAX
            strSQL &= vbCrLf & "      , MIN(PRD_IN.KONSU) AS MIN_KONSU "        ' MIN
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_IN.KONSU ),0) AS KONSU_AVG "       ' 平均紺数(実績がある日の平均)
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_IN.PALLET_CNT),0) AS PL_AVG "      ' 平均PL数(実績がある日の平均)
            strSQL &= vbCrLf & "FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & ") PRD_IN "
            strSQL &= vbCrLf & "GROUP BY   PRD_IN.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "ORDER BY   PRD_IN.XARTICLE_TYPE_CODE "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_PRODUCT_IN"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XARTICLE_TYPE_CODE_J01
                        '' ''    '(製品)
                        '' ''    Call objExcel.SetCellValue("G7", TO_STRING(objRow("KONSU")))            ' 紺数
                        '' ''    Call objExcel.SetCellValue("G8", TO_STRING(objRow("PL_CNT")))           ' PL数
                        '' ''    Call objExcel.SetCellValue("G9", TO_STRING(objRow("MAX_KONSU")))        ' MAX
                        '' ''    Call objExcel.SetCellValue("G10", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                        '' ''    Call objExcel.SetCellValue("G11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                        '' ''    Call objExcel.SetCellValue("G12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        '' ''Case XARTICLE_TYPE_CODE_J02
                        '' ''    '(中間品)
                        '' ''    Call objExcel.SetCellValue("L7", TO_STRING(objRow("KONSU")))            ' 紺数
                        '' ''    Call objExcel.SetCellValue("L8", TO_STRING(objRow("PL_CNT")))           ' PL数
                        '' ''    Call objExcel.SetCellValue("L9", TO_STRING(objRow("MAX_KONSU")))        ' MAX
                        '' ''    Call objExcel.SetCellValue("L10", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                        '' ''    Call objExcel.SetCellValue("L11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                        '' ''    Call objExcel.SetCellValue("L12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        '' ''Case XARTICLE_TYPE_CODE_J03
                        '' ''    '(包材)
                        '' ''    Call objExcel.SetCellValue("AK7", TO_STRING(objRow("KONSU")))            ' 紺数
                        '' ''    Call objExcel.SetCellValue("AK8", TO_STRING(objRow("PL_CNT")))           ' PL数
                        '' ''    Call objExcel.SetCellValue("AK9", TO_STRING(objRow("MAX_KONSU")))        ' MAX
                        '' ''    Call objExcel.SetCellValue("AK10", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                        '' ''    Call objExcel.SetCellValue("AK11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                        '' ''    Call objExcel.SetCellValue("AK12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                        Case XARTICLE_TYPE_CODE_J01
                            '(製品)
                            Call objExcel.SetCellValue("G13", TO_STRING(objRow("KONSU")))           ' 梱数
                            Call objExcel.SetCellValue("G14", TO_STRING(objRow("PL_CNT")))          ' PL数
                            Call objExcel.SetCellValue("G15", TO_STRING(objRow("MAX_KONSU")))       ' MAX
                            Call objExcel.SetCellValue("G16", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                            Call objExcel.SetCellValue("G17", TO_STRING(objRow("KONSU_AVG")))       ' 平均梱数
                            Call objExcel.SetCellValue("G18", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        Case XARTICLE_TYPE_CODE_J02
                            '(中間品)
                            Call objExcel.SetCellValue("L13", TO_STRING(objRow("KONSU")))           ' 梱数
                            Call objExcel.SetCellValue("L14", TO_STRING(objRow("PL_CNT")))          ' PL数
                            Call objExcel.SetCellValue("L15", TO_STRING(objRow("MAX_KONSU")))       ' MAX
                            Call objExcel.SetCellValue("L16", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                            Call objExcel.SetCellValue("L17", TO_STRING(objRow("KONSU_AVG")))       ' 平均梱数
                            Call objExcel.SetCellValue("L18", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        Case XARTICLE_TYPE_CODE_J03
                            '(包材)
                            Call objExcel.SetCellValue("AK13", TO_STRING(objRow("KONSU")))           ' 梱数
                            Call objExcel.SetCellValue("AK14", TO_STRING(objRow("PL_CNT")))          ' PL数
                            Call objExcel.SetCellValue("AK15", TO_STRING(objRow("MAX_KONSU")))       ' MAX
                            Call objExcel.SetCellValue("AK16", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                            Call objExcel.SetCellValue("AK17", TO_STRING(objRow("KONSU_AVG")))       ' 平均梱数
                            Call objExcel.SetCellValue("AK18", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '月単位での集計(合計)
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        SUM(PRD_IN_TOTAL.KONSU ) AS KONSU "             ' 紺数
            strSQL &= vbCrLf & "      , SUM(PRD_IN_TOTAL.PL_CNT) AS PL_CNT "            ' PL数
            strSQL &= vbCrLf & "      , MAX(PRD_IN_TOTAL.KONSU ) AS MAX_KONSU "         ' MAX紺数
            strSQL &= vbCrLf & "      , MIN(PRD_IN_TOTAL.KONSU) AS MIN_KONSU "          ' MINPL数
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_IN_TOTAL.KONSU ),0) AS KONSU_AVG "         ' 平均紺数
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_IN_TOTAL.PL_CNT),0) AS PL_AVG "            ' 平均PL数
            strSQL &= vbCrLf & "FROM ( "
            ' 製品、中間品のみを集計
            strSQL &= vbCrLf & "    SELECT "
            strSQL &= vbCrLf & "            SUM(PRD_IN.KONSU ) AS KONSU "           ' 紺数
            strSQL &= vbCrLf & "          , SUM(PRD_IN.PALLET_CNT) AS PL_CNT "      ' PL数
            strSQL &= vbCrLf & "    FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & "    ) PRD_IN "
            strSQL &= vbCrLf & "	WHERE 1=1 "
            strSQL &= vbCrLf & "	AND   PRD_IN.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSQL &= vbCrLf & "		                               ,'" & XARTICLE_TYPE_CODE_J02 & "' ) "
            strSQL &= vbCrLf & "    GROUP BY   PRD_IN.XSOUGYOU_DT "
            strSQL &= vbCrLf & ") PRD_IN_TOTAL "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_PRODUCT_IN"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    ' '' ''(合計)
                    '' ''Call objExcel.SetCellValue("Q7", TO_STRING(objRow("KONSU")))            ' 紺数
                    '' ''Call objExcel.SetCellValue("Q8", TO_STRING(objRow("PL_CNT")))           ' PL数
                    '' ''Call objExcel.SetCellValue("Q9", TO_STRING(objRow("MAX_KONSU")))        ' MAX紺数
                    '' ''Call objExcel.SetCellValue("Q10", TO_STRING(objRow("MIN_KONSU")))       ' MIN紺数
                    ' '' ''Call objExcel.SetCellValue("Q11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                    ' '' ''Call objExcel.SetCellValue("Q12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                    '(合計)
                    Call objExcel.SetCellValue("Q13", TO_STRING(objRow("KONSU")))           ' 梱数
                    Call objExcel.SetCellValue("Q14", TO_STRING(objRow("PL_CNT")))          ' PL数
                    Call objExcel.SetCellValue("Q15", TO_STRING(objRow("MAX_KONSU")))       ' MAX梱数
                    Call objExcel.SetCellValue("Q16", TO_STRING(objRow("MIN_KONSU")))       ' MIN梱数
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    '↑↑↑↑↑↑************************************************************************************************************
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 月報変更
            ' '' ''平均値を単純に加算
            '' ''decKONSU = TO_DECIMAL(objExcel.GetCellValue("G11")) + TO_DECIMAL(objExcel.GetCellValue("L11"))      '(梱数)
            '' ''decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("G12")) + TO_DECIMAL(objExcel.GetCellValue("L12"))     '(PL数)
            '' ''Call objExcel.SetCellValue("Q11", TO_STRING(decKONSU))          ' 平均紺数
            '' ''Call objExcel.SetCellValue("Q12", TO_STRING(decPL_CNT))         ' 平均PL数
            '平均値を単純に加算
            decKONSU = TO_DECIMAL(objExcel.GetCellValue("G17")) + TO_DECIMAL(objExcel.GetCellValue("L17"))      '(梱数)
            decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("G18")) + TO_DECIMAL(objExcel.GetCellValue("L18"))     '(PL数)
            Call objExcel.SetCellValue("Q17", TO_STRING(decKONSU))          ' 平均梱数
            Call objExcel.SetCellValue("Q18", TO_STRING(decPL_CNT))         ' 平均PL数
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 出庫
            '----------------------------
            '日単位での集計
            strSubSQL = ""
            strSubSQL &= vbCrLf & "		SELECT "
            strSubSQL &= vbCrLf & "		        XRST_OUT.XSYUKKA_D "                            ' 日付
            strSubSQL &= vbCrLf & "		      , XRST_OUT.XARTICLE_TYPE_CODE  "                  ' 商品区分
            strSubSQL &= vbCrLf & "		      , SUM(XRST_OUT.XNUM) AS KONSU  "                  ' 紺数
            strSubSQL &= vbCrLf & "		      , COUNT(XRST_OUT.FPALLET_ID) AS PALLET_CNT  "     ' PL数
            strSubSQL &= vbCrLf & "		FROM "
            strSubSQL &= vbCrLf & "		      XRST_OUT "
            strSubSQL &= vbCrLf & "		WHERE 1=1 "
            strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
            strSubSQL &= vbCrLf & "		AND   XRST_OUT.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' ) "
            strSubSQL &= vbCrLf & "		GROUP BY   XRST_OUT.XSYUKKA_D "
            strSubSQL &= vbCrLf & "		         , XRST_OUT.XARTICLE_TYPE_CODE "

            '月単位での集計
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        PRD_OUT.XARTICLE_TYPE_CODE  "            ' 商品区分
            strSQL &= vbCrLf & "      , SUM(PRD_OUT.KONSU ) AS KONSU "           ' 紺数
            strSQL &= vbCrLf & "      , SUM(PRD_OUT.PALLET_CNT) AS PL_CNT "      ' PL数
            strSQL &= vbCrLf & "      , MAX(PRD_OUT.KONSU) AS MAX_KONSU "        ' MAX
            strSQL &= vbCrLf & "      , MIN(PRD_OUT.KONSU) AS MIN_KONSU "        ' MIN
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_OUT.KONSU ),0) AS KONSU_AVG "       ' 平均紺数(実績がある日の平均)
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_OUT.PALLET_CNT),0) AS PL_AVG "      ' 平均PL数(実績がある日の平均)
            strSQL &= vbCrLf & "FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & ") PRD_OUT "
            strSQL &= vbCrLf & "GROUP BY   PRD_OUT.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "ORDER BY   PRD_OUT.XARTICLE_TYPE_CODE "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XARTICLE_TYPE_CODE_J01
                        '' ''    '(製品)
                        '' ''    Call objExcel.SetCellValue("V7", TO_STRING(objRow("KONSU")))            ' 紺数
                        '' ''    Call objExcel.SetCellValue("V8", TO_STRING(objRow("PL_CNT")))           ' PL数
                        '' ''    Call objExcel.SetCellValue("V9", TO_STRING(objRow("MAX_KONSU")))        ' MAX
                        '' ''    Call objExcel.SetCellValue("V10", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                        '' ''    Call objExcel.SetCellValue("V11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                        '' ''    Call objExcel.SetCellValue("V12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        '' ''Case XARTICLE_TYPE_CODE_J02
                        '' ''    '(中間品)
                        '' ''    Call objExcel.SetCellValue("AA7", TO_STRING(objRow("KONSU")))            ' 紺数
                        '' ''    Call objExcel.SetCellValue("AA8", TO_STRING(objRow("PL_CNT")))           ' PL数
                        '' ''    Call objExcel.SetCellValue("AA9", TO_STRING(objRow("MAX_KONSU")))        ' MAX
                        '' ''    Call objExcel.SetCellValue("AA10", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                        '' ''    Call objExcel.SetCellValue("AA11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                        '' ''    Call objExcel.SetCellValue("AA12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                        Case XARTICLE_TYPE_CODE_J01
                            '(製品)
                            Call objExcel.SetCellValue("V13", TO_STRING(objRow("KONSU")))           ' 梱数
                            Call objExcel.SetCellValue("V14", TO_STRING(objRow("PL_CNT")))          ' PL数
                            Call objExcel.SetCellValue("V15", TO_STRING(objRow("MAX_KONSU")))       ' MAX
                            Call objExcel.SetCellValue("V16", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                            Call objExcel.SetCellValue("V17", TO_STRING(objRow("KONSU_AVG")))       ' 平均梱数
                            Call objExcel.SetCellValue("V18", TO_STRING(objRow("PL_AVG")))          ' 平均PL数

                        Case XARTICLE_TYPE_CODE_J02
                            '(中間品)
                            Call objExcel.SetCellValue("AA13", TO_STRING(objRow("KONSU")))           ' 梱数
                            Call objExcel.SetCellValue("AA14", TO_STRING(objRow("PL_CNT")))          ' PL数
                            Call objExcel.SetCellValue("AA15", TO_STRING(objRow("MAX_KONSU")))       ' MAX
                            Call objExcel.SetCellValue("AA16", TO_STRING(objRow("MIN_KONSU")))       ' MIN
                            Call objExcel.SetCellValue("AA17", TO_STRING(objRow("KONSU_AVG")))       ' 平均梱数
                            Call objExcel.SetCellValue("AA18", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '月単位での集計(合計)
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        SUM(PRD_OUT_TOTAL.KONSU ) AS KONSU "            ' 紺数
            strSQL &= vbCrLf & "      , SUM(PRD_OUT_TOTAL.PL_CNT) AS PL_CNT "           ' PL数
            strSQL &= vbCrLf & "      , MAX(PRD_OUT_TOTAL.KONSU ) AS MAX_KONSU "        ' MAX紺数
            strSQL &= vbCrLf & "      , MIN(PRD_OUT_TOTAL.KONSU) AS MIN_KONSU "         ' MINPL数
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_OUT_TOTAL.KONSU ),0) AS KONSU_AVG "        ' 平均紺数
            strSQL &= vbCrLf & "      , ROUND(AVG(PRD_OUT_TOTAL.PL_CNT),0) AS PL_AVG "           ' 平均PL数
            strSQL &= vbCrLf & "FROM ( "
            ' 製品、中間品のみを集計
            strSQL &= vbCrLf & "    SELECT "
            strSQL &= vbCrLf & "            SUM(PRD_OUT.KONSU ) AS KONSU "           ' 紺数
            strSQL &= vbCrLf & "          , SUM(PRD_OUT.PALLET_CNT) AS PL_CNT "      ' PL数
            strSQL &= vbCrLf & "    FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & "    ) PRD_OUT "
            strSQL &= vbCrLf & "	WHERE 1=1 "
            strSQL &= vbCrLf & "    GROUP BY   PRD_OUT.XSYUKKA_D "
            strSQL &= vbCrLf & ") PRD_OUT_TOTAL "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_PRODUCT_IN"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    ' '' ''(合計)
                    '' ''Call objExcel.SetCellValue("AF7", TO_STRING(objRow("KONSU")))            ' 紺数
                    '' ''Call objExcel.SetCellValue("AF8", TO_STRING(objRow("PL_CNT")))           ' PL数
                    '' ''Call objExcel.SetCellValue("AF9", TO_STRING(objRow("MAX_KONSU")))        ' MAX紺数
                    '' ''Call objExcel.SetCellValue("AF10", TO_STRING(objRow("MIN_KONSU")))       ' MIN紺数
                    ' '' ''Call objExcel.SetCellValue("AF11", TO_STRING(objRow("KONSU_AVG")))       ' 平均紺数
                    ' '' ''Call objExcel.SetCellValue("AF12", TO_STRING(objRow("PL_AVG")))          ' 平均PL数
                    '(合計)
                    Call objExcel.SetCellValue("AF13", TO_STRING(objRow("KONSU")))           ' 梱数
                    Call objExcel.SetCellValue("AF14", TO_STRING(objRow("PL_CNT")))          ' PL数
                    Call objExcel.SetCellValue("AF15", TO_STRING(objRow("MAX_KONSU")))       ' MAX梱数
                    Call objExcel.SetCellValue("AF16", TO_STRING(objRow("MIN_KONSU")))       ' MIN梱数
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    '↑↑↑↑↑↑************************************************************************************************************
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 月報変更
            ' '' ''平均値を単純に加算
            '' ''decKONSU = TO_DECIMAL(objExcel.GetCellValue("V11")) + TO_DECIMAL(objExcel.GetCellValue("AA11"))      '(梱数)
            '' ''decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("V12")) + TO_DECIMAL(objExcel.GetCellValue("AA12"))     '(PL数)
            '' ''Call objExcel.SetCellValue("AF11", TO_STRING(decKONSU))          ' 平均紺数
            '' ''Call objExcel.SetCellValue("AF12", TO_STRING(decPL_CNT))         ' 平均PL数
            '平均値を単純に加算
            decKONSU = TO_DECIMAL(objExcel.GetCellValue("V17")) + TO_DECIMAL(objExcel.GetCellValue("AA17"))      '(梱数)
            decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("V18")) + TO_DECIMAL(objExcel.GetCellValue("AA18"))     '(PL数)
            Call objExcel.SetCellValue("AF17", TO_STRING(decKONSU))          ' 平均紺数
            Call objExcel.SetCellValue("AF18", TO_STRING(decPL_CNT))         ' 平均PL数
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(月報_出荷状況)                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(月報_出荷状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strSrcDt">作成日付(YYYYMM)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasGeppoRstOUT(ByRef objExcel As clsExcelAppCtl, ByVal strSrcDt As String) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            '----------------------------
            ' 出荷状況
            '----------------------------
            '----------------------------
            ' 積別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XTUMI_HOUKOU "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
            strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUKOU IN ('" & XTUMI_HOUKOU_JBACK & "' "
            strSQL &= vbCrLf & "                                ,'" & XTUMI_HOUKOU_JWING & "' "
            strSQL &= vbCrLf & "                                ,'" & XTUMI_HOUKOU_JSIDE & "' ) "
            strSQL &= vbCrLf & " GROUP BY XRST_OUT.XTUMI_HOUKOU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUKOU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XTUMI_HOUKOU"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XTUMI_HOUKOU_JBACK
                        '' ''    '(後積み)
                        '' ''    Call objExcel.SetCellValue("G16", TO_STRING(objRow("NUM")))           '数量

                        '' ''Case XTUMI_HOUKOU_JWING
                        '' ''    '(両横積み)
                        '' ''    Call objExcel.SetCellValue("K16", TO_STRING(objRow("NUM")))           '数量

                        '' ''Case XTUMI_HOUKOU_JSIDE
                        '' ''    '(片横積み)
                        '' ''    Call objExcel.SetCellValue("O16", TO_STRING(objRow("NUM")))           '数量
                        Case XTUMI_HOUKOU_JBACK
                            '(後積み)
                            Call objExcel.SetCellValue("G22", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUKOU_JWING
                            '(両横積み)
                            Call objExcel.SetCellValue("K22", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUKOU_JSIDE
                            '(片横積み)
                            Call objExcel.SetCellValue("O22", TO_STRING(objRow("NUM")))           '数量
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '----------------------------
            ' 手段別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XTUMI_HOUHOU "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
            strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUHOU IN ('" & XTUMI_HOUHOU_JP & "' "
            strSQL &= vbCrLf & "                                ,'" & XTUMI_HOUHOU_JB & "' "
            strSQL &= vbCrLf & "                                ,'" & XTUMI_HOUHOU_JL & "' ) "
            strSQL &= vbCrLf & " GROUP BY XRST_OUT.XTUMI_HOUHOU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUHOU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XTUMI_HOUHOU"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XTUMI_HOUHOU_JP
                        '' ''    '(PL積み)
                        '' ''    Call objExcel.SetCellValue("G18", TO_STRING(objRow("NUM")))           '数量

                        '' ''Case XTUMI_HOUHOU_JB
                        '' ''    '(ﾊﾞﾗ積み)
                        '' ''    Call objExcel.SetCellValue("K18", TO_STRING(objRow("NUM")))           '数量

                        '' ''Case XTUMI_HOUHOU_JL
                        '' ''    '(ﾛｰﾀﾞｰ積み)
                        '' ''    Call objExcel.SetCellValue("O18", TO_STRING(objRow("NUM")))           '数量
                        Case XTUMI_HOUHOU_JP
                            '(PL積み)
                            Call objExcel.SetCellValue("G24", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ積み)
                            Call objExcel.SetCellValue("K24", TO_STRING(objRow("NUM")))           '数量

                        Case XTUMI_HOUHOU_JL
                            '(ﾛｰﾀﾞｰ積み)
                            Call objExcel.SetCellValue("O24", TO_STRING(objRow("NUM")))           '数量
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '----------------------------
            ' 手段別
            '----------------------------
            For ii As Integer = XTUMI_HOUHOU_JP To XTUMI_HOUHOU_JL
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "       COUNT(XRST_OUT.XHENSEI_NO_OYA) AS NUM "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "       XRST_OUT "
                strSQL &= vbCrLf & " WHERE 1=1 "
                strSQL &= vbCrLf & " AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
                strSQL &= vbCrLf & " AND   XRST_OUT.XTUMI_HOUHOU =" & TO_STRING(ii)
                strSQL &= vbCrLf & " GROUP BY   XRST_OUT.XSYUKKA_D "
                strSQL &= vbCrLf & "          , XRST_OUT.XHENSEI_NO_OYA "
                strSQL &= vbCrLf & " ORDER BY XRST_OUT.XTUMI_HOUHOU "

                ObjDb.SQL = strSQL
                strDataSetName = "XRST_OUT"
                ObjDb.GetDataSet(strDataSetName, objData)
                intRecCnt = objData.Tables(strDataSetName).Rows.Count
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case ii
                        Case XTUMI_HOUHOU_JP
                            '(PL積み)
                            Call objExcel.SetCellValue("G26", TO_STRING(intRecCnt))             '数量

                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ積み)
                            Call objExcel.SetCellValue("K26", TO_STRING(intRecCnt))             '数量

                        Case XTUMI_HOUHOU_JL
                            '(ﾛｰﾀﾞｰ積み)
                            Call objExcel.SetCellValue("O26", TO_STRING(intRecCnt))             '数量
                    End Select
                Next

                'ﾃﾞｰﾀｾｯﾄｸﾘｱ
                objData.Reset()
            Next ii
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '↑↑↑↑↑↑************************************************************************************************************


            '----------------------------
            ' 輸送別
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         XRST_OUT.XSAIMOKU "
            strSQL &= vbCrLf & "       , COUNT(XRST_OUT.FPALLET_ID) AS PALLET_CNT "
            strSQL &= vbCrLf & "       , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "       XRST_OUT "
            strSQL &= vbCrLf & " WHERE 1=1 "
            strSQL &= vbCrLf & " AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
            strSQL &= vbCrLf & " AND   XRST_OUT.XSAIMOKU IN ('" & XSAIMOKU_JISOU & "' "
            strSQL &= vbCrLf & "                            ,'" & XSAIMOKU_JHOKYUU & "' "
            strSQL &= vbCrLf & "                            ,'" & XSAIMOKU_JIDOU & "' "
            strSQL &= vbCrLf & "                            ,'" & XSAIMOKU_JHAISOU & "' ) "
            strSQL &= vbCrLf & " GROUP BY XRST_OUT.XSAIMOKU "
            strSQL &= vbCrLf & " ORDER BY XRST_OUT.XSAIMOKU "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XSAIMOKU"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XSAIMOKU_JISOU
                        '' ''    '(移送)
                        '' ''    Call objExcel.SetCellValue("K20", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("K21", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JHOKYUU
                        '' ''    '(補給)
                        '' ''    Call objExcel.SetCellValue("O20", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("O21", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JIDOU
                        '' ''    '(移動)
                        '' ''    Call objExcel.SetCellValue("S20", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("S21", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        '' ''Case XSAIMOKU_JHAISOU
                        '' ''    '(配送(直送))
                        '' ''    Call objExcel.SetCellValue("W20", TO_STRING(objRow("NUM")))             '数量
                        '' ''    Call objExcel.SetCellValue("W21", TO_STRING(objRow("PALLET_CNT")))      'PL数
                        Case XSAIMOKU_JISOU
                            '(移送)
                            Call objExcel.SetCellValue("K28", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("K29", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JHOKYUU
                            '(補給)
                            Call objExcel.SetCellValue("O28", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("O29", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JIDOU
                            '(移動)
                            Call objExcel.SetCellValue("S28", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("S29", TO_STRING(objRow("PALLET_CNT")))      'PL数

                        Case XSAIMOKU_JHAISOU
                            '(配送(直送))
                            Call objExcel.SetCellValue("W28", TO_STRING(objRow("NUM")))             '数量
                            Call objExcel.SetCellValue("W29", TO_STRING(objRow("PALLET_CNT")))      'PL数
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '----------------------------
            ' 輸送別(平均)
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "         ROUND(AVG(RST_OUT.PL_CNT),0) AS PL_AVG "
            strSQL &= vbCrLf & "       , ROUND(AVG(RST_OUT.NUM),0) AS NUM_AVG "
            strSQL &= vbCrLf & " FROM ("
            strSQL &= vbCrLf & "     SELECT "
            strSQL &= vbCrLf & "             COUNT(XRST_OUT.FPALLET_ID) AS PL_CNT "
            strSQL &= vbCrLf & "           , SUM(XRST_OUT.XNUM) AS NUM "
            strSQL &= vbCrLf & "     FROM "
            strSQL &= vbCrLf & "           XRST_OUT "
            strSQL &= vbCrLf & "     WHERE 1=1 "
            strSQL &= vbCrLf & "     AND   TO_CHAR(XRST_OUT.XSYUKKA_D,'yyyyMM') = '" & strSrcDt & "' "
            strSQL &= vbCrLf & "     AND   XRST_OUT.XSAIMOKU IN ('" & XSAIMOKU_JISOU & "' "
            strSQL &= vbCrLf & "                                ,'" & XSAIMOKU_JHOKYUU & "' "
            strSQL &= vbCrLf & "                                ,'" & XSAIMOKU_JIDOU & "' "
            strSQL &= vbCrLf & "                                ,'" & XSAIMOKU_JHAISOU & "' ) "
            strSQL &= vbCrLf & "     GROUP BY XRST_OUT.XSYUKKA_D "
            strSQL &= vbCrLf & "     ) RST_OUT "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_OUT"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    ' '' ''(平均)
                    '' ''Call objExcel.SetCellValue("AI20", TO_STRING(objRow("NUM_AVG")))            '数量
                    '' ''Call objExcel.SetCellValue("AI21", TO_STRING(objRow("PL_AVG")))             'PL数
                    '(平均)
                    Call objExcel.SetCellValue("AI28", TO_STRING(objRow("NUM_AVG")))            '数量
                    Call objExcel.SetCellValue("AI29", TO_STRING(objRow("PL_AVG")))             'PL数
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    '↑↑↑↑↑↑************************************************************************************************************

                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(月報_ﾗｯｸ内在庫状況)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(月報_ﾗｯｸ内在庫状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strSrcDt">作成日付(YYYYMM)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasGeppoZaiko(ByRef objExcel As clsExcelAppCtl, ByVal strSrcDt As String) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strSubSQL As String = ""                '合計取得ｻﾌﾞSQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            '----------------------------
            ' ﾗｯｸ内在庫状況
            '----------------------------
            '日単位での集計
            strSubSQL = ""
            strSubSQL &= vbCrLf & "		SELECT "
            strSubSQL &= vbCrLf & "		        XRPT_ZAIKO.XSOUGYOU_DT "                        ' 日付
            strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_KOSOU) AS KONSU  "        ' 紺数
            strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_PL) AS PALLET_CNT  "      ' PL数
            strSubSQL &= vbCrLf & "		FROM "
            strSubSQL &= vbCrLf & "		      XRPT_ZAIKO "
            strSubSQL &= vbCrLf & "		    , TMST_ITEM "
            strSubSQL &= vbCrLf & "		WHERE 1=1 "
            strSubSQL &= vbCrLf & "		AND   XRPT_ZAIKO.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRPT_ZAIKO.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "
            strSubSQL &= vbCrLf & "		AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' ) "
            strSubSQL &= vbCrLf & "		GROUP BY   XRPT_ZAIKO.XSOUGYOU_DT "

            '月単位での集計(製品・中間品)
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        ROUND(AVG(ZAIKO.KONSU),0) AS KONSU "            ' 紺数平均
            strSQL &= vbCrLf & "      , ROUND(AVG(ZAIKO.PALLET_CNT),0) AS PL_CNT "      ' PL数平均
            strSQL &= vbCrLf & "      , MAX(ZAIKO.KONSU) AS MAX_KONSU "                 ' MAX紺数
            strSQL &= vbCrLf & "      , MIN(ZAIKO.KONSU) AS MIN_KONSU "                 ' MIN紺数
            strSQL &= vbCrLf & "      , MAX(ZAIKO.PALLET_CNT) AS MAX_PL_CNT "           ' MAXPL数
            strSQL &= vbCrLf & "      , MIN(ZAIKO.PALLET_CNT) AS MIN_PL_CNT "           ' MINPL数
            strSQL &= vbCrLf & "FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & ") ZAIKO "
            strSQL &= vbCrLf & "WHERE 1=1 "

            ObjDb.SQL = strSQL
            strDataSetName = "XRPT_ZAIKO"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    '(製品・中間品)
                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    '' ''Call objExcel.SetCellValue("H26", TO_STRING(objRow("KONSU")))               ' 紺数平均
                    '' ''Call objExcel.SetCellValue("H27", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                    '' ''Call objExcel.SetCellValue("H28", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                    '' ''Call objExcel.SetCellValue("M26", TO_STRING(objRow("PL_CNT")))              ' PL数平均
                    '' ''Call objExcel.SetCellValue("M27", TO_STRING(objRow("MAX_PL_CNT")))          ' MAXPL数
                    '' ''Call objExcel.SetCellValue("M28", TO_STRING(objRow("MIN_PL_CNT")))          ' MINPL数
                    Call objExcel.SetCellValue("H34", TO_STRING(objRow("KONSU")))               ' 紺数平均
                    Call objExcel.SetCellValue("H35", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                    Call objExcel.SetCellValue("H36", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                    Call objExcel.SetCellValue("M34", TO_STRING(objRow("PL_CNT")))              ' PL数平均
                    Call objExcel.SetCellValue("M35", TO_STRING(objRow("MAX_PL_CNT")))          ' MAXPL数
                    Call objExcel.SetCellValue("M36", TO_STRING(objRow("MIN_PL_CNT")))          ' MINPL数
                    'JobMate:S.Ouchi 2013/11/13 月報変更
                    '↑↑↑↑↑↑************************************************************************************************************
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

            '月単位での集計(包材、空ﾊﾟﾚｯﾄ)
            strSubSQL = ""
            strSubSQL &= vbCrLf & "		SELECT "
            strSubSQL &= vbCrLf & "		        XRPT_ZAIKO.XSOUGYOU_DT "                        ' 日付
            strSubSQL &= vbCrLf & "		      , TMST_ITEM.XARTICLE_TYPE_CODE  "                 ' 商品区分
            strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_KOSOU) AS KONSU  "        ' 紺数
            strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_PL) AS PALLET_CNT  "      ' PL数
            strSubSQL &= vbCrLf & "		FROM "
            strSubSQL &= vbCrLf & "		      XRPT_ZAIKO "
            strSubSQL &= vbCrLf & "		    , TMST_ITEM "
            strSubSQL &= vbCrLf & "		WHERE 1=1 "
            strSubSQL &= vbCrLf & "		AND   XRPT_ZAIKO.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRPT_ZAIKO.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "
            strSubSQL &= vbCrLf & "		AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J03 & "' "
            strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J00 & "' ) "
            strSubSQL &= vbCrLf & "		GROUP BY   XRPT_ZAIKO.XSOUGYOU_DT "
            strSubSQL &= vbCrLf & "		         , TMST_ITEM.XARTICLE_TYPE_CODE "

            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        ZAIKO.XARTICLE_TYPE_CODE "                  ' 商品区分
            strSQL &= vbCrLf & "      , ROUND(AVG(ZAIKO.KONSU),0) AS KONSU "        ' 紺数平均
            strSQL &= vbCrLf & "      , ROUND(AVG(ZAIKO.PALLET_CNT),0) AS PL_CNT "  ' PL数平均
            strSQL &= vbCrLf & "      , MAX(ZAIKO.KONSU) AS MAX_KONSU "             ' MAX紺数
            strSQL &= vbCrLf & "      , MIN(ZAIKO.KONSU) AS MIN_KONSU "             ' MIN紺数
            strSQL &= vbCrLf & "      , MAX(ZAIKO.PALLET_CNT) AS MAX_PL_CNT "       ' MAXPL数
            strSQL &= vbCrLf & "      , MIN(ZAIKO.PALLET_CNT) AS MIN_PL_CNT "       ' MINPL数
            strSQL &= vbCrLf & "FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & ") ZAIKO "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   ZAIKO.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J03 & "' "
            strSQL &= vbCrLf & "                                  ,'" & XARTICLE_TYPE_CODE_J00 & "' )"
            strSQL &= vbCrLf & "GROUP BY ZAIKO.XARTICLE_TYPE_CODE "
            strSQL &= vbCrLf & "ORDER BY ZAIKO.XARTICLE_TYPE_CODE "

            ObjDb.SQL = strSQL
            strDataSetName = "XRPT_ZAIKO"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XARTICLE_TYPE_CODE"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XARTICLE_TYPE_CODE_J03
                        '' ''    '(包材)
                        '' ''    Call objExcel.SetCellValue("Q26", TO_STRING(objRow("KONSU")))               ' 紺数平均
                        '' ''    Call objExcel.SetCellValue("Q27", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                        '' ''    Call objExcel.SetCellValue("Q28", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                        '' ''    Call objExcel.SetCellValue("V26", TO_STRING(objRow("PL_CNT")))              ' PL数平均
                        '' ''    Call objExcel.SetCellValue("V27", TO_STRING(objRow("MAX_PL_CNT")))          ' MAXPL数
                        '' ''    Call objExcel.SetCellValue("V28", TO_STRING(objRow("MIN_PL_CNT")))          ' MINPL数

                        '' ''Case XARTICLE_TYPE_CODE_J00
                        '' ''    '(空ﾊﾟﾚｯﾄ)
                        '' ''    Call objExcel.SetCellValue("Z26", TO_STRING(objRow("KONSU")))               ' 紺数平均
                        '' ''    Call objExcel.SetCellValue("Z27", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                        '' ''    Call objExcel.SetCellValue("Z28", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                        '' ''    Call objExcel.SetCellValue("AE26", TO_STRING(objRow("PL_CNT")))             ' PL数平均
                        '' ''    Call objExcel.SetCellValue("AE27", TO_STRING(objRow("MAX_PL_CNT")))         ' MAXPL数
                        '' ''    Call objExcel.SetCellValue("AE28", TO_STRING(objRow("MIN_PL_CNT")))         ' MINPL数
                        Case XARTICLE_TYPE_CODE_J03
                            '(包材)
                            Call objExcel.SetCellValue("Q34", TO_STRING(objRow("KONSU")))               ' 紺数平均
                            Call objExcel.SetCellValue("Q35", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                            Call objExcel.SetCellValue("Q36", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                            Call objExcel.SetCellValue("V34", TO_STRING(objRow("PL_CNT")))              ' PL数平均
                            Call objExcel.SetCellValue("V35", TO_STRING(objRow("MAX_PL_CNT")))          ' MAXPL数
                            Call objExcel.SetCellValue("V36", TO_STRING(objRow("MIN_PL_CNT")))          ' MINPL数

                        Case XARTICLE_TYPE_CODE_J00
                            '(空ﾊﾟﾚｯﾄ)
                            Call objExcel.SetCellValue("Z34", TO_STRING(objRow("KONSU")))               ' 紺数平均
                            Call objExcel.SetCellValue("Z35", TO_STRING(objRow("MAX_KONSU")))           ' MAX紺数
                            Call objExcel.SetCellValue("Z36", TO_STRING(objRow("MIN_KONSU")))           ' MIN紺数
                            Call objExcel.SetCellValue("AE34", TO_STRING(objRow("PL_CNT")))             ' PL数平均
                            Call objExcel.SetCellValue("AE35", TO_STRING(objRow("MAX_PL_CNT")))         ' MAXPL数
                            Call objExcel.SetCellValue("AE36", TO_STRING(objRow("MIN_PL_CNT")))         ' MINPL数
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()


            ''日単位での集計
            'strSubSQL = ""
            'strSubSQL &= vbCrLf & "		SELECT "
            'strSubSQL &= vbCrLf & "		        XRPT_ZAIKO.XSOUGYOU_DT "                        ' 日付
            'strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_KOSOU) AS KONSU  "        ' 紺数
            'strSubSQL &= vbCrLf & "		      , SUM(XRPT_ZAIKO.XSTOCK_PL) AS PALLET_CNT  "      ' PL数
            'strSubSQL &= vbCrLf & "		FROM "
            'strSubSQL &= vbCrLf & "		      XRPT_ZAIKO "
            'strSubSQL &= vbCrLf & "		    , TMST_ITEM "
            'strSubSQL &= vbCrLf & "		WHERE 1=1 "
            'strSubSQL &= vbCrLf & "		AND   XRPT_ZAIKO.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
            'strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRPT_ZAIKO.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "
            'strSubSQL &= vbCrLf & "		AND   TMST_ITEM.XARTICLE_TYPE_CODE IN ('" & XARTICLE_TYPE_CODE_J01 & "' "
            'strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J02 & "' "
            'strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J03 & "' "
            'strSubSQL &= vbCrLf & "		                                      ,'" & XARTICLE_TYPE_CODE_J00 & "' ) "
            'strSubSQL &= vbCrLf & "		GROUP BY   XRPT_ZAIKO.XSOUGYOU_DT "

            ''月単位での集計(平均合計)
            'strSQL = ""
            'strSQL &= vbCrLf & "SELECT "
            'strSQL &= vbCrLf & "        ROUND(AVG(ZAIKO.KONSU),0) AS KONSU "            ' 紺数
            'strSQL &= vbCrLf & "      , ROUND(AVG(ZAIKO.PALLET_CNT),0) AS PL_CNT "      ' PL数
            'strSQL &= vbCrLf & "FROM ( "
            'strSQL &= vbCrLf & strSubSQL
            'strSQL &= vbCrLf & ") ZAIKO "
            'strSQL &= vbCrLf & "WHERE 1=1 "

            'ObjDb.SQL = strSQL
            'strDataSetName = "XRPT_ZAIKO"
            'ObjDb.GetDataSet(strDataSetName, objData)
            'intRecCnt = objData.Tables(strDataSetName).Rows.Count
            'If intRecCnt > 0 Then
            '    For Each objRow In objData.Tables(strDataSetName).Rows
            '        '(製品・中間品)
            '        Call objExcel.SetCellValue("AI26", TO_STRING(objRow("KONSU")))               ' 紺数
            '        Call objExcel.SetCellValue("AN26", TO_STRING(objRow("PL_CNT")))              ' PL数
            '    Next
            'End If

            ''ﾃﾞｰﾀｾｯﾄｸﾘｱ
            'objData.Reset()

            '平均値を単純に加算
            Dim decKONSU As Decimal = 0.0           ' 梱数(平均合計計算用)
            Dim decPL_CNT As Decimal = 0.0          ' PL数(平均合計計算用)
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '' ''decKONSU = TO_DECIMAL(objExcel.GetCellValue("H26")) + TO_DECIMAL(objExcel.GetCellValue("Q26")) + TO_DECIMAL(objExcel.GetCellValue("Z26"))
            '' ''decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("M26")) + TO_DECIMAL(objExcel.GetCellValue("V26")) + TO_DECIMAL(objExcel.GetCellValue("AE26"))
            '' ''Call objExcel.SetCellValue("AI26", TO_STRING(decKONSU))          ' 平均紺数
            '' ''Call objExcel.SetCellValue("AN26", TO_STRING(decPL_CNT))         ' 平均PL数
            decKONSU = TO_DECIMAL(objExcel.GetCellValue("H34")) + TO_DECIMAL(objExcel.GetCellValue("Q34")) + TO_DECIMAL(objExcel.GetCellValue("Z34"))
            decPL_CNT = TO_DECIMAL(objExcel.GetCellValue("M34")) + TO_DECIMAL(objExcel.GetCellValue("V34")) + TO_DECIMAL(objExcel.GetCellValue("AE34"))
            Call objExcel.SetCellValue("AI34", TO_STRING(decKONSU))          ' 平均紺数
            Call objExcel.SetCellValue("AN34", TO_STRING(decPL_CNT))         ' 平均PL数
            'JobMate:S.Ouchi 2013/11/13 月報変更
            '↑↑↑↑↑↑************************************************************************************************************

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(月報_設備ﾄﾗﾌﾞﾙ状況)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(月報_設備ﾄﾗﾌﾞﾙ状況)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="strSrcDt">作成日付(YYYYMM)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasGeppoEqError(ByRef objExcel As clsExcelAppCtl, ByVal strSrcDt As String) As Boolean
        Dim blnRet As Boolean = True
        Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
        Dim strSQL As String = ""                   'SQL
        Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
        Dim intRecCnt As Integer
        Try

            '----------------------------
            ' 設備ﾄﾗﾌﾞﾙ状況
            '----------------------------
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "
            strSQL &= vbCrLf & "      , COUNT(XRST_EQ_ERROR.FLOG_NO) AS LOG_CNT "
            strSQL &= vbCrLf & "      , SUM(XRST_EQ_ERROR.XTEISI_JIKAN) AS XTEISI_JIKAN "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "        XRST_EQ_ERROR "     '【設備異常ログ】
            strSQL &= vbCrLf & "      , TSTS_EQ_CTRL "      '【設備状況】
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   XRST_EQ_ERROR.FEQ_ID = TSTS_EQ_CTRL.FEQ_ID "
            strSQL &= vbCrLf & "AND   TO_CHAR(XRST_EQ_ERROR.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "
            strSQL &= vbCrLf & "AND   TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 IN ('" & XEQ_RPT_KUBUN01_STC01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_RTN01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_TKR01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_TANA01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_CV01 & "' "
            strSQL &= vbCrLf & "                                      ,'" & XEQ_RPT_KUBUN01_RTN02 & "' )"
            strSQL &= vbCrLf & "GROUP BY TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "
            strSQL &= vbCrLf & "ORDER BY TSTS_EQ_CTRL.XEQ_RPT_KUBUN01 "


            ObjDb.SQL = strSQL
            strDataSetName = "XRST_EQ_ERROR"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                For Each objRow In objData.Tables(strDataSetName).Rows
                    Select Case TO_INTEGER(objRow("XEQ_RPT_KUBUN01"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case XEQ_RPT_KUBUN01_STC01
                        '' ''    '(1階_STC)
                        '' ''    Call objExcel.SetCellValue("H43", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("H44", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_RTN01
                        '' ''    '(1階_RTN)
                        '' ''    Call objExcel.SetCellValue("L43", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("L44", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_TKR01
                        '' ''    '(1階_TKR)
                        '' ''    Call objExcel.SetCellValue("P43", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("P44", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_TANA01
                        '' ''    '(1階_入出棚)
                        '' ''    Call objExcel.SetCellValue("T43", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("T44", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_CV01
                        '' ''    '(1階_出庫CV)
                        '' ''    Call objExcel.SetCellValue("X43", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("X44", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        '' ''Case XEQ_RPT_KUBUN01_RTN02
                        '' ''    '(2階_RTN)
                        '' ''    Call objExcel.SetCellValue("AB49", TO_STRING(objRow("LOG_CNT")))         '件数
                        '' ''    Call objExcel.SetCellValue("AB50", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)
                        Case XEQ_RPT_KUBUN01_STC01
                            '(1階_STC)
                            Call objExcel.SetCellValue("H51", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("H52", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_RTN01
                            '(1階_RTN)
                            Call objExcel.SetCellValue("L51", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("L52", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_TKR01
                            '(1階_TKR)
                            Call objExcel.SetCellValue("P51", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("P52", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_TANA01
                            '(1階_入出棚)
                            Call objExcel.SetCellValue("T51", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("T52", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_CV01
                            '(1階_出庫CV)
                            Call objExcel.SetCellValue("X51", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("X52", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)

                        Case XEQ_RPT_KUBUN01_RTN02
                            '(2階_RTN)
                            Call objExcel.SetCellValue("AB57", TO_STRING(objRow("LOG_CNT")))         '件数
                            Call objExcel.SetCellValue("AB58", TO_STRING(objRow("XTEISI_JIKAN")))    '時間(分)
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************
                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()


            '----------------------------
            ' 30分以上停止　TOP3
            '----------------------------
            '30分以上停止
            Dim strSubSQL As String = ""                'ｻﾌﾞSQL
            strSubSQL = ""
            strSubSQL &= vbCrLf & "		SELECT "
            strSubSQL &= vbCrLf & "		        ROW_NUMBER() OVER (ORDER BY XRST_EQ_ERROR.XTEISI_JIKAN DESC) AS NO "        ' No
            strSubSQL &= vbCrLf & "		      , XRST_EQ_ERROR.FEQ_ID  "                                 ' 設備ID
            strSubSQL &= vbCrLf & "		      , XRST_EQ_ERROR.FEQ_STS  "                                ' 設備状態
            strSubSQL &= vbCrLf & "		      , XRST_EQ_ERROR.XTEISI_JIKAN  "                           ' 停止時間
            strSubSQL &= vbCrLf & "		      , XRST_EQ_ERROR.FEQ_STOP_CD  "                            ' 停止要因コード
            strSubSQL &= vbCrLf & "		FROM "
            strSubSQL &= vbCrLf & "		      XRST_EQ_ERROR "   '【設備異常ログ】
            strSubSQL &= vbCrLf & "		WHERE 1=1 "
            strSubSQL &= vbCrLf & "		AND   XRST_EQ_ERROR.XTEISI_JIKAN >= 30 " '30分以上
            strSubSQL &= vbCrLf & "		AND   TO_CHAR(XRST_EQ_ERROR.XSOUGYOU_DT,'yyyyMM') = '" & strSrcDt & "' "

            'TOP3
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        EQ_ERR.NO  "                        ' NO
            strSQL &= vbCrLf & "      , EQ_ERR.FEQ_ID  "                    ' 設備ID
            strSQL &= vbCrLf & "      , TSTS_EQ_CTRL.FEQ_NAME "             ' 設備名
            strSQL &= vbCrLf & "      , EQ_ERR.XTEISI_JIKAN "               ' 停止時間
            strSQL &= vbCrLf & "      , EQ_ERR.FEQ_STOP_CD "                ' 停止要因コード
            strSQL &= vbCrLf & "      , TMST_EQ_ERROR.FEQ_STOP_NAME "        ' 停止要因名称
            strSQL &= vbCrLf & "FROM ( "
            strSQL &= vbCrLf & strSubSQL
            strSQL &= vbCrLf & "     ) EQ_ERR "
            strSQL &= vbCrLf & "     , TSTS_EQ_CTRL "       '【設備状況】
            strSQL &= vbCrLf & "     , TMST_EQ_ERROR "      '【設備異常マスタ】
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "AND   EQ_ERR.FEQ_ID = TSTS_EQ_CTRL.FEQ_ID(+) "
            strSQL &= vbCrLf & "AND   EQ_ERR.FEQ_ID = TMST_EQ_ERROR.FEQ_ID(+) "
            strSQL &= vbCrLf & "AND   EQ_ERR.FEQ_STS = TMST_EQ_ERROR.FEQ_STS(+) "
            strSQL &= vbCrLf & "AND   EQ_ERR.NO <= 3 "  'TOP3
            strSQL &= vbCrLf & "ORDER BY   EQ_ERR.NO "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_EQ_ERROR"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                Dim strFEQ_ID As String = ""
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                For Each objRow In objData.Tables(strDataSetName).Rows
                    '設備名取得
                    strFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(TO_STRING(objRow("FEQ_ID")))
                    objTSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                    objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                  '設備ID
                    objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)     '特定

                    Select Case TO_INTEGER(objRow("NO"))
                        '    ↓↓↓↓↓↓************************************************************************************************************
                        '    JobMate:S.Ouchi 2013/11/13 月報変更
                        '' ''Case 1
                        '' ''    '(1位)
                        '' ''    Call objExcel.SetCellValue("D52", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                        '' ''    Call objExcel.SetCellValue("J52", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                        '' ''    Call objExcel.SetCellValue("P52", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称

                        '' ''Case 2
                        '' ''    '(2位)
                        '' ''    Call objExcel.SetCellValue("D53", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                        '' ''    Call objExcel.SetCellValue("J53", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                        '' ''    Call objExcel.SetCellValue("P53", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称

                        '' ''Case 3
                        '' ''    '(3位)
                        '' ''    Call objExcel.SetCellValue("D54", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                        '' ''    Call objExcel.SetCellValue("J54", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                        '' ''    Call objExcel.SetCellValue("P54", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称
                        Case 1
                            '(1位)
                            Call objExcel.SetCellValue("D60", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                            Call objExcel.SetCellValue("J60", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                            Call objExcel.SetCellValue("P60", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称

                        Case 2
                            '(2位)
                            Call objExcel.SetCellValue("D61", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                            Call objExcel.SetCellValue("J61", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                            Call objExcel.SetCellValue("P61", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称

                        Case 3
                            '(3位)
                            Call objExcel.SetCellValue("D62", TO_STRING(objTSTS_EQ_CTRL.FEQ_NAME))        ' 設備名
                            Call objExcel.SetCellValue("J62", TO_STRING(objRow("XTEISI_JIKAN")))    ' 停止時間
                            Call objExcel.SetCellValue("P62", TO_STRING(objRow("FEQ_NAME")))        ' 停止要因名称
                            'JobMate:S.Ouchi 2013/11/13 月報変更
                            '↑↑↑↑↑↑************************************************************************************************************

                    End Select
                Next
            End If

            'ﾃﾞｰﾀｾｯﾄｸﾘｱ
            objData.Reset()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        Finally
            objData = Nothing
        End Try

        Return blnRet
    End Function
#End Region

#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
#Region "　生産ﾗｲﾝ日報印刷処理　            　 　   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産ﾗｲﾝ日報印刷処理
    ''' </summary>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <param name="strFilePath">作成ﾌｧｲﾙﾊﾟｽ</param>
    ''' <param name="strFileName">作成ﾌｧｲﾙ名</param>
    ''' <param name="strCSVFileName">作成CSVﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function makeReportSeisanNippo(ByVal dtSearchDate As Date _
                                  , ByVal strFilePath As String _
                                  , ByVal strFileName As String _
                                  , ByVal strCSVFileName As String _
                                  ) _
                                  As Boolean

        Dim blnResult As Boolean = True     ' 戻り値
        'Excelｵﾌﾞｼﾞｪｸﾄ操作ｸﾗｽ
        Dim objExcelCtl As clsExcelAppCtl = New clsExcelAppCtl(Owner, ObjDb, ObjDbLog)

        Try
            '***********************
            '初期設定
            '***********************
            '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
            Dim strFilePathName As String = ""
            strFilePathName &= strFilePath
            strFilePathName &= strFileName

            ' ''***********************************************
            ' '' configﾌｧｲﾙから取得
            ' ''***********************************************
            ''Dim strPrtNM As String = gobjComFuncGMN.GET_CONFIG_INFO()
            ' Temp帳票ﾌｧｲﾙ名
            Dim strDirectory As String = "..\Excel\Temp"

            '*============================
            '* ファイルのコピー
            '*============================
            Dim tempFilePath As String = strDirectory & "\" & "生産ライン日報Temp.xls"
            'ファイルをコピーする(上書き)
            System.IO.File.Copy(tempFilePath, strFilePathName, True)

            'Excelｵﾌﾞｼﾞｪｸﾄ作成
            strFilePathName = System.IO.Path.GetFullPath(strFilePathName)
            objExcelCtl.ExcelOpen(strFilePathName)

            '--------------------
            'ﾃﾞｰﾀｾｯﾄ
            '--------------------
            'ｼｰﾄへﾃﾞｰﾀをｾｯﾄ
            If SetDatasSeisanNippo(objExcelCtl, dtSearchDate) = False Then
                Throw New UserException("ﾃﾞｰﾀのｾｯﾄに失敗しました。")
                blnResult = False
            End If

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            blnResult = False
            Throw ex

        Finally
            'Excelｵﾌﾞｼﾞｪｸﾄ解放
            objExcelCtl.ExcelClose(blnResult)
        End Try

        Return blnResult

    End Function
#End Region
#Region " Excelｼｰﾄへのﾃﾞｰﾀｾｯﾄ処理(生産ﾗｲﾝ日報)      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelｼｰﾄﾍのﾃﾞｰﾀｾｯﾄ処理(生産ﾗｲﾝ日報)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasSeisanNippo(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True

        Try

            'ﾃﾞｰﾀｾｯﾄｼｰﾄ取得
            Call objExcel.SheetOpen(1)

            '作成日付設定
            Dim strSerchDate = Format(dtSearchDate, "  yyyy年  MM月  dd日 （ddd）  ")
            Call objExcel.SetCellValue("AM3", strSerchDate)

            '----------------------------
            ' 2.ﾊﾟﾚﾀｲｻﾞ稼働状況
            '----------------------------
            If SetDatasSeisanNippoPlKadou(objExcel, dtSearchDate) = False Then
                blnRet = False
                Exit Try
            End If

            'Excelﾌｧｲﾙ保存
            objExcel.ExcelSave()

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        End Try

        Return blnRet
    End Function
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ処理(生産ﾗｲﾝ日報_ﾊﾟﾚﾀｲｻﾞ稼働状況)　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ処理(日報_入庫実績)
    ''' </summary>
    ''' <param name="objExcel">ｴｸｾﾙｸﾗｽ</param>
    ''' <param name="dtSearchDate">作成日付</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Function SetDatasSeisanNippoPlKadou(ByRef objExcel As clsExcelAppCtl, ByVal dtSearchDate As Date) As Boolean
        Dim blnRet As Boolean = True
        Try
            Dim objData As DataSet = New DataSet        'ﾃﾞｰﾀｾｯﾄ
            Dim objRow As DataRow = Nothing             'ﾃﾞｰﾀｾｯﾄ行
            Dim strSQL As String = ""                   'SQL
            Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
            Dim intRecCnt As Integer

            '----------------------------
            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績
            '----------------------------
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "        XRST_DPL_PL.XSOUGYOU_DT AS XSOUGYOU_DT "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_NO AS XDPL_PL_NO "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.FHINMEI_CD AS FHINMEI_CD "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_PTN AS XDPL_PL_PTN "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XSTART_DT AS XSTART_DT "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XEND_DT AS XEND_DT "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_CNT AS XDPL_PL_CNT "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_PLT AS XDPL_PL_PLT "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_HAS AS XDPL_PL_HAS "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_KADO_TIM AS XDPL_PL_KADO_TIM "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_TRBL_TIM AS XDPL_PL_TRBL_TIM "
            strSQL &= vbCrLf & "      , XRST_DPL_PL.XDPL_PL_TRBL_CNT AS XDPL_PL_TRBL_CNT "
            strSQL &= vbCrLf & "      , XMST_DPL_PL.XDPL_PL_NAME AS XDPL_PL_NAME "
            strSQL &= vbCrLf & "      , XMST_DPL_PL.XPROD_LINE AS XPROD_LINE "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "        XRST_DPL_PL "
            strSQL &= vbCrLf & "      , XMST_DPL_PL "
            strSQL &= vbCrLf & "WHERE 1=1 "
            strSQL &= vbCrLf & "  AND   XRST_DPL_PL.XSOUGYOU_DT = TO_DATE('" & Format(dtSearchDate, "yyyy/MM/dd") & "', 'yyyy/MM/dd') "
            strSQL &= vbCrLf & "  AND   XRST_DPL_PL.XDPL_PL_NO = XMST_DPL_PL.XDPL_PL_NO "
            strSQL &= vbCrLf & "ORDER BY XMST_DPL_PL.XPROD_LINE "
            strSQL &= vbCrLf & "       , XRST_DPL_PL.XSTART_DT "

            ObjDb.SQL = strSQL
            strDataSetName = "XRST_DPL_PL"
            ObjDb.GetDataSet(strDataSetName, objData)
            intRecCnt = objData.Tables(strDataSetName).Rows.Count
            If intRecCnt > 0 Then
                Dim intROW As Integer = 0
                For Each objRow In objData.Tables(strDataSetName).Rows
                    intROW += 1
                    If intROW + 9 >= 44 Then Continue For
                    Dim strROW As String = TO_STRING(intROW + 9)

                    '----------------------------
                    'Excelｼｰﾄに貼り付け
                    '----------------------------
                    Call objExcel.SetCellValue("B" & strROW, TO_STRING(objRow("XDPL_PL_NAME")))         'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
                    Call objExcel.SetCellValue("I" & strROW, TO_STRING(objRow("XPROD_LINE")))           '生産ﾗｲﾝ№
                    Call objExcel.SetCellValue("L" & strROW, TO_STRING(objRow("FHINMEI_CD")))           '品目ｺｰﾄﾞ
                    Call objExcel.SetCellValue("T" & strROW, TO_STRING(objRow("XDPL_PL_CNT")))          '積付数
                    Call objExcel.SetCellValue("X" & strROW, TO_STRING(objRow("XDPL_PL_PLT")))          '生産ﾊﾟﾚｯﾄ数
                    Call objExcel.SetCellValue("AB" & strROW, TO_STRING(objRow("XDPL_PL_HAS")))         '端数ﾃﾞｰﾀ
                    Call objExcel.SetCellValue("AE" & strROW, TO_STRING(objRow("XSTART_DT")))           '開始日時
                    Call objExcel.SetCellValue("AJ" & strROW, TO_STRING(objRow("XEND_DT")))             '終了日時
                    Call objExcel.SetCellValue("AO" & strROW, TO_STRING(objRow("XDPL_PL_KADO_TIM")))    '運転時間
                    Call objExcel.SetCellValue("AS" & strROW, TO_STRING(objRow("XDPL_PL_TRBL_CNT")))    'ﾄﾗﾌﾞﾙ件数
                    Call objExcel.SetCellValue("AV" & strROW, TO_STRING(objRow("XDPL_PL_TRBL_TIM")))    'ﾄﾗﾌﾞﾙ時間
                Next
            End If

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            blnRet = False
            Throw ex
        End Try

        Return blnRet
    End Function
#End Region
    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  Excelファイル展開処理                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelファイルを開く
    ''' </summary>
    ''' <param name="file">ファイル(フルパス)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub OpenExcelFile(ByVal file As String)
        Try
            '*============================
            '* ファイルの存在チェック
            '*============================
            If System.IO.File.Exists(file) = False Then
                '(ファイルがないとき)
                Exit Sub
            End If

            '*============================
            '* Excelﾌｧｲﾙを開く
            '*============================
            Process.Start("Excel.exe", String.Format("""{0}""", file))  '別ウィンドウで表示

        Catch ex As UserException
            Throw
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
#Region "  起動中のExcelの特定処理                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelの起動ﾁｪｯｸ処理
    ''' </summary>
    ''' <param name="strExcelFile">Excelのファイル名</param>
    ''' <remarks>True:成功、False:失敗</remarks>
    ''' *******************************************************************************************************************
    Public Function IsExcelBookOpen(ByVal strExcelFile As String) As Boolean
        Dim blnExistFlag As Boolean = False     ' 戻り値

        Try
            '実行中のExcelのプロセス一覧を取得
            Dim prcExcels As Process() = Process.GetProcessesByName("Excel")

            '対象のExcelが含まれているかをチェック
            Dim strTitle As String = mRPRT_EXCEL_TITLE & strExcelFile
            For Each prcExcel As Process In prcExcels
                If InStr(prcExcel.MainWindowTitle, strTitle) > 0 Then
                    blnExistFlag = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try

        Return blnExistFlag
    End Function
#End Region
#Region "  CSVﾌｧｲﾙ出力                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' CSVﾌｧｲﾙ出力
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeCSV(ByVal lstData As List(Of String()) _
                     , ByVal strFilePath As String _
                     , ByVal strFileName As String _
                     )


        '***********************
        'ﾌｫﾙﾀﾞの作成
        '***********************
        If Directory.Exists(strFilePath) = False Then
            Try
                Directory.CreateDirectory(strFilePath)
            Catch ex As Exception
                Exit Sub
            End Try
        End If

        '***********************
        '初期設定
        '***********************
        '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
        Dim strFilePathName As String = ""
        strFilePathName &= strFilePath
        strFilePathName &= strFileName

        '***********************
        '* ファイル作成
        '***********************
        Dim strData As String()
        Using sw As New StreamWriter(strFilePathName, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Try
                For Each strData In lstData
                    '配列の内容をファイルに書き出す
                    sw.Write(String.Join(",", strData))
                    sw.Write(vbCrLf)
                Next
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Throw ex
            Finally
                sw.Close()
            End Try
        End Using


    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/12 日報変更
#Region "　空ﾌﾞﾛｯｸ数を取得               　     "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 空ﾌﾞﾛｯｸ数を取得
    ''' </summary>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Private Function akiTanaDisplay() As Integer

        Dim strSQL As String                        'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    COUNT(*) AS CNT "
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "

        '============================================================
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ副問合せ
        '============================================================
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "      TPRG_TRK_BUF.XTANA_BLOCK "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_FORM) AS FRAC_FORM "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRNS_ADDRESS) AS FTRNS_ADDRESS "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRES_KIND) AS FRES_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FREMOVE_KIND) AS FREMOVE_KIND "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FTRK_BUF_NO) AS FTRK_BUF_NO "
        strSQL &= vbCrLf & "     ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU "
        strSQL &= vbCrLf & "    FROM TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    WHERE 1 = 1 "
        strSQL &= vbCrLf & "    GROUP BY TPRG_TRK_BUF.XTANA_BLOCK"
        strSQL &= vbCrLf & "    ) TPRG_TRK_BUF "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "      1 = 1 "
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND    = " & FRES_KIND_SAKI                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.引当状態 が 0:空棚 のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FREMOVE_KIND = " & FREMOVE_KIND_SNORMAL          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.禁止有無 が 0:無   のﾚｺｰﾄﾞを抽出
        strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FTRK_BUF_NO  = " & FTRK_BUF_NO_J9000             '自動倉庫

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        ObjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)

        Return TO_INTEGER(objRow("CNT"))

    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/12 日報変更
    '↑↑↑↑↑↑************************************************************************************************************

End Class
