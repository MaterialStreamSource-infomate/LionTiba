'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾊﾞｰｽ状況ﾓﾆﾀ
' 【作成】SIT
'**********************************************************************************************
#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311090
#Region "　共通変数　                           "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mintBERTH_COUNT As Integer = 20              'ﾊﾞｰｽNoのｶｳﾝﾄ用定数
    Private mintLoaderBERTH_COUNT As Integer = 6         'ﾛｰﾀﾞﾊﾞｰｽNoのｶｳﾝﾄ用定数

    Private mPlayer As System.Media.SoundPlayer = Nothing   '音楽再生用

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmBerthListCol
        XBERTH_NO             'ﾊﾞｰｽ
        XSTS_CONVEYOR         'ｺﾝﾍﾞﾔﾓｰﾄﾞ
        XSYARYOU_NO           '車輌No.
        XHENSEI_NO_OYA        '親編成No.
        XHENSEI_NO1           '編成No.1
        XHENSEI_NO2           '編成No.2
        XHENSEI_NO3           '編成No.3
        XHENSEI_NO4           '編成No.4
        XTUMI_HOUHOU          '積込方法
        XTUMI_HOUKOU          '積込方向
        XOUT_START_DT         '出庫開始日時
        ZAN_PL                '残PL

        SYUKKO_PL             '出庫中PL
        HANSOU_PL             '搬送中PL

        XSYUKKA_STS           '出荷状況
        XSYUKKA_D             '出荷日
        FEQ_CUT_STS           '切離
        FEQ_ID                '設備ID

        DATA18                '未使用
        DATA19                '未使用
        DATA20                '未使用

        MAXCOL

    End Enum

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
    Enum menmWaitListCol
        XSYARYOU_NO           '車輌No.
        XBERTH_SET            'ﾊﾞｰｽ指定
        XTUMI_HOUKOU          '積込方向
        XSYUKKA_D             '出荷日
        XHENSEI_NO_OYA        '親編成No.
        DATA05                  '未使用

        MAXCOL
    End Enum
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾀｲﾏｰ 表示更新                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ 表示更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311090_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr311090.Tick
        Try

            tmr311090.Enabled = False


            '**************************************************
            ' 表示更新ﾀｲﾏｰ処理
            '**************************************************
            Call tmr311090_TickProcess()


        Catch ex As Exception
            ComError(ex)
        Finally
            tmr311090.Enabled = True

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

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
#Region "　ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ                            "
    '*******************************************************************************************************************
    '【機能】ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub chkDISP_FLG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDISP_FLG.CheckedChanged
        If chkDISP_FLG.Checked = False Then
            GroupBox3.Visible = False
            GroupBox4.Visible = False
            GroupBox5.Visible = False
        Else
            GroupBox3.Visible = True
            GroupBox4.Visible = True
            GroupBox5.Visible = True
        End If
    End Sub
#End Region
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
    '↑↑↑↑↑↑************************************************************************************************************

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
        ' 左部ﾒﾆｭｰ消去
        '*********************************************
        cmd01.Visible = False
        cmd02.Visible = False
        cmd03.Visible = False
        cmd04.Visible = False
        cmd05.Visible = False
        cmd06.Visible = False
        cmd07.Visible = False
        cmd08.Visible = False
        cmd09.Visible = False
        cmd10.Visible = False
        Button4.Visible = False

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList_Berth, 1, menmBerthListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call gobjComFuncFRM.FlexGridInitialize(grdList_Loader, 1, menmBerthListCol.MAXCOL) 'ｸﾞﾘｯﾄﾞ初期設定
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        Call gobjComFuncFRM.FlexGridInitialize(grdList_PL_Wait, 1, menmWaitListCol.MAXCOL)
        Call gobjComFuncFRM.FlexGridInitialize(grdList_Bara_Wait, 1, menmWaitListCol.MAXCOL)
        Call gobjComFuncFRM.FlexGridInitialize(grdList_Wait, 1, menmWaitListCol.MAXCOL)
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        '↑↑↑↑↑↑************************************************************************************************************

        grdListDisplay_Loader()
        grdListDisplay_Berth()
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        Dim intDispFlg As Integer       '表示ﾌﾗｸﾞ
        intDispFlg = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ311090_001))
        If intDispFlg <> FLAG_ON Then
            chkDISP_FLG.Checked = False
        End If

        grdListDisplay_PL_Wait()        'ﾊﾟﾚｯﾄ積み待ち車輌
        grdListDisplay_Bara_Wait()      'ﾊﾞﾗ積み待ち車輌
        grdListDisplay_Wait()           'ﾛｰﾀﾞ積み待ち車輌
        If chkDISP_FLG.Checked = False Then
            GroupBox3.Visible = False
            GroupBox4.Visible = False
            GroupBox5.Visible = False
        End If
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        '↑↑↑↑↑↑************************************************************************************************************

        tmr311090.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS311090_001))
        tmr311090.Enabled = True




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
        grdList_Berth.Dispose()
        grdList_Loader.Dispose()

    End Sub
#End Region

#Region "  F4(戻る)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        Me.Close()

    End Sub
#End Region

#Region "　ｸﾞﾘｯﾄﾞ表示(ﾊﾞｰｽ)　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(ﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_Berth()

        '*******************************************
        ' SQL文
        '*******************************************
        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable20      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '============================================================
        'SELECT 出荷ﾊﾞｰｽ状況
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                  '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_GROUP"                         '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XHENSEI_NO XHENSEI_NO"                '出荷ﾊﾞｰｽ状況.  編成No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_STS XBERTH_STS"                '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽ指示状況
        '' ''strSQL &= vbCrLf & "  , XSTS_BERTH.FEQ_ID FEQ_ID"                        '出荷ﾊﾞｰｽ状況.  設備ID
        'strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
        'strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '出荷指示.  積込方法
        'strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        'strSQL &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '出荷指示.  出庫開始日時
        'strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '出荷指示.  出荷状況
        'strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
        'strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO XHENSEI_NO"                  '出荷指示.  編成No.

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                     '【出荷ﾊﾞｰｽ状況】
        'strSQL &= vbCrLf & "  , XPLN_OUT "                                       '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_BERTH.XBERTH_NO LIKE 'Y%' "
        'strSQL &= vbCrLf & "    AND XSTS_BERTH.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA(+) "    '出荷ﾊﾞｰｽ状況　と　出荷指示　を　編成No.　で結合
        'strSQL &= vbCrLf & "    AND XSTS_BERTH.XSYUKKA_D = XPLN_OUT.XSYUKKA_D(+) "          '出荷ﾊﾞｰｽ状況　と　出荷指示　を　出荷日　 で結合


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_BERTH"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim strXBERTH_NO As String = ""         'ﾊﾞｰｽNo.
                Dim strXBERTH_GROUP As String = ""      'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                Dim strXBERTH_YOUTO As String = ""      'ｺﾝﾍﾞﾔ用途
                Dim strXSYUKKA_D As String = ""         '出荷日
                Dim strXHENSEI_NO_OYA As String = ""    '親編成No.
                Dim strXBERTH_STS As String = ""        'ﾊﾞｰｽ指示状況

                Dim strXSYARYOU_NO As String = ""               '車輌No.
                Dim strXTUMI_HOUHOU As String = ""              '積込方法
                Dim strXTUMI_HOUKOU As String = ""              '積込方向
                Dim datXOUT_START_DT As New Date(0)             '出庫開始時間
                Dim strXOUT_START_DT As String = ""             '同上
                Dim strXSYUKKA_STS As String = ""               '出荷状況
                Dim strPLCount As String = ""                   '残PL数
                Dim strSYUKKO As String = ""                    '出庫中PL数
                Dim strHANSOUTYUU As String = ""                '搬送中PL数
                Dim strXHENSEI_NO(3) As String                  '編成No.

                strXBERTH_NO = TO_STRING(objRow("XBERTH_NO"))       'ﾊﾞｰｽNo.

                'ｺﾝﾍﾞﾔ用途
                strXBERTH_GROUP = TO_STRING(objRow("XBERTH_GROUP"))
                strXBERTH_YOUTO = gobjComFuncFRM.GetXCONVEYOR_YOUTO(strXBERTH_GROUP)

                strXSYUKKA_D = TO_STRING(objRow("XSYUKKA_D"))       '出荷日
                strXHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO")) '親編成No.
                strXBERTH_STS = TO_STRING(objRow("XBERTH_STS"))     'ﾊﾞｰｽ指示状況

                Select Case TO_INTEGER(strXBERTH_STS)
                    ' ''Case XBERTH_STS_JSESSYA
                    ' ''    'ﾊﾞｰｽ使用状況が1:「接車」の場合
                    ' ''    strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                    ' ''    strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))
                    ' ''    strXTUMI_HOUKOU = TO_STRING(objRow2("XTUMI_HOUKOU"))
                    ' ''    datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))

                    ' ''    If datXOUT_START_DT <> New Date(0) Then
                    ' ''        strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_01)
                    ' ''    End If

                    Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                        'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                        '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                        Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                        objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                        objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                        objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                        objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                        strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                End Select

                '============================================================
                ' 出荷指示 取得
                '============================================================
                If strXSYUKKA_D <> "" And _
                    strXHENSEI_NO_OYA <> "" Then
                    '(出荷日と編成No.が設定されている場合)

                    Dim strSQL2 As String                           'SQL文
                    Dim objRow2 As DataRow                          '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                    Dim strDataSetName2 As String                   'ﾃﾞｰﾀｾｯﾄ名
                    Dim objDataSet2 As New DataSet                  'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

                    '============================================================
                    'SELECT 出荷指示
                    '============================================================
                    strSQL2 = ""
                    strSQL2 &= vbCrLf & "SELECT "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '出荷指示.  積込方法
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '出荷指示.  出庫開始日時
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '出荷指示.  出荷状況
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO XHENSEI_NO"                  '出荷指示.  編成No.

                    strSQL2 &= vbCrLf & " FROM "
                    strSQL2 &= vbCrLf & "    XPLN_OUT "                                       '【出荷指示】

                    '============================================================
                    'WHERE
                    '============================================================
                    strSQL2 &= vbCrLf & " WHERE "
                    strSQL2 &= vbCrLf & "        XPLN_OUT.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '親編成No.
                    strSQL2 &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_D = '" & strXSYUKKA_D & "' "              '出荷日

                    '============================================================
                    'ORDER BY
                    '============================================================
                    strSQL2 &= vbCrLf & " ORDER BY  "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

                    '-----------------------
                    '抽出
                    '-----------------------
                    gobjDb.SQL = strSQL2
                    objDataSet2.Clear()
                    strDataSetName2 = "XPLN_OUT"
                    gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                    If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        '(1件目の共通ﾃﾞｰﾀを取得)
                        objRow2 = objDataSet2.Tables(strDataSetName2).Rows(0)

                        Select Case TO_INTEGER(strXBERTH_STS)
                            Case XBERTH_STS_JSESSYA
                                'ﾊﾞｰｽ使用状況が1:「接車」の場合
                                strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                                strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))

                                Select Case TO_STRING(objRow2("XTUMI_HOUKOU"))
                                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                                        strXTUMI_HOUKOU = "後積"
                                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                                        strXTUMI_HOUKOU = "片横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                                        strXTUMI_HOUKOU = "両横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                                        strXTUMI_HOUKOU = "ALL"
                                End Select

                                datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))
                                If datXOUT_START_DT <> New Date(0) Then
                                    strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_02)
                                End If

                                ' ''Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                                ' ''    'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                                ' ''    '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                                ' ''    Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                                ' ''    objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                                ' ''    objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                                ' ''    objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                                ' ''    objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                                ' ''    strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                        End Select

                        '出荷状況
                        If gobjComFuncFRM.BERTH_GetKeppin(strXBERTH_NO) = True Then
                            strXSYUKKA_STS = XSYUKKA_STS_JLESS
                        Else
                            strXSYUKKA_STS = TO_STRING(objRow2("XSYUKKA_STS"))
                        End If
                        'INTSYUKKA_STS = TO_STRING(objRow("INTSYUKKA_STS"))

                        '' ''ﾊﾞｰｽ切離取得
                        ' ''Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                        ' ''If TO_STRING(objRow("FEQ_ID")) <> "" Then
                        ' ''    objTBL_TSTS_EQ_CTRL.FEQ_ID = TO_STRING(objRow("FEQ_ID"))
                        ' ''    objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
                        ' ''End If

                        ' ﾊﾞｰｽ毎のPL数取得
                        strPLCount = TO_STRING(gobjComFuncFRM.BERTH_GetPLCount(strXBERTH_NO))
                        'If strPLCount = "0" Then
                        '    '(PL数が0の場合)
                        '    strPLCount = ""
                        'End If

                    End If

                    ' 編成No.の取得
                    strXHENSEI_NO = gobjComFuncFRM.BERTH_GetHENSEI_NO(strXBERTH_NO)

                    ' 出庫中PLの取得
                    strSYUKKO = TO_STRING(gobjComFuncFRM.COUNT_SYUKKO(strXBERTH_NO))

                    ' 搬送中PLの取得
                    strHANSOUTYUU = TO_STRING(gobjComFuncFRM.COUNT_HANSOUTYUU(strXBERTH_NO))


                End If

                '============================================================
                ' 設備状態 取得
                '============================================================
                Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                objTBL_TSTS_EQ_CTRL.FEQ_ID = strXBERTH_NO
                objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()

                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '********************************************************************
                objDataTable.userAddRowDataSet(strXBERTH_NO, _
                                               strXBERTH_YOUTO, _
                                               strXSYARYOU_NO, _
                                               strXHENSEI_NO_OYA, _
                                               strXHENSEI_NO(0), _
                                               strXHENSEI_NO(1), _
                                               strXHENSEI_NO(2), _
                                               strXHENSEI_NO(3), _
                                               strXTUMI_HOUHOU, _
                                               strXTUMI_HOUKOU, _
                                               strXOUT_START_DT, _
                                               strPLCount, _
                                               strSYUKKO, _
                                               strHANSOUTYUU, _
                                               strXSYUKKA_STS, _
                                               TO_DATE(objRow("XSYUKKA_D")), _
                                               objTBL_TSTS_EQ_CTRL.FEQ_CUT_STS, _
                                               objTBL_TSTS_EQ_CTRL.FEQ_ID _
                                               )

                '' ''============================================================
                '' ''音声合成用前回ﾃﾞｰﾀ取得
                '' ''============================================================
                ' ''mSTRFRONT_SYARYOU(ii) = TO_STRING(objRow("XSYARYOU_NO"))
                ' ''mSTRBERTH_NO(ii) = TO_STRING(objRow("XBERTH_NO"))
                ' ''mDTMSYUKKA_D(ii) = TO_DATE(objRow("XSYUKKA_D"))              '音声合成の比較用　　出荷日No
                ' ''mSTRHENSEI_NO(ii) = TO_STRING(objRow("XHENSEI_NO"))          '音声合成の比較用　　編成No

            Next
        End If

        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Berth, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataTable = Nothing
        objDataTable = New GamenCommon.clsGridDataTable20

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_BerthSetup()                'ｸﾞﾘｯﾄﾞ表示設定
        If grdList_Berth.RowCount > 0 Then
            Call gobjComFuncFRM.GridSelect(grdList_Berth, intSelectRow, 4, objPoint)     'ｸﾞﾘｯﾄﾞ選択処理
        End If

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾊﾞｰｽ)　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(ﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_BerthSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Berth)

        '************************************************
        '色変更の確認
        '************************************************
        Dim i As Integer
        For i = 0 To grdList_Berth.RowCount - 1
            Dim strXSYUKKA_STS As String
            strXSYUKKA_STS = grdList_Berth.Item(menmBerthListCol.XSYUKKA_STS, i).FormattedValue()             '出荷状況

            If strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_DTL_JLESS) Then
                '(欠品の場合)
                grdList_Berth.Item(menmBerthListCol.XSYARYOU_NO, i).Style.BackColor = Color.Red

            End If

            Dim strFEQ_CUT_STS As String
            strFEQ_CUT_STS = grdList_Berth.Item(menmBerthListCol.FEQ_CUT_STS, i).FormattedValue()             '設備切離し状況
            If strFEQ_CUT_STS = TO_STRING(FEQ_CUT_STS_SON) Then
                '(切離しの場合)
                grdList_Berth.Item(menmBerthListCol.XBERTH_NO, i).Style.BackColor = Color.Yellow

            End If

        Next

        '' ''************************************************
        '' ''ｿｰﾄ無効
        '' ''************************************************
        ' ''For i = 0 To grdList_Berth.ColumnCount - 1
        ' ''    grdList_Berth.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        ' ''Next

    End Sub
#End Region

#Region "　ｸﾞﾘｯﾄﾞ表示(ﾛｰﾀﾞﾊﾞｰｽ)　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(ﾛｰﾀﾞﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_Loader()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable20      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '============================================================
        'SELECT 出荷ﾊﾞｰｽ状況
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                  '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_GROUP "                        '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XHENSEI_NO XHENSEI_NO"                '出荷ﾊﾞｰｽ状況.  編成No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_STS XBERTH_STS"                '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽ指示状況
        strSQL &= vbCrLf & "  , XSTS_BERTH.FEQ_ID FEQ_ID"                        '出荷ﾊﾞｰｽ状況.  設備ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                     '【出荷ﾊﾞｰｽ状況】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO LIKE 'X%' "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_BERTH"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim strXBERTH_NO As String = ""         'ﾊﾞｰｽNo.
                Dim strXBERTH_GROUP As String = ""      'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                Dim strXBERTH_YOUTO As String = ""      'ｺﾝﾍﾞﾔ用途
                Dim strXSYUKKA_D As String = ""         '出荷日
                Dim strXHENSEI_NO_OYA As String = ""    '親編成No.
                Dim strXBERTH_STS As String = ""        'ﾊﾞｰｽ指示状況

                Dim strXSYARYOU_NO As String = ""               '車輌No.
                Dim strXTUMI_HOUHOU As String = ""              '積込方法
                Dim strXTUMI_HOUKOU As String = ""              '積込方向
                Dim datXOUT_START_DT As New Date(0)             '出庫開始時間
                Dim strXOUT_START_DT As String = ""             '同上
                Dim strXSYUKKA_STS As String = ""               '出荷状況
                Dim strPLCount As String = ""                   '残PL数
                Dim strSYUKKO As String = ""                    '出庫中PL数
                Dim strHANSOUTYUU As String = ""                '搬送中PL数
                Dim strXHENSEI_NO(3) As String                  '編成No.

                strXBERTH_NO = TO_STRING(objRow("XBERTH_NO"))       'ﾊﾞｰｽNo.

                'ｺﾝﾍﾞﾔ用途
                strXBERTH_GROUP = TO_STRING(objRow("XBERTH_GROUP"))
                strXBERTH_YOUTO = gobjComFuncFRM.GetXCONVEYOR_YOUTO(strXBERTH_GROUP)


                strXSYUKKA_D = TO_STRING(objRow("XSYUKKA_D"))       '出荷日
                strXHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO")) '親編成No.
                strXBERTH_STS = TO_STRING(objRow("XBERTH_STS"))     'ﾊﾞｰｽ指示状況

                Select Case TO_INTEGER(strXBERTH_STS)
                    ' ''Case XBERTH_STS_JSESSYA
                    ' ''    'ﾊﾞｰｽ使用状況が1:「接車」の場合
                    ' ''    strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                    ' ''    strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))
                    ' ''    strXTUMI_HOUKOU = TO_STRING(objRow2("XTUMI_HOUKOU"))
                    ' ''    datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))

                    ' ''    If datXOUT_START_DT <> New Date(0) Then
                    ' ''        strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_01)
                    ' ''    End If

                    Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                        'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                        '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                        Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                        objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                        objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                        objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                        objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                        strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                End Select

                '============================================================
                ' 出荷指示 取得
                '============================================================
                If strXSYUKKA_D <> "" And _
                    strXHENSEI_NO_OYA <> "" Then
                    '(出荷日と編成No.が設定されている場合)

                    Dim strSQL2 As String                           'SQL文
                    Dim objRow2 As DataRow                          '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                    Dim strDataSetName2 As String                   'ﾃﾞｰﾀｾｯﾄ名
                    Dim objDataSet2 As New DataSet                  'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

                    '============================================================
                    'SELECT 出荷指示
                    '============================================================
                    strSQL2 = ""
                    strSQL2 &= vbCrLf & "SELECT "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '出荷指示.  積込方法
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '出荷指示.  出庫開始日時
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '出荷指示.  出荷状況
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO XHENSEI_NO"                  '出荷指示.  編成No.

                    strSQL2 &= vbCrLf & " FROM "
                    strSQL2 &= vbCrLf & "    XPLN_OUT "                                       '【出荷指示】

                    '============================================================
                    'WHERE
                    '============================================================
                    strSQL2 &= vbCrLf & " WHERE "
                    strSQL2 &= vbCrLf & "        XPLN_OUT.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '親編成No.
                    strSQL2 &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_D = '" & strXSYUKKA_D & "' "              '出荷日

                    '============================================================
                    'ORDER BY
                    '============================================================
                    strSQL2 &= vbCrLf & " ORDER BY  "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

                    '-----------------------
                    '抽出
                    '-----------------------
                    gobjDb.SQL = strSQL2
                    objDataSet2.Clear()
                    strDataSetName2 = "XPLN_OUT"
                    gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                    If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        '(1件目の共通ﾃﾞｰﾀを取得)
                        objRow2 = objDataSet2.Tables(strDataSetName2).Rows(0)

                        Select Case TO_INTEGER(strXBERTH_STS)
                            Case XBERTH_STS_JSESSYA
                                'ﾊﾞｰｽ使用状況が1:「接車」の場合
                                strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                                strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))

                                Select Case TO_STRING(objRow2("XTUMI_HOUKOU"))
                                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                                        strXTUMI_HOUKOU = "後積"
                                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                                        strXTUMI_HOUKOU = "片横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                                        strXTUMI_HOUKOU = "両横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                                        strXTUMI_HOUKOU = "ALL"
                                End Select

                                datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))
                                If datXOUT_START_DT <> New Date(0) Then
                                    strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_02)
                                End If

                                ' ''Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                                ' ''    'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                                ' ''    '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                                ' ''    Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                                ' ''    objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                                ' ''    objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                                ' ''    objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                                ' ''    objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                                ' ''    strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                        End Select

                        '出荷状況
                        If gobjComFuncFRM.BERTH_GetKeppin(strXBERTH_NO) = True Then
                            strXSYUKKA_STS = XSYUKKA_STS_JLESS
                        Else
                            strXSYUKKA_STS = TO_STRING(objRow2("XSYUKKA_STS"))
                        End If
                        'INTSYUKKA_STS = TO_STRING(objRow("INTSYUKKA_STS"))

                        '' ''ﾊﾞｰｽ切離取得
                        ' ''Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                        ' ''If TO_STRING(objRow("FEQ_ID")) <> "" Then
                        ' ''    objTBL_TSTS_EQ_CTRL.FEQ_ID = TO_STRING(objRow("FEQ_ID"))
                        ' ''    objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
                        ' ''End If

                        ' ﾊﾞｰｽ毎のPL数取得
                        strPLCount = TO_STRING(gobjComFuncFRM.BERTH_GetPLCount(strXBERTH_NO))
                        'If strPLCount = "0" Then
                        '    '(PL数が0の場合)
                        '    strPLCount = ""
                        'End If

                    End If

                    ' 編成No.の取得
                    strXHENSEI_NO = gobjComFuncFRM.BERTH_GetHENSEI_NO(strXBERTH_NO)

                    ' 出庫中PLの取得
                    strSYUKKO = TO_STRING(gobjComFuncFRM.COUNT_SYUKKO(strXBERTH_NO))

                    ' 搬送中PLの取得
                    strHANSOUTYUU = TO_STRING(gobjComFuncFRM.COUNT_HANSOUTYUU(strXBERTH_NO))

                End If

                '============================================================
                ' 設備状態 取得
                '============================================================
                Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                objTBL_TSTS_EQ_CTRL.FEQ_ID = strXBERTH_NO
                objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()

                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '********************************************************************
                objDataTable.userAddRowDataSet(strXBERTH_NO, _
                                               strXBERTH_YOUTO, _
                                               strXSYARYOU_NO, _
                                               strXHENSEI_NO_OYA, _
                                               strXHENSEI_NO(0), _
                                               strXHENSEI_NO(1), _
                                               strXHENSEI_NO(2), _
                                               strXHENSEI_NO(3), _
                                               strXTUMI_HOUHOU, _
                                               strXTUMI_HOUKOU, _
                                               strXOUT_START_DT, _
                                               strPLCount, _
                                               strSYUKKO, _
                                               strHANSOUTYUU, _
                                               strXSYUKKA_STS, _
                                               TO_DATE(objRow("XSYUKKA_D")), _
                                               objTBL_TSTS_EQ_CTRL.FEQ_CUT_STS, _
                                               objTBL_TSTS_EQ_CTRL.FEQ_ID _
                                               )

                '' ''============================================================
                '' ''音声合成用前回ﾃﾞｰﾀ取得
                '' ''============================================================
                ' ''mSTRFRONT_SYARYOU(ii) = TO_STRING(objRow("XSYARYOU_NO"))
                ' ''mSTRBERTH_NO(ii) = TO_STRING(objRow("XBERTH_NO"))
                ' ''mDTMSYUKKA_D(ii) = TO_DATE(objRow("XSYUKKA_D"))              '音声合成の比較用　　出荷日No
                ' ''mSTRHENSEI_NO(ii) = TO_STRING(objRow("XHENSEI_NO"))          '音声合成の比較用　　編成No
            Next
        End If

        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Loader, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataTable = Nothing
        objDataTable = New GamenCommon.clsGridDataTable20

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_LoaderSetup()                'ｸﾞﾘｯﾄﾞ表示設定
        If grdList_Loader.RowCount > 0 Then
            Call gobjComFuncFRM.GridSelect(grdList_Loader, intSelectRow, 3, objPoint)     'ｸﾞﾘｯﾄﾞ選択処理
        End If

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾛｰﾀﾞﾊﾞｰｽ)　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(ﾛｰﾀﾞﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_LoaderSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Loader)

        '************************************************
        '色変更の確認
        '************************************************
        Dim i As Integer
        For i = 0 To grdList_Loader.RowCount - 1
            Dim strXSYUKKA_STS As String
            strXSYUKKA_STS = grdList_Loader.Item(menmBerthListCol.XSYUKKA_STS, i).FormattedValue()             '出荷状況

            If strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_DTL_JLESS) Then
                '(欠品の場合)
                grdList_Loader.Item(menmBerthListCol.XSYARYOU_NO, i).Style.BackColor = Color.Red

            End If

            Dim strFEQ_CUT_STS As String
            strFEQ_CUT_STS = grdList_Loader.Item(menmBerthListCol.FEQ_CUT_STS, i).FormattedValue()             '設備切離し状況
            If strFEQ_CUT_STS = TO_STRING(FEQ_CUT_STS_SON) Then
                '(切離しの場合)
                grdList_Loader.Item(menmBerthListCol.XBERTH_NO, i).Style.BackColor = Color.Yellow

            End If

        Next

        '' ''************************************************
        '' ''ｿｰﾄ無効
        '' ''************************************************
        ' ''For i = 0 To grdList_Loader.ColumnCount - 1
        ' ''    grdList_Loader.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        ' ''Next

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
#Region "  ｸﾞﾘｯﾄﾞ表示   (ﾊﾟﾚｯﾄ積み待ち車輌)       　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListDisplay_PL_Wait()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable05()      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        objDataTable.Clear()

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT 出荷指示
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO "               '出荷指示.  車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO XBERTH_NO"                    '出荷指示.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_D XSYUKKA_D"                    '出荷指示.  出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "                                           '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XSYUKKA_STS = " & XSYUKKA_STS_JDIR & " "       '出荷指示.出荷状況 = 3(指示済)
        strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA "         '出荷指示.編成No = 出荷指示.親編成No
        strSQL &= vbCrLf & "    AND XPLN_OUT.XTUMI_HOUHOU = " & XTUMI_HOUHOU_JP & " "       '出荷指示.積込方法 = 1(:パレット)

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL DESC"                                '出荷指示.緊急度 　　　     降順
        strSQL &= vbCrLf & "   ,XPLN_OUT.XSYUKKA_DIR_DT"                                    '出荷指示.出荷指示日時      昇順

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                Dim XSYARYOU_NO As String = ""                    '車輌No
                Dim XBERTH_NO As String = ""                     'ﾊﾞｰｽ指定
                Dim XTUMI_HOUKOU As String = ""                   '積込方向
                Dim XSYUKKA_D As New Date(0)                      '出荷日
                Dim XHENSEI_NO_OYA As String = ""                 '親編成No


                XSYARYOU_NO = TO_STRING(objRow("XSYARYOU_NO"))
                If TO_STRING(objRow("XBERTH_NO")) = "0" Then
                    XBERTH_NO = ""
                Else
                    XBERTH_NO = TO_STRING(objRow("XBERTH_NO"))
                End If

                Select Case TO_STRING(objRow("XTUMI_HOUKOU"))
                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                        XTUMI_HOUKOU = "後積"
                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                        XTUMI_HOUKOU = "片横積"
                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                        XTUMI_HOUKOU = "両横積"
                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                        XTUMI_HOUKOU = "ALL"
                End Select

                XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))
                XHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO_OYA"))

                '-----------------------
                ' 重複車輌の確認
                '-----------------------
                Dim objRow2 As DataRow
                Dim blnFind As Boolean = False
                For Each objRow2 In objDataTable.Rows
                    If XSYARYOU_NO = TO_STRING(objRow2.Item(0)) And _
                      XSYUKKA_D = TO_STRING(objRow2.Item(3)) And _
                      XHENSEI_NO_OYA = TO_STRING(objRow2.Item(4)) Then
                        '(車輌番号、出荷日、親編成No.が一致した場合)
                        blnFind = True
                        Exit For
                    End If
                Next

                If blnFind = False Then
                    '(重複なしの場合)
                    objDataTable.userAddRowDataSet(XSYARYOU_NO, _
                                                   XBERTH_NO, _
                                                   XTUMI_HOUKOU, _
                                                   XSYUKKA_D, _
                                                   XHENSEI_NO_OYA)
                End If

            Next
        End If

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_PL_Wait, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_PL_Wait_Setup()                                                                'ｸﾞﾘｯﾄﾞ表示設定
        Call gobjComFuncFRM.GridSelect(grdList_PL_Wait, intSelectRow, intSelectCol, objPoint)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾊﾟﾚｯﾄ積み待ち車輌)　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(ﾊﾟﾚｯﾄ積み待ち車輌)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_PL_Wait_Setup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_PL_Wait)

    End Sub
#End Region

#Region "  ｸﾞﾘｯﾄﾞ表示   (ﾊﾞﾗ積み待ち車輌)         　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListDisplay_Bara_Wait()
        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim objDataTable As New GamenCommon.clsGridDataTable05()      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
        objDataTable.Clear()

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT 出荷指示
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO XBERTH_NO"                  '出荷指示.  ﾊﾞｰｽ指定
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_D XSYUKKA_D"                    '出荷指示.  出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "                                           '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XSYUKKA_STS = " & XSYUKKA_STS_JDIR & " "   '出荷指示.出荷状況 = 3(指示済)
        strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA"     '出荷指示.編成No = 出荷指示.親編成No
        strSQL &= vbCrLf & "    AND XPLN_OUT.XTUMI_HOUHOU = " & XTUMI_HOUHOU_JB & " "   '出荷指示.積込方法 = 2(:バラ)


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL　DESC"                          '出荷指示.緊急度        降順
        strSQL &= vbCrLf & "   ,XPLN_OUT.XSYUKKA_DIR_DT"                               '出荷指示.出荷指示日時  昇順

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                Dim XSYARYOU_NO As String = ""                    '車輌No
                Dim XBERTH_NO As String = ""                      'ﾊﾞｰｽNo
                Dim XTUMI_HOUKOU As String = ""                   '積込方向
                Dim XSYUKKA_D As New Date(0)                      '出荷日
                Dim XHENSEI_NO_OYA As String = ""                 '親編成No


                XSYARYOU_NO = TO_STRING(objRow("XSYARYOU_NO"))
                If TO_STRING(objRow("XBERTH_NO")) = "0" Then
                    XBERTH_NO = ""
                Else
                    XBERTH_NO = TO_STRING(objRow("XBERTH_NO"))
                End If
                Select Case TO_STRING(objRow("XTUMI_HOUKOU"))
                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                        XTUMI_HOUKOU = "後積"
                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                        XTUMI_HOUKOU = "片横積"
                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                        XTUMI_HOUKOU = "両横積"
                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                        XTUMI_HOUKOU = "ALL"
                End Select
                XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))
                XHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO_OYA"))

                '-----------------------
                ' 重複車輌の確認
                '-----------------------
                Dim objRow2 As DataRow
                Dim blnFind As Boolean = False
                For Each objRow2 In objDataTable.Rows
                    If XSYARYOU_NO = TO_STRING(objRow2.Item(0)) And _
                      XSYUKKA_D = TO_STRING(objRow2.Item(3)) And _
                      XHENSEI_NO_OYA = TO_STRING(objRow2.Item(4)) Then
                        '(車輌番号、出荷日、親編成No.が一致した場合)
                        blnFind = True
                        Exit For
                    End If
                Next

                If blnFind = False Then
                    '(重複なしの場合)
                    objDataTable.userAddRowDataSet(XSYARYOU_NO, _
                                                   XBERTH_NO, _
                                                   XTUMI_HOUKOU, _
                                                   XSYUKKA_D, _
                                                   XHENSEI_NO_OYA)
                End If

            Next
        End If

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Bara_Wait, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_Bara_Wait_Setup()                                                              'ｸﾞﾘｯﾄﾞ表示設定
        Call gobjComFuncFRM.GridSelect(grdList_Bara_Wait, intSelectRow, intSelectCol, objPoint)     'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾊﾞﾗ積み待ち車輌)　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(ﾊﾞﾗ積み待ち車輌)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_Bara_Wait_Setup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Bara_Wait)

    End Sub
#End Region

#Region "  ｸﾞﾘｯﾄﾞ表示   (ﾛｰﾀﾞ積み待ち車輌)        　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListDisplay_Wait()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable05()      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        objDataTable.Clear()

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT 出荷指示
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO XBERTH_NO"                    '出荷指示.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_D XSYUKKA_D"                    '出荷指示.  出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "                                           '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XSYUKKA_STS = " & XSYUKKA_STS_JDIR & " "       '出荷指示.出荷状況 = 3(指示済)
        strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA"          '出荷指示.編成No = 出荷指示.親編成No
        strSQL &= vbCrLf & "    AND XPLN_OUT.XTUMI_HOUHOU = " & XTUMI_HOUHOU_JL & " "       '出荷指示.積込方法 = 3(:ﾛｰﾀﾞ)

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL DESC"                                '出荷指示.緊急度 　　　     降順
        strSQL &= vbCrLf & "   ,XPLN_OUT.XSYUKKA_DIR_DT"                                    '出荷指示.出荷指示日時      昇順

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                Dim XSYARYOU_NO As String = ""                    '車輌No
                Dim XBERTH_NO As String = ""                     'ﾊﾞｰｽ指定
                Dim XTUMI_HOUKOU As String = ""                   '積込方向
                Dim XSYUKKA_D As New Date(0)                      '出荷日
                Dim XHENSEI_NO_OYA As String = ""                 '親編成No


                XSYARYOU_NO = TO_STRING(objRow("XSYARYOU_NO"))
                If TO_STRING(objRow("XBERTH_NO")) = "0" Then
                    XBERTH_NO = ""
                Else
                    XBERTH_NO = TO_STRING(objRow("XBERTH_NO"))
                End If
                Select Case TO_STRING(objRow("XTUMI_HOUKOU"))
                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                        XTUMI_HOUKOU = "後積"
                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                        XTUMI_HOUKOU = "片横積"
                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                        XTUMI_HOUKOU = "両横積"
                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                        XTUMI_HOUKOU = "ALL"
                End Select
                XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))
                XHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO_OYA"))

                '-----------------------
                ' 重複車輌の確認
                '-----------------------
                Dim objRow2 As DataRow
                Dim blnFind As Boolean = False
                For Each objRow2 In objDataTable.Rows
                    If XSYARYOU_NO = TO_STRING(objRow2.Item(0)) And _
                      XSYUKKA_D = TO_STRING(objRow2.Item(3)) And _
                      XHENSEI_NO_OYA = TO_STRING(objRow2.Item(4)) Then
                        '(車輌番号、出荷日、親編成No.が一致した場合)
                        blnFind = True
                        Exit For
                    End If
                Next

                If blnFind = False Then
                    '(重複なしの場合)
                    objDataTable.userAddRowDataSet(XSYARYOU_NO, _
                                                   XBERTH_NO, _
                                                   XTUMI_HOUKOU, _
                                                   XSYUKKA_D, _
                                                   XHENSEI_NO_OYA)
                End If

            Next
        End If

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Wait, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataTable = Nothing
        objDataTable = New GamenCommon.clsGridDataTable05

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_Wait_Setup()                                                               'ｸﾞﾘｯﾄﾞ表示設定
        Call gobjComFuncFRM.GridSelect(grdList_Wait, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾛｰﾀﾞ積み待ち車輌)　       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(待ち車輌)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_Wait_Setup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Wait)

    End Sub
#End Region
    'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  表示更新ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面更新ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311090_TickProcess()

        Dim blnSoundFlg As Boolean = False     '音再生ﾌﾗｸﾞ
        Dim i As Integer = 0

        '**********************************************************
        ' 更新前状態の記録
        '**********************************************************
        'ﾛｰﾀﾞﾊﾞｰｽ
        Dim strXSYUKKA_D_Loader(grdList_Loader.RowCount - 1) As String      'ﾛｰﾀﾞﾊﾞｰｽ 出荷日
        Dim strXHENSEI_NO1_Loader(grdList_Loader.RowCount - 1) As String    'ﾛｰﾀﾞﾊﾞｰｽ 編成No.1

        For i = 0 To grdList_Loader.RowCount - 1
            '(各行ごとに記録)
            strXSYUKKA_D_Loader(i) = TO_STRING(grdList_Loader.Item(menmBerthListCol.XSYUKKA_D, i).Value)
            strXHENSEI_NO1_Loader(i) = TO_STRING(grdList_Loader.Item(menmBerthListCol.XHENSEI_NO1, i).Value)
        Next

        'ﾊﾞｰｽ
        Dim strXSYUKKA_DT_Berth(grdList_Berth.RowCount - 1) As String       'ﾊﾞｰｽ 出荷日
        Dim strXHENSEI_NO1_Berth(grdList_Berth.RowCount - 1) As String      'ﾊﾞｰｽ 編成No.1
        Dim strXHENSEI_NO2_Berth(grdList_Berth.RowCount - 1) As String      'ﾊﾞｰｽ 編成No.2
        Dim strXHENSEI_NO3_Berth(grdList_Berth.RowCount - 1) As String      'ﾊﾞｰｽ 編成No.3
        Dim strXHENSEI_NO4_Berth(grdList_Berth.RowCount - 1) As String      'ﾊﾞｰｽ 編成No.4

        For i = 0 To grdList_Berth.RowCount - 1
            '(各行ごとに記録)
            strXSYUKKA_DT_Berth(i) = TO_STRING(grdList_Berth.Item(menmBerthListCol.XSYUKKA_D, i).Value)
            strXHENSEI_NO1_Berth(i) = TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO1, i).Value)
            strXHENSEI_NO2_Berth(i) = TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO2, i).Value)
            strXHENSEI_NO3_Berth(i) = TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO3, i).Value)
            strXHENSEI_NO4_Berth(i) = TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO4, i).Value)

        Next

        '**********************************************************
        ' 状態表示変更（ ｸﾞﾘｯﾄﾞ表示）
        '**********************************************************
        grdList_Loader.ScrollBars = ScrollBars.None
        Call grdListDisplay_Loader()        'ﾛｰﾀﾞﾊﾞｰｽ   状態
        grdList_Loader.ScrollBars = ScrollBars.Both
        grdList_Berth.ScrollBars = ScrollBars.None
        Call grdListDisplay_Berth()         'ﾊﾞｰｽ       状態
        grdList_Berth.ScrollBars = ScrollBars.Both

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        grdListDisplay_PL_Wait()        'ﾊﾟﾚｯﾄ積み待ち車輌
        grdListDisplay_Bara_Wait()      'ﾊﾞﾗ積み待ち車輌
        grdListDisplay_Wait()           'ﾛｰﾀﾞ積み待ち車輌
        'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ 待ち行列追加
        '↑↑↑↑↑↑************************************************************************************************************

        Me.Refresh()

        '**********************************************************
        ' 更新後の変更有無ﾁｪｯｸ
        '**********************************************************
        'ﾛｰﾀﾞﾊﾞｰｽ
        For i = 0 To grdList_Loader.Rows.Count - 1
            '(変更されていないかﾁｪｯｸ)
            If ((TO_STRING(grdList_Loader.Item(menmBerthListCol.XSYUKKA_D, i).Value) <> strXSYUKKA_D_Loader(i)) _
                Or (TO_STRING(grdList_Loader.Item(menmBerthListCol.XHENSEI_NO1, i).Value) <> strXHENSEI_NO1_Loader(i))) _
               And (TO_STRING(grdList_Loader.Item(menmBerthListCol.XHENSEI_NO1, i).Value) <> "") Then
                '(出荷日が異なる or 編成No.1が違う場合)
                '(編成Noが空=終了時は無視)

                blnSoundFlg = True      '音再生ﾌﾗｸﾞ

            End If
        Next

        'ﾊﾞｰｽ
        For i = 0 To grdList_Berth.Rows.Count - 1
            '(変更されていないかﾁｪｯｸ)
            If ((TO_STRING(grdList_Berth.Item(menmBerthListCol.XSYUKKA_D, i).Value) <> strXSYUKKA_DT_Berth(i)) _
                Or (TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO1, i).Value) <> strXHENSEI_NO1_Berth(i))) _
               And (TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO1, i).Value) <> "") Then
                '(出荷日が異なる or 編成No.1が違う場合)
                '(編成Noが空=終了時は無視)

                blnSoundFlg = True      '音再生ﾌﾗｸﾞ

            End If
        Next

        '**********************************************************
        ' 音再生
        '**********************************************************
        If blnSoundFlg = True Then
            '(音再生ﾌﾗｸﾞがOn)
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ ﾌｧｲﾙ指定音声対応
            '' ''System.Media.SystemSounds.Asterisk.Play()

            '' '' '' ''ﾌｧｲﾙ名取得
            ' '' '' ''Dim strWaveFile As String
            ' '' '' ''strWaveFile = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303010_001)

            '' '' '' ''再生されているときは止める
            ' '' '' ''If Not (mPlayer Is Nothing) Then
            ' '' '' ''    mPlayer.Stop()
            ' '' '' ''    mPlayer.Dispose()
            ' '' '' ''    mPlayer = Nothing
            ' '' '' ''End If

            '' '' '' ''読み込む
            ' '' '' ''mPlayer = New System.Media.SoundPlayer(strWaveFile)
            '' '' '' ''非同期再生する
            ' '' '' ''mPlayer.Play()

            '' '' '' ''次のようにすると、ループ再生される
            '' '' '' ''player.PlayLooping()

            '' '' '' ''次のようにすると、最後まで再生し終えるまで待機する
            '' '' '' ''player.PlaySync()

            'ﾌｧｲﾙ名取得
            Dim strWaveFile As String
            strWaveFile = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ311090_002)

            '再生されているときは止める
            If Not (mPlayer Is Nothing) Then
                mPlayer.Stop()
                mPlayer.Dispose()
                mPlayer = Nothing
            End If

            If Dir(strWaveFile) <> "" Then
                '読み込む
                mPlayer = New System.Media.SoundPlayer(strWaveFile)
                '非同期再生する
                mPlayer.Play()

                '次のようにすると、ループ再生される
                'player.PlayLooping()

                '次のようにすると、最後まで再生し終えるまで待機する
                'player.PlaySync()
            End If
            'JobMate:S.Ouchi 2013/10/31 ﾊﾞｰｽ状況ﾓﾆﾀ ﾌｧｲﾙ指定音声対応
            '↑↑↑↑↑↑************************************************************************************************************


        End If

        'System.Media.SystemSounds.Asterisk.Play()

        '' ''********************************************************************
        '' '' 音声合成用のﾃﾞｰﾀの比較
        '' ''********************************************************************
        ' ''Dim strMSG As String = ""             '音声合成用ﾒｯｾｰｼﾞ

        ' ''For ii As Integer = LBound(mDTMSYUKKA_D) To UBound(mDTMSYUKKA_D)
        ' ''    '----------------------------------------------
        ' ''    '出荷日、編成Noが違っていた場合、
        ' ''    '音声案内を実行
        ' ''    '----------------------------------------------
        ' ''    If ( _
        ' ''       (mDTMSYUKKA_D(ii) <> DTMSYUKKA_D_before(ii)) _
        ' ''       Or (mSTRHENSEI_NO(ii) <> STRHENSEI_NO_before(ii)) _
        ' ''       ) _
        ' ''       And (mSTRHENSEI_NO(ii) <> "") Then

        ' ''        '-----------------------------------------
        ' ''        '車両ﾅﾝﾊﾞｰをゆっくり喋らす
        ' ''        '-----------------------------------------
        ' ''        Const strSpeakSpeed As String = "{T3}"      '喋るｽﾋﾟｰﾄﾞ
        ' ''        Const strCarNoSpeed As String = "{T0}"      '車両Noの喋るｽﾋﾟｰﾄﾞ
        ' ''        Dim STRFRONT_SYARYOU_Slow As String         '車両ﾅﾝﾊﾞｰをゆっくり喋らす文字列
        ' ''        STRFRONT_SYARYOU_Slow = strCarNoSpeed & mSTRFRONT_SYARYOU(ii)

        ' ''        Dim strSpeakHeader As String = "お待たせしました"       '最初の言葉
        ' ''        Select Case Val(Format(Now, "ss")) Mod 10
        ' ''            Case 1
        ' ''                'strSpeakHeader = "まいどおおきに"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 2
        ' ''                'strSpeakHeader = "まいどおおきに"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 3
        ' ''                'strSpeakHeader = "たばこの吸いすぎには注意しましょう"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 4
        ' ''                'strSpeakHeader = "いつもお世話になっております"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 5
        ' ''                'strSpeakHeader = "おつかれさまです"
        ' ''                strSpeakHeader = "今日もご安全に"
        ' ''            Case 6
        ' ''                'strSpeakHeader = "まいど、ごくろうさまです"
        ' ''                strSpeakHeader = "今日も安全運転でお願いします"
        ' ''            Case 7
        ' ''                strSpeakHeader = "今日もご安全に"
        ' ''            Case 8
        ' ''                strSpeakHeader = "今日も安全運転でお願いします"
        ' ''            Case 9
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case Else
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''        End Select

        ' ''        strMSG &= "{B4}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ
        ' ''        strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        strMSG &= strSpeakHeader                                                            'ﾍｯﾀﾞｰ部分
        ' ''        strMSG &= "、車輌ナンバー、" & STRFRONT_SYARYOU_Slow                                'ｾﾘﾌ
        ' ''        strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        strMSG &= "の運転手のかたは、" & mINTBERTH_NO(ii) & "番バースに、接車して下さい"    'ｾﾘﾌ
        ' ''        strMSG &= "{B5}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ

        ' ''        '' ''strMSG &= "{B4}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ
        ' ''        '' ''strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        '' ''strMSG &= "お待たせしました、車輌ナンバー、" & STRFRONT_SYARYOU_Slow                'ｾﾘﾌ
        ' ''        '' ''strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        '' ''strMSG &= "の運転手のかたは、" & mINTBERTH_NO(ii) & "番バースに、接車して下さい"    'ｾﾘﾌ
        ' ''        '' ''strMSG &= "{B5}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ

        ' ''    End If

        ' ''Next

        ' ''Call Speak(strMSG)


    End Sub
#End Region
End Class
