'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾒﾝﾃﾅﾝｽﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_205000

#Region "  ｲﾍﾞﾝﾄ　                              "
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　　　　　　　　　           "
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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      'ｵﾝﾗｲﾝ設定
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      'ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '在庫ﾒﾝﾃﾅﾝｽ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '在庫照合
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '棚卸し作業

    End Sub
#End Region

#Region "　ｵﾝﾗｲﾝ設定ｸﾘｯｸ　　　　　              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾝﾗｲﾝ設定ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽｸﾘｯｸ　　　　　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　在庫ﾒﾝﾃﾅﾝｽｸﾘｯｸ　　　　　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫ﾒﾝﾃﾅﾝｽｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　在庫照合ｸﾘｯｸ　　　　　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫照合ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　棚卸し作業ｸﾘｯｸ　　　　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 棚卸し作業ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*ｶｺﾞﾒﾅｼ* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ﾎﾞﾀﾝ押下処理　　　　　           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8  ﾎﾞﾀﾝ押下処理
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
