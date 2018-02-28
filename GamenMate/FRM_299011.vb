'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】SQL文実行画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299011

#Region "　共通変数　                               "

    '================================================
    '変数
    '================================================
    '画面ｻｲｽﾞ変更用
    Private mobjDb As clsConn                       'DB接続
    Private mobjFRM_299010 As FRM_299010            'DBﾒﾝﾃﾅﾝｽﾂｰﾙ

    '画面ｻｲｽﾞ変更用
    Private mintDifftxtSQLX As Integer              'SQLﾃｷｽﾄﾎﾞｯｸｽX軸差分
    Private mintDifftxtSQLY As Integer              'SQLﾃｷｽﾄﾎﾞｯｸｽY軸差分

    '================================================
    '定数
    '================================================
    'ﾒｯｾｰｼﾞ
    Private Const MSG001 As String = "ﾃﾞｰﾀを取得します。よろしいですか？"
    Private Const MSG002 As String = "SQL文を実行します。よろしいですか？"
    Private Const MSG003 As String = "件のﾚｺｰﾄﾞが実行されました。"


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    Public Property objFRM_299010() As FRM_299010
        Get
            Return mobjFRM_299010
        End Get
        Set(ByVal Value As FRM_299010)
            mobjFRM_299010 = Value
        End Set
    End Property
    Public Property objDb() As clsConn
        Get
            Return mobjDb
        End Get
        Set(ByVal Value As clsConn)
            mobjDb = Value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑｻｲｽﾞ変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｻｲｽﾞ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299011_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            Call FormSizeChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  取得ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 取得ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdGetDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetDisp.Click
        Try
            Call cmdGetDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  更新ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExecute.Click
        Try
            Call cmdExecuteProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'ﾒﾆｭｰ
#Region "  Select文ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Select文ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSelect.Click
        Try
            Call tsmSelectClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Update文ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update文ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmUpdate.Click
        Try
            Call tsmUpdateClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Insert文ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert文ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInsert.Click
        Try
            Call tsmInsertClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Delete文ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete文ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelete.Click
        Try
            Call tsmDeleteClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  取得ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 取得ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmGetDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmGetDisp.Click
        Try
            Call tsmGetDispClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  更新ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExecute.Click
        Try
            Call tsmExecuteClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

    'ｲﾍﾞﾝﾄ処理
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()


        '********************************************************************
        '色々初期化
        '********************************************************************
        mintDifftxtSQLX = Me.Size.Width - txtSQL.Size.Width         'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞX軸差分
        mintDifftxtSQLY = Me.Size.Height - txtSQL.Size.Height       'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞY軸差分


    End Sub
#End Region
#Region "  ﾌｫｰﾑｻｲｽﾞ変更処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｻｲｽﾞ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormSizeChangedProcess()


        If mintDifftxtSQLX <> 0 Then


            '********************************************************************
            'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞ調整
            '********************************************************************
            Dim inttxtSQLSizeX As Integer = Me.Size.Width - mintDifftxtSQLX
            Dim inttxtSQLSizeY As Integer = Me.Size.Height - mintDifftxtSQLY
            txtSQL.Size = New System.Drawing.Size(inttxtSQLSizeX, inttxtSQLSizeY)


        End If


    End Sub
#End Region
#Region "  取得ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 取得ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdGetDispProcess()
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名


        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG001, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        strSQL = txtSQL.Text
        mobjDb.SQL = strSQL
        strDataSetName = "TABLE"
        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)
        mobjFRM_299010.grdTableData.DataSource = objDataSet.Tables(strDataSetName)


    End Sub
#End Region
#Region "  更新ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdExecuteProcess()
        Dim strSQL As String                    'SQL文
        Dim intRetSQL As Integer                'SQL実行戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG002, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        'ﾃﾞｰﾀ更新
        '********************************************************************
        strSQL = txtSQL.Text
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "対象ﾚｺｰﾄﾞが存在しません。" & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        Else
            MsgBox(CStr(intRetSQL) & MSG003)
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call cmdGetDispProcess()


    End Sub
#End Region
    'ﾒﾆｭｰ
#Region "  Select文ｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  Select文ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelectClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL文
        Call mobjFRM_299010.MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL文
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Update文ｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Update文ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdateClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLSet As String = ""            'SQL文
        Call mobjFRM_299010.MakeSQLSet(strSQLSet, 5)


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""          'SQL文
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        strSQL = ""
        strSQL &= vbCrLf & " UPDATE "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " SET "
        strSQL &= vbCrLf & strSQLSet
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Insert文ｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insert文ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsertClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL文
        Call mobjFRM_299010.MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLValue As String = ""          'SQL文
        Call mobjFRM_299010.MakeSQLValue(strSQLValue, 5)


        '********************************************************************
        'SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        strSQL = ""
        strSQL &= vbCrLf & " INSERT INTO "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf & "    VALUES"
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLValue
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  Delete文ｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Delete文ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDeleteClickProcess()
        Dim strTableName As String = mobjFRM_299010.cboTableName.SelectedValue


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL文
        Call mobjFRM_299010.MakeSQLWhere(strSQLWhere, 5)


        '********************************************************************
        'SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        strSQL = ""
        strSQL &= vbCrLf & " DELETE "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        txtSQL.Text &= strSQL


    End Sub
#End Region
#Region "  取得ｸﾘｯｸ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 取得ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmGetDispClickProcess()


        '********************************************************************
        '取得処理
        '********************************************************************
        Call cmdGetDispProcess()


    End Sub
#End Region
#Region "  更新ｸﾘｯｸ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 更新ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmExecuteClickProcess()


        '********************************************************************
        '更新処理
        '********************************************************************
        Call cmdExecuteProcess()


    End Sub
#End Region
    '内部関数
#Region "　ｴﾗｰ処理                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴｸｾﾌﾟｼｮﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            Call gobjComFuncFRM.ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region


End Class