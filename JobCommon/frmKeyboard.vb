'*******************************************************************************
'生産管理ｼｽﾃﾑ
'機能名     ：ﾀｯﾁｷｰﾎﾞｰﾄﾞﾃﾞｰﾀ入力画面
'ファイル名 ：frmKeyboard.vb
'プロセス名 ：ﾀｯﾁﾊﾟﾈﾙ作業操作系ﾌﾟﾛｾｽ・管理操作系ﾌﾟﾛｾｽ
'*******************************************************************************


' 以下の名前空間をインポートする
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmKeyboard
    Inherits System.Windows.Forms.Form


#Region "  ﾌﾟﾛﾊﾟﾃｨ        "

#Region "  ﾃｷｽﾄﾎﾞｯｸｽ"

    ''' =======================================
    ''' <summary></summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTextBoxValue() As String
        '値を取得する
        Get
            Return txtInputData.Text
        End Get
        '値を設定する
        Set(ByVal Value As String)
            txtInputData.Text = Value
            mstrOldInputDate = Value
        End Set
    End Property
#End Region

#Region "  ﾊﾟｽﾜｰﾄﾞﾌﾗｸﾞ"
    ''' =======================================
    ''' <summary>ﾊﾟｽﾜｰﾄﾞﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userPasswordFlag() As Boolean
        '値を取得する
        Get
            Return mblnPasswordFlg
        End Get
        '値を設定する
        Set(ByVal Value As Boolean)
            mblnPasswordFlg = Value
        End Set
    End Property
#End Region

#Region "  画面固定ﾌﾗｸﾞ"
    ''' =======================================
    ''' <summary>画面固定ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMoveable() As Boolean
        Get
            Return Me._Moveable
        End Get

        Set(ByVal value As Boolean)
            Me._Moveable = value
        End Set
    End Property
#End Region

#Region "  最大文字数"
    ''' =======================================
    ''' <summary>最大文字数</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userMaxTextLength() As Integer
        '値を取得する
        Get
            Return mintMaxTextLength
        End Get
        '値を設定する
        Set(ByVal Value As Integer)
            mintMaxTextLength = Value
        End Set
    End Property
#End Region

#Region "  画面位置固定ﾌﾗｸﾞ"
    ''' =======================================
    ''' <summary>画面位置固定ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userFormLock() As enmFormLock
        '値を取得する
        Get
            Return mudtFormLock
        End Get
        '値を設定する
        Set(ByVal Value As enmFormLock)
            mudtFormLock = Value
        End Set
    End Property
#End Region

#Region "  入力制限ﾌﾗｸﾞ"
    ''' =======================================
    ''' <summary>入力制限ﾌﾗｸﾞ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userButtonEnable() As enmButtonEnable
        '値を取得する
        Get
            Return mudtButtonEnable
        End Get
        '値を設定する
        Set(ByVal Value As enmButtonEnable)
            mudtButtonEnable = Value
        End Set
    End Property
#End Region

#End Region

#Region "  共通変数         "

#Region "  宣言"
    '---------- <定数宣言部> ----------
    Private Const VAL_BUTTON_NUM As Integer = 10        '数値ﾎﾞﾀﾝ数
    Private Const ALPHA_BUTTON_NUM As Integer = 26      '英字ﾎﾞﾀﾝ数
    Private Const SIGN_BUTTON_NUM As Integer = 6       '記号ﾎﾞﾀﾝ

    '---------- <外部変数宣言部> ----------
    Private mintCursorPoint As Integer          'ｶｰｿﾙﾎﾟｲﾝﾄ
    Private mstrOldInputDate As String          '変更前のﾃﾞｰﾀ
    Private mintMaxTextLength As Integer        '最大文字列長


    '---------- <ﾌﾟﾛﾊﾟﾃｨ変数宣言部> ----------
    Private mblnPasswordFlg As Boolean              'ﾊﾟｽﾜｰﾄﾞﾌﾗｸﾞ
    Private mudtButtonEnable As enmButtonEnable     'ﾎﾞﾀﾝ制限
    Private mudtFormLock As enmFormLock             '画面位置設定
    Private _Moveable As Boolean = True             '画面固定

    'ｺﾝﾄﾛｰﾙ配列
    Private objInputNumBtn(VAL_BUTTON_NUM) As System.Windows.Forms.Button           '数値ﾎﾞﾀﾝ
    Private objInputAlphaBtn(ALPHA_BUTTON_NUM) As System.Windows.Forms.Button
    '英字ﾎﾞﾀﾝ
    Private objInputSignBtn(SIGN_BUTTON_NUM) As System.Windows.Forms.Button         '記号ﾎﾞﾀﾝ


    ''' <summary>ﾎﾞﾀﾝ制限</summary>
    Enum enmButtonEnable
        All                 '全て
        Number              '数値のみ
    End Enum

    ''' <summary>画面位置設定</summary>
    Enum enmFormLock
        lock                 '画面固定
        unlock               '固定解除
    End Enum

#End Region

#End Region

#Region "  ｲﾍﾞﾝﾄ         "

#Region "  ﾌｫｰﾑﾛｰﾄﾞ時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>画面ﾛｰﾄﾞ時の初期処理を行う</remarks>
    ''' *******************************************************************************************************************
    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intCount As Integer   'ｶｳﾝﾀ値
        Dim intii As Integer

        Try
            'mnCursorPoint = 0               'ｶｰｿﾙﾎﾟｲﾝﾄの初期化
            mintCursorPoint = txtInputData.Text.Length        'ｶｰｿﾙﾎﾟｲﾝﾄを文字の最後にする

            'ﾊﾟｽﾜｰﾄﾞﾌﾗｸﾞﾁｪｯｸ
            If mblnPasswordFlg Then
                Me.txtInputData.PasswordChar = "*"
            End If

            '数値ﾎﾞﾀﾝｺﾝﾄﾛｰﾙの配列にすでに作成されているｲﾝｽﾀﾝｽを代入
            objInputNumBtn(0) = cmdNumBtn0  '0
            objInputNumBtn(1) = cmdNumBtn1  '1
            objInputNumBtn(2) = cmdNumBtn2  '2
            objInputNumBtn(3) = cmdNumBtn3  '3
            objInputNumBtn(4) = cmdNumBtn4  '4
            objInputNumBtn(5) = cmdNumBtn5  '5
            objInputNumBtn(6) = cmdNumBtn6  '6
            objInputNumBtn(7) = cmdNumBtn7  '7
            objInputNumBtn(8) = cmdNumBtn8  '8
            objInputNumBtn(9) = cmdNumBtn9  '9

            'ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗに関連付け
            For intCount = 0 To VAL_BUTTON_NUM - 1
                AddHandler objInputNumBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '英字ﾎﾞﾀﾝｺﾝﾄﾛｰﾙの配列にすでに作成されているｲﾝｽﾀﾝｽを代入
            objInputAlphaBtn(0) = cmdAlphaBtn0        'A
            objInputAlphaBtn(1) = cmdAlphaBtn1        'B
            objInputAlphaBtn(2) = cmdAlphaBtn2        'C
            objInputAlphaBtn(3) = cmdAlphaBtn3        'D
            objInputAlphaBtn(4) = cmdAlphaBtn4        'E
            objInputAlphaBtn(5) = cmdAlphaBtn5        'F
            objInputAlphaBtn(6) = cmdAlphaBtn6        'G
            objInputAlphaBtn(7) = cmdAlphaBtn7        'H
            objInputAlphaBtn(8) = cmdAlphaBtn8        'I
            objInputAlphaBtn(9) = cmdAlphaBtn9        'J
            objInputAlphaBtn(10) = cmdAlphaBtn10      'K
            objInputAlphaBtn(11) = cmdAlphaBtn11      'L
            objInputAlphaBtn(12) = cmdAlphaBtn12      'M
            objInputAlphaBtn(13) = cmdAlphaBtn13      'N
            objInputAlphaBtn(14) = cmdAlphaBtn14      'O
            objInputAlphaBtn(15) = cmdAlphaBtn15      'P
            objInputAlphaBtn(16) = cmdAlphaBtn16      'Q
            objInputAlphaBtn(17) = cmdAlphaBtn17      'R
            objInputAlphaBtn(18) = cmdAlphaBtn18      'S
            objInputAlphaBtn(19) = cmdAlphaBtn19      'T
            objInputAlphaBtn(20) = cmdAlphaBtn20      'U
            objInputAlphaBtn(21) = cmdAlphaBtn21      'V
            objInputAlphaBtn(22) = cmdAlphaBtn22      'W
            objInputAlphaBtn(23) = cmdAlphaBtn23      'X
            objInputAlphaBtn(24) = cmdAlphaBtn24      'Y
            objInputAlphaBtn(25) = cmdAlphaBtn25      'Z

            'ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗに関連付け
            For intCount = 0 To ALPHA_BUTTON_NUM - 1
                AddHandler objInputAlphaBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '記号ﾎﾞﾀﾝｺﾝﾄﾛｰﾙの配列にすでに作成されているｲﾝｽﾀﾝｽを代入
            objInputSignBtn(0) = cmdSignBtn0    '.
            objInputSignBtn(1) = cmdSignBtn1    '+
            objInputSignBtn(2) = cmdSignBtn2    '-(文字側)
            objInputSignBtn(3) = cmdSignBtn5    '$
            objInputSignBtn(4) = cmdSignBtn6    '\
            objInputSignBtn(5) = cmdSignBtn9    '-(電卓側)

            'ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗに関連付け
            For intCount = 0 To SIGN_BUTTON_NUM - 1
                AddHandler objInputSignBtn(intCount).Click, AddressOf InputBtn_Click
            Next

            '入力制限
            If mudtButtonEnable <> enmButtonEnable.All Then
                For intii = 0 To 25
                    objInputAlphaBtn(intii).Enabled = False
                Next
                For intii = 0 To 5
                    objInputSignBtn(intii).Enabled = False
                Next
            End If

            '画面位置設定
            If mudtFormLock = enmFormLock.lock Then
                'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterParent
            End If

        Catch ex As Exception
            Call ComError(ex)

        Finally

        End Try
    End Sub
#End Region

#Region "  ｢ｷｬﾝｾﾙ｣ﾎﾞﾀﾝ押下時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｢ｷｬﾝｾﾙ｣ﾎﾞﾀﾝ押下時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>入力内容を破棄し、当画面を終了する</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnESC.Click
        Try
            txtInputData.Text = mstrOldInputDate
            '画面ｸﾛｰｽﾞ
            Me.Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  「OK」ﾎﾞﾀﾝ押下時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「OK」ﾎﾞﾀﾝ押下時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>入力内容を確定し、当画面を終了する</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnENT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnENT.Click
        Try
            '画面ｸﾛｰｽﾞ
            Me.Close()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  「BS」ﾎﾞﾀﾝ押下時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 「BS」ﾎﾞﾀﾝ押下時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>ｶｰｿﾙ位置の一つ前の文字を削除する
    ''' ｶｰｿﾙ位置が先頭文字より前の場合は削除不可</remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdBtnBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBtnBS.Click
        Try
            Call RemoveChar()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  入力ﾎﾞﾀﾝ押下時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾎﾞﾀﾝ押下時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>半角数字"0"～"9"、半角英文字"A"～"Z"、"."、"+"、"-"、"*"、"/"の内ｸﾘｯｸされたﾎﾞﾀﾝの値(Textﾌﾟﾛﾊﾟﾃｨ値)を入力する
    ''' </remarks>
    ''' *******************************************************************************************************************
    Private Sub InputBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strInputChar As String    '入力文字列

        Try
            'ｸﾘｯｸされたﾎﾞﾀﾝのTextﾌﾟﾛﾊﾟﾃｨ値取得
            strInputChar = CType(sender, System.Windows.Forms.Button).Text
            '文字入力処理
            Call InsertChar(strInputChar)

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try
    End Sub
#End Region

#Region "  入力ﾃﾞｰﾀ表示部ｸﾘｯｸ時処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾃﾞｰﾀ表示部ｸﾘｯｸ時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>ｶｰｿﾙをmnCursorPointに合わせる</remarks>
    ''' *******************************************************************************************************************
    Private Sub txtInputData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInputData.Click
        Try

            'ｶｰｿﾙを末尾に移動
            txtInputData.SelectionStart = Len(txtInputData.Text)

            'ﾌｫｰｶｽ移動処理
            Call MoveFocus()


        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#End Region

#Region "  文字入力処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字入力処理
    ''' </summary>
    ''' <param name="strInputChar">入力文字</param>
    ''' <remarks>入力文字をｶｰｿﾙ位置に挿入する</remarks>
    ''' *******************************************************************************************************************
    Private Sub InsertChar(ByVal strInputChar As String)
        Dim strCurrString As String   '現在文字列

        Try
            '現在のﾃｷｽﾄﾎﾞｯｸｽ文字列を取得
            strCurrString = txtInputData.Text

            '文字列長ﾁｪｯｸ
            If strCurrString.Length < mintMaxTextLength Then
                '最大入力文字以下の場合
                '現在の文字列内に入力文字を挿入
                txtInputData.Text = strCurrString.Insert(mintCursorPoint, strInputChar)

                'ｶｰｿﾙﾎﾟｲﾝﾄｲｸﾘﾒﾝﾄ処理
                Call MoveIncCursorPoint()

            End If

            'ﾌｫｰｶｽ移動処理
            Call MoveFocus()

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try
    End Sub
#End Region

#Region "  文字削除処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 文字削除処理
    ''' </summary>
    ''' <remarks>ｶｰｿﾙ位置の文字を削除する(BSｷｰ)</remarks>
    ''' *******************************************************************************************************************
    Private Sub RemoveChar()
        Dim strCurrString As String   '現在文字列

        Try
            '現在のﾃｷｽﾄﾎﾞｯｸｽ文字列を取得
            strCurrString = txtInputData.Text

            If mintCursorPoint > 0 Then
                'ｶｰｿﾙ位置が先頭でない場合
                '入力ﾃﾞｰﾀ表示文字列のｶｰｿﾙ位置の一つ前の文字を一文字分削除
                txtInputData.Text = strCurrString.Remove(mintCursorPoint - 1, 1)

                'ｶｰｿﾙﾎﾟｲﾝﾄﾃﾞｸﾘﾒﾝﾄ処理
                Call MoveDecCursorPoint()
            End If

            'ﾌｫｰｶｽ移動処理
            Call MoveFocus()

        Catch ex As Exception
            Call ComError(ex)
        Finally

        End Try

    End Sub
#End Region

#Region "  ｶｰｿﾙﾎﾟｲﾝﾄｲﾝｸﾘﾒﾝﾄ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｶｰｿﾙﾎﾟｲﾝﾄｲﾝｸﾘﾒﾝﾄ処理
    ''' </summary>
    ''' <remarks>ｶｰｿﾙﾎﾟｲﾝﾄを一つ進める
    ''' ただし、ｶｰｿﾙ位置が最大文字列以上、あるいは最後尾の場合はそれ以上は進めない</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveIncCursorPoint()
        Try
            If mintCursorPoint < mintMaxTextLength And _
                mintCursorPoint < txtInputData.TextLength Then
                'ｶｰｿﾙﾎﾟｲﾝﾄが最大文字列以下かつ現在の最後尾でない場合
                mintCursorPoint += 1      'ｶｰｿﾙﾎﾟｲﾝﾄのｲﾝｸﾘﾒﾝﾄ
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try

    End Sub
#End Region

#Region "  ｶｰｿﾙﾎﾟｲﾝﾄﾃﾞｸﾘﾒﾝﾄ処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｶｰｿﾙﾎﾟｲﾝﾄﾃﾞｸﾘﾒﾝﾄ処理
    ''' </summary>
    ''' <remarks>ｶｰｿﾙ位置を一つ戻す
    ''' ただし、ｶｰｿﾙ位置が最初にある場合はそれ以上戻れない</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveDecCursorPoint()
        Try
            If mintCursorPoint > 0 Then
                'ｶｰｿﾙﾎﾟｲﾝﾄが先頭でない場合
                mintCursorPoint -= 1      'ｶｰｿﾙﾎﾟｲﾝﾄのﾃﾞｸﾘﾒﾝﾄ
            End If
        Catch ex As Exception
            Call ComError(ex)
        End Try

    End Sub
#End Region

#Region "  ﾃｷｽﾄﾎﾞｯｸｽへﾌｫｰｶｽ移動処理"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾎﾞｯｸｽへﾌｫｰｶｽ移動処理
    ''' </summary>
    ''' <remarks>文字入力後、ﾌｫｰｶｽをﾃｷｽﾄﾎﾞｯｸｽへ戻す</remarks>
    ''' *******************************************************************************************************************
    Private Sub MoveFocus()
        Try
            'ｶｰｿﾙ位置を設定
            txtInputData.SelectionStart = mintCursorPoint
            ' ''選択長を0に設定
            ''txtInputData.SelectionLength = 0
            'ﾌｫｰｶｽを移す
            txtInputData.Focus()
        Catch ex As Exception
            Call ComError(ex)
        End Try
    End Sub
#End Region

#Region "  WndProcﾒｿｯﾄﾞのｵｰﾊﾞｰﾗｲﾄﾞ"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' WndProcﾒｿｯﾄﾞのｵｰﾊﾞｰﾗｲﾄﾞ
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Protected Overrides Sub WndProc(ByRef m As Message)
        If Me.userMoveable = False Then
            Const WM_SYSCOMMAND As Integer = &H112
            Const SC_MOVE As Integer = &HF010
            Const SC_MASK As Integer = &HFFF0

            ' フォームの移動を捕捉したら以降の制御をカットする
            If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And SC_MASK) = SC_MOVE Then
                Return
            End If
        End If

        ' 基本クラスのメソッドを実行する
        MyBase.WndProc(m)
    End Sub
#End Region

#Region "  ｴﾗｰ処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｴﾗｰ処理
    ''' </summary>
    ''' <param name="objException"></param>
    ''' <remarks>ｴﾗｰﾒｯｾｰｼﾞをﾒｯｾｰｼﾞﾎﾞｯｸｽで表示する</remarks>
    ''' *******************************************************************************************************************
    Private Sub ComError(ByVal objException As Exception)
        Try

            '**************************************************
            'ｴﾗｰﾒｯｾｰｼﾞ表示
            '**************************************************
            Dim strMsg As String = ""
            strMsg &= "ｴﾗｰが発生しました。"
            strMsg &= vbCrLf & objException.Message
            MsgBox(strMsg)

        Catch ex As Exception
            '何もしない

        End Try
    End Sub
#End Region

End Class