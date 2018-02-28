'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307123

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrPLC_STNO As String                    'ST№
    Protected mstrPLC_MODE_VOL1 As String               '入庫ﾓｰﾄﾞ
    Protected mstrPLC_MODE_VOL2 As String               '出庫ﾓｰﾄﾞ
    Protected mstrPLC_PARE_VOL As String                'ﾍﾟｱ
    Protected mstrPLC_FORK_VOL1 As String               'ﾌｫｰｸ2
    Protected mstrPLC_FORK_VOL2 As String               'ﾌｫｰｸ1
    Protected mstrPLC_LS As String                      'L/S
    Protected mstrPLC_W_VOL As String                   'Wﾘｰﾁ
    Protected mstrPLC_RETU_VOL As String                '列
    Protected mstrPLC_GOUKI As String                   '号機
    Protected mstrPLC_REN As String                     '連
    Protected mstrPLC_END As String                     'END
    Protected mstrPLC_RETRY As String                   '入庫再設定
    Protected mstrPLC_DAN As String                     '段
    Protected mstrPLC_GOTO_VOL As String                '行先
    Protected mstrPLC_KO_VOL As String                  '子
    Protected mstrPLC_OYA_VOL As String                 '親
    Protected mstrPLC_ZAISEKI_VOL As String             '在席

    Protected mstrPLC_STNO_KO As String                 'ST№(子)
    Protected mstrPLC_MODE_VOL1_KO As String            '入庫ﾓｰﾄﾞ(子)
    Protected mstrPLC_MODE_VOL2_KO As String            '出庫ﾓｰﾄﾞ(子)
    Protected mstrPLC_PARE_VOL_KO As String             'ﾍﾟｱ(子)
    Protected mstrPLC_FORK_VOL1_KO As String            'ﾌｫｰｸ2(子)
    Protected mstrPLC_FORK_VOL2_KO As String            'ﾌｫｰｸ1(子)
    Protected mstrPLC_LS_KO As String                   'L/S(子)
    Protected mstrPLC_W_VOL_KO As String                'Wﾘｰﾁ(子)
    Protected mstrPLC_RETU_VOL_KO As String             '列(子)
    Protected mstrPLC_GOUKI_KO As String                '号機(子)
    Protected mstrPLC_REN_KO As String                  '連(子)
    Protected mstrPLC_END_KO As String                  'END(子)
    Protected mstrPLC_RETRY_KO As String                '入庫再設定(子)
    Protected mstrPLC_DAN_KO As String                  '段(子)
    Protected mstrPLC_GOTO_VOL_KO As String             '行先(子)
    Protected mstrPLC_KO_VOL_KO As String               '子(子)
    Protected mstrPLC_OYA_VOL_KO As String              '親(子)
    Protected mstrPLC_ZAISEKI_VOL_KO As String          '在席(子)

    Protected mstrXMAINTE_KUBUN As String               'ﾒﾝﾃﾅﾝｽ区分

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        Send_Click                  '送信ﾎﾞﾀﾝｸﾘｯｸ時
        Clear_Click                 'ｸﾘｱﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "

    ''' =======================================
    ''' <summary>ST№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_STNO() As String
        Get
            Return mstrPLC_STNO
        End Get
        Set(ByVal value As String)
            mstrPLC_STNO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_MODE_VOL1() As String
        Get
            Return mstrPLC_MODE_VOL1
        End Get
        Set(ByVal value As String)
            mstrPLC_MODE_VOL1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出庫ﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_MODE_VOL2() As String
        Get
            Return mstrPLC_MODE_VOL2
        End Get
        Set(ByVal value As String)
            mstrPLC_MODE_VOL2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾍﾟｱ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_PARE_VOL() As String
        Get
            Return mstrPLC_PARE_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_PARE_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾌｫｰｸ2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FORK_VOL1() As String
        Get
            Return mstrPLC_FORK_VOL1
        End Get
        Set(ByVal value As String)
            mstrPLC_FORK_VOL1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾌｫｰｸ1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FORK_VOL2() As String
        Get
            Return mstrPLC_FORK_VOL2
        End Get
        Set(ByVal value As String)
            mstrPLC_FORK_VOL2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>L/S</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_LS() As String
        Get
            Return mstrPLC_LS
        End Get
        Set(ByVal value As String)
            mstrPLC_LS = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Wﾘｰﾁ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_W_VOL() As String
        Get
            Return mstrPLC_W_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_W_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>列</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_RETU_VOL() As String
        Get
            Return mstrPLC_RETU_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_RETU_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>号機</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_GOUKI() As String
        Get
            Return mstrPLC_GOUKI
        End Get
        Set(ByVal value As String)
            mstrPLC_GOUKI = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>連</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_REN() As String
        Get
            Return mstrPLC_REN
        End Get
        Set(ByVal value As String)
            mstrPLC_REN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>END</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_END() As String
        Get
            Return mstrPLC_END
        End Get
        Set(ByVal value As String)
            mstrPLC_END = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫再設定</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_RETRY() As String
        Get
            Return mstrPLC_RETRY
        End Get
        Set(ByVal value As String)
            mstrPLC_RETRY = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>段</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_DAN() As String
        Get
            Return mstrPLC_DAN
        End Get
        Set(ByVal value As String)
            mstrPLC_DAN = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>行先</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_GOTO_VOL() As String
        Get
            Return mstrPLC_GOTO_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_GOTO_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>子</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_KO_VOL() As String
        Get
            Return mstrPLC_KO_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_KO_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>親</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_OYA_VOL() As String
        Get
            Return mstrPLC_OYA_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_OYA_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在席</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_ZAISEKI_VOL() As String
        Get
            Return mstrPLC_ZAISEKI_VOL
        End Get
        Set(ByVal value As String)
            mstrPLC_ZAISEKI_VOL = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ST№(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_STNO_KO() As String
        Get
            Return mstrPLC_STNO_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_STNO_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫ﾓｰﾄﾞ(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_MODE_VOL1_KO() As String
        Get
            Return mstrPLC_MODE_VOL1_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_MODE_VOL1_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出庫ﾓｰﾄﾞ(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_MODE_VOL2_KO() As String
        Get
            Return mstrPLC_MODE_VOL2_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_MODE_VOL2_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾍﾟｱ(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_PARE_VOL_KO() As String
        Get
            Return mstrPLC_PARE_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_PARE_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾌｫｰｸ2(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FORK_VOL1_KO() As String
        Get
            Return mstrPLC_FORK_VOL1_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_FORK_VOL1_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾌｫｰｸ1(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_FORK_VOL2_KO() As String
        Get
            Return mstrPLC_FORK_VOL2_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_FORK_VOL2_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>L/S(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_LS_KO() As String
        Get
            Return mstrPLC_LS_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_LS_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Wﾘｰﾁ(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_W_VOL_KO() As String
        Get
            Return mstrPLC_W_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_W_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>列(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_RETU_VOL_KO() As String
        Get
            Return mstrPLC_RETU_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_RETU_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>号機(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_GOUKI_KO() As String
        Get
            Return mstrPLC_GOUKI_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_GOUKI_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>連(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_REN_KO() As String
        Get
            Return mstrPLC_REN_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_REN_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>END(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_END_KO() As String
        Get
            Return mstrPLC_END_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_END_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>入庫再設定(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_RETRY_KO() As String
        Get
            Return mstrPLC_RETRY_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_RETRY_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>段(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_DAN_KO() As String
        Get
            Return mstrPLC_DAN_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_DAN_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>行先(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_GOTO_VOL_KO() As String
        Get
            Return mstrPLC_GOTO_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_GOTO_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>子(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_KO_VOL_KO() As String
        Get
            Return mstrPLC_KO_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_KO_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>親(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_OYA_VOL_KO() As String
        Get
            Return mstrPLC_OYA_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_OYA_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在席(子)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPLC_ZAISEKI_VOL_KO() As String
        Get
            Return mstrPLC_ZAISEKI_VOL_KO
        End Get
        Set(ByVal value As String)
            mstrPLC_ZAISEKI_VOL_KO = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾒﾝﾃﾅﾝｽ区分</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXMAINTE_KUBUN() As String
        Get
            Return mstrXMAINTE_KUBUN
        End Get
        Set(ByVal value As String)
            mstrXMAINTE_KUBUN = value
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
    Private Sub FRM_307081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub FRM_307081_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  送信ﾎﾞﾀﾝｸﾘｯｸ                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Try

            Call cmdSend_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
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
#Region "　ｸﾘｱ    　 ﾎﾞﾀﾝ押下                       "
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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        '**********************************************************
        ' 親
        '**********************************************************

        '===================================
        ' ﾗﾍﾞﾙ                 ｾｯﾄ
        '===================================
        lblPLC_STNo.Text = mstrPLC_STNO                     'ST№

        '===================================
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '===================================
        Call gobjComFuncFRM.InitRetuRenDan_TrkBufNo_ALL(FTRK_BUF_NO_J9000, cboPLC_RETU, cboPLC_REN, cboPLC_DAN)

        '===================================
        ' ﾓｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Dim intINOUTMODE As Integer = -1            '入出庫ﾓｰﾄﾞ
        If mstrPLC_MODE_VOL1 = FLAG_ON And mstrPLC_MODE_VOL2 = FLAG_ON Then
            '(出庫ﾓｰﾄﾞのとき)
            intINOUTMODE = INOUT_MODE_VOL_OUT_MODE

        ElseIf mstrPLC_MODE_VOL1 = FLAG_ON And mstrPLC_MODE_VOL2 = FLAG_OFF Then
            '(入庫ﾓｰﾄﾞのとき)
            intINOUTMODE = INOUT_MODE_VOL_IN_MODE

        End If

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_MODE, True, intINOUTMODE)

        '===================================
        ' ﾍﾟｱｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_PARE, False, mstrPLC_PARE_VOL)


        '===================================
        ' ﾌｫｰｸｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Dim intFork As Integer = -1              'ﾌｫｰｸ
        If mstrPLC_FORK_VOL1 = FLAG_ON And mstrPLC_FORK_VOL2 = FLAG_OFF Then
            '(子のとき)
            intFork = FORK_VOL_KO

        ElseIf mstrPLC_FORK_VOL1 = FLAG_OFF And mstrPLC_FORK_VOL2 = FLAG_ON Then
            '(親のとき)
            intFork = FORK_VOL_OYA

        End If

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_FORK, True, intFork)


        '===================================
        ' L/Sｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_LS, True, mstrPLC_LS)


        '===================================
        ' Wﾘｰﾁｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_W, False, mstrPLC_W_VOL)


        '===================================
        ' 左右ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Dim intSAYU As Integer = -1

        If TO_INTEGER(mstrPLC_RETU_VOL) = 0 Then
            '(Nullのとき)
            intSAYU = -1
        ElseIf TO_INTEGER(mstrPLC_RETU_VOL) Mod 2 = 0 Then
            '(偶数のとき)
            intSAYU = RETU_VOL_LEFT
        Else
            '(奇数のとき)
            intSAYU = RETU_VOL_RIGHT
        End If
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_SAYU, True, intSAYU)


        '===================================
        ' 号機ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_GOUKI, True, mstrPLC_GOUKI)


        '===================================
        ' 連ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSelectValue(cboPLC_REN, mstrPLC_REN)


        '===================================
        ' ENDｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_END, False, mstrPLC_END)


        '===================================
        ' 再Fｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_RETRY, False, mstrPLC_RETRY)


        '===================================
        ' 段ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSelectValue(cboPLC_DAN, mstrPLC_DAN)


        '===================================
        ' 行先ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboPLC_GOTOSetup(FDISP_ID_SKOTEI, Me.cboPLC_GOTO, True, mstrPLC_GOTO_VOL)




        '**********************************************************
        ' 子
        '**********************************************************

        '===================================
        ' ﾗﾍﾞﾙ(子)              ｾｯﾄ
        '===================================
        lblPLC_STNo_KO.Text = mstrPLC_STNO_KO                     'ST№(子)

        '===================================
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ(子)
        '===================================
        Call gobjComFuncFRM.InitRetuRenDan_TrkBufNo_ALL(FTRK_BUF_NO_J9000, cboPLC_RETU_KO, cboPLC_REN_KO, cboPLC_DAN_KO)

        '===================================
        ' ﾓｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Dim intINOUTMODE_KO As Integer = -1            '入出庫ﾓｰﾄﾞ(子)
        If mstrPLC_MODE_VOL1_KO = FLAG_ON And mstrPLC_MODE_VOL2_KO = FLAG_ON Then
            '(出庫ﾓｰﾄﾞのとき)
            intINOUTMODE_KO = INOUT_MODE_VOL_OUT_MODE

        ElseIf mstrPLC_MODE_VOL1_KO = FLAG_ON And mstrPLC_MODE_VOL2_KO = FLAG_OFF Then
            '(入庫ﾓｰﾄﾞのとき)
            intINOUTMODE_KO = INOUT_MODE_VOL_IN_MODE

        End If

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_MODE_KO, True, intINOUTMODE_KO)

        '===================================
        ' ﾍﾟｱｺﾝﾎﾞﾎﾞｯｸｽ(子)      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_PARE_KO, False, mstrPLC_PARE_VOL_KO)


        '===================================
        ' ﾌｫｰｸｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Dim intFork_KO As Integer = -1           'ﾌｫｰｸ(子)
        If mstrPLC_FORK_VOL1_KO = FLAG_ON And mstrPLC_FORK_VOL2_KO = FLAG_OFF Then
            '(子のとき)
            intFork_KO = FORK_VOL_KO

        ElseIf mstrPLC_FORK_VOL1_KO = FLAG_OFF And mstrPLC_FORK_VOL2_KO = FLAG_ON Then
            '(親のとき)
            intFork_KO = FORK_VOL_OYA

        End If

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_FORK_KO, True, intFork_KO)


        '===================================
        ' L/Sｺﾝﾎﾞﾎﾞｯｸｽ(子)      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_LS_KO, True, mstrPLC_LS_KO)


        '===================================
        ' Wﾘｰﾁｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_W_KO, False, mstrPLC_W_VOL_KO)


        '===================================
        ' 左右ｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Dim intSAYU_KO As Integer = -1

        If TO_INTEGER(mstrPLC_RETU_VOL_KO) = 0 Then
            '(Nullのとき)
            intSAYU_KO = -1
        ElseIf TO_INTEGER(mstrPLC_RETU_VOL_KO) Mod 2 = 0 Then
            '(偶数のとき)
            intSAYU_KO = RETU_VOL_LEFT
        Else
            '(奇数のとき)
            intSAYU_KO = RETU_VOL_RIGHT
        End If
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_SAYU_KO, True, intSAYU_KO)


        '===================================
        ' 号機ｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_GOUKI_KO, True, mstrPLC_GOUKI_KO)


        '===================================
        ' 連ｺﾝﾎﾞﾎﾞｯｸｽ(子)       ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSelectValue(cboPLC_REN_KO, mstrPLC_REN_KO)


        '===================================
        ' ENDｺﾝﾎﾞﾎﾞｯｸｽ(子)      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_END_KO, False, mstrPLC_END_KO)


        '===================================
        ' 再Fｺﾝﾎﾞﾎﾞｯｸｽ(子)      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboPLC_RETRY_KO, False, mstrPLC_RETRY_KO)


        '===================================
        ' 段ｺﾝﾎﾞﾎﾞｯｸｽ(子)       ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSelectValue(cboPLC_DAN_KO, mstrPLC_DAN_KO)


        '===================================
        ' 行先ｺﾝﾎﾞﾎﾞｯｸｽ(子)     ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboPLC_GOTOSetup(FDISP_ID_SKOTEI, Me.cboPLC_GOTO_KO, True, mstrPLC_GOTO_VOL_KO)



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
        cboPLC_MODE.Dispose()                           'ﾓｰﾄﾞ
        cboPLC_PARE.Dispose()                           'ﾍﾟｱ
        cboPLC_FORK.Dispose()                           'ﾌｫｰｸ
        cboPLC_LS.Dispose()                             'L/S
        cboPLC_W.Dispose()                              'Wﾘｰﾁ
        cboPLC_SAYU.Dispose()                           '左右
        cboPLC_GOUKI.Dispose()                          '号機
        cboPLC_REN.Dispose()                            '連
        cboPLC_END.Dispose()                            'END
        cboPLC_RETRY.Dispose()                          '再F
        cboPLC_DAN.Dispose()                            '段
        cboPLC_GOTO.Dispose()                           '行先

        cboPLC_RETU.Dispose()                           '列

        cboPLC_MODE_KO.Dispose()                        'ﾓｰﾄﾞ
        cboPLC_PARE_KO.Dispose()                        'ﾍﾟｱ
        cboPLC_FORK_KO.Dispose()                        'ﾌｫｰｸ
        cboPLC_LS_KO.Dispose()                          'L/S
        cboPLC_W_KO.Dispose()                           'Wﾘｰﾁ
        cboPLC_SAYU_KO.Dispose()                        '左右
        cboPLC_GOUKI_KO.Dispose()                       '号機
        cboPLC_REN_KO.Dispose()                         '連
        cboPLC_END_KO.Dispose()                         'END
        cboPLC_DAN_KO.Dispose()                         '段
        cboPLC_GOTO_KO.Dispose()                        '行先

        cboPLC_RETU_KO.Dispose()                        '列

    End Sub
#End Region
#Region "  送信         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 送信         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdSend_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Send_Click) = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "  ｸﾘｱ          ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｱ         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdClear_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Clear_Click) = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket02()


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
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        'Dim intRet As RetCode
        'Dim strMsg As String = ""


        Select Case udtCheck_Case
            Case menmCheckCase.Send_Click
                '(修正の場合)

                ''========================================
                ''ﾓｰﾄﾞ
                ''========================================
                'If cboPLC_MODE.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_01, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''ﾍﾟｱ
                ''========================================
                'If cboPLC_PARE.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_02, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''ﾌｫｰｸ
                ''========================================
                'If cboPLC_FORK.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_03, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''L/S
                ''========================================
                'If cboPLC_LS.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_04, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''Wﾘｰﾁ
                ''========================================
                'If cboPLC_W.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_05, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''左右
                ''========================================
                'If cboPLC_SAYU.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_06, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''号機
                ''========================================
                'If cboPLC_GOUKI.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_07, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''連
                ''========================================
                'If cboPLC_REN.SelectedIndex < 0 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_08, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''END
                ''========================================
                'If cboPLC_END.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_09, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''再F
                ''========================================
                'If cboPLC_RETRY.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_10, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''段
                ''========================================
                'If cboPLC_DAN.SelectedIndex < 0 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_11, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If

                ''========================================
                ''行先
                ''========================================
                'If cboPLC_GOTO.SelectedIndex < 1 Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307081_12, _
                '                     PopupFormType.Ok, _
                '                     PopupIconType.Information)
                '    Exit Select
                'End If


                blnCheckErr = False

            Case menmCheckCase.Clear_Click
                '(ｸﾘｱの場合)

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
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()

        Dim intRet As RetCode

        Dim strData01_02 As String = ""     'ﾃﾞｰﾀ01(02進数)
        Dim strData02_02 As String = ""     'ﾃﾞｰﾀ02(02進数)
        Dim strData03_02 As String = ""     'ﾃﾞｰﾀ03(02進数)

        Dim strData01_10 As String = ""     'ﾃﾞｰﾀ01(10進数)
        Dim strData02_10 As String = ""     'ﾃﾞｰﾀ02(10進数)
        Dim strData03_10 As String = ""     'ﾃﾞｰﾀ03(10進数)

        Dim strData04_02 As String = ""     'ﾃﾞｰﾀ04(02進数)
        Dim strData05_02 As String = ""     'ﾃﾞｰﾀ05(02進数)
        Dim strData06_02 As String = ""     'ﾃﾞｰﾀ06(02進数)

        Dim strData04_10 As String = ""     'ﾃﾞｰﾀ04(10進数)
        Dim strData05_10 As String = ""     'ﾃﾞｰﾀ05(10進数)
        Dim strData06_10 As String = ""     'ﾃﾞｰﾀ06(10進数)


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "送信" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If



        '*****************************************************
        '前準備
        '*****************************************************
        Dim strSendPLC_IN As String             '入庫ﾓｰﾄﾞ
        Dim strSendPLC_OUT As String            '出庫ﾓｰﾄﾞ
        Dim strSendPLC_PARE As String           'ﾍﾟｱ搬送
        Dim strSendPLC_FORK2 As String          'ﾌｫｰｸ2
        Dim strSendPLC_FORK1 As String          'ﾌｫｰｸ1
        Dim strSendPLC_LS As String             'L/S番号
        Dim strSendPLC_W As String              'Wﾘｰﾁ
        Dim strSendPLC_RETU As String           '列
        Dim strSendPLC_GOUKI As String          '号機
        Dim strSendPLC_REN As String            '連
        Dim strSendPLC_END As String            'ENDﾌﾗｸﾞ
        Dim strSendPLC_RETRY As String          '入棚再設定
        Dim strSendPLC_DAN As String            '段
        Dim strSendPLC_GOTO As String           '行先

        '----------------------------------
        ' 入庫ﾓｰﾄﾞ/出庫ﾓｰﾄﾞ
        '----------------------------------
        If cboPLC_MODE.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_IN = "0"
            strSendPLC_OUT = "0"
        ElseIf cboPLC_MODE.SelectedValue = TO_STRING(INOUT_MODE_VOL_IN_MODE) Then
            '(入庫のとき)
            strSendPLC_IN = "1"
            strSendPLC_OUT = "0"
        Else
            '(出庫のとき)
            strSendPLC_IN = "1"
            strSendPLC_OUT = "1"
        End If

        '----------------------------------
        ' ﾍﾟｱ搬送
        '----------------------------------
        strSendPLC_PARE = TO_STRING(cboPLC_PARE.SelectedValue)

        '----------------------------------
        ' ﾌｫｰｸ2/ﾌｫｰｸ1
        '----------------------------------
        If cboPLC_FORK.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_FORK2 = "0"
            strSendPLC_FORK1 = "0"
        ElseIf cboPLC_FORK.SelectedValue = TO_STRING(FORK_VOL_KO) Then
            '(子のとき)
            strSendPLC_FORK2 = "1"
            strSendPLC_FORK1 = "0"
        Else
            '(親のとき)
            strSendPLC_FORK2 = "0"
            strSendPLC_FORK1 = "1"
        End If

        '----------------------------------
        ' L/S番号
        '----------------------------------
        If cboPLC_LS.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_LS = "00"
        Else
            '(選択時)
            strSendPLC_LS = Change10To2(TO_STRING(cboPLC_LS.SelectedValue), 2)
        End If

        '----------------------------------
        ' Wﾘｰﾁ
        '----------------------------------
        strSendPLC_W = TO_STRING(cboPLC_W.SelectedValue)

        '----------------------------------
        ' 列
        '----------------------------------
        If cboPLC_SAYU.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_RETU = "00"
        ElseIf cboPLC_SAYU.SelectedValue = TO_STRING(RETU_VOL_LEFT) Then
            '(左のとき)
            strSendPLC_RETU = "10"
        Else
            '(右のとき)
            strSendPLC_RETU = "01"
        End If

        '----------------------------------
        ' 号機
        '----------------------------------
        If cboPLC_GOUKI.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_GOUKI = "0000"
        Else
            '(選択時)
            strSendPLC_GOUKI = Change10To2(TO_STRING(cboPLC_GOUKI.SelectedValue), 4)
        End If

        '----------------------------------
        ' 連
        '----------------------------------
        If cboPLC_GOUKI.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_REN = "000000"
        Else
            '(選択時)
            strSendPLC_REN = Change10To2(TO_STRING(cboPLC_REN.SelectedValue), 6)
        End If

        '----------------------------------
        ' END
        '----------------------------------
        strSendPLC_END = TO_STRING(cboPLC_END.SelectedValue)

        '----------------------------------
        ' 入棚再設定
        '----------------------------------
        strSendPLC_RETRY = TO_STRING(cboPLC_RETRY.SelectedValue)

        '----------------------------------
        ' 段
        '----------------------------------
        If cboPLC_DAN.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_DAN = "0000"
        Else
            '(選択時)
            strSendPLC_DAN = Change10To2(TO_STRING(cboPLC_DAN.SelectedValue), 4)
        End If

        '----------------------------------
        ' 行先
        '----------------------------------
        If cboPLC_GOTO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_GOTO = "0000000000000000"
        Else
            '(選択時)
            strSendPLC_GOTO = Change10To2(IIf(IsNull(TO_STRING(cboPLC_GOTO.SelectedValue)), 0, TO_STRING(cboPLC_GOTO.SelectedValue)), 16)
        End If


        '*****************************************************
        'ﾃﾞｰﾀ               作成
        '*****************************************************
        'ﾃﾞｰﾀ01(02進数)
        strData01_02 &= "0"                         '固定
        strData01_02 &= strSendPLC_IN               '入庫ﾓｰﾄﾞ
        strData01_02 &= strSendPLC_OUT              '出庫ﾓｰﾄﾞ
        strData01_02 &= strSendPLC_PARE             'ﾍﾟｱ搬送
        strData01_02 &= strSendPLC_FORK2            'ﾌｫｰｸ2
        strData01_02 &= strSendPLC_FORK1            'ﾌｫｰｸ1
        strData01_02 &= strSendPLC_LS               'L/S番号
        strData01_02 &= "0"                         '固定
        strData01_02 &= strSendPLC_W                'Wﾘｰﾁ
        strData01_02 &= strSendPLC_RETU             '列
        strData01_02 &= strSendPLC_GOUKI            '号機
        'ﾃﾞｰﾀ02(02進数)
        strData02_02 &= "00"                        '固定
        strData02_02 &= strSendPLC_REN              '連
        strData02_02 &= strSendPLC_END              'ENDﾌﾗｸﾞ
        strData02_02 &= strSendPLC_RETRY            '入棚再設定
        strData02_02 &= "00"                        '固定
        strData02_02 &= strSendPLC_DAN              '段
        'ﾃﾞｰﾀ03(02進数)
        strData03_02 &= strSendPLC_GOTO             '行先



        '*****************************************************
        'ﾁｪｯｸ
        '*****************************************************
        If strData01_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ01(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData02_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ02(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData03_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ03(02進)が16桁じゃないのでｴﾗｰとします。")


        '*****************************************************
        '10進数に変換
        '*****************************************************
        strData01_10 = Change2To10(strData01_02)    'ﾃﾞｰﾀ01(10進数)
        strData02_10 = Change2To10(strData02_02)    'ﾃﾞｰﾀ02(10進数)
        strData03_10 = Change2To10(strData03_02)    'ﾃﾞｰﾀ03(10進数)





        '*****************************************************
        '前準備(子)
        '*****************************************************
        Dim strSendPLC_IN_KO As String             '入庫ﾓｰﾄﾞ
        Dim strSendPLC_OUT_KO As String            '出庫ﾓｰﾄﾞ
        Dim strSendPLC_PARE_KO As String           'ﾍﾟｱ搬送
        Dim strSendPLC_FORK2_KO As String          'ﾌｫｰｸ2
        Dim strSendPLC_FORK1_KO As String          'ﾌｫｰｸ1
        Dim strSendPLC_LS_KO As String             'L/S番号
        Dim strSendPLC_W_KO As String              'Wﾘｰﾁ
        Dim strSendPLC_RETU_KO As String           '列
        Dim strSendPLC_GOUKI_KO As String          '号機
        Dim strSendPLC_REN_KO As String            '連
        Dim strSendPLC_END_KO As String            'ENDﾌﾗｸﾞ
        Dim strSendPLC_RETRY_KO As String          '入棚再設定
        Dim strSendPLC_DAN_KO As String            '段
        Dim strSendPLC_GOTO_KO As String           '行先

        '----------------------------------
        ' 入庫ﾓｰﾄﾞ/出庫ﾓｰﾄﾞ
        '----------------------------------
        If cboPLC_MODE_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_IN_KO = "0"
            strSendPLC_OUT_KO = "0"
        ElseIf cboPLC_MODE_KO.SelectedValue = TO_STRING(INOUT_MODE_VOL_IN_MODE) Then
            '(入庫のとき)
            strSendPLC_IN_KO = "1"
            strSendPLC_OUT_KO = "0"
        Else
            '(出庫のとき)
            strSendPLC_IN_KO = "1"
            strSendPLC_OUT_KO = "1"
        End If

        '----------------------------------
        ' ﾍﾟｱ搬送
        '----------------------------------
        strSendPLC_PARE_KO = TO_STRING(cboPLC_PARE_KO.SelectedValue)

        '----------------------------------
        ' ﾌｫｰｸ2/ﾌｫｰｸ1
        '----------------------------------
        If cboPLC_FORK_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_FORK2_KO = "0"
            strSendPLC_FORK1_KO = "0"
        ElseIf cboPLC_FORK_KO.SelectedValue = TO_STRING(FORK_VOL_KO) Then
            '(子のとき)
            strSendPLC_FORK2_KO = "1"
            strSendPLC_FORK1_KO = "0"
        Else
            '(親のとき)
            strSendPLC_FORK2_KO = "0"
            strSendPLC_FORK1_KO = "1"
        End If

        '----------------------------------
        ' L/S番号
        '----------------------------------
        If cboPLC_LS_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_LS_KO = "00"
        Else
            '(選択時)
            strSendPLC_LS_KO = Change10To2(TO_STRING(cboPLC_LS_KO.SelectedValue), 2)
        End If

        '----------------------------------
        ' Wﾘｰﾁ
        '----------------------------------
        strSendPLC_W_KO = TO_STRING(cboPLC_W_KO.SelectedValue)

        '----------------------------------
        ' 列
        '----------------------------------
        If cboPLC_SAYU_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_RETU_KO = "00"
        ElseIf cboPLC_SAYU_KO.SelectedValue = TO_STRING(RETU_VOL_LEFT) Then
            '(左のとき)
            strSendPLC_RETU_KO = "10"
        Else
            '(右のとき)
            strSendPLC_RETU_KO = "01"
        End If

        '----------------------------------
        ' 号機
        '----------------------------------
        If cboPLC_GOUKI_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_GOUKI_KO = "0000"
        Else
            '(選択時)
            strSendPLC_GOUKI_KO = Change10To2(TO_STRING(cboPLC_GOUKI_KO.SelectedValue), 4)
        End If

        '----------------------------------
        ' 連
        '----------------------------------
        If cboPLC_GOUKI_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_REN_KO = "000000"
        Else
            '(選択時)
            strSendPLC_REN_KO = Change10To2(TO_STRING(cboPLC_REN_KO.SelectedValue), 6)
        End If

        '----------------------------------
        ' END
        '----------------------------------
        strSendPLC_END_KO = TO_STRING(cboPLC_END_KO.SelectedValue)

        '----------------------------------
        ' 入棚再設定
        '----------------------------------
        strSendPLC_RETRY_KO = TO_STRING(cboPLC_RETRY_KO.SelectedValue)

        '----------------------------------
        ' 段
        '----------------------------------
        If cboPLC_DAN_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_DAN_KO = "0000"
        Else
            '(選択時)
            strSendPLC_DAN_KO = Change10To2(TO_STRING(cboPLC_DAN_KO.SelectedValue), 4)
        End If

        '----------------------------------
        ' 行先
        '----------------------------------
        If cboPLC_GOTO_KO.SelectedIndex <= 0 Then
            '(未選択のとき)
            strSendPLC_GOTO_KO = "0000000000000000"
        Else
            '(選択時)
            strSendPLC_GOTO_KO = Change10To2(IIf(IsNull(TO_STRING(cboPLC_GOTO_KO.SelectedValue)), 0, TO_STRING(cboPLC_GOTO_KO.SelectedValue)), 16)
        End If


        '*****************************************************
        'ﾃﾞｰﾀ               作成
        '*****************************************************
        'ﾃﾞｰﾀ04(02進数)
        strData04_02 &= "0"                         '固定
        strData04_02 &= strSendPLC_IN_KO            '入庫ﾓｰﾄﾞ
        strData04_02 &= strSendPLC_OUT_KO           '出庫ﾓｰﾄﾞ
        strData04_02 &= strSendPLC_PARE_KO          'ﾍﾟｱ搬送
        strData04_02 &= strSendPLC_FORK2_KO         'ﾌｫｰｸ2
        strData04_02 &= strSendPLC_FORK1_KO         'ﾌｫｰｸ1
        strData04_02 &= strSendPLC_LS_KO            'L/S番号
        strData04_02 &= "0"                         '固定
        strData04_02 &= strSendPLC_W_KO             'Wﾘｰﾁ
        strData04_02 &= strSendPLC_RETU_KO          '列
        strData04_02 &= strSendPLC_GOUKI_KO         '号機
        'ﾃﾞｰﾀ02(02進数)
        strData05_02 &= "00"                        '固定
        strData05_02 &= strSendPLC_REN_KO           '連
        strData05_02 &= strSendPLC_END_KO           'ENDﾌﾗｸﾞ
        strData05_02 &= strSendPLC_RETRY_KO         '入棚再設定
        strData05_02 &= "00"                        '固定
        strData05_02 &= strSendPLC_DAN_KO           '段
        'ﾃﾞｰﾀ03(02進数)
        strData06_02 &= strSendPLC_GOTO_KO          '行先



        '*****************************************************
        'ﾁｪｯｸ
        '*****************************************************
        If strData04_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ04(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData05_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ05(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData06_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ06(02進)が16桁じゃないのでｴﾗｰとします。")


        '*****************************************************
        '10進数に変換
        '*****************************************************
        strData04_10 = Change2To10(strData04_02)    'ﾃﾞｰﾀ04(10進数)
        strData05_10 = Change2To10(strData05_02)    'ﾃﾞｰﾀ05(10進数)
        strData06_10 = Change2To10(strData06_02)    'ﾃﾞｰﾀ06(10進数)


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strXEQ_ID_ENUM As String = ""                   '設備ID列挙
        Dim strXSEND_DATA As String = ""                    '送信ﾃﾞｰﾀ

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400701                      'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        '********************************************************************
        ' ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ取得
        '********************************************************************
        Dim objXDSP_PLC_MAINTE As TBL_XDSP_PLC_MAINTE                                       'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ
        objXDSP_PLC_MAINTE = New TBL_XDSP_PLC_MAINTE(gobjOwner, gobjDb, Nothing)
        objXDSP_PLC_MAINTE.XMAINTE_NAME = mstrPLC_STNO                                      'ﾒﾝﾃﾅﾝｽ表示名
        objXDSP_PLC_MAINTE.XMAINTE_KUBUN = mstrXMAINTE_KUBUN                                'ﾒﾝﾃﾅﾝｽ区分
        intRet = objXDSP_PLC_MAINTE.GET_XDSP_PLC_MAINTE()

        Dim objXDSP_PLC_MAINTE_KO As TBL_XDSP_PLC_MAINTE                                    'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ(子)
        objXDSP_PLC_MAINTE_KO = New TBL_XDSP_PLC_MAINTE(gobjOwner, gobjDb, Nothing)
        objXDSP_PLC_MAINTE_KO.XMAINTE_NAME = mstrPLC_STNO_KO                                'ﾒﾝﾃﾅﾝｽ表示名(子)
        objXDSP_PLC_MAINTE_KO.XMAINTE_KUBUN = mstrXMAINTE_KUBUN                             'ﾒﾝﾃﾅﾝｽ区分(子)
        intRet = objXDSP_PLC_MAINTE_KO.GET_XDSP_PLC_MAINTE()

        Dim strXEQ_ID() As String
        Dim strXEQ_ID_KO() As String

        strXEQ_ID = (objXDSP_PLC_MAINTE.XEQ_ID_MAINTE).Split(KUGIRI01)
        strXEQ_ID_KO = (objXDSP_PLC_MAINTE_KO.XEQ_ID_MAINTE).Split(KUGIRI01)

        '前後の並びを逆転
        strXEQ_ID_ENUM = TO_STRING(strXEQ_ID_KO(0) & "," & strXEQ_ID_KO(1) & "," & strXEQ_ID_KO(2) & "," & strXEQ_ID(0) & "," & strXEQ_ID(1) & "," & strXEQ_ID(2))      '設備ID列挙
        strXSEND_DATA = strData04_10 & "," & strData05_10 & "," & strData06_10 & "," & strData01_10 & "," & strData02_10 & "," & strData03_10

        objTelegram.SETIN_DATA("XDSPEQ_ID_ENUM", strXEQ_ID_ENUM)                            '設備ID列挙
        objTelegram.SETIN_DATA("XDSPTEXT_ID", FTEXT_ID_JW_MAINTE_INOUT)                     'ﾃｷｽﾄID
        objTelegram.SETIN_DATA("XDSPSEND_DATA", strXSEND_DATA)                              '送信ﾃﾞｰﾀ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                   'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = "送信" & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            End If
        End If






    End Sub
#End Region
#Region "  ｿｹｯﾄ送信02                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket02()

        Dim intRet As RetCode

        Dim strData01_02 As String = ""     'ﾃﾞｰﾀ01(02進数)
        Dim strData02_02 As String = ""     'ﾃﾞｰﾀ02(02進数)
        Dim strData03_02 As String = ""     'ﾃﾞｰﾀ03(02進数)

        Dim strData01_10 As String = ""     'ﾃﾞｰﾀ01(10進数)
        Dim strData02_10 As String = ""     'ﾃﾞｰﾀ02(10進数)
        Dim strData03_10 As String = ""     'ﾃﾞｰﾀ03(10進数)

        Dim strData04_02 As String = ""     'ﾃﾞｰﾀ04(02進数)
        Dim strData05_02 As String = ""     'ﾃﾞｰﾀ05(02進数)
        Dim strData06_02 As String = ""     'ﾃﾞｰﾀ06(02進数)

        Dim strData04_10 As String = ""     'ﾃﾞｰﾀ04(10進数)
        Dim strData05_10 As String = ""     'ﾃﾞｰﾀ05(10進数)
        Dim strData06_10 As String = ""     'ﾃﾞｰﾀ06(10進数)


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "クリア" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*****************************************************
        'ﾃﾞｰﾀ               作成
        '*****************************************************
        'ﾃﾞｰﾀ01(02進数)
        strData01_02 &= "0000000000000000"                      '固定
        'ﾃﾞｰﾀ02(02進数)
        strData02_02 &= "0000000000000000"                      '固定
        'ﾃﾞｰﾀ03(02進数)
        strData03_02 &= "0000000000000000"                      '固定
        'ﾃﾞｰﾀ04(02進数)
        strData04_02 &= "0000000000000000"                      '固定
        'ﾃﾞｰﾀ05(02進数)
        strData05_02 &= "0000000000000000"                      '固定
        'ﾃﾞｰﾀ06(02進数)
        strData06_02 &= "0000000000000000"                      '固定


        '*****************************************************
        'ﾁｪｯｸ
        '*****************************************************
        If strData01_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ01(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData02_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ02(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData03_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ03(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData04_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ04(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData05_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ05(02進)が16桁じゃないのでｴﾗｰとします。")
        If strData06_02.Length <> 16 Then Throw New Exception("ﾃﾞｰﾀ06(02進)が16桁じゃないのでｴﾗｰとします。")


        '*****************************************************
        '10進数に変換
        '*****************************************************
        strData01_10 = Change2To10(strData01_02)    'ﾃﾞｰﾀ01(10進数)
        strData02_10 = Change2To10(strData02_02)    'ﾃﾞｰﾀ02(10進数)
        strData03_10 = Change2To10(strData03_02)    'ﾃﾞｰﾀ03(10進数)
        strData04_10 = Change2To10(strData04_02)    'ﾃﾞｰﾀ04(10進数)
        strData05_10 = Change2To10(strData05_02)    'ﾃﾞｰﾀ05(10進数)
        strData06_10 = Change2To10(strData06_02)    'ﾃﾞｰﾀ06(10進数)


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strXEQ_ID_ENUM As String = ""                   '設備ID列挙
        Dim strXSEND_DATA As String = ""                    '送信ﾃﾞｰﾀ

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400701                      'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        '********************************************************************
        ' ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ取得
        '********************************************************************
        Dim objXDSP_PLC_MAINTE As TBL_XDSP_PLC_MAINTE                                       'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ
        objXDSP_PLC_MAINTE = New TBL_XDSP_PLC_MAINTE(gobjOwner, gobjDb, Nothing)
        objXDSP_PLC_MAINTE.XMAINTE_NAME = mstrPLC_STNO                                      'ﾒﾝﾃﾅﾝｽ表示名
        objXDSP_PLC_MAINTE.XMAINTE_KUBUN = mstrXMAINTE_KUBUN                                'ﾒﾝﾃﾅﾝｽ区分
        intRet = objXDSP_PLC_MAINTE.GET_XDSP_PLC_MAINTE()

        Dim objXDSP_PLC_MAINTE_KO As TBL_XDSP_PLC_MAINTE                                    'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ(子)
        objXDSP_PLC_MAINTE_KO = New TBL_XDSP_PLC_MAINTE(gobjOwner, gobjDb, Nothing)
        objXDSP_PLC_MAINTE_KO.XMAINTE_NAME = mstrPLC_STNO_KO                                'ﾒﾝﾃﾅﾝｽ表示名(子)
        objXDSP_PLC_MAINTE_KO.XMAINTE_KUBUN = mstrXMAINTE_KUBUN                             'ﾒﾝﾃﾅﾝｽ区分(子)
        intRet = objXDSP_PLC_MAINTE_KO.GET_XDSP_PLC_MAINTE()

        Dim strXEQ_ID() As String
        Dim strXEQ_ID_KO() As String

        strXEQ_ID = (objXDSP_PLC_MAINTE.XEQ_ID_MAINTE).Split(KUGIRI01)
        strXEQ_ID_KO = (objXDSP_PLC_MAINTE_KO.XEQ_ID_MAINTE).Split(KUGIRI01)

        '前後の並びを逆転
        strXEQ_ID_ENUM = TO_STRING(strXEQ_ID_KO(0) & "," & strXEQ_ID_KO(1) & "," & strXEQ_ID_KO(2) & "," & strXEQ_ID(0) & "," & strXEQ_ID(1) & "," & strXEQ_ID(2))      '設備ID列挙
        strXSEND_DATA = strData04_10 & "," & strData05_10 & "," & strData06_10 & "," & strData01_10 & "," & strData02_10 & "," & strData03_10                           '送信ﾃﾞｰﾀ

        objTelegram.SETIN_DATA("XDSPEQ_ID_ENUM", strXEQ_ID_ENUM)                        '設備ID列挙
        objTelegram.SETIN_DATA("XDSPTEXT_ID", FTEXT_ID_JW_MAINTE_INOUT)                 'ﾃｷｽﾄID
        objTelegram.SETIN_DATA("XDSPSEND_DATA", strXSEND_DATA)                          '送信ﾃﾞｰﾀ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                   'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = "クリア" & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()

            End If
        End If

    End Sub
#End Region

End Class
