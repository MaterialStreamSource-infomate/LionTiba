'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷引当処理
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_310201
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
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '****************************************
            '出荷指示           取得
            '****************************************
            Dim strSQL01 As String = ""       'SQL文

            '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            '　2017/08/17 1件のみ処理するようにSORT順を修正 YAMAMOTO
            '　※ここで時間がかかると他処理でソケット通信ができなくなる対応
            '
            'strSQL01 &= vbCrLf & " SELECT "
            'strSQL01 &= vbCrLf & "    XPLN_OUT.XSYUKKA_D "              '出荷日
            'strSQL01 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA "         '親編成No.
            'strSQL01 &= vbCrLf & " FROM "
            'strSQL01 &= vbCrLf & "    XPLN_OUT "
            'strSQL01 &= vbCrLf & " WHERE "
            'strSQL01 &= vbCrLf & "    1 = 1 "
            'strSQL01 &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JRDY) & " "      '出荷状況
            'strSQL01 &= vbCrLf & " GROUP BY "
            'strSQL01 &= vbCrLf & "    XSYUKKA_D "
            'strSQL01 &= vbCrLf & "  , XHENSEI_NO_OYA "
            'strSQL01 &= vbCrLf & " ORDER BY "
            'strSQL01 &= vbCrLf & "    XSYUKKA_D "
            'strSQL01 &= vbCrLf & "  , XHENSEI_NO_OYA "
            'strSQL01 &= vbCrLf
            strSQL01 &= vbCrLf & " SELECT "
            strSQL01 &= vbCrLf & "    XPLN_OUT.XSYUKKA_D "              '出荷日
            strSQL01 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA "         '親編成No.
            strSQL01 &= vbCrLf & " FROM "
            strSQL01 &= vbCrLf & "    XPLN_OUT "
            strSQL01 &= vbCrLf & " WHERE "
            strSQL01 &= vbCrLf & "    1 = 1 "
            strSQL01 &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = " & TO_STRING(XSYUKKA_STS_JRDY) & " "      '出荷状況
            strSQL01 &= vbCrLf & " GROUP BY "
            strSQL01 &= vbCrLf & "    XSYUKKA_D "
            strSQL01 &= vbCrLf & "  , XHENSEI_NO_OYA "
            strSQL01 &= vbCrLf & "  , XSYUKKA_DIR_DT "
            strSQL01 &= vbCrLf & " ORDER BY "
            strSQL01 &= vbCrLf & "    XSYUKKA_DIR_DT "
            strSQL01 &= vbCrLf
            '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

            '抽出
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            'Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            ObjDb.SQL = strSQL01
            objDataSet.Clear()
            strDataSetName = "XPLN_OUT"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)

                For Each objRow As DataRow In objDataSet.Tables(strDataSetName).Rows
                    '(ﾙｰﾌﾟ:取得したﾃﾞｰﾀ数)


                    '****************************************
                    '初期設定
                    '****************************************
                    Dim dtmXSYUKKA_D As Date = objRow(0)            '出荷日
                    Dim strXHENSEI_NO_OYA As String = objRow(1)     '編成No.


                    '****************************************
                    '出荷指示詳細               取得
                    '****************************************
                    Dim objAryXPLN_OUT_DTL As New TBL_XPLN_OUT_DTL(Owner, ObjDb, ObjDbLog)
                    objAryXPLN_OUT_DTL.XSYUKKA_D = dtmXSYUKKA_D                 '出荷日
                    objAryXPLN_OUT_DTL.XHENSEI_NO_OYA = strXHENSEI_NO_OYA       '編成No.
                    intRet = objAryXPLN_OUT_DTL.GET_XPLN_OUT_DTL_ANY()          '取得
                    If intRet = RetCode.OK Then
                        '(見つかった場合)


                        '****************************************
                        '出荷引当処理(ﾙｰﾄ)
                        '****************************************
                        Select Case objAryXPLN_OUT_DTL.ARYME(0).FSAGYOU_KIND
                            Case FSAGYOU_KIND_J55
                                intRet = SyukkaHikiateRoot(dtmXSYUKKA_D, strXHENSEI_NO_OYA, SyukkaHikiateMode.Pallet)
                            Case FSAGYOU_KIND_J56
                                intRet = SyukkaHikiateRoot(dtmXSYUKKA_D, strXHENSEI_NO_OYA, SyukkaHikiateMode.Bara)
                            Case FSAGYOU_KIND_J57
                                intRet = SyukkaHikiateRoot(dtmXSYUKKA_D, strXHENSEI_NO_OYA, SyukkaHikiateMode.Loader01)
                                intRet = SyukkaHikiateRoot(dtmXSYUKKA_D, strXHENSEI_NO_OYA, SyukkaHikiateMode.Loader02)
                            Case Else
                                Throw New Exception("作業種別が不正です。[出荷日:" & objAryXPLN_OUT_DTL.ARYME(0).XSYUKKA_D & "]" _
                                                                      & "[編成№:" & objAryXPLN_OUT_DTL.ARYME(0).XHENSEI_NO & "]" _
                                                                      & "[品目ｺｰﾄﾞ:" & objAryXPLN_OUT_DTL.ARYME(0).FHINMEI_CD & "]" _
                                                                      & "[伝票No.:" & objAryXPLN_OUT_DTL.ARYME(0).XDENPYOU_NO & "]" _
                                                                      & "[作業種別:" & objAryXPLN_OUT_DTL.ARYME(0).FSAGYOU_KIND & "]" _
                                                                      )
                        End Select


                    End If


                    '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
                    '　2017/08/17 1件のみ処理するようにExitする YAMAMOTO
                    Exit For
                    '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
