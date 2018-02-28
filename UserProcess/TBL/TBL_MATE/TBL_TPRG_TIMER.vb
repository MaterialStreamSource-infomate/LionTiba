'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' y–¼ÌzMaterialStreamÃ°ÌŞÙ¸×½
' y‹@”\z’èüŠúŠÇ—Ã°ÌŞÙ¸×½
' yì¬z2010/03/02  SIT                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' ’èüŠúŠÇ—Ã°ÌŞÙ¸×½
''' </summary>
Public Class TBL_TPRG_TIMER
    Inherits clsTemplateTable

    '**********************************************************************************************
    '«««©“®¶¬•”
#Region "  ¸×½•Ï”’è‹`                  "
    'ÌßÛÊßÃ¨
    Private mobjAryMe As TBL_TPRG_TIMER()                                        '’èüŠúŠÇ—
    Private mstrUSER_SQL As String                                               'Õ°»Ş°SQL
    Private mORDER_BY As String                                                  'OrderBy‹å
    Private mWHERE As String                                                     'Where‹å
    Private mFSYORI_ID As String                                                 'ˆ—ID
    Private mFYUKOU_FLAG As Nullable(Of Integer)                                 '—LŒøÌ×¸Ş
    Private mFKIDOU_FLAG As Nullable(Of Integer)                                 '‹N“®Ì×¸Ş
    Private mFEXEC_DT As Nullable(Of Date)                                       'ÀsŠÔ
    Private mFRANK As Nullable(Of Integer)                                       'ˆ——Dæ‡ˆÊ
    Private mFRANK_DTL As Nullable(Of Integer)                                   'ˆ——Dæ‡ˆÊÚ×
    Private mFSOCKET_MSG As String                                               'ˆ—
    Private mFLAST_DT As Nullable(Of Date)                                       'ÅIˆ—“ú
    Private mFTIME_OUT_SEC As Nullable(Of Integer)                               'À²Ï°üŠú
    Private mFCOMMENT As String                                                  'ºÒİÄ
    Private mFLOG_OPE_FLAG As Nullable(Of Integer)                               'µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş
    Private mFLOG_TRN_FLAG As Nullable(Of Integer)                               'Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş
    Private mFEVD_OPE_FLAG As Nullable(Of Integer)                               'ì‹Æ—š—ğ“o˜^Ì×¸Ş
#End Region
#Region "  ÌßÛÊßÃ¨’è‹`                  "
    ''' <summary>
    ''' ¼½ÃÑ•Ï” (©¸×½Œ^”z—ñ)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_TIMER()
        Get
            Return mobjAryMe
        End Get
    End Property
    ''' <summary>
    ''' Õ°»Ş°SQL (•¶šŒ^)
    ''' </summary>
    Public WriteOnly Property USER_SQL() As String
        Set(ByVal Value As String)
            mstrUSER_SQL = Value
        End Set
    End Property
    ''' <summary>
    ''' OrderBy‹å
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
    ''' Where‹å
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
    ''' ˆ—ID
    ''' </summary>
    Public Property FSYORI_ID() As String
        Get
            Return mFSYORI_ID
        End Get
        Set(ByVal Value As String)
            mFSYORI_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' —LŒøÌ×¸Ş
    ''' </summary>
    Public Property FYUKOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFYUKOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFYUKOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ‹N“®Ì×¸Ş
    ''' </summary>
    Public Property FKIDOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFKIDOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFKIDOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ÀsŠÔ
    ''' </summary>
    Public Property FEXEC_DT() As Nullable(Of Date)
        Get
            Return mFEXEC_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFEXEC_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ˆ——Dæ‡ˆÊ
    ''' </summary>
    Public Property FRANK() As Nullable(Of Integer)
        Get
            Return mFRANK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK = Value
        End Set
    End Property
    ''' <summary>
    ''' ˆ——Dæ‡ˆÊÚ×
    ''' </summary>
    Public Property FRANK_DTL() As Nullable(Of Integer)
        Get
            Return mFRANK_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' ˆ—
    ''' </summary>
    Public Property FSOCKET_MSG() As String
        Get
            Return mFSOCKET_MSG
        End Get
        Set(ByVal Value As String)
            mFSOCKET_MSG = Value
        End Set
    End Property
    ''' <summary>
    ''' ÅIˆ—“ú
    ''' </summary>
    Public Property FLAST_DT() As Nullable(Of Date)
        Get
            Return mFLAST_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLAST_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' À²Ï°üŠú
    ''' </summary>
    Public Property FTIME_OUT_SEC() As Nullable(Of Integer)
        Get
            Return mFTIME_OUT_SEC
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTIME_OUT_SEC = Value
        End Set
    End Property
    ''' <summary>
    ''' ºÒİÄ
    ''' </summary>
    Public Property FCOMMENT() As String
        Get
            Return mFCOMMENT
        End Get
        Set(ByVal Value As String)
            mFCOMMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş
    ''' </summary>
    Public Property FLOG_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_OPE_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş
    ''' </summary>
    Public Property FLOG_TRN_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_TRN_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_TRN_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ì‹Æ—š—ğ“o˜^Ì×¸Ş
    ''' </summary>
    Public Property FEVD_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFEVD_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEVD_OPE_FLAG = Value
        End Set
    End Property
#End Region
#Region "  ºİ½Ä×¸À                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ºİ½Ä×¸À
    ''' </summary>
    ''' <param name="objOwner">µ°Å°µÌŞ¼Şª¸Ä</param>
    ''' <param name="objDb">DB±¸¾½µÌŞ¼Şª¸Ä</param>
    ''' <param name="objDbLog">DB±¸¾½µÌŞ¼Şª¸Ä(Û¸Ş‘‚«‚İ—p)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)   'e¸×½‚Ìºİ½Ä×¸À‚ğÀ‘•
    End Sub
#End Region
#Region "  ÃŞ°Àæ“¾                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àæ“¾
    ''' </summary>
    ''' <param name="blnNotFoundError">Úº°ÄŞ‚ªˆêŒ‚àæ“¾o—ˆ‚È‚©‚Á‚½ê‡AThrow‚·‚é‚©”Û‚©‚ÌÌ×¸Ş</param>
    ''' <returns>‹¤’Ê–ß‚è’l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TIMER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As New StringBuilder 'SQL•¶
        Dim objDataSet As New DataSet   'ÃŞ°À¾¯Ä
        Dim strDataSetName As String    'ÃŞ°À¾¯Ä–¼
        Dim objRow As DataRow           '1Úº°ÄŞ•ª‚ÌÃŞ°À
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '’ŠoSQLì¬
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --ˆ—")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ºÒİÄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
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
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '’Šo
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        ElseIf objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then

            If blnNotFoundError = True Then
                '(´×°‚Æ‚·‚éê‡)
                Dim strMsg As String = ""
                Call MAKE_ERRMSG01(strMsg)
                Throw New UserException(strMsg)
            Else
                '(´×°‚µ‚È‚¢ê‡)
                Return (RetCode.NotFound)
            End If

        Else
            Throw New UserException("•¡”Úº°ÄŞ’Šo‚µ‚½ˆ×A´×°‚Æ‚µ‚Ü‚·B")
        End If


    End Function
#End Region
#Region "  ÃŞ°Àæ“¾(•¡”Úº°ÄŞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àæ“¾(•¡”Úº°ÄŞ)
    ''' </summary>
    ''' <returns>‹¤’Ê–ß‚è’l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TIMER_ANY() As RetCode
        Dim strSQL As New StringBuilder 'SQL•¶
        Dim objDataSet As New DataSet   'ÃŞ°À¾¯Ä
        Dim strDataSetName As String    'ÃŞ°À¾¯Ä–¼
        Dim objRow As DataRow           '1Úº°ÄŞ•ª‚ÌÃŞ°À
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '’ŠoSQLì¬
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --ˆ—")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ºÒİÄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
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
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '’Šo
        '***********************
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ÃŞ°Àæ“¾(¶½ÀÑ’Šo)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àæ“¾(¶½ÀÑ’Šo)
    ''' </summary>
    ''' <param name="objUSER_PARAM">Õ°»Ş°PARAM (ÊŞ²İÄŞ•Ï”—pµÌŞ¼Şª¸ÄŒ^”z—ñ)</param>
    ''' <returns>‹¤’Ê–ß‚è’l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TIMER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
        Dim strMsg As String            'Ò¯¾°¼Ş
        Dim objDataSet As New DataSet   'ÃŞ°À¾¯Ä
        Dim strDataSetName As String    'ÃŞ°À¾¯Ä–¼
        Dim objRow As DataRow           '1Úº°ÄŞ•ª‚ÌÃŞ°À
        Dim ii As Integer               '¶³İÀ


        '***********************
        'ÌßÛÊßÃ¨Áª¯¸
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mstrUSER_SQL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[Õ°»Ş°SQL]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '’Šo
        '***********************
        mobjAryMe = Nothing
        If IsNothing(objUSER_PARAM) = False Then
            ObjDb.Parameter = objUSER_PARAM
        End If
        ObjDb.SQL = mstrUSER_SQL
        objDataSet.Clear()
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ÃŞ°Àæ“¾(¶³İÄ)               "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àæ“¾(¶³İÄ)
    ''' </summary>
    ''' <returns>‹¤’Ê–ß‚è’l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TIMER_COUNT() As Integer
        Dim strSQL As New StringBuilder 'SQL•¶
        Dim objDataSet As New DataSet   'ÃŞ°À¾¯Ä
        Dim strDataSetName As String    'ÃŞ°À¾¯Ä–¼
        Dim objRow As DataRow           '1Úº°ÄŞ•ª‚ÌÃŞ°À
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '’ŠoSQLì¬
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --ˆ—")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ºÒİÄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '’Šo
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        Return (objRow(0))


    End Function
#End Region
#Region "  ÃŞ°ÀXV                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°ÀXV
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_TPRG_TIMER()
        Dim strSQL As New StringBuilder     'SQL•¶
        Dim strMsg As String                'Ò¯¾°¼Ş
        Dim intRetSQL As Integer            'SQLÀs–ß‚è’l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ÌßÛÊßÃ¨Áª¯¸
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ˆ—ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'XVSQLì¬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = NULL --ˆ—ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = NULL --ˆ—ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = :" & Ubound(strBindField) - 1 & " --ˆ—ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = :" & Ubound(strBindField) - 1 & " --ˆ—ID")
        End If
        intCount = intCount + 1
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = NULL --—LŒøÌ×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = NULL --—LŒøÌ×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = NULL --‹N“®Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = NULL --‹N“®Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = NULL --ÀsŠÔ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = NULL --ÀsŠÔ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = :" & Ubound(strBindField) - 1 & " --ÀsŠÔ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = :" & Ubound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = NULL --ˆ——Dæ‡ˆÊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = NULL --ˆ——Dæ‡ˆÊ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = NULL --ˆ——Dæ‡ˆÊÚ×")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = NULL --ˆ——Dæ‡ˆÊÚ×")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = NULL --ˆ—")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = NULL --ˆ—")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --ˆ—")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --ˆ—")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = NULL --ÅIˆ—“ú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = NULL --ÅIˆ—“ú")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = :" & Ubound(strBindField) - 1 & " --ÅIˆ—“ú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = :" & Ubound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = NULL --À²Ï°üŠú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = NULL --À²Ï°üŠú")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --À²Ï°üŠú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = NULL --ºÒİÄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = NULL --ºÒİÄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = :" & Ubound(strBindField) - 1 & " --ºÒİÄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = :" & Ubound(strBindField) - 1 & " --ºÒİÄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = NULL --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = NULL --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = NULL --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = NULL --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = NULL --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = NULL --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --ˆ—ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If


        '***********************
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'XV
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL´×°)
            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If
        If intRetSQL < 1 Then
            '(‘ÎÛs–³‚µ)
            strMsg = ERRMSG_ERR_UPDATE & "[‘ÎÛs–³‚µ]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ÃŞ°À’Ç‰Á                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°À’Ç‰Á
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ADD_TPRG_TIMER()
        Dim strSQL As New StringBuilder     'SQL•¶
        Dim strMsg As String                'Ò¯¾°¼Ş
        Dim intRetSQL As Integer            'SQLÀs–ß‚è’l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ÌßÛÊßÃ¨Áª¯¸
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ˆ—ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '’Ç‰ÁSQLì¬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ˆ—ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ˆ—ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ˆ—ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ˆ—ID")
        End If
        intCount = intCount + 1
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --—LŒøÌ×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --—LŒøÌ×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --‹N“®Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --‹N“®Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ÀsŠÔ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ÀsŠÔ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ÀsŠÔ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ˆ——Dæ‡ˆÊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ˆ——Dæ‡ˆÊ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ˆ——Dæ‡ˆÊÚ×")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ˆ——Dæ‡ˆÊÚ×")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ˆ—")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ˆ—")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ˆ—")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ˆ—")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ÅIˆ—“ú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ÅIˆ—“ú")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ÅIˆ—“ú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --À²Ï°üŠú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --À²Ï°üŠú")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --À²Ï°üŠú")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ºÒİÄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ºÒİÄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ºÒİÄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ºÒİÄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " )")


        '***********************
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '’Ç‰Á
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL´×°)
            strMsg = ERRMSG_ERR_ADD & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ÃŞ°Àíœ                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àíœ
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TPRG_TIMER()
        Dim strSQL As New StringBuilder     'SQL•¶
        Dim strMsg As String                'Ò¯¾°¼Ş
        Dim intRetSQL As Integer            'SQLÀs–ß‚è’l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ÌßÛÊßÃ¨Áª¯¸
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ˆ—ID]"
            Throw New UserException(strMsg)
        End If


        '***********************
        'íœSQLì¬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --ˆ—ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If


        '***********************
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'íœ
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL´×°)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ÃŞ°Àíœ(•¡”Úº°ÄŞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°Àíœ
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TPRG_TIMER_ANY()
        Dim strSQL As New StringBuilder     'SQL•¶
        Dim strMsg As String                'Ò¯¾°¼Ş
        Dim intRetSQL As Integer            'SQLÀs–ß‚è’l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'íœSQLì¬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --ˆ—ID")
        End If
        If IsNotNull(FYUKOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --—LŒøÌ×¸Ş")
        End If
        If IsNotNull(FKIDOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --‹N“®Ì×¸Ş")
        End If
        If IsNotNull(FEXEC_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --ÀsŠÔ")
        End If
        If IsNotNull(FRANK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊ")
        End If
        If IsNotNull(FRANK_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --ˆ——Dæ‡ˆÊÚ×")
        End If
        If IsNotNull(FSOCKET_MSG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --ˆ—")
        End If
        If IsNotNull(FLAST_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --ÅIˆ—“ú")
        End If
        If IsNotNull(FTIME_OUT_SEC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --À²Ï°üŠú")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ºÒİÄ")
        End If
        If IsNotNull(FLOG_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNotNull(FLOG_TRN_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş")
        End If
        If IsNotNull(FEVD_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ì‹Æ—š—ğ“o˜^Ì×¸Ş")
        End If


        '***********************
        'ÊŞ²İÄŞ•Ï”’è‹`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        'íœ
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL´×°)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ÌßÛÊßÃ¨ºËß°                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        'ÌßÛÊßÃ¨•Ï”‚Ö¾¯Ä
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("FSYORI_ID")) = False Then mFSYORI_ID = objObject.FSYORI_ID 'ˆ—ID
        If IsNothing(objType.GetProperty("FYUKOU_FLAG")) = False Then mFYUKOU_FLAG = objObject.FYUKOU_FLAG '—LŒøÌ×¸Ş
        If IsNothing(objType.GetProperty("FKIDOU_FLAG")) = False Then mFKIDOU_FLAG = objObject.FKIDOU_FLAG '‹N“®Ì×¸Ş
        If IsNothing(objType.GetProperty("FEXEC_DT")) = False Then mFEXEC_DT = objObject.FEXEC_DT 'ÀsŠÔ
        If IsNothing(objType.GetProperty("FRANK")) = False Then mFRANK = objObject.FRANK 'ˆ——Dæ‡ˆÊ
        If IsNothing(objType.GetProperty("FRANK_DTL")) = False Then mFRANK_DTL = objObject.FRANK_DTL 'ˆ——Dæ‡ˆÊÚ×
        If IsNothing(objType.GetProperty("FSOCKET_MSG")) = False Then mFSOCKET_MSG = objObject.FSOCKET_MSG 'ˆ—
        If IsNothing(objType.GetProperty("FLAST_DT")) = False Then mFLAST_DT = objObject.FLAST_DT 'ÅIˆ—“ú
        If IsNothing(objType.GetProperty("FTIME_OUT_SEC")) = False Then mFTIME_OUT_SEC = objObject.FTIME_OUT_SEC 'À²Ï°üŠú
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT 'ºÒİÄ
        If IsNothing(objType.GetProperty("FLOG_OPE_FLAG")) = False Then mFLOG_OPE_FLAG = objObject.FLOG_OPE_FLAG 'µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş
        If IsNothing(objType.GetProperty("FLOG_TRN_FLAG")) = False Then mFLOG_TRN_FLAG = objObject.FLOG_TRN_FLAG 'Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş
        If IsNothing(objType.GetProperty("FEVD_OPE_FLAG")) = False Then mFEVD_OPE_FLAG = objObject.FEVD_OPE_FLAG 'ì‹Æ—š—ğ“o˜^Ì×¸Ş

    End Sub
#End Region
#Region "  ÌßÛÊßÃ¨¸Ø±                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÌßÛÊßÃ¨¸Ø±
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub CLEAR_PROPERTY()


        '***********************
        'ÌßÛÊßÃ¨•Ï”¸Ø±
        '***********************
        Call ARYME_CLEAR()
        mstrUSER_SQL = Nothing
        mFSYORI_ID = Nothing
        mFYUKOU_FLAG = Nothing
        mFKIDOU_FLAG = Nothing
        mFEXEC_DT = Nothing
        mFRANK = Nothing
        mFRANK_DTL = Nothing
        mFSOCKET_MSG = Nothing
        mFLAST_DT = Nothing
        mFTIME_OUT_SEC = Nothing
        mFCOMMENT = Nothing
        mFLOG_OPE_FLAG = Nothing
        mFLOG_TRN_FLAG = Nothing
        mFEVD_OPE_FLAG = Nothing


    End Sub
#End Region
#Region "  AryMe¸Ø±                     "
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

#Region "  ÃŞ°À¨•Ï”                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ÃŞ°À¨•Ï”
    ''' </summary>
    ''' <param name="objRow">ÃŞ°ÀÚº°ÄŞµÌŞ¼Şª¸Ä</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA(ByVal objRow As DataRow)


        '***********************
        'ÃŞ°À¾¯Ä
        '***********************
        mFSYORI_ID = TO_STRING_NULLABLE(objRow("FSYORI_ID"))
        mFYUKOU_FLAG = TO_INTEGER_NULLABLE(objRow("FYUKOU_FLAG"))
        mFKIDOU_FLAG = TO_INTEGER_NULLABLE(objRow("FKIDOU_FLAG"))
        mFEXEC_DT = TO_DATE_NULLABLE(objRow("FEXEC_DT"))
        mFRANK = TO_INTEGER_NULLABLE(objRow("FRANK"))
        mFRANK_DTL = TO_INTEGER_NULLABLE(objRow("FRANK_DTL"))
        mFSOCKET_MSG = TO_STRING_NULLABLE(objRow("FSOCKET_MSG"))
        mFLAST_DT = TO_DATE_NULLABLE(objRow("FLAST_DT"))
        mFTIME_OUT_SEC = TO_INTEGER_NULLABLE(objRow("FTIME_OUT_SEC"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))
        mFLOG_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_OPE_FLAG"))
        mFLOG_TRN_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_TRN_FLAG"))
        mFEVD_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FEVD_OPE_FLAG"))


    End Sub
#End Region
#Region "  ´×°Ò¯¾°¼Ş•¶š—ñì¬01        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ´×°Ò¯¾°¼Ş•¶š—ñì¬01
    ''' </summary>
    ''' <param name="strMsg">´×°Ò¯¾°¼Ş•¶š—ñ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub MAKE_ERRMSG01(ByRef strMsg As String)


        '***********************
        'ÃŞ°À¾¯Ä
        '***********************
        strMsg = "Úº°ÄŞ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½B"
        strMsg &= "[Ã°ÌŞÙ–¼:’èüŠúŠÇ—]"
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[ˆ—ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FYUKOU_FLAG) Then
            strMsg &= "[—LŒøÌ×¸Ş:" & FYUKOU_FLAG & "]"
        End If
        If IsNotNull(FKIDOU_FLAG) Then
            strMsg &= "[‹N“®Ì×¸Ş:" & FKIDOU_FLAG & "]"
        End If
        If IsNotNull(FEXEC_DT) Then
            strMsg &= "[ÀsŠÔ:" & FEXEC_DT & "]"
        End If
        If IsNotNull(FRANK) Then
            strMsg &= "[ˆ——Dæ‡ˆÊ:" & FRANK & "]"
        End If
        If IsNotNull(FRANK_DTL) Then
            strMsg &= "[ˆ——Dæ‡ˆÊÚ×:" & FRANK_DTL & "]"
        End If
        If IsNotNull(FSOCKET_MSG) Then
            strMsg &= "[ˆ—:" & FSOCKET_MSG & "]"
        End If
        If IsNotNull(FLAST_DT) Then
            strMsg &= "[ÅIˆ—“ú:" & FLAST_DT & "]"
        End If
        If IsNotNull(FTIME_OUT_SEC) Then
            strMsg &= "[À²Ï°üŠú:" & FTIME_OUT_SEC & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[ºÒİÄ:" & FCOMMENT & "]"
        End If
        If IsNotNull(FLOG_OPE_FLAG) Then
            strMsg &= "[µÍßÚ°¼®İÛ¸Ş“o˜^Ì×¸Ş:" & FLOG_OPE_FLAG & "]"
        End If
        If IsNotNull(FLOG_TRN_FLAG) Then
            strMsg &= "[Ä×İ»Ş¸¼®İÛ¸Ş“o˜^Ì×¸Ş:" & FLOG_TRN_FLAG & "]"
        End If
        If IsNotNull(FEVD_OPE_FLAG) Then
            strMsg &= "[ì‹Æ—š—ğ“o˜^Ì×¸Ş:" & FEVD_OPE_FLAG & "]"
        End If


    End Sub
#End Region
    'ªªª©“®¶¬•”
    '**********************************************************************************************

    '**********************************************************************************************
    '«««¼½ÃÑ‹¤’Ê
#Region "  —LŒøÌ×¸ŞON               (Public  YUKOU_ON)"
    Public Sub YUKOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '–ß‚è’l


            '***********************
            '’èüŠúŠÇ—î•ñæ“¾
            '***********************
            '««««««************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 Ò¿¯ÄŞ‚ğ˜A‘±Callo—ˆ‚È‚¢ˆ×AC³
            Call CLEAR_PROPERTY()
            'ªªªªªª************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '’èüŠúŠÇ—î•ñXV
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  —LŒøÌ×¸ŞOFF              (Public  YUUOU_OFF)"
    Public Sub YUKOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '–ß‚è’l

            '***********************
            '’èüŠúŠÇ—î•ñæ“¾
            '***********************
            '««««««************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 Ò¿¯ÄŞ‚ğ˜A‘±Callo—ˆ‚È‚¢ˆ×AC³
            Call CLEAR_PROPERTY()
            'ªªªªªª************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '’èüŠúŠÇ—î•ñXV
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ‹N“®Ì×¸ŞON               (Public  KIDOU_ON)"
    Public Sub KIDOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '–ß‚è’l

            '***********************
            '’èüŠúŠÇ—î•ñæ“¾
            '***********************
            '««««««************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 Ò¿¯ÄŞ‚ğ˜A‘±Callo—ˆ‚È‚¢ˆ×AC³
            Call CLEAR_PROPERTY()
            'ªªªªªª************************************************************************************************************
            mFSYORI_ID = FORMAT_DSP_DELCMD & strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '’èüŠúŠÇ—î•ñXV
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ‹N“®Ì×¸ŞOFF              (Public  KIDOU_OFF)"
    Public Sub KIDOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '–ß‚è’l

            '***********************
            '’èüŠúŠÇ—î•ñæ“¾
            '***********************
            '««««««************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 Ò¿¯ÄŞ‚ğ˜A‘±Callo—ˆ‚È‚¢ˆ×AC³
            Call CLEAR_PROPERTY()
            'ªªªªªª************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '’èüŠúŠÇ—î•ñXV
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    'ªªª¼½ÃÑ‹¤’Ê
    '**********************************************************************************************


    '**********************************************************************************************
    '«««¼½ÃÑŒÅ—L

    'ªªª¼½ÃÑŒÅ—L
    '**********************************************************************************************

End Class
