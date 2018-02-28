'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｼｽﾃﾑﾒﾝﾃﾅﾝｽﾒﾆｭｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207000

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
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd01)      'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd02)      'ｼｽﾃﾑｴﾗｰﾛｸﾞ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd03)      '設備異常ﾛｸﾞ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd04)      '設備通信ﾛｸﾞ
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd05)      'ﾒｯｾｰｼﾞ履歴
        Call gobjComFuncFRM.ButtonTextSet(Me.Name, cmd06)      'ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽ

    End Sub
#End Region
#Region "　ｵﾍﾟﾚｰｼｮﾝﾛｸﾞｸﾘｯｸ                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾍﾟﾚｰｼｮﾝﾛｸﾞｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207010, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｼｽﾃﾑｴﾗｰﾛｸﾞｸﾘｯｸ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑｴﾗｰﾛｸﾞｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207020, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　設備異常ﾛｸﾞｸﾘｯｸ                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備異常ﾛｸﾞｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207030, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　設備通信ﾛｸﾞｸﾘｯｸ                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備通信ﾛｸﾞｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207040, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾒｯｾｰｼﾞ履歴ｸﾘｯｸ                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ履歴ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207050, Me)
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽｸﾘｯｸ                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmd06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_207060, Me)
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
