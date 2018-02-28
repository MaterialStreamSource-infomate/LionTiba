'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【機能】ｼｰｹﾝｽNo取得、更新機能
' 【作成】SIT
'**********************************************************************************************


Public Class clsSeqNo
    Implements IDisposable

#Region "  ｺﾝｽﾄﾗｸﾀ      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objDb">既存の接続ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="blnConnUse">既存の接続ｵﾌﾞｼﾞｪｸﾄを使用するか否かのﾌﾗｸﾞ True:使用する  False:使用しない(ﾃﾞﾌｫﾙﾄ:True)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objDb As clsConn, _
                   Optional ByVal blnConnUse As Boolean = True _
                   )
        Try
            Dim blnRet As Boolean       '戻値


            '*****************************************
            '内部変数に記憶
            '*****************************************
            mblnConnUse = blnConnUse


            '*****************************************
            'DB接続設定
            '*****************************************
            If blnConnUse = True Then
                '(既存の接続を使用する場合)

                mobjDb = objDb

            Else
                '(新しい接続を使用する場合)

                mobjDb = New clsConn
                mobjDb.ConnectString = objDb.ConnectString      '接続文字列ｾｯﾄ
                blnRet = mobjDb.Connect()                       '接続
                If blnRet = False Then
                    Throw New UserException("DB接続に失敗しました。")
                End If

            End If


            '*****************************************
            '変数初期化
            '*****************************************
            mFSEQ_NO = Integer.MaxValue               'ｼｰｹﾝｽﾅﾝﾊﾞｰ
            mFSEQ_NO_MAX = Integer.MaxValue           'ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
            mFSEQ_NO_MIN = Integer.MaxValue           'ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ﾃﾞｽﾄﾗｸﾀ      "

    Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '明示的に呼び出されたときにアンマネージ リソースを解放します
            End If

            '共有のアンマネージ リソースを解放します

            '*********************************************
            'ｸﾛｰｽﾞ処理
            '*********************************************
            Try
                Call Close()
            Catch ex As Exception
                '何もしない
            End Try


        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#End Region
#Region "  ｸﾗｽ変数定義"
    Protected mobjDb As clsConn                     'DB接続
    Protected mstrDBName As String                  'DB名
    Protected mstrTableName As String               'ﾃｰﾌﾞﾙ名
    Protected mblnConnUse As Boolean                '既存接続ｵﾌﾞｼﾞｪｸﾄ使用ﾌﾗｸﾞ

    Protected mFSEQ_ID As String                    '
    Protected mFSEQ_NAME As String                  'ｼｰｹﾝｽﾅﾝﾊﾞｰ名称
    Protected mFSEQ_NO As Integer                   'ｼｰｹﾝｽﾅﾝﾊﾞｰ
    Protected mFSEQ_NO_MAX As Integer               'ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
    Protected mFSEQ_NO_MIN As Integer               'ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値
    Protected mFUPDATE_DT As Date                   '更新日時
    Protected mFRESET_DT As Date                    'ﾘｾｯﾄ日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>ｼｰｹﾝｽﾅﾝﾊﾞｰID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFSEQ_ID() As String
        Get
            Return mFSEQ_ID
        End Get
        Set(ByVal Value As String)
            mFSEQ_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>DB名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userstrDBName() As String
        Get
            Return mstrDBName
        End Get
        Set(ByVal Value As String)
            mstrDBName = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾃｰﾌﾞﾙ名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userstrTableName() As String
        Get
            Return mstrTableName
        End Get
        Set(ByVal Value As String)
            mstrTableName = Value
        End Set
    End Property
#End Region
#Region "  ｼｰｹﾝｽ№取得 & 更新               (Public  userGetUpdateSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽ№取得＆更新
    ''' </summary>
    ''' <returns>ｼｰｹﾝｽ№</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function userGetUpdateSeqNo() As Integer
        Try
            mobjDb.BeginTrans()

            Try
                Dim intReturn As Integer    '戻値
                Dim strMsg As String        'ﾒｯｾｰｼﾞ


                '******************************************************
                'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
                '******************************************************
                If mFSEQ_ID = "" Then
                    strMsg = "ｼｰｹﾝｽﾅﾝﾊﾞｰIDが設定されていません。"
                    Throw New UserException(strMsg)
                End If
                'If mstrDBName = "" Then
                '    strMsg = "DB名が設定されていません。"
                '    Throw New UserException(strMsg)
                'End If
                If mstrTableName = "" Then
                    strMsg = "ﾃｰﾌﾞﾙ名が設定されていません。"
                    Throw New UserException(strMsg)
                End If


                '******************************************************
                'ｼｰｹﾝｽ№取得
                '******************************************************
                Call GetSeqNo()
                intReturn = mFSEQ_NO


                '******************************************************
                'ｼｰｹﾝｽ№更新
                '******************************************************
                Call UpdateSeqNo()


                '↓↓↓↓↓↓************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/12/25  SEQ№発番時にﾘｾｯﾄされないﾊﾞｸﾞ修正
                '                                    日付が切り替わった瞬間に、二つのexeが同時にSEQ№を発番した場合、ﾀｲﾐﾝｸﾞによっては片方がSEQ№ﾘｾｯﾄされない場合がある。


                '******************************************************
                'ｼｰｹﾝｽﾅﾝﾊﾞｰﾘｾｯﾄ
                '******************************************************
                Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ﾘｾｯﾄ日付
                Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '更新日時
                Dim dtmResetDate As Date = CDate(strResetDate)                      'ﾘｾｯﾄ日付
                Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '更新日時
                If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
                    '(最終ﾘｾｯﾄ日時から一日以上経過していた場合)

                    Call userResetSeqNo()               'ｼｰｹﾝｽ№ﾘｾｯﾄ
                    Call GetSeqNo()                     'ｼｰｹﾝｽ№取得
                    intReturn = mFSEQ_NO                'ｼｰｹﾝｽ№取得(更新前に取得しなければならない)
                    Call UpdateSeqNo()                  'ｼｰｹﾝｽ№更新

                End If


                '↑↑↑↑↑↑************************************************************************************************************


                Return (intReturn)
            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                mobjDb.Commit()
            End Try
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "  ｼｰｹﾝｽ№ﾘｾｯﾄ                      (Public  userResetSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽ№ﾘｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub userResetSeqNo()
        Try
            Dim strSQL As String                    'SQL文
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer                'SQL実行戻り値
            Dim dtmNow As Date = Now                '現在日時

            '******************************************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '******************************************************
            If mFSEQ_ID = "" Then
                strMsg = "ｼｰｹﾝｽﾅﾝﾊﾞｰIDが設定されていません。"
                Throw New UserException(strMsg)
            End If
            'If mstrDBName = "" Then
            '    strMsg = "DB名が設定されていません。"
            '    Throw New UserException(strMsg)
            'End If
            If mstrTableName = "" Then
                strMsg = "ﾃｰﾌﾞﾙ名が設定されていません。"
                Throw New UserException(strMsg)
            End If


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FSEQ_NO = FSEQ_NO_MIN"
            strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ,FRESET_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "'"
            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = mobjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "更新失敗：" & mobjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(対象行無し)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "更新失敗：" & "(対象行無し)[ﾃｰﾌﾞﾙ:TDSP_OPEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ｸﾛｰｽﾞ処理                        (Private userClose)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Close()
        Try

            If mblnConnUse = False Then
                '(新しい接続を使用した場合)

                If IsNothing(mobjDb) = False Then
                    mobjDb.Disconnect()
                    mobjDb = Nothing
                End If

            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  内部関数     "

#Region "  ｼｰｹﾝｽ№取得                      (Protected  GetSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽ№取得
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub GetSeqNo()
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intReturn As Integer = -1   '戻値


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "' "
            strSQL &= vbCrLf & " FOR UPDATE"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            mobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SEQNO"
            mobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                If Not IsDBNull(objRow("FSEQ_NO")) Then

                    Call SET_TPRG_SEQNO(objRow)

                Else
                    strMsg = "設定されたｼｰｹﾝｽIDのﾚｺｰﾄﾞにNullが設定されています。"
                    Throw New UserException(strMsg)
                End If

            Else
                strMsg = "設定されたｼｰｹﾝｽIDのﾚｺｰﾄﾞが存在しません。"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ｼｰｹﾝｽ№更新                      (Protected  UpdateSeqNo)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽ№更新
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub UpdateSeqNo()
        Try
            Dim strSQL As String                    'SQL文
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer                'SQL実行戻り値
            Dim dtmNow As Date = Now                '現在日時
            Dim intUpdateSeqNo As Integer           'ｼｰｹﾝｽ№ + 1


            '***********************
            'ｼｰｹﾝｽ№ + 1
            '***********************
            intUpdateSeqNo = SeqNoPlus1()


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ№発番時にﾘｾｯﾄされないﾊﾞｸﾞ修正
            '                                    日付が切り替わった瞬間に、二つのexeが同時にSEQ№を発番した場合、ﾀｲﾐﾝｸﾞによっては片方がSEQ№ﾘｾｯﾄされない場合がある


            '******************************************************
            'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            '******************************************************
            mFSEQ_NO = intUpdateSeqNo   'ｼｰｹﾝｽﾅﾝﾊﾞｰ
            mFUPDATE_DT = dtmNow        '更新日時


            '↑↑↑↑↑↑************************************************************************************************************


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    " & mstrTableName
            strSQL &= vbCrLf & " SET"
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ№発番時にﾘｾｯﾄされないﾊﾞｸﾞ修正
            '                                    日付が切り替わった瞬間に、二つのexeが同時にSEQ№を発番した場合、ﾀｲﾐﾝｸﾞによっては片方がSEQ№ﾘｾｯﾄされない場合がある

            strSQL &= vbCrLf & "    FSEQ_NO = " & CStr(mFSEQ_NO) & ""
            strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & mFUPDATE_DT & "','YYYY/MM/DD HH24:MI:SS')"

            'strSQL &= vbCrLf & "    FSEQ_NO = " & CStr(intUpdateSeqNo) & ""
            'strSQL &= vbCrLf & "   ,FUPDATE_DT = TO_DATE('" & dtmNow & "','YYYY/MM/DD HH24:MI:SS')"

            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & mFSEQ_ID & "'"
            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = mobjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "更新失敗" & mobjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(対象行無し)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = "更新失敗" & "(対象行無し)[ﾃｰﾌﾞﾙ:TDSP_OPEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "  ｼｰｹﾝｽ№ + 1                      (Protected  SeqNoPlus1)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽ№ + 1
    ''' </summary>
    ''' <returns>ｼｰｹﾝｽ№</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function SeqNoPlus1() As Integer
        Try
            Dim intReturn As Integer                                        '戻値


            '******************************************************
            'ｼｰｹﾝｽ№ + 1
            '******************************************************
            If mFSEQ_NO_MAX <= mFSEQ_NO Then
                '(ｼｰｹﾝｽ№が最大値以上の時)
                intReturn = mFSEQ_NO_MIN
            Else
                '(それ以外の時)
                intReturn = mFSEQ_NO + 1
            End If


            Return (intReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "  ｼｰｹﾝｽﾅﾝﾊﾞｰ発番変数設定           (Protected  SET_TPRG_SEQNO)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰ発番変数設定
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Sub SET_TPRG_SEQNO(ByVal objRow As DataRow)
        Try

            '***********************
            'ﾃﾞｰﾀｾｯﾄ
            '***********************
            mFSEQ_ID = objRow("FSEQ_ID")                             'ｼｰｹﾝｽﾅﾝﾊﾞｰID
            mFSEQ_NAME = objRow("FSEQ_NAME")                         'ｼｰｹﾝｽﾅﾝﾊﾞｰ名称
            mFSEQ_NO = objRow("FSEQ_NO")                             'ｼｰｹﾝｽﾅﾝﾊﾞｰ
            mFSEQ_NO_MAX = objRow("FSEQ_NO_MAX")                     'ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
            mFSEQ_NO_MIN = objRow("FSEQ_NO_MIN")                     'ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値
            mFUPDATE_DT = objRow("FUPDATE_DT")                       '更新日時
            mFRESET_DT = objRow("FRESET_DT")                         'ﾘｾｯﾄ日時


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#End Region

End Class
