'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】Configファイル読込
' 【作成】KSH
'**********************************************************************************************
#Region " imports "
Imports JobCommon
#End Region

Public Class clsConfigFileRead
    Inherits Global.jobCommon.clsConfigReader

#Region "  共通定数＆変数"

    '==================================================================
    '   Configﾌｧｲﾙｷｰ情報
    '==================================================================
    Private Const KEY_DB_KIND = "DB Kind"                               'DB種別
    Private Const KEY_DB_CNSTR = "DB Connect String"                    'DB接続文字列
    Private Const KEY_DB_HOST_CNSTR = "DB Host Connect String"          'ﾎｽﾄDB接続文字列
    Private Const KEY_LSNR_PORTN_DISP = "Listener Port_DISP"            'ﾘｽﾅｰﾎﾟｰﾄ 画面用
    Private Const KEY_LSNR_QUENM = "Listener Que"                       'QUEﾊﾞｯﾌｧ数
    Private Const KEY_THRD_TIMER = "Thread End Timer"
    Private Const KEY_THRD_COUNT = "Thread End Count"
    Private Const KEY_TMAD_ENABL = "Timer Advance Enable"
    Private Const KEY_TMAD_INTVL = "Timer Advance Interval"
    Private Const KEY_ONTM_HEADR = "OnTime"
    Private Const KEY_ONTM_ONTIM = " SetOnTime"
    Private Const KEY_ONTM_CMDNO = " CommandNo"


    '==================================================================
    '   Configﾌｧｲﾙ情報
    '==================================================================
    Private mstrDB_KIND As String
    Private mstrDB_CNSTR As String
    Private mstrDB_CNTST As String
    Private mstrDB_PCCST As String
    Private mstrDB_HOST_CNSTR As String
    Private mstrDB_OCHOZOU_CNSTR As String
    Private mstrDB_OKOUZAI_CNSTR As String
    Private mstrDB_OSEIKEI_CNSTR As String
    Private mintLSNR_PORTN_DISP As Integer
    Private mintLSNR_QUENM As Integer
    Private mintTHRD_TIMER As Integer
    Private mintTHRD_COUNT As Integer

    '定時処理
    Private mintOntimeCount As Integer      '定時処理 設定数
    Private mdtmOntimeSetTm() As Date       '定時処理 実行時刻
    Private mintOntimeCmdNo() As Integer    '定時処理 実行コマンドNo.

    '拡張定周期処理
    Private mintTMAD_ENABL As Integer       '拡張定時処理 有効フラグ
    Private mintTMAD_INTVL As Integer       '拡張定時処理 実行周期

#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨ定数"
    ''' =======================================
    ''' <summary>Property    DBKind</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBKind() As String
        Get
            DBKind = mstrDB_KIND
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    DBConnectString</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBConnectString() As String
        Get
            DBConnectString = mstrDB_CNSTR
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    DBConnectString</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBHostConnectString() As String
        Get
            DBHostConnectString = mstrDB_HOST_CNSTR
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    DBConnectString</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBOChozouConnectString() As String
        Get
            DBOChozouConnectString = mstrDB_OCHOZOU_CNSTR
        End Get
    End Property
    ''' =======================================
    ''' <summary>Property    DBConnectString</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBOKouzaiConnectString() As String
        Get
            DBOKouzaiConnectString = mstrDB_OKOUZAI_CNSTR
        End Get
    End Property
    ''' =======================================
    ''' <summary>Property    DBConnectString</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property DBOSeikeiConnectString() As String
        Get
            DBOSeikeiConnectString = mstrDB_OSEIKEI_CNSTR
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    ListenerPort</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ListenerPort_DISP() As Integer
        Get
            ListenerPort_DISP = mintLSNR_PORTN_DISP
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    ListenerQue</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ListenerQue() As Integer
        Get
            ListenerQue = mintLSNR_QUENM
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    ThreadEndTimer</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ThreadEndTimer() As Integer
        Get
            ThreadEndTimer = mintTHRD_TIMER
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    ThreadEndCount</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property ThreadEndCount() As Integer
        Get
            ThreadEndCount = mintTHRD_COUNT
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    OntimeCount</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property OntimeCount() As Integer
        Get
            OntimeCount = mintOntimeCount
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    OntimeCmdNo</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property OntimeCmdNo(ByVal intCnt As Integer) As Integer
        Get
            If intCnt > 0 And intCnt <= mintOntimeCount Then
                OntimeCmdNo = mintOntimeCmdNo(intCnt)
            End If
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    OntimeSetTm</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property OntimeSetTm(ByVal intCnt As Integer) As Date
        Get
            If intCnt > 0 And intCnt <= mintOntimeCount Then
                OntimeSetTm = mdtmOntimeSetTm(intCnt)
            End If
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    TimerAdvEnable</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property TimerAdvEnable() As Integer
        Get
            TimerAdvEnable = mintTMAD_ENABL
        End Get
    End Property

    ''' =======================================
    ''' <summary>Property    TimerAdvIntvl</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property TimerAdvIntvl() As Integer
        Get
            TimerAdvIntvl = mintTMAD_INTVL
        End Get
    End Property

#End Region

#Region "  ｺﾝｽﾄﾗｸﾀ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sFile">Configﾌｧｲﾙ名</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal sFile As String)
        MyBase.New(sFile)
    End Sub
#End Region

#Region "  Configﾌｧｲﾙ全情報の取得           (Public  clsmALLGetPrivateProfile)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙ全情報の取得 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub clsmALLGetPrivateProfile()
        Try
            mstrDB_KIND = GetConfigProfile(KEY_DB_KIND)                     'DB種別
            mstrDB_CNSTR = GetConfigProfile(KEY_DB_CNSTR)                   'DB接続文字列
            mstrDB_HOST_CNSTR = GetConfigProfile(KEY_DB_HOST_CNSTR)         'ﾎｽﾄDB接続文字列
            mintLSNR_PORTN_DISP = GetConfigProfile(KEY_LSNR_PORTN_DISP)     'ﾘｽﾅｰﾎﾟｰﾄ 画面用
            mintLSNR_QUENM = GetConfigProfile(KEY_LSNR_QUENM)               'QUEﾊﾞｯﾌｧ数
            mintTHRD_TIMER = GetConfigProfile(KEY_THRD_TIMER)
            mintTHRD_COUNT = GetConfigProfile(KEY_THRD_COUNT)

            GetConfigOnTime()
            mintTMAD_ENABL = GetConfigProfile(KEY_TMAD_ENABL)
            mintTMAD_INTVL = GetConfigProfile(KEY_TMAD_INTVL)
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

#Region "  Configﾌｧｲﾙ情報(定時処理)の取得   (Private GetConfigOnTime)"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Configﾌｧｲﾙ情報(定時処理)の取得
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub GetConfigOnTime()
        Try
            Dim intCnt As Integer           '設定数
            Dim blnLoopEnd As Boolean       'ループ終了フラグ
            Dim strKeyNmSettm As String     'キー名称 実行時刻
            Dim strKeyNmCmdno As String     'キー名称 実行コマンドNo.
            Dim strCfgSettm As String       'Config設定情報 実行時刻
            Dim strCfgCmdno As String       'Config設定情報 実行コマンドNo.

            intCnt = 0                      '設定数
            blnLoopEnd = False              'ループ終了フラグ
            While blnLoopEnd = False
                strKeyNmSettm = KEY_ONTM_HEADR & Right("00" & Trim(Str(intCnt + 1)), 2) & KEY_ONTM_ONTIM
                strKeyNmCmdno = KEY_ONTM_HEADR & Right("00" & Trim(Str(intCnt + 1)), 2) & KEY_ONTM_CMDNO
                strCfgSettm = ""                                    'Config設定情報 実行時刻
                strCfgCmdno = ""                                    'Config設定情報 実行コマンドNo.
                strCfgSettm = GetConfigProfile(strKeyNmSettm)       'Config設定情報 実行時刻
                strCfgCmdno = GetConfigProfile(strKeyNmCmdno)       'Config設定情報 実行コマンドNo.
                If strCfgSettm Is Nothing Or strCfgCmdno Is Nothing Or _
                   strCfgSettm = "" Or strCfgCmdno = "" Or _
                   Not IsDate(strCfgSettm) Then
                    blnLoopEnd = True                               'ループ終了

                Else
                    intCnt += 1
                    ReDim Preserve mdtmOntimeSetTm(intCnt)                      '実行時刻
                    ReDim Preserve mintOntimeCmdNo(intCnt)                      '実行コマンドNo.
                    mintOntimeCount = intCnt                                    '設定数
                    mdtmOntimeSetTm(intCnt) = TO_DATE_NULLABLE(strCfgSettm)     '実行時刻
                    mintOntimeCmdNo(intCnt) = CInt(strCfgCmdno)                 '実行コマンドNo.
                End If
            End While
        Catch e As Exception
            Throw New System.Exception(e.Message)
        End Try
    End Sub
#End Region

End Class
