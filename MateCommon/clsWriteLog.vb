'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾛｸﾞ出力
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.IO
#End Region

Public Class clsWriteLog

#Region "  共通定数＆変数"
    '------------------------------------------------------------------------
    '定数宣言
    '------------------------------------------------------------------------
    Private Const FOMT_DATE_TIME As String = "yyyy/MM/dd HH:mm:ss"
    Private strDate As String      ' 日付
    Private strC1 As String
    Private strTime As String      ' 時刻
    Private strC2 As String
    Private strProg As String      ' ﾌﾟﾛｸﾞﾗﾑ名
    Private strC3 As String
    Private strFunc As String      ' 関数名
    Private strC4 As String
    Private strMsg As String       ' ﾒｯｾｰｼﾞ


    Private strCRLF As String
    '------------------------------------------------------------------------
    ' 内部変数
    '------------------------------------------------------------------------
    Private mstrFileName As String
    Private mstrCopyName As String
    Private mlngMaxSize As Long
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>clspFilePath プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property clspFileName( _
      ) As String
        Get
            Return (mstrFileName)
        End Get
        Set(ByVal Value As String)
            mstrFileName = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>clspCopyFile プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property clspCopyFile( _
     ) As String
        Get
            Return (mstrCopyName)
        End Get
        Set(ByVal Value As String)
            mstrCopyName = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>clspMaxSize プロパティ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property clspMaxSize( _
      ) As Long
        Get
            Return (mlngMaxSize)
        End Get
        Set(ByVal Value As Long)
            mlngMaxSize = Value
        End Set
    End Property
#End Region

#Region "  ﾛｸﾞﾌｧｲﾙ書込み            (Public  clsmWriteLog)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞﾌｧｲﾙ書込み
    ''' </summary>
    ''' <param name="strMsg_1"></param>
    ''' <param name="strMsg_2"></param>
    ''' <param name="strMsg_3"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub WriteLog(ByVal strMsg_1 As String, _
                             Optional ByVal strMsg_2 As String = "", _
                             Optional ByVal strMsg_3 As String = "")

        Try
            Dim fi As FileInfo
            Dim strWriteBuf As String
            Dim writer As StreamWriter

            ' ログ情報の格納
            strDate = Format(Now, "yyyy/MM/dd")
            strTime = Format(Now, "HH:mm:ss.ffffff")
            strWriteBuf = ""
            strWriteBuf = strWriteBuf & strDate
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strTime
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_2
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_3
            strWriteBuf = strWriteBuf & ","
            strWriteBuf = strWriteBuf & strMsg_1
            strWriteBuf = strWriteBuf & Chr(13) & Chr(10)


            '=========================================
            'ﾌｫﾙﾀﾞがなかった場合は自動生成
            '=========================================
            Dim strDirectoryName As String = System.IO.Path.GetDirectoryName(mstrFileName)
            If False = System.IO.Directory.Exists(strDirectoryName) Then
                Call System.IO.Directory.CreateDirectory(strDirectoryName)      'ﾌｫﾙﾀﾞ作成
            End If


            '---------------------------------------------------------
            ' ファイルの容量チェック
            '---------------------------------------------------------
            fi = New FileInfo(mstrFileName)
            If fi.Exists = True Then
                'ファイルが存在する場合
                If fi.Length >= mlngMaxSize Then
                    'ファイルをコピー
                    fi.CopyTo(mstrCopyName, True)
                    'データを上書き
                    '' ''writer = New StreamWriter(mstrFileName, False)
                    writer = New StreamWriter(mstrFileName, False, System.Text.Encoding.GetEncoding(932))   'shift_jis で出力
                Else
                    'データを追加
                    '' ''writer = New StreamWriter(mstrFileName, True)
                    writer = New StreamWriter(mstrFileName, True, System.Text.Encoding.GetEncoding(932))    'shift_jis で出力
                End If
            Else
                'ファイルが存在しない場合
                '' ''writer = New StreamWriter(mstrFileName, False)
                writer = New StreamWriter(mstrFileName, False, System.Text.Encoding.GetEncoding(932))       'shift_jis で出力
            End If
            writer.Write(strWriteBuf)
            writer.Flush()
            writer.Close()
            writer = Nothing

        Catch ex As Exception
            '何もしない

        End Try
    End Sub
#End Region

End Class

