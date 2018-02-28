'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ
' 【機能】ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾋﾞｭｰ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                          "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenCommon.clsComFuncGMN
Imports UserProcess
#End Region

Public Class cmpMDataGrid

#Region "  共通変数                     "
    Public mblnDBUpdate As Boolean = False              'DBｱｯﾌﾟﾃﾞｰﾄ可不可
    Public mblnSelectionChanged As Boolean = False      '選択変更ｲﾍﾞﾝﾄ処理中ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    '''**********************************************************************************************
    ''' <summary>
    ''' DBｱｯﾌﾟﾃﾞｰﾄ可不可
    '''    True    :TDSP_GCOLﾃｰﾌﾞﾙ更新  可能
    '''    False   :TDSP_GCOLﾃｰﾌﾞﾙ更新不可能
    ''' </summary>
    '''**********************************************************************************************
    Public Property blnDBUpdate() As Boolean
        Get
            Return mblnDBUpdate
        End Get
        Set(ByVal Value As Boolean)
            mblnDBUpdate = Value
        End Set
    End Property
    '''**********************************************************************************************
    ''' <summary>
    ''' 選択変更ｲﾍﾞﾝﾄ処理中ﾌﾗｸﾞ
    '''    True    :処理中
    '''    False   :非処理中
    ''' </summary>  
    '''**********************************************************************************************
    Public Property blnSelectionChanged() As Boolean
        Get
            Return mblnSelectionChanged
        End Get
        Set(ByVal Value As Boolean)
            mblnSelectionChanged = Value
        End Set
    End Property
    '''**********************************************************************************************
    ''' <summary>
    ''' 再描画設定
    '''    True    :ちらつき防止表示
    '''    False   :ﾉｰﾏﾙ表示(ﾃﾞﾌｫﾙﾄ)
    ''' </summary>
    '''**********************************************************************************************
    Public Property MyBeseDoubleBuffered() As Boolean
        Get
            Return Me.DoubleBuffered
        End Get
        Set(ByVal Value As Boolean)
            Me.DoubleBuffered = Value
        End Set
    End Property
#End Region

#Region "  列順番変更ｲﾍﾞﾝﾄ              "
    '''**********************************************************************************************
    ''' <summary>
    ''' 列順番変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub cmpMDataGrid_ColumnDisplayIndexChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnDisplayIndexChanged
        Try
            Call TDSP_GCOL_Update()
        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region
#Region "  列幅変更ｲﾍﾞﾝﾄ                "
    '''**********************************************************************************************
    ''' <summary>
    ''' 列幅変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub cmpMDataGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnWidthChanged
        Try
            Call TDSP_GCOL_Update()
        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
#End Region

#Region "  列情報DB更新                 "
    '''**********************************************************************************************
    ''' <summary>
    ''' 列情報DB更新
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub TDSP_GCOL_Update()
        Try
            '************************************************
            '状態ﾁｪｯｸ
            '************************************************
            If mblnDBUpdate = False Then Exit Sub


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:A.Noto 2012/04/28  ﾌﾗｸﾞでｸﾞﾘｯﾄﾞ列幅/列順を登録するか否かを判定
            If TO_NUMBER(gobjComFuncGMN.GetSYS_HEN(FHENSU_ID_SGS000000_032)) = FLAG_OFF Then
                '(ｸﾞﾘｯﾄﾞ列記憶ﾌﾗｸﾞがOFFのとき)
                Exit Sub
            End If
            '↑↑↑↑↑↑************************************************************************************************************


            '************************************************
            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '************************************************
            gobjDb.BeginTrans()
            Try


                '************************************************
                'ｸﾞﾘｯﾄﾞ列ﾏｽﾀ        初期化
                '************************************************
                Dim objTDSP_GCOL As New TBL_TDSP_GCOL(gobjOwner, gobjDb, Nothing)
                objTDSP_GCOL.FUSER_ID = gcstrFUSER_ID               'ﾕｰｻﾞｰID
                objTDSP_GCOL.FDISP_ID = Me.FindForm.Name            '画面ID
                objTDSP_GCOL.FCTRL_ID = Me.Name                     'ｺﾝﾄﾛｰﾙID
                objTDSP_GCOL.DELETE_TDSP_GCOL_FDISP_ID_FCTRL_ID()   '削除


                '************************************************
                'ｸﾞﾘｯﾄﾞ列ﾏｽﾀ        追加
                '************************************************
                For ii As Integer = 0 To Me.ColumnCount - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞの列数)


                    '************************************************
                    'ｸﾞﾘｯﾄﾞ表示の設定
                    '************************************************
                    objTDSP_GCOL.FCOL_INDEX = ii                                        '列ｲﾝﾃﾞｯｸｽ
                    objTDSP_GCOL.FGRID_D_WIDTH = Me.Columns(ii).Width                   '列幅調整
                    objTDSP_GCOL.FGRID_DISPLAYINDEX = Me.Columns(ii).DisplayIndex       'ｸﾞﾘｯﾄﾞ列表示順序


                    '************************************************
                    '追加
                    '************************************************
                    objTDSP_GCOL.ADD_TDSP_GCOL()                                        '追加


                Next


            Catch ex As Exception
                Call gobjComFuncGMN.ComError_frm(ex)
                Throw ex
            Finally


                '************************************************
                'ｺﾐｯﾄ
                '************************************************
                gobjDb.Commit()


            End Try
        Catch ex As Exception
            Call gobjComFuncGMN.ComError_frm(ex)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ｴﾗｰ処理                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub DoError(ByVal ex As Exception)
        MsgBox(ex.Message)
    End Sub
#End Region

#Region "　ｿｰﾄｲﾍﾞﾝﾄ                     "

#End Region
    '''**********************************************************************************************
    ''' <summary>
    ''' ｿｰﾄｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub cmpMDataGrid_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Sorted
        Try
            '**************************************
            '行選択解除
            '**************************************
            Me.ClearSelection()

        Catch ex As Exception
            Call DoError(ex)
        End Try
    End Sub
End Class
