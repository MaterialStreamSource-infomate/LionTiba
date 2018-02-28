'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文作成ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

Imports System.Xml
Public Class clsTelegram

    '*********************************************
    'Public宣言
    '*********************************************
#Region "  共通変数、共通定数                   "
    '***********************************************************************************************
    '共通変数
    '***********************************************************************************************
    'ﾌﾟﾛﾊﾟﾃｨ変数
    Private mstrTELEGRAM_MAKED As String        '作成された電文
    Private mstrTELEGRAM_PARTITION As String    '分割する電文
    Private mstrHEADER As String                'ﾍｯﾀﾞｰ
    Private mstrDATA As String                  'ﾃﾞｰﾀ
    Private mstrFORMAT_ID As String             'ﾌｫｰﾏｯﾄID
    Private mintTEL_LEN As Integer              '電文全体の長さ     （ 0 以下の場合は、電文全体の長さは調節しない）
    Private mblnHEADER_FLUG As Boolean          'ﾍｯﾀﾞｰ部分処理ﾌﾗｸﾞ  （True = 処理する　False = 処理しない    ﾃﾞﾌｫﾙﾄ:True）
    Private mstrFILLER As String                'Filler文字列       （ﾃﾞﾌｫﾙﾄ = Space(1)）        
    Private mobjDocument As New XmlDocument     'ｸﾗｽｲﾝｽﾀﾝｽ化

    'その他
    Private mstrFILENAME As String              '読み込む定義ﾌｧｲﾙのﾊﾟｽ
    Private mobjConfigData As Collection        'ﾃﾞｰﾀ部分を格納するｺﾚｸｼｮﾝ
    Private mobjConfigHeader As Collection      'ﾍｯﾀﾞｰ部分を格納するｺﾚｸｼｮﾝ


    '***********************************************************************************************
    '共通定数
    '***********************************************************************************************
    'XML
    Private Const XML_NODE_CONFIG As String = "configuration"
    Private Const XML_NODE_HEADER As String = "HEADER"
    Private Const XML_NODE_KEY As String = "key"
    Private Const XML_NODE_VALUE As String = "value"
    Private Const XML_NODE_ADD As String = "add"
    Private Const XML_NODE_ID_PREFIX As String = "ID_"
    'ﾒｯｾｰｼﾞ
    Private Const ERROR_MESSAGE_01 As String = "にキーがありません    ["

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                          "
    ''' =======================================
    ''' <summary>作成された電文</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property TELEGRAM_MAKED() As String
        Get
            Return mstrTELEGRAM_MAKED
        End Get
    End Property

    ''' =======================================
    ''' <summary>分割する電文</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property TELEGRAM_DATA() As String
        Get
            Return mstrDATA
        End Get
    End Property

    ''' =======================================
    ''' <summary>ﾍｯﾀﾞｰ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property TELEGRAM_HEADER() As String
        Get
            Return mstrHEADER
        End Get
    End Property

    Public Property TELEGRAM_PARTITION() As String
        Get
            Return mstrTELEGRAM_PARTITION
        End Get
        Set(ByVal Value As String)
            mstrTELEGRAM_PARTITION = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾌｫｰﾏｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FORMAT_ID() As String
        Get
            Return mstrFORMAT_ID
        End Get
        Set(ByVal Value As String)
            mstrFORMAT_ID = Value

            '***********************************
            'Configから定義取得
            '***********************************
            Call GET_DATAFORMAT_FOR_CONFIG()
        End Set
    End Property

    ''' =======================================
    ''' <summary>電文全体の長さ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property TEL_LEN() As Integer
        Get
            Return mintTEL_LEN
        End Get
        Set(ByVal Value As Integer)
            mintTEL_LEN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary></summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property HEADER_FLUG() As Boolean
        Get
            Return mblnHEADER_FLUG
        End Get
        Set(ByVal Value As Boolean)
            mblnHEADER_FLUG = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Filler文字列</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FILLER() As String
        Get
            Return mstrFILLER
        End Get
        Set(ByVal Value As String)
            mstrFILLER = Value
        End Set
    End Property

#End Region
#Region "  内部ｸﾗｽ                              "
    Private Class clsState
        '内部変数
        Private mSTRTEL_ID As String            '電文ID
        Private mINTORDER As String             '順番
        Private mSTRTEL_KUBUN As String         '電文区分名
        Private mINTTEL_LEN As String           '文字列長
        Private mstrDATA As String              'ﾃﾞｰﾀ

        'ﾌﾟﾛﾊﾟﾃｨ
        Public Property TEL_ID() As String
            Get
                Return mSTRTEL_ID
            End Get
            Set(ByVal Value As String)
                mSTRTEL_ID = Value
            End Set
        End Property
        Public Property ORDER() As String
            Get
                Return mINTORDER
            End Get
            Set(ByVal Value As String)
                mINTORDER = Value
            End Set
        End Property
        Public Property TEL_KUBUN() As String
            Get
                Return mSTRTEL_KUBUN
            End Get
            Set(ByVal Value As String)
                mSTRTEL_KUBUN = Value
            End Set
        End Property
        Public Property TEL_LEN() As String
            Get
                Return mINTTEL_LEN
            End Get
            Set(ByVal Value As String)
                mINTTEL_LEN = Value
            End Set
        End Property
        Public Property DATA() As String
            Get
                Return mstrDATA
            End Get
            Set(ByVal Value As String)
                mstrDATA = Value
            End Set
        End Property
    End Class
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="strFileName">読み込む定義ﾌｧｲﾙのﾊﾟｽ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal strFileName As String)
        Try
            '***********************************
            '初期設定
            '***********************************
            mstrFILENAME = strFileName                      '定義ﾌｧｲﾙ名取得
            mblnHEADER_FLUG = True                          'ﾍｯﾀﾞｰ処理ﾌﾗｸﾞ
            mstrFILLER = Space(1)                           'Filler文字列


            '****************************************************
            '構成ファイルをXML DOMに読み込む
            '****************************************************
            mobjDocument.Load(mstrFILENAME)          'ﾃﾞｰﾀﾛｰﾄﾞ


            '***********************************
            'Configから定義取得
            '***********************************
            Call GET_CONFIG_FOR_CONFIG()


            '***********************************
            'Configからﾍｯﾀﾞｰ定義取得
            '***********************************
            Call GET_HEADERFORMAT_FOR_CONFIG()


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  電文のﾍｯﾀﾞｰ部分をｾｯﾄ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文のﾍｯﾀﾞｰ部分をｾｯﾄ
    ''' </summary>
    ''' <param name="strKubun">電文区分</param>
    ''' <param name="strData">電文のｾｯﾄされるﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SETIN_HEADER(ByVal strKubun As String, _
                            ByVal strData As String)
        Try
            '*************************************************
            'ｺﾚｸｼｮﾝにﾃﾞｰﾀ追加
            '*************************************************
            mobjConfigHeader.Item(strKubun).DATA = strData


        Catch ex As Exception
            Dim strMessage As String = ""
            strMessage &= mstrFILENAME & ERROR_MESSAGE_01 & strKubun & "]"
            Throw New Exception(strMessage)

        End Try
    End Sub
#End Region
#Region "   電文のﾍｯﾀﾞｰ部分を取得               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文のﾍｯﾀﾞｰ部分を取得
    ''' </summary>
    ''' <param name="strKubun">電文区分</param>
    ''' <returns>電文から、strKubunをｷｰに取得した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SELECT_HEADER(ByVal strKubun As String) As String
        Try

            Dim strRet As String = ""
            strRet = mobjConfigHeader.Item(strKubun).DATA

            Return (strRet)
        Catch ex As Exception
            Dim strMessage As String = ""
            strMessage &= mstrFILENAME & ERROR_MESSAGE_01 & strKubun & "]"
            Throw New Exception(strMessage)

        End Try
    End Function
#End Region
#Region "  電文のﾃﾞｰﾀ部分をｾｯﾄ                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】strKubun   ：
    '        strData    ：
    '【戻値】
    '*******************************************************************************************************************
    ''' <summary>
    ''' 電文のﾃﾞｰﾀ部分をｾｯﾄ
    ''' </summary>
    ''' <param name="strKubun">電文区分</param>
    ''' <param name="strData">電文のｾｯﾄされるﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    Public Sub SETIN_DATA(ByVal strKubun As String, _
                          ByVal strData As String)
        Try

            '*************************************************
            'ｺﾚｸｼｮﾝにﾃﾞｰﾀ追加
            '*************************************************
            mobjConfigData.Item(strKubun).DATA = strData


        Catch ex As Exception
            Dim strMessage As String = ""
            strMessage &= mstrFILENAME & ERROR_MESSAGE_01 & strKubun & "]"
            Throw New Exception(strMessage)

        End Try
    End Sub
#End Region
#Region "  電文のﾃﾞｰﾀ部分をｾｯﾄ(画面ﾃｽﾄ用)       "
    ''*******************************************************************************************************************
    ''【機能】同上
    ''【引数】strKubun   ：電文区分
    ''        strData    ：電文のｾｯﾄされるﾃﾞｰﾀ
    ''【戻値】
    ''*******************************************************************************************************************
    'Public Sub SETIN_DATA(ByVal strKubun As String, _
    '                      ByVal strData As String)

    '    '電文にｾｯﾄされるﾃﾞｰﾀをﾒｯｾｰｼﾞﾎﾞｯｸｽで表示
    '    Call MsgBox("電文区分：" & strKubun & vbCrLf & "電文ﾃﾞｰﾀ：" & strData)

    'End Sub
#End Region
#Region "  電文のﾃﾞｰﾀ部分を取得                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文のﾃﾞｰﾀ部分を取得
    ''' </summary>
    ''' <param name="strKubun">電文区分</param>
    ''' <returns>電文から、strKubunをｷｰに取得した文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SELECT_DATA(ByVal strKubun As String) As String
        Try

            Dim strRet As String = ""
            strRet = mobjConfigData.Item(strKubun).DATA

            Return (strRet)
        Catch ex As Exception
            Dim strMessage As String = ""
            strMessage &= mstrFILENAME & ERROR_MESSAGE_01 & strKubun & "]"
            Throw New Exception(strMessage)

        End Try
    End Function
#End Region
#Region "  電文作成                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MAKE_TELEGRAM()
        Try
            Dim strTelegram As String


            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            strTelegram = ""
            If mblnHEADER_FLUG = True Then
                For ii As Integer = 1 To mobjConfigHeader.Count
                    strTelegram &= STRING_CUT_SPACE(mobjConfigHeader.Item(ii).DATA, _
                                                    mobjConfigHeader.Item(ii).TEL_LEN)
                Next
            End If
            mstrHEADER = strTelegram


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            strTelegram = ""
            For ii As Integer = 1 To mobjConfigData.Count
                strTelegram &= STRING_CUT_SPACE(mobjConfigData.Item(ii).DATA, _
                                                mobjConfigData.Item(ii).TEL_LEN)
            Next
            mstrDATA = strTelegram


            '***********************************************
            ' 電文作成
            '***********************************************
            mstrTELEGRAM_MAKED = mstrHEADER & mstrDATA

            '-----------------------------------
            '文字列長さ調節
            '-----------------------------------
            If mintTEL_LEN > 0 Then
                mstrTELEGRAM_MAKED = STRING_CUT_SPACE(mstrTELEGRAM_MAKED, _
                                                      mintTEL_LEN)
                mstrDATA = STRING_CUT_SPACE(mstrDATA, _
                                            mintTEL_LEN - Len(mstrHEADER))
            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  電文分解                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 電文分解
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub PARTITION()
        Try
            Dim strTemp As String = mstrTELEGRAM_PARTITION          '分割する電文


            '***********************************************
            ' 定義取得
            '***********************************************
            Call GET_HEADERFORMAT_FOR_CONFIG()


            '***********************************************
            ' ﾍｯﾀﾞｰ部分分割
            '***********************************************
            If mblnHEADER_FLUG = True Then
                Call PARTITION_STRING(strTemp, mobjConfigHeader)
            End If


            '***********************************************
            ' ﾃﾞｰﾀ部分分割
            '***********************************************
            Call PARTITION_STRING(strTemp, mobjConfigData)


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region

    '*********************************************
    'Private宣言
    '*********************************************
#Region "  ｴﾗｰ処理                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="ex">ｴﾗｰException</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ComError(ByVal ex As Exception)

        Throw ex

    End Sub
#End Region
#Region "  Configﾌｧｲﾙから、情報取得（ﾃﾞｰﾀ部分用）       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから、情報取得（ﾃﾞｰﾀ部分用）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GET_DATAFORMAT_FOR_CONFIG() As String
        Dim strRet As String = ""
        Try
            '****************************************************
            '初期化
            '****************************************************
            mobjConfigData = Nothing
            mobjConfigData = New Collection


            '****************************************************
            'ノードを探す
            '****************************************************
            Dim objNode As XmlNode
            For Each objNode In mobjDocument(XML_NODE_CONFIG)(XML_NODE_ID_PREFIX & mstrFORMAT_ID)
                If objNode.Name = XML_NODE_ADD Then
                    '-------------------------------------------------
                    'ｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄにﾃﾞｰﾀ追加
                    '-------------------------------------------------
                    Dim objState As New clsState                'ｺﾚｸｼｮﾝに格納するｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄ
                    objState.TEL_KUBUN = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    objState.TEL_LEN = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
                    objState.DATA = ""


                    '-------------------------------------------------
                    'ｺﾚｸｼｮﾝにﾃﾞｰﾀ追加
                    '-------------------------------------------------
                    mobjConfigData.Add(objState, _
                                       objState.TEL_KUBUN)

                    objState = Nothing
                End If
            Next

            Return (strRet)

        Catch ex As Exception
            ComError(ex)
            Return (strRet)

        End Try
    End Function
#End Region
#Region "  Configﾌｧｲﾙから、情報取得（ﾍｯﾀﾞｰ部分用）      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから、情報取得（ﾍｯﾀﾞｰ部分用）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GET_HEADERFORMAT_FOR_CONFIG() As String
        Dim strRet As String = ""
        Try
            '****************************************************
            '初期化
            '****************************************************
            mobjConfigHeader = Nothing
            mobjConfigHeader = New Collection


            '****************************************************
            'ノードを探す
            '****************************************************
            Dim objNode As XmlNode
            For Each objNode In mobjDocument(XML_NODE_CONFIG)(XML_NODE_HEADER)
                If objNode.Name = XML_NODE_ADD Then
                    '-------------------------------------------------
                    'ｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄにﾃﾞｰﾀ追加
                    '-------------------------------------------------
                    Dim objState As New clsState                'ｺﾚｸｼｮﾝに格納するｽﾃｰﾄｵﾌﾞｼﾞｪｸﾄ



                    objState.TEL_KUBUN = objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                    objState.TEL_LEN = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
                    objState.DATA = ""


                    '-------------------------------------------------
                    'ｺﾚｸｼｮﾝにﾃﾞｰﾀ追加
                    '-------------------------------------------------
                    mobjConfigHeader.Add(objState, _
                                         objState.TEL_KUBUN)

                    objState = Nothing
                End If
            Next

            Return (strRet)

        Catch ex As Exception
            ComError(ex)
            Return (strRet)

        End Try
    End Function
#End Region
#Region "  Configﾌｧｲﾙから、情報取得（定義用）           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから、情報取得（定義用）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function GET_CONFIG_FOR_CONFIG() As String
        Dim strRet As String = ""
        Try
            '****************************************************
            '初期化
            '****************************************************
            mobjConfigHeader = Nothing
            mobjConfigHeader = New Collection


            '****************************************************
            'ノードを探す
            '****************************************************
            Dim objNode As XmlNode
            For Each objNode In mobjDocument(XML_NODE_CONFIG)("CONFIG")
                If objNode.Name = XML_NODE_ADD Then

                    '-------------------------------------------------
                    '定義設定
                    '-------------------------------------------------
                    Select Case objNode.Attributes.GetNamedItem(XML_NODE_KEY).Value
                        Case "TELEGRAM_LEN"
                            mintTEL_LEN = objNode.Attributes.GetNamedItem(XML_NODE_VALUE).Value
                    End Select

                End If
            Next

            Return (strRet)

        Catch ex As Exception
            ComError(ex)
            Return (strRet)

        End Try
    End Function
#End Region
#Region "  分割処理                                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 分割処理
    ''' </summary>
    ''' <param name="strTemp">ｶｯﾄしていく文字列</param>
    ''' <param name="objCollection">ﾃﾞｰﾀをｾｯﾄしてするｺﾚｸｼｮﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PARTITION_STRING(ByRef strTemp As String, _
                                 ByRef objCollection As Collection)
        Try

            For ii As Integer = 1 To objCollection.Count
                '-----------------------------------------------
                'ﾃﾞｰﾀｾｯﾄ
                '-----------------------------------------------
                objCollection.Item(ii).DATA = STRING_CUT_SPACE(strTemp, _
                                                               objCollection.Item(ii).TEL_LEN)

                '-----------------------------------------------
                '文字列ｶｯﾄ
                '-----------------------------------------------
                strTemp = Replace(strTemp, _
                                  objCollection.Item(ii).DATA, _
                                  "", _
                                  1, _
                                  1, _
                                  CompareMethod.Binary)
            Next

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  桁あわせ処理（後ろに　ﾌﾟﾛﾊﾟﾃｨ FILLER を挿入）"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 桁あわせ処理
    ''' </summary>
    ''' <param name="strData">桁合わせ前の文字列</param>
    ''' <param name="iSize">桁合わせのｻｲｽﾞ</param>
    ''' <returns>桁合わせ後の文字列</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function STRING_CUT_SPACE(ByVal strData As String, ByVal iSize As Long) As String
        Dim strTemp As String = strData
        Dim lngRet As Long
        Dim strRet As String

        '---------------------------------------------------
        'FILLERﾁｪｯｸ
        '---------------------------------------------------
        lngRet = System.Text.Encoding.GetEncoding(932).GetByteCount(mstrFILLER)
        If lngRet <> 1 Then
            mstrFILLER = Space(1)
        End If


        '---------------
        'データセット
        '---------------
        If IsNothing(strData) Then
            strData = ""
        End If

        '---------------
        'バイト数取得
        '---------------
        lngRet = System.Text.Encoding.GetEncoding(932).GetByteCount(strData)

        '---------------------------------------------------
        '文字列の長さが、設定文字列数よりも長い場合
        '---------------------------------------------------
        If lngRet > iSize Then
            While lngRet > iSize
                strTemp = Left(strTemp, strTemp.Length - 1)                             '一文字削除
                lngRet = System.Text.Encoding.GetEncoding(932).GetByteCount(strTemp)    'バイト数取得



            End While

            'ﾊﾞｲﾄ数ﾁｪｯｸ(全角文字を削除した場合、一文字で2ﾊﾞｲﾄなくなるので、1ﾊﾞｲﾄ加算する)
            If lngRet = iSize Then
                Return (strTemp)
            Else
                strTemp = strTemp & mstrFILLER          'ｽﾍﾟｰｽ加算



                Return (strTemp)
            End If
        End If

        '---------------------------------------------------
        '後にｽﾍﾟｰｽを加算
        '---------------------------------------------------
        strRet = strData & StrDup(CInt(iSize - lngRet), mstrFILLER)
        Return (strRet)

    End Function
#End Region

End Class
