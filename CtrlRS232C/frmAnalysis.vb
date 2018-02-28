'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】改善提案
' 【機能】RS232C通信ﾃｽﾄ用ﾌﾟﾛｸﾞﾗﾑ
' 【作成】2012/01/30  SIT  Rev 0.00
'**********************************************************************************************

#Region "  Imports          "
Imports System.Text
Imports JobCommon
Imports MateCommon
Imports UserProcess
Imports MateCommon.clsConst
Imports MateCommon.mdlComFunc
#End Region

Public Class frmAnalysis

#Region "  共通変数                             "
    Private mobjRS232C As frmRS232C
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                              "
    ''' <summary>
    ''' 親ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
    ''' </summary>
    Public Property objRS232C() As frmRS232C
        Get
            Return mobjRS232C
        End Get
        Set(ByVal Value As frmRS232C)
            mobjRS232C = Value
        End Set
    End Property
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ                             "
    Private Sub frmAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            txtLineEyeTextFile.AllowDrop = True
            txtTextFile02.AllowDrop = True
            txtTelegramAnalysis01.AllowDrop = True
            txtTelegramAnalysis02.AllowDrop = True

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾄﾞﾗｯｸﾞ & ﾄﾞﾛｯﾌﾟ でﾌｧｲﾙﾊﾟｽを取得      "

    '******************************************************
    'ﾌｧｲﾙﾊﾟｽ
    '******************************************************
    Private Sub txtLineEyeTextFile_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLineEyeTextFile.DragEnter
        Try

            'ファイル形式の場合のみ、ドラッグを受け付けます。
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub

    Private Sub txtLineEyeTextFile_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLineEyeTextFile.DragDrop
        Try

            'ドラッグされたファイル・フォルダのパスを格納します。
            Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

            'ファイルの存在確認を行い、ある場合にのみ、
            'テキストボックスにパスを表示します。
            '（この処理でフォルダを対象外にしています。）
            If System.IO.File.Exists(strFileName(0).ToString) = True Then
                Me.txtLineEyeTextFile.Text = strFileName(0).ToString
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub


    '******************************************************
    'ﾌｧｲﾙﾊﾟｽ2
    '******************************************************
    Private Sub txtTextFile02_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTextFile02.DragEnter
        Try

            'ファイル形式の場合のみ、ドラッグを受け付けます。
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub

    Private Sub txtTextFile02_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTextFile02.DragDrop
        Try

            'ドラッグされたファイル・フォルダのパスを格納します。
            Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

            'ファイルの存在確認を行い、ある場合にのみ、
            'テキストボックスにパスを表示します。
            '（この処理でフォルダを対象外にしています。）
            If System.IO.File.Exists(strFileName(0).ToString) = True Then
                Me.txtTextFile02.Text = strFileName(0).ToString
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

#End Region
#Region "  ﾄﾞﾗｯｸﾞ & ﾄﾞﾛｯﾌﾟ でﾃｷｽﾄを取得         "

    '分解電文01
    Private Sub txtTelegramAnalysis01_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis01.DragDrop
        txtTelegramAnalysis01.Text = e.Data.GetData(DataFormats.Text).ToString
    End Sub
    Private Sub txtTelegramAnalysis01_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis01.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    '分解電文02
    Private Sub txtTelegramAnalysis02_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis02.DragDrop
        txtTelegramAnalysis02.Text = e.Data.GetData(DataFormats.Text).ToString
    End Sub
    Private Sub txtTelegramAnalysis02_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTelegramAnalysis02.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

#End Region
#Region "  時系列にﾌｧｲﾙ出力             ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
        Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '初期設定
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""        '送信電文01ﾃｷｽﾄ
            Dim strSD02 As String = ""        '送信電文02ﾃｷｽﾄ
            Dim strRD01 As String = ""        '受信電文01ﾃｷｽﾄ
            Dim strRD02 As String = ""        '受信電文02ﾃｷｽﾄ


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'ﾌｧｲﾙ読込
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Try
                While (objSR01.Peek >= 0)
                    '(ﾙｰﾌﾟ:読込不可となるまで)


                    '**************************************
                    '一行目、二行目読込
                    '**************************************
                    Dim blnSD As Boolean = False    '送信ﾃｷｽﾄﾌﾗｸﾞ
                    Dim blnRD As Boolean = False    '受信ﾃｷｽﾄﾌﾗｸﾞ
                    Dim strTemp01 As String = objSR01.ReadLine()    '一行目ﾃｷｽﾄ
                    If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
                        '(送信電文の場合)
                        blnSD = True
                    ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
                        '(受信電文の場合)
                        blnRD = True
                    Else
                        Continue While
                    End If
                    Dim strTemp02 As String = objSR01.ReadLine()    '二行目ﾃｷｽﾄ


                    '**************************************
                    'ﾃｷｽﾄ編集
                    '**************************************
                    strTemp01 = MidD(strTemp01, 4)      '送信電文ﾃｷｽﾄ
                    strTemp02 = MidD(strTemp02, 4)      '送信電文ﾃｷｽﾄ
                    strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '送信電文ﾃｷｽﾄ
                    strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '受信電文ﾃｷｽﾄ



                    '**************************************
                    'ﾃｷｽﾄ合体
                    '**************************************
                    If blnSD = True Then
                        '(送信電文の場合)
                        strSD01 &= strTemp01
                        strSD02 &= strTemp02
                    ElseIf blnRD = True Then
                        '(受信電文の場合)
                        strRD01 &= strTemp01
                        strRD02 &= strTemp02
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '一回目ﾌｧｲﾙ出力
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '***********************
            'StreamWriter   作成
            '***********************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           'ﾊﾟｽ
            Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '拡張子を含まないﾌｧｲﾙ名
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '拡張子
            'System.IO.Directory.CreateDirectory(strFilePath)        'ﾌｫﾙﾀﾞの作成
            Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Try
                objSW01.WriteLine(strSD01)          '追加
                objSW01.WriteLine(strSD02)          '追加
                'objSW01.Write(strRD01)          '追加
                'objSW01.Write(strRD02)          '追加
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '[ TMSP ]を置換
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strSD01_Origin As String = strSD01        '送信電文01ﾃｷｽﾄ
            'Dim strSD02_Origin As String = strSD02        '送信電文02ﾃｷｽﾄ
            'Dim strRD01_Origin As String = strRD01        '受信電文01ﾃｷｽﾄ
            'Dim strRD02_Origin As String = strRD02        '受信電文02ﾃｷｽﾄ
            For ii As Integer = 1 To strSD01.Length - 8
                '(ﾙｰﾌﾟ:置換可能な文字数)

                If MidD(strSD01, ii, 8) = TMSP Then
                    '([ TMSP ]の場合)

                    If ii = 1 Then
                        strSD01 = MidD(strSD02, ii, 8) & MidD(strSD01, 9)
                        strRD01 = MidD(strSD02, ii, 8) & MidD(strRD01, 9)
                        strRD02 = MidD(strSD02, ii, 8) & MidD(strRD02, 9)
                    Else
                        strSD01 = MidD(strSD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strSD01, ii + 8)
                        strRD01 = MidD(strRD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD01, ii + 8)
                        strRD02 = MidD(strRD02, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD02, ii + 8)
                    End If

                End If


                '***********************
                '進捗表示
                '***********************
                If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                End If


            Next


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '電文毎に一行にする
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_02" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            'ｶｽﾀﾏｲｽﾞ

            Dim objSW03 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_91" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Dim strReadCommand(0) As String

            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""
                Dim strSDTemp02 As String = ""
                Dim strRDTemp01 As String = ""
                Dim strRDTemp02 As String = ""
                For ii As Integer = 1 To strSD01.Length
                    '(ﾙｰﾌﾟ:文字列の長さ)


                    '**********************************************
                    'ﾌｧｲﾙ出力       判定
                    '**********************************************
                    Dim blnOutFile As Boolean = False
                    If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
                        '(時間ﾃﾞｰﾀが入っている可能性がある場合)

                        If rdoMakeFileNon.Checked Then
                            '(時間ﾃﾞｰﾀ毎に区切る場合)

                            If MidD(strSD01, ii, 1) = "[" _
                               And MidD(strSD01, ii + 7, 1) = "]" _
                               And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                               Then
                                '(時間ﾃﾞｰﾀが入っている場合)
                                blnOutFile = True
                            End If

                        ElseIf rdoMakeFileSend.Checked Then
                            '(送信-受信ｾｯﾄの場合)

                            If MidD(strSD01, ii, 1) = "[" _
                               And MidD(strSD01, ii + 7, 3) <> "] -" _
                               And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                               Then
                                '(時間ﾃﾞｰﾀが入っている場合)
                                blnOutFile = True
                            End If

                        ElseIf rdoMakeFileRecv.Checked Then
                            '(受信-送信ｾｯﾄの場合)

                            If MidD(strRD01, ii, 1) = "[" _
                               And MidD(strRD01, ii + 7, 3) <> "] -" _
                               And IsDate("2000/01/01 " & MidD(strRD01, ii + 1, 2) & ":" & MidD(strRD01, ii + 3, 2) & ":" & MidD(strRD01, ii + 5, 2)) _
                               Then
                                '(時間ﾃﾞｰﾀが入っている場合)
                                blnOutFile = True
                            End If

                        End If


                    End If


                    '**********************************************
                    'ﾌｧｲﾙ出力
                    '**********************************************
                    If blnOutFile = True Then
                        '(ﾌｧｲﾙ出力するの場合)

                        If chkBinary.Checked = True Then objSW02.WriteLine(strSDTemp01.ToString) '追加
                        If chkAscii.Checked = True Then objSW02.WriteLine(strSDTemp02.ToString) '追加
                        If chkBinary.Checked = True Then objSW02.WriteLine(strRDTemp01.ToString) '追加
                        If chkAscii.Checked = True Then objSW02.WriteLine(strRDTemp02.ToString) '追加
                        objSW02.WriteLine("")               '追加(改行)

                        '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                        '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                        'ｶｽﾀﾏｲｽﾞ

                        ''読込みｺﾏﾝﾄﾞ取得02(ﾘｰﾄﾞｱﾄﾞﾚｽ一覧)
                        'Dim strTemp As String = Mid(strSDTemp01, 13, 4)
                        'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                        '    objSW03.WriteLine(TO_STRING(40001 + Change16To10(strTemp)))
                        '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                        '    strReadCommand(UBound(strReadCommand)) = strTemp
                        'End If

                        ''読込みｺﾏﾝﾄﾞ取得01(ﾘｰﾄﾞｺﾏﾝﾄﾞ一覧)
                        'Dim strTemp As String = Mid(strSDTemp01, 8, 9)
                        'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                        '    objSW03.WriteLine(strSDTemp01)
                        '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                        '    strReadCommand(UBound(strReadCommand)) = strTemp
                        'End If

                        '書込みｺﾏﾝﾄﾞ取得01
                        'If 1 <= InStr(strSDTemp01, "]0310") And InStr(strSDTemp01, "]0310206C") = 0 Then
                        '    objSW03.WriteLine(strSDTemp01)
                        'End If

                        '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
                        '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************

                        strSDTemp01 = ""       '初期化
                        strSDTemp02 = ""       '初期化
                        strRDTemp01 = ""       '初期化
                        strRDTemp02 = ""       '初期化

                    End If


                    '***********************
                    '一文字ずつ抜き出し
                    '***********************
                    strSDTemp01 &= (MidD(strSD01, ii, 1))
                    strSDTemp02 &= (MidD(strSD02, ii, 1))
                    strRDTemp01 &= (MidD(strRD01, ii, 1))
                    strRDTemp02 &= (MidD(strRD02, ii, 1))


                    '***********************
                    'ﾌｧｲﾙ出力
                    '***********************
                    If ii = strSD01.Length Then
                        '(ﾃﾞｰﾀが終わった場合)
                        objSW02.WriteLine(strSDTemp01.ToString)          '追加
                        objSW02.WriteLine(strSDTemp02.ToString)          '追加
                        objSW02.WriteLine(strRDTemp01.ToString)          '追加
                        objSW02.WriteLine(strRDTemp02.ToString)          '追加
                    End If


                    '***********************
                    '進捗表示
                    '***********************
                    If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                        lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02.Close()
                objSW03.Close()
            End Try


            ''**************************************
            ''ﾌｧｲﾙ読込
            ''**************************************
            'Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            'objSR01.ReadLine()    '一行取得
            'objSR01.ReadLine()    '一行取得
            'Dim strDBBackupPath As String = Trim(MidD(objSR01.ReadLine(), 4))
            'If System.IO.Directory.Exists(strDBBackupPath) = False Then
            '    '(ﾌｫﾙﾀﾞが存在しない場合)
            '    Call AddToMsgLog(Now, FMSG_ID_S9002, "外付けHDDのﾊﾞｯｸｱｯﾌﾟ先が認識出来ません。", "「" & strDBBackupPath & "」が見つかりません")
            '    Return RetCode.OK
            'End If





        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾃｰﾌﾞﾙに追加                  ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdDBInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDBInsert.Click
        Try
            Dim strMsg As String = ""
            Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '初期設定
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""        '送信電文01ﾃｷｽﾄ
            Dim strSD02 As String = ""        '送信電文02ﾃｷｽﾄ
            Dim strRD01 As String = ""        '受信電文01ﾃｷｽﾄ
            Dim strRD02 As String = ""        '受信電文02ﾃｷｽﾄ

            '===============================================
            '色々ﾁｪｯｸ
            '===============================================
            If IsDate(txtInsertDate.Text) = False Then
                strMsg = "日付設定を行って下さい。"
                MsgBox(strMsg)
                Throw New Exception(strMsg)
            End If

            '===============================================
            'DB接続
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB接続ｴﾗｰ")

            '===============================================
            'ﾃｰﾌﾞﾙｸﾗｽ定義 & ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '===============================================
            Dim objXLOG_MODBUS As New TBL_XLOG_MODBUS(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'ﾌｧｲﾙ読込
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Try
                While (objSR01.Peek >= 0)
                    '(ﾙｰﾌﾟ:読込不可となるまで)


                    '**************************************
                    '一行目、二行目読込
                    '**************************************
                    Dim blnSD As Boolean = False    '送信ﾃｷｽﾄﾌﾗｸﾞ
                    Dim blnRD As Boolean = False    '受信ﾃｷｽﾄﾌﾗｸﾞ
                    Dim strTemp01 As String = objSR01.ReadLine()    '一行目ﾃｷｽﾄ
                    If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
                        '(送信電文の場合)
                        blnSD = True
                    ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
                        '(受信電文の場合)
                        blnRD = True
                    Else
                        Continue While
                    End If
                    Dim strTemp02 As String = objSR01.ReadLine()    '二行目ﾃｷｽﾄ


                    '**************************************
                    'ﾃｷｽﾄ編集
                    '**************************************
                    strTemp01 = MidD(strTemp01, 4)      '送信電文ﾃｷｽﾄ
                    strTemp02 = MidD(strTemp02, 4)      '送信電文ﾃｷｽﾄ
                    strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '送信電文ﾃｷｽﾄ
                    strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '受信電文ﾃｷｽﾄ



                    '**************************************
                    'ﾃｷｽﾄ合体
                    '**************************************
                    If blnSD = True Then
                        '(送信電文の場合)
                        strSD01 &= strTemp01
                        strSD02 &= strTemp02
                    ElseIf blnRD = True Then
                        '(受信電文の場合)
                        strRD01 &= strTemp01
                        strRD02 &= strTemp02
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '一回目ﾌｧｲﾙ出力
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '***********************
            'StreamWriter   作成
            '***********************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           'ﾊﾟｽ
            Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '拡張子を含まないﾌｧｲﾙ名
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '拡張子
            'System.IO.Directory.CreateDirectory(strFilePath)        'ﾌｫﾙﾀﾞの作成
            Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Try
                objSW01.WriteLine(strSD01)          '追加
                objSW01.WriteLine(strSD02)          '追加
                'objSW01.Write(strRD01)          '追加
                'objSW01.Write(strRD02)          '追加
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '[ TMSP ]を置換
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strSD01_Origin As String = strSD01        '送信電文01ﾃｷｽﾄ
            'Dim strSD02_Origin As String = strSD02        '送信電文02ﾃｷｽﾄ
            'Dim strRD01_Origin As String = strRD01        '受信電文01ﾃｷｽﾄ
            'Dim strRD02_Origin As String = strRD02        '受信電文02ﾃｷｽﾄ
            For ii As Integer = 1 To strSD01.Length - 8
                '(ﾙｰﾌﾟ:置換可能な文字数)

                If MidD(strSD01, ii, 8) = TMSP Then
                    '([ TMSP ]の場合)

                    If ii = 1 Then
                        strSD01 = MidD(strSD02, ii, 8) & MidD(strSD01, 9)
                        strRD01 = MidD(strSD02, ii, 8) & MidD(strRD01, 9)
                        strRD02 = MidD(strSD02, ii, 8) & MidD(strRD02, 9)
                    Else
                        strSD01 = MidD(strSD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strSD01, ii + 8)
                        strRD01 = MidD(strRD01, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD01, ii + 8)
                        strRD02 = MidD(strRD02, 1, ii - 1) & MidD(strSD02, ii, 8) & MidD(strRD02, ii + 8)
                    End If

                End If


                '***********************
                '進捗表示
                '***********************
                If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                    Me.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                End If


            Next


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '電文毎に一行にする
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_02" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            'ｶｽﾀﾏｲｽﾞ

            Dim objSW03 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtension _
                                                      & "_91" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Dim strReadCommand(0) As String

            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""
                Dim strSDTemp02 As String = ""
                Dim strRDTemp01 As String = ""
                Dim strRDTemp02 As String = ""
                For ii As Integer = 1 To strSD01.Length
                    '(ﾙｰﾌﾟ:文字列の長さ)
                    Try


                        '**********************************************
                        'ﾌｧｲﾙ出力       判定
                        '**********************************************
                        Dim blnOutFile As Boolean = False
                        If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
                            '(時間ﾃﾞｰﾀが入っている可能性がある場合)

                            If rdoMakeFileNon.Checked Then
                                '(時間ﾃﾞｰﾀ毎に区切る場合)

                                If MidD(strSD01, ii, 1) = "[" _
                                   And MidD(strSD01, ii + 7, 1) = "]" _
                                   And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                                   Then
                                    '(時間ﾃﾞｰﾀが入っている場合)
                                    blnOutFile = True
                                End If

                            ElseIf rdoMakeFileSend.Checked Then
                                '(送信-受信ｾｯﾄの場合)

                                If MidD(strSD01, ii, 1) = "[" _
                                   And MidD(strSD01, ii + 7, 3) <> "] -" _
                                   And IsDate("2000/01/01 " & MidD(strSD01, ii + 1, 2) & ":" & MidD(strSD01, ii + 3, 2) & ":" & MidD(strSD01, ii + 5, 2)) _
                                   Then
                                    '(時間ﾃﾞｰﾀが入っている場合)
                                    blnOutFile = True
                                End If

                            ElseIf rdoMakeFileRecv.Checked Then
                                '(受信-送信ｾｯﾄの場合)

                                If MidD(strRD01, ii, 1) = "[" _
                                   And MidD(strRD01, ii + 7, 3) <> "] -" _
                                   And IsDate("2000/01/01 " & MidD(strRD01, ii + 1, 2) & ":" & MidD(strRD01, ii + 3, 2) & ":" & MidD(strRD01, ii + 5, 2)) _
                                   Then
                                    '(時間ﾃﾞｰﾀが入っている場合)
                                    blnOutFile = True
                                End If

                            End If


                        End If


                        '**********************************************
                        'ﾌｧｲﾙ出力
                        '**********************************************
                        If blnOutFile = True Then
                            '(ﾌｧｲﾙ出力するの場合)

                            If chkBinary.Checked = True Then objSW02.WriteLine(strSDTemp01.ToString) '追加
                            If chkAscii.Checked = True Then objSW02.WriteLine(strSDTemp02.ToString) '追加
                            If chkBinary.Checked = True Then objSW02.WriteLine(strRDTemp01.ToString) '追加
                            If chkAscii.Checked = True Then objSW02.WriteLine(strRDTemp02.ToString) '追加
                            objSW02.WriteLine("")               '追加(改行)

                            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                            'ﾃｰﾌﾞﾙに追加

                            Try


                                '********************************************************************************************
                                'PC →PLC       電文取得
                                '********************************************************************************************
                                Dim strInsertDateSend As String = txtInsertDate.Text & Space(1) & MidD(strSDTemp01, 2, 2) & ":" & MidD(strSDTemp01, 4, 2) & ":" & MidD(strSDTemp01, 6, 2)       '発生日時取得(PC →PLC)
                                Dim dtmInsertDateSend As Date = CDate(strInsertDateSend)                                                                                                        '発生日時取得(PC →PLC)
                                Dim intStart02 As Integer = InStr(9, strSDTemp01, "[")          '二つ目の「 [ 」の位置を取得
                                Dim strTelSend As String = Mid(strSDTemp01, 9, intStart02 - 9)  'PC→PLC        電文


                                '********************************************************************************************
                                'PLC→PC        電文取得
                                '********************************************************************************************
                                Dim strInsertDateRecv As String = txtInsertDate.Text & Space(1) & MidD(strRDTemp01, intStart02 + 1, 2) & ":" & MidD(strRDTemp01, intStart02 + 3, 2) & ":" & MidD(strRDTemp01, intStart02 + 5, 2)    '発生日時取得(PLC→PC)
                                Dim dtmInsertDateRecv As Date = CDate(strInsertDateRecv)                                                                                                                                            '発生日時取得(PC →PLC)
                                Dim strTelRecv As String = Mid(strRDTemp01, intStart02 + 8)               'PLC→PC        電文


                                '********************************************************************************************
                                'ﾃｰﾌﾞﾙに追加ﾁｪｯｸ
                                '********************************************************************************************
                                Dim blnInsert As Boolean = True     '追加ﾌﾗｸﾞ
                                If chkCheckSame.Checked = True Then
                                    '(同一ﾚｺｰﾄﾞは追加しない場合)
                                    objXLOG_MODBUS.CLEAR_PROPERTY()
                                    objXLOG_MODBUS.FLOG_CHECK_DT1 = dtmInsertDateSend
                                    objXLOG_MODBUS.FLOG_CHECK_DT2 = dtmInsertDateRecv
                                    objXLOG_MODBUS.FDENBUN = strTelSend
                                    objXLOG_MODBUS.FDENBUN02 = strTelRecv
                                    intRet = objXLOG_MODBUS.GET_XLOG_MODBUS(False)
                                    If intRet = RetCode.OK Then
                                        '(見つかった場合)
                                        blnInsert = False
                                        Call AddToLog("同一ﾚｺｰﾄﾞが見つかった為、ﾚｺｰﾄﾞは追加しません。[確認日時_1:" & dtmInsertDateSend & "]" _
                                                                                                  & "[確認日時_2:" & dtmInsertDateRecv & "]" _
                                                                                                  & "[通信電文:" & strTelSend & "]" _
                                                                                                  & "[通信電文02:" & strTelRecv & "]" _
                                                                                                    )
                                    End If
                                End If



                                '********************************************************************************************
                                'ﾃｰﾌﾞﾙに追加
                                '********************************************************************************************
                                If blnInsert = True Then
                                    '(追加する場合)
                                    objXLOG_MODBUS.CLEAR_PROPERTY()
                                    objXLOG_MODBUS.FLOG_CHECK_DT1 = dtmInsertDateSend       '確認日時_1
                                    objXLOG_MODBUS.FLOG_CHECK_DT2 = dtmInsertDateRecv       '確認日時_2
                                    objXLOG_MODBUS.FDENBUN = strTelSend                     '通信電文
                                    objXLOG_MODBUS.FDENBUN02 = strTelRecv                   '通信電文02
                                    objXLOG_MODBUS.ADD_XLOG_MODBUS_SEQ()
                                End If


                            Catch ex As Exception
                                ComError(ex)

                            End Try

                            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
                            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************



                            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
                            'ｶｽﾀﾏｲｽﾞ

                            ''読込みｺﾏﾝﾄﾞ取得02(ﾘｰﾄﾞｱﾄﾞﾚｽ一覧)
                            'Dim strTemp As String = Mid(strSDTemp01, 13, 4)
                            'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                            '    objSW03.WriteLine(TO_STRING(40001 + Change16To10(strTemp)))
                            '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                            '    strReadCommand(UBound(strReadCommand)) = strTemp
                            'End If

                            ''読込みｺﾏﾝﾄﾞ取得01(ﾘｰﾄﾞｺﾏﾝﾄﾞ一覧)
                            'Dim strTemp As String = Mid(strSDTemp01, 8, 9)
                            'If ArrayFindData(strReadCommand, strTemp) = -1 And InStr(strSDTemp01, "]0310") = 0 Then
                            '    objSW03.WriteLine(strSDTemp01)
                            '    ReDim Preserve strReadCommand(UBound(strReadCommand) + 1)
                            '    strReadCommand(UBound(strReadCommand)) = strTemp
                            'End If

                            '書込みｺﾏﾝﾄﾞ取得01
                            'If 1 <= InStr(strSDTemp01, "]0310") And InStr(strSDTemp01, "]0310206C") = 0 Then
                            '    objSW03.WriteLine(strSDTemp01)
                            'End If

                            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
                            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************

                            strSDTemp01 = ""       '初期化
                            strSDTemp02 = ""       '初期化
                            strRDTemp01 = ""       '初期化
                            strRDTemp02 = ""       '初期化

                        End If


                        '***********************
                        '一文字ずつ抜き出し
                        '***********************
                        strSDTemp01 &= (MidD(strSD01, ii, 1))
                        strSDTemp02 &= (MidD(strSD02, ii, 1))
                        strRDTemp01 &= (MidD(strRD01, ii, 1))
                        strRDTemp02 &= (MidD(strRD02, ii, 1))


                        '***********************
                        'ﾌｧｲﾙ出力
                        '***********************
                        If ii = strSD01.Length Then
                            '(ﾃﾞｰﾀが終わった場合)
                            objSW02.WriteLine(strSDTemp01.ToString)          '追加
                            objSW02.WriteLine(strSDTemp02.ToString)          '追加
                            objSW02.WriteLine(strRDTemp01.ToString)          '追加
                            objSW02.WriteLine(strRDTemp02.ToString)          '追加
                        End If


                        '***********************
                        '進捗表示
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try
                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02.Close()
                objSW03.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Melsec電文解析               ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdMelsecAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMelsecAnalysis.Click
        Try
            Dim strMsg As String = ""
            'Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '初期設定
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim strSD01 As String = ""          '送信電文01ﾃｷｽﾄ
            Dim strRD01 As String = ""          '受信電文01ﾃｷｽﾄ

            '===============================================
            '色々ﾁｪｯｸ
            '===============================================
            If IsDate(txtInsertDate.Text) = False Then
                strMsg = "日付設定を行って下さい。"
                MsgBox(strMsg)
                Throw New Exception(strMsg)
            End If

            '===============================================
            'DB接続
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB接続ｴﾗｰ")

            '===============================================
            'ﾃｰﾌﾞﾙｸﾗｽ定義 & ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '===============================================
            Dim objXLOG_MELSEC As New TBL_XLOG_MELSEC(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'ﾌｧｲﾙ読込
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '****************************************************************************
            'PC →PLC
            '****************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Try


                '**************************************
                '読込
                '**************************************
                strSD01 = objSR01.ReadToEnd()    '一行目ﾃｷｽﾄ


                '**************************************
                '無駄な文字をﾘﾌﾟﾚｰｽ
                '**************************************
                strSD01 = Replace(strSD01, Space(1), "")
                strSD01 = Replace(strSD01, vbCr, "")
                strSD01 = Replace(strSD01, vbLf, "")


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '****************************************************************************
            'PLC→PC
            '****************************************************************************
            Dim objSR02 As New System.IO.StreamReader(txtTextFile02.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Try


                '**************************************
                '読込
                '**************************************
                strRD01 = objSR02.ReadToEnd()    '一行目ﾃｷｽﾄ


                '**************************************
                '無駄な文字をﾘﾌﾟﾚｰｽ
                '**************************************
                strRD01 = Replace(strRD01, Space(1), "")
                strRD01 = Replace(strRD01, vbCr, "")
                strRD01 = Replace(strRD01, vbLf, "")


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '一回目ﾌｧｲﾙ出力
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '****************************************************************************
            'PC →PLC
            '****************************************************************************
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           'ﾊﾟｽ
            Dim strFileNameWithoutExtensionSD01 As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text) '拡張子を含まないﾌｧｲﾙ名
            Dim strFileNameWithoutExtensionRD01 As String = System.IO.Path.GetFileNameWithoutExtension(txtTextFile02.Text)      '拡張子を含まないﾌｧｲﾙ名
            Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '拡張子
            Dim objSW01_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtensionSD01 _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Dim objSW01_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                      & "\" _
                                                      & strFileNameWithoutExtensionRD01 _
                                                      & "_01" _
                                                      & strExtension _
                                                      , False _
                                                      , System.Text.Encoding.GetEncoding(932) _
                                                      )           'Shift JISで書き込む
            Try
                objSW01_SD01.WriteLine(strSD01)          '追加
                objSW01_RD01.WriteLine(strSD01)          '追加
            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW01_SD01.Close()
                objSW01_RD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '二回目ﾌｧｲﾙ出力
            '電文毎に一行にする
            'PC →PLC
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'Dim strArySD01() As String = Nothing
            Dim lngRecordCount As Long = 0              'ﾚｺｰﾄﾞ数
            Dim objSW02_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JISで書き込む
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            '↓↓↓↓↓↓********************************************************************************************************************************************************************************************************************************************
            'ｶｽﾀﾏｲｽﾞ

            Dim objSW91_SD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_91" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JISで書き込む

            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            '↑↑↑↑↑↑********************************************************************************************************************************************************************************************************************************************
            Try
                Dim strSDTemp01 As String = ""              '作業用ﾃﾝﾎﾟﾗﾘ
                Dim strRDTemp01 As String = ""              '作業用ﾃﾝﾎﾟﾗﾘ
                For ii As Integer = 1 To strSD01.Length
                    '(ﾙｰﾌﾟ:解析する文字数)
                    Try


                        '*********************************************************************
                        '初期設定
                        '*********************************************************************
                        strSDTemp01 &= (MidD(strSD01, ii, 1))


                        '*********************************************************************
                        '読込ｺﾏﾝﾄﾞ      取得
                        '*********************************************************************
                        If strSDTemp01.Length = 24 Then
                            If MidD(strSDTemp01, 1, 4) = "01FF" And MidD(strSDTemp01, 23, 2) = "00" Then
                                '(読込ｺﾏﾝﾄﾞの場合)

                                'ﾌｧｲﾙ出力
                                objSW02_SD01.WriteLine(strSDTemp01)  'ﾌｧｲﾙ出力
                                ''配列にｾｯﾄ
                                'If IsNull(strArySD01) Then ReDim strArySD01(0) Else ReDim Preserve strArySD01(UBound(strArySD01) + 1)
                                'strArySD01(UBound(strArySD01)) = strTelSend
                                '初期化
                                strSDTemp01 = ""                    '作業用ﾃﾝﾎﾟﾗﾘ
                                lngRecordCount += 1                 'ﾚｺｰﾄﾞ+1
                            End If
                        End If


                        '*********************************************************************
                        '書込ｺﾏﾝﾄﾞ      取得
                        '*********************************************************************
                        If 28 <= strSDTemp01.Length Then
                            If MidD(strSDTemp01, 1, 4) = "03FF" And MidD(strSDTemp01, 23, 2) = "00" Then
                                '(書込ｺﾏﾝﾄﾞの場合)
                                Dim intAdrsCount As Integer = Change16To10(Mid(strSDTemp01, 21, 2))                   'ﾃﾞﾊﾞｲｽ点数
                                If 24 + (intAdrsCount * 4) <= strSDTemp01.Length Then
                                    '(書込ｺﾏﾝﾄﾞの場合)

                                    objSW02_SD01.WriteLine(strSDTemp01)       'ﾌｧｲﾙ出力
                                    strSDTemp01 = ""                    '作業用ﾃﾝﾎﾟﾗﾘ
                                    lngRecordCount += 1                 'ﾚｺｰﾄﾞ+1

                                End If
                            End If
                        End If


                        '*********************************************************************
                        '電文取りこぼしﾁｪｯｸ
                        '*********************************************************************
                        If 200 <= strSDTemp01.Length Then

                            Call AddToLog("ｺﾞﾐ電文検出:" & strSDTemp01)     'ﾛｸﾞ出力
                            objSW91_SD01.WriteLine(strSDTemp01)          'ﾌｧｲﾙ出力
                            strSDTemp01 = ""                        '作業用ﾃﾝﾎﾟﾗﾘ
                            strSDTemp01 &= (MidD(strSD01, ii, 1))   '作業用ﾃﾝﾎﾟﾗﾘ

                        End If


                        '***********************
                        '進捗表示
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02_SD01.Close()
                objSW91_SD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '二回目ﾌｧｲﾙ出力
            '電文毎に一行にする
            'PLC→PC
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSW02_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JISで書き込む
            Dim objSW91_RD01 As New System.IO.StreamWriter(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_91" _
                                                           & strExtension _
                                                           , False _
                                                           , System.Text.Encoding.GetEncoding(932) _
                                                           )           'Shift JISで書き込む
            Try
                'Dim strSDTemp01 As String = ""              '作業用ﾃﾝﾎﾟﾗﾘ
                Dim strRDTemp01 As String = ""              '作業用ﾃﾝﾎﾟﾗﾘ
                For ii As Integer = 1 To strSD01.Length
                    '(ﾙｰﾌﾟ:解析する文字数)
                    Try


                        '*********************************************************************
                        '初期設定
                        '*********************************************************************
                        strRDTemp01 &= (MidD(strRD01, ii, 1))


                        '*********************************************************************
                        '読込応答       取得
                        '面倒なので、1ﾜｰﾄﾞしか読んでいない事前提
                        '*********************************************************************
                        If 8 = strRDTemp01.Length Then
                            If MidD(strRDTemp01, 1, 2) = "81" Then
                                '(読込応答の場合)

                                objSW02_RD01.WriteLine(strRDTemp01)       'ﾌｧｲﾙ出力
                                strRDTemp01 = ""                    '作業用ﾃﾝﾎﾟﾗﾘ

                            End If
                        End If


                        '*********************************************************************
                        '書込応答       取得
                        '*********************************************************************
                        If strRDTemp01.Length = 4 Then
                            If MidD(strRDTemp01, 1, 2) = "83" Then
                                '(書込応答の場合)

                                objSW02_RD01.WriteLine(strRDTemp01) 'ﾌｧｲﾙ出力
                                strRDTemp01 = ""                    '作業用ﾃﾝﾎﾟﾗﾘ

                            End If
                        End If


                        '*********************************************************************
                        '電文取りこぼしﾁｪｯｸ
                        '*********************************************************************
                        If 200 <= strRDTemp01.Length Then

                            Call AddToLog("ｺﾞﾐ電文検出:" & strRDTemp01)     'ﾛｸﾞ出力
                            objSW91_RD01.WriteLine(strRDTemp01)          'ﾌｧｲﾙ出力
                            strRDTemp01 = ""                        '作業用ﾃﾝﾎﾟﾗﾘ
                            strRDTemp01 &= (MidD(strSD01, ii, 1))   '作業用ﾃﾝﾎﾟﾗﾘ

                        End If


                        '***********************
                        '進捗表示
                        '***********************
                        If ii Mod 1000 = 0 Or ii = strSD01.Length Then
                            lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
                            Me.Refresh()
                            System.Windows.Forms.Application.DoEvents()
                        End If


                    Catch ex As Exception
                        ComError(ex)
                    End Try


                Next


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSW02_SD01.Close()
                objSW02_RD01.Close()
                objSW91_SD01.Close()
                objSW91_RD01.Close()
            End Try


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'DBに出力
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01_SD02 As New System.IO.StreamReader(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionSD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , System.Text.Encoding.Default _
                                                           )   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Dim objSR01_RD02 As New System.IO.StreamReader(strDirectoryName _
                                                           & "\" _
                                                           & strFileNameWithoutExtensionRD01 _
                                                           & "_02" _
                                                           & strExtension _
                                                           , System.Text.Encoding.Default _
                                                           )   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Dim hh As Integer = 0
            Try
                '**************************************
                '一行ずつ読込み
                '**************************************
                While (objSR01_SD02.Peek >= 0)
                    '(ﾙｰﾌﾟ:読込不可となるまで)


                    '**************************************
                    '初期設定
                    '**************************************
                    hh += 1


                    '**************************************
                    'ﾚｺｰﾄﾞ読み取り
                    '**************************************
                    Dim strSDTemp01 As String = objSR01_SD02.ReadLine()                '一行目ﾃｷｽﾄ
                    Dim strRDTemp01 As String = objSR01_RD02.ReadLine()                '一行目ﾃｷｽﾄ


                    '********************************************************************************************
                    'ﾃｰﾌﾞﾙに追加
                    '********************************************************************************************
                    Try
                        objXLOG_MELSEC.CLEAR_PROPERTY()
                        objXLOG_MELSEC.FLOG_CHECK_DT1 = CDate(txtInsertDate.Text)       '確認日時_1
                        objXLOG_MELSEC.FLOG_CHECK_DT2 = CDate(txtInsertDate.Text)       '確認日時_2
                        objXLOG_MELSEC.FDENBUN = strSDTemp01                            '通信電文
                        objXLOG_MELSEC.FDENBUN02 = strRDTemp01                          '通信電文02
                        objXLOG_MELSEC.ADD_XLOG_MELSEC_SEQ()                            '追加
                    Catch ex As Exception
                        ComError(ex)

                    End Try


                    '***********************
                    '進捗表示
                    '***********************
                    If hh Mod 1000 = 0 Or hh = lngRecordCount Then
                        lblProgress.Text = Format((hh * 100) / lngRecordCount, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01_SD02.Close()
                objSR01_RD02.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  XMST_EQ_NAME追加             ﾎﾞﾀﾝｸﾘｯｸ"
    Private Sub cmdInsertXMST_EQ_NAME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertXMST_EQ_NAME.Click
        Try
            Dim strMsg As String = ""
            Dim intRet As RetCode


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            '初期設定
            '************************************************************************************************************************************
            '************************************************************************************************************************************

            '===============================================
            'DB接続
            '===============================================
            Dim objSystem As New clsConnectConfig(CONFIG_FILE)
            Dim objDb As New JobCommon.clsConn
            objDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            Dim blnRet As Boolean = False
            blnRet = objDb.Connect()
            If blnRet = False Then Throw New Exception("DB接続ｴﾗｰ")

            '===============================================
            'ﾃｰﾌﾞﾙｸﾗｽ定義 & ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '===============================================
            Dim objXLOG_MELSEC As New TBL_XLOG_MELSEC(Nothing, objDb, objDb)
            objDb.BeginTrans()


            '************************************************************************************************************************************
            '************************************************************************************************************************************
            'ﾌｧｲﾙ読込
            '************************************************************************************************************************************
            '************************************************************************************************************************************
            Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
            Try


                '**************************************
                'ﾚｺｰﾄﾞ数        取得
                '**************************************
                Dim lngRecordCount As Long = 0
                While (objSR01.Peek >= 0)
                    '(ﾙｰﾌﾟ:読込不可となるまで)
                    Dim strTemp01 As String = objSR01.ReadLine()                '一行目ﾃｷｽﾄ
                    lngRecordCount += 1
                End While
                Dim ii As Long = 0


                '**************************************
                'もう一度読み直し
                '**************************************
                objSR01.Close()
                objSR01.Dispose()
                objSR01 = Nothing
                objSR01 = New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
                While (objSR01.Peek >= 0)
                    '(ﾙｰﾌﾟ:読込不可となるまで)


                    '**************************************
                    '初期設定
                    '**************************************
                    ii += 1


                    '**************************************
                    '一行目、二行目読込
                    '**************************************
                    Dim strTemp01 As String = objSR01.ReadLine()                '一行目ﾃｷｽﾄ
                    Dim strAryTemp01() As String = Split(strTemp01, Space(1))   '一行目ﾃｷｽﾄ


                    '**************************************
                    '設備状況ﾏｽﾀ        追加
                    '**************************************
                    If IsNotNull(strAryTemp01) Then
                        If 3 <= strAryTemp01.Length Then
                            '(値が入っていた場合)
                            Dim objXMST_XCOMMENT01_01 As New TBL_XMST_XCOMMENT01_01(Nothing, objDb, objDb)
                            objXMST_XCOMMENT01_01.FEQ_ID = strAryTemp01(0)          '設備ID
                            objXMST_XCOMMENT01_01.XCOMMENT01 = strAryTemp01(1)      'ｺﾒﾝﾄ01
                            If 3 <= strAryTemp01.Length Then
                                For jj As Integer = 2 To strAryTemp01.Length - 1
                                    objXMST_XCOMMENT01_01.XCOMMENT01_01 &= strAryTemp01(jj)
                                Next
                            End If
                            intRet = objXMST_XCOMMENT01_01.GET_XMST_XCOMMENT01_01(False)
                            If intRet <> RetCode.OK Then
                                objXMST_XCOMMENT01_01.ADD_XMST_XCOMMENT01_01()
                            End If
                        End If

                    End If


                    '***********************
                    '進捗表示
                    '***********************
                    If ii Mod 1000 = 0 Or ii = lngRecordCount Then
                        lblProgress.Text = Format((ii * 100) / lngRecordCount, "0.00") & "%"
                        Me.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                    End If


                End While


            Catch ex As Exception
                ComError(ex)
                Throw ex
            Finally
                objSR01.Close()
                objDb.Commit()
            End Try


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region




#Region "  画面ｴﾗｰ処理                          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】ex         ：ｴﾗｰException
    '【戻値】
    '*******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)
        If IsNotNull(mobjRS232C) Then mobjRS232C.ComError(ex)
        MsgBox(ex.Message)
    End Sub
#End Region
#Region "  ﾛｸﾞ書込処理                          "
    '****************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '****************************************************************************************
    Public Sub AddToLog(ByVal strMsg_1 As String, _
                        Optional ByVal strMsg_2 As String = "【ﾕｰｻﾞｰﾛｸﾞ      】", _
                        Optional ByVal strMsg_3 As String = "")
        mobjRS232C.AddToLog(strMsg_1, strMsg_2, strMsg_3)
    End Sub
#End Region
#Region "  MidD関数                             "
    '''***********************************************************************************************************************************
    ''' <summary>
    ''' ﾁｪｯｸﾎﾞｯｸｽによって、ﾕﾆMidかﾊﾞｲﾄMidか判別
    ''' </summary>
    ''' <param name="strMsg">文字列</param>
    ''' <param name="intPos">開始位置</param>
    ''' <param name="intLen">ﾊﾞｲﾄ数</param>
    ''' <returns>Mid関数戻値</returns>
    ''' <remarks></remarks>
    '''***********************************************************************************************************************************
    Private Function MidD(ByVal strMsg As String _
                        , ByVal intPos As Integer _
                        , Optional ByVal intLen As Integer = Integer.MaxValue _
                        ) _
                        As String
        Dim strReturn As String


        '************************************************
        'ﾁｪｯｸﾎﾞｯｸｽで判断
        '************************************************
        If chkSJIS.Checked = True Then
            '(全角対応の場合)
            strReturn = MID_SJIS(strMsg, intPos, intLen)
        Else
            '(全角未対応の場合)
            If intLen = Integer.MaxValue Then
                strReturn = Mid(strMsg, intPos)
            Else
                strReturn = Mid(strMsg, intPos, intLen)
            End If
        End If


        Return strReturn
    End Function
#End Region


    'StringBuilderで作成(効果がなかったが、一応ﾊﾞｯｸｱｯﾌﾟ)
#Region "  時系列にﾌｧｲﾙ出力             ﾎﾞﾀﾝｸﾘｯｸ"
    'Private Sub cmdAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnalysis.Click
    '    Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '初期設定
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim strSD01 As String = ""        '送信電文01ﾃｷｽﾄ
    '        Dim strSD02 As String = ""        '送信電文02ﾃｷｽﾄ
    '        Dim strRD01 As String = ""        '受信電文01ﾃｷｽﾄ
    '        Dim strRD02 As String = ""        '受信電文02ﾃｷｽﾄ


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        'ﾌｧｲﾙ読込
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
    '        Try
    '            While (objSR01.Peek >= 0)
    '                '(ﾙｰﾌﾟ:読込不可となるまで)


    '                '**************************************
    '                '一行目、二行目読込
    '                '**************************************
    '                Dim blnSD As Boolean = False    '送信ﾃｷｽﾄﾌﾗｸﾞ
    '                Dim blnRD As Boolean = False    '受信ﾃｷｽﾄﾌﾗｸﾞ
    '                Dim strTemp01 As String = objSR01.ReadLine()    '一行目ﾃｷｽﾄ
    '                If Microsoft.VisualBasic.Left(strTemp01, 3) = "SD:" Then
    '                    '(送信電文の場合)
    '                    blnSD = True
    '                ElseIf Microsoft.VisualBasic.Left(strTemp01, 3) = "RD:" Then
    '                    '(受信電文の場合)
    '                    blnRD = True
    '                Else
    '                    Continue While
    '                End If
    '                Dim strTemp02 As String = objSR01.ReadLine()    '二行目ﾃｷｽﾄ


    '                '**************************************
    '                'ﾃｷｽﾄ編集
    '                '**************************************
    '                strTemp01 = MidD(strTemp01, 4)      '送信電文ﾃｷｽﾄ
    '                strTemp02 = MidD(strTemp02, 4)      '送信電文ﾃｷｽﾄ
    '                strTemp01 = SPC_PAD_LEFT_SJIS(strTemp01, 56)      '送信電文ﾃｷｽﾄ
    '                strTemp02 = SPC_PAD_LEFT_SJIS(strTemp02, 56)      '受信電文ﾃｷｽﾄ



    '                '**************************************
    '                'ﾃｷｽﾄ合体
    '                '**************************************
    '                If blnSD = True Then
    '                    '(送信電文の場合)
    '                    strSD01 &= strTemp01
    '                    strSD02 &= strTemp02
    '                ElseIf blnRD = True Then
    '                    '(受信電文の場合)
    '                    strRD01 &= strTemp01
    '                    strRD02 &= strTemp02
    '                End If


    '            End While


    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSR01.Close()
    '        End Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '一回目ﾌｧｲﾙ出力
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '***********************
    '        'StreamWriter   作成
    '        '***********************
    '        Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(txtLineEyeTextFile.Text)                           'ﾊﾟｽ
    '        Dim strFileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(txtLineEyeTextFile.Text)     '拡張子を含まないﾌｧｲﾙ名
    '        Dim strExtension As String = System.IO.Path.GetExtension(txtLineEyeTextFile.Text)                                   '拡張子
    '        'System.IO.Directory.CreateDirectory(strFilePath)        'ﾌｫﾙﾀﾞの作成
    '        Dim objSW01 As New System.IO.StreamWriter(strDirectoryName _
    '                                                  & "\" _
    '                                                  & strFileNameWithoutExtension _
    '                                                  & "_01" _
    '                                                  & strExtension _
    '                                                  , False _
    '                                                  , System.Text.Encoding.GetEncoding(932) _
    '                                                  )           'Shift JISで書き込む
    '        Try
    '            objSW01.WriteLine(strSD01)          '追加
    '            objSW01.WriteLine(strSD02)          '追加
    '            'objSW01.Write(strRD01)          '追加
    '            'objSW01.Write(strRD02)          '追加
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSW01.Close()
    '        End Try


    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        '電文毎に一行にする
    '        '************************************************************************************************************************************
    '        '************************************************************************************************************************************
    '        Dim objSW02 As New System.IO.StreamWriter(strDirectoryName _
    '                                                  & "\" _
    '                                                  & strFileNameWithoutExtension _
    '                                                  & "_02" _
    '                                                  & strExtension _
    '                                                  , False _
    '                                                  , System.Text.Encoding.GetEncoding(932) _
    '                                                  )           'Shift JISで書き込む
    '        Try
    '            Dim strSDTemp01 As New StringBuilder
    '            Dim strSDTemp02 As New StringBuilder
    '            Dim strRDTemp01 As New StringBuilder
    '            Dim strRDTemp02 As New StringBuilder
    '            For ii As Integer = 1 To strSD01.Length
    '                '(ﾙｰﾌﾟ:文字列の長さ)


    '                '***********************
    '                'ﾌｧｲﾙ出力
    '                '***********************
    '                If ii <= strSD01.Length - 8 And IsNotNull(strSDTemp01.ToString) Then
    '                    '(時間ﾃﾞｰﾀが入っている可能性がある場合)


    '                    If MidD(strSD01, ii, 8) = "[ TMSP ]" _
    '                       And MidD(strSD01, ii, 10) <> "[ TMSP ] -" Then
    '                        '(時間ﾃﾞｰﾀが入っている場合)
    '                        objSW02.WriteLine(strSDTemp01.ToString)      '追加
    '                        objSW02.WriteLine(strSDTemp02.ToString)      '追加
    '                        objSW02.WriteLine(strRDTemp01.ToString)      '追加
    '                        objSW02.WriteLine(strRDTemp02.ToString)      '追加
    '                        objSW02.WriteLine("")               '追加(改行)
    '                        strSDTemp01.Remove(0, strSDTemp01.Length)       '初期化
    '                        strSDTemp02.Remove(0, strSDTemp02.Length)       '初期化
    '                        strRDTemp01.Remove(0, strRDTemp01.Length)       '初期化
    '                        strRDTemp02.Remove(0, strRDTemp02.Length)       '初期化
    '                    End If


    '                    ''If MID_SJIS(strSD01, ii, 8) = "[ TMSP ]" Then
    '                    ''    '(時間ﾃﾞｰﾀが入っている場合)
    '                    ''    objSW02.WriteLine(strSDTemp01)      '追加
    '                    ''    objSW02.WriteLine(strSDTemp02)      '追加
    '                    ''    objSW02.WriteLine(strRDTemp01)      '追加
    '                    ''    objSW02.WriteLine(strRDTemp02)      '追加
    '                    ''    objSW02.WriteLine("")               '追加(改行)
    '                    ''    strSDTemp01 = ""        '初期化
    '                    ''    strSDTemp02 = ""        '初期化
    '                    ''    strRDTemp01 = ""        '初期化
    '                    ''    strRDTemp02 = ""        '初期化
    '                    ''End If


    '                End If


    '                '***********************
    '                '一文字ずつ抜き出し
    '                '***********************
    '                strSDTemp01.Append(MidD(strSD01, ii, 1))
    '                strSDTemp02.Append(MidD(strSD02, ii, 1))
    '                strRDTemp01.Append(MidD(strRD01, ii, 1))
    '                strRDTemp02.Append(MidD(strRD02, ii, 1))


    '                '***********************
    '                'ﾌｧｲﾙ出力
    '                '***********************
    '                If ii = strSD01.Length Then
    '                    '(ﾃﾞｰﾀが終わった場合)
    '                    objSW02.WriteLine(strSDTemp01.ToString)          '追加
    '                    objSW02.WriteLine(strSDTemp02.ToString)          '追加
    '                    objSW02.WriteLine(strRDTemp01.ToString)          '追加
    '                    objSW02.WriteLine(strRDTemp02.ToString)          '追加
    '                End If


    '                '***********************
    '                '進捗表示
    '                '***********************
    '                If ii Mod 1001 = 0 Or ii = strSD01.Length Then
    '                    lblProgress.Text = Format((ii * 100) / strSD01.Length, "0.00") & "%"
    '                    Me.Refresh()
    '                    System.Windows.Forms.Application.DoEvents()
    '                End If


    '            Next


    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            objSW02.Close()
    '        End Try


    '        ''**************************************
    '        ''ﾌｧｲﾙ読込
    '        ''**************************************
    '        'Dim objSR01 As New System.IO.StreamReader(txtLineEyeTextFile.Text, System.Text.Encoding.Default)   ' StreamReader の新しいｲﾝｽﾀﾝｽを生成する
    '        'objSR01.ReadLine()    '一行取得
    '        'objSR01.ReadLine()    '一行取得
    '        'Dim strDBBackupPath As String = Trim(MidD(objSR01.ReadLine(), 4))
    '        'If System.IO.Directory.Exists(strDBBackupPath) = False Then
    '        '    '(ﾌｫﾙﾀﾞが存在しない場合)
    '        '    Call AddToMsgLog(Now, FMSG_ID_S9002, "外付けHDDのﾊﾞｯｸｱｯﾌﾟ先が認識出来ません。", "「" & strDBBackupPath & "」が見つかりません")
    '        '    Return RetCode.OK
    '        'End If





    '    Catch ex As Exception
    '        ComError(ex)

    '    End Try
    'End Sub
#End Region


    '↓↓↓↓↓↓↓↓↓↓↓↓************************************************************************************************************************************
    '安川機能

#Region "  共通変数                                 "
    Private TMSP As String = "[ TMSP ]"
#End Region
#Region "  分解電文01                   ﾃｷｽﾄﾁｪﾝｼﾞ   "
    Private Sub txtTelegramAnalysis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelegramAnalysis01.TextChanged
        Try


            '**************************************************************************************************
            '**************************************************************************************************
            '読出要求           表示
            '**************************************************************************************************
            '**************************************************************************************************
            If MID_SJIS(txtTelegramAnalysis01.Text, 3, 2) = "03" Then
                txtReadSend01_01.Text = MID_SJIS(txtTelegramAnalysis01.Text, 1, 2)
                txtReadSend01_02.Text = MID_SJIS(txtTelegramAnalysis01.Text, 3, 2)
                txtReadSend01_03.Text = 40001 + Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 5, 4))
                txtReadSend01_04.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 9, 4))
                txtReadSend01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis01.Text, 4)
            Else
                txtReadSend01_01.Text = ""
                txtReadSend01_02.Text = ""
                txtReadSend01_03.Text = ""
                txtReadSend01_04.Text = ""
                txtReadSend01_99.Text = ""
            End If


            '**************************************************************************************************
            '**************************************************************************************************
            '書込要求           表示
            '**************************************************************************************************
            '**************************************************************************************************
            If MID_SJIS(txtTelegramAnalysis01.Text, 3, 2) = "10" Then

                '********************************************************
                '基本
                '********************************************************
                txtWriteSend01_01.Text = MID_SJIS(txtTelegramAnalysis01.Text, 1, 2)
                txtWriteSend01_02.Text = MID_SJIS(txtTelegramAnalysis01.Text, 3, 2)
                txtWriteSend01_03.Text = 40001 + Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 5, 4))
                txtWriteSend01_04.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 9, 4))
                txtWriteSend01_05.Text = Change16To10(MID_SJIS(txtTelegramAnalysis01.Text, 13, 2))
                txtWriteSend01_06.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, TO_INTEGER(txtWriteSend01_05.Text) * 2) & vbCrLf & vbCrLf
                If TO_INTEGER(txtWriteSend01_04.Text) <= 6 Then
                    txtWriteSend01_81.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, TO_INTEGER(txtWriteSend01_04.Text) * 4)
                Else
                    txtWriteSend01_81.Text = MID_SJIS(txtTelegramAnalysis01.Text, 15, 24)
                End If
                txtWriteSend01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis01.Text, 4)


                '********************************************************
                '書込ﾃﾞｰﾀ
                '********************************************************
                txtWriteSend01_06.Text &= Space(6) & "(     2進数      )(16進)( 10進)" & vbCrLf
                For ii As Integer = 0 To TO_INTEGER(txtWriteSend01_04.Text) - 1
                    '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

                    '================================================
                    '書込ﾃﾞｰﾀ
                    '================================================
                    Dim strData16 As String = MID_SJIS(txtTelegramAnalysis01.Text, 15 + (ii * 4), 4)
                    Dim strData10 As Integer = Change16To10(strData16)
                    Dim strData02 As String = Change10To2(strData10, 16)
                    txtWriteSend01_06.Text &= (TO_INTEGER(txtWriteSend01_03.Text) + ii) & ":"
                    txtWriteSend01_06.Text &= "(" & strData02 & ")"
                    txtWriteSend01_06.Text &= "(" & strData16 & ")"
                    txtWriteSend01_06.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                    txtWriteSend01_06.Text &= vbCrLf


                Next


            Else
                txtWriteSend01_01.Text = ""
                txtWriteSend01_02.Text = ""
                txtWriteSend01_03.Text = ""
                txtWriteSend01_04.Text = ""
                txtWriteSend01_05.Text = ""
                txtWriteSend01_06.Text = ""
                txtWriteSend01_99.Text = ""
            End If




        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  分解電文02                   ﾃｷｽﾄﾁｪﾝｼﾞ   "
    Private Sub txtTelegramAnalysis02_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelegramAnalysis02.TextChanged
        Try


            '*************************************************
            '読込応答           表示
            '*************************************************
            If MID_SJIS(txtTelegramAnalysis02.Text, 3, 2) = "03" Then

                '===================================
                'ﾁｪｯｸ
                '===================================
                If IsNull(txtTelegramAnalysis01.Text) Or IsNull(txtReadSend01_03.Text) Then
                    '(読込要求電文が分解されていない場合)
                    txtReadRecv01_01.Text = ""
                    txtReadRecv01_02.Text = ""
                    txtReadRecv01_03.Text = ""
                    txtReadRecv01_04.Text = ""
                    txtReadRecv01_99.Text = ""
                    Throw New Exception("対応する読込要求電文を分解させて下さい。" & vbCrLf & "読込アドレスが取得出来ません。")
                End If

                '===================================
                '基本
                '===================================
                txtReadRecv01_01.Text = MID_SJIS(txtTelegramAnalysis02.Text, 1, 2)
                txtReadRecv01_02.Text = MID_SJIS(txtTelegramAnalysis02.Text, 3, 2)
                txtReadRecv01_03.Text = Change16To10(MID_SJIS(txtTelegramAnalysis02.Text, 5, 2))
                txtReadRecv01_04.Text = MID_SJIS(txtTelegramAnalysis02.Text, 7, TO_INTEGER(txtReadRecv01_03.Text) * 2) & vbCrLf & vbCrLf
                txtReadRecv01_99.Text = Microsoft.VisualBasic.Right(txtTelegramAnalysis02.Text, 4)

                '===================================
                '書込ﾃﾞｰﾀ
                '===================================
                txtReadRecv01_04.Text &= Space(6) & "(     2進数      )(16進)( 10進)" & vbCrLf
                For ii As Integer = 0 To (TO_INTEGER(txtReadRecv01_03.Text) / 2) - 1
                    '(ﾙｰﾌﾟ:書込ﾃﾞｰﾀ数)

                    Dim strData16 As String = MID_SJIS(txtTelegramAnalysis02.Text, 7 + (ii * 4), 4)
                    Dim strData10 As Integer = Change16To10(strData16)
                    Dim strData02 As String = Change10To2(strData10, 16)
                    txtReadRecv01_04.Text &= (TO_INTEGER(txtReadSend01_03.Text) + ii) & ":"
                    txtReadRecv01_04.Text &= "(" & strData02 & ")"
                    txtReadRecv01_04.Text &= "(" & strData16 & ")"
                    txtReadRecv01_04.Text &= "(" & SPC_PAD_RIGHT_SJIS(strData10, 5) & ")"
                    txtReadRecv01_04.Text &= vbCrLf

                Next

            Else
                txtReadRecv01_01.Text = ""
                txtReadRecv01_02.Text = ""
                txtReadRecv01_03.Text = ""
                txtReadRecv01_04.Text = ""
                txtReadRecv01_99.Text = ""
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  入出庫                       ﾃｷｽﾄﾁｪﾝｼﾞ   "
    Private Sub txtWriteSend01_81_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWriteSend01_81.TextChanged
        Try
            txtWriteSend01_82.Text = ""


            For ii As Integer = 1 To txtWriteSend01_81.Text.Length Step +4
                '(ﾙｰﾌﾟ:ｾｯﾄされた文字数)


                '**************************************************
                'ﾃﾞｰﾀ取得
                '**************************************************
                Dim strData16 As String = MID_SJIS(txtWriteSend01_81.Text, ii, 4)   '16進数
                Dim strData10 As String = Change16To10(strData16)                   '10進数
                Dim strData02 As String = Change10To2(strData10, 16)                '02進数


                '**************************************************
                '入出庫
                '**************************************************
                '1つ目
                Dim strDataInout01 As String = MID_SJIS(strData02, 2, 1)        '入庫ﾓｰﾄﾞ
                Dim strDataInout02 As String = MID_SJIS(strData02, 3, 1)        '出庫ﾓｰﾄﾞ
                Dim strDataInout03 As String = MID_SJIS(strData02, 4, 1)        'ﾍﾟｱ搬送
                Dim strDataInout04 As String = MID_SJIS(strData02, 5, 1)        'ﾌｫｰｸ2
                Dim strDataInout05 As String = MID_SJIS(strData02, 6, 1)        'ﾌｫｰｸ1
                Dim strDataInout06 As String = MID_SJIS(strData02, 7, 2)        'L/S番号
                Dim strDataInout07 As String = MID_SJIS(strData02, 10, 1)       'ﾀﾞﾌﾞﾙﾘｰﾁ
                Dim strDataInout08 As String = Change2To10(MID_SJIS(strData02, 11, 2))      '列
                Dim strDataInout09 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '号機
                '2つ目
                Dim strDataInout10 As String = Change2To10(MID_SJIS(strData02, 3, 6))       '連
                Dim strDataInout11 As String = MID_SJIS(strData02, 9, 1)                    'ENDﾌﾗｸﾞ
                Dim strDataInout12 As String = MID_SJIS(strData02, 10, 1)                   '入棚再設定
                Dim strDataInout13 As String = Change2To10(MID_SJIS(strData02, 13, 4))      '段


                '**************************************************
                'ﾃｷｽﾄﾎﾞｯｸｽに出力
                '**************************************************
                Select Case ii
                    Case 1, 13
                        txtWriteSend01_82.Text &= "入庫ﾓｰﾄﾞ  :" & strDataInout01 & vbCrLf
                        txtWriteSend01_82.Text &= "出庫ﾓｰﾄﾞ  :" & strDataInout02 & vbCrLf
                        txtWriteSend01_82.Text &= "ﾍﾟｱ搬送   :" & strDataInout03 & vbCrLf
                        txtWriteSend01_82.Text &= "ﾌｫｰｸ2     :" & strDataInout04 & vbCrLf
                        txtWriteSend01_82.Text &= "ﾌｫｰｸ1     :" & strDataInout05 & vbCrLf
                        txtWriteSend01_82.Text &= "L/S番号   :" & strDataInout06 & vbCrLf
                        txtWriteSend01_82.Text &= "ﾀﾞﾌﾞﾙﾘｰﾁ  :" & strDataInout07 & vbCrLf
                        txtWriteSend01_82.Text &= "列        :" & strDataInout08 & vbCrLf
                        txtWriteSend01_82.Text &= "号機      :" & strDataInout09 & vbCrLf
                    Case 5, 17
                        txtWriteSend01_82.Text &= "連        :" & strDataInout10 & vbCrLf
                        txtWriteSend01_82.Text &= "ENDﾌﾗｸﾞ   :" & strDataInout11 & vbCrLf
                        txtWriteSend01_82.Text &= "入棚再設定:" & strDataInout12 & vbCrLf
                        txtWriteSend01_82.Text &= "段        :" & strDataInout13 & vbCrLf
                    Case 9, 21
                        txtWriteSend01_82.Text &= "ｱﾄﾞﾚｽ     :" & strData10 & vbCrLf & vbCrLf
                End Select


                If 21 <= ii Then Exit For
            Next


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

#Region "  要求 or 応答                 選択変更    "

    Private Sub rdoSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWriteSend.CheckedChanged
        Try
            Call rdoSend_CheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

    Private Sub rdoRecv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWriteRecv.CheckedChanged
        Try
            Call rdoSend_CheckedChangedProcess()
        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub

    Private Sub rdoSend_CheckedChangedProcess()

        If rdoWriteSend.Checked = True And rdoWriteRecv.Checked = False Then
            '(要求の場合)
            txtWriteSend01_05.Enabled = True
            txtWriteSend01_06.Enabled = True
        ElseIf rdoWriteSend.Checked = False And rdoWriteRecv.Checked = True Then
            '(応答の場合)
            txtWriteSend01_05.Enabled = False
            txtWriteSend01_06.Enabled = False
        End If

    End Sub

#End Region

    '↑↑↑↑↑↑↑↑↑↑↑↑************************************************************************************************************************************


End Class