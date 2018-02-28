'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｸﾚｰﾝ優先順更新ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100205
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
    Private mFEQ_ID As String                       '設備ID
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/05/24  更新するｸﾚｰﾝ優先順を選択可能にする
    Private mFHENSU_ID As String                    '変数ID
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>設備ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/05/24  更新するｸﾚｰﾝ優先順を選択可能にする
    ''' =======================================
    ''' <summary>変数ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
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
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ｸﾚｰﾝ優先順更新                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾚｰﾝ優先順更新
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CRANE_ORDER_UPDATE()
        Try
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode       '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '******************************************
            'ｸﾚｰﾝ優先順の再構築
            '******************************************
            '================================
            'ｼｽﾃﾑ変数取得
            '================================
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         'ｼｽﾃﾑ変数ｸﾗｽ
            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2013/05/24  更新するｸﾚｰﾝ優先順を選択可能にする
            If IsNotNull(mFHENSU_ID) Then
                objTPRG_SYS_HEN.FHENSU_ID = mFHENSU_ID                  '変数ID
            Else
                objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002     '変数ID
            End If
            'objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '変数ID
            '↑↑↑↑↑↑************************************************************************************************************
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '取得

            '================================
            '設備ID検索
            '================================
            Dim strTemp() As String             '設備ID配列一時保管
            Dim blnFound As Boolean = False     '設備ID発見ﾌﾗｸﾞ
            Dim ii As Integer                   'ｶｳﾝﾀ
            strTemp = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)
            For ii = LBound(strTemp) To UBound(strTemp)
                '(ﾙｰﾌﾟ:ｸﾚｰﾝ数)
                If mFEQ_ID = strTemp(ii) Then
                    '(見つかった場合)
                    blnFound = True
                    Exit For
                End If
            Next
            If blnFound = False Then
                strMsg = ERRMSG_NOTFOUND_FEQ_ID & "[設備ID:" & TO_STRING(mFEQ_ID) & "][ｸﾚｰﾝ優先順:" & objTPRG_SYS_HEN.FHENSU_CHAR & "]"
                Throw New UserException(strMsg)
            End If

            '================================
            '再構築
            '================================
            Dim strSCRN_PRI As String = ""      'ｸﾚｰﾝ優先順再構築
            If ii <> UBound(strTemp) Then
                '(選択されたｸﾚｰﾝが最後尾じゃない場合)

                For jj As Integer = ii + 1 To UBound(strTemp)
                    '(ﾙｰﾌﾟ:設定された次のｸﾚｰﾝから、最後尾のｸﾚｰﾝまで)
                    strSCRN_PRI &= KUGIRI01 & strTemp(jj)
                Next
                For jj As Integer = LBound(strTemp) To ii
                    '(ﾙｰﾌﾟ:最初のｸﾚｰﾝから、設定されたｸﾚｰﾝまで)
                    strSCRN_PRI &= KUGIRI01 & strTemp(jj)
                Next

                '最初のﾀｰﾐﾈｰﾀを削除
                strSCRN_PRI = Replace(strSCRN_PRI, KUGIRI01, "", 1, 1)

                '更新
                objTPRG_SYS_HEN.FHENSU_CHAR = strSCRN_PRI   'ｸﾚｰﾝ優先順
                objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN()       '更新

            End If






            ' '' ''************************
            ' '' ''ｸﾚｰﾝ優先順の再構築
            ' '' ''************************
            '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)     'ｼｽﾃﾑ変数ｸﾗｽ
            '' ''Dim strSCRANE As String = objTPRG_SYS_HEN.SCRANE                        'ｸﾚｰﾝ優先順
            '' ''Dim strTemp As String = DEFAULT_STRING                                  'TEMP
            '' ''intLen = Len(strSCRANE)                                                 '文字長の取得
            '' ''intPos = InStr(TO_STRING(strSCRANE), mFCRANE_ID)                        '文字位置の特定
            '' ''strTemp = strTemp & Mid(TO_STRING(strSCRANE), intPos + 1)
            '' ''strTemp = strTemp & Mid(TO_STRING(strSCRANE), 1, intPos)


            ' '' ''************************
            ' '' ''ｼｽﾃﾑ変数の更新
            ' '' ''************************
            '' ''objTPRG_SYS_HEN.SCRANE = strTemp


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
