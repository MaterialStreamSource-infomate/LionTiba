'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷引当詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308051

#Region "　共通変数　                               "

    Private mstrFHINMEI_CD As String                     '品名ｺｰﾄﾞ
    Private mstrFHINMEI As String                        '品名
    Private mstrXSEIZOU_DT As String                     '製造年月日
    Private mstrXHINSHITU_STS As String                  '品質ｽﾃｰﾀｽ

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '背景色
    Private Color_BackColor_FRETPLAN_NUM As Color = Color.White         'ｸﾞﾘｯﾄﾞ背景色(返却予定数)
    Private Color_BackColor_ETC As Color = Color.LightGray              'ｸﾞﾘｯﾄﾞ背景色(その他)

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XORDER_NO                           '発注№
        XSYUKKA_NO                          '出荷№
        FHINMEI_CD                          '品名ｺｰﾄﾞ
        XSEIZOU_DT                          '製造年月日
        XHINSHITU_STS                       '品質ｽﾃｰﾀｽ
        XIDOU_CD                            '移動手段ｺｰﾄﾞ
        XIDOU_NM                            '移動手段名
        TAHINMOK                            '構内他品目出荷
        BARA                                '構内ﾊﾞﾗ出荷
        BARA_DSP                            '構内ﾊﾞﾗ出荷(表示用)
        XSYUKKA_VOL                         '出荷PL数
        FNUM_IN_PALLET                      'PL毎積載数
        ASOUKO                              '引当PL数・自動倉庫
        HIRA                                '引当PL数・平置
        GAIBU1                              '引当PL数・外部倉庫1
        GAIBU2                              '引当PL数・外部倉庫2
        GAIBU3                              '引当PL数・外部倉庫3
        GAIBU4                              '引当PL数・外部倉庫4
        GAIBU5                              '引当PL数・外部倉庫5
        GAIBU6                              '引当PL数・外部倉庫6
        GAIBU7                              '引当PL数・外部倉庫7
        GAIBU8                              '引当PL数・外部倉庫8
        GAIBU9                              '引当PL数・外部倉庫9
        GAIBU10                             '引当PL数・外部倉庫10

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        KeisanBtn1_Click      '計算ﾎﾞﾀﾝｸﾘｯｸ時
        KeisanBtn2_Click      '計算ﾎﾞﾀﾝｸﾘｯｸ時
        SaiHikiateBtn_Click   '再引当ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' 品名ｺｰﾄﾞ
    '======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    '======================================
    ' 品名
    '======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    '======================================
    ' 製造年月日
    '======================================
    Public Property userXSEIZOU_DT() As String
        Get
            Return mstrXSEIZOU_DT
        End Get
        Set(ByVal value As String)
            mstrXSEIZOU_DT = value
        End Set
    End Property

    '======================================
    ' 品質ｽﾃｰﾀｽ
    '======================================
    Public Property userXHINSHITU_STS() As String
        Get
            Return mstrXHINSHITU_STS
        End Get
        Set(ByVal value As String)
            mstrXHINSHITU_STS = value
        End Set
    End Property

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ｾﾙｽﾀｲﾙ変更                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙｽﾀｲﾙ変更
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdList.CellFormatting
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)

            'ｾﾙの列を確認
            If (dgv.Columns(e.ColumnIndex).Index = menmListCol.ASOUKO) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.HIRA) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU1) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU2) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU3) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU4) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU5) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU6) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU7) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU8) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU9) Or _
               (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU10) Then
                '(入力ｾﾙのとき、背景色を変更する)
                dgv(e.ColumnIndex, e.RowIndex).Style.BackColor = Color_BackColor_FRETPLAN_NUM
                dgv(e.ColumnIndex, e.RowIndex).Style.SelectionForeColor = Color.White
                dgv(e.ColumnIndex, e.RowIndex).Style.SelectionBackColor = SystemColors.ActiveCaption
            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｾﾙﾛｽﾄﾌｫｰｶｽ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙﾛｽﾄﾌｫｰｶｽ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellLeave
        Try

            Dim dgv As DataGridView = CType(sender, DataGridView)

            If e.RowIndex >= 0 Then
                '(ﾍｯﾀﾞｰ以外のとき)
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.ASOUKO) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.HIRA) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU1) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU2) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU3) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU4) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU5) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU6) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU7) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU8) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU9) Or _
                   (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU10) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = "0"
                    End If
                    If dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Length > 4 Then
                        '(4桁より大きいとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Substring(0, 4)
                    End If

                End If
            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｾﾙﾊﾞﾘｭｰﾁｪﾝｼﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙﾊﾞﾘｭｰﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellValueChanged
        Try

            Dim dgv As DataGridView = CType(sender, DataGridView)

            If e.RowIndex >= 0 Then
                '(ﾍｯﾀﾞｰ以外のとき)
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.ASOUKO) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.HIRA) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU1) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU2) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU3) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU4) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU5) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU6) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU7) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU8) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU9) Or _
                    (dgv.Columns(e.ColumnIndex).Index = menmListCol.GAIBU10) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = "0"
                    End If
                    If dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Length > 4 Then
                        '(4桁より大きいとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Substring(0, 4)
                    End If

                End If
            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ


        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ表示
        '**********************************************************
        lblFHINMEI_CD.Text = mstrFHINMEI_CD         '品名ｺｰﾄﾞ
        lblFHINMEI.Text = mstrFHINMEI               '品名
        lblXSEIZOU_DT.Text = mstrXSEIZOU_DT         '製造年月日

        '*********************************************
        ' 品質ｽﾃｰﾀｽ　表示
        '*********************************************
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim strXHINSHITU_STS_DSP As String = ""       '品質ｽﾃｰﾀｽ(表示用)

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT"
        strSQL &= vbCrLf & "     FDISP_VALUE "
        strSQL &= vbCrLf & "   , FGAMEN_DISP "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TDSP_DISP "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND FTABLE_NAME = 'TRST_STOCK' "
        strSQL &= vbCrLf & "   AND FFIELD_NAME = 'XHINSHITU_STS' "
        strSQL &= vbCrLf & "   AND FDISP_VALUE = '" & mstrXHINSHITU_STS & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     FDISP_VALUE "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_DISP"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            strXHINSHITU_STS_DSP = TO_STRING(objRow("FGAMEN_DISP"))
        Else
            '(見つからない場合)
            strXHINSHITU_STS_DSP = ""
        End If

        lblXHINSHITU_STS.Text = strXHINSHITU_STS_DSP   '品質ｽﾃｰﾀｽ


        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        grdList.ColumnHeadersVisible = False
        Call grdListDisplaySub(grdList)

        '**********************************************************
        ' 合計表示
        '**********************************************************
        Call GoukeiDisplay()

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F6(計算)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.KeisanBtn1_Click) = False Then
            Exit Sub
        End If


        ''**********************************************************
        '' ﾘｽﾄ表示
        ''**********************************************************
        'Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        'grdList.ColumnHeadersVisible = False
        'Call grdListDisplaySub(grdList)

        '**********************************************************
        ' 合計表示
        '**********************************************************
        Call GoukeiDisplay()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.KeisanBtn2_Click) = False Then
            Exit Sub
        End If

    End Sub
#End Region
#Region "  F7(再引当)         ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.KeisanBtn1_Click) = False Then
            Exit Sub
        End If

        '**********************************************************
        ' 合計表示
        '**********************************************************
        Call GoukeiDisplay()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.KeisanBtn2_Click) = False Then
            Exit Sub
        End If

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.SaiHikiateBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If SendSocket02() = False Then
            Exit Sub
        End If


        Me.Close()

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        Me.Close()

    End Sub
#End Region
#Region "　ﾘｽﾄ表示　                                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()


        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     B.XORDER_NO "                          '発注№
        strSQL &= vbCrLf & "   , B.XSYUKKA_NO "                         '出荷№
        strSQL &= vbCrLf & "   , B.FHINMEI_CD "                         '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , B.XSEIZOU_DT "                         '製造年月日
        strSQL &= vbCrLf & "   , B.XHINSHITU_STS "                      '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , B.XIDOU_CD "                           '移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , B.XIDOU_NM "                           '移動手段名
        strSQL &= vbCrLf & "   , B.TAHINMOK "                           '構内他品目出荷
        strSQL &= vbCrLf & "   , B.BARA "                               '構内ﾊﾞﾗ出荷
        strSQL &= vbCrLf & "   , B.BARA_DSP "                           '構内ﾊﾞﾗ出荷(表示用)
        strSQL &= vbCrLf & "   , B.XSYUKKA_PL_SU "                      '出荷PL数
        strSQL &= vbCrLf & "   , B.FNUM_IN_PALLET "                     'PL毎積載数
        strSQL &= vbCrLf & "   , B.ASOUKO "                             '引当PL数・自動倉庫
        strSQL &= vbCrLf & "   , B.HIRA "                               '引当PL数・平置
        strSQL &= vbCrLf & "   , B.GAIBU1 "                             '引当PL数・外部倉庫1
        strSQL &= vbCrLf & "   , B.GAIBU2 "                             '引当PL数・外部倉庫2
        strSQL &= vbCrLf & "   , B.GAIBU3 "                             '引当PL数・外部倉庫3
        strSQL &= vbCrLf & "   , B.GAIBU4 "                             '引当PL数・外部倉庫4
        strSQL &= vbCrLf & "   , B.GAIBU5 "                             '引当PL数・外部倉庫5
        strSQL &= vbCrLf & "   , B.GAIBU6 "                             '引当PL数・外部倉庫6
        strSQL &= vbCrLf & "   , B.GAIBU7 "                             '引当PL数・外部倉庫7
        strSQL &= vbCrLf & "   , B.GAIBU8 "                             '引当PL数・外部倉庫8
        strSQL &= vbCrLf & "   , B.GAIBU9 "                             '引当PL数・外部倉庫9
        strSQL &= vbCrLf & "   , B.GAIBU10 "                            '引当PL数・外部倉庫10

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   ( "

        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     A.XORDER_NO "                          '発注№
        strSQL &= vbCrLf & "   , A.XSYUKKA_NO "                         '出荷№
        strSQL &= vbCrLf & "   , A.FHINMEI_CD "                         '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , A.XSEIZOU_DT "                         '製造年月日
        strSQL &= vbCrLf & "   , A.XHINSHITU_STS "                      '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , A.XIDOU_CD "                           '移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , A.XIDOU_NM "                           '移動手段名
        strSQL &= vbCrLf & "   , A.TAHINMOK "                           '構内他品目出荷
        strSQL &= vbCrLf & "   , A.BARA "                               '構内ﾊﾞﾗ出荷
        strSQL &= vbCrLf & "   , A.BARA_DSP "                           '構内ﾊﾞﾗ出荷(表示用)
        strSQL &= vbCrLf & "   , SUM(A.XSYUKKA_PL_SU)   AS XSYUKKA_PL_SU "    '出荷PL数
        strSQL &= vbCrLf & "   , A.FNUM_IN_PALLET "                     'PL毎積載数
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_ASOUKO)  AS ASOUKO "     '引当PL数・自動倉庫
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_HIRA)    AS HIRA "       '引当PL数・平置
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU1)  AS GAIBU1 "     '引当PL数・外部倉庫1
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU2)  AS GAIBU2 "     '引当PL数・外部倉庫2
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU3)  AS GAIBU3 "     '引当PL数・外部倉庫3
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU4)  AS GAIBU4 "     '引当PL数・外部倉庫4
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU5)  AS GAIBU5 "     '引当PL数・外部倉庫5
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU6)  AS GAIBU6 "     '引当PL数・外部倉庫6
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU7)  AS GAIBU7 "     '引当PL数・外部倉庫7
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU8)  AS GAIBU8 "     '引当PL数・外部倉庫8
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU9)  AS GAIBU9 "     '引当PL数・外部倉庫9
        strSQL &= vbCrLf & "   , SUM(A.HIKIATE_GAIBU10) AS GAIBU10 "    '引当PL数・外部倉庫10

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   ( "

        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J9000            '自動倉庫
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8001            '1F平置き
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8100            '外部倉庫1
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8101            '外部倉庫2
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8102            '外部倉庫3
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8103            '外部倉庫4
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8104            '外部倉庫5
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8105            '外部倉庫6
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8106            '外部倉庫7
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8107            '外部倉庫8
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8108            '外部倉庫9
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "


        strSQL &= vbCrLf & "   UNION ALL "
        strSQL &= vbCrLf & "   SELECT "
        strSQL &= vbCrLf & "       XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
        strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_CD "
        strSQL &= vbCrLf & "     , XPLN_OUT.XIDOU_NM "
        strSQL &= vbCrLf & "     , NULL AS TAHINMOK "
        strSQL &= vbCrLf & "     , 0    AS BARA "
        strSQL &= vbCrLf & "     , '　' AS BARA_DSP "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS XSYUKKA_PL_SU "
        strSQL &= vbCrLf & "     , TMST_ITEM.FNUM_IN_PALLET "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_ASOUKO "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_HIRA "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU1 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU2 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU3 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU4 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU5 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU6 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU7 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU8 "
        strSQL &= vbCrLf & "     , 0                         AS HIKIATE_GAIBU9 "
        strSQL &= vbCrLf & "     , TRUNC(XRST_STOCK_K2.FTR_RES_VOL / TMST_ITEM.FNUM_IN_PALLET) AS HIKIATE_GAIBU10 "
        strSQL &= vbCrLf & "   FROM "
        strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
        strSQL &= vbCrLf & "     , XPLN_OUT "               '出荷計画
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
        strSQL &= vbCrLf & "     , TMST_ITEM "              '品目ﾏｽﾀ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        strSQL &= vbCrLf & "   WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & mstrFHINMEI_CD & "%' "   '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & mstrXHINSHITU_STS            '品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     AND NVL(XRST_STOCK_K2.FHASU_FLAG,0) = " & FHASU_FLAG_SMANSU            '満数

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO        = " & FTRK_BUF_NO_J8109            '外部倉庫10
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        = TMST_ITEM.FHINMEI_CD(+) "

        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_SOUT            '計画出庫

        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = XPLN_OUT.XSYUKKA_NO "

        strSQL &= vbCrLf & "     ) A "

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     A.XORDER_NO "
        strSQL &= vbCrLf & "   , A.XSYUKKA_NO "
        strSQL &= vbCrLf & "   , A.FHINMEI_CD "
        strSQL &= vbCrLf & "   , A.XSEIZOU_DT "
        strSQL &= vbCrLf & "   , A.XHINSHITU_STS "
        strSQL &= vbCrLf & "   , A.XIDOU_CD "
        strSQL &= vbCrLf & "   , A.XIDOU_NM "
        strSQL &= vbCrLf & "   , A.TAHINMOK "
        strSQL &= vbCrLf & "   , A.BARA "
        strSQL &= vbCrLf & "   , A.BARA_DSP "
        strSQL &= vbCrLf & "   , A.FNUM_IN_PALLET "

        strSQL &= vbCrLf & "     ) B "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                True)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


        '********************************************************************
        '構内他品目出荷 設定
        '********************************************************************
        Call Set_Kounai_TaHinmoku()

        '********************************************************************
        '構内バラ出荷 設定
        '********************************************************************
        Call Set_Kounai_Bara()

    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定　                            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        '=========================================
        '編集ﾓｰﾄﾞ
        '=========================================
        grdList.SelectionMode = DataGridViewSelectionMode.CellSelect
        grdList.ReadOnly = False

        grdList.Columns(menmListCol.XSYUKKA_NO).ReadOnly = True          '出荷№
        grdList.Columns(menmListCol.XIDOU_CD).ReadOnly = True            '移動手段ｺｰﾄﾞ
        grdList.Columns(menmListCol.TAHINMOK).ReadOnly = True            '構内他品目出荷
        grdList.Columns(menmListCol.BARA).ReadOnly = True                '構内ﾊﾞﾗ出荷
        grdList.Columns(menmListCol.XSYUKKA_VOL).ReadOnly = True         '出荷PL数

        grdList.DefaultCellStyle.BackColor = Color_BackColor_ETC               'ｸﾞﾘｯﾄﾞ背景色(その他)
        grdList.DefaultCellStyle.SelectionBackColor = Color_BackColor_ETC      'ｸﾞﾘｯﾄﾞ選択時背景色(その他)
        grdList.DefaultCellStyle.SelectionForeColor = Color.Black

        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

        grdList.Columns(menmListCol.GAIBU10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill         '列幅自動調節
        grdList.AllowUserToResizeColumns = False                                                        '列のｻｲｽﾞ変更禁止


    End Sub
#End Region
#Region "  構内他品目出荷設定　                     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Set_Kounai_TaHinmoku()

        Dim strSQL As String = ""

        '********************************************************************
        '構内他品目出荷 設定
        '********************************************************************
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim strTAHIN As String = ""         '構内他品目出荷

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "     XSYUKKA_NO "
            strSQL &= vbCrLf & "   , (CASE SYKNO_CNT "
            strSQL &= vbCrLf & "      WHEN 0 THEN '　' "
            strSQL &= vbCrLf & "      WHEN 1 THEN '　' "
            strSQL &= vbCrLf & "      ELSE        '○' "
            strSQL &= vbCrLf & "      END "
            strSQL &= vbCrLf & "     ) AS TAHIN "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "   ( "
            strSQL &= vbCrLf & "    SELECT "
            strSQL &= vbCrLf & "       XPLN_OUT_DTL.XSYUKKA_NO "
            strSQL &= vbCrLf & "     , COUNT(0) AS SYKNO_CNT "
            strSQL &= vbCrLf & "    FROM "
            strSQL &= vbCrLf & "       XPLN_OUT_DTL "
            strSQL &= vbCrLf & "    WHERE 1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO  = '" & TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, ii).Value) & "' "
            strSQL &= vbCrLf & "    GROUP BY "
            strSQL &= vbCrLf & "       XPLN_OUT_DTL.XSYUKKA_NO "
            strSQL &= vbCrLf & "   ) A"


            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "A"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                strTAHIN = TO_STRING(objRow("TAHIN"))
            Else
                '(見つからない場合)
                strTAHIN = ""
            End If

            grdList.Item(menmListCol.TAHINMOK, ii).Value = strTAHIN

        Next

    End Sub
#End Region
#Region "  構内バラ出荷設定　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub Set_Kounai_Bara()

        Dim strSQL As String = ""

        '********************************************************************
        '構内バラ出荷 設定
        '********************************************************************
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        'Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim strBARA As String = ""         '構内ﾊﾞﾗ出荷

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       XPLN_OUT_DTL.XSYUKKA_NO "
            strSQL &= vbCrLf & "     , XRST_STOCK_K2.FHINMEI_CD "
            strSQL &= vbCrLf & "     , XRST_STOCK_K2.XSEIZOU_DT"
            strSQL &= vbCrLf & "     , XRST_STOCK_K2.XHINSHITU_STS "
            strSQL &= vbCrLf & "     , XRST_STOCK_K2.FPALLET_ID "
            strSQL &= vbCrLf & "     , XRST_STOCK_K2.FLOT_NO_STOCK "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2.FSAGYOU_KIND "
            strSQL &= vbCrLf & "     , 1 AS BARA "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XRST_STOCK_K2 "          '在庫情報_仮2
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K2 "        '在庫引当情報_仮2
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "           '出荷計画詳細
            strSQL &= vbCrLf & "   WHERE 1 = 1 "
            strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FHINMEI_CD        LIKE '" & TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, ii).Value) & "%' "   '品名ｺｰﾄﾞ
            strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XSEIZOU_DT        = TO_DATE('" & TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, ii).Value) & "', 'YYYY/MM/DD HH24:MI:SS') " '製造年月日
            strSQL &= vbCrLf & "     AND XRST_STOCK_K2.XHINSHITU_STS     = " & TO_STRING(grdList.Item(menmListCol.XHINSHITU_STS, ii).Value)            '品質ｽﾃｰﾀｽ

            strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FPALLET_ID        = XSTS_HIKIATE_K2.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XRST_STOCK_K2.FLOT_NO_STOCK     = XSTS_HIKIATE_K2.FLOT_NO_STOCK(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FSAGYOU_KIND    = " & FSAGYOU_KIND_JOUT_BARA       'バラ補充出庫

            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K2.FPLAN_KEY       = XPLN_OUT_DTL.FPLAN_KEY "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO         = '" & TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, ii).Value) & "' "   '出荷№

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT_DTL"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)
                'objRow = objDataSet.Tables(strDataSetName).Rows(0)

                grdList.Item(menmListCol.BARA, ii).Value = 1
                grdList.Item(menmListCol.BARA_DSP, ii).Value = "○"

            Else
                '(見つからない場合)
                grdList.Item(menmListCol.BARA, ii).Value = 0
                grdList.Item(menmListCol.BARA_DSP, ii).Value = "　"
            End If

        Next

    End Sub
#End Region
#Region "  合計表示    　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub GoukeiDisplay()

        If mFlag_Form_Load = True Then
            '(初期表示の時)
            Call ZaikoGoukeiDisplay()           '在庫合計表示
        End If

        '================================-
        ' 引当合計表示
        '================================-
        Dim intHIKIATE_GOUKEI As Integer = 0    '引当合計・合計
        Dim intHIKIATE_ASOUKO As Integer = 0    '引当合計・自動倉庫
        Dim intHIKIATE_HIRA As Integer = 0      '引当合計・平置き
        Dim intHIKIATE_GAIBU1 As Integer = 0    '引当合計・外部倉庫1
        Dim intHIKIATE_GAIBU2 As Integer = 0    '引当合計・外部倉庫2
        Dim intHIKIATE_GAIBU3 As Integer = 0    '引当合計・外部倉庫3
        Dim intHIKIATE_GAIBU4 As Integer = 0    '引当合計・外部倉庫4
        Dim intHIKIATE_GAIBU5 As Integer = 0    '引当合計・外部倉庫5
        Dim intHIKIATE_GAIBU6 As Integer = 0    '引当合計・外部倉庫6
        Dim intHIKIATE_GAIBU7 As Integer = 0    '引当合計・外部倉庫7
        Dim intHIKIATE_GAIBU8 As Integer = 0    '引当合計・外部倉庫8
        Dim intHIKIATE_GAIBU9 As Integer = 0    '引当合計・外部倉庫9
        Dim intHIKIATE_GAIBU10 As Integer = 0   '引当合計・外部倉庫10

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

            intHIKIATE_ASOUKO += TO_INTEGER(grdList.Item(menmListCol.ASOUKO, ii).Value)      '引当合計・自動倉庫
            intHIKIATE_HIRA += TO_INTEGER(grdList.Item(menmListCol.HIRA, ii).Value)          '引当合計・平置き
            intHIKIATE_GAIBU1 += TO_INTEGER(grdList.Item(menmListCol.GAIBU1, ii).Value)      '引当合計・外部倉庫1
            intHIKIATE_GAIBU2 += TO_INTEGER(grdList.Item(menmListCol.GAIBU2, ii).Value)      '引当合計・外部倉庫2
            intHIKIATE_GAIBU3 += TO_INTEGER(grdList.Item(menmListCol.GAIBU3, ii).Value)      '引当合計・外部倉庫3
            intHIKIATE_GAIBU4 += TO_INTEGER(grdList.Item(menmListCol.GAIBU4, ii).Value)      '引当合計・外部倉庫4
            intHIKIATE_GAIBU5 += TO_INTEGER(grdList.Item(menmListCol.GAIBU5, ii).Value)      '引当合計・外部倉庫5
            intHIKIATE_GAIBU6 += TO_INTEGER(grdList.Item(menmListCol.GAIBU6, ii).Value)      '引当合計・外部倉庫6
            intHIKIATE_GAIBU7 += TO_INTEGER(grdList.Item(menmListCol.GAIBU7, ii).Value)      '引当合計・外部倉庫7
            intHIKIATE_GAIBU8 += TO_INTEGER(grdList.Item(menmListCol.GAIBU8, ii).Value)      '引当合計・外部倉庫8
            intHIKIATE_GAIBU9 += TO_INTEGER(grdList.Item(menmListCol.GAIBU9, ii).Value)      '引当合計・外部倉庫9
            intHIKIATE_GAIBU10 += TO_INTEGER(grdList.Item(menmListCol.GAIBU10, ii).Value)    '引当合計・外部倉庫10

        Next

        '引当合計・合計
        intHIKIATE_GOUKEI = intHIKIATE_ASOUKO + intHIKIATE_HIRA + intHIKIATE_GAIBU1 + _
                            intHIKIATE_GAIBU2 + intHIKIATE_GAIBU3 + intHIKIATE_GAIBU4 + _
                            intHIKIATE_GAIBU5 + intHIKIATE_GAIBU6 + intHIKIATE_GAIBU7 + _
                            intHIKIATE_GAIBU8 + intHIKIATE_GAIBU9 + intHIKIATE_GAIBU10

        lblHIKIATE_GOUKEI.Text = intHIKIATE_GOUKEI          '引当合計・合計
        lblHIKIATE_ASOUKO.Text = intHIKIATE_ASOUKO          '引当合計・自動倉庫
        lblHIKIATE_HIRA.Text = intHIKIATE_HIRA              '引当合計・平置き
        lblHIKIATE_GAIBU1.Text = intHIKIATE_GAIBU1          '引当合計・外部倉庫1
        lblHIKIATE_GAIBU2.Text = intHIKIATE_GAIBU2          '引当合計・外部倉庫2
        lblHIKIATE_GAIBU3.Text = intHIKIATE_GAIBU3          '引当合計・外部倉庫3
        lblHIKIATE_GAIBU4.Text = intHIKIATE_GAIBU4          '引当合計・外部倉庫4
        lblHIKIATE_GAIBU5.Text = intHIKIATE_GAIBU5          '引当合計・外部倉庫5
        lblHIKIATE_GAIBU6.Text = intHIKIATE_GAIBU6          '引当合計・外部倉庫6
        lblHIKIATE_GAIBU7.Text = intHIKIATE_GAIBU7          '引当合計・外部倉庫7
        lblHIKIATE_GAIBU8.Text = intHIKIATE_GAIBU8          '引当合計・外部倉庫8
        lblHIKIATE_GAIBU9.Text = intHIKIATE_GAIBU9          '引当合計・外部倉庫9
        lblHIKIATE_GAIBU10.Text = intHIKIATE_GAIBU10        '引当合計・外部倉庫10

    End Sub
#End Region
#Region "  合計表示(在庫合計)                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub ZaikoGoukeiDisplay()

        Dim intZAIKO_GOUKEI As Integer = 0            '在庫合計・合計
        Dim intZAIKO_ASOUKO As Integer = 0            '在庫合計・自動倉庫
        Dim intZAIKO_HIRA As Integer = 0              '在庫合計・平置き
        Dim intZAIKO_GAIBU1 As Integer = 0            '在庫合計・外部倉庫1
        Dim intZAIKO_GAIBU2 As Integer = 0            '在庫合計・外部倉庫2
        Dim intZAIKO_GAIBU3 As Integer = 0            '在庫合計・外部倉庫3
        Dim intZAIKO_GAIBU4 As Integer = 0            '在庫合計・外部倉庫4
        Dim intZAIKO_GAIBU5 As Integer = 0            '在庫合計・外部倉庫5
        Dim intZAIKO_GAIBU6 As Integer = 0            '在庫合計・外部倉庫6
        Dim intZAIKO_GAIBU7 As Integer = 0            '在庫合計・外部倉庫7
        Dim intZAIKO_GAIBU8 As Integer = 0            '在庫合計・外部倉庫8
        Dim intZAIKO_GAIBU9 As Integer = 0            '在庫合計・外部倉庫9
        Dim intZAIKO_GAIBU10 As Integer = 0           '在庫合計・外部倉庫10


        Dim strFTRK_BUF_NO() As String

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
        intZAIKO_ASOUKO = Get_ZaikoGoukei(strFTRK_BUF_NO)   '在庫合計・自動倉庫

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8001
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_HIRA = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)     '在庫合計・平置き
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8100
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU1 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫1
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8101
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU2 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫2
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8102
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU3 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫3
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8103
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU4 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫4
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8104
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU5 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫5
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8105
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU6 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫6
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8106
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU7 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫7
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8107
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU8 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫8
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8108
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU9 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)   '在庫合計・外部倉庫9
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

        ReDim strFTRK_BUF_NO(0)
        strFTRK_BUF_NO(0) = FTRK_BUF_NO_J8109
        '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
        intZAIKO_GAIBU10 = Get_ZaikoGoukei_HIRA(strFTRK_BUF_NO)  '在庫合計・外部倉庫10
        '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応


        '在庫合計・合計
        intZAIKO_GOUKEI = intZAIKO_ASOUKO + intZAIKO_HIRA + intZAIKO_GAIBU1 + _
                          intZAIKO_GAIBU2 + intZAIKO_GAIBU3 + intZAIKO_GAIBU4 + _
                          intZAIKO_GAIBU5 + intZAIKO_GAIBU6 + intZAIKO_GAIBU7 + _
                          intZAIKO_GAIBU8 + intZAIKO_GAIBU9 + intZAIKO_GAIBU10
        lblZAIKO_GOUKEI.Text = TO_STRING(intZAIKO_GOUKEI)

        lblZAIKO_ASOUKO.Text = TO_STRING(intZAIKO_ASOUKO)            '在庫合計・自動倉庫
        lblZAIKO_HIRA.Text = TO_STRING(intZAIKO_HIRA)                '在庫合計・平置き
        lblZAIKO_GAIBU1.Text = TO_STRING(intZAIKO_GAIBU1)            '在庫合計・外部倉庫1
        lblZAIKO_GAIBU2.Text = TO_STRING(intZAIKO_GAIBU2)            '在庫合計・外部倉庫2
        lblZAIKO_GAIBU3.Text = TO_STRING(intZAIKO_GAIBU3)            '在庫合計・外部倉庫3
        lblZAIKO_GAIBU4.Text = TO_STRING(intZAIKO_GAIBU4)            '在庫合計・外部倉庫4
        lblZAIKO_GAIBU5.Text = TO_STRING(intZAIKO_GAIBU5)            '在庫合計・外部倉庫5
        lblZAIKO_GAIBU6.Text = TO_STRING(intZAIKO_GAIBU6)            '在庫合計・外部倉庫6
        lblZAIKO_GAIBU7.Text = TO_STRING(intZAIKO_GAIBU7)            '在庫合計・外部倉庫7
        lblZAIKO_GAIBU8.Text = TO_STRING(intZAIKO_GAIBU8)            '在庫合計・外部倉庫8
        lblZAIKO_GAIBU9.Text = TO_STRING(intZAIKO_GAIBU9)            '在庫合計・外部倉庫9
        lblZAIKO_GAIBU10.Text = TO_STRING(intZAIKO_GAIBU10)          '在庫合計・外部倉庫10

    End Sub
#End Region
#Region "  各保管場所 在庫合計 取得 (自動倉庫)      "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ(保管場所)
    '【戻値】在庫量
    '*******************************************************************************************************************
    Private Function Get_ZaikoGoukei(ByVal strFTRK_BUF_NO() As String _
                                    ) As Integer

        Dim intZAIKO_VOL As Integer = 0            '在庫合計

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strSQL As String                'SQL文

        '********************************************************************
        '在庫合計 取得SQL
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "       TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "     , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "     , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , SUM(TRUNC(TRST_STOCK.FTR_VOL / TMST_ITEM.FNUM_IN_PALLET)) AS ZAIKO_VOL "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "      TRST_STOCK "
        strSQL &= vbCrLf & "    , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    , TMST_ITEM "

        If strFTRK_BUF_NO(0) = FTRK_BUF_NO_J9000 Then
            '(自動倉庫の時)
            strSQL &= vbCrLf & "    , TMST_CRANE "                          'ｸﾚｰﾝﾏｽﾀ
            strSQL &= vbCrLf & "    , TSTS_EQ_CTRL "                        '設備状況
        End If

        strSQL &= vbCrLf & "  WHERE "
        strSQL &= vbCrLf & "        TRST_STOCK.FPALLET_ID    = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD    = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "

        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN ( "

        For ii As Integer = LBound(strFTRK_BUF_NO) To UBound(strFTRK_BUF_NO)
            '(ﾙｰﾌﾟ:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
            If ii = 0 Then
                '(1回目)
                strSQL &= vbCrLf & "                                  " & strFTRK_BUF_NO(ii)
            Else
                '(2回目以降)
                strSQL &= vbCrLf & "                                , " & strFTRK_BUF_NO(ii)
            End If
        Next

        strSQL &= vbCrLf & "                                    ) "

        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD    LIKE '" & mstrFHINMEI_CD & "%' "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XSEIZOU_DT    = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XHINSHITU_STS = " & mstrXHINSHITU_STS

        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN(SELECT FPALLET_ID FROM XSTS_HIKIATE_K2 WHERE FSAGYOU_KIND = 51) "

        If strFTRK_BUF_NO(0) = FTRK_BUF_NO_J9000 Then
            '(自動倉庫の時)
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU   >= TMST_CRANE.FCRANE_ROW1(+) "       '列1
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRAC_RETU   <= TMST_CRANE.FCRANE_ROW2(+) "       '列2
            strSQL &= vbCrLf & "    AND TMST_CRANE.FEQ_ID         = TSTS_EQ_CTRL.FEQ_ID(+) "          '設備ID
            strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS  = " & FEQ_CUT_STS_SOFF              '切離状態 = 通常
        End If

        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "      TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "    , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "    , TRST_STOCK.XHINSHITU_STS  "


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TRST_STOCK"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                intZAIKO_VOL += TO_DECIMAL(objRow("ZAIKO_VOL"))   '在庫合計
            Next

        End If

        Return intZAIKO_VOL     '在庫合計

    End Function
#End Region
    '↓↓↓↓ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応
#Region "  各保管場所 在庫合計 取得 (平置き、外部倉庫)     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ(保管場所)
    '【戻値】在庫量
    '*******************************************************************************************************************
    Private Function Get_ZaikoGoukei_HIRA(ByVal strFTRK_BUF_NO() As String _
                                    ) As Integer

        Dim intZAIKO_VOL As Integer = 0            '在庫合計

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strSQL As String                'SQL文

        '********************************************************************
        '在庫合計 取得SQL
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "    SELECT  "
        strSQL &= vbCrLf & "        G2.FHINMEI_CD "
        strSQL &= vbCrLf & "      , G2.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , G2.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , TRUNC((G2.FTR_VOL - G2.ZAIKO_HIKIATEZUMI) / G2.FNUM_IN_PALLET) AS ZAIKO_VOL "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    ( "
        strSQL &= vbCrLf & "    SELECT "
        strSQL &= vbCrLf & "        G1.FHINMEI_CD "
        strSQL &= vbCrLf & "      , G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , G1.XHINSHITU_STS "
        strSQL &= vbCrLf & "      , MAX(G1.FTR_VOL)              AS FTR_VOL "
        strSQL &= vbCrLf & "      , MAX(FNUM_IN_PALLET)          AS FNUM_IN_PALLET"
        strSQL &= vbCrLf & "      , SUM(NVL(XRST_OUT.FTR_VOL,0)) AS ZAIKO_HIKIATEZUMI "
        strSQL &= vbCrLf & "    FROM "
        strSQL &= vbCrLf & "    ("

        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "       TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "     , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "     , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "     , SUM(TRST_STOCK.FTR_VOL)       AS FTR_VOL "
        strSQL &= vbCrLf & "     , MAX(TMST_ITEM.FNUM_IN_PALLET) AS FNUM_IN_PALLET "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "      TRST_STOCK "
        strSQL &= vbCrLf & "    , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    , TMST_ITEM "

        strSQL &= vbCrLf & "  WHERE "
        strSQL &= vbCrLf & "        TRST_STOCK.FPALLET_ID    = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD    = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN( "                            '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "

        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN ( "

        For ii As Integer = LBound(strFTRK_BUF_NO) To UBound(strFTRK_BUF_NO)
            '(ﾙｰﾌﾟ:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
            If ii = 0 Then
                '(1回目)
                strSQL &= vbCrLf & "                                  " & strFTRK_BUF_NO(ii)
            Else
                '(2回目以降)
                strSQL &= vbCrLf & "                                , " & strFTRK_BUF_NO(ii)
            End If
        Next

        strSQL &= vbCrLf & "                                    ) "

        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD    LIKE '" & mstrFHINMEI_CD & "%' "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XSEIZOU_DT    = TO_DATE('" & mstrXSEIZOU_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XHINSHITU_STS = " & mstrXHINSHITU_STS

        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID NOT IN(SELECT FPALLET_ID FROM XSTS_HIKIATE_K2 WHERE FSAGYOU_KIND = 51) "

        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "      TRST_STOCK.FHINMEI_CD "
        strSQL &= vbCrLf & "    , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "    , TRST_STOCK.XHINSHITU_STS  "

        strSQL &= vbCrLf & "  ) G1 "
        strSQL &= vbCrLf & "    LEFT JOIN "
        strSQL &= vbCrLf & "    XRST_OUT "
        strSQL &= vbCrLf & "  ON 1 = 1 "
        strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO IN( "

        For ii As Integer = LBound(strFTRK_BUF_NO) To UBound(strFTRK_BUF_NO)
            '(ﾙｰﾌﾟ:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
            If ii = 0 Then
                '(1回目)
                strSQL &= vbCrLf & "                                  " & strFTRK_BUF_NO(ii)
            Else
                '(2回目以降)
                strSQL &= vbCrLf & "                                , " & strFTRK_BUF_NO(ii)
            End If
        Next

        strSQL &= vbCrLf & "                                    ) "

        strSQL &= vbCrLf & "     AND XRST_OUT.XPALLET_ID_KARI = '###' "
        strSQL &= vbCrLf & "     AND XRST_OUT.FHINMEI_CD      = G1.FHINMEI_CD "
        strSQL &= vbCrLf & "     AND XRST_OUT.XSEIZOU_DT      = G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "     G1.FHINMEI_CD "
        strSQL &= vbCrLf & "   , G1.XSEIZOU_DT "
        strSQL &= vbCrLf & "   , G1.XHINSHITU_STS "
        strSQL &= vbCrLf & " ) G2 "


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TRST_STOCK"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                intZAIKO_VOL += TO_DECIMAL(objRow("ZAIKO_VOL"))   '在庫合計
            Next

        End If

        Return intZAIKO_VOL     '在庫合計

    End Function
#End Region
    '↑↑↑↑ 2012.12.04 17:45 H.Morita 出荷実績の引当済み分を考慮する対応

#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.KeisanBtn1_Click
                '(計算ﾎﾞﾀﾝｸﾘｯｸ時 最初のﾁｪｯｸ)

                '==========================
                'ｸﾞﾘｯﾄﾞ表示
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ｸﾞﾘｯﾄﾞ表示されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '================================
                '入力ﾁｪｯｸ  引当PL数・自動倉庫
                '================================
                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)
                    If (IsNumeric(grdList.Item(menmListCol.ASOUKO, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.HIRA, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU1, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU2, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU3, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU4, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU5, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU6, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU7, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU8, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU9, ii).Value) = False) Or _
                       (IsNumeric(grdList.Item(menmListCol.GAIBU10, ii).Value) = False) Then
                        '(数値が入っていない場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_02, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                Next

                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)
                    If (TO_DECIMAL(grdList.Item(menmListCol.ASOUKO, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.HIRA, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU1, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU2, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU3, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU4, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU5, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU6, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU7, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU8, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU9, ii).Value) < 0) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU10, ii).Value) < 0) Then
                        '(数値が 0 より小さいとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_03, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                Next

                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)
                    If (TO_DECIMAL(grdList.Item(menmListCol.ASOUKO, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.HIRA, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU1, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU2, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU3, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU4, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU5, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU6, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU7, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU8, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU9, ii).Value) > 9999) Or _
                       (TO_DECIMAL(grdList.Item(menmListCol.GAIBU10, ii).Value) > 9999) Then
                        '(数値が 9999 より大きいとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_04, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                Next


                blnCheckErr = False


            Case menmCheckCase.KeisanBtn2_Click
                '(計算ﾎﾞﾀﾝｸﾘｯｸ時 合計ﾁｪｯｸ)

                '==========================
                '計算ﾁｪｯｸ
                '==========================

                '==========================
                '引当PL数横合計 ﾁｪｯｸ
                '==========================
                Dim decXSYUKKA_VOL As Decimal = 0           '出荷PL数
                Dim decHIKIATE_PL_GOUKEI As Decimal = 0     '引当PL数横合計

                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

                    '引当PL数横合計
                    decHIKIATE_PL_GOUKEI = TO_DECIMAL(grdList.Item(menmListCol.ASOUKO, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.HIRA, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU1, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU2, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU3, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU4, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU5, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU6, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU7, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU8, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU9, ii).Value) + _
                                           TO_DECIMAL(grdList.Item(menmListCol.GAIBU10, ii).Value)

                    decXSYUKKA_VOL = TO_DECIMAL(grdList.Item(menmListCol.XSYUKKA_VOL, ii).Value)    '出荷PL数

                    If decXSYUKKA_VOL = decHIKIATE_PL_GOUKEI Then
                        '(出荷PL数と、引当PL数横合計が同じの時)
                    Else
                        '(出荷PL数と、引当PL数横合計が異なる時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_05, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                Next


                '==========================
                '引当PL数縦合計 ﾁｪｯｸ
                '==========================
                If TO_DECIMAL(lblZAIKO_ASOUKO.Text) >= TO_DECIMAL(lblHIKIATE_ASOUKO.Text) Then
                    '(自動倉庫の在庫合計≧引当合計の時)
                Else
                    '(自動倉庫の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_HIRA.Text) >= TO_DECIMAL(lblHIKIATE_HIRA.Text) Then
                    '(平置きの在庫合計≧引当合計の時)
                Else
                    '(平置きの在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU1.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU1.Text) Then
                    '(外部倉庫1の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫1の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU2.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU2.Text) Then
                    '(外部倉庫2の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫2の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU3.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU3.Text) Then
                    '(外部倉庫3の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫3の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU4.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU4.Text) Then
                    '(外部倉庫4の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫4の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU5.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU5.Text) Then
                    '(外部倉庫5の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫5の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU6.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU6.Text) Then
                    '(外部倉庫6の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫6の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU7.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU7.Text) Then
                    '(外部倉庫7の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫7の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU8.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU8.Text) Then
                    '(外部倉庫8の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫8の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU9.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU9.Text) Then
                    '(外部倉庫9の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫9の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If TO_DECIMAL(lblZAIKO_GAIBU10.Text) >= TO_DECIMAL(lblHIKIATE_GAIBU10.Text) Then
                    '(外部倉庫10の在庫合計≧引当合計の時)
                Else
                    '(外部倉庫10の在庫合計＜引当合計の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False


            Case menmCheckCase.SaiHikiateBtn_Click
                '(再引当ﾎﾞﾀﾝｸﾘｯｸ時)

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

#Region "  ｿｹｯﾄ送信02 (再引当)                    　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnReturn As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308051_07, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strXDSPSYUKKA_NO As String = ""              '出荷№
            Dim strXDSPPALLET_NUM_9000 As String = ""        '出荷ﾊﾟﾚｯﾄ数(自動倉庫)
            Dim strXDSPPALLET_NUM_8001 As String = ""        '出荷ﾊﾟﾚｯﾄ数(1F平置き)
            Dim strXDSPPALLET_NUM_8100 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫1)
            Dim strXDSPPALLET_NUM_8101 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫2)
            Dim strXDSPPALLET_NUM_8102 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫3)
            Dim strXDSPPALLET_NUM_8103 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫4)
            Dim strXDSPPALLET_NUM_8104 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫5)
            Dim strXDSPPALLET_NUM_8105 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫6)
            Dim strXDSPPALLET_NUM_8106 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫7)
            Dim strXDSPPALLET_NUM_8107 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫8)
            Dim strXDSPPALLET_NUM_8108 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫9)
            Dim strXDSPPALLET_NUM_8109 As String = ""        '出荷ﾊﾟﾚｯﾄ数(外部倉庫10)


            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400604       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strXDSPSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, ii).Value)                '出荷№
            strXDSPPALLET_NUM_9000 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.ASOUKO, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(自動倉庫)
            strXDSPPALLET_NUM_8001 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.HIRA, ii).Value))    '出荷ﾊﾟﾚｯﾄ数(1F平置き)
            strXDSPPALLET_NUM_8100 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU1, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫1)
            strXDSPPALLET_NUM_8101 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU2, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫2)
            strXDSPPALLET_NUM_8102 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU3, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫3)
            strXDSPPALLET_NUM_8103 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU4, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫4)
            strXDSPPALLET_NUM_8104 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU5, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫5)
            strXDSPPALLET_NUM_8105 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU6, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫6)
            strXDSPPALLET_NUM_8106 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU7, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫7)
            strXDSPPALLET_NUM_8107 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU8, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫8)
            strXDSPPALLET_NUM_8108 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU9, ii).Value))  '出荷ﾊﾟﾚｯﾄ数(外部倉庫9)
            strXDSPPALLET_NUM_8109 = TO_STRING(TO_INTEGER(grdList.Item(menmListCol.GAIBU10, ii).Value)) '出荷ﾊﾟﾚｯﾄ数(外部倉庫10)


            objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)                        '出荷№
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_9000", TO_STRING(FTRK_BUF_NO_J9000))      '出荷ﾊﾟﾚｯﾄ数(自動倉庫)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_9000", strXDSPPALLET_NUM_9000)            '出荷ﾊﾟﾚｯﾄ数(自動倉庫)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8001", TO_STRING(FTRK_BUF_NO_J8001))      '出荷ﾊﾟﾚｯﾄ数(1F平置き)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8001", strXDSPPALLET_NUM_8001)            '出荷ﾊﾟﾚｯﾄ数(1F平置き)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8100", TO_STRING(FTRK_BUF_NO_J8100))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫1)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8100", strXDSPPALLET_NUM_8100)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫1)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8101", TO_STRING(FTRK_BUF_NO_J8101))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫2)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8101", strXDSPPALLET_NUM_8101)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫2)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8102", TO_STRING(FTRK_BUF_NO_J8102))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫3)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8102", strXDSPPALLET_NUM_8102)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫3)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8103", TO_STRING(FTRK_BUF_NO_J8103))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫4)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8103", strXDSPPALLET_NUM_8103)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫4)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8104", TO_STRING(FTRK_BUF_NO_J8104))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫5)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8104", strXDSPPALLET_NUM_8104)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫5)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8105", TO_STRING(FTRK_BUF_NO_J8105))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫6)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8105", strXDSPPALLET_NUM_8105)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫6)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8106", TO_STRING(FTRK_BUF_NO_J8106))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫7)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8106", strXDSPPALLET_NUM_8106)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫7)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8107", TO_STRING(FTRK_BUF_NO_J8107))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫8)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8107", strXDSPPALLET_NUM_8107)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫8)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8108", TO_STRING(FTRK_BUF_NO_J8108))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫9)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8108", strXDSPPALLET_NUM_8108)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫9)
            objTelegramSub.SETIN_DATA("XDSPTRK_BUF_NO_8109", TO_STRING(FTRK_BUF_NO_J8109))      '出荷ﾊﾟﾚｯﾄ数(外部倉庫10)
            objTelegramSub.SETIN_DATA("XDSPPALLET_NUM_8109", strXDSPPALLET_NUM_8109)            '出荷ﾊﾟﾚｯﾄ数(外部倉庫10)


            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        Next


        '*******************************************************
        ' 電文作成
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDSPHINMEI_CD As String = ""        '品名ｺｰﾄﾞ
        Dim strXDSPSEIZOU_DT As String = ""       '製造年月日
        Dim strXDSPHINSHITU_STS As String = ""    '品質ｽﾃｰﾀｽ

        strDSPHINMEI_CD = mstrFHINMEI_CD          '品名ｺｰﾄﾞ
        strXDSPSEIZOU_DT = mstrXSEIZOU_DT         '製造年月日
        strXDSPHINSHITU_STS = mstrXHINSHITU_STS   '品質ｽﾃｰﾀｽ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400604      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPHINMEI_CD", strDSPHINMEI_CD)         '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSEIZOU_DT", strXDSPSEIZOU_DT)       '製造年月日
        objTelegram.SETIN_DATA("XDSPHINSHITU_STS", strXDSPHINSHITU_STS) '品質ｽﾃｰﾀｽ


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM308051_08
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnReturn = True
            End If
        End If

        Return blnReturn

    End Function
#End Region

End Class
