'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷指示画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_311030

#Region "　共通変数　                           "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYARYOU_ENTRY_DT       '出荷指示.        車輌受付日時
        XSYUKKA_D               '出荷指示.        出荷日時
        XHENSEI_NO              '出荷指示.        編成№
        XHENSEI_NO_OYA          '出荷指示.        親編成No
        XDENPYOU_NO             '出荷指示.　　　　伝票No.
        XBUNRUI_NO              '出荷指示.        分類No.
        XSYARYOU_NO             '出荷指示.        車輌№
        XTUMI_HOUHOU            '出荷指示.　　　　積込方法
        XTUMI_HOUHOU_DISP       '出荷指示.　　　　積込方法(表示用)
        XTUMI_HOUKOU            '出荷指示.　　　　積込方向
        XTUMI_HOUKOU_DISP       '出荷指示.　　　　積込方向(表示用)
        XGYOUSYA_CD             '出荷指示.        業者ｺｰﾄﾞ
        XGYOUSYA_NAME           '出荷指示.        業者名
        XSEND_NAME              '出荷指示.        届先名称
        XSEND_ADDRESS           '出荷指示.        届先住所
        XBERTH_NO               '出荷指示.        ﾊﾞｰｽNo.
        XKINKYU_KBN             '出荷維持.        緊急出荷区分
        XKINKYU_LEVEL           '出荷指示.        緊急度
        XSYUKKA_DIR_DT          '出荷指示.        出荷指示日時
        XOUT_START_DT           '出荷指示.        出庫開始日時
        XOUT_END_DT             '出荷指示.        出庫完了日時
        XTUMI_END_DT            '出荷指示.        積込完了日時
        XSYUKKA_STS             '出荷指示.        出荷状況

        MAXCOL                   'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        ShukkaBtn_Click         '出荷指示ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾀｲﾏｰ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ処理 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311030_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr311030.Tick
        Try

            tmr311030.Enabled = False
            mFlag_Form_Load = True

            '************************************
            ' ｸﾞﾘｯﾄﾞ表示
            '************************************
            grdList.ScrollBars = ScrollBars.None
            Call grdListDisplaySub(grdList)
            grdList.ScrollBars = ScrollBars.Both

        Catch ex As Exception
            ComError(ex)
        Finally
            mFlag_Form_Load = False
            tmr311030.Enabled = True

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "  構造体定義                           "
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        grdList.ScrollBars = ScrollBars.None
        Call grdListDisplaySub(grdList)
        grdList.ScrollBars = ScrollBars.Both


        tmr311030.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS311030_001))
        tmr311030.Enabled = True

        mFlag_Form_Load = False

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
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F4(出荷指示)　ﾎﾞﾀﾝ押下処理　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.ShukkaBtn_Click) = False Then
            Exit Sub
        End If

        tmr311030.Enabled = False

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311031) = False Then
            gobjFRM_311031.Close()
            gobjFRM_311031.Dispose()
            gobjFRM_311031 = Nothing
        End If
        gobjFRM_311031 = New FRM_311031
        Call SetProperty()                                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ



        Dim intRet As DialogResult
        intRet = gobjFRM_311031.ShowDialog()            '展開

        tmr311030.Enabled = True

        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        grdList.ScrollBars = ScrollBars.None
        Call grdListDisplaySub(grdList)
        grdList.ScrollBars = ScrollBars.Both


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
            Case menmCheckCase.ShukkaBtn_Click
                '(出荷指示ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
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
#Region "　構造体ｾｯﾄ　                          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
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
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYARYOU_ENTRY_DT "                        '出荷指示.  　　車輌受付日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_D "                                '出荷指示.  　　出荷日付
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO "                               '出荷指示.      編成No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA "                           '出荷指示.  　　親編成No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XDENPYOU_NO "                              '出荷指示.      伝票No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XBUNRUI_NO "                               '出荷指示.      分類No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO "                              '出荷指示.      車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU "                             '出荷指示.      積込方法
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XTUMI_HOUHOU_Dsp "            '出荷指示.      積込方法(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU "                             '出荷指示.      積込方向
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XTUMI_HOUKOU_Dsp "            '出荷指示.      積込方向(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XGYOUSYA_CD "                              '出荷指示.      業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XMST_GYOUSYA.XGYOUSYA_NAME "                        '業者ﾏｽﾀ.       業者名
        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_NAME "                               '出荷指示.      届先名称
        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_ADDRESS "                            '出荷指示.      届先住所
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO "                                '出荷指示.      ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_KBN "                              '出荷指示.      緊急出荷区分
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_LEVEL "                            '出荷指示.      緊急度
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_DIR_DT "                           '出荷指示.  　　出荷指示日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT "                            '出荷指示.  　　出庫開始日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XOUT_END_DT "                              '出荷指示.  　　出庫完了日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_END_DT "                             '出荷指示.  　　積込完了日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS "                              '出荷指示.  　　出荷状況

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      XPLN_OUT "                                        '【出荷指示】
        strSQL &= vbCrLf & "    , XMST_GYOUSYA "                                    '【業者ﾏｽﾀ】
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_OUT", "XTUMI_HOUKOU")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XGYOUSYA_CD = XMST_GYOUSYA.XGYOUSYA_CD(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_OUT", "XTUMI_HOUKOU")
        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_STS = " & XSYUKKA_STS_JREQ          '出荷指示.       出荷状況
        'strSQL &= vbCrLf & "     AND XPLN_OUT.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA"       '出荷指示.       編成No.=親編成No.



        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf



        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                False, _
                                False, _
                                intSelectRow, _
                                intSelectCol, _
                                objPoint)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
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


    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】 
    '*******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_311031.userXSYUKKA_D = TO_STRING(grdList.Item(menmListCol.XSYUKKA_D, grdList.SelectedRows(0).Index).Value)      '出荷日
        gobjFRM_311031.userXHENSEI_NO = TO_STRING(grdList.Item(menmListCol.XHENSEI_NO, grdList.SelectedRows(0).Index).Value)    '編成№
        gobjFRM_311031.userXDENPYOU_NO = TO_STRING(grdList.Item(menmListCol.XDENPYOU_NO, grdList.SelectedRows(0).Index).Value)    '伝票№

    End Sub
#End Region

End Class
