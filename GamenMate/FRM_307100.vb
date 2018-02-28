'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ(出庫予定数)画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_307100

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXMAINTE_KUBUN                           'ﾒﾝﾃﾅﾝｽ区分

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        RefreshBtn_Click                '表示更新ﾎﾞﾀﾝｸﾘｯｸ時
        Settei_Click                    '設定数ﾎﾞﾀﾝｸﾘｯｸ時
        Genzai_Click                    '現在数ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        XMAINTE_NAME                    'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ.         ﾒﾝﾃﾅﾝｽ表示名
        FEQ_ID01                        'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ.         設備ID(設定値)
        FEQ_STS01                       '設備状況.              設備状態(設定値)
        FEQ_ID02                        'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ.         設備ID(現在値)
        FEQ_STS02                       '設備状況.              設備状態(現在値)
        XMAINTE_ORDER                   'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ.         ﾒﾝﾃﾅﾝｽ区分順

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義　                             "

    '検索条件
    Private Structure SEARCH_ITEM
        Dim XMAINTE_KUBUN As String        'ﾒﾝﾃﾅﾝｽ区分
    End Structure

#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨ                                  "
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ｸﾞﾘｯﾄﾞ01     選択変更ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ01 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList01.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ01 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList01)
                If 0 < grdList01.SelectedRows.Count Then
                    txtList01.Text = grdList01.SelectedRows(0).Index
                Else
                    txtList01.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ02     選択変更ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ02 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList02.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ02 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList02)
                If 0 < grdList02.SelectedRows.Count Then
                    txtList02.Text = grdList02.SelectedRows(0).Index
                Else
                    txtList02.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ03     選択変更ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ03 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList03_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList03.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ03 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList03)
                If 0 < grdList03.SelectedRows.Count Then
                    txtList03.Text = grdList03.SelectedRows(0).Index
                Else
                    txtList03.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ04     選択変更ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ04 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList04_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList04.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ04 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList04)
                If 0 < grdList04.SelectedRows.Count Then
                    txtList04.Text = grdList04.SelectedRows(0).Index
                Else
                    txtList04.Text = -1
                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ01ﾀﾞﾌﾞﾙｸﾘｯｸ    ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ01ﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList01.DoubleClick
        Try

            '********************************************************************
            'ﾘｽﾄ選択ﾁｪｯｸ
            '********************************************************************
            If grdList01.SelectedRows.Count < 1 Then
                Exit Try
            End If


            '****************************************
            ' ｸﾞﾘｯﾄﾞ01 選択変更処理
            '****************************************
            Call grdListChangeColor_Selection(grdList01)
            If 0 < grdList01.SelectedRows.Count Then
                txtList01.Text = grdList01.SelectedRows(0).Index
            Else
                txtList01.Text = -1
            End If


            '********************************************************************
            'F6押下処理
            '********************************************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ02ﾀﾞﾌﾞﾙｸﾘｯｸ    ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ02ﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList02.DoubleClick
        Try

            '********************************************************************
            'ﾘｽﾄ選択ﾁｪｯｸ
            '********************************************************************
            If grdList02.SelectedRows.Count < 1 Then
                Exit Try
            End If


            '****************************************
            ' ｸﾞﾘｯﾄﾞ02 選択変更処理
            '****************************************
            Call grdListChangeColor_Selection(grdList02)
            If 0 < grdList02.SelectedRows.Count Then
                txtList02.Text = grdList02.SelectedRows(0).Index
            Else
                txtList02.Text = -1
            End If


            '********************************************************************
            'F6押下処理
            '********************************************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ03ﾀﾞﾌﾞﾙｸﾘｯｸ    ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ03ﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList03_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList03.DoubleClick
        Try

            '********************************************************************
            'ﾘｽﾄ選択ﾁｪｯｸ
            '********************************************************************
            If grdList03.SelectedRows.Count < 1 Then
                Exit Try
            End If


            '****************************************
            ' ｸﾞﾘｯﾄﾞ03 選択変更処理
            '****************************************
            Call grdListChangeColor_Selection(grdList03)
            If 0 < grdList03.SelectedRows.Count Then
                txtList03.Text = grdList03.SelectedRows(0).Index
            Else
                txtList03.Text = -1
            End If


            '********************************************************************
            'F6押下処理
            '********************************************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ04ﾀﾞﾌﾞﾙｸﾘｯｸ    ｲﾍﾞﾝﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ04ﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList04_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList04.DoubleClick
        Try

            '********************************************************************
            'ﾘｽﾄ選択ﾁｪｯｸ
            '********************************************************************
            If grdList04.SelectedRows.Count < 1 Then
                Exit Try
            End If

            '****************************************
            ' ｸﾞﾘｯﾄﾞ04 選択変更処理
            '****************************************
            Call grdListChangeColor_Selection(grdList04)
            If 0 < grdList04.SelectedRows.Count Then
                txtList04.Text = grdList04.SelectedRows(0).Index
            Else
                txtList04.Text = -1
            End If


            '********************************************************************
            'F6押下処理
            '********************************************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr307100_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr307100.Tick
        Try

            tmr307100.Enabled = False
            mFlag_Form_Load = True


            '********************************************************************
            'F1押下処理
            '********************************************************************
            Call F1Process()


        Catch ex As Exception
            ComError(ex)
        Finally
            mFlag_Form_Load = False
            tmr307100.Enabled = True

        End Try
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        cmdF1.Visible = False


        '**********************************************************
        ' ﾃｷｽﾄ初期化
        '**********************************************************
        txtList01.Text = -1
        txtList01.Visible = False
        txtList02.Text = -1
        txtList02.Visible = False
        txtList03.Text = -1
        txtList03.Visible = False
        txtList04.Text = -1
        txtList04.Visible = False


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList01, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList02, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList03, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList04, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定

        grdList01.Font = New Font("ＭＳ ゴシック", 10, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        grdList02.Font = New Font("ＭＳ ゴシック", 10, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        grdList03.Font = New Font("ＭＳ ゴシック", 10, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        grdList04.Font = New Font("ＭＳ ゴシック", 10, FontStyle.Bold)                 'ﾌｫﾝﾄ設定


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplay(grdList01, XMAINTE_KUBUN_YOTEI_OUT_GP01)
        Call grdListDisplay(grdList02, XMAINTE_KUBUN_YOTEI_OUT_GP02)
        Call grdListDisplay(grdList03, XMAINTE_KUBUN_YOTEI_OUT_GP03)
        Call grdListDisplay(grdList04, XMAINTE_KUBUN_YOTEI_OUT_GP04)


        tmr307100.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS307100_001))
        tmr307100.Enabled = True


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")

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
        grdList01.Dispose()
        grdList02.Dispose()
        grdList03.Dispose()
        grdList04.Dispose()
        tmr307100.Dispose()

    End Sub
#End Region
#Region "  F1(表示更新)    ﾎﾞﾀﾝ押下処理　           "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.RefreshBtn_Click) = False Then
            Exit Sub
        End If


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        grdList01.ScrollBars = ScrollBars.None
        grdList02.ScrollBars = ScrollBars.None
        grdList03.ScrollBars = ScrollBars.None
        grdList04.ScrollBars = ScrollBars.None

        Call grdListDisplay(grdList01, XMAINTE_KUBUN_YOTEI_OUT_GP01)
        Call grdListDisplay(grdList02, XMAINTE_KUBUN_YOTEI_OUT_GP02)
        Call grdListDisplay(grdList03, XMAINTE_KUBUN_YOTEI_OUT_GP03)
        Call grdListDisplay(grdList04, XMAINTE_KUBUN_YOTEI_OUT_GP04)

        grdList01.ScrollBars = ScrollBars.Both
        grdList02.ScrollBars = ScrollBars.Both
        grdList03.ScrollBars = ScrollBars.Both
        grdList04.ScrollBars = ScrollBars.Both

        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F6(ﾒﾝﾃﾅﾝｽ)      ﾎﾞﾀﾝ押下処理　           "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Settei_Click) = False Then
            Exit Sub
        End If

        tmr307100.Enabled = False

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_307101) = False Then
            gobjFRM_307101.Close()
            gobjFRM_307101.Dispose()
            gobjFRM_307101 = Nothing
        End If

        gobjFRM_307101 = New FRM_307101

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_307101.ShowDialog()            '展開

        tmr307100.Enabled = True

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList01)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F7(現在値変更)      ﾎﾞﾀﾝ押下処理　           "
    '*******************************************************************************************************************
    '【機能】F7  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Genzai_Click) = False Then
            Exit Sub
        End If

        tmr307100.Enabled = False

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_307101) = False Then
            gobjFRM_307101.Close()
            gobjFRM_307101.Dispose()
            gobjFRM_307101 = Nothing
        End If

        gobjFRM_307101 = New FRM_307101

        Call SetProperty2()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_307101.ShowDialog()            '展開

        tmr307100.Enabled = True

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList01)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strXMAINTE_KUBUN">ﾒﾝﾃﾅﾝｽ区分</param>
    ''' <param name="intIdx"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid, _
                               ByVal strXMAINTE_KUBUN As String, _
                               Optional ByVal intIdx As Integer = -1)

        Dim strSQL As String                            'SQL文
        Dim objDataSet2 As New DataSet
        'Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
        Dim intGouki As Integer                         '号機のｶｳﾝﾄ
        'objDataTable.Clear()
        intGouki = 1

        '********************************************************************
        ' DB情報取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "      A.XMAINTE_NAME "
        strSQL &= vbCrLf & "     ,A.FEQ_ID02 "
        strSQL &= vbCrLf & "     ,B02.FEQ_STS "
        strSQL &= vbCrLf & "     ,A.FEQ_ID01 "
        strSQL &= vbCrLf & "     ,B01.FEQ_STS "
        strSQL &= vbCrLf & "     ,A.XMAINTE_ORDER "
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "      (SELECT XDSP_PLC_MAINTE.XEQ_ID_MAINTE  "
        strSQL &= vbCrLf & "             ,SUBSTR(XDSP_PLC_MAINTE.XEQ_ID_MAINTE,0,15) AS FEQ_ID01  "
        strSQL &= vbCrLf & "             ,SUBSTR(XDSP_PLC_MAINTE.XEQ_ID_MAINTE,17,15) AS FEQ_ID02 "
        strSQL &= vbCrLf & "             ,XDSP_PLC_MAINTE.XMAINTE_NAME "
        strSQL &= vbCrLf & "             ,XDSP_PLC_MAINTE.XMAINTE_ORDER "
        strSQL &= vbCrLf & "       FROM XDSP_PLC_MAINTE "
        strSQL &= vbCrLf & "       WHERE XDSP_PLC_MAINTE.XMAINTE_KUBUN = '" & strXMAINTE_KUBUN & "'"
        strSQL &= vbCrLf & "      ) A "
        strSQL &= vbCrLf & "      ,TSTS_EQ_CTRL B01 "
        strSQL &= vbCrLf & "      ,TSTS_EQ_CTRL B02 "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "       1 = 1"
        strSQL &= vbCrLf & "   AND A.FEQ_ID01 = B01.FEQ_ID "
        strSQL &= vbCrLf & "   AND A.FEQ_ID02 = B02.FEQ_ID "
        strSQL &= vbCrLf & " ORDER BY"
        strSQL &= vbCrLf & "       A.XMAINTE_ORDER"


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        If grdControl.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdControl.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdControl.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        objPoint.X = grdControl.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        objPoint.Y = grdControl.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdControl, strSQL, False)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/08/17 D41,D42の追加、対応
        'D41、D42には設定数が存在しないため、表示を変更する
        If grdControl Is grdList04 Then

            Dim objDataTable As System.Data.DataTable
            objDataTable = grdControl.DataSource
            Dim i As Integer
            For i = 0 To objDataTable.Rows.Count - 1
                If TO_STRING(objDataTable.Rows(i).Item(0).ToString = "D41") Then
                    objDataTable.Rows(i).Item(2) = "---"

                ElseIf TO_STRING(objDataTable.Rows(i).Item(0).ToString = "D42") Then
                    objDataTable.Rows(i).Item(2) = "---"
                End If
            Next
        End If

        '↑↑↑↑↑↑************************************************************************************************************



        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdControl)
        grdControl.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdControl.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdControl, intSelectRow, 2, objPoint)    'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup(ByVal grdList As GamenCommon.cmpMDataGrid)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        grdList.Columns(menmListCol.XMAINTE_NAME).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


        '=========================================
        '行の高さ
        '=========================================
        For ii As Integer = 0 To grdList.Rows.Count - 1
            grdList.Rows(ii).Height = 18
        Next


        '************************************************
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True/False</returns>
    ''' <remarks>戻値 = True :入力ﾁｪｯｸ成功/False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.RefreshBtn_Click
                '(表示更新ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False


            Case menmCheckCase.Settei_Click
                '(設定数ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If TO_INTEGER(txtList01.Text) = -1 And TO_INTEGER(txtList02.Text) = -1 And TO_INTEGER(txtList03.Text) = -1 And TO_INTEGER(txtList04.Text) = -1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                'D41、D42の場合
                If TO_INTEGER(txtList04.Text) <> -1 Then
                    Dim strSTNO As String = TO_STRING(grdList04.Item(menmListCol.XMAINTE_NAME, grdList04.SelectedRows(0).Index).Value)            'ST№

                    If strSTNO = "D41" Or strSTNO = "D42" Then
                        Call gobjComFuncFRM.DisplayPopup("選択されているSTでは設定数の変更はできません。", PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                blnCheckErr = False

            Case menmCheckCase.Genzai_Click
                '(現在数ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If TO_INTEGER(txtList01.Text) = -1 And TO_INTEGER(txtList02.Text) = -1 And TO_INTEGER(txtList03.Text) = -1 And TO_INTEGER(txtList04.Text) = -1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
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
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        If TO_INTEGER(txtList01.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList01.Item(menmListCol.XMAINTE_NAME, grdList01.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList01.Item(menmListCol.FEQ_ID01, grdList01.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList01.Item(menmListCol.FEQ_STS01, grdList01.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList01.Item(menmListCol.FEQ_ID02, grdList01.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList01.Item(menmListCol.FEQ_STS02, grdList01.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList02.Item(menmListCol.XMAINTE_NAME, grdList02.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList02.Item(menmListCol.FEQ_ID01, grdList02.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList02.Item(menmListCol.FEQ_STS01, grdList02.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList02.Item(menmListCol.FEQ_ID02, grdList02.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList02.Item(menmListCol.FEQ_STS02, grdList02.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList03.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList03.Item(menmListCol.XMAINTE_NAME, grdList03.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList03.Item(menmListCol.FEQ_ID01, grdList03.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList03.Item(menmListCol.FEQ_STS01, grdList03.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList03.Item(menmListCol.FEQ_ID02, grdList03.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList03.Item(menmListCol.FEQ_STS02, grdList03.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList04.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList04.Item(menmListCol.XMAINTE_NAME, grdList04.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList04.Item(menmListCol.FEQ_ID01, grdList04.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList04.Item(menmListCol.FEQ_STS01, grdList04.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList04.Item(menmListCol.FEQ_ID02, grdList04.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList04.Item(menmListCol.FEQ_STS02, grdList04.SelectedRows(0).Index).Value)       '現在数

        End If

        gobjFRM_307101.userPLC_Mainte_Target = 1

    End Sub

#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ2　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ2
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()

        If TO_INTEGER(txtList01.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList01.Item(menmListCol.XMAINTE_NAME, grdList01.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList01.Item(menmListCol.FEQ_ID01, grdList01.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList01.Item(menmListCol.FEQ_STS01, grdList01.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList01.Item(menmListCol.FEQ_ID02, grdList01.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList01.Item(menmListCol.FEQ_STS02, grdList01.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList02.Item(menmListCol.XMAINTE_NAME, grdList02.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList02.Item(menmListCol.FEQ_ID01, grdList02.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList02.Item(menmListCol.FEQ_STS01, grdList02.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList02.Item(menmListCol.FEQ_ID02, grdList02.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList02.Item(menmListCol.FEQ_STS02, grdList02.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList03.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList03.Item(menmListCol.XMAINTE_NAME, grdList03.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList03.Item(menmListCol.FEQ_ID01, grdList03.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList03.Item(menmListCol.FEQ_STS01, grdList03.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList03.Item(menmListCol.FEQ_ID02, grdList03.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList03.Item(menmListCol.FEQ_STS02, grdList03.SelectedRows(0).Index).Value)       '現在数

        ElseIf TO_INTEGER(txtList04.Text) <> -1 Then
            gobjFRM_307101.userPLC_STNO = TO_STRING(grdList04.Item(menmListCol.XMAINTE_NAME, grdList04.SelectedRows(0).Index).Value)            'ST№
            gobjFRM_307101.userPLC_FEQ_ID01 = TO_STRING(grdList04.Item(menmListCol.FEQ_ID01, grdList04.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL01 = TO_STRING(grdList04.Item(menmListCol.FEQ_STS01, grdList04.SelectedRows(0).Index).Value)       '設定数
            gobjFRM_307101.userPLC_FEQ_ID02 = TO_STRING(grdList04.Item(menmListCol.FEQ_ID02, grdList04.SelectedRows(0).Index).Value)            '設備ID
            gobjFRM_307101.userPLC_FEQ_ID_VOL02 = TO_STRING(grdList04.Item(menmListCol.FEQ_STS02, grdList04.SelectedRows(0).Index).Value)       '現在数

        End If

        gobjFRM_307101.userPLC_Mainte_Target = 2

    End Sub

#End Region
#Region "  選択変更時のｸﾞﾘｯﾄﾞ色変え                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択変更時のｸﾞﾘｯﾄﾞ色変え
    ''' </summary>
    ''' <param name="grdList"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor_Selection(ByRef grdList As GamenCommon.cmpMDataGrid)

        If mFlag_Form_Load = True Then Exit Sub
        If grdList.SelectedRows.Count < 1 Then Exit Sub

        ' 選択されていない方の、選択状態を解除
        If grdList Is grdList01 Then
            Call grdList02.ClearSelection()
            txtList02.Text = -1
            Call grdList03.ClearSelection()
            txtList03.Text = -1
            Call grdList04.ClearSelection()
            txtList04.Text = -1

        ElseIf grdList Is grdList02 Then
            Call grdList01.ClearSelection()
            txtList01.Text = -1
            Call grdList03.ClearSelection()
            txtList03.Text = -1
            Call grdList04.ClearSelection()
            txtList04.Text = -1

        ElseIf grdList Is grdList03 Then
            Call grdList01.ClearSelection()
            txtList01.Text = -1
            Call grdList02.ClearSelection()
            txtList02.Text = -1
            Call grdList04.ClearSelection()
            txtList04.Text = -1

        ElseIf grdList Is grdList04 Then
            Call grdList01.ClearSelection()
            txtList01.Text = -1
            Call grdList02.ClearSelection()
            txtList02.Text = -1
            Call grdList03.ClearSelection()
            txtList03.Text = -1

        Else
            Call grdList01.ClearSelection()
            txtList01.Text = -1
            Call grdList02.ClearSelection()
            txtList02.Text = -1
            Call grdList03.ClearSelection()
            txtList03.Text = -1
            Call grdList04.ClearSelection()
            txtList04.Text = -1

        End If

    End Sub
#End Region

End Class
