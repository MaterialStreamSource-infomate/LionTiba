'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' ÅyñºèÃÅzMaterialStream√∞ÃﬁŸ∏◊Ω
' Åyã@î\ÅzïÔçﬁ“∞∂∞œΩ¿√∞ÃﬁŸ∏◊Ω
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
''' ïÔçﬁ“∞∂∞œΩ¿√∞ÃﬁŸ∏◊Ω
''' </summary>
Public Class TBL_XMST_WRAPPING_MAKER
    Inherits clsTemplateTable

    '**********************************************************************************************
    'Å´Å´Å´é©ìÆê∂ê¨ïî
#Region "  ∏◊ΩïœêîíËã`                  "
    'Ãﬂ€ ﬂ√®
    Private mobjAryMe As TBL_XMST_WRAPPING_MAKER()                               'ïÔçﬁ“∞∂∞œΩ¿
    Private mstrUSER_SQL As String                                               '’∞ªﬁ∞SQL
    Private mORDER_BY As String                                                  'OrderByãÂ
    Private mWHERE As String                                                     'WhereãÂ
    Private mXMAKER_CD As String                                                 '“∞∂-∫∞ƒﬁ
    Private mXMAKER_NAME As String                                               '“∞∂-ñº
    Private mFENTRY_DT As Nullable(Of Date)                                      'ìoò^ì˙éû
#End Region
#Region "  Ãﬂ€ ﬂ√®íËã`                  "
    ''' <summary>
    ''' ºΩ√—ïœêî (é©∏◊Ωå^îzóÒ)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_WRAPPING_MAKER()
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
    ''' “∞∂-∫∞ƒﬁ
    ''' </summary>
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' “∞∂-ñº
    ''' </summary>
    Public Property XMAKER_NAME() As String
        Get
            Return mXMAKER_NAME
        End Get
        Set(ByVal Value As String)
            mXMAKER_NAME = Value
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
    Public Function GET_XMST_WRAPPING_MAKER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        If IsNull(XMAKER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            strSQL.Append(vbCrLf & "    AND XMAKER_NAME = :" & UBound(strBindField) - 1 & " --“∞∂-ñº")
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
        strDataSetName = "XMST_WRAPPING_MAKER"
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
    Public Function GET_XMST_WRAPPING_MAKER_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        If IsNull(XMAKER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            strSQL.Append(vbCrLf & "    AND XMAKER_NAME = :" & UBound(strBindField) - 1 & " --“∞∂-ñº")
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
        strDataSetName = "XMST_WRAPPING_MAKER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_WRAPPING_MAKER(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_WRAPPING_MAKER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XMST_WRAPPING_MAKER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_WRAPPING_MAKER(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_WRAPPING_MAKER_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        If IsNull(XMAKER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            strSQL.Append(vbCrLf & "    AND XMAKER_NAME = :" & UBound(strBindField) - 1 & " --“∞∂-ñº")
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
        strDataSetName = "XMST_WRAPPING_MAKER"
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
    Public Sub UPDATE_XMST_WRAPPING_MAKER()
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
        ElseIf IsNull(mXMAKER_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[“∞∂-∫∞ƒﬁ]"
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = NULL --“∞∂-∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = NULL --“∞∂-∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = :" & Ubound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = :" & Ubound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_NAME = NULL --“∞∂-ñº")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_NAME = NULL --“∞∂-ñº")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_NAME = :" & Ubound(strBindField) - 1 & " --“∞∂-ñº")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_NAME = :" & Ubound(strBindField) - 1 & " --“∞∂-ñº")
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
        If IsNull(XMAKER_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XMAKER_CD IS NULL --“∞∂-∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
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
    Public Sub ADD_XMST_WRAPPING_MAKER()
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
        ElseIf IsNull(mXMAKER_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[“∞∂-∫∞ƒﬁ]"
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --“∞∂-∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --“∞∂-∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --“∞∂-ñº")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --“∞∂-ñº")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --“∞∂-ñº")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --“∞∂-ñº")
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
    Public Sub DELETE_XMST_WRAPPING_MAKER()
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
        ElseIf IsNull(mXMAKER_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[“∞∂-∫∞ƒﬁ]"
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XMAKER_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XMAKER_CD IS NULL --“∞∂-∫∞ƒﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
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
    Public Sub DELETE_XMST_WRAPPING_MAKER_ANY()
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
        strSQL.Append(vbCrLf & "    XMST_WRAPPING_MAKER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XMAKER_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --“∞∂-∫∞ƒﬁ")
        End If
        If IsNotNull(XMAKER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_NAME
            strSQL.Append(vbCrLf & "    AND XMAKER_NAME = :" & UBound(strBindField) - 1 & " --“∞∂-ñº")
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
        If IsNothing(objType.GetProperty("XMAKER_CD")) = False Then mXMAKER_CD = objObject.XMAKER_CD '“∞∂-∫∞ƒﬁ
        If IsNothing(objType.GetProperty("XMAKER_NAME")) = False Then mXMAKER_NAME = objObject.XMAKER_NAME '“∞∂-ñº
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
        mXMAKER_CD = Nothing
        mXMAKER_NAME = Nothing
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
        mXMAKER_CD = TO_STRING_NULLABLE(objRow("XMAKER_CD"))
        mXMAKER_NAME = TO_STRING_NULLABLE(objRow("XMAKER_NAME"))
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
        strMsg &= "[√∞ÃﬁŸñº:ïÔçﬁ“∞∂∞œΩ¿]"
        If IsNotNull(XMAKER_CD) Then
            strMsg &= "[“∞∂-∫∞ƒﬁ:" & XMAKER_CD & "]"
        End If
        If IsNotNull(XMAKER_NAME) Then
            strMsg &= "[“∞∂-ñº:" & XMAKER_NAME & "]"
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
