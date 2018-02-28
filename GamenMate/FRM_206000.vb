'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾏｽﾀﾒﾝﾃﾅﾝｽﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_206000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '製品品番ﾏｽﾀﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '原料品番ﾏｽﾀﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '理由ﾏｽﾀﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '包材品番ﾏｽﾀﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      '担当者ﾏｽﾀﾒﾝﾃﾅﾝｽ


    End Sub
#End Region

#Region "　製品品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 製品品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_306010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　原料品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 原料品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　理由ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 理由ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　包材品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 包材品番ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_306030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　担当者ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ    　　　　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 担当者ﾏｽﾀﾒﾝﾃﾅﾝｽｸﾘｯｸ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_206020, Me)
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
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_FRM_201000, Me)

    End Sub
#End Region

End Class
