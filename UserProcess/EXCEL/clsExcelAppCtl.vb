'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ機能
' 【機能】Excelｺﾝﾄﾛｰﾙ
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

Public Class clsExcelAppCtl
    Inherits clsTemplateServer

#Region " 変数                                  "
    Private _xlApp As Excel.Application     'Excelｵﾌﾞｼﾞｪｸﾄ
    Private _xlBooks As Excel.Workbooks     'WorkBooksﾌﾞｼﾞｪｸﾄ
    Private _xlBook As Excel.Workbook       'WorkBookﾌﾞｼﾞｪｸﾄ
    Private _xlSheets As Excel.Sheets       'Sheetsﾌﾞｼﾞｪｸﾄ
    Private _xlSheet As Excel.Worksheet     'Worksheetﾌﾞｼﾞｪｸﾄ

    Private _filePath As String             'ﾌｧｲﾙﾊﾟｽ
#End Region
#Region " ｺﾝｽﾄﾗｸﾀ                               "
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
#Region " Excelｵﾌﾞｼﾞｪｸﾄ作成                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelｵﾌﾞｼﾞｪｸﾄ作成
    ''' </summary>
    ''' <param name="filePath">ファイルパス</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExcelOpen(ByVal filePath As String)

        Try
            '事前ﾁｪｯｸ
            If String.IsNullOrEmpty(filePath) = True Then
                Throw New UserException("ﾌｧｲﾙの作成に失敗しました。[ﾌｧｲﾙ名無し]")
                Exit Sub
            End If

            'Excelｵﾌﾞｼﾞｪｸﾄ作成
            _xlApp = New Excel.Application
            'Workbooksｵﾌﾞｼﾞｪｸﾄ取得
            _xlBooks = _xlApp.Workbooks

            '指定のﾌﾞｯｸを開く
            _filePath = filePath
            _xlBook = _xlBooks.Open(Filename:=filePath)
            _xlSheets = _xlBook.Worksheets

            '表示しない
            _xlApp.Visible = False

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region " COMオブジェクト解放処理               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' COMオブジェクトの参照カウントをデクリメントします。
    ''' </summary>
    ''' <param name="objCom">
    ''' COM オブジェクト持った変数を指定します。
    ''' このメソッドの呼出し後、この引数の内容は Nothing となります。
    ''' </param>
    ''' <typeparam name="T">(省略可能)</typeparam>
    ''' <param name="force">
    ''' すべての参照を強制解放する場合はTrue、現在の参照のみを減ずる場合はFalse。
    ''' </param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MRComObject(Of T As Class)(ByRef objCom As T, Optional ByVal force As Boolean = False)
        If objCom Is Nothing Then
            Return
        End If
        Try
            If System.Runtime.InteropServices.Marshal.IsComObject(objCom) Then
                If force Then
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objCom)
                Else
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)
                End If
            End If
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            objCom = Nothing
        End Try
    End Sub

#End Region
#Region " Excelｵﾌﾞｼﾞｪｸﾄ解放                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelｵﾌﾞｼﾞｪｸﾄ解放
    ''' </summary>
    ''' <param name="quitFlg">True：Excelを終了する</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExcelClose(Optional ByVal quitFlg As Boolean = False)
        Try
            'xlSheet の解放
            If IsNothing(_xlSheet) = False Then
                MRComObject(_xlSheet)
            End If
            'xlSheets の解放
            If IsNothing(_xlSheets) = False Then
                MRComObject(_xlSheets)
            End If
            'xlBook の解放
            If IsNothing(_xlBook) = False Then
                'xlBook を閉じる
                _xlBook.Close(SaveChanges:=False)
                MRComObject(_xlBook)
            End If
            'xlBooks の解放
            If IsNothing(_xlBooks) = False Then
                MRComObject(_xlBooks)
            End If
            'xlApp を解放
            If IsNothing(_xlApp) = False Then
                If quitFlg = True Then
                    ExcelQuit()
                End If
                MRComObject(_xlApp)
            End If
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region " Excelの終了                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelを終了する
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExcelQuit()
        Try
            _xlApp.CutCopyMode = False
            _xlApp.Quit()
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region " 指定のｼｰﾄを取得                       "
#Region " 指定のｼｰﾄを取得(番号指定)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指定のｼｰﾄを取得(番号指定)
    ''' </summary>
    ''' <param name="sheetNo">シート番号</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SheetOpen(ByVal sheetNo As Integer)

        Try
            If sheetNo <= 0 Then
                '(0以下の場合)
                '1シート名を参照
                _xlSheet = CType(_xlSheets.Item(1), Excel.Worksheet)
            Else
                _xlSheet = CType(_xlSheets(sheetNo), Excel.Worksheet)
            End If

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region " 指定のｼｰﾄを取得(名称指定)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 指定のｼｰﾄを取得(名称指定)
    ''' </summary>
    ''' <param name="sheetName">シート名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SheetOpen(ByVal sheetName As String)

        Try
            '事前ﾁｪｯｸ
            If String.IsNullOrEmpty(sheetName) = True Then
                Throw New UserException("ﾌｧｲﾙの作成に失敗しました。[ｼｰﾄ名無し]")
                Exit Sub
            End If

            _xlSheet = CType(_xlSheets(sheetName), Excel.Worksheet)

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#End Region
#Region " Excelの保存                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Excelﾌｧｲﾙを保存する
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ExcelSave()
        Try
            '上書き保存して終了処理を実行する
            _xlApp.DisplayAlerts = False   '保存時の問合せのダイアログを非表示に設定

            Dim kts As String = System.IO.Path.GetExtension(_filePath).ToLower()

            If _xlBook.ReadOnly = False Then
                '(読取り専用でない場合)
                Dim fm As Excel.XlFileFormat
                '拡張子に合せて保存形式を変更
                Select Case kts
                    Case ".csv"    'CSV (カンマ区切り) 形式
                        fm = Excel.XlFileFormat.xlCSV
                        '(読取り専用以外の場合)
                        _xlBook.SaveAs(_filePath, fm)    'ファイルに保存
                    Case ".xls"    'Excel 97～2003 ブック形式
                        '(読取り専用以外の場合)
                        _xlBook.SaveAs(Filename:=_filePath)    'ファイルに保存
                End Select
            Else
                '(読み取り専用の場合)
                Throw New UserException("ﾌｧｲﾙが読み取り専用になっている為、保存できません。")
                Exit Sub
            End If

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region " ﾃﾞｰﾀをｸﾘｱする                         "
#Region " ﾃﾞｰﾀｸﾘｱ_選択ｼｰﾄ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択ｼｰﾄのﾃﾞｰﾀをｸﾘｱする
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClearSheet()
        Dim xlRange As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlRange = CType(_xlSheet.Cells(), Excel.Range)
            xlRange.Clear()

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try
    End Sub

#End Region
#Region " ﾃﾞｰﾀｸﾘｱ_ｾﾙ指定                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択ｾﾙのﾃﾞｰﾀをｸﾘｱする
    ''' </summary>
    ''' <param name="rangeX">範囲 X座標</param>
    ''' <param name="rangeY">範囲 Y座標</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClearCell(ByVal rangeX As Integer, ByVal rangeY As Integer)
        Dim xlRange As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If rangeX < 0 Then Exit Sub
            If rangeY < 0 Then Exit Sub
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlRange = CType(_xlSheet.Cells(rangeY, rangeX), Excel.Range)
            xlRange.Clear()

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try
    End Sub
#End Region
#Region " ﾃﾞｰﾀｸﾘｱ_ｾﾙ範囲指定                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択範囲のﾃﾞｰﾀをｸﾘｱする
    ''' </summary>
    ''' <param name="rangeXS">範囲 X座標</param>
    ''' <param name="rangeYS">範囲 Y座標</param>
    ''' <param name="rangeXE">範囲 X座標エンド</param>
    ''' <param name="rangeYE">範囲 Y座標エンド</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ClearCell(ByVal rangeXS As Integer, ByVal rangeYS As Integer, ByVal rangeXE As Integer, ByVal rangeYE As Integer)
        Dim xlRange As Excel.Range = Nothing
        Dim xlCell1 As Excel.Range = Nothing
        Dim xlCell2 As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If rangeXS < 0 Then Exit Sub
            If rangeYS < 0 Then Exit Sub
            If rangeXE < 0 Then Exit Sub
            If rangeYE < 0 Then Exit Sub
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlCell1 = CType(_xlSheet.Cells(rangeYS, rangeXS), Excel.Range)
            xlCell2 = CType(_xlSheet.Cells(rangeYE, rangeXE), Excel.Range)
            xlRange = _xlSheet.Range(xlCell1, xlCell2)   'データの入力セル範囲
            xlRange.Clear()

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
            If IsNothing(xlCell1) = False Then
                MRComObject(xlCell1)
            End If
            If IsNothing(xlCell2) = False Then
                MRComObject(xlCell2)
            End If
        End Try
    End Sub

#End Region

#End Region
#Region " ｾﾙにﾃﾞｰﾀをｾｯﾄする                     "
#Region " ﾃﾞｰﾀｾｯﾄ(ｾﾙ指定_文字列)                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙにﾃﾞｰﾀをｾｯﾄする
    ''' </summary>
    ''' <param name="rangeStr">範囲文字列</param>
    ''' <param name="data">データ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SetCellValue(ByVal rangeStr As String, ByVal data As String)
        Dim xlRange As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If String.IsNullOrEmpty(rangeStr) = True Then
                '(範囲指定が無い場合)
                Exit Sub
            End If
            If String.IsNullOrEmpty(data) = True Then
                '(データが無い場合)
                Exit Sub
            End If
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlRange = _xlSheet.Range(rangeStr)          'データの入力セル範囲
            xlRange.Value = data                        'セルへデータの入力

            'xlRange オブジェクトを解放  
            MRComObject(xlRange)

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try
    End Sub
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ(ｾﾙ指定_数値)                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙにﾃﾞｰﾀをｾｯﾄする
    ''' </summary>
    ''' <param name="rangeX">範囲 X座標</param>
    ''' <param name="rangeY">範囲 Y座標</param>
    ''' <param name="data">データ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SetCellValue(ByVal rangeX As Integer, ByVal rangeY As Integer, ByVal data As String)
        Dim xlRange As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If rangeX < 0 Then Exit Sub
            If rangeY < 0 Then Exit Sub
            If String.IsNullOrEmpty(data) = True Then
                '(データが無い場合)
                Exit Sub
            End If
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlRange = CType(_xlSheet.Cells(rangeY, rangeX), Excel.Range)    'データの入力セル範囲
            xlRange.Value = data                                            'セルへデータの入力

            'xlRange オブジェクトを解放  
            MRComObject(xlRange)

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try
    End Sub
#End Region
#Region " ﾃﾞｰﾀｾｯﾄ(ｾﾙ範囲_数値)             　　 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄ(ｾﾙ範囲_数値)
    ''' </summary>
    ''' <param name="rangeXS">範囲 X座標スタート</param>
    ''' <param name="rangeYS">範囲 Y座標スタート</param>
    ''' <param name="rangeXE">範囲 X座標エンド</param>
    ''' <param name="rangeYE">範囲 Y座標エンド</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SetCellValue(ByVal rangeXS As Integer, ByVal rangeYS As Integer, ByVal rangeXE As Integer, ByVal rangeYE As Integer, ByVal data() As String)
        Dim xlRange As Excel.Range = Nothing
        Dim xlCell1 As Excel.Range = Nothing
        Dim xlCell2 As Excel.Range = Nothing
        Try
            '事前ﾁｪｯｸ
            If rangeXS < 0 Then Exit Sub
            If rangeYS < 0 Then Exit Sub
            If rangeXE < 0 Then Exit Sub
            If rangeYE < 0 Then Exit Sub
            If IsNothing(data) = True OrElse data.Count = 0 Then
                '(データが無い場合)
                Exit Sub
            End If
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Exit Sub
            End If

            xlCell1 = CType(_xlSheet.Cells(rangeYS, rangeXS), Excel.Range)
            xlCell2 = CType(_xlSheet.Cells(rangeYE, rangeXE), Excel.Range)
            xlRange = _xlSheet.Range(xlCell1, xlCell2)              'データの入力セル範囲
            xlRange.Value = data                                    'セルへデータの入力

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
            If IsNothing(xlCell1) = False Then
                MRComObject(xlCell1)
            End If
            If IsNothing(xlCell2) = False Then
                MRComObject(xlCell2)
            End If
        End Try
    End Sub
#End Region

#End Region
#Region " ｾﾙのﾃﾞｰﾀを取得する                    "
#Region " ﾃﾞｰﾀ取得(ｾﾙ指定_文字列)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｾﾙ指定_文字列)
    ''' </summary>
    ''' <param name="rangeStr">範囲文字列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCellValue(ByVal rangeStr As String) As String
        Dim xlRange As Excel.Range = Nothing
        Dim strRtn As String = String.Empty
        Try
            '事前ﾁｪｯｸ
            If String.IsNullOrEmpty(rangeStr) = True Then
                '(範囲指定が無い場合)
                Return strRtn
            End If
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Return strRtn
            End If

            xlRange = _xlSheet.Range(rangeStr)                  'セル範囲
            strRtn = xlRange.Value2                             'セルのデータ取得

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try

        Return strRtn

    End Function
#End Region
#Region " ﾃﾞｰﾀ取得(ｾﾙ指定_数値)                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｾﾙ指定_数値)
    ''' </summary>
    ''' <param name="rangeX">範囲 X座標</param>
    ''' <param name="rangeY">範囲 Y座標</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCellValue(ByVal rangeX As Integer, ByVal rangeY As Integer) As String
        Dim xlRange As Excel.Range = Nothing
        Dim strRtn As String = String.Empty
        Try
            '事前ﾁｪｯｸ
            If rangeX < 0 Then Return strRtn
            If rangeY < 0 Then Return strRtn
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Return strRtn
            End If

            xlRange = CType(_xlSheet.Cells(rangeY, rangeX), Excel.Range)    'セル範囲
            strRtn = xlRange.Value                                          'セルのデータ取得

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try

        Return strRtn
    End Function
#End Region
#Region " ﾃﾞｰﾀ取得(ｾﾙ範囲_数値)             　　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｾﾙ範囲_数値)
    ''' </summary>
    ''' <param name="rangeXS">範囲 X座標スタート</param>
    ''' <param name="rangeYS">範囲 Y座標スタート</param>
    ''' <param name="rangeXE">範囲 X座標エンド</param>
    ''' <param name="rangeYE">範囲 Y座標エンド</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCellValues(ByVal rangeXS As Integer, _
                             ByVal rangeYS As Integer, _
                             ByVal rangeXE As Integer, _
                             ByVal rangeYE As Integer) As List(Of String())

        Dim xlCell1 As Excel.Range = Nothing
        Dim strRtn As List(Of String()) = Nothing

        Try
            '事前ﾁｪｯｸ
            If rangeXS < 0 Then Return strRtn
            If rangeYS < 0 Then Return strRtn
            If rangeXE < 0 Then Return strRtn
            If rangeYE < 0 Then Return strRtn
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Return strRtn
            End If

            For iY As Integer = rangeYS To rangeYE
                Dim strTemp(rangeXE - rangeXS + 1) As String
                Dim iCnt As Integer = 0
                For iX As Integer = rangeXS To rangeXE
                    xlCell1 = CType(_xlSheet.Cells(iY, iX), Excel.Range)    'セル範囲
                    strTemp(iCnt) = xlCell1.Value                           'セルのデータ取得
                Next
                strRtn.Add(strTemp)
            Next

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlCell1) = False Then
                MRComObject(xlCell1)
            End If
        End Try

        Return strRtn
    End Function
#End Region
#Region " 時間ﾃﾞｰﾀ取得(ｾﾙ指定_文字列)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 時間ﾃﾞｰﾀ取得(ｾﾙ指定_文字列)
    ''' </summary>
    ''' <param name="rangeStr">範囲文字列</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCellDateValue(ByVal rangeStr As String) As Date
        Dim xlRange As Excel.Range = Nothing
        Dim dtRtn As Date = Nothing
        Try
            '事前ﾁｪｯｸ
            If String.IsNullOrEmpty(rangeStr) = True Then
                '(範囲指定が無い場合)
                Return dtRtn
            End If
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Return dtRtn
            End If

            xlRange = _xlSheet.Range(rangeStr)                  'セル範囲
            Dim value As Object = xlRange.Value2                  'セルのデータ取得

            If Not value Is Nothing Then
                If TypeOf value Is Double Then
                    dtRtn = DateTime.FromOADate(CType(value, Double))
                Else
                    DateTime.TryParse(CType(value, String), dtRtn)
                End If
            End If


        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try

        Return dtRtn

    End Function
#End Region
#Region " 時間ﾃﾞｰﾀ取得(ｾﾙ指定_数値)             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 時間ﾃﾞｰﾀ取得(ｾﾙ指定_数値)
    ''' </summary>
    ''' <param name="rangeX">範囲 X座標</param>
    ''' <param name="rangeY">範囲 Y座標</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCellDateValue(ByVal rangeX As Integer, ByVal rangeY As Integer) As Date
        Dim xlRange As Excel.Range = Nothing
        Dim dtRtn As Date = Nothing
        Try
            '事前ﾁｪｯｸ
            If rangeX < 0 Then Return dtRtn
            If rangeY < 0 Then Return dtRtn
            If IsNothing(_xlSheet) = True Then
                '(シートが指定されて無い場合)
                Return dtRtn
            End If

            xlRange = CType(_xlSheet.Cells(rangeY, rangeX), Excel.Range)    'セル範囲
            Dim value As Object = xlRange.Value2                  'セルのデータ取得

            If Not value Is Nothing Then
                If TypeOf value Is Double Then
                    dtRtn = DateTime.FromOADate(CType(value, Double))
                Else
                    DateTime.TryParse(CType(value, String), dtRtn)
                End If
            End If

        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw ex
        Finally
            'xlRange オブジェクトを解放  
            If IsNothing(xlRange) = False Then
                MRComObject(xlRange)
            End If
        End Try

        Return dtRtn
    End Function
#End Region

#End Region

End Class
