'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】PLCｱｸｾｽ ｼｽﾃﾑ
' 【機能】PLCｱｸｾｽ 接続基本 ｸﾗｽ
' 【作成】2005/11/08　KSH/S.Ouchi　Rev 0.00　初版
'**********************************************************************************************

Public MustInherit Class UntBase

#Region "内部変数"
    '==================================================
    '   内部変数
    '==================================================
    Private mobjDrv As DrvBase
#End Region

#Region "プロパティ"
    '==================================================
    '   Property    Connector
    '==================================================
    Public Property Connector( _
    ) As DrvBase
        Get
            Return mobjDrv
        End Get
        Set(ByVal Value As DrvBase)
            mobjDrv = Value
        End Set
    End Property
#End Region

#Region "初期/終了 処理"
    '==========================================================
    '【機能】コンストラクタ
    '【引数】接続ﾓｼﾞｭｰﾙ :	DrvBase	    objDrvBase
    '==========================================================
    Public Sub New(ByVal objDrvBase As DrvBase)
        MyBase.New()
        Try
            mobjDrv = objDrvBase
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '==========================================================
    '【機能】デストラクタ
    '==========================================================
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Try
            mobjDrv = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "仮想関数"
    '==========================================================
    '【機能】仮想関数
    '【機能】ビット単位読込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        読込データ	:	int		intBit()
    '==========================================================
    Public Overridable Sub SeqBitRead(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByRef intBit() As Integer)
    End Sub

    '==========================================================
    '【機能】仮想関数
    '【機能】ビット単位書込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intBit()
    '==========================================================
    Public Overridable Sub SeqBitWrite(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByVal intBit() As Integer)
    End Sub

    '==========================================================
    '【機能】仮想関数
    '【機能】ワード単位読込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        読込データ	:	int		intBit()
    '==========================================================
    Public Overridable Sub SeqWordRead(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByRef intWord() As Integer)
    End Sub

    '==========================================================
    '【機能】仮想関数
    '【機能】ワード単位書込
    '【引数】CPU 番号	:	int		intCPU
    '        デバイス名	:	String	strDev
    '        処理数		:	int		intCnt
    '        書込データ	:	int		intBit()
    '==========================================================
    Public Overridable Sub SeqWordWrite(ByVal intCPU As Integer, ByVal strDev As String, ByVal intCnt As Integer, ByVal intWord() As Integer)
    End Sub

#End Region

#Region "左０詰め処理"
    '**********************************************************************************************
    '【機能】桁数に合わせて「左０詰め」で数値を返す
    '        例：    (4, 12) → "0012"
    '                (3, 1)  → "001"
    '【引数】桁数			:	int		intLen
    '        変換数値		:	int		intNum
    '**********************************************************************************************
    Public Shared Function ZeroSppr(ByVal intLen As Integer, ByVal intNum As Integer) As String
        Try
            Dim strNum As String

            strNum = StrDup(intLen, "0") & intNum.ToString
            strNum = Right(strNum, intLen)
            Return strNum
        Catch ex As Exception
            Throw ex

        End Try

    End Function
    '**********************************************************************************************
    '【機能】桁数に合わせて「左０詰め」で数値を返す
    '        例：    (4, 12) → "0012"
    '                (3, 1)  → "001"
    '【引数】桁数			:	int		intLen
    '        変換数値		:	String	srtNum
    '**********************************************************************************************
    Public Shared Function ZeroSppr(ByVal intLen As Integer, ByVal srtNum As String) As String
        Try
            Dim strNum As String

            strNum = StrDup(intLen, "0") & srtNum
            strNum = Right(strNum, intLen)
            Return strNum
        Catch ex As Exception
            Throw ex

        End Try

    End Function
#End Region

#Region "右ｽﾍﾟｰｽ詰め処理"
    '**********************************************************************************************
    '【機能】桁数に合わせて「右ｽﾍﾟｰｽ詰め」で数値を返す
    '        例：    (4, 12) → "12  "
    '                (3, 1)  → "1  "
    '【引数】桁数			:	int		intLen
    '        変換数値		:	int		intNum
    '**********************************************************************************************
    Public Shared Function SpaceSppr(ByVal intLen As Integer, ByVal intNum As Integer) As String
        Try
            Dim strNum As String

            strNum = intNum.ToString & StrDup(intLen, " ")
            strNum = Left(strNum, intLen)
            Return strNum
        Catch ex As Exception
            Throw ex

        End Try

    End Function
    '**********************************************************************************************
    '【機能】桁数に合わせて「右ｽﾍﾟｰｽ詰め」で数値を返す
    '        例：    (4, 12) → "0012"
    '                (3, 1)  → "001"
    '【引数】桁数			:	int		intLen
    '        変換数値		:	String	srtNum
    '**********************************************************************************************
    Public Shared Function SpaceSppr(ByVal intLen As Integer, ByVal srtNum As String) As String
        Try
            Dim strNum As String

            strNum = srtNum & StrDup(intLen, "0")
            strNum = Left(strNum, intLen)
            Return strNum
        Catch ex As Exception
            Throw ex

        End Try

    End Function
#End Region

End Class
