'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】検品ﾊﾞｰｺｰﾄﾞ読取画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_201030

#Region "  共通変数　                           "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXCAR_NO As String        '車番
    Private mstrXCAR_NO_EDA As String    '枝番

    'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ用構造体
    Private mudtBC_ITEM As New BC_ITEM

    'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ
    Private mstrBC() As String                      'BCﾃﾞｰﾀ

    '検品ﾃﾞｰﾀ用
    Private mstrKENPIN_ITEM() As KENPIN_ITEM         '検品ﾃﾞｰﾀ

    Private mstrBC_FTRK_BUF_NO As String            'BC読取場所
    Private mstrBC_FPALLET_ID As String             'BC読取ﾊﾟﾚｯﾄID

    'ﾃｰﾌﾞﾙ
    Dim mobjXRST_OUT As TBL_XRST_OUT            '出荷実績
    Dim mobjTRST_STOCK As TBL_TRST_STOCK        '在庫情報
    Dim mobjXPLN_OUT_DTL As TBL_XPLN_OUT_DTL    '出荷計画詳細
    Dim mobjXPLN_OUT As TBL_XPLN_OUT            '出荷計画


    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        KANRYO_Click            '完了ﾎﾞﾀﾝｸﾘｯｸ時
        BC_READ                 'BC読取時

    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目(画面表示用)</summary>
    Enum menmListCol
        TRK_BUF_NO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        KANRYO                              '完了
        TRK_BUF_NAME                        '出庫場所
        ZUMI_NUM                            '済
        MI_NUM                              '未

        MAXCOL

    End Enum


    ''' <summary>ｸﾞﾘｯﾄﾞ項目(内部検品用)</summary>
    Enum menmListCol2
        FTRK_BUF_NO                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                           '出庫場所
        XSYUKKA_NO                          '出荷№
        XPLN_DTL_NO                         '計画明細№
        FPALLET_ID                          'ﾊﾟﾚｯﾄID
        FHINMEI_CD                          '品名ｺｰﾄﾞ
        XSEIZOU_DT                          '製造年月日
        XLINE_NO                            'ﾗｲﾝ№
        XPALLET_NO                          'ﾊﾟﾚｯﾄ№
        FTR_VOL                             '積載数
        XKENPIN_FLAG                        '検品ﾌﾗｸﾞ
        XKENPIN_VOL                         '検品数
        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
        'XKENPIN_PALLET_ID                   '検品品ﾊﾟﾚｯﾄID
        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応

        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
        FTR_VOL_KARI                        '積載数_仮
        XKENPIN_FLAG_KARI                   '検品ﾌﾗｸ_仮
        XKENPIN_VOL_KARI                    '検品数_仮
        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応

        MAXCOL

    End Enum


#End Region
#Region "  構造体定義                           "
    ''' <summary>ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ</summary>
    Private Structure BC_ITEM
        Dim HINMEI_CD As String         '品名ｺｰﾄﾞ
        Dim SEIZOU_DT As String         '製造年月日
        Dim KOUJYOU_NO As String        '工場№
        Dim LINE_CD As String           'ﾗｲﾝｺｰﾄﾞ
        Dim PALLET_NO As String         'ﾊﾟﾚｯﾄ№
        Dim TR_VOL As String            '積み数
        Dim KENSA_KUBUN As String       '検査区分
        Dim AB_KUBUN As String          'AB区分

    End Structure
    ''' <summary>検品ﾃﾞｰﾀ</summary>
    Private Structure KENPIN_ITEM
        Dim FTRK_BUF_NO As String          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim XPALLET_ID_KARI As String      'ﾊﾟﾚｯﾄID(仮引当)
        Dim XSYUKKA_NO As String           '出荷№
        Dim XPLN_DTL_NO As String          '計画明細№
        '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
        Dim XSEIZOU_DT                     '製造年月日
        '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
        Dim XTR_VOL_CHECK As Decimal       '検品数
        Dim XPALLET_ID_CHECK As String     'ﾊﾟﾚｯﾄID(検品済み)
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ''' ======================================
    ''' <summary>車番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO() As String
        Get
            Return mstrXCAR_NO
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>枝番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_EDA() As String
        Get
            Return mstrXCAR_NO_EDA
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA = value
        End Set
    End Property
#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱｸﾃｨﾌﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_201030_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            '****************************************
            'ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽ
            '****************************************
            txtBarcode.Focus()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞﾃｷｽﾄLOSTﾌｫｰｶｽ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃｷｽﾄLOSTﾌｫｰｶｽ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtBarcode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.Leave
        Try

            '****************************************
            'ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽ
            '****************************************
            txtBarcode.Focus()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾁｪﾝｼﾞ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃｷｽﾄﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        Try

            If txtBarcode.Text <> "" Then

                Dim strTemCont As String = String.Empty

                For itemcount As Integer = 1 To Len(txtBarcode.Text)        '１文字づつ繰り返す
                    strTemCont = MID_SJIS(txtBarcode.Text, itemcount, 1)            '１文字取得
                    If Asc(strTemCont) = 3 Or Asc(strTemCont) = 13 Then
                        '([3]-ETX（テキスト終了）,[13]-CR（復帰）を検出したとき)

                        If txtBarcode.Text.Length <= 2 Then
                            '(Enter(CRLF)のみを押下されたとき無視する)
                            '(または、識別文字列桁数より小さいとき無視する)
                            txtBarcode.Text = ""
                            Exit For
                        End If

                        'ﾛｸﾞにﾊﾞｰｺｰﾄﾞﾃﾞｰﾀを残す
                        Call gobjComFuncPDA.AddToLog_frm("BCﾃﾞｰﾀ【" & MID_SJIS(txtBarcode.Text, 1, itemcount - 1) & "】")

                        Dim strBCData As String = String.Empty
                        strBCData = MID_SJIS(txtBarcode.Text, 1, itemcount - 1)
                        Call ReadBarCode(strBCData)
                        txtBarcode.Text = ""
                        Exit For

                    End If
                Next

            End If


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '*******************************************************
        '画面ﾒｯｾｰｼﾞ
        '*******************************************************
        lblMsg.Text = FRM_MSG_PDA_MSG_02


        '*******************************************************
        'ｺﾝﾄﾛｰﾙ初期化
        '*******************************************************
        lblXCAR_NO.Text = mstrXCAR_NO
        lblXCAR_NO_EDA.Text = mstrXCAR_NO_EDA

        mstrBC = Nothing                                'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ

        mstrKENPIN_ITEM = Nothing                       '検品ﾃﾞｰﾀ

        'Dim gudtHINMEI_SUM(0)                          '品名毎積み数合計
        gudtHINMEI_SUM = Nothing                        '品名毎積み数合計

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncPDA.FlexGridInitialize02(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定(画面表示用)
        grdList.RowTemplate.Height = 80
        grdList.Font = New Font(grdList.Font.Name, 24)
        'grdList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Call grdListDisplay(grdList)

        Call gobjComFuncPDA.FlexGridInitialize02(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定(内部検品用)
        Call grdListDisplay2(grdList2)


        '******************************************
        ' BCﾀｲﾏ周期(s)
        '******************************************
        txtBarcode.TimerBCCheckCount = gobjComFuncPDA.GetSYS_HEN(FHENSU_ID_SPS000000_002)    'BCﾁｪｯｸﾀｲﾏ周期(s)
        If txtBarcode.TimerBCCheckCount <> 0 Then
            '(BCﾀｲﾏ周期(s)が0以外とき)
            txtBarcode.Size = New System.Drawing.Size(0, 0)
        End If


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
        grdList.Dispose()
        lblXCAR_NO.Dispose()
        lblXCAR_NO_EDA.Dispose()

    End Sub
#End Region
#Region "  F1(ｸﾘｱ)  ﾎﾞﾀﾝ押下処理　              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(ｸﾘｱ)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()
        Try

            Dim udeRet As RetPopup

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BTN_CONFIRM_02, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> RetPopup.OK Then
                Exit Sub
            End If

            '*******************************************************
            '画面遷移
            '*******************************************************
            Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_201000, Me)

            '********************************************************************
            ' 自身のｸﾛｰｽﾞ処理
            '********************************************************************
            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  F4(完了)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(完了)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()
        Try

            Dim intMODE As Integer = 0


            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.KANRYO_Click) = False Then
                '(エラーの時)

                '==============================================
                '未検品 ﾁｪｯｸ
                '==============================================
                If IsNull(gudtHINMEI_SUM) = True Then
                    '(品名毎積み数合計がない時)
                    Exit Sub
                End If


                '********************************************************************
                ' 画面展開
                '********************************************************************
                If IsNull(gobjPDA_201020) = False Then
                    gobjPDA_201020.Close()
                    gobjPDA_201020.Dispose()
                    gobjPDA_201020 = Nothing
                End If

                gobjPDA_201020 = New PDA_201020                 'ｵﾌﾞｼﾞｪｸﾄ作成

                Call SetProperty(gobjPDA_201020)                'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
                'Call gobjPDA_201020.Show()                      '画面表示
                If gobjPDA_201020.ShowDialog() = DialogResult.No Then
                    Exit Sub
                End If


                ''********************************************************************
                '' 自身のｸﾛｰｽﾞ処理
                ''********************************************************************
                'Me.Close()
                'Me.Dispose()

                'Exit Sub

                intMODE = 2         '検品中断にて検品済みを処理

            Else
                '(検品完了OKの時)
                intMODE = 1         '検品完了OK
            End If


            '********************************************************************
            'ｿｹｯﾄ送信処理
            '********************************************************************
            If SendSocket02(intMODE) = False Then
                Exit Sub
            End If

            '*******************************************************
            '画面遷移
            '*******************************************************
            Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_201000, Me)

            '********************************************************************
            ' 自身のｸﾛｰｽﾞ処理
            '********************************************************************
            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
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
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase, _
                                Optional ByVal strBCData As String = "") As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        Dim intRet As RetCode
        'Dim strMsg As String = ""

        Select Case udtCheck_Case
            Case menmCheckCase.KANRYO_Click
                '(完了ﾎﾞﾀﾝｸﾘｯｸ時)


                '==============================================
                '未検品 ﾁｪｯｸ
                '==============================================
                If IsNull(gudtHINMEI_SUM) = True Then
                    '(品名毎積み数合計がない時)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_MSG_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '==============================================
                '検品数 ﾁｪｯｸ
                '==============================================
                Dim strSQL As String                'SQL文
                Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "    XRST_OUT.FHINMEI_CD               AS FHINMEI_CD "
                strSQL &= vbCrLf & "  , SUM(XRST_OUT.FTR_VOL)             AS FTR_VOL "
                strSQL &= vbCrLf & "  , SUM(XRST_OUT.XSYUKKA_KENPIN_VOL)  AS XSYUKKA_KENPIN_VOL "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    XPLN_OUT "
                strSQL &= vbCrLf & "  , XRST_OUT "
                strSQL &= vbCrLf & " WHERE 1 = 1 "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "' "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "' "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XSYUKKA_NO           = XRST_OUT.XSYUKKA_NO(+) "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XPROGRESS_OUT IN (" & XPROGRESS_OUT_JWORK
                strSQL &= vbCrLf & "                               , " & XPROGRESS_OUT_JOUT
                strSQL &= vbCrLf & "                               , " & XPROGRESS_OUT_JCOMP
                strSQL &= vbCrLf & "                               , " & XPROGRESS_OUT_JWARITUKE
                strSQL &= vbCrLf & "                               , " & XPROGRESS_OUT_JBERTH_OTHER
                strSQL &= vbCrLf & "                               , " & XPROGRESS_OUT_JGAIBU_SOUKO
                strSQL &= vbCrLf & "                                ) "
                strSQL &= vbCrLf & "  AND XRST_OUT.XKENPIN_FLAG         = 0"
                strSQL &= vbCrLf & " GROUP BY "
                strSQL &= vbCrLf & "    XRST_OUT.FHINMEI_CD "


                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "XRST_OUT"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count = 0 Then
                    '(読めなかった時)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                Dim intKenpin_Chk_Su As Integer = 0     '検品ﾁｪｯｸ済み数
                Dim blnKenpin_Chk As Boolean = False    '検品数不一致ﾌﾗｸﾞ

                For Each objRow In objDataSet.Tables(strDataSetName).Rows
                    '(ﾙｰﾌﾟ:出庫指示ﾃﾞｰﾀ)

                    Dim strFHINMEI_CD As String
                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
                    Dim decTR_VOL As Decimal
                    'decTR_VOL = TO_DECIMAL(objRow("TR_VOL"))
                    decTR_VOL = TO_DECIMAL(objRow("FTR_VOL"))

                    For jj As Integer = LBound(gudtHINMEI_SUM) To UBound(gudtHINMEI_SUM)
                        '(ﾙｰﾌﾟ:検品ﾃﾞｰﾀ)
                        If gudtHINMEI_SUM(jj).HINMEI_CD = strFHINMEI_CD Then
                            '(品名ｺｰﾄﾞが一致した時)

                            intKenpin_Chk_Su += 1       '検品ﾁｪｯｸ済み数

                            If gudtHINMEI_SUM(jj).KENPIN_VOL = decTR_VOL Then
                                '(積み数と検品数が一致した時)
                            Else
                                '(積み数と検品数が不一致の時)
                                blnKenpin_Chk = True
                            End If
                        End If
                    Next

                Next


                If (blnKenpin_Chk = True) Then
                    '(検品数不一致の場合)
                    'Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_07, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If (intKenpin_Chk_Su <> objDataSet.Tables(strDataSetName).Rows.Count) Then
                    '(未検品品目あり場合)
                    'Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False


            Case menmCheckCase.BC_READ
                '(BC読取時)


                '==============================================
                '桁数ﾁｪｯｸ
                '==============================================
                If strBCData.Length <> PDA_PALLET_CARD_KETA Then
                    '(ﾊﾟﾚｯﾄｶｰﾄﾞ以外の場合)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                ''==============================================
                ''読取り重複ﾁｪｯｸ
                ''==============================================
                If IsNull(mstrBC) = True Then
                    '(１件も読まれていない時)
                Else
                    '(読込まれている時)
                    For ii As Integer = LBound(mstrBC) To UBound(mstrBC)
                        'If strBCData = mstrBC(ii) Then
                        '    '(同一ﾊﾞｰｺｰﾄﾞありの時)
                        If Mid(strBCData, 1, 24) = Mid(mstrBC(ii), 1, 24) Then
                            '(同一ﾊﾟﾚｯﾄのﾊﾞｰｺｰﾄﾞありの時)
                            Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_02, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    Next
                End If


                '*****************************************************
                'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解
                '*****************************************************
                Call Disassembly_BCData(strBCData)


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2012/11/26 在庫数ﾁｪｯｸ 
                '**********************************************************
                ' 在庫情報の特定
                '**********************************************************
                Dim objTRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                objTRST_STOCK.FHINMEI_CD = mudtBC_ITEM.HINMEI_CD                       '品名ｺｰﾄﾞ
                'objTRST_STOCK.XSEIZOU_DT = mudtBC_ITEM.SEIZOU_DT                       '製造年月日
                objTRST_STOCK.XSEIZOU_DT = Mid(mudtBC_ITEM.SEIZOU_DT, 1, 4) & "/" & _
                                             Mid(mudtBC_ITEM.SEIZOU_DT, 5, 2) & "/" & _
                                             Mid(mudtBC_ITEM.SEIZOU_DT, 7, 2) & " 00:00:00"    '製造年月日
                objTRST_STOCK.XLINE_NO = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD  'ﾗｲﾝ№
                objTRST_STOCK.XPALLET_NO = mudtBC_ITEM.PALLET_NO                       'ﾊﾟﾚｯﾄ№
                intRet = objTRST_STOCK.GET_TRST_STOCK(False)
                If intRet <> RetCode.OK Then
                    '(在庫が見つからない場合)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_10, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                If objTRST_STOCK.FTR_VOL < TO_DECIMAL(mudtBC_ITEM.TR_VOL) Then
                    '(検品数が搬送管理量より大きい場合)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_11, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                '↑↑↑↑↑↑************************************************************************************************************



                '==========================
                '保留区分ﾁｪｯｸ
                '==========================
                Dim strSQL As String

                Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
                'Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID "
                strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TRST_STOCK "
                strSQL &= vbCrLf & " WHERE 1 = 1 "
                strSQL &= vbCrLf & "  AND TRST_STOCK.FHINMEI_CD      = '" & mudtBC_ITEM.HINMEI_CD & "' "
                strSQL &= vbCrLf & "  AND TRST_STOCK.XSEIZOU_DT      = TO_DATE('" & mudtBC_ITEM.SEIZOU_DT & " 00:00:00', 'YYYY/MM/DD HH24:MI:SS') "
                strSQL &= vbCrLf & "  AND TRST_STOCK.XLINE_NO        = '" & mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD & "' "
                strSQL &= vbCrLf & "  AND TRST_STOCK.XPALLET_NO      = '" & mudtBC_ITEM.PALLET_NO & "' "
                strSQL &= vbCrLf & "  AND TRST_STOCK.FHORYU_KUBUN   <> " & FHORYU_KUBUN_SNORMAL     '保留区分 <> 通常 
                strSQL &= vbCrLf

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TRST_STOCK"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    '(見つかった場合)
                    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_08, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '↓↓↓↓ 2012.11.26 11:20 H.Morita Del
                ''===============================
                ''既に検品されたﾊﾟﾚｯﾄのﾁｪｯｸ
                ''===============================
                ''-----------------------
                ''抽出SQL作成
                ''-----------------------
                'strSQL = ""
                'strSQL &= vbCrLf & " SELECT "
                'strSQL &= vbCrLf & "   XRST_OUT.XSYUKKA_NO "
                'strSQL &= vbCrLf & " , XRST_OUT.XPLN_DTL_NO "
                'strSQL &= vbCrLf & " , XRST_OUT.FTRK_BUF_NO "
                'strSQL &= vbCrLf & " , XRST_OUT.XPALLET_ID_KARI "
                'strSQL &= vbCrLf & " , XRST_OUT.XPALLET_ID_CHECK "
                'strSQL &= vbCrLf & " , XRST_OUT.XKENPIN_FLAG "
                'strSQL &= vbCrLf & " , XRST_OUT.FHINMEI_CD "
                'strSQL &= vbCrLf & " , XRST_OUT.XSEIZOU_DT "
                'strSQL &= vbCrLf & " , XRST_OUT.XLINE_NO "
                'strSQL &= vbCrLf & " , XRST_OUT.XPALLET_NO "
                'strSQL &= vbCrLf & " , XRST_OUT.XTR_VOL_LOG "
                'strSQL &= vbCrLf & " , XRST_OUT.XSYUKKA_KENPIN_VOL "
                'strSQL &= vbCrLf & " FROM "
                'strSQL &= vbCrLf & "   XPLN_OUT "
                'strSQL &= vbCrLf & " , XRST_OUT "
                'strSQL &= vbCrLf & " WHERE 1 = 1 "
                'strSQL &= vbCrLf & "   AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "' "
                'strSQL &= vbCrLf & "   AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "' "
                'strSQL &= vbCrLf & "   AND XPLN_OUT.XSYUKKA_NO           = XRST_OUT.XSYUKKA_NO "

                'strSQL &= vbCrLf & "   AND XRST_OUT.FHINMEI_CD           = '" & mudtBC_ITEM.HINMEI_CD & "' "
                'strSQL &= vbCrLf & "   AND XRST_OUT.XSEIZOU_DT           = TO_DATE('" & mudtBC_ITEM.SEIZOU_DT & " 00:00:00', 'YYYY/MM/DD HH24:MI:SS') "
                'strSQL &= vbCrLf & "   AND XRST_OUT.XLINE_NO             = '" & mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD & "' "
                'strSQL &= vbCrLf & "   AND XRST_OUT.XPALLET_NO           = '" & mudtBC_ITEM.PALLET_NO & "' "

                'strSQL &= vbCrLf & "   AND XRST_OUT.XKENPIN_FLAG         = 1 "
                'strSQL &= vbCrLf

                ''-----------------------
                ''抽出
                ''-----------------------
                'gobjDb.SQL = strSQL
                'objDataSet.Clear()
                'strDataSetName = "XRST_OUT"
                'gobjDb.GetDataSet(strDataSetName, objDataSet)

                'If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '    '(見つかった場合)
                '    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_09, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If
                '↑↑↑↑ 2012.11.26 11:20 H.Morita Del


                '==============================================
                '検品ﾁｪｯｸ
                '==============================================
                Dim blnOK As Boolean = False

                mstrBC_FTRK_BUF_NO = ""         'BC読取場所
                mstrBC_FPALLET_ID = ""          'BC読取ﾊﾟﾚｯﾄID


                '出荷実績品(ﾊﾞｰｽ出庫(自動倉庫))
                For ii As Integer = 0 To grdList2.RowCount - 1
                    '(ﾙｰﾌﾟ:内部検品表明細数)

                    If (TO_STRING(grdList2.Item(menmListCol2.FHINMEI_CD, ii).Value) = mudtBC_ITEM.HINMEI_CD) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value) = mudtBC_ITEM.SEIZOU_DT) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XLINE_NO, ii).Value) = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XPALLET_NO, ii).Value) = mudtBC_ITEM.PALLET_NO) And _
                       (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL, ii).Value) = TO_DECIMAL(mudtBC_ITEM.TR_VOL)) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value) = XKENPIN_FLAG_JOFF) Then
                        '(内部検品表と照合あり [品名ｺｰﾄﾞ>製造年月日>ﾗｲﾝ№>ﾊﾟﾚｯﾄ№>積載数])


                        '↓↓↓↓ 2012.12.03 16:00 H.Morita 一度検品したものを再度検品してもｴﾗｰとしない ｺﾒﾝﾄｱｳﾄ
                        '↓↓↓↓ 2012.11.26 11:20 H.Morita Add
                        ''===============================
                        ''既に検品されたﾊﾟﾚｯﾄのﾁｪｯｸ
                        ''===============================
                        'If Chk_Kenpin_PALLET(TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value), _
                        '                     TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value), _
                        '                     TO_INTEGER(mstrBC_FTRK_BUF_NO), _
                        '                     mstrBC_FPALLET_ID, _
                        '                     TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value) _
                        '                     ) = True Then
                        '    '(一度検品されたﾊﾟﾚｯﾄが見つかった場合)
                        '    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_09, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If
                        '↑↑↑↑ 2012.11.26 11:20 H.Morita Add
                        '↑↑↑↑ 2012.12.03 16:00 H.Morita 一度検品したものを再度検品してもｴﾗｰとしない ｺﾒﾝﾄｱｳﾄ


                        blnOK = True        '照合OK

                        mstrBC_FTRK_BUF_NO = grdList2.Item(menmListCol2.FTRK_BUF_NO, ii).Value      'BC読取場所
                        mstrBC_FPALLET_ID = grdList2.Item(menmListCol2.FPALLET_ID, ii).Value        'BC読取在庫ﾊﾟﾚｯﾄID

                        grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value = XKENPIN_FLAG_JON       '検品済み
                        grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value = TO_DECIMAL(mudtBC_ITEM.TR_VOL)      '検品数量

                        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                        'grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, ii).Value = grdList2.Item(menmListCol2.FPALLET_ID, ii).Value  '検品ﾊﾟﾚｯﾄID
                        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応


                        If IsNull(mstrKENPIN_ITEM) = True Then
                            '(最初の時)
                            ReDim mstrKENPIN_ITEM(0)
                            mstrKENPIN_ITEM(0).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                            mstrKENPIN_ITEM(0).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                            mstrKENPIN_ITEM(0).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                            mstrKENPIN_ITEM(0).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(0).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(0).XTR_VOL_CHECK = TO_DECIMAL(mudtBC_ITEM.TR_VOL)                                '検品数
                            mstrKENPIN_ITEM(0).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        Else
                            '(以降の時)
                            ReDim Preserve mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM) + 1)
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XTR_VOL_CHECK = TO_DECIMAL(mudtBC_ITEM.TR_VOL)                                '検品数
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        End If


                        Exit For
                    End If

                Next

                If blnOK = True Then
                    '(検品ﾁｪｯｸOKの時)
                    blnCheckErr = False
                    Exit Select
                End If


                '代用品(平置き、外部倉庫)

                'Dim strSQL As String
                'Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                'Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

                '在庫情報より、代わりの在庫の、ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№等の情報を引き出す。
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "   TRST_STOCK.FPALLET_ID "
                strSQL &= vbCrLf & " , TRST_STOCK.FHINMEI_CD "
                strSQL &= vbCrLf & " , TRST_STOCK.XSEIZOU_DT "
                strSQL &= vbCrLf & " , TRST_STOCK.XLINE_NO "
                strSQL &= vbCrLf & " , TRST_STOCK.XPALLET_NO "
                strSQL &= vbCrLf & " , TPRG_TRK_BUF.FTRK_BUF_NO "
                strSQL &= vbCrLf & "FROM "
                strSQL &= vbCrLf & "   TRST_STOCK "
                strSQL &= vbCrLf & " , TPRG_TRK_BUF "
                strSQL &= vbCrLf & "WHERE 1 = 1 "
                strSQL &= vbCrLf & "  AND TRST_STOCK.FHINMEI_CD  = '" & mudtBC_ITEM.HINMEI_CD & "' "                          '品名ｺｰﾄﾞ
                strSQL &= vbCrLf & "  AND TRST_STOCK.XSEIZOU_DT  = TO_DATE('" & mudtBC_ITEM.SEIZOU_DT & "', 'YYYY/MM/DD') "   '製造年月日
                strSQL &= vbCrLf & "  AND TRST_STOCK.XLINE_NO    = '" & mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD & "' "   'ﾗｲﾝ№
                strSQL &= vbCrLf & "  AND TRST_STOCK.XPALLET_NO  = '" & mudtBC_ITEM.PALLET_NO & "' "                          'ﾊﾟﾚｯﾄ№
                strSQL &= vbCrLf & "  AND TRST_STOCK.FPALLET_ID  = TPRG_TRK_BUF.FPALLET_ID "                                  'ﾊﾟﾚｯﾄID
                'strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                                       '引当状態：在庫
                'strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                                                   '在庫棚(未引当)
                'strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
                'strSQL &= vbCrLf & "                                    ) "
                'strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                                                   '在庫棚(未引当)
                'strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
                'strSQL &= vbCrLf & "                                    ) "

                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TRST_STOCK"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count = 0 Then
                    '(読めなかった時)
                    Call Kenpin_NG(strBCData)
                    blnCheckErr = True
                    Exit Select
                Else
                    '(読めた時)
                    mstrBC_FTRK_BUF_NO = objDataSet.Tables(strDataSetName).Rows(0).Item("FTRK_BUF_NO")      'BC読取した在庫の場所
                    mstrBC_FPALLET_ID = objDataSet.Tables(strDataSetName).Rows(0).Item("FPALLET_ID")        'BC読取した在庫のﾊﾟﾚｯﾄID
                End If


                '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                Dim decBC_FTR_VOL As Decimal = TO_DECIMAL(mudtBC_ITEM.TR_VOL)      'BC読込んだ、数量
                Dim strIDX() As String = Nothing                                   '内部検品表で対象となったIDX
                Dim strXKENPIN_VOL() As String = Nothing                           '内部検品表で対象となったものへの、検品数
                Dim decXKENPIN_VOL_NOW As Decimal = 0                              '今回検品できた数量
                '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応


                For ii As Integer = 0 To grdList2.RowCount - 1
                    '(ﾙｰﾌﾟ:内部検品表明細数)


                    '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                    '***仮にｺﾋﾟｰ
                    grdList2.Item(menmListCol2.FTR_VOL_KARI, ii).Value = grdList2.Item(menmListCol2.FTR_VOL, ii).Value
                    grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value = grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value
                    grdList2.Item(menmListCol2.XKENPIN_FLAG_KARI, ii).Value = grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value
                    '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応


                    '(TO_STRING(grdList2.Item(menmListCol2.XLINE_NO, ii).Value) = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD) And _
                    '(TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL, ii).Value) = TO_DECIMAL(mudtBC_ITEM.TR_VOL)) And _
                    '(内部検品表と照合あり [ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№>品名ｺｰﾄﾞ>製造年月日>数量])
                    '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                    '(TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value) = XKENPIN_FLAG_JOFF) Then
                    '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                    If (TO_STRING(grdList2.Item(menmListCol2.FTRK_BUF_NO, ii).Value) = mstrBC_FTRK_BUF_NO) And _
                       (TO_STRING(grdList2.Item(menmListCol2.FHINMEI_CD, ii).Value) = mudtBC_ITEM.HINMEI_CD) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value) = mudtBC_ITEM.SEIZOU_DT) And _
                       (TO_STRING(grdList2.Item(menmListCol2.XKENPIN_FLAG_KARI, ii).Value) = XKENPIN_FLAG_JOFF) Then
                        '(内部検品表と照合あり [ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№>品名ｺｰﾄﾞ>製造年月日] 未検品_仮)


                        '↓↓↓↓ 2012.12.03 16:00 H.Morita 一度検品したものを再度検品してもｴﾗｰとしない ｺﾒﾝﾄｱｳﾄ
                        '↓↓↓↓ 2012.11.26 11:20 H.Morita Add
                        ''===============================
                        ''既に検品されたﾊﾟﾚｯﾄのﾁｪｯｸ
                        ''===============================
                        'If Chk_Kenpin_PALLET(TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value), _
                        '                     TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value), _
                        '                     TO_INTEGER(mstrBC_FTRK_BUF_NO), _
                        '                     mstrBC_FPALLET_ID, _
                        '                     TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)) = True Then
                        '    '(一度検品されたﾊﾟﾚｯﾄが見つかった場合)
                        '    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_ERROR_09, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If
                        '↑↑↑↑ 2012.11.26 11:20 H.Morita Add
                        '↑↑↑↑ 2012.12.03 16:00 H.Morita 一度検品したものを再度検品してもｴﾗｰとしない ｺﾒﾝﾄｱｳﾄ



                        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                        'If (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL, ii).Value) >= _
                        '   (TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value) + TO_DECIMAL(mudtBC_ITEM.TR_VOL))) Then
                        '    '(搬送量≧検品数＋BC検品数の時 OK)
                        'Else
                        '    '(搬送量<検品数＋BC検品数の時 BAD)
                        '    Call Kenpin_NG(strBCData)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If


                        'blnOK = True    '照合OK

                        'If (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL, ii).Value) = _
                        '   (TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value) + TO_DECIMAL(mudtBC_ITEM.TR_VOL))) Then
                        '    '(搬送量=検品数＋BC検品数の時)
                        '    grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value = XKENPIN_FLAG_JON                '検品済み
                        'End If

                        'grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value += TO_DECIMAL(mudtBC_ITEM.TR_VOL)  '検品数量に加算
                        'grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, ii).Value = mstrBC_FPALLET_ID          'BC読取在庫ﾊﾟﾚｯﾄID(意味無し)


                        'If IsNull(mstrKENPIN_ITEM) = True Then
                        '    '(最初の時)
                        '    ReDim mstrKENPIN_ITEM(0)
                        '    mstrKENPIN_ITEM(0).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                        '    mstrKENPIN_ITEM(0).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                        '    mstrKENPIN_ITEM(0).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                        '    mstrKENPIN_ITEM(0).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                        '    '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                        '    mstrKENPIN_ITEM(0).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                        '    '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                        '    mstrKENPIN_ITEM(0).XTR_VOL_CHECK = TO_DECIMAL(mudtBC_ITEM.TR_VOL)                                '検品数
                        '    mstrKENPIN_ITEM(0).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        'Else
                        '    '(以降の時)
                        '    ReDim Preserve mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM) + 1)
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                        '    '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                        '    '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XTR_VOL_CHECK = TO_DECIMAL(mudtBC_ITEM.TR_VOL)                                '検品数
                        '    mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        'End If


                        'Exit For



                        If (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL_KARI, ii).Value) >= _
                           (TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value) + decBC_FTR_VOL)) Then
                            '(搬送量_仮≧検品数_仮＋BC検品数の時)

                            If IsNull(strIDX) = True Then
                                ReDim strIDX(0)
                                ReDim strXKENPIN_VOL(0)
                                strIDX(0) = TO_STRING(ii)                                       '対象の内部検品表
                                strXKENPIN_VOL(0) = TO_STRING(decBC_FTR_VOL)                    '対象の内部検品表への検品数
                            Else
                                ReDim Preserve strIDX(UBound(strIDX) + 1)
                                ReDim Preserve strXKENPIN_VOL(UBound(strXKENPIN_VOL) + 1)
                                strIDX(UBound(strIDX)) = TO_STRING(ii)                             '対象の内部検品表
                                strXKENPIN_VOL(UBound(strXKENPIN_VOL)) = TO_STRING(decBC_FTR_VOL)  '対象の内部検品表への検品数
                            End If

                            decXKENPIN_VOL_NOW = decBC_FTR_VOL                                  '今回検品できた数量
                            decBC_FTR_VOL = 0                                                   'BC検品数は全て検品できた

                        Else
                            '(搬送量<検品数＋BC検品数の時)

                            If IsNull(strIDX) = True Then
                                ReDim strIDX(0)
                                ReDim strXKENPIN_VOL(0)
                                strIDX(0) = TO_STRING(ii)                                       '対象の内部検品表
                                strXKENPIN_VOL(0) = TO_STRING(TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL_KARI, ii).Value) - _
                                                              TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value))    '対象の内部検品表への検品数

                                decXKENPIN_VOL_NOW = TO_DECIMAL(strXKENPIN_VOL(0))              '今回検品できた数量
                                decBC_FTR_VOL -= TO_DECIMAL(strXKENPIN_VOL(0))                  'BC検品数を検品できた分だけ減算

                            Else
                                ReDim Preserve strIDX(UBound(strIDX) + 1)
                                ReDim Preserve strXKENPIN_VOL(UBound(strXKENPIN_VOL) + 1)
                                strIDX(UBound(strIDX)) = TO_STRING(ii)                          '対象の内部検品表
                                strXKENPIN_VOL(UBound(strXKENPIN_VOL)) = TO_STRING(TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL_KARI, ii).Value) - _
                                                                         TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value))    '対象の内部検品表への検品数

                                decXKENPIN_VOL_NOW = TO_DECIMAL(strXKENPIN_VOL(UBound(strXKENPIN_VOL))) '今回検品できた数量
                                decBC_FTR_VOL -= TO_DECIMAL(strXKENPIN_VOL(UBound(strXKENPIN_VOL)))     'BC検品数を検品できた分だけ減算

                            End If

                        End If


                        If (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL_KARI, ii).Value) = _
                           (TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value) + decXKENPIN_VOL_NOW)) Then
                            '(搬送量=検品数＋BC検品数の時)
                            grdList2.Item(menmListCol2.XKENPIN_FLAG_KARI, ii).Value = XKENPIN_FLAG_JON                '検品済み
                        End If

                        grdList2.Item(menmListCol2.XKENPIN_VOL_KARI, ii).Value += decXKENPIN_VOL_NOW                  '検品数量に加算


                        If decBC_FTR_VOL = 0 Then
                            '(BC検品数は全て検品できた)
                            Exit For
                        End If

                        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応

                    End If

                Next



                '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                If (IsNull(strIDX) = False) And (decBC_FTR_VOL = 0) Then
                    '(内部検品表idxのﾃﾞｰﾀがある時　且つ、検品数量が全て振り分けられた時)


                    blnOK = True    '照合OK


                    For jj As Integer = LBound(strIDX) To UBound(strIDX)
                        '(ﾙｰﾌﾟ:内部検品表idxのﾃﾞｰﾀ分)

                        Dim ii As Integer = TO_INTEGER(strIDX(jj))                      '対象の内部検品表
                        Dim decXKENPIN_VOL As Decimal = TO_DECIMAL(strXKENPIN_VOL(jj))   '対象の内部検品表への検品数

                        If IsNull(mstrKENPIN_ITEM) = True Then
                            '(最初の時)
                            ReDim mstrKENPIN_ITEM(0)
                            mstrKENPIN_ITEM(0).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                            mstrKENPIN_ITEM(0).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                            mstrKENPIN_ITEM(0).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                            mstrKENPIN_ITEM(0).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(0).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(0).XTR_VOL_CHECK = decXKENPIN_VOL                                                '検品数
                            mstrKENPIN_ITEM(0).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        Else
                            '(以降の時)
                            ReDim Preserve mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM) + 1)
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).FTRK_BUF_NO = mstrBC_FTRK_BUF_NO                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_KARI = TO_STRING(grdList2.Item(menmListCol2.FPALLET_ID, ii).Value) 'ﾊﾟﾚｯﾄID(仮引当)
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSYUKKA_NO = TO_STRING(grdList2.Item(menmListCol2.XSYUKKA_NO, ii).Value)      '出荷№
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPLN_DTL_NO = TO_STRING(grdList2.Item(menmListCol2.XPLN_DTL_NO, ii).Value)    '計画明細№
                            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XSEIZOU_DT = TO_STRING(grdList2.Item(menmListCol2.XSEIZOU_DT, ii).Value)      '製造年月日
                            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応。
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XTR_VOL_CHECK = decXKENPIN_VOL                                                '検品数
                            mstrKENPIN_ITEM(UBound(mstrKENPIN_ITEM)).XPALLET_ID_CHECK = mstrBC_FPALLET_ID                                          'ﾊﾟﾚｯﾄID(検品済み)
                        End If


                        If (TO_DECIMAL(grdList2.Item(menmListCol2.FTR_VOL, ii).Value) = _
                           (TO_DECIMAL(grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value) + decXKENPIN_VOL)) Then
                            '(搬送量=検品数＋BC検品数の時)
                            grdList2.Item(menmListCol2.XKENPIN_FLAG, ii).Value = XKENPIN_FLAG_JON                '検品済み
                        End If

                        grdList2.Item(menmListCol2.XKENPIN_VOL, ii).Value += decXKENPIN_VOL                  '検品数量に加算

                        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
                        'grdList2.Item(menmListCol2.XKENPIN_PALLET_ID, ii).Value = mstrBC_FPALLET_ID          'BC読取在庫ﾊﾟﾚｯﾄID(意味無し)
                        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応

                    Next

                End If
                '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応



                If blnOK = True Then
                    '(検品ﾁｪｯｸOKの時)
                    blnCheckErr = False
                    Exit Select
                Else
                    '(検品ﾁｪｯｸNGの時)
                    Call Kenpin_NG(strBCData)
                    blnCheckErr = True
                    Exit Select
                End If


                ''==============================================
                ''出荷計画ﾁｪｯｸ
                ''==============================================
                ''**********************************************************
                '' 出荷計画の特定
                ''**********************************************************
                'Dim strSQL As String
                'Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                'Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名


                'strSQL = ""
                'strSQL &= "SELECT "
                'strSQL &= "  * "
                'strSQL &= "FROM "
                'strSQL &= "  XPLN_OUT "
                'strSQL &= "WHERE 1 = 1 "
                'strSQL &= "  AND XPLN_OUT.XCAR_NO_WARITUKE     = " & mstrXCAR_NO        '受付車番
                'strSQL &= "  AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = " & mstrXCAR_NO_EDA    '受付車番枝番"
                'strSQL &= "  AND XPLN_OUT.XPROGRESS_OUT NOT IN (" & XPROGRESS_OUT_JCOMP    '進捗状態　≠ 「検品完了(積込済)」
                'strSQL &= "                                   , " & XPROGRESS_OUT_JKYOUSEI '進捗状態　≠ 「強制完了」
                'strSQL &= "                                    ) "

                'mobjXPLN_OUT = Nothing
                'mobjXPLN_OUT = New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
                'mobjXPLN_OUT.USER_SQL = strSQL
                ''intRet = mobjXPLN_OUT.GET_XPLN_OUT_ANY()
                'intRet = mobjXPLN_OUT.GET_XPLN_OUT_USER()
                'If intRet <> RetCode.OK Then
                '    '(読めない時)
                '    'Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_07, PopupFormType.Ok, PopupIconType.Information)
                '    Call Kenpin_NG(strBCData)
                '    blnCheckErr = True
                '    Exit Select
                'End If


                ''==============================================
                ''出荷実績ﾁｪｯｸ
                ''==============================================
                ''**********************************************************
                '' 出荷実績の特定
                ''**********************************************************
                'Dim blnOK As Boolean = False

                'For ii As Integer = LBound(mobjXPLN_OUT.ARYME) To UBound(mobjXPLN_OUT.ARYME)

                '    mobjXRST_OUT = Nothing
                '    mobjXRST_OUT = New TBL_XRST_OUT(gobjOwner, gobjDb, Nothing)
                '    mobjXRST_OUT.FHINMEI_CD = mudtBC_ITEM.HINMEI_CD                            '品名ｺｰﾄﾞ
                '    mobjXRST_OUT.XSEIZOU_DT = Mid(mudtBC_ITEM.SEIZOU_DT, 1, 4) & "/" & _
                '                             Mid(mudtBC_ITEM.SEIZOU_DT, 5, 2) & "/" & _
                '                             Mid(mudtBC_ITEM.SEIZOU_DT, 7, 2) & " 00:00:00"    '製造年月日
                '    mobjXRST_OUT.XLINE_NO = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD       'ﾗｲﾝ№
                '    mobjXRST_OUT.XPALLET_NO = mudtBC_ITEM.PALLET_NO                            'ﾊﾟﾚｯﾄ№
                '    mobjXRST_OUT.XKENPIN_FLAG = XKENPIN_FLAG_JOFF                              '検品ﾌﾗｸﾞ
                '    mobjXRST_OUT.XORDER_NO = mobjXPLN_OUT.ARYME(ii).XORDER_NO                  'ｵｰﾀﾞｰ№
                '    intRet = mobjXRST_OUT.GET_XRST_OUT(False)
                '    If intRet = RetCode.OK Then
                '        '(読めた時)
                '        blnOK = True
                '        Exit For
                '    End If

                'Next

                ''↓↓↓↓↓ 2012.10.10 H.Morita ﾊﾟﾚｯﾄ№と関係なく出荷検品対応
                'If blnOK = False Then
                '    '(読めない時)
                '    Call Kenpin_NG(strBCData)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                ''If blnOK = False Then
                ''    '(読めない時)
                ''    '在庫情報より、代わりの在庫の、ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№等の情報を引き出す。

                ''    strSQL = ""
                ''    strSQL &= vbCrLf & "SELECT "
                ''    strSQL &= vbCrLf & "   TRST_STOCK.FPALLET_ID "
                ''    strSQL &= vbCrLf & " , TRST_STOCK.FHINMEI_CD "
                ''    strSQL &= vbCrLf & " , TRST_STOCK.XSEIZOU_DT "
                ''    strSQL &= vbCrLf & " , TRST_STOCK.XLINE_NO "
                ''    strSQL &= vbCrLf & " , TRST_STOCK.XPALLET_NO "
                ''    strSQL &= vbCrLf & " , TPRG_TRK_BUF.FTRK_BUF_NO "
                ''    strSQL &= vbCrLf & "FROM "
                ''    strSQL &= vbCrLf & "   TRST_STOCK "
                ''    strSQL &= vbCrLf & " , TPRG_TRK_BUF "
                ''    strSQL &= vbCrLf & "WHERE 1 = 1 "
                ''    strSQL &= vbCrLf & "  AND TRST_STOCK.FHINMEI_CD  = '" & mudtBC_ITEM.HINMEI_CD & "' "                          '品名ｺｰﾄﾞ
                ''    strSQL &= vbCrLf & "  AND TRST_STOCK.XSEIZOU_DT  = TO_DATE('" & mudtBC_ITEM.SEIZOU_DT & "', 'YYYY/MM/DD') "   '製造年月日
                ''    strSQL &= vbCrLf & "  AND TRST_STOCK.XLINE_NO    = '" & mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD & "' "   'ﾗｲﾝ№
                ''    strSQL &= vbCrLf & "  AND TRST_STOCK.FPALLET_ID  = TPRG_TRK_BUF.FPALLET_ID "                                  'ﾊﾟﾚｯﾄID
                ''    strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                                       '引当状態：在庫
                ''    strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                                                   '在庫棚(未引当)
                ''    strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
                ''    strSQL &= vbCrLf & "                                    ) "
                ''    strSQL &= vbCrLf & "  AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                                                   '在庫棚(未引当)
                ''    strSQL &= vbCrLf & "                  (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
                ''    strSQL &= vbCrLf & "                                    ) "


                ''    gobjDb.SQL = strSQL
                ''    objDataSet.Clear()
                ''    strDataSetName = "TRST_STOCK"
                ''    gobjDb.GetDataSet(strDataSetName, objDataSet)

                ''    If objDataSet.Tables(strDataSetName).Rows.Count = 0 Then
                ''        '(読めなかった時)
                ''        Call Kenpin_NG(strBCData)
                ''        blnCheckErr = True
                ''        Exit Select
                ''    Else
                ''        '(読めた時)

                ''    End If

                ''End If
                ''↑↑↑↑↑ 2012.10.10 H.Morita ﾊﾟﾚｯﾄ№と関係なく出荷検品対応


                ''==============================================
                ''在庫情報ﾁｪｯｸ
                ''==============================================
                ''**********************************************************
                '' 在庫情報の特定
                ''**********************************************************
                'mobjTRST_STOCK = Nothing
                'mobjTRST_STOCK = New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                'mobjTRST_STOCK.FPALLET_ID = mobjXRST_OUT.FPALLET_ID                       'ﾊﾟﾚｯﾄID
                'intRet = mobjTRST_STOCK.GET_TRST_STOCK(False)
                'If intRet <> RetCode.OK Then
                '    '(読めない時)
                '    Call Kenpin_NG(strBCData)
                '    blnCheckErr = True
                '    Exit Select
                'End If


                ''==============================================
                ''出荷計画詳細ﾁｪｯｸ
                ''==============================================
                ''**********************************************************
                '' 出荷計画詳細の特定
                ''**********************************************************
                'mobjXPLN_OUT_DTL = Nothing
                'mobjXPLN_OUT_DTL = New TBL_XPLN_OUT_DTL(gobjOwner, gobjDb, Nothing)
                'mobjXPLN_OUT_DTL.XSYUKKA_NO = mobjXRST_OUT.XSYUKKA_NO                       '出荷№
                'mobjXPLN_OUT_DTL.XPLN_DTL_NO = mobjXRST_OUT.XPLN_DTL_NO                     '計画明細№
                'intRet = mobjXPLN_OUT_DTL.GET_XPLN_OUT_DTL_ANY()
                'If intRet <> RetCode.OK Then
                '    '(読めない時)
                '    'Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_06, PopupFormType.Ok, PopupIconType.Information)
                '    Call Kenpin_NG(strBCData)
                '    blnCheckErr = True
                '    Exit Select
                'End If


                ''********************************************************************
                ''出庫場所 ﾁｪｯｸ
                ''********************************************************************
                'Dim blnChk As Boolean = False
                'Dim strFTRK_BUF_NO As String = ""

                ''**********************************************************
                '' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀの特定
                ''**********************************************************
                'Dim objTMST_TRK As TBL_TMST_TRK                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
                'objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                'objTMST_TRK.FTRK_BUF_NO = mobjXRST_OUT.FTRK_BUF_NO   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                'intRet = objTMST_TRK.GET_TMST_TRK(True)
                'If intRet = RetCode.OK Then
                '    '(読めた時)
                '    If IsNull(objTMST_TRK.XTRK_BUF_NO_OUT_HIRA) = True Then
                '        '(ﾊﾞｰｽ平置き場のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№がないとき)
                '        strFTRK_BUF_NO = mobjXRST_OUT.FTRK_BUF_NO
                '    Else
                '        '(ﾊﾞｰｽ平置き場のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№があるとき)
                '        strFTRK_BUF_NO = objTMST_TRK.XTRK_BUF_NO_OUT_HIRA
                '    End If
                'End If


                ''**********************************************************
                '' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬの特定
                ''**********************************************************
                'Dim objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF                                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
                'objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                'objTPRG_TRK_BUF.FPALLET_ID = mobjXRST_OUT.FPALLET_ID                       'ﾊﾟﾚｯﾄID
                'intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)
                'If intRet = RetCode.OK Then
                '    '(読めた時)
                '    If objTPRG_TRK_BUF.FTRK_BUF_NO = strFTRK_BUF_NO Then
                '        '(在庫が出荷場所に来ているとき)
                '        blnChk = True
                '    End If
                'End If


                'If blnChk = False Then
                '    '(該当の出庫場所がない時)
                '    Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_10, PopupFormType.Ok, PopupIconType.Information)
                '    'Call Kenpin_NG(strBCData)
                '    blnCheckErr = True
                '    Exit Select
                'End If


                ''********************************************************************
                ''未検品ｶｳﾝﾄ ﾁｪｯｸ
                ''********************************************************************
                'For ii As Integer = 0 To grdList.RowCount - 1
                '    If mobjXRST_OUT.FTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, ii).Value) Then
                '        '(該当の出庫場所の時)
                '        If TO_INTEGER(grdList.Item(menmListCol.MI_NUM, ii).Value) = 0 Then
                '            '(未検品がない時)
                '            Call gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BC_ERROR_09, PopupFormType.Ok, PopupIconType.Information)
                '            'Call Kenpin_NG(strBCData)
                '            blnCheckErr = True
                '            Exit Select
                '        End If
                '    End If
                'Next


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
#Region "　ｸﾞﾘｯﾄﾞ表示(画面表示用)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(画面表示用)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim strSQL As String                            'SQL文

        '********************************************************************
        ' DB情報取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "       A.FTRK_BUF_NO "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "     , (CASE WHEN A.MI = 0 THEN '○' ELSE '' END) AS KANRYO "   '完了
        strSQL &= vbCrLf & "     , A.FBUF_NAME "                                            '出庫場所
        strSQL &= vbCrLf & "     , A.ZUMI "                                                 '済
        strSQL &= vbCrLf & "     , A.MI "                                                   '未
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & " ( "

        strSQL &= vbCrLf & " SELECT"
        strSQL &= vbCrLf & "       XRST_OUT.FTRK_BUF_NO "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "     , ''    AS KANRYO "                    '完了
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                 '出庫場所
        'strSQL &= vbCrLf & "     , SUM( "
        'strSQL &= vbCrLf & "           CASE WHEN XRST_OUT.XKENPIN_FLAG = 1 THEN 1 "
        'strSQL &= vbCrLf & "           ELSE 0 END "
        'strSQL &= vbCrLf & "       ) AS ZUMI "
        'strSQL &= vbCrLf & "     , SUM( "
        'strSQL &= vbCrLf & "           CASE WHEN XRST_OUT.XKENPIN_FLAG = 0 THEN 1 "
        'strSQL &= vbCrLf & "           ELSE 0 END "
        'strSQL &= vbCrLf & "       ) AS MI "

        strSQL &= vbCrLf & "     , SUM( "
        strSQL &= vbCrLf & "           CASE WHEN XRST_OUT.XKENPIN_FLAG = 1 THEN XRST_OUT.XSYUKKA_KENPIN_VOL "
        strSQL &= vbCrLf & "           ELSE 0 END "
        strSQL &= vbCrLf & "       ) AS ZUMI "                          '済
        strSQL &= vbCrLf & "     , SUM( "
        strSQL &= vbCrLf & "           CASE WHEN XRST_OUT.XKENPIN_FLAG = 0 THEN XRST_OUT.FTR_VOL "
        strSQL &= vbCrLf & "           ELSE 0 END "
        strSQL &= vbCrLf & "       ) AS MI "                            '未

        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "       XPLN_OUT "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "     , XRST_OUT "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "       1 = 1"
        strSQL &= vbCrLf & "   AND XPLN_OUT.XSYUKKA_NO           = XPLN_OUT_DTL.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "   AND XPLN_OUT_DTL.XSYUKKA_NO       = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "   AND XPLN_OUT_DTL.XPLN_DTL_NO      = XRST_OUT.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & "   AND XRST_OUT.FTRK_BUF_NO          = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "   AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "' "
        strSQL &= vbCrLf & "   AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "' "
        strSQL &= vbCrLf & "   AND XPLN_OUT.XWARITUKE_DT         = "                                            '割付日時 = 最新
        strSQL &= vbCrLf & "                                      (SELECT MAX(XWARITUKE_DT)"
        strSQL &= vbCrLf & "                                       FROM XPLN_OUT "
        strSQL &= vbCrLf & "                                       WHERE 1 = 1 "
        strSQL &= vbCrLf & "                                        AND XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "'"
        strSQL &= vbCrLf & "                                        AND XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "'"
        strSQL &= vbCrLf & "                                      ) "
        strSQL &= vbCrLf & "   AND XRST_OUT.XKENPIN_FLAG          = " & XKENPIN_FLAG_JOFF
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "       XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "      ,TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & " ) A "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "       A.FTRK_BUF_NO "


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        'strDataSetName = "XRST_OUT"
        strDataSetName = "A"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncPDA.GridDisplay(objDataSet.Tables(strDataSetName), _
                         grdControl, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataSet = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncPDA.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(画面表示用)　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(画面表示用)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncPDA.TDSP_GRIDSetup(Me, grdList)

        grdList.Columns(menmListCol.TRK_BUF_NAME).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill        '列幅自動調節
        grdList.AllowUserToResizeColumns = False

        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示(検品内部用)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(検品内部用)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay2(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim strSQL As String                            'SQL文

        '********************************************************************
        ' DB情報取得
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "        XRST_OUT.FTRK_BUF_NO "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "      , TMST_TRK.FBUF_NAME "            '出庫場所
        strSQL &= vbCrLf & "      , XRST_OUT.XSYUKKA_NO "           '出荷№
        strSQL &= vbCrLf & "      , XRST_OUT.XPLN_DTL_NO "          '計画明細№
        'strSQL &= vbCrLf & "      , XRST_OUT.FPALLET_ID "           'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "      , XRST_OUT.XPALLET_ID_KARI "      'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "      , XRST_OUT.FHINMEI_CD "           '品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "      , TO_CHAR(XRST_OUT.XSEIZOU_DT, 'YYYYMMDD') AS XSEIZOU_DT_DSP "    '製造年月日
        strSQL &= vbCrLf & "      , XRST_OUT.XLINE_NO "             'ﾗｲﾝ№     
        strSQL &= vbCrLf & "      , XRST_OUT.XPALLET_NO "           'ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "      , XRST_OUT.FTR_VOL "              '積載数
        strSQL &= vbCrLf & "      , XRST_OUT.XKENPIN_FLAG "         '検品ﾌﾗｸﾞ
        strSQL &= vbCrLf & "      , XRST_OUT.XSYUKKA_KENPIN_VOL "   '検品数
        strSQL &= vbCrLf & "      , '' AS XKENPIN_PALLET_ID "       '検品品ﾊﾟﾚｯﾄID
        '↓↓↓↓ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
        strSQL &= vbCrLf & "      , XRST_OUT.FTR_VOL             AS FTR_VOL_KARI "         '積載数_仮
        strSQL &= vbCrLf & "      , XRST_OUT.XKENPIN_FLAG        AS XKENPIN_FLAG_KARI "    '検品ﾌﾗｸ_仮
        strSQL &= vbCrLf & "      , XRST_OUT.XSYUKKA_KENPIN_VOL  AS XKENPIN_VOL_KARI "     '検品数_仮
        '↑↑↑↑ 2012.12.03 18:15 H.Morita 同一出荷№ + 異なる出荷明細№ + 同一品目 の検品の対応
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "        XPLN_OUT "          '出荷計画
        strSQL &= vbCrLf & "      , XPLN_OUT_DTL "      '出荷計画詳細
        strSQL &= vbCrLf & "      , XRST_OUT "          '出荷実績
        strSQL &= vbCrLf & "      , TMST_TRK "          'ﾄﾗｯｷﾝｸﾞﾏｽﾀ
        strSQL &= vbCrLf & "  WHERE 1 = 1 "
        strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_NO           = XPLN_OUT_DTL.XSYUKKA_NO(+) "    '出荷№
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO       = XRST_OUT.XSYUKKA_NO(+) "        '出荷№
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XPLN_DTL_NO      = XRST_OUT.XPLN_DTL_NO(+) "       '計画明細№
        strSQL &= vbCrLf & "    AND XRST_OUT.FTRK_BUF_NO          = TMST_TRK.FTRK_BUF_NO(+) "       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "' "         '受付車番
        strSQL &= vbCrLf & "    AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "' "     '受付車番枝番
        strSQL &= vbCrLf & "    AND XPLN_OUT.XWARITUKE_DT         = "                               '割付日時 = 最新
        strSQL &= vbCrLf & "                                       (SELECT MAX(XWARITUKE_DT)"
        strSQL &= vbCrLf & "                                        FROM XPLN_OUT "
        strSQL &= vbCrLf & "                                        WHERE 1 = 1 "
        strSQL &= vbCrLf & "                                         AND XCAR_NO_WARITUKE     = '" & mstrXCAR_NO & "'"
        strSQL &= vbCrLf & "                                         AND XCAR_NO_EDA_WARITUKE = '" & mstrXCAR_NO_EDA & "'"
        strSQL &= vbCrLf & "                                       ) "
        strSQL &= vbCrLf & "    AND XRST_OUT.XKENPIN_FLAG          = " & XKENPIN_FLAG_JOFF          '未検品
        strSQL &= vbCrLf & "  ORDER BY "
        strSQL &= vbCrLf & "        XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "      , XRST_OUT.FHINMEI_CD "
        strSQL &= vbCrLf & "      , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & "      , XRST_OUT.XLINE_NO "
        strSQL &= vbCrLf & "      , XRST_OUT.XPALLET_NO "


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "XRST_OUT"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncPDA.GridDisplay(objDataSet.Tables(strDataSetName), _
                         grdControl, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataSet = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncPDA.GridSelect(grdList2, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(検品内部用)　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(検品内部用)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncPDA.TDSP_GRIDSetup(Me, grdList2)

        'grdList2.AllowUserToResizeColumns = False

        'For Each objColum As DataGridViewColumn In grdList2.Columns
        '    objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        'Next

    End Sub
#End Region
#Region "　ﾊﾞｰｺｰﾄﾞ読取ｲﾍﾞﾝﾄ処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞ読取ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ReadBarCode(ByVal strBCData As String)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BC_READ, strBCData) = False Then
            Exit Sub
        End If


        '********************************************************************
        'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ格納
        '********************************************************************
        If IsNull(mstrBC) = True Then
            '(最初の一回)
            ReDim mstrBC(0)
            mstrBC(0) = strBCData
        Else
            '(二回目以降)
            ReDim Preserve mstrBC(UBound(mstrBC) + 1)
            mstrBC(UBound(mstrBC)) = strBCData
        End If


        '********************************************************************
        '検品済みｶｳﾝﾄ
        '********************************************************************
        For ii As Integer = 0 To grdList.RowCount - 1
            'If mobjXRST_OUT.FTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, ii).Value) Then
            If mstrBC_FTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, ii).Value) Then
                '(該当の出庫場所の時)
                'grdList.Item(menmListCol.ZUMI_NUM, ii).Value += 1      '検品済み
                'grdList.Item(menmListCol.MI_NUM, ii).Value -= 1       '未検品

                grdList.Item(menmListCol.ZUMI_NUM, ii).Value += mudtBC_ITEM.TR_VOL      '検品済み
                grdList.Item(menmListCol.MI_NUM, ii).Value -= mudtBC_ITEM.TR_VOL        '未検品

                If TO_DECIMAL(grdList.Item(menmListCol.MI_NUM, ii).Value) = 0 Then
                    '(未検品が0の時)
                    grdList.Item(menmListCol.KANRYO, ii).Value = "○"                   '完了
                End If

                grdList.ClearSelection()
            End If
        Next


        '********************************************************************
        '検品済み 品名 積み数加算
        '********************************************************************
        Dim intRet As Integer = -1

        If IsNull(gudtHINMEI_SUM) = True Then
            '(最初の一回)
            ReDim gudtHINMEI_SUM(0)
            'gudtHINMEI_SUM(0).HINMEI_CD = mobjXRST_OUT.FHINMEI_CD
            gudtHINMEI_SUM(0).HINMEI_CD = mudtBC_ITEM.HINMEI_CD
            gudtHINMEI_SUM(0).KENPIN_VOL = mudtBC_ITEM.TR_VOL
        Else
            '(二回目以降)
            For ii As Integer = LBound(gudtHINMEI_SUM) To UBound(gudtHINMEI_SUM)
                '(ﾙｰﾌﾟ:品名毎積み数)
                'If gudtHINMEI_SUM(ii).HINMEI_CD = mobjXRST_OUT.FHINMEI_CD Then
                If gudtHINMEI_SUM(ii).HINMEI_CD = mudtBC_ITEM.HINMEI_CD Then
                    '(品名ｺｰﾄﾞがある時)
                    intRet = ii
                    Exit For
                End If
            Next

            If intRet = -1 Then
                '(品名ｺｰﾄﾞが見つからなかった場合)
                ReDim Preserve gudtHINMEI_SUM(UBound(gudtHINMEI_SUM) + 1)
                'gudtHINMEI_SUM(UBound(gudtHINMEI_SUM)).HINMEI_CD = mobjXRST_OUT.FHINMEI_CD
                gudtHINMEI_SUM(UBound(gudtHINMEI_SUM)).HINMEI_CD = mudtBC_ITEM.HINMEI_CD
                gudtHINMEI_SUM(UBound(gudtHINMEI_SUM)).KENPIN_VOL = mudtBC_ITEM.TR_VOL
            Else
                '(品名ｺｰﾄﾞが見つかった場合)
                gudtHINMEI_SUM(intRet).KENPIN_VOL += mudtBC_ITEM.TR_VOL     '検品数加算
            End If

        End If

    End Sub
#End Region

#Region "  ｿｹｯﾄ送信02                         　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02(ByVal intMODE As Integer) As Boolean


        Dim blnRet As Boolean = False
        'Dim intRet As RetCode
        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        If intMODE = 1 Then
            '(検品完了の時)
            strMessage &= FRM_MSG_PDA_BTN_CONFIRM_03
        Else
            '(検品中断にて検品済み分を完了する時)
            strMessage &= FRM_MSG_PDA_BTN_CONFIRM_04
        End If
        udtRet = gobjComFuncPDA.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If



        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = LBound(mstrKENPIN_ITEM) To UBound(mstrKENPIN_ITEM)
            '(ﾙｰﾌﾟ:検品ﾃﾞｰﾀ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strDSPST_FM As String = ""                                   '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            Dim strXDSPPALLET_ID_KARI As String = ""                         'ﾊﾟﾚｯﾄID(仮引当)
            Dim strXDSPSYUKKA_NO As String = ""                              '出荷№
            Dim strXDSPPLN_DTL_NO As String = ""                             '計画明細№
            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            Dim strXDSPSEIZOU_DT As String = ""                              '製造年月日
            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            Dim strDSPTR_VOL As String = ""                                  '搬送管理量
            Dim strXDSPPALLET_ID_CHECK As String = ""                        'ﾊﾟﾚｯﾄID(検品済)

            strDSPST_FM = mstrKENPIN_ITEM(ii).FTRK_BUF_NO                    '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strXDSPPALLET_ID_KARI = mstrKENPIN_ITEM(ii).XPALLET_ID_KARI      'ﾊﾟﾚｯﾄID(仮引当)
            strXDSPSYUKKA_NO = mstrKENPIN_ITEM(ii).XSYUKKA_NO                '出荷№
            strXDSPPLN_DTL_NO = mstrKENPIN_ITEM(ii).XPLN_DTL_NO              '計画明細№
            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            strXDSPSEIZOU_DT = Mid(mstrKENPIN_ITEM(ii).XSEIZOU_DT, 1, 4) & "/" & _
                               Mid(mstrKENPIN_ITEM(ii).XSEIZOU_DT, 5, 2) & "/" & _
                               Mid(mstrKENPIN_ITEM(ii).XSEIZOU_DT, 7, 2) & _
                               " 00:00:00"                                   '製造年月日
            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            strDSPTR_VOL = mstrKENPIN_ITEM(ii).XTR_VOL_CHECK                 '搬送管理量
            strXDSPPALLET_ID_CHECK = mstrKENPIN_ITEM(ii).XPALLET_ID_CHECK    'ﾊﾟﾚｯﾄID(検品済)


            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101            'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                          '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KARI", strXDSPPALLET_ID_KARI)      'ﾊﾟﾚｯﾄID(仮引当)
            objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)                '出荷№
            objTelegramSub.SETIN_DATA("XDSPPLN_DTL_NO", strXDSPPLN_DTL_NO)              '計画明細№
            '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            objTelegramSub.SETIN_DATA("XDSPSEIZOU_DT", strXDSPSEIZOU_DT)                '製造年月日
            '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
            objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)                        '搬送管理量
            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_CHECK", strXDSPPALLET_ID_CHECK)    'ﾊﾟﾚｯﾄID(検品済)

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
        Dim strPARA_ID As String = ""
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPST_FM", "")                                      '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTelegram.SETIN_DATA("XDSPPALLET_ID_KARI", "")                            'ﾊﾟﾚｯﾄID(仮引当)
        objTelegram.SETIN_DATA("XDSPSYUKKA_NO", "")                                 '出荷№
        objTelegram.SETIN_DATA("XDSPPLN_DTL_NO", "")                                '計画明細№
        '↓↓↓↓ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
        objTelegram.SETIN_DATA("XDSPSEIZOU_DT", "")                                 '製造年月日
        '↑↑↑↑ 2012.11.21 14:00 H.Morita 出荷実績ﾃｰﾌﾞﾙに「製造年月日」項目追加の対応
        objTelegram.SETIN_DATA("DSPTR_VOL", "")                                     '搬送管理量
        objTelegram.SETIN_DATA("XDSPPALLET_ID_CHECK", "")                           'ﾊﾟﾚｯﾄID(検品済)

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_PDA_ERROR_04
        udtSckSendRET = gobjComFuncPDA.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        Return blnRet

    End Function
#End Region

#Region "  検品NG画面表示                       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 検品NG画面表示
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Kenpin_NG(ByVal strBCData As String)

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjPDA_100201) = False Then
            gobjPDA_100201.Close()
            gobjPDA_100201.Dispose()
            gobjPDA_100201 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjPDA_100201 = New PDA_100201                             'ｵﾌﾞｼﾞｪｸﾄ作成

        'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjPDA_100201.userXCAR_NO = mstrXCAR_NO                   '車番
        gobjPDA_100201.userXCAR_NO_EDA = mstrXCAR_NO_EDA           '枝番
        gobjPDA_100201.userFHINMEI_CD = mudtBC_ITEM.HINMEI_CD      '品名ｺｰﾄﾞ
        gobjPDA_100201.userXSEIZOU_DT = Mid(mudtBC_ITEM.SEIZOU_DT, 1, 4) & "/" & _
                                        Mid(mudtBC_ITEM.SEIZOU_DT, 5, 2) & "/" & _
                                        Mid(mudtBC_ITEM.SEIZOU_DT, 7, 2)                  '製造年月日
        gobjPDA_100201.userXLINE_NO = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD        'ﾗｲﾝ№
        gobjPDA_100201.userXPALLET_NO = mudtBC_ITEM.PALLET_NO      'ﾊﾟﾚｯﾄ№
        gobjPDA_100201.userXSYUKA_KENPIN_VOL = TO_STRING(TO_DECIMAL(mudtBC_ITEM.TR_VOL))  '積み数
        gobjPDA_100201.userBCData = strBCData                      'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ


        Call gobjPDA_100201.ShowDialog()        '画面表示

    End Sub
#End Region
#Region "  ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Disassembly_BCData(ByVal strBCData As String)

        Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BCR)
        objTel.FORMAT_ID = FORMAT_BCR_01                        'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTel.TELEGRAM_PARTITION = strBCData                   '分割する電文ｾｯﾄ
        objTel.PARTITION()                                      '電文分割
        mudtBC_ITEM.HINMEI_CD = Trim(objTel.SELECT_DATA("BCR01HINMEI_CD"))              '品名ｺｰﾄﾞ
        mudtBC_ITEM.SEIZOU_DT = Trim(objTel.SELECT_DATA("BCR01SEIZOU_DT"))              '製造年月日
        mudtBC_ITEM.KOUJYOU_NO = Trim(objTel.SELECT_DATA("BCR01KOUJYO_NO"))             '工場№
        mudtBC_ITEM.LINE_CD = Trim(objTel.SELECT_DATA("BCR01LINE_CD"))                  'ﾗｲﾝｺｰﾄﾞ
        mudtBC_ITEM.PALLET_NO = Trim(objTel.SELECT_DATA("BCR01PALLET_NO"))              'ﾊﾟﾚｯﾄ№
        mudtBC_ITEM.TR_VOL = Trim(objTel.SELECT_DATA("BCR01VOL"))                       '積み数
        mudtBC_ITEM.KENSA_KUBUN = Trim(objTel.SELECT_DATA("BCR01KENSA_KUBUN"))          '検査区分
        mudtBC_ITEM.AB_KUBUN = objTel.SELECT_DATA("BCR01AB_KUBUN")                      'AB区分       (ｽﾍﾟｰｽがﾃﾞｰﾀとして入るのでTrimはかけない)

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ　                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As PDA_201020)

        objForm.userXCAR_NO = mstrXCAR_NO                      '車番
        objForm.userXCAR_NO_EDA = mstrXCAR_NO_EDA              '枝番
        objForm.userBCData = mstrBC                            'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ

    End Sub
#End Region
#Region "　既に検品されたﾊﾟﾚｯﾄのﾁｪｯｸ            "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function Chk_Kenpin_PALLET(ByVal strXSYUKKA_NO As String, _
                                       ByVal strXPLN_DTL_NO As String, _
                                       ByVal intFTRK_BUF_NO As Integer, _
                                       ByVal strFPALLET_ID As String, _
                                       ByVal strXSEIZOU_DT As String _
                                       ) As Boolean

        Dim blnCheckErr As Boolean = False

        Dim strSQL As String

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名


        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "   XRST_OUT.XSYUKKA_NO "
        strSQL &= vbCrLf & " , XRST_OUT.XPLN_DTL_NO "
        strSQL &= vbCrLf & " , XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & " , XRST_OUT.XPALLET_ID_KARI "
        strSQL &= vbCrLf & " , XRST_OUT.XPALLET_ID_CHECK "
        strSQL &= vbCrLf & " , XRST_OUT.XKENPIN_FLAG "
        strSQL &= vbCrLf & " , XRST_OUT.FHINMEI_CD "
        strSQL &= vbCrLf & " , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & " , XRST_OUT.XLINE_NO "
        strSQL &= vbCrLf & " , XRST_OUT.XPALLET_NO "
        strSQL &= vbCrLf & " , XRST_OUT.XTR_VOL_LOG "
        strSQL &= vbCrLf & " , XRST_OUT.XSYUKKA_KENPIN_VOL "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   XRST_OUT "
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "   AND XRST_OUT.XSYUKKA_NO        = '" & strXSYUKKA_NO & "' "
        strSQL &= vbCrLf & "   AND XRST_OUT.XPLN_DTL_NO       = '" & strXPLN_DTL_NO & "' "
        strSQL &= vbCrLf & "   AND XRST_OUT.FTRK_BUF_NO       =  " & intFTRK_BUF_NO
        strSQL &= vbCrLf & "   AND XRST_OUT.XPALLET_ID_CHECK  = '" & strFPALLET_ID & "' "
        strSQL &= vbCrLf & "   AND XRST_OUT.XSEIZOU_DT        = TO_DATE('" & Mid(strXSEIZOU_DT, 1, 4) & "/" & _
                                                                             Mid(strXSEIZOU_DT, 5, 2) & "/" & _
                                                                             Mid(strXSEIZOU_DT, 7, 2) & "', " & _
                                                                         "'YYYY/MM/DD HH24:MI:SS') "
        strSQL &= vbCrLf & "   AND XRST_OUT.XKENPIN_FLAG      = 1 "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XRST_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            blnCheckErr = True
        End If


        Return blnCheckErr

    End Function
#End Region

End Class
