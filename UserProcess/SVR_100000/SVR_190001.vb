'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】電文送信ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_190001
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mFENTRY_NO As String                                                 '登録№
    Private mFEQ_ID As String                                                    '設備ID
    Private mFCOMMAND_ID As String = FCOMMAND_ID_SOT                             'ｺﾏﾝﾄﾞID
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFTRNS_SERIAL As String                                              '搬送ｼﾘｱﾙ№(MCｷｰ)
    Private mFPRIORITY As Nullable(Of Integer) = FPRIORITY_SLOW                  '優先ﾚﾍﾞﾙ
    Private mFOFFLINE_FLAG As Nullable(Of Integer)                               'ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "

    ''' <summary>
    ''' 登録№
    ''' </summary>
    Public Property FENTRY_NO() As String
        Get
            Return mFENTRY_NO
        End Get
        Set(ByVal Value As String)
            mFENTRY_NO = Value
        End Set
    End Property

    ''' <summary>
    ''' 設備ID
    ''' </summary>
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property

    ''' <summary>
    ''' ｺﾏﾝﾄﾞID
    ''' </summary>
    Public Property FCOMMAND_ID() As String
        Get
            Return mFCOMMAND_ID
        End Get
        Set(ByVal Value As String)
            mFCOMMAND_ID = Value
        End Set
    End Property

    ''' <summary>
    ''' ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property

    ''' <summary>
    ''' 搬送ｼﾘｱﾙ№(MCｷｰ)
    ''' </summary>
    Public Property FTRNS_SERIAL() As String
        Get
            Return mFTRNS_SERIAL
        End Get
        Set(ByVal Value As String)
            mFTRNS_SERIAL = Value
        End Set
    End Property

    ''' <summary>
    ''' 優先ﾚﾍﾞﾙ
    ''' </summary>
    Public Property FPRIORITY() As Nullable(Of Integer)
        Get
            Return mFPRIORITY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPRIORITY = Value
        End Set
    End Property

    ''' <summary>
    ''' ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ
    ''' </summary>
    Public Property FOFFLINE_FLAG() As Nullable(Of Integer)
        Get
            Return mFOFFLINE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFOFFLINE_FLAG = Value
        End Set
    End Property

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region

#Region "  搬送制御送信IFへ電文追加                                                             "
    '''**********************************************************************************************
    ''' <summary>
    ''' 搬送制御送信IFへ電文追加
    ''' </summary>
    ''' <param name="strFDENBUN">送信電文</param>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="blnRetryCheck">同じ電文が存在しても、搬送制御送信IFに追加するか否かのﾌﾗｸﾞ</param>
    ''' <param name="strFDENBUN_PRM1">電文ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFDENBUN_PRM2">電文ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFDENBUN_PRM3">電文ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFDENBUN_PRM4">電文ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFDENBUN_PRM5">電文ﾊﾟﾗﾒｰﾀ5</param>
    ''' <param name="strFDENBUN_PRM6">電文ﾊﾟﾗﾒｰﾀ6</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub InsertTLIF_TRNS_SEND(ByVal strFDENBUN As String _
                                  , ByVal strFTEXT_ID As String _
                                  , Optional ByVal blnRetryCheck As Boolean = True _
                                  , Optional ByVal strFDENBUN_PRM1 As String = Nothing _
                                  , Optional ByVal strFDENBUN_PRM2 As String = Nothing _
                                  , Optional ByVal strFDENBUN_PRM3 As String = Nothing _
                                  , Optional ByVal strFDENBUN_PRM4 As String = Nothing _
                                  , Optional ByVal strFDENBUN_PRM5 As String = Nothing _
                                  , Optional ByVal strFDENBUN_PRM6 As String = Nothing _
                                    )
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '*********************************************
            '搬送制御送信IF     ﾁｪｯｸ
            '*********************************************
            If blnRetryCheck = True Then
                '(電文重複ﾁｪｯｸを行う場合)
                '(同じ電文を無限に送信しない為のﾁｪｯｸ)

                Dim objTLIF_TRNS_SEND_Check As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog)     '搬送制御送信IF
                objTLIF_TRNS_SEND_Check.FEQ_ID = mFEQ_ID                        '設備ID
                objTLIF_TRNS_SEND_Check.FCOMMAND_ID = mFCOMMAND_ID              'ｺﾏﾝﾄﾞID
                objTLIF_TRNS_SEND_Check.FTEXT_ID = strFTEXT_ID                  'ﾃｷｽﾄID
                objTLIF_TRNS_SEND_Check.FDENBUN = strFDENBUN                    '通信電文
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM1 = strFDENBUN_PRM1          '電文ﾊﾟﾗﾒｰﾀ1
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM2 = strFDENBUN_PRM2          '電文ﾊﾟﾗﾒｰﾀ2
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM3 = strFDENBUN_PRM3          '電文ﾊﾟﾗﾒｰﾀ3
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM4 = strFDENBUN_PRM4          '電文ﾊﾟﾗﾒｰﾀ4
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM5 = strFDENBUN_PRM5          '電文ﾊﾟﾗﾒｰﾀ5
                objTLIF_TRNS_SEND_Check.FDENBUN_PRM6 = strFDENBUN_PRM6          '電文ﾊﾟﾗﾒｰﾀ6
                objTLIF_TRNS_SEND_Check.FPROGRESS = FPROGRESS_SNON              '進捗状態
                intRet = objTLIF_TRNS_SEND_Check.GET_TLIF_TRNS_SEND(False)      '取得
                If intRet = RetCode.OK Then
                    '(同じ電文が存在した場合)
                    Exit Sub
                End If

            End If


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog)     '搬送制御送信IF
            objTLIF_TRNS_SEND.FEQ_ID = mFEQ_ID                      '設備ID
            objTLIF_TRNS_SEND.FCOMMAND_ID = mFCOMMAND_ID            'ｺﾏﾝﾄﾞID
            objTLIF_TRNS_SEND.FPALLET_ID = mFPALLET_ID              'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.FTEXT_ID = strFTEXT_ID                'ﾃｷｽﾄID
            objTLIF_TRNS_SEND.FDENBUN_PRM1 = strFDENBUN_PRM1        '電文ﾊﾟﾗﾒｰﾀ1
            objTLIF_TRNS_SEND.FDENBUN_PRM2 = strFDENBUN_PRM2        '電文ﾊﾟﾗﾒｰﾀ2
            objTLIF_TRNS_SEND.FDENBUN_PRM3 = strFDENBUN_PRM3        '電文ﾊﾟﾗﾒｰﾀ3
            objTLIF_TRNS_SEND.FDENBUN_PRM4 = strFDENBUN_PRM4        '電文ﾊﾟﾗﾒｰﾀ4
            objTLIF_TRNS_SEND.FDENBUN_PRM5 = strFDENBUN_PRM5        '電文ﾊﾟﾗﾒｰﾀ5
            objTLIF_TRNS_SEND.FDENBUN_PRM6 = strFDENBUN_PRM6        '電文ﾊﾟﾗﾒｰﾀ6
            objTLIF_TRNS_SEND.FTRNS_SERIAL = mFTRNS_SERIAL          '搬送ｼﾘｱﾙ№
            objTLIF_TRNS_SEND.FPRIORITY = mFPRIORITY                '優先ﾚﾍﾞﾙ
            objTLIF_TRNS_SEND.FDENBUN = strFDENBUN                  '通信電文
            objTLIF_TRNS_SEND.FPROGRESS = FPROGRESS_SNON            '進捗状態
            objTLIF_TRNS_SEND.FRES_CD_EQ = DEFAULT_STRING           '設備応答ｺｰﾄﾞ
            objTLIF_TRNS_SEND.FOFFLINE_FLAG = mFOFFLINE_FLAG        'ｵﾌﾗｲﾝ送信ﾌﾗｸﾞ
            objTLIF_TRNS_SEND.FENTRY_DT = Now                       '登録日時
            objTLIF_TRNS_SEND.FUPDATE_DT = Now                      '更新日時
            If IsNull(mFENTRY_NO) Then
                objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND_SEQ()          '登録
            Else
                objTLIF_TRNS_SEND.FENTRY_NO = mFENTRY_NO            '登録№
                objTLIF_TRNS_SEND.ADD_TLIF_TRNS_SEND()              '登録
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '安川,Melsec
#Region "  安川         入庫指示                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川         入庫指示
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUE</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDIn(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                               , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                               , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                               , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                               , ByVal objTMST_ROUTE As TBL_TMST_ROUTE _
                               )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(親かつﾍﾟｱ搬送の場合)
                Exit Sub
            End If


            '*************************************************
            '付属ﾃﾞｰﾀ取得
            '*************************************************
            '==========================================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(搬送元)        取得
            '==========================================
            Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK_FM.GET_TMST_TRK()

            '==========================================
            '号機
            '==========================================
            Dim intGouki As Integer
            Dim strGouki As String
            intGouki = (objTPRG_TRK_BUF_TO.FRAC_RETU \ 2) + (objTPRG_TRK_BUF_TO.FRAC_RETU Mod 2)
            strGouki = Change10To2(intGouki, 4)


            '**************************************************************************************************
            '**************************************************************************************************
            '2ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            '*************************************************
            'ﾃﾞｰﾀ1(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData01Second_02 As String = ""     'ﾃﾞｰﾀ1(親)( 2進数)
            strData01Second_02 &= "0"                                                 '固定
            strData01Second_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
            strData01Second_02 &= "0"                                                 '出庫ﾓｰﾄﾞ
            strData01Second_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
            strData01Second_02 &= "1"                                                 'ﾌｫｰｸ2
            strData01Second_02 &= "0"                                                 'ﾌｫｰｸ1
            strData01Second_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
            strData01Second_02 &= "0"                                                 '固定
            If objTPRG_TRK_BUF_TO.FRAC_RETU <> FRAC_RETU_J27 Then
                strData01Second_02 &= Change10To2(objTPRG_TRK_BUF_TO.FRAC_EDA, 1)     'ﾀﾞﾌﾞﾙﾘｰﾁ
            Else
                strData01Second_02 &= Change10To2(0, 1)                               'ﾀﾞﾌﾞﾙﾘｰﾁ
            End If
            strData01Second_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_TO.FRAC_RETU), 2)     '列
            strData01Second_02 &= strGouki                                            '号機


            '*************************************************
            'ﾃﾞｰﾀ2(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData02Second_02 As String = ""     'ﾃﾞｰﾀ2(親)( 2進数)
            strData02Second_02 &= "00"                                                '固定
            strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_TO.FRAC_REN, 6)         '連
            strData02Second_02 &= "1"                                                 'ENDﾌﾗｸﾞ
            strData02Second_02 &= "1"                                                 '入棚再設定
            strData02Second_02 &= "00"                                                '固定
            strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_TO.FRAC_DAN, 4)         '段


            '*************************************************
            'ﾃﾞｰﾀ3(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData03Second_10 As String = ""     'ﾃﾞｰﾀ3(親)(10進数)
            strData03Second_10 = "0"                  'ｱﾄﾞﾚｽ


            '**************************************************************************************************
            '**************************************************************************************************
            '1ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            Dim strData01First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ1( 2進数)
            Dim strData02First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ2( 2進数)
            Dim strData03First_10 As String = "0"                   'ﾃﾞｰﾀ3(10進数)
            Dim blnFirst As Boolean = False                         '1ﾊﾟﾚｯﾄ目の存在ﾌﾗｸﾞ


            '*************************************************
            'TOﾄﾗｯｷﾝｸﾞ(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞ)       取得
            '*************************************************
            Dim intRetTo As RetCode                                 'TOﾄﾗｯｷﾝｸﾞ(子ﾄﾗｯｷﾝｸﾞ)戻り値
            Dim objTPRG_TRK_BUF_First_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                objTPRG_TRK_BUF_First_TO.FTRK_BUF_NO = FTRK_BUF_NO_J9000                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_First_TO.FRSV_PALLET = objTPLN_CARRY_QUE.XPALLET_ID_AITE       '仮引当ﾊﾟﾚｯﾄID
                intRetTo = objTPRG_TRK_BUF_First_TO.GET_TPRG_TRK_BUF_RSV_PALLET()              '取得
            End If


            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) And intRetTo = RetCode.OK Then
                '(親かつﾍﾟｱ搬送かつ1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞがある場合)
                blnFirst = True


                '*************************************************
                'ﾃﾞｰﾀ1(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData01First_02 = ""
                strData01First_02 &= "0"                                                 '固定
                strData01First_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
                strData01First_02 &= "0"                                                 '出庫ﾓｰﾄﾞ
                strData01First_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
                strData01First_02 &= "0"                                                 'ﾌｫｰｸ2
                strData01First_02 &= "1"                                                 'ﾌｫｰｸ1
                strData01First_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
                strData01First_02 &= "0"                                                 '固定
                If objTPRG_TRK_BUF_TO.FRAC_RETU <> FRAC_RETU_J27 Then
                    strData01First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_EDA, 1)   'ﾀﾞﾌﾞﾙﾘｰﾁ
                Else
                    strData01First_02 &= Change10To2(0, 1)                               'ﾀﾞﾌﾞﾙﾘｰﾁ
                End If
                strData01First_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_First_TO.FRAC_RETU), 2)    '列
                strData01First_02 &= strGouki                                            '号機


                '*************************************************
                'ﾃﾞｰﾀ2(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData02First_02 = ""
                strData02First_02 &= "00"                                                '固定
                strData02First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_REN, 6)   '連
                strData02First_02 &= "0"                                                 'ENDﾌﾗｸﾞ
                strData02First_02 &= "1"                                                 '入棚再設定
                strData02First_02 &= "00"                                                '固定
                strData02First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_DAN, 4)   '段


                '*************************************************
                'ﾃﾞｰﾀ3(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData03First_10 = "0"                                                  'ｱﾄﾞﾚｽ


            Else
                '(ｼﾝｸﾞﾙ搬送の場合)

                'ﾌｫｰｸ1での搬送に修正
                strData01Second_02 = Mid(strData01Second_02, 1, 3) & "001" & Mid(strData01Second_02, 7)     'ﾍﾟｱ搬送、ﾌｫｰｸ2、ﾌｫｰｸ1      を修正

            End If


            '*************************************************
            'ﾃﾞｰﾀ       結合
            '*************************************************
            Dim strDataComplete As String
            If blnFirst = True _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2041 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2043 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2055 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2057 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2067 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2065 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2053 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2049 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2045 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2913 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2915 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2916 _
               Then
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在していた場合)
                '(もしくは、前後逆転させる場合)
                strDataComplete = TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
            Else
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在しない場合)
                strDataComplete = TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
            End If


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = objTMST_ROUTE.FEQ_ID_TRNS             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD      'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_IN, True, objTMST_TRK_FM.XADRS_IN, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川         出庫指示                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川         出庫指示
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTSTS_HIKIATE">在庫引当情</param>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUE</param>
    ''' <param name="objTMST_ROUTE">搬送ﾙｰﾄﾏｽﾀ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDOut(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                                , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                                , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                                , ByVal objTSTS_HIKIATE As TBL_TSTS_HIKIATE _
                                , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                                , ByVal objTMST_ROUTE As TBL_TMST_ROUTE _
                                )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(親かつﾍﾟｱ搬送の場合)
                Exit Sub
            End If


            '*************************************************
            '付属ﾃﾞｰﾀ取得
            '*************************************************
            '==========================================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(搬送元)        取得
            '==========================================
            Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_TO.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK_FM.GET_TMST_TRK()

            '==========================================
            '号機
            '==========================================
            Dim intGouki As Integer
            Dim strGouki As String
            intGouki = (objTPRG_TRK_BUF_FM.FRAC_RETU \ 2) + (objTPRG_TRK_BUF_FM.FRAC_RETU Mod 2)
            strGouki = Change10To2(intGouki, 4)

            '==========================================
            'ｱﾄﾞﾚｽ
            '==========================================
            Dim objTPRG_TRK_BUF_Adrs As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Adrs.FTRK_BUF_NO = objTMST_ROUTE.FBUF_TO
            objTPRG_TRK_BUF_Adrs.FTRK_BUF_ARRAY = 1
            objTPRG_TRK_BUF_Adrs.GET_TPRG_TRK_BUF()


            '**************************************************************************************************
            '**************************************************************************************************
            '1ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            '*************************************************
            'ﾃﾞｰﾀ1(1ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData01First_02 As String = ""     'ﾃﾞｰﾀ1(親)( 2進数)
            strData01First_02 &= "0"                                                 '固定
            strData01First_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
            strData01First_02 &= "1"                                                 '出庫ﾓｰﾄﾞ
            strData01First_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
            strData01First_02 &= "1"                                                 'ﾌｫｰｸ2
            strData01First_02 &= "0"                                                 'ﾌｫｰｸ1
            strData01First_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
            strData01First_02 &= "0"                                                 '固定
            If objTPRG_TRK_BUF_FM.FRAC_RETU <> FRAC_RETU_J27 Then
                strData01First_02 &= Change10To2(objTPRG_TRK_BUF_FM.FRAC_EDA, 1)     'ﾀﾞﾌﾞﾙﾘｰﾁ
            Else
                strData01First_02 &= Change10To2(0, 1)                               'ﾀﾞﾌﾞﾙﾘｰﾁ
            End If
            strData01First_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_FM.FRAC_RETU), 2)     '列
            strData01First_02 &= strGouki                                            '号機


            '*************************************************
            'ﾃﾞｰﾀ2(1ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData02First_02 As String = ""     'ﾃﾞｰﾀ2(親)( 2進数)
            strData02First_02 &= "00"                                                '固定
            strData02First_02 &= Change10To2(objTPRG_TRK_BUF_FM.FRAC_REN, 6)         '連
            strData02First_02 &= "1"                                                 'ENDﾌﾗｸﾞ
            strData02First_02 &= "0"                                                 '入棚再設定
            strData02First_02 &= "00"                                                '固定
            strData02First_02 &= Change10To2(objTPRG_TRK_BUF_FM.FRAC_DAN, 4)         '段


            '*************************************************
            'ﾃﾞｰﾀ3(1ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData03First_10 As String = ""     'ﾃﾞｰﾀ3(親)(10進数)
            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(ﾍﾟｱ搬送の場合)

                Select Case objTPRG_TRK_BUF_Adrs.FTRK_BUF_NO
                    Case FTRK_BUF_NO_J1085, FTRK_BUF_NO_J1086 : strData03First_10 = 102    'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1088, FTRK_BUF_NO_J1089 : strData03First_10 = 104    'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1090, FTRK_BUF_NO_J1091 : strData03First_10 = 106    'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1093, FTRK_BUF_NO_J1094 : strData03First_10 = 108    'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1096, FTRK_BUF_NO_J1097 : strData03First_10 = 110    'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1098, FTRK_BUF_NO_J1099 : strData03First_10 = 112    'ｱﾄﾞﾚｽ
                    Case Else : strData03First_10 = objTPRG_TRK_BUF_Adrs.FTRNS_ADDRESS     'ｱﾄﾞﾚｽ
                End Select

            Else
                '(ｼﾝｸﾞﾙ搬送の場合)

                strData03First_10 = objTPRG_TRK_BUF_Adrs.FTRNS_ADDRESS     'ｱﾄﾞﾚｽ

            End If


            '**************************************************************************************************
            '**************************************************************************************************
            '2ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            Dim strData01Second_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ1( 2進数)
            Dim strData02Second_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ2( 2進数)
            Dim strData03Second_10 As String = "0"                   'ﾃﾞｰﾀ3(10進数)
            Dim blnSecond As Boolean = False                         '1ﾊﾟﾚｯﾄ目の存在ﾌﾗｸﾞ


            '*************************************************
            'TOﾄﾗｯｷﾝｸﾞ(2ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞ)       取得
            '*************************************************
            Dim intRetTo As RetCode                                 'TOﾄﾗｯｷﾝｸﾞ(子ﾄﾗｯｷﾝｸﾞ)戻り値
            Dim objTPRG_TRK_BUF_Second_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                objTPRG_TRK_BUF_Second_TO.FTRK_BUF_NO = FTRK_BUF_NO_J9000                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_Second_TO.FRSV_PALLET = objTPLN_CARRY_QUE.XPALLET_ID_AITE       '仮引当ﾊﾟﾚｯﾄID
                intRetTo = objTPRG_TRK_BUF_Second_TO.GET_TPRG_TRK_BUF_RSV_PALLET()              '取得
            End If


            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) And intRetTo = RetCode.OK Then
                '(親かつﾍﾟｱ搬送かつ1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞがある場合)
                blnSecond = True


                '*************************************************
                'ﾃﾞｰﾀ1(2ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData01Second_02 = ""
                strData01Second_02 &= "0"                                                 '固定
                strData01Second_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
                strData01Second_02 &= "1"                                                 '出庫ﾓｰﾄﾞ
                strData01Second_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
                strData01Second_02 &= "0"                                                 'ﾌｫｰｸ2
                strData01Second_02 &= "1"                                                 'ﾌｫｰｸ1
                strData01Second_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
                strData01Second_02 &= "0"                                                 '固定
                If objTPRG_TRK_BUF_FM.FRAC_RETU <> FRAC_RETU_J27 Then
                    strData01Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_EDA, 1)   'ﾀﾞﾌﾞﾙﾘｰﾁ
                Else
                    strData01Second_02 &= Change10To2(0, 1)                               'ﾀﾞﾌﾞﾙﾘｰﾁ
                End If
                strData01Second_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_Second_TO.FRAC_RETU), 2)    '列
                strData01Second_02 &= strGouki                                            '号機


                '*************************************************
                'ﾃﾞｰﾀ2(2ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData02Second_02 = ""
                strData02Second_02 &= "00"                                                '固定
                strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_REN, 6)   '連
                strData02Second_02 &= "1"                                                 'ENDﾌﾗｸﾞ
                strData02Second_02 &= "0"                                                 '入棚再設定
                strData02Second_02 &= "00"                                                '固定
                strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_DAN, 4)   '段


                '*************************************************
                'ﾃﾞｰﾀ3(2ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                Select Case objTPRG_TRK_BUF_Adrs.FTRK_BUF_NO
                    Case FTRK_BUF_NO_J1085, FTRK_BUF_NO_J1086 : strData03Second_10 = 101     'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1088, FTRK_BUF_NO_J1089 : strData03Second_10 = 103     'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1090, FTRK_BUF_NO_J1091 : strData03Second_10 = 105     'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1093, FTRK_BUF_NO_J1094 : strData03Second_10 = 107     'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1096, FTRK_BUF_NO_J1097 : strData03Second_10 = 109     'ｱﾄﾞﾚｽ
                    Case FTRK_BUF_NO_J1098, FTRK_BUF_NO_J1099 : strData03Second_10 = 111     'ｱﾄﾞﾚｽ
                    Case Else : strData03Second_10 = objTPRG_TRK_BUF_Adrs.FTRNS_ADDRESS      'ｱﾄﾞﾚｽ
                End Select


                '*************************************************
                'ﾃﾞｰﾀ2(1ﾊﾟﾚｯﾄ目)    修正
                'ENDﾌﾗｸﾞ            修正
                '*************************************************
                strData02First_02 = Mid(strData02First_02, 1, 8) & "0" & Mid(strData02First_02, 10)      'ENDﾌﾗｸﾞ                    を修正


            Else
                '(ｼﾝｸﾞﾙ搬送の場合)

                '=============================================
                'ﾌｫｰｸ1での搬送に    修正
                '=============================================
                strData01First_02 = Mid(strData01First_02, 1, 3) & "001" & Mid(strData01First_02, 7)     'ﾍﾟｱ搬送、ﾌｫｰｸ2、ﾌｫｰｸ1      を修正

                '=============================================
                'ﾌｫｰｸ2での搬送に    修正
                '=============================================
                If objTPRG_TRK_BUF_FM.FRAC_REN = 1 And (19 <= objTPRG_TRK_BUF_FM.FRAC_RETU And objTPRG_TRK_BUF_FM.FRAC_RETU <= 28) Then
                    '(19列以降は、1連の場合はﾌｫｰｸ2じゃないとすくえない為)
                    strData01First_02 = Mid(strData01First_02, 1, 4) & "10" & Mid(strData01First_02, 7)  'ﾌｫｰｸ2、ﾌｫｰｸ1               を修正
                End If

            End If


            '*************************************************
            'ﾃﾞｰﾀ       結合
            '*************************************************
            Dim strDataComplete As String
            strDataComplete = TO_STRING(Change2To10(strData01First_02))
            strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
            strDataComplete &= "," & strData03First_10
            strDataComplete &= "," & TO_STRING(Change2To10(strData01Second_02))
            strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
            strDataComplete &= "," & strData03Second_10


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = objTMST_ROUTE.FEQ_ID_TRNS             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD      'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_OUT, True, objTMST_TRK_FM.XADRS_OUT, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川         搬送指示                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川         搬送指示
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUE</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDTrns(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                                 , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                                 , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                                 , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                                 , ByVal objTMST_ROUTE As TBL_TMST_ROUTE _
                                 )
        Dim intRet As RetCode                   '戻り値
        Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(親かつﾍﾟｱ搬送の場合)
                Exit Sub
            End If
            Select Case objTPRG_TRK_BUF_FM.FTRK_BUF_NO
                Case FTRK_BUF_NO_J1012 _
                   , FTRK_BUF_NO_J1015 _
                   , FTRK_BUF_NO_J1019 _
                   , FTRK_BUF_NO_J1023 _
                   , FTRK_BUF_NO_J1027 _
                   , FTRK_BUF_NO_J1031 _
                   , FTRK_BUF_NO_J1035 _
                   , FTRK_BUF_NO_J1039 _
                   , FTRK_BUF_NO_J1043 _
                   , FTRK_BUF_NO_J1047 _
                   , FTRK_BUF_NO_J1051 _
                   , FTRK_BUF_NO_J1055 _
                   , FTRK_BUF_NO_J1059 _
                   , FTRK_BUF_NO_J1063 _
                   , FTRK_BUF_NO_J2080 _
                   , FTRK_BUF_NO_J2082 _
                   , FTRK_BUF_NO_J2085 _
                   , FTRK_BUF_NO_J2088 _
                   , FTRK_BUF_NO_J2091 _
                   , FTRK_BUF_NO_J2094 _
                   , FTRK_BUF_NO_J2097 _
                   , FTRK_BUF_NO_J2100 _
                   , FTRK_BUF_NO_J2103 _
                   , FTRK_BUF_NO_J2106 _
                   , FTRK_BUF_NO_J2109 _
                   , FTRK_BUF_NO_J2112 _
                   , FTRK_BUF_NO_J2115 _
                   , FTRK_BUF_NO_J2118
                    '(出庫の場合)
                    Exit Sub
            End Select


            '*************************************************
            '付属ﾃﾞｰﾀ取得
            '*************************************************
            '==========================================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(搬送元)        取得
            '==========================================
            Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK_FM.GET_TMST_TRK()


            '**************************************************************************************************
            '**************************************************************************************************
            '2ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            '*************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞ(自動倉庫))      取得
            '*************************************************
            Dim objTPRG_TRK_BUF_Second_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            objTPRG_TRK_BUF_Second_TO.FTRK_BUF_NO = FTRK_BUF_NO_J9000                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF_Second_TO.FRSV_PALLET = objTPLN_CARRY_QUE.FPALLET_ID            '仮引当ﾊﾟﾚｯﾄID
            intRet = objTPRG_TRK_BUF_Second_TO.GET_TPRG_TRK_BUF_RSV_PALLET()                '取得
            If intRet <> RetCode.OK Then
                '(見つからなかった場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & TO_STRING(objTPRG_TRK_BUF_Second_TO.FTRK_BUF_NO) & "][仮引当ﾊﾟﾚｯﾄID:" & objTPRG_TRK_BUF_Second_TO.FRSV_PALLET & "]"
                Throw New UserException(strMsg)
            End If

            '==========================================
            '号機
            '==========================================
            Dim intGouki As Integer
            Dim strGouki As String
            intGouki = (objTPRG_TRK_BUF_Second_TO.FRAC_RETU \ 2) + (objTPRG_TRK_BUF_Second_TO.FRAC_RETU Mod 2)
            strGouki = Change10To2(intGouki, 4)


            '*************************************************
            'ﾃﾞｰﾀ1(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData01Second_02 As String = ""     'ﾃﾞｰﾀ1(親)( 2進数)
            strData01Second_02 &= "0"                                                 '固定
            strData01Second_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
            strData01Second_02 &= "0"                                                 '出庫ﾓｰﾄﾞ
            strData01Second_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
            strData01Second_02 &= "1"                                                 'ﾌｫｰｸ2
            strData01Second_02 &= "0"                                                 'ﾌｫｰｸ1
            strData01Second_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
            strData01Second_02 &= "0"                                                 '固定
            strData01Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_EDA, 1)  'ﾀﾞﾌﾞﾙﾘｰﾁ
            strData01Second_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_Second_TO.FRAC_RETU), 2)      '列
            strData01Second_02 &= strGouki                                            '号機


            '*************************************************
            'ﾃﾞｰﾀ2(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData02Second_02 As String = ""     'ﾃﾞｰﾀ2(親)( 2進数)
            strData02Second_02 &= "00"                                                '固定
            strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_REN, 6)  '連
            strData02Second_02 &= "1"                                                 'ENDﾌﾗｸﾞ
            strData02Second_02 &= "0"                                                 '入棚再設定
            strData02Second_02 &= "00"                                                '固定
            strData02Second_02 &= Change10To2(objTPRG_TRK_BUF_Second_TO.FRAC_DAN, 4)  '段


            '*************************************************
            'ﾃﾞｰﾀ3(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData03Second_10 As String = ""                                      'ﾃﾞｰﾀ3(親)(10進数)
            strData03Second_10 = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                      'ｱﾄﾞﾚｽ


            '**************************************************************************************************
            '**************************************************************************************************
            '1ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            Dim strData01First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ1( 2進数)
            Dim strData02First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ2( 2進数)
            Dim strData03First_10 As String = "0"                   'ﾃﾞｰﾀ3(10進数)
            Dim blnFirst As Boolean = False                         '1ﾊﾟﾚｯﾄ目の存在ﾌﾗｸﾞ


            '*************************************************
            'TOﾄﾗｯｷﾝｸﾞ(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞ)       取得
            '*************************************************
            Dim intRetTo As RetCode                                 'TOﾄﾗｯｷﾝｸﾞ(子ﾄﾗｯｷﾝｸﾞ)戻り値
            Dim objTPRG_TRK_BUF_First_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
            If IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                objTPRG_TRK_BUF_First_TO.FTRK_BUF_NO = FTRK_BUF_NO_J9000                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF_First_TO.FRSV_PALLET = objTPLN_CARRY_QUE.XPALLET_ID_AITE       '仮引当ﾊﾟﾚｯﾄID
                intRetTo = objTPRG_TRK_BUF_First_TO.GET_TPRG_TRK_BUF_RSV_PALLET()              '取得
            End If


            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) And intRetTo = RetCode.OK Then
                '(親かつﾍﾟｱ搬送かつ1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞがある場合)
                blnFirst = True


                '*************************************************
                'ﾃﾞｰﾀ1(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData01First_02 = ""
                strData01First_02 &= "0"                                                 '固定
                strData01First_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
                strData01First_02 &= "0"                                                 '出庫ﾓｰﾄﾞ
                strData01First_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
                strData01First_02 &= "0"                                                 'ﾌｫｰｸ2
                strData01First_02 &= "1"                                                 'ﾌｫｰｸ1
                strData01First_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
                strData01First_02 &= "0"                                                 '固定
                strData01First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_EDA, 1)   'ﾀﾞﾌﾞﾙﾘｰﾁ
                strData01First_02 &= Change10To2(GetPLCRetuFromFRAC_RETU(objTPRG_TRK_BUF_First_TO.FRAC_RETU), 2)        '列
                strData01First_02 &= strGouki                                            '号機


                '*************************************************
                'ﾃﾞｰﾀ2(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData02First_02 = ""
                strData02First_02 &= "00"                                                '固定
                strData02First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_REN, 6)   '連
                strData02First_02 &= "0"                                                 'ENDﾌﾗｸﾞ
                strData02First_02 &= "0"                                                 '入棚再設定
                strData02First_02 &= "00"                                                '固定
                strData02First_02 &= Change10To2(objTPRG_TRK_BUF_First_TO.FRAC_DAN, 4)   '段


                '*************************************************
                'ﾃﾞｰﾀ3(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData03First_10 = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                     'ｱﾄﾞﾚｽ


            Else
                '(ｼﾝｸﾞﾙ搬送の場合)

                'ﾌｫｰｸ1での搬送に修正
                strData01Second_02 = Mid(strData01Second_02, 1, 3) & "001" & Mid(strData01Second_02, 7)     'ﾍﾟｱ搬送、ﾌｫｰｸ2、ﾌｫｰｸ1      を修正

            End If


            '*************************************************
            'ﾃﾞｰﾀ       結合
            '*************************************************
            Dim strDataComplete As String
            If blnFirst = True _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2041 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2043 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2055 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2057 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2067 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2065 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2053 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2049 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2045 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2913 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2915 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2916 _
               Then
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在していた場合)
                '(もしくは、前後逆転させる場合)
                strDataComplete = TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
            Else
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在しない場合)
                strDataComplete = TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
            End If


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = objTMST_ROUTE.FEQ_ID_TRNS             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD      'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_TRNS, True, objTMST_TRK_FM.XADRS_HANSOU, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川         搬送指示(緊急入庫設定)                                                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川         搬送指示(緊急入庫設定)
    ''' </summary>
    ''' <param name="objTPRG_TRK_BUF_RELAY">搬送中ﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_FM">FMﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPRG_TRK_BUF_TO">TOﾄﾗｯｷﾝｸﾞ</param>
    ''' <param name="objTPLN_CARRY_QUE">搬送指示QUE</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDKinkyuTrns(ByVal objTPRG_TRK_BUF_RELAY As TBL_TPRG_TRK_BUF _
                                       , ByVal objTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF _
                                       , ByVal objTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF _
                                       , ByVal objTPLN_CARRY_QUE As TBL_TPLN_CARRY_QUE _
                                       , ByVal objTMST_ROUTE As TBL_TMST_ROUTE _
                                       )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JOYA And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(親かつﾍﾟｱ搬送の場合)
                Exit Sub
            End If


            '*************************************************
            '付属ﾃﾞｰﾀ取得
            '*************************************************
            '==========================================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(搬送元)        取得
            '==========================================
            Dim objTMST_TRK_FM As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTRK_BUF_NO        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK_FM.GET_TMST_TRK()


            '**************************************************************************************************
            '**************************************************************************************************
            '2ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            '*************************************************
            'ﾃﾞｰﾀ1(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData01Second_02 As String = ""     'ﾃﾞｰﾀ1(親)( 2進数)
            strData01Second_02 &= "0"                                                 '固定
            strData01Second_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
            strData01Second_02 &= "1"                                                 '出庫ﾓｰﾄﾞ
            strData01Second_02 &= IIf(IsNull(objTPLN_CARRY_QUE), "0", "1")            'ﾍﾟｱ搬送
            strData01Second_02 &= "0"                                                 'ﾌｫｰｸ2
            strData01Second_02 &= "0"                                                 'ﾌｫｰｸ1
            strData01Second_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
            strData01Second_02 &= "0"                                                 '固定
            strData01Second_02 &= "0"                                                 'ﾀﾞﾌﾞﾙﾘｰﾁ
            strData01Second_02 &= "00"                                                '列
            strData01Second_02 &= "0000"                                              '号機


            '*************************************************
            'ﾃﾞｰﾀ2(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData02Second_02 As String = ""     'ﾃﾞｰﾀ2(親)( 2進数)
            strData02Second_02 &= "00"          '固定
            strData02Second_02 &= "000000"      '連
            strData02Second_02 &= "1"           'ENDﾌﾗｸﾞ
            strData02Second_02 &= "0"           '入棚再設定
            strData02Second_02 &= "00"          '固定
            strData02Second_02 &= "0000"        '段


            '*************************************************
            'ﾃﾞｰﾀ3(2ﾊﾟﾚｯﾄ目)        作成
            '*************************************************
            Dim strData03Second_10 As String = ""                                      'ﾃﾞｰﾀ3(親)(10進数)
            strData03Second_10 = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                      'ｱﾄﾞﾚｽ


            '**************************************************************************************************
            '**************************************************************************************************
            '1ﾊﾟﾚｯﾄ目のﾃﾞｰﾀを作成
            '**************************************************************************************************
            '**************************************************************************************************
            Dim strData01First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ1( 2進数)
            Dim strData02First_02 As String = StrDup(16, "0")       'ﾃﾞｰﾀ2( 2進数)
            Dim strData03First_10 As String = "0"                   'ﾃﾞｰﾀ3(10進数)
            Dim blnFirst As Boolean = False                         '1ﾊﾟﾚｯﾄ目の存在ﾌﾗｸﾞ


            If objTPLN_CARRY_QUE.XOYAKO_KUBUN = XOYAKO_KUBUN_JKO And IsNotNull(objTPLN_CARRY_QUE.XPALLET_ID_AITE) Then
                '(親かつﾍﾟｱ搬送かつ1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞがある場合)
                blnFirst = True


                '*************************************************
                'ﾃﾞｰﾀ1(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData01First_02 = ""
                strData01First_02 &= "0"                                                 '固定
                strData01First_02 &= "1"                                                 '入庫ﾓｰﾄﾞ
                strData01First_02 &= "1"                                                 '出庫ﾓｰﾄﾞ
                strData01First_02 &= "1"                                                 'ﾍﾟｱ搬送
                strData01First_02 &= "0"                                                 'ﾌｫｰｸ2
                strData01First_02 &= "0"                                                 'ﾌｫｰｸ1
                strData01First_02 &= Change10To2(objTMST_TRK_FM.XLS_NO, 2)               'L/S番号
                strData01First_02 &= "0"                                                 '固定
                strData01First_02 &= "0"                                                 'ﾀﾞﾌﾞﾙﾘｰﾁ
                strData01First_02 &= "00"                                                '列
                strData01First_02 &= "0000"                                              '号機


                '*************************************************
                'ﾃﾞｰﾀ2(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData02First_02 = ""
                strData02First_02 &= "00"               '固定
                strData02First_02 &= "000000"           '連
                strData02First_02 &= "0"                'ENDﾌﾗｸﾞ
                strData02First_02 &= "0"                '入棚再設定
                strData02First_02 &= "00"               '固定
                strData02First_02 &= "0000"             '段


                '*************************************************
                'ﾃﾞｰﾀ3(1ﾊﾟﾚｯﾄ目)        作成
                '*************************************************
                strData03First_10 = objTPRG_TRK_BUF_TO.FTRNS_ADDRESS                     'ｱﾄﾞﾚｽ


            Else
                '(ｼﾝｸﾞﾙ搬送の場合)

                'ﾌｫｰｸ1での搬送に修正
                strData01Second_02 = Mid(strData01Second_02, 1, 3) & "000" & Mid(strData01Second_02, 7)     'ﾍﾟｱ搬送、ﾌｫｰｸ2、ﾌｫｰｸ1      を修正

            End If


            '*************************************************
            'ﾃﾞｰﾀ       結合
            '*************************************************
            Dim strDataComplete As String
            If blnFirst = True _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2041 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2043 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2055 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2057 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2067 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2065 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2053 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2049 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2045 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2913 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2915 _
               Or objTPRG_TRK_BUF_FM.FTRK_BUF_NO = FTRK_BUF_NO_J2916 _
               Then
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在していた場合)
                '(もしくは、前後逆転させる場合)
                strDataComplete = TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
            Else
                '(1ﾊﾟﾚｯﾄ目のﾄﾗｯｷﾝｸﾞが存在しない場合)
                strDataComplete = TO_STRING(Change2To10(strData01Second_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02Second_02))
                strDataComplete &= "," & strData03Second_10
                strDataComplete &= "," & TO_STRING(Change2To10(strData01First_02))
                strDataComplete &= "," & TO_STRING(Change2To10(strData02First_02))
                strDataComplete &= "," & strData03First_10
            End If


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = objTMST_ROUTE.FEQ_ID_TRNS             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD      'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_TRNS, True, objTMST_TRK_FM.XADRS_HANSOU, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川         到着予定数                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川         到着予定数
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intNumSingle">到着予定数(ｼﾝｸﾞﾙ搬送)</param>
    ''' <param name="intNumPair">到着予定数(ﾍﾟｱ搬送)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDYotei(ByVal intFTRK_BUF_NO As Integer _
                                  , ByVal intNumSingle As Integer _
                                  , Optional ByVal intNumPair As Integer = 0 _
                                  )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ            取得
            '*************************************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
            objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            objTMST_TRK.GET_TMST_TRK()                                       '取得


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(objTMST_TRK.XADRS_YOTEI01)     '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD                              'ｺﾏﾝﾄﾞID
            If IsNotNull(objTMST_TRK.XADRS_YOTEI01) Then Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_YOTEI, True, objTMST_TRK.XADRS_YOTEI01, intNumSingle)
            If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JW_YOTEI, True, objTMST_TRK.XADRS_YOTEI02, intNumPair)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  Melsec       車番表示                                                                "
    '''**********************************************************************************************
    ''' <summary>
    ''' Melsec       車番表示
    ''' </summary>
    ''' <param name="intXBERTH_GROUP">ﾊﾞｰｽｸﾞﾙｰﾌﾟ</param>
    ''' <param name="intXSYARYOU_NO">車輌番号</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDDispSyaban(ByVal intXBERTH_GROUP As Integer _
                                       , ByVal intXSYARYOU_NO As Integer _
                                       )
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*************************************************
            '出荷ﾊﾞｰｽ状況           取得
            '*************************************************
            Dim objAryXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objAryXSTS_BERTH.XBERTH_GROUP = intXBERTH_GROUP                'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
            intRet = objAryXSTS_BERTH.GET_XSTS_BERTH_ANY()                 '取得
            If intRet = RetCode.OK Then
                For Each objXSTS_BERTH As TBL_XSTS_BERTH In objAryXSTS_BERTH.ARYME
                    '(ﾙｰﾌﾟ:ｸﾞﾙｰﾌﾟ内のﾊﾞｰｽ数)


                    '*************************************************
                    '出荷ﾊﾞｰｽ状況           取得
                    '*************************************************
                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
                    objTSTS_EQ_CTRL.FEQ_ID = objXSTS_BERTH.XBERTH_NO        '設備ID
                    objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()


                    '*************************************************
                    '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾜｰﾄﾞ)
                    '*************************************************
                    If objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SOFF Then
                        '(切離されていない場合)
                        If IsNotNull(objXSTS_BERTH.XEQ_ID_B_SYABAN) Then
                            '(設定するﾚｼﾞｽﾀが存在する場合)
                            Call SendYasukawaMelsec_IDMainteWord(objXSTS_BERTH.XEQ_ID_B_SYABAN, FTEXT_ID_JW_SYABAN, intXSYARYOU_NO)
                        End If
                    End If


                Next
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  Melsec       編成№表示                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' Melsec       編成№表示
    ''' </summary>
    ''' <param name="intXBERTH_GROUP">出庫CV配列</param>
    ''' <param name="strXHENSEI_NO_OYA">親編成No.</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDDispHensei(ByVal intXBERTH_GROUP As Integer _
                                       , ByVal strXHENSEI_NO_OYA As String _
                                       )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '************************************************
            '出庫CV配列                   取得
            '************************************************
            Dim intAryOutCV() As Integer = Nothing                              '出庫CV
            Call GetintAryOutCV(intAryOutCV, intXBERTH_GROUP)


            '*************************************************
            '出荷ｺﾝﾍﾞﾔ状況              取得
            '*************************************************
            For Each intOutCV As Integer In intAryOutCV
                '(ﾙｰﾌﾟ:ｸﾞﾙｰﾌﾟ内のﾊﾞｰｽ数)


                '*************************************************
                '出荷ｺﾝﾍﾞﾔ状況              取得
                '*************************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                objTMST_TRK.FTRK_BUF_NO = intOutCV              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_TRK.GET_TMST_TRK()                      '取得
                If IsNotNull(objTMST_TRK.XEQ_ID_B_HENSEI) Then
                    '(設定するﾚｼﾞｽﾀが存在する場合)

                    Call SendYasukawaMelsec_IDMainteWord(objTMST_TRK.XEQ_ID_B_HENSEI, FTEXT_ID_JW_HENSEI, TO_INTEGER(strXHENSEI_NO_OYA))

                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  Melsec       出庫完了ﾗﾝﾌﾟ                                                            "
    '''**********************************************************************************************
    ''' <summary>
    ''' Melsec       出庫完了ﾗﾝﾌﾟ
    ''' </summary>
    ''' <param name="intXBERTH_GROUP">出庫CV配列</param>
    ''' <param name="intLamp">ﾗﾝﾌﾟ値</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDDispOutEnd(ByVal intXBERTH_GROUP As Integer _
                                       , ByVal intLamp As Integer _
                                       )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '************************************************
            '出庫CV配列                   取得
            '************************************************
            Dim intAryOutCV() As Integer = Nothing                              '出庫CV
            Call GetintAryOutCV(intAryOutCV, intXBERTH_GROUP)


            '*************************************************
            '出荷ｺﾝﾍﾞﾔ状況              取得
            '*************************************************
            For Each intOutCV As Integer In intAryOutCV
                '(ﾙｰﾌﾟ:ｸﾞﾙｰﾌﾟ内のﾊﾞｰｽ数)


                '*************************************************
                '出荷ｺﾝﾍﾞﾔ状況              取得
                '*************************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                objTMST_TRK.FTRK_BUF_NO = intOutCV              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_TRK.GET_TMST_TRK()                      '取得
                If IsNotNull(objTMST_TRK.XEQ_ID_B_OUTEND) Then
                    '(設定するﾚｼﾞｽﾀが存在する場合)

                    Call SendYasukawaMelsec_IDMainteBit(objTMST_TRK.XEQ_ID_B_OUTEND, FTEXT_ID_JW_OUTEND, intLamp)

                End If

            Next


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  Melsec       ﾛｰﾀﾞｰﾓｰﾄﾞ                                                               "
    '''**********************************************************************************************
    ''' <summary>
    ''' Melsec       ﾛｰﾀﾞｰﾓｰﾄﾞ
    ''' </summary>
    ''' <param name="intXSYARYOU_MODE">ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDLoaderMode(ByVal intXSYARYOU_MODE As Integer _
                                       , ByVal strAdrs As String _
                                       , ByVal strSBit As String _
                                       )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '****************************************
            'ﾁｪｯｸ
            '****************************************
            'NOP


            '*************************************************
            'ﾛｰﾀﾞﾓｰﾄﾞをMelsec用値に変換
            '*************************************************
            Dim strBit_15 As String     '× 1 のﾋﾞｯﾄ
            Dim strBit_14 As String     '× 2 のﾋﾞｯﾄ
            Dim strBit_13 As String     '× 4 のﾋﾞｯﾄ
            Dim strBit_12 As String     '× 8 のﾋﾞｯﾄ
            Dim strBit_11 As String     '×10 のﾋﾞｯﾄ
            Dim strBit_10 As String     '×20 のﾋﾞｯﾄ
            Dim strBit_09 As String     '×40 のﾋﾞｯﾄ
            Dim strBit_08 As String     '×80 のﾋﾞｯﾄ
            Dim intTemp01 As Integer = intXSYARYOU_MODE
            '80のﾋﾞｯﾄ取得
            strBit_08 = TO_STRING(intTemp01 \ 80)
            intTemp01 = intTemp01 Mod 80
            '40のﾋﾞｯﾄ取得
            strBit_09 = TO_STRING(intTemp01 \ 40)
            intTemp01 = intTemp01 Mod 40
            '20のﾋﾞｯﾄ取得
            strBit_10 = TO_STRING(intTemp01 \ 20)
            intTemp01 = intTemp01 Mod 20
            '10のﾋﾞｯﾄ取得
            strBit_11 = TO_STRING(intTemp01 \ 10)
            intTemp01 = intTemp01 Mod 10
            ' 8のﾋﾞｯﾄ取得
            strBit_12 = TO_STRING(intTemp01 \ 8)
            intTemp01 = intTemp01 Mod 8
            ' 4のﾋﾞｯﾄ取得
            strBit_13 = TO_STRING(intTemp01 \ 4)
            intTemp01 = intTemp01 Mod 4
            ' 2のﾋﾞｯﾄ取得
            strBit_14 = TO_STRING(intTemp01 \ 2)
            intTemp01 = intTemp01 Mod 2
            ' 1のﾋﾞｯﾄ取得
            strBit_15 = TO_STRING(intTemp01 \ 1)
            'ﾜｰﾄﾞとしてのﾃﾞｰﾀ作成
            Dim intWord As Integer      '書込むﾜｰﾄﾞ値
            Dim strTemp As String = ""
            strTemp &= strBit_15
            strTemp &= strBit_14
            strTemp &= strBit_13
            strTemp &= strBit_12
            strTemp &= strBit_11
            strTemp &= strBit_10
            strTemp &= strBit_09
            strTemp &= strBit_08
            strTemp &= strSBit
            strTemp &= "0000000"
            intWord = Change2To10(strTemp)


            '*************************************************
            '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾜｰﾄﾞ)
            '*************************************************
            Call SendYasukawaMelsec_IDMainteWord(strAdrs, FTEXT_ID_JW_ETC, intWord)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
    ''''**********************************************************************************************
    '''' <summary>
    '''' Melsec       出庫完了ﾗﾝﾌﾟ
    '''' </summary>
    '''' <param name="intXBERTH_GROUP">ﾊﾞｰｽｸﾞﾙｰﾌﾟ</param>
    '''' <param name="intXSYARYOU_NO">車輌番号</param>
    '''' <remarks></remarks>
    ''''**********************************************************************************************
    'Public Sub SendYasukawa_IDLoaderMode(ByVal intXBERTH_GROUP As Integer _
    '                                   , ByVal intXSYARYOU_NO As Integer _
    '                                   , ByVal intSyukkaHikiateMode As SyukkaHikiateMode _
    '                                   )
    '    Dim intRet As RetCode                   '戻り値
    '    'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
    '    Try
    '        Dim strFDENBUN As String = ""       '送信電文


    '        '****************************************
    '        'ﾁｪｯｸ
    '        '****************************************
    '        If intSyukkaHikiateMode <> SyukkaHikiateMode.Loader02 Then Exit Sub


    '        '*************************************************
    '        '出荷ﾊﾞｰｽ状況           取得
    '        '*************************************************
    '        Dim objAryXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
    '        objAryXSTS_BERTH.XBERTH_GROUP = intXBERTH_GROUP                'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
    '        intRet = objAryXSTS_BERTH.GET_XSTS_BERTH_ANY()                 '取得
    '        If intRet = RetCode.OK Then


    '            '*************************************************
    '            '書込ﾚｼﾞｽﾀ              取得
    '            '*************************************************
    '            Dim strAdrs As String = ""
    '            Select Case objAryXSTS_BERTH.ARYME(0).XBERTH_NO
    '                Case XBERTH_NO_JX01 _
    '                   , XBERTH_NO_JX02 _
    '                   , XBERTH_NO_JX03
    '                    strAdrs = FEQ_ID_JOTHMFF_D000105
    '                Case XBERTH_NO_JX04 _
    '                   , XBERTH_NO_JX05 _
    '                   , XBERTH_NO_JX06
    '                    strAdrs = FEQ_ID_JOTHMFF_D000106
    '                Case Else : Exit Sub
    '            End Select


    '            '*************************************************
    '            '車輌ﾏｽﾀ            取得
    '            '*************************************************
    '            Dim objXMST_SYARYOU As New TBL_XMST_SYARYOU(Owner, ObjDb, ObjDbLog)
    '            objXMST_SYARYOU.XSYARYOU_NO = intXSYARYOU_NO        '車輌番号
    '            objXMST_SYARYOU.GET_XMST_SYARYOU()                  '取得


    '            '*************************************************
    '            'ﾛｰﾀﾞﾓｰﾄﾞをMelsec用値に変換
    '            '*************************************************
    '            Dim strBit_15 As String     '× 1 のﾋﾞｯﾄ
    '            Dim strBit_14 As String     '× 2 のﾋﾞｯﾄ
    '            Dim strBit_13 As String     '× 4 のﾋﾞｯﾄ
    '            Dim strBit_12 As String     '× 8 のﾋﾞｯﾄ
    '            Dim strBit_11 As String     '×10 のﾋﾞｯﾄ
    '            Dim strBit_10 As String     '×20 のﾋﾞｯﾄ
    '            Dim strBit_09 As String     '×40 のﾋﾞｯﾄ
    '            Dim strBit_08 As String     '×80 のﾋﾞｯﾄ
    '            Dim intTemp01 As Integer = objXMST_SYARYOU.XSYARYOU_MODE
    '            '80のﾋﾞｯﾄ取得
    '            strBit_08 = TO_STRING(intTemp01 \ 80)
    '            intTemp01 = intTemp01 Mod 80
    '            '40のﾋﾞｯﾄ取得
    '            strBit_09 = TO_STRING(intTemp01 \ 40)
    '            intTemp01 = intTemp01 Mod 40
    '            '20のﾋﾞｯﾄ取得
    '            strBit_10 = TO_STRING(intTemp01 \ 20)
    '            intTemp01 = intTemp01 Mod 20
    '            '10のﾋﾞｯﾄ取得
    '            strBit_11 = TO_STRING(intTemp01 \ 10)
    '            intTemp01 = intTemp01 Mod 10
    '            ' 8のﾋﾞｯﾄ取得
    '            strBit_12 = TO_STRING(intTemp01 \ 8)
    '            intTemp01 = intTemp01 Mod 8
    '            ' 4のﾋﾞｯﾄ取得
    '            strBit_13 = TO_STRING(intTemp01 \ 4)
    '            intTemp01 = intTemp01 Mod 4
    '            ' 2のﾋﾞｯﾄ取得
    '            strBit_14 = TO_STRING(intTemp01 \ 2)
    '            intTemp01 = intTemp01 Mod 2
    '            ' 1のﾋﾞｯﾄ取得
    '            strBit_15 = TO_STRING(intTemp01 \ 1)
    '            'ﾜｰﾄﾞとしてのﾃﾞｰﾀ作成
    '            Dim intWord As Integer      '書込むﾜｰﾄﾞ値
    '            Dim strTemp As String = ""
    '            strTemp &= strBit_15
    '            strTemp &= strBit_14
    '            strTemp &= strBit_13
    '            strTemp &= strBit_12
    '            strTemp &= strBit_11
    '            strTemp &= strBit_10
    '            strTemp &= strBit_09
    '            strTemp &= strBit_08
    '            strTemp &= "00000000"
    '            intWord = Change2To10(strTemp)


    '            '*************************************************
    '            '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾜｰﾄﾞ)
    '            '*************************************************
    '            Call SendYasukawaMelsec_IDMainteWord(strAdrs, FTEXT_ID_JW_ETC, intWord)


    '        End If


    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Throw ex
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
    '        Throw ex
    '    End Try
    'End Sub
#End Region
#Region "  Melsec       異常ﾗﾝﾌﾟﾋﾞｯﾄ更新                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' Melsec       異常ﾗﾝﾌﾟﾋﾞｯﾄ更新
    ''' </summary>
    ''' <param name="strFMSG_ID">ﾒｯｾｰｼﾞID</param>
    ''' <param name="intBit">更新するﾋﾞｯﾄﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawa_IDErrLamp(ByVal strFMSG_ID As String _
                                    , ByVal intBit As Integer _
                                    )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '****************************************
            'ﾁｪｯｸ
            '****************************************
            'NOP


            '*************************************************
            '異常ﾋﾞｯﾄ検索
            '*************************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)
            Dim strAryFMSG_ID_SJ000000_041() As String = Split(objTPRG_SYS_HEN.SJ000000_041, ",")
            Dim strAryFMSG_ID_SJ000000_042() As String = Split(objTPRG_SYS_HEN.SJ000000_042, ",")
            Dim strAryFMSG_ID_SJ000000_043() As String = Split(objTPRG_SYS_HEN.SJ000000_043, ",")
            Dim strAdrs As String   '異常ﾋﾞｯﾄｱﾄﾞﾚｽ
            If -1 <> ArrayFindData(strAryFMSG_ID_SJ000000_041, strFMSG_ID) Then
                strAdrs = FEQ_ID_JOTHMFF_D000104_13
            ElseIf -1 <> ArrayFindData(strAryFMSG_ID_SJ000000_042, strFMSG_ID) Then
                strAdrs = FEQ_ID_JOTHMFF_D000104_14
            ElseIf -1 <> ArrayFindData(strAryFMSG_ID_SJ000000_043, strFMSG_ID) Then
                strAdrs = FEQ_ID_JOTHMFF_D000104_15
            Else
                strAdrs = FEQ_ID_JOTHMFF_D000104_15
            End If


            '*************************************************
            '安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾋﾞｯﾄ)
            '*************************************************
            Call SendYasukawaMelsec_IDMainteBit(strAdrs, FTEXT_ID_JW_ETC, intBit)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾜｰﾄﾞ)                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾜｰﾄﾞ)
    ''' </summary>
    ''' <param name="strFEQ_ID_ENUM">設備ID列挙</param>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="strDataComplete">送信ﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawaMelsec_IDMainteWord(ByVal strFEQ_ID_ENUM As String _
                                             , ByVal strFTEXT_ID As String _
                                             , ByVal strDataComplete As String _
                                             )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            Dim strFDENBUN As String = ""       '送信電文
            Dim strFEQ_ID As String = ""        '設備ID
            Dim strFEQ_ID_ARY() As String
            strFEQ_ID_ARY = Split(strFEQ_ID_ENUM, KUGIRI01)


            '************************************************************************
            'ﾛｰｶﾙ設備ID           → 設備ID(送信PLC)          変換
            '************************************************************************
            strFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(strFEQ_ID_ARY(0))


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = strFEQ_ID                             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD      'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, strFTEXT_ID, True, strFEQ_ID_ENUM, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾋﾞｯﾄ)                                                         "
    '''**********************************************************************************************
    ''' <summary>
    ''' 安川 Melsec  PLCﾒﾝﾃﾅﾝｽ(ﾋﾞｯﾄ)
    ''' </summary>
    ''' <param name="strFEQ_ID_ENUM">設備ID列挙</param>
    ''' <param name="strFTEXT_ID">ﾃｷｽﾄID</param>
    ''' <param name="strDataComplete">送信ﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendYasukawaMelsec_IDMainteBit(ByVal strFEQ_ID_ENUM As String _
                                            , ByVal strFTEXT_ID As String _
                                            , ByVal strDataComplete As String _
                                            )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try

            Dim strFDENBUN As String = ""       '送信電文
            Dim strFEQ_ID As String = ""        '設備ID
            Dim strFEQ_ID_ARY() As String
            strFEQ_ID_ARY = Split(strFEQ_ID_ENUM, KUGIRI01)


            '************************************************************************
            'ﾛｰｶﾙ設備ID           → 設備ID(送信PLC)          変換
            '************************************************************************
            strFEQ_ID = GetXEQ_ID_SendFromFEQ_ID_LOCAL(strFEQ_ID_ARY(0))


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = strFEQ_ID                             '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_BIT       'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, strFTEXT_ID, True, strFEQ_ID_ENUM, strDataComplete)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

    '車輌ｺﾝﾄﾛｰﾗ系
#Region "  車輌ｺﾝﾄﾛｰﾗ   ｶｰﾄﾞﾘｰﾀﾞ読込応答                                                        "
    '''**********************************************************************************************
    ''' <summary>
    ''' 車輌ｺﾝﾄﾛｰﾗ   ｶｰﾄﾞﾘｰﾀﾞ読込応答
    ''' </summary>
    ''' <param name="strFDENBUN">送信電文</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendCar_IDJS_CARD01(ByVal strFDENBUN As String)
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            'NOP


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = FEQ_ID_JSYS0101                       '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SOT                  'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JS_CARD01)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region
#Region "  車輌ｺﾝﾄﾛｰﾗ   表示盤出力                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' 車輌ｺﾝﾄﾛｰﾗ   表示盤出力
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendCar_IDJS_CARD02()
        Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '*************************************************
            'ﾁｪｯｸ
            '*************************************************
            'NOP


            '*************************************************
            '初期設定
            '*************************************************
            Dim strArySyaryou(5) As String
            For ii As Integer = 0 To UBound(strArySyaryou)
                strArySyaryou(ii) = "40_40_40_40"
            Next



            '*************************************************
            '出荷ﾊﾞｰｽ状況           取得
            '*************************************************
            Dim objAryXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            objAryXSTS_BERTH.WHERE = "   AND XBERTH_NO IN ('" & XBERTH_NO_JX01 & "', '" & XBERTH_NO_JX02 & "', '" & XBERTH_NO_JX03 & "', '" & XBERTH_NO_JX04 & "', '" & XBERTH_NO_JX05 & "', '" & XBERTH_NO_JX06 & "') "
            objAryXSTS_BERTH.ORDER_BY = "   XBERTH_NO "
            objAryXSTS_BERTH.GET_XSTS_BERTH_ANY()
            For ii As Integer = 0 To UBound(objAryXSTS_BERTH.ARYME)
                '(ﾙｰﾌﾟ:ﾄﾗｯｸﾛｰﾀﾞ数)


                If IsNotNull(objAryXSTS_BERTH.ARYME(ii).XSYUKKA_D) And IsNotNull(objAryXSTS_BERTH.ARYME(ii).XHENSEI_NO) Then
                    '(出荷日、編成№が設定されていた場合)


                    '*************************************************
                    '出荷指示               取得
                    '*************************************************
                    Dim objAryXPLN_OUT As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                    objAryXPLN_OUT.XSYUKKA_D = objAryXSTS_BERTH.ARYME(ii).XSYUKKA_D     '出荷日
                    objAryXPLN_OUT.XHENSEI_NO = objAryXSTS_BERTH.ARYME(ii).XHENSEI_NO   '編成No.
                    intRet = objAryXPLN_OUT.GET_XPLN_OUT_ANY()                          '取得
                    If intRet = RetCode.OK Then
                        '(見つかった場合)
                        If IsNotNull(objAryXPLN_OUT.ARYME(0).XSYARYOU_NO) Then
                            '(車輌№がｾｯﾄされている場合)

                            '===============================================
                            '車輌№をIBM EBCDICでﾊﾞｲﾄ変換
                            '===============================================
                            Dim bytAryRet() As Byte
                            bytAryRet = Text.Encoding.GetEncoding(20290).GetBytes(ZERO_PAD(TO_INTEGER(objAryXPLN_OUT.ARYME(0).XSYARYOU_NO), 4))
                            For jj As Integer = 0 To UBound(bytAryRet)
                                If jj = 0 Then
                                    strArySyaryou(ii) = Change10To16(bytAryRet(jj), 2).ToUpper
                                Else
                                    strArySyaryou(ii) &= "_" & Change10To16(bytAryRet(jj), 2).ToUpper
                                End If
                            Next

                        End If
                    End If


                End If


            Next


            '*************************************************
            '車輌№がｾｯﾄされているか否か
            '*************************************************
            Dim blnSyaryouSet As Boolean = False        '車輌№がｾｯﾄされているか否かのﾌﾗｸﾞ
            For ii As Integer = 0 To UBound(strArySyaryou)
                If strArySyaryou(ii) <> "40_40_40_40" Then blnSyaryouSet = True : Exit For
            Next



            '*************************************************
            '電文作成
            '*************************************************
            Dim strFDENBUN As String = ""
            If blnSyaryouSet = True Then
                '(車輌№がｾｯﾄされている場合)

                strFDENBUN = ""
                strFDENBUN &= "F2_F0"                   '制御ｺｰﾄﾞ
                strFDENBUN &= "_" & "F0_F0_F0_F1"       'ﾀﾞﾐｰ
                strFDENBUN &= "_" & "F0_F0_F0_F1"       '出荷順位X
                strFDENBUN &= "_" & strArySyaryou(0)    'ﾊﾞｰｽ 1用車輌番号
                strFDENBUN &= "_" & strArySyaryou(1)    'ﾊﾞｰｽ 2用車輌番号
                strFDENBUN &= "_" & strArySyaryou(2)    'ﾊﾞｰｽ 3用車輌番号
                strFDENBUN &= "_" & strArySyaryou(3)    'ﾊﾞｰｽ 4用車輌番号
                strFDENBUN &= "_" & strArySyaryou(4)    'ﾊﾞｰｽ 5用車輌番号
                strFDENBUN &= "_" & strArySyaryou(5)    'ﾊﾞｰｽ 6用車輌番号
                strFDENBUN &= "_" & "40_40_40_40"       'ﾊﾞｰｽ 7用車輌番号
                strFDENBUN &= "_" & "40_40_40_40"       'ﾊﾞｰｽ 8用車輌番号
                strFDENBUN &= "_" & "40_40_40_40"       'ﾊﾞｰｽ 9用車輌番号
                strFDENBUN &= "_" & "F0_F0_F0_F0"       'ﾊﾞｰｽ10用車輌番号
                strFDENBUN &= "_" & "F0_F0_F0_F0"       '出荷順位Y
                strFDENBUN &= "_" & "40_40_40_40"       '出荷順位Z
                strFDENBUN &= "_" & "40_40_40_40_40_40" 'ﾀﾞﾐｰ

            Else
                '(車輌№がｾｯﾄされていない場合)

                strFDENBUN = ""
                strFDENBUN &= "F2_F0"              '制御ｺｰﾄﾞ
                strFDENBUN &= "_" & "00_00_00_00"  'ﾀﾞﾐｰ
                strFDENBUN &= "_" & "F0_F0_F0_F1"  '出荷順位X
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 1用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 2用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 3用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 4用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 5用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 6用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 7用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 8用車輛番号
                strFDENBUN &= "_" & "40_40_40_40"  'ﾊﾞｰｽ 9用車輛番号
                strFDENBUN &= "_" & "F0_F0_F0_F0"  'ﾊﾞｰｽ10用車輛番号
                strFDENBUN &= "_" & "F0_F0_F0_F0"  '出荷順位Y
                strFDENBUN &= "_" & "40_40_40_40"  '出荷順位Z
                strFDENBUN &= "_" & "40_40_40_40_40_40"    'ﾀﾞﾐｰ

            End If


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = FEQ_ID_JSYS0101                       '設備ID
            mFCOMMAND_ID = FCOMMAND_ID_SOT                  'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN, FTEXT_ID_JS_CARD02)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region


    '別ﾌﾟﾛｾｽ
#Region "  印字(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)、ｴｸｾﾙ作成(日報)、ｴｸｾﾙ作成(月報)                                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' 印字(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)、ｴｸｾﾙ作成(日報)、ｴｸｾﾙ作成(月報)
    ''' </summary>
    ''' <param name="strFCOMMAND_ID">ｺﾏﾝﾄﾞID</param>
    ''' <param name="strFDENBUN_PRM1">電文ﾊﾟﾗﾒｰﾀ1</param>
    ''' <param name="strFDENBUN_PRM2">電文ﾊﾟﾗﾒｰﾀ2</param>
    ''' <param name="strFDENBUN_PRM3">電文ﾊﾟﾗﾒｰﾀ3</param>
    ''' <param name="strFDENBUN_PRM4">電文ﾊﾟﾗﾒｰﾀ4</param>
    ''' <param name="strFDENBUN_PRM5">電文ﾊﾟﾗﾒｰﾀ5</param>
    ''' <param name="strFDENBUN_PRM6">電文ﾊﾟﾗﾒｰﾀ6</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub SendOther_IDOther(ByVal strFCOMMAND_ID As String _
                               , Optional ByVal strFDENBUN_PRM1 As String = Nothing _
                               , Optional ByVal strFDENBUN_PRM2 As String = Nothing _
                               , Optional ByVal strFDENBUN_PRM3 As String = Nothing _
                               , Optional ByVal strFDENBUN_PRM4 As String = Nothing _
                               , Optional ByVal strFDENBUN_PRM5 As String = Nothing _
                               , Optional ByVal strFDENBUN_PRM6 As String = Nothing _
                               )
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try
            Dim strFDENBUN As String = ""       '送信電文


            '*********************************************
            '搬送制御送信IFへ電文追加
            '*********************************************
            mFEQ_ID = FEQ_ID_JSYS0201                       '設備ID
            mFCOMMAND_ID = strFCOMMAND_ID                   'ｺﾏﾝﾄﾞID
            Call InsertTLIF_TRNS_SEND(strFDENBUN _
                                    , "" _
                                    , True _
                                    , strFDENBUN_PRM1 _
                                    , strFDENBUN_PRM2 _
                                    , strFDENBUN_PRM3 _
                                    , strFDENBUN_PRM4 _
                                    , strFDENBUN_PRM5 _
                                    , strFDENBUN_PRM6 _
                                    )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Throw ex
        End Try
    End Sub
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
