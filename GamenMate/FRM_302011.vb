'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産入庫設定子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region
Public Class FRM_302011
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
    Private mBlnDPL As Boolean = False                  'ﾃﾞﾊﾟﾚﾌﾗｸﾞ
    'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXMST_DPL_PL As TBL_XMST_DPL_PL                          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
    Dim mobjXSTS_PRODUCT_IN As TBL_XSTS_PRODUCT_IN                  '生産入庫設定状態ﾃｰﾌﾞﾙ
    Dim mobjXSTS_WRAPPING_MATERIAL As TBL_XSTS_WRAPPING_MATERIAL    '包材出庫設定状態ﾃｰﾌﾞﾙ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mintXDPL_PL_NO As Integer                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Protected mstrXDPL_PL_NAME As String                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
    Protected mstrXPROD_LINE As String                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .生産ﾗｲﾝ№
    Protected mintXDPL_PL_ONLINE As Nullable(Of Integer)    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
    Protected mintXDPL_PL_STS As Nullable(Of Integer)       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
    Protected mintFEQ_STS_01 As Nullable(Of Integer)        '設備状況(異常状態)     .設備状態
    Protected mstrFHINMEI_CD As String                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .品目ｺｰﾄﾞ
    Protected mintXDPL_PL_PTN As Nullable(Of Integer)       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        UntenBtn_Click                  '運転
        TeisiBtn_Click                  '停止
        DataClear_Click                 'ﾃﾞｰﾀｸﾘｱ
        SeisanEND_Click                 '生産終了
        HinsyuBtn_Click                 '品種設定
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        HaraiBtn_Click                  '払出停止
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDPL_PL_NO() As Integer
        Get
            Return mintXDPL_PL_NO
        End Get
        Set(ByVal value As Integer)
            mintXDPL_PL_NO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDPL_PL_NAME() As String
        Get
            Return mstrXDPL_PL_NAME
        End Get
        Set(ByVal value As String)
            mstrXDPL_PL_NAME = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>生産ﾗｲﾝ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXPROD_LINE() As String
        Get
            Return mstrXPROD_LINE
        End Get
        Set(ByVal value As String)
            mstrXPROD_LINE = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ｵﾝﾗｲﾝ状態</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDPL_PL_ONLINE() As Nullable(Of Integer)
        Get
            Return mintXDPL_PL_ONLINE
        End Get
        Set(ByVal value As Nullable(Of Integer))
            mintXDPL_PL_ONLINE = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>運転状態</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDPL_PL_STS() As Nullable(Of Integer)
        Get
            Return mintXDPL_PL_STS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            mintXDPL_PL_STS = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>異常状態</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFEQ_STS_01() As Nullable(Of Integer)
        Get
            Return mintFEQ_STS_01
        End Get
        Set(ByVal value As Nullable(Of Integer))
            mintFEQ_STS_01 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品目ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾊﾟﾀｰﾝ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXDPL_PL_PTN() As Nullable(Of Integer)
        Get
            Return mintXDPL_PL_PTN
        End Get
        Set(ByVal value As Nullable(Of Integer))
            mintXDPL_PL_PTN = value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_302011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_302011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　運転       　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdUnten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnten.Click
        Try

            Call cmdUnten_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　停止       　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdTeisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTeisi.Click
        Try

            Call cmdTeisi_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾘｱ    　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Try

            Call cmdClear_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　生産終了   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSyuryou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSyuryou.Click
        Try

            Call cmdSyuryou_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　品種設定   　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdHinsyu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHinsyu.Click
        Try

            Call cmdHinsyu_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ      　ﾎﾞﾀﾝ押下                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾟﾀｰﾝ        選択処理                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cboXDPL_PL_PTN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXDPL_PL_PTN.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then
                '===================================
                ' ﾊﾟﾀｰﾝ ﾃﾞﾌｫﾙﾄ値 取得
                '===================================
                If cboXDPL_PL_PTN.Text <> "" Then
                    lblPTN_COMMENT.Text = cboXDPL_PL_PTN.SelectedValue
                End If

            End If

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_302011_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()
        Dim intRet As RetCode

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        '' ''If mintXDPL_PL_STS Is Nothing Or _
        '' ''   TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_TEISI Or _
        '' ''   TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_KANOU Then
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        '**********************************************************
        ' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ情報の特定
        '**********************************************************
        mobjXMST_DPL_PL = New TBL_XMST_DPL_PL(gobjOwner, gobjDb, Nothing)
        mobjXMST_DPL_PL.XDPL_PL_NO = mintXDPL_PL_NO               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        mobjXMST_DPL_PL.GET_XMST_DPL_PL()

        '**********************************************************
        ' 生産入庫設定状態の特定
        '**********************************************************
        mobjXSTS_PRODUCT_IN = New TBL_XSTS_PRODUCT_IN(gobjOwner, gobjDb, Nothing)
        mobjXSTS_PRODUCT_IN.FTRK_BUF_NO = mobjXMST_DPL_PL.FTRK_BUF_NO
        intRet = mobjXSTS_PRODUCT_IN.GET_XSTS_PRODUCT_IN(False)

        If intRet <> RetCode.OK Then
            '**********************************************************
            ' 包材出庫設定状態の特定
            '**********************************************************
            mobjXSTS_WRAPPING_MATERIAL = New TBL_XSTS_WRAPPING_MATERIAL(gobjOwner, gobjDb, Nothing)
            mobjXSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = mobjXMST_DPL_PL.FTRK_BUF_NO
            intRet = mobjXSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)
            If intRet = RetCode.OK Then
                mstrFHINMEI_CD = mobjXSTS_WRAPPING_MATERIAL.FHINMEI_CD

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
                mBlnDPL = True                                  'ﾃﾞﾊﾟﾚﾌﾗｸﾞ
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

            Else
                mstrFHINMEI_CD = ""
            End If
        Else
            mstrFHINMEI_CD = mobjXSTS_PRODUCT_IN.FHINMEI_CD
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        '' ''End If
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        lblXDPL_PL_NAME.Text = mstrXDPL_PL_NAME

        '************************************************
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
        '************************************************
        Dim strXDPL_PL_PTN As String = ""
        Dim objXSTS_DPL_PL As New TBL_XSTS_DPL_PL(gobjOwner, gobjDb, Nothing)
        objXSTS_DPL_PL.XDPL_PL_NO = mintXDPL_PL_NO
        objXSTS_DPL_PL.GET_XSTS_DPL_PL(False)
        If TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_PTN) > 0 Then
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
            If IsNull(mstrFHINMEI_CD) = False Then
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

                mintXDPL_PL_PTN = TO_INTEGER(objXSTS_DPL_PL.XDPL_PL_PTN)

                '************************************************
                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
                '************************************************
                Dim objXMST_DPL_PL_PTN As New TBL_XMST_DPL_PL_PTN(gobjOwner, gobjDb, Nothing)
                objXMST_DPL_PL_PTN.XDPL_PL_NO = mintXDPL_PL_NO
                objXMST_DPL_PL_PTN.FHINMEI_CD = mstrFHINMEI_CD
                objXMST_DPL_PL_PTN.XDPL_PL_PTN = mintXDPL_PL_PTN
                intRet = objXMST_DPL_PL_PTN.GET_XMST_DPL_PL_PTN(False)
                If intRet = RetCode.OK Then
                    strXDPL_PL_PTN = objXMST_DPL_PL_PTN.XDPL_PL_PTN_COMMENT
                End If

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
            End If
            'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        End If

        '===================================
        ' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = mstrFHINMEI_CD
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '===================================
        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call cboXDPL_PL_PTN_Setup(cboXDPL_PL_PTN, mintXDPL_PL_NO, mstrFHINMEI_CD, False, strXDPL_PL_PTN, "")
        lblPTN_COMMENT.Text = cboXDPL_PL_PTN.SelectedValue


        If mintXDPL_PL_STS Is Nothing Or _
           TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_TEISI Or _
           TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_KANOU Then
            '===================================
            '運転開始前
            '===================================
            cboFHINMEI_CD.Enabled = False
            cboXDPL_PL_PTN.Enabled = True
            cmdHinsyu.Enabled = True
            cmdUnten.Enabled = True
            cmdTeisi.Enabled = False
            cmdClear.Enabled = True
            cmdSyuryou.Enabled = False
        ElseIf TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_CHUDN Then
            '===================================
            '停止状態
            '===================================
            cboFHINMEI_CD.Enabled = False
            cboXDPL_PL_PTN.Enabled = False
            cmdHinsyu.Enabled = False
            cmdUnten.Enabled = True
            cmdTeisi.Enabled = False
            cmdClear.Enabled = True
            cmdSyuryou.Enabled = True
        Else
            '===================================
            '運転開始後
            '===================================
            cboFHINMEI_CD.Enabled = False
            cboXDPL_PL_PTN.Enabled = False
            cmdHinsyu.Enabled = False
            cmdUnten.Enabled = False
            cmdTeisi.Enabled = True
            cmdClear.Enabled = True
            cmdSyuryou.Enabled = False
            'JobMate:S.Ouchi 2017/05/18 CW6追加対応 デパレ払出停止対応(起動中払出停止対応) ↓↓↓↓↓↓
            'cmdSyuryou.Enabled = False
            If TO_INTEGER(mintXDPL_PL_STS) = XDPL_PL_STS_KIDOU And _
               mBlnDPL = True Then
                cmdSyuryou.Enabled = True
            Else
                cmdSyuryou.Enabled = False
            End If
            'JobMate:S.Ouchi 2017/05/18 CW6追加対応 デパレ払出停止対応(起動中払出停止対応) ↑↑↑↑↑↑

        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        If mBlnDPL = True Then
            cmdSyuryou.Text = "払出停止"
        End If
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************


    End Sub
#End Region
#Region "　運転         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 運転 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdUnten_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.UntenBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket(menmCheckCase.UntenBtn_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　停止         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 停止 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdTeisi_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.TeisiBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket(menmCheckCase.TeisiBtn_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　ﾃﾞｰﾀｸﾘｱ      ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｸﾘｱ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClear_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.DataClear_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket(menmCheckCase.DataClear_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　生産終了     ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 生産終了 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSyuryou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SeisanEND_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket(menmCheckCase.SeisanEND_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　品種設定     ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品種設定 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdHinsyu_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.HinsyuBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket(menmCheckCase.HinsyuBtn_Click) = False Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        '' ''If InputCheck(menmCheckCase.CancelBtn_Click) = False Then
        '' ''    Exit Sub
        '' ''End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = False      'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.UntenBtn_Click, _
                 menmCheckCase.HinsyuBtn_Click
                '(運転の場合)
                '========================================
                '進捗状況
                '========================================
                If udtCheck_Case = menmCheckCase.HinsyuBtn_Click Then
                    If mintXDPL_PL_STS <> XDPL_PL_STS_TEISI And _
                       mintXDPL_PL_STS <> XDPL_PL_STS_KANOU Then
                        '（開始状態の場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM302011_01, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        blnCheckErr = True
                    End If
                ElseIf udtCheck_Case = menmCheckCase.UntenBtn_Click Then
                    If mintXDPL_PL_STS <> XDPL_PL_STS_KANOU And _
                       mintXDPL_PL_STS <> XDPL_PL_STS_CHUDN Then
                        '（開始状態の場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM302011_04, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        blnCheckErr = True
                    End If
                End If
                If blnCheckErr = True Then Exit Select

                '========================================
                '品名ｺｰﾄﾞ
                '========================================
                If mstrFHINMEI_CD = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM302011_02, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '========================================
                'ﾊﾟﾀｰﾝ
                '========================================
                If Trim(cboXDPL_PL_PTN.Text) = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM302011_03, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If
            Case menmCheckCase.TeisiBtn_Click
                '(停止の場合)
            Case menmCheckCase.DataClear_Click
                '(ﾃﾞｰﾀｸﾘｱの場合)
            Case menmCheckCase.SeisanEND_Click
                '(生産終了の場合)
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

#Region "  ｿｹｯﾄ送信                                 "
    ''' <summary>
    ''' ｿｹｯﾄ送信(運転)
    ''' </summary>
    ''' <param name="udtCheck_Case">処理区分</param>
    ''' <returns>True :送信成功 False:送信失敗</returns>
    ''' <remarks></remarks>
    Private Function SendSocket(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False    '自関数戻値
        Dim blnCheckErr As Boolean = True   'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
        If udtCheck_Case = menmCheckCase.SeisanEND_Click Then
            If mBlnDPL = True Then
                udtCheck_Case = menmCheckCase.HaraiBtn_Click
            End If
        End If
        'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        Select Case udtCheck_Case
            Case menmCheckCase.UntenBtn_Click
                strMessage &= "運転を開始" & FRM_MSG_FRM200000_01
            Case menmCheckCase.TeisiBtn_Click
                strMessage &= "運転を停止" & FRM_MSG_FRM200000_01
            Case menmCheckCase.DataClear_Click
                strMessage &= "生産データがクリアされますが" & vbCrLf & "本当によろしいですか？"
            Case menmCheckCase.SeisanEND_Click
                strMessage &= "生産を終了" & FRM_MSG_FRM200000_01

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↓↓↓↓↓↓
            Case menmCheckCase.HaraiBtn_Click
                strMessage &= "払出停止" & FRM_MSG_FRM200000_01
                'JobMate:S.Ouchi 2015/09/15 CW6追加対応 デパレ払出停止対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

            Case menmCheckCase.HinsyuBtn_Click
                strMessage &= "品種を設定" & FRM_MSG_FRM200000_01
        End Select
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim datNow As Date = DateTime.Now

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400901              'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPDIR_KUBUN", TO_STRING(udtCheck_Case))        '処理区分
        objTelegram.SETIN_DATA("XDSPDPL_PL_NO", TO_STRING(mintXDPL_PL_NO))      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        objTelegram.SETIN_DATA("DSPHINMEI_CD", mstrFHINMEI_CD)                  '品名ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPDPL_PL_PTN", cboXDPL_PL_PTN.Text)           'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If


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
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ)  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ)
    ''' </summary>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboXDPL_PL_PTN_Setup(ByRef cboControl As Windows.Forms.ComboBox _
                   , ByVal intXDPL_PL_NO As Integer _
                   , ByVal strFHINMEI_CD As String _
                   , Optional ByVal blnAllFlag As Boolean = True _
                   , Optional ByVal objDefault As Object = Nothing _
                   , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                     )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        cboControl.DataSource = Nothing
        cboControl.Items.Clear()


        '*******************************************************
        ' 包材ﾒｰｶﾏｽﾀ 取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "        XDPL_PL_PTN_COMMENT "       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ   .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝｺﾒﾝﾄ
        strSQL &= vbCrLf & "   ,    XDPL_PL_PTN "               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ   .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "        XMST_DPL_PL_PTN "           '[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ]
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND  XDPL_PL_NO = " & TO_STRING(intXDPL_PL_NO)
        strSQL &= vbCrLf & "   AND  FHINMEI_CD = '" & strFHINMEI_CD & "'"
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "        XDPL_PL_PTN "               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ   .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XMST_DPL_PL_PTN"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                'ｱｲﾃﾑｾｯﾄ
                cboControl.Items.Add(TO_STRING(objRow("XDPL_PL_PTN")))

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XDPL_PL_PTN"))
                Dim SubItem2 As String
                SubItem2 = TO_STRING(objRow("XDPL_PL_PTN_COMMENT"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = SubItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

            Next
        Else
            '(ﾏｽﾀに存在しない場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call gobjComFuncFRM.cboSelectValue(cboControl, objDefault)

        End If

    End Sub
#End Region

End Class
