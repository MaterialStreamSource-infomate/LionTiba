'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｼｽﾃﾑｴﾗｰﾛｸﾞ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207020

#Region "　共通変数　                           "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FHASSEI_DT                       'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       発生日時
        FPROC_CD                         'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       処理コード
        FLOG_DATA                        'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       異常内容
        FLOG_NO                          'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       ﾛｸﾞ№

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義                           "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim KIKAN_FROM As String        '期間(FROM)
        Dim KIKAN_TO As String          '期間(TO)
    End Structure
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


    End Sub
#End Region
#Region "  F1(検索)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(検索) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then

            Exit Sub

        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
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
        dtpFrom.Dispose()
        dtpTo.Dispose()
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                '********************************************************************
                '日付文字列作成
                '********************************************************************
                If dtpFrom.userDispChecked <> False And dtpTo.userDispChecked <> False Then
                    '(FROM,TOの日時ｺﾝﾎﾞにﾁｪｯｸが付いているとき)

                    Dim strFrom As String                   'From
                    Dim strTo As String                     'To
                    strFrom = dtpFrom.userDateTimeText
                    strTo = dtpTo.userDateTimeText


                    '********************************************************************
                    '入力ﾁｪｯｸ
                    '********************************************************************
                    '==========================
                    '期間
                    '==========================
                    If CDate(strFrom) > CDate(strTo) Then
                        ' 期間の大小関係
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_DTP_KIKAN_TIME_02, PopupFormType.Ok, PopupIconType.Information)
                        Exit Select
                    End If

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
#Region "　構造体ｾｯﾄ　                          "
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
        '期間(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            mudtSEARCH_ITEM.KIKAN_FROM = dtpFrom.userDateTimeText       '期間FROM
        Else
            mudtSEARCH_ITEM.KIKAN_FROM = ""
        End If

        '===============================================
        '期間(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            mudtSEARCH_ITEM.KIKAN_TO = dtpTo.userDateTimeText           '期間TO
        Else
            mudtSEARCH_ITEM.KIKAN_TO = ""
        End If


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_SYS.FHASSEI_DT "                         'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       発生日時　 
        strSQL &= vbCrLf & "  , TLOG_SYS.FPROC_CD "                           'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       処理コード　
        strSQL &= vbCrLf & "  , TLOG_SYS.FLOG_DATA "                          'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       異常内容
        strSQL &= vbCrLf & "  , TLOG_SYS.FLOG_NO "                            'ｼｽﾃﾑｴﾗｰﾛｸﾞ.       ﾛｸﾞ№
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_SYS "                                    'ｼｽﾃﾑｴﾗｰﾛｸﾞ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        '----------------------------
        'ﾛｸﾞ発生日時
        '----------------------------
        If mudtSEARCH_ITEM.KIKAN_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_SYS.FHASSEI_DT >= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_FROM & "','YYYY/MM/DD HH24:MI:SS')"          'ｼｽﾃﾑｴﾗｰﾛｸﾞ.     発生日時
        End If
        If mudtSEARCH_ITEM.KIKAN_TO <> "" Then
            strSQL &= vbCrLf & "    AND TLOG_SYS.FHASSEI_DT <= TO_DATE('" & mudtSEARCH_ITEM.KIKAN_TO & "','YYYY/MM/DD HH24:MI:SS')"            'ｼｽﾃﾑｴﾗｰﾛｸﾞ.     発生日時
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
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
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
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

        'grdList.Columns(menmListCol.FLOG_DATA).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


    End Sub
#End Region

End Class
