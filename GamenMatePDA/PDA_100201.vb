'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾊﾞｰｺｰﾄﾞｴﾗｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_100201

#Region "  共通変数　                               "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXCAR_NO As String               '車番
    Private mstrXCAR_NO_EDA As String           '枝番
    Private mstrFHINMEI_CD As String            '品名ｺｰﾄﾞ
    Private mstrXSEIZOU_DT As String            '製造年月日
    Private mstrXLINE_NO As String              'ﾗｲﾝ№
    Private mstrXPALLET_NO As String            'ﾊﾟﾚｯﾄ№
    Private mstrXSYUKKA_KENPIN_VOL As String    '積数
    Private mstrBCData As String                'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
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

    ''' ======================================
    ''' <summary>品名ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>製造年月日</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXSEIZOU_DT() As String
        Get
            Return mstrXSEIZOU_DT
        End Get
        Set(ByVal value As String)
            mstrXSEIZOU_DT = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾗｲﾝ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXLINE_NO() As String
        Get
            Return mstrXLINE_NO
        End Get
        Set(ByVal value As String)
            mstrXLINE_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾟﾚｯﾄ№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXPALLET_NO() As String
        Get
            Return mstrXPALLET_NO
        End Get
        Set(ByVal value As String)
            mstrXPALLET_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>積み数</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXSYUKA_KENPIN_VOL() As String
        Get
            Return mstrXSYUKKA_KENPIN_VOL
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_KENPIN_VOL = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userBCData() As String
        Get
            Return mstrBCData
        End Get
        Set(ByVal value As String)
            mstrBCData = value
        End Set
    End Property
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PDA_100201_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "　確認ﾎﾞﾀﾝ押下                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 確認ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncPDA.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmLoad()

        Dim intRet As RetCode

        '*******************************************************
        ' 初期設定
        '*******************************************************
        lblXCAR_NO.Text = mstrXCAR_NO               '車番
        lblXCAR_NO_EDA.Text = mstrXCAR_NO_EDA       '枝番
        lblFHINEMI_CD.Text = mstrFHINMEI_CD         '品目ｺｰﾄﾞ

        lblFHINMEI.Text = ""                        '品名
        Dim objTMST_ITEM As TBL_TMST_ITEM                             '品目ﾏｽﾀｰ
        objTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        objTMST_ITEM.FHINMEI_CD = mstrFHINMEI_CD                      '品名ｺｰﾄﾞ
        intRet = objTMST_ITEM.GET_TMST_ITEM(False)
        If intRet = RetCode.OK Then
            '(読めた時)
            lblFHINMEI.Text = TO_STRING(objTMST_ITEM.FHINMEI)         '品名
        End If

        lblXSEIZOU_DT.Text = mstrXSEIZOU_DT         '製造年月日
        lblXLINE_NO.Text = mstrXLINE_NO             'ﾗｲﾝ№
        lblXPALLET_NO.Text = mstrXPALLET_NO         'ﾊﾟﾚｯﾄ№
        lblFTR_VOL.Text = mstrXSYUKKA_KENPIN_VOL    '積み数
        lblXBC_DATA.Text = mstrBCData               'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ


    End Sub
#End Region
#Region "  確認         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 確認 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        Me.Close()


    End Sub
#End Region

End Class
