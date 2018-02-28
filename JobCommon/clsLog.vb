'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
' 【機能】ﾛｸﾞｸﾗｽ
' 【作成】SIT
'**********************************************************************************************
#Region " imports "
Imports System.Text
Imports System.Windows.Forms
'Imports System.Data.SqlClient
Imports System.Data.OleDb

#End Region

Public Class clsLog

#Region " 列挙体宣言 "

    ''' <summary>エラーレベル</summary>
    Public Enum ErrLevel    'エラーレベル
        eLevel1                     '警告
        eLevel2                     '軽度
        eLevel3                     '重度
    End Enum

    ''' <summary>操作履歴区分</summary>
    Public Enum OpeKubun    '操作履歴区分
        eRegist                     '登録
        eDelete                     '削除
        ePrint                      '印刷
        eOther                      'その他
    End Enum
#End Region

#Region " 定数宣言 "
    Private Const FMSGID_NOTHING = "E9999"              'ﾒｯｾｰｼﾞID無しｺｰﾄﾞ
#End Region

#Region " 変数宣言 "
    Private mobjConn As clsConn     'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private msDBName As String      'DB名
    Private mstrErrLogTbl As String 'ｴﾗｰﾛｸﾞﾃｰﾌﾞﾙ名
    Private mstrOpeLogTbl As String '操作ﾛｸﾞﾃｰﾌﾞﾙ名
    Private mstrMsgCdTbl As String  'ﾒｯｾｰｼﾞｺｰﾄﾞﾃｰﾌﾞﾙ名
    Private mblnInErrMsgBox As Boolean  '内部ｴﾗｰ発生時MsgBox表示ﾌﾗｸﾞ
#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "

    ''' =======================================
    ''' <summary>ｴﾗｰﾛｸﾞﾃｰﾌﾞﾙ名のﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public WriteOnly Property ErrLogTbl() As String
        Set(ByVal Value As String)
            Me.mstrErrLogTbl = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>操作ﾛｸﾞﾃｰﾌﾞﾙ名のﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public WriteOnly Property OpeLogTbl() As String
        Set(ByVal Value As String)
            Me.mstrOpeLogTbl = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾒｯｾｰｼﾞｺｰﾄﾞﾃｰﾌﾞﾙ名のﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public WriteOnly Property MsgCdTbl() As String
        Set(ByVal Value As String)
            Me.mstrMsgCdTbl = Value
        End Set
    End Property

#End Region

#Region " ｺﾝｽﾄﾗｸﾀ "
    ''Public Sub New(ByVal objConn As clsConn, Optional ByVal sDBName As String = "", Optional ByVal blnInErrMsgBox As Boolean = True)
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objConn">DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="sDBName">DB名 [Oracleの場合      ･･･ "ｽｷｰﾏ名"または省略] [SQLServerの場合   ･･･ "DB名"."ﾃﾞｰﾀﾍﾞｰｽ所有者"]</param>
    ''' <param name="blnInErrMsgBox">内部ｴﾗｰ発生時MsgBox表示ﾌﾗｸﾞ[True:表示、False:非表示]</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objConn As clsConn, Optional ByVal sDBName As String = "", Optional ByVal blnInErrMsgBox As Boolean = True)
        Me.mobjConn = objConn
        Me.msDBName = IIf(sDBName = "", "", sDBName & ".")
        Me.mblnInErrMsgBox = blnInErrMsgBox
    End Sub
#End Region

#Region " ErrorWrite ｴﾗｰ処理関数 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理関数
    ''' </summary>
    ''' <param name="objEx">Exception</param>
    ''' <param name="blnMsgDspFlg">ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示ﾌﾗｸﾞ 表示=True 非表示=False</param>
    ''' <param name="strDtl2">詳細2[省略可]</param>
    ''' <param name="strDtl3">詳細3[省略可](SQL文など)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ErrorWrite(ByVal objEx As Exception, ByVal blnMsgDspFlg As Boolean, _
                          Optional ByVal strDtl2 As String = "", Optional ByVal strDtl3 As String = "")
        Dim strbErrText As New StringBuilder 'ｴﾗｰ内容
        Dim strStackTrace As String          'ｴﾗｰ発生場所
        Dim eErrLevel As ErrLevel            'ｴﾗｰﾚﾍﾞﾙ
        Dim strDtl1 As String                '詳細1

        Try
            '--- ｴﾗｰ内容 ---
            'If objEx.GetType.Name = "SqlException" Then
            If objEx.GetType.Name = "OleDbException" Then
                ''SQLServerｴﾗｰの場合のｴﾗｰ内容
                'Dim objSqlEx As SqlException
                'DBｴﾗｰの場合のｴﾗｰ内容
                Dim objDbEx As OleDbException
                Dim intI As Integer
                objDbEx = objEx
                For intI = 0 To objDbEx.Errors.Count - 1
                    If intI <> 0 Then strbErrText.Append(";")
                    'strbErrText.Append("[" & objDbEx.Errors.Item(intI).Number.ToString & "]" & objDbEx.Errors.Item(intI).Message)
                    strbErrText.Append("[" & objDbEx.Errors.Item(intI).NativeError.ToString & "]" & objDbEx.Errors.Item(intI).Message)
                Next
            Else
                'その他のｴﾗｰの場合のｴﾗｰ内容
                strbErrText.Append(objEx.Message)
            End If
            '--- ｴﾗｰ発生場所 ---
            strStackTrace = Replace(objEx.StackTrace, vbCrLf, ";")
            '--- ｴﾗｰﾚﾍﾞﾙ ---
            If objEx.GetType.Name = "UserException" Then
                eErrLevel = ErrLevel.eLevel2 : strDtl1 = ""
            ElseIf objEx.GetType.Name = "OleDbException" Then
                eErrLevel = ErrLevel.eLevel3 : strDtl1 = "DBエラー"
            Else
                eErrLevel = ErrLevel.eLevel3 : strDtl1 = "例外エラー"
            End If

            '--- ｱﾗｰﾑ履歴登録 ---
            ErrorLogWrite(eErrLevel, strbErrText.ToString, strStackTrace, strDtl1, strDtl2, strDtl3)

            '--- ﾒｯｾｰｼﾞBox表示ﾌﾗｸﾞONなら ---
            If blnMsgDspFlg Then
                MessageBox.Show(strbErrText.ToString, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            strbErrText = Nothing
        End Try
    End Sub

#End Region

#Region " ErrorLogWrite ｱﾗｰﾑﾛｸﾞ書き込み "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｱﾗｰﾑﾛｸﾞを書き込む関数
    ''' </summary>
    ''' <param name="eErrLevel">ｴﾗｰﾚﾍﾞﾙ</param>
    ''' <param name="strMsg">ｴﾗｰ内容</param>
    ''' <param name="strModule">ｴﾗｰ発生場所</param>
    ''' <param name="strDtl1">詳細1</param>
    ''' <param name="strDtl2">詳細2</param>
    ''' <param name="strDtl3">詳細3(SQL文など)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ErrorLogWrite(ByVal eErrLevel As ErrLevel, ByVal strMsg As String, ByVal strModule As String, _
                             ByVal strDtl1 As String, ByVal strDtl2 As String, ByVal strDtl3 As String)
        Dim strSQL As String        'SQL文字列
        Dim objTool As New clsTool
        Dim strErrLevel As String   'ｴﾗｰﾚﾍﾞﾙ

        Try
            If Me.mstrErrLogTbl = "" Then
                Throw New Exception("エラーログテーブル名が指定されていません。")
            End If

            'ｴﾗｰﾚﾍﾞﾙ名取得
            Select Case eErrLevel
                Case ErrLevel.eLevel1 : strErrLevel = "警告"
                Case ErrLevel.eLevel2 : strErrLevel = "軽度"
                Case ErrLevel.eLevel3 : strErrLevel = "重度"
                Case Else : Exit Sub
            End Select

            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Me.mobjConn.BeginTrans()

            'ｱﾗｰﾑ履歴ﾃﾞｰﾀ書き込み
            strSQL = "INSERT INTO " & Me.msDBName & Me.mstrErrLogTbl & "(FDATE, FSTATE, FMSG, FPROCESS, FMODULE, FDETAILS1, FDETAILS2, FDETAILS3) VALUES(" & _
                        " GetDate()" & _
                        ",'" & strErrLevel & "'" & _
                        ",'" & objTool.LeftB(strMsg.Replace("'", "''"), 512) & "'" & _
                        ",'" & My.Application.Info.ProductName & "'" & _
                        ",'" & objTool.LeftB(strModule.Replace("'", "''"), 1024) & "'" & _
                        ",'" & objTool.LeftB(strDtl1.Replace("'", "''"), 128) & "'" & _
                        ",'" & objTool.LeftB(strDtl2.Replace("'", "''"), 128) & "'" & _
                        ",'" & objTool.LeftB(strDtl3.Replace("'", "''"), 2048) & "'" & _
                     ")"
            Me.mobjConn.Execute(strSQL)

            'ﾄﾗﾝｻﾞｸｼｮﾝ確定
            Me.mobjConn.Commit()

        Catch ex As Exception
            'ﾄﾗﾝｻﾞｸｼｮﾝ取り消し
            Me.mobjConn.RollBack()
            If Me.mblnInErrMsgBox = True Then
                MessageBox.Show("ｱﾗｰﾑ履歴書き込みでｴﾗｰ発生(" & ex.Message & ") 元のｴﾗｰ (" & strMsg & ")", "重度", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Debug.Print("ｱﾗｰﾑ履歴書き込みでｴﾗｰ発生(" & ex.Message & ") 元のｴﾗｰ (" & strMsg & ")")
            End If
        Finally
            objTool = Nothing
        End Try
    End Sub
#End Region

#Region " OpeLogWrite 操作ﾛｸﾞ書き込み "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 操作ﾛｸﾞを書き込む関数
    ''' </summary>
    ''' <param name="eOpeKubun">操作区分</param>
    ''' <param name="strMsg">操作内容</param>
    ''' <param name="strModule">ｸﾗｽ名 / ﾒｿｯﾄﾞ名(ｲﾍﾞﾝﾄ名)</param>
    ''' <param name="strDtl1">詳細1[省略可]</param>
    ''' <param name="strDtl2">詳細2[省略可]</param>
    ''' <param name="strDtl3">詳細3[省略可]</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub OpeLogWrite(ByVal eOpeKubun As OpeKubun, ByVal strMsg As String, ByVal strModule As String, _
                           Optional ByVal strDtl1 As String = "", Optional ByVal strDtl2 As String = "", Optional ByVal strDtl3 As String = "")
        Dim strSQL As String        'SQL文字列
        Dim objTool As New clsTool
        Dim strOpeKbn As String     '操作区分

        Try
            If Me.mstrOpeLogTbl = "" Then
                Throw New Exception("操作ログテーブル名が指定されていません。")
            End If

            '操作区分名取得
            Select Case eOpeKubun
                Case OpeKubun.eRegist : strOpeKbn = "登録"
                Case OpeKubun.eDelete : strOpeKbn = "削除"
                Case OpeKubun.ePrint : strOpeKbn = "印刷"
                Case OpeKubun.eOther : strOpeKbn = "その他"
                Case Else : Exit Sub
            End Select

            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Me.mobjConn.BeginTrans()

            '操作履歴ﾃﾞｰﾀ書き込み
            strSQL = "INSERT INTO " & Me.msDBName & Me.mstrOpeLogTbl & "(FDATE, FSTATE, FMSG, FPROCESS, FMODULE, FDETAILS1, FDETAILS2, FDETAILS3) VALUES(" & _
                        " GetDate()" & _
                        ",'" & strOpeKbn & "'" & _
                        ",'" & objTool.LeftB(strMsg.Replace("'", "''"), 512) & "'" & _
                        ",'" & My.Application.Info.ProductName & "'" & _
                        ",'" & objTool.LeftB(strModule.Replace("'", "''"), 1024) & "'" & _
                        ",'" & objTool.LeftB(strDtl1.Replace("'", "''"), 128) & "'" & _
                        ",'" & objTool.LeftB(strDtl2.Replace("'", "''"), 128) & "'" & _
                        ",'" & objTool.LeftB(strDtl3.Replace("'", "''"), 2048) & "'" & _
                     ")"
            Me.mobjConn.Execute(strSQL)

            'ﾄﾗﾝｻﾞｸｼｮﾝ確定
            Me.mobjConn.Commit()

        Catch ex As Exception
            'ﾄﾗﾝｻﾞｸｼｮﾝ取り消し
            Me.mobjConn.RollBack()
            If Me.mblnInErrMsgBox = True Then
                MessageBox.Show("操作ﾛｸﾞ書込みでｴﾗｰ発生(" & ex.Message & ")", "重度", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Debug.Print("操作ﾛｸﾞ書込みでｴﾗｰ発生(" & ex.Message & ")")
            End If
        Finally
            objTool = Nothing
        End Try
    End Sub
#End Region

#Region " DspMsg ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得し、MsgBoxを表示する関数 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得し、MsgBoxを表示する関数
    ''' </summary>
    ''' <param name="strMsgCd">ﾒｯｾｰｼﾞｺｰﾄﾞ</param>
    ''' <param name="strMsgPrv">先頭付属ﾒｯｾｰｼﾞ内容[省略可]</param>
    ''' <param name="strMsgAft">終端付属ﾒｯｾｰｼﾞ内容[省略可]</param>
    ''' <returns>OK,ｷｬﾝｾﾙ,はい,いいえ,中止･･･-99:異常終了</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function DspMsg(ByVal strMsgCd As String, _
                           Optional ByVal strMsgPrv As String = "", Optional ByVal strMsgAft As String = "") As DialogResult
        Dim strMsgCdWk As String                'ﾒｯｾｰｼﾞｺｰﾄﾞ(Work)
        Dim strMsgTxt As String = ""            'MsgBox用(表示ﾒｯｾｰｼﾞ)
        Dim eBtnType As MessageBoxButtons       'MsgBox用(ﾎﾞﾀﾝ種類)
        Dim eIconType As MessageBoxIcon         'MsgBox用(使用ｱｲｺﾝ)
        Dim eDefType As MessageBoxDefaultButton 'MsgBox用(標準ﾎﾞﾀﾝ)
        Dim strTitle As String = ""             'MsgBox用(ﾀｲﾄﾙ)
        Dim eRet As DialogResult = DialogResult.OK
        Dim objData As DataSet = New DataSet
        Dim objRow As DataRow

        Try
            If Me.mstrMsgCdTbl = "" Then
                Throw New Exception("メッセージコードテーブル名が指定されていません。")
            End If

            '指定のﾒｯｾｰｼﾞｺｰﾄﾞが存在するかどうか確認する
            Me.mobjConn.SQL = "select COUNT(*) from " & Me.msDBName & Me.mstrMsgCdTbl & " where FMSGID = '" & strMsgCd & "'"
            Me.mobjConn.GetDataSet(Me.mstrMsgCdTbl, objData)
            If objData.Tables(Me.mstrMsgCdTbl).Rows(0).Item(0) = 0 Then
                strMsgCdWk = FMSGID_NOTHING
            Else
                strMsgCdWk = strMsgCd
            End If
            objData.Reset()

            'ﾒｯｾｰｼﾞｺｰﾄﾞよりﾒｯｾｰｼﾞ内容を取得
            Me.mobjConn.SQL = "select FMSGDISP,FBUTTON,FICON,FDEFAULT,FMODE,FTITLE from " & Me.msDBName & Me.mstrMsgCdTbl & " WHERE FMSGID = '" & strMsgCdWk & "'"
            Me.mobjConn.GetDataSet(Me.mstrMsgCdTbl, objData)
            If objData.Tables(Me.mstrMsgCdTbl).Rows.Count = 1 Then
                objRow = objData.Tables(Me.mstrMsgCdTbl).Rows(0)
                strMsgTxt = objRow("FMSGDISP")
                eBtnType = objRow("FBUTTON")
                eIconType = objRow("FICON")
                eDefType = objRow("FDEFAULT")
                'lngMode = objRow("FMODE")
                strTitle = objRow("FTITLE")
            End If
            objData.Reset()

            '取得した表示ﾒｯｾｰｼﾞの先頭に付属ﾒｯｾｰｼﾞ内容を付ける
            If strMsgCdWk <> FMSGID_NOTHING Then
                strMsgTxt = strMsgPrv & strMsgTxt & strMsgAft
            End If

            'ﾒｯｾｰｼﾞﾎﾞｯｸｽを表示する
            eRet = MessageBox.Show(strMsgTxt, strTitle, eBtnType, eIconType, eDefType)

        Catch ex As Exception
            'ｴﾗｰ処理
            If Me.mblnInErrMsgBox = True Then
                MessageBox.Show("MsgBox表示でｴﾗｰ発生(" & ex.Message & ")", "重度", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Debug.Print("MsgBox表示でｴﾗｰ発生(" & ex.Message & ")")
            End If
            '戻り値 NG
            eRet = -99
        Finally
            objData = Nothing
        End Try
        Return eRet
    End Function
#End Region

#Region " GetMsg ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得する関数 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得する関数
    ''' </summary>
    ''' <param name="strMsgCd">ﾒｯｾｰｼﾞｺｰﾄﾞ</param>
    ''' <returns>ﾒｯｾｰｼﾞ内容 ｴﾗｰ時は""</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetMsg(ByVal strMsgCd As String) As String
        Dim strMsgCdWk As String                'ﾒｯｾｰｼﾞｺｰﾄﾞ(Work)
        Dim strRet As String = ""               '戻り値
        Dim objData As DataSet = New DataSet
        Dim objRow As DataRow

        Try
            If Me.mstrMsgCdTbl = "" Then
                Throw New Exception("メッセージコードテーブル名が指定されていません。")
            End If

            '指定のﾒｯｾｰｼﾞｺｰﾄﾞが存在するかどうか確認する
            Me.mobjConn.SQL = "select COUNT(*) from " & Me.msDBName & Me.mstrMsgCdTbl & " where FMSGID = '" & strMsgCd & "'"
            Me.mobjConn.GetDataSet(Me.mstrMsgCdTbl, objData)
            If objData.Tables(Me.mstrMsgCdTbl).Rows(0).Item(0) = 0 Then
                strMsgCdWk = FMSGID_NOTHING
            Else
                strMsgCdWk = strMsgCd
            End If
            objData.Reset()

            'ﾒｯｾｰｼﾞｺｰﾄﾞよりﾒｯｾｰｼﾞ内容を取得
            Me.mobjConn.SQL = "select FMSGDISP from " & Me.msDBName & Me.mstrMsgCdTbl & " WHERE FMSGID = '" & strMsgCdWk & "'"
            Me.mobjConn.GetDataSet(Me.mstrMsgCdTbl, objData)
            If objData.Tables(Me.mstrMsgCdTbl).Rows.Count = 1 Then
                objRow = objData.Tables(Me.mstrMsgCdTbl).Rows(0)
                strRet = objRow("FMSGDISP")
            End If
            objData.Reset()

        Catch ex As Exception
            'ｴﾗｰ処理
            If Me.mblnInErrMsgBox = True Then
                MessageBox.Show("ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得でｴﾗｰ発生(" & ex.Message & ")", "重度", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Debug.Print("ﾒｯｾｰｼﾞｺｰﾄﾞからﾒｯｾｰｼﾞ内容を取得でｴﾗｰ発生(" & ex.Message & ")")
            End If
        Finally
            objData = Nothing
        End Try
        Return strRet
    End Function
#End Region

End Class
