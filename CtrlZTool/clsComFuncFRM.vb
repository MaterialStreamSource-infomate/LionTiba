'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports System.Text
Imports System.Xml
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
Imports System.Net
#End Region

Public Class clsComFuncFRM

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通


    '**********************************************************************************************
    ' ｸﾞﾛｰﾊﾞﾙ変数
    '**********************************************************************************************
    Public Shared gobjDb As clsConnZTool                        'DB接続ｵﾌﾞｼﾞｪｸﾄ
    Public Shared gobjOwner As clsOwner                         '画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Public Shared gblnFirst As Boolean = True                   '最初のﾌｫｰﾑか否か


    Public Shared gobjFRM_100004 As FRM_100004          'Wait画面

    '取得ﾃﾞｰﾀ
    Public Shared gcstrFUSER_ID As String                    'ﾕｰｻﾞｰID
    Public Shared gcstrFTERM_ID As String                    '端末ID

    '=======================================================================
    ' Config    取得ﾃﾞｰﾀ
    '=======================================================================
    '画面ｴﾗｰﾛｸﾞ用
    Public Shared gcstrLOG_FILE_PATH As String              'ﾌｧｲﾙ格納場所
    Public Shared gcstrLOG_FILE_NAME As String              'ﾌｧｲﾙ名         
    Public Shared gcstrLOG_FILE_NAME_OLD As String          'ﾌｧｲﾙ名(古い)   
    Public Shared gcstrLOG_FILE_SIZE As String              '最大ﾌｧｲﾙｻｲｽﾞ   


    '**********************************************************************************************
    ' ｸﾞﾛｰﾊﾞﾙ定数
    '**********************************************************************************************
    'Configｷｰ
    Public Const GKEY_G000000_005 As String = "G000000_005"           '画面ﾛｸﾞﾌｧｲﾙ名
    Public Const GKEY_G000000_006 As String = "G000000_006"           '画面ﾛｸﾞﾌｧｲﾙ名(古い方)
    Public Const GKEY_G000000_007 As String = "G000000_007"           '画面ﾛｸﾞﾌｧｲﾙの最大ｻｲｽﾞ
    Public Const GKEY_G000000_020 As String = "G000000_020"           '列ﾀｰﾐﾈｰﾀ
    Public Const GKEY_G000000_021 As String = "G000000_021"           '行ﾀｰﾐﾈｰﾀ
    Public Const GKEY_G000000_022 As String = "G000000_022"           'PDF出力先（開発者用）
    Public Const GKEY_G000000_031 As String = "G000000_031"           '画面ﾛｸﾞﾌｧｲﾙ格納場所
    Public Const GKEY_G000000_041 As String = "G000000_041"           'ﾂｰﾙﾄﾘｯﾌﾟﾃｷｽﾄﾎﾞｯｸｽをﾀﾞﾌﾞﾙｸﾘｯｸした時に設定するNow日時の差分(Min)
    Public Const GKEY_G000000_042 As String = "G000000_042"           'ﾌﾟﾛｸﾞﾗﾑ開始時のﾌｫｰﾑ状態    0:ﾉｰﾏﾙ   1:最大化
    Public Const GKEY_G000000_043 As String = "G000000_043"           'ｸﾞﾘｯﾄﾞ表示の際、警告ﾒｯｾｰｼﾞを表示する基準となる行数   (ここで設定された行数を超えると警告ﾒｯｾｰｼﾞを出力する)
    Public Const GKEY_G000000_044 As String = "G000000_044"           '1秒で表示可能な行数(行/sec)                          (警告ﾒｯｾｰｼﾞで使用)
    Public Const GKEY_G000000_051 As String = "G000000_051"           'ﾌﾟﾛｸﾞﾗﾑ開始時に表示するﾃｰﾌﾞﾙ一覧
    Public Const GKEY_G000000_061 As String = "G000000_061"           'ﾛｸﾞﾃｰﾌﾞﾙ表示定義   【ﾃｰﾌﾞﾙ名】@@@【ﾌｨｰﾙﾄﾞ名】
    Public Const GKEY_G000000_062 As String = "G000000_062"           'ﾛｸﾞﾃｰﾌﾞﾙ表示定義のﾃﾞﾘﾐﾀ定義
    'その他
    Public Const CONFIG_ZTOOL As String = "..\Config\xmlZTool.config"               'Configﾌｧｲﾙ名(ZTool)
    Public Const DATE_FORMAT_02 As String = "yyyy/MM/dd"                            '日付ﾌｫｰﾏｯﾄ
    Public Const DATE_FORMAT_03 As String = "yyyy/MM/dd HH:mm:ss"                   '日付ﾌｫｰﾏｯﾄ



#Region "  Configﾌｧｲﾙから、情報取得             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから情報取得
    ''' </summary>
    ''' <param name="sKey">検索するｷｰ</param>
    ''' <returns>Configﾌｧｲﾙから取得した文字列</returns>
    ''' <remarks>引数にて指示された情報をConfigﾌｧｲﾙより取得する</remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GET_CONFIG_INFO(ByVal sKey As String) As String
        Dim strRet As String = ""                               '戻値
        Dim objSystem As New clsConnectConfig(CONFIG_ZTOOL)     'Configﾌｧｲﾙ接続ｸﾗｽ（画面用Config）

        strRet = TO_STRING(objSystem.GET_INFO(sKey))

        Return (strRet)
    End Function
#End Region
#Region "  ﾛｸﾞ書込処理                          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理
    ''' </summary>
    ''' <param name="strMsg_1">ﾒｯｾｰｼﾞ1</param>
    ''' <param name="intErrorType">ｴﾗｰﾀｲﾌﾟ</param>
    ''' <param name="strMsg_3">ﾒｯｾｰｼﾞ3</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Shared Sub AddToLog_frm(ByVal strMsg_1 As String, _
                                   Optional ByVal intErrorType As AddToLog_D_ErrorType = AddToLog_D_ErrorType.USER_LOG, _
                                   Optional ByVal strMsg_3 As String = "")
        Try
            Dim strMsg_2 As String = ""

            '***************************************
            'ログ出力
            '***************************************
            Dim objLogWrite As clsWriteLog
            objLogWrite = New clsWriteLog
            objLogWrite.clspFileName = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME       'ﾌｧｲﾙ名         ｾｯﾄ
            objLogWrite.clspCopyFile = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME_OLD   'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            objLogWrite.clspMaxSize = gcstrLOG_FILE_SIZE        '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


            Select Case intErrorType
                Case AddToLog_D_ErrorType.PROGRAM_ERROR
                    strMsg_2 = FRM_ERR_COMERROR_TITLE
                Case AddToLog_D_ErrorType.USER_ERROR
                    strMsg_2 = FRM_ERR_USERERRO_TITLE
                Case AddToLog_D_ErrorType.USER_LOG
                    strMsg_2 = FRM_ERR_USERLOG_TITLE
            End Select


            objLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              'ﾛｸﾞ書込

        Catch ex2 As Exception
            MsgBox("AddToLog_frm関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  ｴﾗｰ処理      (継承画面用)            "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理(継承画面用)
    ''' </summary>
    ''' <param name="objException">ｴﾗｰの Exception</param>
    ''' <param name="lblError">ｴﾗｰを表示させるﾗﾍﾞﾙ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Shared Sub ComError_frm(ByVal objException As Exception, _
                                   Optional ByVal lblError As Windows.Forms.Label = Nothing)
        Try


            '***************************************
            'Wait画面を強制的にｸﾛｰｽﾞ
            '  ﾌﾟﾘﾝﾄｴﾗｰの時、Wait画面が残ったままになる為
            '  どうせなら、ｴﾗｰが発生した時には、何も考えずWait画面を削除するように
            '***************************************
            Call WaitFormClose()


            '***************************************
            'ﾃｷｽﾄ生成
            '***************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)


            '****************************************
            ' ﾛｸﾞ書込み
            '****************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog_frm(objException.Message, _
                             AddToLog_D_ErrorType.PROGRAM_ERROR, _
                             strStackTrace(ii))
            Next


            '***************************************
            'ﾗﾍﾞﾙ出力
            '***************************************
            If Not (IsNull(lblError)) Then
                lblError.Text = FRM_ERR_COMERROR_TITLE & objException.Message
            Else

                MsgBox(objException.Message, _
                       MsgBoxStyle.Exclamation, _
                       FRM_ERR_COMERROR_TITLE)

            End If


        Catch ex2 As Exception
            MsgBox("ComError_frm関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  Waitﾌｫｰﾑ         Show、Close処理     "
    Public Shared Sub WaitFormShow()

        '***************************************************
        ' ﾒｯｾｰｼﾞ表示
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If
        gobjFRM_100004 = New FRM_100004
        gobjFRM_100004.Show()
        gobjFRM_100004.Refresh()

    End Sub

    Public Shared Sub WaitFormClose()

        '***************************************************
        ' ﾒｯｾｰｼﾞ削除
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If

    End Sub

#End Region
#Region "　ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strText01">ﾃｷｽﾄ1</param>
    ''' <param name="strText02">ﾃｷｽﾄ2</param>
    ''' <param name="strText05">ﾃｷｽﾄ5</param>
    ''' <param name="strText06">ﾃｷｽﾄ6</param>
    ''' <param name="strText07">ﾃｷｽﾄ7</param>
    ''' <param name="strFooter01">ﾌｯﾀｰ1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Sub CRPrintKaihatu(ByVal grdControl As System.Windows.Forms.DataGridView _
                                   , ByVal strTableName As String _
                                   , ByVal strText01 As String _
                                   , ByVal strText02 As String _
                                   , ByVal strText05 As String _
                                   , ByVal strText06 As String _
                                   , ByVal strText07 As String _
                                   , ByVal strFooter01 As String _
                                   )

        Call WaitFormShow()                     ' Waitﾌｫｰﾑ表示


        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_000001             'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
        Dim strColTerminator As String = GET_CONFIG_INFO(GKEY_G000000_020)
        Dim strRowTerminator As String = GET_CONFIG_INFO(GKEY_G000000_021)

        Try


            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call ChangeCRText(objCR, "crDateTime01", "")    '発行日時
            Call ChangeCRText(objCR, "Text3", "")           '発行日時
            Call ChangeCRText(objCR, "crText01", strText01)
            Call ChangeCRText(objCR, "crText02", strText02)
            '' ''Call ChangeCRText(objCR, "crText03", strText03)
            '' ''Call ChangeCRText(objCR, "crText04", strText04)
            Call ChangeCRText(objCR, "crText05", strText05)
            Call ChangeCRText(objCR, "crText06", strText06)
            Call ChangeCRText(objCR, "crText07", strText07)
            Call ChangeCRText(objCR, "crFooter01", strFooter01)
            Call ChangeCRText(objCR, "crFooter02", strText01)


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdControl.Rows.Count - 1 - 1
                '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数 - 1    ｸﾞﾘｯﾄﾞ最終行は空白なので省く)

                '=========================================
                '文字列作成
                '=========================================
                Dim strData As String = ""
                For jj As Integer = 0 To grdControl.ColumnCount - 1
                    If jj <> 0 Then strData &= strColTerminator
                    strData &= """" & grdControl.Item(jj, ii).Value & """"
                Next
                strData &= strRowTerminator

                '=========================================
                '配列作成
                '=========================================
                Dim strDataArray() As String = Nothing
                Call DivStringToArray(strData, strDataArray)

                '=========================================
                'ﾃﾞｰﾀ追加
                '=========================================
                For jj As Integer = LBound(strDataArray) To UBound(strDataArray)
                    Dim objDataRow As clsPrintDataSet.DataTable01Row
                    objDataRow = objDataSet.DataTable01.NewRow
                    objDataRow.BeginEdit()
                    objDataRow.Data00 = strDataArray(jj)
                    objDataRow.EndEdit()
                    objDataSet.DataTable01.Rows.Add(objDataRow)
                Next

            Next


            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)


            ' ''***********************************************
            ' '' 印字
            ' ''***********************************************
            ''objCR.PrintToPrinter(1, False, 0, 0)    ' 印字


            '***********************************************
            ' PDF出力
            '***********************************************
            'ﾌｧｲﾙ名作成
            Dim strPathPDF As String = GET_CONFIG_INFO(GKEY_G000000_022)
            strPathPDF &= strFooter01
            strPathPDF &= "_"
            strPathPDF &= strTableName
            '' ''strPathPDF &= "_"
            '' ''strPathPDF &= Format(Now, GAMEN_DATE_FORMAT_04)
            strPathPDF &= ".pdf"
            'ﾌｧｲﾙﾁｪｯｸ
            'ﾌｫﾙﾀﾞ作成
            If System.IO.File.Exists(strPathPDF) Then
                If MessageBox.Show("同じ名前のファイルが既に存在しています。" & vbCrLf & "上書きしますか？", "確認", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
            'PDF出力
            objCR.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strPathPDF)


        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更
    ''' </summary>
    ''' <param name="objCR">ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strObjectName">ｸﾘｽﾀﾙﾚﾎﾟｰﾄの貼り付いているｵﾌﾞｼﾞｪｸﾄ名</param>
    ''' <param name="strText">ｸﾘｽﾀﾙﾚﾎﾟｰﾄに表示させるﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Sub ChangeCRText(ByVal objCR As Object, _
                            ByVal strObjectName As String, _
                            ByVal strText As String)

        CType(objCR.ReportDefinition.ReportObjects(strObjectName),  _
              CrystalDecisions.CrystalReports.Engine.TextObject). _
              Text = strText

    End Sub
#End Region
#Region "  文字列をx文字ずつ分割して、配列に挿入    "
    '''****************************************************************************************
    ''' <summary>
    ''' 文字列をx文字ずつ分割して、配列に挿入
    ''' </summary>
    ''' <param name="strString">分割する文字列</param>
    ''' <param name="strArray">分割後の配列</param>
    ''' <param name="intDivLength">分割する文字数</param>
    ''' <remarks></remarks>
    '''****************************************************************************************
    Public Shared Sub DivStringToArray(ByVal strString As String _
                                     , ByRef strArray() As String _
                                     , Optional ByVal intDivLength As Integer = 180 _
                                     )
        Dim strWork As String = strString
        Dim ii As Integer = 0


        While True
            Dim strTemp As String = MID_SJIS(strWork, 1, intDivLength)
            If strTemp = "" Then Exit While
            ReDim Preserve strArray(ii)
            strArray(ii) = strTemp
            ii += 1
            strWork = Replace(strWork, strTemp, "")
        End While


    End Sub
#End Region

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************





End Class
