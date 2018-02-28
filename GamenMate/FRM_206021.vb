'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】担当者ﾏｽﾀﾒﾝﾃﾅﾝｽ子画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206021

#Region "  共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    Private mobjTBL_TMST_USER As TBL_TMST_USER                  'ﾕｰｻﾞﾏｽﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FUSER_DSP_LEVEL_NAME            '権限ﾏｽﾀ.         権限ﾚﾍﾞﾙ名称
        FUSER_ID_Data                   '権限ﾏｽﾀ.         ﾕｰｻﾞ操作ﾚﾍﾞﾙﾁｪｯｸﾎﾞｯｸｽ
        FUSER_DSP_LEVEL                 '権限ﾏｽﾀ.         ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        FUSER_ID                        '権限ﾏｽﾀ.         ﾕｰｻﾞ操作ﾚﾍﾞﾙﾁｪｯｸﾎﾞｯｸｽ(表示用)

        MAXCOL

    End Enum


    'ﾌﾟﾛﾊﾟﾃｨ
    Protected mstrFUSER_ID As String             'ﾕｰｻﾞｰID
    Protected mstrFLOGIN_ID As String            'ﾛｸﾞｲﾝID
    Protected mstrFUSER_NAME As String           'ﾕｰｻﾞｰ名

    Dim mintButtonMode As Integer                   'ﾎﾞﾀﾝﾓｰﾄﾞ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFUSER_ID() As String
        Get
            Return mstrFUSER_ID
        End Get
        Set(ByVal value As String)
            mstrFUSER_ID = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾛｸﾞｲﾝID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFLOGIN_ID() As String
        Get
            Return mstrFLOGIN_ID
        End Get
        Set(ByVal value As String)
            mstrFLOGIN_ID = value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾕｰｻﾞｰ名</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFUSER_NAME() As String
        Get
            Return mstrFUSER_NAME
        End Get
        Set(ByVal value As String)
            mstrFUSER_NAME = value
        End Set
    End Property

    ''' =======================================
    ''' <summary>ﾎﾞﾀﾝﾓｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userButtonMode() As Integer
        Get
            Return mintButtonMode
        End Get
        Set(ByVal Value As Integer)
            mintButtonMode = Value
        End Set
    End Property


#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region " ﾌｫｰﾑﾛｰﾄﾞ                                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_206021_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call LoadProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region " ﾌｫｰﾑｱﾝﾛｰﾄﾞ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_206021_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            Call ClosingProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  実行ﾎﾞﾀﾝｸﾘｯｸ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行ﾎﾞﾀﾝｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            Call cmdZikkou_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Call cmdCancel_ClickProcess()


        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ     処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LoadProcess()

        Dim strFREASON_KUBUN As String = ""      '作業種別

        '**********************************************************
        ' 実行ﾎﾞﾀﾝ                  ｾｯﾄ
        '**********************************************************
        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                cmdZikkou.Text = "追加"
                strFREASON_KUBUN = FREASON_KUBUN_STMST_USER_INSERT
            Case BUTTONMODE_UPDATE
                '(変更の場合)
                cmdZikkou.Text = "変更"
                strFREASON_KUBUN = FREASON_KUBUN_STMST_USER_UPDATE
            Case BUTTONMODE_DELETE
                '(削除の場合)
                cmdZikkou.Text = "削除"
                strFREASON_KUBUN = FREASON_KUBUN_STMST_USER_DELETE
        End Select


        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        ' 更新理由ｺﾝﾎﾞﾎﾞｯｸｽ       ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboFREASON_CDSetup(Me.Name, Me.cboFREASON, strFREASON_KUBUN, True)

        '**********************************************************
        ' ﾕｰｻﾞﾏｽﾀ情報取得       
        '**********************************************************
        mobjTBL_TMST_USER = New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        mobjTBL_TMST_USER.FUSER_ID = mstrFUSER_ID
        If mintButtonMode <> BUTTONMODE_ADD Then
            Call mobjTBL_TMST_USER.GET_TMST_USER(False)
        End If


        '**********************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ                 ｾｯﾄ
        '**********************************************************
        txtFUSER_ID.Text = mstrFUSER_ID             'ﾕｰｻﾞｰID
        ''txtFLOGIN_ID.Text = mstrFLOGIN_ID           'ﾛｸﾞｲﾝID
        txtFUSER_NAME.Text = mstrFUSER_NAME         'ﾕｰｻﾞｰ名

        '===================================
        ' ｺﾝﾄﾛｰﾙﾏｽｸ処理
        '===================================
        Call ControlEnable()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplay()


        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ   処理                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ClosingProcess()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()
        cboFREASON.Dispose()

    End Sub
#End Region
#Region "  実行         ﾎﾞﾀﾝ押下処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行 ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then

            Exit Sub
        End If


        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        Call SendSocket01()


    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ        ﾎﾞﾀﾝ押下処理                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cmdCancel_ClickProcess()

        Me.Close()

    End Sub
#End Region
#Region "　ﾘｽﾄ表示(ﾕｰｻﾞ権限ﾚﾍﾞﾙ)　                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示(ﾕｰｻﾞ権限ﾚﾍﾞﾙ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay()


        Dim strSQL As String                        'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     A.FUSER_DSP_LEVEL_NAME "                           '権限ﾏｽﾀ.  権限ﾚﾍﾞﾙ名称
        strSQL &= vbCrLf & "   , DECODE(B.FUSER_ID,NULL,'0','1') FUSER_ID"            '権限ﾏｽﾀ.  ﾕｰｻﾞ操作ﾚﾍﾞﾙﾁｪｯｸﾎﾞｯｸｽ
        strSQL &= vbCrLf & "   , A.FUSER_DSP_LEVEL "                                '権限ﾏｽﾀ.  ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     ( SELECT  "
        strSQL &= vbCrLf & "           TMST_LEVEL.FUSER_DSP_LEVEL_NAME  "
        strSQL &= vbCrLf & "         , TMST_LEVEL.FUSER_DSP_LEVEL  "
        strSQL &= vbCrLf & "       FROM "
        strSQL &= vbCrLf & "           TMST_LEVEL  "
        strSQL &= vbCrLf & "     ) A  "
        strSQL &= vbCrLf & "    ,( SELECT  "
        strSQL &= vbCrLf & "           TMST_USER_DSP.FUSER_ID  "
        strSQL &= vbCrLf & "         , TMST_USER_DSP.FUSER_DSP_LEVEL  "
        strSQL &= vbCrLf & "       FROM "
        strSQL &= vbCrLf & "           TMST_LEVEL "
        strSQL &= vbCrLf & "         , TMST_USER_DSP "
        strSQL &= vbCrLf & "       WHERE 0 = 0 "
        strSQL &= vbCrLf & "           AND TMST_LEVEL.FUSER_DSP_LEVEL = TMST_USER_DSP.FUSER_DSP_LEVEL  "
        strSQL &= vbCrLf & "           AND TMST_USER_DSP.FUSER_ID = '" & mstrFUSER_ID & "' "             'ﾕｰｻﾞｰID
        strSQL &= vbCrLf & "     ) B  "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "     A.FUSER_DSP_LEVEL = B.FUSER_DSP_LEVEL(+)  "


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(ﾕｰｻﾞ権限ﾚﾍﾞﾙ)　              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定(ﾕｰｻﾞ権限ﾚﾍﾞﾙ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ﾁｪｯｸﾎﾞｯｸｽ追加
        '************************************************
        Call gobjComFuncFRM.GridAddCheckBoxColumn(grdList, menmListCol.FUSER_ID_Data)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)
        grdList.ReadOnly = False                                                         'ｾﾙの編集           許可設定


        '************************************************
        '編集ﾓｰﾄﾞ
        '************************************************
        grdList.Columns(menmListCol.FUSER_DSP_LEVEL_NAME).ReadOnly = True

        If mintButtonMode = BUTTONMODE_DELETE Then
            '(削除のとき)
            grdList.Columns(menmListCol.FUSER_ID).ReadOnly = True
        End If


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                '========================================
                'ﾕｰｻﾞｰID
                '========================================
                If txtFUSER_ID.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FUSER_ID_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                ' ''========================================
                ' ''ﾛｸﾞｲﾝID
                ' ''========================================
                ''If txtFLOGIN_ID.Text = "" Then
                ''    Call DisplayPopup(FRM_MSG_FLOGIN_ID_MSG_01, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select
                ''End If
                '========================================
                'ﾕｰｻﾞｰID重複ﾁｪｯｸ
                '========================================
                Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)       'ﾕｰｻﾞｰﾏｽﾀ
                Dim intRet As Integer
                objTMST_USER.FUSER_ID = txtFUSER_ID.Text                                    'ﾕｰｻﾞｰID
                intRet = objTMST_USER.GET_TMST_USER(False)                              '特定
                If intRet = RetCode.OK Then
                    '(入力されたﾕｰｻﾞｰIDが登録されている場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206021_05, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select

                End If
                ' ''========================================
                ' ''ﾛｸﾞｲﾝID重複ﾁｪｯｸ
                ' ''========================================
                ''objTMST_USER.CLEAR_PROPERTY()                               'ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
                ''objTMST_USER.FLOGIN_ID = txtFLOGIN_ID.Text                  'ﾛｸﾞｲﾝID
                ''intRet = objTMST_USER.GET_TMST_USER_FLOGIN_ID()             '特定
                ''If intRet = RetCode.OK Then
                ''    '(入力されたﾕｰｻﾞｰIDが登録されている場合)
                ''    Call DisplayPopup(FRM_MSG_FRM206021_06, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select

                ''End If

                '↓↓↓↓↓ システム固有
               
                '↑↑↑↑↑ システム固有

                '========================================
                'ﾕｰｻﾞｰ名
                '========================================
                If txtFUSER_NAME.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FUSER_NAME_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                '========================================
                '更新理由
                '========================================
                If cboFREASON.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                blnCheckErr = False


            Case BUTTONMODE_UPDATE
                '(変更の場合)
                '========================================
                'ﾕｰｻﾞｰID
                '========================================
                If txtFUSER_ID.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FUSER_ID_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If
                ' ''========================================
                ' ''ﾛｸﾞｲﾝID
                ' ''========================================
                ''If txtFLOGIN_ID.Text = "" Then
                ''    Call DisplayPopup(FRM_MSG_FLOGIN_ID_MSG_01, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select
                ''End If
                ' ''========================================
                ' ''ﾛｸﾞｲﾝID重複ﾁｪｯｸ
                ' ''========================================
                ''Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)       'ﾕｰｻﾞｰﾏｽﾀ
                ''Dim intRet As Integer
                ''objTMST_USER.FUSER_ID = txtFUSER_ID.Text                    'ﾕｰｻﾞｰID
                ''objTMST_USER.FLOGIN_ID = txtFLOGIN_ID.Text                  'ﾛｸﾞｲﾝID
                ''intRet = objTMST_USER.GET_TMST_USER_FLOGIN_ID_CHECK()       '特定
                ''If intRet = RetCode.OK Then
                ''    '(入力されたﾕｰｻﾞｰIDが登録されている場合)
                ''    Call DisplayPopup(FRM_MSG_FRM206021_06, _
                ''                      PopupFormType.Ok, _
                ''                      PopupIconType.Information)
                ''    Exit Select

                ''End If
                '========================================
                'ﾕｰｻﾞｰ名
                '========================================
                If txtFUSER_NAME.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FUSER_NAME_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If

                '↓↓↓↓↓ システム固有

                '↑↑↑↑↑ システム固有

                '========================================
                '更新理由
                '========================================
                If cboFREASON.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
                    Exit Select
                End If


                blnCheckErr = False

            Case BUTTONMODE_DELETE
                '(削除の場合)
                '========================================
                '更新理由
                '========================================
                If cboFREASON.Text = "" Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FREASON_CD_MSG_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Information)
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
#Region "　ｺﾝﾄﾛｰﾙﾏｽｸ処理　                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙﾏｽｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub ControlEnable()

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)

                txtFUSER_ID.Enabled = True                     'ﾕｰｻﾞｰID
                ''txtFLOGIN_ID.Enabled = True                    'ﾛｸﾞｲﾝID
                txtFUSER_NAME.Enabled = True                   'ﾕｰｻﾞｰ名
                cboFREASON.Enabled = True                   '更新理由
                grdList.Enabled = True                         '権限ﾚﾍﾞﾙ

                Exit Select

            Case BUTTONMODE_UPDATE
                '(変更の場合)

                txtFUSER_ID.Enabled = False                    'ﾕｰｻﾞｰID
                ''txtFLOGIN_ID.Enabled = True                    'ﾛｸﾞｲﾝID
                txtFUSER_NAME.Enabled = True                   'ﾕｰｻﾞｰ名
                cboFREASON.Enabled = True                   '更新理由
                grdList.Enabled = True                         '権限ﾚﾍﾞﾙ

                Exit Select

            Case BUTTONMODE_DELETE
                '(削除の場合)

                txtFUSER_ID.Enabled = False                    'ﾕｰｻﾞｰID
                ''txtFLOGIN_ID.Enabled = False                   'ﾛｸﾞｲﾝID
                txtFUSER_NAME.Enabled = False                  'ﾕｰｻﾞｰ名
                cboFREASON.Enabled = True                   '更新理由
                grdList.Enabled = False                        '権限ﾚﾍﾞﾙ

                Exit Select

        End Select

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
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= cmdZikkou.Text & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing
        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(展開元画面の行分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            'ﾁｪｯｸﾎﾞｯｸｽ値ｾｯﾄ
            Dim strDSPCHECK As String = "0"
            Dim blnTrue As Boolean = True
            If grdList.Item(menmListCol.FUSER_ID, ii).Value = blnTrue.ToString Or grdList.Item(menmListCol.FUSER_ID, ii).Value = "1" Then
                '(ﾁｪｯｸが入っている場合)
                strDSPCHECK = "1"
            End If

            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200701              'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            objTelegramSub.SETIN_HEADER("DSPREASON", "")            '理由
            objTelegramSub.SETIN_DATA("DSPDIR_KUBUN", "")           '処理区分
            objTelegramSub.SETIN_DATA("DSPMAINTE_USER_ID", "")      'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
            objTelegramSub.SETIN_DATA("DSPMAINTE_LOGIN_ID", "")     'ﾛｸﾞｲﾝID
            objTelegramSub.SETIN_DATA("DSPMAINTE_USER_NAME", "")    'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名
            objTelegramSub.SETIN_DATA("DSPUSER_DSP_LEVEL", grdList.Item(menmListCol.FUSER_DSP_LEVEL, ii).Value)    'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
            objTelegramSub.SETIN_DATA("DSPCHECK", strDSPCHECK)      'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
            '↓↓↓↓↓ システム固有 
            ''objTelegramSub.SETIN_DATA("XDSPUserIdValidFrom", "")    'ｱｶｳﾝﾄ有効期間_FROM
            ''objTelegramSub.SETIN_DATA("XDSPUserIdValidTo", "")      'ｱｶｳﾝﾄ有効期間_TO
            '↑↑↑↑↑ システム固有
            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED
        Next


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDIR_KUBUN As String = ""             '処理区分
        Dim strMAINTE_USER_ID As String = ""        'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
        Dim strMAINTE_LOGIN_ID As String = ""       'ﾒﾝﾃﾅﾝｽﾛｸﾞｲﾝID
        Dim strMAINTE_USER_NAME As String = ""      'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名
        Dim strREASON As String = ""                '理由ｺｰﾄﾞ
        '↓↓↓↓↓ システム固有
        ''Dim strUserIDValidFrom As String = ""       'ｱｶｳﾝﾄ有効期限FROM
        ''Dim strUserIDValidTo As String = ""         'ｱｶｳﾝﾄ有効期限TO
        '↑↑↑↑↑ システム固有 


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200701              'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        Select Case mintButtonMode
            Case BUTTONMODE_ADD
                '(追加の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_ADD)            '指示区分

            Case BUTTONMODE_UPDATE
                '(変更の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_UPDATE)         '指示区分

            Case BUTTONMODE_DELETE
                '(削除の場合)
                strDIR_KUBUN = TO_STRING(BUTTONMODE_DELETE)         '指示区分

        End Select

        strMAINTE_USER_ID = TO_STRING(txtFUSER_ID.Text)                     'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
        ''strMAINTE_LOGIN_ID = TO_STRING(txtFLOGIN_ID.Text)                   'ﾒﾝﾃﾅﾝｽﾛｸﾞｲﾝID
        strMAINTE_USER_NAME = TO_STRING(txtFUSER_NAME.Text)                 'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名
        strREASON = cboFREASON.Text                                      '理由
       

        objTelegram.SETIN_HEADER("DSPREASON", strREASON)                    '理由
        objTelegram.SETIN_DATA("DSPDIR_KUBUN", strDIR_KUBUN)                '処理区分
        objTelegram.SETIN_DATA("DSPMAINTE_USER_ID", strMAINTE_USER_ID)      'ﾕｰｻﾞｰID
        objTelegram.SETIN_DATA("DSPMAINTE_LOGIN_ID", strMAINTE_LOGIN_ID)    'ﾛｸﾞｲﾝID
        objTelegram.SETIN_DATA("DSPMAINTE_USER_NAME", strMAINTE_USER_NAME)  'ﾕｰｻﾞｰ名
        objTelegram.SETIN_DATA("DSPUSER_DSP_LEVEL", "")                     'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
        objTelegram.SETIN_DATA("DSPCHECK", "")                              'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
        '↓↓↓↓↓ システム固有 
        ''objTelegram.SETIN_DATA("XDSPUserIdValidFrom", strUserIDValidFrom)   'ｱｶｳﾝﾄ有効期間_FROM
        ''objTelegram.SETIN_DATA("XDSPUserIdValidTO", strUserIDValidTo)       'ｱｶｳﾝﾄ有効期間_TO
        '↑↑↑↑↑ システム固有

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM206021_04
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()
            End If
        End If


    End Sub
#End Region

End Class
