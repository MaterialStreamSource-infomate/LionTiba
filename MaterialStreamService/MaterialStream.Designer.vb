Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaterialStream
    Inherits System.ServiceProcess.ServiceBase

    'UserService は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' 処理のメイン エントリ ポイントです。
    <MTAThread()> _
    <System.Diagnostics.DebuggerNonUserCode()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' 2 つ以上の NT サービスを同じプロセス内で実行できます。別のサービスを
        ' この処理に追加するには、以下の行を追加して
        ' 2 番目のサービス オブジェクトを作成してください。例 :
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New MaterialStream}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'コンポーネント デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。  
    ' コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        '
        'MaterialStream
        '
        Me.ServiceName = "MaterialStream"

    End Sub

End Class
