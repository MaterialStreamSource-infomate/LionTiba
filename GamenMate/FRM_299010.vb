'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】DBﾒﾝﾃﾅﾝｽﾂｰﾙ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299010

#Region "　共通変数　                               "

    '================================================
    '変数
    '================================================
    'ｸﾗｽ
    Private mobjDb As clsConn                           'DB接続
    Private Shared mobjInstanceFRM_299011 As FRM_299011 'SQL文実行画面

    'ﾃｰﾌﾞﾙﾃﾞｰﾀ変更ｲﾍﾞﾝﾄ用
    Private mintCurrentCellRow As Integer           '現在選択行位置
    Private mintCurrentCellCol As Integer           '現在選択列位置
    Private mintBeforeCellRow As Integer            '前回選択行位置
    Private mintBeforeCellCol As Integer            '前回選択列位置
    Private mblnCellValueChange As Boolean          'ｾﾙ値変更ﾌﾗｸﾞ
    Private mblnRowInsert As Boolean                '行追加ﾌﾗｸﾞ

    '画面ｻｲｽﾞ変更用
    Private mintDiffgrdColumnDataX As Integer       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞX軸差分
    Private mintDiffgrdColumnDataY As Integer       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞY軸差分
    Private mintDiffgrdTableDataX As Integer        'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞX軸差分
    Private mintDiffgrdTableDataY As Integer        'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞY軸差分
    Private mintgrdColumnDataWidth As Integer       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅
    Private mintgrdTableDataWidth As Integer        'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅

    'ﾄﾗﾝｻﾞｸｼｮﾝ用
    Private Const TRANS_NOTRANS As String = "自動ｺﾐｯﾄ中"
    Private Const TRANS_BEGINTRANS As String = "ﾄﾗﾝｻﾞｸｼｮﾝ" & vbCrLf & "開始中"
    Private TRANS_COLOR_NOTRANS As Color = Color.Red                '自動ｺﾐｯﾄ中
    Private TRANS_COLOR_BEGINTRANS As Color = Color.LightBlue       'ﾄﾗﾝｻﾞｸｼｮﾝ開始中

    'その他
    Private mblnFormLoad As Boolean                     'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ
    Private Const CBOTABLENAME_LENGTH As Integer = 20   'ﾃｰﾌﾞﾙ名の長さ

    '================================================
    '定数
    '================================================
    'ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const COL_DATA_TYPE_VARCHAR2 As String = "VARCHAR2"
    Private Const COL_DATA_TYPE_NUMBER As String = "NUMBER"
    Private Const COL_DATA_TYPE_DATE As String = "DATE"

    'ﾒｯｾｰｼﾞ
    Private Const MSG001 As String = "選択したﾚｺｰﾄﾞを追加してもよろしいですか？"
    Private Const MSG002 As String = "選択したﾚｺｰﾄﾞを更新してもよろしいですか？"
    Private Const MSG003 As String = "選択したﾚｺｰﾄﾞを削除してもよろしいですか？"
    Private Const MSG011 As String = "ﾚｺｰﾄﾞが追加されました。追加を実行してもよろしいですか？"
    Private Const MSG012 As String = "ﾚｺｰﾄﾞが更新されました。更新を実行してもよろしいですか？"
    Private Const MSG013 As String = "ﾚｺｰﾄﾞが削除されました。削除を実行してもよろしいですか？"
    Private Const MSG101 As String = "ﾄﾗﾝｻﾞｸｼｮﾝを開始してもよろしいですか？"
    Private Const MSG102 As String = "ﾛｰﾙﾊﾞｯｸしてもよろしいですか？"
    Private Const MSG103 As String = "ｺﾐｯﾄしてもよろしいですか？"

    'その他
    Private Const CONSTRAINT_TYPE_PK As String = "P"    'ﾌﾟﾗｲﾏﾘｰｷｰ判定
    Private Const GRID_MAXCOUNT As Integer = 10000      'ｸﾞﾘｯﾄﾞ表示件数(これ以上のﾚｺｰﾄﾞを表示する場合はﾒｯｾｰｼﾞﾎﾞｯｸｽを出力する)
    Private Const SQL_COMMENT_POSITION As Integer = 35          'SQL文ｺﾒﾝﾄ開始位置
    Private Const SQL_USER_INPUT_PLACE As String = "@@@@"       'ﾕｰｻﾞｰ定義部分


    '================================================
    '列挙体
    '================================================
    ''' <summary>ｿｹｯﾄﾃﾞｰﾀｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        COLUMN_NAME         '列名
        DATA_TYPE           'ﾀｲﾌﾟ
        COMMENTS            'ｺﾒﾝﾄ
        PK                  'ﾌﾟﾗｲﾏﾘｰｷｰ
        Data04              'ﾃﾞｰﾀ4(空)
        Data05              'ﾃﾞｰﾀ5(空)
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '********************************************************************
    'ただ一つのﾌｫｰﾑにｱｸｾｽする為のﾌﾟﾛﾊﾟﾃｨ
    '********************************************************************
    Private Shared ReadOnly Property objFRM_299011() As FRM_299011
        Get
            'ﾌｫｰﾑがnullまたは破棄されているときは、新しくｲﾝｽﾀﾝｽを作成する
            If mobjInstanceFRM_299011 Is Nothing OrElse mobjInstanceFRM_299011.IsDisposed Then
                mobjInstanceFRM_299011 = New FRM_299011
            End If
            Return mobjInstanceFRM_299011
        End Get
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
    Private Sub FRM_299010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mblnFormLoad = True     'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ
        Try
            Call FormLoad()
        Catch ex As Exception
            ComError(ex)
        Finally
            mblnFormLoad = False    'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ
        End Try
    End Sub
#End Region
#Region "  表示ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisp.Click
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  印字ﾎﾞﾀﾝｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印字ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try
            Call cmdPrintProcess()
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
    Private Sub FRM_299010_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            Call FormSizeChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkgrdColumnDataVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkgrdColumnDataVisible.CheckedChanged
        Try
            Call chkgrdColumnDataVisibleCheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ変更"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTableName.SelectedIndexChanged
        Try
            Call cboTableName_SelectedIndexChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    'ﾒﾆｭｰ
#Region "  SQL文実行画面ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文実行画面ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSQL.Click
        Try
            Call tsmSQLClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ更新ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ更新ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDataUpdate_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmDataUpdate.DropDownOpened
        Try
            Call tsmDataUpdateDropDownOpenedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  Selectｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Selectｸﾘｯｸ
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
#Region "  Insertｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insertｸﾘｯｸ
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
#Region "  Updateｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Updateｸﾘｯｸ
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
#Region "  Deleteｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Deleteｸﾘｯｸ
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
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝ開始ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝ開始ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmBeginTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBeginTrans.Click
        Try
            Call tsmBeginTransClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾛｰﾙﾊﾞｯｸｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｰﾙﾊﾞｯｸｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRollBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRollBack.Click
        Try
            Call tsmRollBackClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ｺﾐｯﾄｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾐｯﾄｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCommit.Click
        Try
            Call tsmCommitClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    'ﾃﾞｰﾀｸﾞﾘｯﾄﾞｲﾍﾞﾝﾄ
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ選択変更ｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTableData.SelectionChanged
        Try
            Call grdTableDataSelectionChangedProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ編集終了ｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ編集終了ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles grdTableData.CellParsing
        Try
            Call grdTableDataCellParsingProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ新しい行追加ｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ新しい行追加ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdTableData.UserAddedRow
        Try
            Call grdTableDataUserAddedRowProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ行削除ｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ行削除直前
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdTableData.UserDeletingRow
        Try
            Call grdTableDataUserDeletingRowProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ行削除直後
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdTableData.UserDeletedRow
        Try
            Call cmdDispProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region

    '外部公開関数
#Region "　SQL文用文字列取得                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文用文字列取得
    ''' </summary>
    ''' <param name="strData">ﾃﾞｰﾀ</param>
    ''' <param name="strDataType">ﾃﾞｰﾀﾀｲﾌﾟ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetStringSQLData(ByVal strData As String _
                                   , ByVal strDataType As String _
                                    ) As String
        Dim strReturn As String     '戻り値


        Select Case strDataType
            Case COL_DATA_TYPE_VARCHAR2
                '(文字型の場合)
                strReturn = "'" & strData & "'"
            Case COL_DATA_TYPE_NUMBER
                '(数値型の場合)
                strReturn = strData
            Case COL_DATA_TYPE_DATE
                '(日付型の場合)
                strReturn = "TO_DATE('" & strData & "','YYYY/MM/DD HH24:MI:SS')"
            Case Else
                Throw New Exception("不明な型を検出しました。")
        End Select


        Return (strReturn)
    End Function
#End Region
#Region "　SQL文 列名部分作成                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文 列名部分作成
    ''' </summary>
    ''' <param name="strSQL">作成されるSQL文</param>
    ''' <param name="intSpace">頭に付加するｽﾍﾟｰｽの数</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLColumnData(ByRef strSQL As String _
                               , ByVal intSpace As Integer _
                                )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)


            '********************************************************************
            '一行だけ作成
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    'ｽﾍﾟｰｽ詰め
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     'ｺﾒﾝﾄ


            '********************************************************************
            '全体と結合
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '不要文字削除
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "", 1, 1)
                strSQL = Replace(strSQL, ",", " ", 1, 1)
            End If


        Next


    End Sub
#End Region
#Region "　SQL文 Where句部分作成                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文 Where句部分作成
    ''' </summary>
    ''' <param name="strSQL">作成されるSQL文</param>
    ''' <param name="intSpace">頭に付加するｽﾍﾟｰｽの数</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLWhere(ByRef strSQL As String _
                          , ByVal intSpace As Integer _
                            )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)


            '********************************************************************
            '一行だけ作成
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & "AND "
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            strTemp &= " = "
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    'ｽﾍﾟｰｽ詰め
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     'ｺﾒﾝﾄ


            '********************************************************************
            '全体と結合
            '********************************************************************
            strSQL &= vbCrLf & strTemp


        Next


    End Sub
#End Region
#Region "　SQL文 Set句部分作成                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文 Set句部分作成
    ''' </summary>
    ''' <param name="strSQL">作成されるSQL文</param>
    ''' <param name="intSpace">頭に付加するｽﾍﾟｰｽの数</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLSet(ByRef strSQL As String _
                        , ByVal intSpace As Integer _
                          )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)


            '********************************************************************
            '一行だけ作成
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= grdColumnData.Item(FRM_299010.menmListCol.COLUMN_NAME, ii).Value
            strTemp &= " = "
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    'ｽﾍﾟｰｽ詰め
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     'ｺﾒﾝﾄ


            '********************************************************************
            '全体と結合
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '不要文字削除
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "")
                strSQL = Replace(strSQL, ",", " ")
            End If


        Next


    End Sub
#End Region
#Region "　SQL文 ﾃﾞｰﾀ部分作成                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文 ﾃﾞｰﾀ部分作成 
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="intSpace"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MakeSQLValue(ByRef strSQL As String _
                          , ByVal intSpace As Integer _
                            )


        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)


            '********************************************************************
            '一行だけ作成
            '********************************************************************
            Dim strTemp As String = ""
            strTemp &= Space(intSpace) & ","
            strTemp &= GetStringSQLData(SQL_USER_INPUT_PLACE, grdColumnData.Item(FRM_299010.menmListCol.DATA_TYPE, ii).Value)
            If GET_BYTE_LENGTH_STRING(strTemp) <= SQL_COMMENT_POSITION Then
                strTemp = SPC_PAD(strTemp, SQL_COMMENT_POSITION)    'ｽﾍﾟｰｽ詰め
            End If
            strTemp &= " --" & grdColumnData.Item(FRM_299010.menmListCol.COMMENTS, ii).Value     'ｺﾒﾝﾄ


            '********************************************************************
            '全体と結合
            '********************************************************************
            strSQL &= vbCrLf & strTemp


            '********************************************************************
            '不要文字削除
            '********************************************************************
            If ii = 0 Then
                strSQL = Replace(strSQL, vbCrLf, "")
                strSQL = Replace(strSQL, ",", " ")
            End If


        Next


    End Sub
#End Region


    'ｲﾍﾞﾝﾄ処理
#Region "     ﾌｫｰﾑﾛｰﾄﾞ処理                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim aryData As ArrayList = New ArrayList


        '**************************************************************************
        ' ｵﾗｸﾙ接続
        '**************************************************************************
        '==========================================
        'Config取得
        '==========================================
        Dim objSystem As clsConnectConfig
        objSystem = New clsConnectConfig(CONFIG_FILE)                ' Configﾌｧｲﾙ接続ｸﾗｽ（画面用Config）

        '==========================================
        'DB接続
        '==========================================
        mobjDb = gobjDb
        '' ''Dim blnRet As Boolean
        '' ''mobjDb = New clsConn
        '' ''mobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        '' ''blnRet = mobjDb.Connect()     '接続
        '' ''If blnRet = False Then
        '' ''    Throw New Exception("DB接続に失敗しました。")
        '' ''End If


        '********************************************************************
        '初期化
        '********************************************************************
        mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
        mblnRowInsert = False               '行追加ﾌﾗｸﾞ
        txtTitle.Text = "FRM_"

        '********************************************************************
        'ﾃﾞｰﾀ取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    USER_TABLES.TABLE_NAME"
        strSQL &= vbCrLf & "   ,USER_TAB_COMMENTS.COMMENTS"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    USER_TABLES"
        strSQL &= vbCrLf & "   ,USER_TAB_COMMENTS"
        strSQL &= vbCrLf & " WHERE  1 = 1"
        strSQL &= vbCrLf & "    AND USER_TABLES.TABLE_NAME = USER_TAB_COMMENTS.TABLE_NAME"
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "    USER_TABLES.TABLE_NAME"
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName = "USER_TABLES"
        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(ﾃﾞｰﾀが取得出来た場合)
            For ii As Integer = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ﾙｰﾌﾟ:取得ﾃﾞｰﾀ数)

                Dim strComboDisp As String = ""         'ｺﾝﾎﾞﾎﾞｯｸｽ表示用文字列
                Dim strTableName As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("TABLE_NAME"))        'ﾃｰﾌﾞﾙ名
                Dim strTableComment As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("COMMENTS"))       'ﾃｰﾌﾞﾙ名ｺﾒﾝﾄ
                strComboDisp &= SPC_PAD(strTableName, CBOTABLENAME_LENGTH)
                strComboDisp &= strTableComment
                aryData.Add(New GamenCommon.clsCboData(strComboDisp, strTableName))
            Next
        Else
            Throw New Exception("ﾃｰﾌﾞﾙが見つかりません。")
        End If
        cboTableName.DisplayMember = GamenCommon.clsCboData.DISPLAYMEMBER
        cboTableName.ValueMember = GamenCommon.clsCboData.VALUEMEMBER
        cboTableName.DataSource = aryData
        cboTableName.SelectedIndex = 0


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ差分を取得
        '********************************************************************
        mintDiffgrdColumnDataX = Me.Size.Width - grdColumnData.Location.X       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞX軸差分
        mintDiffgrdColumnDataY = Me.Size.Height - grdColumnData.Size.Height     '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞY軸差分
        mintDiffgrdTableDataX = Me.Size.Width - grdTableData.Size.Width         'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞX軸差分
        mintDiffgrdTableDataY = Me.Size.Height - grdTableData.Size.Height       'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞY軸差分
        mintgrdColumnDataWidth = grdColumnData.Size.Width                       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅
        mintgrdTableDataWidth = grdTableData.Size.Width                         'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅


        '********************************************************************
        '色々初期化
        '********************************************************************
        chkgrdColumnDataVisible.Checked = False                 '列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ
        Call chkgrdColumnDataVisibleCheckedChangedProcess()     '列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ
        Call tsmBeginTransClickProcess()                        'ﾄﾗﾝｻﾞｸｼｮﾝ開始


    End Sub
#End Region
#Region "  表示ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdDispProcess()
        Dim strSQL As String                    'SQL文
        Dim objDataSet01 As New DataSet         'ﾃﾞｰﾀｾｯﾄ
        Dim objDataSet02 As New DataSet         'ﾃﾞｰﾀｾｯﾄ
        Dim objDataSetGrid As New DataSet       'ﾃﾞｰﾀｾｯﾄ(ｸﾞﾘｯﾄﾞ表示用)
        Dim strDataSetName01 As String          'ﾃﾞｰﾀｾｯﾄ名
        Dim strTableName As String = cboTableName.SelectedValue



        '********************************************************************
        'ﾃﾞｰﾀ件数取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    COUNT(*) "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "COUNT"
        objDataSet02.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSet02)
        If objDataSet02.Tables(strDataSetName01).Rows.Count > 0 Then
            '(ﾃﾞｰﾀが取得出来た場合)
            If GRID_MAXCOUNT < TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0)) Then
                '(ﾃﾞｰﾀ件数が多すぎた場合)

                Dim strMsg As String = ""
                strMsg = "ﾃﾞｰﾀ件数が" & GRID_MAXCOUNT & "件を超えています。"
                strMsg &= vbCrLf & "ｸﾞﾘｯﾄﾞに表示しようとすると、非常に時間がかかります。"
                strMsg &= vbCrLf & "続行しますか？。"
                If MsgBox(strMsg, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                    Throw New Exception("ﾃﾞｰﾀ表示をｷｬﾝｾﾙしました。")
                End If
            End If
        Else
            Throw New Exception("ﾃｰﾌﾞﾙのﾃﾞｰﾀ件数が取得出来ません。")
        End If


        '********************************************************************
        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示(列ﾃﾞｰﾀ)
        '********************************************************************
        Call grdColumnDataDisplay(strTableName)


        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL文
        Call MakeSQLColumnData(strSQLColumnData, 5)


        '********************************************************************
        'ﾃﾞｰﾀ取得(ﾃﾞｰﾀ表示用)
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSetGrid.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSetGrid)
        grdTableData.DataSource = objDataSetGrid.Tables(strDataSetName01)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdTableDataSetup()


    End Sub
#End Region
#Region "  印字ﾎﾞﾀﾝｸﾘｯｸ処理                         "
    Private Sub cmdPrintProcess()


        '********************************************************************
        'ﾍｯﾀﾞｰ部分作成
        '********************************************************************
        Dim strColTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_020)
        Dim strRowTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_021)
        Dim strTableName As String = ""     'ﾃｰﾌﾞﾙ名
        Dim strText01 As String = ""        'ﾍｯﾀﾞｰﾃｷｽﾄ01
        Dim strText05 As String = ""        'ﾍｯﾀﾞｰﾃｷｽﾄ05
        Dim strText06 As String = ""        'ﾍｯﾀﾞｰﾃｷｽﾄ06
        Dim strText07 As String = ""        'ﾍｯﾀﾞｰﾃｷｽﾄ07
        Dim strHeader As String = ""        'ﾍｯﾀﾞｰﾃｷｽﾄ

        '===================================
        'ﾍｯﾀﾞｰﾃｷｽﾄ作成01
        '===================================
        strText01 = MID_SJIS(cboTableName.Text, CBOTABLENAME_LENGTH + 1)
        strTableName = MID_SJIS(cboTableName.Text, 1, CBOTABLENAME_LENGTH)
        strTableName = Trim(strTableName)

        '===================================
        'ﾍｯﾀﾞｰﾃｷｽﾄ作成02
        '===================================
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)
            If ii <> 0 Then strHeader &= strColTerminator
            strHeader &= """" & grdColumnData.Item(menmListCol.COMMENTS, ii).Value & """"
        Next
        strHeader &= strRowTerminator
        strHeader = Replace(strHeader, vbCrLf, "")
        'ﾍｯﾀﾞｰﾃｷｽﾄ分割
        Dim strHeaderArray() As String = Nothing
        Call gobjComFuncFRM.DivStringToArray(strHeader, strHeaderArray)
        If IsNothing(strHeaderArray) = False Then
            If 0 <= UBound(strHeaderArray) Then strText05 = strHeaderArray(0)
            If 1 <= UBound(strHeaderArray) Then strText06 = strHeaderArray(1)
            If 2 <= UBound(strHeaderArray) Then strText07 = strHeaderArray(2)
        End If


        '********************************************************************
        '印字
        '********************************************************************
        Call gobjComFuncFRM.CRPrintKaihatu(grdTableData, strTableName, strText01, "", strText05, strText06, strText07, txtTitle.Text)


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


        If mintDiffgrdColumnDataX <> 0 Then


            '********************************************************************
            '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞ調整
            '********************************************************************
            Dim intgrdColumnDataLocationX As Integer = Me.Size.Width - mintDiffgrdColumnDataX
            Dim intgrdColumnDataSizeY As Integer = Me.Size.Height - mintDiffgrdColumnDataY
            grdColumnData.Location = New System.Drawing.Point(intgrdColumnDataLocationX, grdColumnData.Location.Y)
            grdColumnData.Size = New System.Drawing.Size(grdColumnData.Size.Width, intgrdColumnDataSizeY)


            '********************************************************************
            'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞ調整
            '********************************************************************
            Dim intgrdTableDataSizeX As Integer = Me.Size.Width - mintDiffgrdTableDataX
            Dim intgrdTableDataSizeY As Integer = Me.Size.Height - mintDiffgrdTableDataY
            If grdColumnData.Visible = False Then intgrdTableDataSizeX += mintgrdColumnDataWidth
            grdTableData.Size = New System.Drawing.Size(intgrdTableDataSizeX, intgrdTableDataSizeY)


        End If
        mintgrdColumnDataWidth = grdColumnData.Size.Width                       '列ﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅
        mintgrdTableDataWidth = grdTableData.Size.Width                         'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期幅


    End Sub
#End Region
#Region "  列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ変更処理              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列ﾃﾞｰﾀ表示ﾁｪｯｸﾎﾞｯｸｽ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkgrdColumnDataVisibleCheckedChangedProcess()

        grdColumnData.Visible = chkgrdColumnDataVisible.Checked
        If grdColumnData.Visible = True Then
            '(表示の場合)
            grdTableData.Size = New System.Drawing.Size(mintgrdTableDataWidth, grdTableData.Size.Height)
        Else
            '(非表示の場合)
            grdTableData.Size = New System.Drawing.Size(mintgrdTableDataWidth + mintgrdColumnDataWidth, grdTableData.Size.Height)
        End If


    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ変更処理               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChangedProcess()


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ初期化
        '********************************************************************
        grdTableData.DataSource = Nothing
        grdColumnData.DataSource = Nothing


        '********************************************************************
        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示(列ﾃﾞｰﾀ)
        '********************************************************************
        Call grdColumnDataDisplay(cboTableName.SelectedValue)


    End Sub
#End Region
    'ﾒﾆｭｰﾊﾞｰｲﾍﾞﾝﾄ
#Region "  SQL文実行画面ｸﾘｯｸ処理                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQL文実行画面ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSQLClickProcess()


        '********************************************************************
        'ﾌｫｰﾑ表示
        '********************************************************************
        objFRM_299011.objDb = mobjDb                'DB接続
        objFRM_299011.objFRM_299010 = Me            'DBﾒﾝﾃﾅﾝｽﾂｰﾙ
        objFRM_299011.Location = Me.Location        '位置を合わせる
        objFRM_299011.Show()                        '表示
        objFRM_299011.TopMost = True                '常に手前に設定(一回手前に持って来る)
        objFRM_299011.TopMost = False               '常に手前に設定解除


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ更新ｸﾘｯｸ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ更新ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDataUpdateDropDownOpenedProcess()


        '********************************************************************
        'ﾃﾞｰﾀ更新
        '********************************************************************
        Select Case lblTrans.Text
            Case TRANS_NOTRANS
                '(自動ｺﾐｯﾄ中)
                tsmBeginTrans.Enabled = True      'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                tsmRollBack.Enabled = False       'ﾛｰﾙﾊﾞｯｸ
                tsmCommit.Enabled = False         'ｺﾐｯﾄ
            Case TRANS_BEGINTRANS
                '(ﾄﾗﾝｻﾞｸｼｮﾝ開始中)
                tsmBeginTrans.Enabled = False     'ﾄﾗﾝｻﾞｸｼｮﾝ開始
                tsmRollBack.Enabled = True        'ﾛｰﾙﾊﾞｯｸ
                tsmCommit.Enabled = True          'ｺﾐｯﾄ
        End Select


    End Sub
#End Region
#Region "  Selectｸﾘｯｸ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Selectｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmSelectClickProcess()


        '********************************************************************
        '表示ﾎﾞﾀﾝｸﾘｯｸ処理
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Insertｸﾘｯｸ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Insertｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmInsertClickProcess()

        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG001, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '追加処理
        '********************************************************************
        Call DataInsert(grdTableData.CurrentCell.RowIndex)


        '********************************************************************
        '画面更新
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Updateｸﾘｯｸ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Updateｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmUpdateClickProcess()

        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG002, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        '追加処理
        '********************************************************************
        Call DataUpdate(grdTableData.CurrentCell.RowIndex)


        '********************************************************************
        '画面更新
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Deleteｸﾘｯｸ処理                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Deleteｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDeleteClickProcess()


        Call grdTableDataUserDeletingRowProcess()


        ' '' ''********************************************************************
        ' '' ''確認画面
        ' '' ''********************************************************************
        '' ''If MsgBox(MSG003, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
        '' ''    Exit Sub
        '' ''End If


        ' '' ''********************************************************************
        ' '' ''追加処理
        ' '' ''********************************************************************
        '' ''Call DataDelete(grdTableData.CurrentCell.RowIndex)


        ' '' ''********************************************************************
        ' '' ''画面更新
        ' '' ''********************************************************************
        '' ''Call cmdDispProcess()


    End Sub
#End Region
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝ開始ｸﾘｯｸ                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝ開始ｸﾘｯｸ 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmBeginTransClickProcess()


        '********************************************************************
        '確認画面
        '********************************************************************
        If mblnFormLoad = False Then
            '(ﾌｫｰﾑﾛｰﾄﾞ以外の場合)
            If MsgBox(MSG101, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If


        '********************************************************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '********************************************************************
        Try
            mobjDb.BeginTrans()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Call lblTransUpdate(TRANS_BEGINTRANS)           'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


    End Sub
#End Region
#Region "  ﾛｰﾙﾊﾞｯｸ開始ｸﾘｯｸ                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｰﾙﾊﾞｯｸ開始ｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRollBackClickProcess()


        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG102, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '********************************************************************
        Try
            mobjDb.RollBack()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


        '********************************************************************
        '画面更新
        '********************************************************************
        Call cmdDispProcess()


        '********************************************************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '********************************************************************
        Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  ｺﾐｯﾄ開始ｸﾘｯｸ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾐｯﾄ開始ｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmCommitClickProcess()


        '********************************************************************
        '確認画面
        '********************************************************************
        If MsgBox(MSG103, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '********************************************************************
        Try
            mobjDb.Commit()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


        '********************************************************************
        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        '********************************************************************
        Call tsmBeginTransClickProcess()


    End Sub
#End Region

    '内部関数
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示(列ﾃﾞｰﾀ)                   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示(列ﾃﾞｰﾀ)
    ''' </summary>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub grdColumnDataDisplay(ByVal strTableName As String)
        Dim strSQL As String                    'SQL文
        Dim objDataSet01 As New DataSet         'ﾃﾞｰﾀｾｯﾄ
        Dim objDataSet02 As New DataSet         'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName01 As String          'ﾃﾞｰﾀｾｯﾄ名
        Dim strDataSetName02 As String          'ﾃﾞｰﾀｾｯﾄ名


        '********************************************************************
        'ﾃﾞｰﾀ取得(列名取得用)
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    USER_TAB_COLUMNS "
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "    AND TABLE_NAME = '" & strTableName & "'"
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    COLUMN_ID "
        strSQL &= vbCrLf
        mobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSet01.Clear()
        mobjDb.GetDataSet(strDataSetName01, objDataSet01)


        '********************************************************************
        '行ﾃﾞｰﾀ取得
        '********************************************************************
        If objDataSet01.Tables(strDataSetName01).Rows.Count > 0 Then
            Dim objDataTable As New GamenCommon.clsGridDataTable05          'ﾃﾞｰﾀﾃｰﾌﾞﾙ
            For ii As Integer = 0 To objDataSet01.Tables(strDataSetName01).Rows.Count - 1
                '(ﾙｰﾌﾟ:ﾃﾞｰﾀ件数)

                Dim strColumnName As String = TO_STRING(objDataSet01.Tables(strDataSetName01).Rows(ii)("COLUMN_NAME"))   '列名
                Dim strBindField(1) As String   'ﾊﾞｲﾝﾄﾞ変数(ﾌｨｰﾙﾄﾞ名)
                Dim objBindValue(1) As Object   'ﾊﾞｲﾝﾄﾞ変数(値)


                '=====================================================
                'ﾊﾞｲﾝﾄﾞ変数定義
                '=====================================================
                Dim objParameter(1, 1) As Object
                objParameter(0, 0) = "TABLE_NAME"
                objParameter(1, 0) = strTableName
                objParameter(0, 1) = "COLUMN_NAME"
                objParameter(1, 1) = strColumnName

                '=====================================================
                '列ﾀｲﾌﾟ、ｺﾒﾝﾄ取得
                '=====================================================
                strSQL = ""
                strSQL &= vbCrLf & " SELECT"
                strSQL &= vbCrLf & "    USER_TAB_COLUMNS.COLUMN_NAME "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_TYPE "
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS.COMMENTS "
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "    USER_TAB_COLUMNS "
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS "
                strSQL &= vbCrLf & " WHERE"
                strSQL &= vbCrLf & "        1 = 1 "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.TABLE_NAME  = USER_COL_COMMENTS.TABLE_NAME "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.COLUMN_NAME = USER_COL_COMMENTS.COLUMN_NAME "
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.TABLE_NAME = :" & objParameter(0, 0) & ""
                strSQL &= vbCrLf & "    AND USER_TAB_COLUMNS.COLUMN_NAME = :" & objParameter(0, 1) & ""
                strSQL &= vbCrLf
                mobjDb.SQL = strSQL
                mobjDb.Parameter = objParameter
                strDataSetName02 = "COLUMNS"
                objDataSet02.Clear()
                mobjDb.GetDataSet(strDataSetName02, objDataSet02)
                Dim strCOLUMN_NAME As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COLUMN_NAME"))      '列名
                Dim strDATA_TYPE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_TYPE"))          'ﾀｲﾌﾟ
                Dim strCOMMENTS As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COMMENTS"))            'ｺﾒﾝﾄ

                '=====================================================
                'ﾌﾟﾗｲﾏﾘｰｷｰ取得
                '=====================================================
                Dim strPK As String = ""            'ﾌﾟﾗｲﾏﾘｰｷｰ
                strSQL = ""
                strSQL &= vbCrLf & " SELECT"
                strSQL &= vbCrLf & "     C.TABLE_NAME"
                strSQL &= vbCrLf & "    ,COL.COLUMN_NAME"
                strSQL &= vbCrLf & "    ,C.CONSTRAINT_TYPE"
                strSQL &= vbCrLf & " FROM"
                strSQL &= vbCrLf & "     USER_CONSTRAINTS C"
                strSQL &= vbCrLf & "    ,USER_CONS_COLUMNS COL"
                strSQL &= vbCrLf & " WHERE 1 = 1"
                strSQL &= vbCrLf & "   AND C.TABLE_NAME = COL.TABLE_NAME"
                strSQL &= vbCrLf & "   AND C.CONSTRAINT_NAME = COL.CONSTRAINT_NAME"
                strSQL &= vbCrLf & "   AND C.CONSTRAINT_TYPE = 'P'"
                strSQL &= vbCrLf & "   AND C.TABLE_NAME = :" & objParameter(0, 0) & ""
                strSQL &= vbCrLf & "   AND COL.COLUMN_NAME = :" & objParameter(0, 1) & ""
                strSQL &= vbCrLf
                mobjDb.SQL = strSQL
                mobjDb.Parameter = objParameter
                strDataSetName02 = "PK"
                objDataSet02.Clear()
                mobjDb.GetDataSet(strDataSetName02, objDataSet02)
                If objDataSet02.Tables(strDataSetName02).Rows.Count > 0 Then
                    strPK = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("CONSTRAINT_TYPE"))      'ﾌﾟﾗｲﾏﾘｰｷｰ
                End If

                '=====================================================
                'ﾃﾞｰﾀﾃｰﾌﾞﾙに追加
                '=====================================================
                objDataTable.userAddRowDataSet(strCOLUMN_NAME _
                                             , strDATA_TYPE _
                                             , strCOMMENTS _
                                             , strPK _
                                             )

            Next
            grdColumnData.DataSource = objDataTable
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdColumnDataSetup()


    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定(ﾃｰﾌﾞﾙﾃﾞｰﾀ)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定(ﾃｰﾌﾞﾙﾃﾞｰﾀ) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataSetup()

        '***********************
        '初期設定
        '***********************
        '' ''grdTableData.RowHeadersVisible = False                                      '行ﾍｯﾀﾞｰ表示        許可設定
        grdTableData.AllowUserToResizeRows = False                                  '行のｻｲｽﾞ変更       許可設定
        '' ''grdTableData.AllowUserToResizeColumns = False                            '列のｻｲｽﾞ変更       許可設定
        '' ''grdTableData.MultiSelect = False                                            '複数ｾﾙ同時選択     許可設定
        grdTableData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect      '選択ﾓｰﾄﾞ
        '' ''grdTableData.AllowUserToAddRows = False                                  '行追加             許可設定
        '' ''grdTableData.AllowUserToDeleteRows = False                               '行削除             許可設定
        grdTableData.AllowUserToOrderColumns = False                                '列移動             許可設定
        grdTableData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)    '列の幅自動調整


        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            Select Case grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value
                Case COL_DATA_TYPE_VARCHAR2
                    '(文字型の場合)
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_DATA_TYPE_NUMBER
                    '(数値型の場合)
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case COL_DATA_TYPE_DATE
                    '(日付型の場合)
                    grdTableData.Columns(ii).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                    grdTableData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    grdTableData.Columns(ii).Width = 115
            End Select

        Next


        '***********************
        '初期選択
        '***********************
        Try
            'ﾃﾞｰﾀが表示されない場合もある為
            grdTableData(-1, -1).Selected = True
        Catch ex As Exception
        End Try


    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定(列ﾃﾞｰﾀ)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示設定(列ﾃﾞｰﾀ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdColumnDataSetup()

        '***********************
        '初期設定
        '***********************
        grdColumnData.RowHeadersVisible = False                                   '行ﾍｯﾀﾞｰ表示        許可設定
        '' ''grdColumnData.AllowUserToResizeColumns = False                            '列のｻｲｽﾞ変更       許可設定
        grdColumnData.MultiSelect = False                                         '複数ｾﾙ同時選択     許可設定
        grdColumnData.SelectionMode = DataGridViewSelectionMode.FullRowSelect     '選択ﾓｰﾄﾞ
        grdColumnData.AllowUserToAddRows = False                                  '行追加             許可設定
        grdColumnData.AllowUserToDeleteRows = False                               '行削除             許可設定
        grdColumnData.AllowUserToResizeRows = False                               '行ｻｲｽﾞ変更         許可設定
        grdColumnData.AllowUserToOrderColumns = False                             '列移動             許可設定
        For Each objColum As DataGridViewColumn In grdColumnData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '列の並替禁止
        Next

        '***********************
        'ﾍｯﾀﾞｰ表示変更
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).HeaderText = "列名"
        grdColumnData.Columns(menmListCol.DATA_TYPE).HeaderText = "ﾀｲﾌﾟ"
        grdColumnData.Columns(menmListCol.COMMENTS).HeaderText = "ｺﾒﾝﾄ"
        grdColumnData.Columns(menmListCol.PK).HeaderText = "PK"


        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_TYPE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.COMMENTS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.PK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        '***********************
        '非表示
        '***********************
        grdColumnData.Columns(menmListCol.Data04).Visible = False
        grdColumnData.Columns(menmListCol.Data05).Visible = False


        '***********************
        '列幅調整
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).Width = 120
        grdColumnData.Columns(menmListCol.DATA_TYPE).Width = 80
        grdColumnData.Columns(menmListCol.COMMENTS).Width = 129
        grdColumnData.Columns(menmListCol.PK).Width = 20


        '***********************
        '編集ﾛｯｸ
        '***********************
        grdColumnData.ReadOnly = True


    End Sub
#End Region
#Region "　ﾚｺｰﾄﾞ追加                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾚｺｰﾄﾞ追加
    ''' </summary>
    ''' <param name="intRow">追加されるｸﾞﾘｯﾄﾞの行ｲﾝﾃﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataInsert(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL文
        Dim intRetSQL As Integer                'SQL実行戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '********************************************************************
        'ﾌﾟﾗｲﾏﾘｰｷｰﾁｪｯｸ
        '********************************************************************

        '********************************************************************
        'NotNullﾁｪｯｸ
        '********************************************************************

        '********************************************************************
        'SQL文列名部分作成
        '********************************************************************
        Dim strSQLColumnData As String = ""                    'SQL文
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            strSQLColumnData &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value
            If ii = 0 Then
                strSQLColumnData = Replace(strSQLColumnData, vbCrLf, "")
                strSQLColumnData = Replace(strSQLColumnData, ",", " ")
            End If
        Next


        '********************************************************************
        'SQL文ﾃﾞｰﾀ部分作成
        '********************************************************************
        Dim strSQLValue As String = ""                    'SQL文
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).Value)
            If strValue = "" Then
                strSQLValue &= vbCrLf & "    ,Null"
            Else
                strSQLValue &= vbCrLf & "    ," & GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

            If ii = 0 Then
                strSQLValue = Replace(strSQLValue, vbCrLf, "")
                strSQLValue = Replace(strSQLValue, ",", " ")
            End If
        Next


        '********************************************************************
        'INSERT文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " INSERT INTO "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf & "    VALUES"
        strSQL &= vbCrLf & "    ("
        strSQL &= vbCrLf & strSQLValue
        strSQL &= vbCrLf & "    )"
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "　ﾚｺｰﾄﾞ削除                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾚｺｰﾄﾞ削除
    ''' </summary>
    ''' <param name="intRow">追加されたｸﾞﾘｯﾄﾞの行ｲﾝﾃﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataDelete(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL文
        Dim intRetSQL As Integer                'SQL実行戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL文
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                '(ﾌﾟﾗｲﾏﾘｰｷｰの場合)
                strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

        Next


        '********************************************************************
        'Delete文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " DELETE "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "対象ﾚｺｰﾄﾞが存在しません。" & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "　ﾚｺｰﾄﾞ更新                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾚｺｰﾄﾞ更新
    ''' </summary>
    ''' <param name="intRow">追加されたｸﾞﾘｯﾄﾞの行ｲﾝﾃﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DataUpdate(ByVal intRow As Integer)
        Dim strSQL As String                    'SQL文
        Dim intRetSQL As Integer                'SQL実行戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ


        '********************************************************************
        'SQL文Set句部分作成
        '********************************************************************
        Dim strSQLSet As String = ""                    'SQL文
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).Value)
            If strValue = "" Then
                strSQLSet &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = Null"
            Else
                strSQLSet &= vbCrLf & "    ," & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLSet &= GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If


            If ii = 0 Then
                strSQLSet = Replace(strSQLSet, vbCrLf, "")
                strSQLSet = Replace(strSQLSet, ",", " ")
            End If

        Next


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL文
        For ii As Integer = 0 To grdColumnData.RowCount - 1
            '(ﾙｰﾌﾟ:列数)

            If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                '(ﾌﾟﾗｲﾏﾘｰｷｰの場合)
                strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

        Next


        '********************************************************************
        'Update文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " UPDATE "
        strSQL &= vbCrLf & "    " & cboTableName.SelectedValue
        strSQL &= vbCrLf & " SET "
        strSQL &= vbCrLf & strSQLSet
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = mobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & mobjDb.ErrMsg & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        ElseIf intRetSQL = 0 Then
            strMsg = "対象ﾚｺｰﾄﾞが存在しません。" & "【" & strSQL & "】"
            Throw New Exception(strMsg)
        End If


    End Sub
#End Region
#Region "　ﾄﾗﾝｻﾞｸｼｮﾝ状態ﾗﾍﾞﾙ更新                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝ状態ﾗﾍﾞﾙ更新
    ''' </summary>
    ''' <param name="strText">ﾗﾍﾞﾙを更新するﾃｷｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblTransUpdate(ByVal strText As String)


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Select Case strText
            Case TRANS_NOTRANS
                lblTrans.BackColor = TRANS_COLOR_NOTRANS
            Case TRANS_BEGINTRANS
                lblTrans.BackColor = TRANS_COLOR_BEGINTRANS
        End Select
        lblTrans.Text = strText


        '********************************************************************
        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ更新
        '********************************************************************
        Call tsmDataUpdateDropDownOpenedProcess()


    End Sub
#End Region
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

    'ﾃﾞｰﾀｸﾞﾘｯﾄﾞｲﾍﾞﾝﾄ処理
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ選択変更ｲﾍﾞﾝﾄ処理              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ選択変更ｲﾍﾞﾝﾄ処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataSelectionChangedProcess()


        '********************************************************************
        '事前ﾁｪｯｸ
        '********************************************************************
        If IsNull(grdTableData.CurrentCell) = True Then
            '(ﾍｯﾀﾞｰを選択された場合とか)
            Exit Sub
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ選択情報記憶
        '********************************************************************
        mintBeforeCellRow = mintCurrentCellRow                              '前回選択行位置
        mintBeforeCellCol = mintCurrentCellCol                              '前回選択列位置
        mintCurrentCellRow = grdTableData.CurrentCell.RowIndex              '現在選択行位置
        mintCurrentCellCol = grdTableData.CurrentCell.ColumnIndex           '現在選択列位置


        '********************************************************************
        '分岐処理
        '********************************************************************
        If mintBeforeCellRow = mintCurrentCellRow Then
            '(行選択が変わっていない場合)
            Exit Sub
        End If
        If mblnRowInsert = True Then
            '(行が追加されていた場合)

            '========================================================
            '確認画面
            '========================================================
            If MsgBox(MSG011, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            '========================================================
            '追加処理
            '========================================================
            Try
                Call DataInsert(mintBeforeCellRow)
            Catch ex As Exception
                ComError(ex)
            End Try
            mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
            mblnRowInsert = False               '行追加ﾌﾗｸﾞ

            '========================================================
            '画面更新
            '========================================================
            Call cmdDispProcess()

        ElseIf mblnCellValueChange = True Then
            '(値が更新されていた場合)

            '========================================================
            '確認画面
            '========================================================
            If MsgBox(MSG012, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            '========================================================
            '更新処理
            '========================================================
            Try
                Call DataUpdate(mintBeforeCellRow)
            Catch ex As Exception
                ComError(ex)
            End Try
            mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
            mblnRowInsert = False               '行追加ﾌﾗｸﾞ

            '========================================================
            '画面更新
            '========================================================
            Call cmdDispProcess()

        End If


    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ編集終了ｲﾍﾞﾝﾄ処理              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ編集終了ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataCellParsingProcess()


        '********************************************************************
        'ﾌﾗｸﾞON
        '********************************************************************
        mblnCellValueChange = True          'ｾﾙ値変更ﾌﾗｸﾞ


    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾞﾘｯﾄﾞ新しい行追加ｲﾍﾞﾝﾄ処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ新しい行追加ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataUserAddedRowProcess()


        '********************************************************************
        'ﾌﾗｸﾞON
        '********************************************************************
        mblnRowInsert = True


    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞ行削除ｲﾍﾞﾝﾄ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞ行削除ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableDataUserDeletingRowProcess()


        '========================================================
        '確認画面
        '========================================================
        If MsgBox(MSG013, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If

        '========================================================
        '削除処理
        '========================================================
        Try

            For ii As Integer = 0 To grdTableData.RowCount - 1
                '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

                If grdTableData.Rows(ii).Selected = True Then
                    Call DataDelete(ii)
                End If

                '' ''Call DataDelete(grdTableData.CurrentCell.RowIndex)
            Next

        Catch ex As Exception
            ComError(ex)
        End Try
        mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
        mblnRowInsert = False               '行追加ﾌﾗｸﾞ

        ' '' ''========================================================
        ' '' ''画面更新
        ' '' ''========================================================
        '' ''Call cmdDispProcess()


    End Sub
#End Region


End Class