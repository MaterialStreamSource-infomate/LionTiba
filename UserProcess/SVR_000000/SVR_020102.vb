'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】設備状態受信処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_020102
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
#End Region
#Region "  ｸﾗｽ変数定義                                                                          "
    Private mobjTLIF_TRNS_RECV As TBL_TLIF_TRNS_RECV                 '
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property objTLIF_TRNS_RECV() As TBL_TLIF_TRNS_RECV
        Get
            Return mobjTLIF_TRNS_RECV
        End Get
        Set(ByVal Value As TBL_TLIF_TRNS_RECV)
            mobjTLIF_TRNS_RECV = Value
        End Set
    End Property
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
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function ExecCmdFunction() As Integer
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '************************
            '初期処理
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SSTART & "機器状態報告  [受信電文:" & objTLIF_TRNS_RECV.FDENBUN & "]")


            ''*****************************************************
            ''受信電文分解
            ''*****************************************************
            'Dim objTel As New clsTelegram(CONFIG_TELEGRAM_AGC)
            'objTel.FORMAT_ID = FORMAT_AGC_30                        'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            'objTel.TELEGRAM_PARTITION = mobjTLIF_TRNS_RECV.FDENBUN  '分割する電文ｾｯﾄ
            'objTel.PARTITION()                                      '電文分割

            'Dim strKikiJoutai As String
            'strKikiJoutai = objTel.SELECT_DATA("AGCREPORT_KIKI_STATE")  '報告機器状態
            'strKikiJoutai = RTrim(strKikiJoutai)
            'For ii As Integer = 0 To 32
            '    '(ﾙｰﾌﾟ:14×33ﾊﾞｲﾄ)


            '    '************************
            '    '文字数ﾁｪｯｸ
            '    '************************
            '    If GET_BYTE_LENGTH_STRING(strKikiJoutai) < (14 * ii) + 14 Then
            '        Exit For
            '    End If


            '    '************************
            '    'さらに分解
            '    '************************
            '    Dim strKisyuCode As String = Mid(strKikiJoutai, (14 * ii) + 1, 2)       '機種ｺｰﾄﾞ
            '    Dim strGoukiNo As String = Mid(strKikiJoutai, (14 * ii) + 3, 4)         '号機No
            '    Dim strFEQ_STS As String = Mid(strKikiJoutai, (14 * ii) + 7, 1)         '設備状態
            '    Dim strFEQ_STOP_CD As String = Mid(strKikiJoutai, (14 * ii) + 8, 7)     '停止要因ｺｰﾄﾞ
            '    strGoukiNo = ZERO_PAD(strGoukiNo, 4)                    '号機No
            '    strFEQ_STS = TO_INTEGER(strFEQ_STS)                     '設備状態
            '    strFEQ_STOP_CD = TO_STRING(TO_INTEGER(strFEQ_STOP_CD))  '停止要因ｺｰﾄﾞ


            '    '************************
            '    '設備状況の特定
            '    '************************
            '    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            '    objTSTS_EQ_CTRL.FEQ_ID_LOCAL = strKisyuCode & "_" & strGoukiNo      'ﾛｰｶﾙ設備ID
            '    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '特定


            '    '************************
            '    '設備状況の更新
            '    '************************
            '    objTSTS_EQ_CTRL.FEQ_STS = strFEQ_STS            '設備状態
            '    objTSTS_EQ_CTRL.FEQ_STOP_CD = strFEQ_STOP_CD    '停止要因ｺｰﾄﾞ
            '    objTSTS_EQ_CTRL.FUPDATE_DT = Now                '更新日時
            '    objTSTS_EQ_CTRL.UPDATE_TSTS_EQ_CTRL()           '更新


            '    '************************
            '    '設備異常ﾛｸﾞ登録
            '    '************************
            '    If objTSTS_EQ_CTRL.FEQ_STS = 2 Then
            '        '(故障中の場合)

            '        '====================
            '        '設備異常ﾛｸﾞ登録
            '        '====================
            '        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
            '        objTLOG_EQ_ERROR.FHASSEI_DT = objTLIF_TRNS_RECV.FENTRY_DT                   '発生日時
            '        objTLOG_EQ_ERROR.FHUKKI_DT = DEFAULT_DATE                                   '復旧日時
            '        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
            '        objTLOG_EQ_ERROR.FEQ_STS = objTSTS_EQ_CTRL.FEQ_STS                          '設備状態
            '        objTLOG_EQ_ERROR.FEQ_STOP_CD = strFEQ_STOP_CD                               '停止ｺｰﾄﾞ
            '        objTLOG_EQ_ERROR.ADD_TLOG_EQ_ERROR_SEQ()                                    '登録

            '    Else
            '        '(正常 の場合)

            '        '====================
            '        '設備異常ﾛｸﾞ更新
            '        '====================
            '        Dim objTLOG_EQ_ERROR As New TBL_TLOG_EQ_ERROR(Owner, ObjDb, ObjDbLog)       '設備異常ﾛｸﾞ
            '        objTLOG_EQ_ERROR.FEQ_ID = objTSTS_EQ_CTRL.FEQ_ID                            '設備ID
            '        objTLOG_EQ_ERROR.FHUKKI_DT = objTLIF_TRNS_RECV.FENTRY_DT                    '復旧日時
            '        objTLOG_EQ_ERROR.UPDATE_TLOG_EQ_ERROR_FEQ_ID()                              '登録


            '    End If


            'Next


            '************************
            '正常完了
            '************************
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[受信電文:" & mobjTLIF_TRNS_RECV.FDENBUN & "]" _
                             )


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function

#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
