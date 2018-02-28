'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾊﾞｰｽ引当処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310301
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用定数定義                                                                "
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｺﾈｸﾄｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾒｲﾝ処理                                                                              "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾒｲﾝ処理
    ''' </summary>
    ''' <param name="strMSG_RECV">受信電文</param>
    ''' <param name="strMSG_SEND">送信電文</param>
    ''' <returns>OK/NG</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Dim intRet As RetCode                   '戻り値
        Dim strSQL As String                    'SQL文
        Try
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
            Dim dtmNow01 As Date = Now
            'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
            '↑↑↑↑↑↑************************************************************************************************************

            '-------------------
            'ﾊﾞｰｽ引当待ちﾌﾗｸﾞ初期化
            '-------------------
            Dim blnWaitL As Boolean = False                    'ﾊﾞｰｽ引当待ち(ﾛｰﾀﾞ)
            Dim blnWaitP_W As Boolean = False                  'ﾊﾞｰｽ引当待ち(ﾊﾟﾚｯﾄ:両横積)
            Dim blnWaitP_S As Boolean = False                  'ﾊﾞｰｽ引当待ち(ﾊﾟﾚｯﾄ:片横積)
            Dim blnWaitP_B As Boolean = False                  'ﾊﾞｰｽ引当待ち(ﾊﾟﾚｯﾄ:後積)
            Dim blnWaitB As Boolean = False                    'ﾊﾞｰｽ引当待ち(ﾊﾞﾗ)
            Dim intOyaCnt As Integer = 0
            Dim dtmSYUKKA(intOyaCnt) As Nullable(Of Date)
            Dim strHENSEI(intOyaCnt) As String

            dtmSYUKKA(intOyaCnt) = DEFAULT_DATE
            strHENSEI(intOyaCnt) = DEFAULT_STRING

            '-------------------
            '出荷指示読込
            '-------------------
            Dim objPLN_OUT_ARY As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
            strSQL = ""
            strSQL &= vbCrLf & "SELECT *"
            strSQL &= vbCrLf & " FROM  XPLN_OUT"
            strSQL &= vbCrLf & " WHERE XSYUKKA_STS = " & XSYUKKA_STS_JDIR                   '出荷状況 = 「指示済」
            strSQL &= vbCrLf & "   AND XHENSEI_NO = XHENSEI_NO_OYA"                         '編成№ = 親編成№
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "       XKINKYU_LEVEL DESC"                                  '緊急度
            strSQL &= vbCrLf & "      ,XSYUKKA_DIR_DT"                                      '出荷指示日時
            strSQL &= vbCrLf
            objPLN_OUT_ARY.USER_SQL = strSQL
            intRet = objPLN_OUT_ARY.GET_XPLN_OUT_USER()
            If intRet = RetCode.OK Then
                For Each objPLN_OUT As TBL_XPLN_OUT In objPLN_OUT_ARY.ARYME
                    Dim intHikiate As RetCode = RetCode.NG
                    Dim intRetBth As RetCode
                    Dim strBerthNo As String = ""

                    '処理済ﾃﾞｰﾀ判定
                    Dim blnSkip As Boolean = False
                    For ii As Integer = LBound(dtmSYUKKA) To UBound(dtmSYUKKA)
                        If dtmSYUKKA(ii) = objPLN_OUT.XSYUKKA_D And _
                           strHENSEI(ii) = objPLN_OUT.XHENSEI_NO_OYA Then
                            blnSkip = True
                            Exit For
                        End If
                    Next
                    If blnSkip = True Then
                        Continue For
                    Else
                        intOyaCnt += 1
                        ReDim Preserve dtmSYUKKA(intOyaCnt)
                        ReDim Preserve strHENSEI(intOyaCnt)
                        dtmSYUKKA(intOyaCnt) = objPLN_OUT.XSYUKKA_D
                        strHENSEI(intOyaCnt) = objPLN_OUT.XHENSEI_NO_OYA
                    End If

                    '処理ｽｷｯﾌﾟ判定
                    If TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then            'ﾛｰﾀﾞ積
                        If blnWaitL = True Then                                             '他の優先が高いﾛｰﾀﾞ積が待ちの為、他のﾛｰﾀﾞ積も待たせる
                            Continue For                                                    '処理ｽｷｯﾌﾟ
                        End If
                    ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JP Then        'ﾊﾟﾚｯﾄ積
                        If TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JWING Then     '両横積
                            If blnWaitP_W = True Then                                       '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                                Continue For                                                '処理ｽｷｯﾌﾟ
                            End If
                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JSIDE Then '片横積
                            If blnWaitP_S = True Then                                       '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                                Continue For                                                '処理ｽｷｯﾌﾟ
                            End If
                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JBACK Then '後積
                            If blnWaitP_B = True Then                                       '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                                Continue For                                                '処理ｽｷｯﾌﾟ
                            End If
                        Else
                            Dim strMsg As String
                            strMsg = "出荷指示の積込方向が異常です[出荷日:" & TO_DATE(objPLN_OUT.XSYUKKA_D) & "][親編成No:" & objPLN_OUT.XHENSEI_NO_OYA & "][積込方向:" & objPLN_OUT.XTUMI_HOUKOU & "]"
                            Throw New System.Exception(strMsg)
                        End If
                    ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then        'ﾊﾞﾗ積
                        If blnWaitB = True Then                                             '他の優先が高いﾊﾞﾗ積が待ちの為、他のﾊﾞﾗ積も待たせる
                            Continue For                                                    '処理ｽｷｯﾌﾟ
                        End If
                    Else
                        Dim strMsg As String
                        strMsg = "出荷指示の積込方法が異常です[出荷日:" & TO_DATE(objPLN_OUT.XSYUKKA_D) & "][親編成No:" & objPLN_OUT.XHENSEI_NO_OYA & "][積込方法:" & objPLN_OUT.XTUMI_HOUHOU & "]"
                        Throw New System.Exception(strMsg)
                    End If

                    '-------------------
                    '出荷ﾊﾞｰｽ状況読込
                    '-------------------
                    Dim objXSTS_BERTH_ALL As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)     '出荷ﾊﾞｰｽ状況ｸﾗｽ
                    strSQL = ""
                    strSQL &= vbCrLf & "SELECT"
                    strSQL &= vbCrLf & "    *"
                    strSQL &= vbCrLf & " FROM"
                    strSQL &= vbCrLf & "    XSTS_BERTH"                                     '出荷ﾊﾞｰｽ状況
                    strSQL &= vbCrLf & " ORDER BY"
                    strSQL &= vbCrLf & "    XBERTH_NO"                                      'ﾊﾞｰｽ№
                    strSQL &= vbCrLf
                    objXSTS_BERTH_ALL.USER_SQL = strSQL
                    objXSTS_BERTH_ALL.GET_XSTS_BERTH_USER()

                    '-------------------
                    '設備状況読込
                    '-------------------
                    Dim objTSTS_EQ_ALL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)      '設備状況ｸﾗｽ
                    strSQL = ""
                    strSQL &= vbCrLf & "SELECT"
                    strSQL &= vbCrLf & "    *"
                    strSQL &= vbCrLf & " FROM"
                    strSQL &= vbCrLf & "    TSTS_EQ_CTRL"                                   '設備状況
                    strSQL &= vbCrLf & "   ,XSTS_BERTH"                                     '出荷ﾊﾞｰｽ状況
                    strSQL &= vbCrLf & " WHERE "
                    strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_ID = XSTS_BERTH.XBERTH_NO"     '設備状況.設備ID = 出荷ﾊﾞｰｽ状況.ﾊﾞｰｽ№
                    strSQL &= vbCrLf & " ORDER BY"
                    strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO"                           'ﾊﾞｰｽ№
                    strSQL &= vbCrLf
                    objTSTS_EQ_ALL.USER_SQL = strSQL
                    objTSTS_EQ_ALL.GET_TSTS_EQ_CTRL_USER()

                    'ﾊﾞｰｽ指定判定 
                    If IsNull(objPLN_OUT.XBERTH_NO) = False Then                                        'ﾊﾞｰｽ指定有りの場合
                        '-------------------
                        'ﾊﾞｰｽ使用可能判定
                        '------------------- 
                        intRetBth = Check_Barth(objPLN_OUT.XBERTH_NO, _
                                                objPLN_OUT, _
                                                objXSTS_BERTH_ALL, _
                                                objTSTS_EQ_ALL)                                             'ﾊﾞｰｽ使用可能判定
                        If intRetBth = RetCode.OK Then
                            intHikiate = RetCode.OK
                            strBerthNo = objPLN_OUT.XBERTH_NO
                        End If
                    Else                                                                                'ﾊﾞｰｽ指定無しの場合
                        '積込方法判定
                        If TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then                        'ﾛｰﾀﾞ積
                            ' '' ''↓↓↓↓↓↓************************************************************************************************************
                            ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            ' '' ''-------------------
                            ' '' ''ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)読込
                            ' '' ''-------------------
                            '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
                            '' ''Dim strXBERTH_NO_L() As String
                            '' ''strXBERTH_NO_L = Split(objTPRG_SYS_HEN.SJ000000_003, KUGIRI01)                      '取得
                            ' '' ''objTPRG_SYS_HEN.SJ000000_003 = strXBERTH_NO_L(1) & "," & _
                            ' '' ''                               strXBERTH_NO_L(2) & "," & _
                            ' '' ''                               strXBERTH_NO_L(3) & "," & _
                            ' '' ''                               strXBERTH_NO_L(4) & "," & _
                            ' '' ''                               strXBERTH_NO_L(5) & "," & _
                            ' '' ''                               strXBERTH_NO_L(0)

                            ' '' ''ﾊﾞｰｽ使用可能判定
                            '' ''For intCnt As Integer = 0 To UBound(strXBERTH_NO_L)
                            '' ''    intRetBth = Check_Barth(strXBERTH_NO_L(intCnt), _
                            '' ''                            objPLN_OUT, _
                            '' ''                            objXSTS_BERTH_ALL, _
                            '' ''                            objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                            '' ''    If intRetBth = RetCode.OK Then
                            '' ''        intHikiate = RetCode.OK
                            '' ''        strBerthNo = strXBERTH_NO_L(intCnt)
                            '' ''        Exit For
                            '' ''    End If
                            '' ''Next
                            ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            ' '' ''↑↑↑↑↑↑************************************************************************************************************

                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            '-------------------
                            'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)読込
                            '-------------------
                            Dim objTPRG_SYS_HEN_WK As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)              'ｼｽﾃﾑ変数ｸﾗｽ
                            Dim strGoukiL() As String
                            strGoukiL = Split(objTPRG_SYS_HEN_WK.SJ000000_005, KUGIRI01)                        '取得

                            'ﾊﾞｰｽ使用可能判定
                            For intCnt As Integer = 0 To UBound(strGoukiL)
                                Dim strXBERTH_L() As String
                                If TO_INTEGER(strGoukiL(intCnt)) = 1 Then
                                    strXBERTH_L = Split(objTPRG_SYS_HEN_WK.SJ000000_006, KUGIRI01)              '取得
                                ElseIf TO_INTEGER(strGoukiL(intCnt)) = 2 Then
                                    strXBERTH_L = Split(objTPRG_SYS_HEN_WK.SJ000000_007, KUGIRI01)              '取得
                                Else
                                    Exit For
                                End If
                                For intCnt2 As Integer = 0 To UBound(strXBERTH_L)
                                    intRetBth = Check_Barth(strXBERTH_L(intCnt2), _
                                                            objPLN_OUT, _
                                                            objXSTS_BERTH_ALL, _
                                                            objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                                    If intRetBth = RetCode.OK Then
                                        intHikiate = RetCode.OK
                                        strBerthNo = strXBERTH_L(intCnt2)
                                        Exit For
                                    End If
                                Next
                                If strBerthNo <> "" Then
                                    Exit For
                                End If
                            Next
                            'JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            '↑↑↑↑↑↑************************************************************************************************************

                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JP Then                    'ﾊﾟﾚｯﾄ積
                            '-------------------
                            'ﾊﾞｰｽ引当順(ﾊﾟﾚｯﾄ)読込
                            '-------------------
                            Dim objXSTS_BERTH_P As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)                   '出荷ﾊﾞｰｽ状況ｸﾗｽ
                            strSQL = ""
                            strSQL &= vbCrLf & "SELECT"
                            strSQL &= vbCrLf & "    *"
                            strSQL &= vbCrLf & " FROM"
                            strSQL &= vbCrLf & "    XSTS_BERTH"                                                 '出荷ﾊﾞｰｽ状況
                            strSQL &= vbCrLf & " WHERE"
                            strSQL &= vbCrLf & "    XBERTH_GROUP IN"                                            'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                            strSQL &= vbCrLf & "    ("
                            strSQL &= vbCrLf & "        SELECT"
                            strSQL &= vbCrLf & "            XBERTH_GROUP"                                       'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                            strSQL &= vbCrLf & "        FROM"
                            strSQL &= vbCrLf & "            XSTS_CONVEYOR"                                      '出荷ｺﾝﾍﾞﾔ状況
                            strSQL &= vbCrLf & "        WHERE"
                            strSQL &= vbCrLf & "            XCONVEYOR_YOUTO = " & XCONVEYOR_YOUTO_JPALLET       'ｺﾝﾍﾞﾔ用途(ﾊﾟﾚｯﾄ)
                            strSQL &= vbCrLf & "    )"
                            strSQL &= vbCrLf & " ORDER BY"
                            strSQL &= vbCrLf & "    XBERTH_NO"                                                  'ﾊﾞｰｽ№
                            strSQL &= vbCrLf
                            objXSTS_BERTH_P.USER_SQL = strSQL
                            objXSTS_BERTH_P.GET_XSTS_BERTH_USER()

                            'ﾊﾞｰｽ使用可能判定
                            For Each objXSTS_BERTH As TBL_XSTS_BERTH In objXSTS_BERTH_P.ARYME
                                intRetBth = Check_Barth(objXSTS_BERTH.XBERTH_NO, _
                                                        objPLN_OUT, _
                                                        objXSTS_BERTH_ALL, _
                                                        objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                                If intRetBth = RetCode.OK Then
                                    intHikiate = RetCode.OK
                                    strBerthNo = objXSTS_BERTH.XBERTH_NO
                                    Exit For
                                End If
                            Next

                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then                    'ﾊﾞﾗ積
                            Dim strBerthNoLast As String = ""
                            '-------------------
                            '最終使用ﾊﾞﾗﾊﾞｰｽ読込
                            '-------------------
                            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
                            strBerthNoLast = objTPRG_SYS_HEN.SJ000000_004

                            '-------------------
                            'ﾊﾞｰｽ引当順(ﾊﾞﾗ)読込
                            '-------------------
                            Dim objXSTS_BERTH_B As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)                   '出荷ﾊﾞｰｽ状況ｸﾗｽ
                            strSQL = ""
                            strSQL &= vbCrLf & "SELECT"
                            strSQL &= vbCrLf & "    *"
                            strSQL &= vbCrLf & " FROM"
                            strSQL &= vbCrLf & "    XSTS_BERTH"                                                 '出荷ﾊﾞｰｽ状況
                            strSQL &= vbCrLf & " WHERE"
                            strSQL &= vbCrLf & "    XBERTH_GROUP IN"                                            'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                            strSQL &= vbCrLf & "    ("
                            strSQL &= vbCrLf & "        SELECT"
                            strSQL &= vbCrLf & "            XBERTH_GROUP"                                       'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                            strSQL &= vbCrLf & "        FROM"
                            strSQL &= vbCrLf & "            XSTS_CONVEYOR"                                      '出荷ｺﾝﾍﾞﾔ状況
                            strSQL &= vbCrLf & "        WHERE"
                            strSQL &= vbCrLf & "            XCONVEYOR_YOUTO = " & XCONVEYOR_YOUTO_JBARA         'ｺﾝﾍﾞﾔ用途(ﾊﾞﾗ)
                            strSQL &= vbCrLf & "    )"
                            strSQL &= vbCrLf & " ORDER BY"
                            strSQL &= vbCrLf & "    XBERTH_NO"                                                  'ﾊﾞｰｽ№
                            strSQL &= vbCrLf
                            objXSTS_BERTH_B.USER_SQL = strSQL
                            objXSTS_BERTH_B.GET_XSTS_BERTH_USER()

                            'ﾊﾞｰｽ使用可能判定
                            '' ''For Each objXSTS_BERTH As TBL_XSTS_BERTH In objXSTS_BERTH_B.ARYME
                            '' ''    intRetBth = Check_Barth(objXSTS_BERTH.XBERTH_NO, _
                            '' ''                            objPLN_OUT, _
                            '' ''                            objXSTS_BERTH_ALL, _
                            '' ''                            objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                            '' ''    If intRetBth = RetCode.OK Then
                            '' ''        intHikiate = RetCode.OK
                            '' ''        strBerthNo = objXSTS_BERTH.XBERTH_NO
                            '' ''        Exit For
                            '' ''    End If
                            '' ''Next

                            'ﾊﾞｰｽ使用可能判定(ｻｲｸﾘｯｸ対応)
                            Dim blnFlag As Boolean = False
                            For Each objXSTS_BERTH As TBL_XSTS_BERTH In objXSTS_BERTH_B.ARYME
                                If objXSTS_BERTH.XBERTH_NO = strBerthNoLast Then
                                    blnFlag = True
                                    Continue For
                                End If
                                If blnFlag = True Then
                                    intRetBth = Check_Barth(objXSTS_BERTH.XBERTH_NO, _
                                                            objPLN_OUT, _
                                                            objXSTS_BERTH_ALL, _
                                                            objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                                    If intRetBth = RetCode.OK Then
                                        intHikiate = RetCode.OK
                                        strBerthNo = objXSTS_BERTH.XBERTH_NO
                                        Exit For
                                    End If
                                End If
                            Next
                            If strBerthNo = "" Then
                                For Each objXSTS_BERTH As TBL_XSTS_BERTH In objXSTS_BERTH_B.ARYME
                                    intRetBth = Check_Barth(objXSTS_BERTH.XBERTH_NO, _
                                                            objPLN_OUT, _
                                                            objXSTS_BERTH_ALL, _
                                                            objTSTS_EQ_ALL)                                         'ﾊﾞｰｽ使用可能判定
                                    If intRetBth = RetCode.OK Then
                                        intHikiate = RetCode.OK
                                        strBerthNo = objXSTS_BERTH.XBERTH_NO
                                        Exit For
                                    End If
                                Next
                            End If

                        Else
                            Dim strMsg As String
                            strMsg = "出荷指示の積込方法が異常です[出荷日:" & TO_DATE(objPLN_OUT.XSYUKKA_D) & "][親編成No:" & objPLN_OUT.XHENSEI_NO_OYA & "][積込方法:" & objPLN_OUT.XTUMI_HOUHOU & "]"
                            Throw New System.Exception(strMsg)
                        End If
                    End If



                    '-------------------
                    '引当可能ﾊﾞｰｽ状態更新
                    '------------------- 
                    If intHikiate = RetCode.OK And strBerthNo <> "" Then
                        Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
                        Dim objTSTS_EQ As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)

                        '-------------------
                        '出荷指示更新
                        '-------------------
                        Dim objPLN_OUT_ARY2 As New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                        objPLN_OUT_ARY2.XSYUKKA_D = objPLN_OUT.XSYUKKA_D
                        objPLN_OUT_ARY2.XHENSEI_NO_OYA = objPLN_OUT.XHENSEI_NO_OYA
                        objPLN_OUT_ARY2.GET_XPLN_OUT_ANY()
                        For Each objPLN_OUT_WK As TBL_XPLN_OUT In objPLN_OUT_ARY2.ARYME
                            objPLN_OUT_WK.XBERTH_NO = strBerthNo                    'ﾊﾞｰｽ№
                            objPLN_OUT_WK.XSYUKKA_STS = XSYUKKA_STS_JRDY            '出荷状況(引当可能)
                            objPLN_OUT_WK.UPDATE_XPLN_OUT()

                            '-------------------
                            '出荷指示更新
                            '-------------------
                            Dim objXPLN_OUT_DTL_ARY As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                            objXPLN_OUT_DTL_ARY.XSYUKKA_D = objPLN_OUT_WK.XSYUKKA_D
                            objXPLN_OUT_DTL_ARY.XHENSEI_NO = objPLN_OUT_WK.XHENSEI_NO
                            objXPLN_OUT_DTL_ARY.XDENPYOU_NO = objPLN_OUT_WK.XDENPYOU_NO
                            objXPLN_OUT_DTL_ARY.GET_XPLN_OUT_DTL_ANY()
                            For Each objXPLN_OUT_DTL_WK As TBL_XPLN_OUT_DTL In objXPLN_OUT_DTL_ARY.ARYME
                                If TO_NUMBER(objPLN_OUT_WK.XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then
                                    objXPLN_OUT_DTL_WK.FSAGYOU_KIND = FSAGYOU_KIND_J57            '作業種別(ﾛｰﾀﾞ出庫)
                                    objXPLN_OUT_DTL_WK.UPDATE_XPLN_OUT_DTL()
                                ElseIf TO_NUMBER(objPLN_OUT_WK.XTUMI_HOUHOU) = XTUMI_HOUHOU_JP Then
                                    objXPLN_OUT_DTL_WK.FSAGYOU_KIND = FSAGYOU_KIND_J55            '作業種別(ﾊﾟﾚｯﾄ出庫)
                                    objXPLN_OUT_DTL_WK.UPDATE_XPLN_OUT_DTL()
                                ElseIf TO_NUMBER(objPLN_OUT_WK.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then
                                    objXPLN_OUT_DTL_WK.FSAGYOU_KIND = FSAGYOU_KIND_J56            '作業種別(ﾊﾞﾗ出庫)
                                    objXPLN_OUT_DTL_WK.UPDATE_XPLN_OUT_DTL()
                                End If
                            Next
                        Next

                        '-------------------
                        'ﾊﾞｰｽ状態更新
                        '-------------------
                        'ﾊﾞｰｽ使用状況更新
                        intRet = Get_Barth_Data_EQ(strBerthNo, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                        objXSTS_BERTH.XSYUKKA_D = objPLN_OUT.XSYUKKA_D              '出荷日
                        objXSTS_BERTH.XHENSEI_NO = objPLN_OUT.XHENSEI_NO_OYA        '編成No.
                        objXSTS_BERTH.XSYUKKA_D_RIN1 = DEFAULT_DATE                 '隣接1出荷日
                        objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = ""                      '隣接1親編成No.
                        objXSTS_BERTH.XSYUKKA_D_RIN2 = DEFAULT_DATE                 '隣接2出荷日
                        objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = ""                      '隣接2親編成No.
                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JSESSYA               'ﾊﾞｰｽ使用状況
                        objXSTS_BERTH.FUPDATE_DT = Now                              '更新日時
                        objXSTS_BERTH.UPDATE_XSTS_BERTH()

                        If TO_INTEGER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JP Or _
                           TO_INTEGER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then
                            Select Case TO_INTEGER(objPLN_OUT.XTUMI_HOUKOU)
                                Case XTUMI_HOUKOU_JBACK         '後積み
                                    'NOP
                                Case XTUMI_HOUKOU_JSIDE         '片横積み
                                    '-------------------
                                    '横ﾊﾞｰｽ(上)状態更新
                                    '-------------------
                                    Dim strBth_Prev = ""
                                    intRet = Get_Barth_Prev(strBerthNo, strBth_Prev)
                                    intRet = Get_Barth_Data_EQ(strBth_Prev, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                                    objXSTS_BERTH.XSYUKKA_D = DEFAULT_DATE                              '出荷日
                                    objXSTS_BERTH.XHENSEI_NO = ""                                       '編成No.
                                    objXSTS_BERTH.XSYUKKA_D_RIN2 = objPLN_OUT.XSYUKKA_D                 '隣接2出荷日
                                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = objPLN_OUT.XHENSEI_NO_OYA       '隣接2親編成No.
                                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP Then
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN                   'ﾊﾞｰｽ使用状況
                                    Else
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JDOWN                     'ﾊﾞｰｽ使用状況
                                    End If
                                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                                Case XTUMI_HOUKOU_JWING         '両横積み
                                    '-------------------
                                    '両横ﾊﾞｰｽ(上)状態更新
                                    '-------------------
                                    Dim strBth_Prev = ""
                                    intRet = Get_Barth_Prev(strBerthNo, strBth_Prev)
                                    intRet = Get_Barth_Data_EQ(strBth_Prev, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                                    objXSTS_BERTH.XSYUKKA_D = DEFAULT_DATE                              '出荷日
                                    objXSTS_BERTH.XHENSEI_NO = ""                                       '編成No.
                                    objXSTS_BERTH.XSYUKKA_D_RIN2 = objPLN_OUT.XSYUKKA_D                 '隣接2出荷日
                                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN2 = objPLN_OUT.XHENSEI_NO_OYA       '隣接2親編成No.
                                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP Then
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN                   'ﾊﾞｰｽ使用状況
                                    Else
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JDOWN                     'ﾊﾞｰｽ使用状況
                                    End If
                                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                                    objXSTS_BERTH.UPDATE_XSTS_BERTH()

                                    '-------------------
                                    '両横ﾊﾞｰｽ(下)状態更新
                                    '-------------------
                                    Dim strBth_Next = ""
                                    intRet = Get_Barth_Next(strBerthNo, strBth_Next)
                                    intRet = Get_Barth_Data_EQ(strBth_Next, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                                    objXSTS_BERTH.XSYUKKA_D = DEFAULT_DATE                              '出荷日
                                    objXSTS_BERTH.XHENSEI_NO = ""                                       '編成No.
                                    objXSTS_BERTH.XSYUKKA_D_RIN1 = objPLN_OUT.XSYUKKA_D                 '隣接1出荷日
                                    objXSTS_BERTH.XHENSEI_NO_OYA_RIN1 = objPLN_OUT.XHENSEI_NO_OYA       '隣接1親編成No.
                                    If objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JDOWN Then
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUPDOWN                   'ﾊﾞｰｽ使用状況
                                    Else
                                        objXSTS_BERTH.XBERTH_STS = XBERTH_STS_JUP                       'ﾊﾞｰｽ使用状況
                                    End If
                                    objXSTS_BERTH.FUPDATE_DT = Now                                      '更新日時
                                    objXSTS_BERTH.UPDATE_XSTS_BERTH()
                            End Select
                        End If

                        '-------------------
                        'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)更新
                        '-------------------
                        If TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then            'ﾛｰﾀﾞ積
                            ' '' ''↓↓↓↓↓↓************************************************************************************************************
                            ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            ' '' ''-------------------
                            ' '' ''ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)読込
                            ' '' ''-------------------
                            '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
                            '' ''Dim strXBERTH_NO_L() As String
                            '' ''strXBERTH_NO_L = Split(objTPRG_SYS_HEN.SJ000000_003, KUGIRI01)                      '取得

                            ' '' ''引当順文字列作成
                            '' ''Dim strJun As String = ""
                            '' ''Dim blnFlg As Boolean = False
                            '' ''Dim intPnt As Integer = 0
                            '' ''For intCnt As Integer = 0 To UBound(strXBERTH_NO_L)
                            '' ''    If strXBERTH_NO_L(intCnt) = strBerthNo Then
                            '' ''        blnFlg = True
                            '' ''        intPnt = intCnt
                            '' ''    End If
                            '' ''    If blnFlg = True And intPnt <> intCnt Then
                            '' ''        If strJun = "" Then
                            '' ''            strJun = strJun & strXBERTH_NO_L(intCnt)
                            '' ''        Else
                            '' ''            strJun = strJun & "," & strXBERTH_NO_L(intCnt)
                            '' ''        End If
                            '' ''    End If
                            '' ''Next
                            '' ''For intCnt As Integer = LBound(strXBERTH_NO_L) To intPnt
                            '' ''    If strJun = "" Then
                            '' ''        strJun = strJun & strXBERTH_NO_L(intCnt)
                            '' ''    Else
                            '' ''        strJun = strJun & "," & strXBERTH_NO_L(intCnt)
                            '' ''    End If
                            '' ''Next

                            ' '' ''-------------------
                            ' '' ''ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)更新
                            ' '' ''-------------------
                            '' ''objTPRG_SYS_HEN.SJ000000_003 = strJun
                            ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            ' '' ''↑↑↑↑↑↑************************************************************************************************************


                            '↓↓↓↓↓↓************************************************************************************************************
                            'JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            If strBerthNo = "X01" Or strBerthNo = "X02" Or strBerthNo = "X03" Then
                                Dim objTPRG_SYS_HEN_WK As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)              'ｼｽﾃﾑ変数ｸﾗｽ
                                objTPRG_SYS_HEN_WK.SJ000000_005 = "2,1"

                                '-------------------
                                'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)読込
                                '-------------------
                                Dim strXBERTH_L() As String
                                strXBERTH_L = Split(objTPRG_SYS_HEN_WK.SJ000000_006, KUGIRI01)                      '取得

                                '引当順文字列作成
                                Dim strJun As String = ""
                                Dim blnFlg As Boolean = False
                                Dim intPnt As Integer = 0
                                For intCnt As Integer = 0 To UBound(strXBERTH_L)
                                    If strXBERTH_L(intCnt) = strBerthNo Then
                                        blnFlg = True
                                        intPnt = intCnt
                                    End If
                                    If blnFlg = True And intPnt <> intCnt Then
                                        If strJun = "" Then
                                            strJun = strJun & strXBERTH_L(intCnt)
                                        Else
                                            strJun = strJun & "," & strXBERTH_L(intCnt)
                                        End If
                                    End If
                                Next
                                For intCnt As Integer = LBound(strXBERTH_L) To intPnt
                                    If strJun = "" Then
                                        strJun = strJun & strXBERTH_L(intCnt)
                                    Else
                                        strJun = strJun & "," & strXBERTH_L(intCnt)
                                    End If
                                Next

                                '-------------------
                                'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)更新
                                '-------------------
                                objTPRG_SYS_HEN_WK.SJ000000_006 = strJun
                            ElseIf strBerthNo = "X04" Or strBerthNo = "X05" Or strBerthNo = "X06" Then
                                Dim objTPRG_SYS_HEN_WK As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)              'ｼｽﾃﾑ変数ｸﾗｽ
                                objTPRG_SYS_HEN_WK.SJ000000_005 = "1,2"

                                '-------------------
                                'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)読込
                                '-------------------
                                Dim strXBERTH_L() As String
                                strXBERTH_L = Split(objTPRG_SYS_HEN_WK.SJ000000_007, KUGIRI01)                      '取得

                                '引当順文字列作成
                                Dim strJun As String = ""
                                Dim blnFlg As Boolean = False
                                Dim intPnt As Integer = 0
                                For intCnt As Integer = 0 To UBound(strXBERTH_L)
                                    If strXBERTH_L(intCnt) = strBerthNo Then
                                        blnFlg = True
                                        intPnt = intCnt
                                    End If
                                    If blnFlg = True And intPnt <> intCnt Then
                                        If strJun = "" Then
                                            strJun = strJun & strXBERTH_L(intCnt)
                                        Else
                                            strJun = strJun & "," & strXBERTH_L(intCnt)
                                        End If
                                    End If
                                Next
                                For intCnt As Integer = LBound(strXBERTH_L) To intPnt
                                    If strJun = "" Then
                                        strJun = strJun & strXBERTH_L(intCnt)
                                    Else
                                        strJun = strJun & "," & strXBERTH_L(intCnt)
                                    End If
                                Next

                                '-------------------
                                'ﾊﾞｰｽ引当順(ﾛｰﾀﾞ)更新
                                '-------------------
                                objTPRG_SYS_HEN_WK.SJ000000_007 = strJun
                            End If
                            'JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞの号機交互割付対応
                            '↑↑↑↑↑↑************************************************************************************************************


                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then            'ﾊﾞﾗ積
                            '-------------------
                            '最終使用ﾊﾞﾗﾊﾞｰｽ更新
                            '-------------------
                            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)                 'ｼｽﾃﾑ変数ｸﾗｽ
                            objTPRG_SYS_HEN.SJ000000_004 = strBerthNo

                        End If

                        '-------------------
                        '出荷引当処理起動
                        '-------------------
                        Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '定周期管理ｸﾗｽ
                        objTPRG_TIMER.KIDOU_ON(FSYORI_ID_J310201)                               '起動

                    Else
                        If TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JL Then            'ﾛｰﾀﾞ積
                            blnWaitL = True                                                     '他の優先が高いﾛｰﾀﾞ積が待ちの為、他のﾛｰﾀﾞ積も待たせる
                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JP Then        'ﾊﾟﾚｯﾄ積
                            If TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JWING Then     '両横積
                                blnWaitP_W = True                                               '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                            ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JSIDE Then '片横積
                                blnWaitP_S = True                                               '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                            ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUKOU) = XTUMI_HOUKOU_JBACK Then '後積
                                blnWaitP_B = True                                               '他の優先が高いﾊﾟﾚｯﾄ積が待ちの為、他のﾊﾟﾚｯﾄ積も待たせる
                            End If
                        ElseIf TO_NUMBER(objPLN_OUT.XTUMI_HOUHOU) = XTUMI_HOUHOU_JB Then        'ﾊﾞﾗ積
                            blnWaitB = True                                                     '他の優先が高いﾊﾞﾗ積が待ちの為、他のﾊﾞﾗ積も待たせる
                        End If
                    End If

                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
                    If intHikiate = RetCode.OK And strBerthNo <> "" Then
                        Dim objDiff As TimeSpan = Now - dtmNow01
                        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
                             FLOG_DATA_TRN_SEND_NORMAL _
                             & "[ﾊﾞｰｽ:" & strBerthNo & "]" _
                             & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
                             )
                        Exit For
                    End If
                    'JobMate:S.Ouchi 2017/08/17 出荷起動処理修正(ﾀｲﾑｱｳﾄ対策)
                    '↑↑↑↑↑↑************************************************************************************************************
                Next
            End If

            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, FLOG_DATA_TRN_SEND_ERR & "  [" & ex.Message & "]")
            Return RetCode.NG
        End Try
    End Function
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

#Region "  ﾊﾞｰｽ使用可能判定   (Private  Check_Barth)"
    '==============================================================================================
    '【機能】ﾊﾞｰｽ使用可能判定
    '【引数】[IN ] strBth       :
    '        [IN ] objPLN_OUT   :
    '【戻値】RetCode
    '==============================================================================================
    Private Function Check_Barth(ByVal strBth As String, ByVal objPLN_OUT As TBL_XPLN_OUT, ByVal objXSTS_BERTH_ALL As TBL_XSTS_BERTH, ByVal objTSTS_EQ_ALL As TBL_TSTS_EQ_CTRL) As RetCode
        Try
            Dim intRet As RetCode
            Dim objXSTS_BERTH As New TBL_XSTS_BERTH(Owner, ObjDb, ObjDbLog)
            Dim objTSTS_EQ As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog)
            intRet = Get_Barth_Data_EQ(strBth, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)

            '-------------------
            '指定ﾊﾞｰｽ使用可能判定
            '-------------------
            'ﾊﾞｰｽ使用状況判定
            If TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JAKI Then     '[空き]以外は引当不可
                Return RetCode.NG
            End If

            '切離し判定
            If TO_INTEGER(objTSTS_EQ.FEQ_CUT_STS) = FEQ_CUT_STS_SON Then        '[切離]は引当不可
                Return RetCode.NG
            End If

            '-------------------
            '同一ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟの使用可能判定
            '-------------------
            For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                If objXSTS_BERTH.XBERTH_GROUP = objXSTS_BERTH_WK.XBERTH_GROUP Then          'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                    If TO_INTEGER(objXSTS_BERTH_WK.XBERTH_STS) = XBERTH_STS_JSESSYA Then
                        Return RetCode.NG                                                   '他のﾊﾞｰｽで同一ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ使用中
                    End If
                End If
            Next

            '-------------------
            '積込方法別判定
            '-------------------
            Select Case TO_INTEGER(objPLN_OUT.XTUMI_HOUHOU)
                Case XTUMI_HOUHOU_JL            'ﾛｰﾀﾞ積
                    ' '' ''↓↓↓↓↓↓************************************************************************************************************
                    ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞ複数割付対応
                    ' '' ''-------------------
                    ' '' ''ﾛｰﾀﾞの場合、同一号機の使用中能判定
                    ' '' ''-------------------    
                    '' ''Dim intGouki As Integer
                    '' ''intGouki = Get_LOADER_GOUKI(strBth)
                    '' ''For Each objXSTS_BERTH_WK As TBL_XSTS_BERTH In objXSTS_BERTH_ALL.ARYME
                    '' ''    If strBth <> objXSTS_BERTH_WK.XBERTH_NO Then
                    '' ''        Dim intGoukiChk As Integer
                    '' ''        intGoukiChk = Get_LOADER_GOUKI(objXSTS_BERTH_WK.XBERTH_NO)
                    '' ''        If intGouki = intGoukiChk Then
                    '' ''            If TO_INTEGER(objXSTS_BERTH_WK.XBERTH_STS) <> XBERTH_STS_JAKI Then
                    '' ''                Return RetCode.NG                                               '同一号機使用中
                    '' ''            End If
                    '' ''        End If
                    '' ''    End If
                    '' ''Next
                    ' '' ''JobMate:S.Ouchi 2013/09/10 ﾛｰﾀﾞ複数割付対応
                    ' '' ''↑↑↑↑↑↑************************************************************************************************************

                Case XTUMI_HOUHOU_JP, _
                     XTUMI_HOUHOU_JB            'ﾊﾟﾚｯﾄ積 , ﾊﾞﾗ積
                    '-------------------
                    '積込方向別判定
                    '-------------------
                    Select Case TO_INTEGER(objPLN_OUT.XTUMI_HOUKOU)
                        Case XTUMI_HOUKOU_JBACK         '後積み
                            '-------------------
                            '出荷ﾊﾞｰｽ状況ﾃｰﾌﾞﾙの積込方向判定
                            '-------------------
                            If TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JALL And _
                               TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JBACK Then    '[ALL][後積]以外は引当不可
                                Return RetCode.NG
                            End If

                        Case XTUMI_HOUKOU_JSIDE         '片横積み
                            '-------------------
                            '出荷ﾊﾞｰｽ状況ﾃｰﾌﾞﾙの積込方向判定
                            '-------------------
                            If TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JALL And _
                               TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JSIDE Then    '[ALL][片横]以外は引当不可
                                Return RetCode.NG
                            End If

                            '-------------------
                            '片横(ﾊﾞｯｸ接車助手席側)の判定
                            '-------------------
                            Dim strBth_Prev = ""
                            intRet = Get_Barth_Prev(strBth, strBth_Prev)
                            If intRet <> RetCode.OK Then
                                Return RetCode.NG
                            End If

                            '-------------------
                            '横ﾊﾞｰｽ(上)使用可能判定
                            '-------------------
                            'ﾊﾞｰｽ使用状況判定
                            intRet = Get_Barth_Data_EQ(strBth_Prev, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                            If TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JAKI And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JUP And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JDOWN Then     '[空き]以外は引当不可
                                Return RetCode.NG
                            End If

                        Case XTUMI_HOUKOU_JWING         '両横積み
                            '-------------------
                            '出荷ﾊﾞｰｽ状況ﾃｰﾌﾞﾙの積込方向判定
                            '-------------------
                            If TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JALL And _
                               TO_INTEGER(objXSTS_BERTH.XTUMI_HOUKOU) <> XTUMI_HOUKOU_JWING Then    '[ALL][両横]以外は引当不可
                                Return RetCode.NG
                            End If

                            '-------------------
                            '両横の判定(上)
                            '-------------------
                            Dim strBth_Prev = ""
                            Dim strBth_Next = ""
                            intRet = Get_Barth_Prev(strBth, strBth_Prev)
                            If intRet <> RetCode.OK Then
                                Return RetCode.NG
                            End If

                            '-------------------
                            '横ﾊﾞｰｽ(上)使用可能判定
                            '-------------------
                            'ﾊﾞｰｽ使用状況判定
                            intRet = Get_Barth_Data_EQ(strBth_Prev, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                            If TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JAKI And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JUP And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JDOWN Then     '[空き]以外は引当不可
                                Return RetCode.NG
                            End If

                            '-------------------
                            '両横の判定(下)
                            '-------------------
                            intRet = Get_Barth_Next(strBth, strBth_Next)
                            If intRet <> RetCode.OK Then
                                Return RetCode.NG
                            End If

                            '-------------------
                            '横ﾊﾞｰｽ(下)使用可能判定
                            '-------------------
                            'ﾊﾞｰｽ使用状況判定
                            intRet = Get_Barth_Data_EQ(strBth_Next, objXSTS_BERTH_ALL, objTSTS_EQ_ALL, objXSTS_BERTH, objTSTS_EQ)
                            If TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JAKI And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JUP And _
                               TO_INTEGER(objXSTS_BERTH.XBERTH_STS) <> XBERTH_STS_JDOWN Then     '[空き]以外は引当不可
                                Return RetCode.NG
                            End If

                        Case Else
                            Dim strMsg As String
                            strMsg = "出荷指示の積込方向が異常です[出荷日:" & TO_DATE(objPLN_OUT.XSYUKKA_D) & "][親編成No:" & objPLN_OUT.XHENSEI_NO_OYA & "][積込方向:" & objPLN_OUT.XTUMI_HOUKOU & "]"
                            Throw New System.Exception(strMsg)
                    End Select
                Case Else
                    Dim strMsg As String
                    strMsg = "出荷指示の積込方法が異常です[出荷日:" & TO_DATE(objPLN_OUT.XSYUKKA_D) & "][親編成No:" & objPLN_OUT.XHENSEI_NO_OYA & "][積込方法:" & objPLN_OUT.XTUMI_HOUHOU & "]"
                    Throw New System.Exception(strMsg)
            End Select

            '正常終了
            Return RetCode.OK

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
