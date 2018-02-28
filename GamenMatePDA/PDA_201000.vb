'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】PDA車輌№入力画面
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMatePDA.clsComFuncPDA
#End Region

Public Class PDA_201000

#Region "　共通変数　                           "

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SEARCH_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                "
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************



    End Sub
#End Region
#Region "  F1(ﾛｸﾞｵﾌ)  ﾎﾞﾀﾝ押下処理　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(ﾛｸﾞｵﾌ)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()
        Try

            Dim udeRet As RetPopup

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            udeRet = gobjComFuncPDA.DisplayPopup(FRM_MSG_PDA_BTN_CONFIRM_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> RetPopup.OK Then
                Exit Sub
            End If


            '*******************************************************
            'ｿｹｯﾄ送信処理
            '*******************************************************
            Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200004           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            Call gobjComFuncPDA.SockSendServer01(objTelegram)                    'ｿｹｯﾄ送信


            ''*******************************************************
            ''画面遷移
            ''*******************************************************
            'Call gobjComFuncPDA.FormMoveSelect(FDISP_ID_JPDA_100001, Me)


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  F4(検索)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(検索)  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()
        Try

            '********************************************************************
            '入力ﾁｪｯｸ
            '********************************************************************
            If InputCheck(menmCheckCase.SEARCH_Click) = False Then
                Exit Sub
            End If


            '********************************************************************
            ' 自身のｸﾛｰｽﾞ処理
            '********************************************************************
            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncPDA.ComError_frm(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        'Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        Select Case udtCheck_Case
            Case menmCheckCase.SEARCH_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

        End Select

        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region

End Class
