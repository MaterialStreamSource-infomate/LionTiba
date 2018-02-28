'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾒｯｾｰｼﾞ確認画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports　                                "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_209000

#Region "  共通変数　                               "

    Enum menmListCol
        FLOG_CHECK_FLAG     'ﾒｯｾｰｼﾞﾛｸﾞ.確認済みﾌﾗｸﾞ
        FLOG_CHECK_FLAG_disp     'ﾒｯｾｰｼﾞﾛｸﾞ.確認済みﾌﾗｸﾞ(表示用)
        FHASSEI_DT          'ﾒｯｾｰｼﾞﾛｸﾞ.発生日時
        FMSG_NAIYOU         'ﾒｯｾｰｼﾞﾏｽﾀ.名称
        FMSG_PRM1           'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ1
        FMSG_PRM2           'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ2
        FMSG_PRM3           'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ3
        FMSG_PRM4           'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ4
        FMSG_PRM5           'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ5
        FLOG_NO             'ﾒｯｾｰｼﾞﾛｸﾞ.ﾛｸﾞNo
        FMSG_ID             'ﾒｯｾｰｼﾞﾛｸﾞ.ﾒｯｾｰｼﾞID

        MAXCOL

    End Enum

#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F1(表示更新)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(表示更新) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()
        Try
            '*******************************************************
            'ｸﾞﾘｯﾄﾞ表示
            '*******************************************************
            Call grdListDisplaySub(grdList)


            '*******************************************************
            'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ更新
            '*******************************************************
            Call GetLogMessage()


        Catch ex As Exception
            ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  F4(選択確認)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(選択確認) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '*******************************************************
        '選択確認ｿｹｯﾄ送信     
        '*******************************************************
        Call SendSocket01()


        '*******************************************************
        'ｸﾞﾘｯﾄﾞ再表示
        '*******************************************************
        Call grdListDisplaySub(grdList)


        '*******************************************************
        'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ更新
        '*******************************************************
        Call GetLogMessage()


    End Sub
#End Region
#Region "  F5(一括確認)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(一括確認) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '*******************************************************
        '一括確認ｿｹｯﾄ送信     
        '*******************************************************
        Call SendSocket02()


        '*******************************************************
        'ｸﾞﾘｯﾄﾞ再表示
        '*******************************************************
        Call grdListDisplaySub(grdList)


        '*******************************************************
        'ｵﾍﾟﾚｰｼｮﾝﾒｯｾｰｼﾞ更新
        '*******************************************************
        Call GetLogMessage()


    End Sub
#End Region
#Region "  F8(戻る)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '*******************************************************
        '自身ｸﾛｰｽﾞ
        '*******************************************************
        Me.Close()
        Me.Dispose()


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_CHECK_FLAG FLOG_CHECK_FLAG "  'ﾒｯｾｰｼﾞﾛｸﾞ.確認済みﾌﾗｸﾞ
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP "                            'ﾒｯｾｰｼﾞﾛｸﾞ.確認済みﾌﾗｸﾞ(表示用)
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FHASSEI_DT FHASSEI_DT "            'ﾒｯｾｰｼﾞﾛｸﾞ.発生日時
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_NAIYOU FMSG_NAIYOU "          'ﾒｯｾｰｼﾞﾏｽﾀ.名称
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM1 FMSG_PRM1 "              'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ1
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM2 FMSG_PRM2 "              'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ2
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM3 FMSG_PRM3 "              'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ3
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM4 FMSG_PRM4 "              'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ4
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM5 FMSG_PRM5 "              'ﾒｯｾｰｼﾞﾛｸﾞ.ﾊﾟﾗﾒｰﾀ5
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO FLOG_NO "                  'ﾒｯｾｰｼﾞﾛｸﾞ.ﾛｸﾞNo
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_ID FMSG_ID "                  'ﾒｯｾｰｼﾞﾛｸﾞ.ﾒｯｾｰｼﾞID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_MESSAGE "                                  'ﾒｯｾｰｼﾞﾛｸﾞ
        strSQL &= vbCrLf & "    ,TMST_MESSAGE "                                 'ﾒｯｾｰｼﾞﾏｽﾀ 
        strSQL &= vbCrLf & "     ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TLOG_MESSAGE", "FLOG_CHECK_FLAG")
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND TLOG_MESSAGE.FMSG_ID = TMST_MESSAGE.FMSG_ID "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TLOG_MESSAGE", "FLOG_CHECK_FLAG")
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_NO DESC"            'ﾛｸﾞNo


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ表示設定　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信01                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If grdList.SelectedRows.Count < 1 Then
            'ｺﾝﾍﾞﾔ
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_01, PopupFormType.Ok, PopupIconType.Information)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_51, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200101        'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPLOG_NO", grdList.Item(menmListCol.FLOG_NO, grdList.SelectedRows(0).Index).Value)            'ﾛｸﾞNo
        objTelegram.SETIN_DATA("DSPMSG_ID", grdList.Item(menmListCol.FMSG_ID, grdList.SelectedRows(0).Index).Value)            'ﾒｯｾｰｼﾞID

        Call gobjComFuncFRM.SockSendServer01(objTelegram, "")        'ｿｹｯﾄ送信


    End Sub
#End Region
#Region "  ｿｹｯﾄ送信02                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket02()

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_52, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200101        'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPLOG_NO", CBO_ALL_VALUE)            'ﾛｸﾞNo

        Call gobjComFuncFRM.SockSendServer01(objTelegram, "")                          'ｿｹｯﾄ送信

    End Sub
#End Region

End Class
