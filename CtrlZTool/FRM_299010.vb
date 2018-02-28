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
Imports CtrlZTool.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299010

#Region "　共通変数　                               "

    '================================================
    '変数
    '================================================
    'ｸﾗｽ
    Private Shared mobjInstanceFRM_299011 As FRM_299011 'SQL文実行画面

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrDispTableName As String                  '初期表示するﾃｰﾌﾞﾙ名

    'ﾃｰﾌﾞﾙﾃﾞｰﾀ変更ｲﾍﾞﾝﾄ用
    Private mintCurrentCellRow As Integer           '現在選択行位置
    Private mintCurrentCellCol As Integer           '現在選択列位置
    Private mintBeforeCellRow As Integer            '前回選択行位置
    Private mintBeforeCellCol As Integer            '前回選択列位置
    Private mblnCellValueChange As Boolean          'ｾﾙ値変更ﾌﾗｸﾞ
    Private mblnRowInsert As Boolean                '行追加ﾌﾗｸﾞ
    Private mstrSQLFilterWhere As String            'ﾌｨﾙﾀｰ用SQL文Where句
    Private mstrSQLFilterOrder As String            'ﾌｨﾙﾀｰ用SQL文OrderBy句
    Private mstrSQLFilterAryOrder(0) As String      'ﾌｨﾙﾀｰ用SQL文OrderBy句  (配列)
    Private mstrSQLUpdateWhere As String            'Update用SQL文Where句

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
    Private mblnFormClose As Boolean                    'ﾌｫｰﾑｸﾛｰｽﾞﾌﾗｸﾞ(ﾌﾟﾛｸﾞﾗﾑ開始時に複数ﾌｫｰﾑ表示させるようにしたら、一枚目のﾌｫｰﾑが残ってしまい見っとも無くなったから追加)
    Private mobjAryLogDispConfig() As strcLogDispConfig 'ﾛｸﾞﾃｰﾌﾞﾙ表示定義


    '================================================
    '定数
    '================================================
    'ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const COL_DATA_TYPE_VARCHAR2 As String = "VARCHAR2"
    Private Const COL_DATA_TYPE_NUMBER As String = "NUMBER"
    Private Const COL_DATA_TYPE_DATE As String = "DATE"

    '並び順
    Private Const ORDER_BY_ASC As String = " ASC"       '昇順
    Private Const ORDER_BY_DESC As String = " DESC"     '降順

    'ﾒｯｾｰｼﾞ
    Private Const MSG001 As String = "選択したﾚｺｰﾄﾞを追加してもよろしいですか？"
    Private Const MSG002 As String = "選択したﾚｺｰﾄﾞを更新してもよろしいですか？"
    Private Const MSG003 As String = "選択したﾚｺｰﾄﾞを削除してもよろしいですか？"
    Private Const MSG011 As String = "ﾚｺｰﾄﾞが追加されました。追加を実行してもよろしいですか？"
    Private Const MSG012 As String = "ﾚｺｰﾄﾞが更新されました。更新を実行してもよろしいですか？"
    Private Const MSG013 As String = "ﾚｺｰﾄﾞが削除されました。削除を実行してもよろしいですか？"
    Private Const MSG021 As String = "ﾚｺｰﾄﾞを追加してもよろしいですか？"
    Private Const MSG101 As String = "ﾄﾗﾝｻﾞｸｼｮﾝを開始してもよろしいですか？"
    Private Const MSG102 As String = "ﾛｰﾙﾊﾞｯｸしてもよろしいですか？"
    Private Const MSG103 As String = "ｺﾐｯﾄしてもよろしいですか？"
    Private Const MSG501 As String = "ﾍﾟｰｽﾄ作業は、最終行を選択してから実行して下さい。"
    Private Const MSG502 As String = "ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀ数と、ｸﾞﾘｯﾄﾞのﾃﾞｰﾀの列数が一致しません。"
    Private Const MSG503 As String = "ｾﾙが選択されていません。" & vbCrLf & "ｾﾙを選択してください。"
    Private Const MSG504 As String = "複数のｾﾙが選択されています。" & vbCrLf & "一つのｾﾙを選択してください。"

    'ｺﾝﾃｯｸｽ文字列
    Private Const MENU_EQUAL_TEXT As String = "  に等しい"
    Private Const MENU_NOTEQUAL_TEXT As String = "  に等しくない"
    Private Const MENU_CONTAIN_TEXT As String = "  を含む"
    Private Const MENU_NOTCONTAIN_TEXT As String = "  を含まない"
    Private Const MENU_OVER_TEXT As String = "  以上"
    Private Const MENU_UNDER_TEXT As String = "  以下"

    '色
    Private HEADER_COLOR_RED As Color = Color.FromArgb(255, 0, 0)          'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞのﾍｯﾀﾞｰ背景色(赤)
    Private HEADER_COLOR_BLUE As Color = Color.FromArgb(197, 196, 251)     'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞのﾍｯﾀﾞｰ背景色(青)
    Private HEADER_COLOR_PURPLE As Color = Color.FromArgb(172, 101, 203)   'ﾃｰﾌﾞﾙﾃﾞｰﾀｸﾞﾘｯﾄﾞのﾍｯﾀﾞｰ背景色(紫)

    'その他
    Private Const CBOTABLENAME_LENGTH As Integer = 30           'ﾃｰﾌﾞﾙ名の長さ
    Private Const CONSTRAINT_TYPE_PK As String = "P"            'ﾌﾟﾗｲﾏﾘｰｷｰ判定
    Private Const SQL_COMMENT_POSITION As Integer = 35          'SQL文ｺﾒﾝﾄ開始位置
    Private Const SQL_USER_INPUT_PLACE As String = "@@@@"       'ﾕｰｻﾞｰ定義部分


    '================================================
    '列挙体
    '================================================
    ''' <summary>ｿｹｯﾄﾃﾞｰﾀｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        COLUMN_NAME         '列名
        COMMENTS            'ｺﾒﾝﾄ
        DATA_TYPE           'ﾀｲﾌﾟ
        DATA_LENGTH         '列の長さ
        DATA_PRECISION      '精度
        DATA_SCALE          '数値の小数点以下の桁
        PK                  'ﾌﾟﾗｲﾏﾘｰｷｰ
        NN                  'NULLABLE
        Data08              'ﾃﾞｰﾀ08(空)
        Data09              'ﾃﾞｰﾀ09(空)
        Data10              'ﾃﾞｰﾀ10(空)
        Data11              'ﾃﾞｰﾀ11(空)
        Data12              'ﾃﾞｰﾀ12(空)
        Data13              'ﾃﾞｰﾀ13(空)
        Data14              'ﾃﾞｰﾀ14(空)
        Data15              'ﾃﾞｰﾀ15(空)
        Data16              'ﾃﾞｰﾀ16(空)
        Data17              'ﾃﾞｰﾀ17(空)
        Data18              'ﾃﾞｰﾀ18(空)
        Data19              'ﾃﾞｰﾀ19(空)
        Data20              'ﾃﾞｰﾀ20(空)
    End Enum

    ''' <summary>ﾌｨﾙﾀｰ機能のSQL文Where句作成時の分類</summary>
    Enum menmFilterSQLWhere
        Equal               '～に等しい
        NotEqual            '～に等しくない
        Contain             '～を含む
        NotContain          '～を含まない
        Over                '～以上
        Under               '～以下
    End Enum

    '================================================
    '構造体
    '================================================
    ''' <summary>ﾛｸﾞﾃｰﾌﾞﾙ表示定義</summary>
    Private Structure strcLogDispConfig
        Public strTableName         'ﾃｰﾌﾞﾙ名
        Public strFieldNameWhere    'ﾌｨｰﾙﾄﾞ名(条件)
        Public strFieldNameOrder    'ﾌｨｰﾙﾄﾞ名(並び)
    End Structure


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '''****************************************************************************************************************************************
    ''' <summary>
    ''' ただ一つのﾌｫｰﾑにｱｸｾｽする為のﾌﾟﾛﾊﾟﾃｨ
    ''' </summary>
    ''' <value>SQL文実行画面</value>
    ''' <returns>SQL文実行画面</returns>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Private Shared ReadOnly Property objFRM_299011() As FRM_299011
        Get
            'ﾌｫｰﾑがnullまたは破棄されているときは、新しくｲﾝｽﾀﾝｽを作成する
            If mobjInstanceFRM_299011 Is Nothing OrElse mobjInstanceFRM_299011.IsDisposed Then
                mobjInstanceFRM_299011 = New FRM_299011
            End If
            Return mobjInstanceFRM_299011
        End Get
    End Property

    '''****************************************************************************************************************************************
    ''' <summary>
    ''' ﾌｨﾙﾀｰ用Where句公開
    ''' </summary>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Public ReadOnly Property strSQLFilterWhere() As String
        Get
            Return mstrSQLFilterWhere
        End Get
    End Property

    '''****************************************************************************************************************************************
    ''' <summary>
    ''' 初期表示するﾃｰﾌﾞﾙ名
    ''' </summary>
    ''' <remarks></remarks>
    '''****************************************************************************************************************************************
    Public Property strDispTableName() As String
        Get
            Return mstrDispTableName
        End Get
        Set(ByVal Value As String)
            mstrDispTableName = Value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "

#Region "  ﾌｫｰﾑﾛｰﾄﾞ                                                 "
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
            Call FormLoad(True)
        Catch ex As Exception
            ComError(ex)
        Finally
            mblnFormLoad = False    'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ
        End Try
    End Sub
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｼｮｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_299010_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If mblnFormClose = True Then Me.Close()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  表示                                         ﾎﾞﾀﾝｸﾘｯｸ    "
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


            '********************************************************************
            '色々初期化
            '********************************************************************
            mstrSQLFilterWhere = ""
            mstrSQLFilterOrder = ""
            ReDim mstrSQLFilterAryOrder(0)
            grdTableData.DataSource = Nothing


            '********************************************************************
            '表示ﾎﾞﾀﾝｸﾘｯｸ処理
            '********************************************************************
            Call cmdDispProcess()


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  更新                                         ﾎﾞﾀﾝｸﾘｯｸ    "
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Try
            Call tsmRefreshClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ表示                                      ﾎﾞﾀﾝｸﾘｯｸ    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ表示                                      ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogDisp.Click
        Try
            Call cmdLogDisp_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  列縮                                         ﾎﾞﾀﾝｸﾘｯｸ    "
    Private Sub cmdColInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColInitialize.Click
        Try
            Call cmdColInitialize_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  印字                                         ﾎﾞﾀﾝｸﾘｯｸ    "
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
#Region "  SQL                                          ﾎﾞﾀﾝｸﾘｯｸ    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQLﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSQLFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSQLFile.Click
        Try


            '********************************************************************
            '表示ﾎﾞﾀﾝｸﾘｯｸ処理
            '********************************************************************
            Call cmdSQLFileProcess()


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾌｫｰﾑ                                         ｻｲｽﾞ変更    "
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
#Region "  列ﾃﾞｰﾀ表示                                   ﾁｪｯｸﾎﾞｯｸｽ変更   "
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
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ                           変更        "
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
#Region "  SQL文実行画面                                    ｸﾘｯｸ"
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
#Region "  新規ｳｨﾝﾄﾞｳ                                       ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 新規ｳｨﾝﾄﾞｳｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmNewMake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNewMake.Click
        Try
            Call tsmNewMakeClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ更新                                         ｸﾘｯｸ"
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
#Region "  Select                                           ｸﾘｯｸ"
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
#Region "  表示更新                                         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRefresh.Click
        Try
            Call tsmRefreshClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝ開始                                    ｸﾘｯｸ"
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
#Region "  ﾛｰﾙﾊﾞｯｸ                                          ｸﾘｯｸ"
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
#Region "  ｺﾐｯﾄ                                             ｸﾘｯｸ"
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
#Region "  接続                                             ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 接続ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmConnect.Click
        Try
            Call tsmConnect_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  切断                                             ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 切断ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmDisConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDisConnect.Click
        Try
            Call tsmDisConnect_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ自動解除                       ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmTableNameSelectAutoCansel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameSelectAutoCansel.Click
        Try
            Call tsmTableNameSelectAutoCansel_ClickProcess()
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽﾄﾞﾛｯﾌﾟﾀﾞｳﾝｽﾀｲﾙ                 ｸﾘｯｸ"
    Private Sub tsmTableNameDropDownStyle01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameDropDownStyle01.Click
        Try
            Call tsmTableNameDropDownStyle00_ClickProcess(sender)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
    Private Sub tsmTableNameDropDownStyle02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTableNameDropDownStyle02.Click
        Try
            Call tsmTableNameDropDownStyle00_ClickProcess(sender)
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
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdTableData.KeyDown
        Try
            If e.Control And e.KeyCode = Keys.V Then
                '(Ctrl + V の場合)
                Call DataPasteProcess()
            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdTableData.CellMouseDown
        Try
            Call grdTableData_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽｱｯﾌﾟｲﾍﾞﾝﾄ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞｾﾙﾏｳｽｱｯﾌﾟｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdTableData.CellMouseUp
        Try
            Call grdTableData_CellMouseDownProcess(sender, e)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

    'ﾃﾞｰﾀｸﾞﾘｯﾄﾞｺﾝﾃｯｸｽﾒﾆｭｰｽﾄﾘｯﾌﾟｲﾍﾞﾝﾄ
#Region "  ～に等しい                   ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～に等しい                   ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Equal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Equal.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Equal)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ～に等しくない               ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～に等しくない               ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_NotEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_NotEqual.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.NotEqual)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ～を含む                     ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～を含む                     ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Contain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Contain.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Contain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ～を含まない                 ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～を含まない                 ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_NotContain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_NotContain.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.NotContain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ～以上                       ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～以上                       ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Over_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Over.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Over)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ～以下                       ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ～以下                       ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Under_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Under.Click
        Try
            Call ChoiceFilterProcess(menmFilterSQLWhere.Under)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ に等しい            ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ に等しい            ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Equal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Equal.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Equal)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ に等しくない        ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ に等しくない        ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_NotEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_NotEqual.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.NotEqual)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ を含む              ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ を含む              ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Contain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Contain.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Contain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ を含まない          ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ を含まない          ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_NotContain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_NotContain.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.NotContain)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ 以上                ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ 以上                ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Over_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Over.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Over)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ 以下                ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ 以下                ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_Under_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sitei_Under.Click
        Try
            Call TextFilterProcess(menmFilterSQLWhere.Under)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  昇順                         ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 昇順                         ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Asc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Asc.Click
        Try
            Call Menu_Asc_ClickProcess(ORDER_BY_ASC)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  降順                         ｸﾘｯｸｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 降順                         ｸﾘｯｸｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Desc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Desc.Click
        Try
            Call Menu_Asc_ClickProcess(ORDER_BY_DESC)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  ﾃｷｽﾄﾎﾞｯｸｽ                    ﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄ  "
    Private Sub Menu_Sitei_TextBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Sitei_TextBox.DoubleClick
        Try
            Call Menu_Sitei_TextBox_DoubleClickProcess()
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
                If IsDate(strData) Then
                    strReturn = "TO_DATE('" & Format(TO_DATE(strData), CtrlZTool.clsComFuncFRM.DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS')"
                Else
                    strReturn = "TO_DATE('" & Format(strData, CtrlZTool.clsComFuncFRM.DATE_FORMAT_03) & "','YYYY/MM/DD HH24:MI:SS')"
                End If
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
#Region "  ﾌｫｰﾑ                         ﾛｰﾄﾞ処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <param name="blnInitialize">初期化ﾌﾗｸﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad(ByVal blnInitialize As Boolean)


        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        '色々初期化処理
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        If blnInitialize = True Then
            Call InitializeProcess()
        End If



        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        '初期化後の本番処理
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim aryData As ArrayList = New ArrayList


        '**************************************************************************
        '色々初期化
        '**************************************************************************
        chkgrdColumnDataVisible.Checked = True      '列ﾃﾞｰﾀが表示されてないとﾌｫｰﾑﾛｰﾄﾞ処理でおかしくなる(でもﾌｫｰﾑﾛｰﾄﾞ終了時には列ﾃﾞｰﾀは非表示)


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
        gobjDb.SQL = strSQL
        strDataSetName = "USER_TABLES"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(ﾃﾞｰﾀが取得出来た場合)
            For ii As Integer = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1
                '(ﾙｰﾌﾟ:取得ﾃﾞｰﾀ数)

                Dim strComboDisp As String = ""         'ｺﾝﾎﾞﾎﾞｯｸｽ表示用文字列
                Dim strTableName As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("TABLE_NAME"))        'ﾃｰﾌﾞﾙ名
                Dim strTableComment As String = TO_STRING(objDataSet.Tables(strDataSetName).Rows(ii)("COMMENTS"))       'ﾃｰﾌﾞﾙ名ｺﾒﾝﾄ
                strComboDisp &= SPC_PAD(strTableName, CBOTABLENAME_LENGTH)
                strComboDisp &= strTableComment
                aryData.Add(New clsCboData(strComboDisp, strTableName))
            Next
        Else
            Throw New Exception("ﾃｰﾌﾞﾙが見つかりません。")
        End If
        cboTableName.DisplayMember = clsCboData.DISPLAYMEMBER
        cboTableName.ValueMember = clsCboData.VALUEMEMBER
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
        'Call tsmBeginTransClickProcess()                        'ﾄﾗﾝｻﾞｸｼｮﾝ開始
        Call lblTransUpdate(TRANS_NOTRANS)                      'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


        '********************************************************************
        '初期表示するﾃｰﾌﾞﾙが設定されていた場合
        '********************************************************************
        If IsNotNull(mstrDispTableName) Then
            '(初期表示するﾃｰﾌﾞﾙが設定されていた場合)

            'ｺﾝﾎﾞﾎﾞｯｸｽ設定
            cboTableName.SelectedValue = mstrDispTableName

        End If


        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        'ﾌﾟﾛｸﾞﾗﾑ開始後、一回目の処理
        '****************************************************************************************************************************************************
        '****************************************************************************************************************************************************
        If gblnFirst = True Then
            '(ﾌﾟﾛｸﾞﾗﾑ開始後、一回目の処理の場合)
            gblnFirst = False
            mblnFormClose = True


            '*******************************************************
            'ﾌｫｰﾑ最大化
            '*******************************************************
            If TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_042)) = 1 Then
                Me.WindowState = FormWindowState.Maximized
            End If


            ''*******************************************************
            ''ﾌﾟﾛｸﾞﾗﾑ開始時に表示するﾃｰﾌﾞﾙ一覧
            ''*******************************************************
            'Dim strAryTableName() As String = Split(TO_STRING(GET_CONFIG_INFO(GKEY_G000000_051)), ",")
            'For ii As Integer = 0 To strAryTableName.Length - 1
            '    strAryTableName(ii) = strAryTableName(ii).Replace(vbCrLf, "")
            '    strAryTableName(ii) = RTrim(strAryTableName(ii))
            '    strAryTableName(ii) = LTrim(strAryTableName(ii))

            '    Exit For  ''MOD
            'Next
            'For Each strTableName As String In strAryTableName
            '    '(ﾙｰﾌﾟ:ﾌﾟﾛｸﾞﾗﾑ開始時に表示するﾃｰﾌﾞﾙ一覧数)
            '    For Each cboTableNameItems As clsCboData In cboTableName.Items
            '        '(ﾙｰﾌﾟ:ｺﾝﾎﾞﾎﾞｯｸｽにｾｯﾄされているｱｲﾃﾑ数)
            '        If cboTableNameItems.Value = strTableName Then
            '            '(ﾌﾟﾛｸﾞﾗﾑ開始時に表示する場合)
            '            Call tsmNewMakeClickProcess(cboTableNameItems.Value)
            '            Exit For
            '        End If
            '    Next
            'Next
            Call tsmNewMakeClickProcess()       '最後の一枚を表示(多くの場合がこの処理が必要な為)

        End If


    End Sub
#End Region
#Region "  表示                         ﾎﾞﾀﾝｸﾘｯｸ処理        "
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
        Dim blnDispData As Boolean = True       'ﾃﾞｰﾀ表示ﾌﾗｸﾞ


        '********************************************************************
        'ﾃﾞｰﾀ件数取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "    COUNT(*) "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName
        If mstrSQLFilterWhere <> "" Then
            '(条件がある場合)
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        1 = 1 "
            strSQL &= vbCrLf & mstrSQLFilterWhere
        End If
        strSQL &= vbCrLf
        gobjDb.SQL = strSQL
        strDataSetName01 = "COUNT"
        objDataSet02.Clear()
        gobjDb.GetDataSet(strDataSetName01, objDataSet02)
        If objDataSet02.Tables(strDataSetName01).Rows.Count > 0 Then
            '(ﾃﾞｰﾀが取得出来た場合)
            If TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_043)) < TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0)) Then
                '(ﾃﾞｰﾀ件数が多すぎた場合)

                If (New StackFrame(7).GetMethod.Name) = "FormLoad" Then
                    '(strDispTableNameﾌﾟﾛﾊﾟﾃｨが設定されていて、それによる表示の場合)
                    blnDispData = False
                ElseIf (New StackFrame(1).GetMethod.Name) = "Menu_Asc_ClickProcess" _
                   And (New StackFrame(2).GetMethod.Name) = "cmdLogDisp_ClickProcess" _
                   Then
                    '(ﾛｸﾞ表示処理での表示　かつ　並び替え処理の場合)
                    '(二重の確認になってしまうので、無視する事にした)
                    'NOP
                ElseIf (New StackFrame(2).GetMethod.Name) = "cboTableName_SelectedIndexChangedProcess" _
                   And RetCode.OK = SearchLogDispDefine(cboTableName.SelectedValue) _
                   Then
                    '(ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽで選択が変更された　かつ　ﾛｸﾞﾃｰﾌﾞﾙ表示定義がされていた場合)
                    blnDispData = False
                Else
                    '(通常の表示の場合)
                    Dim intRowCount As Integer = TO_INTEGER(objDataSet02.Tables(strDataSetName01).Rows(0)(0))       'ﾃﾞｰﾀ件数
                    Dim intRowPerSec As Integer = TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_044))                     '1秒で表示可能な行数(行/sec)
                    Dim intMin As Integer = (intRowCount \ (intRowPerSec * 60))                                     '分
                    Dim intSec As Integer = (intRowCount Mod (intRowPerSec * 60)) \ (intRowPerSec)                  '秒
                    Dim strMsg As String = ""
                    strMsg = "ﾃﾞｰﾀ件数が" & Format(intRowCount, "#,#") & "件です。"
                    strMsg &= vbCrLf & "約" & TO_STRING(intMin) & "分" & TO_STRING(intSec) & "秒"
                    strMsg &= vbCrLf & "かかります。"
                    strMsg &= vbCrLf & "続行しますか？"
                    If MsgBox(strMsg, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                        blnDispData = False
                    End If
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
        '========================================================
        'SELECT句
        '========================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & strSQLColumnData
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    " & strTableName

        '========================================================
        'WHERE句
        '========================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        If blnDispData = False Then
            '(ﾃﾞｰﾀを表示しない場合)
            strSQL &= vbCrLf & "    AND 1 <> 1 "
        End If
        If mstrSQLFilterWhere <> "" Then
            '(条件がある場合)
            strSQL &= mstrSQLFilterWhere
        End If

        '========================================================
        'ORDER BY句
        '========================================================
        strSQL &= vbCrLf & " ORDER BY "
        If mstrSQLFilterOrder <> "" Then
            '(条件がある場合)
            strSQL &= vbCrLf & mstrSQLFilterOrder
        Else
            '(条件がない場合)
            strSQL &= vbCrLf & strSQLColumnData
        End If
        strSQL &= vbCrLf

        '========================================================
        '取得
        '========================================================
        gobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSetGrid.Clear()
        '取得 & 処理速度測定
        Dim dtmNow01 As Date = Now
        gobjDb.GetDataSet(strDataSetName01, objDataSetGrid)
        Dim objDiff As TimeSpan = Now - dtmNow01
        'ﾛｸﾞ出力
        gobjDb.AddToLog(gobjDb.SQL & ";")
        gobjDb.AddToLog("[DB取得処理時間:" & CStr(CDec(objDiff.TotalMilliseconds / 1000)) & "(sec)]")
        'ｸﾞﾘｯﾄﾞに反映
        grdTableData.DataSource = objDataSetGrid.Tables(strDataSetName01)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdTableDataSetup()


    End Sub
#End Region
#Region "  ﾛｸﾞ表示                      ﾎﾞﾀﾝｸﾘｯｸ処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ表示                      ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdLogDisp_ClickProcess()
        Dim intRet As RetCode


        '*******************************************************
        'ﾛｸﾞﾃｰﾌﾞﾙ定義名(ﾃｰﾌﾞﾙ名)      の検索処理
        '*******************************************************
        Dim strFieldNameWhere As String = ""         'ﾌｨｰﾙﾄﾞ名(条件)
        Dim strFieldNameOrder As String = ""         'ﾌｨｰﾙﾄﾞ名(並び)
        intRet = SearchLogDispDefine(cboTableName.SelectedValue, strFieldNameWhere, strFieldNameOrder)
        If intRet = RetCode.OK Then
            '(定義が見つかった場合)


            '*******************************************************
            'ﾛｸﾞﾃｰﾌﾞﾙ定義名(ﾌｨｰﾙﾄﾞ名)     の検索処理
            '*******************************************************
            Dim intColIndexWhere As Integer      '列ｲﾝﾃﾞｯｸｽ(条件)
            Dim intColIndexOrder As Integer      '列ｲﾝﾃﾞｯｸｽ(並び)
            Call SearchFieldIndex(strFieldNameWhere, intColIndexWhere)
            Call SearchFieldIndex(strFieldNameOrder, intColIndexOrder)


            '*******************************************************
            'ﾃｷｽﾄﾌｨﾙﾀ 以上          処理
            '*******************************************************
            grdTableData.ClearSelection()                               'ｸﾞﾘｯﾄﾞ選択
            grdTableData.Item(intColIndexWhere, 0).Selected = True      'ｸﾞﾘｯﾄﾞ選択
            Menu_Sitei_TextBox.Text = Format(Now, CtrlZTool.clsComFuncFRM.DATE_FORMAT_02)
            Call TextFilterProcess(menmFilterSQLWhere.Over)


            '*******************************************************
            '降順                   処理
            '*******************************************************
            If 1 < grdTableData.RowCount Then
                '(表示時間の警告でｷｬﾝｾﾙを押下した場合は表示は行わない)
                grdTableData.ClearSelection()                               'ｸﾞﾘｯﾄﾞ選択
                grdTableData.Item(intColIndexOrder, 0).Selected = True      'ｸﾞﾘｯﾄﾞ選択
                Call Menu_Asc_ClickProcess(ORDER_BY_DESC)
            End If


        End If


    End Sub
#End Region
#Region "  列縮                         ﾎﾞﾀﾝｸﾘｯｸ処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列縮                         ﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdColInitialize_ClickProcess()


        '********************************************************
        '列幅を縮める
        '********************************************************
        For ii As Integer = 0 To grdTableData.Columns.Count - 1
            If 120 <= grdTableData.Columns(ii).Width Then
                grdTableData.Columns(ii).Width = 120
            End If
        Next


    End Sub
#End Region
#Region "  印字                         ﾎﾞﾀﾝｸﾘｯｸ処理        "
    Private Sub cmdPrintProcess()


        '********************************************************************
        'ﾍｯﾀﾞｰ部分作成
        '********************************************************************
        Dim strColTerminator As String = GET_CONFIG_INFO(GKEY_G000000_020)
        Dim strRowTerminator As String = GET_CONFIG_INFO(GKEY_G000000_021)
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
        Call DivStringToArray(strHeader, strHeaderArray)
        If IsNothing(strHeaderArray) = False Then
            If 0 <= UBound(strHeaderArray) Then strText05 = strHeaderArray(0)
            If 1 <= UBound(strHeaderArray) Then strText06 = strHeaderArray(1)
            If 2 <= UBound(strHeaderArray) Then strText07 = strHeaderArray(2)
        End If


        '********************************************************************
        '印字
        '********************************************************************
        Call CRPrintKaihatu(grdTableData, strTableName, strText01, "", strText05, strText06, strText07, txtTitle.Text)


    End Sub
#End Region
#Region "  SQL                          ﾎﾞﾀﾝｸﾘｯｸ処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SQLﾎﾞﾀﾝｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSQLFileProcess()


        '********************************************************************
        'ﾛｸﾞﾌｧｲﾙ表示
        '********************************************************************
        Dim strFilePathName As String = ""
        strFilePathName = gcstrLOG_FILE_PATH & gcstrLOG_FILE_NAME       'ﾌｧｲﾙ名         ｾｯﾄ
        Call System.Diagnostics.Process.Start(strFilePathName)


    End Sub
#End Region
#Region "  ﾌｫｰﾑ                         ｻｲｽﾞ変更処理        "
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
#Region "  列ﾃﾞｰﾀ表示                   ﾁｪｯｸﾎﾞｯｸｽ変更処理   "
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

        'ﾌｫｰﾑｻｲｽﾞ変更処理
        Call FormSizeChangedProcess()

    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ           変更処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ変更処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboTableName_SelectedIndexChangedProcess()
        Dim intRet As RetCode


        '********************************************************************
        'ﾌｫｰﾑ表示名更新
        '********************************************************************
        Dim strText As String = cboTableName.Text
        While True
            strText = strText.Replace(Space(2), Space(1))
            If strText.IndexOf(Space(2)) < 0 Then Exit While
        End While
        Me.Text = strText


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ初期化
        '********************************************************************
        grdTableData.DataSource = Nothing
        grdColumnData.DataSource = Nothing


        '********************************************************************
        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ表示(列ﾃﾞｰﾀ)
        '********************************************************************
        Call grdColumnDataDisplay(cboTableName.SelectedValue)


        '********************************************************************
        'ﾃﾞｰﾀ表示
        '********************************************************************
        Call cmdDisp_Click(Nothing, Nothing)
        'Call cmdDispProcess()


        '*******************************************************
        'ﾛｸﾞﾃｰﾌﾞﾙ定義名(ﾃｰﾌﾞﾙ名)      の検索処理
        '*******************************************************
        Dim strFieldNameWhere As String = ""         'ﾌｨｰﾙﾄﾞ名(条件)
        Dim strFieldNameOrder As String = ""         'ﾌｨｰﾙﾄﾞ名(並び)
        intRet = SearchLogDispDefine(cboTableName.SelectedValue, strFieldNameWhere, strFieldNameOrder)
        If intRet = RetCode.OK Then
            '(定義が見つかった場合)


            '*******************************************************
            'ﾛｸﾞ表示                      ﾎﾞﾀﾝｸﾘｯｸ処理
            'ﾃﾞｰﾀ表示処理が行われないと、正常に処理されない
            '*******************************************************
            Call cmdLogDisp_ClickProcess()


        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ選択解除
        '*******************************************************
        If tsmTableNameSelectAutoCansel.Checked = True Then
            cmdDisp.Focus()
        End If


    End Sub
#End Region


    'ﾒﾆｭｰﾊﾞｰｲﾍﾞﾝﾄ
#Region "  SQL文実行画面                        ｸﾘｯｸ処理    "
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
        objFRM_299011.objFRM_299010 = Me            'DBﾒﾝﾃﾅﾝｽﾂｰﾙ
        objFRM_299011.Location = Me.Location        '位置を合わせる
        objFRM_299011.Show()                        '表示
        objFRM_299011.TopMost = True                '常に手前に設定(一回手前に持って来る)
        objFRM_299011.TopMost = False               '常に手前に設定解除


    End Sub
#End Region
#Region "  新規作成                             ｸﾘｯｸ処理    "
    Private Sub tsmNewMakeClickProcess(Optional ByVal strDispTableName As String = "")
        Dim objForm As FRM_299010
        objForm = New FRM_299010
        objForm.strDispTableName = strDispTableName
        objForm.Show()
        If Me.WindowState = FormWindowState.Maximized Then
            objForm.WindowState = FormWindowState.Maximized
        End If
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ更新                             ｸﾘｯｸ処理    "
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
#Region "  表示更新                             ｸﾘｯｸ処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 表示更新処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tsmRefreshClickProcess()


        '********************************************************************
        '表示更新
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  Select                               ｸﾘｯｸ処理    "
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
        Call cmdDisp_Click(Nothing, Nothing)


    End Sub
#End Region
#Region "  ﾄﾗﾝｻﾞｸｼｮﾝ開始                        ｸﾘｯｸ処理    "
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
            gobjDb.BeginTrans()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Call lblTransUpdate(TRANS_BEGINTRANS)           'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


    End Sub
#End Region
#Region "  ﾛｰﾙﾊﾞｯｸ開始                          ｸﾘｯｸ処理    "
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
            gobjDb.RollBack()
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


        ''********************************************************************
        ''ﾄﾗﾝｻﾞｸｼｮﾝ開始
        ''********************************************************************
        'Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  ｺﾐｯﾄ開始                             ｸﾘｯｸ処理    "
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
            gobjDb.Commit()
        Catch ex As Exception
            Call ComError(ex)
        End Try


        '********************************************************************
        'ﾗﾍﾞﾙ更新
        '********************************************************************
        Call lblTransUpdate(TRANS_NOTRANS)              'ﾄﾗﾝｻﾞｸｼｮﾝ状態表示


        ''********************************************************************
        ''ﾄﾗﾝｻﾞｸｼｮﾝ開始
        ''********************************************************************
        'Call tsmBeginTransClickProcess()


    End Sub
#End Region
#Region "  接続                                 ｸﾘｯｸ処理    "
    Private Sub tsmConnect_ClickProcess()


        '**************************************************************************
        '接続画面起動
        '**************************************************************************
        Dim objFRM_299012 As New FRM_299012
        objFRM_299012.ShowDialog()


        '**************************************************************************
        'ﾌｫｰﾑﾛｰﾄﾞ処理
        '**************************************************************************
        Call FormLoad(False)


    End Sub
#End Region
#Region "  切断                                 ｸﾘｯｸ処理    "
    Private Sub tsmDisConnect_ClickProcess()

        If IsNull(gobjDb) = False Then
            gobjDb.Disconnect()
            gobjDb = Nothing
        End If

    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ 自動解除          ｸﾘｯｸ処理    "
    Private Sub tsmTableNameSelectAutoCansel_ClickProcess()

        tsmTableNameSelectAutoCansel.Checked = Not (tsmTableNameSelectAutoCansel.Checked)

    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙ選択ｺﾝﾎﾞﾎﾞｯｸｽ ﾄﾞﾛｯﾌﾟﾀﾞｳﾝｽﾀｲﾙ    ｸﾘｯｸ処理    "
    Private Sub tsmTableNameDropDownStyle00_ClickProcess(ByVal sender As System.Object)


        '************************************************************
        '
        '************************************************************
        Dim tsmSelect As System.Windows.Forms.ToolStripMenuItem = sender
        Select Case tsmSelect.Name
            Case tsmTableNameDropDownStyle01.Name
                '(ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ選択の場合)
                tsmTableNameDropDownStyle01.Checked = True                  'ﾒﾆｭｰ表示更新
                tsmTableNameDropDownStyle02.Checked = False                 'ﾒﾆｭｰ表示更新
                cboTableName.DropDownStyle = ComboBoxStyle.DropDownList     'ｺﾝﾎﾞﾎﾞｯｸｽ更新
            Case tsmTableNameDropDownStyle02.Name
                '(ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ選択の場合)
                tsmTableNameDropDownStyle01.Checked = False                 'ﾒﾆｭｰ表示更新
                tsmTableNameDropDownStyle02.Checked = True                  'ﾒﾆｭｰ表示更新
                cboTableName.DropDownStyle = ComboBoxStyle.DropDown         'ｺﾝﾎﾞﾎﾞｯｸｽ更新
        End Select


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


            mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
            mblnRowInsert = False               '行追加ﾌﾗｸﾞ


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

            ''========================================================
            ''画面更新
            ''========================================================
            'Call cmdDispProcess()

        ElseIf mblnCellValueChange = True Then
            '(値が更新されていた場合)


            mblnCellValueChange = False         'ｾﾙ値変更ﾌﾗｸﾞ
            mblnRowInsert = False               '行追加ﾌﾗｸﾞ


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

            ''========================================================
            ''画面更新
            ''========================================================
            'Call cmdDispProcess()

        End If


        '********************************************************************
        '行が選択された時点で、UPDATE文用のWHERE句を作成する
        '********************************************************************
        mstrSQLUpdateWhere = ""
        If grdTableData.RowCount - 1 <> mintCurrentCellRow Then
            '(最終行選択以外の場合)
            For ii As Integer = 0 To grdColumnData.RowCount - 1
                '(ﾙｰﾌﾟ:列数)

                If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
                    '(ﾌﾟﾗｲﾏﾘｰｷｰの場合)
                    mstrSQLUpdateWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
                    mstrSQLUpdateWhere &= GetStringSQLData(grdTableData.Item(ii, mintCurrentCellRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
                End If

            Next
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

            For ii As Integer = 0 To grdTableData.RowCount - 2
                '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数、一番下の行はﾃﾞｰﾀが存在しないので省く)

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
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾃﾞｰﾀﾍﾟｰｽﾄ処理                  "
    Private Sub DataPasteProcess()
        Dim blnRet As Boolean = False


        '********************************************************************
        '色々ﾁｪｯｸ
        '********************************************************************
        If grdTableData.Rows(grdTableData.RowCount - 1).Selected = False Then
            '(最終行を選択していない場合)
            MsgBox(MSG501, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If MsgBox(MSG021, MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
            Exit Sub
        End If


        '********************************************************************
        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾃﾞｰﾀを取得
        '********************************************************************
        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容を取得
        Dim strClipboardDataText As String = Clipboard.GetText()
        '改行を変換
        strClipboardDataText = strClipboardDataText.Replace(vbCrLf, vbLf)
        strClipboardDataText = strClipboardDataText.Replace(vbCr, vbLf)
        '改行で分割
        Dim strDatalines() As String = Split(strClipboardDataText, vbLf)


        '********************************************************************
        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾃﾞｰﾀの貼り付け
        '********************************************************************
        Dim blnError As Boolean = False     '追加ｴﾗｰﾌﾗｸﾞ
        For ii As Integer = LBound(strDatalines) To UBound(strDatalines)
            '(ﾙｰﾌﾟ:ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾃﾞｰﾀの行数)

            '========================================================
            '列毎に分割
            '========================================================
            Dim strDataColumnes() As String = Split(strDatalines(ii), vbTab)
            If strDatalines(ii).Replace(Space(1), "").Replace(vbTab, "") = "" Then Exit For '(最後の行として判断)
            If strDataColumnes.Length = 1 Then If IsNull(strDataColumnes(0)) Then Exit For '(最後の行として判断)
            If strDataColumnes.Length <> grdTableData.ColumnCount Then
                '(ｸﾞﾘｯﾄﾞの列数と合っていない場合)
                MsgBox(MSG502, MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            '========================================================
            'ﾃﾞｰﾀをｾｯﾄ
            '========================================================
            For jj As Integer = LBound(strDataColumnes) To UBound(strDataColumnes)
                '(ﾙｰﾌﾟ:ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾃﾞｰﾀの列数)
                If IsNotNull(strDataColumnes(jj)) Then
                    grdTableData.Item(jj, grdTableData.RowCount - 1).Value = strDataColumnes(jj)
                Else
                    grdTableData.Item(jj, grdTableData.RowCount - 1).Value = System.DBNull.Value
                End If
            Next

            '========================================================
            '追加処理
            '========================================================
            Try
                Call DataInsert(grdTableData.RowCount - 1)
            Catch ex As Exception
                ComError(ex)
                blnError = True
            End Try


        Next


        '********************************************************************
        '画面更新
        '********************************************************************
        If blnError = False Then
            '(正常に全てのﾃﾞｰﾀが追加された場合)
            Call cmdDispProcess()
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾏｳｽﾀﾞｳﾝ処理                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾏｳｽﾀﾞｳﾝ処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdTableData_CellMouseDownProcess(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)


        If e.Button = MouseButtons.Right Then
            '(右ｸﾘｯｸの場合)


            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
                '(ﾍｯﾀﾞ以外のｾﾙの場合)


                '********************************************************************
                '選択ｾﾙを変更する
                '********************************************************************
                grdTableData.ClearSelection()
                grdTableData.Item(e.ColumnIndex, e.RowIndex).Selected = True


                '********************************************************************
                'ｺﾝﾃｯｸｽﾒﾆｭｰを変更する
                '********************************************************************
                grdTableData.ContextMenuStrip = ContextMenuStrip1
                Menu_Equal.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_EQUAL_TEXT
                Menu_NotEqual.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_NOTEQUAL_TEXT
                Menu_Contain.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_CONTAIN_TEXT
                Menu_NotContain.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_NOTCONTAIN_TEXT
                Menu_Over.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_OVER_TEXT
                Menu_Under.Text = grdTableData.Item(e.ColumnIndex, e.RowIndex).Value & MENU_UNDER_TEXT


            Else
                '(ﾍｯﾀﾞの場合)
                grdTableData.ContextMenuStrip = Nothing
            End If


        End If


    End Sub
#End Region

    'ﾃﾞｰﾀｸﾞﾘｯﾄﾞｺﾝﾃｯｸｽﾒﾆｭｰｽﾄﾘｯﾌﾟｲﾍﾞﾝﾄ処理
#Region "  選択ﾌｨﾙﾀ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択ﾌｨﾙﾀ処理
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ChoiceFilterProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere)


        '********************************************************************
        '色々ﾁｪｯｸ
        '********************************************************************
        If grdTableData.SelectedCells.Count = 0 Then
            MsgBox(MSG503, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If 1 < grdTableData.SelectedCells.Count Then
            MsgBox(MSG504, MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        '********************************************************************
        '表示
        '********************************************************************
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '選択ｾﾙ行ｲﾝﾃﾞｯｸｽ
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '選択ｾﾙ列ｲﾝﾃﾞｯｸｽ
        Call FilterSQLWhereMakeProcess(intFilterSQLWhere _
                                     , grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value _
                                     , grdColumnData.Item(menmListCol.DATA_TYPE, intCIndex).Value _
                                     , TO_STRING(grdTableData.Item(intCIndex, intRIndex).Value) _
                                     )


        '********************************************************************
        '色々初期化
        '********************************************************************
        '列ﾍｯﾀﾞ色調整
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE Then
            '(並び替え後の場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(並び替えandﾌｨﾙﾀ後の場合)
            'NOP
        Else
            '(何もしていない場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED
        End If


    End Sub
#End Region
#Region "  ﾃｷｽﾄﾌｨﾙﾀ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾌｨﾙﾀ処理
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TextFilterProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere)


        '********************************************************************
        '色々ﾁｪｯｸ
        '********************************************************************
        If grdTableData.SelectedCells.Count = 0 Then
            MsgBox(MSG503, MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If 1 < grdTableData.SelectedCells.Count Then
            MsgBox(MSG504, MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        '********************************************************************
        '表示
        '********************************************************************
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '選択ｾﾙ行ｲﾝﾃﾞｯｸｽ
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '選択ｾﾙ列ｲﾝﾃﾞｯｸｽ
        Call FilterSQLWhereMakeProcess(intFilterSQLWhere _
                                     , grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value _
                                     , grdColumnData.Item(menmListCol.DATA_TYPE, intCIndex).Value _
                                     , Menu_Sitei_TextBox.Text _
                                     )


        '********************************************************************
        '色々初期化
        '********************************************************************
        Menu_Sitei_TextBox.Text = ""
        '列ﾍｯﾀﾞ色調整
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE Then
            '(並び替え後の場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(並び替えandﾌｨﾙﾀ後の場合)
            'NOP
        Else
            '(何もしていない場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED
        End If


    End Sub
#End Region
#Region "  ﾌｨﾙﾀSQL文 Where句作成処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｨﾙﾀSQL文 Where句作成処理
    ''' </summary>
    ''' <param name="intFilterSQLWhere"></param>
    ''' <param name="strColumnName"></param>
    ''' <param name="strColumnDataType"></param>
    ''' <param name="strDataValue"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FilterSQLWhereMakeProcess(ByVal intFilterSQLWhere As menmFilterSQLWhere _
                                        , ByVal strColumnName As String _
                                        , ByVal strColumnDataType As String _
                                        , ByVal strDataValue As String _
                                        )


        '********************************************************************
        'SQL文Where句部分作成
        '********************************************************************
        Dim strSQLWhere As String = ""                    'SQL文
        Select Case intFilterSQLWhere
            Case menmFilterSQLWhere.Equal
                If IsNotNull(strDataValue) Then
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IN ( "
                    strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType) & " )"
                Else
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IS NULL "
                End If
            Case menmFilterSQLWhere.NotEqual
                If IsNotNull(strDataValue) Then
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " NOT IN ( "
                    strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType) & " )"
                Else
                    strSQLWhere &= vbCrLf & "    AND " & strColumnName & " IS NOT NULL "
                End If
            Case menmFilterSQLWhere.Contain
                strSQLWhere &= vbCrLf & "    AND INSTR(" & strColumnName & " , "
                strSQLWhere &= "'" & strDataValue & "') > 0"
            Case menmFilterSQLWhere.NotContain
                strSQLWhere &= vbCrLf & "    AND INSTR(" & strColumnName & " , "
                strSQLWhere &= "'" & strDataValue & "') = 0"
            Case menmFilterSQLWhere.Over
                strSQLWhere &= vbCrLf & "    AND " & strColumnName & " >= "
                strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType)
            Case menmFilterSQLWhere.Under
                strSQLWhere &= vbCrLf & "    AND " & strColumnName & " <= "
                strSQLWhere &= GetStringSQLData(strDataValue, strColumnDataType)
        End Select


        '********************************************************************
        '表示ﾎﾞﾀﾝｸﾘｯｸ処理
        '********************************************************************
        mstrSQLFilterWhere &= strSQLWhere
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  ﾌｨﾙﾀSQL文 OrderBy句作成処理              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strSort">昇順or降順の指定</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Asc_ClickProcess(ByVal strSort As String)
        Dim intRIndex As Integer = grdTableData.SelectedCells(0).RowIndex       '選択ｾﾙ行ｲﾝﾃﾞｯｸｽ
        Dim intCIndex As Integer = grdTableData.SelectedCells(0).ColumnIndex    '選択ｾﾙ列ｲﾝﾃﾞｯｸｽ
        Dim strOrderAsc As String = grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value & ORDER_BY_ASC     '昇順
        Dim strOrderDesc As String = grdColumnData.Item(menmListCol.COLUMN_NAME, intCIndex).Value & ORDER_BY_DESC   '降順


        '********************************************************************
        '追加用OrderBy句作成
        '********************************************************************
        Dim strOrderBy As String        'OrderBy句
        Select Case strSort
            Case ORDER_BY_ASC : strOrderBy = strOrderAsc
            Case ORDER_BY_DESC : strOrderBy = strOrderDesc
            Case Else : Throw New Exception("引数が不正です。")
        End Select


        '********************************************************************
        '重複ﾁｪｯｸ
        '********************************************************************
        For ii As Integer = LBound(mstrSQLFilterAryOrder) To UBound(mstrSQLFilterAryOrder)
            '(ﾙｰﾌﾟ:今までの昇順降順の記録)
            If mstrSQLFilterAryOrder(ii) = strOrderAsc Or mstrSQLFilterAryOrder(ii) = strOrderDesc Then
                '(以前に同じ列で並び替えしていた場合)
                mstrSQLFilterAryOrder(ii) = Nothing
            End If
        Next


        '********************************************************************
        'ﾌｨﾙﾀｰ用SQL文OrderBy句(配列)更新
        '********************************************************************
        ReDim Preserve mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder) + 1)           '要素追加
        mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder)) = strOrderBy                 'OrderBy句ｾｯﾄ


        '********************************************************************
        'ﾌｨﾙﾀｰ用SQL文OrderBy句作成
        '********************************************************************
        mstrSQLFilterOrder = Space(6) & mstrSQLFilterAryOrder(UBound(mstrSQLFilterAryOrder))    '最終要素には必ず値が入っているはず
        For ii As Integer = UBound(mstrSQLFilterAryOrder) - 1 To LBound(mstrSQLFilterAryOrder) Step -1
            '(ﾙｰﾌﾟ:今までの昇順降順の記録)
            If IsNotNull(mstrSQLFilterAryOrder(ii)) Then
                mstrSQLFilterOrder &= vbCrLf & Space(5) & "," & mstrSQLFilterAryOrder(ii)
            End If
        Next


        '********************************************************************
        '色々初期化
        '********************************************************************
        '============================================
        '列ﾍｯﾀﾞ色調整
        '============================================
        If grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_RED Then
            '(ﾌｨﾙﾀ後の場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE
        ElseIf grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_PURPLE Then
            '(並び替えandﾌｨﾙﾀ後の場合)
            'NOP
        Else
            '(何もしていない場合)
            grdTableData.Columns(intCIndex).HeaderCell.Style.BackColor = HEADER_COLOR_BLUE
        End If
        '============================================
        '列ﾍｯﾀﾞﾃｷｽﾄ調整
        '============================================
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("▼", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("▲", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("▽", "")
        grdTableData.Columns(intCIndex).HeaderText = grdTableData.Columns(intCIndex).HeaderText.Replace("△", "")
        Select Case strSort
            Case ORDER_BY_ASC : grdTableData.Columns(intCIndex).HeaderText &= "▼"
            Case ORDER_BY_DESC : grdTableData.Columns(intCIndex).HeaderText &= "▲"
            Case Else : Throw New Exception("引数が不正です。")
        End Select
        For ii As Integer = 0 To grdTableData.Columns.Count - 1
            If ii = intCIndex Then Continue For
            grdTableData.Columns(ii).HeaderText = grdTableData.Columns(ii).HeaderText.Replace("▼", "▽")
            grdTableData.Columns(ii).HeaderText = grdTableData.Columns(ii).HeaderText.Replace("▲", "△")
        Next


        '********************************************************************
        '表示ﾎﾞﾀﾝｸﾘｯｸ処理
        '********************************************************************
        Call cmdDispProcess()


    End Sub
#End Region
#Region "  ﾃｷｽﾄﾎﾞｯｸｽ      ﾀﾞﾌﾞﾙｸﾘｯｸ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾎﾞｯｸｽ      ﾀﾞﾌﾞﾙｸﾘｯｸ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Menu_Sitei_TextBox_DoubleClickProcess()
        Dim intDiffMin As Integer = TO_INTEGER(GET_CONFIG_INFO(GKEY_G000000_041))


        If IsNull(Menu_Sitei_TextBox.Text) Then
            '(何もﾃﾞｰﾀが設定されていない場合)


            '********************************************************************
            '日付を設定
            '********************************************************************
            Dim dtmTemp As Date = Now.AddMinutes(-intDiffMin)
            Menu_Sitei_TextBox.Text = Format(dtmTemp, CtrlZTool.clsComFuncFRM.DATE_FORMAT_03)


        ElseIf IsDate(Menu_Sitei_TextBox.Text) Then
            '(日付型のﾃﾞｰﾀが設定されていた場合)


            '********************************************************************
            '時分秒を削除
            '********************************************************************
            Dim dtmTemp As Date = TO_DATE(Menu_Sitei_TextBox.Text)
            Menu_Sitei_TextBox.Text = Format(dtmTemp, CtrlZTool.clsComFuncFRM.DATE_FORMAT_02)


        End If


    End Sub
#End Region

    '内部関数(DB処理)
#Region "　初期化処理                               "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub InitializeProcess()


        '*******************************************************
        ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ作成
        '*******************************************************
        gobjOwner = New clsOwner                 ' 画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ


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
        Dim blnRet As Boolean
        gobjDb = New clsConnZTool(gobjOwner)
        gobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
        blnRet = gobjDb.Connect()     '接続
        If blnRet = False Then
            Throw New Exception("DB接続に失敗しました。")
        End If


        '**********************************************************
        'Config & ｼｽﾃﾑ変数  ﾃﾞｰﾀ取得
        '**********************************************************
        '画面ﾛｸﾞ用
        gcstrLOG_FILE_PATH = GET_CONFIG_INFO(GKEY_G000000_031)                           '画面ﾛｸﾞﾌｧｲﾙ格納場所
        gcstrLOG_FILE_NAME = GET_CONFIG_INFO(GKEY_G000000_005)                           'ﾌｧｲﾙ名
        gcstrLOG_FILE_NAME_OLD = GET_CONFIG_INFO(GKEY_G000000_006)                       'ﾌｧｲﾙ名(古い)
        gcstrLOG_FILE_SIZE = GET_CONFIG_INFO(GKEY_G000000_007)                           '最大ﾌｧｲﾙｻｲｽﾞ
        gcstrLOG_FILE_SIZE = TO_NUMBER(gcstrLOG_FILE_SIZE) * 1000000                     'Byte → MByte


        '*******************************************************
        ' 起動ﾛｸﾞ書込み
        '*******************************************************
        Call AddToLog_frm(Application.ExecutablePath & "  起動")


        '********************************************************************
        'ﾛｸﾞﾃｰﾌﾞﾙ表示定義   【ﾃｰﾌﾞﾙ名】@@@【ﾌｨｰﾙﾄﾞ名】
        '********************************************************************
        Dim strAryTemp01() As String = Split(TO_STRING(GET_CONFIG_INFO(GKEY_G000000_061)), ",")         'ﾛｸﾞﾃｰﾌﾞﾙ表示定義(ﾃﾝﾎﾟﾗﾘ)
        ReDim mobjAryLogDispConfig(UBound(strAryTemp01))                                                'ﾛｸﾞﾃｰﾌﾞﾙ表示定義
        For ii As Integer = 0 To strAryTemp01.Length - 1
            '(ﾙｰﾌﾟ:ﾛｸﾞﾃｰﾌﾞﾙ表示定義数)

            strAryTemp01(ii) = strAryTemp01(ii).Replace(vbCrLf, "")
            strAryTemp01(ii) = RTrim(strAryTemp01(ii))
            strAryTemp01(ii) = LTrim(strAryTemp01(ii))
            Dim strAryTemp02() As String = Split(strAryTemp01(ii), TO_STRING(GET_CONFIG_INFO(GKEY_G000000_062)))        'ﾛｸﾞﾃｰﾌﾞﾙ表示定義(ﾃﾝﾎﾟﾗﾘ)
            mobjAryLogDispConfig(ii).strTableName = strAryTemp02(0)         'ﾃｰﾌﾞﾙ名
            mobjAryLogDispConfig(ii).strFieldNameWhere = strAryTemp02(1)    'ﾌｨｰﾙﾄﾞ名(条件)
            mobjAryLogDispConfig(ii).strFieldNameOrder = strAryTemp02(2)    'ﾌｨｰﾙﾄﾞ名(並び)

        Next


    End Sub
#End Region
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
        gobjDb.SQL = strSQL
        strDataSetName01 = "TABLE"
        objDataSet01.Clear()
        gobjDb.GetDataSet(strDataSetName01, objDataSet01)


        '********************************************************************
        '行ﾃﾞｰﾀ取得
        '********************************************************************
        If objDataSet01.Tables(strDataSetName01).Rows.Count > 0 Then
            Dim objDataTable As New clsGridDataTable20          'ﾃﾞｰﾀﾃｰﾌﾞﾙ
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
                strSQL &= vbCrLf & "   ,USER_COL_COMMENTS.COMMENTS "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_TYPE "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.NULLABLE "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_LENGTH "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_PRECISION "
                strSQL &= vbCrLf & "   ,USER_TAB_COLUMNS.DATA_SCALE "
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
                gobjDb.SQL = strSQL
                gobjDb.Parameter = objParameter
                strDataSetName02 = "COLUMNS"
                objDataSet02.Clear()
                gobjDb.GetDataSet(strDataSetName02, objDataSet02)
                Dim strCOLUMN_NAME As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COLUMN_NAME"))          '列名
                Dim strCOMMENTS As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("COMMENTS"))                'ｺﾒﾝﾄ
                Dim strDATA_TYPE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_TYPE"))              'ﾀｲﾌﾟ
                Dim strNN As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("NULLABLE"))                      'NULLABLE
                Dim strDATA_LENGTH As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_LENGTH"))          '列の長さ
                Dim strDATA_PRECISION As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_PRECISION"))    '精度
                Dim strDATA_SCALE As String = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("DATA_SCALE"))            '数値の小数点以下の桁
                If IsNotNull(strDATA_PRECISION) Then strDATA_LENGTH = strDATA_PRECISION
                If strNN <> "N" Then strNN = ""

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
                gobjDb.SQL = strSQL
                gobjDb.Parameter = objParameter
                strDataSetName02 = "PK"
                objDataSet02.Clear()
                gobjDb.GetDataSet(strDataSetName02, objDataSet02)
                If objDataSet02.Tables(strDataSetName02).Rows.Count > 0 Then
                    strPK = TO_STRING(objDataSet02.Tables(strDataSetName02).Rows(0)("CONSTRAINT_TYPE"))      'ﾌﾟﾗｲﾏﾘｰｷｰ
                End If

                '=====================================================
                'ﾃﾞｰﾀﾃｰﾌﾞﾙに追加
                '=====================================================
                objDataTable.userAddRowDataSet(strCOLUMN_NAME _
                                             , strCOMMENTS _
                                             , strDATA_TYPE _
                                             , strDATA_LENGTH _
                                             , strDATA_PRECISION _
                                             , strDATA_SCALE _
                                             , strPK _
                                             , strNN _
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
        '' ''grdTableData.RowHeadersVisible = False                                     '行ﾍｯﾀﾞｰ表示        許可設定
        grdTableData.AllowUserToResizeRows = False                                      '行のｻｲｽﾞ変更       許可設定
        '' ''grdTableData.AllowUserToResizeColumns = False                              '列のｻｲｽﾞ変更       許可設定
        '' ''grdTableData.MultiSelect = False                                           '複数ｾﾙ同時選択     許可設定
        grdTableData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect          '選択ﾓｰﾄﾞ
        '' ''grdTableData.AllowUserToAddRows = False                                    '行追加             許可設定
        '' ''grdTableData.AllowUserToDeleteRows = False                                 '行削除             許可設定
        grdTableData.AllowUserToOrderColumns = True                                     '列移動             許可設定
        grdTableData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)        '列の幅自動調整
        grdTableData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText      'ｸﾘｯﾌﾟﾎﾞｰﾄﾞへのｺﾋﾟｰ設定
        For Each objColum As DataGridViewColumn In grdTableData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next
        'grdTableData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0)          '列ﾍｯﾀﾞ背景色
        'grdTableData.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0)    '列ﾍｯﾀﾞ文字色


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
        grdColumnData.MultiSelect = True                                          '複数ｾﾙ同時選択     許可設定
        grdColumnData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect   '選択ﾓｰﾄﾞ
        grdColumnData.AllowUserToAddRows = False                                  '行追加             許可設定
        grdColumnData.AllowUserToDeleteRows = False                               '行削除             許可設定
        grdColumnData.AllowUserToResizeRows = False                               '行ｻｲｽﾞ変更         許可設定
        grdColumnData.AllowUserToOrderColumns = False                             '列移動             許可設定
        For Each objColum As DataGridViewColumn In grdColumnData.Columns
            objColum.SortMode = DataGridViewColumnSortMode.Programmatic     '列の並替禁止
        Next
        grdColumnData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText     'ｸﾘｯﾌﾟﾎﾞｰﾄﾞへのｺﾋﾟｰ設定


        '***********************
        'ﾍｯﾀﾞｰ表示変更
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).HeaderText = "列名"
        grdColumnData.Columns(menmListCol.COMMENTS).HeaderText = "ｺﾒﾝﾄ"
        grdColumnData.Columns(menmListCol.DATA_TYPE).HeaderText = "ﾀｲﾌﾟ"
        grdColumnData.Columns(menmListCol.DATA_LENGTH).HeaderText = "列の長さ"
        grdColumnData.Columns(menmListCol.DATA_PRECISION).HeaderText = "精度"
        grdColumnData.Columns(menmListCol.DATA_SCALE).HeaderText = "小数点桁数"
        grdColumnData.Columns(menmListCol.PK).HeaderText = "PK"
        grdColumnData.Columns(menmListCol.NN).HeaderText = "NN"


        '***********************
        'ﾃﾞｰﾀ部配置変更
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.COMMENTS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_TYPE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdColumnData.Columns(menmListCol.DATA_LENGTH).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.DATA_PRECISION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.DATA_SCALE).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdColumnData.Columns(menmListCol.PK).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdColumnData.Columns(menmListCol.NN).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        '***********************
        '非表示
        '***********************
        grdColumnData.Columns(menmListCol.DATA_PRECISION).Visible = False
        grdColumnData.Columns(menmListCol.Data08).Visible = False
        grdColumnData.Columns(menmListCol.Data09).Visible = False
        grdColumnData.Columns(menmListCol.Data10).Visible = False
        grdColumnData.Columns(menmListCol.Data11).Visible = False
        grdColumnData.Columns(menmListCol.Data12).Visible = False
        grdColumnData.Columns(menmListCol.Data13).Visible = False
        grdColumnData.Columns(menmListCol.Data14).Visible = False
        grdColumnData.Columns(menmListCol.Data15).Visible = False
        grdColumnData.Columns(menmListCol.Data16).Visible = False
        grdColumnData.Columns(menmListCol.Data17).Visible = False
        grdColumnData.Columns(menmListCol.Data18).Visible = False
        grdColumnData.Columns(menmListCol.Data19).Visible = False
        grdColumnData.Columns(menmListCol.Data20).Visible = False


        '***********************
        '列幅調整
        '***********************
        grdColumnData.Columns(menmListCol.COLUMN_NAME).Width = 120
        grdColumnData.Columns(menmListCol.COMMENTS).Width = 129
        grdColumnData.Columns(menmListCol.DATA_TYPE).Width = 80
        grdColumnData.Columns(menmListCol.DATA_LENGTH).Width = 30
        grdColumnData.Columns(menmListCol.DATA_PRECISION).Width = 30
        grdColumnData.Columns(menmListCol.DATA_SCALE).Width = 30
        grdColumnData.Columns(menmListCol.PK).Width = 20
        grdColumnData.Columns(menmListCol.NN).Width = 20


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

            Dim strValue As String = TO_STRING(grdTableData.Item(ii, intRow).EditedFormattedValue)
            If strValue = "" Then
                strSQLValue &= vbCrLf & "    ,Null"
            Else
                strSQLValue &= vbCrLf & "    ," & GetStringSQLData(strValue, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
            End If

            If ii = 0 Then
                strSQLValue = Replace(strSQLValue, vbCrLf, "")
                strSQLValue = Replace(strSQLValue, ",", " ", 1, 1)
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
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "【" & strSQL & "】"
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
        strSQL &= strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "【" & strSQL & "】"
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
                strSQLSet = Replace(strSQLSet, ",", " ", 1, 1)
            End If

        Next


        ''********************************************************************
        ''SQL文Where句部分作成
        ''********************************************************************
        'Dim strSQLWhere As String = ""                    'SQL文
        'For ii As Integer = 0 To grdColumnData.RowCount - 1
        '    '(ﾙｰﾌﾟ:列数)

        '    If grdColumnData.Item(menmListCol.PK, ii).Value = CONSTRAINT_TYPE_PK Then
        '        '(ﾌﾟﾗｲﾏﾘｰｷｰの場合)
        '        strSQLWhere &= vbCrLf & "    AND " & grdColumnData.Item(menmListCol.COLUMN_NAME, ii).Value & " = "
        '        strSQLWhere &= GetStringSQLData(grdTableData.Item(ii, intRow).Value, grdColumnData.Item(menmListCol.DATA_TYPE, ii).Value)
        '    End If

        'Next


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
        strSQL &= mstrSQLUpdateWhere
        'strSQL &= vbCrLf & strSQLWhere
        strSQL &= vbCrLf
        intRetSQL = gobjDb.Execute(strSQL)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & gobjDb.ErrMsg & "【" & strSQL & "】"
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
    '内部関数(その他)
#Region "　ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾃｰﾌﾞﾙ名)  の検索処理  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾃｰﾌﾞﾙ名)      の検索処理
    ''' </summary>
    ''' <param name="strTableName">ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾃｰﾌﾞﾙ名)</param>
    ''' <param name="strFieldNameWhere">ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾌｨｰﾙﾄﾞ名(条件))</param>
    ''' <param name="strFieldNameOrder">ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾌｨｰﾙﾄﾞ名(並び))</param>
    ''' <returns>
    ''' OK :定義あり
    ''' NO:定義なし
    ''' </returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SearchLogDispDefine(ByVal strTableName As String _
                                       , Optional ByRef strFieldNameWhere As String = "" _
                                       , Optional ByRef strFieldNameOrder As String = "" _
                                       ) _
                                       As RetCode
        Dim intReturn As RetCode = RetCode.NotFound     '戻り値


        '*******************************************************
        'ﾛｸﾞﾃｰﾌﾞﾙ表示定義数ﾙｰﾌﾟ
        '*******************************************************
        For Each objLogDispConfig As strcLogDispConfig In mobjAryLogDispConfig
            '(ﾙｰﾌﾟ:ﾛｸﾞﾃｰﾌﾞﾙ表示定義数)


            '*******************************************************
            'ﾃｰﾌﾞﾙ名が見つかった場合
            '*******************************************************
            If strTableName = objLogDispConfig.strTableName Then
                '(ﾛｸﾞﾃｰﾌﾞﾙ表示定義されていた場合)
                strFieldNameWhere = objLogDispConfig.strFieldNameWhere
                strFieldNameOrder = objLogDispConfig.strFieldNameOrder
                intReturn = RetCode.OK
                Exit For
            End If


        Next


        Return intReturn
    End Function
#End Region
#Region "  ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾌｨｰﾙﾄﾞ名) の検索処理  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾌｨｰﾙﾄﾞ名)     の検索処理
    ''' </summary>
    ''' <param name="strFieldName">ﾛｸﾞﾃｰﾌﾞﾙ表示定義名(ﾌｨｰﾙﾄﾞ名)</param>
    ''' <param name="intColIndex">ﾌｨｰﾙﾄﾞの列ｲﾝﾃﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchFieldIndex(ByVal strFieldName As String _
                               , ByRef intColIndex As Integer _
                               )


        '*******************************************************
        'ﾃｰﾌﾞﾙの列数ﾙｰﾌﾟ
        '*******************************************************
        For jj As Integer = 0 To grdColumnData.ColumnCount - 1
            '(ﾙｰﾌﾟ:ﾃｰﾌﾞﾙの列数)


            '*******************************************************
            'ﾌｨｰﾙﾄﾞ名が見つかった場合
            '*******************************************************
            If grdColumnData.Item(menmListCol.COLUMN_NAME, jj).Value = strFieldName Then
                '(ﾌｨｰﾙﾄﾞが一致していた場合)

                intColIndex = jj
                Exit For

            End If


            If jj = (grdColumnData.ColumnCount - 1) Then Throw New Exception("Configﾌｧｲﾙのﾛｸﾞﾃｰﾌﾞﾙ表示定義が不正です。ﾌｨｰﾙﾄﾞ名が見つかりません。")
        Next


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
            Call ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class