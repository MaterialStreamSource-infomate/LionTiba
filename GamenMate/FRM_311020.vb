'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】車両受付画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311020

#Region "  共通変数　"

    Private my_FLG As String        '車輌No.　or　編成No.TEXTBOX選択ﾌﾗｸﾞ
    Private mintCMD0 As String = 0  'ｷｰﾎﾞﾀﾝ"0"の定数
    Private mintCMD1 As String = 1  'ｷｰﾎﾞﾀﾝ"1"の定数
    Private mintCMD2 As String = 2  'ｷｰﾎﾞﾀﾝ"2"の定数
    Private mintCMD3 As String = 3  'ｷｰﾎﾞﾀﾝ"3"の定数
    Private mintCMD4 As String = 4  'ｷｰﾎﾞﾀﾝ"4"の定数
    Private mintCMD5 As String = 5  'ｷｰﾎﾞﾀﾝ"5"の定数
    Private mintCMD6 As String = 6  'ｷｰﾎﾞﾀﾝ"6"の定数
    Private mintCMD7 As String = 7  'ｷｰﾎﾞﾀﾝ"7"の定数
    Private mintCMD8 As String = 8  'ｷｰﾎﾞﾀﾝ"8"の定数
    Private mintCMD9 As String = 9  'ｷｰﾎﾞﾀﾝ"9"の定数

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        cmdTouroku_Click                '登録
    End Enum

#End Region

#Region "　ｲﾍﾞﾝﾄ　"
#Region "  車輌No         選択ｲﾍﾞﾝﾄ　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtSyaryouNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSyaryouNo.Click

        Call txtSyaryouNo_SET()

    End Sub

#End Region
#Region "  編成No1        選択ｲﾍﾞﾝﾄ　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtHenseiNo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHenseiNo1.Click

        Call txtHenseiNo_SET(1)

    End Sub

#End Region
#Region "  編成No2        選択ｲﾍﾞﾝﾄ　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtHenseiNo2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHenseiNo2.Click

        Call txtHenseiNo_SET(2)

    End Sub

#End Region
#Region "  編成No3        選択ｲﾍﾞﾝﾄ　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtHenseiNo3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHenseiNo3.Click

        Call txtHenseiNo_SET(3)

    End Sub

#End Region
#Region "  編成No4        選択ｲﾍﾞﾝﾄ　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtHenseiNo4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHenseiNo4.Click

        Call txtHenseiNo_SET(4)

    End Sub

#End Region
#End Region

#Region "　ﾌｫｰﾑﾛｰﾄﾞ    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' 車輌No          ﾘｾｯﾄ
        '**********************************************************
        txtSyaryouNo.Text = ""

        '**********************************************************
        ' 編成No          ﾘｾｯﾄ
        '**********************************************************
        txtHenseiNo1.Text = ""
        txtHenseiNo2.Text = ""
        txtHenseiNo3.Text = ""
        txtHenseiNo4.Text = ""

        '**********************************************************
        ' 積込方法ﾎﾞﾀﾝ     ﾘｾｯﾄ
        '**********************************************************
        cmdTumiHouhou1.BackColor = Color.Silver
        cmdTumiHouhou2.BackColor = Color.Silver
        cmdTumiHouhou3.BackColor = Color.Silver

        '**********************************************************
        ' 積込方向ﾎﾞﾀﾝ     ﾘｾｯﾄ
        '**********************************************************
        cmdTumiHoukou1.BackColor = Color.Silver
        cmdTumiHoukou2.BackColor = Color.Silver
        cmdTumiHoukou3.BackColor = Color.Silver

        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ    ﾘｾｯﾄ
        '**********************************************************
        my_FLG = 0

        '**********************************************************
        ' 車輌No         選択処理
        '**********************************************************
        Call txtSyaryouNo_SET()

    End Sub
#End Region

#Region "　ｲﾍﾞﾝﾄ処理　 "
#Region "  車輌No         選択処理　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtSyaryouNo_SET()
        Try

            my_FLG = 1                                          'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　1:車輌No

            txtHenseiNo1.BackColor = Color.White                '編成Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White
            txtHenseiNo3.BackColor = Color.White
            txtHenseiNo4.BackColor = Color.White

            txtSyaryouNo.Focus()
            txtSyaryouNo.BackColor = Color.LightYellow          '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色色替え

            Call lclBTNColor(txtSyaryouNo.Text)             'ﾎﾞﾀﾝ色変更

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "  編成No         選択処理　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub txtHenseiNo_SET(ByVal intHenseiNo As Integer)
        Try

            my_FLG = 1 + intHenseiNo                        'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　2:編成No1  3:編成No2  4:編成No3  5:編成No4

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ

            txtHenseiNo1.BackColor = Color.White
            txtHenseiNo2.BackColor = Color.White
            txtHenseiNo3.BackColor = Color.White
            txtHenseiNo4.BackColor = Color.White

            Select Case intHenseiNo
                Case 1
                    txtHenseiNo1.Focus()
                    txtHenseiNo1.BackColor = Color.LightYellow
                Case 2
                    txtHenseiNo2.Focus()
                    txtHenseiNo2.BackColor = Color.LightYellow
                Case 3
                    txtHenseiNo3.Focus()
                    txtHenseiNo3.BackColor = Color.LightYellow
                Case 4
                    txtHenseiNo4.Focus()
                    txtHenseiNo4.BackColor = Color.LightYellow

            End Select

            Call lclBTNColor(txtSyaryouNo.Text)             'ﾎﾞﾀﾝ色変更

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#End Region

#Region "  ﾎﾞﾀﾝ色変更　"

    Private Sub lclBTNColor(ByVal strSYARYOU As String)

        '空文字ﾁｪｯｸ
        If strSYARYOU = "" Then
            Exit Sub
        End If


        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    *"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    XMST_SYARYOU "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XSYARYOU_NO = '" & strSYARYOU & "' "


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
            Exit Sub
        Else
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '積込方法
                If cmdTumiHouhou1.BackColor = Color.GreenYellow Or _
                        cmdTumiHouhou2.BackColor = Color.GreenYellow Or _
                            cmdTumiHouhou3.BackColor = Color.GreenYellow Then

                Else
                    Select Case objRow("XTUMI_HOUHOU")
                        Case XTUMI_HOUHOU_JP
                            '(ﾊﾟﾚｯﾄ積)
                            cmdTumiHouhou3.BackColor = Color.GreenYellow
                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ積)
                            cmdTumiHouhou2.BackColor = Color.GreenYellow

                    End Select
                End If

                '積込方向
                If cmdTumiHoukou1.BackColor = Color.GreenYellow Or _
                          cmdTumiHoukou2.BackColor = Color.GreenYellow Or _
                                cmdTumiHoukou3.BackColor = Color.GreenYellow Then

                Else
                    Select Case objRow("XTUMI_HOUKOU")
                        Case XTUMI_HOUKOU_JBACK
                            '(後積)
                            cmdTumiHoukou1.BackColor = Color.GreenYellow
                        Case XTUMI_HOUKOU_JSIDE
                            '(片横積)
                            cmdTumiHoukou2.BackColor = Color.GreenYellow
                        Case XTUMI_HOUKOU_JWING
                            '(両横積)
                            cmdTumiHoukou3.BackColor = Color.GreenYellow
                    End Select
                End If
            Next
        End If

    End Sub

#End Region

#Region "　積込方法 　 "
#Region "　ﾛｰﾀﾞﾎﾞﾀﾝ         押下処理　"
    Private Sub cmdTumiHouhou1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHouhou1.Click
        Try
            cmdTumiHouhou1.BackColor = Color.GreenYellow    'ﾛｰﾀﾞﾎﾞﾀﾝを色替え
            cmdTumiHouhou2.BackColor = Color.Silver         'ﾊﾞﾗ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHouhou3.BackColor = Color.Silver         'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾞﾗ積みﾎﾞﾀﾝ      押下処理　"
    Private Sub cmdTumiHouhou2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHouhou2.Click
        Try
            cmdTumiHouhou1.BackColor = Color.Silver         'ﾛｰﾀﾞﾎﾞﾀﾝをﾃﾞﾌｫﾙﾄ
            cmdTumiHouhou2.BackColor = Color.GreenYellow    'ﾊﾞﾗ積ﾎﾞﾀﾝ色替え
            cmdTumiHouhou3.BackColor = Color.Silver         'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾊﾟﾚｯﾄ積みﾎﾞﾀﾝ    押下処理　"
    Private Sub cmdTumiHouhou3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHouhou3.Click
        Try
            cmdTumiHouhou1.BackColor = Color.Silver         'ﾛｰﾀﾞﾎﾞﾀﾝをﾃﾞﾌｫﾙﾄ
            cmdTumiHouhou2.BackColor = Color.Silver         'ﾊﾞﾗ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHouhou3.BackColor = Color.GreenYellow    'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝ色替え

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region

#Region "　積込方向 　 "
#Region "　後積みﾎﾞﾀﾝ       押下処理　"
    Private Sub cmdTumiHoukou1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHoukou1.Click
        Try
            cmdTumiHoukou1.BackColor = Color.GreenYellow    '後積みﾎﾞﾀﾝ色替え
            cmdTumiHoukou2.BackColor = Color.Silver         '片横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHoukou3.BackColor = Color.Silver         '両横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "　片横積みﾎﾞﾀﾝ     押下処理　"
    Private Sub cmdTumiHoukou2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHoukou2.Click
        Try
            cmdTumiHoukou1.BackColor = Color.Silver         '後積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHoukou2.BackColor = Color.GreenYellow    '片横積みﾎﾞﾀﾝ色替え
            cmdTumiHoukou3.BackColor = Color.Silver         '両横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "　両横積みﾎﾞﾀﾝ     押下処理　"
    Private Sub cmdTumiHoukou3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTumiHoukou3.Click
        Try
            cmdTumiHoukou1.BackColor = Color.Silver         '後積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHoukou2.BackColor = Color.Silver         '片横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
            cmdTumiHoukou3.BackColor = Color.GreenYellow    '両横積みﾎﾞﾀﾝ色替え

            txtSyaryouNo.BackColor = Color.White            '車輌Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo1.BackColor = Color.White            '編成No1ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo2.BackColor = Color.White            '編成No2ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo3.BackColor = Color.White            '編成No3ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            txtHenseiNo4.BackColor = Color.White            '編成No4ﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ
            my_FLG = 0                                      'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#End Region

#Region "  ｷｰﾎﾞﾀﾝ           押下処理　"
#Region "  cmd0         押下処理　"
    Private Sub cmd0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd0.Click
        Try
            Call BtnCom(mintCMD0)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd1         押下処理　"
    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        Try
            Call BtnCom(mintCMD1)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd2         押下処理　"
    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        Try
            Call BtnCom(mintCMD2)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd3         押下処理　"
    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        Try
            Call BtnCom(mintCMD3)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd4         押下処理　"
    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        Try
            Call BtnCom(mintCMD4)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd5         押下処理　"
    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        Try
            Call BtnCom(mintCMD5)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd6         押下処理　"
    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        Try
            Call BtnCom(mintCMD6)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd7         押下処理　"
    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        Try
            Call BtnCom(mintCMD7)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd8         押下処理　"
    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        Try
            Call BtnCom(mintCMD8)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmd9         押下処理　"
    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        Try
            Call BtnCom(mintCMD9)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "  cmdClear     押下処理　"
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Try
            If my_FLG = 1 Then
                txtSyaryouNo.Text = ""
            ElseIf my_FLG = 2 Then
                txtHenseiNo1.Text = ""
            ElseIf my_FLG = 3 Then
                txtHenseiNo2.Text = ""
            ElseIf my_FLG = 4 Then
                txtHenseiNo3.Text = ""
            ElseIf my_FLG = 5 Then
                txtHenseiNo4.Text = ""
            ElseIf my_FLG = 0 Then
                Call txtSyaryouNo_SET()
                'Dim udtRet As RetPopup
                'udtRet = DisplayPopup(FRM_MSG_FRM2403_01, PopupFormType.Ok, PopupIconType.Information)
                'Exit Sub
            End If
            '**********************************************************
            ' 積込方法ﾎﾞﾀﾝ     ﾘｾｯﾄ
            '**********************************************************
            cmdTumiHouhou1.BackColor = Color.Silver
            cmdTumiHouhou2.BackColor = Color.Silver
            cmdTumiHouhou3.BackColor = Color.Silver

            '**********************************************************
            ' 積込方向ﾎﾞﾀﾝ     ﾘｾｯﾄ
            '**********************************************************
            cmdTumiHoukou1.BackColor = Color.Silver
            cmdTumiHoukou2.BackColor = Color.Silver
            cmdTumiHoukou3.BackColor = Color.Silver

            Call lclBTNColor(txtSyaryouNo.Text)

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  cmdkettei    押下処理　"
    Private Sub cmdkettei_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKettei.Click
        Try

            If my_FLG = 1 Then
                '(車輌No ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ)

                '------------------------------
                ' ﾃﾞﾌｫﾙﾄ値の取得
                '------------------------------
                Call GetDefaultSetting()

                Call lclBTNColor(txtSyaryouNo.Text)     'ﾎﾞﾀﾝ色変更
                my_FLG = 2                              'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　2:編成No1
                Call txtHenseiNo_SET(1)                 '編成No1 ﾃｷｽﾄﾎﾞｯｸｽ選択処理

            ElseIf my_FLG = 2 Then
                '(編成No1 ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ)
                Call lclBTNColor(txtSyaryouNo.Text)     'ﾎﾞﾀﾝ色変更
                my_FLG = 3                              'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　3:編成No2
                Call txtHenseiNo_SET(2)                 '編成No2 ﾃｷｽﾄﾎﾞｯｸｽ選択処理

            ElseIf my_FLG = 3 Then
                '(編成No2 ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ)
                Call lclBTNColor(txtSyaryouNo.Text)     'ﾎﾞﾀﾝ色変更
                my_FLG = 4                              'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　4:編成No3
                Call txtHenseiNo_SET(3)                 '編成No3 ﾃｷｽﾄﾎﾞｯｸｽ選択処理

            ElseIf my_FLG = 4 Then
                '(編成No3 ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ)
                Call lclBTNColor(txtSyaryouNo.Text)     'ﾎﾞﾀﾝ色変更
                my_FLG = 5                              'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　5:編成No4
                Call txtHenseiNo_SET(4)                 '編成No4 ﾃｷｽﾄﾎﾞｯｸｽ選択処理


            ElseIf my_FLG = 5 Then
                '(編成No4 ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ)
                Call lclBTNColor(txtSyaryouNo.Text)     'ﾎﾞﾀﾝ色変更
                txtHenseiNo4.BackColor = Color.White    '編成Noﾃｷｽﾄﾎﾞｯｸｽ背景色ﾃﾞﾌｫﾙﾄ

                cmdTumiHouhou1.Focus()
                my_FLG = 0                              'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "　ｷｰﾎﾞﾀﾝ           共通処理　"
    '*******************************************************************************************************************
    '【機能】
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Sub BtnCom(ByVal strCMD As String)

        'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　0:なし、1:車輌No、2:編成No1、3:編成No2、4:編成No3、5:編成No4
        If my_FLG = 0 Then
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_01, PopupFormType.Ok, PopupIconType.Information)
            Exit Sub

        ElseIf my_FLG = 1 Then
            '(車輌No)
            Select Case txtSyaryouNo.Text.Length
                Case 0
                    txtSyaryouNo.Text = strCMD
                Case 1 To 3
                    txtSyaryouNo.Text &= strCMD
                Case 4
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_02, PopupFormType.Ok, PopupIconType.Err)
                Case Else
            End Select

        ElseIf my_FLG = 2 Then
            '(編成No1)
            Select Case txtHenseiNo1.Text.Length
                Case 0
                    txtHenseiNo1.Text = strCMD
                Case 1 To 3
                    txtHenseiNo1.Text &= strCMD
                Case 4
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_02, PopupFormType.Ok, PopupIconType.Err)
                Case Else
            End Select

        ElseIf my_FLG = 3 Then
            '(編成No2)
            Select Case txtHenseiNo2.Text.Length
                Case 0
                    txtHenseiNo2.Text = strCMD
                Case 1 To 3
                    txtHenseiNo2.Text &= strCMD
                Case 4
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_02, PopupFormType.Ok, PopupIconType.Err)
                Case Else
            End Select

        ElseIf my_FLG = 4 Then
            '(編成No3)
            Select Case txtHenseiNo3.Text.Length
                Case 0
                    txtHenseiNo3.Text = strCMD
                Case 1 To 3
                    txtHenseiNo3.Text &= strCMD
                Case 4
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_02, PopupFormType.Ok, PopupIconType.Err)
                Case Else
            End Select

        ElseIf my_FLG = 5 Then
            '(編成No4)
            Select Case txtHenseiNo4.Text.Length
                Case 0
                    txtHenseiNo4.Text = strCMD
                Case 1 To 3
                    txtHenseiNo4.Text &= strCMD
                Case 4
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_02, PopupFormType.Ok, PopupIconType.Err)
                Case Else
            End Select


        End If

    End Sub

#End Region

#Region "  登録             押下処理　"
    Private Sub cmdtouroku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTouroku.Click
        Try
            '*******************************************************
            ' 車輌番号
            '*******************************************************
            If InputCheck(menmCheckCase.cmdTouroku_Click) = False Then
                Exit Sub
            End If

            '*******************************************************
            ' ｿｹｯﾄ送信
            '*******************************************************
            If SendSock_400102() = False Then
                Exit Sub
            End If

            '*******************************************************
            ' 初期化
            '*******************************************************
            txtSyaryouNo.Text = ""
            txtHenseiNo1.Text = ""
            txtHenseiNo2.Text = ""
            txtHenseiNo3.Text = ""
            txtHenseiNo4.Text = ""
            txtHenseiNo1.BackColor = Color.White
            txtHenseiNo2.BackColor = Color.White
            txtHenseiNo3.BackColor = Color.White
            txtHenseiNo4.BackColor = Color.White
            cmdTumiHoukou1.BackColor = Color.Silver
            cmdTumiHoukou2.BackColor = Color.Silver
            cmdTumiHoukou3.BackColor = Color.Silver
            cmdTumiHouhou1.BackColor = Color.Silver
            cmdTumiHouhou2.BackColor = Color.Silver
            cmdTumiHouhou3.BackColor = Color.Silver


            txtSyaryouNo.Focus()
            txtSyaryouNo.BackColor = Color.LightYellow
            my_FLG = 1                                          'ﾃｷｽﾄﾎﾞｯｸｽ選択ﾌﾗｸﾞ　1:車輌No

        Catch ex As Exception
            ComError(ex)

        End Try
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
    Protected Overridable Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.cmdTouroku_Click
                '(登録の場合)

                '*******************************************************
                ' 車輌番号
                '*******************************************************
                'If txtSyaryouNo.Text.Length <> 4 Then
                '    Call DisplayPopup(FRM_MSG_FRM2403_03, PopupFormType.Ok, PopupIconType.Err)
                '    Exit Sub
                'end if

                '*******************************************************
                ' 編成番号
                '*******************************************************
                If txtHenseiNo1.Text = "" And _
                    txtHenseiNo2.Text = "" And _
                    txtHenseiNo3.Text = "" And _
                    txtHenseiNo4.Text = "" Then
                    '(全て空の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_03, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If

                If txtHenseiNo1.Text <> "" And txtHenseiNo1.Text.Length <> 4 Then
                    '(編成No1が4桁)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_03, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If

                If txtHenseiNo2.Text <> "" And txtHenseiNo2.Text.Length <> 4 Then
                    '(編成No2が4桁)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_03, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If

                If txtHenseiNo3.Text <> "" And txtHenseiNo3.Text.Length <> 4 Then
                    '(編成No3が4桁)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_03, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If

                If txtHenseiNo4.Text <> "" And txtHenseiNo4.Text.Length <> 4 Then
                    '(編成No4が4桁)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_03, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If

                '*******************************************************
                ' 積込方法
                '*******************************************************
                If cmdTumiHouhou1.BackColor = Color.Silver And _
                    cmdTumiHouhou2.BackColor = Color.Silver And _
                    cmdTumiHouhou3.BackColor = Color.Silver Then
                    '(未選択の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_04, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
                End If


                '*******************************************************
                ' 積込方向
                '*******************************************************
                If cmdTumiHoukou1.BackColor = Color.GreenYellow And _
                    cmdTumiHoukou2.BackColor = Color.GreenYellow And _
                    cmdTumiHoukou3.BackColor = Color.GreenYellow Then
                    '(未選択の場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311020_04, PopupFormType.Ok, PopupIconType.Err)
                    Exit Function
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

#Region "  車輌受付送信         （ID : 400102）"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSock_400102() As Boolean

        '' ''*******************************************************
        '' ''確認ﾒｯｾｰｼﾞ
        '' ''*******************************************************
        ' ''Dim udtRet As RetPopup
        ' ''Dim strMessage As String
        ' ''strMessage = ""
        ' ''strMessage &= "車輌受付" & FRM_MSG_FRM200000_01
        ' ''udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        ' ''If udtRet <> RetPopup.OK Then
        ' ''    Exit Sub
        ' ''End If

        Dim blnRet As Boolean = False

        '*******************************************************
        '送信ﾃﾞｰﾀ
        '*******************************************************
        Dim strSYARYOU_NO As String     '車輌No.
        Dim strHENSEI_NO1 As String     '編成No.1
        Dim strHENSEI_NO2 As String     '編成No.2
        Dim strHENSEI_NO3 As String     '編成No.3
        Dim strHENSEI_NO4 As String     '編成No.4
        Dim strTUMI_HOUHOU As String    '積込方法
        Dim strTUMI_HOUKOU As String    '積込方向

        strSYARYOU_NO = txtSyaryouNo.Text
        strHENSEI_NO1 = txtHenseiNo1.Text
        strHENSEI_NO2 = txtHenseiNo2.Text
        strHENSEI_NO3 = txtHenseiNo3.Text
        strHENSEI_NO4 = txtHenseiNo4.Text

        '積込方法
        strTUMI_HOUHOU = ""
        If cmdTumiHouhou1.BackColor = Color.GreenYellow Then
            strTUMI_HOUHOU = TO_STRING(XTUMI_HOUHOU_JL)
        ElseIf cmdTumiHouhou2.BackColor = Color.GreenYellow Then
            strTUMI_HOUHOU = TO_STRING(XTUMI_HOUHOU_JB)
        ElseIf cmdTumiHouhou3.BackColor = Color.GreenYellow Then
            strTUMI_HOUHOU = TO_STRING(XTUMI_HOUHOU_JP)
        End If

        '積込方向
        strTUMI_HOUKOU = ""
        If cmdTumiHoukou1.BackColor = Color.GreenYellow Then
            strTUMI_HOUKOU = TO_STRING(XTUMI_HOUKOU_JBACK)
        ElseIf cmdTumiHoukou2.BackColor = Color.GreenYellow Then
            strTUMI_HOUKOU = TO_STRING(XTUMI_HOUKOU_JSIDE)
        ElseIf cmdTumiHoukou3.BackColor = Color.GreenYellow Then
            strTUMI_HOUKOU = TO_STRING(XTUMI_HOUKOU_JWING)
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400102    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPSYARYOU_NO", strSYARYOU_NO)         '車輌No.
        objTelegram.SETIN_DATA("XDSPHENSEI_NO1", strHENSEI_NO1)         '編成No.1
        objTelegram.SETIN_DATA("XDSPHENSEI_NO2", strHENSEI_NO2)         '編成No.2
        objTelegram.SETIN_DATA("XDSPHENSEI_NO3", strHENSEI_NO3)         '編成No.3
        objTelegram.SETIN_DATA("XDSPHENSEI_NO4", strHENSEI_NO4)         '編成No.4
        objTelegram.SETIN_DATA("XDSPTUMI_HOUKOU", strTUMI_HOUKOU)       '積込方向
        objTelegram.SETIN_DATA("XDSPTUMI_HOUHOU", strTUMI_HOUHOU)       '積込方法

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        SendSock_400102 = blnRet

    End Function
#End Region

#Region "  積込方法、方向のﾃﾞﾌｫﾙﾄ設定値の取得           "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 積込方法、方向のﾃﾞﾌｫﾙﾄ設定値の取得
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub GetDefaultSetting()

        Try
            Dim intRet As Integer
            Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(gobjOwner, gobjDb, Nothing)

            If txtSyaryouNo.Text <> "" Then
                objXMST_SYARYOU.XSYARYOU_NO = txtSyaryouNo.Text                  '車輌番号
                intRet = objXMST_SYARYOU.GET_XMST_SYARYOU(False)
                If intRet = RetCode.OK Then
                    '(一致した場合)
                    Dim intXTUMI_HOUHOU As Integer  '積込方法
                    intXTUMI_HOUHOU = objXMST_SYARYOU.XTUMI_HOUHOU

                    Dim intXTUMI_HOUKOU As Integer  '積込方向
                    intXTUMI_HOUKOU = objXMST_SYARYOU.XTUMI_HOUKOU

                    '--------------------
                    '積込方法
                    '--------------------
                    Select Case intXTUMI_HOUHOU
                        Case XTUMI_HOUHOU_JL
                            '(ﾛｰﾀﾞ)
                            cmdTumiHouhou1.BackColor = Color.GreenYellow    'ﾛｰﾀﾞﾎﾞﾀﾝを色替え
                            cmdTumiHouhou2.BackColor = Color.Silver         'ﾊﾞﾗ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHouhou3.BackColor = Color.Silver         'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

                        Case XTUMI_HOUHOU_JB
                            '(ﾊﾞﾗ)
                            cmdTumiHouhou1.BackColor = Color.Silver         'ﾛｰﾀﾞﾎﾞﾀﾝをﾃﾞﾌｫﾙﾄ
                            cmdTumiHouhou2.BackColor = Color.GreenYellow    'ﾊﾞﾗ積ﾎﾞﾀﾝ色替え
                            cmdTumiHouhou3.BackColor = Color.Silver         'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

                        Case XTUMI_HOUHOU_JP
                            '(ﾊﾟﾚｯﾄ)
                            cmdTumiHouhou1.BackColor = Color.Silver         'ﾛｰﾀﾞﾎﾞﾀﾝをﾃﾞﾌｫﾙﾄ
                            cmdTumiHouhou2.BackColor = Color.Silver         'ﾊﾞﾗ積ﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHouhou3.BackColor = Color.GreenYellow    'ﾊﾟﾚｯﾄ積ﾎﾞﾀﾝ色替え

                    End Select


                    '--------------------
                    '積込方向
                    '--------------------
                    Select Case intXTUMI_HOUKOU
                        Case XTUMI_HOUKOU_JBACK
                            '(後積み)
                            cmdTumiHoukou1.BackColor = Color.GreenYellow    '後積みﾎﾞﾀﾝ色替え
                            cmdTumiHoukou2.BackColor = Color.Silver         '片横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHoukou3.BackColor = Color.Silver         '両横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

                        Case XTUMI_HOUKOU_JSIDE
                            '(片横積み)
                            cmdTumiHoukou1.BackColor = Color.Silver         '後積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHoukou2.BackColor = Color.GreenYellow    '片横積みﾎﾞﾀﾝ色替え
                            cmdTumiHoukou3.BackColor = Color.Silver         '両横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ

                        Case XTUMI_HOUKOU_JWING
                            '(両横積み)
                            cmdTumiHoukou1.BackColor = Color.Silver         '後積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHoukou2.BackColor = Color.Silver         '片横積みﾎﾞﾀﾝﾃﾞﾌｫﾙﾄ
                            cmdTumiHoukou3.BackColor = Color.GreenYellow    '両横積みﾎﾞﾀﾝ色替え

                    End Select

                End If

            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region



End Class
