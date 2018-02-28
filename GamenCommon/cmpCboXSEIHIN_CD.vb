'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】製品品番ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ ｶｽﾀﾑｺﾝﾄﾛｰﾙ
' 【機能】何らかのｷｰ入力があった場合のみ、入力された値を元に下記処理を実行する
'           製品品番ｺｰﾄﾞを検索し、製品品番ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽのﾘｽﾄをｾｯﾄ
'           製品品番ｺｰﾄﾞに対応する名称、色名称を取得･表示
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon
Imports MateCommon.clsConst
#End Region

Public Class cmpCboXSEIHIN_CD

#Region "  ｸﾗｽ変数定義                      "

    Private mstrSQL As String                           'SQL文
    Private mstrTableName As String                     'ﾃｰﾌﾞﾙ名
    Private mobjDb As clsConn                           'ｺﾈｸｼｮﾝ
    Private mblnKeyPressFlg As Boolean                  'ｷｰﾌﾟﾚｽｲﾍﾞﾝﾄ
    Private mintCol1Width As Integer = 150              'Col1の列幅
    Private mblnSeihinmeiVisible As Boolean = True         '品名列表示ﾌﾗｸﾞ
    Private mobjSeihinmeiLabel As Windows.Forms.Label = Nothing  '製品名ﾗﾍﾞﾙ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                      "
    '====================================
    ' ｺﾈｸｼｮﾝｵﾌﾞｼﾞｪｸﾄ
    '====================================
    Public Property conn() As clsConn
        Get
            Return mobjDb
        End Get
        Set(ByVal Value As clsConn)
            mobjDb = Value
        End Set
    End Property
    '====================================
    ' Col1列幅
    '====================================
    Public Property Col1Width() As Integer
        Get
            Return mintCol1Width
        End Get
        Set(ByVal Value As Integer)
            mintCol1Width = Value
        End Set
    End Property
    '====================================
    ' 品名列表示設定
    '====================================
    Public Property SeihinmeiVisible() As Boolean
        Get
            Return mblnSeihinmeiVisible
        End Get
        Set(ByVal Value As Boolean)
            mblnSeihinmeiVisible = Value
        End Set
    End Property
    '====================================
    ' 製品名ﾗﾍﾞﾙ
    '====================================
    Public Property SeihinmeiLabel() As Windows.Forms.Label
        Get
            Return mobjSeihinmeiLabel
        End Get
        Set(ByVal Value As Windows.Forms.Label)
            mobjSeihinmeiLabel = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。


        '***********************************************************************
        'ｸﾗｽ変数の初期化
        '***********************************************************************
        mstrSQL = ""
        mstrTableName = "XMST_SEIHIN"


        '*******************************************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ設定用ｶﾗﾑ作成処理
        '*******************************************************************
        Dim objComboTable As New DataTable()

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


    End Sub
#End Region
#Region "  ｲﾍﾞﾝﾄ                            "
#Region "　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示   ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示   ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmpCboXSEIHIN_CD_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDown

        Call cmbDropDownOpenProccess()

    End Sub
#End Region
#Region "  ﾃｷｽﾄﾁｪﾝｼﾞ        ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmpCboXSEIHIN_CD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged

        If IsNothing(mobjSeihinmeiLabel) = False Then
            '(製品名ﾗﾍﾞﾙが設定されている場合)
            Call lblTextSet()
        End If

    End Sub
#End Region
#Region "　"
    Private Sub cmpCboXSEIHIN_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If mblnSeihinmeiVisible = True Then
            Me.Text = Me.SelectedValue.ToString
        End If
    End Sub
#End Region
#End Region
#Region "　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示   ｲﾍﾞﾝﾄ処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmbDropDownOpenProccess()

        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄにﾃﾞｰﾀをｾｯﾄ
        Call cboSetupSeihinCd(Me.Text)


    End Sub
#End Region
#Region "  製品ｺｰﾄﾞﾘｽﾄのｾｯﾄ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 製品ｺｰﾄﾞﾘｽﾄ
    ''' </summary>
    ''' <param name="strSeihinCd">製品ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboSetupSeihinCd(ByVal strSeihinCd As String)

        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名

        Dim objComboTable As New DataTable()
        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If

        ''********************************************************************
        '' 表示する品名情報の取得
        ''********************************************************************
        mstrSQL = ""
        mstrSQL &= vbCrLf & " SELECT DISTINCT "
        mstrSQL &= vbCrLf & "     " & mstrTableName & ".XProductCodeFinal "             '製品品番ｺｰﾄﾞ
        mstrSQL &= vbCrLf & "   , " & mstrTableName & ".XSEIHINMEI "                    '製品名
        mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
        mstrSQL &= vbCrLf & " WHERE 0 = 0 "
        mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".XProductCodeFinal LIKE '" & strSeihinCd & "%' "  '前方一致
        mstrSQL &= vbCrLf & " GROUP BY "
        mstrSQL &= vbCrLf & "     " & mstrTableName & ".XProductCodeFinal "             '製品品番ｺｰﾄﾞ
        mstrSQL &= vbCrLf & "   , " & mstrTableName & ".XSEIHINMEI "                    '製品名
        mstrSQL &= vbCrLf & " ORDER BY  "
        mstrSQL &= vbCrLf & "    " & mstrTableName & ".XProductCodeFinal "              '製品品番ｺｰﾄﾞ

        mobjDb.SQL = mstrSQL

        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XProductCodeFinal"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("XSEIHINMEI"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = SubItem1

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        Me.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        Me.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        Me.ValueMember = "ID"


        Me.EndUpdate()      'まとめて描画

        Me.Text = strSeihinCd


    End Sub
#End Region
#Region "  製品名ﾗﾍﾞﾙ表示処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 製品名ﾗﾍﾞﾙ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblTextSet()

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If


        '********************************************************************
        ' 表示する製品名の取得
        '********************************************************************
        mstrSQL = ""
        mstrSQL &= vbCrLf & " SELECT DISTINCT "
        mstrSQL &= vbCrLf & "     " & mstrTableName & ".XProductCodeFinal "             '製品品番ｺｰﾄﾞ
        mstrSQL &= vbCrLf & "   , " & mstrTableName & ".XSEIHINMEI "                    '製品名
        mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
        mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".XProductCodeFinal = '" & Me.Text & "' "
        mstrSQL &= vbCrLf & " ORDER BY  "
        mstrSQL &= vbCrLf & "    " & mstrTableName & ".XProductCodeFinal "              '製品品番ｺｰﾄﾞ

        mobjDb.SQL = mstrSQL

        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
            '(品名が取得できなかった場合)
            mobjSeihinmeiLabel.Text = ""
        Else
            '(品名が取得できた場合)
            mobjSeihinmeiLabel.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows(0).Item("XSEIHINMEI"))
        End If


    End Sub
#End Region

End Class
