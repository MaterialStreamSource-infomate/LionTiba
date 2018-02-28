'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｼｽﾃﾑ定数ﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_207061

#Region "  共通変数　                           "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mFHENSU_ID As String           '変数ID
    Private mFHENSU_NAME As String         '変数項目名称
    Private mFHENSU_FLAG As String         '変数区分
    Private mFHENSU_KIND As String         'ﾃﾞｰﾀ種別
    Private mFHENSU_INT As String          '整数ﾃﾞｰﾀ
    Private mFHENSU_REAL As String         '実数ﾃﾞｰﾀ
    Private mFHENSU_CHAR As String         '文字ﾃﾞｰﾀ
    Private mFHENSU_DATE As Nullable(Of Date)           '日時ﾃﾞｰﾀ
    Private mobjOwner As FRM_207060      'ｵｰﾅｰﾌｫｰﾑ

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                        "
    Public Property userSTRHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
        End Set
    End Property
    Public Property userSTRHENSU_NAME() As String
        Get
            Return mFHENSU_NAME
        End Get
        Set(ByVal Value As String)
            mFHENSU_NAME = Value
        End Set
    End Property
    Public Property userINTHENSU_KBN() As String
        Get
            Return mFHENSU_FLAG
        End Get
        Set(ByVal Value As String)
            mFHENSU_FLAG = Value
        End Set
    End Property
    Public Property userINTHENSU_KIND() As String
        Get
            Return mFHENSU_KIND
        End Get
        Set(ByVal Value As String)
            mFHENSU_KIND = Value
        End Set
    End Property
    Public Property userINTHENSU_INT() As String
        Get
            Return mFHENSU_INT
        End Get
        Set(ByVal Value As String)
            mFHENSU_INT = Value
        End Set
    End Property
    Public Property userINTHENSU_REAL() As String
        Get
            Return mFHENSU_REAL
        End Get
        Set(ByVal Value As String)
            mFHENSU_REAL = Value
        End Set
    End Property
    Public Property userSTRHENSU_CHAR() As String
        Get
            Return mFHENSU_CHAR
        End Get
        Set(ByVal Value As String)
            mFHENSU_CHAR = Value
        End Set
    End Property
    Public Property userDTMHENSU_DATE() As Nullable(Of Date)
        Get
            Return mFHENSU_DATE
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHENSU_DATE = Value
        End Set
    End Property
    Public Property userOWNER() As FRM_207060
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_207060)
            mobjOwner = Value
        End Set
    End Property
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "  ﾌｫｰﾑﾛｰﾄﾞ処理　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub FRM_207061_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '-------------------------------------
        ' ﾃﾞｰﾀ型ｾﾚｸﾄ
        '-------------------------------------
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboDataType, False, mFHENSU_KIND)            'データ型


        '****************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽｾｯﾄ          （ﾃｷｽﾄ）
        '****************************************************

        '定数ID
        If Not IsNull(mFHENSU_ID) Then
            txtTeisuID.Text = mFHENSU_ID
        End If

        '定数項目名称
        If Not IsNull(mFHENSU_NAME) Then
            txtTeisuName.Text = mFHENSU_NAME
        End If

        '定数整数ﾃﾞｰﾀ
        If Not IsNull(mFHENSU_INT) Then
            txtDataSeisu.Text = mFHENSU_INT
        End If

        '定数実数ﾃﾞｰﾀ
        If Not IsNull(mFHENSU_REAL) Then
            txtDataZissu.Text = mFHENSU_REAL
        End If

        '定数文字ﾃﾞｰﾀ
        If Not IsNull(mFHENSU_CHAR) Then
            txtDataString.Text = TO_STRING(mFHENSU_CHAR)
        End If

        '定数日時ﾃﾞｰﾀ
        If IsNull(mFHENSU_DATE) Then
            '(ﾃﾞｰﾀがない場合)
            dtpDate.cmpMDateTimePicker_D.Value = Now
            dtpDate.cmpMDateTimePicker_T.Value = Now

        Else
            '(ﾃﾞｰﾀがある場合)
            dtpDate.cmpMDateTimePicker_D.Value = mFHENSU_DATE
            dtpDate.cmpMDateTimePicker_T.Value = mFHENSU_DATE

        End If


        '****************************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽｾｯﾄ          （Enabled、Color）
        '****************************************************
        Select Case mFHENSU_KIND
            Case FHENSU_KIND_SINT
                txtDataSeisu.Enabled = True
                txtDataSeisu.BackColor = Color.White

            Case FHENSU_KIND_SREAL
                txtDataZissu.Enabled = True
                txtDataZissu.BackColor = Color.White

            Case FHENSU_KIND_SCHAR
                txtDataString.Enabled = True
                txtDataString.BackColor = Color.White

            Case FHENSU_KIND_SDATE
                dtpDate.Enabled = True

        End Select

    End Sub
#End Region
#Region "　実行　 　 ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 実行   押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdZikkou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZikkou.Click
        Try

            '******************************************
            ' ｿｹｯﾄ送信処理
            '******************************************
            Call SendSocket01()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#Region "　ｷｬﾝｾﾙ   　ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ 押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

#End Region
#Region "  ｿｹｯﾄ送信                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
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
        strMessage &= "システム定数　" & "「" & cboDataType.Text & "」" & "　データの" & vbCrLf
        strMessage &= "変更処理を実施しますか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200601    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPHENSU_ID", txtTeisuID.Text)                                      '定数ID
        Select Case TO_INTEGER(cboDataType.SelectedValue.ToString)
            Case FHENSU_KIND_SINT
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataSeisu.Text)                          '定数整数ﾃﾞｰﾀ

            Case FHENSU_KIND_SREAL
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataZissu.Text)                          '定数実数ﾃﾞｰﾀ

            Case FHENSU_KIND_SCHAR
                objTelegram.SETIN_DATA("DSPHENSU_DATA", txtDataString.Text)                         '定数文字ﾃﾞｰﾀ

            Case FHENSU_KIND_SDATE
                objTelegram.SETIN_DATA("DSPHENSU_DATA", dtpDate.userDateTimeText)                   '定数日付ﾃﾞｰﾀ

        End Select

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = FRM_MSG_FRM207061_01
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
                Me.Dispose()
            End If
        End If


    End Sub

#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class