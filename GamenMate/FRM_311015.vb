'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷指示詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
Imports GamenCommon
#End Region

Public Class FRM_311015
#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mblnMenuFlg As Boolean = True             'ﾒﾆｭｰ呼び出しﾌﾗｸﾞ
    Protected mstrXSYUKKA_D As String                   '出荷日
    Protected mstrXHENSEI_NO As String                  '編成№
    Protected mstrXDENPYOU_NO As String                 '伝票№
    Protected mstrXSYUKKA_STS As String                 '出荷状況(進捗状況)

    '共通定数
    Private mintSTART_CNT As Integer = 1       '品名取得用の開始定数（品名1～8ｱｲﾃﾑ）
    Private mintEND_CNT As Integer = 8         '品名取得用の終了定数（品名1～8ｱｲﾃﾑ）

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XROWCOUNT                   '行番号
        XSYUKKA_D                   '出荷日
        XSYUKKA_STS                 '出荷状況(進捗状況)
        XSYUKKA_STS_DISP            '出荷状況(進捗状況)(表示用)
        XHENSEI_NO                  '編成No
        XHENSEI_NO_OYA              '親編成No
        XDENPYOU_NO                 '伝票No
        XBUNRUI_NO                  '分類No
        XSYARYOU_NO                 '車輌No
        XHINMEI_CD                  '品名ｺｰﾄﾞ
        FHINMEI_CD                  '品名記号
        XSYUKKA_NUM                 '予定梱数
        XTUMI_HOUHOU                '積込方法
        XTUMI_HOUHOU_DISP           '積込方法(表示用)
        XTUMI_HOUKOU                '積込方向
        XTUMI_HOUKOU_DISP           '積込方向(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:N.Nakada 2013/10/30 ｱｲﾃﾑ変更
        XSYASYU_KBN                '車種区分
        '↑↑↑↑↑↑************************************************************************************************************
        XGYOUSYA_CD                 '業者ｺｰﾄﾞ
        XGYOUSYA_NAME               '業者名
        XKINKYU_KBN                 '緊急出荷区分
        XKINKYU_KBN_DISP            '緊急出荷区分(表示用)
        XBERTH_SET                  'ﾊﾞｰｽ指定

        XSEND_NAME                  '届け先名称
        XSEND_ADDRESS               '住所
        XSAIMOKU                    '取引区分細目
        XSAIMOKU_DISP               '取引区分細目(表示用)
        XARTICLE_TYPE_CODE          '商品区分
        XARTICLE_TYPE_CODE_DISP     '商品区分(表示用)
        XZAIKO_KBN                  '在庫区分
        XIDOU_KBN                   '移動区分
        XDATA_KIND                  'ﾃﾞｰﾀ種別
        XEDIT_KBN                   '編集区分
        XINPUT_PLACE                'ｲﾝﾌﾟｯﾄ場所
        XINPUT_DT                   'ｲﾝﾌﾟｯﾄ日付
        XINPUT_NO                   'ｲﾝﾌﾟｯﾄNo.
        XDATA_DT                    'ﾃﾞｰﾀ日付
        XSOUKO_CD                   '倉庫ｺｰﾄﾞ
        XTOU_NO                     '棟ｺｰﾄﾞ
        XTORIHIKI_KBN               '取引区分
        XDATA_SYORI                 'ﾃﾞｰﾀ処理
        XUNKOU_NO                   '運行No.
       
        DATA41 '未使用
        DATA42 '未使用
        DATA43 '未使用
        DATA44 '未使用
        DATA45 '未使用
        DATA46 '未使用
        DATA47 '未使用
        DATA48 '未使用
        DATA49 '未使用
        DATA50 '未使用

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click             '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_D As String                         '出荷日
        Dim XHENSEI_NO As String                        '編成№
        Dim XDENPYOU_NO As String                       '伝票No.
        Dim XSYUKKA_STS As String                       '進捗状況
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾒﾆｭｰ呼び出しﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMenuFlg() As Boolean
        Get
            Return mblnMenuFlg
        End Get
        Set(ByVal value As Boolean)
            mblnMenuFlg = value
        End Set
    End Property

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

    ''' =======================================
    ''' <summary>出荷状況(進捗状況)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_STS() As String
        Get
            Return mstrXSYUKKA_STS
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_STS = value
        End Set
    End Property
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

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        If mblnMenuFlg = True Then
            '(ﾒﾆｭｰ画面時)
            Call CmdEnabledChange(cmdF4, False)                     '戻るﾎﾞﾀﾝ
        Else
            '(子画面時)
            Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        End If

        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXSYUKKA_STS, True) '進捗状況 ｾｯﾄ

        '**********************************************************
        ' 子画面初期表示
        '**********************************************************
        If mblnMenuFlg = False Then
            '(子画面時)

            '----------------------------
            ' ｺﾝﾄﾛｰﾙ
            '----------------------------
            If mstrXSYUKKA_D <> "" Then                                 '出荷日
                cboXSYUKKA_D.cmpMDateTimePicker_D.Text = mstrXSYUKKA_D
            Else
                cboXSYUKKA_D.userChecked = False
            End If
            txtXHENSEI_NO.Text = mstrXHENSEI_NO                         '編成No.
            txtXDENPYOU_NO.Text = mstrXDENPYOU_NO                       '伝票No.
            cboXSYUKKA_STS.SelectedValue = mstrXSYUKKA_STS              '進捗状況

            '----------------------------
            ' 検索構造体
            '----------------------------
            mudtSEARCH_ITEM.XSYUKKA_D = mstrXSYUKKA_D                   '出荷日
            mudtSEARCH_ITEM.XHENSEI_NO = mstrXHENSEI_NO                 '編成No.
            mudtSEARCH_ITEM.XDENPYOU_NO = mstrXDENPYOU_NO               '伝票No.
            mudtSEARCH_ITEM.XSYUKKA_STS = mstrXSYUKKA_STS               '進捗状況

        Else
            cboXSYUKKA_D.cmpMDateTimePicker_D.Text = Now

        End If

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定

        If mblnMenuFlg = True Then
            '(ﾒﾆｭｰ画面時)
            Call grdListSetup()
        Else
            '(子画面時)
            Call grdListDisplaySub(grdList)
        End If




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
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

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
#Region "  F4(戻る)  ﾎﾞﾀﾝ押下処理         　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '画面遷移
        '********************************************************************
        Me.Close()

    End Sub
#End Region
#Region "  F5(印刷)  ﾎﾞﾀﾝ押下処理               "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call printOut()


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

            Case menmCheckCase.Print_Click
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
        mudtSEARCH_ITEM.XDENPYOU_NO = txtXDENPYOU_NO.Text                           '伝票№
        mudtSEARCH_ITEM.XSYUKKA_STS = TO_STRING(cboXSYUKKA_STS.SelectedValue)       '進捗状況

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
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New clsGridDataTable50      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D "                                    '出荷指示.      出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS "                                  '出荷指示.      出荷状況(進捗状況)
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_STS_Dsp "                 '出荷指示.      出荷状況(進捗状況)(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO "                                   '出荷指示.      編成No
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA "                               '出荷指示.      親編成No
        strSQL &= vbCrLf & "  , XPLN_OUT.XDENPYOU_NO "                                  '出荷指示.      伝票No
        strSQL &= vbCrLf & "  , XPLN_OUT.XBUNRUI_NO "                                   '出荷指示.      分類No
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO "                                  '出荷指示.      車輌No
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                  '品目ﾏｽﾀ.       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                               '出荷指示詳細.  品名記号
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_KON_PLAN "                         '出荷指示詳細.  出荷予定数
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU "                                 '出荷指示.      積込方法
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XTUMI_HOUHOU_Dsp "                '出荷指示.      積込方法(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU "                                 '出荷指示.      積込方向
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS XTUMI_HOUKOU_Dsp "                '出荷指示.      積込方向(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:N.Nakada 2013/10/30 ｱｲﾃﾑ変更
        strSQL &= vbCrLf & "  , XSYASYU_KBN "                                          '出荷指示.      車種区分
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "  , XPLN_OUT.XGYOUSYA_CD "                                  '出荷指示.      業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XMST_GYOUSYA.XGYOUSYA_NAME "                            '業者ﾏｽﾀ.       業者名
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_KBN "                                  '出荷指示.      緊急出荷区分
        strSQL &= vbCrLf & "  , HASH04.FGAMEN_DISP AS XKINKYU_KBN_Dsp "                 '出荷指示.      緊急出荷区分(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO "                                    '出荷指示.      ﾊﾞｰｽNo.

        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_NAME "                                   '出荷指示.      届け先名称
        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_ADDRESS "                                '出荷指示.      住所
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSAIMOKU "                                 '出荷指示詳細.  取引区分細目
        strSQL &= vbCrLf & "  , HASH05.FGAMEN_DISP AS XSAIMOKU_Dsp "                    '出荷指示詳細.  取引区分細目(表示用)
        strSQL &= vbCrLf & "  , TMST_ITEM.XARTICLE_TYPE_CODE "                          '品目ﾏｽﾀ.       商品区分
        strSQL &= vbCrLf & "  , HASH06.FGAMEN_DISP AS XARTICLE_TYPE_CODE_Dsp "          '品目ﾏｽﾀ.       商品区分(表示用)

        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FZAIKO_KUBUN "                             '出荷指示詳細.  在庫区分
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN "                                '出荷指示詳細.  移動区分

        strSQL &= vbCrLf & "  , XPLN_OUT.XDATA_KIND "                                   '出荷指示.      ﾃﾞｰﾀ種別
        strSQL &= vbCrLf & "  , XPLN_OUT.XEDIT_KBN "                                    '出荷指示.      編集区分
        strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_PLACE "                                 '出荷指示.      ｲﾝﾌﾟｯﾄ場所
        strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_DT "                                    '出荷指示.      ｲﾝﾌﾟｯﾄ日付
        strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_NO "                                    '出荷指示.      ｲﾝﾌﾟｯﾄNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XDATA_DT "                                     '出荷指示.      ﾃﾞｰﾀ日付
        strSQL &= vbCrLf & "  , XPLN_OUT.XSOUKO_CD "                                    '出荷指示.      倉庫ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XPLN_OUT.XTOU_NO "                                      '出荷指示.      棟ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XPLN_OUT.XTORIHIKI_KBN "                                '出荷指示.      取引区分
        strSQL &= vbCrLf & "  , XPLN_OUT.XDATA_SYORI "                                  '出荷指示.      ﾃﾞｰﾀ処理
        strSQL &= vbCrLf & "  , XPLN_OUT.XUNKOU_NO "                                    '出荷指示.      運行No.

       
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      XPLN_OUT "                                                '【出荷指示】
        strSQL &= vbCrLf & "    , XPLN_OUT_DTL "                                            '【出荷指示詳細】
        strSQL &= vbCrLf & "    , XMST_GYOUSYA "                                            '【業者ﾏｽﾀ】
        strSQL &= vbCrLf & "    , TMST_ITEM "                                               '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT", "XSYUKKA_STS")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "XPLN_OUT", "XTUMI_HOUKOU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "XPLN_OUT", "XKINKYU_KBN")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "XPLN_OUT_DTL", "XSAIMOKU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TMST_ITEM", "XARTICLE_TYPE_CODE")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XGYOUSYA_CD = XMST_GYOUSYA.XGYOUSYA_CD(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_D = XPLN_OUT_DTL.XSYUKKA_D(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XDENPYOU_NO = XPLN_OUT_DTL.XDENPYOU_NO(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XHENSEI_NO = XPLN_OUT_DTL.XHENSEI_NO(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT", "XSYUKKA_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "XPLN_OUT", "XTUMI_HOUKOU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "XPLN_OUT", "XKINKYU_KBN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "XPLN_OUT_DTL", "XSAIMOKU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TMST_ITEM", "XARTICLE_TYPE_CODE")

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_D <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_D = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        End If

        '----------------------------
        '編成№
        '----------------------------
        If mudtSEARCH_ITEM.XHENSEI_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = '" & mudtSEARCH_ITEM.XHENSEI_NO & "' "
        End If

        '----------------------------
        '伝票№
        '----------------------------
        If mudtSEARCH_ITEM.XDENPYOU_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XDENPYOU_NO = '" & mudtSEARCH_ITEM.XDENPYOU_NO & "' "
        End If

        '----------------------------
        '進捗状況
        '----------------------------
        If mudtSEARCH_ITEM.XSYUKKA_STS <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = '" & mudtSEARCH_ITEM.XSYUKKA_STS & "' "
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                '出荷指示.     出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS"              '出荷指示.     進捗状況
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO"               '出荷指示.     編成No
        strSQL &= vbCrLf & "  , XPLN_OUT.XDENPYOU_NO"              '出荷指示.     伝票No
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER"           '出荷指示詳細.  車輌内出荷品目順
        strSQL &= vbCrLf


        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        Dim mFHINMEI_CD(mintEND_CNT) As String                '品名ｺｰﾄﾞ
        Dim mXSYUKKA_KON_PLAN(mintEND_CNT) As String          '出荷予定梱数
        Dim mXSAIMOKU(mintEND_CNT) As String                  '取引区分細目
        Dim mXSAIMOKU_DISP(mintEND_CNT) As String             '取引区分細目(表示用)
        Dim mXZAIKO_KBN(mintEND_CNT) As String                '在庫区分
        Dim mXIDOU_KBN(mintEND_CNT) As String                 '移動区分
        Dim strXHENSEI_NO As String
        Dim strXSYUKKA_D As String
        Dim strXSAIMOKU As String
        Dim intRowCnt As Integer = 0

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
                strXSYUKKA_D = TO_STRING(objRow("XSYUKKA_D"))

                strXSAIMOKU = TO_STRING(objRow("XSAIMOKU_Dsp"))

                If TO_INTEGER(objRow("XSAIMOKU")) = XSAIMOKU_JIDOU Then
                    '(細目が移動の場合)
                    If TO_INTEGER(objRow("XIDOU_KBN")) = XIDOU_KBN_JIDOU Then
                        '(移動区分が1の場合)
                        strXSAIMOKU = "移動-1"
                    End If
                End If

                intRowCnt += 1

                '-----------------------
                'ﾃﾞｰﾀｾｯﾄ
                '-----------------------
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:N.Nakada 2013/10/30 ｱｲﾃﾑ変更
                '' ''               objDataTable.userAddRowDataSet _
                '' ''                   ( _
                '' ''                   TO_STRING(intRowCnt), TO_STRING(objRow("XSYUKKA_D")), TO_STRING(objRow("XSYUKKA_STS")), TO_STRING(objRow("XSYUKKA_STS_Dsp")), _
                '' ''                   TO_STRING(objRow("XHENSEI_NO")), TO_STRING(objRow("XHENSEI_NO_OYA")), TO_STRING(objRow("XDENPYOU_NO")), _
                '' ''                   TO_STRING(objRow("XBUNRUI_NO")), TO_STRING(objRow("XSYARYOU_NO")), _
                '' ''                   TO_STRING(objRow("XHINMEI_CD")), TO_STRING(objRow("FHINMEI_CD")), TO_STRING(objRow("XSYUKKA_KON_PLAN")), _
                '' ''                   TO_STRING(objRow("XTUMI_HOUHOU")), TO_STRING(objRow("XTUMI_HOUHOU_Dsp")), _
                '' ''                   TO_STRING(objRow("XTUMI_HOUKOU")), TO_STRING(objRow("XTUMI_HOUKOU_Dsp")), _
                '' ''                   TO_STRING(objRow("XGYOUSYA_CD")), TO_STRING(objRow("XGYOUSYA_NAME")), _
                '' ''                   TO_STRING(objRow("XKINKYU_KBN")), TO_STRING(objRow("XKINKYU_KBN_Dsp")), TO_STRING(objRow("XBERTH_NO")), _
                '' ''_
                '' ''                   TO_STRING(objRow("XSEND_NAME")), TO_STRING(objRow("XSEND_ADDRESS")), _
                '' ''                   TO_STRING(objRow("XSAIMOKU")), strXSAIMOKU, _
                '' ''                   TO_STRING(objRow("XARTICLE_TYPE_CODE")), TO_STRING(objRow("XARTICLE_TYPE_CODE_Dsp")), _
                '' ''                   TO_STRING(objRow("FZAIKO_KUBUN")), TO_STRING(objRow("XIDOU_KBN")), _
                '' ''_
                '' ''                   TO_STRING(objRow("XDATA_KIND")), TO_STRING(objRow("XEDIT_KBN")), TO_STRING(objRow("XINPUT_PLACE")), TO_STRING(Format(TO_DATE(objRow("XINPUT_DT")), "yyMMdd")), _
                '' ''                   TO_STRING(objRow("XINPUT_NO")), TO_STRING(Format(TO_DATE(objRow("XDATA_DT")), "yyMMdd")), TO_STRING(objRow("XSOUKO_CD")), TO_STRING(objRow("XTOU_NO")), _
                '' ''                   TO_STRING(objRow("XTORIHIKI_KBN")), TO_STRING(objRow("XDATA_SYORI")), TO_STRING(objRow("XUNKOU_NO")), _
                '' ''                   )

                objDataTable.userAddRowDataSet _
                    ( _
                    TO_STRING(intRowCnt), TO_STRING(objRow("XSYUKKA_D")), TO_STRING(objRow("XSYUKKA_STS")), TO_STRING(objRow("XSYUKKA_STS_Dsp")), _
                    TO_STRING(objRow("XHENSEI_NO")), TO_STRING(objRow("XHENSEI_NO_OYA")), TO_STRING(objRow("XDENPYOU_NO")), _
                    TO_STRING(objRow("XBUNRUI_NO")), TO_STRING(objRow("XSYARYOU_NO")), _
                    TO_STRING(objRow("XHINMEI_CD")), TO_STRING(objRow("FHINMEI_CD")), TO_STRING(objRow("XSYUKKA_KON_PLAN")), _
                    TO_STRING(objRow("XTUMI_HOUHOU")), TO_STRING(objRow("XTUMI_HOUHOU_Dsp")), _
                    TO_STRING(objRow("XTUMI_HOUKOU")), TO_STRING(objRow("XTUMI_HOUKOU_Dsp")), _
                    TO_STRING(objRow("XSYASYU_KBN")), _
                    TO_STRING(objRow("XGYOUSYA_CD")), TO_STRING(objRow("XGYOUSYA_NAME")), _
                    TO_STRING(objRow("XKINKYU_KBN")), TO_STRING(objRow("XKINKYU_KBN_Dsp")), TO_STRING(objRow("XBERTH_NO")), _
 _
                    TO_STRING(objRow("XSEND_NAME")), TO_STRING(objRow("XSEND_ADDRESS")), _
                    TO_STRING(objRow("XSAIMOKU")), strXSAIMOKU, _
                    TO_STRING(objRow("XARTICLE_TYPE_CODE")), TO_STRING(objRow("XARTICLE_TYPE_CODE_Dsp")), _
                    TO_STRING(objRow("FZAIKO_KUBUN")), TO_STRING(objRow("XIDOU_KBN")), _
 _
                    TO_STRING(objRow("XDATA_KIND")), TO_STRING(objRow("XEDIT_KBN")), TO_STRING(objRow("XINPUT_PLACE")), TO_STRING(Format(TO_DATE(objRow("XINPUT_DT")), "yyMMdd")), _
                    TO_STRING(objRow("XINPUT_NO")), TO_STRING(Format(TO_DATE(objRow("XDATA_DT")), "yyMMdd")), TO_STRING(objRow("XSOUKO_CD")), TO_STRING(objRow("XTOU_NO")), _
                    TO_STRING(objRow("XTORIHIKI_KBN")), TO_STRING(objRow("XDATA_SYORI")), TO_STRING(objRow("XUNKOU_NO")), _
                    )
                '↑↑↑↑↑↑************************************************************************************************************
            Next

        End If

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.Columns.Clear()
        grdList.DataSource = objDataTable

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

#Region "　印刷処理　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Nakada 2013/10/30 ｱｲﾃﾑ変更
    Private Sub printOut()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_311015_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))     '発行日時

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '*明細項目(表示)    
                objDataRow.Data00 = grdList.Item(menmListCol.XHENSEI_NO, ii).FormattedValue             '編成No.
                objDataRow.Data01 = grdList.Item(menmListCol.XDENPYOU_NO, ii).FormattedValue            '伝票No.
                objDataRow.Data02 = grdList.Item(menmListCol.XSYASYU_KBN, ii).FormattedValue            '車種区分
                objDataRow.Data03 = grdList.Item(menmListCol.XGYOUSYA_NAME, ii).FormattedValue          '業者名
                objDataRow.Data04 = grdList.Item(menmListCol.XSYARYOU_NO, ii).FormattedValue            '車両No.
                objDataRow.Data05 = grdList.Item(menmListCol.XUNKOU_NO, ii).FormattedValue              '運行No.
                objDataRow.Data06 = grdList.Item(menmListCol.XSEND_NAME, ii).FormattedValue             '届先名
                objDataRow.Data07 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue             '品名記号
                objDataRow.Data08 = grdList.Item(menmListCol.XSYUKKA_NUM, ii).FormattedValue            '数量
                objDataRow.Data09 = ""                                                                  '備考
                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub

    '↑↑↑↑↑↑************************************************************************************************************

#End Region

End Class
