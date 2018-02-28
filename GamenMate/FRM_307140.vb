'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産入庫登録(BCR)登録画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307140
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        RefreshBtn_Click                '再表示
        OUTSetBtn_Click                 '出庫登録
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        EQIP_NAME       '設備名称
        ITEM_CD
        ITEM_MARK
        ITEM_NAME
        MAKER_CD
        START_DATE
        IN_PL_CNT
        IN_CNT
        ITF_CD
        LAST_DATE
        DATA10
        MAXCOL

    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()



        '*********************************************
        'ｸﾞﾘｯﾄﾞ初期化()
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)



        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()

    End Sub
#End Region
#Region "  F1(再表示)  ﾎﾞﾀﾝ押下処理　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(再表示) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F2(出庫登録)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(出庫登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()



    End Sub
#End Region

#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）
        Dim objDataSet2 As New DataSet

        Dim objDataTable As New GamenCommon.clsGridDataTable10      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '============================================================
        'SELECT 包材出庫設定状態
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT"
        strSQL &= vbCrLf & " T2.FBUF_NAME,"
        strSQL &= vbCrLf & " T3.XHINMEI_CD,"
        strSQL &= vbCrLf & " T1.FHINMEI_CD,"
        strSQL &= vbCrLf & " T3.FHINMEI,"
        strSQL &= vbCrLf & " T3.XMAKER_CD,"
        strSQL &= vbCrLf & " T1.XSTART_DT,"
        strSQL &= vbCrLf & " T1.XCOUNT_PL_IN,"
        strSQL &= vbCrLf & " T1.XCOUNT_IN,"
        strSQL &= vbCrLf & " T1.XITF_CD,"
        strSQL &= vbCrLf & " T1.FLAST_DT, "
        strSQL &= vbCrLf & " T1.FTRK_BUF_NO "
        strSQL &= vbCrLf & " FROM XSTS_BCR T1"
        strSQL &= vbCrLf & " JOIN TMST_TRK T2"
        strSQL &= vbCrLf & " ON T1.FTRK_BUF_NO = T2.FTRK_BUF_NO"
        strSQL &= vbCrLf & " JOIN TMST_ITEM T3"
        strSQL &= vbCrLf & " ON T3.FHINMEI_CD = T1.FHINMEI_CD"



        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    T2.FBUF_NAME,T1.FLAST_DT desc"

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "BCR_DATA"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim FBUF_NAME As String = TO_STRING(objRow("FBUF_NAME"))
                Dim XHINMEI_CD As String = TO_STRING(objRow("XHINMEI_CD"))
                Dim FHINMEI_CD As String = TO_STRING(objRow("FHINMEI_CD"))
                Dim FHINMEI As String = TO_STRING(objRow("FHINMEI"))
                Dim XMAKER_CD As String = TO_STRING(objRow("XMAKER_CD"))
                Dim XSTART_DT As String = TO_STRING(objRow("XSTART_DT"))
                Dim XCOUNT_PL_IN As String = TO_STRING(objRow("XCOUNT_PL_IN"))
                Dim XCOUNT_IN As String = TO_STRING(objRow("XCOUNT_IN"))
                Dim XITF_CD As String = TO_STRING(objRow("XITF_CD"))
                Dim FLAST_DT As String = TO_STRING(objRow("FLAST_DT"))
                Dim FBUF_NO As String = TO_STRING(objRow("FTRK_BUF_NO"))




                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '********************************************************************
                objDataTable.userAddRowDataSet(FBUF_NAME, _
                                               XHINMEI_CD, _
                                               FHINMEI_CD, _
                                               FHINMEI, _
                                               XMAKER_CD, _
                                               XSTART_DT, _
                                               XCOUNT_PL_IN, _
                                               XCOUNT_IN, _
                                               XITF_CD, _
                                               FLAST_DT, _
                                               FBUF_NO _
                                              )
            Next
        End If

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                                        grdList _
                                        )
        objDataTable = Nothing

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()                'ｸﾞﾘｯﾄﾞ表示設定

    End Sub

#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
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

#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01(ByVal strBufNo As String, ByVal strItemCd As String, ByVal intMode As Integer)


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= IIf(intMode = 1, "ｸﾘｱ", "削除") & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If
        

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400705    'ﾌｫｰﾏｯﾄ名ｾｯﾄ


        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strBufNo)                        'バッファNO
        objTelegram.SETIN_DATA("DSPHINMEI_CD", strItemCd)                     '品名
        objTelegram.SETIN_DATA("DSPMODE", intMode)   'ﾓｰﾄﾞ　1:クリア 2:行削除


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = IIf(intMode = 1, "ｸﾘｱ", "削除") & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If
        End If

    End Sub
#End Region


    Private Sub cmdF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF5.Click

        '********************************************************************
        'ﾘｽﾄ選択ﾁｪｯｸ
        '********************************************************************
        If grdList.SelectedRows.Count < 1 Then
            '(ﾘｽﾄが選択されていない場合)
            Exit Sub
        End If

        Dim strBuff As String = TO_STRING(grdList.Item(10, grdList.SelectedRows(0).Index).Value)                     'ST
        Dim strItem As String = TO_STRING(grdList.Item(2, grdList.SelectedRows(0).Index).Value)                     'ITEM
        'クリア
        SendSocket01(strBuff, strItem, 1)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)
    End Sub

    Private Sub cmdF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF6.Click

        '********************************************************************
        'ﾘｽﾄ選択ﾁｪｯｸ
        '********************************************************************
        If grdList.SelectedRows.Count < 1 Then
            '(ﾘｽﾄが選択されていない場合)
            Exit Sub
        End If

        Dim strBuff As String = TO_STRING(grdList.Item(10, grdList.SelectedRows(0).Index).Value)                     'ST
        Dim strItem As String = TO_STRING(grdList.Item(2, grdList.SelectedRows(0).Index).Value)                     'ITEM
        '削除
        SendSocket01(strBuff, strItem, 2)



        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)
    End Sub
End Class
