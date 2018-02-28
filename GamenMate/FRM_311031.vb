'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷指示子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311031

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrXSYUKKA_D As String                   '出荷日
    Protected mstrXHENSEI_NO As String                  '編成№
    Protected mstrXDENPYOU_NO As String                 '伝票№

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXPLN_OUT As TBL_XPLN_OUT            '出荷指示
    Dim mobjXPLN_OUT_DTL As TBL_XPLN_OUT_DTL    '出荷指示詳細

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        XSYUKKA_D               '出荷指示.　　　　出荷日
        XHENSEI_NO              '出荷指示.　　　　編成No.
        XDENPYOU_NO             '出荷指示.　　　　伝票No.
        XOUT_ORDER              '出荷指示詳細.　　車輌内出荷品目順（No.）
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD              '品名ﾏｽﾀ.         品名ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        FHINMEI_CD              '出荷指示詳細. 　 品名ｺｰﾄﾞ(品名記号)
        XHINMEI                 '品名ﾏｽﾀ. 　      品名
        '↑↑↑↑↑↑************************************************************************************************************
        XSYUKKA_KON_PLAN        '出荷指示詳細.    出荷予定梱数（梱数）
        XHEIGHT_IN_PALLET       '品名ﾏｽﾀ.         ﾊﾟﾚｯﾄ高さ

        MAXCOL
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>出荷日</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_D() As String
        Get
            Return mstrXSYUKKA_D
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_D = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>編成№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXHENSEI_NO() As String
        Get
            Return mstrXHENSEI_NO
        End Get
        Set(ByVal value As String)
            mstrXHENSEI_NO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>伝票№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDENPYOU_NO() As String
        Get
            Return mstrXDENPYOU_NO
        End Get
        Set(ByVal value As String)
            mstrXDENPYOU_NO = value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_311031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_311031_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

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



    End Sub
#End Region
#Region "　ｾﾙﾘｰﾌﾞ                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙﾘｰﾌﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellLeave
        Try

            Dim dgv As DataGridView = CType(sender, DataGridView)

            If e.RowIndex >= 0 Then
                '(ﾍｯﾀﾞｰ以外のとき)
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.XOUT_ORDER) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = ""
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
                If (dgv.Columns(e.ColumnIndex).Index = menmListCol.XOUT_ORDER) Then
                    '(入力ｾﾙのとき)
                    If TO_STRING(dgv(e.ColumnIndex, e.RowIndex).Value) = String.Empty Then
                        '(NULLのとき)
                        dgv(e.ColumnIndex, e.RowIndex).Value = ""
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
#Region "　ｾﾙ ｶﾚﾝﾄｾﾙ ｽﾃｰﾀｽ ﾁｪﾝｼﾞ                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙ ｶﾚﾝﾄｾﾙ ｽﾃｰﾀｽ ﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdList.CurrentCellDirtyStateChanged

        If grdList Is Nothing Then
            Exit Sub
        End If

        grdList.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub
#End Region
#Region "　ﾁｪｯｸﾎﾞｯｸｽﾁｪｯｸﾁｪﾝｼﾞ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾁｪｯｸﾎﾞｯｸｽﾁｪｯｸﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub chkALLSYUKKO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkALLSYUKKO.CheckedChanged

        If chkALLSYUKKO.Checked = True Then
            '(一括出庫にﾁｪｯｸを付けたとき)
            For ii As Integer = 0 To grdList.Rows.Count - 1
                '(ﾙｰﾌﾟ:計画詳細分)
                grdList.Item(menmListCol.XOUT_ORDER, ii).Value = ""           '№
            Next
        End If

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '**********************************************************
        ' 出荷指示の特定
        '**********************************************************
        mobjXPLN_OUT = New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
        mobjXPLN_OUT.XSYUKKA_D = mstrXSYUKKA_D                  '出荷日
        mobjXPLN_OUT.XHENSEI_NO = mstrXHENSEI_NO                '編成№
        mobjXPLN_OUT.XDENPYOU_NO = mstrXDENPYOU_NO              '伝票№
        mobjXPLN_OUT.GET_XPLN_OUT(False)


        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        ' 積込方法ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUHOU, True, mobjXPLN_OUT.XTUMI_HOUHOU)

        '===================================
        ' 積込方向ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUKOU, True, mobjXPLN_OUT.XTUMI_HOUKOU)

        '===================================
        ' ﾊﾞｰｽ指定ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call MakeXBerth_NO_cbo(cboXBERTH_NO)

        '===================================
        ' 緊急出荷ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXKINKYU_KBN, True, mobjXPLN_OUT.XKINKYU_KBN)
        If TO_STRING(mobjXPLN_OUT.XKINKYU_KBN) = "" Then
            cboXKINKYU_KBN.SelectedIndex = 1
        End If

        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtXSYARYOU_NO.Text = TO_STRING(mobjXPLN_OUT.XSYARYOU_NO)               '車輌№


        '**********************************************************
        ' ﾁｪｯｸﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        chkALLSYUKKO.Checked = False                                            '一括出庫


        '**********************************************************
        ' ﾗﾍﾞﾙ                 ｾｯﾄ
        '**********************************************************
        lblXSYUKKA_D.Text = TO_STRING(mstrXSYUKKA_D)                            '出荷日
        lblXHENSEI_NO.Text = TO_STRING(mobjXPLN_OUT.XHENSEI_NO)                 '編成№
        lblXDENPYOU_NO.Text = TO_STRING(mobjXPLN_OUT.XDENPYOU_NO)               '伝票№
        lblXGYOUSYA_CD.Text = TO_STRING(mobjXPLN_OUT.XGYOUSYA_CD)               '業者ｺｰﾄﾞ
        lblXBUNRUI_NO.Text = TO_STRING(mobjXPLN_OUT.XBUNRUI_NO)                 '分類№
        lblXSEND_NAME.Text = TO_STRING(mobjXPLN_OUT.XSEND_NAME)                 '届け先
        lblXSEND_ADDRESS.Text = TO_STRING(mobjXPLN_OUT.XSEND_ADDRESS)           '住所


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplay()


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        txtXSYARYOU_NO.Dispose()            '車輌№
        cboXTUMI_HOUHOU.Dispose()           '積込方法
        cboXTUMI_HOUKOU.Dispose()           '積込方向
        cboXBERTH_NO.Dispose()             'ﾊﾞｰｽ指定
        cboXKINKYU_KBN.Dispose()            '緊急出荷
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then
            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        'Dim intRet As RetCode
        Dim strMsg As String = ""


        Select Case 1
            Case 1
                '(出荷指示の場合)

                '========================================
                '車輌№
                '========================================
                If txtXSYARYOU_NO.Text = Nothing Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311031_01, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積込方法
                '========================================
                If TO_STRING(cboXTUMI_HOUHOU.SelectedValue.ToString) = CBO_ALL_VALUE Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311031_02, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '積込方向
                '========================================
                If TO_STRING(cboXTUMI_HOUKOU.SelectedValue.ToString) = CBO_ALL_VALUE Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311031_03, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '緊急出庫
                '========================================
                If TO_STRING(cboXKINKYU_KBN.SelectedValue.ToString) = CBO_ALL_VALUE Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311031_04, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

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
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
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
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D "                            '出荷指示.      出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO "                           '出荷指示.      編成№
        strSQL &= vbCrLf & "  , XPLN_OUT.XDENPYOU_NO "                          '出荷指示.      伝票№
        strSQL &= vbCrLf & "  , TO_CHAR(XPLN_OUT_DTL.XOUT_ORDER) "              '出荷指示詳細.  車輌内出荷品目順
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                          '品名ﾏｽﾀ.　     品名ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                       '出荷指示詳細.  品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                             '品名ﾏｽﾀ.　     品名
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_KON_PLAN "                 '出荷指示詳細.  出荷予定梱数
        strSQL &= vbCrLf & "  , TMST_ITEM.XHEIGHT_IN_PALLET "                   '品名ﾏｽﾀ.  　   ﾊﾟﾚｯﾄ高さ  
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "              '【出荷指示】
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "          '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TMST_ITEM "             '【品名ﾏｽﾀ】
        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "   　     XPLN_OUT.XSYUKKA_D = XPLN_OUT_DTL.XSYUKKA_D"                                  '出荷指示と出荷指示詳細を出荷日で結合
        strSQL &= vbCrLf & "   　AND  XPLN_OUT.XHENSEI_NO = XPLN_OUT_DTL.XHENSEI_NO"                                '出荷指示と出荷指示詳細を編成No.で結合
        strSQL &= vbCrLf & "   　AND  XPLN_OUT.XDENPYOU_NO = XPLN_OUT_DTL.XDENPYOU_NO"                              '出荷指示と出荷指示詳細を伝票No.で結合
        strSQL &= vbCrLf & "   　AND  XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD"                               '出荷指示詳細と品名ﾏｽﾀを品名ｺｰﾄﾞで結合
        strSQL &= vbCrLf & "     AND　XPLN_OUT_DTL.XSYUKKA_D = TO_DATE('" & mstrXSYUKKA_D & "', 'YYYY/MM/DD')"
        strSQL &= vbCrLf & "     AND  XPLN_OUT.XHENSEI_NO_OYA = '" & mobjXPLN_OUT.XHENSEI_NO_OYA & "'"              '出荷指示.       編成№=親編成№
        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "   　     XPLN_OUT_DTL.XOUT_ORDER "
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


        '************************************************
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)


        grdList.CurrentCell = Nothing
        grdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grdList.ReadOnly = False

        grdList.Columns(menmListCol.XSYUKKA_D).ReadOnly = True              '出荷日
        grdList.Columns(menmListCol.XHENSEI_NO).ReadOnly = True             '編成No.
        grdList.Columns(menmListCol.XOUT_ORDER).ReadOnly = False            '車輌内出荷品目順（No.）
        grdList.Columns(menmListCol.FHINMEI_CD).ReadOnly = True             '品名ｺｰﾄﾞ
        grdList.Columns(menmListCol.XHINMEI).ReadOnly = True                '品名
        grdList.Columns(menmListCol.XHINMEI_CD).ReadOnly = True             '品名ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        grdList.Columns(menmListCol.XSYUKKA_KON_PLAN).ReadOnly = True       '出荷予定梱数（梱数）
        grdList.Columns(menmListCol.XHEIGHT_IN_PALLET).ReadOnly = True      'ﾊﾟﾚｯﾄ高さ


        'Call grdList_Selection(False)       '全解除


    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        'Dim intRet As RetCode


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ件数分)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            Dim strXDSPSYUKKA_D As String = ""              '出荷日
            Dim strXDSPSYARYOU_NO As String = ""            '車輌番号
            Dim strXDSPTUMI_HOUKOU As String = ""           '積込方向
            Dim strXDSPTUMI_HOUHOU As String = ""           '積込方法
            Dim strXDSPBERTH_NO As String = ""              'ﾊﾞｰｽ指定
            Dim strXDSPKINKYU_KBN As String = ""            '緊急出荷区分
            Dim strXDSPHENSEI_NO As String = ""             '編成№
            Dim strXDSPDENPYOU_NO As String = ""            '伝票№
            Dim strXDSPHINMEI_CD As String = ""             '品名ｺｰﾄﾞ
            Dim strXDSPOUT_ORDER As String = ""             '車輌内出荷品目順

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400103       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strXDSPSYUKKA_D = TO_STRING(lblXSYUKKA_D.Text)        '出荷日
            strXDSPSYARYOU_NO = TO_STRING(txtXSYARYOU_NO.Text)                          '車輌番号
            strXDSPTUMI_HOUKOU = TO_STRING(cboXTUMI_HOUKOU.SelectedValue)               '積込方向
            strXDSPTUMI_HOUHOU = TO_STRING(cboXTUMI_HOUHOU.SelectedValue)               '積込方法
            strXDSPBERTH_NO = TO_STRING(cboXBERTH_NO.Text)                              'ﾊﾞｰｽ指定
            strXDSPKINKYU_KBN = TO_STRING(cboXKINKYU_KBN.SelectedValue)                 '緊急出荷区分

            strXDSPHENSEI_NO = TO_STRING(grdList.Item(menmListCol.XHENSEI_NO, ii).Value)            '編成№
            strXDSPDENPYOU_NO = TO_STRING(grdList.Item(menmListCol.XDENPYOU_NO, ii).Value)          '伝票№
            strXDSPHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, ii).Value)            '品名ｺｰﾄﾞ
            strXDSPOUT_ORDER = TO_STRING(grdList.Item(menmListCol.XOUT_ORDER, ii).Value)            '車輌内出荷品目順

            objTelegramSub.SETIN_DATA("XDSPSYUKKA_D", strXDSPSYUKKA_D)                  '出荷日
            objTelegramSub.SETIN_DATA("XDSPSYARYOU_NO", strXDSPSYARYOU_NO)              '車輌番号
            objTelegramSub.SETIN_DATA("XDSPTUMI_HOUKOU", strXDSPTUMI_HOUKOU)            '積込方向
            objTelegramSub.SETIN_DATA("XDSPTUMI_HOUHOU", strXDSPTUMI_HOUHOU)            '積込方法
            objTelegramSub.SETIN_DATA("XDSPBERTH_NO", strXDSPBERTH_NO)                  'ﾊﾞｰｽ指定
            objTelegramSub.SETIN_DATA("XDSPKINKYU_KBN", strXDSPKINKYU_KBN)              '緊急出荷区分
            objTelegramSub.SETIN_DATA("XDSPHENSEI_NO", strXDSPHENSEI_NO)                '編成№
            objTelegramSub.SETIN_DATA("XDSPDENPYOU_NO", strXDSPDENPYOU_NO)              '伝票№
            objTelegramSub.SETIN_DATA("DSPHINMEI_CD", strXDSPHINMEI_CD)                 '品名ｺｰﾄﾞ
            objTelegramSub.SETIN_DATA("XDSPOUT_ORDER", strXDSPOUT_ORDER)                '車輌内出荷品目順

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

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400103       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        'ﾍｯﾀﾞﾃﾞｰﾀ
        objTelegram.SETIN_HEADER("DSPCMD_ID", objTelegram.FORMAT_ID.Substring(objTelegram.FORMAT_ID.Length - 6, 6))              'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

        'ﾃﾞｰﾀ
        objTelegram.SETIN_DATA("XDSPSYUKKA_D", TO_STRING(lblXSYUKKA_D.Text))                    '出荷日
        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", TO_STRING(txtXSYARYOU_NO.Text))                '車輌番号
        objTelegram.SETIN_DATA("XDSPTUMI_HOUKOU", TO_STRING(cboXTUMI_HOUKOU.SelectedValue))     '積込方向
        objTelegram.SETIN_DATA("XDSPTUMI_HOUHOU", TO_STRING(cboXTUMI_HOUHOU.SelectedValue))     '積込方法
        objTelegram.SETIN_DATA("XDSPBERTH_NO", TO_STRING(cboXBERTH_NO.Text))                    'ﾊﾞｰｽ指定
        objTelegram.SETIN_DATA("XDSPKINKYU_KBN", TO_STRING(cboXKINKYU_KBN.SelectedValue))       '緊急出荷区分

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM311031_05
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Me.Dispose()
            End If
        End If

    End Sub
#End Region

#Region "　ﾊﾞｰｽNo.ｺﾝﾎﾞﾎﾞｯｸｽ作成                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽNo.ｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <param name="cboBox">ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeXBerth_NO_cbo(ByRef cboBox As cmpMComboBox)

        cboBox.Items.Clear()    '初期化
        cboBox.Items.Add("")    '全選択 追加

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO "                  '出荷ﾊﾞｰｽ状況.     ﾊﾞｰｽNo.
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                            '【出荷ﾊﾞｰｽ状況】
        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XBERTH_NO "                             '出荷ﾊﾞｰｽ状況.     ﾊﾞｰｽNo.
        strSQL &= vbCrLf
        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_BERTH"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '(1件ずつ追加)
                cboBox.Items.Add(TO_STRING(objRow("XBERTH_NO")))

            Next
        End If

        '********************************************************************
        ' 初期表示
        '********************************************************************
        If IsNull(mobjXPLN_OUT.XBERTH_NO) = False Then
            cboBox.Text = mobjXPLN_OUT.XBERTH_NO
        End If

    End Sub
#End Region

End Class
