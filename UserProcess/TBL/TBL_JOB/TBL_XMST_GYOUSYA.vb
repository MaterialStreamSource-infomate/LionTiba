'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' ÅyñºèÃÅzMaterialStream√∞ÃﬁŸ∏◊Ω
' Åyã@î\Åzã∆é“œΩ¿√∞ÃﬁŸ∏◊Ω
' ÅyçÏê¨Åz2010/03/02  SIT                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' ã∆é“œΩ¿√∞ÃﬁŸ∏◊Ω
''' </summary>
Public Class TBL_XMST_GYOUSYA
    Inherits clsTemplateTable

    '**********************************************************************************************
    'Å´Å´Å´é©ìÆê∂ê¨ïî
#Region "  ∏◊ΩïœêîíËã`                  "
    'Ãﬂ€ ﬂ√®
    Private mobjAryMe As TBL_XMST_GYOUSYA()                                      'ã∆é“œΩ¿
    Private mstrUSER_SQL As String                                               '’∞ªﬁ∞SQL
    Private mORDER_BY As String                                                  'OrderByãÂ
    Private mWHERE As String                                                     'WhereãÂ
    Private mXGYOUSYA_CD As String                                               'ï®ó¨ã∆é“∫∞ƒﬁ
    Private mXGYOUSYA_NAME As String                                             'ï®ó¨ã∆é“ñºèÃ
    Private mXGYOUSYA_RYAKU As String                                            'ó™èÃ
    Private mXADDRESS As String                                                  'èZèä
    Private mXTELEPHONE As String                                                'ìdòbî‘çÜ
    Private mXPOSTAL_CODE As String                                              'óXï÷î‘çÜ
    Private mFENTRY_DT As Nullable(Of Date)                                      'ìoò^ì˙éû
#End Region
#Region "  Ãﬂ€ ﬂ√®íËã`                  "
    ''' <summary>
    ''' ºΩ√—ïœêî (é©∏◊Ωå^îzóÒ)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_GYOUSYA()
        Get
            Return mobjAryMe
        End Get
    End Property
    ''' <summary>
    ''' ’∞ªﬁ∞SQL (ï∂éöå^)
    ''' </summary>
    Public WriteOnly Property USER_SQL() As String
        Set(ByVal Value As String)
            mstrUSER_SQL = Value
        End Set
    End Property
    ''' <summary>
    ''' OrderByãÂ
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
    ''' WhereãÂ
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
    ''' ï®ó¨ã∆é“∫∞ƒﬁ
    ''' </summary>
    Public Property XGYOUSYA_CD() As String
        Get
            Return mXGYOUSYA_CD
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ï®ó¨ã∆é“ñºèÃ
    ''' </summary>
    Public Property XGYOUSYA_NAME() As String
        Get
            Return mXGYOUSYA_NAME
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ó™èÃ
    ''' </summary>
    Public Property XGYOUSYA_RYAKU() As String
        Get
            Return mXGYOUSYA_RYAKU
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_RYAKU = Value
        End Set
    End Property
    ''' <summary>
    ''' èZèä
    ''' </summary>
    Public Property XADDRESS() As String
        Get
            Return mXADDRESS
        End Get
        Set(ByVal Value As String)
            mXADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' ìdòbî‘çÜ
    ''' </summary>
    Public Property XTELEPHONE() As String
        Get
            Return mXTELEPHONE
        End Get
        Set(ByVal Value As String)
            mXTELEPHONE = Value
        End Set
    End Property
    ''' <summary>
    ''' óXï÷î‘çÜ
    ''' </summary>
    Public Property XPOSTAL_CODE() As String
        Get
            Return mXPOSTAL_CODE
        End Get
        Set(ByVal Value As String)
            mXPOSTAL_CODE = Value
        End Set
    End Property
    ''' <summary>
    ''' ìoò^ì˙éû
    ''' </summary>
    Public Property FENTRY_DT() As Nullable(Of Date)
        Get
            Return mFENTRY_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFENTRY_DT = Value
        End Set
    End Property
#End Region
#Region "  ∫›Ωƒ◊∏¿                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ∫›Ωƒ◊∏¿
    ''' </summary>
    ''' <param name="objOwner">µ∞≈∞µÃﬁºﬁ™∏ƒ</param>
    ''' <param name="objDb">DB±∏æΩµÃﬁºﬁ™∏ƒ</param>
    ''' <param name="objDbLog">DB±∏æΩµÃﬁºﬁ™∏ƒ(€∏ﬁèëÇ´çûÇ›óp)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)   'êe∏◊ΩÇÃ∫›Ωƒ◊∏¿Çé¿ëï
    End Sub
#End Region
#Region "  √ﬁ∞¿éÊìæ                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿éÊìæ
    ''' </summary>
    ''' <param name="blnNotFoundError">⁄∫∞ƒﬁÇ™àÍåèÇ‡éÊìæèoóàÇ»Ç©Ç¡ÇΩèÍçáÅAThrowÇ∑ÇÈÇ©î€Ç©ÇÃÃ◊∏ﬁ</param>
    ''' <returns>ã§í ñﬂÇËíl</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_GYOUSYA(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As New StringBuilder 'SQLï∂
        Dim objDataSet As New DataSet   '√ﬁ∞¿æØƒ
        Dim strDataSetName As String    '√ﬁ∞¿æØƒñº
        Dim objRow As DataRow           '1⁄∫∞ƒﬁï™ÇÃ√ﬁ∞¿
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        'íäèoSQLçÏê¨
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --ó™èÃ")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --èZèä")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --ìoò^ì˙éû")
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
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'íäèo
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        ElseIf objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then

            If blnNotFoundError = True Then
                '(¥◊∞Ç∆Ç∑ÇÈèÍçá)
                Dim strMsg As String = ""
                Call MAKE_ERRMSG01(strMsg)
                Throw New UserException(strMsg)
            Else
                '(¥◊∞ÇµÇ»Ç¢èÍçá)
                Return (RetCode.NotFound)
            End If

        Else
            Throw New UserException("ï°êî⁄∫∞ƒﬁíäèoÇµÇΩà◊ÅA¥◊∞Ç∆ÇµÇ‹Ç∑ÅB")
        End If


    End Function
#End Region
#Region "  √ﬁ∞¿éÊìæ(ï°êî⁄∫∞ƒﬁ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿éÊìæ(ï°êî⁄∫∞ƒﬁ)
    ''' </summary>
    ''' <returns>ã§í ñﬂÇËíl</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_GYOUSYA_ANY() As RetCode
        Dim strSQL As New StringBuilder 'SQLï∂
        Dim objDataSet As New DataSet   '√ﬁ∞¿æØƒ
        Dim strDataSetName As String    '√ﬁ∞¿æØƒñº
        Dim objRow As DataRow           '1⁄∫∞ƒﬁï™ÇÃ√ﬁ∞¿
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        'íäèoSQLçÏê¨
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --ó™èÃ")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --èZèä")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --ìoò^ì˙éû")
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
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'íäèo
        '***********************
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_GYOUSYA(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  √ﬁ∞¿éÊìæ(∂Ω¿—íäèo)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿éÊìæ(∂Ω¿—íäèo)
    ''' </summary>
    ''' <param name="objUSER_PARAM">’∞ªﬁ∞PARAM ( ﬁ≤›ƒﬁïœêîópµÃﬁºﬁ™∏ƒå^îzóÒ)</param>
    ''' <returns>ã§í ñﬂÇËíl</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_GYOUSYA_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
        Dim strMsg As String            '“Øæ∞ºﬁ
        Dim objDataSet As New DataSet   '√ﬁ∞¿æØƒ
        Dim strDataSetName As String    '√ﬁ∞¿æØƒñº
        Dim objRow As DataRow           '1⁄∫∞ƒﬁï™ÇÃ√ﬁ∞¿
        Dim ii As Integer               '∂≥›¿


        '***********************
        'Ãﬂ€ ﬂ√®¡™Ø∏
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mstrUSER_SQL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[’∞ªﬁ∞SQL]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'íäèo
        '***********************
        mobjAryMe = Nothing
        If IsNothing(objUSER_PARAM) = False Then
            ObjDb.Parameter = objUSER_PARAM
        End If
        ObjDb.SQL = mstrUSER_SQL
        objDataSet.Clear()
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_GYOUSYA(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  √ﬁ∞¿éÊìæ(∂≥›ƒ)               "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿éÊìæ(∂≥›ƒ)
    ''' </summary>
    ''' <returns>ã§í ñﬂÇËíl</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_GYOUSYA_COUNT() As Integer
        Dim strSQL As New StringBuilder 'SQLï∂
        Dim objDataSet As New DataSet   '√ﬁ∞¿æØƒ
        Dim strDataSetName As String    '√ﬁ∞¿æØƒñº
        Dim objRow As DataRow           '1⁄∫∞ƒﬁï™ÇÃ√ﬁ∞¿
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        'íäèoSQLçÏê¨
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --ó™èÃ")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --èZèä")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --ìoò^ì˙éû")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'íäèo
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        Return (objRow(0))


    End Function
#End Region
#Region "  √ﬁ∞¿çXêV                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿çXêV
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_XMST_GYOUSYA()
        Dim strSQL As New StringBuilder     'SQLï∂
        Dim strMsg As String                '“Øæ∞ºﬁ
        Dim intRetSQL As Integer            'SQLé¿çsñﬂÇËíl
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'Ãﬂ€ ﬂ√®¡™Ø∏
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ï®ó¨ã∆é“∫∞ƒﬁ]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'çXêVSQLçÏê¨
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_NAME = NULL --ï®ó¨ã∆é“ñºèÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_NAME = NULL --ï®ó¨ã∆é“ñºèÃ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_NAME = :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_NAME = :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_RYAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_RYAKU = NULL --ó™èÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_RYAKU = NULL --ó™èÃ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_RYAKU = :" & Ubound(strBindField) - 1 & " --ó™èÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_RYAKU = :" & Ubound(strBindField) - 1 & " --ó™èÃ")
        End If
        intCount = intCount + 1
        If IsNull(mXADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADDRESS = NULL --èZèä")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADDRESS = NULL --èZèä")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADDRESS = :" & Ubound(strBindField) - 1 & " --èZèä")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADDRESS = :" & Ubound(strBindField) - 1 & " --èZèä")
        End If
        intCount = intCount + 1
        If IsNull(mXTELEPHONE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTELEPHONE = NULL --ìdòbî‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTELEPHONE = NULL --ìdòbî‘çÜ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTELEPHONE = :" & Ubound(strBindField) - 1 & " --ìdòbî‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTELEPHONE = :" & Ubound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        intCount = intCount + 1
        If IsNull(mXPOSTAL_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPOSTAL_CODE = NULL --óXï÷î‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPOSTAL_CODE = NULL --óXï÷î‘çÜ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPOSTAL_CODE = :" & Ubound(strBindField) - 1 & " --óXï÷î‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPOSTAL_CODE = :" & Ubound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = NULL --ìoò^ì˙éû")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = NULL --ìoò^ì˙éû")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = :" & Ubound(strBindField) - 1 & " --ìoò^ì˙éû")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = :" & Ubound(strBindField) - 1 & " --ìoò^ì˙éû")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XGYOUSYA_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD IS NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If


        '***********************
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'çXêV
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL¥◊∞)
            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If
        If intRetSQL < 1 Then
            '(ëŒè€çsñ≥Çµ)
            strMsg = ERRMSG_ERR_UPDATE & "[ëŒè€çsñ≥Çµ]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  √ﬁ∞¿í«â¡                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿í«â¡
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ADD_XMST_GYOUSYA()
        Dim strSQL As New StringBuilder     'SQLï∂
        Dim strMsg As String                '“Øæ∞ºﬁ
        Dim intRetSQL As Integer            'SQLé¿çsñﬂÇËíl
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'Ãﬂ€ ﬂ√®¡™Ø∏
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ï®ó¨ã∆é“∫∞ƒﬁ]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'í«â¡SQLçÏê¨
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ï®ó¨ã∆é“ñºèÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ï®ó¨ã∆é“ñºèÃ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_RYAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ó™èÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ó™èÃ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ó™èÃ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ó™èÃ")
        End If
        intCount = intCount + 1
        If IsNull(mXADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --èZèä")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --èZèä")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --èZèä")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --èZèä")
        End If
        intCount = intCount + 1
        If IsNull(mXTELEPHONE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ìdòbî‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ìdòbî‘çÜ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ìdòbî‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        intCount = intCount + 1
        If IsNull(mXPOSTAL_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --óXï÷î‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --óXï÷î‘çÜ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --óXï÷î‘çÜ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ìoò^ì˙éû")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ìoò^ì˙éû")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ìoò^ì˙éû")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ìoò^ì˙éû")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " )")


        '***********************
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'í«â¡
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL¥◊∞)
            strMsg = ERRMSG_ERR_ADD & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  √ﬁ∞¿çÌèú                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿çÌèú
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_XMST_GYOUSYA()
        Dim strSQL As New StringBuilder     'SQLï∂
        Dim strMsg As String                '“Øæ∞ºﬁ
        Dim intRetSQL As Integer            'SQLé¿çsñﬂÇËíl
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'Ãﬂ€ ﬂ√®¡™Ø∏
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ï®ó¨ã∆é“∫∞ƒﬁ]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'çÌèúSQLçÏê¨
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XGYOUSYA_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD IS NULL --ï®ó¨ã∆é“∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If


        '***********************
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'çÌèú
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL¥◊∞)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  √ﬁ∞¿çÌèú(ï°êî⁄∫∞ƒﬁ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿çÌèú
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_XMST_GYOUSYA_ANY()
        Dim strSQL As New StringBuilder     'SQLï∂
        Dim strMsg As String                '“Øæ∞ºﬁ
        Dim intRetSQL As Integer            'SQLé¿çsñﬂÇËíl
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'çÌèúSQLçÏê¨
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“∫∞ƒﬁ")
        End If
        If IsNotNull(XGYOUSYA_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --ï®ó¨ã∆é“ñºèÃ")
        End If
        If IsNotNull(XGYOUSYA_RYAKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --ó™èÃ")
        End If
        If IsNotNull(XADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --èZèä")
        End If
        If IsNotNull(XTELEPHONE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --ìdòbî‘çÜ")
        End If
        If IsNotNull(XPOSTAL_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --óXï÷î‘çÜ")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --ìoò^ì˙éû")
        End If


        '***********************
        ' ﬁ≤›ƒﬁïœêîíËã`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'çÌèú
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL¥◊∞)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  Ãﬂ€ ﬂ√®∫Àﬂ∞                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        'Ãﬂ€ ﬂ√®ïœêîÇ÷æØƒ
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD 'ï®ó¨ã∆é“∫∞ƒﬁ
        If IsNothing(objType.GetProperty("XGYOUSYA_NAME")) = False Then mXGYOUSYA_NAME = objObject.XGYOUSYA_NAME 'ï®ó¨ã∆é“ñºèÃ
        If IsNothing(objType.GetProperty("XGYOUSYA_RYAKU")) = False Then mXGYOUSYA_RYAKU = objObject.XGYOUSYA_RYAKU 'ó™èÃ
        If IsNothing(objType.GetProperty("XADDRESS")) = False Then mXADDRESS = objObject.XADDRESS 'èZèä
        If IsNothing(objType.GetProperty("XTELEPHONE")) = False Then mXTELEPHONE = objObject.XTELEPHONE 'ìdòbî‘çÜ
        If IsNothing(objType.GetProperty("XPOSTAL_CODE")) = False Then mXPOSTAL_CODE = objObject.XPOSTAL_CODE 'óXï÷î‘çÜ
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT 'ìoò^ì˙éû

    End Sub
#End Region
#Region "  Ãﬂ€ ﬂ√®∏ÿ±                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' Ãﬂ€ ﬂ√®∏ÿ±
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub CLEAR_PROPERTY()


        '***********************
        'Ãﬂ€ ﬂ√®ïœêî∏ÿ±
        '***********************
        Call ARYME_CLEAR()
        mstrUSER_SQL = Nothing
        mXGYOUSYA_CD = Nothing
        mXGYOUSYA_NAME = Nothing
        mXGYOUSYA_RYAKU = Nothing
        mXADDRESS = Nothing
        mXTELEPHONE = Nothing
        mXPOSTAL_CODE = Nothing
        mFENTRY_DT = Nothing


    End Sub
#End Region
#Region "  AryMe∏ÿ±                     "
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

#Region "  √ﬁ∞¿Å®ïœêî                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' √ﬁ∞¿Å®ïœêî
    ''' </summary>
    ''' <param name="objRow">√ﬁ∞¿⁄∫∞ƒﬁµÃﬁºﬁ™∏ƒ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA(ByVal objRow As DataRow)


        '***********************
        '√ﬁ∞¿æØƒ
        '***********************
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXGYOUSYA_NAME = TO_STRING_NULLABLE(objRow("XGYOUSYA_NAME"))
        mXGYOUSYA_RYAKU = TO_STRING_NULLABLE(objRow("XGYOUSYA_RYAKU"))
        mXADDRESS = TO_STRING_NULLABLE(objRow("XADDRESS"))
        mXTELEPHONE = TO_STRING_NULLABLE(objRow("XTELEPHONE"))
        mXPOSTAL_CODE = TO_STRING_NULLABLE(objRow("XPOSTAL_CODE"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))


    End Sub
#End Region
#Region "  ¥◊∞“Øæ∞ºﬁï∂éöóÒçÏê¨01        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ¥◊∞“Øæ∞ºﬁï∂éöóÒçÏê¨01
    ''' </summary>
    ''' <param name="strMsg">¥◊∞“Øæ∞ºﬁï∂éöóÒ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub MAKE_ERRMSG01(ByRef strMsg As String)


        '***********************
        '√ﬁ∞¿æØƒ
        '***********************
        strMsg = "⁄∫∞ƒﬁÇ™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩÅB"
        strMsg &= "[√∞ÃﬁŸñº:ã∆é“œΩ¿]"
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[ï®ó¨ã∆é“∫∞ƒﬁ:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XGYOUSYA_NAME) Then
            strMsg &= "[ï®ó¨ã∆é“ñºèÃ:" & XGYOUSYA_NAME & "]"
        End If
        If IsNotNull(XGYOUSYA_RYAKU) Then
            strMsg &= "[ó™èÃ:" & XGYOUSYA_RYAKU & "]"
        End If
        If IsNotNull(XADDRESS) Then
            strMsg &= "[èZèä:" & XADDRESS & "]"
        End If
        If IsNotNull(XTELEPHONE) Then
            strMsg &= "[ìdòbî‘çÜ:" & XTELEPHONE & "]"
        End If
        If IsNotNull(XPOSTAL_CODE) Then
            strMsg &= "[óXï÷î‘çÜ:" & XPOSTAL_CODE & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[ìoò^ì˙éû:" & FENTRY_DT & "]"
        End If


    End Sub
#End Region
    'Å™Å™Å™é©ìÆê∂ê¨ïî
    '**********************************************************************************************

    '**********************************************************************************************
    'Å´Å´Å´ºΩ√—ã§í 

    'Å™Å™Å™ºΩ√—ã§í 
    '**********************************************************************************************


    '**********************************************************************************************
    'Å´Å´Å´ºΩ√—å≈óL

    'Å™Å™Å™ºΩ√—å≈óL
    '**********************************************************************************************

End Class
