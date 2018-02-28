'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】問合せﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_204000

#Region "  ｲﾍﾞﾝﾄ　                              "
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝ名取得
        '**********************************************************
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '在庫問合せ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '作業履歴問合せ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '入出庫実績問合せ

    End Sub
#End Region

#Region "　在庫問合せｸﾘｯｸ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫問合せｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　作業履歴問合せｸﾘｯｸ                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 作業履歴問合せｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204050, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　入出庫実績問合せｸﾘｯｸ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入出庫実績問合せｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ﾎﾞﾀﾝ押下処理　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_201000, Me)

    End Sub
#End Region

End Class
