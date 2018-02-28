'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】入出庫業務ﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_203000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      '出庫計画
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      '出庫開始設定
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '問合せ出庫設定
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '配替作業指示
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      '立会い作業設定

    End Sub
#End Region
#Region "　出庫計画ｸﾘｯｸ  　     　              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫計画ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　出庫開始設定ｸﾘｯｸ                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出庫開始設定ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*ｶｺﾞﾒﾅｼ* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　問合せ出庫設定ｸﾘｯｸ     　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 問合せ出庫設定ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*ｶｺﾞﾒﾅｼ* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　配替作業指示ｸﾘｯｸ 　                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 配替作業指示ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '*ｶｺﾞﾒﾅｼ* Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_303060, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region

#Region "  F8  ﾎﾞﾀﾝ押下処理　                   "
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
