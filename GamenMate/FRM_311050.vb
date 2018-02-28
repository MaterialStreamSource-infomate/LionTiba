'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷中状況詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311050

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrXBERTH_NO As String                   'ﾊﾞｰｽ№
    Protected mstrXHENSEI_NO_OYA As String              '親編成No.
    Protected mstrXDENPYOU_NO As String                 '伝票No.
    Protected mstrXSYARYOU_NO As String                 '車輌番号
    Protected mstrXSYUKKA_D As String                   '出荷日

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XOUT_ORDER                  '出荷指示詳細.  　車輌内出荷品目順
        XSYUKKA_STS_DTL             '出荷指示詳細     出荷状況詳細
        XSYUKKA_STS_DTL_DSP         '出荷指示詳細     出荷状況詳細(表示用)
        XHENSEI_NO                  '出荷指示詳細　　 編成No.
        XHENSEI_NO_OYA              '出荷指示詳細　　 親編成No.
        XDENPYOU_NO                 '出荷指示詳細　　 伝票No.
        XHINMEI_CD                  '品名ﾏｽﾀ　　　　　品名ｺｰﾄﾞ
        FHINMEI_CD                  '出荷指示詳細　　 品名記号
        FHINMEI                     '品名ﾏｽﾀ　　　　　品名
        XSYUKKA_KON_PLAN            '出荷指示詳細　　 出荷予定梱数
        XSYUKKA_KON_RESULT          '出荷指示詳細　　 出荷実績梱数

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SaiHikiateBtn_Click         '最引当ﾎﾞﾀﾝｸﾘｯｸ時
        KyouseiKanryouBtn_Click     '強制完了ﾎﾞﾀﾝｸﾘｯｸ時
        ReturnBtn_Click             '戻るﾎﾞﾀﾝｸﾘｯｸ時
        PrintBtn_Click              '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ﾊﾞｰｽNo.</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXBERTH_NO() As String
        Get
            Return mstrXBERTH_NO
        End Get
        Set(ByVal value As String)
            mstrXBERTH_NO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>親編成№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXHENSEI_NO_OYA() As String
        Get
            Return mstrXHENSEI_NO_OYA
        End Get
        Set(ByVal value As String)
            mstrXHENSEI_NO_OYA = value
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
    ''' <summary>車輌番号</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYARYOU_NO() As String
        Get
            Return mstrXSYARYOU_NO
        End Get
        Set(ByVal value As String)
            mstrXSYARYOU_NO = value
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
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾀｲﾏｰ ｲﾍﾞﾝﾄ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311050_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr311050.Tick

        Call tmr311050_TickProcess()

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

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般

        '**********************************************************
        ' 初期表示
        '**********************************************************
        '----------------------------
        ' ｺﾝﾄﾛｰﾙ
        '----------------------------
        lblBERTH_NO.Text = mstrXBERTH_NO                            'ﾊﾞｰｽNo.
        lblSYARYOU_NO.Text = mstrXSYARYOU_NO                        '車輌番号

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        '**********************************************************
        ' 各ﾊﾟﾚｯﾄ数表示
        '**********************************************************
        Dim lngSYUKKO As Long
        Dim lngHANSOUTYUU As Long

        lngSYUKKO = gobjComFuncFRM.COUNT_SYUKKO(mstrXBERTH_NO)
        lngHANSOUTYUU = gobjComFuncFRM.COUNT_HANSOUTYUU(mstrXBERTH_NO)

        lblSYUKKO.Text = TO_STRING(lngSYUKKO)
        lblHANSOU.Text = TO_STRING(lngHANSOUTYUU)

        tmr311050.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS311050_001))
        tmr311050.Enabled = True

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
        lblBERTH_NO.Dispose()
        lblSYARYOU_NO.Dispose()
        lblSYUKKO.Dispose()
        lblHANSOU.Dispose()
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region

#Region "  F1(再引当)      ﾎﾞﾀﾝ押下処理        　   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(再引当)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        tmr311050.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SaiHikiateBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            tmr311050.Enabled = True
            Exit Sub
        End If

        '********************************************************************
        '再引当要求送信
        '********************************************************************
        If SendSock_400108() = True Then
            '(ｴﾗｰ、ｷｬﾝｾﾙの場合)
            tmr311050.Enabled = True
            Exit Sub
        End If

        tmr311050.Enabled = True

    End Sub
#End Region
#Region "  F2(強制完了)    ﾎﾞﾀﾝ押下処理       　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(強制完了)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        tmr311050.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KyouseiKanryouBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            tmr311050.Enabled = True
            Exit Sub
        End If

        '********************************************************************
        '強制完了要求送信
        '********************************************************************
        If SendSock_400106() = False Then
            '(ｴﾗｰ、ｷｬﾝｾﾙの場合)
            tmr311050.Enabled = True
            Exit Sub
        End If

        '********************************************************************
        '画面遷移
        '********************************************************************
        Me.Close()

    End Sub
#End Region
#Region "  F3(印刷)        ﾎﾞﾀﾝ押下処理       　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(印刷) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        tmr311050.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PrintBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            tmr311050.Enabled = True
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
        Dim strXHENSEI_NO_OYA As String
        Dim strXSYUKKA_DT As String

        strXHENSEI_NO_OYA = mstrXHENSEI_NO_OYA
        strXSYUKKA_DT = mstrXSYUKKA_D

        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)
        Call objTemplateServer.PrintPickingList(strXSYUKKA_DT, strXHENSEI_NO_OYA)

        ''************************************
        ''ﾌﾟﾛﾊﾟﾃｨｾｯﾄ()
        ''************************************
        ''If IsNull(gobjFRM_311055) = False Then
        ''    gobjFRM_311055.Close()
        ''    gobjFRM_311055.Dispose()
        ''    gobjFRM_311055 = Nothing
        ''End If
        ''gobjFRM_311055 = New FRM_311055
        ''Call SetProperty()                              'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        ''Dim intRet As DialogResult
        ''intRet = gobjFRM_311055.ShowDialog()            '展開

        tmr311050.Enabled = True

    End Sub
#End Region
#Region "  F4(戻る)        ﾎﾞﾀﾝ押下処理       　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        tmr311050.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ReturnBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            tmr311050.Enabled = True
            Exit Sub
        End If

        '********************************************************************
        '画面遷移
        '********************************************************************
        Me.Close()


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
            Case menmCheckCase.SaiHikiateBtn_Click
                '(再引当ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '出荷中ｱｲﾃﾑ数ﾁｪｯｸ
                '==========================
                If grdList.Rows.Count < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311050_03, PopupFormType.Ok, PopupIconType.Information)
                    Exit Function
                End If

                ' ''==========================
                ' ''欠品ﾁｪｯｸ
                ' ''==========================
                ''Dim ERR_CNT As Integer

                ' ''出荷指示詳細=欠品(9)以外はｴﾗｰ
                ''For ii As Integer = 0 To grdList.Rows.Count - 1
                ''    If TO_INTEGER(grdList.Item(menmListCol.XSYUKKA_STS_DTL, ii).Value) = XSYUKKA_STS_DTL_JLESS Then
                ''        ERR_CNT += 1
                ''    End If
                ''Next
                ''If ERR_CNT = 0 Then
                ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311050_04, PopupFormType.Ok, PopupIconType.Information)
                ''    Exit Function
                ''End If

                blnCheckErr = False

            Case menmCheckCase.KyouseiKanryouBtn_Click
                '(強制完了ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '出荷中ｱｲﾃﾑ数ﾁｪｯｸ
                '==========================
                If grdList.Rows.Count < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311050_03, PopupFormType.Ok, PopupIconType.Information)
                    Exit Function
                End If

                blnCheckErr = False

            Case menmCheckCase.ReturnBtn_Click
                '(戻るﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.PrintBtn_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                            'SQL文

        '************************************************************
        ' SQL文作成
        '************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XOUT_ORDER "                           '出荷指示詳細.  　　車輌内出荷品目順
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_STS_DTL "                      '出荷指示詳細.  　　出荷状況詳細
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_STS_DTL_DSP "         '出荷指示詳細.  　　出荷状況詳細(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XHENSEI_NO "                           '出荷指示詳細.      編成No.
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XHENSEI_NO_OYA "                       '出荷指示詳細.      親編成No.
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                          '出荷指示詳細.      伝票No.
        strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                              '品名ﾏｽﾀ.　　       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                           '出荷指示詳細.      品名記号
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                 '品名ﾏｽﾀ.　　       品名
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_KON_PLAN "                     '出荷指示詳細.      出荷予定梱数
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_KON_RESULT "                   '出荷指示詳細.  　　出荷実績梱数

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "             '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "           '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TMST_ITEM "              '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT_DTL", "XSYUKKA_STS_DTL")     '【出荷状況詳細(表示用)】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "         XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "            '出荷指示詳細 と 品名ﾏｽﾀ を 品名ｺｰﾄﾞ で結合
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D "             '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 出荷日 で結合
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO "       '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 親編成No. で結合
        strSQL &= vbCrLf & "     AND XSTS_BERTH.XBERTH_NO = '" & mstrXBERTH_NO & "' "            '出荷ﾊﾞｰｽ状況 を ﾊﾞｰｽNo で結合
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT_DTL", "XSYUKKA_STS_DTL")

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataSet.Tables(strDataSetName), _
                 grdList, _
                 intSelectRow, _
                 intSelectCol, _
                 objPoint)
        objDataSet = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()                'ｸﾞﾘｯﾄﾞ表示設定
        If grdList.RowCount > 0 Then
            Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, 3, objPoint)     'ｸﾞﾘｯﾄﾞ選択処理
        End If

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

#Region "　ﾀｲﾏｰ処理　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311050_TickProcess()

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)


        '**********************************************************
        ' 各ﾊﾟﾚｯﾄ数表示
        '**********************************************************
        Dim lngSYUKKO As Long
        Dim lngHANSOUTYUU As Long

        lngSYUKKO = gobjComFuncFRM.COUNT_SYUKKO(mstrXBERTH_NO)
        lngHANSOUTYUU = gobjComFuncFRM.COUNT_HANSOUTYUU(mstrXBERTH_NO)

        lblSYUKKO.Text = TO_STRING(lngSYUKKO)
        lblHANSOU.Text = TO_STRING(lngHANSOUTYUU)

    End Sub
#End Region

#Region "  再引当要求送信            （ID : 400108）"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSock_400108() As Boolean

        Dim udtRet As RetPopup
        Dim ERR_CNT As Integer = 0
        Dim strHensei As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311050_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return False
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400108    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPBERTH_NO", mstrXBERTH_NO)           'ﾊﾞｰｽNo.
        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", mstrXSYARYOU_NO)       '車輌No.
        objTelegram.SETIN_DATA("XDSPSYUKKA_D", mstrXSYUKKA_D)           '出荷日
        objTelegram.SETIN_DATA("XDSPHENSEI_NO_OYA", mstrXHENSEI_NO_OYA)     '親編成No.

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If

        Return True

    End Function

#End Region
#Region "  強制完了要求送信          （ID : 400106）"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSock_400106() As Boolean

        Dim udtRet As RetPopup
        Dim ERR_CNT As Integer = 0
        Dim strHensei As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311050_02, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return False
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400106    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPBERTH_NO", mstrXBERTH_NO)           'ﾊﾞｰｽNo.
        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", mstrXSYARYOU_NO)       '車輌No.
        objTelegram.SETIN_DATA("XDSPSYUKKA_D", mstrXSYUKKA_D)           '出荷日
        objTelegram.SETIN_DATA("XDSPHENSEI_NO_OYA", mstrXHENSEI_NO_OYA)     '親編成No.

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If

        Return True

    End Function

#End Region

#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】 
    '*******************************************************************************************************************
    Private Sub SetProperty()

        ' ''gobjFRM_311055.userXSYUKKA_D = TO_STRING(grdList.Item(menmListCol.XSYUKKA_D, grdList.SelectedRows(0).Index).Value)      '出荷日
        ' ''gobjFRM_311055.userXHENSEI_NO_OYA = TO_STRING(grdList.Item(menmListCol.XHENSEI_NO, grdList.SelectedRows(0).Index).Value)    '編成№
        gobjFRM_311055.userXHENSEI_NO_OYA = mstrXHENSEI_NO_OYA          '編成№

    End Sub
#End Region

End Class
