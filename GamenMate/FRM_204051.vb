'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】作業履歴詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_204051

#Region "　共通変数　                               "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrFLOG_NO As String       'ﾛｸﾞ№

    '共通変数
    Private mstrTableName As String     'ﾃｰﾌﾞﾙ名

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FDENBUN_ITEM_NAME               'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.   電文ｱｲﾃﾑ名称
        FDENBUN_ITEM_DATA               'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.   電文ｱｲﾃﾑﾃﾞｰﾀ

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義                               "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FLOG_NO As String               'ﾛｸﾞ№
    End Structure
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨ                                  "
    ''' =======================================
    ''' <summary>ﾛｸﾞ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFLOG_NO() As String
        Get
            Return mstrFLOG_NO
        End Get
        Set(ByVal value As String)
            mstrFLOG_NO = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_204051_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_204051_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　確認   　 ﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 確認 ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()


        '*********************************************
        ' ﾌｫｰﾑ名ｾｯﾄ
        '*********************************************
        If Me.Name = "FRM_204051" Then
            Me.Text = "作業履歴詳細"
            mstrTableName = "TEVD_OPE_DTL"
        Else
            Me.Text = "オペレーションログ詳細"
            mstrTableName = "TLOG_OPE_DTL"
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplay()


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************


    End Sub
#End Region
#Region "　確認         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 確認 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        Me.Close()

    End Sub
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
        '===============================================
        'ﾛｸﾞ№
        '===============================================
        mudtSEARCH_ITEM.FLOG_NO = mstrFLOG_NO           'ﾛｸﾞ№


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    " & mstrTableName & ".FDENBUN_ITEM_NAME "    'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.   電文ｱｲﾃﾑ名称
        strSQL &= vbCrLf & "  , " & mstrTableName & ".FDENBUN_ITEM_DATA "    'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.   電文ｱｲﾃﾑﾃﾞｰﾀ
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & mstrTableName & " "                      'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        '----------------------------
        'ﾛｸﾞ№
        '----------------------------
        strSQL &= vbCrLf & "    AND " & mstrTableName & ".FLOG_NO = '" & mudtSEARCH_ITEM.FLOG_NO & "' "  'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.    ﾛｸﾞ№
        strSQL &= vbCrLf & "    AND " & mstrTableName & ".FDENBUN_ITEM_NAME IS NOT NULL "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    " & mstrTableName & ".FORDER "               'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ詳細.   表示順
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
        '列幅自動調節
        '************************************************
        grdList.Columns(grdList.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region

End Class
