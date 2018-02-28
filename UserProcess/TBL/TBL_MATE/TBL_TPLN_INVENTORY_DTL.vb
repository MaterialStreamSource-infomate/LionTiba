'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】棚卸し作業詳細ﾃｰﾌﾞﾙｸﾗｽ
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
''' 棚卸し作業詳細ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPLN_INVENTORY_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPLN_INVENTORY_DTL()                                '棚卸し作業詳細
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFPLAN_KEY As String                                                 '計画ｷｰ
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFLOT_NO As String                                                   'ﾛｯﾄ№
    Private mFDISP_ADDRESS As String                                             '表記用ｱﾄﾞﾚｽ
    Private mFSTOCK_NUM As Nullable(Of Decimal)                                  '現在庫数量
    Private mFSTOCK_KOSOU As Nullable(Of Integer)                                '現在庫個装数
    Private mFSTOCK_HASU As Nullable(Of Integer)                                 '現在庫端数数
    Private mFINVENTORY_NUM As Nullable(Of Decimal)                              '棚卸し実績数量
    Private mFINVENTORY_KOSOU As Nullable(Of Integer)                            '棚卸し実績個装数
    Private mFINVENTORY_HASU As Nullable(Of Integer)                             '棚卸し実績端数数
    Private mFPROGRESS_PLNINVDTL As Nullable(Of Integer)                         '進捗状態(棚卸し詳細)
    Private mFTRNS_START_DT As Nullable(Of Date)                                 '搬送開始日時
    Private mFTRNS_END_DT As Nullable(Of Date)                                   '搬送完了日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPLN_INVENTORY_DTL()
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
    ''' 計画ｷｰ
    ''' </summary>
    Public Property FPLAN_KEY() As String
        Get
            Return mFPLAN_KEY
        End Get
        Set(ByVal Value As String)
            mFPLAN_KEY = Value
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
    ''' 品目ｺｰﾄﾞ
    ''' </summary>
    Public Property FHINMEI_CD() As String
        Get
            Return mFHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mFHINMEI_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｯﾄ№
    ''' </summary>
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 表記用ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property FDISP_ADDRESS() As String
        Get
            Return mFDISP_ADDRESS
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' 現在庫数量
    ''' </summary>
    Public Property FSTOCK_NUM() As Nullable(Of Decimal)
        Get
            Return mFSTOCK_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSTOCK_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' 現在庫個装数
    ''' </summary>
    Public Property FSTOCK_KOSOU() As Nullable(Of Integer)
        Get
            Return mFSTOCK_KOSOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSTOCK_KOSOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 現在庫端数数
    ''' </summary>
    Public Property FSTOCK_HASU() As Nullable(Of Integer)
        Get
            Return mFSTOCK_HASU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSTOCK_HASU = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚卸し実績数量
    ''' </summary>
    Public Property FINVENTORY_NUM() As Nullable(Of Decimal)
        Get
            Return mFINVENTORY_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFINVENTORY_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚卸し実績個装数
    ''' </summary>
    Public Property FINVENTORY_KOSOU() As Nullable(Of Integer)
        Get
            Return mFINVENTORY_KOSOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINVENTORY_KOSOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚卸し実績端数数
    ''' </summary>
    Public Property FINVENTORY_HASU() As Nullable(Of Integer)
        Get
            Return mFINVENTORY_HASU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINVENTORY_HASU = Value
        End Set
    End Property
    ''' <summary>
    ''' 進捗状態(棚卸し詳細)
    ''' </summary>
    Public Property FPROGRESS_PLNINVDTL() As Nullable(Of Integer)
        Get
            Return mFPROGRESS_PLNINVDTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPROGRESS_PLNINVDTL = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送開始日時
    ''' </summary>
    Public Property FTRNS_START_DT() As Nullable(Of Date)
        Get
            Return mFTRNS_START_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFTRNS_START_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送完了日時
    ''' </summary>
    Public Property FTRNS_END_DT() As Nullable(Of Date)
        Get
            Return mFTRNS_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFTRNS_END_DT = Value
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
    Public Function GET_TPLN_INVENTORY_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FSTOCK_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            strSQL.Append(vbCrLf & "    AND FSTOCK_NUM = :" & UBound(strBindField) - 1 & " --現在庫数量")
        End If
        If IsNull(FSTOCK_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            strSQL.Append(vbCrLf & "    AND FSTOCK_KOSOU = :" & UBound(strBindField) - 1 & " --現在庫個装数")
        End If
        If IsNull(FSTOCK_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            strSQL.Append(vbCrLf & "    AND FSTOCK_HASU = :" & UBound(strBindField) - 1 & " --現在庫端数数")
        End If
        If IsNull(FINVENTORY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            strSQL.Append(vbCrLf & "    AND FINVENTORY_NUM = :" & UBound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        If IsNull(FINVENTORY_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_KOSOU = :" & UBound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        If IsNull(FINVENTORY_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_HASU = :" & UBound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        If IsNull(FPROGRESS_PLNINVDTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        If IsNull(FTRNS_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_START_DT = :" & UBound(strBindField) - 1 & " --搬送開始日時")
        End If
        If IsNull(FTRNS_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_END_DT = :" & UBound(strBindField) - 1 & " --搬送完了日時")
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
        strDataSetName = "TPLN_INVENTORY_DTL"
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
    Public Function GET_TPLN_INVENTORY_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FSTOCK_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            strSQL.Append(vbCrLf & "    AND FSTOCK_NUM = :" & UBound(strBindField) - 1 & " --現在庫数量")
        End If
        If IsNull(FSTOCK_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            strSQL.Append(vbCrLf & "    AND FSTOCK_KOSOU = :" & UBound(strBindField) - 1 & " --現在庫個装数")
        End If
        If IsNull(FSTOCK_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            strSQL.Append(vbCrLf & "    AND FSTOCK_HASU = :" & UBound(strBindField) - 1 & " --現在庫端数数")
        End If
        If IsNull(FINVENTORY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            strSQL.Append(vbCrLf & "    AND FINVENTORY_NUM = :" & UBound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        If IsNull(FINVENTORY_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_KOSOU = :" & UBound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        If IsNull(FINVENTORY_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_HASU = :" & UBound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        If IsNull(FPROGRESS_PLNINVDTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        If IsNull(FTRNS_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_START_DT = :" & UBound(strBindField) - 1 & " --搬送開始日時")
        End If
        If IsNull(FTRNS_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_END_DT = :" & UBound(strBindField) - 1 & " --搬送完了日時")
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
        strDataSetName = "TPLN_INVENTORY_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_INVENTORY_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_INVENTORY_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPLN_INVENTORY_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_INVENTORY_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_INVENTORY_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FSTOCK_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            strSQL.Append(vbCrLf & "    AND FSTOCK_NUM = :" & UBound(strBindField) - 1 & " --現在庫数量")
        End If
        If IsNull(FSTOCK_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            strSQL.Append(vbCrLf & "    AND FSTOCK_KOSOU = :" & UBound(strBindField) - 1 & " --現在庫個装数")
        End If
        If IsNull(FSTOCK_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            strSQL.Append(vbCrLf & "    AND FSTOCK_HASU = :" & UBound(strBindField) - 1 & " --現在庫端数数")
        End If
        If IsNull(FINVENTORY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            strSQL.Append(vbCrLf & "    AND FINVENTORY_NUM = :" & UBound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        If IsNull(FINVENTORY_KOSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_KOSOU = :" & UBound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        If IsNull(FINVENTORY_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_HASU = :" & UBound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        If IsNull(FPROGRESS_PLNINVDTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        If IsNull(FTRNS_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_START_DT = :" & UBound(strBindField) - 1 & " --搬送開始日時")
        End If
        If IsNull(FTRNS_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_END_DT = :" & UBound(strBindField) - 1 & " --搬送完了日時")
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
        strDataSetName = "TPLN_INVENTORY_DTL"
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
    Public Sub UPDATE_TPLN_INVENTORY_DTL()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = NULL --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
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
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = NULL --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = NULL --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = NULL --ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = NULL --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = NULL --表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_NUM = NULL --現在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_NUM = NULL --現在庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_NUM = :" & Ubound(strBindField) - 1 & " --現在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_NUM = :" & Ubound(strBindField) - 1 & " --現在庫数量")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_KOSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_KOSOU = NULL --現在庫個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_KOSOU = NULL --現在庫個装数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_KOSOU = :" & Ubound(strBindField) - 1 & " --現在庫個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_KOSOU = :" & Ubound(strBindField) - 1 & " --現在庫個装数")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_HASU = NULL --現在庫端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_HASU = NULL --現在庫端数数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTOCK_HASU = :" & Ubound(strBindField) - 1 & " --現在庫端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTOCK_HASU = :" & Ubound(strBindField) - 1 & " --現在庫端数数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_NUM = NULL --棚卸し実績数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_NUM = NULL --棚卸し実績数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_NUM = :" & Ubound(strBindField) - 1 & " --棚卸し実績数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_NUM = :" & Ubound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_KOSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_KOSOU = NULL --棚卸し実績個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_KOSOU = NULL --棚卸し実績個装数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_KOSOU = :" & Ubound(strBindField) - 1 & " --棚卸し実績個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_KOSOU = :" & Ubound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_HASU = NULL --棚卸し実績端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_HASU = NULL --棚卸し実績端数数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_HASU = :" & Ubound(strBindField) - 1 & " --棚卸し実績端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_HASU = :" & Ubound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS_PLNINVDTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINVDTL = NULL --進捗状態(棚卸し詳細)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINVDTL = NULL --進捗状態(棚卸し詳細)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINVDTL = :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINVDTL = :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_START_DT = NULL --搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_START_DT = NULL --搬送開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_START_DT = :" & Ubound(strBindField) - 1 & " --搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_START_DT = :" & Ubound(strBindField) - 1 & " --搬送開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_END_DT = NULL --搬送完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_END_DT = NULL --搬送完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_END_DT = :" & Ubound(strBindField) - 1 & " --搬送完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_END_DT = :" & Ubound(strBindField) - 1 & " --搬送完了日時")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPLAN_KEY) = True Then
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY IS NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
    Public Sub ADD_TPLN_INVENTORY_DTL()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --計画ｷｰ")
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
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --現在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --現在庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --現在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --現在庫数量")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_KOSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --現在庫個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --現在庫個装数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --現在庫個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --現在庫個装数")
        End If
        intCount = intCount + 1
        If IsNull(mFSTOCK_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --現在庫端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --現在庫端数数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --現在庫端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --現在庫端数数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚卸し実績数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚卸し実績数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚卸し実績数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_KOSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚卸し実績個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚卸し実績個装数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚卸し実績個装数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚卸し実績端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚卸し実績端数数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚卸し実績端数数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS_PLNINVDTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --進捗状態(棚卸し詳細)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --進捗状態(棚卸し詳細)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送完了日時")
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
    Public Sub DELETE_TPLN_INVENTORY_DTL()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPLAN_KEY) = True Then
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY IS NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
    Public Sub DELETE_TPLN_INVENTORY_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FPLAN_KEY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNotNull(FDISP_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FSTOCK_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_NUM
            strSQL.Append(vbCrLf & "    AND FSTOCK_NUM = :" & UBound(strBindField) - 1 & " --現在庫数量")
        End If
        If IsNotNull(FSTOCK_KOSOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_KOSOU
            strSQL.Append(vbCrLf & "    AND FSTOCK_KOSOU = :" & UBound(strBindField) - 1 & " --現在庫個装数")
        End If
        If IsNotNull(FSTOCK_HASU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTOCK_HASU
            strSQL.Append(vbCrLf & "    AND FSTOCK_HASU = :" & UBound(strBindField) - 1 & " --現在庫端数数")
        End If
        If IsNotNull(FINVENTORY_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_NUM
            strSQL.Append(vbCrLf & "    AND FINVENTORY_NUM = :" & UBound(strBindField) - 1 & " --棚卸し実績数量")
        End If
        If IsNotNull(FINVENTORY_KOSOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_KOSOU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_KOSOU = :" & UBound(strBindField) - 1 & " --棚卸し実績個装数")
        End If
        If IsNotNull(FINVENTORY_HASU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_HASU
            strSQL.Append(vbCrLf & "    AND FINVENTORY_HASU = :" & UBound(strBindField) - 1 & " --棚卸し実績端数数")
        End If
        If IsNotNull(FPROGRESS_PLNINVDTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し詳細)")
        End If
        If IsNotNull(FTRNS_START_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_START_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_START_DT = :" & UBound(strBindField) - 1 & " --搬送開始日時")
        End If
        If IsNotNull(FTRNS_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_END_DT
            strSQL.Append(vbCrLf & "    AND FTRNS_END_DT = :" & UBound(strBindField) - 1 & " --搬送完了日時")
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
        If IsNothing(objType.GetProperty("FPLAN_KEY")) = False Then mFPLAN_KEY = objObject.FPLAN_KEY '計画ｷｰ
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ﾛｯﾄ№
        If IsNothing(objType.GetProperty("FDISP_ADDRESS")) = False Then mFDISP_ADDRESS = objObject.FDISP_ADDRESS '表記用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FSTOCK_NUM")) = False Then mFSTOCK_NUM = objObject.FSTOCK_NUM '現在庫数量
        If IsNothing(objType.GetProperty("FSTOCK_KOSOU")) = False Then mFSTOCK_KOSOU = objObject.FSTOCK_KOSOU '現在庫個装数
        If IsNothing(objType.GetProperty("FSTOCK_HASU")) = False Then mFSTOCK_HASU = objObject.FSTOCK_HASU '現在庫端数数
        If IsNothing(objType.GetProperty("FINVENTORY_NUM")) = False Then mFINVENTORY_NUM = objObject.FINVENTORY_NUM '棚卸し実績数量
        If IsNothing(objType.GetProperty("FINVENTORY_KOSOU")) = False Then mFINVENTORY_KOSOU = objObject.FINVENTORY_KOSOU '棚卸し実績個装数
        If IsNothing(objType.GetProperty("FINVENTORY_HASU")) = False Then mFINVENTORY_HASU = objObject.FINVENTORY_HASU '棚卸し実績端数数
        If IsNothing(objType.GetProperty("FPROGRESS_PLNINVDTL")) = False Then mFPROGRESS_PLNINVDTL = objObject.FPROGRESS_PLNINVDTL '進捗状態(棚卸し詳細)
        If IsNothing(objType.GetProperty("FTRNS_START_DT")) = False Then mFTRNS_START_DT = objObject.FTRNS_START_DT '搬送開始日時
        If IsNothing(objType.GetProperty("FTRNS_END_DT")) = False Then mFTRNS_END_DT = objObject.FTRNS_END_DT '搬送完了日時

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
        mFPLAN_KEY = Nothing
        mFPALLET_ID = Nothing
        mFHINMEI_CD = Nothing
        mFLOT_NO = Nothing
        mFDISP_ADDRESS = Nothing
        mFSTOCK_NUM = Nothing
        mFSTOCK_KOSOU = Nothing
        mFSTOCK_HASU = Nothing
        mFINVENTORY_NUM = Nothing
        mFINVENTORY_KOSOU = Nothing
        mFINVENTORY_HASU = Nothing
        mFPROGRESS_PLNINVDTL = Nothing
        mFTRNS_START_DT = Nothing
        mFTRNS_END_DT = Nothing


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
        mFPLAN_KEY = TO_STRING_NULLABLE(objRow("FPLAN_KEY"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFDISP_ADDRESS = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS"))
        mFSTOCK_NUM = TO_DECIMAL_NULLABLE(objRow("FSTOCK_NUM"))
        mFSTOCK_KOSOU = TO_INTEGER_NULLABLE(objRow("FSTOCK_KOSOU"))
        mFSTOCK_HASU = TO_INTEGER_NULLABLE(objRow("FSTOCK_HASU"))
        mFINVENTORY_NUM = TO_DECIMAL_NULLABLE(objRow("FINVENTORY_NUM"))
        mFINVENTORY_KOSOU = TO_INTEGER_NULLABLE(objRow("FINVENTORY_KOSOU"))
        mFINVENTORY_HASU = TO_INTEGER_NULLABLE(objRow("FINVENTORY_HASU"))
        mFPROGRESS_PLNINVDTL = TO_INTEGER_NULLABLE(objRow("FPROGRESS_PLNINVDTL"))
        mFTRNS_START_DT = TO_DATE_NULLABLE(objRow("FTRNS_START_DT"))
        mFTRNS_END_DT = TO_DATE_NULLABLE(objRow("FTRNS_END_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:棚卸し作業詳細]"
        If IsNotNull(FPLAN_KEY) Then
            strMsg &= "[計画ｷｰ:" & FPLAN_KEY & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ﾛｯﾄ№:" & FLOT_NO & "]"
        End If
        If IsNotNull(FDISP_ADDRESS) Then
            strMsg &= "[表記用ｱﾄﾞﾚｽ:" & FDISP_ADDRESS & "]"
        End If
        If IsNotNull(FSTOCK_NUM) Then
            strMsg &= "[現在庫数量:" & FSTOCK_NUM & "]"
        End If
        If IsNotNull(FSTOCK_KOSOU) Then
            strMsg &= "[現在庫個装数:" & FSTOCK_KOSOU & "]"
        End If
        If IsNotNull(FSTOCK_HASU) Then
            strMsg &= "[現在庫端数数:" & FSTOCK_HASU & "]"
        End If
        If IsNotNull(FINVENTORY_NUM) Then
            strMsg &= "[棚卸し実績数量:" & FINVENTORY_NUM & "]"
        End If
        If IsNotNull(FINVENTORY_KOSOU) Then
            strMsg &= "[棚卸し実績個装数:" & FINVENTORY_KOSOU & "]"
        End If
        If IsNotNull(FINVENTORY_HASU) Then
            strMsg &= "[棚卸し実績端数数:" & FINVENTORY_HASU & "]"
        End If
        If IsNotNull(FPROGRESS_PLNINVDTL) Then
            strMsg &= "[進捗状態(棚卸し詳細):" & FPROGRESS_PLNINVDTL & "]"
        End If
        If IsNotNull(FTRNS_START_DT) Then
            strMsg &= "[搬送開始日時:" & FTRNS_START_DT & "]"
        End If
        If IsNotNull(FTRNS_END_DT) Then
            strMsg &= "[搬送完了日時:" & FTRNS_END_DT & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ﾃﾞｰﾀ削除(ｷｰ:計画ｷｰ)                                          "
    Public Sub DELETE_TPLN_INVENTORY_DTL_FPLAN_KEY()
        Try
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
            ElseIf IsNull(mFPLAN_KEY) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
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
            strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1 ")
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")


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


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  進捗状態(棚卸し)更新(ｷｰ:計画ｷｰ)                              "
    ''''''' <summary>
    ''''''' ﾃﾞｰﾀ更新
    ''''''' </summary>
    ''''''' <remarks></remarks>
    '' ''Public Sub UPDATE_TPLN_INVENTORY_DTL_FPROGRESS_PLNINV()
    '' ''    Try
    '' ''        Dim strSQL As New StringBuilder     'SQL文
    '' ''        Dim strMsg As String                'ﾒｯｾｰｼﾞ
    '' ''        Dim intRetSQL As Integer            'SQL実行戻り値
    '' ''        Dim objParameter(1, 0) As Object
    '' ''        Dim strBindField(0) As String
    '' ''        Dim objBindValue(0) As Object

    '' ''        '***********************
    '' ''        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
    '' ''        '***********************
    '' ''        If 1 <> 1 Then
    '' ''        ElseIf IsNull(mFPLAN_KEY) = True Then
    '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
    '' ''            Throw New UserException(strMsg)
    '' ''        ElseIf IsNull(mFPROGRESS_PLNINVDTL) = True Then
    '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[進捗状態(棚卸し詳細)]"
    '' ''            Throw New UserException(strMsg)
    '' ''        End If


    '' ''        '***********************
    '' ''        '更新SQL作成
    '' ''        '***********************
    '' ''        strBindField = Nothing
    '' ''        objBindValue = Nothing
    '' ''        ReDim Preserve strBindField(0)
    '' ''        ReDim Preserve objBindValue(0)
    '' ''        strSQL.Append(vbCrLf & "UPDATE")
    '' ''        strSQL.Append(vbCrLf & "    TPLN_INVENTORY_DTL")
    '' ''        strSQL.Append(vbCrLf & " SET")
    '' ''        Dim intCount As Integer = 0
    '' ''        If IsNull(mFPROGRESS_PLNINVDTL) = True Then
    '' ''            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINVDTL = NULL --進捗状態(棚卸し)")
    '' ''            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINVDTL = NULL --進捗状態(棚卸し)")
    '' ''        Else
    '' ''            ReDim Preserve strBindField(UBound(strBindField) + 1)
    '' ''            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
    '' ''            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
    '' ''            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINVDTL
    '' ''            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
    '' ''            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINVDTL = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
    '' ''        End If
    '' ''        intCount = intCount + 1
    '' ''        strSQL.Append(vbCrLf & " WHERE")
    '' ''        strSQL.Append(vbCrLf & "        1 = 1 ")
    '' ''        If IsNull(FPLAN_KEY) = True Then
    '' ''            strSQL.Append(vbCrLf & "    AND FPLAN_KEY IS NULL --計画ｷｰ")
    '' ''        Else
    '' ''            ReDim Preserve strBindField(UBound(strBindField) + 1)
    '' ''            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
    '' ''            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
    '' ''            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
    '' ''            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
    '' ''        End If


    '' ''        '***********************
    '' ''        'ﾊﾞｲﾝﾄﾞ変数定義
    '' ''        '***********************
    '' ''        objParameter = Nothing
    '' ''        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
    '' ''        Dim ii As Integer
    '' ''        For ii = LBound(strBindField) + 1 To UBound(strBindField)
    '' ''            objParameter(0, ii - 1) = strBindField(ii)
    '' ''            objParameter(1, ii - 1) = objBindValue(ii)
    '' ''        Next ii


    '' ''        '***********************
    '' ''        '更新
    '' ''        '***********************
    '' ''        ObjDb.Parameter = objParameter
    '' ''        intRetSQL = ObjDb.Execute(strSQL.ToString)
    '' ''        If intRetSQL = -1 Then
    '' ''            '(SQLｴﾗｰ)
    '' ''            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
    '' ''            Throw New UserException(strMsg)
    '' ''        End If
    '' ''        If intRetSQL < 1 Then
    '' ''            '(対象行無し)
    '' ''            strMsg = ERRMSG_ERR_UPDATE & "[対象行無し]"
    '' ''            Throw New UserException(strMsg)
    '' ''        End If


    '' ''    Catch ex As UserException
    '' ''        Throw ex
    '' ''    Catch ex As Exception
    '' ''        Throw ex
    '' ''    End Try
    '' ''End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
