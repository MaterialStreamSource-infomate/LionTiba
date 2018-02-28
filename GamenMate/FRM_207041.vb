'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文解析画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_207041

#Region "　共通変数　                           "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrEQ_ID As String             '設備ID(PLC・ALC)
    Private mstrDIRECTION As String         '方向
    Private mstrTEXT_ID As String           'ﾃｷｽﾄID
    Private mstrDENBUN As String            '電文
    Private mobjOwner As FRM_207040         'ｵｰﾅｰﾌｫｰﾑ

    Enum menmListCol
        DENBUN_NAME         '電文名称
        DENBUN_CONTENTS     '内容
        DATA02              '未使用
        DATA03              '未使用
        DATA04              '未使用
        DATA05              '未使用

        MAXCOL

    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ''' =======================================
    ''' <summary>ｵｰﾅｰﾌｫｰﾑ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userOWNER() As FRM_207040
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_207040)
            mobjOwner = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userEQ_ID() As String
        Get
            Return mstrEQ_ID
        End Get
        Set(ByVal Value As String)
            mstrEQ_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>方向</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userDIRECTION() As String
        Get
            Return mstrDIRECTION
        End Get
        Set(ByVal Value As String)
            mstrDIRECTION = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾃｷｽﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTEXT_ID() As String
        Get
            Return mstrTEXT_ID
        End Get
        Set(ByVal Value As String)
            mstrTEXT_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>電文</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userDENBUN() As String
        Get
            Return mstrDENBUN
        End Get
        Set(ByVal Value As String)
            mstrDENBUN = Value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207041_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　閉じる   ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じる ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try

            Call cmdClose_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadProcess()

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay()


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理                       "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Private Sub ClosingProcess()

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ開放
        '**********************************************************
        grdList.Dispose()

    End Sub
#End Region
#Region "　閉じる   　ﾎﾞﾀﾝ押下処理　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 閉じる ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClose_ClickProcess()

        Me.Close()

    End Sub

#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()

        'Dim strTelConfigPath As String

        Select Case mstrEQ_ID
            Case FEQ_ID_JSYS0000, FEQ_ID_JSYS0001, FEQ_ID_JSYS0002, FEQ_ID_JSYS0003, FEQ_ID_JSYS0004, FEQ_ID_JSYS0005, FEQ_ID_JSYS0006
                '********************************************************************
                '安川PLC、MELSECのとき
                '********************************************************************
                Call TelegramDisp_Bunkai()

            Case FEQ_ID_JSYS0101
                '********************************************************************
                '車両ｺﾝﾄﾛｰﾗのとき
                '********************************************************************


                If mstrTEXT_ID = FTEXT_ID_JR_CARD Then
                    Call TelegramDisp_CARD01()
                ElseIf mstrTEXT_ID = FTEXT_ID_JS_CARD01 Then
                    Call TelegramDisp_CARD01()

                ElseIf mstrTEXT_ID = FTEXT_ID_JS_CARD02 Then
                    Call TelegramDisp_CARD02()
                End If




        End Select

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示設定　                     "
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
#Region "　電文分解ｸﾞﾘｯﾄﾞ表示(JOB固有)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文分解ｸﾞﾘｯﾄﾞ表示(JOB固有)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_Bunkai()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        Dim strDENBUN_BEFORE As String                      '分解前電文
        Dim strDENBUN_ARY(RTNSiziArray.MAX) As String       '分解後電文

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_BEFORE = strDENBUN_BEFORE.Replace("][", "],[")
        strDENBUN_ARY = Split(strDENBUN_BEFORE, KUGIRI01)

        For jj As Integer = LBound(strDENBUN_ARY) To UBound(strDENBUN_ARY)
            '(ﾙｰﾌﾟ:配列数分)

            Dim strDENBUN_ARY_ROW(1) As String
            strDENBUN_ARY_ROW = Split(strDENBUN_ARY(jj), ":")

            strDENBUN_ARY_ROW(0) = Trim(strDENBUN_ARY_ROW(0).Replace("[", ""))
            strDENBUN_ARY_ROW(1) = Trim(strDENBUN_ARY_ROW(1).Replace("]", ""))


            '**********************************
            '行追加
            '**********************************
            Call objDataTable.userAddRowDataSet(strDENBUN_ARY_ROW(0) _
                                              , strDENBUN_ARY_ROW(1) _
                                              )

        Next

        '↓↓↓↓↓↓************************************************************************************************************
        'CommentMate:A.Noto 2012/06/26 後で設定必須
        ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
        ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
        ''    '(出庫計画電文の時)

        ''    For ii = 1 To intDataKensu - 1
        ''        '(ﾃﾞｰﾀ件数分、2件目から)
        ''        kk = ii * 60 + 31           '電文中の桁位置

        ''        For jj As Integer = 0 To 7
        ''            '(明細項目分)
        ''            strDenData = Mid(mstrDENBUN, kk, intDenLeng(jj))            '内容
        ''            objDataTable.userAddRowDataSet("［" & Microsoft.VisualBasic.Right("00" & TO_STRING(ii + 1), 2) & "］" & _
        ''                                        strDenName(jj), strDenData)  '電文名称、内容のｾｯﾄ

        ''            kk += intDenLeng(jj)    '項目桁数分加算
        ''        Next
        ''    Next
        ''End If
        '↑↑↑↑↑↑************************************************************************************************************


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region

#Region "　電文分解ｸﾞﾘｯﾄﾞ表示(ｶｰﾄﾞ1用)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文分解ｸﾞﾘｯﾄﾞ表示(ｶｰﾄﾞ1用)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_CARD01()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        Dim strDENBUN_BEFORE As String                      '分解前電文
        Dim strDENBUN_ARY() As String                       '分解後電文

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_ARY = Split(strDENBUN_BEFORE, "_")


        '**********************************
        '行追加
        '**********************************
        '制御ｺｰﾄﾞ
        Call objDataTable.userAddRowDataSet("制御ｺｰﾄﾞ", _
                                            strDENBUN_ARY(0) & "_" & strDENBUN_ARY(1) _
                                          )
        'ｶｰﾄﾞ交換機区分
        Call objDataTable.userAddRowDataSet("ｶｰﾄﾞ交換機区分", _
                                            strDENBUN_ARY(2) & "_" & strDENBUN_ARY(3) _
                                          )
        'ｶｰﾄﾞﾘｰﾀﾞ区分
        Call objDataTable.userAddRowDataSet("ｶｰﾄﾞﾘｰﾀﾞ区分", _
                                            strDENBUN_ARY(4) & "_" & strDENBUN_ARY(5) _
                                          )
        'ｶｰﾄﾞﾃﾞｰﾀ
        Call objDataTable.userAddRowDataSet("ｶｰﾄﾞﾃﾞｰﾀ", _
                                            strDENBUN_ARY(6) & "_" & strDENBUN_ARY(7) & "_" & strDENBUN_ARY(8) & "_" & strDENBUN_ARY(9) & "_" & strDENBUN_ARY(10) & "_" & strDENBUN_ARY(11) _
                                          )
        '予備
        Dim strYobi As String = ""
        Dim i As Long
        For i = 12 To UBound(strDENBUN_ARY)
            strYobi = strYobi & strDENBUN_ARY(i) & "_"
        Next
        strYobi = strYobi.Substring(0, Len(strYobi) - 1)

        Call objDataTable.userAddRowDataSet("予備", _
                                            strYobi _
                                          )

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        grdList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grdList.ScrollBars = ScrollBars.Both

    End Sub
#End Region
#Region "　電文分解ｸﾞﾘｯﾄﾞ表示(ｶｰﾄﾞ2用)          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文分解ｸﾞﾘｯﾄﾞ表示(ｶｰﾄﾞ2用)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub TelegramDisp_CARD02()

        Dim objDataTable As New GamenCommon.clsGridDataTable05          'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        Dim strDENBUN_BEFORE As String                      '分解前電文
        Dim strDENBUN_ARY() As String                       '分解後電文

        strDENBUN_BEFORE = mstrDENBUN
        strDENBUN_ARY = Split(strDENBUN_BEFORE, "_")


        '**********************************
        '行追加
        '**********************************
        '制御ｺｰﾄﾞ
        Call objDataTable.userAddRowDataSet("制御ｺｰﾄﾞ", _
                                            strDENBUN_ARY(0) & "_" & strDENBUN_ARY(1) _
                                          )
        'ｶｰﾄﾞ交換機区分
        Call objDataTable.userAddRowDataSet("ｶｰﾄﾞ交換機区分", _
                                            strDENBUN_ARY(2) & "_" & strDENBUN_ARY(3) _
                                          )
        'ｶｰﾄﾞﾘｰﾀﾞ区分
        Call objDataTable.userAddRowDataSet("ｶｰﾄﾞﾘｰﾀﾞ区分", _
                                            strDENBUN_ARY(4) & "_" & strDENBUN_ARY(5) _
                                          )
        'ﾊﾟﾚｯﾂ順位
        Call objDataTable.userAddRowDataSet("ﾊﾟﾚｯﾂ順位", _
                                            strDENBUN_ARY(6) & "_" & strDENBUN_ARY(7) & "_" & strDENBUN_ARY(8) & "_" & strDENBUN_ARY(9) _
                                          )
        '車両No1
        Call objDataTable.userAddRowDataSet("車両No1", _
                                            strDENBUN_ARY(10) & "_" & strDENBUN_ARY(11) & "_" & strDENBUN_ARY(12) & "_" & strDENBUN_ARY(13) _
                                          )
        '車両No2
        Call objDataTable.userAddRowDataSet("車両No2", _
                                            strDENBUN_ARY(14) & "_" & strDENBUN_ARY(15) & "_" & strDENBUN_ARY(16) & "_" & strDENBUN_ARY(17) _
                                          )
        '車両No3
        Call objDataTable.userAddRowDataSet("車両No3", _
                                            strDENBUN_ARY(18) & "_" & strDENBUN_ARY(19) & "_" & strDENBUN_ARY(20) & "_" & strDENBUN_ARY(21) _
                                          )
        '車両No4
        Call objDataTable.userAddRowDataSet("車両No4", _
                                            strDENBUN_ARY(22) & "_" & strDENBUN_ARY(23) & "_" & strDENBUN_ARY(24) & "_" & strDENBUN_ARY(25) _
                                          )
        '車両No5
        Call objDataTable.userAddRowDataSet("車両No5", _
                                            strDENBUN_ARY(26) & "_" & strDENBUN_ARY(27) & "_" & strDENBUN_ARY(28) & "_" & strDENBUN_ARY(29) _
                                          )
        '車両No6
        Call objDataTable.userAddRowDataSet("車両No6", _
                                            strDENBUN_ARY(30) & "_" & strDENBUN_ARY(31) & "_" & strDENBUN_ARY(32) & "_" & strDENBUN_ARY(33) _
                                          )
        '車両No7
        Call objDataTable.userAddRowDataSet("車両No7", _
                                            strDENBUN_ARY(34) & "_" & strDENBUN_ARY(35) & "_" & strDENBUN_ARY(36) & "_" & strDENBUN_ARY(37) _
                                          )
        '車両No8
        Call objDataTable.userAddRowDataSet("車両No8", _
                                            strDENBUN_ARY(38) & "_" & strDENBUN_ARY(39) & "_" & strDENBUN_ARY(40) & "_" & strDENBUN_ARY(41) _
                                          )
        '車両No9
        Call objDataTable.userAddRowDataSet("車両No9", _
                                            strDENBUN_ARY(42) & "_" & strDENBUN_ARY(43) & "_" & strDENBUN_ARY(44) & "_" & strDENBUN_ARY(45) _
                                          )
        '車両No10
        Call objDataTable.userAddRowDataSet("車両No10", _
                                            strDENBUN_ARY(46) & "_" & strDENBUN_ARY(47) & "_" & strDENBUN_ARY(48) & "_" & strDENBUN_ARY(49) _
                                          )
        'ﾊﾞﾗB順位
        Call objDataTable.userAddRowDataSet("ﾊﾞﾗB順位", _
                                            strDENBUN_ARY(50) & "_" & strDENBUN_ARY(51) & "_" & strDENBUN_ARY(52) & "_" & strDENBUN_ARY(53) _
                                          )
        'ﾊﾞﾗC順位
        Call objDataTable.userAddRowDataSet("ﾊﾞﾗC順位", _
                                            strDENBUN_ARY(54) & "_" & strDENBUN_ARY(55) & "_" & strDENBUN_ARY(56) & "_" & strDENBUN_ARY(57) _
                                          )
        '予備
        Dim strYobi As String = ""
        Dim i As Long
        For i = 58 To UBound(strDENBUN_ARY)
            strYobi = strYobi & strDENBUN_ARY(i) & "_"
        Next
        strYobi = strYobi.Substring(0, Len(strYobi) - 1)

        Call objDataTable.userAddRowDataSet("予備", _
                                            strYobi _
                                          )

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
        objDataTable = Nothing


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        grdList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grdList.ScrollBars = ScrollBars.Both

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2013/04/10 未使用
#Region "　電文分解ｸﾞﾘｯﾄﾞ表示(未使用)           "
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' 電文分解ｸﾞﾘｯﾄﾞ表示
    '''' </summary>
    '''' <param name="strTelConfigPath"></param>
    '''' <param name="strFORMAT_ID"></param>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Private Sub TelegramDisp(ByVal strTelConfigPath _
    '                       , ByVal strFORMAT_ID _
    '                       )


    ''********************************************************************
    ''出庫計画(BZ_HOSTSK0)受信電文分解用
    ''********************************************************************
    'Dim intDataKensu As Integer = 0     'ﾃﾞｰﾀ件数
    'Dim strDenName(7) As String         '電文名称
    'Dim intDenLeng(7) As Integer        '内容長さ
    'Dim strDenData As String = ""       '内容
    'Dim ii As Integer = 0
    'Dim kk As Integer = 0


    ''********************************************************************
    ''受信電文分解
    ''********************************************************************
    'Dim objTelegram As New clsTelegram(strTelConfigPath)        '電文
    'objTelegram.FORMAT_ID = strFORMAT_ID                        'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    'objTelegram.TELEGRAM_PARTITION = mstrDENBUN                 '分割する電文ｾｯﾄ
    'objTelegram.PARTITION()


    ''********************************************************************
    ''ﾍｯﾀﾞｰ部分Config取得
    ''********************************************************************
    'Dim strItem As String = ""          'ｱｲﾃﾑ名
    'Dim strItemName As String = ""      'ｱｲﾃﾑ名称
    'Dim objDataTable As New GamenCommon.clsGridDataTable05          'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
    'Dim objDocument As New System.Xml.XmlDocument       'XMLﾄﾞｷｭﾒﾝﾄ
    'Dim objNode As System.Xml.XmlNode                   'XMLﾉｰﾄﾞ
    'objDocument.Load(strTelConfigPath)                  'ﾃﾞｰﾀﾛｰﾄﾞ
    'objDataTable.Clear()                                'ﾃﾞｰﾀﾃｰﾌﾞﾙｸﾘｱ
    'For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
    '    '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

    '    If objNode.Name = XML_NODE_ADD Then
    '        '(ﾃﾞｰﾀ定義の場合)
    '        strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
    '    End If
    '    If objNode.NodeType = Xml.XmlNodeType.Comment Then
    '        strItemName = LTrim(objNode.Value)
    '        If strItem <> "DUMMY" Then
    '            objDataTable.userAddRowDataSet(strItemName _
    '                                         , objTelegram.SELECT_HEADER(strItem) _
    '                                         )
    '            '↓↓↓↓↓↓************************************************************************************************************
    '            'CommentMate:A.Noto 2012/06/26 後で設定必須
    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) And _
    '            ''   (strItem = "BZRECORD_NUM") Then
    '            ''    '(出庫計画電文分解用、ﾃﾞｰﾀ件数の取得)
    '            ''    intDataKensu = TO_INTEGER(objTelegram.SELECT_HEADER(strItem))
    '            ''End If
    '            '↑↑↑↑↑↑************************************************************************************************************

    '        End If

    '    End If

    'Next


    ''********************************************************************
    ''ﾃﾞｰﾀ部分Config取得
    ''********************************************************************
    'For Each objNode In objDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & strFORMAT_ID)
    '    '(ﾙｰﾌﾟ:ﾉｰﾄﾞ数)

    '    If objNode.Name = XML_NODE_ADD Then
    '        '(ﾃﾞｰﾀ定義の場合)
    '        strItem = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value

    '        ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '        ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    '        ''    '(出庫計画電文分解用、各項目長取得)
    '        ''    intDenLeng(ii) = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
    '        ''End If

    '    End If
    '    If objNode.NodeType = Xml.XmlNodeType.Comment Then
    '        strItemName = LTrim(objNode.Value)
    '        If strItem <> "DUMMY" Then
    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) And _
    '            ''   (intDataKensu > 1) Then
    '            ''    '(出庫計画電文で、ﾃﾞｰﾀ件数が1より多い時)
    '            ''    objDataTable.userAddRowDataSet("［01］" & strItemName _
    '            ''                                 , objTelegram.SELECT_DATA(strItem) _
    '            ''                                 )
    '            ''Else
    '            '(以外の時)
    '            objDataTable.userAddRowDataSet(strItemName _
    '                                         , objTelegram.SELECT_DATA(strItem) _
    '                                         )
    '            ''End If

    '            ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    '            ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    '            ''    '(出庫計画電文分解用、電文名称取得)
    '            ''    strDenName(ii) = strItemName
    '            ''    ii += 1
    '            ''End If

    '        End If
    '    End If

    'Next

    ''↓↓↓↓↓↓************************************************************************************************************
    ''CommentMate:A.Noto 2012/06/26 後で設定必須
    ' ''If (mstrEQ_ID = FEQ_ID_JSYS0001) And _
    ' ''   (strFORMAT_ID = FTEXT_ID_JBZ_HOSTSK0) Then
    ' ''    '(出庫計画電文の時)

    ' ''    For ii = 1 To intDataKensu - 1
    ' ''        '(ﾃﾞｰﾀ件数分、2件目から)
    ' ''        kk = ii * 60 + 31           '電文中の桁位置

    ' ''        For jj As Integer = 0 To 7
    ' ''            '(明細項目分)
    ' ''            strDenData = Mid(mstrDENBUN, kk, intDenLeng(jj))            '内容
    ' ''            objDataTable.userAddRowDataSet("［" & Microsoft.VisualBasic.Right("00" & TO_STRING(ii + 1), 2) & "］" & _
    ' ''                                        strDenName(jj), strDenData)  '電文名称、内容のｾｯﾄ

    ' ''            kk += intDenLeng(jj)    '項目桁数分加算
    ' ''        Next
    ' ''    Next
    ' ''End If
    ''↑↑↑↑↑↑************************************************************************************************************


    ''********************************************************************
    ''ｸﾞﾘｯﾄﾞ表示
    ''********************************************************************
    'Call gobjComFuncFRM.GridDisplay(objDataTable, grdList, True)
    'objDataTable = Nothing


    ''********************************************************************
    ''ｸﾞﾘｯﾄﾞ表示設定
    ''********************************************************************
    'Call grdListSetup()
    'Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    'End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

End Class