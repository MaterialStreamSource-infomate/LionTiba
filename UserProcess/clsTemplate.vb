'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｸﾗｽﾃﾝﾌﾟﾚｰﾄ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports"
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class clsTemplate

#Region "  共通変数"
    Private mdlOwner As Object                  'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ
    Private mdlObjDb As clsConn                 'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ
    Private mdlObjDbLog As clsConn              'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    ''' =======================================
    ''' <summary>ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property Owner() As Object
        Get
            Owner = mdlOwner
        End Get
    End Property
    ''' =======================================
    ''' <summary>DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ObjDb() As clsConn
        Get
            ObjDb = mdlObjDb
        End Get
    End Property
    ''' =======================================
    ''' <summary>DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ObjDbLog() As clsConn
        Get
            ObjDbLog = mdlObjDbLog
        End Get
    End Property
#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        'ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ定義
        mdlOwner = objOwner
        mdlObjDb = objDb
        mdlObjDbLog = objDbLog
    End Sub
#End Region

#Region "  ﾃﾞｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub Finalize()
        Close()
    End Sub
#End Region

#Region "  ｸﾛｰｽﾞ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub Close()
        'ｵﾌﾞｼﾞｪｸﾄ開放
        mdlOwner = Nothing
        mdlObjDb = Nothing
        mdlObjDbLog = Nothing
    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'Checked SystemMate:N.Dounoshita 2011/10/25 ｽﾚｯﾄﾞ用DB接続方法の修正
#Region "  ｽﾚｯﾄﾞ用DB接続ｵﾌﾞｼﾞｪｸﾄの生成"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub GetclsConnThreadConnect()


        '************************
        '色々ﾁｪｯｸ
        '************************
        If IsNotNull(mdlObjDb) Then Throw New Exception("DB接続定義ｴﾗｰ")
        If IsNotNull(mdlObjDbLog) Then Throw New Exception("DB接続定義ｴﾗｰ")


        '************************
        ' ｽﾚｯﾄﾞ用DB接続
        '************************
        Dim blnRet As Boolean = False
        Dim objThreadDb As New clsConn
        Dim objThreadDbLog As New clsConn

        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続
        objThreadDb.ConnectString = ConfigFile.DBConnectString
        blnRet = objThreadDb.Connect()

        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続(ﾛｸﾞ書込み用)
        blnRet = False
        objThreadDbLog.ConnectString = ConfigFile.DBConnectString
        blnRet = objThreadDbLog.Connect()

        '共通変数にｾｯﾄ
        mdlObjDb = objThreadDb
        mdlObjDbLog = objThreadDbLog


    End Sub
#End Region
#Region "  ｽﾚｯﾄﾞ用DB接続ｵﾌﾞｼﾞｪｸﾄの開放"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub DeleteclsConnThreadConnect()


        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続
        If IsNotNull(mdlObjDb) Then
            mdlObjDb.Disconnect()
            mdlObjDb = Nothing
        End If

        'DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ接続(ﾛｸﾞ書込み用)
        If IsNotNull(mdlObjDb) Then
            mdlObjDbLog.Disconnect()
            mdlObjDbLog = Nothing
        End If


    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class