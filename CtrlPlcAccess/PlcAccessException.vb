'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ 例外 ｸﾗｽ
' 【作成】2005/11/28　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Public Class PlcAccessException
    Inherits ApplicationException

#Region "初期/終了 処理"
    Public Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
#End Region

End Class
