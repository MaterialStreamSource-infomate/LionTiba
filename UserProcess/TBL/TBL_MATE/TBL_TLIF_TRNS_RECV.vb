'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ
' 【作成】2010/03/02  SIT                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' 搬送制御受信IFﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TLIF_TRNS_RECV
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TLIF_TRNS_RECV()                                    '搬送制御受信IF
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFENTRY_NO As String                                                 '登録№
    Private mFEQ_ID As String                                                    '設備ID
    Private mFCOMMAND_ID As String                                               'ｺﾏﾝﾄﾞID
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFTEXT_ID As String                                                  'ﾃｷｽﾄID
    Private mFDENBUN_PRM1 As String                                              '電文ﾊﾟﾗﾒｰﾀ1
    Private mFDENBUN_PRM2 As String                                              '電文ﾊﾟﾗﾒｰﾀ2
    Private mFDENBUN_PRM3 As String                                              '電文ﾊﾟﾗﾒｰﾀ3
    Private mFDENBUN_PRM4 As String                                              '電文ﾊﾟﾗﾒｰﾀ4
    Private mFDENBUN_PRM5 As String                                              '電文ﾊﾟﾗﾒｰﾀ5
    Private mFDENBUN_PRM6 As String                                              '電文ﾊﾟﾗﾒｰﾀ6
    Private mFTRNS_SERIAL As String                                              '搬送ｼﾘｱﾙ№(MCｷｰ)
    Private mFPRIORITY As Nullable(Of Integer)                                   '優先ﾚﾍﾞﾙ
    Private mFDENBUN As String                                                   '通信電文
    Private mFDENBUN02 As String                                                 '通信電文02
    Private mFPROGRESS As Nullable(Of Integer)                                   '進捗状態
    Private mFRES_CD_EQ As String                                                '設備応答ｺｰﾄﾞ
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TLIF_TRNS_RECV()
        Get
            Return mobjAryMe
        End Get
    End Property
    ''' <summary>
    ''' ﾕｰｻﾞｰSQL (文字型)
    ''' </summary>
    Public WriteOnly Property USER_SQL() As String
        Set(ByVal Value As String)
            mstrUSER_SQL = Value
        End Set
    End Property
    ''' <summary>
    ''' OrderBy句
    ''' </summary>
    Public Property ORDER_BY() As String
        Get
            Return mORDER_BY
        End Get
        Set(ByVal Value As String)
            mORDER_BY = Value
        End Set
    End Property
    ''' <summary>
    ''' Where句
    ''' </summary>
    Public Property WHERE() As String
        Get
            Return mWHERE
        End Get
        Set(ByVal Value As String)
            mWHERE = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録№
    ''' </summary>
    Public Property FENTRY_NO() As String
        Get
            Return mFENTRY_NO
        End Get
        Set(ByVal Value As String)
            mFENTRY_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備ID
    ''' </summary>
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾏﾝﾄﾞID
    ''' </summary>
    Public Property FCOMMAND_ID() As String
        Get
            Return mFCOMMAND_ID
        End Get
        Set(ByVal Value As String)
            mFCOMMAND_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃｷｽﾄID
    ''' </summary>
    Public Property FTEXT_ID() As String
        Get
            Return mFTEXT_ID
        End Get
        Set(ByVal Value As String)
            mFTEXT_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ1
    ''' </summary>
    Public Property FDENBUN_PRM1() As String
        Get
            Return mFDENBUN_PRM1
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ2
    ''' </summary>
    Public Property FDENBUN_PRM2() As String
        Get
            Return mFDENBUN_PRM2
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ3
    ''' </summary>
    Public Property FDENBUN_PRM3() As String
        Get
            Return mFDENBUN_PRM3
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ4
    ''' </summary>
    Public Property FDENBUN_PRM4() As String
        Get
            Return mFDENBUN_PRM4
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ5
    ''' </summary>
    Public Property FDENBUN_PRM5() As String
        Get
            Return mFDENBUN_PRM5
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM5 = Value
        End Set
    End Property
    ''' <summary>
    ''' 電文ﾊﾟﾗﾒｰﾀ6
    ''' </summary>
    Public Property FDENBUN_PRM6() As String
        Get
            Return mFDENBUN_PRM6
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM6 = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送ｼﾘｱﾙ№(MCｷｰ)
    ''' </summary>
    Public Property FTRNS_SERIAL() As String
        Get
            Return mFTRNS_SERIAL
        End Get
        Set(ByVal Value As String)
            mFTRNS_SERIAL = Value
        End Set
    End Property
    ''' <summary>
    ''' 優先ﾚﾍﾞﾙ
    ''' </summary>
    Public Property FPRIORITY() As Nullable(Of Integer)
        Get
            Return mFPRIORITY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPRIORITY = Value
        End Set
    End Property
    ''' <summary>
    ''' 通信電文
    ''' </summary>
    Public Property FDENBUN() As String
        Get
            Return mFDENBUN
        End Get
        Set(ByVal Value As String)
            mFDENBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 通信電文02
    ''' </summary>
    Public Property FDENBUN02() As String
        Get
            Return mFDENBUN02
        End Get
        Set(ByVal Value As String)
            mFDENBUN02 = Value
        End Set
    End Property
    ''' <summary>
    ''' 進捗状態
    ''' </summary>
    Public Property FPROGRESS() As Nullable(Of Integer)
        Get
            Return mFPROGRESS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPROGRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備応答ｺｰﾄﾞ
    ''' </summary>
    Public Property FRES_CD_EQ() As String
        Get
            Return mFRES_CD_EQ
        End Get
        Set(ByVal Value As String)
            mFRES_CD_EQ = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録日時
    ''' </summary>
    Public Property FENTRY_DT() As Nullable(Of Date)
        Get
            Return mFENTRY_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFENTRY_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新日時
    ''' </summary>
    Public Property FUPDATE_DT() As Nullable(Of Date)
        Get
            Return mFUPDATE_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFUPDATE_DT = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)   '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ取得                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得
    ''' </summary>
    ''' <param name="blnNotFoundError">ﾚｺｰﾄﾞが一件も取得出来なかった場合、Throwするか否かのﾌﾗｸﾞ</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TLIF_TRNS_RECV(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    *")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --通信電文")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --通信電文02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --進捗状態")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        If IsNotNull(mORDER_BY) Then
            strSQL.Append(vbCrLf & " ORDER BY ")
            strSQL.Append(vbCrLf & mORDER_BY)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        ElseIf objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then

            If blnNotFoundError = True Then
                '(ｴﾗｰとする場合)
                Dim strMsg As String = ""
                Call MAKE_ERRMSG01(strMsg)
                Throw New UserException(strMsg)
            Else
                '(ｴﾗｰしない場合)
                Return (RetCode.NotFound)
            End If

        Else
            Throw New UserException("複数ﾚｺｰﾄﾞ抽出した為、ｴﾗｰとします。")
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(複数ﾚｺｰﾄﾞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(複数ﾚｺｰﾄﾞ)
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TLIF_TRNS_RECV_ANY() As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    *")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --通信電文")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --通信電文02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --進捗状態")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        If IsNotNull(mORDER_BY) Then
            strSQL.Append(vbCrLf & " ORDER BY ")
            strSQL.Append(vbCrLf & mORDER_BY)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLIF_TRNS_RECV(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)
    ''' </summary>
    ''' <param name="objUSER_PARAM">ﾕｰｻﾞｰPARAM (ﾊﾞｲﾝﾄﾞ変数用ｵﾌﾞｼﾞｪｸﾄ型配列)</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TLIF_TRNS_RECV_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
        Dim strMsg As String            'ﾒｯｾｰｼﾞ
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim ii As Integer               'ｶｳﾝﾀ


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mstrUSER_SQL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰSQL]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '抽出
        '***********************
        mobjAryMe = Nothing
        If IsNothing(objUSER_PARAM) = False Then
            ObjDb.Parameter = objUSER_PARAM
        End If
        ObjDb.SQL = mstrUSER_SQL
        objDataSet.Clear()
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLIF_TRNS_RECV(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(ｶｳﾝﾄ)               "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｶｳﾝﾄ)
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TLIF_TRNS_RECV_COUNT() As Integer
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    COUNT(*)")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --通信電文")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --通信電文02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --進捗状態")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        Return (objRow(0))


    End Function
#End Region
#Region "  ﾃﾞｰﾀ更新                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ更新
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_TLIF_TRNS_RECV()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[登録№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFENTRY_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_NO = NULL --登録№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_NO = NULL --登録№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_NO = :" & Ubound(strBindField) - 1 & " --登録№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_NO = :" & Ubound(strBindField) - 1 & " --登録№")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = NULL --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = :" & Ubound(strBindField) - 1 & " --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = :" & Ubound(strBindField) - 1 & " --設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMAND_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMAND_ID = NULL --ｺﾏﾝﾄﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMAND_ID = NULL --ｺﾏﾝﾄﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMAND_ID = :" & Ubound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMAND_ID = :" & Ubound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = NULL --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = NULL --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM1 = NULL --電文ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM1 = NULL --電文ﾊﾟﾗﾒｰﾀ1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM1 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM1 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM2 = NULL --電文ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM2 = NULL --電文ﾊﾟﾗﾒｰﾀ2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM2 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM2 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM3 = NULL --電文ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM3 = NULL --電文ﾊﾟﾗﾒｰﾀ3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM3 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM3 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM4 = NULL --電文ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM4 = NULL --電文ﾊﾟﾗﾒｰﾀ4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM4 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM4 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM5 = NULL --電文ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM5 = NULL --電文ﾊﾟﾗﾒｰﾀ5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM5 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM5 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM6) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM6 = NULL --電文ﾊﾟﾗﾒｰﾀ6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM6 = NULL --電文ﾊﾟﾗﾒｰﾀ6")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM6 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM6 = :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = NULL --搬送ｼﾘｱﾙ№(MCｷｰ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = NULL --搬送ｼﾘｱﾙ№(MCｷｰ)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        intCount = intCount + 1
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = NULL --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = NULL --優先ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN = NULL --通信電文")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN = NULL --通信電文")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN = :" & Ubound(strBindField) - 1 & " --通信電文")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN = :" & Ubound(strBindField) - 1 & " --通信電文")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN02 = NULL --通信電文02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN02 = NULL --通信電文02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN02 = :" & Ubound(strBindField) - 1 & " --通信電文02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN02 = :" & Ubound(strBindField) - 1 & " --通信電文02")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS = NULL --進捗状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS = NULL --進捗状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS = :" & Ubound(strBindField) - 1 & " --進捗状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS = :" & Ubound(strBindField) - 1 & " --進捗状態")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_CD_EQ) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_CD_EQ = NULL --設備応答ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_CD_EQ = NULL --設備応答ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_CD_EQ = :" & Ubound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_CD_EQ = :" & Ubound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = NULL --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = NULL --登録日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = :" & Ubound(strBindField) - 1 & " --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = :" & Ubound(strBindField) - 1 & " --登録日時")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = NULL --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = NULL --更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --更新日時")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FENTRY_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FENTRY_NO IS NULL --登録№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '更新
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If
        If intRetSQL < 1 Then
            '(対象行無し)
            strMsg = ERRMSG_ERR_UPDATE & "[対象行無し]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ追加                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ追加
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ADD_TLIF_TRNS_RECV()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[登録№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFENTRY_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録№")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMAND_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾏﾝﾄﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾏﾝﾄﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM6) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --電文ﾊﾟﾗﾒｰﾀ6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --電文ﾊﾟﾗﾒｰﾀ6")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送ｼﾘｱﾙ№(MCｷｰ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送ｼﾘｱﾙ№(MCｷｰ)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        intCount = intCount + 1
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --優先ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --通信電文")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --通信電文")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --通信電文")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --通信電文")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --通信電文02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --通信電文02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --通信電文02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --通信電文02")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --進捗状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --進捗状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --進捗状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --進捗状態")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_CD_EQ) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備応答ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備応答ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録日時")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新日時")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " )")


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '追加
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ削除                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ削除
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TLIF_TRNS_RECV()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[登録№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '削除SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FENTRY_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FENTRY_NO IS NULL --登録№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '削除
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ削除(複数ﾚｺｰﾄﾞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ削除
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TLIF_TRNS_RECV_ANY()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '削除SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FENTRY_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --登録№")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(FCOMMAND_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --ｺﾏﾝﾄﾞID")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FTEXT_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNotNull(FDENBUN_PRM1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNotNull(FDENBUN_PRM2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNotNull(FDENBUN_PRM3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNotNull(FDENBUN_PRM4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNotNull(FDENBUN_PRM5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ5")
        End If
        If IsNotNull(FDENBUN_PRM6) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --電文ﾊﾟﾗﾒｰﾀ6")
        End If
        If IsNotNull(FTRNS_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNotNull(FPRIORITY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNotNull(FDENBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --通信電文")
        End If
        If IsNotNull(FDENBUN02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --通信電文02")
        End If
        If IsNotNull(FPROGRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --進捗状態")
        End If
        If IsNotNull(FRES_CD_EQ) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --設備応答ｺｰﾄﾞ")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '削除
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨｺﾋﾟｰ                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨ変数へｾｯﾄ
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("FENTRY_NO")) = False Then mFENTRY_NO = objObject.FENTRY_NO '登録№
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("FCOMMAND_ID")) = False Then mFCOMMAND_ID = objObject.FCOMMAND_ID 'ｺﾏﾝﾄﾞID
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FTEXT_ID")) = False Then mFTEXT_ID = objObject.FTEXT_ID 'ﾃｷｽﾄID
        If IsNothing(objType.GetProperty("FDENBUN_PRM1")) = False Then mFDENBUN_PRM1 = objObject.FDENBUN_PRM1 '電文ﾊﾟﾗﾒｰﾀ1
        If IsNothing(objType.GetProperty("FDENBUN_PRM2")) = False Then mFDENBUN_PRM2 = objObject.FDENBUN_PRM2 '電文ﾊﾟﾗﾒｰﾀ2
        If IsNothing(objType.GetProperty("FDENBUN_PRM3")) = False Then mFDENBUN_PRM3 = objObject.FDENBUN_PRM3 '電文ﾊﾟﾗﾒｰﾀ3
        If IsNothing(objType.GetProperty("FDENBUN_PRM4")) = False Then mFDENBUN_PRM4 = objObject.FDENBUN_PRM4 '電文ﾊﾟﾗﾒｰﾀ4
        If IsNothing(objType.GetProperty("FDENBUN_PRM5")) = False Then mFDENBUN_PRM5 = objObject.FDENBUN_PRM5 '電文ﾊﾟﾗﾒｰﾀ5
        If IsNothing(objType.GetProperty("FDENBUN_PRM6")) = False Then mFDENBUN_PRM6 = objObject.FDENBUN_PRM6 '電文ﾊﾟﾗﾒｰﾀ6
        If IsNothing(objType.GetProperty("FTRNS_SERIAL")) = False Then mFTRNS_SERIAL = objObject.FTRNS_SERIAL '搬送ｼﾘｱﾙ№(MCｷｰ)
        If IsNothing(objType.GetProperty("FPRIORITY")) = False Then mFPRIORITY = objObject.FPRIORITY '優先ﾚﾍﾞﾙ
        If IsNothing(objType.GetProperty("FDENBUN")) = False Then mFDENBUN = objObject.FDENBUN '通信電文
        If IsNothing(objType.GetProperty("FDENBUN02")) = False Then mFDENBUN02 = objObject.FDENBUN02 '通信電文02
        If IsNothing(objType.GetProperty("FPROGRESS")) = False Then mFPROGRESS = objObject.FPROGRESS '進捗状態
        If IsNothing(objType.GetProperty("FRES_CD_EQ")) = False Then mFRES_CD_EQ = objObject.FRES_CD_EQ '設備応答ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時

    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨｸﾘｱ                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub CLEAR_PROPERTY()


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨ変数ｸﾘｱ
        '***********************
        Call ARYME_CLEAR()
        mstrUSER_SQL = Nothing
        mFENTRY_NO = Nothing
        mFEQ_ID = Nothing
        mFCOMMAND_ID = Nothing
        mFPALLET_ID = Nothing
        mFTEXT_ID = Nothing
        mFDENBUN_PRM1 = Nothing
        mFDENBUN_PRM2 = Nothing
        mFDENBUN_PRM3 = Nothing
        mFDENBUN_PRM4 = Nothing
        mFDENBUN_PRM5 = Nothing
        mFDENBUN_PRM6 = Nothing
        mFTRNS_SERIAL = Nothing
        mFPRIORITY = Nothing
        mFDENBUN = Nothing
        mFDENBUN02 = Nothing
        mFPROGRESS = Nothing
        mFRES_CD_EQ = Nothing
        mFENTRY_DT = Nothing
        mFUPDATE_DT = Nothing


    End Sub
#End Region
#Region "  AryMeｸﾘｱ                     "
    Public Sub ARYME_CLEAR()


        If IsNull(mobjAryMe) = False Then
            For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                mobjAryMe(ii).CLEAR_PROPERTY()
                mobjAryMe(ii) = Nothing
            Next
            mobjAryMe = Nothing
        End If


    End Sub
#End Region

#Region "  ﾃﾞｰﾀ→変数                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ→変数
    ''' </summary>
    ''' <param name="objRow">ﾃﾞｰﾀﾚｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA(ByVal objRow As DataRow)


        '***********************
        'ﾃﾞｰﾀｾｯﾄ
        '***********************
        mFENTRY_NO = TO_STRING_NULLABLE(objRow("FENTRY_NO"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFCOMMAND_ID = TO_STRING_NULLABLE(objRow("FCOMMAND_ID"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFTEXT_ID = TO_STRING_NULLABLE(objRow("FTEXT_ID"))
        mFDENBUN_PRM1 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM1"))
        mFDENBUN_PRM2 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM2"))
        mFDENBUN_PRM3 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM3"))
        mFDENBUN_PRM4 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM4"))
        mFDENBUN_PRM5 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM5"))
        mFDENBUN_PRM6 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM6"))
        mFTRNS_SERIAL = TO_STRING_NULLABLE(objRow("FTRNS_SERIAL"))
        mFPRIORITY = TO_INTEGER_NULLABLE(objRow("FPRIORITY"))
        mFDENBUN = TO_STRING_NULLABLE(objRow("FDENBUN"))
        mFDENBUN02 = TO_STRING_NULLABLE(objRow("FDENBUN02"))
        mFPROGRESS = TO_INTEGER_NULLABLE(objRow("FPROGRESS"))
        mFRES_CD_EQ = TO_STRING_NULLABLE(objRow("FRES_CD_EQ"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))


    End Sub
#End Region
#Region "  ｴﾗｰﾒｯｾｰｼﾞ文字列作成01        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰﾒｯｾｰｼﾞ文字列作成01
    ''' </summary>
    ''' <param name="strMsg">ｴﾗｰﾒｯｾｰｼﾞ文字列</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub MAKE_ERRMSG01(ByRef strMsg As String)


        '***********************
        'ﾃﾞｰﾀｾｯﾄ
        '***********************
        strMsg = "ﾚｺｰﾄﾞが見つかりませんでした。"
        strMsg &= "[ﾃｰﾌﾞﾙ名:搬送制御受信IF]"
        If IsNotNull(FENTRY_NO) Then
            strMsg &= "[登録№:" & FENTRY_NO & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FCOMMAND_ID) Then
            strMsg &= "[ｺﾏﾝﾄﾞID:" & FCOMMAND_ID & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FTEXT_ID) Then
            strMsg &= "[ﾃｷｽﾄID:" & FTEXT_ID & "]"
        End If
        If IsNotNull(FDENBUN_PRM1) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ1:" & FDENBUN_PRM1 & "]"
        End If
        If IsNotNull(FDENBUN_PRM2) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ2:" & FDENBUN_PRM2 & "]"
        End If
        If IsNotNull(FDENBUN_PRM3) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ3:" & FDENBUN_PRM3 & "]"
        End If
        If IsNotNull(FDENBUN_PRM4) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ4:" & FDENBUN_PRM4 & "]"
        End If
        If IsNotNull(FDENBUN_PRM5) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ5:" & FDENBUN_PRM5 & "]"
        End If
        If IsNotNull(FDENBUN_PRM6) Then
            strMsg &= "[電文ﾊﾟﾗﾒｰﾀ6:" & FDENBUN_PRM6 & "]"
        End If
        If IsNotNull(FTRNS_SERIAL) Then
            strMsg &= "[搬送ｼﾘｱﾙ№(MCｷｰ):" & FTRNS_SERIAL & "]"
        End If
        If IsNotNull(FPRIORITY) Then
            strMsg &= "[優先ﾚﾍﾞﾙ:" & FPRIORITY & "]"
        End If
        If IsNotNull(FDENBUN) Then
            strMsg &= "[通信電文:" & FDENBUN & "]"
        End If
        If IsNotNull(FDENBUN02) Then
            strMsg &= "[通信電文02:" & FDENBUN02 & "]"
        End If
        If IsNotNull(FPROGRESS) Then
            strMsg &= "[進捗状態:" & FPROGRESS & "]"
        End If
        If IsNotNull(FRES_CD_EQ) Then
            strMsg &= "[設備応答ｺｰﾄﾞ:" & FRES_CD_EQ & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  搬送制御受信IF追加   [SEQ№発番]                     (Public  ADD_TLIF_TRNS_SEND_SEQ)"
    Public Sub ADD_TLIF_TRNS_RECV_SEQ()
        Try
            'Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            'Dim intRetSQL As Integer    'SQL実行戻り値

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '登録№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRENTRY_NO_TRNS_R              'ｼｰｹﾝｽID
            mFENTRY_NO = objTPRG_SEQNO.GET_ENTRY_NO()                       '登録№の特定


            '***********************
            '追加SQL作成
            '***********************
            Me.ADD_TLIF_TRNS_RECV()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  搬送制御受信IF削除   [ﾊﾟﾚｯﾄID]                       (Public  DELETE_TLIF_TRNS_RECV_PALLET)"
    Public Sub DELETE_TLIF_TRNS_RECV_PALLET()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '削除SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPALLET_ID = '" & TO_STRING(mFPALLET_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '削除
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  通信異常ﾚｺｰﾄﾞ取得                                    (Public  GET_TLIF_TRNS_RECV_ERROR_RECORD)"
    Public Function GET_TLIF_TRNS_RECV_ERROR_RECORD() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '通信異常ﾚｺｰﾄﾞﾁｪｯｸ
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                      '設備ID
            strSQL &= vbCrLf & "    AND FCOMMAND_ID = '" & TO_STRING(FCOMMAND_ID_SCUT_EQ) & "'"      'ｺﾏﾝﾄﾞID
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_RECV"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)
                Return (RetCode.OK)
            Else
                '(見つからなかった場合)
                Return (RetCode.NotFound)
            End If


        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
