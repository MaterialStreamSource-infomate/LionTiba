﻿'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PLCﾒﾝﾃﾅﾝｽ(入庫ST)画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
Imports GamenCommon
#End Region

Public Class FRM_307090

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ﾌﾟﾛﾊﾟﾃｨ
    Private mstrXMAINTE_KUBUN                           'ﾒﾝﾃﾅﾝｽ区分

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        RefreshBtn_Click                '表示更新ﾎﾞﾀﾝｸﾘｯｸ時
        ST_SELECT_Click                 'ST選択ﾎﾞﾀﾝｸﾘｯｸ時
        PAGE_BACK_Click                 '前ﾍﾟｰｼﾞﾎﾞﾀﾝｸﾘｯｸ時
        PAGE_UP_Click                   '次ﾍﾟｰｼﾞﾎﾞﾀﾝｸﾘｯｸ時
        Maintenance_Click               'ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝｸﾘｯｸ時

    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        PLC_STNO                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        STNo.
        PLC_MODE                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        ﾓｰﾄﾞ
        PLC_MODE_VOL1                   '                       入庫ﾓｰﾄﾞ
        PLC_MODE_VOL2                   '                       出庫ﾓｰﾄﾞ
        PLC_PARE                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        ﾍﾟｱ
        PLC_PARE_VOL                    '                       ﾍﾟｱ搬送
        PLC_FORK                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        ﾌｫｰｸ
        PLC_FORK_VOL1                   '                       ﾌｫｰｸ2
        PLC_FORK_VOL2                   '                       ﾌｫｰｸ1
        PLC_LS                          'PLCﾒﾝﾃﾅﾝｽ(RTN).        L/S
        PLC_W                           'PLCﾒﾝﾃﾅﾝｽ(RTN).        Wﾘｰﾁ
        PLC_W_VOL                       '                       Wﾘｰﾁ
        PLC_RETU_VOL                    '                       列
        PLC_LEFT                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        左
        PLC_RIGHT                       'PLCﾒﾝﾃﾅﾝｽ(RTN).        右
        PLC_GOUKI                       'PLCﾒﾝﾃﾅﾝｽ(RTN).        号機
        PLC_REN                         'PLCﾒﾝﾃﾅﾝｽ(RTN).        連
        PLC_END                         'PLCﾒﾝﾃﾅﾝｽ(RTN).        END
        PLC_RETRY                       'PLCﾒﾝﾃﾅﾝｽ(RTN).        入棚再設定
        PLC_DAN                         'PLCﾒﾝﾃﾅﾝｽ(RTN).        段
        PLC_GOTO                        'PLCﾒﾝﾃﾅﾝｽ(RTN).        行先
        PLC_GOTO_VOL                    '                       行先
        PLC_KO                          'PLCﾒﾝﾃﾅﾝｽ(RTN).        子
        PLC_KO_VOL                      '                       子
        PLC_OYA                         'PLCﾒﾝﾃﾅﾝｽ(RTN).        親
        PLC_OYA_VOL                     '                       親
        PLC_ZAISEKI                     'PLCﾒﾝﾃﾅﾝｽ(RTN).        在席
        PLC_ZAISEKI_VOL                 '                       在席
        FTRK_BUF_NO                     'PLCﾒﾝﾃﾅﾝｽ(RTN).        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        DATA39
        DATA40
        DATA41
        DATA42
        DATA43
        DATA44
        DATA45
        DATA46
        DATA47
        DATA48
        DATA49
        DATA50

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義　                             "

    '検索条件
    Private Structure SEARCH_ITEM
        Dim XMAINTE_KUBUN As String        'ﾒﾝﾃﾅﾝｽ区分
    End Structure

#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨ                                  "
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ    ｲﾍﾞﾝﾄ　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ(電文詳細展開) ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.DoubleClick
        Try

            '********************************************************************
            'F6押下処理
            '********************************************************************
            Call F6Process()


        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ ﾀｲﾑｱｯﾌﾟ 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr307090_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr307090.Tick
        Try

            tmr307090.Enabled = False
            mFlag_Form_Load = True


            '********************************************************************
            'F1押下処理
            '********************************************************************
            Call F1Process()


        Catch ex As Exception
            ComError(ex)
        Finally
            mFlag_Form_Load = False
            tmr307090.Enabled = True

        End Try
    End Sub
#End Region
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

        cmdF1.Visible = False


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, 0)  'ｸﾞﾘｯﾄﾞ初期設定

        grdList.Font = New Font("ＭＳ ゴシック", 10, FontStyle.Bold)                 'ﾌｫﾝﾄ設定


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set(XMAINTE_KUBUN_ST_1F_GP01)


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        tmr307090.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS307090_001))
        tmr307090.Enabled = True


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")

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
        tmr307090.Dispose()

    End Sub
#End Region
#Region "  F1(表示更新)    ﾎﾞﾀﾝ押下処理　           "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.RefreshBtn_Click) = False Then
            Exit Sub
        End If


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F2(ST選択)  ﾎﾞﾀﾝ押下処理　               "
    '*******************************************************************************************************************
    '【機能】F2  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F2Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ST_SELECT_Click) = False Then
            Exit Sub
        End If


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_307092) = False Then
            gobjFRM_307092.Close()
            gobjFRM_307092.Dispose()
            gobjFRM_307092 = Nothing
        End If

        gobjFRM_307092 = New FRM_307092

        ' ''Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_307092.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set(gobjFRM_307092.userXMAINTE_KUBUN)


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F4(前ﾍﾟｰｼﾞ)  ﾎﾞﾀﾝ押下処理　              "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PAGE_BACK_Click) = False Then
            Exit Sub
        End If


        '*********************************************
        ' ﾍﾟｰｼﾞ切替
        '*********************************************
        Dim intPageNo As Integer
        intPageNo = TO_INTEGER(mudtSEARCH_ITEM.XMAINTE_KUBUN)
        Call PageNoChange(intPageNo, FLAG_OFF)


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set(intPageNo)


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F5(次ﾍﾟｰｼﾞ)  ﾎﾞﾀﾝ押下処理　              "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PAGE_UP_Click) = False Then
            Exit Sub
        End If


        '*********************************************
        ' ﾍﾟｰｼﾞ切替
        '*********************************************
        Dim intPageNo As Integer
        intPageNo = TO_INTEGER(mudtSEARCH_ITEM.XMAINTE_KUBUN)
        Call PageNoChange(intPageNo, FLAG_ON)


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set(intPageNo)


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


    End Sub
#End Region
#Region "  F6(ﾒﾝﾃﾅﾝｽ)      ﾎﾞﾀﾝ押下処理　           "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Maintenance_Click) = False Then
            Exit Sub
        End If

        tmr307090.Enabled = False

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_307091) = False Then
            gobjFRM_307091.Close()
            gobjFRM_307091.Dispose()
            gobjFRM_307091 = Nothing
        End If

        gobjFRM_307091 = New FRM_307091

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_307091.ShowDialog()            '展開

        tmr307090.Enabled = True

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        ''一定時間ｽﾘｰﾌﾟする(更新に時間がかかるから)
        'Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)
        'System.Threading.Thread.Sleep(objTPRG_SYS_HEN.GJ307000_001)


        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


        lblGET_Time.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")


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

        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim intRet As RetCode
        Dim objDataTable As New clsGridDataTable50      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '********************************************************************
        ' ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ取得
        '********************************************************************
        Dim objXDSP_PLC_MAINTE As New TBL_XDSP_PLC_MAINTE(gobjOwner, gobjDb, Nothing)
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XEQ_ID_MAINTE "
        strSQL &= vbCrLf & "   ,XMAINTE_KUBUN "
        strSQL &= vbCrLf & "   ,XMAINTE_ORDER "
        strSQL &= vbCrLf & "   ,XMAINTE_NAME "
        strSQL &= vbCrLf & "   ,FTRK_BUF_NO "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XDSP_PLC_MAINTE "
        strSQL &= vbCrLf & " WHERE 1 = 1 "
        strSQL &= vbCrLf & "    AND XMAINTE_KUBUN = " & mudtSEARCH_ITEM.XMAINTE_KUBUN         'ﾒﾝﾃﾅﾝｽ表示ﾏｽﾀ.      ﾒﾝﾃﾅﾝｽ区分
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XMAINTE_ORDER "
        strSQL &= vbCrLf
        objXDSP_PLC_MAINTE.USER_SQL = strSQL
        intRet = objXDSP_PLC_MAINTE.GET_XDSP_PLC_MAINTE_USER()
        If intRet = RetCode.NG Then
            Throw New Exception(ERRMSG_NOTFOUND_XDSP_PLC_MAINTE)
        End If
        If intRet = RetCode.OK Then
            For ii As Integer = LBound(objXDSP_PLC_MAINTE.ARYME) To UBound(objXDSP_PLC_MAINTE.ARYME)
                '(ﾙｰﾌﾟ:取得件数分)

                '****************************************
                ' 表示設備IDを分解
                '****************************************
                Dim strFEQ_ID_ARY(5) As String
                Dim strAryData(5) As String
                Dim intAryPLCFormat(RTNSiziArray.MAX) As Integer
                strFEQ_ID_ARY = Split(objXDSP_PLC_MAINTE.ARYME(ii).XEQ_ID_MAINTE, KUGIRI01)
                For jj As Integer = LBound(strFEQ_ID_ARY) To UBound(strFEQ_ID_ARY)
                    '(ﾙｰﾌﾟ:配列数分)

                    '********************************************************************
                    ' PLC生値取得
                    '********************************************************************
                    Dim objTSTS_EQ_CTRL As TBL_TSTS_EQ_CTRL                                     '設備状況
                    objTSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                    objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID_ARY(jj)                                  '設備ID
                    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()


                    '****************************************
                    ' 配列に設備状態格納
                    '****************************************
                    strAryData(jj) = objTSTS_EQ_CTRL.FEQ_STS


                Next


                '********************************************************************
                ' 設備状態     →  搬送指示ﾃﾞｰﾀ
                '********************************************************************
                Call GetHansouSiziData(strAryData, intAryPLCFormat)


                '**********************************
                ' ﾓｰﾄﾞ
                '**********************************
                Dim strINOUTMODE As String = ""            '入出庫ﾓｰﾄﾞ名称
                If intAryPLCFormat(RTNSiziArray.InMode) = FLAG_ON And intAryPLCFormat(RTNSiziArray.OutMode) = FLAG_ON Then
                    '(出庫ﾓｰﾄﾞのとき)
                    strINOUTMODE = INOUT_MODE_NAME_OUT_MODE

                ElseIf intAryPLCFormat(RTNSiziArray.InMode) = FLAG_ON And intAryPLCFormat(RTNSiziArray.OutMode) = FLAG_OFF Then
                    '(入庫ﾓｰﾄﾞのとき)
                    strINOUTMODE = INOUT_MODE_NAME_IN_MODE

                Else
                    '(それ以外のとき)
                    strINOUTMODE = INOUT_MODE_NAME_NOTHING

                End If


                '**********************************
                ' ﾍﾟｱ
                '**********************************
                Dim strPARE As String = ""            'ﾍﾟｱ名称
                If intAryPLCFormat(RTNSiziArray.PairHansou) = FLAG_OFF Then
                    '(ｼﾝｸﾞﾙのとき)
                    strPARE = PARE_NAME_SINGLE

                ElseIf intAryPLCFormat(RTNSiziArray.PairHansou) = FLAG_ON Then
                    '(ﾍﾟｱのとき)
                    strPARE = PARE_NAME_PARE

                Else
                    '(それ以外のとき)
                    strPARE = PARE_NAME_NOTHING

                End If


                '**********************************
                ' ﾌｫｰｸ
                '**********************************
                Dim strFork As String = ""              'ﾌｫｰｸ名称
                If intAryPLCFormat(RTNSiziArray.Fork2) = FLAG_ON And intAryPLCFormat(RTNSiziArray.Fork1) = FLAG_OFF Then
                    '(子のとき)
                    strFork = FORK_NAME_KO

                ElseIf intAryPLCFormat(RTNSiziArray.Fork2) = FLAG_OFF And intAryPLCFormat(RTNSiziArray.Fork1) = FLAG_ON Then
                    '(親のとき)
                    strFork = FORK_NAME_OYA

                Else
                    '(それ以外のとき)
                    strFork = FORK_NAME_NOTHING

                End If


                '**********************************
                ' Wﾘｰﾁ
                '**********************************
                Dim strW As String = ""            'Wﾘｰﾁ名称
                If intAryPLCFormat(RTNSiziArray.DoubleReach) = FLAG_OFF Then
                    '(手前のとき)
                    strW = W_NAME_TEMAE

                ElseIf intAryPLCFormat(RTNSiziArray.DoubleReach) = FLAG_ON Then
                    '(奥のとき)
                    strW = W_NAME_OKU

                Else
                    '(それ以外のとき)
                    strW = W_NAME_NOTHING

                End If


                '**********************************
                ' 列
                '**********************************
                Dim strLeft As String = ""               '左
                Dim strRight As String = ""              '右
                If intAryPLCFormat(RTNSiziArray.Retu) = 0 Then
                    '(0のとき)
                    strLeft = RETU_NAME_NULL
                    strRight = RETU_NAME_NULL
                Else
                    '(それ以外のとき)
                    If intAryPLCFormat(RTNSiziArray.Retu) Mod 2 = 0 Then
                        '(偶数のとき)
                        strLeft = RETU_NAME_LEFT
                        strRight = RETU_NAME_NULL
                    Else
                        '(奇数のとき)
                        strLeft = RETU_NAME_NULL
                        strRight = RETU_NAME_RIGHT
                    End If
                End If


                '**********************************
                ' 行先
                '**********************************
                Dim strGOTO As String = ""               '行先

                '********************************************************************
                ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ取得
                '********************************************************************
                Dim objTPRG_TRK_BUF As TBL_TPRG_TRK_BUF                                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTPRG_TRK_BUF = New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
                objTPRG_TRK_BUF.FTRNS_ADDRESS = TO_STRING(intAryPLCFormat(RTNSiziArray.Addrs))      '搬送指示用ｱﾄﾞﾚｽ
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_ANY()
                If intRet = RetCode.OK Then
                    strGOTO = objTPRG_TRK_BUF.ARYME(0).FDISP_ADDRESS
                End If



                '**********************************
                ' RTN子
                '**********************************
                Dim strRTN_KO As String = ""               'RTN子
                If intAryPLCFormat(RTNSiziArray.Ko) = FLAG_ON Then
                    '(子のとき)
                    strRTN_KO = RTN_NAME_KO
                Else
                    '(それ以外のとき)
                    strRTN_KO = RTN_NAME_NULL
                End If


                '**********************************
                ' RTN親
                '**********************************
                Dim strRTN_OYA As String = ""               'RTN親
                If intAryPLCFormat(RTNSiziArray.Oya) = FLAG_ON Then
                    '(親のとき)
                    strRTN_OYA = RTN_NAME_OYA
                Else
                    '(それ以外のとき)
                    strRTN_OYA = RTN_NAME_NULL
                End If

                '**********************************
                ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                '**********************************
                Dim strFTRK_BUF_NO As String = ""
                strFTRK_BUF_NO = objXDSP_PLC_MAINTE.ARYME(ii).FTRK_BUF_NO

                '**********************************
                '行追加
                '**********************************
                Call objDataTable.userAddRowDataSet(objXDSP_PLC_MAINTE.ARYME(ii).XMAINTE_NAME _
                                                  , strINOUTMODE _
                                                  , intAryPLCFormat(RTNSiziArray.InMode) _
                                                  , intAryPLCFormat(RTNSiziArray.OutMode) _
                                                  , strPARE _
                                                  , intAryPLCFormat(RTNSiziArray.PairHansou) _
                                                  , strFork _
                                                  , intAryPLCFormat(RTNSiziArray.Fork2) _
                                                  , intAryPLCFormat(RTNSiziArray.Fork1) _
                                                  , intAryPLCFormat(RTNSiziArray.LSNo) _
                                                  , strW _
                                                  , intAryPLCFormat(RTNSiziArray.DoubleReach) _
                                                  , intAryPLCFormat(RTNSiziArray.Retu) _
                                                  , strLeft _
                                                  , strRight _
                                                  , intAryPLCFormat(RTNSiziArray.Gouki) _
                                                  , intAryPLCFormat(RTNSiziArray.Ren) _
                                                  , intAryPLCFormat(RTNSiziArray.EndFlag) _
                                                  , intAryPLCFormat(RTNSiziArray.IritanaRetry) _
                                                  , intAryPLCFormat(RTNSiziArray.Dan) _
                                                  , strGOTO _
                                                  , intAryPLCFormat(RTNSiziArray.Addrs) _
                                                  , strRTN_KO _
                                                  , intAryPLCFormat(RTNSiziArray.Ko) _
                                                  , strRTN_OYA _
                                                  , intAryPLCFormat(RTNSiziArray.Oya) _
                                                  , "" _
                                                  , intAryPLCFormat(RTNSiziArray.Zaiseki) _
                                                  , strFTRK_BUF_NO _
                                                  )

            Next

        End If


        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        If grdList.SelectedCells.Count = 0 Then
            intSelectRow = -1               'ﾘｽﾄの行
            intSelectCol = -1               'ﾘｽﾄの列
        Else
            intSelectRow = grdList.SelectedCells(0).RowIndex             'ﾘｽﾄの行
            intSelectCol = grdList.SelectedCells(0).ColumnIndex          'ﾘｽﾄの列
        End If

        objPoint.X = grdList.HorizontalScrollingOffset           'ｽｸﾛｰﾙﾊﾞｰ位置　横
        objPoint.Y = grdList.FirstDisplayedScrollingRowIndex     'ｽｸﾛｰﾙﾊﾞｰ位置　縦


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.DataSource = objDataTable


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup(grdList)
        grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, 1, objPoint)    'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup(ByVal grdList As GamenCommon.cmpMDataGrid)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        'grdList.Columns(menmListCol.PLC_OYA).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


        '=========================================
        '行の高さ
        '=========================================
        For ii As Integer = 0 To grdList.Rows.Count - 1
            grdList.Rows(ii).Height = 18
        Next


        '************************************************
        'ｸﾞﾘｯﾄﾞ列の並替ﾓｰﾄﾞ変更
        '************************************************
        Call gobjComFuncFRM.GridSortModeSet(grdList, DataGridViewColumnSortMode.NotSortable)


    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <param name="strXMAINTE_KUBUN">ﾒﾝﾃﾅﾝｽ区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set(ByVal strXMAINTE_KUBUN As String)

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        mudtSEARCH_ITEM.XMAINTE_KUBUN = strXMAINTE_KUBUN            'ﾒﾝﾃﾅﾝｽ区分

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True/False</returns>
    ''' <remarks>戻値 = True :入力ﾁｪｯｸ成功/False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.RefreshBtn_Click
                '(表示更新ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.ST_SELECT_Click
                '(ST選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.PAGE_BACK_Click
                '(前ﾍﾟｰｼﾞﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.PAGE_UP_Click
                '(次ﾍﾟｰｼﾞﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.Maintenance_Click
                '(ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

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
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        '********************************************************************
        ' 親と子の行を特定
        '********************************************************************
        Dim intOyaIndex As Integer
        Dim intKoIndex As Integer

        If grdList.SelectedRows(0).Index = 0 Then
            '(先頭が選択された場合)
            intOyaIndex = grdList.SelectedRows(0).Index
            intKoIndex = grdList.SelectedRows(0).Index + 1
        ElseIf (grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) = (grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index - 1).Value) Then
            '(子が選択された場合)
            intOyaIndex = grdList.SelectedRows(0).Index - 1
            intKoIndex = grdList.SelectedRows(0).Index
        ElseIf (grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) = (grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index + 1).Value) Then
            '(親が選択された場合)
            intOyaIndex = grdList.SelectedRows(0).Index
            intKoIndex = grdList.SelectedRows(0).Index + 1
        End If

        '********************************************************************
        ' 親ﾌﾟﾛﾊﾟﾃｨ
        '********************************************************************
        gobjFRM_307091.userPLC_STNO = TO_STRING(grdList.Item(menmListCol.PLC_STNO, intOyaIndex).Value)                    'ST№
        gobjFRM_307091.userPLC_MODE_VOL1 = TO_STRING(grdList.Item(menmListCol.PLC_MODE_VOL1, intOyaIndex).Value)          '入庫ﾓｰﾄﾞ
        gobjFRM_307091.userPLC_MODE_VOL2 = TO_STRING(grdList.Item(menmListCol.PLC_MODE_VOL2, intOyaIndex).Value)          '出庫ﾓｰﾄﾞ
        gobjFRM_307091.userPLC_PARE_VOL = TO_STRING(grdList.Item(menmListCol.PLC_PARE_VOL, intOyaIndex).Value)            'ﾍﾟｱ
        gobjFRM_307091.userPLC_FORK_VOL1 = TO_STRING(grdList.Item(menmListCol.PLC_FORK_VOL1, intOyaIndex).Value)          'ﾌｫｰｸ2
        gobjFRM_307091.userPLC_FORK_VOL2 = TO_STRING(grdList.Item(menmListCol.PLC_FORK_VOL2, intOyaIndex).Value)          'ﾌｫｰｸ1
        gobjFRM_307091.userPLC_LS = TO_STRING(grdList.Item(menmListCol.PLC_LS, intOyaIndex).Value)                        'L/S
        gobjFRM_307091.userPLC_W_VOL = TO_STRING(grdList.Item(menmListCol.PLC_W_VOL, intOyaIndex).Value)                  'Wﾘｰﾁ
        gobjFRM_307091.userPLC_RETU_VOL = TO_STRING(grdList.Item(menmListCol.PLC_RETU_VOL, intOyaIndex).Value)            '列
        gobjFRM_307091.userPLC_GOUKI = TO_STRING(grdList.Item(menmListCol.PLC_GOUKI, intOyaIndex).Value)                  '号機
        gobjFRM_307091.userPLC_REN = TO_STRING(grdList.Item(menmListCol.PLC_REN, intOyaIndex).Value)                      '連
        gobjFRM_307091.userPLC_END = TO_STRING(grdList.Item(menmListCol.PLC_END, intOyaIndex).Value)                      'END
        gobjFRM_307091.userPLC_RETRY = TO_STRING(grdList.Item(menmListCol.PLC_RETRY, intOyaIndex).Value)                  '入庫再設定
        gobjFRM_307091.userPLC_DAN = TO_STRING(grdList.Item(menmListCol.PLC_DAN, intOyaIndex).Value)                      '段
        gobjFRM_307091.userPLC_GOTO_VOL = TO_STRING(grdList.Item(menmListCol.PLC_GOTO_VOL, intOyaIndex).Value)            '行先
        gobjFRM_307091.userPLC_KO_VOL = TO_STRING(grdList.Item(menmListCol.PLC_KO_VOL, intOyaIndex).Value)                '子
        gobjFRM_307091.userPLC_OYA_VOL = TO_STRING(grdList.Item(menmListCol.PLC_OYA_VOL, intOyaIndex).Value)              '親
        gobjFRM_307091.userPLC_ZAISEKI_VOL = TO_STRING(grdList.Item(menmListCol.PLC_ZAISEKI_VOL, intOyaIndex).Value)      '在席


        '********************************************************************
        ' 子ﾌﾟﾛﾊﾟﾃｨ
        '********************************************************************
        gobjFRM_307091.userPLC_STNO_KO = TO_STRING(grdList.Item(menmListCol.PLC_STNO, intKoIndex).Value)                    'ST№
        gobjFRM_307091.userPLC_MODE_VOL1_KO = TO_STRING(grdList.Item(menmListCol.PLC_MODE_VOL1, intKoIndex).Value)          '入庫ﾓｰﾄﾞ
        gobjFRM_307091.userPLC_MODE_VOL2_KO = TO_STRING(grdList.Item(menmListCol.PLC_MODE_VOL2, intKoIndex).Value)          '出庫ﾓｰﾄﾞ
        gobjFRM_307091.userPLC_PARE_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_PARE_VOL, intKoIndex).Value)            'ﾍﾟｱ
        gobjFRM_307091.userPLC_FORK_VOL1_KO = TO_STRING(grdList.Item(menmListCol.PLC_FORK_VOL1, intKoIndex).Value)          'ﾌｫｰｸ2
        gobjFRM_307091.userPLC_FORK_VOL2_KO = TO_STRING(grdList.Item(menmListCol.PLC_FORK_VOL2, intKoIndex).Value)          'ﾌｫｰｸ1
        gobjFRM_307091.userPLC_LS_KO = TO_STRING(grdList.Item(menmListCol.PLC_LS, intKoIndex).Value)                        'L/S
        gobjFRM_307091.userPLC_W_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_W_VOL, intKoIndex).Value)                  'Wﾘｰﾁ
        gobjFRM_307091.userPLC_RETU_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_RETU_VOL, intKoIndex).Value)            '列
        gobjFRM_307091.userPLC_GOUKI_KO = TO_STRING(grdList.Item(menmListCol.PLC_GOUKI, intKoIndex).Value)                  '号機
        gobjFRM_307091.userPLC_REN_KO = TO_STRING(grdList.Item(menmListCol.PLC_REN, intKoIndex).Value)                      '連
        gobjFRM_307091.userPLC_END_KO = TO_STRING(grdList.Item(menmListCol.PLC_END, intKoIndex).Value)                      'END
        gobjFRM_307091.userPLC_RETRY_KO = TO_STRING(grdList.Item(menmListCol.PLC_RETRY, intKoIndex).Value)                  '入庫再設定
        gobjFRM_307091.userPLC_DAN_KO = TO_STRING(grdList.Item(menmListCol.PLC_DAN, intKoIndex).Value)                      '段
        gobjFRM_307091.userPLC_GOTO_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_GOTO_VOL, intKoIndex).Value)            '行先
        gobjFRM_307091.userPLC_KO_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_KO_VOL, intKoIndex).Value)                '子
        gobjFRM_307091.userPLC_OYA_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_OYA_VOL, intKoIndex).Value)              '親
        gobjFRM_307091.userPLC_ZAISEKI_VOL_KO = TO_STRING(grdList.Item(menmListCol.PLC_ZAISEKI_VOL, intKoIndex).Value)      '在席


        gobjFRM_307091.userXMAINTE_KUBUN = TO_STRING(mudtSEARCH_ITEM.XMAINTE_KUBUN)         'ﾒﾝﾃﾅﾝｽ区分

    End Sub

#End Region
#Region "  ﾍﾟｰｼﾞ切替　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾍﾟｰｼﾞ切替
    ''' </summary>
    ''' <param name="intPageNo">ﾍﾟｰｼﾞ番号</param>
    ''' <param name="intPageKubun">ﾍﾟｰｼﾞ区分(0:back,1:up)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PageNoChange(ByRef intPageNo As Integer, ByVal intPageKubun As Integer)


        '***********************************************
        'ﾍﾟｰｼﾞ番号変更
        '***********************************************
        If intPageKubun = FLAG_OFF Then
            '(前ﾍﾟｰｼﾞのとき)
            If intPageNo = XMAINTE_KUBUN_ST_1F_GP01 Then
                '(最初のﾍﾟｰｼﾞのとき、最後のﾍﾟｰｼﾞを表示する)  
                'intPageNo = XMAINTE_KUBUN_ST_2F_GP02
                intPageNo = XMAINTE_KUBUN_ST_2F_GP03    'JobMate:ikeda 2017/07/19 B30-B33追加対応 変更
            Else
                '(それ以外のとき)
                intPageNo -= 1
            End If

        ElseIf intPageKubun = FLAG_ON Then
            '(次ﾍﾟｰｼﾞのとき)
            'If intPageNo = XMAINTE_KUBUN_ST_2F_GP02 Then
            If intPageNo = XMAINTE_KUBUN_ST_2F_GP03 Then    'JobMate:ikeda 2017/07/19 B30-B33追加対応 変更
                '(最後のﾍﾟｰｼﾞのとき、最初のﾍﾟｰｼﾞを表示する)
                intPageNo = XMAINTE_KUBUN_ST_1F_GP01
            Else
                '(それ以外のとき)
                intPageNo += 1
            End If

        End If

    End Sub
#End Region

End Class
