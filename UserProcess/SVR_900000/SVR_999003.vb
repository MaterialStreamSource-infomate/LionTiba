'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】TMST_EQ_ERRORのFEQ_STSを変換
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_999003
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
        'Dim intRet As RetCode                   '戻り値
        'Dim strMsg As String                    'ﾒｯｾｰｼﾞ
        Try


            '**********************************************
            '設備異常ﾏｽﾀ        全取得
            '**********************************************
            Dim objAryTMST_EQ_ERROR As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)
            objAryTMST_EQ_ERROR.GET_TMST_EQ_ERROR_ANY()
            For Each objTMST_EQ_ERROR As TBL_TMST_EQ_ERROR In objAryTMST_EQ_ERROR.ARYME
                '(ﾙｰﾌﾟ:ﾚｺｰﾄﾞ数)


                '**********************************************
                '設備ID         ﾁｪｯｸ
                '**********************************************
                Select Case objTMST_EQ_ERROR.FEQ_ID
                    Case FEQ_ID_JOTHY05_X048501 _
                       , FEQ_ID_JOTHY05_X048502 _
                       , FEQ_ID_JOTHY05_X048503 _
                       , FEQ_ID_JOTHY05_X048504 _
                       , FEQ_ID_JOTHY05_X048505 _
                       , FEQ_ID_JOTHY05_X048506 _
                       , FEQ_ID_JOTHY05_X048507 _
                       , FEQ_ID_JOTHY05_X048508 _
                       , FEQ_ID_JOTHY05_X048509 _
                       , FEQ_ID_JOTHY05_X048510 _
                       , FEQ_ID_JOTHY05_X048511 _
                       , FEQ_ID_JOTHY05_X048512 _
                       , FEQ_ID_JOTHY05_X048513 _
                       , FEQ_ID_JOTHY05_X048514
                        '(ｸﾚｰﾝｴﾗｰｺｰﾄﾞの場合)
                        'NOP
                    Case Else
                        Continue For
                End Select


                '**********************************************
                '設備異常ﾏｽﾀ(追加用)    更新
                '**********************************************
                Dim objTMST_EQ_ERROR_Add As New TBL_TMST_EQ_ERROR(Owner, ObjDb, ObjDbLog)
                objTMST_EQ_ERROR_Add.COPY_PROPERTY(objTMST_EQ_ERROR)


                '**********************************************
                '設備状態           値取得
                '**********************************************
                Dim strTemp01 As String
                strTemp01 = TO_STRING(TO_INTEGER(objTMST_EQ_ERROR.FEQ_STS) - 5120)
                strTemp01 = Change10To16(TO_INTEGER(strTemp01), 2)

                '' ''Dim intTemp01 As Integer
                '' ''intTemp01 = Change16To10(objTMST_EQ_ERROR.FEQ_STS)
                '' ''intTemp01 += 5120


                '**********************************************
                '設備異常ﾏｽﾀ        削除
                '**********************************************
                objTMST_EQ_ERROR.DELETE_TMST_EQ_ERROR()


                '**********************************************
                '設備異常ﾏｽﾀ        追加
                '**********************************************
                objTMST_EQ_ERROR_Add.FEQ_STS = strTemp01        '設備状態
                objTMST_EQ_ERROR_Add.ADD_TMST_EQ_ERROR()        '追加


            Next



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
