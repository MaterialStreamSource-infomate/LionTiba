Partial Class cmpCboXSEIHIN_CD
    Inherits System.Windows.Forms.ComboBox
    'Inherits MateCommon.cmpMComboBox

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

End Class
