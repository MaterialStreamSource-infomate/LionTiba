'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】MELSEC通信ﾛｸﾞﾃｰﾌﾞﾙｸﾗｽ
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
''' MELSEC通信ﾛｸﾞﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XLOG_MELSEC
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XLOG_MELSEC()                                       'MELSEC通信ﾛｸﾞ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFLOG_CHECK_DT1 As Nullable(Of Date)                                 '確認日時_1
    Private mFEQ_ID As String                                                    '設備ID
    Private mXCOMMENT01 As String                                                'ｺﾒﾝﾄ01
    Private mXCOMMENT01_01 As String                                             'ｺﾒﾝﾄ01_01
    Private mXCOMMENT02 As String                                                'ｺﾒﾝﾄ02
    Private mXCOMMENT03 As String                                                'ｺﾒﾝﾄ03
    Private mXCOMMENT04 As String                                                'ｺﾒﾝﾄ04
    Private mXCOMMENT05 As String                                                'ｺﾒﾝﾄ05
    Private mXCOMMENT06 As String                                                'ｺﾒﾝﾄ06
    Private mXCOMMENT07 As String                                                'ｺﾒﾝﾄ07
    Private mXCOMMENT08 As String                                                'ｺﾒﾝﾄ08
    Private mXCOMMENT09 As String                                                'ｺﾒﾝﾄ09
    Private mFTEXT_ID As String                                                  'ﾃｷｽﾄID
    Private mFTRNS_SERIAL As String                                              '搬送ｼﾘｱﾙ№(MCｷｰ)
    Private mFLOG_CHECK_DT2 As Nullable(Of Date)                                 '確認日時_2
    Private mFDENBUN As String                                                   '通信電文
    Private mFDENBUN02 As String                                                 '通信電文02
    Private mFLOG_NO As String                                                   'ﾛｸﾞ№
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XLOG_MELSEC()
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
    ''' 確認日時_1
    ''' </summary>
    Public Property FLOG_CHECK_DT1() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT1
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT1 = Value
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
    ''' ｺﾒﾝﾄ01
    ''' </summary>
    Public Property XCOMMENT01() As String
        Get
            Return mXCOMMENT01
        End Get
        Set(ByVal Value As String)
            mXCOMMENT01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ01_01
    ''' </summary>
    Public Property XCOMMENT01_01() As String
        Get
            Return mXCOMMENT01_01
        End Get
        Set(ByVal Value As String)
            mXCOMMENT01_01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ02
    ''' </summary>
    Public Property XCOMMENT02() As String
        Get
            Return mXCOMMENT02
        End Get
        Set(ByVal Value As String)
            mXCOMMENT02 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ03
    ''' </summary>
    Public Property XCOMMENT03() As String
        Get
            Return mXCOMMENT03
        End Get
        Set(ByVal Value As String)
            mXCOMMENT03 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ04
    ''' </summary>
    Public Property XCOMMENT04() As String
        Get
            Return mXCOMMENT04
        End Get
        Set(ByVal Value As String)
            mXCOMMENT04 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ05
    ''' </summary>
    Public Property XCOMMENT05() As String
        Get
            Return mXCOMMENT05
        End Get
        Set(ByVal Value As String)
            mXCOMMENT05 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ06
    ''' </summary>
    Public Property XCOMMENT06() As String
        Get
            Return mXCOMMENT06
        End Get
        Set(ByVal Value As String)
            mXCOMMENT06 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ07
    ''' </summary>
    Public Property XCOMMENT07() As String
        Get
            Return mXCOMMENT07
        End Get
        Set(ByVal Value As String)
            mXCOMMENT07 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ08
    ''' </summary>
    Public Property XCOMMENT08() As String
        Get
            Return mXCOMMENT08
        End Get
        Set(ByVal Value As String)
            mXCOMMENT08 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ09
    ''' </summary>
    Public Property XCOMMENT09() As String
        Get
            Return mXCOMMENT09
        End Get
        Set(ByVal Value As String)
            mXCOMMENT09 = Value
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
    ''' 確認日時_2
    ''' </summary>
    Public Property FLOG_CHECK_DT2() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT2
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT2 = Value
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
    ''' ﾛｸﾞ№
    ''' </summary>
    Public Property FLOG_NO() As String
        Get
            Return mFLOG_NO
        End Get
        Set(ByVal Value As String)
            mFLOG_NO = Value
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
    Public Function GET_XLOG_MELSEC(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
        strDataSetName = "XLOG_MELSEC"
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
    Public Function GET_XLOG_MELSEC_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
        strDataSetName = "XLOG_MELSEC"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XLOG_MELSEC(Owner, objDb, objDbLog)
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
    Public Function GET_XLOG_MELSEC_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XLOG_MELSEC"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XLOG_MELSEC(Owner, objDb, objDbLog)
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
    Public Function GET_XLOG_MELSEC_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
        strDataSetName = "XLOG_MELSEC"
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
    Public Sub UPDATE_XLOG_MELSEC()
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
        End If


        '***********************
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = NULL --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = NULL --確認日時_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --確認日時_1")
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
        If IsNull(mXCOMMENT01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01 = NULL --ｺﾒﾝﾄ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01 = NULL --ｺﾒﾝﾄ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT01_01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01_01 = NULL --ｺﾒﾝﾄ01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01_01 = NULL --ｺﾒﾝﾄ01_01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01_01 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01_01 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT02 = NULL --ｺﾒﾝﾄ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT02 = NULL --ｺﾒﾝﾄ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT02 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT02 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT03) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT03 = NULL --ｺﾒﾝﾄ03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT03 = NULL --ｺﾒﾝﾄ03")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT03 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT03 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT04 = NULL --ｺﾒﾝﾄ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT04 = NULL --ｺﾒﾝﾄ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT04 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT04 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT05 = NULL --ｺﾒﾝﾄ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT05 = NULL --ｺﾒﾝﾄ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT05 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT05 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT06) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT06 = NULL --ｺﾒﾝﾄ06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT06 = NULL --ｺﾒﾝﾄ06")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT06 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT06 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT07) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT07 = NULL --ｺﾒﾝﾄ07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT07 = NULL --ｺﾒﾝﾄ07")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT07 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT07 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT08) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT08 = NULL --ｺﾒﾝﾄ08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT08 = NULL --ｺﾒﾝﾄ08")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT08 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT08 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT09) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT09 = NULL --ｺﾒﾝﾄ09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT09 = NULL --ｺﾒﾝﾄ09")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT09 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT09 = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
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
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = NULL --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = NULL --確認日時_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --確認日時_2")
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
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
    Public Sub ADD_XLOG_MELSEC()
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
        End If


        '***********************
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_1")
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
        If IsNull(mXCOMMENT01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT01_01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ01_01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT03) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ03")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT06) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ06")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT07) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ07")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT08) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ08")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT09) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ09")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
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
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_2")
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
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
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
    Public Sub DELETE_XLOG_MELSEC()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
    Public Sub DELETE_XLOG_MELSEC_ANY()
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_CHECK_DT1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(XCOMMENT01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01")
        End If
        If IsNotNull(XCOMMENT01_01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ01_01")
        End If
        If IsNotNull(XCOMMENT02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ02")
        End If
        If IsNotNull(XCOMMENT03) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ03")
        End If
        If IsNotNull(XCOMMENT04) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ04")
        End If
        If IsNotNull(XCOMMENT05) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ05")
        End If
        If IsNotNull(XCOMMENT06) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ06")
        End If
        If IsNotNull(XCOMMENT07) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ07")
        End If
        If IsNotNull(XCOMMENT08) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ08")
        End If
        If IsNotNull(XCOMMENT09) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ09")
        End If
        If IsNotNull(FTEXT_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNotNull(FTRNS_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --搬送ｼﾘｱﾙ№(MCｷｰ)")
        End If
        If IsNotNull(FLOG_CHECK_DT2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
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
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT1")) = False Then mFLOG_CHECK_DT1 = objObject.FLOG_CHECK_DT1 '確認日時_1
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("XCOMMENT01")) = False Then mXCOMMENT01 = objObject.XCOMMENT01 'ｺﾒﾝﾄ01
        If IsNothing(objType.GetProperty("XCOMMENT01_01")) = False Then mXCOMMENT01_01 = objObject.XCOMMENT01_01 'ｺﾒﾝﾄ01_01
        If IsNothing(objType.GetProperty("XCOMMENT02")) = False Then mXCOMMENT02 = objObject.XCOMMENT02 'ｺﾒﾝﾄ02
        If IsNothing(objType.GetProperty("XCOMMENT03")) = False Then mXCOMMENT03 = objObject.XCOMMENT03 'ｺﾒﾝﾄ03
        If IsNothing(objType.GetProperty("XCOMMENT04")) = False Then mXCOMMENT04 = objObject.XCOMMENT04 'ｺﾒﾝﾄ04
        If IsNothing(objType.GetProperty("XCOMMENT05")) = False Then mXCOMMENT05 = objObject.XCOMMENT05 'ｺﾒﾝﾄ05
        If IsNothing(objType.GetProperty("XCOMMENT06")) = False Then mXCOMMENT06 = objObject.XCOMMENT06 'ｺﾒﾝﾄ06
        If IsNothing(objType.GetProperty("XCOMMENT07")) = False Then mXCOMMENT07 = objObject.XCOMMENT07 'ｺﾒﾝﾄ07
        If IsNothing(objType.GetProperty("XCOMMENT08")) = False Then mXCOMMENT08 = objObject.XCOMMENT08 'ｺﾒﾝﾄ08
        If IsNothing(objType.GetProperty("XCOMMENT09")) = False Then mXCOMMENT09 = objObject.XCOMMENT09 'ｺﾒﾝﾄ09
        If IsNothing(objType.GetProperty("FTEXT_ID")) = False Then mFTEXT_ID = objObject.FTEXT_ID 'ﾃｷｽﾄID
        If IsNothing(objType.GetProperty("FTRNS_SERIAL")) = False Then mFTRNS_SERIAL = objObject.FTRNS_SERIAL '搬送ｼﾘｱﾙ№(MCｷｰ)
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT2")) = False Then mFLOG_CHECK_DT2 = objObject.FLOG_CHECK_DT2 '確認日時_2
        If IsNothing(objType.GetProperty("FDENBUN")) = False Then mFDENBUN = objObject.FDENBUN '通信電文
        If IsNothing(objType.GetProperty("FDENBUN02")) = False Then mFDENBUN02 = objObject.FDENBUN02 '通信電文02
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO 'ﾛｸﾞ№

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
        mFLOG_CHECK_DT1 = Nothing
        mFEQ_ID = Nothing
        mXCOMMENT01 = Nothing
        mXCOMMENT01_01 = Nothing
        mXCOMMENT02 = Nothing
        mXCOMMENT03 = Nothing
        mXCOMMENT04 = Nothing
        mXCOMMENT05 = Nothing
        mXCOMMENT06 = Nothing
        mXCOMMENT07 = Nothing
        mXCOMMENT08 = Nothing
        mXCOMMENT09 = Nothing
        mFTEXT_ID = Nothing
        mFTRNS_SERIAL = Nothing
        mFLOG_CHECK_DT2 = Nothing
        mFDENBUN = Nothing
        mFDENBUN02 = Nothing
        mFLOG_NO = Nothing


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
        mFLOG_CHECK_DT1 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT1"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mXCOMMENT01 = TO_STRING_NULLABLE(objRow("XCOMMENT01"))
        mXCOMMENT01_01 = TO_STRING_NULLABLE(objRow("XCOMMENT01_01"))
        mXCOMMENT02 = TO_STRING_NULLABLE(objRow("XCOMMENT02"))
        mXCOMMENT03 = TO_STRING_NULLABLE(objRow("XCOMMENT03"))
        mXCOMMENT04 = TO_STRING_NULLABLE(objRow("XCOMMENT04"))
        mXCOMMENT05 = TO_STRING_NULLABLE(objRow("XCOMMENT05"))
        mXCOMMENT06 = TO_STRING_NULLABLE(objRow("XCOMMENT06"))
        mXCOMMENT07 = TO_STRING_NULLABLE(objRow("XCOMMENT07"))
        mXCOMMENT08 = TO_STRING_NULLABLE(objRow("XCOMMENT08"))
        mXCOMMENT09 = TO_STRING_NULLABLE(objRow("XCOMMENT09"))
        mFTEXT_ID = TO_STRING_NULLABLE(objRow("FTEXT_ID"))
        mFTRNS_SERIAL = TO_STRING_NULLABLE(objRow("FTRNS_SERIAL"))
        mFLOG_CHECK_DT2 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT2"))
        mFDENBUN = TO_STRING_NULLABLE(objRow("FDENBUN"))
        mFDENBUN02 = TO_STRING_NULLABLE(objRow("FDENBUN02"))
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:MELSEC通信ﾛｸﾞ]"
        If IsNotNull(FLOG_CHECK_DT1) Then
            strMsg &= "[確認日時_1:" & FLOG_CHECK_DT1 & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(XCOMMENT01) Then
            strMsg &= "[ｺﾒﾝﾄ01:" & XCOMMENT01 & "]"
        End If
        If IsNotNull(XCOMMENT01_01) Then
            strMsg &= "[ｺﾒﾝﾄ01_01:" & XCOMMENT01_01 & "]"
        End If
        If IsNotNull(XCOMMENT02) Then
            strMsg &= "[ｺﾒﾝﾄ02:" & XCOMMENT02 & "]"
        End If
        If IsNotNull(XCOMMENT03) Then
            strMsg &= "[ｺﾒﾝﾄ03:" & XCOMMENT03 & "]"
        End If
        If IsNotNull(XCOMMENT04) Then
            strMsg &= "[ｺﾒﾝﾄ04:" & XCOMMENT04 & "]"
        End If
        If IsNotNull(XCOMMENT05) Then
            strMsg &= "[ｺﾒﾝﾄ05:" & XCOMMENT05 & "]"
        End If
        If IsNotNull(XCOMMENT06) Then
            strMsg &= "[ｺﾒﾝﾄ06:" & XCOMMENT06 & "]"
        End If
        If IsNotNull(XCOMMENT07) Then
            strMsg &= "[ｺﾒﾝﾄ07:" & XCOMMENT07 & "]"
        End If
        If IsNotNull(XCOMMENT08) Then
            strMsg &= "[ｺﾒﾝﾄ08:" & XCOMMENT08 & "]"
        End If
        If IsNotNull(XCOMMENT09) Then
            strMsg &= "[ｺﾒﾝﾄ09:" & XCOMMENT09 & "]"
        End If
        If IsNotNull(FTEXT_ID) Then
            strMsg &= "[ﾃｷｽﾄID:" & FTEXT_ID & "]"
        End If
        If IsNotNull(FTRNS_SERIAL) Then
            strMsg &= "[搬送ｼﾘｱﾙ№(MCｷｰ):" & FTRNS_SERIAL & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT2) Then
            strMsg &= "[確認日時_2:" & FLOG_CHECK_DT2 & "]"
        End If
        If IsNotNull(FDENBUN) Then
            strMsg &= "[通信電文:" & FDENBUN & "]"
        End If
        If IsNotNull(FDENBUN02) Then
            strMsg &= "[通信電文02:" & FDENBUN02 & "]"
        End If
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[ﾛｸﾞ№:" & FLOG_NO & "]"
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
#Region "  ﾒﾙｾｯｸ通信ﾛｸﾞ追加  [SEQ発番]                  "
    Public Sub ADD_XLOG_MELSEC_SEQ()
        Try


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_EQ                    'ｼｰｹﾝｽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ№の特定


            '***********************
            '追加
            '***********************
            Me.ADD_XLOG_MELSEC()


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
