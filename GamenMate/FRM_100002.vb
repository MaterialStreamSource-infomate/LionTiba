'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾂﾘｰ画面
' 【作成】SIT
'**********************************************************************************************

#Region " Imports                                "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100002

#Region "  内部変数                             "
    '************************************************************************
    ' 内部変数
    '************************************************************************
    Private mblnTreeViewClick As Boolean            'ﾂﾘｰﾋﾞｭｰがｸﾘｯｸされた直後を示すﾌﾗｸﾞ

    '----------------------------------------
    ' ﾌﾟﾛﾊﾟﾃｨ用変数
    '----------------------------------------
    Private mblnCANCEL As Boolean           'ｷｬﾝｾﾙ
    Private mstrNowDispID As String         '現在の         画面ID
    Private mstrNextDISP_ID As String       '次に展開する   画面ID

    '----------------------------------------
    ' Config    取得ﾃﾞｰﾀ
    '----------------------------------------
    Private minttmrTest_1_Interval As Integer       '画面遷移ﾃｽﾄ用            ﾀｲﾏｰ
    Private mstrTMRTEST_1_Flag As String            '画面遷移ﾃｽﾄ用            ﾀｲﾏｰﾌﾗｸﾞ

#End Region

#Region "  TreeNode.Tagﾌﾟﾛﾊﾟﾃｨに挿入する        ｵﾌﾞｼﾞｪｸﾄｸﾗｽ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' TreeNode.Tagﾌﾟﾛﾊﾟﾃｨに挿入するｵﾌﾞｼﾞｪｸﾄｸﾗｽ
    ''' </summary>
    ''' <remarks>他に必要な項目が出て来るかもしれないので、一応ｸﾗｽにしてみた</remarks>
    ''' *******************************************************************************************************************
    Private Class clsTreeNode_Tag

        '共通変数
        Private mSTRDISP_ID As String       '画面ID

        'ﾌﾟﾛﾊﾟﾃｨ
        Public Property STRDISP_ID() As String
            Get
                Return mSTRDISP_ID
            End Get
            Set(ByVal Value As String)
                mSTRDISP_ID = Value
            End Set
        End Property

    End Class
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                              "
    Public ReadOnly Property CANCEL() As Boolean
        Get
            Return mblnCANCEL
        End Get
    End Property

    Public Property NowDispID() As String
        Get
            Return mstrNowDispID
        End Get
        Set(ByVal Value As String)
            mstrNowDispID = Value
        End Set
    End Property

    Public ReadOnly Property NextDISP_ID() As String
        Get
            Return mstrNextDISP_ID
        End Get
    End Property

#End Region
#Region "  ｲﾍﾞﾝﾄ　　　　　                      "
#Region "  ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call FormLoad()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  F8(戻る)  ﾎﾞﾀﾝ                   ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る)  ﾎﾞﾀﾝｸﾘｯｸ"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            Call cmdF8Proc()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰﾉｰﾄﾞ                      選択直後（ｸﾘｯｸ以外や、ﾌﾟﾛｸﾞﾗﾑ選択時でも発生）"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰﾉｰﾄﾞ 選択直後（ｸﾘｯｸ以外や、ﾌﾟﾛｸﾞﾗﾑ選択時でも発生）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvTree.AfterSelect
        Try
            Dim intRet As Integer

            '***************************************************
            ' ﾂﾘｰﾋﾞｭｰから画面遷移
            '***************************************************
            If mblnTreeViewClick = True Then
                intRet = NextForm(sender, e)
            End If

            If intRet <> RetCode.OK Then
                mblnTreeViewClick = False
            End If


            '''''If mblnTrvClick = True Then
            '''''Call StartProc_FromTreeView(sender, e)
            '''''If Me.CANCEL = False Then
            '''''    Me.Close()
            '''''End If
            '''''End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰﾋﾞｭｰ                          ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰﾋﾞｭｰ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvTree.Click
        Try

            mblnTreeViewClick = True

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰﾉｰﾄﾞのない所でﾏｳｽﾎﾞﾀﾝ         ｸﾘｯｸ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰﾉｰﾄﾞのない所でﾏｳｽﾎﾞﾀﾝ ｸﾘｯｸ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvTree.MouseDown
        Try

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  ﾌｧﾝｸｼｮﾝｷｰ                    押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｧﾝｸｼｮﾝｷｰ押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmTree_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Select Case e.KeyCode
                Case Windows.Forms.Keys.F8
                    cmdF8Proc()
            End Select


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  Enterｷｰ                      押下処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' Enterｷｰ押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub trvTree_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvTree.KeyDown
        Try
            '***************************************************
            ' ﾂﾘｰﾋﾞｭｰから画面遷移
            '***************************************************
            If e.KeyCode = Keys.Enter Then
                Call NextForm(sender, e)
            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  画面遷移ﾃｽﾄ                      ﾀｲﾏｰ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移ﾃｽﾄﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmrTest_1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest_1.Tick
        Try
            Call FORM_MOVE_TEST()

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "  ﾌｫｰﾑﾛｰﾄﾞ         処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FormLoad()
        Try
            '*************************************************
            'Configﾌｧｲﾙ取得
            '*************************************************
            minttmrTest_1_Interval = Val(gobjComFuncFRM.GET_CONFIG_INFO(GKEY_tmrTest_1_Interval))      '画面遷移ﾃｽﾄ用            ﾀｲﾏｰ
            mstrTMRTEST_1_Flag = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_TMRTEST_1_FLG)                    '画面遷移ﾃｽﾄ用            ﾀｲﾏｰﾌﾗｸﾞ


            '*************************************************
            'ﾀｲﾏｰ初期化
            '*************************************************
            tmrTest_1.Interval = minttmrTest_1_Interval
            Select Case mstrTMRTEST_1_Flag
                Case FLAG_ON
                    tmrTest_1.Enabled = True
                Case Else
                    tmrTest_1.Enabled = False
            End Select


            '*************************************************
            '共通変数    初期化
            '*************************************************
            '------------------------------
            'ﾌﾟﾛﾊﾟﾃｨ変数    初期化
            '------------------------------
            mblnCANCEL = True


            '------------------------------
            'その他
            '------------------------------
            mblnTreeViewClick = False


            '*************************************************
            ' ﾂﾘｰﾋﾞｭｰ表示
            '*************************************************
            Call Make_Tree()


            '*************************************************
            ' ﾂﾘｰﾋﾞｭｰ選択
            '*************************************************
            trvTree.Select()


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  F8(戻る)  ﾎﾞﾀﾝ押下     処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8Proc()
        Try

            mblnCANCEL = True                                   'ｷｬﾝｾﾙﾌﾟﾛﾊﾟﾃｨ   ｾｯﾄ
            Me.DialogResult = Windows.Forms.DialogResult.No     '自身非表示（非表示しているだけ）
            tmrTest_1.Enabled = False                           '画面遷移ﾃｽﾄ      ﾀｲﾏｰ処理  ｵﾌ

        Catch ex As Exception
            ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region

    '************************************************************************
    ' ﾌﾟﾗｲﾍﾞｰﾄ関数
    '************************************************************************

#Region "  ﾂﾘｰﾋﾞｭｰ表示                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰﾋﾞｭｰ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Make_Tree()
        Try
            'DB関係
            Dim strSQL As String                    'SQL文
            Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intRet As RetCode                   '戻値用

            'ﾂﾘｰﾋﾞｭｰ関係
            Dim objTreeNode(0) As TreeNode          'ﾂﾘｰﾉｰﾄﾞ
            Dim strBefore_ID(9) As String           '前回のﾂﾘｰID
            Dim strNow_ID(9) As String              '今回のﾂﾘｰID
            Dim intBefore_Level As Integer = 0      '前回のﾉｰﾄﾞを追加した階層を記憶
            Dim objTemp_TrNode(9) As TreeNode       'ﾉｰﾄﾞの記憶
            Dim blnExit_For As Boolean = False      'ﾙｰﾌﾟ脱出ﾌﾗｸﾞ

            'その他
            Dim ii As Integer = 0



            '**********************************************************************************
            ' 初期設定
            '**********************************************************************************
            '--------------------------------
            'その他         初期化
            '--------------------------------
            ii = 0
            intBefore_Level = 0
            blnExit_For = False
            trvTree.Nodes.Clear()               'ｺﾚｸｼｮﾝから、すべてのﾂﾘｰﾉｰﾄﾞを削除
            For jj As Integer = 0 To 9
                strBefore_ID(jj) = "00"
                strNow_ID(jj) = "00"
            Next


            '**********************************************************************************
            ' DBからﾃﾞｰﾀ取得
            '**********************************************************************************
            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    TDSP_TREE.FTREE_ID             FTREE_ID"            '画面ﾂﾘｰﾏｽﾀ.    ﾂﾘｰID
            strSQL &= vbCrLf & "  , TDSP_TREE.FDISP_ID             FDISP_ID"            '画面ﾂﾘｰﾏｽﾀ.    遷移可能画面ID
            strSQL &= vbCrLf & "  , TDSP_NAME.FOBJECT_NAME          FOBJECT_NAME"         '画面ﾏｽﾀ.       画面名称
            strSQL &= vbCrLf & "  , TDSP_PMT_TERM.FOPE_FLAG        FOPE_FLAG_T"         '端末別許可ﾏｽﾀ. 操作ﾌﾗｸﾞ
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TDSP_TREE"      '画面ﾂﾘｰﾏｽﾀ
            strSQL &= vbCrLf & "  , TDSP_NAME"      '画面ﾏｽﾀ
            strSQL &= vbCrLf & "  , (SELECT * FROM TDSP_PMT_TERM WHERE TDSP_PMT_TERM.FTERM_KUBUN = " & TO_STRING(gcintFTERM_KBN) & " AND TDSP_PMT_TERM.FCTRL_ID = '" & FCTRL_ID_SKOTEI & "') TDSP_PMT_TERM"            '端末別許可ﾏｽﾀ
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "        TDSP_TREE.FDISP_ID = TDSP_NAME.FDISP_ID(+) "            '画面ID     結合
            strSQL &= vbCrLf & "    AND TDSP_NAME.FDISP_ID = TDSP_PMT_TERM.FDISP_ID "           '画面ID     結合
            strSQL &= vbCrLf & "    AND TDSP_NAME.FCTRL_ID = TDSP_PMT_TERM.FCTRL_ID "     'ｺﾝﾄﾛｰﾙID   結合
            strSQL &= vbCrLf & " ORDER BY "
            strSQL &= vbCrLf & "    TDSP_TREE.FTREE_ID "

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TDSP_TREE"
            gobjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                For Each objRow In objDataSet.Tables(strDataSetName).Rows
                    '**********************************************************************************
                    ' ﾃﾞｰﾀ取得
                    '**********************************************************************************
                    Dim strFTREE_ID As String = TO_STRING(objRow("FTREE_ID"))
                    Dim strFDISP_ID As String = TO_STRING(objRow("FDISP_ID"))
                    Dim strFOBJECT_NAME As String
                    strFOBJECT_NAME = Replace(TO_STRING(objRow("FOBJECT_NAME")), REPLACE_STRING_01, "")
                    strFOBJECT_NAME = Replace(strFOBJECT_NAME, vbCrLf, "")
                    Dim intFOPE_FLAG_Term As Integer = 0            '操作ﾌﾗｸﾞ   (端末別許可ﾏｽﾀ用)
                    intFOPE_FLAG_Term = IIf(IsDBNull(objRow("FOPE_FLAG_T")), gcintOPE_FLG, TO_NUMBER(objRow("FOPE_FLAG_T")))
                    If intFOPE_FLAG_Term <> FOPE_FLAG_SON Then
                        Continue For
                    End If


                    '**********************************************************************************
                    ' '端末別許可ﾏｽﾀの特定
                    '**********************************************************************************
                    Dim intFOPE_FLAG_User As Integer = 0            '操作ﾌﾗｸﾞ   (ﾕｰｻﾞ別許可ﾏｽﾀ用)
                    Dim strSQLUserLevel As String = ""              'ﾕｰｻﾞﾚﾍﾞﾙのSQL部分
                    For jj As Integer = LBound(gcintFUSER_LEVEL) To UBound(gcintFUSER_LEVEL)
                        '(ﾙｰﾌﾟ:与えられたﾕｰｻﾞﾚﾍﾞﾙ数)

                        Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)   'ﾕｰｻﾞｰ操作ﾏｽﾀ
                        objTDSP_PMT_USER.FUSER_DSP_LEVEL = gcintFUSER_LEVEL(jj)     'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ  ｾｯﾄ
                        objTDSP_PMT_USER.FDISP_ID = strFDISP_ID                     '画面ID
                        objTDSP_PMT_USER.FCTRL_ID = FCTRL_ID_SKOTEI                  'ｺﾝﾄﾛｰﾙID
                        intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)          '取得
                        If intRet = RetCode.OK Then
                            intFOPE_FLAG_User = objTDSP_PMT_USER.FOPE_FLAG
                        Else
                            intFOPE_FLAG_User = gcintOPE_FLG
                        End If
                        If intFOPE_FLAG_User = FOPE_FLAG_SON Then Exit For

                    Next


                    '**********************************************************************************
                    ' TreeNode.Tagﾌﾟﾛﾊﾟﾃｨに挿入する        ｵﾌﾞｼﾞｪｸﾄｸﾗｽｲﾝｽﾀﾝｽ化
                    '**********************************************************************************
                    Dim objTreeNode_Tag As New clsTreeNode_Tag


                    '**********************************************************************************
                    ' ﾉｰﾄﾞ作成
                    '**********************************************************************************
                    '--------------------------------
                    ' ｲﾝｽﾀﾝｽ化
                    '--------------------------------
                    ReDim Preserve objTreeNode(ii)                                 '配列再定義
                    objTreeNode(ii) = New TreeNode(strFOBJECT_NAME, 1, 1)            'ﾉｰﾄﾞｲﾝｽﾀﾝｽ化

                    '--------------------------------
                    ' 色設定
                    '--------------------------------
                    If strFDISP_ID = "" _
                       Or strFDISP_ID = mstrNowDispID _
                       Or intFOPE_FLAG_Term = FOPE_FLAG_SOFF _
                       Or intFOPE_FLAG_User = FOPE_FLAG_SOFF _
                       Then
                        objTreeNode(ii).ForeColor = Color.LightGray                'ﾉｰﾄﾞ色設定 （灰色）
                    Else
                        objTreeNode(ii).ForeColor = Color.Black                    'ﾉｰﾄﾞ色設定 （黒色）
                    End If

                    '--------------------------------
                    ' ｸﾗｽｵﾌﾞｼﾞｪｸﾄ（画面IDｾｯﾄ）
                    '--------------------------------
                    objTreeNode_Tag.STRDISP_ID = strFDISP_ID     '画面IDｾｯﾄ
                    objTreeNode(ii).Tag = objTreeNode_Tag       'ｵﾌﾞｼﾞｪｸﾄｾｯﾄ
                    objTreeNode_Tag = Nothing                   'ｵﾌﾞｼﾞｪｸﾄ開放


                    '**********************************************************************************
                    ' ﾂﾘｰID分解
                    '**********************************************************************************
                    Call Analysis_STRTREE_ID(strNow_ID, strFTREE_ID)


                    '**********************************************************************************
                    ' ﾂﾘｰ作成
                    '**********************************************************************************
                    For jj As Integer = LBound(strNow_ID) To UBound(strNow_ID)
                        If strNow_ID(jj) <> strBefore_ID(jj) Then
                            '**********************************************************************************
                            ' ﾉｰﾄﾞ追加
                            '**********************************************************************************
                            If jj = 0 Then
                                '=======================================================
                                ' ﾂﾘｰ   にﾉｰﾄﾞ追加
                                '=======================================================
                                trvTree.Nodes.Add(objTreeNode(ii))                 ' ﾂﾘｰ   にﾂﾘｰﾉｰﾄﾞ追加

                            Else
                                '=======================================================
                                ' ﾉｰﾄﾞ  にﾉｰﾄﾞ追加
                                '=======================================================
                                If intBefore_Level >= jj Then
                                    '--------------------------------------
                                    ' 前回の階層のﾉｰﾄﾞ      にﾉｰﾄﾞ追加
                                    '--------------------------------------
                                    objTreeNode(jj - 1).Nodes.Add(objTreeNode(ii))    ' ﾂﾘｰﾉｰﾄﾞ   にﾂﾘｰﾉｰﾄﾞ追加
                                Else
                                    '--------------------------------------
                                    ' 前回のﾉｰﾄﾞ            にﾉｰﾄﾞ追加
                                    '--------------------------------------
                                    objTreeNode(ii - 1).Nodes.Add(objTreeNode(ii))    ' ﾂﾘｰﾉｰﾄﾞ   にﾂﾘｰﾉｰﾄﾞ追加
                                End If
                            End If

                            objTreeNode(jj) = objTreeNode(ii)                   ' 前回の階層のﾂﾘｰﾉｰﾄﾞ           を記憶
                            intBefore_Level = jj                                ' 前回のﾂﾘｰﾉｰﾄﾞを追加した階層   を記憶
                            Exit For
                        End If

                        '=======================================================
                        ' 混乱防止
                        '=======================================================
                        If jj >= intBefore_Level + 2 Then
                            Throw New Exception("ﾏｽﾀの定義の仕方が間違っています。")
                        End If
                    Next


                    '=======================================================
                    ' ﾂﾘｰID     記憶
                    '=======================================================
                    For jj As Integer = 0 To 9
                        strBefore_ID(jj) = strNow_ID(jj)
                    Next

                    ii += 1
                Next
            End If



            '*****************************************************************************
            ' 現在のﾌｫｰﾑの場所までﾉｰﾄﾞを展開
            '*****************************************************************************
            Call Development_TreeView()



        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰﾋﾞｭｰから画面遷移  ﾌﾟﾛﾊﾟﾃｨｾｯﾄ      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾂﾘｰﾋﾞｭｰから画面遷移 ﾌﾟﾛﾊﾟﾃｨｾｯﾄ 
    ''' </summary>
    ''' <param name="sender">ｲﾍﾞﾝﾄのｿｰｽ</param>
    ''' <param name="e">ｲﾍﾞﾝﾄﾃﾞｰﾀを格納しているSystem.EventArgs</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function NextForm(ByVal sender As Object, _
                              ByVal e As System.EventArgs) As Integer
        Dim objTreeView As TreeView = CType(sender, TreeView)
        Dim objTreeNode_Tag As clsTreeNode_Tag                      'TreeNode.Tagﾌﾟﾛﾊﾟﾃｨに挿入する  ｵﾌﾞｼﾞｪｸﾄｸﾗｽ


        '*******************************************************
        ' 選択不可の場合、Exit
        '*******************************************************
        Select Case objTreeView.SelectedNode.ForeColor.ToString
            Case Color.LightGray.ToString
                Return (RetCode.NotEnough)
        End Select


        '*******************************************************
        ' 画面遷移処理
        '*******************************************************
        objTreeNode_Tag = objTreeView.SelectedNode.Tag              'ｸﾗｽｵﾌﾞｼﾞｪｸﾄ取得
        mstrNextDISP_ID = objTreeNode_Tag.STRDISP_ID                '次に展開する   画面IDｾｯﾄ
        mblnCANCEL = False                                          'ｷｬﾝｾﾙﾌﾟﾛﾊﾟﾃｨ   ｾｯﾄ
        Me.Close()

        Return (RetCode.OK)
    End Function
#End Region
#Region "  ｴﾗｰ処理                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="ex">ｴﾗｰの Exception</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ComError(ByVal ex As Exception)
        Try

            gobjComFuncFRM.ComError_frm(ex)

        Catch ex2 As Exception
            MsgBox("ComError関数でｴﾗｰ発生")

        End Try
    End Sub
#End Region
#Region "  ﾂﾘｰID文字列      分解                "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ﾂﾘｰID文字列分解
    ''' </summary>
    ''' <param name="strNow_ID"></param>
    ''' <param name="strTREE_ID"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Analysis_STRTREE_ID(ByRef strNow_ID() As String, _
                                    ByVal strTREE_ID As String)
        '=======================================================
        ' 混乱防止
        '=======================================================
        If Len(strTREE_ID) <> 20 Then
            Throw New Exception("ﾏｽﾀの定義の仕方が間違っています。「STRTREE_ID」は必ず20桁で入力して下さい。")
        End If

        strNow_ID(0) = Mid(strTREE_ID, 1, 2)
        strNow_ID(1) = Mid(strTREE_ID, 3, 2)
        strNow_ID(2) = Mid(strTREE_ID, 5, 2)
        strNow_ID(3) = Mid(strTREE_ID, 7, 2)
        strNow_ID(4) = Mid(strTREE_ID, 9, 2)
        strNow_ID(5) = Mid(strTREE_ID, 11, 2)
        strNow_ID(6) = Mid(strTREE_ID, 13, 2)
        strNow_ID(7) = Mid(strTREE_ID, 15, 2)
        strNow_ID(8) = Mid(strTREE_ID, 17, 2)
        strNow_ID(9) = Mid(strTREE_ID, 19, 2)
    End Sub
#End Region
#Region "  現在のﾌｫｰﾑの場所までﾉｰﾄﾞを展開       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 現在のﾌｫｰﾑの場所までﾉｰﾄﾞを展開
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Development_TreeView()

        Dim Node0 As TreeNode
        Dim Node1 As TreeNode
        Dim Node2 As TreeNode
        Dim Node3 As TreeNode
        Dim Node4 As TreeNode
        Dim Node5 As TreeNode
        Dim Node6 As TreeNode
        Dim Node7 As TreeNode
        Dim Node8 As TreeNode
        Dim Node9 As TreeNode

        Dim objTreeNode_Tag As clsTreeNode_Tag
        Dim blnExit_For As Boolean = False      'ﾙｰﾌﾟ脱出ﾌﾗｸﾞ


        trvTree.CollapseAll()                   '全てのﾂﾘｰﾉｰﾄﾞを閉じる
        '' ''trvTree.ExpandAll()                     '全てのﾂﾘｰﾉｰﾄﾞを展開

        For Each Node0 In trvTree.Nodes
            objTreeNode_Tag = Node0.Tag
            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                trvTree.SelectedNode = Node0
                Node0.Expand()
                blnExit_For = True

            Else
                For Each Node1 In Node0.Nodes
                    objTreeNode_Tag = Node1.Tag
                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                        trvTree.SelectedNode = Node1
                        Node1.Expand()
                        blnExit_For = True

                    Else
                        For Each Node2 In Node1.Nodes
                            objTreeNode_Tag = Node2.Tag
                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                trvTree.SelectedNode = Node2
                                Node2.Expand()
                                blnExit_For = True

                            Else
                                For Each Node3 In Node2.Nodes
                                    objTreeNode_Tag = Node3.Tag
                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                        trvTree.SelectedNode = Node3
                                        Node3.Expand()
                                        blnExit_For = True

                                    Else
                                        For Each Node4 In Node3.Nodes
                                            objTreeNode_Tag = Node4.Tag
                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                trvTree.SelectedNode = Node4
                                                Node4.Expand()
                                                blnExit_For = True

                                            Else
                                                For Each Node5 In Node4.Nodes
                                                    objTreeNode_Tag = Node5.Tag
                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                        trvTree.SelectedNode = Node5
                                                        Node5.Expand()
                                                        blnExit_For = True

                                                    Else
                                                        For Each Node6 In Node5.Nodes
                                                            objTreeNode_Tag = Node6.Tag
                                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                trvTree.SelectedNode = Node6
                                                                Node6.Expand()
                                                                blnExit_For = True

                                                            Else
                                                                For Each Node7 In Node6.Nodes
                                                                    objTreeNode_Tag = Node7.Tag
                                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                        trvTree.SelectedNode = Node7
                                                                        Node7.Expand()
                                                                        blnExit_For = True

                                                                    Else
                                                                        For Each Node8 In Node7.Nodes
                                                                            objTreeNode_Tag = Node8.Tag
                                                                            If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                                trvTree.SelectedNode = Node8
                                                                                Node8.Expand()
                                                                                blnExit_For = True

                                                                            Else
                                                                                For Each Node9 In Node8.Nodes
                                                                                    objTreeNode_Tag = Node9.Tag
                                                                                    If objTreeNode_Tag.STRDISP_ID = mstrNowDispID Then
                                                                                        trvTree.SelectedNode = Node9
                                                                                        Node9.Expand()
                                                                                        blnExit_For = True

                                                                                    Else
                                                                                        '-----終了

                                                                                    End If
                                                                                    If blnExit_For = True Then Exit For
                                                                                Next

                                                                            End If
                                                                            If blnExit_For = True Then Exit For
                                                                        Next

                                                                    End If
                                                                    If blnExit_For = True Then Exit For
                                                                Next

                                                            End If
                                                            If blnExit_For = True Then Exit For
                                                        Next

                                                    End If
                                                    If blnExit_For = True Then Exit For
                                                Next

                                            End If
                                            If blnExit_For = True Then Exit For
                                        Next

                                    End If
                                    If blnExit_For = True Then Exit For
                                Next

                            End If
                            If blnExit_For = True Then Exit For
                        Next

                    End If
                    If blnExit_For = True Then Exit For
                Next

            End If
            If blnExit_For = True Then Exit For
        Next

    End Sub
#End Region
#Region "  画面遷移ﾃｽﾄ      ﾀｲﾏｰ処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移ﾃｽﾄﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FORM_MOVE_TEST()

        If Me.Visible = True Then

            gobjComFuncFRM.AddToLog_frm("frmCR2101へ遷移")
            Call cmdF8Proc()
        End If

    End Sub
#End Region

End Class