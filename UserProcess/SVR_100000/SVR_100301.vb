'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞ強制完了ｸﾗｽ
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon使用の為
Imports MateCommon.clsConst                 'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
#End Region

Public Class SVR_100301
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ変数定義                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFPALLET_ID As String                   'ﾊﾟﾚｯﾄID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                                                                          "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ﾊﾟﾚｯﾄID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                                                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ 
    ''' </summary>
    ''' <param name="objOwner"></param>
    ''' <param name="objDb"></param>
    ''' <param name="objDbLog"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞ強制完了                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞ強制完了
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_FINISH()
        Try
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            Dim intRet As RetCode                   '戻り値


            '************************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If

          

            '************************
            'ﾄﾗｯｷﾝｸﾞﾏｽﾀの特定
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀｸﾗｽ
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '特定

            
            '************************
            'ﾄﾗｯｷﾝｸﾞ強制完了
            '************************
            Select Case TO_INTEGER(objTMST_TRK.FBUF_KIND)
                Case FBUF_KIND_SIN
                    '(入庫中の場合)

                    '========================
                    '入庫中強制完了
                    '========================
                    Dim objSVR_010102 As New SVR_010102(Owner, ObjDb, ObjDbLog) '入庫完了ｸﾗｽ
                    objSVR_010102.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                    objSVR_010102.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_IN       'IN/OUT
                    Call objSVR_010102.ExecCmdFunction()


                Case FBUF_KIND_SOUT
                    '(出庫中の場合)

                    '========================
                    '出庫中強制完了
                    '========================
                    Dim objSVR_010202 As New SVR_010202(Owner, ObjDb, ObjDbLog) '出庫完了ｸﾗｽ
                    objSVR_010202.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                    objSVR_010202.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_OUT      'IN/OUT
                    Call objSVR_010202.ExecCmdFunction()


                Case FBUF_KIND_STRNS
                    '(搬送中の場合)


                    '↓↓↓↓↓↓************************************************************************************************************
                    'JobMate:N.Dounoshita 2013/09/03 予定数ﾏｲﾅｽ1


                    ''*********************************************
                    ''予定数ﾏｲﾅｽ1
                    ''*********************************************
                    'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


                    '↑↑↑↑↑↑************************************************************************************************************

                    '========================
                    '搬送中強制完了
                    '========================
                    Dim objSVR_010302 As New SVR_010302(Owner, ObjDb, ObjDbLog) '搬送完了ｸﾗｽ
                    objSVR_010302.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                    objSVR_010302.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_RELAY    'IN/OUT
                    Call objSVR_010302.ExecCmdFunction()


                Case FBUF_KIND_SSOUKO
                    '(倉庫間搬送の場合)

                    '========================
                    '倉庫間搬送中強制完了
                    '========================
                    Dim objSVR_010102 As New SVR_010102(Owner, ObjDb, ObjDbLog) '入庫完了ｸﾗｽ
                    objSVR_010102.FPALLET_ID = mFPALLET_ID                      'ﾊﾟﾚｯﾄID
                    objSVR_010102.FINOUT_STS = FINOUT_STS_SMENTE_FINISH_SOUKO    'IN/OUT
                    Call objSVR_010102.ExecCmdFunction()


                Case Else
                    '(見つからない場合)

                    strMsg = ERRMSG_DISP_MENTE_FINISH_BUF_KIND & "[搬送中以外のﾄﾗｯｷﾝｸﾞ]" & "[ﾊﾞｯﾌｧNo:" & TO_STRING(objTMST_TRK.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)


            End Select


            '************************
            '搬送制御送信IFの削除
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '搬送制御送信IFｸﾗｽ
            objTLIF_TRNS_SEND.FPALLET_ID = mFPALLET_ID                              'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '削除


            '************************
            '搬送制御受信IFの削除
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '搬送制御受信IFｸﾗｽ
            objTLIF_TRNS_RECV.FPALLET_ID = mFPALLET_ID                              'ﾊﾟﾚｯﾄID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '削除


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  特殊処理31(予定数ﾘｾｯﾄ)                                                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 特殊処理31(予定数ﾘｾｯﾄ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Special31() As RetCode
        'Dim intRet As RetCode
        'Dim strMsg As String
        Dim intReturn As RetCode = RetCode.OK


        '************************
        'ﾁｪｯｸ
        '************************
        'NOP

        '***********************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        '***********************************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
        objTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID        'ﾊﾟﾚｯﾄID
        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF()
        If IsNull(objTPRG_TRK_BUF.FTR_TO) Then Return RetCode.OK


        '***********************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ(TO)
        '***********************************************
        Dim objTMST_TRK_TO As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
        objTMST_TRK_TO.FTRK_BUF_NO = objTPRG_TRK_BUF.FTR_TO            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        objTMST_TRK_TO.GET_TMST_TRK()                                  '取得


        '**************************************
        '到着予定数         送信
        '到着予定数をﾘｾｯﾄ
        '**************************************
        If IsNotNull(objTMST_TRK_TO.XADRS_YOTEI01) Then
            '(予定数がある場合)
            Dim objSVR_190001 As New SVR_190001(Owner, ObjDb, ObjDbLog)
            objSVR_190001.FCOMMAND_ID = FCOMMAND_ID_SWRITE_REG_WORD         'ｺﾏﾝﾄﾞID
            objSVR_190001.FPALLET_ID = ""                                   'ﾊﾟﾚｯﾄID
            objSVR_190001.FTRNS_SERIAL = ""                                 '搬送ｼﾘｱﾙ№
            Call objSVR_190001.SendYasukawa_IDYotei(objTMST_TRK_TO.FTRK_BUF_NO _
                                                  , 0 _
                                                  , 0 _
                                                  )
        End If


        Return intReturn
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
