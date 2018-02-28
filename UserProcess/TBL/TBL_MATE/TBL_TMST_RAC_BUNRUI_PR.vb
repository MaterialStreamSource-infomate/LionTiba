'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' ÅyñºèÃÅzMaterialStream√∞ÃﬁŸ∏◊Ω
' Åyã@î\ÅzíIï™óﬁóDêÊèáœΩ¿√∞ÃﬁŸ∏◊Ω
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
''' íIï™óﬁóDêÊèáœΩ¿√∞ÃﬁŸ∏◊Ω
''' </summary>
Public Class TBL_TMST_RAC_BUNRUI_PR
    Inherits clsTemplateTable

    '**********************************************************************************************
    'Å´Å´Å´é©ìÆê∂ê¨ïî
#Region "  ∏◊ΩïœêîíËã`                  "
    'Ãﬂ€ ﬂ√®
    Private mobjAryMe As TBL_TMST_RAC_BUNRUI_PR()                                'íIï™óﬁóDêÊèáœΩ¿
    Private mstrUSER_SQL As String                                               '’∞ªﬁ∞SQL
    Private mORDER_BY As String                                                  'OrderByãÂ
    Private mWHERE As String                                                     'WhereãÂ
    Private mFRES_TYPE As String                                                 'à¯ìñ¿≤Ãﬂ
    Private mFRAC_PRIORITY As Nullable(Of Integer)                               'óDêÊèá
    Private mFRAC_BUNRUI As String                                               'íIï™óﬁ
#End Region
#Region "  Ãﬂ€ ﬂ√®íËã`                  "
    ''' <summary>
    ''' ºΩ√—ïœêî (é©∏◊Ωå^îzóÒ)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_RAC_BUNRUI_PR()
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
    ''' à¯ìñ¿≤Ãﬂ
    ''' </summary>
    Public Property FRES_TYPE() As String
        Get
            Return mFRES_TYPE
        End Get
        Set(ByVal Value As String)
            mFRES_TYPE = Value
        End Set
    End Property
    ''' <summary>
    ''' óDêÊèá
    ''' </summary>
    Public Property FRAC_PRIORITY() As Nullable(Of Integer)
        Get
            Return mFRAC_PRIORITY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_PRIORITY = Value
        End Set
    End Property
    ''' <summary>
    ''' íIï™óﬁ
    ''' </summary>
    Public Property FRAC_BUNRUI() As String
        Get
            Return mFRAC_BUNRUI
        End Get
        Set(ByVal Value As String)
            mFRAC_BUNRUI = Value
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
    Public Function GET_TMST_RAC_BUNRUI_PR(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FRES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNull(FRAC_PRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --íIï™óﬁ")
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
        strDataSetName = "TMST_RAC_BUNRUI_PR"
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
    Public Function GET_TMST_RAC_BUNRUI_PR_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FRES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNull(FRAC_PRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --íIï™óﬁ")
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
        strDataSetName = "TMST_RAC_BUNRUI_PR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_RAC_BUNRUI_PR(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_RAC_BUNRUI_PR_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_RAC_BUNRUI_PR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_RAC_BUNRUI_PR(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_RAC_BUNRUI_PR_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FRES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNull(FRAC_PRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --íIï™óﬁ")
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
        strDataSetName = "TMST_RAC_BUNRUI_PR"
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
    Public Sub UPDATE_TMST_RAC_BUNRUI_PR()
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
        ElseIf IsNull(mFRES_TYPE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[à¯ìñ¿≤Ãﬂ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRAC_PRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[óDêÊèá]"
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFRES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_TYPE = NULL --à¯ìñ¿≤Ãﬂ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_TYPE = NULL --à¯ìñ¿≤Ãﬂ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_TYPE = :" & Ubound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_TYPE = :" & Ubound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_PRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_PRIORITY = NULL --óDêÊèá")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_PRIORITY = NULL --óDêÊèá")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_PRIORITY = :" & Ubound(strBindField) - 1 & " --óDêÊèá")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_PRIORITY = :" & Ubound(strBindField) - 1 & " --óDêÊèá")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = NULL --íIï™óﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = NULL --íIï™óﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --íIï™óﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --íIï™óﬁ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FRES_TYPE) = True Then
            strSQL.Append(vbCrLf & "    AND FRES_TYPE IS NULL --à¯ìñ¿≤Ãﬂ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNull(FRAC_PRIORITY) = True Then
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY IS NULL --óDêÊèá")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
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
    Public Sub ADD_TMST_RAC_BUNRUI_PR()
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
        ElseIf IsNull(mFRES_TYPE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[à¯ìñ¿≤Ãﬂ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRAC_PRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[óDêÊèá]"
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFRES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --à¯ìñ¿≤Ãﬂ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --à¯ìñ¿≤Ãﬂ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_PRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --óDêÊèá")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --óDêÊèá")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --óDêÊèá")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --óDêÊèá")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --íIï™óﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --íIï™óﬁ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --íIï™óﬁ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --íIï™óﬁ")
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
    Public Sub DELETE_TMST_RAC_BUNRUI_PR()
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
        ElseIf IsNull(mFRES_TYPE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[à¯ìñ¿≤Ãﬂ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRAC_PRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[óDêÊèá]"
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FRES_TYPE) = True Then
            strSQL.Append(vbCrLf & "    AND FRES_TYPE IS NULL --à¯ìñ¿≤Ãﬂ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNull(FRAC_PRIORITY) = True Then
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY IS NULL --óDêÊèá")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
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
    Public Sub DELETE_TMST_RAC_BUNRUI_PR_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_RAC_BUNRUI_PR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FRES_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_TYPE
            strSQL.Append(vbCrLf & "    AND FRES_TYPE = :" & UBound(strBindField) - 1 & " --à¯ìñ¿≤Ãﬂ")
        End If
        If IsNotNull(FRAC_PRIORITY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_PRIORITY
            strSQL.Append(vbCrLf & "    AND FRAC_PRIORITY = :" & UBound(strBindField) - 1 & " --óDêÊèá")
        End If
        If IsNotNull(FRAC_BUNRUI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --íIï™óﬁ")
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
        If IsNothing(objType.GetProperty("FRES_TYPE")) = False Then mFRES_TYPE = objObject.FRES_TYPE 'à¯ìñ¿≤Ãﬂ
        If IsNothing(objType.GetProperty("FRAC_PRIORITY")) = False Then mFRAC_PRIORITY = objObject.FRAC_PRIORITY 'óDêÊèá
        If IsNothing(objType.GetProperty("FRAC_BUNRUI")) = False Then mFRAC_BUNRUI = objObject.FRAC_BUNRUI 'íIï™óﬁ

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
        mFRES_TYPE = Nothing
        mFRAC_PRIORITY = Nothing
        mFRAC_BUNRUI = Nothing


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
        mFRES_TYPE = TO_STRING_NULLABLE(objRow("FRES_TYPE"))
        mFRAC_PRIORITY = TO_INTEGER_NULLABLE(objRow("FRAC_PRIORITY"))
        mFRAC_BUNRUI = TO_STRING_NULLABLE(objRow("FRAC_BUNRUI"))


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
        strMsg &= "[√∞ÃﬁŸñº:íIï™óﬁóDêÊèáœΩ¿]"
        If IsNotNull(FRES_TYPE) Then
            strMsg &= "[à¯ìñ¿≤Ãﬂ:" & FRES_TYPE & "]"
        End If
        If IsNotNull(FRAC_PRIORITY) Then
            strMsg &= "[óDêÊèá:" & FRAC_PRIORITY & "]"
        End If
        If IsNotNull(FRAC_BUNRUI) Then
            strMsg &= "[íIï™óﬁ:" & FRAC_BUNRUI & "]"
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
