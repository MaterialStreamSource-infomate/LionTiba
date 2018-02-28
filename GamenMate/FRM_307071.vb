'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ子画面 RTN選択(1F)
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307071

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "　①   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】①   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL001.Click, cmdL001_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_1_01)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　②   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】②   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL002.Click, cmdL002_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_1_02)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　③   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】③   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL003.Click, cmdL003_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_1_03)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　④   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】④   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL004.Click, cmdL004_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_1_04)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑤   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑤   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL005.Click, cmdL005_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_2_01)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑥   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑥   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL006.Click, cmdL006_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_2_02)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑦   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑦   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL007.Click, cmdL007_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_2_03)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑧   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑧   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL008.Click, cmdL008_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_2_04)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑨   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑨   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL009.Click, cmdL009_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_3_01)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑩   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑩   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL010.Click, cmdL010_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_3_02)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑪   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑪   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL011.Click, cmdL011_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_3_03)

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　⑫   　ﾎﾞﾀﾝ押下                       "
    '*******************************************************************************************************************
    '【機能】⑫   　ﾎﾞﾀﾝ押下
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdLocation12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL012.Click, cmdL012_m.Click
        Try
            Call cmdRTNLocation_ClickProcess(XMAINTE_KUBUN_CW_3_04)

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

#Region "　場所         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 場所        ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <param name="XMAINTE_KUBUN">ﾒﾝﾃﾅﾝｽ区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdRTNLocation_ClickProcess(ByVal XMAINTE_KUBUN As Integer)

        'ﾒﾝﾃﾅﾝｽ区分
        gobjFRM_307070.userXMAINTE_KUBUN = XMAINTE_KUBUN

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
