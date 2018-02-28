'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】出荷指示詳細ﾃｰﾌﾞﾙｸﾗｽ
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
''' 出荷指示詳細ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XPLN_OUT_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XPLN_OUT_DTL()                                      '出荷指示詳細
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSYUKKA_D As Nullable(Of Date)                                      '出荷日
    Private mXHENSEI_NO As String                                                '編成No.
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '作業種別
    Private mFPLAN_KEY As String                                                 '計画ｷｰ
    Private mXOUT_ORDER As Nullable(Of Integer)                                  '車輌内出荷品目順
    Private mXSYUKKA_KON_PLAN As Nullable(Of Integer)                            '出荷予定梱数
    Private mXSYUKKA_KON_RESERVE As Nullable(Of Integer)                         '出荷引当梱数
    Private mXSYUKKA_KON_RESULT As Nullable(Of Integer)                          '出荷実績梱数
    Private mXSYUKKA_KON_H_RESULT As Nullable(Of Integer)                        '出荷実績梱数(平置)
    Private mXSAIMOKU As String                                                  '取引区分細目
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '在庫区分
    Private mXIDOU_KBN As String                                                 '移動区分
    Private mXHENSEI_NO_OYA As String                                            '親編成No.
    Private mXTORIKIRI As Nullable(Of Integer)                                   '取り切り指定
    Private mXOUT_START_DT As Nullable(Of Date)                                  '出庫開始日時
    Private mXOUT_END_DT As Nullable(Of Date)                                    '出庫完了日時
    Private mXSYUKKA_STS_DTL As Nullable(Of Integer)                             '出荷状況詳細
    Private mXDENPYOU_NO As String                                               '伝票No.
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XPLN_OUT_DTL()
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
    ''' 出荷日
    ''' </summary>
    Public Property XSYUKKA_D() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D = Value
        End Set
    End Property
    ''' <summary>
    ''' 編成No.
    ''' </summary>
    Public Property XHENSEI_NO() As String
        Get
            Return mXHENSEI_NO
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO = Value
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
    ''' 作業種別
    ''' </summary>
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
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
    ''' 車輌内出荷品目順
    ''' </summary>
    Public Property XOUT_ORDER() As Nullable(Of Integer)
        Get
            Return mXOUT_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXOUT_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷予定梱数
    ''' </summary>
    Public Property XSYUKKA_KON_PLAN() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_PLAN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_PLAN = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷引当梱数
    ''' </summary>
    Public Property XSYUKKA_KON_RESERVE() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_RESERVE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_RESERVE = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷実績梱数
    ''' </summary>
    Public Property XSYUKKA_KON_RESULT() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_RESULT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_RESULT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷実績梱数(平置)
    ''' </summary>
    Public Property XSYUKKA_KON_H_RESULT() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_H_RESULT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_H_RESULT = Value
        End Set
    End Property
    ''' <summary>
    ''' 取引区分細目
    ''' </summary>
    Public Property XSAIMOKU() As String
        Get
            Return mXSAIMOKU
        End Get
        Set(ByVal Value As String)
            mXSAIMOKU = Value
        End Set
    End Property
    ''' <summary>
    ''' 在庫区分
    ''' </summary>
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 移動区分
    ''' </summary>
    Public Property XIDOU_KBN() As String
        Get
            Return mXIDOU_KBN
        End Get
        Set(ByVal Value As String)
            mXIDOU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' 親編成No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA() As String
        Get
            Return mXHENSEI_NO_OYA
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA = Value
        End Set
    End Property
    ''' <summary>
    ''' 取り切り指定
    ''' </summary>
    Public Property XTORIKIRI() As Nullable(Of Integer)
        Get
            Return mXTORIKIRI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTORIKIRI = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫開始日時
    ''' </summary>
    Public Property XOUT_START_DT() As Nullable(Of Date)
        Get
            Return mXOUT_START_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_START_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫完了日時
    ''' </summary>
    Public Property XOUT_END_DT() As Nullable(Of Date)
        Get
            Return mXOUT_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷状況詳細
    ''' </summary>
    Public Property XSYUKKA_STS_DTL() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_STS_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_STS_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' 伝票No.
    ''' </summary>
    Public Property XDENPYOU_NO() As String
        Get
            Return mXDENPYOU_NO
        End Get
        Set(ByVal Value As String)
            mXDENPYOU_NO = Value
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
    Public Function GET_XPLN_OUT_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --出荷予定梱数")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --出荷引当梱数")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --取り切り指定")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --出荷状況詳細")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
        strDataSetName = "XPLN_OUT_DTL"
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
    Public Function GET_XPLN_OUT_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --出荷予定梱数")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --出荷引当梱数")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --取り切り指定")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --出荷状況詳細")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
        strDataSetName = "XPLN_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XPLN_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --出荷予定梱数")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --出荷引当梱数")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --取り切り指定")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --出荷状況詳細")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
        strDataSetName = "XPLN_OUT_DTL"
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
    Public Sub UPDATE_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = NULL --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = NULL --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --編成No.")
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
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = NULL --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --作業種別")
        End If
        intCount = intCount + 1
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
        If IsNull(mXOUT_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_ORDER = NULL --車輌内出荷品目順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_ORDER = NULL --車輌内出荷品目順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_ORDER = :" & Ubound(strBindField) - 1 & " --車輌内出荷品目順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_ORDER = :" & Ubound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_PLAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_PLAN = NULL --出荷予定梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_PLAN = NULL --出荷予定梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_PLAN = :" & Ubound(strBindField) - 1 & " --出荷予定梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_PLAN = :" & Ubound(strBindField) - 1 & " --出荷予定梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESERVE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESERVE = NULL --出荷引当梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESERVE = NULL --出荷引当梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESERVE = :" & Ubound(strBindField) - 1 & " --出荷引当梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESERVE = :" & Ubound(strBindField) - 1 & " --出荷引当梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESULT = NULL --出荷実績梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESULT = NULL --出荷実績梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESULT = :" & Ubound(strBindField) - 1 & " --出荷実績梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESULT = :" & Ubound(strBindField) - 1 & " --出荷実績梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_H_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_H_RESULT = NULL --出荷実績梱数(平置)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_H_RESULT = NULL --出荷実績梱数(平置)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_H_RESULT = :" & Ubound(strBindField) - 1 & " --出荷実績梱数(平置)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_H_RESULT = :" & Ubound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        intCount = intCount + 1
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = NULL --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = NULL --取引区分細目")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = :" & Ubound(strBindField) - 1 & " --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = :" & Ubound(strBindField) - 1 & " --取引区分細目")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = NULL --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = NULL --在庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --在庫区分")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = NULL --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = NULL --移動区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --移動区分")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = NULL --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = NULL --親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIKIRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIKIRI = NULL --取り切り指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIKIRI = NULL --取り切り指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIKIRI = :" & Ubound(strBindField) - 1 & " --取り切り指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIKIRI = :" & Ubound(strBindField) - 1 & " --取り切り指定")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = NULL --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = NULL --出庫開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --出庫開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = NULL --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = NULL --出庫完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --出庫完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS_DTL = NULL --出荷状況詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS_DTL = NULL --出荷状況詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS_DTL = :" & Ubound(strBindField) - 1 & " --出荷状況詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS_DTL = :" & Ubound(strBindField) - 1 & " --出荷状況詳細")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = NULL --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --伝票No.")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
    Public Sub ADD_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --編成No.")
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
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --作業種別")
        End If
        intCount = intCount + 1
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
        If IsNull(mXOUT_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車輌内出荷品目順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車輌内出荷品目順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車輌内出荷品目順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_PLAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷予定梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷予定梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷予定梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷予定梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESERVE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷引当梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷引当梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷引当梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷引当梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷実績梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷実績梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷実績梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷実績梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_H_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷実績梱数(平置)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷実績梱数(平置)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷実績梱数(平置)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        intCount = intCount + 1
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --取引区分細目")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --取引区分細目")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫区分")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --移動区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --移動区分")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIKIRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --取り切り指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --取り切り指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --取り切り指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --取り切り指定")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷状況詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷状況詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷状況詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷状況詳細")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --伝票No.")
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
    Public Sub DELETE_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
    Public Sub DELETE_XPLN_OUT_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSYUKKA_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNotNull(XHENSEI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNotNull(FPLAN_KEY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNotNull(XOUT_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --車輌内出荷品目順")
        End If
        If IsNotNull(XSYUKKA_KON_PLAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --出荷予定梱数")
        End If
        If IsNotNull(XSYUKKA_KON_RESERVE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --出荷引当梱数")
        End If
        If IsNotNull(XSYUKKA_KON_RESULT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数")
        End If
        If IsNotNull(XSYUKKA_KON_H_RESULT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --出荷実績梱数(平置)")
        End If
        If IsNotNull(XSAIMOKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNotNull(XIDOU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNotNull(XTORIKIRI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --取り切り指定")
        End If
        If IsNotNull(XOUT_START_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNotNull(XOUT_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNotNull(XSYUKKA_STS_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --出荷状況詳細")
        End If
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '出荷日
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '編成No.
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '作業種別
        If IsNothing(objType.GetProperty("FPLAN_KEY")) = False Then mFPLAN_KEY = objObject.FPLAN_KEY '計画ｷｰ
        If IsNothing(objType.GetProperty("XOUT_ORDER")) = False Then mXOUT_ORDER = objObject.XOUT_ORDER '車輌内出荷品目順
        If IsNothing(objType.GetProperty("XSYUKKA_KON_PLAN")) = False Then mXSYUKKA_KON_PLAN = objObject.XSYUKKA_KON_PLAN '出荷予定梱数
        If IsNothing(objType.GetProperty("XSYUKKA_KON_RESERVE")) = False Then mXSYUKKA_KON_RESERVE = objObject.XSYUKKA_KON_RESERVE '出荷引当梱数
        If IsNothing(objType.GetProperty("XSYUKKA_KON_RESULT")) = False Then mXSYUKKA_KON_RESULT = objObject.XSYUKKA_KON_RESULT '出荷実績梱数
        If IsNothing(objType.GetProperty("XSYUKKA_KON_H_RESULT")) = False Then mXSYUKKA_KON_H_RESULT = objObject.XSYUKKA_KON_H_RESULT '出荷実績梱数(平置)
        If IsNothing(objType.GetProperty("XSAIMOKU")) = False Then mXSAIMOKU = objObject.XSAIMOKU '取引区分細目
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '在庫区分
        If IsNothing(objType.GetProperty("XIDOU_KBN")) = False Then mXIDOU_KBN = objObject.XIDOU_KBN '移動区分
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '親編成No.
        If IsNothing(objType.GetProperty("XTORIKIRI")) = False Then mXTORIKIRI = objObject.XTORIKIRI '取り切り指定
        If IsNothing(objType.GetProperty("XOUT_START_DT")) = False Then mXOUT_START_DT = objObject.XOUT_START_DT '出庫開始日時
        If IsNothing(objType.GetProperty("XOUT_END_DT")) = False Then mXOUT_END_DT = objObject.XOUT_END_DT '出庫完了日時
        If IsNothing(objType.GetProperty("XSYUKKA_STS_DTL")) = False Then mXSYUKKA_STS_DTL = objObject.XSYUKKA_STS_DTL '出荷状況詳細
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '伝票No.

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
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mFHINMEI_CD = Nothing
        mFSAGYOU_KIND = Nothing
        mFPLAN_KEY = Nothing
        mXOUT_ORDER = Nothing
        mXSYUKKA_KON_PLAN = Nothing
        mXSYUKKA_KON_RESERVE = Nothing
        mXSYUKKA_KON_RESULT = Nothing
        mXSYUKKA_KON_H_RESULT = Nothing
        mXSAIMOKU = Nothing
        mFZAIKO_KUBUN = Nothing
        mXIDOU_KBN = Nothing
        mXHENSEI_NO_OYA = Nothing
        mXTORIKIRI = Nothing
        mXOUT_START_DT = Nothing
        mXOUT_END_DT = Nothing
        mXSYUKKA_STS_DTL = Nothing
        mXDENPYOU_NO = Nothing


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
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFPLAN_KEY = TO_STRING_NULLABLE(objRow("FPLAN_KEY"))
        mXOUT_ORDER = TO_INTEGER_NULLABLE(objRow("XOUT_ORDER"))
        mXSYUKKA_KON_PLAN = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_PLAN"))
        mXSYUKKA_KON_RESERVE = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_RESERVE"))
        mXSYUKKA_KON_RESULT = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_RESULT"))
        mXSYUKKA_KON_H_RESULT = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_H_RESULT"))
        mXSAIMOKU = TO_STRING_NULLABLE(objRow("XSAIMOKU"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mXIDOU_KBN = TO_STRING_NULLABLE(objRow("XIDOU_KBN"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))
        mXTORIKIRI = TO_INTEGER_NULLABLE(objRow("XTORIKIRI"))
        mXOUT_START_DT = TO_DATE_NULLABLE(objRow("XOUT_START_DT"))
        mXOUT_END_DT = TO_DATE_NULLABLE(objRow("XOUT_END_DT"))
        mXSYUKKA_STS_DTL = TO_INTEGER_NULLABLE(objRow("XSYUKKA_STS_DTL"))
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:出荷指示詳細]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[出荷日:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[編成No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[作業種別:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FPLAN_KEY) Then
            strMsg &= "[計画ｷｰ:" & FPLAN_KEY & "]"
        End If
        If IsNotNull(XOUT_ORDER) Then
            strMsg &= "[車輌内出荷品目順:" & XOUT_ORDER & "]"
        End If
        If IsNotNull(XSYUKKA_KON_PLAN) Then
            strMsg &= "[出荷予定梱数:" & XSYUKKA_KON_PLAN & "]"
        End If
        If IsNotNull(XSYUKKA_KON_RESERVE) Then
            strMsg &= "[出荷引当梱数:" & XSYUKKA_KON_RESERVE & "]"
        End If
        If IsNotNull(XSYUKKA_KON_RESULT) Then
            strMsg &= "[出荷実績梱数:" & XSYUKKA_KON_RESULT & "]"
        End If
        If IsNotNull(XSYUKKA_KON_H_RESULT) Then
            strMsg &= "[出荷実績梱数(平置):" & XSYUKKA_KON_H_RESULT & "]"
        End If
        If IsNotNull(XSAIMOKU) Then
            strMsg &= "[取引区分細目:" & XSAIMOKU & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[在庫区分:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(XIDOU_KBN) Then
            strMsg &= "[移動区分:" & XIDOU_KBN & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[親編成No.:" & XHENSEI_NO_OYA & "]"
        End If
        If IsNotNull(XTORIKIRI) Then
            strMsg &= "[取り切り指定:" & XTORIKIRI & "]"
        End If
        If IsNotNull(XOUT_START_DT) Then
            strMsg &= "[出庫開始日時:" & XOUT_START_DT & "]"
        End If
        If IsNotNull(XOUT_END_DT) Then
            strMsg &= "[出庫完了日時:" & XOUT_END_DT & "]"
        End If
        If IsNotNull(XSYUKKA_STS_DTL) Then
            strMsg &= "[出荷状況詳細:" & XSYUKKA_STS_DTL & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[伝票No.:" & XDENPYOU_NO & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  出荷指示詳細削除[編成№/伝票№単位] (Public  DELETE_XPLN_OUT_DTL_HENSEI)"
    Public Sub DELETE_XPLN_OUT_DTL_HENSEI()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '----------------
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '----------------
            If mXSYUKKA_D = DEFAULT_DATE Then
                strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
                Throw New System.Exception(strMsg)
            ElseIf mXHENSEI_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[編成№]"
                Throw New System.Exception(strMsg)
            ElseIf mXDENPYOU_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[伝票№]"
                Throw New System.Exception(strMsg)
            End If


            '-----------------------
            '削除SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_D = TO_DATE('" & Format(mXSYUKKA_D, "yyyy/MM/dd") & "','YYYY/MM/DD')"                       '出荷日
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XHENSEI_NO = '" & TO_STRING(mXHENSEI_NO) & "'"          '編成№
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XDENPYOU_NO = '" & TO_STRING(mXDENPYOU_NO) & "'"        '伝票№
            strSQL &= vbCrLf


            '-----------------
            '削除
            '-----------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_DELETE & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
