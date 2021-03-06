﻿'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出庫追跡問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304040
#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_D               '出荷実績.          出荷日付
        XHENSEI_NO              '出荷実績.          編成No
        XDENPYOU_NO             '出荷実績.          伝票No
        XSEND_NAME              '出荷実績.          届け先
        XGYOUSYA_CD             '出荷実績.          業者ｺｰﾄﾞ
        XGYOUSYA_NAME           '業者ﾏｽﾀ.           物流業者名称
        XHINMEI_CD              '品名ﾏｽﾀ.           品名記号
        FHINMEI_CD              '出荷実績.          品名ｺｰﾄﾞ
        XPROD_LINE              '出荷実績.          生産ﾗｲﾝ№
        FLOT_NO                 '出荷実績.          ﾛｯﾄNo
        XFM_ST                  '出荷実績.          搬送元ST
        XFM_ST_FBUF_NAME        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        FBUF_FM                 '出荷実績.          搬送元ﾊﾞｯﾌｧNo 
        FBUF_FM_FBUF_NAME       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        FDISP_ADDRESS           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        FBUF_TO                 '出荷実績.          搬送先ﾊﾞｯﾌｧNo 
        FBUF_TO_FBUF_NAME       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        XNUM                    '出荷実績.          数量
        XBERTH_NO               '出荷実績.          ﾊﾞｰｽNo
        XSYARYOU_NO             '出荷実績.          車輌No.

        XSAIMOKU                '出荷実績.          細目
        XIDOU                   '出荷実績.          移動区分
        XSAIMOKU_Disp           '出荷実績.          細目(表示用)
        XARTICLE_TYPE_CODE      '出荷実績.          商品区分
        XARTICLE_TYPE_CODE_Disp '出荷実績.          商品区分(表示用)

        FIN_KUBUN               '出荷実績.          入庫区分
        FIN_KUBUN_Disp          '出荷実績.          入庫区分(表示用)
        XKENPIN_KUBUN           '出荷実績.          検品区分
        XKENPIN_KUBUN_Disp      '出荷実績.          検品区分(表示用)
        FARRIVE_DT              '出荷実績.          在庫発生日時
        XRAC_IN_DT              '出荷実績.          入庫日時
        XSYUKKA_RESULT_DT       '出荷実績.          出荷実績日時

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        CSVPrint_Click              'CSV出力ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_D As String                         '出荷日
        Dim XHENSEI_NO As String                        '編成№
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
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


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '出荷日                ｾｯﾄ
        '===================================
        cboXSYUKKA_D.cmpMDateTimePicker_D.Value = Now       '出荷日
        'cboXSYUKKA_D.userChecked = False                    'ﾁｪｯｸを外す

        '**********************************************************
        ' 編成No            ﾘｾｯﾄ
        '**********************************************************
        txtXHENSEI_NO.Text = ""

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


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
        cboXSYUKKA_D.Dispose()              '出荷日
        txtXHENSEI_NO.Dispose()             '出荷状況
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F6(印刷)　ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(印刷) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CSVPrint_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        'CSV出力処理
        '*******************************************************
        Call CSV_Out()

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
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


                blnCheckErr = False


            Case menmCheckCase.CSVPrint_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
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
        If cboXSYUKKA_D.userDispChecked = True Then
            mudtSEARCH_ITEM.XSYUKKA_D = Mid(cboXSYUKKA_D.userDateTimeText, 1, 10)       '出荷日
        Else
            mudtSEARCH_ITEM.XSYUKKA_D = ""
        End If
        mudtSEARCH_ITEM.XHENSEI_NO = txtXHENSEI_NO.Text                             '編成№

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
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
        strSQL &= vbCrLf & "    XRST_OUT.XSYUKKA_D "                                '出荷実績.          出荷日付
        strSQL &= vbCrLf & "  , XRST_OUT.XHENSEI_NO "                               '出荷実績.          編成No
        strSQL &= vbCrLf & "  , XRST_OUT.XDENPYOU_NO "                              '出荷実績.          伝票No
        strSQL &= vbCrLf & "  , XRST_OUT.XSEND_NAME "                               '出荷実績.          届け先
        strSQL &= vbCrLf & "  , XRST_OUT.XGYOUSYA_CD "                              '出荷実績.          業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH01", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT", "XGYOUSYA_CD") '業者ﾏｽﾀ.           物流業者名称
        strSQL &= vbCrLf & "  , XRST_OUT.XHINMEI_CD "                               '出荷実績.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XRST_OUT.FHINMEI_CD "                               '出荷実績.          品名記号
        strSQL &= vbCrLf & "  , XRST_OUT.XPROD_LINE "                               '出荷実績.          生産ﾗｲﾝ№
        strSQL &= vbCrLf & "  , XRST_OUT.FLOT_NO "                                  '出荷実績.          ﾛｯﾄNo
        strSQL &= vbCrLf & "  , XRST_OUT.XFM_ST "                                   '出荷実績.          搬送元ST
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH02", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "  , XRST_OUT.FBUF_FM "                                  '出荷実績.          搬送元ﾊﾞｯﾌｧNo 
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH03", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FDISP_ADDRESS "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "  , XRST_OUT.FBUF_TO "                                  '出荷実績.          搬送先ﾊﾞｯﾌｧNo 
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH04", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "  , XRST_OUT.XNUM "                                     '出荷実績.          数量
        strSQL &= vbCrLf & "  , XRST_OUT.XBERTH_NO "                                '出荷実績.          ﾊﾞｰｽNo
        strSQL &= vbCrLf & "  , XRST_OUT.XSYARYOU_NO "                              '出荷実績.          車輌No.

        strSQL &= vbCrLf & "  , XRST_OUT.XSAIMOKU "                                 '出荷実績.          細目
        strSQL &= vbCrLf & "  , XRST_OUT.XIDOU_KBN "                                '出荷実績.          移動区分
        strSQL &= vbCrLf & "  , (case XRST_OUT.XSAIMOKU "                           '出荷実績.          細目(表示用)
        strSQL &= vbCrLf & "        when '162' then "                               '細目=162 かつ 移動区分=1 の場合 移動-1 に変更
        strSQL &= vbCrLf & "            (case XRST_OUT.XIDOU_KBN "
        strSQL &= vbCrLf & "                when '1' then "
        strSQL &= vbCrLf & "                    '移動-1' "
        strSQL &= vbCrLf & "                else "
        strSQL &= vbCrLf & "                    HASH07.FGAMEN_DISP "
        strSQL &= vbCrLf & "            end) "
        strSQL &= vbCrLf & "        else "
        strSQL &= vbCrLf & "            HASH07.FGAMEN_DISP "
        strSQL &= vbCrLf & "    end) AS XSAIMOKU_Dsp "
        strSQL &= vbCrLf & "  , XRST_OUT.XARTICLE_TYPE_CODE "                       '出荷実績.          商品区分
        strSQL &= vbCrLf & "  , HASH08.FGAMEN_DISP AS XARTICLE_TYPE_CODE_Dsp "      '出荷実績.          商品区分(表示用)

        strSQL &= vbCrLf & "  , XRST_OUT.FIN_KUBUN "                                '出荷実績.          入庫区分
        strSQL &= vbCrLf & "  , HASH05.FGAMEN_DISP AS FIN_KUBUN_Dsp "               '出荷実績.          入庫区分(表示用)
        strSQL &= vbCrLf & "  , XRST_OUT.XKENPIN_KUBUN "                            '出荷実績.          検品区分
        strSQL &= vbCrLf & "  , HASH06.FGAMEN_DISP AS XKENPIN_KUBUN_Dsp "           '出荷実績.          検品区分(表示用)
        strSQL &= vbCrLf & "  , XRST_OUT.FARRIVE_DT "                               '出荷実績.          在庫発生日時
        strSQL &= vbCrLf & "  , XRST_OUT.XRAC_IN_DT "                               '出荷実績.          入庫日時
        strSQL &= vbCrLf & "  , XRST_OUT.XSYUKKA_RESULT_DT "                        '出荷実績.          出荷実績日時

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XRST_OUT "                                             '【出荷実績】
        strSQL &= vbCrLf & "    ,TPRG_TRK_BUF "                                         '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH01", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT", "XGYOUSYA_CD")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH02", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH03", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH04", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "XRST_OUT", "FIN_KUBUN")                                                    '出荷実績.   入庫区分
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "XRST_OUT", "XKENPIN_KUBUN")                                                '出荷実績.   検品区分
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH07", "XRST_OUT", "XSAIMOKU")                                                     '出荷実績.   細目
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH08", "XRST_OUT", "XARTICLE_TYPE_CODE")                                           '出荷実績.   商品区分


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XRST_OUT.FBUF_FM  = TPRG_TRK_BUF.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND XRST_OUT.FARRAY_FM  = TPRG_TRK_BUF.FTRK_BUF_ARRAY(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH01", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT", "XGYOUSYA_CD")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH02", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH03", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH04", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "XRST_OUT", "FIN_KUBUN")                                                    '出荷実績.   入庫区分
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "XRST_OUT", "XKENPIN_KUBUN")                                                '出荷実績.   検品区分
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH07", "XRST_OUT", "XSAIMOKU")                                                     '出荷実績.   細目
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH08", "XRST_OUT", "XARTICLE_TYPE_CODE")                                           '出荷実績.   商品区分

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_D <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TO_DATE(TO_CHAR(XRST_OUT.XSYUKKA_D, 'YYYY/MM/DD')) = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        End If

        '----------------------------
        '編成№
        '----------------------------
        If mudtSEARCH_ITEM.XHENSEI_NO <> "" Then
            strSQL &= vbCrLf & "    AND XRST_OUT.XHENSEI_NO = '" & mudtSEARCH_ITEM.XHENSEI_NO & "' "
        End If



        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/11/01 出荷追跡問合せ画面 当日分ﾃﾞｰﾀ表示
        strSQL &= vbCrLf & "UNION ALL"
        strSQL &= vbCrLf
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XRST_OUT_DTL.XSYUKKA_D "                                '出荷実績.          出荷日付
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XHENSEI_NO "                               '出荷実績.          編成No
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XDENPYOU_NO "                              '出荷実績.          伝票No
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XSEND_NAME "                               '出荷実績.          届け先
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XGYOUSYA_CD "                              '出荷実績.          業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH11", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT_DTL", "XGYOUSYA_CD") '業者ﾏｽﾀ.           物流業者名称
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XHINMEI_CD "                               '出荷実績.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FHINMEI_CD "                               '出荷実績.          品名記号
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XPROD_LINE "                               '出荷実績.          生産ﾗｲﾝ№
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FLOT_NO "                                  '出荷実績.          ﾛｯﾄNo
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XFM_ST "                                   '出荷実績.          搬送元ST
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH12", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FBUF_FM "                                  '出荷実績.          搬送元ﾊﾞｯﾌｧNo 
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH13", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FDISP_ADDRESS "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FBUF_TO "                                  '出荷実績.          搬送先ﾊﾞｯﾌｧNo 
        strSQL &= vbCrLf & "  ," & gobjComFuncFRM.GetSQLHashTableSelect02("HASH14", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XNUM "                                     '出荷実績.          数量
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XBERTH_NO "                                '出荷実績.          ﾊﾞｰｽNo
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XSYARYOU_NO "                              '出荷実績.          車輌No.

        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XSAIMOKU "                                 '出荷実績.          細目
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XIDOU_KBN "                                '出荷実績.          移動区分
        strSQL &= vbCrLf & "  , (case XRST_OUT_DTL.XSAIMOKU "                           '出荷実績.          細目(表示用)
        strSQL &= vbCrLf & "        when '162' then "                               '細目=162 かつ 移動区分=1 の場合 移動-1 に変更
        strSQL &= vbCrLf & "            (case XRST_OUT_DTL.XIDOU_KBN "
        strSQL &= vbCrLf & "                when '1' then "
        strSQL &= vbCrLf & "                    '移動-1' "
        strSQL &= vbCrLf & "                else "
        strSQL &= vbCrLf & "                    HASH17.FGAMEN_DISP "
        strSQL &= vbCrLf & "            end) "
        strSQL &= vbCrLf & "        else "
        strSQL &= vbCrLf & "            HASH17.FGAMEN_DISP "
        strSQL &= vbCrLf & "    end) AS XSAIMOKU_Dsp "
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XARTICLE_TYPE_CODE "                       '出荷実績.          商品区分
        strSQL &= vbCrLf & "  , HASH18.FGAMEN_DISP AS XARTICLE_TYPE_CODE_Dsp "      '出荷実績.          商品区分(表示用)

        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FIN_KUBUN "                                '出荷実績.          入庫区分
        strSQL &= vbCrLf & "  , HASH15.FGAMEN_DISP AS FIN_KUBUN_Dsp "               '出荷実績.          入庫区分(表示用)
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XKENPIN_KUBUN "                            '出荷実績.          検品区分
        strSQL &= vbCrLf & "  , HASH16.FGAMEN_DISP AS XKENPIN_KUBUN_Dsp "           '出荷実績.          検品区分(表示用)
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.FARRIVE_DT "                               '出荷実績.          在庫発生日時
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XRAC_IN_DT "                               '出荷実績.          入庫日時
        strSQL &= vbCrLf & "  , XRST_OUT_DTL.XSYUKKA_RESULT_DT "                        '出荷実績.          出荷実績日時

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XRST_OUT_DTL "                                             '【出荷実績】
        strSQL &= vbCrLf & "    ,TPRG_TRK_BUF "                                         '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH11", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT_DTL", "XGYOUSYA_CD")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH12", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH13", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH14", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH15", "XRST_OUT_DTL", "FIN_KUBUN")                                                    '出荷実績.   入庫区分
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH16", "XRST_OUT_DTL", "XKENPIN_KUBUN")                                                '出荷実績.   検品区分
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH17", "XRST_OUT_DTL", "XSAIMOKU")                                                     '出荷実績.   細目
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH18", "XRST_OUT_DTL", "XARTICLE_TYPE_CODE")                                           '出荷実績.   商品区分


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XRST_OUT_DTL.FBUF_FM  = TPRG_TRK_BUF.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND XRST_OUT_DTL.FARRAY_FM  = TPRG_TRK_BUF.FTRK_BUF_ARRAY(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH11", "XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_NAME", "XRST_OUT_DTL", "XGYOUSYA_CD")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH12", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "XFM_ST")               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送元ST)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH13", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_FM")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH14", "TMST_TRK", "FTRK_BUF_NO", "FBUF_NAME", "XRST_OUT_DTL", "FBUF_TO")              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(搬送先ST)
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH15", "XRST_OUT_DTL", "FIN_KUBUN")                                                    '出荷実績.   入庫区分
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH16", "XRST_OUT_DTL", "XKENPIN_KUBUN")                                                '出荷実績.   検品区分
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH17", "XRST_OUT_DTL", "XSAIMOKU")                                                     '出荷実績.   細目
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH18", "XRST_OUT_DTL", "XARTICLE_TYPE_CODE")                                           '出荷実績.   商品区分

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_D <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TO_DATE(TO_CHAR(XRST_OUT_DTL.XSYUKKA_D, 'YYYY/MM/DD')) = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        End If

        '----------------------------
        '編成№
        '----------------------------
        If mudtSEARCH_ITEM.XHENSEI_NO <> "" Then
            strSQL &= vbCrLf & "    AND XRST_OUT_DTL.XHENSEI_NO = '" & mudtSEARCH_ITEM.XHENSEI_NO & "' "
        End If

        strSQL &= vbCrLf & "    AND NOT EXISTS("
        strSQL &= vbCrLf & "               SELECT"
        strSQL &= vbCrLf & "                  *"
        strSQL &= vbCrLf & "               FROM"
        strSQL &= vbCrLf & "                  XRST_OUT"
        strSQL &= vbCrLf & "               WHERE"
        strSQL &= vbCrLf & "                      XRST_OUT.XSYUKKA_D         = XRST_OUT_DTL.XSYUKKA_D"              '出荷日
        strSQL &= vbCrLf & "                  AND XRST_OUT.XHENSEI_NO        = XRST_OUT_DTL.XHENSEI_NO"             '編成No.
        strSQL &= vbCrLf & "                  AND XRST_OUT.XDENPYOU_NO       = XRST_OUT_DTL.XDENPYOU_NO"            '伝票No.
        strSQL &= vbCrLf & "                  AND XRST_OUT.XSYUKKA_RESULT_DT = XRST_OUT_DTL.XSYUKKA_RESULT_DT"      '出荷実績日時
        strSQL &= vbCrLf & "                  AND XRST_OUT.FPALLET_ID        = XRST_OUT_DTL.FPALLET_ID"             'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "              )"
        'JobMate:S.Ouchi 2013/11/01 出荷追跡問合せ画面 当日分ﾃﾞｰﾀ表示
        '↑↑↑↑↑↑************************************************************************************************************


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


    End Sub
#End Region
#Region "　CSV出力                                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub CSV_Out()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '******************************************
            'ﾌｧｲﾙ名     取得
            '******************************************
            Dim strFile As String = TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ304040_001))

            '******************************************
            'ﾃﾞｰﾀ部     ﾍｯﾀﾞ表示名ｾｯﾄ
            '******************************************
            Dim strDataHeaderName_Ary(23) As String
            strDataHeaderName_Ary(0) = "出荷日"
            strDataHeaderName_Ary(1) = "編成№"
            strDataHeaderName_Ary(2) = "伝票№"
            strDataHeaderName_Ary(3) = "届先名"
            strDataHeaderName_Ary(4) = "業者ｺｰﾄﾞ"
            strDataHeaderName_Ary(5) = "業者名"
            strDataHeaderName_Ary(6) = "品名ｺｰﾄﾞ"
            strDataHeaderName_Ary(7) = "品名記号"
            strDataHeaderName_Ary(8) = "生産ﾗｲﾝ№"
            strDataHeaderName_Ary(9) = "ﾛｯﾄ№"
            strDataHeaderName_Ary(10) = "搬送元ST"
            strDataHeaderName_Ary(11) = "在庫ｴﾘｱ"
            strDataHeaderName_Ary(12) = "ﾛｹｰｼｮﾝ"
            strDataHeaderName_Ary(13) = "搬送先ST"
            strDataHeaderName_Ary(14) = "実績数"
            strDataHeaderName_Ary(15) = "ﾊﾞｰｽ"
            strDataHeaderName_Ary(16) = "車輌№"
            strDataHeaderName_Ary(17) = "細目"
            strDataHeaderName_Ary(18) = "商品区分"
            strDataHeaderName_Ary(19) = "入庫区分"
            strDataHeaderName_Ary(20) = "検品区分"
            strDataHeaderName_Ary(21) = "在庫発生日時"
            strDataHeaderName_Ary(22) = "入庫日時"
            strDataHeaderName_Ary(23) = "出荷実績日時"


            '******************************************
            'ﾃﾞｰﾀ部     ｶﾗﾑ名ｾｯﾄ
            '******************************************
            Dim intDataColumnIdx_Ary(23) As Integer
            intDataColumnIdx_Ary(0) = menmListCol.XSYUKKA_D
            intDataColumnIdx_Ary(1) = menmListCol.XHENSEI_NO
            intDataColumnIdx_Ary(2) = menmListCol.XDENPYOU_NO
            intDataColumnIdx_Ary(3) = menmListCol.XSEND_NAME
            intDataColumnIdx_Ary(4) = menmListCol.XGYOUSYA_CD
            intDataColumnIdx_Ary(5) = menmListCol.XGYOUSYA_NAME
            intDataColumnIdx_Ary(6) = menmListCol.XHINMEI_CD
            intDataColumnIdx_Ary(7) = menmListCol.FHINMEI_CD
            intDataColumnIdx_Ary(8) = menmListCol.XPROD_LINE
            intDataColumnIdx_Ary(9) = menmListCol.FLOT_NO
            intDataColumnIdx_Ary(10) = menmListCol.XFM_ST_FBUF_NAME
            intDataColumnIdx_Ary(11) = menmListCol.FBUF_FM_FBUF_NAME
            intDataColumnIdx_Ary(12) = menmListCol.FDISP_ADDRESS
            intDataColumnIdx_Ary(13) = menmListCol.FBUF_TO_FBUF_NAME
            intDataColumnIdx_Ary(14) = menmListCol.XNUM
            intDataColumnIdx_Ary(15) = menmListCol.XBERTH_NO
            intDataColumnIdx_Ary(16) = menmListCol.XSYARYOU_NO
            intDataColumnIdx_Ary(17) = menmListCol.XSAIMOKU_Disp
            intDataColumnIdx_Ary(18) = menmListCol.XARTICLE_TYPE_CODE_Disp
            intDataColumnIdx_Ary(19) = menmListCol.FIN_KUBUN_Disp
            intDataColumnIdx_Ary(20) = menmListCol.XKENPIN_KUBUN_Disp
            intDataColumnIdx_Ary(21) = menmListCol.FARRIVE_DT
            intDataColumnIdx_Ary(22) = menmListCol.XRAC_IN_DT
            intDataColumnIdx_Ary(23) = menmListCol.XSYUKKA_RESULT_DT

            '******************************************
            'CSVﾌｧｲﾙ出力
            '******************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)                 'ｼｽﾃﾑ変数ｸﾗｽ
            Call MakeCSV(grdList _
                        , objTPRG_SYS_HEN.SJ000000_023 _
                        , strFile _
                        , "" _
                        , strDataHeaderName_Ary _
                        , intDataColumnIdx_Ary _
                        )


        Catch ex As Exception
            Throw ex

        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
