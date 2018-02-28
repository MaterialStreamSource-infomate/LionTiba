'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【機能】ｺﾈｸﾄｸﾗｽ
'           ※再接続処理は接続ﾌﾟｰﾘﾝｸﾞ(ﾃﾞﾌｫﾙﾄ有効)を無効にしないと、Decr Pool Size(ﾃﾞﾌｫﾙﾄ5回)分、
'           　再接続処理がうまくいかなくなる
'           　ｸﾗｲｱﾝﾄ/ｻｰﾊﾞｰ型のｱﾌﾟﾘｹｰｼｮﾝでは、ﾌﾟｰﾘﾝｸﾞ機能があってもあまり意味がない為、
'           　接続ﾌﾟｰﾘﾝｸﾞ機能を無効にする[接続文字列に"Pooling=false"をつける]
'           　by KSH H.Kita
'           ※VBA,VB6からの参照は行わないため、機能として削除
'           　また、ﾊﾟﾗﾒｰﾀｵﾌﾞｼﾞｪｸﾄはｵﾌﾞｼﾞｪｸﾄ型でないとﾊﾞｲﾝﾄﾞ変数としての機能が
'             不完全になるため、Rev 0.00に戻した。
'           　by KSH Y.Kitagawa
'
'           ※Rev 0.03
'             一度DBの接続が切断されると、二度と再接続出来なかった。
'             自動的に再接続されるように修正
'           　by KSH Y.Kitagawa
'
' 【作成】2006/09/21  KSH J.Kato      Rev 0.00
'         2007/10/01  KSH H.Kita      Rev 0.01
'         2008/06/25  KSH Y.Kitagawa  Rev 0.02
'         2009/08/06  KSH Y.Kitagawa  Rev 0.03
'**********************************************************************************************

#Region " Imports "
Imports System
Imports System.Data
Imports System.Threading
Imports System.Collections
Imports System.Collections.Specialized
Imports Oracle.DataAccess.Client
Imports System.Runtime.Remoting.Lifetime
#End Region

Public Class clsConn

#Region "  定数宣言"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定数宣言
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Const SLEEP_TIME As Integer = 1000

    ' 再接続処理を行うエラーコード定義
    Public Enum RetryErrCode
        ErrCode01033 = 1033
        ErrCode01034 = 1034
        ErrCode01089 = 1089
        ErrCode03001 = -3001
        ErrCode03113 = 3113
        ErrCode03114 = 3114
        ErrCode12203 = 12203
        ErrCode12500 = 12500
        ErrCode12537 = 12537
        ErrCode12545 = 12545
        ErrCode12560 = 12560
        ErrCode12571 = 12571
    End Enum

#End Region

#Region "  変数宣言"
    '内部変数
    Private RETRY_COUNT As Integer                  'DB再接続ﾘﾄﾗｲ回数(1はﾘﾄﾗｲなし)

    'Private moForm As frmConnPool
    Protected mobjOraCon As OracleConnection
    Private mobjRdr As OracleDataReader
    Private mobjOraValue() As Object        ' ORACLEフィールドデータ
    Private mobjFieldName As New StringCollection   'ORACLEフィールド名
    Private mintOraValueCnt As Integer
    Private mstrSQL As String
    Private mstrErrMsg As String
    Private mintErrCode As Integer
    Private mobjTrans As OracleTransaction
    Private mstrConnectString As String
    Private Owner As Object                         'オーナオブジェクト
    Private da As New OracleDataAdapter             'Oracle ﾃﾞｰﾀ ｱﾀﾞﾌﾟﾀ

    'ﾊﾞｲﾝﾄﾞ変数用ｵﾌﾞｼﾞｪｸﾄ
    Private mBndObj(,) As Object                   'ﾊﾞｲﾝﾄﾞ変数用ｵﾌﾞｼﾞｪｸﾄ

    Protected mblnReconnectingFlg As Boolean      'ｺﾈｸﾄ状態が未接続状態時に再接続するかどうかのﾌﾗｸﾞ
    '                                              True：再接続する。　False：再接続しない。
#End Region

#Region " ｲﾍﾞﾝﾄ宣言 "

    'DB切断ｲﾍﾞﾝﾄ
    Public Delegate Sub ConnectBrokenEventHandler(ByVal Sender As Object)
    Public Event ConnectBroken As ConnectBrokenEventHandler

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intConnectRtryCnt">DB再接続ﾘﾄﾗｲ回数(1はﾘﾄﾗｲなし)※省略時は1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(Optional ByVal intConnectRtryCnt As Integer = 1)
        Owner = Nothing
        RETRY_COUNT = intConnectRtryCnt  'DB再接続ﾘﾄﾗｲ回数
    End Sub

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="objOwner">オーナオブジェクト定義</param>
    ''' <param name="intConnectRtryCnt">DB再接続ﾘﾄﾗｲ回数(1はﾘﾄﾗｲなし)※省略時は1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, Optional ByVal intConnectRtryCnt As Integer = 1)
        Owner = objOwner        'オーナオブジェクト定義
        RETRY_COUNT = intConnectRtryCnt  'DB再接続ﾘﾄﾗｲ回数
    End Sub

#End Region

#Region "  Finalize"

    Protected Overrides Sub Finalize()
        Owner = Nothing
        mobjOraValue = Nothing
        mobjFieldName = Nothing
        If IsNothing(mobjTrans) = False Then
            mobjTrans.Dispose()
            mobjTrans = Nothing
        End If
        If IsNothing(mobjRdr) = False Then
            mobjRdr.Close()
            mobjRdr.Dispose()
            mobjRdr = Nothing
        End If
        If IsNothing(mobjOraCon) = False Then
            mobjOraCon.Close()
            mobjOraCon.Dispose()
            mobjOraCon = Nothing
        End If
        MyBase.Finalize()
    End Sub

#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ"
    '------------------------------------------------------------------------
    ' プロパティ
    '------------------------------------------------------------------------
    ''' =======================================
    ''' <summary>OraCon プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property OraCon() As Object
        Get
            Return mobjOraCon
        End Get
    End Property

    ''' =======================================
    ''' <summary>Rdr プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property Rdr() As Object
        Get
            Return mobjRdr
        End Get
    End Property

    ''' =======================================
    ''' <summary>ErrMsg プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ErrMsg() As String
        Get
            Return mstrErrMsg
        End Get
    End Property

    ''' =======================================
    ''' <summary>ErrCode プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ErrCode() As Integer
        Get
            Return mintErrCode
        End Get
    End Property

    ''' =======================================
    ''' <summary>SQL プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property SQL() As String
        Get
            Return mstrSQL
        End Get
        Set(ByVal Value As String)
            mstrSQL = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ConnectString プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property ConnectString() As String
        Get
            Return mstrConnectString
        End Get
        Set(ByVal Value As String)
            mstrConnectString = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Parameter プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property Parameter() As Object
        Get
            Return mBndObj
        End Get
        Set(ByVal value As Object)
            mBndObj = value
        End Set
    End Property

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Data プロパティ
    ''' </summary>
    ''' <param name="intIndex">0から始まるフィールドインデックス</param>
    ''' <value></value>
    ''' <returns>フィールドデータ</returns>
    ''' <remarks>フィールドデータの取得</remarks>
    ''' *******************************************************************************************************************
    Public Overloads ReadOnly Property Data(ByVal intIndex As Integer) As Object
        Get
            Return mobjOraValue(intIndex)
        End Get
    End Property

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Data
    ''' </summary>
    ''' <param name="strIndex">フィールド名</param>
    ''' <value></value>
    ''' <returns>フィールドデータ</returns>
    ''' <remarks>フィールドデータの取得</remarks>
    ''' *******************************************************************************************************************
    Public Overloads ReadOnly Property Data( _
        ByVal strIndex As String _
        ) As Object
        Get
            Dim intIndex As Integer
            intIndex = SearchFieldIndex(strIndex)
            If intIndex >= 0 Then
                Return mobjOraValue(intIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "  Connect"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' データベースに接続
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Connect() As Boolean
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = True
        '排他処理
        Dim objMtx As New Mutex(requestInitialOwnership, "mConnenct", mutexWasCreated)

        '排他待ち処理
        If Not (requestInitialOwnership And mutexWasCreated) Then
            objMtx.WaitOne()
        End If
        Try
            '--------------------------------------------------------------------
            ' データベースに接続
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            For i = 0 To RETRY_COUNT - 1
                Try
                    '接続処理
                    If IsNothing(mobjOraCon) = True Then
                        mobjOraCon = New OracleConnection
                        mobjOraCon.ConnectionString = mstrConnectString
                        mobjOraCon.Open()
                        Exit For
                    Else
                        Exit For
                    End If
                Catch ex As OracleException
                    strErrMsg = ex.Message
                    Call SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '追加　Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '削除　Rev 0.03
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Disconnect()
                        blnRet = False
                    End If
                End Try
            Next

        Finally
            '排他処理開放
            objMtx.ReleaseMutex()
        End Try

        Return blnRet

    End Function
#End Region

#Region "  Disconnect"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' データベースを切断
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Disconnect() As Boolean
        Dim strErrMsg As String
        Dim blnRet As Boolean

        blnRet = True
        '--------------------------------------------------------------------
        ' データベースを切断
        '--------------------------------------------------------------------
        'Call ClearExceptionData()
        Try
            If IsNothing(mobjRdr) = False Then
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing
            End If
            If IsNothing(mobjOraCon) = False Then
                mobjOraCon.Close()
                mobjOraCon.Dispose()
                mobjOraCon = Nothing
            End If
        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
            blnRet = False
        End Try

        Return blnRet
    End Function
#End Region

#Region "  GetData"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 引数またはSQLプロパティに設定されたSELECT文でデータを取得
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks>引き数:SQL文(省略時、SQLプロパティ設定されたSQLを実行)</remarks>
    ''' *******************************************************************************************************************
    Public Function GetData() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim intCnt As Integer
        Dim oCmd As OracleCommand = Nothing

        blnRet = False
        '--------------------------------------------------------------------
        ' SELECT文でデータを取得
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                End If
                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If

                oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ処理
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ用ｵﾌﾞｼﾞｪｸﾄがある場合)

                    '--------------------------------------------------------------------
                    ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(ﾊﾞｲﾝﾄﾞ変数に値をｾｯﾄ)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObjにnothingを設定

                End If


                mobjRdr = oCmd.ExecuteReader()

                '--------------------------------------------------------------------
                ' フィールドデータを取得
                '--------------------------------------------------------------------
                mobjFieldName.Clear()
                For intCnt = 0 To mobjRdr.FieldCount - 1
                    Dim intIndex As Integer
                    intIndex = mobjFieldName.Add(mobjRdr.GetName(intCnt))
                Next

                oCmd.Dispose()
                oCmd = Nothing

                blnRet = True
                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '削除　Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet
    End Function
#End Region

#Region "  GetDataSet"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 引数またはSQLプロパティに設定されたSELECT文でデータを取得 結果を DataSet に格納する
    ''' </summary>
    ''' <param name="strCur">テーブル マップに使用するソース テーブルの名</param>
    ''' <param name="dsData">データセット</param>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks>ﾊﾞｲﾝﾄﾞ変数試用　(kato)</remarks>
    ''' *******************************************************************************************************************
    Public Function GetDataSet(ByVal strCur As String, _
                               ByRef dsData As DataSet) As Boolean


        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        blnRet = False

        Try
            '--------------------------------------------------------------------
            ' SELECT文でデータを取得後、データセットに格納
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            For i = 0 To RETRY_COUNT - 1
                Try
                    If IsNothing(mobjOraCon) = True Then
                        If Connect() = False Then
                            RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                            Throw New SystemException("DB再接続に失敗しました")
                        End If
                    End If
                    'Dim sg As OracleGlobalization = mobjOraCon.GetSessionInfo()
                    oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                    oCmd.BindByName = True
                    da = New OracleDataAdapter(oCmd)

                    '====================================================================
                    ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ処理
                    '====================================================================
                    If IsNothing(mBndObj) = False Then
                        '(ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ用ｵﾌﾞｼﾞｪｸﾄがある場合)

                        '--------------------------------------------------------------------
                        ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ
                        '--------------------------------------------------------------------
                        For intii As Integer = 0 To UBound(mBndObj, 2)
                            '(ﾊﾞｲﾝﾄﾞ変数に値をｾｯﾄ)
                            da.SelectCommand.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                        Next

                        mBndObj = Nothing           'mBndObjにnothingを設定

                    End If


                    da.Fill(dsData, strCur)

                    oCmd.Dispose()
                    oCmd = Nothing

                    blnRet = True
                    Exit For
                Catch ex As OracleException
                    strErrMsg = ex.Message

                    If IsNothing(da) = False Then
                        da.Dispose()
                        da = Nothing
                    End If
                    If IsNothing(oCmd) = False Then
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If

                    SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '追加　Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '削除　Rev 0.03
                        'mobjOraCon = Nothing
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Throw ex
                    End If
                Catch exs As Exception
                    Throw exs
                End Try
            Next
        Finally
            If IsNothing(da) = False Then
                da.Dispose()
                da = Nothing
            End If
        End Try

        Return blnRet
    End Function
#End Region

#Region "  Read"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' SELECT文で取得したデータを一行取得
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Read() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim intFieldNo As Integer
        Dim intCounter As Integer
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' 一行分のデータを取得
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                End If

                If IsNothing(mobjRdr) = True Then
                    GetData()
                End If

                If mobjRdr.Read() = True Then
                    intFieldNo = mobjRdr.FieldCount
                    ReDim mobjOraValue(intFieldNo - 1)              ' フィールド分の配列を作成
                    mintOraValueCnt = intFieldNo                    ' 配列数を保存(CloseDBで使用)
                    For intCounter = 0 To intFieldNo - 1            ' フィールド分オブジェクトをセット
                        mobjOraValue(intCounter) = mobjRdr.GetValue(intCounter)
                    Next intCounter
                    blnRet = True
                    Exit For
                End If
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '削除　Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet
    End Function
#End Region

#Region "  CloseDataReader"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' データリーダをクローズ
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CloseDataReader() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String

        blnRet = False
        '--------------------------------------------------------------------
        ' データリーダをクローズ
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        Try
            If IsNothing(mobjRdr) = False Then
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing
            End If

            blnRet = True

        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
        End Try

        Return blnRet

    End Function
#End Region

#Region "  Execute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 引数またはSQLプロパティに設定されたSQLを実行
    ''' </summary>
    ''' <param name="asSQL">SQL文 （省略時、SQLプロパティ設定されたSQLを実行</param>
    ''' <returns>正常時 処理件数(処理無し 0)/ 異常時 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function Execute(Optional ByVal asSQL As String = "") As Integer
        Dim intRet As Integer     ' 汎用戻値
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        intRet = -1
        If asSQL <> "" Then
            mstrSQL = asSQL
        End If
        '--------------------------------------------------------------------
        ' SQL実行
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                End If
                oCmd = New OracleCommand(mstrSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ処理
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ用ｵﾌﾞｼﾞｪｸﾄがある場合)

                    '--------------------------------------------------------------------
                    ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(ﾊﾞｲﾝﾄﾞ変数に値をｾｯﾄ)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObjにnothingを設定

                End If

                intRet = oCmd.ExecuteNonQuery()

                oCmd.Dispose()
                oCmd = Nothing

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '削除　Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return intRet

    End Function
#End Region

#Region "  GetCount"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 現レコードセットの件数の取得
    ''' </summary>
    ''' <param name="asSQL"></param>
    ''' <returns>正常時 レコード件数 / 異常時 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetCount( _
        Optional ByVal asSQL As String = "" _
    ) As Integer
        Dim intCount As Integer
        Dim strErrMsg As String
        Dim i As Integer
        Dim oCmd As OracleCommand = Nothing

        intCount = -1
        '--------------------------------------------------------------------
        ' 件数取得
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                End If
                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If

                oCmd = New OracleCommand(asSQL, mobjOraCon)
                oCmd.BindByName = True

                '====================================================================
                ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ処理
                '====================================================================
                If IsNothing(mBndObj) = False Then
                    '(ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ用ｵﾌﾞｼﾞｪｸﾄがある場合)

                    '--------------------------------------------------------------------
                    ' ﾊﾞｲﾝﾄﾞ変数ｾｯﾄ
                    '--------------------------------------------------------------------
                    For intii As Integer = 0 To UBound(mBndObj, 2)
                        '(ﾊﾞｲﾝﾄﾞ変数に値をｾｯﾄ)
                        oCmd.Parameters.Add(mBndObj(0, intii), mBndObj(1, intii))
                    Next

                    mBndObj = Nothing           'mBndObjにnothingを設定

                End If


                mobjRdr = oCmd.ExecuteReader()
                While mobjRdr.Read()
                    intCount = CInt(mobjRdr.GetValue(0))
                End While
                mobjRdr.Close()
                mobjRdr.Dispose()
                mobjRdr = Nothing

                oCmd.Dispose()
                oCmd = Nothing

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message

                If IsNothing(mobjRdr) = False Then
                    mobjRdr.Close()
                    mobjRdr.Dispose()
                    mobjRdr = Nothing
                End If
                If IsNothing(oCmd) = False Then
                    oCmd.Dispose()
                    oCmd = Nothing
                End If

                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    'mobjOraCon = Nothing
                    '' ''Disconnect()                    '削除　Rev 0.03
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return intCount

    End Function
#End Region

#Region "  GetFieldCount"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 現レコードセットのフィールド数の取得
    ''' </summary>
    ''' <returns>正常時 フィールド数 / 異常時 -1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetFieldCount() As Long
        Dim lCount As Long
        Dim strErrMsg As String

        lCount = -1
        '--------------------------------------------------------------------
        ' フィールド数取得
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        Try
            lCount = mobjRdr.FieldCount
        Catch ex As OracleException
            strErrMsg = ex.Message
            Call SetExceptionData(ex.Message, ex.Number)
            Throw ex
        End Try

        Return lCount

    End Function
#End Region

#Region "  BeginTrans"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' トランザクション開始処理
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BeginTrans() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' トランザクション開始
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                End If

                If IsNothing(mobjTrans) = False Then
                    mobjTrans.Dispose()
                    mobjTrans = Nothing
                End If
                mobjTrans = mobjOraCon.BeginTransaction()

                blnRet = True
                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '削除　Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  Commit"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' コミット処理
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Commit() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' コミット実行
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                Else
                    If IsNothing(mobjTrans) = False Then
                        If IsNothing(mobjTrans.Connection) = False Then
                            mobjTrans.Commit()
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                            blnRet = True
                        Else
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                        End If
                    End If
                End If

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '削除　Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  RollBack"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ロールバック処理
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function RollBack() As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer

        blnRet = False
        '--------------------------------------------------------------------
        ' ロールバック実行
        '--------------------------------------------------------------------
        Call ClearExceptionData()
        For i = 0 To RETRY_COUNT - 1
            Try
                If IsNothing(mobjOraCon) = True Then
                    If Connect() = False Then
                        RaiseEvent ConnectBroken(Me)        'DB切断通知ｲﾍﾞﾝﾄ
                        Throw New SystemException("DB再接続に失敗しました")
                    End If
                Else
                    If IsNothing(mobjTrans) = False Then
                        If IsNothing(mobjTrans.Connection) = False Then
                            mobjTrans.Rollback()
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                            blnRet = True
                        Else
                            mobjTrans.Dispose()
                            mobjTrans = Nothing
                        End If
                    End If
                End If

                Exit For
            Catch ex As OracleException
                strErrMsg = ex.Message
                SetExceptionData(ex.Message, ex.Number)
                Disconnect()                    '追加　Rev 0.03
                If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                    '' ''Disconnect()                    '削除　Rev 0.03
                    'mobjOraCon = Nothing
                    Thread.Sleep(SLEEP_TIME)
                Else
                    Throw ex
                End If
            Catch exs As Exception
                Throw exs
            End Try
        Next

        Return blnRet

    End Function
#End Region

#Region "  ConnenctSrv"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' データベースに接続
    ''' </summary>
    ''' <returns>正常時 true / 異常時 false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function ConnenctSrv() As Boolean
        Dim requestInitialOwnership As Boolean = True
        Dim mutexWasCreated As Boolean
        Dim blnRet As Boolean
        Dim strErrMsg As String
        Dim i As Integer
        Dim blnExit As Boolean

        blnRet = True
        '排他処理
        Dim objMtx As New Mutex(requestInitialOwnership, "mConnenctSrv", mutexWasCreated)

        '排他待ち処理
        If Not (requestInitialOwnership And mutexWasCreated) Then
            objMtx.WaitOne()
        End If
        Try
            '--------------------------------------------------------------------
            ' データベースに接続
            '--------------------------------------------------------------------
            Call ClearExceptionData()
            blnExit = False
            Do While blnExit = False
                Try
                    '接続処理
                    If IsNothing(mobjOraCon) = True Then
                        mobjOraCon = New OracleConnection
                        mobjOraCon.ConnectionString = mstrConnectString
                        mobjOraCon.Open()
                        blnExit = True
                    End If
                Catch ex As OracleException
                    strErrMsg = ex.Message
                    Call SetExceptionData(ex.Message, ex.Number)
                    Disconnect()                    '追加　Rev 0.03
                    If (IsRetry(ex.Number) = True) And (i < RETRY_COUNT - 1) Then
                        '' ''Disconnect()                    '削除　Rev 0.03
                        Thread.Sleep(SLEEP_TIME)
                    Else
                        Disconnect()
                        blnRet = False
                    End If
                End Try
            Loop

        Finally
            '排他処理開放
            objMtx.ReleaseMutex()
        End Try

        Return blnRet

    End Function
#End Region

#Region "  AddToLog"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ログ書き込み処理
    ''' </summary>
    ''' <param name="buf"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AddToLog(ByVal buf As String)

        If IsNothing(Owner) = False Then
            Owner.AddToLog(buf)
        End If

    End Sub
#End Region

#Region "  SetExceptionData"
    Protected Sub SetExceptionData( _
        ByVal strMsg As String, _
        ByVal intCode As Integer)

        mstrErrMsg = strMsg
        mintErrCode = intCode
    End Sub
#End Region

#Region "  ClearExceptionData"
    Protected Sub ClearExceptionData()
        mstrErrMsg = ""
        mintErrCode = 0
    End Sub
#End Region

#Region "  IsRetry"
    Protected Function IsRetry( _
        ByVal intErrCode As Integer) As Boolean

        Dim blnRet As Boolean

        blnRet = True
        Select Case intErrCode
            Case RetryErrCode.ErrCode01033
            Case RetryErrCode.ErrCode01034
            Case RetryErrCode.ErrCode01089
            Case RetryErrCode.ErrCode03001
            Case RetryErrCode.ErrCode03113
            Case RetryErrCode.ErrCode03114
            Case RetryErrCode.ErrCode12203
            Case RetryErrCode.ErrCode12500
            Case RetryErrCode.ErrCode12537
            Case RetryErrCode.ErrCode12545
            Case RetryErrCode.ErrCode12560
            Case RetryErrCode.ErrCode12571
            Case Else
                blnRet = False
        End Select
        Return (blnRet)
    End Function
#End Region

#Region "  SearchFieldIndex"
    Private Function SearchFieldIndex(ByVal strIndex As String) As Integer
        Dim intCount As Integer
        Dim intIndex As Integer

        intIndex = -1
        If mobjFieldName.Count > 0 Then
            For intCount = 0 To mobjFieldName.Count - 1
                If StrComp(mobjFieldName.Item(intCount), strIndex, CompareMethod.Text) = 0 Then
                    intIndex = intCount
                    Exit For
                End If
            Next
        End If

        Return (intIndex)

    End Function
#End Region


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '         　　2010/05/27  SIT J.Kato
    '           　PL/SQLﾌｧﾝｸｼｮﾝをCallするﾒｿｯﾄﾞを追加
#Region "  StoredFunctionExeute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' PL/SQLﾌｧﾝｸｼｮﾝCallﾒｿｯﾄﾞ
    ''' </summary>
    ''' <param name="strFuncionName"></param>
    ''' <param name="udtParamater"></param>
    ''' <param name="strFunctionReturn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StoredFunctionExeute(ByVal strFuncionName As String, _
                                         ByRef udtParamater() As OraParam, _
                                         ByRef strFunctionReturn As Integer _
                                        ) As Boolean

        Dim blnRet As Boolean = True

        '=============================================
        'ｵﾗｸﾙｺﾏﾝﾄﾞｵﾌﾞｼﾞｪｸﾄ作成
        '=============================================
        Dim objCommand As New OracleCommand(strFuncionName, mobjOraCon)
        objCommand.CommandType = CommandType.StoredProcedure

        '=============================================
        'ﾊﾟﾗﾒｰﾀｸﾘｱ
        '=============================================
        objCommand.Parameters.Clear()

        '=============================================
        'ﾌｧﾝｸｼｮﾝReturnﾊﾟﾗﾒｰﾀｾｯﾄ
        '=============================================
        Dim objReturnPram As OracleParameter
        objReturnPram = New OracleParameter("Ret", OracleDbType.Int32, ParameterDirection.ReturnValue)
        objCommand.Parameters.Add(objReturnPram)

        Dim objParamType As OracleDbType = Nothing

        If IsNothing(udtParamater) <> True Then
            '(ﾊﾟﾗﾒｰﾀがｾｯﾄされている場合)
            For ii As Integer = 0 To UBound(udtParamater)

                '=============================================
                'ﾌｧﾝｸｼｮﾝ引数設定
                '=============================================

                Select Case udtParamater(ii).DbType
                    Case OraDBType.Type_NVarchar2
                        objParamType = OracleDbType.NVarchar2
                    Case OraDBType.Type_Int32
                        objParamType = OracleDbType.Int32
                    Case OraDBType.Type_Decimal
                        objParamType = OracleDbType.Decimal
                    Case OraDBType.Type_Date
                        objParamType = OracleDbType.Date
                End Select

                'ﾊﾟﾗﾒｰﾀ追加
                objCommand.Parameters.Add(udtParamater(ii).Name, _
                                          objParamType, _
                                          udtParamater(ii).Size, _
                                          udtParamater(ii).Value, _
                                          udtParamater(ii).Direction)

                ' ''ﾊﾟﾗﾒｰﾀ追加
                ''objCommand.Parameters.Add(udtParamater(ii).Name, _
                ''                          udtParamater(ii).DbType, _
                ''                          udtParamater(ii).Value, _
                ''                          udtParamater(ii).Direction)
            Next
        End If

        '=============================================
        'ｽﾄｱﾄﾞﾌｧﾝｸｼｮﾝの実行
        '=============================================
        Call objCommand.ExecuteNonQuery()

        '=============================================
        '取得ﾊﾟﾗﾒｰﾀｾｯﾄ
        '=============================================
        If IsNothing(udtParamater) <> True Then
            For ii As Integer = 0 To UBound(udtParamater)
                If udtParamater(ii).Direction = ParameterDirection.InputOutput Or _
                   udtParamater(ii).Direction = ParameterDirection.Output Then
                    '(戻り値引数がある場合)
                    Dim objData As Object
                    objData = Nothing
                    Select Case objCommand.Parameters(udtParamater(ii).Name).DbType
                        Case DbType.String
                            objData = objCommand.Parameters(udtParamater(ii).Name).Value.ToString
                        Case DbType.Int16, DbType.Int32, DbType.Int64
                            objData = CInt(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Date
                            objData = CDate(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Decimal
                            objData = CDec(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Double
                            objData = CDbl(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                    End Select

                    udtParamater(ii).Value = objData
                End If
            Next
        End If

        '=============================================
        'ｵﾗｸﾙReturnｾｯﾄ
        '=============================================
        strFunctionReturn = CInt(objCommand.Parameters("Ret").Value.ToString)


        Return blnRet

    End Function
#End Region

    '         　　2010/05/27  SIT J.Kato
    '           　PL/SQLﾌﾟﾛｼｰｼﾞｬをCallするﾒｿｯﾄﾞを追加
#Region "  StoredProcedureExeute"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' PL/SQLﾌﾟﾛｼｰｼﾞｬCallﾒｿｯﾄﾞ
    ''' </summary>
    ''' <param name="strFuncionName"></param>
    ''' <param name="udtParamater"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StoredProcedureExeute(ByVal strFuncionName As String, _
                                          ByRef udtParamater() As OraParam _
                                         ) As Boolean

        Dim blnRet As Boolean = True

        '=============================================
        'ｵﾗｸﾙｺﾏﾝﾄﾞｵﾌﾞｼﾞｪｸﾄ作成
        '=============================================
        Dim objCommand As New OracleCommand(strFuncionName, mobjOraCon)
        objCommand.CommandType = CommandType.StoredProcedure

        '=============================================
        'ﾊﾟﾗﾒｰﾀｸﾘｱ
        '=============================================
        objCommand.Parameters.Clear()

        Dim objParamType As OracleDbType = Nothing

        If IsNothing(udtParamater) <> True Then
            '(ﾊﾟﾗﾒｰﾀがｾｯﾄされている場合)
            For ii As Integer = 0 To UBound(udtParamater)

                Select Case udtParamater(ii).DbType
                    Case OraDBType.Type_NVarchar2
                        objParamType = OracleDbType.NVarchar2
                    Case OraDBType.Type_Int32
                        objParamType = OracleDbType.Int32
                    Case OraDBType.Type_Decimal
                        objParamType = OracleDbType.Decimal
                    Case OraDBType.Type_Date
                        objParamType = OracleDbType.Date
                End Select

                '=============================================
                'ﾌｧﾝｸｼｮﾝ引数設定
                '=============================================
                'ﾊﾟﾗﾒｰﾀ追加
                objCommand.Parameters.Add(udtParamater(ii).Name, _
                                          objParamType, _
                                          udtParamater(ii).Size, _
                                          udtParamater(ii).Value, _
                                          udtParamater(ii).Direction)

                ' ''=============================================
                ' ''ﾌｧﾝｸｼｮﾝ引数設定
                ' ''=============================================
                ' ''ﾊﾟﾗﾒｰﾀ追加
                ''objCommand.Parameters.Add(udtParamater(ii).Name, _
                ''                          udtParamater(ii).DbType, _
                ''                          udtParamater(ii).Value, _
                ''                          udtParamater(ii).Direction)
            Next
        End If

        '=============================================
        'ｽﾄｱﾄﾞﾌｧﾝｸｼｮﾝの実行
        '=============================================
        Call objCommand.ExecuteNonQuery()

        '=============================================
        '取得ﾊﾟﾗﾒｰﾀｾｯﾄ
        '=============================================
        If IsNothing(udtParamater) <> True Then
            For ii As Integer = 0 To UBound(udtParamater)
                If udtParamater(ii).Direction = ParameterDirection.InputOutput Or _
                   udtParamater(ii).Direction = ParameterDirection.Output Then
                    '(戻り値引数がある場合)
                    Dim objData As Object
                    objData = Nothing
                    Select Case objCommand.Parameters(udtParamater(ii).Name).DbType
                        Case DbType.String
                            objData = objCommand.Parameters(udtParamater(ii).Name).Value.ToString
                        Case DbType.Int16, DbType.Int32, DbType.Int64
                            objData = CInt(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Date
                            objData = CDate(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Decimal
                            objData = CDec(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                        Case DbType.Double
                            objData = CDbl(objCommand.Parameters(udtParamater(ii).Name).Value.ToString)
                    End Select

                    udtParamater(ii).Value = objData
                End If
            Next
        End If

        Return blnRet

    End Function
#End Region

#Region "　OraParam(ﾌｧﾝｸｼｮﾝ/ﾌﾟﾛｼｰｼﾞｬ引数)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｧﾝｸｼｮﾝ・ﾌﾟﾛｼｰｼﾞｬﾊﾟﾗﾒｰﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Structure OraParam
        Dim Name As String
        Dim DbType As OraDBType
        Dim Size As Integer
        Dim Value As Object
        Dim Direction As ParameterDirection
    End Structure
#End Region

#Region "　OracleDBType(OraPram用)"

    Public Enum OraDBType
        Type_Int32 = OracleDbType.Int32
        Type_NVarchar2 = OracleDbType.NVarchar2
        Type_Decimal = OracleDbType.Decimal
        Type_Date = OracleDbType.Date
    End Enum

#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
