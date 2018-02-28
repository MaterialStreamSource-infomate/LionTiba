'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】検品NG画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_201020

#Region "  共通変数　                           "

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXCAR_NO As String                '車番
    Private mstrXCAR_NO_EDA As String            '枝番
    Private mstrBC() As String                   'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ
    Private mobjGrid As Windows.Forms.GridItem

    'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ用構造体
    Private mudtBC_ITEM As New BC_ITEM


    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        KAKUNIN_Click            '確認ﾎﾞﾀﾝｸﾘｯｸ時

    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FHINMEI_CD                          '品名ｺｰﾄﾞ
        TR_VOL                              '積み数合計

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義                           "
    ''' <summary>ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ</summary>
    Private Structure BC_ITEM
        Dim HINMEI_CD As String         '品名ｺｰﾄﾞ
        Dim SEIZOU_DT As String         '製造年月日
        Dim KOUJYOU_NO As String        '工場№
        Dim LINE_CD As String           'ﾗｲﾝｺｰﾄﾞ
        Dim PALLET_NO As String         'ﾊﾟﾚｯﾄ№
        Dim TR_VOL As String            '積み数
        Dim KENSA_KUBUN As String       '検査区分
        Dim AB_KUBUN As String          'AB区分

    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    ''' ======================================
    ''' <summary>車番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO() As String
        Get
            Return mstrXCAR_NO
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>枝番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_EDA() As String
        Get
            Return mstrXCAR_NO_EDA
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userBCData() As String()
        Get
            Return mstrBC
        End Get
        Set(ByVal value As String())
            mstrBC = value
        End Set
    End Property

#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '*******************************************************
        '画面ﾒｯｾｰｼﾞ
        '*******************************************************
        lblMsg.Text = FRM_MSG_PDA_MSG_03

        '*******************************************************
        'ｺﾝﾄﾛｰﾙ初期化
        '*******************************************************
        lblXCAR_NO.Text = mstrXCAR_NO
        lblXCAR_NO_EDA.Text = mstrXCAR_NO_EDA

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncPDA.FlexGridInitialize02(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay(grdList)


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
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
        lblXCAR_NO.Dispose()
        lblXCAR_NO_EDA.Dispose()

    End Sub
#End Region
#Region "  F1(中断)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(中断)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()
        Try

            'Dim udeRet As RetPopup

            ''*******************************************************
            ''確認ﾒｯｾｰｼﾞ
            ''*******************************************************
            'udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BTN_CONFIRM_02, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            'If udeRet <> RetPopup.OK Then
            '    Exit Sub
            'End If

            '********************************************************************
            'ｿｹｯﾄ送信処理
            '********************************************************************
            'If SendSocket02() = False Then
            '    Exit Sub
            'End If

            '*******************************************************
            '画面遷移
            '*******************************************************
            'Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_201000, Me)

            '********************************************************************
            ' 自身のｸﾛｰｽﾞ処理
            '********************************************************************
            Me.DialogResult = DialogResult.OK

            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  F4(確認)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(確認)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()
        Try

            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.KAKUNIN_Click) = False Then
                Exit Sub
            End If

            ''********************************************************************
            ''ｿｹｯﾄ送信処理
            ''********************************************************************
            'If SendSocket02() = False Then
            '    Exit Sub
            'End If

            ''*******************************************************
            ''画面遷移
            ''*******************************************************
            'Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_201000, Me)

            '********************************************************************
            ' 自身のｸﾛｰｽﾞ処理
            '********************************************************************
            Me.DialogResult = DialogResult.No

            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase, _
                                Optional ByVal strBCData As String = "") As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        'Dim intRet As RetCode
        'Dim strMsg As String = ""

        Select Case udtCheck_Case
            Case menmCheckCase.KAKUNIN_Click
                '(確認ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

        End Select

        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay(ByVal grdControl As GamenCommon.cmpMDataGrid)

        Dim objDataTable As New GamenCommon.clsGridDataTable05      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        For ii As Integer = LBound(gudtHINMEI_SUM) To UBound(gudtHINMEI_SUM)
            '(ﾙｰﾌﾟ:品目毎積み数合計)
            objDataTable.userAddRowDataSet(TO_STRING(gudtHINMEI_SUM(ii).HINMEI_CD), TO_STRING(TO_DECIMAL(gudtHINMEI_SUM(ii).KENPIN_VOL)))
        Next


        objDataTable.DefaultView.Sort = "Data00 ASC"


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncPDA.GridDisplay(objDataTable, _
                         grdList, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncPDA.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
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
        Call gobjComFuncPDA.TDSP_GRIDSetup(Me, grdList)

        grdList.Columns(menmListCol.TR_VOL).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill        '列幅自動調節
        grdList.AllowUserToResizeColumns = False

        For Each objColum As DataGridViewColumn In grdList.Columns
            objColum.SortMode = DataGridViewColumnSortMode.NotSortable                  '列の並替禁止
        Next

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信02                         　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    'Private Function SendSocket02() As Boolean


    '    Dim blnRet As Boolean = False
    '    Dim intRet As RetCode
    '    Dim strMsg As String = ""

    '    '*******************************************************
    '    '確認ﾒｯｾｰｼﾞ
    '    '*******************************************************
    '    Dim udtRet As RetPopup
    '    Dim strMessage As String
    '    strMessage = ""
    '    strMessage &= FRM_MSG_PDA_BTN_CONFIRM_04
    '    udtRet = gobjComFuncPDA.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
    '    If udtRet <> RetPopup.OK Then
    '        Exit Function
    '    End If

    '    '*******************************************************
    '    'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
    '    '*******************************************************
    '    Dim strSendTel() As String = Nothing

    '    For ii As Integer = LBound(mstrBC) To UBound(mstrBC)
    '        '(ﾙｰﾌﾟ:ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ)

    '        '*****************************************************
    '        'ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解
    '        '*****************************************************
    '        Call Disassembly_BCData(mstrBC(ii))


    '        '==============================================
    '        '出荷実績ﾁｪｯｸ
    '        '==============================================
    '        '**********************************************************
    '        ' 出荷実績の特定
    '        '**********************************************************
    '        Dim objXRST_OUT As TBL_XRST_OUT            '出荷実績
    '        objXRST_OUT = New TBL_XRST_OUT(gobjOwner, gobjDb, Nothing)
    '        objXRST_OUT.FHINMEI_CD = mudtBC_ITEM.HINMEI_CD                            '品名ｺｰﾄﾞ
    '        objXRST_OUT.XSEIZOU_DT = Mid(mudtBC_ITEM.SEIZOU_DT, 1, 4) & "/" & _
    '                                 Mid(mudtBC_ITEM.SEIZOU_DT, 5, 2) & "/" & _
    '                                 Mid(mudtBC_ITEM.SEIZOU_DT, 7, 2) & " 00:00:00"    '製造年月日
    '        objXRST_OUT.XLINE_NO = mudtBC_ITEM.KOUJYOU_NO & mudtBC_ITEM.LINE_CD       'ﾗｲﾝ№
    '        objXRST_OUT.XPALLET_NO = mudtBC_ITEM.PALLET_NO                            'ﾊﾟﾚｯﾄ№
    '        intRet = objXRST_OUT.GET_XRST_OUT(False)
    '        If intRet <> RetCode.OK Then
    '            '(読めない時)
    '            strMsg = ERRMSG_NOTFOUND_XRST_OUT & _
    '                     "[品名ｺｰﾄﾞ:" & mudtBC_ITEM.HINMEI_CD & "]" & _
    '                     "[製造年月日:" & mudtBC_ITEM.SEIZOU_DT & "]" & _
    '                     "[ﾗｲﾝ№:" & objXRST_OUT.XLINE_NO & "]" & _
    '                     "[ﾊﾟﾚｯﾄ№:" & mudtBC_ITEM.PALLET_NO & "]"
    '            Throw New System.Exception(strMsg)
    '        End If


    '        If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

    '        '*******************************************************
    '        ' 電文作成
    '        '*******************************************************
    '        '========================================
    '        ' 変数宣言
    '        '========================================
    '        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '        Dim strDSPST_FM As String = ""                                   '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        Dim strDSPPALLET_ID As String = ""                               'ﾊﾟﾚｯﾄID
    '        Dim strXDSPSYUKKA_NO As String = ""                              '出荷№
    '        Dim strXDSPPLN_DTL_NO As String = ""                             '計画明細№
    '        Dim strDSPTR_VOL As String = ""                                  '搬送管理量

    '        strDSPST_FM = TO_STRING(objXRST_OUT.FTRK_BUF_NO)                 '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        'strDSPPALLET_ID = TO_STRING(objXRST_OUT.FPALLET_ID)              'ﾊﾟﾚｯﾄID

    '        strXDSPSYUKKA_NO = TO_STRING(objXRST_OUT.XSYUKKA_NO)             '出荷№
    '        strXDSPPLN_DTL_NO = TO_STRING(objXRST_OUT.XPLN_DTL_NO)           '計画明細№
    '        strDSPTR_VOL = TO_STRING(TO_DECIMAL(mudtBC_ITEM.TR_VOL))         '搬送管理量

    '        objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101            'ﾌｫｰﾏｯﾄ名ｾｯﾄ

    '        Dim strDSPCMD_ID As String = ""
    '        strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
    '        'ﾍｯﾀﾞﾃﾞｰﾀ
    '        objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
    '        objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
    '        objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

    '        'ﾃﾞｰﾀ
    '        objTelegramSub.SETIN_DATA("DSPST_FM", strDSPST_FM)                  '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '        objTelegramSub.SETIN_DATA("DSPPALLET_ID", strDSPPALLET_ID)          'ﾊﾟﾚｯﾄID
    '        objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)        '出荷№
    '        objTelegramSub.SETIN_DATA("XDSPPLN_DTL_NO", strXDSPPLN_DTL_NO)      '計画明細№
    '        objTelegramSub.SETIN_DATA("DSPTR_VOL", strDSPTR_VOL)                '搬送管理量

    '        objTelegramSub.MAKE_TELEGRAM()

    '        strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

    '    Next


    '    '*******************************************************
    '    ' 電文作成
    '    '*******************************************************
    '    '========================================
    '    ' 変数宣言
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim strPARA_ID As String = ""
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400101                  'ﾌｫｰﾏｯﾄ名ｾｯﾄ

    '    objTelegram.SETIN_DATA("DSPST_FM", "")                                      '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    '    objTelegram.SETIN_DATA("DSPPALLET_ID", "")                                  'ﾊﾟﾚｯﾄID
    '    objTelegram.SETIN_DATA("XDSPSYUKKA_NO", "")                                 '出荷№
    '    objTelegram.SETIN_DATA("XDSPPLN_DTL_NO", "")                                '計画明細№
    '    objTelegram.SETIN_DATA("DSPTR_VOL", "")                                     '搬送管理量

    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
    '    Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
    '    strErrMsg = FRM_MSG_PDA_ERROR_04
    '    udtSckSendRET = gobjComFuncPDA.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(送信できた場合)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(正常終了の場合)
    '            blnRet = True
    '        End If
    '    End If

    '    Return blnRet

    'End Function
#End Region
#Region "  ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解                 "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｺｰﾄﾞﾃﾞｰﾀ 電文分解
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Sub Disassembly_BCData(ByVal strBCData As String)

        Dim objTel As New clsTelegram(CONFIG_TELEGRAM_BCR)
        objTel.FORMAT_ID = FORMAT_BCR_01                        'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTel.TELEGRAM_PARTITION = strBCData                   '分割する電文ｾｯﾄ
        objTel.PARTITION()                                      '電文分割
        mudtBC_ITEM.HINMEI_CD = Trim(objTel.SELECT_DATA("BCR01HINMEI_CD"))              '品名ｺｰﾄﾞ
        mudtBC_ITEM.SEIZOU_DT = Trim(objTel.SELECT_DATA("BCR01SEIZOU_DT"))              '製造年月日
        mudtBC_ITEM.KOUJYOU_NO = Trim(objTel.SELECT_DATA("BCR01KOUJYO_NO"))             '工場№
        mudtBC_ITEM.LINE_CD = Trim(objTel.SELECT_DATA("BCR01LINE_CD"))                  'ﾗｲﾝｺｰﾄﾞ
        mudtBC_ITEM.PALLET_NO = Trim(objTel.SELECT_DATA("BCR01PALLET_NO"))              'ﾊﾟﾚｯﾄ№
        mudtBC_ITEM.TR_VOL = Trim(objTel.SELECT_DATA("BCR01VOL"))                       '積み数
        mudtBC_ITEM.KENSA_KUBUN = Trim(objTel.SELECT_DATA("BCR01KENSA_KUBUN"))          '検査区分
        mudtBC_ITEM.AB_KUBUN = objTel.SELECT_DATA("BCR01AB_KUBUN")                      'AB区分       (ｽﾍﾟｰｽがﾃﾞｰﾀとして入るのでTrimはかけない)

    End Sub
#End Region

End Class
