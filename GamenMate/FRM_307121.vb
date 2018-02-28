'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ子画面 ｸﾚｰﾝ選択
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307121
#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Protected mstrXMAINTE_KUBUN As String               'ﾒﾝﾃﾅﾝｽ区分
    Protected mstrTITLE As String                       'ﾀｲﾄﾙ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
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
    ''' =======================================
    ''' <summary>ﾀｲﾄﾙ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTITLE() As String
        Get
            Return mstrTITLE
        End Get
        Set(ByVal value As String)
            mstrTITLE = value
        End Set
    End Property
#End Region

#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        Me.Text = mstrTITLE

    End Sub
#End Region
#Region "　ｸﾚｰﾝ1   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ1   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane1.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 1)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ2   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ2   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane2.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 2)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ3   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ3   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane3.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 3)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ4   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ4   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane4.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 4)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ5   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ5   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane5.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 5)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ6   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ6   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane6.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 6)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ7   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ7   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane7.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 7)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ8   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ8   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane8.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 8)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ9   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ9   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane9.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 9)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ10  　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ10   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane10.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 10)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ11  　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ11   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane11.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 11)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ12  　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ12   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane12.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 12)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ13  　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ13   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane13.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 13)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾚｰﾝ14  　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】ｸﾚｰﾝ14   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdCrane14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrane14.Click
        Try

            Call cmdCrane_ClickProcess(TO_INTEGER(mstrXMAINTE_KUBUN) + 14)

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

#Region "　ｸﾚｰﾝ         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾚｰﾝ        ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <param name="XMAINTE_KUBUN">ﾒﾝﾃﾅﾝｽ区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCrane_ClickProcess(ByVal XMAINTE_KUBUN As Integer)

        'ﾒﾝﾃﾅﾝｽ区分
        gobjFRM_307120.userXMAINTE_KUBUN = XMAINTE_KUBUN

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
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

End Class
