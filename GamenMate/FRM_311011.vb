'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷指示問合せ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311011

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mintButtonMode As Integer                 'ﾎﾞﾀﾝﾓｰﾄﾞ
    Protected mstrXSYUKKA_D As String                   '出荷日
    Protected mstrXHENSEI_NO As String                  '編成№
    Protected mstrXDENPYOU_NO As String                 '伝票№

    Protected mstrXEDIT_KBN As String                   '編集区分
    Protected mstrXINPUT_PLACE As String                'ｲﾝﾌﾟｯﾄ場所
    Protected mstrXINPUT_DT As String                   'ｲﾝﾌﾟｯﾄ日付
    Protected mstrXINPUT_NO As String                   'ｲﾝﾌﾟｯﾄNo.
    Protected mstrXDATA_DT As String                    'ﾃﾞｰﾀ日付
    Protected mstrXSOUKO_CD As String                   '倉庫ｺｰﾄﾞ
    Protected mstrXTOU_NO As String                     '棟ｺｰﾄﾞ
    Protected mstrXTORIHIKI_KBN As String               '取引区分
    Protected mstrXDATA_SYORI As String                 'ﾃﾞｰﾀ処理
    Protected mstrXSYASYU_KBN As String                 '車種区分
    Protected mstrXUNKOU_NO As String                   '倉庫別運行No.

    Protected mstrFHINMEI_CD1 As String                 '品名ｺｰﾄﾞ1
    Protected mstrXSYUKKA_NUM1 As String                '出荷数1
    Protected mstrXSAIMOKU1 As String                   '取引区分細目1
    Protected mstrZAIKO_KUBUN1 As String                '在庫区分1
    Protected mstrXIDOU_KBN1 As String                  '移動区分1
    Protected mstrFHINMEI_CD2 As String                 '品名ｺｰﾄﾞ2
    Protected mstrXSYUKKA_NUM2 As String                '出荷数2
    Protected mstrXSAIMOKU2 As String                   '取引区分細目2
    Protected mstrZAIKO_KUBUN2 As String                '在庫区分2
    Protected mstrXIDOU_KBN2 As String                  '移動区分2
    Protected mstrFHINMEI_CD3 As String                 '品名ｺｰﾄﾞ3
    Protected mstrXSYUKKA_NUM3 As String                '出荷数3
    Protected mstrXSAIMOKU3 As String                   '取引区分細目3
    Protected mstrZAIKO_KUBUN3 As String                '在庫区分3
    Protected mstrXIDOU_KBN3 As String                  '移動区分3
    Protected mstrFHINMEI_CD4 As String                 '品名ｺｰﾄﾞ4
    Protected mstrXSYUKKA_NUM4 As String                '出荷数4
    Protected mstrXSAIMOKU4 As String                   '取引区分細目4
    Protected mstrZAIKO_KUBUN4 As String                '在庫区分4
    Protected mstrXIDOU_KBN4 As String                  '移動区分4
    Protected mstrFHINMEI_CD5 As String                 '品名ｺｰﾄﾞ5
    Protected mstrXSYUKKA_NUM5 As String                '出荷数5
    Protected mstrXSAIMOKU5 As String                   '取引区分細目5
    Protected mstrZAIKO_KUBUN5 As String                '在庫区分5
    Protected mstrXIDOU_KBN5 As String                  '移動区分5
    Protected mstrFHINMEI_CD6 As String                 '品名ｺｰﾄﾞ6
    Protected mstrXSYUKKA_NUM6 As String                '出荷数6
    Protected mstrXSAIMOKU6 As String                   '取引区分細目6
    Protected mstrZAIKO_KUBUN6 As String                '在庫区分6
    Protected mstrXIDOU_KBN6 As String                  '移動区分6
    Protected mstrFHINMEI_CD7 As String                 '品名ｺｰﾄﾞ7
    Protected mstrXSYUKKA_NUM7 As String                '出荷数7
    Protected mstrXSAIMOKU7 As String                   '取引区分細目7
    Protected mstrZAIKO_KUBUN7 As String                '在庫区分7
    Protected mstrXIDOU_KBN7 As String                  '移動区分7
    Protected mstrFHINMEI_CD8 As String                 '品名ｺｰﾄﾞ8
    Protected mstrXSYUKKA_NUM8 As String                '出荷数8
    Protected mstrXSAIMOKU8 As String                   '取引区分細目8
    Protected mstrZAIKO_KUBUN8 As String                '在庫区分8
    Protected mstrXIDOU_KBN8 As String                  '移動区分8

    'ﾃｰﾌﾞﾙｸﾗｽ
    Dim mobjXPLN_OUT As TBL_XPLN_OUT            '出荷指示
    Dim mobjXPLN_OUT_DTL As TBL_XPLN_OUT_DTL    '出荷指示詳細


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾎﾞﾀﾝﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
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
    ''' <summary>品名ｺｰﾄﾞ1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD1() As String
        Get
            Return mstrFHINMEI_CD1
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM1() As String
        Get
            Return mstrXSYUKKA_NUM1
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU1() As String
        Get
            Return mstrXSAIMOKU1
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN1() As String
        Get
            Return mstrZAIKO_KUBUN1
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分1</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN1() As String
        Get
            Return mstrXIDOU_KBN1
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN1 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD2() As String
        Get
            Return mstrFHINMEI_CD2
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM2() As String
        Get
            Return mstrXSYUKKA_NUM2
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU2() As String
        Get
            Return mstrXSAIMOKU2
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN2() As String
        Get
            Return mstrZAIKO_KUBUN2
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分2</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN2() As String
        Get
            Return mstrXIDOU_KBN2
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN2 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ3</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD3() As String
        Get
            Return mstrFHINMEI_CD3
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD3 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数3</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM3() As String
        Get
            Return mstrXSYUKKA_NUM3
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM3 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目3</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU3() As String
        Get
            Return mstrXSAIMOKU3
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU3 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分3</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN3() As String
        Get
            Return mstrZAIKO_KUBUN3
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN3 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分3</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN3() As String
        Get
            Return mstrXIDOU_KBN3
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN3 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ4</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD4() As String
        Get
            Return mstrFHINMEI_CD4
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD4 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数4</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM4() As String
        Get
            Return mstrXSYUKKA_NUM4
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM4 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目4</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU4() As String
        Get
            Return mstrXSAIMOKU4
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU4 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分4</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN4() As String
        Get
            Return mstrZAIKO_KUBUN4
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN4 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分4</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN4() As String
        Get
            Return mstrXIDOU_KBN4
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN4 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ5</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD5() As String
        Get
            Return mstrFHINMEI_CD5
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD5 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数5</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM5() As String
        Get
            Return mstrXSYUKKA_NUM5
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM5 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目5</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU5() As String
        Get
            Return mstrXSAIMOKU5
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU5 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分5</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN5() As String
        Get
            Return mstrZAIKO_KUBUN5
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN5 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分5</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN5() As String
        Get
            Return mstrXIDOU_KBN5
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN5 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ6</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD6() As String
        Get
            Return mstrFHINMEI_CD6
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD6 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数6</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM6() As String
        Get
            Return mstrXSYUKKA_NUM6
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM6 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目6</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU6() As String
        Get
            Return mstrXSAIMOKU6
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU6 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分6</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN6() As String
        Get
            Return mstrZAIKO_KUBUN6
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN6 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分6</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN6() As String
        Get
            Return mstrXIDOU_KBN6
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN6 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ7</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD7() As String
        Get
            Return mstrFHINMEI_CD7
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD7 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数7</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM7() As String
        Get
            Return mstrXSYUKKA_NUM7
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM7 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目7</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU7() As String
        Get
            Return mstrXSAIMOKU7
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU7 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分7</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN7() As String
        Get
            Return mstrZAIKO_KUBUN7
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN7 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分7</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN7() As String
        Get
            Return mstrXIDOU_KBN7
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN7 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>品名ｺｰﾄﾞ8</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFHINMEI_CD8() As String
        Get
            Return mstrFHINMEI_CD8
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD8 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>出荷数8</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSYUKKA_NUM8() As String
        Get
            Return mstrXSYUKKA_NUM8
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NUM8 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>取引区分細目8</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXSAIMOKU8() As String
        Get
            Return mstrXSAIMOKU8
        End Get
        Set(ByVal value As String)
            mstrXSAIMOKU8 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>在庫区分8</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userZAIKO_KUBUN8() As String
        Get
            Return mstrZAIKO_KUBUN8
        End Get
        Set(ByVal value As String)
            mstrZAIKO_KUBUN8 = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>移動区分8</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userXIDOU_KBN8() As String
        Get
            Return mstrXIDOU_KBN8
        End Get
        Set(ByVal value As String)
            mstrXIDOU_KBN8 = value
        End Set
    End Property

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_311011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_311011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


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
        ' 出荷指示の特定
        '**********************************************************
        mobjXPLN_OUT = New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
        If IsNull(mstrXSYUKKA_D) = False Then
            '(出荷日がある場合）
            mobjXPLN_OUT.XSYUKKA_D = Format(TO_DATE(mstrXSYUKKA_D), "yyyy/MM/dd")   '出荷日
            mobjXPLN_OUT.XHENSEI_NO = mstrXHENSEI_NO                                '編成№
            mobjXPLN_OUT.XDENPYOU_NO = mstrXDENPYOU_NO                              '伝票№
            mobjXPLN_OUT.GET_XPLN_OUT(False)
        End If


        '**********************************************************
        ' 実行ﾎﾞﾀﾝ                  ｾｯﾄ
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                cmdZikkou.Text = "追加"
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                cmdZikkou.Text = "変更"
            Case BUTTONMODE_DELETE
                '(削除の場合)
                cmdZikkou.Text = "削除"
        End Select


        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        '出荷日                ｾｯﾄ
        '===================================
        If IsNull(mobjXPLN_OUT.XSYUKKA_D) = True Then
            '(値がない場合)
            cboXSYUKKA_D.cmpMDateTimePicker_D.Value = Now                           '出荷日
        Else
            '(値がある場合)
            cboXSYUKKA_D.cmpMDateTimePicker_D.Value = mobjXPLN_OUT.XSYUKKA_D        '出荷日
        End If

        '===================================
        ' 車両No.ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call MakeXSYARYOU_NO_cbo(cboXSYARYOU_NO)
        ''Call gobjComFuncFRM.cboMsterSetup("XMST_SYARYOU", "XSYARYOU_NO", "XSYARYOU_NO", "XSYARYOU_NO", cboXSYARYOU_NO)

        '===================================
        ' 積込方法ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUHOU, True, mobjXPLN_OUT.XTUMI_HOUHOU)

        '===================================
        ' 業者ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_GYOUSYA", "XGYOUSYA_CD", "XGYOUSYA_RYAKU", "XGYOUSYA_CD", cboXGYOUSYA_CD, False, mobjXPLN_OUT.XGYOUSYA_CD)
        'Call MakeXGYOUSYA_CD_cbo(cboXGYOUSYA_CD)

        '===================================
        ' 積込方向ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXTUMI_HOUKOU, True, mobjXPLN_OUT.XTUMI_HOUKOU)

        '===================================
        ' ﾊﾞｰｽ指定ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call MakeXBerth_NO_cbo(cboXBERTH_NO)
        'Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, Me.cboXBERTH_NO, True, mobjXPLN_OUT.XBERTH_NO)


        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        'txtXSYARYOU_NO.Text = TO_STRING(mobjXPLN_OUT.XSYARYOU_NO)               '車輌№
        txtXHENSEI_NO.Text = TO_STRING(mobjXPLN_OUT.XHENSEI_NO)                 '編成№
        txtXHENSEI_NO_OYA.Text = TO_STRING(mobjXPLN_OUT.XHENSEI_NO_OYA)         '親編成№
        txtXDENPYOU_NO.Text = TO_STRING(mobjXPLN_OUT.XDENPYOU_NO)               '伝票№
        'txtXGYOUSYA_CD.Text = TO_STRING(mobjXPLN_OUT.XGYOUSYA_CD)               '業者ｺｰﾄﾞ
        txtXBUNRUI_NO.Text = TO_STRING(mobjXPLN_OUT.XBUNRUI_NO)                 '分類№
        txtXSEND_NAME.Text = TO_STRING(mobjXPLN_OUT.XSEND_NAME)                 '届け先
        txtXSEND_ADDRESS.Text = TO_STRING(mobjXPLN_OUT.XSEND_ADDRESS)           '住所



        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ関係                 ｾｯﾄ
        '**********************************************************
        '===================================
        ' 品名ｺｰﾄﾞ01ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD01.conn = gobjDb
        cboFHINMEI_CD01.HinmeiLabel = lblFHINMEI01
        cboFHINMEI_CD01.Text = mstrFHINMEI_CD1
        cboFHINMEI_CD01.HinmeiVisible = False
        cboFHINMEI_CD01.cboSetupHinmeiCd(cboFHINMEI_CD01.Text)

        '===================================
        ' 品名ｺｰﾄﾞ02ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD02.conn = gobjDb
        cboFHINMEI_CD02.HinmeiLabel = lblFHINMEI02
        cboFHINMEI_CD02.Text = mstrFHINMEI_CD2
        cboFHINMEI_CD02.HinmeiVisible = False
        cboFHINMEI_CD02.cboSetupHinmeiCd(cboFHINMEI_CD02.Text)

        '===================================
        ' 品名ｺｰﾄﾞ03ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD03.conn = gobjDb
        cboFHINMEI_CD03.HinmeiLabel = lblFHINMEI03
        cboFHINMEI_CD03.Text = mstrFHINMEI_CD3
        cboFHINMEI_CD03.HinmeiVisible = False
        cboFHINMEI_CD03.cboSetupHinmeiCd(cboFHINMEI_CD03.Text)

        '===================================
        ' 品名ｺｰﾄﾞ04ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD04.conn = gobjDb
        cboFHINMEI_CD04.HinmeiLabel = lblFHINMEI04
        cboFHINMEI_CD04.Text = mstrFHINMEI_CD4
        cboFHINMEI_CD04.HinmeiVisible = False
        cboFHINMEI_CD04.cboSetupHinmeiCd(cboFHINMEI_CD04.Text)

        '===================================
        ' 品名ｺｰﾄﾞ05ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD05.conn = gobjDb
        cboFHINMEI_CD05.HinmeiLabel = lblFHINMEI05
        cboFHINMEI_CD05.Text = mstrFHINMEI_CD5
        cboFHINMEI_CD05.HinmeiVisible = False
        cboFHINMEI_CD05.cboSetupHinmeiCd(cboFHINMEI_CD05.Text)

        '===================================
        ' 品名ｺｰﾄﾞ06ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD06.conn = gobjDb
        cboFHINMEI_CD06.HinmeiLabel = lblFHINMEI06
        cboFHINMEI_CD06.Text = mstrFHINMEI_CD6
        cboFHINMEI_CD06.HinmeiVisible = False
        cboFHINMEI_CD06.cboSetupHinmeiCd(cboFHINMEI_CD06.Text)

        '===================================
        ' 品名ｺｰﾄﾞ07ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD07.conn = gobjDb
        cboFHINMEI_CD07.HinmeiLabel = lblFHINMEI07
        cboFHINMEI_CD07.Text = mstrFHINMEI_CD7
        cboFHINMEI_CD07.HinmeiVisible = False
        cboFHINMEI_CD07.cboSetupHinmeiCd(cboFHINMEI_CD07.Text)

        '===================================
        ' 品名ｺｰﾄﾞ08ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        cboFHINMEI_CD08.conn = gobjDb
        cboFHINMEI_CD08.HinmeiLabel = lblFHINMEI08
        cboFHINMEI_CD08.Text = mstrFHINMEI_CD8
        cboFHINMEI_CD08.HinmeiVisible = False
        cboFHINMEI_CD08.cboSetupHinmeiCd(cboFHINMEI_CD08.Text)

        '===================================
        ' 細目ｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU01, True, mstrXSAIMOKU1)
        If mstrXSAIMOKU1 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN1 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU01.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU02, True, mstrXSAIMOKU2)
        If mstrXSAIMOKU2 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN2 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU02.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU03, True, mstrXSAIMOKU3)
        If mstrXSAIMOKU3 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN3 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU03.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU04, True, mstrXSAIMOKU4)
        If mstrXSAIMOKU4 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN4 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU04.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU05, True, mstrXSAIMOKU5)
        If mstrXSAIMOKU5 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN5 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU05.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU06, True, mstrXSAIMOKU6)
        If mstrXSAIMOKU6 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN6 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU06.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU07, True, mstrXSAIMOKU7)
        If mstrXSAIMOKU7 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN7 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU07.Text = "移動-1"
        End If
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXSAIMOKU08, True, mstrXSAIMOKU8)
        If mstrXSAIMOKU8 = TO_STRING(XSAIMOKU_JIDOU) And mstrXIDOU_KBN8 = TO_STRING(XIDOU_KBN_JIDOU) Then
            '(移動-1か確認)
            cboXSAIMOKU08.Text = "移動-1"
        End If

        '===================================
        ' 予定梱数ﾃｷｽﾄﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        txtXSYUKKA_KON_PLAN01.Text = TO_STRING(mstrXSYUKKA_NUM1)
        txtXSYUKKA_KON_PLAN02.Text = TO_STRING(mstrXSYUKKA_NUM2)
        txtXSYUKKA_KON_PLAN03.Text = TO_STRING(mstrXSYUKKA_NUM3)
        txtXSYUKKA_KON_PLAN04.Text = TO_STRING(mstrXSYUKKA_NUM4)
        txtXSYUKKA_KON_PLAN05.Text = TO_STRING(mstrXSYUKKA_NUM5)
        txtXSYUKKA_KON_PLAN06.Text = TO_STRING(mstrXSYUKKA_NUM6)
        txtXSYUKKA_KON_PLAN07.Text = TO_STRING(mstrXSYUKKA_NUM7)
        txtXSYUKKA_KON_PLAN08.Text = TO_STRING(mstrXSYUKKA_NUM8)


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '**********************************************************
        Call ControlEnable()


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
        cboXSYUKKA_D.Dispose()              '出荷日
        txtXSYARYOU_NO.Dispose()            '車輌№
        cboXTUMI_HOUHOU.Dispose()           '積込方法
        cboXTUMI_HOUKOU.Dispose()           '積込方向
        cboXBERTH_NO.Dispose()             'ﾊﾞｰｽ指定
        txtXHENSEI_NO.Dispose()             '編成№
        txtXHENSEI_NO_OYA.Dispose()         '親編成№
        txtXDENPYOU_NO.Dispose()            '伝票№
        txtXBUNRUI_NO.Dispose()             '分類№
        'txtXGYOUSYA_CD.Dispose()            '業者ｺｰﾄﾞ
        cboXGYOUSYA_CD.Dispose()
        txtXSEND_NAME.Dispose()             '届け先
        txtXSEND_ADDRESS.Dispose()          '住所
        cboFHINMEI_CD01.Dispose()           '品名ｺｰﾄﾞ01
        cboFHINMEI_CD02.Dispose()           '品名ｺｰﾄﾞ02
        cboFHINMEI_CD03.Dispose()           '品名ｺｰﾄﾞ03
        cboFHINMEI_CD04.Dispose()           '品名ｺｰﾄﾞ04
        cboFHINMEI_CD05.Dispose()           '品名ｺｰﾄﾞ05
        cboFHINMEI_CD06.Dispose()           '品名ｺｰﾄﾞ06
        cboFHINMEI_CD07.Dispose()           '品名ｺｰﾄﾞ07
        cboFHINMEI_CD08.Dispose()           '品名ｺｰﾄﾞ08
        txtXSYUKKA_KON_PLAN01.Dispose()     '予定梱数01
        txtXSYUKKA_KON_PLAN02.Dispose()     '予定梱数02
        txtXSYUKKA_KON_PLAN03.Dispose()     '予定梱数03
        txtXSYUKKA_KON_PLAN04.Dispose()     '予定梱数04
        txtXSYUKKA_KON_PLAN05.Dispose()     '予定梱数05
        txtXSYUKKA_KON_PLAN06.Dispose()     '予定梱数06
        txtXSYUKKA_KON_PLAN07.Dispose()     '予定梱数07
        txtXSYUKKA_KON_PLAN08.Dispose()     '予定梱数08
        cboXSAIMOKU01.Dispose()             '細目01
        cboXSAIMOKU02.Dispose()             '細目02
        cboXSAIMOKU03.Dispose()             '細目03
        cboXSAIMOKU04.Dispose()             '細目04
        cboXSAIMOKU05.Dispose()             '細目05
        cboXSAIMOKU06.Dispose()             '細目06
        cboXSAIMOKU07.Dispose()             '細目07
        cboXSAIMOKU08.Dispose()             '細目08


    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then
            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


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
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        'Dim intRet As RetCode
        Dim strMsg As String = ""


        Select Case 1
            Case 1
                '(出荷指示の場合)

                '========================================
                '編成№
                '========================================
                If Trim(txtXHENSEI_NO.Text) = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_01, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                If Trim(txtXHENSEI_NO.Text).Length <> 4 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_02, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If


                '' ''========================================
                '' ''親編成№
                '' ''========================================
                ' ''If Trim(txtXHENSEI_NO_OYA.Text) = "" Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_04, PopupFormType.Ok, PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If

                ' ''If Trim(txtXHENSEI_NO_OYA.Text).Length <> 4 Then
                ' ''    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_05, PopupFormType.Ok, PopupIconType.Information)
                ' ''    Exit Select
                ' ''End If


                '========================================
                '伝票№
                '========================================
                If Trim(txtXDENPYOU_NO.Text) = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_03, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If



                '========================================
                '分類№
                '========================================
                If Trim(txtXBUNRUI_NO.Text) = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_06, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If


                '**********************************************************
                ' 項目№ごとの確認
                '**********************************************************
                '========================================
                '№1
                '========================================
                If SYUKKA_SIJI_Chk(cboFHINMEI_CD01, txtXSYUKKA_KON_PLAN01, cboXSAIMOKU01, 1) = False Then
                    '(ｴﾗｰの時)
                    Exit Select
                End If

                '========================================
                '№2
                '========================================
                If (Trim(cboFHINMEI_CD02.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN02.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN02.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU02.Text) <> "" _
                   ) Then
                    '(項目№2に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD02, txtXSYUKKA_KON_PLAN02, cboXSAIMOKU02, 2) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№3
                '========================================
                If (Trim(cboFHINMEI_CD03.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN03.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN03.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU03.Text) <> "" _
                   ) Then
                    '(項目№3に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD03, txtXSYUKKA_KON_PLAN03, cboXSAIMOKU03, 3) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№4
                '========================================
                If (Trim(cboFHINMEI_CD04.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN04.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN04.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU04.Text) <> "" _
                   ) Then
                    '(項目№4に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD04, txtXSYUKKA_KON_PLAN04, cboXSAIMOKU04, 4) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№5
                '========================================
                If (Trim(cboFHINMEI_CD05.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN05.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN05.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU05.Text) <> "" _
                   ) Then
                    '(項目№5に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD05, txtXSYUKKA_KON_PLAN05, cboXSAIMOKU05, 5) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№6
                '========================================
                If (Trim(cboFHINMEI_CD06.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN06.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN06.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU06.Text) <> "" _
                   ) Then
                    '(項目№6に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD06, txtXSYUKKA_KON_PLAN06, cboXSAIMOKU06, 6) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№7
                '========================================
                If (Trim(cboFHINMEI_CD07.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN07.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN07.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU07.Text) <> "" _
                   ) Then
                    '(項目№7に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD07, txtXSYUKKA_KON_PLAN07, cboXSAIMOKU07, 7) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If

                '========================================
                '№8
                '========================================
                If (Trim(cboFHINMEI_CD08.Text) <> "" _
                    Or ((txtXSYUKKA_KON_PLAN08.Value <> "") And (TO_DECIMAL(txtXSYUKKA_KON_PLAN08.Value) <> 0)) _
                    Or Trim(cboXSAIMOKU08.Text) <> "" _
                   ) Then
                    '(項目№8に入力があるとき)
                    If SYUKKA_SIJI_Chk(cboFHINMEI_CD08, txtXSYUKKA_KON_PLAN08, cboXSAIMOKU08, 8) = False Then
                        '(ｴﾗｰの時)
                        Exit Select
                    End If
                End If


                '===============================================
                '同じ品名ｺｰﾄﾞが存在しないかﾁｪｯｸ
                '===============================================
                Dim strHinmeiCD(8) As String       '品名ｺｰﾄﾞ
                strHinmeiCD(1) = cboFHINMEI_CD01.Text
                strHinmeiCD(2) = cboFHINMEI_CD02.Text
                strHinmeiCD(3) = cboFHINMEI_CD03.Text
                strHinmeiCD(4) = cboFHINMEI_CD04.Text
                strHinmeiCD(5) = cboFHINMEI_CD05.Text
                strHinmeiCD(6) = cboFHINMEI_CD06.Text
                strHinmeiCD(7) = cboFHINMEI_CD07.Text
                strHinmeiCD(8) = cboFHINMEI_CD08.Text

                For ii As Integer = 1 To 8
                    '(品名ｺﾝﾎﾞﾎﾞｯｸｽの数だけ)

                    If strHinmeiCD(ii) = "" Then Continue For
                    Dim strHinmeiTemp = strHinmeiCD(ii)         '品名ｺｰﾄﾞ
                    Dim intOnaji As Integer = 0
                    For jj As Integer = 1 To 8
                        If strHinmeiTemp = strHinmeiCD(jj) Then
                            intOnaji += 1
                        End If
                    Next

                    If 2 <= intOnaji Then
                        '(同じ品名の物が2個以上ある場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_16, PopupFormType.Ok, PopupIconType.Information)
                        Exit Function
                    End If
                Next


                '===============================================
                '同じ出荷指示が存在しないかﾁｪｯｸ
                '===============================================
                If mintButtonMode = BUTTONMODE_ADD Then
                    '(「追加」の場合)
                    Dim objXPLN_OUT As New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
                    objXPLN_OUT.XSYUKKA_D = TO_DATE(Format(cboXSYUKKA_D.cmpMDateTimePicker_D.Value, "yyyy/MM/dd"))              '出荷日
                    objXPLN_OUT.XHENSEI_NO = Trim(txtXHENSEI_NO.Text)                     '編成No
                    objXPLN_OUT.XDENPYOU_NO = Trim(txtXDENPYOU_NO.Text)                   '伝票No
                    If objXPLN_OUT.GET_XPLN_OUT_COUNT > 0 Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311011_17, PopupFormType.Ok, PopupIconType.Information)
                        Exit Function
                    End If
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
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()

        'Dim intRet As RetCode

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        '正式品名記号取得
        '*******************************************************

        Dim strXHINMEI_CD1 As String = ""          '正式品名ｺｰﾄﾞ1
        Dim strXHINMEI_CD2 As String = ""          '正式品名ｺｰﾄﾞ2"
        Dim strXHINMEI_CD3 As String = ""          '正式品名ｺｰﾄﾞ3
        Dim strXHINMEI_CD4 As String = ""          '正式品名ｺｰﾄﾞ4
        Dim strXHINMEI_CD5 As String = ""          '正式品名ｺｰﾄﾞ5
        Dim strXHINMEI_CD6 As String = ""          '正式品名ｺｰﾄﾞ6
        Dim strXHINMEI_CD7 As String = ""          '正式品名ｺｰﾄﾞ7
        Dim strXHINMEI_CD8 As String = ""          '正式品名ｺｰﾄﾞ8

        Dim objTBL_TMST_ITEM As TBL_TMST_ITEM
        Dim intRet As Integer

        If TO_STRING(cboFHINMEI_CD01.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD01.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD01.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD1 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ1
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD1 = cboFHINMEI_CD01.Text

            End If

        End If

        If TO_STRING(cboFHINMEI_CD02.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD02.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD02.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD2 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ2
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD2 = cboFHINMEI_CD02.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD03.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD03.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD03.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD3 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ3
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD3 = cboFHINMEI_CD03.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD04.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD04.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD04.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD4 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ4
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD4 = cboFHINMEI_CD04.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD05.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD05.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD05.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD5 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ5
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD5 = cboFHINMEI_CD05.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD06.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD06.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD06.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD6 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ6
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD6 = cboFHINMEI_CD06.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD07.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD07.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD07.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD7 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ7
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD7 = cboFHINMEI_CD07.Text

            End If
        End If

        If TO_STRING(cboFHINMEI_CD08.Text) <> "" Then
            If IsNumeric(cboFHINMEI_CD08.Text.Substring(0, 1)) = False Then
                '(品名記号の場合)
                objTBL_TMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD08.Text)   '品名記号
                intRet = objTBL_TMST_ITEM.GET_TMST_ITEM(False)
                If intRet = RetCode.OK Then
                    strXHINMEI_CD8 = TO_STRING(objTBL_TMST_ITEM.XHINMEI_CD)    '正式品名ｺｰﾄﾞ8
                End If
                objTBL_TMST_ITEM.Close()
            Else
                '(正式品名ｺｰﾄﾞの場合)
                strXHINMEI_CD8 = cboFHINMEI_CD08.Text

            End If
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101                                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", TO_STRING(mintButtonMode))                           '処理区分
        objTelegram.SETIN_DATA("XDSPDATA_KIND", TO_STRING("10"))                                    'ﾃﾞｰﾀ種類
        objTelegram.SETIN_DATA("XDSPEDIT_KBN", TO_STRING(mobjXPLN_OUT.XEDIT_KBN))                   '編集区分
        objTelegram.SETIN_DATA("XDSPINPUT_PLACE", TO_STRING(mobjXPLN_OUT.XINPUT_PLACE))             'ｲﾝﾌﾟｯﾄ場所
        objTelegram.SETIN_DATA("XDSPINPUT_DT", TO_STRING(mobjXPLN_OUT.XINPUT_DT))                   'ｲﾝﾌﾟｯﾄ日付
        objTelegram.SETIN_DATA("XDSPINPUT_NO", TO_STRING(mobjXPLN_OUT.XINPUT_NO))                   'ｲﾝﾌﾟｯﾄNo.
        objTelegram.SETIN_DATA("XDSPBUNRUI_NO", TO_STRING(txtXBUNRUI_NO.Text))                      '分類No
        objTelegram.SETIN_DATA("XDSPDENPYOU_NO", TO_STRING(txtXDENPYOU_NO.Text))                    '伝票No
        objTelegram.SETIN_DATA("XDSPDATA_DT", TO_STRING(mobjXPLN_OUT.XDATA_DT))                     'ﾃﾞｰﾀ日付
        objTelegram.SETIN_DATA("XDSPSYUKKA_D", TO_STRING(Format(cboXSYUKKA_D.cmpMDateTimePicker_D.Value, "yyyy/MM/dd")))    '出荷日
        objTelegram.SETIN_DATA("XDSPHENSEI_NO", TO_STRING(txtXHENSEI_NO.Text))                      '編成No
        objTelegram.SETIN_DATA("XDSPSOUKO_CD", TO_STRING(mobjXPLN_OUT.XSOUKO_CD))                   '倉庫ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPTOU_NO", TO_STRING(mobjXPLN_OUT.XTOU_NO))                       '棟ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPTORIHIKI_KBN", TO_STRING(mobjXPLN_OUT.XTORIHIKI_KBN))           '取引区分
        objTelegram.SETIN_DATA("XDSPDATA_SYORI", TO_STRING(mobjXPLN_OUT.XDATA_SYORI))               'ﾃﾞｰﾀ処理
        objTelegram.SETIN_DATA("XDSPSYASYU_KBN", TO_STRING(mobjXPLN_OUT.XSYASYU_KBN))               '車種区分
        objTelegram.SETIN_DATA("XDSPGYOUSYA_CD", TO_STRING(cboXGYOUSYA_CD.SelectedValue))           '業者ｺｰﾄﾞ
        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", TO_STRING(cboXSYARYOU_NO.Text))                    '車輌No
        'objTelegram.SETIN_DATA("XDSPSYARYOU_NO", TO_STRING(txtXSYARYOU_NO.Text))                    '車輌No
        objTelegram.SETIN_DATA("XDSPUNKOU_NO", TO_STRING(mobjXPLN_OUT.XUNKOU_NO))                   '倉庫別運行No.
        objTelegram.SETIN_DATA("XDSPTUMI_HOUHOU", TO_STRING(cboXTUMI_HOUHOU.SelectedValue))         '積込方法区分
        objTelegram.SETIN_DATA("XDSPSEND_NAME", TO_STRING(txtXSEND_NAME.Text))                      '届け先
        objTelegram.SETIN_DATA("XDSPSEND_ADDRESS", TO_STRING(txtXSEND_ADDRESS.Text))                '住所
        If txtXHENSEI_NO_OYA.Text <> "" Then                                                        '親編成No
            '(入力済み)
            objTelegram.SETIN_DATA("XDSPHENSEI_NO_OYA", TO_STRING(txtXHENSEI_NO_OYA.Text))
        Else
            '(未入力)
            objTelegram.SETIN_DATA("XDSPHENSEI_NO_OYA", TO_STRING(txtXHENSEI_NO.Text))
        End If

        objTelegram.SETIN_DATA("XDSPBERTH_NO", TO_STRING(cboXBERTH_NO.Text))                        'ﾊﾞｰｽ指定
        objTelegram.SETIN_DATA("XDSPKINKYU_KBN", XKINKYU_KBN_JOFF)                                  '緊急出荷区分
        objTelegram.SETIN_DATA("XDSPKINKYU_LEVEL", XKINKYU_LEVEL_JNON)                              '緊急度
        objTelegram.SETIN_DATA("XDSPTUMI_HOUKOU", TO_STRING(cboXTUMI_HOUKOU.SelectedValue))         '積込方向

        objTelegram.SETIN_DATA("XDSPHINMEI_CD01", strXHINMEI_CD1)                                   '品名ｺｰﾄﾞ1
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN01", TO_STRING(txtXSYUKKA_KON_PLAN01.Text))      '出荷数1
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN01", TO_STRING(mstrZAIKO_KUBUN1))                     '在庫区分1
        If TO_STRING(cboXSAIMOKU01.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU01", TO_STRING(cboXSAIMOKU01.SelectedValue))         '取引区分細目1
            objTelegram.SETIN_DATA("XDSPIDOU_KBN01", TO_STRING("0"))                                '移動区分1

        ElseIf TO_STRING(cboXSAIMOKU01.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU01", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目1
            objTelegram.SETIN_DATA("XDSPIDOU_KBN01", TO_STRING("1"))                                '移動区分1

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD02", strXHINMEI_CD2)                                   '品名ｺｰﾄﾞ2
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN02", TO_STRING(txtXSYUKKA_KON_PLAN02.Text))      '出荷数2
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN02", TO_STRING(mstrZAIKO_KUBUN2))                     '在庫区分2
        If TO_STRING(cboXSAIMOKU02.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU02", TO_STRING(cboXSAIMOKU02.SelectedValue))         '取引区分細目2
            objTelegram.SETIN_DATA("XDSPIDOU_KBN02", TO_STRING("0"))                                '移動区分2

        ElseIf TO_STRING(cboXSAIMOKU02.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU02", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目2
            objTelegram.SETIN_DATA("XDSPIDOU_KBN02", TO_STRING("1"))                                '移動区分2

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD03", strXHINMEI_CD3)                                   '品名ｺｰﾄﾞ3
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN03", TO_STRING(txtXSYUKKA_KON_PLAN03.Text))      '出荷数3
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN03", TO_STRING(mstrZAIKO_KUBUN3))                     '在庫区分3
        If TO_STRING(cboXSAIMOKU03.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU03", TO_STRING(cboXSAIMOKU03.SelectedValue))         '取引区分細目3
            objTelegram.SETIN_DATA("XDSPIDOU_KBN03", TO_STRING("0"))                                '移動区分3

        ElseIf TO_STRING(cboXSAIMOKU03.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU03", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目3
            objTelegram.SETIN_DATA("XDSPIDOU_KBN03", TO_STRING("1"))                                '移動区分3

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD04", strXHINMEI_CD4)                                   '品名ｺｰﾄﾞ4
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN04", TO_STRING(txtXSYUKKA_KON_PLAN04.Text))      '出荷数4
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN04", TO_STRING(mstrZAIKO_KUBUN4))                     '在庫区分4
        If TO_STRING(cboXSAIMOKU04.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU04", TO_STRING(cboXSAIMOKU04.SelectedValue))         '取引区分細目4
            objTelegram.SETIN_DATA("XDSPIDOU_KBN04", TO_STRING("0"))                                '移動区分4

        ElseIf TO_STRING(cboXSAIMOKU04.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU04", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目4
            objTelegram.SETIN_DATA("XDSPIDOU_KBN04", TO_STRING("1"))                                '移動区分4

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD05", strXHINMEI_CD5)                                   '品名ｺｰﾄﾞ5
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN05", TO_STRING(txtXSYUKKA_KON_PLAN05.Text))      '出荷数5
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN05", TO_STRING(mstrZAIKO_KUBUN5))                     '在庫区分5
        If TO_STRING(cboXSAIMOKU05.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU05", TO_STRING(cboXSAIMOKU05.SelectedValue))         '取引区分細目5
            objTelegram.SETIN_DATA("XDSPIDOU_KBN05", TO_STRING("0"))                                '移動区分5

        ElseIf TO_STRING(cboXSAIMOKU05.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU05", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目5
            objTelegram.SETIN_DATA("XDSPIDOU_KBN05", TO_STRING("1"))                                '移動区分5

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD06", strXHINMEI_CD6)                                   '品名ｺｰﾄﾞ6
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN06", TO_STRING(txtXSYUKKA_KON_PLAN06.Text))      '出荷数6
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN06", TO_STRING(mstrZAIKO_KUBUN6))                     '在庫区分6
        If TO_STRING(cboXSAIMOKU06.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU06", TO_STRING(cboXSAIMOKU06.SelectedValue))         '取引区分細目6
            objTelegram.SETIN_DATA("XDSPIDOU_KBN06", TO_STRING("0"))                                '移動区分6

        ElseIf TO_STRING(cboXSAIMOKU06.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU06", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目6
            objTelegram.SETIN_DATA("XDSPIDOU_KBN06", TO_STRING("1"))                                '移動区分6

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD07", strXHINMEI_CD7)                                   '品名ｺｰﾄﾞ7
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN07", TO_STRING(txtXSYUKKA_KON_PLAN07.Text))      '出荷数7
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN07", TO_STRING(mstrZAIKO_KUBUN7))                     '在庫区分7
        If TO_STRING(cboXSAIMOKU07.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU07", TO_STRING(cboXSAIMOKU07.SelectedValue))         '取引区分細目7
            objTelegram.SETIN_DATA("XDSPIDOU_KBN07", TO_STRING("0"))                                '移動区分7

        ElseIf TO_STRING(cboXSAIMOKU07.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU07", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目7
            objTelegram.SETIN_DATA("XDSPIDOU_KBN07", TO_STRING("1"))                                '移動区分7

        End If

        objTelegram.SETIN_DATA("XDSPHINMEI_CD08", strXHINMEI_CD8)                                   '品名ｺｰﾄﾞ8
        objTelegram.SETIN_DATA("XDSPSYUKKA_KON_PLAN08", TO_STRING(txtXSYUKKA_KON_PLAN08.Text))      '出荷数8
        objTelegram.SETIN_DATA("DSPZAIKO_KUBUN08", TO_STRING(mstrZAIKO_KUBUN8))                     '在庫区分8
        If TO_STRING(cboXSAIMOKU08.SelectedValue) <> "999" Then
            '(通常処理)
            objTelegram.SETIN_DATA("XDSPSAIMOKU08", TO_STRING(cboXSAIMOKU08.SelectedValue))         '取引区分細目8
            objTelegram.SETIN_DATA("XDSPIDOU_KBN08", TO_STRING("0"))                                '移動区分8

        ElseIf TO_STRING(cboXSAIMOKU08.SelectedValue) = "999" Then
            '(移動-1 選択時)
            objTelegram.SETIN_DATA("XDSPSAIMOKU08", TO_STRING(XSAIMOKU_JIDOU))                      '取引区分細目8
            objTelegram.SETIN_DATA("XDSPIDOU_KBN08", TO_STRING("1"))                                '移動区分8

        End If

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                 'ｴﾗｰﾒｯｾｰｼﾞ

        objTelegram.MAKE_TELEGRAM()

        strErrMsg = FRM_MSG_FRM311011_18
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

#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙﾏｽｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                cboXSYUKKA_D.Enabled = True                 '出荷日
                'txtXSYARYOU_NO.Enabled = True               '車輌№
                cboXSYARYOU_NO.Enabled = True               '車輌№
                cboXTUMI_HOUHOU.Enabled = True              '積込方法
                cboXTUMI_HOUKOU.Enabled = True              '積込方向
                cboXBERTH_NO.Enabled = True                'ﾊﾞｰｽ指定
                txtXHENSEI_NO.Enabled = True                '編成№
                txtXHENSEI_NO_OYA.Enabled = True            '親編成№
                txtXDENPYOU_NO.Enabled = True               '伝票№
                txtXBUNRUI_NO.Enabled = True                '分類№
                cboXGYOUSYA_CD.Enabled = True               '業者ｺｰﾄﾞ
                txtXSEND_NAME.Enabled = True                '届け先
                txtXSEND_ADDRESS.Enabled = True             '住所

                cboFHINMEI_CD01.Enabled = True              '品名ｺｰﾄﾞ01
                txtXSYUKKA_KON_PLAN01.Enabled = True        '予定梱数01
                cboXSAIMOKU01.Enabled = True                '細目01
                cboFHINMEI_CD02.Enabled = True              '品名ｺｰﾄﾞ02
                txtXSYUKKA_KON_PLAN02.Enabled = True        '予定梱数02
                cboXSAIMOKU02.Enabled = True                '細目02
                cboFHINMEI_CD03.Enabled = True              '品名ｺｰﾄﾞ03
                txtXSYUKKA_KON_PLAN03.Enabled = True        '予定梱数03
                cboXSAIMOKU03.Enabled = True                '細目03
                cboFHINMEI_CD04.Enabled = True              '品名ｺｰﾄﾞ04
                txtXSYUKKA_KON_PLAN04.Enabled = True        '予定梱数04
                cboXSAIMOKU04.Enabled = True                '細目04
                cboFHINMEI_CD05.Enabled = True              '品名ｺｰﾄﾞ05
                txtXSYUKKA_KON_PLAN05.Enabled = True        '予定梱数05
                cboXSAIMOKU05.Enabled = True                '細目05
                cboFHINMEI_CD06.Enabled = True              '品名ｺｰﾄﾞ06
                txtXSYUKKA_KON_PLAN06.Enabled = True        '予定梱数06
                cboXSAIMOKU06.Enabled = True                '細目06
                cboFHINMEI_CD07.Enabled = True              '品名ｺｰﾄﾞ07
                txtXSYUKKA_KON_PLAN07.Enabled = True        '予定梱数07
                cboXSAIMOKU07.Enabled = True                '細目07
                cboFHINMEI_CD08.Enabled = True              '品名ｺｰﾄﾞ08
                txtXSYUKKA_KON_PLAN08.Enabled = True        '予定梱数08
                cboXSAIMOKU08.Enabled = True                '細目08

                Exit Select


            Case BUTTONMODE_UPDATE
                '(変更の場合)

                cboXSYUKKA_D.Enabled = False                '出荷日
                'txtXSYARYOU_NO.Enabled = True               '車輌№
                cboXSYARYOU_NO.Enabled = True               '車輌№
                cboXTUMI_HOUHOU.Enabled = True              '積込方法
                cboXTUMI_HOUKOU.Enabled = True              '積込方向
                cboXBERTH_NO.Enabled = True                'ﾊﾞｰｽ指定
                txtXHENSEI_NO.Enabled = False               '編成№
                txtXHENSEI_NO_OYA.Enabled = True            '親編成№
                txtXDENPYOU_NO.Enabled = False              '伝票№
                txtXBUNRUI_NO.Enabled = True                '分類№
                cboXGYOUSYA_CD.Enabled = True               '業者ｺｰﾄﾞ
                txtXSEND_NAME.Enabled = True                '届け先
                txtXSEND_ADDRESS.Enabled = True             '住所

                cboFHINMEI_CD01.Enabled = True              '品名ｺｰﾄﾞ01
                txtXSYUKKA_KON_PLAN01.Enabled = True        '予定梱数01
                cboXSAIMOKU01.Enabled = True                '細目01
                cboFHINMEI_CD02.Enabled = True              '品名ｺｰﾄﾞ02
                txtXSYUKKA_KON_PLAN02.Enabled = True        '予定梱数02
                cboXSAIMOKU02.Enabled = True                '細目02
                cboFHINMEI_CD03.Enabled = True              '品名ｺｰﾄﾞ03
                txtXSYUKKA_KON_PLAN03.Enabled = True        '予定梱数03
                cboXSAIMOKU03.Enabled = True                '細目03
                cboFHINMEI_CD04.Enabled = True              '品名ｺｰﾄﾞ04
                txtXSYUKKA_KON_PLAN04.Enabled = True        '予定梱数04
                cboXSAIMOKU04.Enabled = True                '細目04
                cboFHINMEI_CD05.Enabled = True              '品名ｺｰﾄﾞ05
                txtXSYUKKA_KON_PLAN05.Enabled = True        '予定梱数05
                cboXSAIMOKU05.Enabled = True                '細目05
                cboFHINMEI_CD06.Enabled = True              '品名ｺｰﾄﾞ06
                txtXSYUKKA_KON_PLAN06.Enabled = True        '予定梱数06
                cboXSAIMOKU06.Enabled = True                '細目06
                cboFHINMEI_CD07.Enabled = True              '品名ｺｰﾄﾞ07
                txtXSYUKKA_KON_PLAN07.Enabled = True        '予定梱数07
                cboXSAIMOKU07.Enabled = True                '細目07
                cboFHINMEI_CD08.Enabled = True              '品名ｺｰﾄﾞ08
                txtXSYUKKA_KON_PLAN08.Enabled = True        '予定梱数08
                cboXSAIMOKU08.Enabled = True                '細目08

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                cboXSYUKKA_D.Enabled = False                '出荷日
                'txtXSYARYOU_NO.Enabled = False              '車輌№
                cboXSYARYOU_NO.Enabled = False              '車輌№
                cboXTUMI_HOUHOU.Enabled = False             '積込方法
                cboXTUMI_HOUKOU.Enabled = False             '積込方向
                cboXBERTH_NO.Enabled = False               'ﾊﾞｰｽ指定
                txtXHENSEI_NO.Enabled = False               '編成№
                txtXHENSEI_NO_OYA.Enabled = False           '親編成№
                txtXDENPYOU_NO.Enabled = False              '伝票№
                txtXBUNRUI_NO.Enabled = False               '分類№
                cboXGYOUSYA_CD.Enabled = False              '業者ｺｰﾄﾞ
                txtXSEND_NAME.Enabled = False               '届け先
                txtXSEND_ADDRESS.Enabled = False            '住所

                cboFHINMEI_CD01.Enabled = False             '品名ｺｰﾄﾞ01
                txtXSYUKKA_KON_PLAN01.Enabled = False       '予定梱数01
                cboXSAIMOKU01.Enabled = False               '細目01
                cboFHINMEI_CD02.Enabled = False             '品名ｺｰﾄﾞ02
                txtXSYUKKA_KON_PLAN02.Enabled = False       '予定梱数02
                cboXSAIMOKU02.Enabled = False               '細目02
                cboFHINMEI_CD03.Enabled = False             '品名ｺｰﾄﾞ03
                txtXSYUKKA_KON_PLAN03.Enabled = False       '予定梱数03
                cboXSAIMOKU03.Enabled = False               '細目03
                cboFHINMEI_CD04.Enabled = False             '品名ｺｰﾄﾞ04
                txtXSYUKKA_KON_PLAN04.Enabled = False       '予定梱数04
                cboXSAIMOKU04.Enabled = False               '細目04
                cboFHINMEI_CD05.Enabled = False             '品名ｺｰﾄﾞ05
                txtXSYUKKA_KON_PLAN05.Enabled = False       '予定梱数05
                cboXSAIMOKU05.Enabled = False               '細目05
                cboFHINMEI_CD06.Enabled = False             '品名ｺｰﾄﾞ06
                txtXSYUKKA_KON_PLAN06.Enabled = False       '予定梱数06
                cboXSAIMOKU06.Enabled = False               '細目06
                cboFHINMEI_CD07.Enabled = False             '品名ｺｰﾄﾞ07
                txtXSYUKKA_KON_PLAN07.Enabled = False       '予定梱数07
                cboXSAIMOKU07.Enabled = False               '細目07
                cboFHINMEI_CD08.Enabled = False             '品名ｺｰﾄﾞ08
                txtXSYUKKA_KON_PLAN08.Enabled = False       '予定梱数08
                cboXSAIMOKU08.Enabled = False               '細目08

                Exit Select

        End Select

    End Sub
#End Region
#Region "　項目№ごとの確認ﾁｪｯｸ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 項目№ごとの確認ﾁｪｯｸ
    ''' </summary>
    ''' <param name="cboFHINMEI_CD">品名ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="txtXSYUKKA_KON_PLAN">予定梱数ﾃｷｽﾄﾎﾞｯｸｽ</param>
    ''' <param name="cboXSAIMOKU">細目ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="intNo">項目№</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SYUKKA_SIJI_Chk(ByVal cboFHINMEI_CD As GamenCommon.cmpCboFHINMEI_CD _
                                           , ByVal txtXSYUKKA_KON_PLAN As MateCommon.cmpMTextBoxNumber _
                                           , ByVal cboXSAIMOKU As MateCommon.cmpMComboBox _
                                           , ByVal intNo As Integer) As Boolean

        Dim intRet As RetCode
        Dim blnCheck As Boolean = False       '可能有無ﾌﾗｸﾞ

        '========================================
        '品目ｺｰﾄﾞ
        '========================================
        If Trim(cboFHINMEI_CD.Text) = "" Then
            Call gobjComFuncFRM.DisplayPopup("項目№" & intNo & "の" & FRM_MSG_FHINMEI_CD_MSG_01, PopupFormType.Ok, PopupIconType.Information)
            Return blnCheck
        End If

        Dim strFHINMEI_CD As String = TO_STRING(cboFHINMEI_CD.Text)

        Dim objTMST_ITEM As TBL_TMST_ITEM                       '品目ﾏｽﾀ
        objTMST_ITEM = New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        If IsNumeric(strFHINMEI_CD.Substring(0, 1)) = False Then
            objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD                 '品名ｺｰﾄﾞ
        Else
            objTMST_ITEM.XHINMEI_CD = strFHINMEI_CD                 '正式品名
        End If
        intRet = objTMST_ITEM.GET_TMST_ITEM(False)

        If intRet = RetCode.OK Then
            '(品名ｺｰﾄﾞ存在する時)
            'NOP
        Else
            '(品名ｺｰﾄﾞが存在しない時)
            Call gobjComFuncFRM.DisplayPopup("項目№" & intNo & "に" & FRM_MSG_FRM311011_19, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Return blnCheck
        End If


        '========================================
        '予定梱数
        '========================================
        If (txtXSYUKKA_KON_PLAN.Value = "") Or (TO_DECIMAL(txtXSYUKKA_KON_PLAN.Value) = 0) Then
            Call gobjComFuncFRM.DisplayPopup("項目№" & intNo & "に" & FRM_MSG_FTR_VOL_MSG_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Return blnCheck
        End If
        If IsNumeric(txtXSYUKKA_KON_PLAN.Value) = False Then
            Call gobjComFuncFRM.DisplayPopup("項目№" & intNo & "は" & FRM_MSG_FRM200000_13 & vbCrLf & FRM_MSG_FTR_VOL_MSG_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Information)
            Return blnCheck
        End If


        '========================================
        '細目
        '========================================
        If Trim(cboXSAIMOKU.Text) = "" Then
            Call gobjComFuncFRM.DisplayPopup("項目№" & intNo & "の" & FRM_MSG_FRM311011_08, PopupFormType.Ok, PopupIconType.Information)
            Return blnCheck
        End If


        blnCheck = True
        Return blnCheck

    End Function
#End Region

#Region "　車両No.ｺﾝﾎﾞﾎﾞｯｸｽ作成                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 車両No.ｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <param name="cboBox">ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeXSYARYOU_NO_cbo(ByRef cboBox As cmpMComboBox)

        cboBox.Items.Clear()    '初期化
        cboBox.Items.Add("")    '全選択 追加

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XMST_SYARYOU.XSYARYOU_NO "              '車両ﾏｽﾀ.     車両No.
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XMST_SYARYOU "                          '【車両ﾏｽﾀ】
        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XSYARYOU_NO "                           '車両ﾏｽﾀ.     車両No.
        strSQL &= vbCrLf
        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '(1件ずつ追加)
                cboBox.Items.Add(TO_STRING(objRow("XSYARYOU_NO")))

            Next
        End If

        '********************************************************************
        ' 初期表示
        '********************************************************************
        If IsNull(mobjXPLN_OUT.XSYARYOU_NO) = False Then
            cboBox.Text = mobjXPLN_OUT.XSYARYOU_NO
        End If

    End Sub
#End Region
#Region "　業者ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ作成                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 業者ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <param name="cboBox">ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeXGYOUSYA_CD_cbo(ByRef cboBox As cmpMComboBox)

        cboBox.Items.Clear()    '初期化
        cboBox.Items.Add("")    '全選択 追加

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XMST_GYOUSYA.XGYOUSYA_CD "              '業者ﾏｽﾀ.     業者ｺｰﾄﾞ
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XMST_GYOUSYA "                          '【業者ﾏｽﾀ】
        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XGYOUSYA_CD "                           '業者ﾏｽﾀ.     業者ｺｰﾄﾞ
        strSQL &= vbCrLf
        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XMST_GYOUSYA"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '(1件ずつ追加)
                cboBox.Items.Add(TO_STRING(objRow("XGYOUSYA_CD")))

            Next
        End If

        '********************************************************************
        ' 初期表示
        '********************************************************************
        If IsNull(mobjXPLN_OUT.XGYOUSYA_CD) = False Then
            cboBox.Text = mobjXPLN_OUT.XGYOUSYA_CD
        End If

    End Sub
#End Region
#Region "　ﾊﾞｰｽNo.ｺﾝﾎﾞﾎﾞｯｸｽ作成                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽNo.ｺﾝﾎﾞﾎﾞｯｸｽ作成
    ''' </summary>
    ''' <param name="cboBox">ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeXBerth_NO_cbo(ByRef cboBox As cmpMComboBox)

        cboBox.Items.Clear()    '初期化
        cboBox.Items.Add("")    '全選択 追加

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO "                  '出荷ﾊﾞｰｽ状況.     ﾊﾞｰｽNo.
        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                            '【出荷ﾊﾞｰｽ状況】
        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XBERTH_NO "                             '出荷ﾊﾞｰｽ状況.     ﾊﾞｰｽNo.
        strSQL &= vbCrLf
        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_BERTH"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '(1件ずつ追加)
                cboBox.Items.Add(TO_STRING(objRow("XBERTH_NO")))

            Next
        End If

        '********************************************************************
        ' 初期表示
        '********************************************************************
        If IsNull(mobjXPLN_OUT.XBERTH_NO) = False Then
            cboBox.Text = mobjXPLN_OUT.XBERTH_NO
        End If

    End Sub
#End Region

End Class
