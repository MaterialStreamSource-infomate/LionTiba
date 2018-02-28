'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】共通関数
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports      "
Imports System.Text
Imports System.Xml
Imports MateCommon.clsConst
Imports MateCommon
Imports JobCommon
Imports System.Net
Imports UserProcess
#End Region

Public Class clsComFuncFRM
    Inherits GamenCommon.clsComFuncGMN

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾞﾛｰﾊﾞﾙ変数                          "

    '**********************************************************************************************
    '　ｸﾞﾛｰﾊﾞﾙ変数
    '**********************************************************************************************
    Protected Friend Shared gobjComFuncFRM As New clsComFuncFRM   '共通関数ｵﾌﾞｼﾞｪｸﾄ

    '画面ｵﾌﾞｼﾞｪｸﾄ
    Public Shared gobjFRM_100001 As FRM_100001          'ﾛｸﾞｲﾝ画面
    Public Shared gobjFRM_100002 As FRM_100002          'ﾂﾘｰ画面
    Public Shared gobjFRM_100004 As FRM_100004          'Wait画面
    Public Shared gobjFRM_100005 As FRM_100005          '離席ﾛｸﾞｵﾝ画面
    Public Shared gobjFRM_100006 As FRM_100006          'ﾊﾟｽﾜｰﾄﾞ変更画面
    Public Shared gobjFRM_100007 As FRM_100007          'ﾊﾟｽﾜｰﾄﾞ確認画面
    Public Shared gobjFRM_100102 As FRM_100102          '確認画面1
    Public Shared gobjFRM_100103 As FRM_100103          '確認画面2
    Public Shared gobjFRM_100104 As FRM_100104          'ﾎﾟｯﾌﾟｱｯﾌﾟ画面(指図書発行ﾁｪｯｸﾎﾞｯｸｽあり)
    Public Shared gobjFRM_100105 As FRM_100105          '確認画面3
    Public Shared gobjFRM_100201 As FRM_100201          '理由ｺﾝﾎﾞﾎﾞｯｸｽ画面

    Public Shared gobjFRM_201000 As FRM_201000              'メインメニュー
    Public Shared gobjFRM_202000 As FRM_202000              'メインメニュー
    Public Shared gobjFRM_202001 As FRM_202001              '二重格納対応操作
    Public Shared gobjFRM_203000 As FRM_203000              '入出庫業務メニュー
    Public Shared gobjFRM_204000 As FRM_204000              '問合せメニュー
    Public Shared gobjFRM_204010 As FRM_204010              '在庫問合せ
    Public Shared gobjFRM_204020 As FRM_204020              '在庫詳細問合せ
    Public Shared gobjFRM_204030 As FRM_204030              '入出庫実績問合せ
    Public Shared gobjFRM_204050 As FRM_204050              '作業履歴問合せ
    Public Shared gobjFRM_204051 As FRM_204051              '作業履歴詳細
    Public Shared gobjFRM_204070 As FRM_204070              '変更履歴問合せ
    Public Shared gobjFRM_205000 As FRM_205000              'メンテナンスメニュー
    Public Shared gobjFRM_205010 As FRM_205010              'オンライン設定
    Public Shared gobjFRM_205020 As FRM_205020              'トラッキングメンテナンス
    Public Shared gobjFRM_205030 As FRM_205030              'トラッキングメンテナンス詳細
    Public Shared gobjFRM_205040 As FRM_205040              '在庫メンテナンス
    Public Shared gobjFRM_205041 As FRM_205041              '在庫メンテナンス(子画面)
    Public Shared gobjFRM_205042 As FRM_205042              '在庫メンテナンス(子画面・禁止棚一括設定)
    Public Shared gobjFRM_206000 As FRM_206000              'マスタメンテナンスメニュー
    Public Shared gobjFRM_206010 As FRM_206010              '品名マスタメンテナンス
    Public Shared gobjFRM_206011 As FRM_206011              '品名マスタメンテナンス(子画面)
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/05 品名ﾏｽﾀﾒﾝﾃﾅﾝｽ画面で品名ｺｰﾄﾞ/記号の直接指定
    Public Shared gobjFRM_206012 As FRM_206012              '品名マスタメンテナンス(子画面)
    'JobMate:S.Ouchi 2013/11/05 品名ﾏｽﾀﾒﾝﾃﾅﾝｽ画面で品名ｺｰﾄﾞ/記号の直接指定
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_206020 As FRM_206020              '担当者マスタメンテナンス
    Public Shared gobjFRM_206021 As FRM_206021              '担当者マスタメンテナンス(子画面)
    Public Shared gobjFRM_206030 As FRM_206030              '捜査権限マスタメンテナンス
    Public Shared gobjFRM_206040 As FRM_206040              '理由マスタメンテナンス
    Public Shared gobjFRM_206041 As FRM_206041              '理由マスタメンテナンス(子画面)
    Public Shared gobjFRM_207000 As FRM_207000              'システムメンテナンスメニュー
    Public Shared gobjFRM_207010 As FRM_207010              'オペレーションログ
    Public Shared gobjFRM_207011 As FRM_207011              'オペレーションログ詳細(子画面)
    Public Shared gobjFRM_207020 As FRM_207020              'システムエラーログ
    Public Shared gobjFRM_207030 As FRM_207030              '設備異常ログ
    Public Shared gobjFRM_207040 As FRM_207040              '設備通信ログ
    Public Shared gobjFRM_207041 As FRM_207041              '電文解析画面(子画面)
    Public Shared gobjFRM_207050 As FRM_207050              'メッセージ履歴
    Public Shared gobjFRM_207060 As FRM_207060              'システム定数メンテナンス
    Public Shared gobjFRM_207061 As FRM_207061              'システム定数メンテナンス(子画面)
    Public Shared gobjFRM_209000 As FRM_209000              'メッセージ確認

#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓FRM共通 ｵｰﾊﾞｰﾛｰﾄﾞ
#Region "  Waitﾌｫｰﾑ         Show、Close処理     "
    Public Overrides Sub WaitFormShow()

        '***************************************************
        ' ﾒｯｾｰｼﾞ表示
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If
        gobjFRM_100004 = New FRM_100004
        gobjFRM_100004.Show()
        gobjFRM_100004.Refresh()

    End Sub

    Public Overrides Sub WaitFormClose()

        '***************************************************
        ' ﾒｯｾｰｼﾞ削除
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Close()
            gobjFRM_100004.Dispose()
            gobjFRM_100004 = Nothing
        End If

    End Sub

    '↓↓↓↓ 2012.12.13 10:00 H.Morita 「しばらくおまちください」白抜け対応 
    Public Sub WaitFormRefresh()

        '***************************************************
        ' ﾒｯｾｰｼﾞ再表示
        '***************************************************
        If IsNull(gobjFRM_100004) = False Then
            gobjFRM_100004.Refresh()
        End If

    End Sub
    '↑↑↑↑ 2012.12.13 10:00 H.Morita 「しばらくおまちください」白抜け対応 

#End Region
#Region "  ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ        表示処理        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ 表示処理
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtFormType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="udtIconType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾃﾞﾌｫﾙﾄﾎﾟｯﾌﾟｱｯﾌﾟ表示名</param>
    ''' <param name="blnAddLog"></param>
    ''' <returns>ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ戻値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayPopup(ByVal strMessage As String _
                                              , ByVal udtFormType As PopupFormType _
                                              , ByVal udtIconType As PopupIconType _
                                              , Optional ByVal strSupplement As String = "" _
                                              , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                              , Optional ByVal blnAddLog As Boolean = True _
                                                ) As RetPopup

        '***********************************************************
        ' ﾛｸﾞ書込み処理
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ表示
        '***********************************************************
        Dim udtPopupRet As RetPopup
        Select Case udtFormType
            Case PopupFormType.Ok
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ﾌｫｰﾑ

            Case PopupFormType.Ok_Cancel
                udtPopupRet = Display_frmPopup_02(strMessage, udtIconType, strSupplement, strTitle)       'OK/CANCEL      ﾌｫｰﾑ

            Case PopupFormType.YES_NO
                udtPopupRet = Display_frmPopup_03(strMessage, udtIconType, strSupplement, strTitle)       'YES/NO         ﾌｫｰﾑ

            Case Else
                udtPopupRet = Display_frmPopup_01(strMessage, udtIconType, strSupplement, strTitle)       'OK             ﾌｫｰﾑ

        End Select


        Return (udtPopupRet)
    End Function

#Region "  frmPopup_01          表示処理"
    Private Function Display_frmPopup_01(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup
        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjFRM_100102) = False Then
            gobjFRM_100102.Close()
            gobjFRM_100102.Dispose()
            gobjFRM_100102 = Nothing
        End If
        gobjFRM_100102 = New FRM_100102

        gobjFRM_100102.Text = " " & strTitle                               'ﾌｫｰﾑﾀｲﾄﾙ（何か文字列が入っていないと変になる）
        gobjFRM_100102.userIconType = udtIconType                          'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjFRM_100102.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjFRM_100102.ShowDialog()                                        '表示

        udtRet = gobjFRM_100102.userRet                                    '戻り値設定

        Return (udtRet)
    End Function
#End Region

#Region "  frmPopup_02          表示処理"
    Private Function Display_frmPopup_02(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup

        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjFRM_100103) = False Then
            gobjFRM_100103.Close()
            gobjFRM_100103.Dispose()
            gobjFRM_100103 = Nothing
        End If
        gobjFRM_100103 = New FRM_100103

        gobjFRM_100103.Text = " " & strTitle                               'ﾌｫｰﾑﾀｲﾄﾙ（何か文字列が入っていないと変になる）
        gobjFRM_100103.userIconType = udtIconType                          'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjFRM_100103.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjFRM_100103.ShowDialog()                                        '表示

        udtRet = gobjFRM_100103.userRet                                    '戻り値設定

        Return (udtRet)
    End Function
#End Region

#Region "  frmPopup_03          表示処理"
    Private Function Display_frmPopup_03(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String _
                                                ) _
                                                As RetPopup

        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjFRM_100105) = False Then
            gobjFRM_100105.Close()
            gobjFRM_100105.Dispose()
            gobjFRM_100105 = Nothing
        End If
        gobjFRM_100105 = New FRM_100105

        gobjFRM_100105.Text = " " & strTitle                               'ﾌｫｰﾑﾀｲﾄﾙ（何か文字列が入っていないと変になる）
        gobjFRM_100105.userIconType = udtIconType                          'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjFRM_100105.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjFRM_100105.ShowDialog()                                        '表示

        udtRet = gobjFRM_100105.userRet                                    '戻り値設定

        Return (udtRet)
    End Function
#End Region

#End Region
#Region "  ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ(ﾁｪｯｸﾎﾞｯｸｽあり) 表示処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ(ﾁｪｯｸﾎﾞｯｸｽあり) 表示処理
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtFormType">ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑﾀｲﾌﾟ</param>
    ''' <param name="udtIconType">ｱｲｺﾝﾀｲﾌﾟ</param>
    ''' <param name="ChckBoxState">ﾁｪｯｸﾎﾞｯｸｽ値</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾀｲﾄﾙ</param>
    ''' <param name="blnAddLog">ﾛｸﾞ書込みﾌﾗｸﾞ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayChckBoxPopup(ByVal strMessage As String _
                                                     , ByVal udtFormType As PopupFormType _
                                                     , ByVal udtIconType As PopupIconType _
                                                     , ByRef ChckBoxState As CheckState _
                                                     , Optional ByVal strSupplement As String = "" _
                                                     , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                                     , Optional ByVal blnAddLog As Boolean = True _
                                                      ) _
                                                      As RetPopup

        '***********************************************************
        ' ﾛｸﾞ書込み処理
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ表示
        '***********************************************************
        Dim udtPopupRet As RetPopup
        Select Case udtFormType
            Case PopupFormType.Ok_Cancel
                udtPopupRet = Display_frmPopup_03(strMessage, udtIconType, strSupplement, strTitle, ChckBoxState)       'OK/CANCEL(CheckBox付き)      ﾌｫｰﾑ
        End Select

        Return (udtPopupRet)

    End Function
#Region "  frmPopup_03          表示処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' frmPopup_03 表示処理 
    ''' </summary>
    ''' <param name="strMessage">ﾒｯｾｰｼﾞ</param>
    ''' <param name="udtIconType">ｱｲｺﾝﾀｲﾌﾟ</param>
    ''' <param name="strSupplement">補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">ﾀｲﾄﾙ</param>
    ''' <param name="ChckBoxValue">ﾁｪｯｸﾎﾞｯｸｽ戻値</param>
    ''' <returns>ﾎﾟｯﾌﾟｱｯﾌﾟﾌｫｰﾑ戻値</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Display_frmPopup_03(ByVal strMessage As String, _
                                                ByVal udtIconType As PopupIconType, _
                                                ByVal strSupplement As String, _
                                                ByVal strTitle As String, _
                                                ByRef ChckBoxValue As CheckState _
                                               ) As RetPopup

        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNothing(gobjFRM_100104) = False Then
            gobjFRM_100104.Close()
            gobjFRM_100104.Dispose()
            gobjFRM_100104 = Nothing
        End If
        gobjFRM_100104 = New FRM_100104

        gobjFRM_100104.Text = " " & strTitle                                'ﾌｫｰﾑﾀｲﾄﾙ（何か文字列が入っていないと変になる）
        gobjFRM_100104.userIconType = udtIconType                           'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        gobjFRM_100104.lblMsg.Text = strMessageTemp                         'ﾒｯｾｰｼﾞ
        gobjFRM_100104.ShowDialog()                                         '表示

        udtRet = gobjFRM_100104.userRet                                     '戻り値設定
        ChckBoxValue = gobjFRM_100104.userCheck                             'ﾁｪｯｸﾎﾞｯｸｽ値

        gobjFRM_100104.Dispose()
        gobjFRM_100104 = Nothing

        Return (udtRet)

    End Function
#End Region
#End Region
#Region "  理由ｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰﾑ        表示処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 理由ｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰﾑ        表示処理
    ''' </summary>
    ''' <param name="strFREASON_KUBUN">[IN]理由区分</param>
    ''' <param name="strFREASON">[OUT]理由</param>
    ''' <param name="strMessage">[IN]ﾒｯｾｰｼﾞ</param>
    ''' <param name="strSupplement">[IN]補足ﾒｯｾｰｼﾞ（ﾒｯｾｰｼﾞの後に接続する）</param>
    ''' <param name="strTitle">[IN]ﾀｲﾄﾙ</param>
    ''' <param name="blnAddLog">[IN]ﾛｸﾞ書込みﾌﾗｸﾞ True:書込み</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function DisplayFRM_100201(ByVal strFREASON_KUBUN As String _
                                                   , ByRef strFREASON As String _
                                                   , Optional ByVal strMessage As String = FRM_MSG_FREASON_CD_MSG_01 _
                                                   , Optional ByVal strSupplement As String = "" _
                                                   , Optional ByVal strTitle As String = GAMEN_POPUPFORM_TITLE _
                                                   , Optional ByVal blnAddLog As Boolean = True _
                                                     ) As RetPopup
        Dim strMessageTemp As String    'ﾗﾍﾞﾙに表示するﾃｷｽﾄ
        Dim udtRet As RetPopup          '戻り値


        '***********************************************************
        ' ﾛｸﾞ書込み処理
        '***********************************************************
        If blnAddLog = True Then
            gobjComFuncFRM.AddToLog_frm(strMessage & strSupplement)
        End If


        '***********************************************************
        ' ﾒｯｾｰｼﾞ作成
        '***********************************************************
        strMessageTemp = ""
        strMessageTemp &= strMessage & vbCrLf
        strMessageTemp &= strSupplement


        '***********************************************************
        ' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '***********************************************************
        If IsNull(gobjFRM_100201) = False Then
            gobjFRM_100201.Close()
            gobjFRM_100201.Dispose()
            gobjFRM_100201 = Nothing
        End If
        gobjFRM_100201 = New FRM_100201

        gobjFRM_100201.Text = " " & strTitle                               'ﾌｫｰﾑﾀｲﾄﾙ（何か文字列が入っていないと変になる）
        gobjFRM_100201.lblMsg.Text = strMessageTemp                        'ﾒｯｾｰｼﾞ
        gobjFRM_100201.userFREASON_KUBUN = strFREASON_KUBUN                        'ﾒｯｾｰｼﾞ
        gobjFRM_100201.ShowDialog()                                        '表示
        udtRet = gobjFRM_100201.userRet                                    '戻り値設定
        strFREASON = gobjFRM_100201.userFREASON                            '理由

        Return (udtRet)
    End Function
#End Region
#Region "  画面遷移（画面IDで遷移）             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面遷移（画面IDで遷移）
    ''' </summary>
    ''' <param name="strDISP_ID">画面ID</param>
    ''' <param name="objFormNow">ﾓｰﾀﾞﾙに遷移するかどうか（ﾃﾞﾌｫﾙﾄではﾓｰﾀﾞﾚｽ）</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub FormMoveSelect(ByVal strDISP_ID As String _
                                           , ByRef objFormNow As Object _
                                           )

        Select Case strDISP_ID
            Case FDISP_ID_SFRM_100001                    'ログイン
                gobjFRM_100001 = New FRM_100001
                Call gobjComFuncFRM.FormMove(gobjFRM_100001, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_201000                    'メインメニュー
                gobjFRM_201000 = New FRM_201000
                Call gobjComFuncFRM.FormMove(gobjFRM_201000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_202000
                gobjFRM_202000 = New FRM_202000         'システムモニタ(原料)
                Call gobjComFuncFRM.FormMove(gobjFRM_202000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_203000                    '入出庫業務メニュー
                gobjFRM_203000 = New FRM_203000
                Call gobjComFuncFRM.FormMove(gobjFRM_203000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204000                    '問合せメニュー
                gobjFRM_204000 = New FRM_204000
                Call gobjComFuncFRM.FormMove(gobjFRM_204000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204010                    '問合せメニュー
                gobjFRM_204010 = New FRM_204010
                Call gobjComFuncFRM.FormMove(gobjFRM_204010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204030                    '入出庫実績問合せ
                gobjFRM_204030 = New FRM_204030
                Call gobjComFuncFRM.FormMove(gobjFRM_204030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204050                    '作業履歴問合せ
                gobjFRM_204050 = New FRM_204050
                Call gobjComFuncFRM.FormMove(gobjFRM_204050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_204070                    '変更履歴問合せ
                gobjFRM_204070 = New FRM_204070
                Call gobjComFuncFRM.FormMove(gobjFRM_204070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205000                    'メンテナンスメニュー
                gobjFRM_205000 = New FRM_205000
                Call gobjComFuncFRM.FormMove(gobjFRM_205000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205010                    'オンライン設定
                gobjFRM_205010 = New FRM_205010
                Call gobjComFuncFRM.FormMove(gobjFRM_205010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205020                    'トラッキングメンテナンス
                gobjFRM_205020 = New FRM_205020
                Call gobjComFuncFRM.FormMove(gobjFRM_205020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205030                    'トラッキングメンテナンス詳細
                gobjFRM_205030 = New FRM_205030
                Call gobjComFuncFRM.FormMove(gobjFRM_205030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_205040                    '在庫メンテナンス
                gobjFRM_205040 = New FRM_205040
                Call gobjComFuncFRM.FormMove(gobjFRM_205040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206010                    '品名マスタメンテナンス
                gobjFRM_206010 = New FRM_206010
                Call gobjComFuncFRM.FormMove(gobjFRM_206010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206020                    '担当者マスタメンテナンス
                gobjFRM_206020 = New FRM_206020
                Call gobjComFuncFRM.FormMove(gobjFRM_206020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206030                    '操作権限マスタメンテナンス
                gobjFRM_206030 = New FRM_206030
                Call gobjComFuncFRM.FormMove(gobjFRM_206030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_206040                    '理由マスタメンテナンス
                gobjFRM_206040 = New FRM_206040
                Call gobjComFuncFRM.FormMove(gobjFRM_206040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207000                    'システムメンテナンスメニュー
                gobjFRM_207000 = New FRM_207000
                Call gobjComFuncFRM.FormMove(gobjFRM_207000, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207010                    'オペレーションログ
                gobjFRM_207010 = New FRM_207010
                Call gobjComFuncFRM.FormMove(gobjFRM_207010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207020                    'システムエラーログ
                gobjFRM_207020 = New FRM_207020
                Call gobjComFuncFRM.FormMove(gobjFRM_207020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207030                    '設備異常ログ
                gobjFRM_207030 = New FRM_207030
                Call gobjComFuncFRM.FormMove(gobjFRM_207030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207040                    '設備通信ログ
                gobjFRM_207040 = New FRM_207040
                Call gobjComFuncFRM.FormMove(gobjFRM_207040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207050                    '設備異常ログ
                gobjFRM_207050 = New FRM_207050
                Call gobjComFuncFRM.FormMove(gobjFRM_207050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_207060                    '設備通信ログ
                gobjFRM_207060 = New FRM_207060
                Call gobjComFuncFRM.FormMove(gobjFRM_207060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_SFRM_209000                    'メッセージ確認
                gobjFRM_209000 = New FRM_209000
                Call gobjComFuncFRM.FormMove(gobjFRM_209000, objFormNow, OpenType.Modal)

                '↓↓↓ｼｽﾃﾑ固有

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
            Case FDISP_ID_JFRM_302010                    '入庫設定
                gobjFRM_302010 = New FRM_302010
                Call gobjComFuncFRM.FormMove(gobjFRM_302010, objFormNow, OpenType.Modaless)
                'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

            Case FDISP_ID_JFRM_303010                    '入庫設定
                gobjFRM_303010 = New FRM_303010
                Call gobjComFuncFRM.FormMove(gobjFRM_303010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303020                    '問合せ出庫設定
                gobjFRM_303020 = New FRM_303020
                Call gobjComFuncFRM.FormMove(gobjFRM_303020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303030                    '倉替入庫設定
                gobjFRM_303030 = New FRM_303030
                Call gobjComFuncFRM.FormMove(gobjFRM_303030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_303040                    '倉替出庫設定
                gobjFRM_303040 = New FRM_303040
                Call gobjComFuncFRM.FormMove(gobjFRM_303040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304040                    '出荷追跡問合せ
                gobjFRM_304040 = New FRM_304040
                Call gobjComFuncFRM.FormMove(gobjFRM_304040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304050                    'ﾛｯﾄ追跡問合せ
                gobjFRM_304050 = New FRM_304050
                Call gobjComFuncFRM.FormMove(gobjFRM_304050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304060                    '生産ﾗｲﾝ別入庫実績問合せ
                gobjFRM_304060 = New FRM_304060
                Call gobjComFuncFRM.FormMove(gobjFRM_304060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304070                    '棚状態績問合せ
                gobjFRM_304070 = New FRM_304070
                Call gobjComFuncFRM.FormMove(gobjFRM_304070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_304080                    '棚卸しリスト
                gobjFRM_304080 = New FRM_304080
                Call gobjComFuncFRM.FormMove(gobjFRM_304080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305050                    'ｺﾝﾍﾞﾔ用途設定
                gobjFRM_305050 = New FRM_305050
                Call gobjComFuncFRM.FormMove(gobjFRM_305050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305060                    'ﾛｯﾄ保留/解除
                gobjFRM_305060 = New FRM_305060
                Call gobjComFuncFRM.FormMove(gobjFRM_305060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305070                    '生産出来高実績ﾒﾝﾃﾅﾝｽ
                gobjFRM_305070 = New FRM_305070
                Call gobjComFuncFRM.FormMove(gobjFRM_305070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_305080                    'ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定
                gobjFRM_305080 = New FRM_305080
                Call gobjComFuncFRM.FormMove(gobjFRM_305080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306020                    '車両ﾏｽﾀ
                gobjFRM_306020 = New FRM_306020
                Call gobjComFuncFRM.FormMove(gobjFRM_306020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306030                    '物流業者ﾏｽﾀ
                gobjFRM_306030 = New FRM_306030
                Call gobjComFuncFRM.FormMove(gobjFRM_306030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306040                    '輸送手段ﾏｽﾀ
                gobjFRM_306040 = New FRM_306040
                Call gobjComFuncFRM.FormMove(gobjFRM_306040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306050                    '包装材料ﾒｰｶﾏｽﾀ
                gobjFRM_306050 = New FRM_306050
                Call gobjComFuncFRM.FormMove(gobjFRM_306050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306060                    '生産ﾗｲﾝﾏｽﾀ
                gobjFRM_306060 = New FRM_306060
                Call gobjComFuncFRM.FormMove(gobjFRM_306060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306070                    '生産ﾗｲﾝﾏｽﾀ(D45)
                gobjFRM_306070 = New FRM_306070
                Call gobjComFuncFRM.FormMove(gobjFRM_306070, objFormNow, OpenType.Modaless)

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
            Case FDISP_ID_JFRM_306080                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
                gobjFRM_306080 = New FRM_306080
                Call gobjComFuncFRM.FormMove(gobjFRM_306080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_306090                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
                gobjFRM_306090 = New FRM_306090
                Call gobjComFuncFRM.FormMove(gobjFRM_306090, objFormNow, OpenType.Modaless)
                'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************

            Case FDISP_ID_JFRM_307070                    'PLCﾒﾝﾃﾅﾝｽ(RTN)
                gobjFRM_307070 = New FRM_307070
                Call gobjComFuncFRM.FormMove(gobjFRM_307070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307080                    'PLCﾒﾝﾃﾅﾝｽ(入出庫CV)
                gobjFRM_307080 = New FRM_307080
                Call gobjComFuncFRM.FormMove(gobjFRM_307080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307090                    'PLCﾒﾝﾃﾅﾝｽ(入庫ST)
                gobjFRM_307090 = New FRM_307090
                Call gobjComFuncFRM.FormMove(gobjFRM_307090, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307100                    'PLCﾒﾝﾃﾅﾝｽ(出庫予定数)
                gobjFRM_307100 = New FRM_307100
                Call gobjComFuncFRM.FormMove(gobjFRM_307100, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307110                    '日報月報出力
                gobjFRM_307110 = New FRM_307110
                Call gobjComFuncFRM.FormMove(gobjFRM_307110, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_307120                    'PLCﾒﾝﾃﾅﾝｽ(入出棚CV)
                gobjFRM_307120 = New FRM_307120
                Call gobjComFuncFRM.FormMove(gobjFRM_307120, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_308010                    '検査結果登録
                gobjFRM_308010 = New FRM_308010
                Call gobjComFuncFRM.FormMove(gobjFRM_308010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310010                    '生産入庫登録
                gobjFRM_310010 = New FRM_310010
                Call gobjComFuncFRM.FormMove(gobjFRM_310010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310020                    '端数生産入庫設定
                gobjFRM_310020 = New FRM_310020
                Call gobjComFuncFRM.FormMove(gobjFRM_310020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310030                    '包材出庫登録
                gobjFRM_310030 = New FRM_310030
                Call gobjComFuncFRM.FormMove(gobjFRM_310030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_310040                    'D45包材出庫登録
                gobjFRM_310040 = New FRM_310040
                Call gobjComFuncFRM.FormMove(gobjFRM_310040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311010                    '出庫指示問合せ
                gobjFRM_311010 = New FRM_311010
                Call gobjComFuncFRM.FormMove(gobjFRM_311010, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311015                    '出庫指示詳細
                gobjFRM_311015 = New FRM_311015
                Call gobjComFuncFRM.FormMove(gobjFRM_311015, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311020                    '車両受付
                gobjFRM_311020 = New FRM_311020
                Call gobjComFuncFRM.FormMove(gobjFRM_311020, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311030                    '出荷指示
                gobjFRM_311030 = New FRM_311030
                Call gobjComFuncFRM.FormMove(gobjFRM_311030, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311040                    'ﾊﾞｰｽﾓﾆﾀ
                gobjFRM_311040 = New FRM_311040
                Call gobjComFuncFRM.FormMove(gobjFRM_311040, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311050                    '出荷中状況詳細
                gobjFRM_311050 = New FRM_311050
                Call gobjComFuncFRM.FormMove(gobjFRM_311050, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311060                    '出荷在庫確認
                gobjFRM_311060 = New FRM_311060
                Call gobjComFuncFRM.FormMove(gobjFRM_311060, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311070                    '出荷量問合せ
                gobjFRM_311070 = New FRM_311070
                Call gobjComFuncFRM.FormMove(gobjFRM_311070, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311080                    'ﾄﾗｯｸﾛｰﾀﾞﾊﾞｰｽﾓﾆﾀ
                gobjFRM_311080 = New FRM_311080
                Call gobjComFuncFRM.FormMove(gobjFRM_311080, objFormNow, OpenType.Modaless)

            Case FDISP_ID_JFRM_311090                    'ﾄﾗｯｸﾛｰﾀﾞﾊﾞｰｽ状況ﾓﾆﾀ
                gobjFRM_311090 = New FRM_311090
                Call gobjComFuncFRM.FormMove(gobjFRM_311090, objFormNow, OpenType.Modaless)


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
            Case FDISP_ID_JFRM_310050
                gobjFRM_310050 = New FRM_310050
                Call gobjComFuncFRM.FormMove(gobjFRM_310050, objFormNow, OpenType.Modaless)
            Case FDISP_ID_JFRM_307130
                gobjFRM_307130 = New FRM_307130
                Call gobjComFuncFRM.FormMove(gobjFRM_307130, objFormNow, OpenType.Modaless)
                'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************
                '↑↑↑ｼｽﾃﾑ固有


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:IKEDA 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
            Case FDISP_ID_JFRM_307140
                gobjFRM_307140 = New FRM_307140
                Call gobjComFuncFRM.FormMove(gobjFRM_307140, objFormNow, OpenType.Modaless)
            Case FDISP_ID_JFRM_307150
                gobjFRM_307150 = New FRM_307150
                Call gobjComFuncFRM.FormMove(gobjFRM_307150, objFormNow, OpenType.Modaless)
                'JobMate:ikeda 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
                '↑↑↑↑↑↑************************************************************************************************************
                '↑↑↑ｼｽﾃﾑ固有

        End Select


    End Sub
#End Region
#Region "　画面離席処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面離席処理
    ''' </summary>
    ''' <param name="objForm"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub AfkProc(ByRef objForm As Form)

        '****************************************************
        '離席ﾛｸﾞｲﾝ設定画面表示
        '****************************************************
        gobjFRM_100005 = Nothing
        gobjFRM_100005 = New FRM_100005     '離席ﾛｸﾞｲﾝ設定画面

        Try

            '*******************************************************
            'ｿｹｯﾄ送信処理
            '*******************************************************
            Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
            objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200005           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
            Call gobjComFuncFRM.SockSendServer01(objTelegram)                                  'ｿｹｯﾄ送信


            '****************************************************
            '画面表示
            '****************************************************
            'objForm.Visible = False             '展開元画面を非表示
            gobjFRM_100005.ShowDialog()


            '****************************************************
            'ﾛｸﾞｲﾝ/ﾛｸﾞｵﾌﾁｪｯｸ
            '****************************************************
            Dim udtAFKFrmRet As AFKFrmRetType
            udtAFKFrmRet = gobjFRM_100005.AFKFORMRET

            '===============================
            'ﾛｸﾞｲﾝ/ﾛｸﾞｵﾌﾁｪｯｸ
            '===============================
            If udtAFKFrmRet = AFKFrmRetType.LogOff Then
                '(強制ﾛｸﾞｵﾌの場合)

                '***************************************************************
                'ﾛｸﾞｲﾝ画面表示
                '***************************************************************
                If gblnLogoff = False Then
                    gblnLogoff = True
                    Call gobjComFuncFRM.PubF_ShellExe(System.Reflection.Assembly.GetExecutingAssembly().Location)
                End If

                '***************************************************************
                '自分自身のﾌﾟﾛｾｽ情報取得
                '***************************************************************
                Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                '======================================
                '自分自身を終了
                '======================================
                hProcess.Kill()

            End If

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            Throw ex

        Finally

            '===============================
            'ｵﾌﾞｼﾞｪｸﾄ開放
            '===============================
            gobjFRM_100005.Dispose()
            gobjFRM_100005 = Nothing

        End Try
    End Sub
#End Region
#Region "  ﾊﾟｽﾜｰﾄﾞ確認処理                      "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ確認処理
    ''' </summary>
    ''' <param name="strFDISP_ID">画面ID</param>
    ''' <param name="strFCTRL_ID">ｺﾝﾄﾛｰﾙID</param>
    ''' <returns>True:ﾊﾟｽﾜｰﾄﾞ確認成功    False:ﾊﾟｽﾜｰﾄﾞ確認失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Overrides Function PassWordCheck(ByVal strFDISP_ID As String _
                                               , ByVal strFCTRL_ID As String _
                                               ) _
                                               As Boolean
        Dim intRet As RetCode
        Dim blnReturn As Boolean = True     '戻り値(基本OKにしておく)


        '******************************************
        ' 画面ﾏｽﾀ取得
        '******************************************
        Dim objTDSP_NAME As New TBL_TDSP_NAME(gobjOwner, gobjDb, Nothing)
        objTDSP_NAME.FDISP_ID = strFDISP_ID        '画面ID
        objTDSP_NAME.FCTRL_ID = strFCTRL_ID        'ｺﾝﾄﾛｰﾙID
        intRet = objTDSP_NAME.GET_TDSP_NAME(False)
        If intRet <> RetCode.OK Then
            '(見つからなかった場合)
            blnReturn = True
            Return blnReturn
        End If


        '******************************************
        ' ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ
        '******************************************
        If objTDSP_NAME.FPASS_CHECK_FLAG = FPASS_CHECK_FLAG_SON Then
            '(ﾊﾟｽﾜｰﾄﾞﾁｪｯｸありの場合)

            '***********************************************************
            ' ﾊﾟｽﾜｰﾄﾞ確認画面表示
            '***********************************************************
            Dim udtRet As RetPopup
            If IsNull(gobjFRM_100007) = False Then
                gobjFRM_100007.Close()
                gobjFRM_100007.Dispose()
                gobjFRM_100007 = Nothing
            End If
            gobjFRM_100007 = New FRM_100007
            gobjFRM_100007.ShowDialog()                                        '表示
            udtRet = gobjFRM_100007.userRet                                    '戻り値設定
            If udtRet = RetPopup.OK Then
                '(ﾊﾟｽﾜｰﾄﾞ認証OKの場合)
                blnReturn = True
            Else
                '(ﾊﾟｽﾜｰﾄﾞ認証NGの場合)
                blnReturn = False
            End If

        Else
            '(ﾊﾟｽﾜｰﾄﾞﾁｪｯｸなしの場合)
            blnReturn = True
        End If


        Return blnReturn
    End Function
#End Region
    'ｸﾘｽﾀﾙﾚﾎﾟｰﾄ
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理
    ''' </summary>
    ''' <param name="objCR">ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CRPrint(ByVal objCR As Object)

        Dim gobjetc1201 As New FRM_100003

        If gcstrPRINT_FLG = FLAG_ON Then

            '=====================================
            '印字ﾌﾗｸﾞ   ｵﾝ
            '=====================================
            objCR.PrintToPrinter(1, False, 0, 0)    ' 印字

        Else
            '=====================================
            '印字ﾌﾗｸﾞ   ｵﾌ
            '=====================================
            If IsNull(gobjetc1201) = False Then
                gobjetc1201.Close()
                gobjetc1201.Dispose()
                gobjetc1201 = Nothing
            End If
            gobjetc1201 = FRM_100003
            gobjetc1201.CrystalReportViewer1.ReportSource = objCR
            gobjetc1201.ShowDialog()

            gobjetc1201.Close()
            gobjetc1201.Dispose()
            gobjetc1201 = Nothing

        End If


    End Sub
#End Region
#Region "　ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄ印字処理(開発ﾂｰﾙ用)
    ''' </summary>
    ''' <param name="grdControl">ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strTableName">ﾃｰﾌﾞﾙ名</param>
    ''' <param name="strText01">ﾃｷｽﾄ1</param>
    ''' <param name="strText02">ﾃｷｽﾄ2</param>
    ''' <param name="strText05">ﾃｷｽﾄ5</param>
    ''' <param name="strText06">ﾃｷｽﾄ6</param>
    ''' <param name="strText07">ﾃｷｽﾄ7</param>
    ''' <param name="strFooter01">ﾌｯﾀｰ1</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CRPrintKaihatu(ByVal grdControl As System.Windows.Forms.DataGridView _
                                           , ByVal strTableName As String _
                                           , ByVal strText01 As String _
                                           , ByVal strText02 As String _
                                           , ByVal strText05 As String _
                                           , ByVal strText06 As String _
                                           , ByVal strText07 As String _
                                           , ByVal strFooter01 As String _
                                           )

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示


        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_000001             'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
        Dim strColTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_020)
        Dim strRowTerminator As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_021)

        Try


            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call ChangeCRText(objCR, "crDateTime01", "")    '発行日時
            Call ChangeCRText(objCR, "Text3", "")           '発行日時
            Call ChangeCRText(objCR, "crText01", strText01)
            Call ChangeCRText(objCR, "crText02", strText02)
            '' ''Call ChangeCRText(objCR, "crText03", strText03)
            '' ''Call ChangeCRText(objCR, "crText04", strText04)
            Call ChangeCRText(objCR, "crText05", strText05)
            Call ChangeCRText(objCR, "crText06", strText06)
            Call ChangeCRText(objCR, "crText07", strText07)
            Call ChangeCRText(objCR, "crFooter01", strFooter01)
            Call ChangeCRText(objCR, "crFooter02", strText01)


            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdControl.Rows.Count - 1 - 1
                '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行数 - 1    ｸﾞﾘｯﾄﾞ最終行は空白なので省く)

                '=========================================
                '文字列作成
                '=========================================
                Dim strData As String = ""
                For jj As Integer = 0 To grdControl.ColumnCount - 1
                    If jj <> 0 Then strData &= strColTerminator
                    strData &= """" & grdControl.Item(jj, ii).Value & """"
                Next
                strData &= strRowTerminator

                '=========================================
                '配列作成
                '=========================================
                Dim strDataArray() As String = Nothing
                Call gobjComFuncFRM.DivStringToArray(strData, strDataArray)

                '=========================================
                'ﾃﾞｰﾀ追加
                '=========================================
                For jj As Integer = LBound(strDataArray) To UBound(strDataArray)
                    Dim objDataRow As clsPrintDataSet.DataTable01Row
                    objDataRow = objDataSet.DataTable01.NewRow
                    objDataRow.BeginEdit()
                    objDataRow.Data00 = strDataArray(jj)
                    objDataRow.EndEdit()
                    objDataSet.DataTable01.Rows.Add(objDataRow)
                Next

            Next


            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)


            ' ''***********************************************
            ' '' 印字
            ' ''***********************************************
            ''objCR.PrintToPrinter(1, False, 0, 0)    ' 印字


            '***********************************************
            ' PDF出力
            '***********************************************
            'ﾌｧｲﾙ名作成
            Dim strPathPDF As String = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_022)
            strPathPDF &= strFooter01
            strPathPDF &= "_"
            strPathPDF &= strTableName
            '' ''strPathPDF &= "_"
            '' ''strPathPDF &= Format(Now, GAMEN_DATE_FORMAT_04)
            strPathPDF &= ".pdf"
            'ﾌｧｲﾙﾁｪｯｸ
            'ﾌｫﾙﾀﾞ作成
            If System.IO.File.Exists(strPathPDF) Then
                If MessageBox.Show("同じ名前のファイルが既に存在しています。" & vbCrLf & "上書きしますか？", "確認", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
            'PDF出力
            objCR.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strPathPDF)


        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region
#Region "  ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾘｽﾀﾙﾚﾎﾟｰﾄのﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄの表示ﾃｷｽﾄを変更
    ''' </summary>
    ''' <param name="objCR">ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="strObjectName">ｸﾘｽﾀﾙﾚﾎﾟｰﾄの貼り付いているｵﾌﾞｼﾞｪｸﾄ名</param>
    ''' <param name="strText">ｸﾘｽﾀﾙﾚﾎﾟｰﾄに表示させるﾃｷｽﾄ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub ChangeCRText(ByVal objCR As Object _
                                         , ByVal strObjectName As String _
                                         , ByVal strText As String _
                                         )

        CType(objCR.ReportDefinition.ReportObjects(strObjectName),  _
              CrystalDecisions.CrystalReports.Engine.TextObject). _
              Text = strText

    End Sub
#End Region

    '↑↑↑FRM共通 ｵｰﾊﾞｰﾛｰﾄﾞ
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:H.Morita 2012/08/23 CSV出力機能の追加
#Region "  CSVﾌｧｲﾙ出力                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' CSVﾌｧｲﾙ出力
    ''' </summary>
    ''' <param name="objGrid">ｸﾞﾘｯﾄﾞ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Shared Sub MakeCSV(ByVal objGrid As GamenCommon.cmpMDataGrid _
                            , ByVal strFilePath As String _
                            , ByVal strFileName As String _
                            , ByVal strHeader As String _
                            , ByVal strDataHeaderName_Ary() As String _
                            , ByVal intDataColumnIdx_Ary() As Integer _
                              )


        '***********************
        'ﾌｫﾙﾀﾞの作成
        '***********************
        ' 指定のパスが存在しなければ作成し、作成不可ならアプリケーション実行フォルダ
        If System.IO.Directory.Exists(strFilePath) = False Then
            Try
                System.IO.Directory.CreateDirectory(strFilePath)
            Catch ex As Exception
                strFilePath = Application.StartupPath
            End Try
        End If
        If Microsoft.VisualBasic.Strings.Right(strFilePath, 1) <> "\" Then strFilePath &= "\"


        '***********************
        '初期設定
        '***********************
        '出力ﾊﾟｽ & ﾌｧｲﾙ名       の設定
        Dim strFilePathName As String = ""
        strFilePathName &= strFilePath
        strFilePathName &= strFileName


        '***********************
        'ﾍｯﾀﾞ部作成
        '***********************
        Dim strWrite As String = ""
        If IsNotNull(strHeader) Then
            strWrite = strHeader & vbCrLf
        End If


        '***********************
        'ﾃﾞｰﾀ部のﾍｯﾀﾞ部分の作成
        '***********************
        For ii As Integer = 0 To UBound(strDataHeaderName_Ary)
            If ii = 0 Then
                strWrite &= strDataHeaderName_Ary(ii)
            Else
                strWrite &= ","
                strWrite &= strDataHeaderName_Ary(ii)
            End If
        Next
        strWrite &= vbCrLf


        '***********************
        'ﾃﾞｰﾀ部作成
        '***********************
        For ii As Integer = 0 To objGrid.Rows.Count - 1
            '(ﾙｰﾌﾟ:ﾃﾞｰﾀﾃｰﾌﾞﾙにｾｯﾄされているﾃﾞｰﾀ数)

            For jj As Integer = 0 To UBound(intDataColumnIdx_Ary)
                '(ﾙｰﾌﾟ:出力する列数)

                If jj = 0 Then
                    If IsDBNull(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value) = True Then
                        '(DBNullの時)
                        strWrite &= ""
                    Else
                        '(値がある時)
                        strWrite &= TO_STRING(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value).Replace(","c, "，"c)    '2012.11.28 13:30 H.Morita ｶﾝﾏ 全角変換
                    End If
                Else
                    strWrite &= ","
                    If IsDBNull(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value) = True Then
                        '(DBNullの時)
                        strWrite &= ""
                    Else
                        '(値がある時)
                        strWrite &= TO_STRING(objGrid.Item(intDataColumnIdx_Ary(jj), ii).Value).Replace(","c, "，"c)    '2012.11.28 13:30 H.Morita ｶﾝﾏ 全角変換
                    End If
                End If

            Next

            strWrite &= vbCrLf

            Call gobjComFuncFRM.WaitFormRefresh()                    ' Waitﾌｫｰﾑ再表示

        Next


        '***********************
        'StreamWriter   作成
        '***********************
        Dim objSW As New System.IO.StreamWriter(strFilePathName, False, System.Text.Encoding.GetEncoding(932))           'Shift JISで書き込む
        Try
            objSW.Write(strWrite)          '追加
        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)
            Throw New Exception(ex.Message)
        Finally
            objSW.Close()
        End Try


    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

#Region "  ｸﾞﾛｰﾊﾞﾙ変数                          "

    '**********************************************************************************************
    '　ｸﾞﾛｰﾊﾞﾙ変数
    '**********************************************************************************************
    '画面ｵﾌﾞｼﾞｪｸﾄ
    Public Shared gobjFRM_302001 As FRM_302001              '空棚詳細表示
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
    Public Shared gobjFRM_302010 As FRM_302010              '生産ﾗｲﾝﾓﾆﾀ
    Public Shared gobjFRM_302011 As FRM_302011              '生産ﾗｲﾝﾓﾆﾀ子画面1
    Public Shared gobjFRM_302012 As FRM_302012              '生産ﾗｲﾝﾓﾆﾀ子画面2
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_303010 As FRM_303010              '入庫設定
    Public Shared gobjFRM_303011 As FRM_303011              '入庫設定子画面1
    Public Shared gobjFRM_303012 As FRM_303012              '入庫設定子画面2
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
    Public Shared gobjFRM_303013 As FRM_303013              '入庫設定子画面3
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_303020 As FRM_303020              '問合せ出庫設定
    Public Shared gobjFRM_303030 As FRM_303030              '倉替入庫設定
    Public Shared gobjFRM_303031 As FRM_303031              '倉替入庫設定子画面
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/18 設定済ﾃﾞｰﾀ表示
    Public Shared gobjFRM_303032 As FRM_303032              '倉替入庫設定子画面2
    'JobMate:S.Ouchi 2013/10/18 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_303040 As FRM_303040              '倉替出庫設定
    Public Shared gobjFRM_303041 As FRM_303041              '倉替出庫設定子画面
    Public Shared gobjFRM_304040 As FRM_304040              '出庫追跡問合せ
    Public Shared gobjFRM_304050 As FRM_304050              'ﾛｯﾄ追跡問合せ
    Public Shared gobjFRM_304060 As FRM_304060              '生産ﾗｲﾝ別入庫実績問合せ
    Public Shared gobjFRM_304070 As FRM_304070              '棚状態問合せ
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:N.Nakada 2013/11/01 棚卸リスト
    Public Shared gobjFRM_304080 As FRM_304080              '棚卸リスト
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_305050 As FRM_305050              'ｺﾝﾍﾞﾔ用途設定
    Public Shared gobjFRM_305060 As FRM_305060              'ﾛｯﾄ保留/解除
    Public Shared gobjFRM_305061 As FRM_305061              'ﾛｯﾄ保留/解除子画面
    Public Shared gobjFRM_305070 As FRM_305070              '緊急時入庫登録
    Public Shared gobjFRM_305071 As FRM_305071              '緊急時入庫登録子画面
    Public Shared gobjFRM_305080 As FRM_305080              'ﾊﾞｰｽ割付ｺﾝﾍﾞﾔ設定
    Public Shared gobjFRM_306020 As FRM_306020              '車両ﾏｽﾀ
    Public Shared gobjFRM_306021 As FRM_306021              '車両ﾏｽﾀ子画面
    Public Shared gobjFRM_306030 As FRM_306030              '物流業者ﾏｽﾀ
    Public Shared gobjFRM_306031 As FRM_306031              '物流業者ﾏｽﾀ子画面
    Public Shared gobjFRM_306040 As FRM_306040              '輸送手段ﾏｽﾀ
    Public Shared gobjFRM_306041 As FRM_306041              '輸送手段ﾏｽﾀ子画面
    Public Shared gobjFRM_306050 As FRM_306050              '包装材料ﾒｰｶﾏｽﾀ
    Public Shared gobjFRM_306051 As FRM_306051              '包装材料ﾒｰｶﾏｽﾀ子画面
    Public Shared gobjFRM_306060 As FRM_306060              '生産ﾗｲﾝﾏｽﾀ
    Public Shared gobjFRM_306061 As FRM_306061              '生産ﾗｲﾝﾏｽﾀ子画面
    Public Shared gobjFRM_306070 As FRM_306070              '生産ﾗｲﾝﾏｽﾀ(D45)
    Public Shared gobjFRM_306071 As FRM_306071              '生産ﾗｲﾝﾏｽﾀ(D45)子画面
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↓↓↓↓↓↓
    Public Shared gobjFRM_306080 As FRM_306080              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
    Public Shared gobjFRM_306081 As FRM_306081              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ子画面
    Public Shared gobjFRM_306090 As FRM_306090              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ
    Public Shared gobjFRM_306091 As FRM_306091              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝﾏｽﾀ子画面
    'JobMate:S.Ouchi 2015/07/03 CW6追加対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************
    Public Shared gobjFRM_307070 As FRM_307070              'PLCﾒﾝﾃﾅﾝｽ(RTN)
    Public Shared gobjFRM_307071 As FRM_307071              'PLCﾒﾝﾃﾅﾝｽ(RTN)子画面 RTN選択(1F)
    Public Shared gobjFRM_307072 As FRM_307072              'PLCﾒﾝﾃﾅﾝｽ(RTN)子画面 RTN選択(2F)
    Public Shared gobjFRM_307073 As FRM_307073              'PLCﾒﾝﾃﾅﾝｽ(RTN)子画面
    Public Shared gobjFRM_307080 As FRM_307080              'PLCﾒﾝﾃﾅﾝｽ(入出庫CV)
    Public Shared gobjFRM_307081 As FRM_307081              'PLCﾒﾝﾃﾅﾝｽ(入出庫CV)子画面
    Public Shared gobjFRM_307090 As FRM_307090              'PLCﾒﾝﾃﾅﾝｽ(入庫ST)
    Public Shared gobjFRM_307091 As FRM_307091              'PLCﾒﾝﾃﾅﾝｽ(入庫ST)子画面
    Public Shared gobjFRM_307092 As FRM_307092              'PLCﾒﾝﾃﾅﾝｽ(入庫ST)ST選択画面
    Public Shared gobjFRM_307100 As FRM_307100              'PLCﾒﾝﾃﾅﾝｽ(出庫予定数)
    Public Shared gobjFRM_307101 As FRM_307101              'PLCﾒﾝﾃﾅﾝｽ(出庫予定数)子画面
    Public Shared gobjFRM_307102 As FRM_307102              'PLCﾒﾝﾃﾅﾝｽ(出庫予定数)子画面 現在値変更
    Public Shared gobjFRM_307110 As FRM_307110              '日報月報出力
    Public Shared gobjFRM_307120 As FRM_307120              'PLCﾒﾝﾃﾅﾝｽ(入出棚CV)
    Public Shared gobjFRM_307121 As FRM_307121              'PLCﾒﾝﾃﾅﾝｽ(入出棚CV)子画面
    Public Shared gobjFRM_307122 As FRM_307122              'PLCﾒﾝﾃﾅﾝｽ(入出棚CV)子画面 現在値変更RTN
    Public Shared gobjFRM_307123 As FRM_307123              'PLCﾒﾝﾃﾅﾝｽ(入出棚CV)子画面 現在値変更ﾘﾌﾀｰ
    Public Shared gobjFRM_308010 As FRM_308010              '検査結果登録
    Public Shared gobjFRM_308011 As FRM_308011              '検査結果登録子画面
    Public Shared gobjFRM_310010 As FRM_310010              '生産入庫登録
    Public Shared gobjFRM_310011 As FRM_310011              '生産入庫登録子画面
    Public Shared gobjFRM_310020 As FRM_310020              '端数生産入庫設定
    Public Shared gobjFRM_310030 As FRM_310030              '包材出庫登録
    Public Shared gobjFRM_310031 As FRM_310031              '包材出庫登録子画面
    Public Shared gobjFRM_310040 As FRM_310040              'D45包材出庫登録
    Public Shared gobjFRM_310041 As FRM_310041              'D45包材出庫登録子画面
    Public Shared gobjFRM_311010 As FRM_311010              '出荷指示問合せ
    Public Shared gobjFRM_311011 As FRM_311011              '出荷指示問合せ子画面
    Public Shared gobjFRM_311015 As FRM_311015              '出荷指示詳細
    Public Shared gobjFRM_311020 As FRM_311020              '車両受付
    Public Shared gobjFRM_311030 As FRM_311030              '出荷指示
    Public Shared gobjFRM_311031 As FRM_311031              '出荷指示子画面
    Public Shared gobjFRM_311040 As FRM_311040              'ﾊﾞｰｽﾓﾆﾀ
    Public Shared gobjFRM_311050 As FRM_311050              '出荷中状況詳細
    Public Shared gobjFRM_311055 As FRM_311055              '出荷中状況詳細子画面
    Public Shared gobjFRM_311060 As FRM_311060              '出荷在庫確認
    Public Shared gobjFRM_311070 As FRM_311070              '出荷量問合せ
    Public Shared gobjFRM_311080 As FRM_311080              'ﾄﾗｯｸﾛｰﾀﾞﾊﾞｰｽﾓﾆﾀ
    Public Shared gobjFRM_311090 As FRM_311090              'ﾄﾗｯｸﾛｰﾀﾞﾊﾞｰｽ状況ﾓﾆﾀ
    'Public Shared gobjFRM_311100 As FRM_311100              'ﾊﾞｰｽ状況ﾓﾆﾀ

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:YAMAMOTO 2017/04/11 1F包材出庫対応 ↓↓↓↓↓↓
    Public Shared gobjFRM_307130 As FRM_307130              'PLCﾒﾝﾃﾅﾝｽ(1F包材出庫)
    Public Shared gobjFRM_307131 As FRM_307131              'PLCﾒﾝﾃﾅﾝｽ(1F包材出庫)子画面
    Public Shared gobjFRM_310050 As FRM_310050              '1F包材出庫登録
    Public Shared gobjFRM_310051 As FRM_310051              '1F包材出庫登録子画面
    'JobMate:YAMAMOTO 2017/04/111F包材出庫対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:IKEDA 2017/07/06 生産入庫登録(BCR)対応 ↓↓↓↓↓↓
    Public Shared gobjFRM_307140 As FRM_307140              '生産入庫登録(BCR)
    Public Shared gobjFRM_307150 As FRM_307150              'PLCﾒﾝﾃﾅﾝｽ(BCR)
    Public Shared gobjFRM_307151 As FRM_307151              'PLCﾒﾝﾃﾅﾝｽ(BCR)子画面
    'JobMate:IKEDA 2017/07/06 PLCメンテナンス(BCR)対応 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  小数点以下桁数取得                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 小数点以下桁数取得
    ''' </summary>
    ''' <param name="intValue">対象の数値</param>
    ''' <returns>小数点以下桁数</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetPrecision(ByVal intValue As Decimal) As Integer

        GetPrecision = (intValue - CInt(intValue)).ToString().TrimEnd("0"c).Replace("0.", String.Empty).Replace("-", String.Empty).Length
        Return GetPrecision

    End Function
#End Region
#Region "  作業者名取得                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 作業者名取得
    ''' </summary>
    ''' <param name="strFUSER_ID">ﾕｰｻﾞｰID</param>
    ''' <returns>ﾕｰｻﾞｰ名</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Get_FUSER_NAME(ByVal strFUSER_ID As String) As String


        '*********************************************
        ' 作業者名　表示
        '*********************************************
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim strFUSER_NAME As String = ""     'ﾕｰｻﾞｰ名

        '-----------------------
        '抽出SQL作成
        '-----------------------
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FUSER_ID "                                'ﾕｰｻﾞｰｺｰﾄﾞ
        strSQL &= vbCrLf & "  , FUSER_NAME "                              'ﾕｰｻﾞｰ名
        strSQL &= vbCrLf & " FROM TMST_USER "                             'ﾕｰｻﾞｰﾏｽﾀ
        strSQL &= vbCrLf & " WHERE"
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TMST_USER.FUSER_ID = '" & strFUSER_ID & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FUSER_ID "
        strSQL &= vbCrLf

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TMST_USER"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(見つかった場合)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            strFUSER_NAME = TO_STRING(objRow("FUSER_NAME"))
        Else
            '(見つからない場合)
            strFUSER_NAME = ""
        End If

        Return strFUSER_NAME

    End Function
#End Region
#Region "  異常ﾊﾟﾚｯﾄID取得                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 異常ﾊﾟﾚｯﾄID取得
    ''' </summary>
    ''' <param name="strCraneID">ｸﾚｰﾝID</param>
    ''' <param name="intFCOMP_KUBUN">完了区分</param>
    ''' <param name="strFPALLET_ID">ﾊﾟﾚｯﾄID</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks>ﾊﾟﾚｯﾄIDを取得する関数</remarks>
    ''' *******************************************************************************************************************
    Public Shared Function GetUnusual_PALLET_ID(ByVal strCraneID As String, ByVal intFCOMP_KUBUN As Integer, ByRef strFPALLET_ID As String) As RetCode

        Dim intRet As RetCode
        Dim strMsg As String = ""

        If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Then
            '(二重搬入のとき)
            strMsg = FRM_MSG_FRM202000_18
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
            '(荷姿不一致のとき)
            strMsg = FRM_MSG_FRM202000_19
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
            '(空出庫のとき)
            strMsg = FRM_MSG_FRM202000_21
        End If

        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
        '************************************************
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)
        objTPRG_TRK_BUF.FEQ_ID = strCraneID                                 '設備ID
        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_RELAY()
        If intRet <> RetCode.OK Then
            If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Or intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
                '(二重搬入または荷姿不一致のとき)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_17, PopupFormType.Ok, PopupIconType.Information)
            ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
                '(空出庫のとき)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_22, PopupFormType.Ok, PopupIconType.Information)
            End If

            Exit Function

        End If

        '************************************************
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定
        '************************************************
        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = objTPRG_TRK_BUF.FTRK_BUF_NO           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTMST_TRK.GET_TMST_TRK()
        If intFCOMP_KUBUN = FCOMP_KUBUN_SNIJUU Or intFCOMP_KUBUN = FCOMP_KUBUN_SNISUGATA Then
            '(二重搬入または荷姿不一致のとき)
            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SOUT Then
                '(ﾊﾞｯﾌｧ種別が出庫中ﾊﾞｯﾌｧのとき)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_20, PopupFormType.Ok, PopupIconType.Information)
                Exit Function
            End If
        ElseIf intFCOMP_KUBUN = FCOMP_KUBUN_SKARA Then
            '(空出庫のとき)
            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SIN Then
                '(ﾊﾞｯﾌｧ種別が入庫中ﾊﾞｯﾌｧのとき)
                gobjComFuncFRM.DisplayPopup(strMsg & vbCrLf & FRM_MSG_FRM202000_23, PopupFormType.Ok, PopupIconType.Information)
                Exit Function
            End If
        End If

        strFPALLET_ID = objTPRG_TRK_BUF.FPALLET_ID

        Return True

    End Function
#End Region

#Region "  ﾗﾍﾞﾙ背景色変更処理  (入出庫ﾓｰﾄﾞ表示ﾗﾍﾞﾙ)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更処理  (入出庫ﾓｰﾄﾞ表示ﾗﾍﾞﾙ) 
    ''' </summary>
    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strFTRK_BUF_NO">入出庫ｽﾃｰｼｮﾝ</param>
    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ''' <param name="strFEQ_STS">設備状態区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColorMOD(ByVal lblControl As Label _
                                , ByVal strFTRK_BUF_NO As String _
                                , ByVal udtLblDspType As LBL_DSPTYPE _
                                , Optional ByRef strFEQ_STS As String = CBO_ALL_CONTENT_01 _
                                 )

        If strFTRK_BUF_NO = CBO_ALL_CONTENT_01 Then
            '(ST指定無し)
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If


        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim strFEQ_ID As String = ""        '入出庫ﾓｰﾄﾞ

        strFEQ_ID = "JMOD" & Microsoft.VisualBasic.Right("0000" & strFTRK_BUF_NO, 4)

        ' ''Select Case strFEQ_ID
        ' ''    Case "JMOD0168"
        ' ''        strFEQ_ID = "JMOD0169"
        ' ''    Case "JMOD0173"
        ' ''        strFEQ_ID = "JMOD0174"
        ' ''    Case "JMOD0184"
        ' ''        strFEQ_ID = "JMOD0185"
        ' ''    Case "JMOD0186"
        ' ''        strFEQ_ID = "JMOD0187"
        ' ''    Case "JMOD0381"
        ' ''        strFEQ_ID = "JMOD0382"
        ' ''End Select

        ' ''If (strFTRK_BUF_NO = FTRK_BUF_NO_J8) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J169) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J174) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J168) Or _
        ' ''   (strFTRK_BUF_NO = FTRK_BUF_NO_J173) Then
        ' ''    '(出荷ﾊﾞｰｽ8の時)

        ' ''    strFEQ_ID = "JMOD0169"

        ' ''    If GetFEQ_STS(strFTRK_BUF_NO, False, False, False) = 2 Then
        ' ''        '(ﾓｰﾄﾞ不一致の時)
        ' ''        lblControl.Visible = True
        ' ''        lblControl.Text = "ﾓｰﾄﾞ不一致"
        ' ''        lblControl.BackColor = gcModeColor_CUS_FUITHI
        ' ''        Exit Sub
        ' ''    End If

        ' ''End If


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_NAME "                           '設備状況.設備名称
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FSTS_NAME "                           '画面設備状態表示ﾏｽﾀ.状態名
        strSQL &= vbCrLf & "   ,NVL(TDSP_EQ_STS.FCOLOR_KUBUN, " & FCOLOR_KUBUN_SWHITE & ") AS FCOLOR_KUBUN "      '画面設備状態表示ﾏｽﾀ.表示色
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS.FEQ_STS "                             '画面設備状態表示ﾏｽﾀ.設備状態区分
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                    '設備状況
        strSQL &= vbCrLf & "   ,TDSP_EQ_STS "                                     '画面設備状態表示ﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND '" & strFEQ_ID & "'      = TSTS_EQ_CTRL.FEQ_ID "                '設備状況 の 設備ID を 指定
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_DSP_KUBUN   = TDSP_EQ_STS.FEQ_DSP_KUBUN(+) "   '設備状況 と 画面設備状態表示ﾏｽﾀ の 画面設備表示区分 を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_STS     = TDSP_EQ_STS.FEQ_STS(+) "             '設備状況 と 画面設備状態表示ﾏｽﾀ の 設備状態 を 外部結合
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_CUT_STS = TDSP_EQ_STS.FEQ_CUT_STS(+) "         '設備状況 と 画面設備状態表示ﾏｽﾀ の 切離有無 を 外部結合


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(読めた時)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)

            lblControl.Visible = True

            Select Case udtLblDspType
                Case LBL_DSPTYPE.EQNAME
                    '画面表示用名称変更(設備名)
                    lblControl.Text = TO_STRING(objRow("FEQ_NAME"))
                Case LBL_DSPTYPE.STSNAME
                    '画面表示用名称変更(ｽﾃｰﾀｽ名)
                    lblControl.Text = StrConv(TO_STRING(objRow("FSTS_NAME")), VbStrConv.Wide)
                    strFEQ_STS = TO_STRING(objRow("FEQ_STS"))
                Case LBL_DSPTYPE.NO_DSP
                    'ﾗﾍﾞﾙ表示変更無し
            End Select


            '背景色変更
            Call AlterBackColorMOD(lblControl, TO_NUMBER(objRow("FCOLOR_KUBUN")))

        Else
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black

        End If


    End Sub
#End Region
#Region "  背景色変更処理                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 背景色変更処理
    ''' </summary>
    ''' <param name="objControl">背景色を変更するｺﾝﾄﾛｰﾙ</param>
    ''' <param name="intColorKubun">ｶﾗｰ区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterBackColorMOD(ByVal objControl As Object _
                            , ByVal intColorKubun As Integer _
                            )

        '******************************************
        '背景色変更
        '******************************************
        Select Case intColorKubun
            'Case FCOLOR_KUBUN_SGREEN
            Case FCOLOR_KUBUN_SLIGHTGREEN
                'objControl.BackColor = gcModeColor_IN       '入庫ﾓｰﾄﾞ
                objControl.BackColor = gcModeColor_CUS_IN       '入庫ﾓｰﾄﾞ
            Case FCOLOR_KUBUN_SBLUE
                'objControl.BackColor = gcModeColor_OUT      '出庫ﾓｰﾄﾞ
                objControl.BackColor = gcModeColor_CUS_OUT      '出庫ﾓｰﾄﾞ
        End Select

    End Sub
#End Region
#Region "  設備状態ﾁｪｯｸ                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態ﾁｪｯｸ
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№</param>
    ''' <param name="intFEQ_STS">設備状態</param>
    ''' <param name="strErrMsg">ｴﾗｰﾒｯｾｰｼﾞ</param>
    ''' <param name="intSTSagyo">入庫・出庫作業</param>
    ''' <returns>false:ｴﾗｰあり/true:ｴﾗｰ無し</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CheckFEQ_STS(ByVal intFTRK_BUF_NO As Integer, _
                                    ByVal intFEQ_STS As Integer, _
                                    ByVal strErrMsg As String, _
                                    ByVal intSTSagyo As Integer _
                                    ) As Boolean

        Dim strMsg As String = ""
        Dim blnCheckErr As Boolean = False       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        Dim intRet As RetCode

        '==========================
        '入出庫ﾓｰﾄﾞﾁｪｯｸ
        '==========================
        Dim intFTRK_BUF_NO1 As Integer          'ﾄﾗｯｲｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim strFEQ_ID As String = ""            '設備ID(ﾓｰﾄﾞ)
        Dim strFEQ_ID_STN As String = ""        '設備ID(台車)
        Dim strFEQ_ID_CRN As String = ""        '設備ID(ｸﾚｰﾝ)

        intFTRK_BUF_NO1 = intFTRK_BUF_NO


        '**********************************************************
        ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀの特定
        '**********************************************************
        Dim objTMST_TRK As TBL_TMST_TRK                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = intFTRK_BUF_NO1           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        intRet = objTMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(読めたとき)
            If IsNull(objTMST_TRK.XEQ_ID_MOD) = False Then
                '(値がある時)
                strFEQ_ID = objTMST_TRK.XEQ_ID_MOD
                strFEQ_ID_STN = objTMST_TRK.XEQ_ID_STN
            Else
                '(値がない時)
                blnCheckErr = True          '(ﾓｰﾄﾞが無いのでﾁｪｯｸ不要。OK)
                Return blnCheckErr
            End If
        Else
            '(読めない時)
            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & intFTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If


        '=============================================
        '設備状況TBL
        '=============================================
        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)     '設備状況ﾃｰﾌﾞﾙｸﾗｽ
        objTSTS_EQ_CTRL.FEQ_ID = strFEQ_ID                                          '設備ID
        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                            '特定
        If intRet = RetCode.NotFound Then
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
            Throw New System.Exception(strMsg)
        End If

        If objTSTS_EQ_CTRL.FEQ_STS <> TO_STRING(intFEQ_STS) Then
            '(指定したﾓｰﾄﾞと異なるとき)
            Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Information)
            Return blnCheckErr
        End If

        '====================================
        'ﾄﾗｯｷﾝｸﾞ状態取得ﾁｪｯｸ
        '====================================
        '(出庫作業の時)
        If Chk_ST_TRK_BUF(intFTRK_BUF_NO1, True) = True Then
            '(ﾄﾗｯｷﾝｸﾞ有りの時)
            Return blnCheckErr
        End If

        blnCheckErr = True
        Return blnCheckErr

    End Function
#End Region
#Region "  ST ﾄﾗｯｷﾝｸﾞ状態 取得ﾁｪｯｸ               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ST ﾄﾗｯｷﾝｸﾞ 有無ﾁｪｯｸ
    ''' </summary>
    ''' <param name="intFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№</param>
    ''' <param name="blnDSP_MSG">ｴﾗｰMSG表示有無</param>
    ''' <returns>false:ｴﾗｰなし/true:ｴﾗｰあり</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Chk_ST_TRK_BUF(ByVal intFTRK_BUF_NO As Integer, ByVal blnDSP_MSG As Boolean) As Boolean

        Dim blnCheckErr As Boolean = False       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        Dim intRet As RetCode

        '====================================
        'ﾄﾗｯｷﾝｸﾞ状態取得ﾁｪｯｸ
        '====================================
        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ
        objTPRG_TRK_BUF.FTRK_BUF_NO = intFTRK_BUF_NO                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_ANY()                     '特定

        If intRet = RetCode.OK Then
            '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬがあるとき)

            For ii As Integer = LBound(objTPRG_TRK_BUF.ARYME) To UBound(objTPRG_TRK_BUF.ARYME)
                '(見つかったﾚｺｰﾄﾞ件数)
                If objTPRG_TRK_BUF.ARYME(ii).FRES_KIND = FRES_KIND_SAKI Then
                    '(引当状態が空棚の時)
                Else
                    '(以外の時)
                    If blnDSP_MSG = True Then
                        '(ｴﾗｰ表示あり)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_STN_ERROR_25, PopupFormType.Ok, PopupIconType.Information)
                    End If
                    blnCheckErr = True
                End If
            Next

        End If

        Return blnCheckErr

    End Function
#End Region

#Region "  ﾗﾍﾞﾙ背景色変更処理 ver.TIBA  (入出庫ﾓｰﾄﾞ表示ﾗﾍﾞﾙ)         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗﾍﾞﾙ背景色変更処理 ver.TIBA (入出庫ﾓｰﾄﾞ表示ﾗﾍﾞﾙ) 
    ''' </summary>
    ''' <param name="lblControl">背景色を変更するﾗﾍﾞﾙｺﾝﾄﾛｰﾙ</param>
    ''' <param name="strFTRK_BUF_NO">入出庫ｽﾃｰｼｮﾝ</param>
    ''' <param name="udtLblDspType">ﾗﾍﾞﾙ表示ﾀｲﾌﾟ</param>
    ''' <param name="strFEQ_STS">設備状態区分</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub AlterLabelColorMOD_TIBA(ByVal lblControl As Label _
                                , ByVal strFTRK_BUF_NO As String _
                                , ByVal udtLblDspType As LBL_DSPTYPE _
                                , Optional ByRef strFEQ_STS As String = CBO_ALL_CONTENT_01 _
                                 )

        If strFTRK_BUF_NO = CBO_ALL_CONTENT_01 Then
            '(ST指定無し)
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If

        Dim strFEQ_ID_OUT As String = ""        '出庫ﾓｰﾄﾞﾚｼﾞｽﾄﾘ
        Dim strFEQ_ID_IN As String = ""         '入庫ﾓｰﾄﾞﾚｼﾞｽﾄﾘ
        Dim intFEQ_STS_OUT As Integer = -1      '出庫ﾓｰﾄﾞ状態
        Dim intFEQ_STS_IN As Integer = -1       '入庫ﾓｰﾄﾞ状態

        Select Case strFTRK_BUF_NO
            Case FTRK_BUF_NO_J2038      'D21緊急入出庫
                strFEQ_ID_OUT = "JOTHMFF_D000030_14"
                strFEQ_ID_IN = "JOTHMFF_D000030_15"

            Case FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174     'C01～C04外部入出庫
                strFEQ_ID_OUT = "JOTHMFF_D000030_06"
                strFEQ_ID_IN = "JOTHMFF_D000030_07"

            Case Else
                lblControl.Visible = False
                lblControl.Text = ""
                lblControl.BackColor = gcLabelColor_Black
                Exit Sub

        End Select


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        Dim strSQL As String                'SQL文
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_ID, "                          '設備状況.設備ID
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL.FEQ_STS "                          '設備状況.設備状態
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TSTS_EQ_CTRL "                                  '設備状況

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TSTS_EQ_CTRL.FEQ_ID IN ('" & strFEQ_ID_OUT & "','" & strFEQ_ID_IN & "') "                '設備状況 の 設備ID を 指定

        '============================================================
        'ORDER
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    FEQ_ID "

        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "TDSP_EQ_STS"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '(読めた時)
            Dim ii As Integer = 0
            For ii = 0 To objDataSet.Tables(strDataSetName).Rows.Count - 1

                objRow = objDataSet.Tables(strDataSetName).Rows(ii)

                Select Case udtLblDspType
                    Case LBL_DSPTYPE.EQNAME
                        '画面表示用名称変更(設備名)

                    Case LBL_DSPTYPE.STSNAME
                        '画面表示用名称変更(ｽﾃｰﾀｽ名)

                        Dim strFEQ_ID As String = ""                '設備ID
                        strFEQ_ID = TO_STRING(objRow("FEQ_ID"))

                        If strFEQ_ID = strFEQ_ID_OUT Then
                            '(出庫ﾓｰﾄﾞ)
                            intFEQ_STS_OUT = TO_INTEGER(objRow("FEQ_STS"))

                        ElseIf strFEQ_ID = strFEQ_ID_IN Then
                            '(入庫ﾓｰﾄﾞ)
                            intFEQ_STS_IN = TO_INTEGER(objRow("FEQ_STS"))

                        End If

                    Case LBL_DSPTYPE.NO_DSP
                        'ﾗﾍﾞﾙ表示変更無し
                End Select

            Next

        Else
            lblControl.Visible = False
            lblControl.Text = ""
            lblControl.BackColor = gcLabelColor_Black
            Exit Sub
        End If


        '********************************************************************
        ' 設備状態ﾗﾍﾞﾙ変更
        '********************************************************************
        lblControl.Visible = True

        If intFEQ_STS_OUT = 1 And intFEQ_STS_IN = 0 Then
            '(出庫ﾓｰﾄﾞ)
            lblControl.Text = "出庫モード"                                      'ﾓｰﾄﾞ
            Call AlterBackColorMOD(lblControl, FCOLOR_KUBUN_SLIGHTGREEN)        '背景色

        ElseIf intFEQ_STS_OUT = 0 And intFEQ_STS_IN = 1 Then
            '(入庫ﾓｰﾄﾞ)
            lblControl.Text = "入庫モード"                                      'ﾓｰﾄﾞ
            Call AlterBackColorMOD(lblControl, FCOLOR_KUBUN_SBLUE)              '背景色

        Else
            '(その他)
            lblControl.Text = "モード不明"                                      'ﾓｰﾄﾞ
            lblControl.BackColor = gcLabelColor_Black                           '背景色

        End If

    End Sub
#End Region

#Region "  ﾋﾟｯｷﾝｸﾞﾘｽﾄ 帳票出力                   "
    '    ''' *******************************************************************************************************************
    '    ''' <summary>
    '    ''' ﾋﾟｯｷﾝｸﾞﾘｽﾄ 帳票出力
    '    ''' </summary>
    '    ''' <param name="XHENSEI_NO_OYA">親編成No.</param>
    '    ''' <param name="XSYUKKA_D">出荷日</param>
    '    ''' <param name="DispWait">Waitﾌｫｰﾑ表示有無</param>
    '    ''' <returns>True=成功</returns>
    '    ''' <remarks></remarks>
    '    ''' *******************************************************************************************************************
    '    Public Function Print_PRT_311050_01(ByVal XHENSEI_NO_OYA As String, _
    '                                         ByVal XSYUKKA_D As String, _
    '                                         Optional ByVal DispWait As Boolean = False _
    '                                         ) As Boolean

    '        Dim blnCheckErr As Boolean = False       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

    '        If DispWait Then
    '            Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示
    '        End If

    '        '***********************************************
    '        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
    '        '***********************************************
    '        Dim objCR As New PRT_311050_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
    '        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

    '        Try
    '            Dim intRet As Integer = 0

    '            '************************************************************
    '            ' ﾍｯﾀﾞｰ部情報取得
    '            '************************************************************
    '            'ﾍｯﾀﾞｰ部変数
    '            Dim strXSYUKKA_D As String = ""                 '出荷日
    '            'Dim strXHENSEI_NO_OYA As String = ""            '親編成No.
    '            Dim strXSYARYOU_NO As String = ""               '車輌No.
    '            Dim strXBERTH_NO As String = ""                 'ﾊﾞｰｽNo.
    '            Dim strXTUMI_HOUHOU As String = ""              '積込方法
    '            Dim strXTUMI_HOUKOU As String = ""              '積込方向

    '            Dim objTBL_XPLN_OUT As New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
    '            objTBL_XPLN_OUT.XHENSEI_NO_OYA = XHENSEI_NO_OYA     '親編成No.
    '            objTBL_XPLN_OUT.XSYUKKA_D = XSYUKKA_D               '出荷日
    '            intRet = objTBL_XPLN_OUT.GET_XPLN_OUT_ANY()
    '            If intRet <> RetCode.OK Then
    '                '(ﾃﾞｰﾀ取得失敗時)
    '                blnCheckErr = True
    '                Exit Try
    '            End If


    '            For Each objTBL_XPLN_OUT_DATA As TBL_XPLN_OUT In objTBL_XPLN_OUT.ARYME
    '                strXSYARYOU_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XSYARYOU_NO)     '車輌No.
    '                strXBERTH_NO = TO_STRING(objTBL_XPLN_OUT_DATA.XBERTH_NO)         'ﾊﾞｰｽNo.
    '                strXTUMI_HOUHOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUHOU)   '積込方法
    '                strXTUMI_HOUKOU = TO_STRING(objTBL_XPLN_OUT_DATA.XTUMI_HOUKOU)   '積込方向
    '            Next


    '            '************************************************************
    '            ' ﾃﾞｰﾀ部情報取得
    '            '************************************************************
    '            Dim strSQL As String                        'SQL文
    '            Dim objRow As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
    '            Dim strDataSetName As String                'ﾃﾞｰﾀｾｯﾄ名
    '            Dim objTBLDataSet As New DataSet            'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

    '            '============================================================
    '            'SELECT
    '            '============================================================
    '            strSQL = ""
    '            strSQL &= vbCrLf & "SELECT "
    '            strSQL &= vbCrLf & "    XPLN_OUT_DTL.XHENSEI_NO "                                       '出荷指示詳細.      編成No.
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XDENPYOU_NO "                                      '出荷指示詳細.      伝票No.
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XOUT_ORDER "                                       '出荷指示詳細.  　　車輌内出荷品目順
    '            strSQL &= vbCrLf & "  , TMST_ITEM.XHINMEI_CD "                                          '品名ﾏｽﾀ.　　       品名ｺｰﾄﾞ
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD "                                       '出荷指示詳細.      品名記号
    '            strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                                             '品名ﾏｽﾀ.　　       品名
    '            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESERVE,0) XSYUKKA_KON_RESERVE "   '出荷指示詳細.  　　出荷引当梱数
    '            strSQL &= vbCrLf & "  , NVL(XPLN_OUT_DTL.XSYUKKA_KON_H_RESULT, 0) XSYUKKA_KON_H_RESULT" '出荷指示詳細.      出荷実績梱数
    '            strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FPLAN_KEY "                                        '出荷指示詳細.      計画ｷｰ


    '            '============================================================
    '            'FROM
    '            '============================================================
    '            strSQL &= vbCrLf & " FROM "
    '            strSQL &= vbCrLf & "    XPLN_OUT_DTL "           '【出荷指示詳細】
    '            strSQL &= vbCrLf & "  , TMST_ITEM "              '【品目ﾏｽﾀ】

    '            '============================================================
    '            'WHERE
    '            '============================================================
    '            strSQL &= vbCrLf & " WHERE "
    '            strSQL &= vbCrLf & "         1 = 1 "
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = '" & XHENSEI_NO_OYA & "' "       '出荷指示詳細 を 親編成No. で特定
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_D = '" & XSYUKKA_D & "' "                 '出荷指示詳細 を 出荷日 で特定
    '            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "               '出荷指示詳細 と 品目ﾏｽﾀ を 品目ｺｰﾄﾞ で結合

    '            '============================================================
    '            'ORDER BY
    '            '============================================================
    '            strSQL &= vbCrLf & " ORDER BY "
    '            strSQL &= vbCrLf & "         XPLN_OUT_DTL.XOUT_ORDER "                                      '出荷指示詳細.  　　車輌内出荷品目順

    '            '-----------------------
    '            '抽出
    '            '-----------------------
    '            gobjDb.SQL = strSQL
    '            objDataSet.Clear()
    '            strDataSetName = "XPLN_OUT_DTL"
    '            gobjDb.GetDataSet(strDataSetName, objDataSet)


    '            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
    '                For Each objRow In objDataSet.Tables(strDataSetName).Rows

    '                    Dim strXHENSEI_NO As String = ""                '編成No.
    '                    Dim strXDENPYOU_NO As String = ""               '伝票No.
    '                    Dim strXOUT_ORDER As String = ""                '出庫順
    '                    Dim strXHINMEI_CD As String = ""                '品名ｺｰﾄﾞ
    '                    Dim strFHINMEI_CD As String = ""                '品名記号
    '                    Dim strFHINMEI As String = ""                   '品名
    '                    Dim strXSYUKKA_KON_RESERVE As String = ""       '出荷数
    '                    Dim strXSYUKKA_KON_H_RESULT As String = ""      '平置

    '                    'ﾃﾞｰﾀ部
    '                    strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
    '                    strXDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))
    '                    strXOUT_ORDER = TO_STRING(objRow("XOUT_ORDER"))
    '                    strXHINMEI_CD = TO_STRING(objRow("XHINMEI_CD"))
    '                    strFHINMEI_CD = TO_STRING(objRow("FHINMEI_CD"))
    '                    strFHINMEI = TO_STRING(objRow("FHINMEI"))
    '                    strXSYUKKA_KON_RESERVE = TO_STRING(objRow("XSYUKKA_KON_RESERVE"))
    '                    strXSYUKKA_KON_H_RESULT = TO_STRING(objRow("XSYUKKA_KON_H_RESULT"))

    '                    Dim strFPLAN_KEY As String = ""                 '計画ｷｰ
    '                    strFPLAN_KEY = TO_STRING(objRow("FPLAN_KEY"))


    '                    '************************************************************
    '                    ' SQL文作成 在庫引当情報取得
    '                    '************************************************************
    '                    Dim strSQL2 As String                        'SQL文
    '                    Dim objRow2 As DataRow                       '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
    '                    Dim strDataSetName2 As String                'ﾃﾞｰﾀｾｯﾄ名
    '                    Dim objTBLDataSet2 As New DataSet            'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

    '                    '============================================================
    '                    'SELECT
    '                    '============================================================
    '                    strSQL2 = ""
    '                    strSQL2 &= vbCrLf & " SELECT "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                           '在庫引当情報.  　　    計画ｷｰ
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    '                    strSQL2 &= vbCrLf & "  , SUM(NVL(TSTS_HIKIATE.FTR_VOL,0)) AS FTR_VOL_SUM "  '在庫引当情報.          搬送管理量合計
    '                    strSQL2 &= vbCrLf & "  , COUNT(0) AS FTR_VOL_PL "                           '在庫引当情報.          PL数
    '                    ' ''strSQL2 &= vbCrLf & "  , TSTS_HIKIATE.FPALLET_ID "                          '在庫引当情報.          ﾊﾟﾚｯﾄID

    '                    '============================================================
    '                    'FROM
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " FROM "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE "           '【在庫引当情報】
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF "           '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】

    '                    '============================================================
    '                    'WHERE
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " WHERE "
    '                    strSQL2 &= vbCrLf & "         1 = 1 "
    '                    strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = '" & strFPLAN_KEY & "' "             '引当情報 を 計画ｷｰ で特定
    '                    'strSQL2 &= vbCrLf & "     AND TSTS_HIKIATE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID "           '引当情報 と ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ を ﾊﾟﾚｯﾄID で結合

    '                    '============================================================
    '                    'GROUP BY
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " GROUP BY  "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '在庫引当情報.  　　計画ｷｰ
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

    '                    '============================================================
    '                    'ORDER BY
    '                    '============================================================
    '                    strSQL2 &= vbCrLf & " ORDER BY  "
    '                    strSQL2 &= vbCrLf & "    TSTS_HIKIATE.FPLAN_KEY "                    '在庫引当情報.  　　計画ｷｰ
    '                    'strSQL2 &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    '                    strSQL2 &= vbCrLf

    '                    '-----------------------
    '                    '抽出
    '                    '-----------------------
    '                    gobjDb.SQL = strSQL2
    '                    objTBLDataSet2.Clear()
    '                    strDataSetName2 = "TSTS_HIKIATE"
    '                    gobjDb.GetDataSet(strDataSetName2, objTBLDataSet2)

    '                    Dim intFTR_VOL_CONVEYOR As Integer = 0     '出荷ｺﾝﾍﾞﾔ
    '                    Dim intFTR_VOL_CONVEYOR_PL As Integer = 0  '出荷ｺﾝﾍﾞﾔ(PL数)

    '                    If objTBLDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
    '                        For Each objRow2 In objTBLDataSet2.Tables(strDataSetName2).Rows

    '                            ' ''Dim strFTRK_BUF_NO As String        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
    '                            Dim strFTR_VOL_SUM As String        '搬送数
    '                            Dim strFTR_VOL_PL As String         '搬送数(PL)

    '                            ' ''strFTRK_BUF_NO = TO_STRING(objRow2("FTRK_BUF_NO"))
    '                            strFTR_VOL_SUM = TO_STRING(objRow2("FTR_VOL_SUM"))
    '                            strFTR_VOL_PL = TO_STRING(objRow2("FTR_VOL_PL"))

    '                            intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '出荷ｺﾝﾍﾞﾔ
    '                            intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '出荷ｺﾝﾍﾞﾔ(PL数)

    '                            '' ''Select Case strFTRK_BUF_NO
    '                            '' ''    Case FTRK_BUF_NO_J9000
    '                            '' ''        '(自動倉庫の場合)
    '                            '' ''        intFTR_VOL_CONVEYOR = intFTR_VOL_CONVEYOR + TO_INTEGER(strFTR_VOL_SUM)      '出荷ｺﾝﾍﾞﾔ
    '                            '' ''        intFTR_VOL_CONVEYOR_PL = intFTR_VOL_CONVEYOR_PL + TO_INTEGER(strFTR_VOL_PL) '出荷ｺﾝﾍﾞﾔ(PL数)
    '                            '' ''    Case FTRK_BUF_NO_J9100, FTRK_BUF_NO_J9200
    '                            '' ''        '(平置、検品ｴﾘｱの場合)
    '                            '' ''        'intFTR_VOL_HIRAOKI = intFTR_VOL_HIRAOKI + TO_INTEGER(strFTR_VOL_SUM)        '平置
    '                            '' ''    Case Else
    '                            '' ''End Select

    '                        Next
    '                    End If

    '                    '***********************************************
    '                    ' ﾃﾞｰﾀ部分作成
    '                    '***********************************************
    '                    Dim objDataRow As clsPrintDataSet.DataTable01Row
    '                    objDataRow = objDataSet.DataTable01.NewRow

    '                    objDataRow.BeginEdit()

    '                    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ ﾃﾞｰﾀ部
    '                    objDataRow.Data00 = strXHENSEI_NO                   '編成No.
    '                    objDataRow.Data01 = strXDENPYOU_NO                  '伝票No.
    '                    objDataRow.Data02 = strXOUT_ORDER                   '出庫順
    '                    objDataRow.Data03 = strXHINMEI_CD                   '品名ｺｰﾄﾞ
    '                    objDataRow.Data04 = strFHINMEI_CD                   '品名記号
    '                    objDataRow.Data05 = strFHINMEI                      '品名
    '                    objDataRow.Data06 = strXSYUKKA_KON_RESERVE          '出荷数
    '                    objDataRow.Data07 = TO_STRING(intFTR_VOL_CONVEYOR) & "(" & TO_STRING(intFTR_VOL_CONVEYOR_PL) & ")"  '出荷ｺﾝﾍﾞﾔ(PL数)
    '                    objDataRow.Data08 = strXSYUKKA_KON_H_RESULT         '平置

    '                    objDataRow.EndEdit()

    '                    objDataSet.DataTable01.Rows.Add(objDataRow)

    '                Next
    '            End If

    '            '***********************************************
    '            ' ﾍｯﾀﾞｰ部分作成
    '            '***********************************************
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))          '発行日時
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXSYARYOU_NO", strXSYARYOU_NO)                            '車番
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXBERTH", strXBERTH_NO)                                   'ﾊﾞｰｽ

    '            Select Case strXTUMI_HOUHOU                                                                         '積込方法
    '                Case TO_STRING(XTUMI_HOUHOU_JP)
    '                    strXTUMI_HOUHOU = "パレット"
    '                Case TO_STRING(XTUMI_HOUHOU_JB)
    '                    strXTUMI_HOUHOU = "バラ"
    '                Case TO_STRING(XTUMI_HOUHOU_JL)
    '                    strXTUMI_HOUHOU = "ローダ"
    '            End Select
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUHOU", strXTUMI_HOUHOU)

    '            Select Case strXTUMI_HOUKOU                                                                         '積込方向
    '                Case TO_STRING(XTUMI_HOUKOU_JBACK)
    '                    strXTUMI_HOUKOU = "後積"
    '                Case TO_STRING(XTUMI_HOUKOU_JSIDE)
    '                    strXTUMI_HOUKOU = "片横積"
    '                Case TO_STRING(XTUMI_HOUKOU_JWING)
    '                    strXTUMI_HOUKOU = "両横積"
    '                Case TO_STRING(XTUMI_HOUKOU_JALL)
    '                    strXTUMI_HOUKOU = "ALL"
    '            End Select
    '            Call gobjComFuncFRM.ChangeCRText(objCR, "crXTUMI_HOUKOU", strXTUMI_HOUKOU)

    '            '***********************************************
    '            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
    '            '***********************************************
    '            objCR.SetDataSource(objDataSet)

    '            '***********************************************
    '            ' 印字
    '            '***********************************************
    '            Call gobjComFuncFRM.CRPrint(objCR)

    '        Catch ex As Exception
    '            Throw ex

    '        Finally

    '            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
    '            objCR.Dispose()
    '            objCR = Nothing
    '            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
    '            objDataSet.Dispose()
    '            objDataSet = Nothing

    '            If DispWait Then
    '                Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除
    '            End If

    '        End Try

    '        If blnCheckErr = True Then
    '            Return False
    '        Else
    '            Return True
    '        End If

    '    End Function

#End Region

#Region "  包材出庫設定ﾁｪｯｸ              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 包材出庫設定ﾁｪｯｸ
    ''' </summary>
    ''' <param name="FTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</param>
    ''' <returns>設定中=True 未設定=False</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Check_XSTS_WRAPPING_MATERIAL(ByVal FTRK_BUF_NO As String) As Boolean

        Dim blnReturn As Boolean = False    '返り値

        Dim intRet As Integer
        Dim objTBL_XSTS_WRAPPING_MATERIAL As New TBL_XSTS_WRAPPING_MATERIAL(gobjOwner, gobjDb, Nothing)
        objTBL_XSTS_WRAPPING_MATERIAL.FTRK_BUF_NO = FTRK_BUF_NO     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        intRet = objTBL_XSTS_WRAPPING_MATERIAL.GET_XSTS_WRAPPING_MATERIAL(False)
        If intRet = RetCode.OK Then
            '(該当あり)
            Dim strFHINMEI_CD As String = ""
            strFHINMEI_CD = TO_STRING(objTBL_XSTS_WRAPPING_MATERIAL.FHINMEI_CD)

            If strFHINMEI_CD = "" Then
                '(包材出庫設定なし)
                blnReturn = False

            Else
                '(包材出庫設定あり)
                blnReturn = True

            End If

        Else
            '(その他)
            blnReturn = False
        End If

        Return blnReturn

    End Function
#End Region


#Region "  ﾊﾞｰｽ毎の欠品有無取得               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽ毎の欠品有無取得
    ''' </summary>
    ''' <param name="strXBERTH_NO">対象ﾊﾞｰｽNo.</param>
    ''' <returns>True=欠品あり False=欠品なし</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BERTH_GetKeppin(ByVal strXBERTH_NO As String) As Boolean
        Dim strSQL As String                'SQL文
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim blnReturn As Boolean = False    '戻り値

        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                  '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XHENSEI_NO XHENSEI_NO"                '出荷ﾊﾞｰｽ状況.  編成No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_STS XBERTH_STS"                '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽ指示状況

        strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '出荷指示.  積込方法
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        strSQL &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '出荷指示.  出庫開始日時
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '出荷指示.  出荷状況
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                         '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT "                                           '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO"      '出荷指示　と　出荷ﾊﾞｰｽ状況　を　編成No.　で結合
        strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D"            '出荷指示　と　出荷ﾊﾞｰｽ状況　を　出荷日　 で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & TO_STRING(strXBERTH_NO) & "' "     '出荷指示.ﾊﾞｰｽNo = 「指定されたﾊﾞｰｽNo」

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XHENSEI_NO"       '出荷指示.      編成No

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '************************************************
                ' 欠品判定
                '************************************************
                If TO_STRING(objRow("XSYUKKA_STS")) = XSYUKKA_STS_JLESS Then
                    blnReturn = True
                    Exit For
                End If
            Next
        End If

        Return blnReturn

    End Function
#End Region
#Region "  ﾊﾞｰｽ毎の編成No.取得関数            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽ毎の編成No.取得関数
    ''' </summary>
    ''' <param name="strXBERTH_NO">対象ﾊﾞｰｽNo.</param>
    ''' <returns>編成No.(最大4つ)</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function BERTH_GetHENSEI_NO(ByVal strXBERTH_NO As String) As String()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim strHENSEI_NO(3) As String                   '編成No.(最大4つ)
        Dim jj As Integer = 0

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    XPLN_OUT.XHENSEI_NO "                                      '出荷指示.          編成No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_LEVEL "                                   '出荷指示.          緊急度
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                               '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT "                                                 '【出荷指示】
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_BERTH.XSYUKKA_D = XPLN_OUT.XSYUKKA_D(+) "         '出荷ﾊﾞｰｽ状況　と　出荷指示　を　出荷日　　 で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA(+) "   '出荷ﾊﾞｰｽ状況　と　出荷指示　を　編成No.　　で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL "

        '-----------------------
        '抽出
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "PLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                strHENSEI_NO(jj) = TO_STRING(objRow("XHENSEI_NO"))
                jj = jj + 1
            Next
        End If

        Return strHENSEI_NO

    End Function
#End Region
#Region "  ﾊﾞｰｽ毎の残PL数 取得                "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽ毎の残PL数 取得
    ''' </summary>
    ''' <param name="strXBERTH_NO">対象ﾊﾞｰｽNo</param>
    ''' <returns>残PL数</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function BERTH_GetPLCount(ByVal strXBERTH_NO As String) As Integer

        Dim intReturn As Integer = 0                    '残PL数

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        '出荷指示詳細.出荷予定梱数と品名ﾏｽﾀ.標準積付梱数よりﾊﾟﾚｯﾄ数算出
        Dim intPal As Integer = 0                   'ﾊﾟﾚｯﾄ数
        Dim intPal_mod As Double

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                             '出荷ﾊﾞｰｽ状況.     ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL.FHINMEI_CD FHINMEI_CD"                         '出荷指示詳細.     品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FNUM_IN_PALLET FNUM_IN_PALLET"                    '品目ﾏｽﾀ.          PL毎積載数"
        strSQL &= vbCrLf & "  , (NVL(XPLN_OUT_DTL.XSYUKKA_KON_PLAN, 0) - NVL(XPLN_OUT_DTL.XSYUKKA_KON_RESULT, 0)) XSYUKKA_KON_PLAN"  '出荷指示詳細.  出荷予定梱数
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                                       '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "                                                     '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TMST_ITEM "                                                        '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_BERTH.XSYUKKA_D = XPLN_OUT_DTL.XSYUKKA_D(+) "             '出荷ﾊﾞｰｽ状況　と　出荷指示詳細　を　出荷日　　 で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XHENSEI_NO = XPLN_OUT_DTL.XHENSEI_NO_OYA(+) "       '出荷ﾊﾞｰｽ状況　と　出荷指示詳細　を　編成No.　　で結合
        strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "            '出荷指示詳細　と　品名ﾏｽﾀ       を　品目ｺｰﾄﾞ   で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "

        '-----------------------
        '抽出
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                If TO_STRING(objRow("FHINMEI_CD")) <> "" Then
                    '(品目コードが存在する場合)
                    If TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) = 0 Then
                        '(予定数が0の場合)
                        intPal = 0
                    ElseIf TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) Mod TO_NUMBER(objRow("FNUM_IN_PALLET")) = 0 Then

                        intPal = (TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) / TO_NUMBER(objRow("FNUM_IN_PALLET")))
                    Else
                        intPal_mod = 1 + (TO_NUMBER(objRow("XSYUKKA_KON_PLAN")) \ TO_NUMBER(objRow("FNUM_IN_PALLET")))
                        intPal = TO_NUMBER(intPal_mod)
                    End If
                End If

                intReturn = intReturn + intPal
            Next
        End If

        BERTH_GetPLCount = intReturn

    End Function
#End Region
#Region "  ﾊﾞｰｽ毎の出庫中PL数 取得          　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽ毎の出庫中PL数 取得
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function COUNT_SYUKKO(ByVal strXBERTH_NO As String) As Long

        Dim strSQL As String                            'SQL文
        Dim RetCount As Long                            '返り値

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_STS_DTL XSYUKKA_STS_DTL"             '出荷指示詳細.  　　出荷状況詳細(状態)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "             '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "           '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TSTS_HIKIATE "           '【在庫引当情報】
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "           '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】

        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "         XPLN_OUT_DTL.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D "                '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 出荷日 で結合
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO "          '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 親編成No. で結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FSAGYOU_KIND = XPLN_OUT_DTL.FSAGYOU_KIND "        '在庫引当情報 と 出荷指示詳細 を 作業種別 で結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = XPLN_OUT_DTL.FPLAN_KEY "              '在庫引当情報 と 出荷指示詳細 を 計画ｷｰ で結合
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TSTS_HIKIATE.FPALLET_ID "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 出荷指示詳細 を ﾊﾟﾚｯﾄID で結合
        strSQL &= vbCrLf & "     AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "                '出荷ﾊﾞｰｽ状況 を ﾊﾞｰｽNo で結合
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & FTRK_BUF_NO_J3201 & "' "       '出庫中

        '********************************************************************
        'ﾃﾞｰﾀ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '出庫中合計
        '********************************************************************
        RetCount = objDataSet.Tables(strDataSetName).Rows.Count

        Return RetCount

    End Function

#End Region
#Region "  ﾊﾞｰｽ毎の搬送中PL数 取得          　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 搬送中PL数 取得
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function COUNT_HANSOUTYUU(ByVal strXBERTH_NO As String) As Long

        Dim strSQL As String                            'SQL文
        Dim RetCount As Long                            '返り値

        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT_DTL.XSYUKKA_STS_DTL XSYUKKA_STS_DTL"             '出荷指示詳細.  　　出荷状況詳細(状態)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "             '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & "  , XPLN_OUT_DTL "           '【出荷指示詳細】
        strSQL &= vbCrLf & "  , TSTS_HIKIATE "           '【在庫引当情報】
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "           '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】

        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "         XPLN_OUT_DTL.XSYUKKA_D = XSTS_BERTH.XSYUKKA_D "                '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 出荷日 で結合
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XHENSEI_NO_OYA = XSTS_BERTH.XHENSEI_NO "          '出荷指示詳細 と 出荷ﾊﾞｰｽ状況 を 親編成No. で結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FSAGYOU_KIND = XPLN_OUT_DTL.FSAGYOU_KIND "        '在庫引当情報 と 出荷指示詳細 を 作業種別 で結合
        strSQL &= vbCrLf & "     AND TSTS_HIKIATE.FPLAN_KEY = XPLN_OUT_DTL.FPLAN_KEY "              '在庫引当情報 と 出荷指示詳細 を 計画ｷｰ で結合
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TSTS_HIKIATE.FPALLET_ID "            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 出荷指示詳細 を ﾊﾟﾚｯﾄID で結合
        strSQL &= vbCrLf & "     AND XSTS_BERTH.XBERTH_NO = '" & strXBERTH_NO & "' "                '出荷ﾊﾞｰｽ状況 を ﾊﾞｰｽNo で結合
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = '" & FTRK_BUF_NO_J3401 & "' "       '搬送中

        '********************************************************************
        'ﾃﾞｰﾀ取得
        '********************************************************************
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名

        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT_DTL"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '********************************************************************
        '搬送中合計
        '********************************************************************
        RetCount = objDataSet.Tables(strDataSetName).Rows.Count

        Return RetCount

    End Function

#End Region

#Region "  ﾊﾞｰｽｸﾞﾙｰﾌﾟ毎のｺﾝﾍﾞﾔ用途取得        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽｸﾞﾙｰﾌﾟ毎のｺﾝﾍﾞﾔ用途取得
    ''' </summary>
    ''' <param name="strXBERTH_GROUP">ﾊﾞｰｽｸﾞﾙｰﾌﾟ</param>
    ''' <returns>ｺﾝﾍﾞﾔ用途</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function GetXCONVEYOR_YOUTO(ByVal strXBERTH_GROUP As String) As String

        Dim strSQL As String                            'SQL文
        'Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim strXCONVEYOR_YOUTO As String = ""           'ｺﾝﾍﾞﾔ用途

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT DISTINCT "
        strSQL &= vbCrLf & "    XSTS_CONVEYOR.XCONVEYOR_YOUTO "                             '出荷ｺﾝﾍﾞﾔ状況.          ｺﾝﾍﾞﾔ用途
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_CONVEYOR "                                             '【出荷ｺﾝﾍﾞﾔ状況】
        strSQL &= vbCrLf & "  , XSTS_BERTH "                                                '【出荷ﾊﾞｰｽ状況】
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XSTS_CONVEYOR.XBERTH_GROUP = XSTS_BERTH.XBERTH_GROUP "  '出荷ｺﾝﾍﾞﾔ状況　と　出荷ﾊﾞｰｽ状況　を　ﾊﾞｰｽｸﾞﾙｰﾌﾟ　　 で結合
        strSQL &= vbCrLf & "    AND XSTS_BERTH.XBERTH_GROUP = '" & strXBERTH_GROUP & "' "   '

        '-----------------------
        '抽出
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "XSTS_CONVEYOR"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            strXCONVEYOR_YOUTO = TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XCONVEYOR_YOUTO")))
        End If

        Select Case strXCONVEYOR_YOUTO
            Case XCONVEYOR_YOUTO_JPALLET
                '(ﾊﾟﾚｯﾄのとき)
                strXCONVEYOR_YOUTO = "パレ"

            Case XCONVEYOR_YOUTO_JBARA
                '(ﾊﾞﾗのとき)
                strXCONVEYOR_YOUTO = "バラ"

            Case XCONVEYOR_YOUTO_JINOUT
                '(設定入出庫のとき)
                strXCONVEYOR_YOUTO = "設定"

            Case XCONVEYOR_YOUTO_JDOWN
                '(ﾀﾞｳﾝのとき)
                strXCONVEYOR_YOUTO = "切離"
        End Select

        Return strXCONVEYOR_YOUTO

    End Function
#End Region

#Region "  入庫ST 入庫要求・端数ﾌﾗｸﾞﾁｪｯｸ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入庫ST 入庫要求・端数ﾌﾗｸﾞﾁｪｯｸ
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.</param>
    ''' <param name="intPattern">入庫ﾊﾟﾀｰﾝ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function Check_IN_HASU_FLAG(ByVal strFTRK_BUF_NO As String, ByVal intPattern As Integer) As Boolean

        Dim intRet As Integer
        Dim strMsg As String
        Dim strSQL As String                            'SQL文
        'Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim strXEQ_ID_IN_FR As String = ""              '入庫要求前設備ID
        Dim strXEQ_ID_IN_BK As String = ""              '入庫要求後設備ID
        Dim strXEQ_ID_HASU_FR As String = ""            '端数前設備ID
        Dim strXEQ_ID_HASU_BK As String = ""            '端数後設備ID

        Dim intXEQ_ID_IN_FR_STS As Integer              '入庫要求前設備ID
        Dim intXEQ_ID_IN_BK_STS As Integer              '入庫要求後設備ID
        Dim intXEQ_ID_HASU_FR_STS As Integer            '端数前設備ID
        Dim intXEQ_ID_HASU_BK_STS As Integer            '端数後設備ID

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    FTRK_BUF_NO "                                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.          ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        strSQL &= vbCrLf & "  , XEQ_ID_IN_FR "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.          入庫要求前設備ID
        strSQL &= vbCrLf & "  , XEQ_ID_IN_BK "                                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.          入庫要求後設備ID
        strSQL &= vbCrLf & "  , XEQ_ID_HASU_FR "                                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.          端数前設備ID
        strSQL &= vbCrLf & "  , XEQ_ID_HASU_BK "                                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.          端数後設備ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                                                  '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        TMST_TRK.FTRK_BUF_NO = " & strFTRK_BUF_NO               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNoで特定

        '-----------------------
        '抽出
        '-----------------------
        objDataSet.Clear()
        gobjDb.SQL = strSQL
        strDataSetName = "TMST_TRK"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            strXEQ_ID_IN_FR = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_IN_FR"))))
            strXEQ_ID_IN_BK = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_IN_BK"))))
            strXEQ_ID_HASU_FR = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_HASU_FR"))))
            strXEQ_ID_HASU_BK = (TO_STRING(((objDataSet.Tables(strDataSetName).Rows(0))("XEQ_ID_HASU_BK"))))
        Else
            '(見つからない場合)
            strMsg = ERRMSG_NOTFOUND_TMST_BUF & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo:" & strFTRK_BUF_NO & "]"
            Throw New System.Exception(strMsg)
        End If


        If strXEQ_ID_HASU_FR <> "" And strXEQ_ID_HASU_BK <> "" Then
            '(端数ﾁｪｯｸ有り)

            Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)

            '入庫要求前設備ID
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_FR
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_IN_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '入庫要求後設備ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_BK
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_IN_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '端数前設備ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_HASU_FR
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_HASU_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()

            '端数後設備ID
            objTBL_TSTS_EQ_CTRL = New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
            objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_HASU_BK
            objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
                Throw New System.Exception(strMsg)
            End If

            intXEQ_ID_HASU_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            objTBL_TSTS_EQ_CTRL.Close()



            '入庫ﾊﾟﾀｰﾝと信号が一致しているか確認
            Select Case intPattern
                Case 1
                    '(満PLを2つ入庫)
                    If intXEQ_ID_IN_FR_STS = 1 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 0 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 2
                    '(満PLと端数PLの入庫)
                    If intXEQ_ID_IN_FR_STS = 1 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 1 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 3
                    '(満PLを1つ入庫)
                    If intXEQ_ID_IN_FR_STS = 0 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 0 Then

                        Check_IN_HASU_FLAG = True
                    End If

                Case 4
                    '(端数PLを1つ入庫)
                    If intXEQ_ID_IN_FR_STS = 0 And _
                       intXEQ_ID_IN_BK_STS = 1 And _
                       intXEQ_ID_HASU_FR_STS = 0 And _
                       intXEQ_ID_HASU_BK_STS = 1 Then

                        Check_IN_HASU_FLAG = True
                    End If

            End Select

        Else
            '(端数ﾁｪｯｸなし)

            Check_IN_HASU_FLAG = True

            '' ''Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)

            ' '' ''入庫要求前設備ID
            '' ''objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_FR
            '' ''objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(見つからない場合)
            '' ''    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
            '' ''    Throw New System.Exception(strMsg)
            '' ''End If

            '' ''intXEQ_ID_IN_FR_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            '' ''objTBL_TSTS_EQ_CTRL.Close()

            ' '' ''入庫要求後設備ID
            '' ''objTBL_TSTS_EQ_CTRL.FEQ_ID = strXEQ_ID_IN_BK
            '' ''objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
            '' ''If intRet = RetCode.NotFound Then
            '' ''    '(見つからない場合)
            '' ''    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[設備ID:" & objTBL_TSTS_EQ_CTRL.FEQ_ID & "]"
            '' ''    Throw New System.Exception(strMsg)
            '' ''End If

            '' ''intXEQ_ID_IN_BK_STS = objTBL_TSTS_EQ_CTRL.FEQ_STS
            '' ''objTBL_TSTS_EQ_CTRL.Close()

        End If

        Return Check_IN_HASU_FLAG

    End Function
#End Region


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************



End Class
