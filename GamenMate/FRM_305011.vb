'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】棚卸し作業指示画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305011

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_StockData_Comp As Boolean = False             '在庫情報取得完了ﾌﾗｸﾞ

    Private mstrFPALLET_ID_CHK As String = ""                   '確認中のﾊﾟﾚｯﾄID

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrTR_TO As String            '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

    ''' <summary>在庫情報取得項目</summary>
    Private Enum menmListCol
        FBUF_IN_DT                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾞｯﾌｬ入日時
        FTRK_BUF_ARRAY                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ配列№
        FDISP_ADDRESS                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ
        FDISPLOG_ADDRESS_FM             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        FPALLET_ID                      '在庫情報.          ﾊﾟﾚｯﾄID
        FHINMEI_CD                      '在庫情報.          品名ｺｰﾄﾞ
        FHINMEI                         '品名ﾏｽﾀ.           品名
        FLOT_NO                         '在庫情報.          ﾛｯﾄ№
        XSEIZOU_DT                      '在庫情報.          製造年月日
        XLINE_NO                        '在庫情報.          ﾗｲﾝ№
        XPALLET_NO                      '在庫情報.          ﾊﾟﾚｯﾄ№
        FTR_VOL_SUM                     '在庫情報.          搬送管理量合計(在庫数量)
        XSYUKKA_KAHI                    '在庫情報.          出荷可否
        XSYUKKA_KAHI_DSP                '在庫情報.          出荷可否(表示用)
        XHINSHITU_STS                   '在庫情報.          品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP               '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                    '在庫情報.          保留区分
        FHORYU_KUBUN_DSP                '在庫情報.          保留区分(表示用)
        FARRIVE_DT                      '在庫情報.          在庫発生日時
        'FBUF_IN_DT                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.      ﾊﾞｯﾌｬ入日時(入庫日時)
        XASRS_IN_DT                     '在庫情報.          入庫日時
        FHASU_FLAG                      '在庫情報.          端数区分
        FHASU_FLAG_DSP                  '在庫情報.          端数区分(表示用)
        XSTRETCH_STS                    '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        XSTRETCH_STS_DSP                '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ(表示用)
        XKENSA_KUBUN                    '在庫情報.          検査区分
        XKENSA_KUBUN_DSP                '在庫情報.          検査区分(表示用)
        XAB_KUBUN                       '在庫情報.          AB区分

        MAXCOL
    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        CHECK_Click             '確認ﾎﾞﾀﾝｸﾘｯｸ時
        WORK_STOP_Click         '作業中止ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr305011_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr305011.Tick
        Try

            tmr305011.Enabled = False
            mFlag_Form_Load = True


            '*****************************************
            '画面表示処理
            '*****************************************
            If ReDispGamen() = True Then
                '(棚卸し作業無し)
                '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
                'tmr305011.Enabled = False
                'tmr305011.Dispose()
                'Me.Dispose()
                '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
            Else
                '(棚卸し作業あり)
                mFlag_Form_Load = False
                tmr305011.Enabled = True
            End If


        Catch ex As Exception
            ComError(ex)
        Finally

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

        '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
        '*********************************************************
        ' 棚卸し作業日時、搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№ｾｯﾄ
        '*********************************************************
        'mstrTR_TO = gstrTR_TO
        mstrTR_TO = FTRK_BUF_NO_J180        'ｽﾄﾚｯﾁ包装ﾗｲﾝ ST180
        '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応

        Dim strMsg As String = ""


        '***********************************************************
        '初期処理
        '***********************************************************

        '***********************************************************
        '画面表示ｸﾘｱ
        '***********************************************************
        Call ClearControlData()

        '***********************************************************
        '画面表示処理
        '***********************************************************
        Call ReDispGamen()


        tmr305011.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS305011_001))
        tmr305011.Enabled = True

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

        tmr305011.Dispose()

    End Sub
#End Region
#Region "  F5 (確認)                ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        Try
            tmr305011.Enabled = False


            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.CHECK_Click) = False Then
                Exit Sub
            End If


            '********************************************************************
            'ｿｹｯﾄ送信
            '********************************************************************
            If SendSocket01() = False Then
                Exit Sub
            End If

            '***********************************************************
            '計画ｽﾃｰﾀｽﾁｪｯｸ
            '***********************************************************
            Dim strFPALLET_ID As String() = Nothing

            If ReDispGamen() = True Then
                '(棚卸し作業無し)
                tmr305011.Enabled = False
                tmr305011.Dispose()
                Me.Dispose()
            Else
                '(棚卸し作業あり)
                mFlag_Form_Load = False
                tmr305011.Enabled = True
            End If

        Finally
            'tmr305011.Enabled = True
        End Try

    End Sub
#End Region
#Region "  F7 (作業中止)            ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F7Process()

        Try
            tmr305011.Enabled = False

            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.WORK_STOP_Click) = False Then
                Exit Sub
            End If


            '********************************************************************
            'ｿｹｯﾄ送信
            '********************************************************************
            If SendSocket02() = False Then
                Exit Sub
            End If


            '***********************************************************
            '計画ｽﾃｰﾀｽﾁｪｯｸ
            '***********************************************************
            Dim strFPALLET_ID As String() = Nothing

            If gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID) = RetCode.OK Then
                '([ST180],[搬送中]も含めて作業中の時)
                '***********************************************************
                '画面表示処理
                '***********************************************************
                Call ReDispGamen()
            Else
                '(作業無しの時)
                '******************************************
                ' 画面遷移
                '******************************************
                ''Me.Close()
                '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応 画面移行しないようにする。
                'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)
                '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応 画面移行しないようにする。
            End If


        Finally
            tmr305011.Enabled = True
        End Try

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        ''Me.Close()
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)

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
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.CHECK_Click
                '(確認ﾎﾞﾀﾝｸﾘｯｸ時)

                'If TO_STRING(mobjTBL_TPRG_TRK_BUF_PICK_ST.FPALLET_ID) = "" Then
                If mstrFPALLET_ID_CHK = "" Then
                    '(確認中のﾊﾟﾚｯﾄIDがない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305011_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.WORK_STOP_Click
                '(作業中止ﾎﾞﾀﾝｸﾘｯｸ時)

                '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
                '***********************************************************
                '計画ｽﾃｰﾀｽﾁｪｯｸ
                '***********************************************************
                Dim strFPALLET_ID As String() = Nothing

                If gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID) = RetCode.OK Then
                    '([ST180],[搬送中]も含めて作業中の時)
                Else
                    '(作業無しの時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305011_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
                '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応

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
#Region "　画面更新処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面更新処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function ReDispGamen() As Boolean

        Dim blnSTS As Boolean = False

        Dim strFPALLET_ID As String() = Nothing

        If gobjComFuncFRM.TANAOROSHI_STS(mstrTR_TO, strFPALLET_ID) = RetCode.OK Then
            '(STにﾃﾞｰﾀが存在する場合)
            '=====================================
            '在庫情報表示
            '=====================================
            Call DispStockData(strFPALLET_ID(0))
        Else
            '(STにﾃﾞｰﾀが存在しない場合)
            If gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID) = RetCode.OK Then
                '(作業ありの時)
                '=====================================
                '画面表示ｸﾘｱ
                '=====================================
                Call ClearControlData()
            Else
                '(作業無しの時)

                blnSTS = True  '作業無し

                '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
                ''******************************************
                '' 画面遷移
                ''******************************************
                'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)
                '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
            End If
        End If

        Return blnSTS

    End Function
#End Region
#Region "　在庫情報表示処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫情報表示処理
    ''' </summary>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DispStockData(ByVal strFPALLET_ID As String)

        '******************************************
        '在庫情報取得
        '******************************************
        Dim strSQL As String
        Dim objDataSet As New DataSet
        strSQL = ""
        '=============================================
        ' SELECT
        '=============================================
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FBUF_IN_DT "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾞｯﾌｬ入日時
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FTRK_BUF_ARRAY "              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ配列№
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FDISP_ADDRESS "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM "         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        strSQL &= vbCrLf & "   , TRST_STOCK.FPALLET_ID "                    '在庫情報.          ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "   , TRST_STOCK.FHINMEI_CD "                    '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                        '品名ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   , TRST_STOCK.FLOT_NO "                       '在庫情報.          ﾛｯﾄ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XSEIZOU_DT "                    '在庫情報.          製造年月日
        strSQL &= vbCrLf & "   , TRST_STOCK.XLINE_NO "                      '在庫情報.          ﾗｲﾝ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XPALLET_NO "                    '在庫情報.          ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "   , SUM(TRST_STOCK.FTR_VOL) AS FTR_VOL_SUM "   '在庫情報.          搬送管理量合計(在庫数量)
        strSQL &= vbCrLf & "   , TRST_STOCK.XSYUKKA_KAHI "                  '在庫情報.          出荷可否
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "   '在庫情報.          出荷可否(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XHINSHITU_STS "                 '在庫情報.          品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "  '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FHORYU_KUBUN "                  '在庫情報.          保留区分
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "   '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FARRIVE_DT "                    '在庫情報.          在庫発生日時
        strSQL &= vbCrLf & "   , TRST_STOCK.XASRS_IN_DT "                   '在庫情報..         入庫日時
        strSQL &= vbCrLf & "   , TRST_STOCK.FHASU_FLAG "                    '在庫情報.          端数区分
        strSQL &= vbCrLf & "   , HASH04.FGAMEN_DISP AS FHASU_FLAG_DSP "     '在庫情報.          端数区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XSTRETCH_STS "                  '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH05.FGAMEN_DISP AS XSTRETCH_STS_DSP "   '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XKENSA_KUBUN "                  '在庫情報.          検査区分
        strSQL &= vbCrLf & "   , HASH06.FGAMEN_DISP AS XKENSA_KUBUN_DSP "   '在庫情報.          検査区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XAB_KUBUN "                     '在庫情報.          AB区分

        '=============================================
        ' FROM
        '=============================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TSTS_HIKIATE "
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "   , TRST_STOCK "
        strSQL &= vbCrLf & "   , TMST_ITEM "
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TRST_STOCK", "FHASU_FLAG")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XSTRETCH_STS")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "XKENSA_KUBUN")

        '=============================================
        ' WHERE
        '=============================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mstrTR_TO                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№で結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "            'ﾊﾟﾚｯﾄIDで結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "              'ﾊﾟﾚｯﾄIDで結合
        strSQL &= vbCrLf & "     AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "                 '品名ｺｰﾄﾞで結合
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TRST_STOCK", "FHASU_FLAG")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TRST_STOCK", "XSTRETCH_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = '" & strFPALLET_ID & "' "              'ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FSAGYOU_KIND IN (" & FSAGYOU_KIND_JOUT_TANA
        strSQL &= vbCrLf & "                                      , " & FSAGYOU_KIND_JOUT_TANA_AUTO
        strSQL &= vbCrLf & "                                      ) "

        '=============================================
        ' GROUP BY
        '=============================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FBUF_IN_DT "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾞｯﾌｬ入日時
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FTRK_BUF_ARRAY "              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ配列№
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FDISP_ADDRESS "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM "         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        strSQL &= vbCrLf & "   , TRST_STOCK.FPALLET_ID "                    '在庫情報.          ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "   , TRST_STOCK.FHINMEI_CD "                    '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                        '品名ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   , TRST_STOCK.FLOT_NO "                       '在庫情報.          ﾛｯﾄ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XSEIZOU_DT "                    '在庫情報.          製造年月日
        strSQL &= vbCrLf & "   , TRST_STOCK.XLINE_NO "                      '在庫情報.          ﾗｲﾝ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XPALLET_NO "                    '在庫情報.          ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XSYUKKA_KAHI "                  '在庫情報.          出荷可否
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP "                       '在庫情報.          出荷可否(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XHINSHITU_STS "                 '在庫情報.          品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP "                       '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FHORYU_KUBUN "                  '在庫情報.          保留区分
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP "                       '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FARRIVE_DT "                    '在庫情報.          在庫発生日時
        strSQL &= vbCrLf & "   , TRST_STOCK.XASRS_IN_DT "                   '在庫情報.          入庫日時
        strSQL &= vbCrLf & "   , TRST_STOCK.FHASU_FLAG "                    '在庫情報.          端数区分
        strSQL &= vbCrLf & "   , HASH04.FGAMEN_DISP "                       '在庫情報.          端数区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XSTRETCH_STS "                  '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ
        strSQL &= vbCrLf & "   , HASH05.FGAMEN_DISP "                       '在庫情報.          ｽﾄﾚｯﾁｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XKENSA_KUBUN "                  '在庫情報.          検査区分
        strSQL &= vbCrLf & "   , HASH06.FGAMEN_DISP "                       '在庫情報.          検査区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XAB_KUBUN "                     '在庫情報.          AB区分

        '=============================================
        ' ORDER BY
        '=============================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FBUF_IN_DT "
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FTRK_BUF_ARRAY "
        strSQL &= vbCrLf


        gobjDb.SQL = strSQL
        Dim strTableName As String = "TRST_STOCK"
        gobjDb.GetDataSet(strTableName, objDataSet)
        If objDataSet.Tables(strTableName).Rows.Count <= 0 Then
            '(ﾃﾞｰﾀが取得できなかった場合)
            Call ClearControlData()             '画面表示ｸﾘｱ
            Exit Sub
        End If
        Dim objRow As DataRow
        objRow = objDataSet.Tables(strTableName).Rows(0)


        '*************************************
        'ｺﾝﾄﾛｰﾙｾｯﾄ
        '*************************************
        ''Dim strFormat As String
        ''strFormat = GetFTR_VOLFormat(TO_INTEGER(objRow(menmListCol.FDECIMAL_POINT)))                'ﾌｫｰﾏｯﾄ取得

        mstrFPALLET_ID_CHK = strFPALLET_ID                                                          '確認中のﾊﾟﾚｯﾄID

        lblFDISP_ADDRESS.Text = TO_STRING(objRow(menmListCol.FDISPLOG_ADDRESS_FM))                  'ﾛｹｰｼｮﾝ

        lblFHINMEI_CD.Text = TO_STRING(objRow(menmListCol.FHINMEI_CD))                              '品名ｺｰﾄﾞ
        lblFHINMEI.Text = TO_STRING(objRow(menmListCol.FHINMEI))                                    '品名
        If IsDate(objRow(menmListCol.XSEIZOU_DT)) = True Then
            '(日時が入っている場合)
            lblXSEIZOU_DT.Text = Format(objRow(menmListCol.XSEIZOU_DT), GAMEN_DATE_FORMAT_03)       '製造年月日
        Else
            lblXSEIZOU_DT.Text = ""                                                                 '製造年月日
        End If
        lblXLINE_NO.Text = TO_STRING(objRow(menmListCol.XLINE_NO))                                  'ﾗｲﾝ№
        lblXPALLET_NO.Text = TO_STRING(objRow(menmListCol.XPALLET_NO))                              'ﾊﾟﾚｯﾄ№
        lblFTR_VOL.Text = TO_STRING(TO_DECIMAL(objRow(menmListCol.FTR_VOL_SUM)))                    '在庫数量
        lblXSYUKKA_KAHI.Text = TO_STRING(objRow(menmListCol.XSYUKKA_KAHI_DSP))                      '出荷可否
        lblXHINSHITU_STS.Text = TO_STRING(objRow(menmListCol.XHINSHITU_STS_DSP))                    '品質ｽﾃｰﾀｽ
        lblFHORYU_KUBUN.Text = TO_STRING(objRow(menmListCol.FHORYU_KUBUN_DSP))                      '保留区分
        If IsDate(objRow(menmListCol.FARRIVE_DT)) = True Then
            '(日時が入っている場合)
            lblFARRIVE_DT.Text = Format(objRow(menmListCol.FARRIVE_DT), GAMEN_DATE_FORMAT_02)       '在庫発生日時
        Else
            lblFARRIVE_DT.Text = ""                                                                 '在庫発生日時
        End If
        If IsDate(objRow(menmListCol.XASRS_IN_DT)) = True Then
            '(日時が入っている場合)
            lblXASRS_IN_DT.Text = Format(objRow(menmListCol.XASRS_IN_DT), GAMEN_DATE_FORMAT_02)      '入庫日時
        Else
            lblXASRS_IN_DT.Text = ""                                                                 '入庫日時
        End If
        lblFHASU_FLAG.Text = TO_STRING(objRow(menmListCol.FHASU_FLAG_DSP))                          '端数区分

        lblXSTRETCH_STS.Text = TO_STRING(objRow(menmListCol.XSTRETCH_STS_DSP))                      'ｽﾄﾚｯﾁｽﾃｰﾀｽ
        lblXKENSA_KUBUN.Text = TO_STRING(objRow(menmListCol.XKENSA_KUBUN))                          '検査区分
        lblXAB_KUBUN.Text = TO_STRING(objRow(menmListCol.XAB_KUBUN))                                'AB区分


        mFlag_StockData_Comp = True

    End Sub
#End Region
#Region "　画面在庫情報ｸﾘｱ処理                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面在庫情報ｸﾘｱ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClearControlData()

        '*************************************
        'ｺﾝﾄﾛｰﾙ初期化
        '*************************************
        mstrFPALLET_ID_CHK = ""             '確認中のﾊﾟﾚｯﾄID

        lblFDISP_ADDRESS.Text = ""          'ﾛｹｰｼｮﾝ
        lblFHINMEI_CD.Text = ""             '品名ｺｰﾄﾞ
        lblFHINMEI.Text = ""                '品名
        lblXSEIZOU_DT.Text = ""             '製造年月日
        lblXLINE_NO.Text = ""               'ﾗｲﾝ№
        lblXPALLET_NO.Text = ""             'ﾊﾟﾚｯﾄ№
        lblFTR_VOL.Text = ""                '積込数
        lblXSYUKKA_KAHI.Text = ""           '出荷可否
        lblXHINSHITU_STS.Text = ""          '品質ｽﾃｰﾀｽ
        lblFHORYU_KUBUN.Text = ""           '保留区分
        lblFARRIVE_DT.Text = ""             '在庫発生日時
        lblXASRS_IN_DT.Text = ""             '入庫日時
        lblFHASU_FLAG.Text = ""             '端数区分
        lblXSTRETCH_STS.Text = ""           'ｽﾄﾚｯﾁｽﾃｰﾀｽ
        lblXKENSA_KUBUN.Text = ""           '検査区分
        lblXAB_KUBUN.Text = ""              'AB区分


        mFlag_StockData_Comp = False

    End Sub
#End Region

#Region "  ｿｹｯﾄ送信01 (確認)                        "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket01() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= FRM_MSG_FRM305011_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strFPALLET_ID As String = ""         '

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400302           'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strFPALLET_ID = mstrFPALLET_ID_CHK                                   'ﾊﾟﾚｯﾄID

        objTelegram.SETIN_DATA("DSPPALLET_ID", strFPALLET_ID)                'ﾊﾟﾚｯﾄID


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM305011_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If
        ''If udtSckSendRET = clsSocketClient.RetCode.OK Then
        ''    '(送信できた場合)
        ''    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
        ''        '(正常終了の場合)
        ''        blnRet = True
        ''    Else
        ''        '(処理が異常終了した場合)
        ''        Call DisplayPopup(strErrMsg, _
        ''                          PopupFormType.Ok, _
        ''                          PopupIconType.Err)
        ''    End If
        ''ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
        ''    '(ﾀｲﾑｱｳﾄの場合)
        ''Else
        ''    '(その他の場合)
        ''    Call DisplayPopup(strErrMsg, _
        ''                      PopupFormType.Ok, _
        ''                      PopupIconType.Err)
        ''End If

        Return blnRet

    End Function

#End Region
#Region "  ｿｹｯﾄ送信02 (作業中止)                    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= FRM_MSG_FRM305011_03
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400303          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DUMMY", "")             'ﾀﾞﾐｰ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM305011_04
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If
        ''If udtSckSendRET = clsSocketClient.RetCode.OK Then
        ''    '(送信できた場合)
        ''    If strRET_STATE = ID_RETURN_RET_STATE_OK Then
        ''        '(正常終了の場合)
        ''        blnRet = True
        ''    Else
        ''        '(処理が異常終了した場合)
        ''        Call DisplayPopup(strErrMsg, _
        ''                          PopupFormType.Ok, _
        ''                          PopupIconType.Err)
        ''    End If
        ''ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
        ''    '(ﾀｲﾑｱｳﾄの場合)
        ''Else
        ''    '(その他の場合)
        ''    Call DisplayPopup(strErrMsg, _
        ''                      PopupFormType.Ok, _
        ''                      PopupIconType.Err)
        ''End If

        Return blnRet

    End Function

#End Region

End Class
