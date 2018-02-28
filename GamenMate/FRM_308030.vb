'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾏﾆｭｱﾙ検品(現在未使用)
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308030
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '背景色
    'Private Color_BackColor_SelON = Color.FromArgb(32, 32, 224)
    Private Color_BackColor_SelON = Color.DarkBlue
    'Private Color_BackColor_XKENPIN_SU As Color = Color.White   'ｸﾞﾘｯﾄﾞ背景色(検品数)
    'Private Color_BackColor_ETC As Color = Color.LightGray      'ｸﾞﾘｯﾄﾞ背景色(その他)

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrFTRK_BUF_NO As String              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所 ﾊﾞｰｽ№)
    Private mstrFBUF_NAME As String                '出庫場所
    Private mstrXSYUKKA_NO As String               '出荷№
    Private mstrFHINMEI_CD As String               '品名ｺｰﾄﾞ
    Private mstrXSEIZOU_DT As String               '製造年月日
    Private mstrXCAR_NO_WARITUKE As String         '受付車番
    Private mstrXCAR_NO_EDA_WARITUKE As String     '受付車番枝番

    'ﾊﾞｰｽ№変換 出庫設定時平置き
    Private mstrXTRK_BUF_NO_OUT_HIRA As String     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)

    '定数
    Private mstrSEL_OFF As String = "0"            '行選択無し
    Private mstrSEL_ON As String = "1"             '行選択あり
    Private mintColXKENPIN_SU As Integer = 15      '検品数のｶﾗﾑ位置

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        SEL_FLG                     '                   行選択有無(非表示)
        XSYUKKA_NO                  '出荷計画詳細.      出荷№(非表示)
        XPLN_DTL_NO                 '出荷計画詳細.      計画明細№(非表示)
        FPLAN_KEY                   '出荷計画詳細.      計画ｷｰ(非表示)
        FHINMEI_CD                  '出荷計画詳細.      品名ｺｰﾄﾞ(非表示)
        XSEIZOU_DT                  '出荷実績.          製造年月日(非表示)
        FPALLET_ID                  '出荷実績.          ﾊﾟﾚｯﾄID(非表示)
        XLINE_NO                    '在庫情報.          ﾗｲﾝ№
        XPALLET_NO                  '在庫情報.          ﾊﾟﾚｯﾄ№
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示) ﾊﾞｰｽ平置場
        FTRK_BUF_NO_BERTH           '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示) ﾊﾞｰｽ№
        XTUMIKOMI_SU                '                   積込数((出荷数+出荷数(ﾊﾞﾗ)) - 出荷検品数)
        XSYUKKA_KENPIN_VOL          '出荷計画詳細.      出荷検品数(非表示)
        XKENPIN_SU                  '                   検品数
        XSYUKKA_KAHI                '在庫情報.          出荷可否
        XSYUKKA_KAHI_DSP            '在庫情報.          出荷可否(表示用)
        XHINSHITU_STS               '在庫情報.          品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                '在庫情報.          保留区分
        FHORYU_KUBUN_DSP            '在庫情報.          保留区分(表示用)
        XSTRETCH_STS                '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        XSTRETCH_STS_DSP            '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ(表示用)
        FARRIVE_DT                  '在庫情報.          在庫発生日時

        XKENPIN_FLAG                '(内部用)検品ﾌﾗｸﾞ

        MAXCOL

    End Enum



    'ｸﾞﾘｯﾄﾞ項目 (内部検品用)
    Enum menmListCol2

        XSYUKKA_NO                  '出荷計画詳細.      出荷№
        XPLN_DTL_NO                 '出荷計画詳細.      計画明細№
        'FPLAN_KEY                   '出荷計画詳細.      計画ｷｰ
        FHINMEI_CD                  '出荷計画詳細.      品名ｺｰﾄﾞ
        XSEIZOU_DT                  '出荷実績.          製造年月日
        FPALLET_ID                  '出荷実績.          ﾊﾟﾚｯﾄID
        'XLINE_NO                    '在庫情報.          ﾗｲﾝ№
        'XPALLET_NO                  '在庫情報.          ﾊﾟﾚｯﾄ№
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№ ﾊﾞｰｽ平置場
        FTRK_BUF_NO_BERTH           '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№ ﾊﾞｰｽ№
        XTUMIKOMI_SU                '                   積込数((出荷数+出荷数(ﾊﾞﾗ)) - 出荷検品数)
        'XSYUKKA_KENPIN_VOL          '出荷計画詳細.      出荷検品数
        'XKENPIN_SU                  '                   検品数

        'XSYUKKA_KAHI                '在庫情報.          出荷可否
        'XSYUKKA_KAHI_DSP            '在庫情報.          出荷可否
        'XHINSHITU_STS               '在庫情報.          品質ｽﾃｰﾀｽ
        'XHINSHITU_STS_DSP           '在庫情報.          品質ｽﾃｰﾀｽ
        'FHORYU_KUBUN                '在庫情報.          保留区分
        'FHORYU_KUBUN_DSP            '在庫情報.          保留区分
        'XSTRETCH_STS                '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        'XSTRETCH_STS_DSP            '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        'FARRIVE_DT                  '在庫情報.          在庫発生日時

        XKENPIN_FLAG                '検品ﾌﾗｸﾞ
        XKENPIN_VOL                 '検品数
        XKENPIN_PALLET_ID           '検品品ﾊﾟﾚｯﾄID

        MAXCOL

    End Enum



    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SelectAll_Click                 '全選択ﾎﾞﾀﾝｸﾘｯｸ時
        NotSelectAll_Click              '全解除ﾎﾞﾀﾝｸﾘｯｸ時
        Reg_Click                       '登録ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim FTRK_BUF_NO As String           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        Dim XTRK_BUF_NO_OUT_HIRA As String  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫設定時平置き)
        Dim XSYUKKA_NO As String            '出荷№
        Dim FHINMEI_CD As String            '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String            '製造年月日
    End Structure
    ''ｿｹｯﾄ送信情報
    'Private Structure STOCK_DATA
    '    Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
    'End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
    '======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property

    '======================================
    ' 出庫場所
    '======================================
    Public Property userFBUF_NAME() As String
        Get
            Return mstrFBUF_NAME
        End Get
        Set(ByVal value As String)
            mstrFBUF_NAME = value
        End Set
    End Property

    '======================================
    ' 出荷№
    '======================================
    Public Property userXSYUKKA_NO() As String
        Get
            Return mstrXSYUKKA_NO
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NO = value
        End Set
    End Property

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
    ' 受付車番
    '======================================
    Public Property userXCAR_NO_WARITUKE() As String
        Get
            Return mstrXCAR_NO_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_WARITUKE = value
        End Set
    End Property

    '======================================
    ' 受付車番枝番
    '======================================
    Public Property userXCAR_NO_EDA_WARITUKE() As String
        Get
            Return mstrXCAR_NO_EDA_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA_WARITUKE = value
        End Set
    End Property
#End Region
#Region "　ｲﾍﾞﾝﾄ                                　  "
#Region "  ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    '''Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.CellMouseClick
        Try

            If mFlag_Form_Load = False Then
                '(画面展開済みのとき)

                '*********************************************
                '選択・非選択 設定
                '*********************************************
                Dim intColIdx As Integer = grdList.CurrentCellAddress.X
                Dim intRowIdx As Integer = grdList.CurrentCellAddress.Y

                If grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_OFF Then
                    '(非選択の時)
                    grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_ON     '行選択有無
                    '検品数
                    grdList.Item(menmListCol.XKENPIN_SU, intRowIdx).Value = TO_DECIMAL(grdList.Item(menmListCol.XTUMIKOMI_SU, intRowIdx).Value) _
                                                                          - TO_DECIMAL(grdList.Item(menmListCol.XSYUKKA_KENPIN_VOL, intRowIdx).Value)

                Else
                    '(選択されていた時)
                    grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_OFF    '行選択有無 
                    grdList.Item(menmListCol.XKENPIN_SU, intRowIdx).Value = 0           '検品数
                End If

                Call grdList_ClickProcess()         '検品数選択処理

            End If

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｾﾙｴﾝﾀｰ                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙｴﾝﾀｰ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellEnter

        If e.RowIndex >= 0 Then
            '(ﾍｯﾀﾞｰ以外のとき)

            If grdList.Item(menmListCol.SEL_FLG, e.RowIndex).Value = mstrSEL_OFF Then
                '行選択有無 (選択ｵﾌ)
                '**********************************************************
                ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                '**********************************************************
                grdList.DefaultCellStyle.SelectionBackColor = Color.White
                grdList.DefaultCellStyle.SelectionForeColor = Color.Black
            Else
                '行選択有無 (選択ｵﾝ)
                '**********************************************************
                ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                '**********************************************************
                grdList.DefaultCellStyle.SelectionBackColor = Color_BackColor_SelON
                grdList.DefaultCellStyle.SelectionForeColor = Color.White
            End If

        End If

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
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.XKENPIN_SU) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = "0"
                    End If
                    If dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Length > 9 Then
                        '(9桁より大きいとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Substring(0, 9)
                    End If

                    If TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Value) > TO_DECIMAL(grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Value) Then
                        '(積込数より大きいとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_04, PopupFormType.Ok, PopupIconType.Information)
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Value = grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Value
                    End If

                    If (TO_DECIMAL(dgv(e.ColumnIndex, e.RowIndex).Value) = 0) Then
                        '(値がない時)
                        grdList.Item(menmListCol.SEL_FLG, e.RowIndex).Value = mstrSEL_OFF    '行選択有無 (選択ｵﾌ)

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                        '**********************************************************
                        grdList.DefaultCellStyle.SelectionBackColor = Color.White
                        grdList.DefaultCellStyle.SelectionForeColor = Color.Black

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞ ｾﾙ 色設定
                        '**********************************************************
                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.BackColor = Color.White

                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.ForeColor = Color.Black

                    Else
                        '(値がある時)

                        grdList.Item(menmListCol.SEL_FLG, e.RowIndex).Value = mstrSEL_ON    '行選択有無 (選択ｵﾝ)

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                        '**********************************************************
                        grdList.DefaultCellStyle.SelectionBackColor = Color_BackColor_SelON
                        grdList.DefaultCellStyle.SelectionForeColor = Color.White

                        ''**********************************************************
                        ' ｸﾞﾘｯﾄﾞ ｾﾙ 色設定
                        '**********************************************************
                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.BackColor = Color_BackColor_SelON

                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.ForeColor = Color.White

                    End If

                    Call grdList_ClickProcess()         '検品数選択処理

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
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.XKENPIN_SU) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = "0"
                    End If
                    If dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Length > 9 Then
                        '(9桁より大きいとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = dgv(e.ColumnIndex, e.RowIndex).Value.ToString.Substring(0, 9)
                    End If

                    If TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Value) > TO_DECIMAL(grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Value) Then
                        '(積込数より大きいとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_04, PopupFormType.Ok, PopupIconType.Information)
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Value = grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Value
                    End If

                    If (TO_DECIMAL(dgv(e.ColumnIndex, e.RowIndex).Value) = 0) Then
                        '(値がない時)

                        grdList.Item(menmListCol.SEL_FLG, e.RowIndex).Value = mstrSEL_OFF    '行選択有無 (選択ｵﾌ)

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                        '**********************************************************
                        grdList.DefaultCellStyle.SelectionBackColor = Color.White
                        grdList.DefaultCellStyle.SelectionForeColor = Color.Black

                        ''**********************************************************
                        ' ｸﾞﾘｯﾄﾞ ｾﾙ 色設定
                        '**********************************************************
                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.BackColor = Color.White
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.BackColor = Color.White

                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.ForeColor = Color.Black
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.ForeColor = Color.Black

                    Else
                        '(値がある時)

                        grdList.Item(menmListCol.SEL_FLG, e.RowIndex).Value = mstrSEL_ON    '行選択有無 (選択ｵﾝ)

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
                        '**********************************************************
                        grdList.DefaultCellStyle.SelectionBackColor = Color_BackColor_SelON
                        grdList.DefaultCellStyle.SelectionForeColor = Color.White

                        '**********************************************************
                        ' ｸﾞﾘｯﾄﾞ ｾﾙ 色設定
                        '**********************************************************
                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.BackColor = Color_BackColor_SelON
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.BackColor = Color_BackColor_SelON

                        grdList.Item(menmListCol.XLINE_NO, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XPALLET_NO, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XTUMIKOMI_SU, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XKENPIN_SU, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XHINSHITU_STS_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.FHORYU_KUBUN_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.XSTRETCH_STS_DSP, e.RowIndex).Style.ForeColor = Color.White
                        grdList.Item(menmListCol.FARRIVE_DT, e.RowIndex).Style.ForeColor = Color.White

                    End If

                    Call grdList_ClickProcess()         '検品数選択処理

                End If
            End If

        Catch ex As Exception
            ComError(ex)
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

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞｶｰｿﾙ 色設定
        '**********************************************************
        grdList.DefaultCellStyle.SelectionBackColor = Color.White
        grdList.DefaultCellStyle.SelectionForeColor = Color.Black

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '*********************************************
        ' 出庫設定時平置き設定
        '*********************************************
        Dim intRet As RetCode
        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
        objTMST_TRK.FTRK_BUF_NO = mstrFTRK_BUF_NO                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        intRet = objTMST_TRK.GET_TMST_TRK(True)                              '特定
        If intRet = RetCode.OK Then
            '(読めた時)
            If IsNull(objTMST_TRK.XTRK_BUF_NO_OUT_HIRA) = True Then
                '(値ない時)
                mstrXTRK_BUF_NO_OUT_HIRA = mstrFTRK_BUF_NO
            Else
                '(値ある時)
                mstrXTRK_BUF_NO_OUT_HIRA = TO_STRING(objTMST_TRK.XTRK_BUF_NO_OUT_HIRA)
            End If
        Else
            '(読めなかった時)
            mstrXTRK_BUF_NO_OUT_HIRA = mstrFTRK_BUF_NO
        End If


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFBUF_NAME.Text = mstrFBUF_NAME                                   '出庫場所
        lblXSYUKKA_NO.Text = mstrXSYUKKA_NO                                 '出荷№
        lblFHINMEI_CD.Text = mstrFHINMEI_CD                                 '品名ｺｰﾄﾞ
        Dim decFNUM_IN_PALLET As Decimal = 0
        gobjComFuncFRM.Get_FHINMEI(mstrFHINMEI_CD, lblFHINMEI.Text, decFNUM_IN_PALLET)    '品名
        lblXSEIZOU_DT.Text = mstrXSEIZOU_DT                                 '製造年月日
        lblSYUKKA_SU.Text = 0                                               '出荷数
        lblMIKENPIN_SU.Text = 0                                             '未検品数
        lblSELGOUKEI_SU.Text = 0                                            '検品数選択合計


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定


        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        Call grdList_Selection(False)       '全解除

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
        lblFBUF_NAME.Dispose()           '出庫場所
        lblXSYUKKA_NO.Dispose()              '出荷№
        lblFHINMEI.Dispose()                '品名ｺｰﾄﾞ
        lblFHINMEI.Dispose()                '品名
        lblXSEIZOU_DT.Dispose()             '製造年月日
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F4(全選択)       ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(全選択)       ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SelectAll_Click) = False Then

            Exit Sub

        End If

        grdList_Selection(True)


        ''*********************************************
        '' 構造体ｾｯﾄ
        ''*********************************************
        'Call SearchItem_Set()

        ''************************************
        '' ｸﾞﾘｯﾄﾞ表示
        ''************************************
        'Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F5(全解除)       ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(全解除)       ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NotSelectAll_Click) = False Then

            Exit Sub

        End If

        grdList_Selection(False)


        ''*********************************************
        '' 構造体ｾｯﾄ
        ''*********************************************
        'Call SearchItem_Set()

        ''************************************
        '' ｸﾞﾘｯﾄﾞ表示
        ''************************************
        'Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F6(登録)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(登録)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.Reg_Click) = False Then
            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02() = False Then
            Exit Sub
        End If


        Me.Close()

    End Sub
#End Region
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)

        Me.Close()

    End Sub
#End Region
#Region "  ﾘｽﾄ              ｸﾘｯｸ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ              ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_ClickProcess()


        '*********************************************
        '混載ｸﾞﾘｯﾄﾞ表示の複数選択処理
        '*********************************************
        'Call gobjComFuncFRM.GridKonsaiSelect(grdList, mstrFPALLET_ID, menmListCol.FPALLET_ID)


        ''*********************************************
        ''選択・非選択 設定
        ''*********************************************
        'Dim intColIdx As Integer = grdList.CurrentCellAddress.X
        'Dim intRowIdx As Integer = grdList.CurrentCellAddress.Y

        'If grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_OFF Then
        '    '(非選択の時)
        '    grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_ON     '行選択有無
        '    grdList.Item(menmListCol.XKENPIN_SU, intRowIdx).Value = grdList.Item(menmListCol.XTUMIKOMI_SU, intRowIdx).Value  '検品数
        'Else
        '    '(選択されていた時)
        '    If (intColIdx = mintColXKENPIN_SU) And _
        '       (TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, intRowIdx).Value) > 0) Then
        '        '(検品数のｾﾙにあるとき、値がある時)
        '        Exit Sub
        '    End If

        '    grdList.Item(menmListCol.SEL_FLG, intRowIdx).Value = mstrSEL_OFF    '行選択有無 
        '    grdList.Item(menmListCol.XKENPIN_SU, intRowIdx).Value = 0           '検品数
        'End If


        '*********************************************
        'ﾊﾟﾚｯﾄID取得
        '*********************************************
        Dim decKENPIN_SU As Decimal = 0                                     '検品数

        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(ﾙｰﾌﾟ:行数)

            If grdList.Item(menmListCol.SEL_FLG, ii).Value = mstrSEL_OFF Then
                '(非選択時)
                grdList.Item(menmListCol.XLINE_NO, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.BackColor = Color.White

                grdList.Item(menmListCol.XLINE_NO, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.ForeColor = Color.Black

                Continue For
            Else
                '(選択時)
                grdList.Item(menmListCol.XLINE_NO, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.BackColor = Color_BackColor_SelON

                grdList.Item(menmListCol.XLINE_NO, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.ForeColor = Color.White

            End If

            decKENPIN_SU += TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, ii).Value)  '検品数選択合計

        Next

        lblSELGOUKEI_SU.Text = decKENPIN_SU         '検品数選択合計

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SelectAll_Click
                '(全選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NotSelectAll_Click
                '(全解除ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.Reg_Click
                '(登録ﾎﾞﾀﾝｸﾘｯｸ時)


                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                'If grdList.SelectedRows.Count <= 0 Then
                '    '(ﾘｽﾄが選択されていない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select

                'End If

                Dim blnSEL As Boolean = False
                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:明細分)
                    If grdList.Item(menmListCol.SEL_FLG, ii).Value = mstrSEL_ON Then
                        '(選択時)
                        blnSEL = True
                    End If
                Next

                If blnSEL = False Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '==========================
                '検品数選択合計ﾁｪｯｸ
                '==========================
                If (mstrXTRK_BUF_NO_OUT_HIRA = FTRK_BUF_NO_J8000) Then
                    '(ﾊﾞﾗ平置きでの検品の時)
                    If (TO_DECIMAL(lblMIKENPIN_SU.Text) < TO_DECIMAL(lblSELGOUKEI_SU.Text)) Then
                        '(未検品数と、検品数選択合計が多いとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_04, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                Else
                    '(ﾊﾞﾗ平置きでの検品以外の時)
                    If (TO_DECIMAL(lblMIKENPIN_SU.Text) <> TO_DECIMAL(lblSELGOUKEI_SU.Text)) Then
                        '(未検品数と、検品数選択合計が等しくないとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_03, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If


                '==========================
                '出庫場所ﾁｪｯｸ
                '==========================
                For ii As Integer = 0 To grdList.Rows.Count - 1
                    '(ﾙｰﾌﾟ:明細分)
                    If grdList.Item(menmListCol.SEL_FLG, ii).Value = mstrSEL_ON Then
                        '(選択時)

                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
                        objTPRG_TRK_BUF.FPALLET_ID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, ii).Value)   'ﾊﾟﾚｯﾄ№
                        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                                   '特定

                        If TO_STRING(objTPRG_TRK_BUF.FTRK_BUF_NO) <> mstrXTRK_BUF_NO_OUT_HIRA Then
                            '(出庫場所に在庫がない時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_05, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If

                    End If
                Next


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
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM.FTRK_BUF_NO = mstrFTRK_BUF_NO                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA = mstrXTRK_BUF_NO_OUT_HIRA     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫設定時平置き)
        mudtSEARCH_ITEM.XSYUKKA_NO = mstrXSYUKKA_NO                         '出荷№
        mudtSEARCH_ITEM.FHINMEI_CD = mstrFHINMEI_CD                         '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = mstrXSEIZOU_DT                         '製造年月日

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT DISTINCT"
        strSQL &= vbCrLf & "    A.SEL_FLG "
        strSQL &= vbCrLf & "  , A.XSYUKKA_NO "
        strSQL &= vbCrLf & "  , A.XPLN_DTL_NO "
        strSQL &= vbCrLf & "  , A.FPLAN_KEY "
        strSQL &= vbCrLf & "  , A.FHINMEI_CD "
        strSQL &= vbCrLf & "  , A.XSEIZOU_DT "
        strSQL &= vbCrLf & "  , A.FPALLET_ID "
        strSQL &= vbCrLf & "  , A.XLINE_NO "
        strSQL &= vbCrLf & "  , A.XPALLET_NO "
        strSQL &= vbCrLf & "  , A.FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , A.FTRK_BUF_NO_BERTH "
        strSQL &= vbCrLf & "  , A.XTUMIKOMI_SU "
        strSQL &= vbCrLf & "  , B.XSYUKKA_KENPIN_VOL "
        strSQL &= vbCrLf & "  , A.XKENPIN_SU "
        strSQL &= vbCrLf & "  , A.XSYUKKA_KAHI "
        strSQL &= vbCrLf & "  , A.XSYUKKA_KAHI_DSP "
        strSQL &= vbCrLf & "  , A.XHINSHITU_STS "
        strSQL &= vbCrLf & "  , A.XHINSHITU_STS_DSP "
        strSQL &= vbCrLf & "  , A.FHORYU_KUBUN "
        strSQL &= vbCrLf & "  , A.FHORYU_KUBUN_DSP "
        strSQL &= vbCrLf & "  , A.XSTRETCH_STS "
        strSQL &= vbCrLf & "  , A.XSTRETCH_STS_DSP "
        strSQL &= vbCrLf & "  , A.FARRIVE_DT "
        strSQL &= vbCrLf & "  , " & XKENPIN_FLAG_JOFF & " AS XKENPIN_FLAG "           '(内部用)検品ﾌﾗｸﾞ

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "( "
        strSQL &= vbCrLf & " SELECT DISTINCT"
        strSQL &= vbCrLf & "    0 AS SEL_FLG "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XPLN_DTL_NO "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "
        'strSQL &= vbCrLf & "  , XRST_OUT.XSEIZOU_DT "
        'strSQL &= vbCrLf & "  , XRST_OUT.FPALLET_ID "
        'strSQL &= vbCrLf & "  , XRST_OUT.XLINE_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_NO "
        strSQL &= vbCrLf & "  , TRST_STOCK.XSEIZOU_DT "
        strSQL &= vbCrLf & "  , TRST_STOCK.FPALLET_ID "
        strSQL &= vbCrLf & "  , TRST_STOCK.XLINE_NO "
        strSQL &= vbCrLf & "  , TRST_STOCK.XPALLET_NO "
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , XRST_OUT.FTRK_BUF_NO AS FTRK_BUF_NO_BERTH"       '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示) ﾊﾞｰｽ№
        'strSQL &= vbCrLf & "  , XRST_OUT.FTR_VOL AS XTUMIKOMI_SU "
        strSQL &= vbCrLf & "  , TRST_STOCK.FTR_VOL AS XTUMIKOMI_SU "
        strSQL &= vbCrLf & "  , 0 AS XKENPIN_SU "
        strSQL &= vbCrLf & "  , TRST_STOCK.XSYUKKA_KAHI "
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "
        strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "
        strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "
        strSQL &= vbCrLf & "  , TRST_STOCK.XSTRETCH_STS "
        strSQL &= vbCrLf & "  , HASH04.FGAMEN_DISP AS XSTRETCH_STS_DSP "
        strSQL &= vbCrLf & "  , TRST_STOCK.FARRIVE_DT "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "  , TRST_STOCK "
        strSQL &= vbCrLf & "  , XRST_OUT "

        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "XSTRETCH_STS")


        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO       = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO      = XRST_OUT.XPLN_DTL_NO(+) "

        '↓↓↓↓↓ H.Morita 2012.10.30
        ''strSQL &= vbCrLf & "    AND XRST_OUT.FPALLET_ID          = TRST_STOCK.FPALLET_ID(+) "
        ''strSQL &= vbCrLf & "    AND XRST_OUT.FPALLET_ID          = TPRG_TRK_BUF.FPALLET_ID(+) "

        'strSQL &= vbCrLf & "    AND XRST_OUT.FHINMEI_CD           = TRST_STOCK.FHINMEI_CD(+) "
        'strSQL &= vbCrLf & "    AND XRST_OUT.XSEIZOU_DT           = TRST_STOCK.XSEIZOU_DT(+) "

        If (mudtSEARCH_ITEM.FTRK_BUF_NO >= FTRK_BUF_NO_J1) And _
           (mudtSEARCH_ITEM.FTRK_BUF_NO <= FTRK_BUF_NO_J8) Then
            '(ﾊﾞｰｽでの作業の時)
            strSQL &= vbCrLf & "    AND XRST_OUT.XPALLET_ID_KARI     = TRST_STOCK.FPALLET_ID(+) "
        Else
            '(以外の時)
            strSQL &= vbCrLf & "    AND XRST_OUT.FHINMEI_CD          = TRST_STOCK.FHINMEI_CD(+) "
            strSQL &= vbCrLf & "    AND XRST_OUT.XSEIZOU_DT          = TRST_STOCK.XSEIZOU_DT(+) "
        End If
        '↑↑↑↑↑ H.Morita 2012.10.30

        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID         = TPRG_TRK_BUF.FPALLET_ID(+) "

        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO       = XPLN_OUT.XSYUKKA_NO(+) "                   '***
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO_WARITUKE & "' "             '***
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA_WARITUKE & "' "     '***
        strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG  NOT IN (" & XKENPIN_FLAG_JON
        strSQL &= vbCrLf & "                                     , " & XKENPIN_FLAG_JKYOUSEI
        strSQL &= vbCrLf & "                                      )"                                     '検品済みﾌﾗｸﾞ = 「検品待ち」

        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "XSTRETCH_STS")



        '----------------------------------------------
        '出庫場所(ﾊﾞｰｽ№)
        '----------------------------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA       'この２つはﾍﾟｱで必要。表示ダブるので。
            strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO     = " & mudtSEARCH_ITEM.FTRK_BUF_NO                'この２つはﾍﾟｱで必要。表示ダブるので。
        End If

        '----------------------------------------------
        '出荷№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XSYUKKA_NO = " & mudtSEARCH_ITEM.XSYUKKA_NO
        End If

        '----------------------------------------------
        '品目ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        End If

        '----------------------------------------------
        '製造年月日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        strSQL &= vbCrLf & " ) A"

        strSQL &= vbCrLf & " , ("
        strSQL &= vbCrLf & " SELECT DISTINCT"
        strSQL &= vbCrLf & "    XRST_OUT.XSYUKKA_NO "
        strSQL &= vbCrLf & "  , XRST_OUT.XPLN_DTL_NO "
        strSQL &= vbCrLf & "  , XRST_OUT.FHINMEI_CD "
        strSQL &= vbCrLf & "  , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & "  , XRST_OUT.XLINE_NO "
        strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_NO "
        strSQL &= vbCrLf & "  , XRST_OUT.XSYUKKA_KENPIN_VOL "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "                                                                   '***
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "  , TSTS_HIKIATE "
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "  , XRST_OUT "
        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FPLAN_KEY      = TSTS_HIKIATE.FPLAN_KEY(+) "
        strSQL &= vbCrLf & "    AND TSTS_HIKIATE.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO    = XRST_OUT.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XPLN_OUT.XSYUKKA_NO(+) "                   '***
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mstrXCAR_NO_WARITUKE & "' "             '***
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA_WARITUKE & "' "     '***
        strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG  NOT IN (" & XKENPIN_FLAG_JON
        strSQL &= vbCrLf & "                                     , " & XKENPIN_FLAG_JKYOUSEI
        strSQL &= vbCrLf & "                                      )"                                     '検品済みﾌﾗｸﾞ = 「検品待ち」

        '----------------------------------------------
        '出庫場所(ﾊﾞｰｽ№)
        '----------------------------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA
            'strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO     = " & mudtSEARCH_ITEM.FTRK_BUF_NO           'ﾊﾞﾗ出荷の時、実際には在庫が1F平置きにある時、有効にすると表示されるが。。。
        End If

        '----------------------------------------------
        '出荷№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XSYUKKA_NO = " & mudtSEARCH_ITEM.XSYUKKA_NO
        End If

        '----------------------------------------------
        '品目ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        End If

        '----------------------------------------------
        '製造年月日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        strSQL &= vbCrLf & " ) B"
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "   AND A.XSYUKKA_NO  = B.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "   AND A.XPLN_DTL_NO = B.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & "   AND A.FHINMEI_CD  = B.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "   AND A.XSEIZOU_DT  = B.XSEIZOU_DT(+) "
        strSQL &= vbCrLf & "   AND A.XLINE_NO    = B.XLINE_NO(+) "
        strSQL &= vbCrLf & "   AND A.XPALLET_NO  = B.XPALLET_NO(+) "



        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, False)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理



        '*********************************************
        ' 内部検品用
        '*********************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        'strSQL &= vbCrLf & " SELECT DISTINCT"
        ''strSQL &= vbCrLf & "    A.SEL_FLG "
        'strSQL &= vbCrLf & "    A.XSYUKKA_NO "
        'strSQL &= vbCrLf & "  , A.XPLN_DTL_NO "
        'strSQL &= vbCrLf & "  , A.FPLAN_KEY "
        'strSQL &= vbCrLf & "  , A.FHINMEI_CD "
        'strSQL &= vbCrLf & "  , A.XSEIZOU_DT "
        ''strSQL &= vbCrLf & "  , A.FPALLET_ID "
        'strSQL &= vbCrLf & "  , A.XPALLET_ID_KARI "
        'strSQL &= vbCrLf & "  , A.XLINE_NO "
        'strSQL &= vbCrLf & "  , A.XPALLET_NO "
        'strSQL &= vbCrLf & "  , A.FTRK_BUF_NO "
        'strSQL &= vbCrLf & "  , A.FTRK_BUF_NO_BERTH "
        'strSQL &= vbCrLf & "  , A.XTUMIKOMI_SU "
        'strSQL &= vbCrLf & "  , B.XSYUKKA_KENPIN_VOL "
        'strSQL &= vbCrLf & "  , A.XKENPIN_SU "
        'strSQL &= vbCrLf & "  , A.XSYUKKA_KAHI "
        'strSQL &= vbCrLf & "  , A.XSYUKKA_KAHI_DSP "
        'strSQL &= vbCrLf & "  , A.XHINSHITU_STS "
        'strSQL &= vbCrLf & "  , A.XHINSHITU_STS_DSP "
        'strSQL &= vbCrLf & "  , A.FHORYU_KUBUN "
        'strSQL &= vbCrLf & "  , A.FHORYU_KUBUN_DSP "
        'strSQL &= vbCrLf & "  , A.XSTRETCH_STS "
        'strSQL &= vbCrLf & "  , A.XSTRETCH_STS_DSP "
        'strSQL &= vbCrLf & "  , A.FARRIVE_DT "

        'strSQL &= vbCrLf & "  , " & XKENPIN_FLAG_JOFF & " AS XKENPIN_FLAG "     '検品ﾌﾗｸﾞ
        'strSQL &= vbCrLf & "  , 0 AS XKENPIN_VOL "                              '検品数
        'strSQL &= vbCrLf & "  , '' AS XKENPIN_PALLET_ID "                       '検品品ﾊﾟﾚｯﾄID

        'strSQL &= vbCrLf & " FROM "
        'strSQL &= vbCrLf & "( "
        'strSQL &= vbCrLf & " SELECT DISTINCT"
        ''strSQL &= vbCrLf & "    0 AS SEL_FLG "
        'strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_NO "
        'strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XPLN_DTL_NO "
        'strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "
        'strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "
        'strSQL &= vbCrLf & "  , XRST_OUT.XSEIZOU_DT "
        ''strSQL &= vbCrLf & "  , XRST_OUT.FPALLET_ID "
        'strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_ID_KARI "
        'strSQL &= vbCrLf & "  , XRST_OUT.XLINE_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_NO "
        'strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.FTRK_BUF_NO AS FTRK_BUF_NO_BERTH"       '出荷実績.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示) ﾊﾞｰｽ№
        'strSQL &= vbCrLf & "  , XRST_OUT.FTR_VOL AS XTUMIKOMI_SU "
        'strSQL &= vbCrLf & "  , 0 AS XKENPIN_SU "
        'strSQL &= vbCrLf & "  , TRST_STOCK.XSYUKKA_KAHI "
        'strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "
        'strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "
        'strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "
        'strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "
        'strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "
        'strSQL &= vbCrLf & "  , TRST_STOCK.XSTRETCH_STS "
        'strSQL &= vbCrLf & "  , HASH04.FGAMEN_DISP AS XSTRETCH_STS_DSP "
        'strSQL &= vbCrLf & "  , TRST_STOCK.FARRIVE_DT "
        'strSQL &= vbCrLf & " FROM "
        'strSQL &= vbCrLf & "    XPLN_OUT "
        'strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
        'strSQL &= vbCrLf & "  , TPRG_TRK_BUF "
        'strSQL &= vbCrLf & "  , TRST_STOCK "
        'strSQL &= vbCrLf & "  , XRST_OUT "
        'strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'TRST_STOCK' AND FFIELD_NAME = 'XSYUKKA_KAHI') HASH01 "
        'strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'TRST_STOCK' AND FFIELD_NAME = 'XHINSHITU_STS') HASH02 "
        'strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'TRST_STOCK' AND FFIELD_NAME = 'FHORYU_KUBUN') HASH03 "
        'strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = 'TRST_STOCK' AND FFIELD_NAME = 'XSTRETCH_STS') HASH04 "
        'strSQL &= vbCrLf & " WHERE 1 = 1  "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XRST_OUT.XSYUKKA_NO(+) "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO    = XRST_OUT.XPLN_DTL_NO(+) "

        ''strSQL &= vbCrLf & "    AND XRST_OUT.FPALLET_ID         = TRST_STOCK.FPALLET_ID(+) "
        'strSQL &= vbCrLf & "    AND XRST_OUT.XPALLET_ID_KARI    = TRST_STOCK.FPALLET_ID(+) "
        ''strSQL &= vbCrLf & "    AND XRST_OUT.FPALLET_ID         = TPRG_TRK_BUF.FPALLET_ID(+) "
        'strSQL &= vbCrLf & "    AND XRST_OUT.XPALLET_ID_KARI    = TPRG_TRK_BUF.FPALLET_ID(+) "

        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XPLN_OUT.XSYUKKA_NO(+) "                   '***
        'strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mstrXCAR_NO_WARITUKE & "' "             '***
        'strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA_WARITUKE & "' "     '***
        'strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG  NOT IN (" & XKENPIN_FLAG_JON
        'strSQL &= vbCrLf & "                                     , " & XKENPIN_FLAG_JKYOUSEI
        'strSQL &= vbCrLf & "                                      )"                                     '検品済みﾌﾗｸﾞ = 「検品待ち」
        'strSQL &= vbCrLf & "    AND HASH01.FDISP_VALUE(+) = TRST_STOCK.XSYUKKA_KAHI "
        'strSQL &= vbCrLf & "    AND HASH02.FDISP_VALUE(+) = TRST_STOCK.XHINSHITU_STS "
        'strSQL &= vbCrLf & "    AND HASH03.FDISP_VALUE(+) = TRST_STOCK.FHORYU_KUBUN "
        'strSQL &= vbCrLf & "    AND HASH04.FDISP_VALUE(+) = TRST_STOCK.XSTRETCH_STS "

        ''----------------------------------------------
        ''出庫場所(ﾊﾞｰｽ№)
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.FTRK_BUF_NO <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA
        'End If

        ''----------------------------------------------
        ''出荷№
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XSYUKKA_NO <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XSYUKKA_NO = " & mudtSEARCH_ITEM.XSYUKKA_NO
        'End If

        ''----------------------------------------------
        ''品目ｺｰﾄﾞ
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        'End If

        ''----------------------------------------------
        ''製造年月日
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
        'End If

        'strSQL &= vbCrLf & " ) A"

        'strSQL &= vbCrLf & " , ("
        'strSQL &= vbCrLf & " SELECT DISTINCT"
        'strSQL &= vbCrLf & "    XRST_OUT.XSYUKKA_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.XPLN_DTL_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.FHINMEI_CD "
        'strSQL &= vbCrLf & "  , XRST_OUT.XSEIZOU_DT "
        'strSQL &= vbCrLf & "  , XRST_OUT.XLINE_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_NO "
        'strSQL &= vbCrLf & "  , XRST_OUT.XSYUKKA_KENPIN_VOL "
        'strSQL &= vbCrLf & " FROM "
        'strSQL &= vbCrLf & "    XPLN_OUT "                                                                   '***
        'strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
        'strSQL &= vbCrLf & "  , TSTS_HIKIATE "
        'strSQL &= vbCrLf & "  , TPRG_TRK_BUF "
        'strSQL &= vbCrLf & "  , XRST_OUT "
        'strSQL &= vbCrLf & " WHERE 1 = 1  "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FPLAN_KEY      = TSTS_HIKIATE.FPLAN_KEY(+) "
        'strSQL &= vbCrLf & "    AND TSTS_HIKIATE.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID(+) "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XRST_OUT.XSYUKKA_NO(+) "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO    = XRST_OUT.XPLN_DTL_NO(+) "
        'strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XPLN_OUT.XSYUKKA_NO(+) "                   '***
        'strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mstrXCAR_NO_WARITUKE & "' "             '***
        'strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA_WARITUKE & "' "     '***
        'strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG  NOT IN (" & XKENPIN_FLAG_JON
        'strSQL &= vbCrLf & "                                     , " & XKENPIN_FLAG_JKYOUSEI
        'strSQL &= vbCrLf & "                                      )"                                     '検品済みﾌﾗｸﾞ = 「検品待ち」

        ''----------------------------------------------
        ''出庫場所(ﾊﾞｰｽ№)
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.FTRK_BUF_NO <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA
        'End If

        ''----------------------------------------------
        ''出荷№
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XSYUKKA_NO <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XSYUKKA_NO = " & mudtSEARCH_ITEM.XSYUKKA_NO
        'End If

        ''----------------------------------------------
        ''品目ｺｰﾄﾞ
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        'End If

        ''----------------------------------------------
        ''製造年月日
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XRST_OUT.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
        'End If

        'strSQL &= vbCrLf & " ) B"
        'strSQL &= vbCrLf & " WHERE 1 = 1 "
        'strSQL &= vbCrLf & "   AND A.XSYUKKA_NO  = B.XSYUKKA_NO(+) "
        'strSQL &= vbCrLf & "   AND A.XPLN_DTL_NO = B.XPLN_DTL_NO(+) "
        'strSQL &= vbCrLf & "   AND A.FHINMEI_CD  = B.FHINMEI_CD(+) "
        'strSQL &= vbCrLf & "   AND A.XSEIZOU_DT  = B.XSEIZOU_DT(+) "
        'strSQL &= vbCrLf & "   AND A.XLINE_NO    = B.XLINE_NO(+) "
        'strSQL &= vbCrLf & "   AND A.XPALLET_NO  = B.XPALLET_NO(+) "

        'strSQL &= vbCrLf & " ORDER BY "
        'strSQL &= vbCrLf & "    A.XSYUKKA_NO "
        'strSQL &= vbCrLf & "  , A.XPLN_DTL_NO "
        'strSQL &= vbCrLf & "  , A.FHINMEI_CD "
        'strSQL &= vbCrLf & "  , A.XSEIZOU_DT "
        'strSQL &= vbCrLf & "  , A.XLINE_NO "
        'strSQL &= vbCrLf & "  , A.XPALLET_NO "


        strSQL &= vbCrLf & " SELECT DISTINCT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_NO "                       '出荷№
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XPLN_DTL_NO "                      '出荷明細№
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                       '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XRST_OUT.XSEIZOU_DT "                           '製造年月日
        strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_ID_KARI "                      'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "  , XRST_OUT.FTRK_BUF_NO AS FTRK_BUF_NO_BERTH"      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "  , XRST_OUT.FTR_VOL     AS XTUMIKOMI_SU "          '積込数
        strSQL &= vbCrLf & "  , " & XKENPIN_FLAG_JOFF & " AS XKENPIN_FLAG "     '検品ﾌﾗｸﾞ
        strSQL &= vbCrLf & "  , 0 AS XKENPIN_VOL "                              '検品数
        strSQL &= vbCrLf & "  , '' AS XKENPIN_PALLET_ID "                       '検品品ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "  , XRST_OUT "
        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO    = XRST_OUT.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & "    AND XRST_OUT.XPALLET_ID_KARI    = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO     = XPLN_OUT.XSYUKKA_NO(+) "

        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO_WARITUKE & "' "        '受付車番
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA_WARITUKE & "' "    '受付車番枝番
        strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG  NOT IN (" & XKENPIN_FLAG_JON
        strSQL &= vbCrLf & "                                     , " & XKENPIN_FLAG_JKYOUSEI
        strSQL &= vbCrLf & "                                      )"                                     '検品済みﾌﾗｸﾞ = 「検品待ち」

        If mudtSEARCH_ITEM.FTRK_BUF_NO = mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA Then
            '(ﾊﾞｰｽ以外の出荷の時)
            strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO   = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA
        Else
            '(ﾊﾞｰｽからの出荷の時)
            strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO   = " & mudtSEARCH_ITEM.FTRK_BUF_NO
        End If

        strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.XSYUKKA_NO    = '" & mudtSEARCH_ITEM.XSYUKKA_NO & "' "
        strSQL &= vbCrLf & "      AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        strSQL &= vbCrLf & "      AND XRST_OUT.XSEIZOU_DT        = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"



        '-----------------------
        '抽出
        '-----------------------
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, False)





        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ表示 (出荷数、検品数)
        '*********************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "   FTRK_BUF_NO "
        strSQL &= vbCrLf & " , XSYUKKA_NO "
        strSQL &= vbCrLf & " , FHINMEI_CD "
        strSQL &= vbCrLf & " , XSEIZOU_DT "
        strSQL &= vbCrLf & " , FTR_VOL "
        strSQL &= vbCrLf & " , KENPINSU_VOL "
        strSQL &= vbCrLf & " , (FTR_VOL - KENPINSU_VOL) AS MI_KENPINSU_VOL "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & " ( "
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "     XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "   , XRST_OUT.XSYUKKA_NO "
        strSQL &= vbCrLf & "   , XRST_OUT.FHINMEI_CD "
        strSQL &= vbCrLf & "   , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & "   , SUM(XRST_OUT.FTR_VOL)            AS FTR_VOL "
        strSQL &= vbCrLf & "   , SUM(XRST_OUT.XSYUKKA_KENPIN_VOL) AS KENPINSU_VOL "
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  　 XRST_OUT "
        strSQL &= vbCrLf & "  WHERE  1 = 1 "

        'strSQL &= vbCrLf & "   AND XRST_OUT.FTRK_BUF_NO    =  " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        If mudtSEARCH_ITEM.FTRK_BUF_NO = mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA Then
            '(ﾊﾞｰｽ以外の出荷の時)
            strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO   = " & mudtSEARCH_ITEM.XTRK_BUF_NO_OUT_HIRA
        Else
            '(ﾊﾞｰｽからの出荷の時)
            strSQL &= vbCrLf & "      AND XRST_OUT.FTRK_BUF_NO   = " & mudtSEARCH_ITEM.FTRK_BUF_NO
        End If

        strSQL &= vbCrLf & "   AND XRST_OUT.XSYUKKA_NO     = '" & mudtSEARCH_ITEM.XSYUKKA_NO & "' "       '出荷№
        strSQL &= vbCrLf & "   AND XRST_OUT.FHINMEI_CD  LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "      '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   AND XRST_OUT.XSEIZOU_DT     = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"   '製造年月日
        strSQL &= vbCrLf & "  GROUP BY "
        strSQL &= vbCrLf & "     XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "   , XRST_OUT.XSYUKKA_NO "
        strSQL &= vbCrLf & "   , XRST_OUT.FHINMEI_CD "
        strSQL &= vbCrLf & "   , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & "  ) A "


        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "A"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(読めた時)
            Dim decSYUKKA_SU As Decimal = 0                                     '出荷数
            Dim decKENPIN_SU As Decimal = 0                                     '検品数

            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                'decSYUKKA_SU += TO_DECIMAL(objRow("XTUMIKOMI_SU"))
                'decKENPIN_SU += TO_DECIMAL(objRow("XSYUKKA_KENPIN_VOL"))
                decSYUKKA_SU += TO_DECIMAL(objRow("FTR_VOL"))
                decKENPIN_SU += TO_DECIMAL(objRow("KENPINSU_VOL"))
            Next

            'For ii As Integer = 0 To grdList2.Rows.Count - 1
            '    decSYUKKA_SU += TO_DECIMAL(grdList2.Item(menmListCol2.XTUMIKOMI_SU, ii).Value)
            '    decKENPIN_SU += TO_DECIMAL(grdList2.Item(menmListCol2.XSYUKKA_KENPIN_VOL, ii).Value)
            'Next

            lblSYUKKA_SU.Text = decSYUKKA_SU                                    '出荷数
            lblMIKENPIN_SU.Text = decSYUKKA_SU - decKENPIN_SU                   '未検品数
        Else
            '(読めない時)
            lblSYUKKA_SU.Text = 0                                               '出荷数
            lblMIKENPIN_SU.Text = 0                                             '未検品数
        End If

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
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

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False
        grdList.CurrentCell = Nothing

        '=========================================
        '編集ﾓｰﾄﾞ
        '=========================================
        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

        'grdList.SelectionMode = DataGridViewSelectionMode.CellSelect
        grdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grdList.ReadOnly = False

        grdList.Columns(menmListCol.XLINE_NO).ReadOnly = True                 'ﾗｲﾝ№
        grdList.Columns(menmListCol.XPALLET_NO).ReadOnly = True               'ﾊﾟﾚｯﾄ№
        grdList.Columns(menmListCol.XTUMIKOMI_SU).ReadOnly = True             '積込数
        grdList.Columns(menmListCol.XSYUKKA_KAHI_DSP).ReadOnly = True         '出荷可否
        grdList.Columns(menmListCol.XHINSHITU_STS_DSP).ReadOnly = True        '品質ｽﾃｰﾀｽ
        grdList.Columns(menmListCol.FHORYU_KUBUN_DSP).ReadOnly = True         '保留区分
        grdList.Columns(menmListCol.XSTRETCH_STS_DSP).ReadOnly = True         'ｽﾄﾚｯﾁｽﾃｰﾀｽ
        grdList.Columns(menmListCol.FARRIVE_DT).ReadOnly = True               '在庫発生日時


        If (TO_INTEGER(mstrFTRK_BUF_NO) = FTRK_BUF_NO_J8000) Then
            '(ﾊﾞﾗ平置きの時)
        Else
            '(ﾊﾞﾗ平置き以外の時)
            grdList.Columns(menmListCol.XKENPIN_SU).ReadOnly = True           '検品数
        End If

        'grdList.DefaultCellStyle.BackColor = Color_BackColor_ETC               'ｸﾞﾘｯﾄﾞ背景色(その他)
        'grdList.DefaultCellStyle.SelectionBackColor = Color_BackColor_ETC      'ｸﾞﾘｯﾄﾞ選択時背景色(その他)
        'grdList.DefaultCellStyle.SelectionForeColor = Color.Black

        Call grdList_Selection(False)       '全解除

    End Sub
#End Region

#Region "  ﾘｽﾄ選択/解除処理                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[IN ]blnSelectFlg
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdList_Selection(ByVal blnSelectFlg As Boolean)

        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        '*********************************************
        ' ﾘｽﾄ選択
        '*********************************************
        Dim lngii As Integer
        If 0 <= grdList.Rows.Count - 1 Then
            For lngii = 0 To grdList.Rows.Count - 1
                grdList.Rows(lngii).Selected = blnSelectFlg
            Next
        End If

        If blnSelectFlg = False Then
            '(選択解除)
            For ii As Integer = 0 To grdList.Rows.Count - 1
                '(ﾙｰﾌﾟ:明細分)
                grdList.Item(menmListCol.SEL_FLG, ii).Value = mstrSEL_OFF    '行選択有無 

                grdList.Item(menmListCol.XKENPIN_SU, ii).Value = 0           '検品数

                grdList.Item(menmListCol.XLINE_NO, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.BackColor = Color.White
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.BackColor = Color.White

                grdList.Item(menmListCol.XLINE_NO, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.ForeColor = Color.Black
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.ForeColor = Color.Black
            Next

        Else
            '(選択)
            For ii As Integer = 0 To grdList.Rows.Count - 1
                '(ﾙｰﾌﾟ:明細分)
                grdList.Item(menmListCol.SEL_FLG, ii).Value = mstrSEL_ON    '行選択有無 

                '検品数
                grdList.Item(menmListCol.XKENPIN_SU, ii).Value = TO_DECIMAL(grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Value) _
                                                               - TO_DECIMAL(grdList.Item(menmListCol.XSYUKKA_KENPIN_VOL, ii).Value)

                grdList.Item(menmListCol.XLINE_NO, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.BackColor = Color_BackColor_SelON
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.BackColor = Color_BackColor_SelON

                grdList.Item(menmListCol.XLINE_NO, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XPALLET_NO, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XTUMIKOMI_SU, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XKENPIN_SU, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.XSTRETCH_STS_DSP, ii).Style.ForeColor = Color.White
                grdList.Item(menmListCol.FARRIVE_DT, ii).Style.ForeColor = Color.White
            Next

        End If

        Call grdList_ClickProcess()         '検品数選択処理

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信02                             　"
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
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308030_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        '*******************************************************
        '内部検品用に編集
        '*******************************************************
        '検品品が、引当品の時
        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(ﾙｰﾌﾟ:明細分)

            If TO_STRING(grdList.Item(menmListCol.SEL_FLG, ii).Value) = mstrSEL_OFF Then
                '(選択無しの時) 
                Continue For
            End If

            For jj As Integer = 0 To grdList2.Rows.Count - 1

                If (TO_STRING(grdList.Item(menmListCol.FPALLET_ID, ii).Value) = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, jj).Value)) And _
                   (TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG, jj).Value) = XKENPIN_FLAG_JOFF) Then
                    '(未検品で、ﾊﾟﾚｯﾄIDが一致する時)
                    grdList2.Item(menmListCol2.XKENPIN_FLAG, jj).Value = XKENPIN_FLAG_JON
                    grdList2.Item(menmListCol2.XKENPIN_VOL, jj).Value = TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, ii).Value)
                    grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, jj).Value = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, ii).Value)

                    grdList.Item(menmListCol.XKENPIN_FLAG, ii).Value = XKENPIN_FLAG_JON     '検品済み

                    Exit For
                End If

            Next

        Next


        '検品品が、代替品の時
        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(ﾙｰﾌﾟ:明細分)

            If TO_STRING(grdList.Item(menmListCol.SEL_FLG, ii).Value) = mstrSEL_OFF Then
                '(選択無しの時) 
                Continue For
            End If

            If TO_STRING(grdList.Item(menmListCol.XKENPIN_FLAG, ii).Value) = XKENPIN_FLAG_JON Then
                '(内部用 検品済みの時) 
                Continue For
            End If

            For jj As Integer = 0 To grdList2.Rows.Count - 1

                If TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG, jj).Value) = XKENPIN_FLAG_JOFF Then
                    '(未検品の時)
                    'If (TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, ii).Value) = TO_STRING(grdList2.Item(menmListCol2.FTRK_BUF_NO, jj).Value)) And _
                    If (TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, ii).Value) = TO_STRING(grdList2.Item(menmListCol2.FHINMEI_CD, jj).Value)) And _
                       (TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, ii).Value) = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, jj).Value)) And _
                       (TO_STRING(grdList.Item(menmListCol.XKENPIN_SU, ii).Value) = TO_STRING(grdList2.Item(menmListCol2.XTUMIKOMI_SU, jj).Value)) Then
                        ''(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№>品名ｺｰﾄﾞ>製造年月日>数量が同じの時)
                        '(品名ｺｰﾄﾞ>製造年月日>数量が同じの時)
                        grdList2.Item(menmListCol2.XKENPIN_FLAG, jj).Value = XKENPIN_FLAG_JON
                        grdList2.Item(menmListCol2.XKENPIN_VOL, jj).Value = TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, ii).Value)
                        grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, jj).Value = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, ii).Value)

                        grdList.Item(menmListCol.XKENPIN_FLAG, ii).Value = XKENPIN_FLAG_JON     '検品済み

                        Exit For
                    End If

                End If

            Next

        Next

        grdList2.Refresh()      '#########################



        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        Dim strDSPST_FM As String = ""                                   '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№


        'For ii As Integer = 0 To grdList.Rows.Count - 1
        '    '(ﾙｰﾌﾟ:明細分)

        '    If TO_STRING(grdList.Item(menmListCol.SEL_FLG, ii).Value) = mstrSEL_OFF Then
        '        '(選択無しの時) 
        '        Continue For
        '    End If

        '    strDSPST_FM = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO_BERTH, ii).Value) '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

        '    If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

        '    '*******************************************************
        '    ' 電文作成
        '    '*******************************************************
        '    '========================================
        '    ' 変数宣言
        '    '========================================
        '    Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
        '    Dim strDSPPALLET_ID As String = ""               'ﾊﾟﾚｯﾄID
        '    Dim strDSPTR_VOL As String = ""                  '搬送管理量
        '    Dim strXDSPSYUKKA_NO As String = ""              '出荷№
        '    Dim strXDSPPLN_DTL_NO As String = ""             '計画明細№


        '    objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        '    Dim strDSPCMD_ID As String = ""
        '    strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
        '    'ﾍｯﾀﾞﾃﾞｰﾀ
        '    objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
        '    objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
        '    objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

        '    'ﾃﾞｰﾀ
        '    strDSPPALLET_ID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, ii).Value)             'ﾊﾟﾚｯﾄID
        '    strDSPTR_VOL = TO_STRING(TO_DECIMAL(grdList.Item(menmListCol.XKENPIN_SU, ii).Value))    '搬送管理量
        '    strXDSPSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, ii).Value)            '出荷№
        '    strXDSPPLN_DTL_NO = TO_STRING(grdList.Item(menmListCol.XPLN_DTL_NO, ii).Value)          '計画明細№

        '    objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)              '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        '    objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)      'ﾊﾟﾚｯﾄID
        '    objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)            '搬送管理量
        '    objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)    '出荷№
        '    objTelegramSub.SETIN_DATA("XDSPPLN_DTL_NO", strXDSPPLN_DTL_NO)  '計画明細№


        '    objTelegramSub.MAKE_TELEGRAM()

        '    strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        'Next




        For ii As Integer = 0 To grdList2.Rows.Count - 1
            '(ﾙｰﾌﾟ:明細分)

            If TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value) = XKENPIN_FLAG_JOFF Then
                '(未検品の時) 
                Continue For
            End If

            strDSPST_FM = TO_STRING(grdList2.Item(menmListCol2.FTRK_BUF_NO_BERTH, ii).Value) '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strXDSPPALLET_ID_KARI As String = ""         'ﾊﾟﾚｯﾄID(仮引当)
            Dim strDSPTR_VOL As String = ""                  '搬送管理量
            Dim strXDSPSYUKKA_NO As String = ""              '出荷№
            Dim strXDSPPLN_DTL_NO As String = ""             '計画明細№
            Dim strXDSPPALLET_ID_CHECK As String = ""        'ﾊﾟﾚｯﾄID(検品済)


            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strXDSPPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value)       'ﾊﾟﾚｯﾄID(仮引当)
            strDSPTR_VOL = TO_STRING(TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value))   '搬送管理量
            strXDSPSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)            '出荷№
            strXDSPPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)          '計画明細№
            strXDSPPALLET_ID_CHECK = TO_STRING(grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(検品済)

            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                    '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KARI", strXDSPPALLET_ID_KARI)      'ﾊﾟﾚｯﾄID(仮引当)
            objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)                  '搬送管理量
            objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)          '出荷№
            objTelegramSub.SETIN_DATA("XDSPPLN_DTL_NO", strXDSPPLN_DTL_NO)        '計画明細№
            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_CHECK", strXDSPPALLET_ID_CHECK)  'ﾊﾟﾚｯﾄID(検品済)
            objTelegramSub.SETIN_DATA("XDSPSEIZOU_DT", mstrXSEIZOU_DT)            '製造年月日


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

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        'objTelegram.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM308030_02
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

