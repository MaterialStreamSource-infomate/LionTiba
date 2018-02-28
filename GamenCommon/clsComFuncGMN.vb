'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports System.Text
Imports System.Xml
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
Imports System.Net
Imports UserProcess
#End Region

Public Class clsComFuncGMN


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通

    'ｸﾞﾛｰﾊﾞﾙ変数
#Region "  ｸﾞﾛｰﾊﾞﾙ変数                          "

    '**********************************************************************************************
    '　ｸﾞﾛｰﾊﾞﾙ変数
    '**********************************************************************************************
    Protected Friend Shared gobjComFuncGMN As New clsComFuncGMN '共通関数ｵﾌﾞｼﾞｪｸﾄ


    Public Shared gobjDb As clsConn                             'DB接続ｵﾌﾞｼﾞｪｸﾄ
    Public Shared gobjOwner As clsOwner                         '画面用ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ

    Public Shared gobjGridDataTable05 As clsGridDataTable05     'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
    Public Shared gobjLocation As Point                         'ﾌｫｰﾑ表示位置
    Public Shared gblnLogoff As Boolean                         'ﾛｸﾞｵﾌﾌﾗｸﾞ

    '設定ﾃﾞｰﾀ
    Public Shared gcdtmStart As Date                        ' exe起動時間
    Public Shared gcLabelColor_Blue As Color                ' (青　)DSP_EQ_STS の INTCOLOR = 0 の時の色
    Public Shared gcLabelColor_Red As Color                 ' (赤　)DSP_EQ_STS の INTCOLOR = 1 の時の色
    Public Shared gcLabelColor_Yellow As Color              ' (黄　)DSP_EQ_STS の INTCOLOR = 2 の時の色
    Public Shared gcLabelColor_Purple As Color              ' (紫　)DSP_EQ_STS の INTCOLOR = 3 の時の色
    Public Shared gcLabelColor_White As Color               ' (白　)DSP_EQ_STS の INTCOLOR = 4 の時の色
    Public Shared gcLabelColor_Green As Color               ' (緑　)DSP_EQ_STS の INTCOLOR = 5 の時の色
    Public Shared gcLabelColor_LightGreen As Color          ' (薄緑)DSP_EQ_STS の INTCOLOR = 6 の時の色
    Public Shared gcLabelColor_Orange As Color              ' (橙  )DSP_EQ_STS の INTCOLOR = 7 の時の色
    Public Shared gcLabelColor_Black As Color               ' (黒　)ｴﾗｰ時の色

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/07/03 入出庫ﾓｰﾄﾞの色設定
    Public Shared gcModeColor_IN As Color                   ' (緑　)入庫ﾓｰﾄﾞ
    Public Shared gcModeColor_OUT As Color                  ' (青　)出庫ﾓｰﾄﾞ
    Public Shared gcModeColor_Black As Color                ' (黒　)
    Public Shared gcModeColor_CUS_IN As Color               ' (緑　)ｶｽﾀﾑ色 入庫ﾓｰﾄﾞ
    Public Shared gcModeColor_CUS_OUT As Color              ' (青　)ｶｽﾀﾑ色 出庫ﾓｰﾄﾞ
    Public Shared gcModeColor_CUS_FUITHI As Color           ' (赤　)ｶｽﾀﾑ色 ﾓｰﾄﾞ不一致
    '↑↑↑↑↑↑************************************************************************************************************
    
    '取得ﾃﾞｰﾀ
    Public Shared gcstrFUSER_ID As String                    'ﾕｰｻﾞｰID
    Public Shared gcstrFUSER_NAME As String                  'ﾕｰｻﾞｰ名
    Public Shared gcintFUSER_LEVEL() As Integer              'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
    Public Shared gcstrFTERM_ID As String                    '端末ID
    Public Shared gcintFTERM_KBN As Nullable(Of Integer)     '端末区分
    Public Shared gcstrFTERM_NAME As String                  '端末名名称
    Public Shared gcstrXREPORTPRINTERNAME As String          'ﾌﾟﾘﾝﾀ名称
    Public Shared gcstrXLABELPRINTERNAME As String           'ﾗﾍﾞﾙﾌﾟﾘﾝﾀ名称


    '=======================================================================
    ' Config    取得ﾃﾞｰﾀ
    '=======================================================================
    'ﾀｲﾏｰ用
    Public Shared gcinttmrTime_Interval As Integer          '時刻表示                   ﾀｲﾏｰ
    Public Shared gcinttmrBlink_Interval As Integer         'ﾎﾞﾀﾝ点滅用                 ﾀｲﾏｰ
    Public Shared gcinttmrOpeMsg_Interval As Integer        'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ取得         ﾀｲﾏｰ
    Public Shared gcinttmrTest_1_Interval As Integer        '画面遷移ﾃｽﾄ用              ﾀｲﾏｰ
    '画面ｴﾗｰﾛｸﾞ用
    Public Shared gcstrLOG_FILE_NAME As String              'ﾌｧｲﾙ名         
    Public Shared gcstrLOG_FILE_NAME_OLD As String          'ﾌｧｲﾙ名(古い)   
    Public Shared gcstrLOG_FILE_SIZE As String              '最大ﾌｧｲﾙｻｲｽﾞ  
    Public Shared gcstrLOG_FILE_PATH As String              'ﾌｧｲﾙ格納場所
    'ｿｹｯﾄ用
    Public Shared gcstrSOCK_SEND_ADDRESS As String          '送信先ｱﾄﾞﾚｽ
    Public Shared gcstrSOCK_SEND_PORT As String             '送信先ﾎﾟｰﾄNo
    Public Shared gcstrSOCK_SEND_TIME_OUT As String         '応答ｿｹｯﾄ待機時間
    'その他
    Public Shared gcintDisp_INTMSG_LEVEL As Integer         '表示するﾒｯｾｰｼﾞﾚﾍﾞﾙ
    Public Shared gcstrTMRTEST_1 As String                  '画面遷移ﾃｽﾄ用              ﾀｲﾏｰﾌﾗｸﾞ
    Public Shared gcstrPRINT_FLG As String                  '印字                       ﾌﾗｸﾞ
    Public Shared gcstrDEGUB_FLG As String                  'ﾃﾞﾊﾞｯｸﾞ                    ﾌﾗｸﾞ
    Public Shared gcintDSPLOGIN_FLG As Integer              'ﾛｸﾞｲﾝ画面表示ﾌﾗｸﾞ          ﾌﾗｸﾞ
    Public Shared gcintDSPLOGOFF As Integer                 'ﾛｸﾞｵﾌﾀｲﾑｱｳﾄ
    Public Shared gcintOPE_FLG As Integer                   '操作ﾌﾗｸﾞﾃﾞﾌｫﾙﾄ値
    Public Shared gcintLOGIN_SVR_USE_FLG As Integer         'ﾛｸﾞｲﾝ時ｻｰﾊﾞﾌﾟﾛｾｽ使用       ﾌﾗｸﾞ
    Public Shared gcintAfkFlg As Integer                    '離席処理有効               ﾌﾗｸﾞ
    Public Shared gcintPASSWORD_KETA As Integer             'ﾊﾟｽﾜｰﾄﾞ最小桁数
    Public Shared gcintPASSWORD_ENG As Integer              'ﾊﾟｽﾜｰﾄﾞ英字ﾁｪｯｸﾌﾗｸﾞ
    Public Shared gcintPASSWORD_NUM As Integer              'ﾊﾟｽﾜｰﾄﾞ数値ﾁｪｯｸﾌﾗｸﾞ
    Public Shared gcintPASSWORD_KIGO As Integer             'ﾊﾟｽﾜｰﾄﾞ記号ﾁｪｯｸﾌﾗｸﾞ
    Public Shared gcintPASSWORD_DAISHO As Integer           'ﾊﾟｽﾜｰﾄﾞ大文字小文字ﾁｪｯｸﾌﾗｸﾞ


#End Region

    '便利
#Region "  ｼｽﾃﾑ変数取得                         "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｼｽﾃﾑ変数取得
    ''' </summary>
    ''' <param name="strITEM_ID">[ OUT ]strITEM_ID      ：定数ID</param>
    ''' <returns>ｼｽﾃﾑ変数</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetSYS_HEN(ByVal strITEM_ID As String) As Object

        Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)
        Dim intRet As RetCode
        Dim strMsg As String


        '*******************************************************
        ' ｼｽﾃﾑ変数取得
        '*******************************************************
        objTPRG_SYS_HEN.FHENSU_ID = strITEM_ID
        intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(False)
        If intRet = RetCode.OK Then
            '*******************************************************
            ' 戻り値設定
            '*******************************************************
            Select Case TO_NUMBER(objTPRG_SYS_HEN.FHENSU_KIND)
                Case FHENSU_KIND_SINT
                    Return (objTPRG_SYS_HEN.FHENSU_INT)        '整数

                Case FHENSU_KIND_SREAL
                    Return (objTPRG_SYS_HEN.FHENSU_REAL)       '実数

                Case FHENSU_KIND_SCHAR
                    Return (objTPRG_SYS_HEN.FHENSU_CHAR)       '文字

                Case FHENSU_KIND_SDATE
                    Return (objTPRG_SYS_HEN.FHENSU_DATE)       '日付

                Case Else
                    strMsg = "ｼｽﾃﾑ変数取得に失敗。　　" & "[定数ID:" & TO_STRING(objTPRG_SYS_HEN.FHENSU_ID) & "]"
                    Throw New System.Exception(strMsg)

            End Select

        Else

            strMsg = "ｼｽﾃﾑ変数取得に失敗。　　" & "[定数ID:" & TO_STRING(objTPRG_SYS_HEN.FHENSU_ID) & "]"
            Throw New System.Exception(strMsg)

        End If


    End Function
#End Region
#Region "  表示用名称取得                       "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 表示用名称取得
    ''' </summary>
    ''' <param name="strFTABLE_NAME">画面表示ﾏｽﾀ.ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strFFIELD_NAME">画面表示ﾏｽﾀ.ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strFDISP_VALUE">画面表示ﾏｽﾀ.画面表示設定値</param>
    ''' <returns>画面表示ﾏｽﾀ.表示用名称</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTDSP_DISP(ByVal strFTABLE_NAME As String _
                               , ByVal strFFIELD_NAME As String _
                               , ByVal strFDISP_VALUE As String _
                               ) _
                               As Object
        Dim objRerutn As Object
        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)
        objRerutn = objTemplateServer.GetTDSP_DISP(strFTABLE_NAME, strFFIELD_NAME, strFDISP_VALUE)
        Return objRerutn
    End Function
#End Region
#Region "  ｺﾝﾄﾛｰﾙ設定値取得                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙ設定値取得
    ''' </summary>
    ''' <param name="strFDISP_ID">画面ID</param>
    ''' <param name="strFCTRL_ID">ｺﾝﾄﾛｰﾙID</param>
    ''' <param name="strFCTRL_ORDER">ｺﾝﾄﾛｰﾙ順番</param>
    ''' <returns>ｺﾝﾄﾛｰﾙ設定値</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTDSP_CTRL(ByVal strFDISP_ID As String _
                               , ByVal strFCTRL_ID As String _
                               , Optional ByVal strFCTRL_ORDER As Integer = 1 _
                               ) _
                               As String

        Dim objTDSP_CTRL As New TBL_TDSP_CTRL(gobjOwner, gobjDb, Nothing)
        Dim objRerutn As String
        Dim intRet As RetCode
        '' ''Dim strMsg As String


        '*******************************************************
        ' 画面ｺﾝﾄﾛｰﾙﾏｽﾀ取得
        '*******************************************************
        If IsNull(strFDISP_ID) = False _
           And IsNull(strFCTRL_ID) = False _
           And IsNull(strFCTRL_ORDER) = False _
           Then
            '(値が設定されている場合)

            objTDSP_CTRL.FDISP_ID = strFDISP_ID         '画面ID
            objTDSP_CTRL.FCTRL_ID = strFCTRL_ID         'ｺﾝﾄﾛｰﾙID
            objTDSP_CTRL.FCTRL_ORDER = strFCTRL_ORDER   'ｺﾝﾄﾛｰﾙ順番
            intRet = objTDSP_CTRL.GET_TDSP_CTRL(False)  '取得
            If intRet = RetCode.OK Then
                '(見つかった場合)
                objRerutn = objTDSP_CTRL.FCTRL_VALUE    'ｺﾝﾄﾛｰﾙ設定値
            Else
                '(見つからなかった場合)
                objRerutn = ""
            End If

        Else
            '(値が設定されていない場合)

            objRerutn = ""

        End If

        Return objRerutn
    End Function
#End Region
#Region "  品名取得                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 品名取得
    ''' </summary>
    ''' <param name="strFHINMEI_CD">品名ｺｰﾄﾞ</param>
    ''' <returns>品名</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTMST_ITEM(ByVal strFHINMEI_CD As String _
                                 ) _
                                 As String

        Dim objTMST_ITEM As New TBL_TMST_ITEM(gobjOwner, gobjDb, Nothing)
        Dim strRerutn As String = ""
        '' ''Dim intRet As RetCode
        '' ''Dim strMsg As String

        If strFHINMEI_CD <> "" And IsNothing(strFHINMEI_CD) = False Then
            objTMST_ITEM.FHINMEI_CD = strFHINMEI_CD     '品名ｺｰﾄﾞ
            objTMST_ITEM.GET_TMST_ITEM(False)           '特定
            strRerutn = objTMST_ITEM.FHINMEI
        End If


        Return strRerutn
    End Function
#End Region
#Region "  保管場所名称取得                     "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 保管場所名称取得
    ''' </summary>
    ''' <param name="strFPLACE_CD">保管場所ｺｰﾄﾞ</param>
    ''' <returns>保管場所名称</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTMST_PLACE(ByVal strFPLACE_CD As String _
                                  ) _
                                  As String

        Dim objTMST_PLACE As New TBL_TMST_PLACE(gobjOwner, gobjDb, Nothing)
        Dim strRerutn As String = ""
        '' ''Dim intRet As RetCode
        '' ''Dim strMsg As String

        If strFPLACE_CD <> "" And IsNothing(strFPLACE_CD) = False Then
            objTMST_PLACE.FPLACE_CD = strFPLACE_CD      '保管場所ｺｰﾄﾞ
            objTMST_PLACE.GET_TMST_PLACE(False)         '特定
            strRerutn = objTMST_PLACE.FPLACE_NAME
        End If


        Return strRerutn
    End Function
#End Region
#Region "  ｴﾘｱ名称取得                          "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｴﾘｱ名称取得
    ''' </summary>
    ''' <param name="strFAREA_CD">ｴﾘｱｺｰﾄﾞ</param>
    ''' <returns>ｴﾘｱ名称</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTMST_AREA(ByVal strFAREA_CD As String _
                                 ) _
                                 As String

        Dim objTMST_AREA As New TBL_TMST_AREA(gobjOwner, gobjDb, Nothing)
        Dim strRerutn As String = ""
        '' ''Dim intRet As RetCode
        '' ''Dim strMsg As String

        If strFAREA_CD <> "" And IsNothing(strFAREA_CD) = False Then
            objTMST_AREA.FAREA_CD = strFAREA_CD        'ｴﾘｱｺｰﾄﾞ
            objTMST_AREA.GET_TMST_AREA(False)          '特定
            strRerutn = objTMST_AREA.FAREA_NAME
        End If


        Return strRerutn
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称取得                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称取得
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <returns>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GetTMST_TRK(ByVal strFTRK_BUF_NO As String _
                                ) _
                                As String

        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        Dim strRerutn As String = ""
        '' ''Dim intRet As RetCode
        '' ''Dim strMsg As String

        If strFTRK_BUF_NO <> "" And IsNothing(strFTRK_BUF_NO) = False Then
            objTMST_TRK.FTRK_BUF_NO = strFTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK.GET_TMST_TRK(False)                 '特定
            strRerutn = objTMST_TRK.FBUF_NAME
        End If


        Return strRerutn
    End Function
#End Region

    'ｸﾞﾘｯﾄﾞ関係
#Region "　ｸﾞﾘｯﾄﾞ表示件数取得処理               "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示件数取得処理
    ''' </summary>
    ''' <param name="strSQL">SQL文</param>
    ''' <returns>引数のSQL文で取得できるﾃﾞｰﾀ件数</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetDataRowCount(ByVal strSQL As String) As Long

        Dim strCountSQL As String
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim lngDataRowCount As Long = 0         'ﾃﾞｰﾀ数

        strCountSQL = ""
        strCountSQL &= vbCrLf & " SELECT "
        strCountSQL &= vbCrLf & "      COUNT(*) AS ROW_COUNT "
        strCountSQL &= vbCrLf & " FROM "
        strCountSQL &= vbCrLf & "      ( "
        strCountSQL &= vbCrLf & strSQL
        strCountSQL &= vbCrLf & "      )"


        gobjDb.SQL = strCountSQL
        strDataSetName = "CountDataRow"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        lngDataRowCount = CLng(objDataSet.Tables(strDataSetName).Rows(0).Item("ROW_COUNT"))
        objDataSet.Dispose()
        objDataSet = Nothing

        Return lngDataRowCount

    End Function
#End Region

    'ｸﾞﾘｯﾄﾞ表示用ｺﾝﾎﾞﾎﾞｯｸｽ
#Region "  ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得
    ''' </summary>
    ''' <param name="strTABLE_NAME">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strFIELD_NAME">ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="objSortedList">ｾｯﾄするﾊｯｼｭﾃｰﾌﾞﾙ</param>
    ''' <param name="udtHashType">何型でｾｯﾄするかの引数</param>
    ''' <remarks>画面表示ﾏｽﾀより、引数にて指定されたﾃｰﾌﾞﾙ名、ﾌｨｰﾙﾄﾞ名にて抽出したﾃﾞｰﾀを画面表示設定値をｷｰ、表示名称を値としてﾏｯﾌﾟします。</remarks>
    ''' *******************************************************************************************************************
    Public Sub GetDisplaySortedList(ByVal strTABLE_NAME As String _
                                  , ByVal strFIELD_NAME As String _
                                  , ByRef objSortedList As SortedList _
                                  , ByVal udtHashType As HashTableType _
                                    )

        Dim strSQL As String                    'SQL文
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のデータ

        If objSortedList Is Nothing Then
            objSortedList = New SortedList
        End If

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    *"
        strSQL &= vbCrLf & " FROM"
        strSQL &= vbCrLf & "    TDSP_DISP"
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        FTABLE_NAME = '" & strTABLE_NAME & "'"       'ﾃｰﾌﾞﾙ名
        strSQL &= vbCrLf & "    AND FFIELD_NAME = '" & strFIELD_NAME & "'"       'ﾌｨｰﾙﾄﾞ名
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FDISP_VALUE "
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        objSortedList.Clear()
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "TDSP_DISP"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                Select Case udtHashType
                    Case HashTableType.CShor
                        objSortedList.Add(TO_SHORT(objRow("FDISP_VALUE")), TO_STRING(objRow("FGAMEN_DISP")))
                    Case HashTableType.CInteger
                        objSortedList.Add(TO_INTEGER(objRow("FDISP_VALUE")), TO_STRING(objRow("FGAMEN_DISP")))
                    Case HashTableType.CDecimal
                        objSortedList.Add(CDec(TO_NUMBER(objRow("FDISP_VALUE"))), TO_STRING(objRow("FGAMEN_DISP")))
                    Case HashTableType.CString
                        objSortedList.Add(TO_STRING(objRow("FDISP_VALUE")), TO_STRING(objRow("FGAMEN_DISP")))
                End Select
            Next
        End If


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得   (ｴﾘｱ用)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得   (ｴﾘｱ用)
    ''' </summary>
    ''' <param name="strPLACE_CD">保管場所ｺｰﾄﾞ</param>
    ''' <param name="objSortedList">ｾｯﾄするｿｰﾃｯﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="udtHashType">何型でｾｯﾄするかの引数</param>
    ''' <remarks>ﾄﾗｯｷﾝｸﾞﾏｽﾀより、引数にて指定された保管場所のｴﾘｱを取得します。</remarks>
    ''' *******************************************************************************************************************
    Public Sub GetDisplaySortedList_AREA(ByVal strPLACE_CD As String _
                                       , ByRef objSortedList As SortedList _
                                       , ByVal udtHashType As HashTableType _
                                         )

        Dim strSQL As String                    'SQL文
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のデータ

        If objSortedList Is Nothing Then
            objSortedList = New SortedList
        End If

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "      TMST_AREA.FPLACE_CD "
        strSQL &= vbCrLf & "    , TMST_AREA.FAREA_CD "
        strSQL &= vbCrLf & "    , TMST_AREA.FAREA_NAME "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      TMST_AREA "
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TMST_AREA.FPLACE_CD = '" & strPLACE_CD & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     TMST_AREA.FAREA_CD "
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        objSortedList.Clear()
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_AREA"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                Select Case udtHashType
                    Case HashTableType.CShor
                        objSortedList.Add(TO_SHORT(objRow("FAREA_CD")), TO_STRING(objRow("FAREA_NAME")))
                    Case HashTableType.CInteger
                        objSortedList.Add(TO_INTEGER(objRow("FAREA_CD")), TO_STRING(objRow("FAREA_NAME")))
                    Case HashTableType.CDecimal
                        objSortedList.Add(CDec(TO_NUMBER(objRow("FAREA_CD"))), TO_STRING(objRow("FAREA_NAME")))
                    Case HashTableType.CString
                        objSortedList.Add(TO_STRING(objRow("FAREA_CD")), TO_STRING(objRow("FAREA_NAME")))
                End Select
            Next
        End If


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得   (ﾏｽﾀﾃｰﾌﾞﾙ用)    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示用SortedListｵﾌﾞｼﾞｪｸﾄﾃﾞｰﾀ取得   (ﾏｽﾀﾃｰﾌﾞﾙ用)
    ''' </summary>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strKEY_FIELD_NAME">ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strDISP_FIELD_NAME">表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="objSortedList">ｾｯﾄするｿｰﾃｯﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="udtHashType">何型でｾｯﾄするかの引数</param>
    ''' <remarks>画面表示ﾏｽﾀより、引数にて指定されたﾃｰﾌﾞﾙ名、ﾌｨｰﾙﾄﾞ名にて抽出したﾃﾞｰﾀを画面表示設定値をｷｰ、表示名称を値としてﾏｯﾌﾟします。</remarks>
    ''' *******************************************************************************************************************
    Public Sub GetDisplaySortedList_MstTbl(ByVal strMASTER_TABLE_NAME As String _
                                         , ByVal strKEY_FIELD_NAME As String _
                                         , ByVal strDISP_FIELD_NAME As String _
                                         , ByRef objSortedList As SortedList _
                                         , ByVal udtHashType As HashTableType _
                                           )

        Dim strSQL As String                    'SQL文
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のデータ

        If objSortedList Is Nothing Then
            objSortedList = New SortedList
        End If

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "      " & strKEY_FIELD_NAME
        strSQL &= vbCrLf & "    , " & strDISP_FIELD_NAME
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      " & strMASTER_TABLE_NAME
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "      " & strKEY_FIELD_NAME
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        objSortedList.Clear()
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = strMASTER_TABLE_NAME
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                Select Case udtHashType
                    Case HashTableType.CShor
                        objSortedList.Add(TO_SHORT(objRow(strKEY_FIELD_NAME)), TO_STRING(objRow(strDISP_FIELD_NAME)))
                    Case HashTableType.CInteger
                        objSortedList.Add(TO_INTEGER(objRow(strKEY_FIELD_NAME)), TO_STRING(objRow(strDISP_FIELD_NAME)))
                    Case HashTableType.CDecimal
                        objSortedList.Add(CDec(TO_NUMBER(objRow(strKEY_FIELD_NAME))), TO_STRING(objRow(strDISP_FIELD_NAME)))
                    Case HashTableType.CString
                        objSortedList.Add(TO_STRING(objRow(strKEY_FIELD_NAME)), TO_STRING(objRow(strDISP_FIELD_NAME)))
                End Select
            Next
        End If


    End Sub
#End Region

    'ﾌｫｰﾑ表示
#Region "  画面遷移                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移
    ''' </summary>
    ''' <param name="objFormNext">遷移するﾌｫｰﾑ</param>
    ''' <param name="objFormNow">遷移元ﾌｫｰﾑ</param>
    ''' <param name="udtOpenType">画面ｵｰﾌﾟﾝ区分</param>
    ''' <param name="strPara"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub FormMove(ByRef objFormNext As Object _
                      , ByRef objFormNow As Object _
                      , ByVal udtOpenType As OpenType _
                      , Optional ByVal strPara As String = "" _
                        )

        '*************************************************
        '画面初期化の有無選択
        '*************************************************
        Select Case udtOpenType
            Case OpenType.Modal
                '*************************************************
                'ﾓｰﾀﾞﾙ
                '*************************************************
                '============================================
                'ﾌｫｰﾑの遷移
                '============================================
                objFormNext.ShowDialog()
                objFormNext.Close()
                objFormNext.Dispose()
                objFormNext = Nothing


            Case OpenType.Modaless
                '*************************************************
                'ﾓｰﾀﾞﾚｽ
                '*************************************************
                '============================================
                'ﾌｫｰﾑの遷移
                '============================================
                objFormNext.Show()

                '============================================
                ' 自身のｸﾛｰｽﾞ処理
                '============================================
                If IsNull(objFormNow) = False Then
                    '' ''objFormNow.MeClose()
                    objFormNow.Close()
                    objFormNow.Dispose()
                    objFormNow = Nothing
                End If


            Case OpenType.ExeBoot
                '*************************************************
                'exe起動
                '*************************************************
                '============================================
                '二重起動ﾁｪｯｸ
                '============================================
                If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
                    Dim strMessage As String
                    strMessage = "Gamen.exeの数が異常です        ："
                    strMessage &= CStr(UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)))
                    Throw New Exception(strMessage)
                End If


                '============================================
                '起動
                '============================================
                If IsNull(objFormNow) = False Then
                    objFormNow.Cursor.Current = Cursors.WaitCursor      'ﾏｳｽﾎﾟｲﾝﾀ砂時計
                    Call PubF_ShellExe("Gamen.exe", strPara)
                    System.Threading.Thread.Sleep(1500)
                    objFormNow.Owner.Close()
                End If


        End Select

    End Sub
#End Region

    'ｿｹｯﾄ
#Region "  ｿｹｯﾄ送信01               (画面ｿｹｯﾄ用)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 (画面ｿｹｯﾄ用)
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成ｸﾗｽ</param>
    ''' <param name="strRET_STATE">ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ種別(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strUSER_ID"></param>
    ''' <param name="strErrMessage">処理ｴﾗｰﾒｯｾｰｼﾞ (2010/05/19 kato ﾒｯｾｰｼﾞ表示を1回にするため追加)</param>
    ''' <returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer01(ByRef objTelegramSend As clsTelegram _
                                   , Optional ByRef strRET_STATE As String = "" _
                                   , Optional ByRef strRET_DATA_SYUBETU As String = "" _
                                   , Optional ByRef strRET_DATA As String = "" _
                                   , Optional ByRef strUSER_ID As String = "" _
                                   , Optional ByRef strErrMessage As String = "" _
                                     ) As clsSocketClient.RetCode
        Dim dtmNow As Date = Now
        Dim objSocketSend As New clsSocketClientGamen(gobjOwner)


        '***************************************************
        ' Waitﾌｫｰﾑ表示
        '***************************************************
        Call WaitFormShow()


        '***************************************************
        ' 電文作成
        '***************************************************
        'ﾍｯﾀﾞｰ部分ｾｯﾄ
        objTelegramSend.SETIN_HEADER("DSPCMD_ID", Right(objTelegramSend.FORMAT_ID, 6))      'ｺﾏﾝﾄﾞID
        objTelegramSend.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                           '端末ID
        If strUSER_ID = "" Then                                                             'ﾕｰｻﾞｰID
            objTelegramSend.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)
        Else
            objTelegramSend.SETIN_HEADER("DSPUSER_ID", strUSER_ID)
        End If
        objTelegramSend.MAKE_TELEGRAM()                                                 '電文作成


        '***************************************************
        ' ｿｹｯﾄ送信
        '***************************************************
        objSocketSend.strAddress = gcstrSOCK_SEND_ADDRESS               '送信先ｱﾄﾞﾚｽ
        objSocketSend.intPortNo = gcstrSOCK_SEND_PORT                   'ﾎﾟｰﾄNo
        objSocketSend.intTimeOut = gcstrSOCK_SEND_TIME_OUT              'ﾀｲﾑｱｳﾄ
        objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '送信ﾃｷｽﾄ
        objSocketSend.blnReceiveFlag = True                             '応答ｿｹｯﾄ待機

        Call AddToLog_frm("START")
        objSocketSend.SendSock()                                        'ｿｹｯﾄ送信
        ''Call AddToLog_frm( & objSocketSend.strSendText)
        Call AddToLog_frm("END")


        '***************************************************
        ' Waitﾌｫｰﾑ削除
        '***************************************************
        Call WaitFormClose()


        '***************************************************
        ' ｿｹｯﾄ送信正常終了ﾁｪｯｸ
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_01, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_02, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ConnectError
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_03, PopupFormType.Ok, PopupIconType.Err)

        End Select


        '***************************************************
        ' 受信ｿｹｯﾄ解析
        '***************************************************
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strRET_MESSAGE_EXIST As String          '応答ﾒｯｾｰｼﾞ有無
        Dim strRET_MESSAGE As String                '応答ﾒｯｾｰｼﾞ
        ''Dim strRET_DATA_SYUBETU As String           '応答ﾃﾞｰﾀ種別
        ''Dim strRET_DATA As String                   '応答ﾃﾞｰﾀ

        objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText                  '分割する電文ｾｯﾄ
        objTelegramRecv.PARTITION()                                                     '電文分割
        strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                      '応答ｽﾃｰﾀｽ
        strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")      '応答ﾒｯｾｰｼﾞ有無
        strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))            '応答ﾒｯｾｰｼﾞ
        strRET_DATA_SYUBETU = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU"))  '応答ﾃﾞｰﾀ種別
        strRET_DATA = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA"))                  '応答ﾃﾞｰﾀ



        '---------------------------------
        'ﾒｯｾｰｼﾞ表示
        '---------------------------------
        If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then

            Select Case Trim(strRET_STATE)
                Case ID_RETURN_RET_STATE_OK
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Information, "", FRM_MSG_SOCKSENDSERVER_91)
                Case ID_RETURN_RET_STATE_NG
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                Case Else
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
            End Select
        Else
            If strErrMessage <> "" Then
                '(引数にﾒｯｾｰｼﾞがｾｯﾄされている場合)
                If objSocketSend.udtRet = clsSocketClient.RetCode.OK Then
                    '(送信できた場合)
                    If strRET_STATE <> ID_RETURN_RET_STATE_OK Then
                        '(処理が異常終了した場合)
                        Call DisplayPopup(strErrMessage, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)

                    End If
                ElseIf objSocketSend.udtRet <> clsSocketClient.RetCode.ReceiveTimeOut And _
                       objSocketSend.udtRet <> clsSocketClient.RetCode.NG And _
                       objSocketSend.udtRet <> clsSocketClient.RetCode.ConnectError Then
                    '(ｿｹｯﾄ送信正常終了ﾁｪｯｸでﾁｪｯｸしたもの以外の場合)

                    Call DisplayPopup(strErrMessage, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                End If
            End If
        End If

        Return (objSocketSend.udtRet)
    End Function
#End Region
#Region "  ｿｹｯﾄ送信02               (画面ｲﾝﾀｰﾌｪｰｽﾃｰﾌﾞﾙを使用しての複数電文送信) "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(画面ｲﾝﾀｰﾌｪｰｽﾃｰﾌﾞﾙを使用しての複数電文送信)
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成ｸﾗｽ</param>
    ''' <param name="strSendTel">画面ｲﾝﾀｰﾌｪｰｽﾃｰﾌﾞﾙに追加する電文配列</param>
    ''' <param name="strRET_STATE">ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ種別(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strUSER_ID"></param>
    ''' <param name="strErrMessage">処理ｴﾗｰﾒｯｾｰｼﾞ (2010/05/19 kato ﾒｯｾｰｼﾞ表示を1回にするため追加)</param>
    ''' <returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer02(ByRef objTelegramSend As clsTelegram _
                                   , ByVal strSendTel() As String _
                                   , Optional ByRef strRET_STATE As String = "" _
                                   , Optional ByRef strRET_DATA_SYUBETU As String = "" _
                                   , Optional ByRef strRET_DATA As String = "" _
                                   , Optional ByRef strUSER_ID As String = "" _
                                   , Optional ByRef strErrMessage As String = "" _
                                     ) _
                                     As clsSocketClient.RetCode

        Try

            Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値


            '*******************************************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加
            '*******************************************************
            Dim dtNow As Date = Now                     'Now
            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除(初期化)
            '===========================================
            Call DeleteParamTable()

            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録
            '===========================================
            Call RgstParamTable(strSendTel, dtNow)       'ﾃﾞｰﾀ登録



            '*******************************************************
            'ｿｹｯﾄ送信
            '*******************************************************
            udtSckSendRET = SockSendServer01(objTelegramSend _
                                         , strRET_STATE _
                                         , strRET_DATA_SYUBETU _
                                         , strRET_DATA _
                                         , strUSER_ID _
                                         , strErrMessage _
                                         )


            Return (udtSckSendRET)

        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex
        Finally
            Call DeleteParamTable()
        End Try
    End Function
#End Region
#Region "　ｿｹｯﾄ送信03               (ﾊﾟﾗﾒｰﾀ通知,200001送信時に使用)                 "
    ''' '*******************************************************************************************************************
    ''' '【機能】<summary>複数ｿｹｯﾄ送信処理
    '''                   (ﾊﾟﾗﾒｰﾀﾃﾞｰﾀ登録→ﾊﾟﾗﾒｰﾀ通知ｿｹｯﾄ送信→受信電文確認→ﾊﾟﾗﾒｰﾀﾃﾞｰﾀ削除の処理を行います。)
    '''          </summary>
    ''' '【引数】<param name="strSndTlgrm">         [IN ]送信電文</param>
    ''' '        <param name="blnPrmSockCmp">       [OUT]ﾊﾟﾗﾒｰﾀ通知成功ﾌﾗｸﾞ(True:成功(ﾀｲﾑｱｳﾄも含む)　False:失敗)</param>
    ''' '        <param name="strRET_STATE">        [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ｽﾃｰﾀｽ     (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '        <param name="strRET_DATA_SYUBETU"> [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ﾃﾞｰﾀ種別  (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '        <param name="strRET_DATA">         [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ﾃﾞｰﾀ      (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '【戻値】
    ''' '*******************************************************************************************************************
    Public Sub SockSendServer03(ByVal strSndTlgrm() As String _
                              , ByRef blnPrmSockCmp As Boolean _
                              , Optional ByRef strRET_STATE() As String = Nothing _
                              , Optional ByRef strRET_DATA_SYUBETU() As String = Nothing _
                              , Optional ByRef strRET_DATA() As String = Nothing _
                              )

        '===========================================
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙにﾃﾞｰﾀを登録
        '===========================================
        Dim strPrmID As String          'ﾊﾟﾗﾒｰﾀID
        Dim dtNow As Date               'Now

        dtNow = Now
        strPrmID = gcstrFTERM_ID

        Try

            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除(初期化)
            '===========================================
            Call DeleteParamTable()


            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録
            '===========================================
            Call RgstParamTable(strSndTlgrm, dtNow)       'ﾃﾞｰﾀ登録


            '===========================================
            'ﾊﾟﾗﾒｰﾀ通知ｿｹｯﾄ送信
            '===========================================
            Dim udtRet As clsSocketClient.RetCode
            Dim strRET_STATE_PRM As String = ""
            Dim strErrMsg As String
            strErrMsg = "パラメータ通知処理に失敗しました。"

            udtRet = SendSock_PARAMETER(strPrmID, strRET_STATE_PRM)

            If udtRet = clsSocketClient.RetCode.OK Then
                '(送信できた場合)
                If strRET_STATE_PRM = ID_RETURN_RET_STATE_OK Then
                    '(正常終了の場合)
                    blnPrmSockCmp = True        'ﾊﾟﾗﾒｰﾀ通知成功ﾌﾗｸﾞ(True:成功(ﾀｲﾑｱｳﾄも含む))
                Else
                    '(処理が異常終了した場合)
                    Call DisplayPopup(strErrMsg, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                    blnPrmSockCmp = False       'ﾊﾟﾗﾒｰﾀ通知成功ﾌﾗｸﾞ(False:失敗)
                    '===========================================
                    'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除
                    '===========================================
                    Call DeleteParamTable()
                    Exit Sub
                End If
            ElseIf udtRet = clsSocketClient.RetCode.ReceiveTimeOut Then
                '(ﾀｲﾑｱｳﾄの場合)
                blnPrmSockCmp = True            'ﾊﾟﾗﾒｰﾀ通知成功ﾌﾗｸﾞ(True:成功(ﾀｲﾑｱｳﾄも含む))
            Else
                '(その他の場合)
                Call DisplayPopup(strErrMsg, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                blnPrmSockCmp = False           'ﾊﾟﾗﾒｰﾀ通知成功ﾌﾗｸﾞ(False:失敗)
                '===========================================
                'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除
                '===========================================
                Call DeleteParamTable()
                Exit Sub
            End If


            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ受信電文取得処理
            '===========================================
            Call RcvTlgrmParamTable(strPrmID, strRET_STATE, strRET_DATA_SYUBETU, strRET_DATA)


            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除
            '===========================================
            Call DeleteParamTable()


        Catch ex As Exception

            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除
            '===========================================
            Call DeleteParamTable()
            Call ComError_frm(ex)
            Throw ex

        End Try





    End Sub
#End Region
#Region "  ｿｹｯﾄ送信04               (検査結果登録:400402送信時に使用) "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(画面ｲﾝﾀｰﾌｪｰｽﾃｰﾌﾞﾙを使用しての複数電文送信)
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成ｸﾗｽ</param>
    ''' <param name="strSendTel">画面ｲﾝﾀｰﾌｪｰｽﾃｰﾌﾞﾙに追加する電文配列</param>
    ''' <param name="strRET_STATE">ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ種別(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strUSER_ID"></param>
    ''' <param name="strErrMessage">処理ｴﾗｰﾒｯｾｰｼﾞ (2010/05/19 kato ﾒｯｾｰｼﾞ表示を1回にするため追加)</param>
    ''' <returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer04(ByRef objTelegramSend As clsTelegram _
                                   , ByVal strSendTel() As String _
                                   , Optional ByRef strRET_STATE As String = "" _
                                   , Optional ByRef strRET_DATA_SYUBETU As String = "" _
                                   , Optional ByRef strRET_DATA As String = "" _
                                   , Optional ByRef strUSER_ID As String = "" _
                                   , Optional ByRef strErrMessage As String = "" _
                                     ) _
                                     As clsSocketClient.RetCode

        Try

            Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値


            '*******************************************************
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加
            '*******************************************************
            Dim dtNow As Date = Now                     'Now
            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除(初期化)
            '===========================================
            ''Call DeleteParamTable()

            '===========================================
            'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録
            '===========================================

            ''他処理の影響を受けないように端末IDを編集する
            Dim strBefTremID As String = gcstrFTERM_ID
            gcstrFTERM_ID = gcstrFTERM_ID & "_" & Now.ToString("yyyyMMddHHmmss")

            Call RgstParamTable(strSendTel, dtNow)       'ﾃﾞｰﾀ登録

            '端末IDを元に戻す
            gcstrFTERM_ID = strBefTremID

            '*******************************************************
            'ｿｹｯﾄ送信
            '*******************************************************
            udtSckSendRET = SockSendServer01(objTelegramSend _
                                         , strRET_STATE _
                                         , strRET_DATA_SYUBETU _
                                         , strRET_DATA _
                                         , strUSER_ID _
                                         , strErrMessage _
                                         )


            Return (udtSckSendRET)

        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex
        Finally
            ''枝番１のパラメータのみ削除する
            Call DeleteParamTable(1)
        End Try
    End Function
#End Region
#Region "  ｿｹｯﾄ送信         (ﾛｸﾞｲﾝｿｹｯﾄ送信)                             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞｲﾝのｿｹｯﾄを送信する。
    ''' </summary>
    ''' <param name="strFLOGIN_ID">ﾛｸﾞｲﾝID</param>
    ''' <param name="strFPASS_WORD">ﾊﾟｽﾜｰﾄﾞ</param>
    ''' <param name="strRET_STATE">応答ｽﾃｰﾀｽ</param>
    ''' <param name="strFSYORI_ID">処理ID    ﾃﾞﾌｫﾙﾄ:200007</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function SendSockLogin(ByVal strFLOGIN_ID As String _
                                , ByVal strFPASS_WORD As String _
                                , ByRef strRET_STATE As String _
                                , Optional ByVal strFSYORI_ID As String = FSYORI_ID_S200007 _
                                ) _
                                As clsSocketClient.RetCode


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strDSPLOGIN_ID As String = ""   'ﾛｸﾞｲﾝID
        Dim strPASSWORD As String = ""      'ﾊﾟｽﾜｰﾄﾞ

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & strFSYORI_ID           'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        strDSPLOGIN_ID = strFLOGIN_ID           'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        strPASSWORD = strFPASS_WORD             'ﾊﾟｽﾜｰﾄﾞ

        objTelegram.SETIN_DATA("DSPLOGIN_ID", strDSPLOGIN_ID)           'ﾛｸﾞｲﾝﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPPASS_WORD", strPASSWORD)             'ﾊﾟｽﾜｰﾄﾞ


        Dim udtSckSendRET As clsSocketClient.RetCode                    'ｿｹｯﾄ送信戻り値
        udtSckSendRET = SockSendServer01(objTelegram, strRET_STATE)     'ｿｹｯﾄ送信


        Return udtSckSendRET
    End Function
#End Region
#Region "　ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙﾃﾞｰﾀ登録　    "
    ''' '*******************************************************************************************************************
    ''' '【機能】<summary> ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙﾃﾞｰﾀ登録 </summary>
    ''' '【引数】<param name="strSndTlgrm"> [IN ]送信電文 </param>
    ''' '        <param name="dtUpdateDt">  [IN ]更新日時 </param>
    ''' '【戻値】
    ''' '*******************************************************************************************************************
    Public Sub RgstParamTable(ByVal strSndTlgrm() As String _
                            , ByVal dtUpdateDt As Date _
                            )

        Try

            Dim intPrmNo As Integer = 0         'ﾊﾟﾗﾒｰﾀ枝番
            Dim strRcvTlgrm As String = ""      '受信電文
            Dim intII As Integer                'ﾙｰﾌﾟ変数

            Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(gobjOwner, gobjDb, Nothing)     '出庫計画ｸﾗｽ

            '******************************************
            ' ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録
            '******************************************
            '=======================================
            ' ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '=======================================
            gobjDb.BeginTrans()                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始

            '=======================================
            ' ﾃｰﾌﾞﾙに登録
            '=======================================
            For intII = 0 To UBound(strSndTlgrm)
                '(送信電文分ﾙｰﾌﾟ)

                '---------------------------------
                ' 枝番
                '---------------------------------
                intPrmNo = intPrmNo + 1

                '=======================================
                ' ﾃｰﾌﾞﾙｸﾗｽによるINSERT
                '=======================================
                objTPRG_PARAM_TBL.FPARA_ID = gcstrFTERM_ID              'ﾊﾟﾗﾒｰﾀID
                objTPRG_PARAM_TBL.FPARA_EDA_NO = intPrmNo               'ﾊﾟﾗﾒｰﾀ枝番
                objTPRG_PARAM_TBL.FSEND_DATA = strSndTlgrm(intII)       '送信電文
                objTPRG_PARAM_TBL.FRECV_DATA = ""                       '受信電文
                objTPRG_PARAM_TBL.FUPDATE_DT = dtUpdateDt               '更新日時
                objTPRG_PARAM_TBL.FENTRY_DT = dtUpdateDt                '登録日時(更新日時と同じﾃﾞｰﾀ)

                objTPRG_PARAM_TBL.ADD_TPRG_PARAM_TBL()

            Next


            '=======================================
            ' ｺﾐｯﾄ
            '=======================================
            gobjDb.Commit()                     'ｺﾐｯﾄ

        Catch ex As Exception

            '=======================================
            ' ﾛｰﾙﾊﾞｯｸ
            '=======================================
            gobjDb.RollBack()       'ﾛｰﾙﾊﾞｯｸ
            Call ComError_frm(ex)
            Throw ex

        End Try

    End Sub
#End Region
#Region "　ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙﾃﾞｰﾀ削除　    "
    ''' '*******************************************************************************************************************
    ''' '【機能】<summary> ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ削除 </summary>
    ''' '【戻値】
    ''' '*******************************************************************************************************************
    Public Sub DeleteParamTable(Optional ByVal intEDANo As Integer = 0)


        Try

            'Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(gobjOwner, gobjDb, Nothing)     '出庫計画ｸﾗｽ
            Dim strSQL As String

            strSQL = ""
            strSQL &= vbCrLf & " DELETE "
            strSQL &= vbCrLf & "     TPRG_PARAM_TBL "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "     FPARA_ID = '" & gcstrFTERM_ID & "'"

            '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            '検査結果登録改善対応 2017/08/18 YAMAMOTO
            If intEDANo = 1 Then
                strSQL &= vbCrLf & " AND "
                strSQL &= vbCrLf & "     FPARA_EDA_NO = 1"
            End If
            '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

            strSQL &= vbCrLf

            '******************************************
            ' ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録
            '******************************************
            '=======================================
            ' ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '=======================================
            gobjDb.BeginTrans()                 'ﾄﾗﾝｻﾞｸｼｮﾝ開始


            ''=======================================
            '' ﾃｰﾌﾞﾙｸﾗｽによるDELETE
            ''=======================================
            'objTPRG_PARAM_TBL.FPARA_ID = strPrmID                       'ﾊﾟﾗﾒｰﾀID
            'objTPRG_PARAM_TBL.DELETE_TPRG_PARAM_TBL()                   '削除
            gobjDb.SQL = strSQL
            gobjDb.Execute()

            '=======================================
            ' ｺﾐｯﾄ
            '=======================================
            gobjDb.Commit()                     'ｺﾐｯﾄ


        Catch ex As Exception

            '=======================================
            ' ﾛｰﾙﾊﾞｯｸ
            '=======================================
            gobjDb.RollBack()       'ﾛｰﾙﾊﾞｯｸ
            Call ComError_frm(ex)
            Throw ex

        End Try

    End Sub
#End Region
#Region "　ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙﾃﾞｰﾀ受信電文取得　"
    ''' '*******************************************************************************************************************
    ''' '【機能】<summary>ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙﾃﾞｰﾀ受信電文取得</summary>
    ''' '【引数】<param name="strPrmID">            [IN ]ﾊﾟﾗﾒｰﾀID                                               </param>
    ''' '        <param name="strRET_STATE">        [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ｽﾃｰﾀｽ     (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '        <param name="strRET_DATA_SYUBETU"> [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ﾃﾞｰﾀ種別  (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '        <param name="strRET_DATA">         [OUT]ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙから取得した応答ﾃﾞｰﾀ      (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' '【戻値】
    ''' '*******************************************************************************************************************
    Public Sub RcvTlgrmParamTable(ByVal strPrmID As String _
                                , Optional ByRef strRET_STATE() As String = Nothing _
                                , Optional ByRef strRET_DATA_SYUBETU() As String = Nothing _
                                , Optional ByRef strRET_DATA() As String = Nothing _
                                  )


        Dim objTPRG_PARAM_TBL As New TBL_TPRG_PARAM_TBL(gobjOwner, gobjDb, Nothing)
        Dim lngDataCnt As Long      'ﾃﾞｰﾀ数
        Dim intII As Integer        'ﾙｰﾌﾟ変数

        Dim strRcvTlgrm(0) As String
        objTPRG_PARAM_TBL.FPARA_ID = strPrmID                  'ﾊﾟﾗﾒｰﾀID
        lngDataCnt = objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL_COUNT()   'ﾃﾞｰﾀ数取得

        ReDim strRcvTlgrm(lngDataCnt - 1)                   '受信電文
        ReDim strRET_STATE(lngDataCnt - 1)                  '受信応答ｽﾃｰﾀｽ
        ReDim strRET_DATA_SYUBETU(lngDataCnt - 1)           '受信応答ﾃﾞｰﾀ種別
        ReDim strRET_DATA(lngDataCnt - 1)                   '受信応答ﾃﾞｰﾀ

        Dim strRET_MESSAGE_EXIST(lngDataCnt - 1) As String          '応答ﾒｯｾｰｼﾞ有無
        Dim strRET_MESSAGE(lngDataCnt - 1) As String                '応答ﾒｯｾｰｼﾞ

        For intII = 0 To lngDataCnt - 1
            '(ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙ登録ﾃﾞｰﾀ分ﾙｰﾌﾟ)

            objTPRG_PARAM_TBL.FPARA_EDA_NO = intII + 1  '枝番
            objTPRG_PARAM_TBL.GET_TPRG_PARAM_TBL(False)

            strRcvTlgrm(intII) = objTPRG_PARAM_TBL.FRECV_DATA       '受信電文取得


            '***************************************************
            ' 受信ｿｹｯﾄ解析
            '***************************************************
            Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP)


            objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramRecv.TELEGRAM_PARTITION = strRcvTlgrm(intII)                         '分割する電文ｾｯﾄ
            objTelegramRecv.PARTITION()                                                     '電文分割
            strRET_STATE(intII) = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                      '応答ｽﾃｰﾀｽ
            strRET_MESSAGE_EXIST(intII) = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")      '応答ﾒｯｾｰｼﾞ有無
            strRET_MESSAGE(intII) = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))            '応答ﾒｯｾｰｼﾞ
            strRET_DATA_SYUBETU(intII) = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU"))  '応答ﾃﾞｰﾀ種別
            strRET_DATA(intII) = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA"))                  '応答ﾃﾞｰﾀ


            '---------------------------------
            'ﾒｯｾｰｼﾞ表示
            '---------------------------------
            If Trim(strRET_MESSAGE_EXIST(intII)) = ID_RETURN_RET_MESSAGE_EXIST_YES Then

                Select Case Trim(strRET_STATE(intII))
                    Case ID_RETURN_RET_STATE_OK
                        Call DisplayPopup(strRET_MESSAGE(intII), PopupFormType.Ok, PopupIconType.Information, "", FRM_MSG_SOCKSENDSERVER_91)
                    Case ID_RETURN_RET_STATE_NG
                        Call DisplayPopup(strRET_MESSAGE(intII), PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                    Case Else
                        Call DisplayPopup(strRET_MESSAGE(intII), PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                End Select

            End If

        Next


    End Sub
#End Region
#Region "　ﾊﾟﾗﾒｰﾀ通知ｿｹｯﾄ送信　     "
    ''' '*******************************************************************************************************************
    ''' '【機能】<summary>ﾊﾟﾗﾒｰﾀ通知ｿｹｯﾄ送信</summary>
    ''' '【引数】<param name="strPrmID">        [IN ]ﾊﾟﾗﾒｰﾀID</param>
    ''' '        <param name="strRET_STATE">    [OUT]ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ     (ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' '【戻値】<returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' '*******************************************************************************************************************
    Public Function SendSock_PARAMETER(ByVal strPrmID As String _
                                     , Optional ByRef strRET_STATE As String = "" _
                                     ) _
                                     As clsSocketClient.RetCode


        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        '========================================
        ' 変数ｾｯﾄ
        '========================================
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200001   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPPARA_ID", strPrmID)              'ﾊﾟﾗﾒｰﾀID

        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strSckSndRetState As String = ""     'ｿｹｯﾄ送信応答ｽﾃｰﾀｽ

        udtSckSendRET = SockSendServer01(objTelegram, strSckSndRetState)   'ｿｹｯﾄ送信

        strRET_STATE = strSckSndRetState        '応答ｽﾃｰﾀｽ

        Return udtSckSendRET

    End Function
#End Region


    'その他
#Region "  ｴﾗｰ処理      (継承画面用)            "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理(継承画面用)
    ''' </summary>
    ''' <param name="objException">ｴﾗｰの Exception</param>
    ''' <param name="lblError">ｴﾗｰを表示させるﾗﾍﾞﾙ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub ComError_frm(ByVal objException As Exception _
                          , Optional ByVal lblError As Windows.Forms.Label = Nothing _
                            )
        Try


            '***************************************
            'Wait画面を強制的にｸﾛｰｽﾞ
            '  ﾌﾟﾘﾝﾄｴﾗｰの時、Wait画面が残ったままになる為
            '  どうせなら、ｴﾗｰが発生した時には、何も考えずWait画面を削除するように
            '***************************************
            Call WaitFormClose()


            '***************************************
            'ﾃｷｽﾄ生成
            '***************************************
            Dim strTemp As String
            Dim strStackTrace(0) As String
            strTemp = Replace(objException.StackTrace, ",", "，")       '半角ｶﾝﾏを全角ｶﾝﾏに変換
            strStackTrace = Split(strTemp, vbCrLf)


            '****************************************
            ' ﾛｸﾞ書込み
            '****************************************
            For ii As Integer = LBound(strStackTrace) To UBound(strStackTrace)
                AddToLog_frm(objException.Message, _
                             AddToLog_D_ErrorType.PROGRAM_ERROR, _
                             strStackTrace(ii))
            Next


            '***************************************
            'ﾗﾍﾞﾙ出力
            '***************************************
            If Not (IsNull(lblError)) Then
                lblError.Text = FRM_ERR_COMERROR_TITLE & objException.Message
            Else

                MsgBox(objException.Message, _
                       MsgBoxStyle.Exclamation, _
                       FRM_ERR_COMERROR_TITLE)

            End If


        Catch ex2 As Exception
            MsgBox("ComError_frm関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  ﾛｸﾞ書込処理                          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ﾛｸﾞ書込処理
    ''' </summary>
    ''' <param name="strMsg_1">ﾒｯｾｰｼﾞ1</param>
    ''' <param name="intErrorType">ｴﾗｰﾀｲﾌﾟ</param>
    ''' <param name="strMsg_3">ﾒｯｾｰｼﾞ3</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub AddToLog_frm(ByVal strMsg_1 As String _
                          , Optional ByVal intErrorType As AddToLog_D_ErrorType = AddToLog_D_ErrorType.USER_LOG _
                          , Optional ByVal strMsg_3 As String = "" _
                          )
        Try
            Dim strMsg_2 As String = ""

            '***************************************
            'ログ出力
            '***************************************
            Dim objLogWrite As clsWriteLog
            objLogWrite = New clsWriteLog
            objLogWrite.clspFileName = gcstrLOG_FILE_PATH & "(TERM)" & gcstrFTERM_ID & gcstrLOG_FILE_NAME          'ﾌｧｲﾙ名         ｾｯﾄ
            objLogWrite.clspCopyFile = gcstrLOG_FILE_PATH & "(TERM)" & gcstrFTERM_ID & gcstrLOG_FILE_NAME_OLD      'ﾌｧｲﾙ名(古い)   ｾｯﾄ
            objLogWrite.clspMaxSize = gcstrLOG_FILE_SIZE                                                '最大ﾌｧｲﾙｻｲｽﾞ   ｾｯﾄ


            Select Case intErrorType
                Case AddToLog_D_ErrorType.PROGRAM_ERROR
                    strMsg_2 = FRM_ERR_COMERROR_TITLE
                Case AddToLog_D_ErrorType.USER_ERROR
                    strMsg_2 = FRM_ERR_USERERRO_TITLE
                Case AddToLog_D_ErrorType.USER_LOG
                    strMsg_2 = FRM_ERR_USERLOG_TITLE
            End Select


            objLogWrite.WriteLog(strMsg_1, strMsg_2, strMsg_3)              'ﾛｸﾞ書込

        Catch ex2 As Exception
            MsgBox("AddToLog_frm関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  Configﾌｧｲﾙから、情報取得             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙから情報取得
    ''' </summary>
    ''' <param name="sKey">検索するｷｰ</param>
    ''' <returns>Configﾌｧｲﾙから取得した文字列</returns>
    ''' <remarks>引数にて指示された情報をConfigﾌｧｲﾙより取得する</remarks>
    ''' *******************************************************************************************************************
    Public Function GET_CONFIG_INFO(ByVal sKey As String) As String
        Dim strRet As String = ""                               '戻値
        Dim objSystem As New clsConnectConfig(CONFIG_APP)       'Configﾌｧｲﾙ接続ｸﾗｽ（画面用Config）

        strRet = TO_STRING(objSystem.GET_INFO(sKey))

        Return (strRet)
    End Function
#End Region
#Region "  ﾎﾞﾀﾝｾｯﾄ      (ﾎﾞﾀﾝ表示名取得)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾞﾀﾝｾｯﾄ(ﾎﾞﾀﾝ表示名取得)
    ''' </summary>
    ''' <param name="strDisp_ID">ﾌｫｰﾑ名</param>
    ''' <param name="cmdButton">ﾃｷｽﾄをｾｯﾄするﾎﾞﾀﾝ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ButtonTextSet(ByVal strDisp_ID As String _
                           , ByRef cmdButton As System.Windows.Forms.Button _
                             )
        Dim intRet As RetCode                   '戻り値


        '**********************************************************
        ' 画面ID取得
        '   【画面ｺﾝﾄﾛｰﾙﾏｽﾀ】
        '**********************************************************
        Dim objDSP_CTRL As New TBL_TDSP_CTRL(gobjOwner, gobjDb, Nothing)
        objDSP_CTRL.FDISP_ID = strDisp_ID                   '画面ID
        objDSP_CTRL.FCTRL_ID = cmdButton.Name               'ｺﾝﾄﾛｰﾙ名
        objDSP_CTRL.FCTRL_ORDER = 1                         '順番
        intRet = objDSP_CTRL.GET_TDSP_CTRL(False)           '情報取得
        If intRet <> RetCode.OK Then
            Call DisplayPopup(FRM_MSG_BUTTONTEXTSET_02, _
                              PopupFormType.Ok, _
                              PopupIconType.Err)
            Exit Sub
        End If


        '**********************************************************
        ' ﾎﾞﾀﾝ名取得
        '   【画面表示ﾏｽﾀ】
        '**********************************************************
        Dim objDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objDSP_NAME.FDISP_ID = objDSP_CTRL.FCTRL_VALUE      '画面ID     ｾｯﾄ
        objDSP_NAME.FCTRL_ID = FCTRL_ID_SKOTEI               'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objDSP_NAME.GET_TDSP_NAME(False)           '情報取得
        If intRet <> RetCode.OK Then
            Call DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Err, _
                              "ID　：" & objDSP_NAME.FDISP_ID)
            Exit Sub
        End If
        cmdButton.Text = StrIsChanged(objDSP_NAME.FOBJECT_NAME)        'ﾀｲﾄﾙ   ﾌﾟﾛﾊﾟﾃｨｾｯﾄ


        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ
        '**********************************************************
        '==================================
        '【端末別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0            '操作ﾌﾗｸﾞ   (端末別許可ﾏｽﾀ用)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '端末区分   ｾｯﾄ
        objTDSP_PMT_TERM.FDISP_ID = objDSP_CTRL.FCTRL_VALUE         '画面ID     ｾｯﾄ
        objTDSP_PMT_TERM.FCTRL_ID = FCTRL_ID_SKOTEI                  'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '情報取得
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG              '操作ﾌﾗｸﾞ
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '【ﾕｰｻﾞ別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '操作ﾌﾗｸﾞ   (ﾕｰｻﾞ別許可ﾏｽﾀ用)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ﾙｰﾌﾟ:与えられたﾕｰｻﾞﾚﾍﾞﾙ数)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ  ｾｯﾄ
            objTDSP_PMT_USER.FDISP_ID = objDSP_CTRL.FCTRL_VALUE         '画面ID         ｾｯﾄ
            objTDSP_PMT_USER.FCTRL_ID = FCTRL_ID_SKOTEI                  'ｺﾝﾄﾛｰﾙID       ｾｯﾄ
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '情報取得
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG              '操作ﾌﾗｸﾞ
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        'ﾎﾞﾀﾝEnabled
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON Then
            cmdButton.Enabled = True
        Else
            cmdButton.Enabled = False
        End If

        '==================================
        'ﾎﾞﾀﾝVisibled
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SOFF Then
            cmdButton.Visible = False
        Else
            cmdButton.Visible = True
        End If


    End Sub
#End Region
#Region "  ﾒﾆｭｰｱｲﾃﾑｾｯﾄ      (ﾒﾆｭｰ表示名取得)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾆｭｰｱｲﾃﾑｾｯﾄ(ﾒﾆｭｰ表示名取得)
    ''' </summary>
    ''' <param name="strDisp_ID">ﾌｫｰﾑ名</param>
    ''' <param name="cmdToolStripMenuItem">ﾃｷｽﾄをｾｯﾄするﾒﾆｭｰｱｲﾃﾑ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub ToolStripMenuItemSet(ByVal strDisp_ID As String _
                           , ByRef cmdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem _
                             )
        Dim intRet As RetCode                   '戻り値


        '**********************************************************
        ' 画面ID取得
        '   【画面ｺﾝﾄﾛｰﾙﾏｽﾀ】
        '**********************************************************
        Dim objDSP_CTRL As New TBL_TDSP_CTRL(gobjOwner, gobjDb, Nothing)
        objDSP_CTRL.FDISP_ID = strDisp_ID                   '画面ID
        objDSP_CTRL.FCTRL_ID = cmdToolStripMenuItem.Name    'ｺﾝﾄﾛｰﾙ名
        objDSP_CTRL.FCTRL_ORDER = 1                         '順番
        intRet = objDSP_CTRL.GET_TDSP_CTRL(False)           '情報取得
        If intRet <> RetCode.OK Then
            Call DisplayPopup(FRM_MSG_BUTTONTEXTSET_02, _
                              PopupFormType.Ok, _
                              PopupIconType.Err)
            Exit Sub
        End If


        '**********************************************************
        ' ﾎﾞﾀﾝ名取得
        '   【画面表示ﾏｽﾀ】
        '**********************************************************
        Dim objDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objDSP_NAME.FDISP_ID = objDSP_CTRL.FCTRL_VALUE      '画面ID     ｾｯﾄ
        objDSP_NAME.FCTRL_ID = FCTRL_ID_SKOTEI               'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objDSP_NAME.GET_TDSP_NAME(False)           '情報取得
        If intRet <> RetCode.OK Then
            Call DisplayPopup(FRM_MSG_BUTTONTEXTSET_01, _
                              PopupFormType.Ok, _
                              PopupIconType.Err, _
                              "ID　：" & objDSP_NAME.FDISP_ID)
            Exit Sub
        End If
        cmdToolStripMenuItem.Text = StrIsChanged(objDSP_NAME.FOBJECT_NAME)        'ﾀｲﾄﾙ   ﾌﾟﾛﾊﾟﾃｨｾｯﾄ


        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ
        '**********************************************************
        '==================================
        '【端末別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_Term As Integer = 0            '操作ﾌﾗｸﾞ   (端末別許可ﾏｽﾀ用)
        Dim objTDSP_PMT_TERM As New TBL_TDSP_PMT_TERM(gobjOwner, gobjDb, Nothing)
        objTDSP_PMT_TERM.FTERM_KUBUN = gcintFTERM_KBN               '端末区分   ｾｯﾄ
        objTDSP_PMT_TERM.FDISP_ID = objDSP_CTRL.FCTRL_VALUE         '画面ID     ｾｯﾄ
        objTDSP_PMT_TERM.FCTRL_ID = FCTRL_ID_SKOTEI                  'ｺﾝﾄﾛｰﾙID   ｾｯﾄ
        intRet = objTDSP_PMT_TERM.GET_TDSP_PMT_TERM(False)          '情報取得
        If intRet = RetCode.OK Then
            intFOPE_FLAG_Term = objTDSP_PMT_TERM.FOPE_FLAG              '操作ﾌﾗｸﾞ
        Else
            intFOPE_FLAG_Term = gcintOPE_FLG
        End If

        '==================================
        '【ﾕｰｻﾞ別許可ﾏｽﾀ】
        '==================================
        Dim intFOPE_FLAG_User As Integer = 0        '操作ﾌﾗｸﾞ   (ﾕｰｻﾞ別許可ﾏｽﾀ用)
        For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
            '(ﾙｰﾌﾟ:与えられたﾕｰｻﾞﾚﾍﾞﾙ数)

            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ  ｾｯﾄ
            objTDSP_PMT_USER.FDISP_ID = objDSP_CTRL.FCTRL_VALUE         '画面ID         ｾｯﾄ
            objTDSP_PMT_USER.FCTRL_ID = FCTRL_ID_SKOTEI                  'ｺﾝﾄﾛｰﾙID       ｾｯﾄ
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '情報取得
            If intRet = RetCode.OK Then
                intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG              '操作ﾌﾗｸﾞ
            Else
                intFOPE_FLAG_User = gcintOPE_FLG
            End If
            If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

        Next

        '==================================
        'ﾎﾞﾀﾝEnabled
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SON And intFOPE_FLAG_User = FOPE_FLAG_SON Then
            cmdToolStripMenuItem.Enabled = True
        Else
            cmdToolStripMenuItem.Enabled = False
        End If

        '==================================
        'ﾎﾞﾀﾝVisibled
        '==================================
        If intFOPE_FLAG_Term = FOPE_FLAG_SOFF Then
            cmdToolStripMenuItem.Visible = False
        Else
            cmdToolStripMenuItem.Visible = True
        End If


    End Sub
#End Region
#Region "  exeのｼｪﾙ起動                         "
    ''' ****************************************************************************************
    ''' <summary>
    ''' exeのｼｪﾙ起動
    ''' </summary>
    ''' <param name="strExe">exe名</param>
    ''' <param name="strPar">ｺﾏﾝﾄﾞ引数</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub PubF_ShellExe(ByVal strExe As String _
                           , Optional ByVal strPar As String = "" _
                           )

        Dim sCmd As String
        sCmd = strExe & Space(1) & Trim(strPar)
        Call Shell(sCmd, _
                   AppWinStyle.NormalFocus, _
                   False, _
                   5000)

    End Sub
#End Region
#Region "　ﾗﾍﾞﾙ表示用名称取得　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ表示用名称取得
    ''' </summary>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strFieldName">ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strDispValue">画面表示設定値</param>
    ''' <param name="lblControl">表示用名称</param>
    ''' <remarks>画面表示ﾏｽﾀからﾗﾍﾞﾙ表示用名称取得</remarks>
    ''' *******************************************************************************************************************
    Public Sub DispLabel(ByVal strTableName As String _
                       , ByVal strFieldName As String _
                       , ByVal strDispValue As String _
                       , ByVal lblControl As Windows.Forms.Label _
                       )


        '----------------------
        'TDSP_DISP
        '----------------------
        Dim objTDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
        objTDSP_DISP.FTABLE_NAME = strTableName            'ﾃｰﾌﾞﾙ名
        objTDSP_DISP.FFIELD_NAME = strFieldName            'ﾌｨｰﾙﾄﾞ名
        objTDSP_DISP.FDISP_VALUE = strDispValue            'ﾃｰﾌﾞﾙ名
        If objTDSP_DISP.GET_TDSP_DISP(False) = RetCode.OK Then

            lblControl.Text = objTDSP_DISP.FGAMEN_DISP

        Else

            lblControl.Text = DEFAULT_STRING

        End If


    End Sub
#End Region
#Region "　###を改行ｺｰﾄﾞに置換　                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ###を改行ｺｰﾄﾞに置換
    ''' </summary>
    ''' <param name="strChangeString">変更される文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function StrIsChanged(ByVal strChangeString As String) As String

        '###を改行ｺｰﾄﾞに置換
        strChangeString = strChangeString.Replace(REPLACE_STRING_01, vbCrLf)

        '変換した文字列を戻す
        Return strChangeString

    End Function

#End Region
#Region "  ﾗﾍﾞﾙ背景色変更       処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更処理
    ''' </summary>
    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strDISP_ID">該当する画面ID</param>
    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColor(ByVal lblControl As Label _
                             , ByVal strDISP_ID As String _
                             , ByVal udtLblDspType As LBL_DSPTYPE _
                               )

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_NAME "                           '設備状況.設備名称
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FSTS_NAME "                           '画面設備状態表示ﾏｽﾀ.状態名
        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FCOLOR_KUBUN, " & FCOLOR_KUBUN_SWHITE & ") AS FCOLOR_KUBUN "      '画面設備状態表示ﾏｽﾀ.表示色
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL "                                       '画面ｺﾝﾄﾛｰﾙﾏｽﾀ
        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL "                                    '設備状況
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                     '画面設備状態表示ﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.FEQ_ID "                '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の 設備ID を 結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN   = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "   '設備状況 と 画面設備状態表示ﾏｽﾀ の 画面設備表示区分 を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS     = TDSP_EQ_STS.FEQ_STS(+) "             '設備状況 と 画面設備状態表示ﾏｽﾀ の 設備状態 を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '設備状況 と 画面設備状態表示ﾏｽﾀ の 切離有無 を 外部結合


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            Select Case udtLblDspType
                Case LBL_DSPTYPE.EQNAME
                    '画面表示用名称変更(設備名)
                    lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
                Case LBL_DSPTYPE.STSNAME
                    '画面表示用名称変更(ｽﾃｰﾀｽ名)
                    lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
                Case LBL_DSPTYPE.NO_DSP
                    'ﾗﾍﾞﾙ表示変更無し

            End Select


            '背景色変更
            Call AlterBackColor(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))

        Else
            lblControl.BackColor = gcLabelColor_Black

        End If


    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:A.NOTO 2013/04/25  ﾗﾍﾞﾙ背景色変更(ｸﾞﾙｰﾌﾟ)を追加
    'SystemMate:H.Okumura 2013/07/08  設備状態の判定方法を変更
#Region "  ﾗﾍﾞﾙ背景色変更(ｸﾞﾙｰﾌﾟ)       処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更処理(ｸﾞﾙｰﾌﾟ)
    ''' </summary>
    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strDISP_ID">該当する画面ID</param>
    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColorGroup(ByVal lblControl As Label _
                             , ByVal strDISP_ID As String _
                             , ByVal udtLblDspType As LBL_DSPTYPE _
                               )

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim intRet As Integer               '返り値

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim blnERRFlg As Boolean = False    '異常ﾌﾗｸﾞ
        Dim blnCUTFlg As Boolean = False    '切離しﾌﾗｸﾞ
        Dim intColor As Integer = 4         '白色

        '********************************************************************
        ' SQL文作成(表示ｸﾞﾙｰﾌﾟの取得)
        '********************************************************************
        Dim objTBL_TDSP_CTRL As New TBL_TDSP_CTRL(gobjOwner, gobjDb, Nothing)
        objTBL_TDSP_CTRL.FDISP_ID = strDISP_ID          '画面ID
        objTBL_TDSP_CTRL.FCTRL_ID = lblControl.Name     'ｺﾝﾄﾛｰﾙ名
        objTBL_TDSP_CTRL.FCTRL_ORDER = "1"              '順番
        intRet = objTBL_TDSP_CTRL.GET_TDSP_CTRL()
        If intRet <> RetCode.OK Then
            '(見つからない場合)
            Exit Sub
        End If

        Dim strXEQ_DSP_GROUP_KUBUN() As String          '画面設備状態表示区分
        strXEQ_DSP_GROUP_KUBUN = TO_STRING(objTBL_TDSP_CTRL.FCTRL_VALUE).Split(",")
        objTBL_TDSP_CTRL.Close()

        '********************************************************************
        ' 設備異常の確認
        '********************************************************************
        If strXEQ_DSP_GROUP_KUBUN.Length >= 1 Then
            '(1番目=設備異常の確認)

            '============================================================
            'SELECT
            '============================================================
            strSQL = ""
            strSQL &= vbCrLf & "SELECT DISTINCT "
            strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_STS "                              '設備状況.設備状態
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                      '設備状況

            '============================================================
            'WHERE
            '============================================================
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        1 = 1 "
            strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.XEQ_DSP_GROUP_KUBUN = '" & strXEQ_DSP_GROUP_KUBUN(0) & "' "    ' 設備状況 の ｸﾞﾙｰﾌﾟ設備状態表示区分 で抽出

            '============================================================
            'ORDER BY
            '============================================================
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    FEQ_STS DESC "

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TSTS_EQ_CTRL"
            gobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)

                Dim strFEQ_STS As String = ""
                strFEQ_STS = TO_STRING(objRow("FEQ_STS"))
                If strFEQ_STS = "1" Then
                    '(異常時)
                    intColor = 2        '黄色
                    blnERRFlg = True    '異常ﾌﾗｸﾞ
                Else
                    '(通常時)
                    ''intColor = 1        '赤色
                    intColor = 6            'Lime に変更　2017/04/17 YAMAMOTO 
                End If

            End If

        End If


        If blnERRFlg = False Then
            '(異常なしの場合のみ確認)

            '********************************************************************
            ' 切離の確認
            '********************************************************************
            If strXEQ_DSP_GROUP_KUBUN.Length >= 2 Then
                '(2番目=切離の確認)

                '============================================================
                'SELECT
                '============================================================
                strSQL = ""
                strSQL &= vbCrLf & "SELECT DISTINCT "
                strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_CUT_STS "                          '設備状況.切離状態
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                      '設備状況

                '============================================================
                'WHERE
                '============================================================
                strSQL &= vbCrLf & " WHERE "
                strSQL &= vbCrLf & "        1 = 1 "
                strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.XEQ_DSP_GROUP_KUBUN = '" & strXEQ_DSP_GROUP_KUBUN(1) & "' "    ' 設備状況 の ｸﾞﾙｰﾌﾟ設備状態表示区分 で抽出

                '============================================================
                'ORDER BY
                '============================================================
                strSQL &= vbCrLf & " ORDER BY "
                strSQL &= vbCrLf & "    FEQ_CUT_STS DESC "

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TSTS_EQ_CTRL"
                gobjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count = 0 Then
                    '(該当なし)
                ElseIf objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
                    '(状態が1種類の場合)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)

                    Dim strFEQ_CUT_STS As String = ""
                    strFEQ_CUT_STS = TO_STRING(objRow("FEQ_CUT_STS"))   '切離状態

                    If strFEQ_CUT_STS = "1" Then
                        '(切離時)
                        intColor = 4        '白色
                    Else
                        '(通常時)
                        'intColor = 1        '赤色
                        intColor = 6            'Lime に変更　2017/04/17 YAMAMOTO 
                    End If


                ElseIf objDataSet.Tables(strDataSetName).Rows.Count >= 2 Then
                    '(状態が複数の場合)

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2013/10/11 1つでも運転で赤色に変更
                    '' ''intColor = 6        '薄緑色
                    'intColor = 1        '赤色
                    intColor = 6            'Lime に変更　2017/04/17 YAMAMOTO 
                    'JobMate:S.Ouchi 2013/10/11 1つでも運転で赤色に変更
                    '↑↑↑↑↑↑************************************************************************************************************

                End If

            End If

        End If

        '********************************************************************
        ' 色の変更
        '********************************************************************
        ' ''Select Case udtLblDspType
        ' ''    Case LBL_DSPTYPE.EQNAME
        ' ''        '画面表示用名称変更(設備名)
        ' ''        'lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
        ' ''        lblControl.Text = TO_STRING(objRow("FCTRL_VALUE"))
        ' ''    Case LBL_DSPTYPE.STSNAME
        ' ''        '画面表示用名称変更(ｽﾃｰﾀｽ名)
        ' ''        lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
        ' ''    Case LBL_DSPTYPE.NO_DSP
        ' ''        'ﾗﾍﾞﾙ表示変更無し

        ' ''End Select

        Call AlterBackColor(lblControl, intColor)


    End Sub




    ' ''#Region "  ﾗﾍﾞﾙ背景色変更(ｸﾞﾙｰﾌﾟ)       処理    "
    ' ''    ''' *******************************************************************************************************************
    ' ''    ''' <summary>
    ' ''    ''' ﾗﾍﾞﾙ背景色変更処理(ｸﾞﾙｰﾌﾟ)
    ' ''    ''' </summary>
    ' ''    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ' ''    ''' <param name="strDISP_ID">該当する画面ID</param>
    ' ''    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ' ''    ''' <remarks></remarks>
    ' ''    ''' *******************************************************************************************************************
    ' ''    Public Sub AlterLabelColorGroup(ByVal lblControl As Label _
    ' ''                             , ByVal strDISP_ID As String _
    ' ''                             , ByVal udtLblDspType As LBL_DSPTYPE _
    ' ''                               )

    ' ''        Dim strSQL As String                'SQL文
    ' ''        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
    ' ''        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
    ' ''        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名


    ' ''        '********************************************************************
    ' ''        ' SQL文作成
    ' ''        '********************************************************************
    ' ''        '============================================================
    ' ''        'SELECT
    ' ''        '============================================================
    ' ''        strSQL = ""
    ' ''        strSQL &= vbCrLf & "SELECT DISTINCT "
    ' ''        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_VALUE "                           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ・ｺﾝﾄﾛｰﾙ値
    ' ''        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FSTS_NAME "                           '画面設備状態表示ﾏｽﾀ.状態名
    ' ''        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FCOLOR_KUBUN, " & FCOLOR_KUBUN_SWHITE & ") AS FCOLOR_KUBUN "      '画面設備状態表示ﾏｽﾀ.表示色
    ' ''        strSQL &= vbCrLf & " FROM "
    ' ''        strSQL &= vbCrLf & "    TDSP_CTRL "                                       '画面ｺﾝﾄﾛｰﾙﾏｽﾀ
    ' ''        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL "                                    '設備状況
    ' ''        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                     '画面設備状態表示ﾏｽﾀ

    ' ''        '============================================================
    ' ''        'WHERE
    ' ''        '============================================================
    ' ''        '----------------------------
    ' ''        'ﾃｰﾌﾞﾙ結合
    ' ''        '----------------------------
    ' ''        strSQL &= vbCrLf & " WHERE "
    ' ''        strSQL &= vbCrLf & "        1 = 1 "
    ' ''        strSQL &= vbCrLf & "    AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
    ' ''        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"               '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
    ' ''        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                      '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
    ' ''        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.XEQ_DSP_GROUP_KUBUN(+) "    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の ｸﾞﾙｰﾌﾟ設備状態表示区分 を 結合
    ' ''        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN   = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "       '設備状況 と 画面設備状態表示ﾏｽﾀ の 画面設備表示区分 を 外部結合
    ' ''        strSQL &= vbCrLf & "    AND ( "
    ' ''        strSQL &= vbCrLf & "         SELECT "
    ' ''        strSQL &= vbCrLf & "           A.FEQ_STS "
    ' ''        strSQL &= vbCrLf & "         FROM "
    ' ''        strSQL &= vbCrLf & "           ( "
    ' ''        strSQL &= vbCrLf & "            SELECT "
    ' ''        strSQL &= vbCrLf & "               TSTS_EQ_CTRL.FEQ_STS "
    ' ''        strSQL &= vbCrLf & "            FROM "
    ' ''        strSQL &= vbCrLf & "               TDSP_CTRL "
    ' ''        strSQL &= vbCrLf & "             , TSTS_EQ_CTRL "
    ' ''        strSQL &= vbCrLf & "            WHERE 1 = 1 "
    ' ''        strSQL &= vbCrLf & "             AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                   '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
    ' ''        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"              '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
    ' ''        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                     '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
    ' ''        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.XEQ_DSP_GROUP_KUBUN(+) "   '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の ｸﾞﾙｰﾌﾟ設備状態表示区分 を 結合
    ' ''        strSQL &= vbCrLf & "            ORDER BY "
    ' ''        strSQL &= vbCrLf & "               FEQ_STS DESC "
    ' ''        strSQL &= vbCrLf & "           ) A "
    ' ''        strSQL &= vbCrLf & "         WHERE "
    ' ''        strSQL &= vbCrLf & "           ROWNUM = 1 "
    ' ''        strSQL &= vbCrLf & "        ) = TDSP_EQ_STS.FEQ_STS "                                       '設備状況 と 画面設備状態表示ﾏｽﾀ の 設備状態 を 結合
    ' ''        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '設備状況 と 画面設備状態表示ﾏｽﾀ の 切離有無 を 外部結合


    ' ''        '********************************************************************
    ' ''        'ﾃﾞｰﾀｾｯﾄ取得
    ' ''        '********************************************************************
    ' ''        '-----------------------
    ' ''        '抽出
    ' ''        '-----------------------
    ' ''        gobjDb.SQL = strSQL
    ' ''        objDataSet.Clear()
    ' ''        strDataSetName = "TDSP_EQ_STS"
    ' ''        gobjDb.GetDataSet(strDataSetName, objDataSet)
    ' ''        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
    ' ''            objRow = objDataSet.Tables(strDataSetName).Rows(0)

    ' ''            Select Case udtLblDspType
    ' ''                Case LBL_DSPTYPE.EQNAME
    ' ''                    '画面表示用名称変更(設備名)
    ' ''                    'lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
    ' ''                    lblControl.Text = TO_STRING(objRow("FCTRL_VALUE"))
    ' ''                Case LBL_DSPTYPE.STSNAME
    ' ''                    '画面表示用名称変更(ｽﾃｰﾀｽ名)
    ' ''                    lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
    ' ''                Case LBL_DSPTYPE.NO_DSP
    ' ''                    'ﾗﾍﾞﾙ表示変更無し

    ' ''            End Select


    ' ''            If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
    ' ''                '(1件の時)
    ' ''                Call AlterBackColor(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))
    ' ''            Else
    ' ''                ''(複数件の時)
    ' ''                'objRow2 = objDataSet.Tables(strDataSetName).Rows(1)     '2件目
    ' ''                'If (TO_STRING(objRow("FSTS_NAME")) = "切離中") And _
    ' ''                '   (TO_STRING(objRow2("FSTS_NAME")) = "異常") Then
    ' ''                '    '(切離中かつ異常の時)
    ' ''                '    '背景色変更
    ' ''                '    Call AlterBackColor(lblControl, TO_NUMBER(objRow2("FCOLOR_KUBUN")))
    ' ''                'Else
    ' ''                '    '(以外の時)
    ' ''                '    Call AlterBackColor(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))
    ' ''                'End If
    ' ''            End If

    ' ''        Else
    ' ''            lblControl.BackColor = gcLabelColor_Black

    ' ''        End If

    ' ''    End Sub
    ' ''#End Region
#End Region
    '↑↑↑↑↑↑************************************************************************************************************
#Region "  背景色変更処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 背景色変更処理
    ''' </summary>
    ''' <param name="objControl">背景色を変更するｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intColorKubun">ｶﾗｰ区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterBackColor(ByVal objControl As Object _
                            , ByVal intColorKubun As Integer _
                            )

        '******************************************
        '背景色変更
        '******************************************
        Select Case intColorKubun
            Case FCOLOR_KUBUN_SBLUE
                objControl.BackColor = gcLabelColor_Blue
            Case FCOLOR_KUBUN_SRED
                objControl.BackColor = gcLabelColor_Red
            Case FCOLOR_KUBUN_SYELLOW
                objControl.BackColor = gcLabelColor_Yellow

            Case FCOLOR_KUBUN_SPURPLE
                objControl.BackColor = gcLabelColor_Purple

            Case FCOLOR_KUBUN_SWHITE
                objControl.BackColor = gcLabelColor_White

            Case FCOLOR_KUBUN_SGREEN
                objControl.BackColor = gcLabelColor_Green

            Case FCOLOR_KUBUN_SLIGHTGREEN
                objControl.BackColor = gcLabelColor_LightGreen

            Case FCOLOR_KUBUN_SORANGE
                objControl.BackColor = gcLabelColor_Orange

            Case Else
                objControl.BackColor = gcLabelColor_Black

        End Select

    End Sub
#End Region
#Region "  ｸﾛｰｽﾞ処理                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾛｰｽﾞ処理
    ''' </summary>
    ''' <param name="objForm"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MeClose(ByRef objForm As Form)
        objForm.Close()
        objForm.Dispose()
        objForm = Nothing
    End Sub
#End Region
#Region "  文字列をx文字ずつ分割して、配列に挿入    "
    '''****************************************************************************************
    ''' <summary>
    ''' 文字列をx文字ずつ分割して、配列に挿入
    ''' </summary>
    ''' <param name="strString">分割する文字列</param>
    ''' <param name="strArray">分割後の配列</param>
    ''' <param name="intDivLength">分割する文字数</param>
    ''' <remarks></remarks>
    '''****************************************************************************************
    Public Sub DivStringToArray(ByVal strString As String _
                              , ByRef strArray() As String _
                              , Optional ByVal intDivLength As Integer = 180 _
                              )
        Dim strWork As String = strString
        Dim ii As Integer = 0


        While True
            Dim strTemp As String = MID_SJIS(strWork, 1, intDivLength)
            If strTemp = "" Then Exit While
            ReDim Preserve strArray(ii)
            strArray(ii) = strTemp
            ii += 1
            strWork = Replace(strWork, strTemp, "")
        End While


    End Sub
#End Region


    '↓↓↓FlexGrid→DataGridView移行
    'ｸﾞﾘｯﾄﾞ関数
#Region "  ｸﾞﾘｯﾄﾞ表示処理                       "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理
    ''' </summary>
    ''' <param name="objDataTable">表示するﾃﾞｰﾀﾃｰﾌﾞﾙ</param>
    ''' <param name="grdControl">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="intSelectRow">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの行位置      (ﾃﾞﾌｫﾙﾄ = -1)</param>
    ''' <param name="intSelectCol">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの列位置      (ﾃﾞﾌｫﾙﾄ =  1)</param>
    ''' <param name="objPoint">ｸﾞﾘｯﾄﾞの以前のｽｸﾛｰﾙ位置           (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GridDisplay(ByVal objDataTable As System.Data.DataTable _
                              , ByVal grdControl As GamenCommon.cmpMDataGrid _
                              , Optional ByRef intSelectRow As Integer = -1 _
                              , Optional ByRef intSelectCol As Integer = -1 _
                              , Optional ByRef objPoint As Object = Nothing _
                                ) _
                                As RetPopup


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        If grdControl.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdControl.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdControl.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        Dim intScrollX, intScrollY As Integer
        intScrollX = grdControl.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        intScrollY = grdControl.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦


        grdControl.blnDBUpdate = False
        Try

            ' ''===================================
            ' ''描画設定(false)
            ' ''===================================
            ''grdControl.Redraw = False

            '*******************************************
            'ﾘｽﾄの表示
            '*******************************************
            If IsNull(grdControl.DataSource) = False Then
                grdControl.DataSource.Rows.Clear()
                grdControl.DataSource.Dispose()
                grdControl.DataSource = Nothing
            End If
            grdControl.RowCount = 0
            grdControl.ColumnCount = 0
            grdControl.DataSource = objDataTable

        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex

        Finally
            ' ''===================================
            ' ''描画設定(True)
            ' ''===================================
            ''grdControl.Redraw = True
            grdControl.blnDBUpdate = True

        End Try


        '===================================
        '前回の選択状態
        '===================================
        Try
            objPoint = Nothing
            objPoint = New Point(intScrollX, intScrollY)    'ｽｸﾛｰﾙﾊﾞｰ位置　
        Catch ex As Exception
            intSelectRow = -1                  'ﾘｽﾄの行
            intSelectCol = -1                  'ﾘｽﾄの列
            objPoint = New Point(0, 0)         'ｽｸﾛｰﾙﾊﾞｰ位置　
        End Try


    End Function
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示処理(ﾃﾞｰﾀ件数ﾁｪｯｸ有)       "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示処理(ﾃﾞｰﾀ件数ﾁｪｯｸ有)
    ''' </summary>
    ''' <param name="grdControl">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="strSQL">SQL文</param>
    ''' <param name="blnNotFoundMsg">表示するﾃﾞｰﾀが一行も存在しなかった場合、その旨をﾒｯｾｰｼﾞを表示するかどうかのﾌﾗｸﾞ</param>
    ''' <param name="blnCheckRowCount">行数をﾁｪｯｸするか否かのﾌﾗｸﾞ    [True:ﾁｪｯｸする][False:ﾁｪｯｸしない]   (ﾃﾞﾌｫﾙﾄ = True)</param>
    ''' <param name="intSelectRow">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの行位置      (ﾃﾞﾌｫﾙﾄ = -1)</param>
    ''' <param name="intSelectCol">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの列位置      (ﾃﾞﾌｫﾙﾄ =  1)</param>
    ''' <param name="objPoint">ｸﾞﾘｯﾄﾞの以前のｽｸﾛｰﾙ位置           (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function TblDataGridDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid _
                                     , ByVal strSQL As String _
                                     , ByVal blnNotFoundMsg As Boolean _
                                     , Optional ByVal blnCheckRowCount As Boolean = True _
                                     , Optional ByRef intSelectRow As Integer = -1 _
                                     , Optional ByRef intSelectCol As Integer = 1 _
                                     , Optional ByRef objPoint As Object = Nothing _
                                       ) _
                                       As RetPopup
        Dim udtRet As RetPopup
        udtRet = RetCode.NG

        '*******************************************
        '行数ﾁｪｯｸ
        '*******************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:N.Dounoshita 2012/08/08  件数をﾁｪｯｸするとｴﾗｰとなる事がある為、必要最低限しかﾁｪｯｸは行わないようにする為
        If blnCheckRowCount = True Then
            '↑↑↑↑↑↑************************************************************************************************************

            '===================================
            'ﾃﾞｰﾀ件数取得処理
            '===================================
            Dim lngDataRows As Long
            lngDataRows = GetDataRowCount(strSQL)

            Dim lngMaxDataRows As Long
            lngMaxDataRows = GetSYS_HEN(FHENSU_ID_SGS000000_011)

            If lngDataRows > lngMaxDataRows Then
                '===================================
                '行数が多い場合
                '===================================
                Dim strMessage As String
                strMessage = TO_STRING(lngMaxDataRows) & FRM_MSG_GRIDDISPLAY_01
                strMessage &= vbCrLf & FRM_MSG_GRIDDISPLAY_03 & TO_STRING(lngDataRows) & FRM_MSG_GRIDDISPLAY_04
                Call DisplayPopup(strMessage, PopupFormType.Ok, PopupIconType.Quest)
                udtRet = RetPopup.Cancel
                Return (udtRet)

            ElseIf lngDataRows = 0 Then
                '===================================
                'ﾃﾞｰﾀが一行もない場合
                '===================================
                If blnNotFoundMsg = True Then
                    '#################### ↓↓↓↓↓ 2010/06/29 kato FlexGrid 4.0 → 5.0 への以降のため変更
                    ''grdControl.Redraw = True
                    'grdControl.EndUpdate()
                    '#################### ↑↑↑↑↑ 2010/06/29 kato FlexGrid 4.0 → 5.0 への以降のため変更
                    grdControl.Refresh()
                    udtRet = DisplayPopup(FRM_MSG_GRIDDISPLAY_02, PopupFormType.Ok, PopupIconType.Information)
                    grdControl.Refresh()
                    '#################### ↓↓↓↓↓ 2010/06/29 kato FlexGrid 4.0 → 5.0 への以降のため変更
                    ''grdControl.Redraw = False
                    'grdControl.BeginUpdate()
                    '#################### ↑↑↑↑↑ 2010/06/29 kato FlexGrid 4.0 → 5.0 への以降のため変更
                End If

            End If


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/08  件数をﾁｪｯｸするとｴﾗｰとなる事がある為、必要最低限しかﾁｪｯｸは行わないようにする為
        End If
        '↑↑↑↑↑↑************************************************************************************************************


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        If grdControl.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdControl.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdControl.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        Dim intScrollX, intScrollY As Integer
        intScrollX = grdControl.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        intScrollY = grdControl.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦

        '*******************************************
        'ﾃﾞｰﾀｾｯﾄ取得用宣言処理
        '*******************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名

        Try

            '*******************************************
            'ﾃﾞｰﾀｾｯﾄ取得
            '*******************************************
            gobjDb.SQL = strSQL
            strDataSetName = "SELECT_DATA"
            objDataSet.Clear()
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            '*******************************************
            'ｸﾞﾘｯﾄﾞ表示設定
            '*******************************************
            Dim udtReturn As RetPopup
            udtReturn = GridDisplay(objDataSet.Tables(strDataSetName), _
                                    grdControl, _
                                    intSelectRow, _
                                    intSelectCol, _
                                    objPoint)

        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex

        Finally

            '===================================
            'ﾃﾞｰﾀｾｯﾄｵﾌﾞｼﾞｪｸﾄ
            '===================================
            objDataSet = Nothing

        End Try


    End Function
#End Region
#Region "　ｸﾞﾘｯﾄﾞ初期設定処理                   "
    ''' ******************************************************************************
    ''' <summary>ｸﾞﾘｯﾄﾞ初期設定処理</summary>
    ''' <param name="objGrid">     FlexGridｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intRowsCount">行数</param>
    ''' <param name="intColsCount">列数</param>
    ''' ******************************************************************************
    Public Sub FlexGridInitialize(ByRef objGrid As GamenCommon.cmpMDataGrid _
                                , ByVal intRowsCount As Integer _
                                , ByVal intColsCount As Integer _
                                  )


        '=========================================
        'ｸﾞﾘｯﾄﾞ初期設定
        '=========================================
        objGrid.DataSource = Nothing
        'objGrid.RowCount = intRowsCount                       '行数
        objGrid.ColumnCount = intColsCount                    '列数
        'objGrid.Clear()
        'objGrid.Styles.Normal.Border.Color = Color.DarkGray
        'objGrid.DoubleBuffer = True

        '=========================================
        'ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ値設定
        '=========================================
        Call gobjComFuncGMN.FlexGridInitialize(objGrid)


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ選択処理                       "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ選択処理
    ''' </summary>
    ''' <param name="grdControl">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="intSelectRow">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの行位置      (ﾃﾞﾌｫﾙﾄ = -1)</param>
    ''' <param name="intSelectCol">ｸﾞﾘｯﾄﾞの以前の選択ｾﾙの列位置      (ﾃﾞﾌｫﾙﾄ =  1)</param>
    ''' <param name="objPoint">ｸﾞﾘｯﾄﾞの以前のｽｸﾛｰﾙ位置           (ﾃﾞﾌｫﾙﾄ = Nothing)</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub GridSelect(ByVal grdControl As GamenCommon.cmpMDataGrid _
                        , ByVal intSelectRow As Integer _
                        , ByVal intSelectCol As Integer _
                        , ByVal objPoint As Point _
                          )

        '*******************************************
        '前回の選択状態
        '*******************************************
        Try

            '======================================
            'ｾﾙ選択
            '======================================
            If intSelectCol <= 0 Then intSelectCol = 1
            If 0 <= intSelectRow And 0 <= intSelectCol Then
                grdControl.Item(intSelectCol, intSelectRow).Selected = True     'ｾﾙ選択
            Else
                grdControl.ClearSelection()                                     'ｾﾙ選択
            End If

            '======================================
            'ｽｸﾛｰﾙﾊﾞｰ位置
            '======================================
            If IsNull(objPoint) = False Then
                grdControl.HorizontalScrollingOffset = objPoint.X           'ｽｸﾛｰﾙﾊﾞｰ位置　横
                grdControl.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            End If

        Catch ex As Exception
            Try
                grdControl.ClearSelection()                                 'ｾﾙ選択
                grdControl.HorizontalScrollingOffset = 0                    'ｽｸﾛｰﾙﾊﾞｰ位置　横
                grdControl.FirstDisplayedScrollingRowIndex = 0              'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            Catch ex2 As Exception
                'NOP
            End Try
        End Try


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更(微妙に中央に寄らない対策にも使用)     "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更(微妙に中央に寄らない対策にも使用)
    ''' </summary>
    ''' <param name="grdControl">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="intSortMode">並替ﾓｰﾄﾞ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub GridSortModeSet(ByVal grdControl As GamenCommon.cmpMDataGrid _
                             , Optional ByVal intSortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable _
                             )


        '*******************************************
        '並替ﾓｰﾄﾞ       変更
        '*******************************************
        For Each objColum As DataGridViewColumn In grdControl.Columns
            objColum.SortMode = intSortMode
        Next


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞﾃﾞｰﾀ表示初期設定                                       "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞｰﾀ表示初期設定
    ''' </summary>
    ''' <param name="grdControl">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub GridDispIni(ByVal grdControl As GamenCommon.cmpMDataGrid)


        '*******************************************
        'ﾍｯﾀﾞｰの配置設定
        '*******************************************
        For Each objColum As DataGridViewColumn In grdControl.Columns
            '(ﾙｰﾌﾟ:列数)

            objColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Next


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ混載表示の複数選択処理                                 "
    Public Sub GridKonsaiSelect(ByRef objGrid As GamenCommon.cmpMDataGrid _
                              , ByRef strColDataArray() As String _
                              , ByVal intColDataPosition As Integer _
                              )
        '*********************************************
        '色々ﾁｪｯｸ
        '*********************************************
        If objGrid.blnSelectionChanged = True Then Exit Sub
        If IsNull(objGrid.DataSource) Then Exit Sub


        Try

            Dim intRet As Integer       '戻り値


            '*********************************************
            '処理中ﾌﾗｸﾞON
            '*********************************************
            objGrid.blnSelectionChanged = True


            '*********************************************
            'ﾊﾟﾚｯﾄID取得
            '*********************************************
            strColDataArray = Nothing
            For ii As Integer = 0 To objGrid.SelectedRows.Count - 1
                '(ﾙｰﾌﾟ:選択された行数)

                Dim strPalletTemp As String = objGrid.Item(intColDataPosition, objGrid.SelectedRows(ii).Index).Value

                If IsNull(strColDataArray) = True Then
                    '(最初の一回)
                    ReDim strColDataArray(0)
                    strColDataArray(0) = strPalletTemp
                Else
                    '(二回目以降)
                    intRet = ArrayFindData(strColDataArray, strPalletTemp)
                    If intRet = -1 Then
                        '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
                        ReDim Preserve strColDataArray(UBound(strColDataArray) + 1)
                        strColDataArray(UBound(strColDataArray)) = strPalletTemp
                    End If

                End If

            Next


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:H.Morita 2012/08/23 再選択しているが、1行目選択出来なかったり、無用に1行目選択されたりと不具合の為、ｺﾒﾝﾄｱｳﾄ
            '*********************************************
            'ｸﾞﾘｯﾄﾞ選択処理
            '*********************************************
            'For ii As Integer = 0 To objGrid.RowCount - 1
            '    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

            '    'Dim strPalletTemp As String = objGrid.Item(intColDataPosition, ii).Value
            '    Dim strPalletTemp As String = TO_STRING(objGrid.Item(intColDataPosition, ii).Value)

            '    intRet = ArrayFindData(strColDataArray, strPalletTemp)
            '    If intRet = -1 Then
            '        '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
            '        objGrid.Rows(ii).Selected = False
            '    Else
            '        '(見つかった場合)
            '        objGrid.Rows(ii).Selected = True
            '    End If

            'Next
            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex
        Finally
            objGrid.blnSelectionChanged = False
        End Try
    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ搬送管理量の桁数合わせ(小数点桁数使用)                 "
    ''' *****************************************************************************************************************
    ''' <summary>
    ''' 搬送管理量の桁数合わせ
    ''' 【メリット　】こっちの方が処理が速い。
    ''' 【デメリット】SQL文、プログラム文が見難く、面倒。
    ''' </summary>
    ''' <param name="objGrid">変更するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="intColFTR_VOLPosition">ﾌｫｰﾏｯﾄ変更する搬送管理量の列位置</param>
    ''' <param name="intColFDECIMAL_POINTPosition">小数点位置情報の列位置</param>
    ''' <remarks></remarks>
    ''' *****************************************************************************************************************
    Public Sub GridFTR_VOLChange01(ByRef objGrid As GamenCommon.cmpMDataGrid _
                                 , ByVal intColFTR_VOLPosition As Integer _
                                 , ByVal intColFDECIMAL_POINTPosition As Integer _
                                 )
        Dim strFormat As String = ""    'ﾌｫｰﾏｯﾄ


        For ii As Integer = 0 To objGrid.Rows.Count - 1
            '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)


            '*********************************************
            'ﾌｫｰﾏｯﾄの設定
            '*********************************************
            Dim intFDECIMAL_POINT As Integer = TO_INTEGER(objGrid.Item(intColFDECIMAL_POINTPosition, ii).Value)
            Dim strDflt As String = "#####"
            Dim strDcmlStr As String = strDflt
            If intFDECIMAL_POINT = 0 Then
                '(整数の場合)
            Else
                '(少数点桁数ありの場合)
                strDcmlStr = StrDup(intFDECIMAL_POINT, "0") & strDflt
            End If
            strFormat = "#0" & "." & strDcmlStr.Substring(0, strDflt.Length)
            objGrid.Item(intColFTR_VOLPosition, ii).Style.Format = strFormat


        Next


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ最終列にﾁｪｯｸﾎﾞｯｸｽ追加                                  "
    ''' ******************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ最終列にﾁｪｯｸﾎﾞｯｸｽ追加
    ''' </summary>
    ''' <param name="objGrid">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <param name="intDataColIndex">追加されるﾁｪｯｸﾎﾞｯｸｽが参照するﾃﾞｰﾀ元の列ｲﾝﾃﾞｯｸｽ</param>
    ''' <param name="strColName">追加する列のｶﾗﾑ名（ｵﾌﾟｼｮﾝ指定）</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************
    Public Sub GridAddCheckBoxColumn(ByVal objGrid As GamenCommon.cmpMDataGrid _
                                   , ByVal intDataColIndex As Integer _
                                   , Optional ByVal strColName As String = "CheckBox" _
                                   )
        objGrid.blnDBUpdate = False
        Try


            '************************************************
            'ﾁｪｯｸﾎﾞｯｸｽ追加
            '************************************************
            If IsNotNull(objGrid.DataSource) Then
                '(ﾃﾞｰﾀが表示されている場合)

                '=========================================
                'ﾁｪｯｸﾎﾞｯｸｽ追加
                '=========================================
                Dim objDataTable As DataTable = objGrid.DataSource
                Dim objDataColumn As DataColumn = New DataColumn(strColName, GetType(Boolean))
                objDataTable.Columns.Add(objDataColumn)

                '=========================================
                '値設定
                '=========================================
                Dim intDispIndex As Integer = objGrid.ColumnCount - 1       '最終列のｲﾝﾃﾞｯｸｽ
                For ii As Integer = 0 To objGrid.RowCount - 1
                    '(ﾙｰﾌﾟ:ﾃﾞｰﾀ件数)
                    If TO_INTEGER(objGrid.Item(intDataColIndex, ii).Value) = FLAG_ON Then
                        objGrid.Item(intDispIndex, ii).Value = True
                    Else
                        objGrid.Item(intDispIndex, ii).Value = False
                    End If
                Next

            End If


        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex
        Finally
            objGrid.blnDBUpdate = True
        End Try
    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ混載表示の複数選択処理                                 "
    Public Sub GridInOutLogSelect(ByRef objGrid As GamenCommon.cmpMDataGrid _
                                , ByRef strColDataArray() As String _
                                , ByVal intColDataPosition As Integer _
                                 )
        '*********************************************
        '色々ﾁｪｯｸ
        '*********************************************
        If objGrid.blnSelectionChanged = True Then Exit Sub
        If IsNull(objGrid.DataSource) Then Exit Sub


        Try

            Dim intRet As Integer       '戻り値


            '*********************************************
            '処理中ﾌﾗｸﾞON
            '*********************************************
            objGrid.blnSelectionChanged = True


            '*********************************************
            'ﾛｸﾞ№取得
            '*********************************************
            strColDataArray = Nothing
            For ii As Integer = 0 To objGrid.SelectedRows.Count - 1
                '(ﾙｰﾌﾟ:選択された行数)

                Dim strLOGNOTemp As String = objGrid.Item(intColDataPosition, objGrid.SelectedRows(ii).Index).Value

                If IsNull(strColDataArray) = True Then
                    '(最初の一回)
                    ReDim strColDataArray(0)
                    strColDataArray(0) = strLOGNOTemp
                Else
                    '(二回目以降)
                    intRet = ArrayFindData(strColDataArray, strLOGNOTemp)
                    If intRet = -1 Then
                        '(ﾛｸﾞ№が見つからなかった場合)
                        ReDim Preserve strColDataArray(UBound(strColDataArray) + 1)
                        strColDataArray(UBound(strColDataArray)) = strLOGNOTemp
                    End If

                End If

            Next


            '*********************************************
            'ｸﾞﾘｯﾄﾞ選択処理
            '*********************************************
            For ii As Integer = 0 To objGrid.RowCount - 1
                '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数)

                Dim strLOGNOTemp As String = TO_STRING(objGrid.Item(intColDataPosition, ii).Value)

                intRet = ArrayFindData(strColDataArray, strLOGNOTemp)
                If intRet = -1 Then
                    '(ﾛｸﾞ№が見つからなかった場合)
                    objGrid.Rows(ii).Selected = False
                Else
                    '(見つかった場合)
                    objGrid.Rows(ii).Selected = True
                End If

            Next


        Catch ex As Exception
            Call ComError_frm(ex)
            Throw ex
        Finally
            objGrid.blnSelectionChanged = False
        End Try
    End Sub
#End Region


    'ｸﾞﾘｯﾄﾞDB定義関係
#Region "　ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ処理                                             "
    ''' ******************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ処理
    ''' </summary>
    ''' <param name="objGrid">FlexGridｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************
    Public Sub FlexGridInitialize(ByRef objGrid As GamenCommon.cmpMDataGrid)


        '=========================================
        'ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ値設定
        '=========================================
        ''objGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single         'ﾍｯﾀﾞ境界線
        objGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing        '列ﾍｯﾀﾞｻｲｽﾞ変更     許可設定
        objGrid.ColumnHeadersHeight = GRID_HEIGHT_TITLE_DBL                             'ﾍｯﾀﾞｰ2行表示のｾﾙの高さ
        objGrid.ReadOnly = True                                                         'ｾﾙの編集           許可設定
        objGrid.RowHeadersVisible = False                                               '行ﾍｯﾀﾞ             表示設定
        objGrid.AllowUserToResizeRows = False                                           '行のｻｲｽﾞ変更       許可設定
        objGrid.MultiSelect = False                                                     '複数ｾﾙ同時選択     許可設定
        objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect                 '選択ﾓｰﾄﾞ
        objGrid.AllowUserToAddRows = False                                              '行追加             許可設定
        objGrid.AllowUserToDeleteRows = False                                           '行削除             許可設定
        objGrid.AllowUserToOrderColumns = True                                          '列移動             許可設定
        'objGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)             '列の幅自動調整
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/09/25  ｸﾞﾘｯﾄﾞﾃﾞｻﾞｲﾝ変更
        'objGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 128, 255) '列ﾍｯﾀﾞ色調整
        'objGrid.Font = New Font("ＭＳ ゴシック", 11.25, FontStyle.Bold)                 'ﾌｫﾝﾄ設定
        'objGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Yellow                  'ﾌｫﾝﾄ設定

        objGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 224)                   '列ﾍｯﾀﾞ色調整
        objGrid.ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳ ゴシック", 12, FontStyle.Bold)
        objGrid.Font = New Font("ＭＳ ゴシック", 11.25, FontStyle.Bold)                                 'ﾌｫﾝﾄ設定
        objGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 241, 15)                  'ﾌｫﾝﾄ設定
        '↑↑↑↑↑↑************************************************************************************************************
        objGrid.ForeColor = Color.Black                                                 'ﾌｫﾝﾄｶﾗｰ

        For Each objColum As DataGridViewColumn In objGrid.Columns
            If Not (objGrid.SortedColumn Is Nothing) Then
                If objGrid.SortedColumn.Equals(objColum) = True Then
                    objGrid.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None 'ｿｰﾄ初期化
                End If
            End If

            objColum.SortMode = DataGridViewColumnSortMode.Automatic                    '列の並替禁止

        Next

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映                                        "
    ''' ****************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
    ''' </summary>
    ''' <param name="objForm">表示するﾌｫｰﾑ</param>
    ''' <param name="objGrid">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Sub TDSP_GRIDSetup(ByVal objForm As Form _
                            , ByVal objGrid As GamenCommon.cmpMDataGrid _
                            )
        Dim intRet As RetCode
        objGrid.blnDBUpdate = False


        '************************************************
        'ﾍｯﾀﾞｰ部配置変更
        '************************************************
        Call GridDispIni(objGrid)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀ
        '************************************************
        Dim objTDSP_GRID As New TBL_TDSP_GRID(gobjOwner, gobjDb, Nothing)
        objTDSP_GRID.FDISP_ID = objForm.Name         '画面ID
        objTDSP_GRID.FCTRL_ID = objGrid.Name         'ｺﾝﾄﾛｰﾙID
        intRet = objTDSP_GRID.GET_TDSP_GRID_ANY()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For ii As Integer = LBound(objTDSP_GRID.ARYME) To UBound(objTDSP_GRID.ARYME)
                '(見つかったﾚｺｰﾄﾞ件数)


                '************************************************
                'ｸﾞﾘｯﾄﾞ表示の設定
                '************************************************
                Dim intCol As Integer = TO_INTEGER(objTDSP_GRID.ARYME(ii).FCOL_INDEX)           '列位置
                Dim intTemp As Nullable(Of Integer)
                Dim strTemp As String

                'ﾍｯﾀﾞｰﾃｷｽﾄ
                strTemp = GetFCONST_VALUE(objTDSP_GRID.ARYME(ii).FGRID_H_TEXT)
                If IsNotNull(strTemp) Then objGrid.Columns(intCol).HeaderText = strTemp

                'ﾍｯﾀﾞｰ配置
                intTemp = TO_INTEGER_NULLABLE(GetFCONST_VALUE(objTDSP_GRID.ARYME(ii).FGRID_H_ALIGNMENT))
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).HeaderCell.Style.Alignment = intTemp

                'ﾃﾞｰﾀ部配置
                intTemp = TO_INTEGER_NULLABLE(GetFCONST_VALUE(objTDSP_GRID.ARYME(ii).FGRID_D_ALIGNMENT))
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).DefaultCellStyle.Alignment = intTemp

                'ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ
                strTemp = GetFCONST_VALUE(objTDSP_GRID.ARYME(ii).FGRID_D_FORMAT)
                If IsNotNull(strTemp) Then objGrid.Columns(intCol).DefaultCellStyle.Format = strTemp

                '列幅調整
                intTemp = TO_INTEGER(GetFCONST_VALUE(objTDSP_GRID.ARYME(ii).FGRID_D_WIDTH))
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).Width = intTemp

                '列非表示設定
                intTemp = TO_INTEGER(objTDSP_GRID.ARYME(ii).FGRID_COL_DISP_FLAG)
                If IsNotNull(intTemp) Then
                    If intTemp = FGRID_COL_DISP_FLAG_SON Then
                        objGrid.Columns(intCol).Visible = True
                    Else
                        objGrid.Columns(intCol).Visible = False
                    End If
                End If

                'ｸﾞﾘｯﾄﾞ列表示順序
                intTemp = TO_INTEGER_NULLABLE(objTDSP_GRID.ARYME(ii).FGRID_DISPLAYINDEX)
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).DisplayIndex = intTemp


            Next
        End If


        '************************************************
        'ｸﾞﾘｯﾄﾞ列ﾏｽﾀ
        '************************************************
        Dim objTDSP_GCOL As New TBL_TDSP_GCOL(gobjOwner, gobjDb, Nothing)
        objTDSP_GCOL.FUSER_ID = gcstrFUSER_ID           'ﾕｰｻﾞｰID
        objTDSP_GCOL.FDISP_ID = objForm.Name         '画面ID
        objTDSP_GCOL.FCTRL_ID = objGrid.Name         'ｺﾝﾄﾛｰﾙID
        intRet = objTDSP_GCOL.GET_TDSP_GCOL_ANY()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For ii As Integer = LBound(objTDSP_GCOL.ARYME) To UBound(objTDSP_GCOL.ARYME)
                '(見つかったﾚｺｰﾄﾞ件数)


                '************************************************
                'ｸﾞﾘｯﾄﾞ表示の設定
                '************************************************
                Dim intCol As Integer = TO_INTEGER(objTDSP_GCOL.ARYME(ii).FCOL_INDEX)           '列位置
                Dim intTemp As Nullable(Of Integer)

                '列幅調整
                intTemp = TO_INTEGER(GetFCONST_VALUE(objTDSP_GCOL.ARYME(ii).FGRID_D_WIDTH))
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).Width = intTemp

                'ｸﾞﾘｯﾄﾞ列表示順序
                intTemp = TO_INTEGER_NULLABLE(objTDSP_GCOL.ARYME(ii).FGRID_DISPLAYINDEX)
                If IsNotNull(intTemp) Then objGrid.Columns(intCol).DisplayIndex = intTemp


            Next
        End If


        '************************************************
        '列幅自動調節
        '************************************************
        objGrid.Columns(objGrid.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None


        ''************************************************
        ''ｸﾞﾘｯﾄﾞﾃﾞﾌｫﾙﾄ処理
        ''************************************************
        'Call gobjComFuncGMN.FlexGridInitialize(objGrid)


        objGrid.blnDBUpdate = True
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞﾏｽﾀSQL文作成処理(OrderBy句)                            "
    ''' ******************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾏｽﾀSQL文作成処理(OrderBy句)
    ''' </summary>
    ''' <param name="objForm">表示するﾌｫｰﾑ</param>
    ''' <param name="objGrid">表示するｸﾞﾘｯﾄﾞ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' ******************************************************************************
    Public Function GetSQL_TDSP_GRID_OrderBy(ByVal objForm As Form _
                                           , ByVal objGrid As GamenCommon.cmpMDataGrid _
                                           ) _
                                           As String
        Dim intRet As RetCode
        Dim strOrderBy As String = ""       '作成されるOrderBy句
        Dim strReturn As String = ""        '戻値


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀ
        '************************************************
        'ﾃｰﾌﾞﾙｸﾗｽOrderBy句作成
        Dim strORDER_BY As String = ""
        strORDER_BY = ""
        strORDER_BY &= vbCrLf & "  FGRID_ORDER_BY      ASC "
        strORDER_BY &= vbCrLf & " ,FGRID_ORDER_ASCDESC ASC "
        'ﾃｰﾌﾞﾙｸﾗｽ取得
        Dim objTDSP_GRID As New TBL_TDSP_GRID(gobjOwner, gobjDb, Nothing)
        objTDSP_GRID.FDISP_ID = objForm.Name         '画面ID
        objTDSP_GRID.FCTRL_ID = objGrid.Name         'ｺﾝﾄﾛｰﾙID
        objTDSP_GRID.ORDER_BY = strORDER_BY          'OrderBy句
        intRet = objTDSP_GRID.GET_TDSP_GRID_ANY()
        If intRet = RetCode.OK Then
            '(見つかった場合)
            For ii As Integer = LBound(objTDSP_GRID.ARYME) To UBound(objTDSP_GRID.ARYME)
                '(見つかったﾚｺｰﾄﾞ件数)


                '************************************************
                '色々ﾁｪｯｸ
                '************************************************
                If IsNull(objTDSP_GRID.ARYME(ii).FGRID_ORDER_BY) Then Exit For


                '************************************************
                'OrderBy句作成
                '************************************************
                Dim strOrderIndex As String = TO_STRING(TO_INTEGER(objTDSP_GRID.ARYME(ii).FCOL_INDEX) + 1)
                If ii = LBound(objTDSP_GRID.ARYME) Then
                    '(最初の場合)
                    strOrderBy &= " ORDER BY "
                    strOrderBy &= vbCrLf & "   " & strOrderIndex & Space(1) & objTDSP_GRID.ARYME(ii).FGRID_ORDER_ASCDESC
                Else
                    '(最初じゃない場合)
                    strOrderBy &= vbCrLf & " , " & strOrderIndex & Space(1) & objTDSP_GRID.ARYME(ii).FGRID_ORDER_ASCDESC
                End If


            Next
        End If
        strReturn = strOrderBy


        Return strReturn
    End Function
#End Region
#Region "  定数値取得                                                   "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 定数値取得
    ''' </summary>
    ''' <param name="strFCONST_ID">定数ID</param>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetFCONST_VALUE(ByVal strFCONST_ID As String) As String
        Dim intRet As RetCode
        Dim strReturn As String = Nothing


        '************************************************
        '色々ﾁｪｯｸ
        '************************************************
        If IsNull(strFCONST_ID) Then Return strReturn


        '************************************************
        '画面定数ﾏｽﾀ
        '************************************************
        Dim objTDSP_CONST As New TBL_TDSP_CONST(gobjOwner, gobjDb, Nothing)
        objTDSP_CONST.FCONST_ID = strFCONST_ID                '定数ID
        intRet = objTDSP_CONST.GET_TDSP_CONST(False)
        If intRet = RetCode.OK Then
            '(見つかった場合)
            strReturn = objTDSP_CONST.FCONST_VALUE
        End If


        '************************************************
        '改行処理
        '************************************************
        If IsNotNull(strReturn) Then
            strReturn = strReturn.Replace(REPLACE_STRING_01, vbCrLf)
        Else
            strReturn = strFCONST_ID.Replace(REPLACE_STRING_01, vbCrLf)
        End If


        Return strReturn
    End Function
#End Region

    'ｸﾞﾘｯﾄﾞSQL文関係
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Select句)(ﾏｽﾀﾃｰﾌﾞﾙ)           "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Select句)(ﾏｽﾀﾃｰﾌﾞﾙ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strMASTER_KEY_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strMASTER_DISP_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strORIGIN_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORIGIN_KEY_FIELD_NAM">実際に結合するﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableSelect02(ByVal strAlias As String _
                                          , ByVal strMASTER_TABLE_NAME As String _
                                          , ByVal strMASTER_KEY_FIELD_NAME As String _
                                          , ByVal strMASTER_DISP_FIELD_NAME As String _
                                          , ByVal strORIGIN_TABLE_NAME As String _
                                          , ByVal strORIGIN_KEY_FIELD_NAM As String _
                                          ) _
                                          As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & "." & strMASTER_DISP_FIELD_NAME & " "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(From句)(画面表示ﾏｽﾀ)          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(From句)(画面表示ﾏｽﾀ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strTDSP_DISP_TABLE_NAME">画面表示ﾏｽﾀで定義されているﾃｰﾌﾞﾙ名</param>
    ''' <param name="strTDSP_DISP_FIELD_NAME">画面表示ﾏｽﾀで定義されているﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableFrom01(ByVal strAlias As String _
                                        , ByVal strTDSP_DISP_TABLE_NAME As String _
                                        , ByVal strTDSP_DISP_FIELD_NAME As String _
                                        ) _
                                        As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= "(SELECT * FROM TDSP_DISP WHERE FTABLE_NAME = '" & strTDSP_DISP_TABLE_NAME & "' AND FFIELD_NAME = '" & strTDSP_DISP_FIELD_NAME & "') " & strAlias & " "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(From句)(ﾏｽﾀﾃｰﾌﾞﾙ)             "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(From句)(ﾏｽﾀﾃｰﾌﾞﾙ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strMASTER_KEY_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strMASTER_DISP_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strORIGIN_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORIGIN_KEY_FIELD_NAM">実際に結合するﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableFrom02(ByVal strAlias As String _
                                        , ByVal strMASTER_TABLE_NAME As String _
                                        , ByVal strMASTER_KEY_FIELD_NAME As String _
                                        , ByVal strMASTER_DISP_FIELD_NAME As String _
                                        , ByVal strORIGIN_TABLE_NAME As String _
                                        , ByVal strORIGIN_KEY_FIELD_NAM As String _
                                        ) _
                                        As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= "(SELECT " & strMASTER_KEY_FIELD_NAME & ", " & strMASTER_DISP_FIELD_NAME & " FROM " & strMASTER_TABLE_NAME & ") " & strAlias & " "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)       "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strTDSP_DISP_TABLE_NAME">画面表示ﾏｽﾀで定義されているﾃｰﾌﾞﾙ名</param>
    ''' <param name="strTDSP_DISP_FIELD_NAME">画面表示ﾏｽﾀで定義されているﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strOrigin_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strOrigin_FIELD_NAME">実際に結合するﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableWhere01(ByVal strAlias As String _
                                         , ByVal strTDSP_DISP_TABLE_NAME As String _
                                         , ByVal strTDSP_DISP_FIELD_NAME As String _
                                         , Optional ByVal strOrigin_TABLE_NAME As String = "" _
                                         , Optional ByVal strOrigin_FIELD_NAME As String = "" _
                                         ) _
                                         As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        '値ｾｯﾄ
        '*******************************************
        If IsNull(strOrigin_TABLE_NAME) Then strOrigin_TABLE_NAME = strTDSP_DISP_TABLE_NAME
        If IsNull(strOrigin_FIELD_NAME) Then strOrigin_FIELD_NAME = strTDSP_DISP_FIELD_NAME


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & ".FDISP_VALUE(+) = " & strOrigin_TABLE_NAME & "." & strOrigin_FIELD_NAME & " "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/08/08  ｷｬｽﾄがあやしいので、一応ｷｬｽﾄを行う
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)_TO_CHAR   "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strTDSP_DISP_TABLE_NAME">画面表示ﾏｽﾀで定義されているﾃｰﾌﾞﾙ名</param>
    ''' <param name="strTDSP_DISP_FIELD_NAME">画面表示ﾏｽﾀで定義されているﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strOrigin_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strOrigin_FIELD_NAME">実際に結合するﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableWhere01_TO_CHAR(ByVal strAlias As String _
                                         , ByVal strTDSP_DISP_TABLE_NAME As String _
                                         , ByVal strTDSP_DISP_FIELD_NAME As String _
                                         , Optional ByVal strOrigin_TABLE_NAME As String = "" _
                                         , Optional ByVal strOrigin_FIELD_NAME As String = "" _
                                         ) _
                                         As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        '値ｾｯﾄ
        '*******************************************
        If IsNull(strOrigin_TABLE_NAME) Then strOrigin_TABLE_NAME = strTDSP_DISP_TABLE_NAME
        If IsNull(strOrigin_FIELD_NAME) Then strOrigin_FIELD_NAME = strTDSP_DISP_FIELD_NAME


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & ".FDISP_VALUE(+) = TO_CHAR(" & strOrigin_TABLE_NAME & "." & strOrigin_FIELD_NAME & ") "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)_TO_NUMBER "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(画面表示ﾏｽﾀ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strTDSP_DISP_TABLE_NAME">画面表示ﾏｽﾀで定義されているﾃｰﾌﾞﾙ名</param>
    ''' <param name="strTDSP_DISP_FIELD_NAME">画面表示ﾏｽﾀで定義されているﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strOrigin_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strOrigin_FIELD_NAME">実際に結合するﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableWhere01_TO_NUMBER(ByVal strAlias As String _
                                         , ByVal strTDSP_DISP_TABLE_NAME As String _
                                         , ByVal strTDSP_DISP_FIELD_NAME As String _
                                         , Optional ByVal strOrigin_TABLE_NAME As String = "" _
                                         , Optional ByVal strOrigin_FIELD_NAME As String = "" _
                                         ) _
                                         As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        '値ｾｯﾄ
        '*******************************************
        If IsNull(strOrigin_TABLE_NAME) Then strOrigin_TABLE_NAME = strTDSP_DISP_TABLE_NAME
        If IsNull(strOrigin_FIELD_NAME) Then strOrigin_FIELD_NAME = strTDSP_DISP_FIELD_NAME


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & ".FDISP_VALUE(+) = TO_NUMBER(" & strOrigin_TABLE_NAME & "." & strOrigin_FIELD_NAME & ") "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(ﾏｽﾀﾃｰﾌﾞﾙ)          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(ﾏｽﾀﾃｰﾌﾞﾙ)
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strMASTER_KEY_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strMASTER_DISP_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strORIGIN_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORIGIN_KEY_FIELD_NAM">実際に結合するﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableWhere02(ByVal strAlias As String _
                                         , ByVal strMASTER_TABLE_NAME As String _
                                         , ByVal strMASTER_KEY_FIELD_NAME As String _
                                         , ByVal strMASTER_DISP_FIELD_NAME As String _
                                         , ByVal strORIGIN_TABLE_NAME As String _
                                         , ByVal strORIGIN_KEY_FIELD_NAM As String _
                                         ) _
                                         As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & "." & strMASTER_KEY_FIELD_NAME & "(+) = " & strORIGIN_TABLE_NAME & "." & strORIGIN_KEY_FIELD_NAM & " "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region
#Region "  画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(ﾏｽﾀﾃｰﾌﾞﾙ)_TO_CHAR          "
    ''' ****************************************************************************************
    ''' <summary>
    ''' 画面表示ﾏｽﾀ結合用SQL文作成処理(Where結合)(ﾏｽﾀﾃｰﾌﾞﾙ)_TO_CHAR
    ''' </summary>
    ''' <param name="strAlias">ﾃｰﾌﾞﾙのｴｲﾘｱｽ</param>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strMASTER_KEY_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strMASTER_DISP_FIELD_NAME">ﾏｽﾀﾃｰﾌﾞﾙ.表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strORIGIN_TABLE_NAME">実際に結合するﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORIGIN_KEY_FIELD_NAM">実際に結合するﾃｰﾌﾞﾙ.ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <returns>SQL文</returns>
    ''' <remarks></remarks>
    ''' ****************************************************************************************
    Public Function GetSQLHashTableWhere02_TO_CHAR(ByVal strAlias As String _
                                         , ByVal strMASTER_TABLE_NAME As String _
                                         , ByVal strMASTER_KEY_FIELD_NAME As String _
                                         , ByVal strMASTER_DISP_FIELD_NAME As String _
                                         , ByVal strORIGIN_TABLE_NAME As String _
                                         , ByVal strORIGIN_KEY_FIELD_NAM As String _
                                         ) _
                                         As String
        Dim strReturn As String = ""
        Dim strSQL As String = ""


        '*******************************************
        'SQL文作成
        '*******************************************
        strSQL &= strAlias & "." & strMASTER_KEY_FIELD_NAME & "(+) = TO_CHAR(" & strORIGIN_TABLE_NAME & "." & strORIGIN_KEY_FIELD_NAM & ") "


        strReturn = strSQL
        Return strReturn
    End Function
#End Region


    '↑↑↑FlexGrid→DataGridView移行


    '↓↓↓Inputman→Combobox移行
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （標準）        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ
    ''' </summary>
    ''' <param name="strDispID">【DSP_CTRL】で定義されている画面ID</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboSetup(ByVal strDispID As String _
                      , ByRef cboControl As Windows.Forms.ComboBox _
                      , Optional ByVal blnAllFlag As Boolean = True _
                      , Optional ByVal objDefault As Object = Nothing _
                      , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                        )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【DSP_CTRL】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP FGAMEN_DISP "          '画面表示ﾏｽﾀ.   表示用名称
        strSQL &= vbCrLf & "  , TDSP_DISP.FDISP_VALUE FDISP_VALUE "          '画面表示ﾏｽﾀ.   設定値
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL LEFT OUTER JOIN "       '画面表示ﾏｽﾀ     (外部結合
        strSQL &= vbCrLf & "    TDSP_DISP ON "                    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ   (外部結合
        strSQL &= vbCrLf & "           TDSP_CTRL.FTABLE_NAME = TDSP_DISP.FTABLE_NAME "     '外部結合   ﾃｰﾌﾞﾙ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FFIELD_NAME = TDSP_DISP.FFIELD_NAME "     '外部結合   ﾌｨｰﾙﾄﾞ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FCTRL_VALUE = TDSP_DISP.FDISP_VALUE "     '外部結合   設定値
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        TDSP_CTRL.FDISP_ID = '" & TO_STRING(strDispID) & "'"                    '画面ID
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID = '" & TO_STRING(cboControl.Name) & "'"            'ｺﾝﾄﾛｰﾙ名
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_ORDER "    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ. 順番
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "DSP_CTRL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FGAMEN_DISP"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FDISP_VALUE"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)

        End If

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾏｽﾀｰﾃｰﾌﾞﾙ）   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾏｽﾀｰﾃｰﾌﾞﾙのｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="strMASTER_TABLE_NAME">ﾏｽﾀﾃｰﾌﾞﾙ名</param>
    ''' <param name="strKEY_FIELD_NAME">ｷｰﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strDISP_FIELD_NAME">表示ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="strORDER_FIELD_NAME">並び順ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub cboMsterSetup(ByVal strMASTER_TABLE_NAME As String _
                           , ByVal strKEY_FIELD_NAME As String _
                           , ByVal strDISP_FIELD_NAME As String _
                           , ByVal strORDER_FIELD_NAME As String _
                           , ByRef cboControl As Windows.Forms.ComboBox _
                           , Optional ByVal blnAllFlag As Boolean = True _
                           , Optional ByVal objDefault As Object = Nothing _
                           , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                           )

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【DSP_CTRL】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    " & strDISP_FIELD_NAME & " "
        strSQL &= vbCrLf & "   ," & strKEY_FIELD_NAME & " "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strMASTER_TABLE_NAME & " "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    " & strORDER_FIELD_NAME & " "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_USER"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow(strDISP_FIELD_NAME))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow(strKEY_FIELD_NAME))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If

    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ）      "
    '' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ）
    ''' </summary>
    ''' <param name="cboControl">作成するﾎﾞｯｸｽ</param>
    ''' <param name="intMax">Max値</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値、品名記号をｾｯﾄする                 （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <param name="intMin">Min値</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub locaSetup(ByRef cboControl As Windows.Forms.ComboBox _
                       , ByVal intMax As Integer _
                       , Optional ByVal blnAllFlag As Boolean = True _
                       , Optional ByVal objDefault As Object = Nothing _
                       , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                       , Optional ByVal intMin As Integer = 1 _
                       )

        Dim objComboTable As New DataTable()
        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        '初期設定
        If intMax = 0 Then intMax = 1

        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '*******************************************************
        For ii As Integer = intMin To intMax

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem1 As String
            SubItem1 = String.Format("{0:00}", ii)
            Dim subItem2 As String
            subItem2 = ii

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem1
            row("ID") = subItem2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

            If IsNull(objDefault) = False Then
                If TO_STRING(objDefault) = subItem2 Then
                    strSearch = subItem2
                End If
            End If

        Next
        For ii As Integer = 0 To cboControl.Items.Count - 1
            cboControl.SelectedIndex = ii
            If cboControl.SelectedIndex = cboControl.Items.Count - 1 Then cboControl.SelectedIndex = 0
        Next


        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)

            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)

            Call cboSelectValue(cboControl, strSearch)

        End If

    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ）3桁Ver"
    '' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ）3桁Ver
    ''' </summary>
    ''' <param name="cboControl">作成するﾎﾞｯｸｽ</param>
    ''' <param name="intMax">Max値</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値、品名記号をｾｯﾄする                 （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <param name="intMin">Min値</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub locaSetup_3keta(ByRef cboControl As Windows.Forms.ComboBox _
                       , ByVal intMax As Integer _
                       , Optional ByVal blnAllFlag As Boolean = True _
                       , Optional ByVal objDefault As Object = Nothing _
                       , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                       , Optional ByVal intMin As Integer = 1 _
                       )

        Dim objComboTable As New DataTable()
        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        '初期設定
        If intMax = 0 Then intMax = 1

        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '*******************************************************
        For ii As Integer = intMin To intMax

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem1 As String
            SubItem1 = String.Format("{0:000}", ii)
            Dim subItem2 As String
            subItem2 = ii

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem1
            row("ID") = subItem2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

            If IsNull(objDefault) = False Then
                If TO_STRING(objDefault) = subItem2 Then
                    strSearch = subItem2
                End If
            End If

        Next
        For ii As Integer = 0 To cboControl.Items.Count - 1
            cboControl.SelectedIndex = ii
            If cboControl.SelectedIndex = cboControl.Items.Count - 1 Then cboControl.SelectedIndex = 0
        Next


        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)

            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)

            Call cboSelectValue(cboControl, strSearch)

        End If

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （理由）        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （理由）
    ''' </summary>
    ''' <param name="strDispID">現在のﾌｫｰﾑ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ </param>
    ''' <param name="strFREASON_KUBUN">理由区分</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboFREASON_CDSetup(ByVal strDispID As String _
                                , ByRef cboControl As Windows.Forms.ComboBox _
                                , ByRef strFREASON_KUBUN As String _
                                , Optional ByVal blnAllFlag As Boolean = True _
                                , Optional ByVal objDefault As Object = Nothing _
                                , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                  )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【TMST_ITEM】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FREASON_CD "                                '理由ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , FREASON "                                   '理由
        strSQL &= vbCrLf & " FROM TMST_REASON "                             '理由ﾏｽﾀ
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TMST_REASON.FREASON_KUBUN = '" & strFREASON_KUBUN & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FREASON_CD "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_REASON"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FREASON"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FREASON_CD"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If


    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ     （指定ﾃｰﾌﾞﾙの製品名ｺﾝﾎﾞ）   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 指定ﾃｰﾌﾞﾙから製品名のｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="strTABLE_NAME">指定ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORDER_FIELD_NAME">並び順ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks>XProductCodeFinalのｺﾝﾎﾞ</remarks>
    '''*******************************************************************************************************************
    Public Sub cboProductCodeFinalSetup(ByVal strTABLE_NAME As String _
                                      , ByVal strORDER_FIELD_NAME As String _
                                      , ByRef cboControl As Windows.Forms.ComboBox _
                                      , Optional ByVal blnAllFlag As Boolean = True _
                                      , Optional ByVal objDefault As Object = Nothing _
                                      , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                      )


        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & ".XProductCodeFinal "
        strSQL &= vbCrLf & "   , TMST_ITEM.XArticleShortName "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTABLE_NAME & " "
        strSQL &= vbCrLf & "    , TMST_ITEM "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND " & strTABLE_NAME & ".XProductCodeFinal = TMST_ITEM.FHINMEI_CD "        '結合条件
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & ".XProductCodeFinal "
        strSQL &= vbCrLf & "   , TMST_ITEM.XArticleShortName "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    " & strORDER_FIELD_NAME & " "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_ITEM"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XArticleShortName"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("XProductCodeFinal"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ     （指定ﾃｰﾌﾞﾙのSﾛｯﾄ№ｺﾝﾎﾞ）   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 指定ﾃｰﾌﾞﾙからSﾛｯﾄ№ｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="strTABLE_NAME">指定ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORDER_FIELD_NAME">並び順ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="strWHERE_ProductCodeFinal">検索条件用製品名ｺｰﾄﾞ                        （ﾃﾞﾌｫﾙﾄ = ""）</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks>製品ｺｰﾄﾞでSﾛｯﾄ№を検索</remarks>
    '''*******************************************************************************************************************
    Public Sub cboSLotSetup(ByVal strTABLE_NAME As String _
                          , ByVal strORDER_FIELD_NAME As String _
                          , ByRef cboControl As Windows.Forms.ComboBox _
                          , Optional ByVal strWHERE_ProductCodeFinal As String = "" _
                          , Optional ByVal blnAllFlag As Boolean = True _
                          , Optional ByVal objDefault As Object = Nothing _
                          , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                          )

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     XOrderLotNo "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTABLE_NAME & " "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        If strWHERE_ProductCodeFinal <> "" Then
            strSQL &= vbCrLf & "   AND XProductCodeFinal = '" & strWHERE_ProductCodeFinal & "' "
        End If
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     XOrderLotNo "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    " & strORDER_FIELD_NAME & " "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = strTABLE_NAME
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XOrderLotNo"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("XOrderLotNo"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If


    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ     （指定ﾃｰﾌﾞﾙ搬送先在庫場所ｺﾝﾎﾞ）   "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 指定ﾃｰﾌﾞﾙから搬送先在庫場所ｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="strTABLE_NAME">指定ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORDER_FIELD_NAME">並び順ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="strWHERE_PlaceDetailCodeTo">検索条件用搬送先在庫場所           （ﾃﾞﾌｫﾙﾄ = ""）</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks>指定ﾃｰﾌﾞﾙから搬送先在庫場所ｺﾝﾎﾞﾎﾞｯｸｽを作成</remarks>
    '''*******************************************************************************************************************
    Public Sub cboPlaceDetaiCodeToSetup(ByVal strTABLE_NAME As String _
                                      , ByVal strORDER_FIELD_NAME As String _
                                      , ByRef cboControl As Windows.Forms.ComboBox _
                                      , Optional ByVal strWHERE_PlaceDetailCodeTo As String = "" _
                                      , Optional ByVal blnAllFlag As Boolean = True _
                                      , Optional ByVal objDefault As Object = Nothing _
                                      , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                       )

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & ".XPlaceDetailCodeTo "
        strSQL &= vbCrLf & "   , TDSP_DISP.FGAMEN_DISP "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTABLE_NAME & " "
        strSQL &= vbCrLf & "    , TDSP_DISP "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND " & strTABLE_NAME & ".XPlaceDetailCodeTo = TDSP_DISP.FDISP_VALUE "   '結合条件
        strSQL &= vbCrLf & "   AND TDSP_DISP.FTABLE_NAME =  '" & strTABLE_NAME & "' "
        strSQL &= vbCrLf & "   AND TDSP_DISP.FFIELD_NAME =  'XPlaceDetailCodeTo' "
        If strWHERE_PlaceDetailCodeTo <> "" Then
            strSQL &= vbCrLf & "   AND " & strTABLE_NAME & ".XPlaceDetailCodeTo = '" & strWHERE_PlaceDetailCodeTo & "' "
        End If
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & ".XPlaceDetailCodeTo "
        strSQL &= vbCrLf & "   , TDSP_DISP.FGAMEN_DISP "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    " & strORDER_FIELD_NAME & " "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = strTABLE_NAME
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FGAMEN_DISP"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("XPlaceDetailCodeTo"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№）        "
    '↓↓↓↓↓↓************************************************************************************************************
    'Checked SystemMate:N.Dounoshita 2011/12/20 この関数は不要or不便だった。画面毎に細かな設定が出来ないので、不便。改善が必要と思われる。

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№）
    ''' </summary>
    ''' <param name="strDispID">現在のﾌｫｰﾑ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ </param>
    ''' <param name="strFPLACE_CD">保管場所ｺｰﾄﾞ</param>
    ''' <param name="strFBUF_KIND">ﾊﾞｯﾌｧ種別</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strFTRK_BUF_NO_Del">対象外のﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboFTRK_BUF_NOSetup(ByVal strDispID As String _
                                 , ByRef cboControl As Windows.Forms.ComboBox _
                                 , Optional ByVal strFPLACE_CD As String = "" _
                                 , Optional ByVal strFBUF_KIND As String = "" _
                                 , Optional ByVal blnAllFlag As Boolean = True _
                                 , Optional ByVal objDefault As Object = Nothing _
                                 , Optional ByVal strFTRK_BUF_NO_Del As String = "" _
                                 , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                   )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【TMST_ITEM】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "  , REPLACE(FBUF_NAME, '仮想ST','') AS FBUF_NAME "      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        'strSQL &= vbCrLf & "  , FBUF_NAME "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & " FROM TMST_TRK "                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        If strFPLACE_CD <> "" Then
            strSQL &= vbCrLf & "    AND TMST_TRK.FPLACE_CD = '" & strFPLACE_CD & "' "       '保管場所ｺｰﾄﾞ
        End If
        If strFBUF_KIND <> "" Then
            strSQL &= vbCrLf & "    AND TMST_TRK.FBUF_KIND = '" & strFBUF_KIND & "' "       'ﾊﾞｯﾌｧ種別
        End If
        If strFTRK_BUF_NO_Del <> "" Then
            strSQL &= vbCrLf & "    AND TMST_TRK.FTRK_BUF_NO <> " & strFTRK_BUF_NO_Del      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        End If

        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_TRK"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FBUF_NAME"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FTRK_BUF_NO"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If


    End Sub
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ     （指定ﾃｰﾌﾞﾙのﾛｯﾄ№ｺﾝﾎﾞ）    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 指定ﾃｰﾌﾞﾙからﾛｯﾄ№ｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="strTABLE_NAME">指定ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strORDER_FIELD_NAME">並び順ﾌｨｰﾙﾄﾞ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="strWHERE_HINMEI_CD">検索条件用品名ｺｰﾄﾞ                        （ﾃﾞﾌｫﾙﾄ = ""）</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks>品名ｺｰﾄﾞでﾛｯﾄ№を検索</remarks>
    '''*******************************************************************************************************************
    Public Sub cboLotSetup(ByVal strTABLE_NAME As String _
                         , ByVal strORDER_FIELD_NAME As String _
                         , ByRef cboControl As Windows.Forms.ComboBox _
                         , Optional ByVal strWHERE_HINMEI_CD As String = "" _
                         , Optional ByVal blnAllFlag As Boolean = True _
                         , Optional ByVal objDefault As Object = Nothing _
                         , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                         )

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & "." & "FLOT_NO "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    " & strTABLE_NAME & " "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        If strWHERE_HINMEI_CD <> "" Then
            strSQL &= vbCrLf & "   AND " & strTABLE_NAME & "." & "FHINMEI_CD = '" & strWHERE_HINMEI_CD & "' "
        End If
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     " & strTABLE_NAME & "." & "FLOT_NO "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    " & strORDER_FIELD_NAME & " "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = strTABLE_NAME
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FLOT_NO"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FLOT_NO"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If


    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ     （製造指図ｺﾝﾎﾞ）    "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 製造指図ｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks>品名ｺｰﾄﾞでﾛｯﾄ№を検索</remarks>
    '''*******************************************************************************************************************
    Public Sub cboXOrderSlipNoSetup(ByRef cboControl As Windows.Forms.ComboBox _
                                  , Optional ByVal blnAllFlag As Boolean = True _
                                  , Optional ByVal objDefault As Object = Nothing _
                                  , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                   )

        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     XOrderSlipNo "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_LBRA_RECV "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPROGRESS_REQ DESC "
        strSQL &= vbCrLf & "    ,XProductStartDTM ASC "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_LBRA_RECV"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XOrderSlipNo"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("XOrderSlipNo"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾎｽﾄ在庫照合） "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾏｽﾀｰﾃｰﾌﾞﾙのｺﾝﾎﾞﾎﾞｯｸｽを作成する。
    ''' </summary>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub cboTLOG_CHECK_HOSTSetup(ByRef cboControl As Windows.Forms.ComboBox _
                                     , Optional ByVal blnAllFlag As Boolean = True _
                                     , Optional ByVal objDefault As Object = Nothing _
                                     , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                     )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【DSP_CTRL】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FENTRY_DT "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_CHECK_HOST "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FENTRY_DT DESC "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TLOG_CHECK_HOST"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(Format(objRow("FENTRY_DT"), GAMEN_DATE_FORMAT_02))
                Dim subItem2 As String
                subItem2 = TO_STRING(Format(objRow("FENTRY_DT"), GAMEN_DATE_FORMAT_02))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, objDefault)
        End If

    End Sub
#End Region

#Region "　期間設定                                     "
    ''' ******************************************************************************************************************
    ''' <summary>
    ''' 期間設定
    ''' </summary>
    ''' <param name="dtpFrom">開始日時</param>
    ''' <param name="dtpTo">終了日時</param>
    ''' <remarks></remarks>
    ''' ******************************************************************************************************************
    Public Sub dtpKikanFromToSetup(ByRef dtpFrom As GamenCommon.cmpMDateTimePicker_DT _
                                 , ByRef dtpTo As GamenCommon.cmpMDateTimePicker_DT _
                                 )
        Dim dtmFrom As Date                 'From 日時
        Dim dtmNow As Date = Now            '現在日時

        '*********************************************
        ' 期間初期化
        '*********************************************
        dtmFrom = DateAdd(DateInterval.Minute, _
                          Val("-" & GetSYS_HEN(FHENSU_ID_SGS000000_008)), _
                          dtmNow)



        dtpFrom.cmpMDateTimePicker_D.Value = dtmFrom
        dtpFrom.cmpMDateTimePicker_T.Value = dtmFrom
        dtpTo.cmpMDateTimePicker_D.Value = dtmNow
        dtpTo.cmpMDateTimePicker_T.Value = dtmNow

        dtpTo.userChecked = False

    End Sub
#End Region
#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｾﾚｸﾄ変更                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｾﾚｸﾄ変更
    ''' </summary>
    ''' <param name="cboControl">選択変更するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="objDefault">ｺﾝﾎﾞﾎﾞｯｸｽの選択させる設定値</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboSelectValue(ByRef cboControl As Windows.Forms.ComboBox _
                            , ByVal objDefault As Object _
                            )


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        '###########################################################################################################
        ' 2011/09/13    J.Kato変更      ↓↓↓↓↓     Valueﾃﾞｰﾀで選択するように変更
        cboControl.SelectedValue = objDefault

        ''Dim intIndex As Integer         'ﾃﾞﾌｫﾙﾄ値のｲﾝﾃﾞｯｸｽ

        '' ''intIndex = cboControl.FindString(String.Format("{0:00}", TO_INTEGER(objDefault)))        '検索
        ''intIndex = cboControl.FindString(objDefault)        '検索

        ''If intIndex < 0 Then
        ''    '(ﾃﾞﾌｫﾙﾄ値が、ｺﾝﾎﾞﾎﾞｯｸｽ内に存在しなかった場合)
        ''    cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)
        ''Else
        ''    '(ﾃﾞﾌｫﾙﾄ値が、ｺﾝﾎﾞﾎﾞｯｸｽ内に存在した場合)
        ''    cboControl.SelectedIndex = intIndex
        ''End If
        ' 2011/09/13    J.Kato変更      ↑↑↑↑↑      Valueﾃﾞｰﾀで選択するように変更
        '###########################################################################################################



    End Sub
#End Region
#Region "　棚番初期設定　                                           "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 棚番初期設定
    ''' </summary>
    ''' <param name="strFPLACE_CD">棚番初期化する保管場所ｺｰﾄﾞ</param>
    ''' <param name="cboFRAC_RETU">列ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_REN">連ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_DAN">段ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub InitRetuRenDan(ByVal strFPLACE_CD As String _
                            , ByRef cboFRAC_RETU As Windows.Forms.ComboBox _
                            , ByRef cboFRAC_REN As Windows.Forms.ComboBox _
                            , ByRef cboFRAC_DAN As Windows.Forms.ComboBox _
                            )
        Dim strSQL As String                'SQL文
        Dim intRetuMin As Integer = 0       '最小列数
        Dim intRenMin As Integer = 0        '最小連数
        Dim intDanMin As Integer = 0        '最小段数
        Dim intRetuMax As Integer = 0       '最大列数
        Dim intRenMax As Integer = 0        '最大連数
        Dim intDanMax As Integer = 0        '最大段数
        Dim objFRAC_RETU_Value As Object = Nothing      'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_REN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_DAN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_RETU.SelectedItem) = False Then objFRAC_RETU_Value = cboFRAC_RETU.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_REN.SelectedItem) = False Then objFRAC_REN_Value = cboFRAC_REN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_DAN.SelectedItem) = False Then objFRAC_DAN_Value = cboFRAC_DAN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MIN "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MIN
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MAX "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MAX
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO "  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№で結合
        strSQL &= vbCrLf & "     AND TMST_TRK.FPLACE_CD = '" & strFPLACE_CD & "'"       '保管場所ｺｰﾄﾞ
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            intRetuMin = TO_INTEGER(objRow("FRAC_RETU_MIN"))
            intRenMin = TO_INTEGER(objRow("FRAC_REN_MIN"))
            intDanMin = TO_INTEGER(objRow("FRAC_DAN_MIN"))

            intRetuMax = TO_INTEGER(objRow("FRAC_RETU_MAX"))
            intRenMax = TO_INTEGER(objRow("FRAC_REN_MAX"))
            intDanMax = TO_INTEGER(objRow("FRAC_DAN_MAX"))

        End If


        '**********************************************************
        ' 列連段ｺﾝﾎﾞ設定
        '**********************************************************
        Call locaSetup(cboFRAC_RETU, intRetuMax, False, objFRAC_RETU_Value, , intRetuMin)
        Call locaSetup(cboFRAC_REN, intRenMax, False, objFRAC_REN_Value, , intRenMin)
        Call locaSetup(cboFRAC_DAN, intDanMax, False, objFRAC_DAN_Value, , intDanMin)


    End Sub
#End Region
#Region "　棚番初期設定(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№から取得Ver)                  "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 棚番初期設定
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">棚番初期化するﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="cboFRAC_RETU">列ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_REN">連ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_DAN">段ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub InitRetuRenDan_TrkBufNo(ByVal strFTRK_BUF_NO As String _
                                     , ByRef cboFRAC_RETU As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_REN As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_DAN As Windows.Forms.ComboBox _
                                     )
        Dim strSQL As String                'SQL文
        Dim intRetuMin As Integer = 0       '最小列数
        Dim intRenMin As Integer = 0        '最小連数
        Dim intDanMin As Integer = 0        '最小段数
        Dim intRetuMax As Integer = 0       '最大列数
        Dim intRenMax As Integer = 0        '最大連数
        Dim intDanMax As Integer = 0        '最大段数
        Dim objFRAC_RETU_Value As Object = Nothing      'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_REN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_DAN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_RETU.SelectedItem) = False Then objFRAC_RETU_Value = cboFRAC_RETU.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_REN.SelectedItem) = False Then objFRAC_REN_Value = cboFRAC_REN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_DAN.SelectedItem) = False Then objFRAC_DAN_Value = cboFRAC_DAN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MIN "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MIN
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MAX "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MAX
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO "  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№で結合
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = '" & strFTRK_BUF_NO & "'"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            intRetuMin = TO_INTEGER(objRow("FRAC_RETU_MIN"))
            intRenMin = TO_INTEGER(objRow("FRAC_REN_MIN"))
            intDanMin = TO_INTEGER(objRow("FRAC_DAN_MIN"))

            intRetuMax = TO_INTEGER(objRow("FRAC_RETU_MAX"))
            intRenMax = TO_INTEGER(objRow("FRAC_REN_MAX"))
            intDanMax = TO_INTEGER(objRow("FRAC_DAN_MAX"))

        End If


        '**********************************************************
        ' 列連段ｺﾝﾎﾞ設定
        '**********************************************************
        Call locaSetup(cboFRAC_RETU, intRetuMax, False, objFRAC_RETU_Value, , intRetuMin)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 連は3桁表示
        'Call locaSetup(cboFRAC_REN, intRenMax, False, objFRAC_REN_Value, , intRenMin)
        Call locaSetup_3keta(cboFRAC_REN, intRenMax, False, objFRAC_REN_Value, , intRenMin)
        '↑↑↑↑↑↑************************************************************************************************************
        Call locaSetup(cboFRAC_DAN, intDanMax, False, objFRAC_DAN_Value, , intDanMin)


    End Sub
#End Region
    '↑↑↑Inputman→Combobox移行


    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓FRM/PDA共通 ｵｰﾊﾞｰﾛｰﾄﾞ可能
#Region "  Waitﾌｫｰﾑ         Show、Close処理     "
    Public Overridable Sub WaitFormShow()

    End Sub

    Public Overridable Sub WaitFormClose()

    End Sub
#End Region
#Region "  ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ        表示処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ 表示処理
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtFormType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="udtIconType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾃﾞﾌｫﾙﾄﾎﾟｯﾌﾟｱｯﾌﾟ表示名</param>
    ''' <param name="blnAddLog"></param>
    ''' <returns>ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ戻値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function DisplayPopup(ByVal strMessage As String _
                               , ByVal udtFormType As PopupFormType _
                               , ByVal udtIconType As PopupIconType _
                               , Optional ByVal strSupplement As String = "" _
                               , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                               , Optional ByVal blnAddLog As Boolean = True _
                                 ) As RetPopup

       
    End Function
#End Region
#Region "  ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ(ﾁｪｯｸﾎﾞｯｸｽあり) 表示処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ(ﾁｪｯｸﾎﾞｯｸｽあり) 表示処理
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtFormType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="udtIconType">ｱｲｺﾝﾀｲﾌﾟ</param>
    ''' <param name="ChckBoxState">ﾁｪｯｸﾎﾞｯｸｽ値</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾀｲﾄﾙ</param>
    ''' <param name="blnAddLog">ﾛｸﾞ書込みﾌﾗｸﾞ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function DisplayChckBoxPopup(ByVal strMessage As String _
                                      , ByVal udtFormType As PopupFormType _
                                      , ByVal udtIconType As PopupIconType _
                                      , ByRef ChckBoxState As CheckState _
                                      , Optional ByVal strSupplement As String = "" _
                                      , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                      , Optional ByVal blnAddLog As Boolean = True _
                                        ) _
                                        As RetPopup


    End Function
#End Region
#Region "  理由ｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰﾑ        表示処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 理由ｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰﾑ        表示処理
    ''' </summary>
    ''' <param name="strFREASON_KUBUN">[IN]理由区分</param>
    ''' <param name="strFREASON">[OUT]理由</param>
    ''' <param name="strMessage">[IN]ﾒｯｾｰｼﾞ</param>
    ''' <param name="strSupplement">[IN]補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">[IN]ﾀｲﾄﾙ</param>
    ''' <param name="blnAddLog">[IN]ﾛｸﾞ書込みﾌﾗｸﾞ True:書込み</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Function DisplayFRM_100201(ByVal strFREASON_KUBUN As String _
                                    , ByRef strFREASON As String _
                                    , Optional ByVal strMessage As String = FRM_MSG_FREASON_CD_MSG_01 _
                                    , Optional ByVal strSupplement As String = "" _
                                    , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                    , Optional ByVal blnAddLog As Boolean = True _
                                    ) _
                                    As RetPopup


    End Function
#End Region
#Region "  画面遷移（画面IDで遷移）             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移（画面IDで遷移）
    ''' </summary>
    ''' <param name="strDISP_ID">画面ID</param>
    ''' <param name="objFormNow">ﾓｰﾀﾞﾙに遷移するかどうか（ﾃﾞﾌｫﾙﾄではﾓｰﾀﾞﾚｽ）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub FormMoveSelect(ByVal strDISP_ID As String _
                                           , ByRef objFormNow As Object _
                                           )



    End Sub
#End Region
#Region "　画面離席処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面離席処理
    ''' </summary>
    ''' <param name="objForm"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub AfkProc(ByRef objForm As Form)

       
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ確認処理                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ確認処理
    ''' </summary>
    ''' <param name="strFDISP_ID">画面ID</param>
    ''' <param name="strFCTRL_ID">ｺﾝﾄﾛｰﾙID</param>
    ''' <returns>True:ﾊﾟｽﾜｰﾄﾞ確認成功    False:ﾊﾟｽﾜｰﾄﾞ確認失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overridable Function PassWordCheck(ByVal strFDISP_ID As String _
                                , ByVal strFCTRL_ID As String _
                                ) _
                                As Boolean


    End Function
#End Region
    'ｸﾘｽﾀﾙﾚﾎﾟｰﾄ
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理
    ''' </summary>
    ''' <param name="objCR">ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub CRPrint(ByVal objCR As Object)

       


    End Sub
#End Region
#Region "　ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strText01">ﾃｷｽﾄ1</param>
    ''' <param name="strText02">ﾃｷｽﾄ2</param>
    ''' <param name="strText05">ﾃｷｽﾄ5</param>
    ''' <param name="strText06">ﾃｷｽﾄ6</param>
    ''' <param name="strText07">ﾃｷｽﾄ7</param>
    ''' <param name="strFooter01">ﾌｯﾀｰ1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub CRPrintKaihatu(ByVal grdControl As System.Windows.Forms.DataGridView _
                            , ByVal strTableName As String _
                            , ByVal strText01 As String _
                            , ByVal strText02 As String _
                            , ByVal strText05 As String _
                            , ByVal strText06 As String _
                            , ByVal strText07 As String _
                            , ByVal strFooter01 As String _
                            )

        

    End Sub
#End Region
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更
    ''' </summary>
    ''' <param name="objCR">ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strObjectName">ｸﾘｽﾀﾙﾚﾎﾟｰﾄの貼り付いているｵﾌﾞｼﾞｪｸﾄ名</param>
    ''' <param name="strText">ｸﾘｽﾀﾙﾚﾎﾟｰﾄに表示させるﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overridable Sub ChangeCRText(ByVal objCR As Object _
                          , ByVal strObjectName As String _
                          , ByVal strText As String _
                          )


    End Sub
#End Region
    '↑↑↑FRM/PDA共通 ｵｰﾊﾞｰﾛｰﾄﾞ可能
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有 ｵｰﾊﾞｰﾛｰﾄﾞ可能
#Region "  作業 Mode 切り替え指示応答     受信待ち                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ確認処理
    ''' </summary>
    ''' <param name="strDSPEQ_ID">設備ID</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overridable Function WaitReturnDenbun(ByVal strDSPEQ_ID As String) As RetCode


    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有 ｵｰﾊﾞｰﾛｰﾄﾞ可能
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  ﾗﾍﾞﾙ背景色変更処理 (ﾌﾞﾛｯｸ用)       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更処理(ﾌﾞﾛｯｸ用)
    ''' </summary>
    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strDISP_ID">該当する画面ID</param>
    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Block_AlterLabelColor(ByVal lblControl As Label _
                                   , ByVal strDISP_ID As String _
                                   , ByVal udtLblDspType As LBL_DSPTYPE _
                                    )

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objRow2 As DataRow              '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ(2件目)
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_VALUE "                           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ・ｺﾝﾄﾛｰﾙ値
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FSTS_NAME "                           '画面設備状態表示ﾏｽﾀ.状態名
        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FCOLOR_KUBUN, " & FCOLOR_KUBUN_SWHITE & ") AS FCOLOR_KUBUN "      '画面設備状態表示ﾏｽﾀ.表示色
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL "                                       '画面ｺﾝﾄﾛｰﾙﾏｽﾀ
        strSQL &= vbCrLf & "   ,TSTS_EQ_CTRL "                                    '設備状況
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                     '画面設備状態表示ﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.XEQ_DSP_BLC_KUBUN(+) "  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の ﾌﾞﾛｯｸ設備状態表示区分 を 結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN   = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "   '設備状況 と 画面設備状態表示ﾏｽﾀ の 画面設備表示区分 を 外部結合

        'strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS     = TDSP_EQ_STS.FEQ_STS(+) "             '設備状況 と 画面設備状態表示ﾏｽﾀ の 設備状態 を 外部結合
        strSQL &= vbCrLf & "    AND ( "
        '↓↓↓↓↓↓  2012.10.01 H.Morita  KAGOME
        'strSQL &= vbCrLf & "         SELECT "
        'strSQL &= vbCrLf & "           MAX(TSTS_EQ_CTRL.FEQ_STS) "
        'strSQL &= vbCrLf & "         FROM "
        'strSQL &= vbCrLf & "           TDSP_CTRL "
        'strSQL &= vbCrLf & "          ,TSTS_EQ_CTRL "
        'strSQL &= vbCrLf & "         WHERE 1 = 1 "
        'strSQL &= vbCrLf & "           AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
        'strSQL &= vbCrLf & "           AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
        'strSQL &= vbCrLf & "           AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
        'strSQL &= vbCrLf & "           AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.XEQ_DSP_BLC_KUBUN(+) "  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の ﾌﾞﾛｯｸ設備状態表示区分 を 結合

        strSQL &= vbCrLf & "         SELECT "
        strSQL &= vbCrLf & "           A.FEQ_STS "
        strSQL &= vbCrLf & "         FROM "
        strSQL &= vbCrLf & "           ( "
        strSQL &= vbCrLf & "            SELECT "
        strSQL &= vbCrLf & "               TSTS_EQ_CTRL.FEQ_STS "
        strSQL &= vbCrLf & "             , CASE TSTS_EQ_CTRL.FEQ_STS "
        strSQL &= vbCrLf & "                WHEN '0'  THEN '2' "                                            '0:手動
        strSQL &= vbCrLf & "                WHEN '1'  THEN '3' "                                            '1:自動
        strSQL &= vbCrLf & "                WHEN '2'  THEN '1' "                                            '2:異常
        strSQL &= vbCrLf & "                ELSE           TSTS_EQ_CTRL.FEQ_STS "
        strSQL &= vbCrLf & "               END AS FEQ_STS_SORT "
        strSQL &= vbCrLf & "            FROM "
        strSQL &= vbCrLf & "               TDSP_CTRL "
        strSQL &= vbCrLf & "             , TSTS_EQ_CTRL "
        strSQL &= vbCrLf & "            WHERE 1 = 1 "
        strSQL &= vbCrLf & "             AND TDSP_CTRL.FDISP_ID       = '" & strDISP_ID & "'"                '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.画面ID 指定
        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_ID       = '" & lblControl.Name & "'"           '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.ｺﾝﾄﾛｰﾙ名 指定
        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_ORDER    = 1 "                                  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ.順番 1固定
        strSQL &= vbCrLf & "             AND TDSP_CTRL.FCTRL_VALUE    = TSTS_EQ_CTRL.XEQ_DSP_BLC_KUBUN(+) "  '画面ｺﾝﾄﾛｰﾙﾏｽﾀ と 設備状況 の ﾌﾞﾛｯｸ設備状態表示区分 を 結合
        strSQL &= vbCrLf & "            ORDER BY "
        strSQL &= vbCrLf & "               FEQ_STS_SORT "
        strSQL &= vbCrLf & "           ) A "
        strSQL &= vbCrLf & "         WHERE "
        strSQL &= vbCrLf & "           ROWNUM = 1 "
        '↑↑↑↑↑↑  2012.10.01 H.Morita  KAGOME

        strSQL &= vbCrLf & "        ) = TDSP_EQ_STS.FEQ_STS "                                       '設備状況 と 画面設備状態表示ﾏｽﾀ の 設備状態 を 結合

        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '設備状況 と 画面設備状態表示ﾏｽﾀ の 切離有無 を 外部結合


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            Select Case udtLblDspType
                Case LBL_DSPTYPE.EQNAME
                    '画面表示用名称変更(設備名)
                    'lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
                    lblControl.Text = "ﾌﾞﾛｯｸ №" & TO_STRING(objRow("FCTRL_VALUE"))
                Case LBL_DSPTYPE.STSNAME
                    '画面表示用名称変更(ｽﾃｰﾀｽ名)
                    lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
                Case LBL_DSPTYPE.NO_DSP
                    'ﾗﾍﾞﾙ表示変更無し

            End Select


            If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
                '(1件の時)
                Call AlterBackColor(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))
            Else
                '(複数件の時)
                objRow2 = objDataSet.Tables(strDataSetName).Rows(1)     '2件目
                If (TO_STRING(objRow("FSTS_NAME")) = "切離中") And _
                   (TO_STRING(objRow2("FSTS_NAME")) = "異常") Then
                    '(切離中かつ異常の時)
                    '背景色変更
                    Call AlterBackColor(lblControl, TO_NUMBER(objRow2("FCOLOR_KUBUN")))
                Else
                    '(以外の時)
                    Call AlterBackColor(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))
                End If
            End If

        Else
            lblControl.BackColor = gcLabelColor_Black

        End If


    End Sub
#End Region
#Region "　棚番初期設定(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№から取得、枝も含む)                  "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 棚番初期設定(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№から取得、枝も含む)
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">棚番初期化するﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="cboFRAC_RETU">列ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_REN">連ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_DAN">段ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_EDA">枝ｺﾝﾎﾞﾎﾞｯｸｽ(Nothingは無視)</param>
    ''' <param name="blnEvenNumber_REN">連偶数のみﾌﾗｸﾞ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub InitRetuRenDanEda_TrkBufNo(ByVal strFTRK_BUF_NO As String _
                                     , ByRef cboFRAC_RETU As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_REN As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_DAN As Windows.Forms.ComboBox _
                                     , Optional ByRef cboFRAC_EDA As Windows.Forms.ComboBox = Nothing _
                                     , Optional ByVal blnEvenNumber_REN As Boolean = False _
                                     )
        Dim strSQL As String                'SQL文
        Dim intRetuMin As Integer = 0       '最小列数
        Dim intRenMin As Integer = 0        '最小連数
        Dim intDanMin As Integer = 0        '最小段数

        Dim intRetuMax As Integer = 0       '最大列数
        Dim intRenMax As Integer = 0        '最大連数
        Dim intDanMax As Integer = 0        '最大段数

        Dim objFRAC_RETU_Value As Object = Nothing      'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_REN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_DAN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管

        If IsNull(cboFRAC_RETU.SelectedItem) = False Then objFRAC_RETU_Value = cboFRAC_RETU.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_REN.SelectedItem) = False Then objFRAC_REN_Value = cboFRAC_REN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_DAN.SelectedItem) = False Then objFRAC_DAN_Value = cboFRAC_DAN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管

        Dim intEdaMin As Integer = 0        '最小枝数
        Dim intEdaMax As Integer = 0        '最大枝数
        Dim objFRAC_EDA_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If Not cboFRAC_EDA Is Nothing Then
            If IsNull(cboFRAC_EDA.SelectedItem) = False Then objFRAC_EDA_Value = cboFRAC_EDA.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        End If


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MIN "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MIN
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MAX "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MAX

        If Not cboFRAC_EDA Is Nothing Then
            strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_EDA) AS FRAC_EDA_MIN "        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚枝MIN
            strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_EDA) AS FRAC_EDA_MAX "        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MAX
        End If

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO "  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№で結合
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = '" & strFTRK_BUF_NO & "'"   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            intRetuMin = TO_INTEGER(objRow("FRAC_RETU_MIN"))
            intRenMin = TO_INTEGER(objRow("FRAC_REN_MIN"))
            intDanMin = TO_INTEGER(objRow("FRAC_DAN_MIN"))

            intRetuMax = TO_INTEGER(objRow("FRAC_RETU_MAX"))
            intRenMax = TO_INTEGER(objRow("FRAC_REN_MAX"))
            intDanMax = TO_INTEGER(objRow("FRAC_DAN_MAX"))

            If Not cboFRAC_EDA Is Nothing Then
                intEdaMin = TO_INTEGER(objRow("FRAC_EDA_MIN"))
                intEdaMax = TO_INTEGER(objRow("FRAC_EDA_MAX"))
            End If
        End If


        '**********************************************************
        ' 列連段ｺﾝﾎﾞ設定
        '**********************************************************
        Call locaSetup(cboFRAC_RETU, intRetuMax, True, objFRAC_RETU_Value, , intRetuMin)

        If blnEvenNumber_REN = True Then
            Call locaSetup_EvenNumber(cboFRAC_REN, intRenMax, True, objFRAC_REN_Value, , intRenMin)
        Else
            Call locaSetup_3keta(cboFRAC_REN, intRenMax, True, objFRAC_REN_Value, , intRenMin)
        End If
        Call locaSetup(cboFRAC_DAN, intDanMax, True, objFRAC_DAN_Value, , intDanMin)
        If Not cboFRAC_EDA Is Nothing Then
            Call locaSetup(cboFRAC_EDA, intEdaMax, True, objFRAC_EDA_Value, , intEdaMin)
        End If

    End Sub
#End Region
#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ偶数のみ）  "
    '' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （ﾛｹｰｼｮﾝ偶数のみ）
    ''' </summary>
    ''' <param name="cboControl">作成するﾎﾞｯｸｽ</param>
    ''' <param name="intMax">Max値</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値、品名記号をｾｯﾄする                 （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <param name="intMin">Min値</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub locaSetup_EvenNumber(ByRef cboControl As Windows.Forms.ComboBox _
                       , ByVal intMax As Integer _
                       , Optional ByVal blnAllFlag As Boolean = True _
                       , Optional ByVal objDefault As Object = Nothing _
                       , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                       , Optional ByVal intMin As Integer = 1 _
                       )

        Dim objComboTable As New DataTable()
        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        '初期設定
        If intMax = 0 Then intMax = 1

        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then

            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽに追加
        '*******************************************************
        For ii As Integer = intMin To intMax
            If ii Mod 2 = 0 Then

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = String.Format("{0:000}", ii)
                Dim subItem2 As String
                subItem2 = ii

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If
            End If
        Next
        For ii As Integer = 0 To cboControl.Items.Count - 1
            cboControl.SelectedIndex = ii
            If cboControl.SelectedIndex = cboControl.Items.Count - 1 Then cboControl.SelectedIndex = 0
        Next


        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)

            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)

            Call cboSelectValue(cboControl, strSearch)

        End If

    End Sub
#End Region

#Region "  ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （PLC行先）        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ         （PLC行先）
    ''' </summary>
    ''' <param name="strDispID">現在のﾌｫｰﾑ名</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ </param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboPLC_GOTOSetup(ByVal strDispID As String _
                                , ByRef cboControl As Windows.Forms.ComboBox _
                                , Optional ByVal blnAllFlag As Boolean = True _
                                , Optional ByVal objDefault As Object = Nothing _
                                , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                                  )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************
        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【TMST_ITEM】
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRNS_ADDRESS AS FTRNS_ADDRESS "        '搬送指示用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FDISP_ADDRESS AS FDISP_ADDRESS "        '表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & " FROM TPRG_TRK_BUF "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "    , TMST_TRK "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO "
        strSQL &= vbCrLf & "    AND TMST_TRK.FBUF_KIND IN ( " & FBUF_KIND_SFIFO & "," & FBUF_KIND_STRNS & ")"
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRNS_ADDRESS <> '0' "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRNS_ADDRESS IS NOT NULL "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FTRNS_ADDRESS "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FDISP_ADDRESS"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FTRNS_ADDRESS"))

                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                row("NAME") = SubItem1
                row("ID") = subItem2

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

                If IsNull(objDefault) = False Then
                    If TO_STRING(objDefault) = subItem2 Then
                        strSearch = subItem2
                    End If
                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"

        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)
        End If


    End Sub
#End Region

#Region "　ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (出庫ST ｺﾝﾍﾞﾔ用途:設定出庫のみ)  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄ (出庫ST ｺﾝﾍﾞﾔ用途:設定出庫のみ)
    ''' </summary>
    ''' <param name="strDispID">【DSP_CTRL】で定義されている画面ID</param>
    ''' <param name="cboControl">作成するｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="blnAllFlag">先頭に「全指定」を表示するか否かのﾌﾗｸﾞ            （ﾃﾞﾌｫﾙﾄ = TRUE）</param>
    ''' <param name="objDefault">ﾃﾞﾌｫﾙﾄの設定値                                    （ﾃﾞﾌｫﾙﾄ = Nothing）</param>
    ''' <param name="strAllString">blnAllFlag が True の時、先頭に追加する文字列     （ﾃﾞﾌｫﾙﾄ = CBO_ALL_CONTENT_01）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboNYUUKO_ST_Setup(ByVal strDispID As String _
                      , ByRef cboControl As Windows.Forms.ComboBox _
                      , Optional ByVal blnAllFlag As Boolean = True _
                      , Optional ByVal objDefault As Object = Nothing _
                      , Optional ByVal strAllString As String = CBO_ALL_CONTENT_01 _
                        )
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objComboTable As New DataTable()

        Dim strSearch As String = ""
        Dim lstSTNo As New List(Of String)      'STNo ｺﾝﾍﾞﾔ用途:設定出庫のみ

        '*******************************************************
        ' ｺﾝﾍﾞﾔ用途:設定出庫 取得
        '*******************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "        XSTNO "
        strSQL &= vbCrLf & "   ,    XCONVEYOR_YOUTO "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "        XSTS_CONVEYOR "
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "   AND  XCONVEYOR_YOUTO <> " & XCONVEYOR_YOUTO_JINOUT & " "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "        XSTNO "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_CONVEYOR"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("XSTNO"))
                'ﾘｽﾄに追加
                lstSTNo.Add(SubItem1)

            Next
        End If


        '*******************************************************
        '一行目ｾｯﾄ
        '*******************************************************

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))

        cboControl.DataSource = Nothing
        cboControl.Items.Clear()
        If blnAllFlag = True Then
            '(AllﾌﾗｸﾞがTRUEの場合)
            ' ｻﾌﾞｱｲﾃﾑを作成 
            Dim SubItem_ALL As String
            SubItem_ALL = strAllString
            Dim subItem_ALL2 As String
            subItem_ALL2 = CBO_ALL_VALUE

            '  各列に値をｾｯﾄ 
            Dim row As DataRow = objComboTable.NewRow()
            row("NAME") = SubItem_ALL
            row("ID") = subItem_ALL2

            '　DataTableに行を追加
            objComboTable.Rows.Add(row)

        End If


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ設定値    取得
        '   【DSP_CTRL】
        '*******************************************************
        objRow = Nothing

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP FGAMEN_DISP "          '画面表示ﾏｽﾀ.   表示用名称
        strSQL &= vbCrLf & "  , TDSP_DISP.FDISP_VALUE FDISP_VALUE "          '画面表示ﾏｽﾀ.   設定値
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TDSP_CTRL LEFT OUTER JOIN "       '画面表示ﾏｽﾀ     (外部結合
        strSQL &= vbCrLf & "    TDSP_DISP ON "                    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ   (外部結合
        strSQL &= vbCrLf & "           TDSP_CTRL.FTABLE_NAME = TDSP_DISP.FTABLE_NAME "     '外部結合   ﾃｰﾌﾞﾙ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FFIELD_NAME = TDSP_DISP.FFIELD_NAME "     '外部結合   ﾌｨｰﾙﾄﾞ名
        strSQL &= vbCrLf & "       AND TDSP_CTRL.FCTRL_VALUE = TDSP_DISP.FDISP_VALUE "     '外部結合   設定値
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        TDSP_CTRL.FDISP_ID = '" & TO_STRING(strDispID) & "'"                    '画面ID
        strSQL &= vbCrLf & "    AND TDSP_CTRL.FCTRL_ID = '" & TO_STRING(cboControl.Name) & "'"            'ｺﾝﾄﾛｰﾙ名
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    TDSP_CTRL.FCTRL_ORDER "    '画面ｺﾝﾄﾛｰﾙﾏｽﾀ. 順番
        strSQL &= vbCrLf


        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "DSP_CTRL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FGAMEN_DISP"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow("FDISP_VALUE"))

                If lstSTNo.Contains(subItem2) = False Then
                    '  各列に値をｾｯﾄ 
                    Dim row As DataRow = objComboTable.NewRow()
                    row("NAME") = SubItem1
                    row("ID") = subItem2

                    '　DataTableに行を追加
                    objComboTable.Rows.Add(row)

                    If IsNull(objDefault) = False Then
                        If TO_STRING(objDefault) = subItem2 Then
                            strSearch = subItem2
                        End If
                    End If

                End If

            Next
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        cboControl.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        cboControl.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        cboControl.ValueMember = "ID"


        '*******************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽ  ｾﾚｸﾄ
        '*******************************************************
        If IsNull(objDefault) Then
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されていない場合)
            cboControl.SelectedIndex = IIf(cboControl.Items.Count = 0, -1, 0)

        Else
            '(ﾃﾞﾌｫﾙﾄの設定値が設定されている場合)
            Call cboSelectValue(cboControl, strSearch)

        End If
    End Sub
#End Region

#Region "　棚番初期設定(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№から取得、全選択Ver)                  "
    '''***************************************************************************************************************
    ''' <summary>
    ''' 棚番初期設定
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">棚番初期化するﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="cboFRAC_RETU">列ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_REN">連ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <param name="cboFRAC_DAN">段ｺﾝﾎﾞﾎﾞｯｸｽ</param>
    ''' <remarks></remarks>
    '''***************************************************************************************************************
    Public Sub InitRetuRenDan_TrkBufNo_ALL(ByVal strFTRK_BUF_NO As String _
                                     , ByRef cboFRAC_RETU As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_REN As Windows.Forms.ComboBox _
                                     , ByRef cboFRAC_DAN As Windows.Forms.ComboBox _
                                     )
        Dim strSQL As String                'SQL文
        Dim intRetuMin As Integer = 0       '最小列数
        Dim intRenMin As Integer = 0        '最小連数
        Dim intDanMin As Integer = 0        '最小段数
        Dim intRetuMax As Integer = 0       '最大列数
        Dim intRenMax As Integer = 0        '最大連数
        Dim intDanMax As Integer = 0        '最大段数
        Dim objFRAC_RETU_Value As Object = Nothing      'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_REN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        Dim objFRAC_DAN_Value As Object = Nothing       'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_RETU.SelectedItem) = False Then objFRAC_RETU_Value = cboFRAC_RETU.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_REN.SelectedItem) = False Then objFRAC_REN_Value = cboFRAC_REN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管
        If IsNull(cboFRAC_DAN.SelectedItem) = False Then objFRAC_DAN_Value = cboFRAC_DAN.SelectedValue.ToString 'ｺﾝﾎﾞﾎﾞｯｸｽ値一時保管


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MIN "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MIN
        strSQL &= vbCrLf & "   ,MIN(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MIN "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MIN
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_RETU) AS FRAC_RETU_MAX "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚列MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_REN) AS FRAC_REN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  棚連MAX
        strSQL &= vbCrLf & "   ,MAX(TPRG_TRK_BUF.FRAC_DAN) AS FRAC_DAN_MAX "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.　棚段MAX
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO "  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№で結合
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = '" & strFTRK_BUF_NO & "'"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    TMST_TRK.FBUF_KIND "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.  ﾊﾞｯﾌｧ種別ｺｰﾄﾞ

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        gobjDb.SQL = strSQL
        strDataSetName = "TPRG_TRK_BUF"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            intRetuMin = TO_INTEGER(objRow("FRAC_RETU_MIN"))
            intRenMin = TO_INTEGER(objRow("FRAC_REN_MIN"))
            intDanMin = TO_INTEGER(objRow("FRAC_DAN_MIN"))

            intRetuMax = TO_INTEGER(objRow("FRAC_RETU_MAX"))
            intRenMax = TO_INTEGER(objRow("FRAC_REN_MAX"))
            intDanMax = TO_INTEGER(objRow("FRAC_DAN_MAX"))

        End If


        '**********************************************************
        ' 列連段ｺﾝﾎﾞ設定
        '**********************************************************
        Call locaSetup(cboFRAC_RETU, intRetuMax, True, objFRAC_RETU_Value, , intRetuMin)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 連は3桁表示
        'Call locaSetup(cboFRAC_REN, intRenMax, False, objFRAC_REN_Value, , intRenMin)
        Call locaSetup_3keta(cboFRAC_REN, intRenMax, True, objFRAC_REN_Value, , intRenMin)
        '↑↑↑↑↑↑************************************************************************************************************
        Call locaSetup(cboFRAC_DAN, intDanMax, True, objFRAC_DAN_Value, , intDanMin)


    End Sub
#End Region

#Region "  ｿｹｯﾄ送信               (旧ﾏｽﾀ移行ｿｹｯﾄ用)        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 (旧ﾏｽﾀ移行ｿｹｯﾄ用)
    ''' </summary>
    ''' <param name="objTelegramSend">電文作成ｸﾗｽ</param>
    ''' <param name="strRET_STATE">ｻｰﾊﾞから受信した応答ｽﾃｰﾀｽ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA_SYUBETU">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ種別(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strRET_DATA">ｻｰﾊﾞから受信した応答ﾃﾞｰﾀ(ﾃﾞﾌｫﾙﾄ = "")</param>
    ''' <param name="strUSER_ID"></param>
    ''' <param name="strErrMessage">処理ｴﾗｰﾒｯｾｰｼﾞ (2010/05/19 kato ﾒｯｾｰｼﾞ表示を1回にするため追加)</param>
    ''' <returns>ｿｹｯﾄ送信、正常応答 or 異常応答</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function SockSendServer_DATA_MOVE(ByRef objTelegramSend As clsTelegram _
                                   , Optional ByRef strRET_STATE As String = "" _
                                   , Optional ByRef strRET_DATA_SYUBETU As String = "" _
                                   , Optional ByRef strRET_DATA As String = "" _
                                   , Optional ByRef strUSER_ID As String = "" _
                                   , Optional ByRef strErrMessage As String = "" _
                                     ) As clsSocketClient.RetCode
        Dim dtmNow As Date = Now
        Dim objSocketSend As New clsSocketClientGamen(gobjOwner)


        '***************************************************
        ' Waitﾌｫｰﾑ表示
        '***************************************************
        Call WaitFormShow()


        '***************************************************
        ' 電文作成
        '***************************************************
        'ﾍｯﾀﾞｰ部分ｾｯﾄ
        objTelegramSend.SETIN_HEADER("DSPCMD_ID", Strings.Right(objTelegramSend.FORMAT_ID, 6))      'ｺﾏﾝﾄﾞID

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:H.Okumura 2013/07/11 端末IDとﾕｰｻﾞｰIDは固定値を設定
        objTelegramSend.SETIN_HEADER("DSPTERM_ID", "LNSS01")                           '端末ID
        objTelegramSend.SETIN_HEADER("DSPUSER_ID", "9")                                 'ﾕｰｻﾞｰID
        '↑↑↑↑↑↑************************************************************************************************************
        '' ''objTelegramSend.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                           '端末ID
        '' ''If strUSER_ID = "" Then                                                             'ﾕｰｻﾞｰID
        '' ''    objTelegramSend.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)
        '' ''Else
        '' ''    objTelegramSend.SETIN_HEADER("DSPUSER_ID", strUSER_ID)
        '' ''End If
        objTelegramSend.MAKE_TELEGRAM()                                                 '電文作成


        '***************************************************
        ' ｿｹｯﾄ送信
        '***************************************************
        objSocketSend.strAddress = gcstrSOCK_SEND_ADDRESS               '送信先ｱﾄﾞﾚｽ
        objSocketSend.intPortNo = gcstrSOCK_SEND_PORT                   'ﾎﾟｰﾄNo
        objSocketSend.intTimeOut = gcstrSOCK_SEND_TIME_OUT              'ﾀｲﾑｱｳﾄ
        objSocketSend.strSendText = objTelegramSend.TELEGRAM_MAKED      '送信ﾃｷｽﾄ
        objSocketSend.blnReceiveFlag = True                             '応答ｿｹｯﾄ待機

        Call AddToLog_frm("START")
        objSocketSend.SendSock()                                        'ｿｹｯﾄ送信
        ''Call AddToLog_frm( & objSocketSend.strSendText)
        Call AddToLog_frm("END")


        '***************************************************
        ' Waitﾌｫｰﾑ削除
        '***************************************************
        Call WaitFormClose()


        '***************************************************
        ' ｿｹｯﾄ送信正常終了ﾁｪｯｸ
        '***************************************************
        Select Case objSocketSend.udtRet
            Case clsSocketClient.RetCode.NG
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_01, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ReceiveTimeOut
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_02, PopupFormType.Ok, PopupIconType.Err)

            Case clsSocketClient.RetCode.ConnectError
                Call DisplayPopup(FRM_MSG_SOCKSENDSERVER_03, PopupFormType.Ok, PopupIconType.Err)

        End Select


        '***************************************************
        ' 受信ｿｹｯﾄ解析
        '***************************************************
        Dim objTelegramRecv As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strRET_MESSAGE_EXIST As String          '応答ﾒｯｾｰｼﾞ有無
        Dim strRET_MESSAGE As String                '応答ﾒｯｾｰｼﾞ
        ''Dim strRET_DATA_SYUBETU As String           '応答ﾃﾞｰﾀ種別
        ''Dim strRET_DATA As String                   '応答ﾃﾞｰﾀ

        objTelegramRecv.FORMAT_ID = FORMAT_DSP_RETURN                                   'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegramRecv.TELEGRAM_PARTITION = objSocketSend.strRecvText                  '分割する電文ｾｯﾄ
        objTelegramRecv.PARTITION()                                                     '電文分割
        strRET_STATE = objTelegramRecv.SELECT_DATA("DSPRET_STATE")                      '応答ｽﾃｰﾀｽ
        strRET_MESSAGE_EXIST = objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE_EXIST")      '応答ﾒｯｾｰｼﾞ有無
        strRET_MESSAGE = Trim(objTelegramRecv.SELECT_DATA("DSPRET_MESSAGE"))            '応答ﾒｯｾｰｼﾞ
        strRET_DATA_SYUBETU = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA_SYUBETU"))  '応答ﾃﾞｰﾀ種別
        strRET_DATA = Trim(objTelegramRecv.SELECT_DATA("DSPRET_DATA"))                  '応答ﾃﾞｰﾀ



        '---------------------------------
        'ﾒｯｾｰｼﾞ表示
        '---------------------------------
        If Trim(strRET_MESSAGE_EXIST) = ID_RETURN_RET_MESSAGE_EXIST_YES Then

            Select Case Trim(strRET_STATE)
                Case ID_RETURN_RET_STATE_OK
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Information, "", FRM_MSG_SOCKSENDSERVER_91)
                Case ID_RETURN_RET_STATE_NG
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
                Case Else
                    Call DisplayPopup(strRET_MESSAGE, PopupFormType.Ok, PopupIconType.Err, "", FRM_MSG_SOCKSENDSERVER_91)
            End Select
        Else
            If strErrMessage <> "" Then
                '(引数にﾒｯｾｰｼﾞがｾｯﾄされている場合)
                If objSocketSend.udtRet = clsSocketClient.RetCode.OK Then
                    '(送信できた場合)
                    If strRET_STATE <> ID_RETURN_RET_STATE_OK Then
                        '(処理が異常終了した場合)
                        Call DisplayPopup(strErrMessage, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Err)

                    End If
                ElseIf objSocketSend.udtRet <> clsSocketClient.RetCode.ReceiveTimeOut And _
                       objSocketSend.udtRet <> clsSocketClient.RetCode.NG And _
                       objSocketSend.udtRet <> clsSocketClient.RetCode.ConnectError Then
                    '(ｿｹｯﾄ送信正常終了ﾁｪｯｸでﾁｪｯｸしたもの以外の場合)

                    Call DisplayPopup(strErrMessage, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                End If
            End If
        End If

        Return (objSocketSend.udtRet)
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************


End Class
