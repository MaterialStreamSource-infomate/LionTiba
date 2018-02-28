'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】DB接続画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports"
Imports MateCommon
Imports MateCommon.clsConst
Imports CtrlZTool.clsComFuncFRM
Imports JobCommon
#End Region

Public Class FRM_299012

    '接続文字列用固定値
    Private Const CON_STR_01 As String = "User ID="
    Private Const CON_STR_02 As String = "Password="
    Private Const CON_STR_03 As String = "Data Source="
    Private Const CON_STR_11 As String = ";"

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try


            '**************************************************************************
            ' ｵﾗｸﾙ接続
            '**************************************************************************
            Dim blnRet As Boolean
            gobjDb.ConnectString = ""
            gobjDb.ConnectString &= CON_STR_01 & txtUserID.Text
            gobjDb.ConnectString &= CON_STR_11 & CON_STR_02 & txtPassword.Text
            gobjDb.ConnectString &= CON_STR_11 & CON_STR_03 & txtDataSource.Text
            gobjDb.Disconnect()             '切断
            blnRet = gobjDb.Connect()       '接続
            If blnRet = False Then
                Throw New Exception("DB接続に失敗しました。")
            End If
            Me.Close()


        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub


#Region "　ｴﾗｰ処理                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException">ｴｸｾﾌﾟｼｮﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try
            Call ComError_frm(objException)
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub FRM_299012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            '**************************************************************************
            '接続文字列分解
            '**************************************************************************
            Dim strConnectString As String = gobjDb.ConnectString
            strConnectString = Replace(strConnectString, CON_STR_01, "")
            strConnectString = Replace(strConnectString, CON_STR_02, "")
            strConnectString = Replace(strConnectString, CON_STR_03, "")

            Dim strTemp() As String = Split(strConnectString, CON_STR_11)
            txtUserID.Text = strTemp(0)
            txtPassword.Text = strTemp(1)
            txtDataSource.Text = strTemp(2)


        Catch ex As Exception
            ComError(ex)
        End Try

    End Sub
End Class