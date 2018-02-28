'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｺﾞﾐ削除
' 【作成】SIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports MateCommon                         'SystemConfig使用の為
Imports MateCommon.clsConst                  'Configﾌｧｲﾙ読込み等標準ﾓｼﾞｭｰﾙ使用の為
Imports JobCommon
#End Region

Public Class SVR_999998
    Inherits clsTemplateServer

#Region "  ｸﾗｽ内部処理用変数定義                                                                "
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
#Region "  Dﾃｽﾄ  出荷指示ﾃｽﾄ                                                                    "
    ''**********************************************************************************************
    ''【機能】てすと
    ''【引数】[IN] msgRecv       ：要求ﾒｯｾｰｼﾞ
    ''　　　　[OUT]msgSend       ：応答ﾒｯｾｰｼﾞ
    ''【戻値】正常終了　         ： 0
    ''　　　　異常終了　         ： 1
    ''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As RetCode
    '    Try
    '        Dim intRet As RetCode                   '戻り値
    '        Dim dtmNow01 As Date = Now


    '        '********************************************************************************************************
    '        '************************************************
    '        'TMST_EQ_ERRORのFEQ_STSを変換
    '        '************************************************
    '        Dim objSVR_999003 As New SVR_999003(Owner, ObjDb, ObjDbLog)
    '        intRet = objSVR_999003.ExecCmd("", "")
    '        '********************************************************************************************************


    '        ''********************************************************************************************************
    '        ''************************************************
    '        ''出荷引当処理(ﾙｰﾄ)          実行
    '        ''************************************************
    '        'Dim objTemplateServer As New clsTemplateServer(Owner, ObjDb, ObjDbLog)

    '        'intRet = objTemplateServer.SyukkaHikiateRoot(CDate("2013/01/01 00:00:00"), "1", SyukkaHikiateMode.Pallet)
    '        ''intRet = objTemplateServer.SyukkaHikiateRoot(CDate("2013/01/02 00:00:00"), "1", SyukkaHikiateMode.Loader01)
    '        ''intRet = objTemplateServer.SyukkaHikiateRoot(CDate("2013/01/02 00:00:00"), "1", SyukkaHikiateMode.Loader02)
    '        ''********************************************************************************************************

    '        'If intRet <> RetCode.OK Then
    '        '    Throw New Exception("ﾌﾟﾛｸﾞﾗﾑｴﾗｰ発生")
    '        'End If


    '        Dim objDiff As TimeSpan = Now - dtmNow01
    '        Call AddToTrnLog(FUSER_ID_SKOTEI, FTERM_ID_SKOTEI, MeSyoriID, _
    '             FLOG_DATA_TRN_SEND_NORMAL _
    '             & "[処理時間:" & TO_STRING(TO_DECIMAL(objDiff.TotalMilliseconds / 1000)) & "]" _
    '             )


    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region
#Region "  Dﾃｽﾄ  原料在庫照合ﾃｰﾌﾞﾙｺﾋﾟｰ                                                          "
    ''**********************************************************************************************
    ''【機能】てすと
    ''【引数】[IN] msgRecv       ：要求ﾒｯｾｰｼﾞ
    ''　　　　[OUT]msgSend       ：応答ﾒｯｾｰｼﾞ
    ''【戻値】正常終了　         ： 0
    ''　　　　異常終了　         ： 1
    ''**********************************************************************************************
    'Public Overrides Function ExecCmd(ByVal msgRecv As String, ByRef msgSend As String) As Integer
    '    Try
    '        'Dim intRet As RetCode                   '戻り値
    '        AddToLog("開始", "", LogType.INFO)

    '        '***********************
    '        'ﾃｰﾌﾞﾙ削除
    '        '***********************
    '        Dim intRetSQL As Integer                'SQL実行戻り値
    '        intRetSQL = ObjDb.Execute("DELETE TLIF_TRK_BUF")
    '        If intRetSQL = -1 Then
    '            '(SQLｴﾗｰ)
    '            Throw New UserException("失敗")
    '        End If
    '        intRetSQL = ObjDb.Execute("DELETE TLIF_STOCK")
    '        If intRetSQL = -1 Then
    '            '(SQLｴﾗｰ)
    '            Throw New UserException("失敗")
    '        End If


    '        '************************
    '        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｺﾋﾟｰ
    '        '************************
    '        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '        Dim objTLIF_TRK_BUF As New TBL_TLIF_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '        objTPRG_TRK_BUF.USER_SQL = "SELECT * FROM TPRG_TRK_BUF"
    '        objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_USER()
    '        For ii As Integer = LBound(objTPRG_TRK_BUF.ARYME) To UBound(objTPRG_TRK_BUF.ARYME)
    '            objTLIF_TRK_BUF.COPY_PROPERTY(objTPRG_TRK_BUF.ARYME(ii))
    '            objTLIF_TRK_BUF.ADD_TLIF_TRK_BUF()
    '        Next


    '        '************************
    '        '在庫情報ｺﾋﾟｰ
    '        '************************
    '        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
    '        Dim objTLIF_STOCK As New TBL_TLIF_STOCK(Owner, ObjDb, ObjDbLog)
    '        objTRST_STOCK.USER_SQL = "SELECT * FROM TRST_STOCK"
    '        objTRST_STOCK.GET_TRST_STOCK_USER()
    '        For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
    '            objTLIF_STOCK.COPY_PROPERTY(objTRST_STOCK.ARYME(ii))
    '            objTLIF_STOCK.ADD_TLIF_STOCK()
    '        Next


    '        AddToLog("終了", "", LogType.INFO)
    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region
#Region "  Dﾃｽﾄ   安川PLCのCRCﾃｽﾄ                                                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' てすと
    ''' </summary>
    ''' <param name="strMSG_RECV">要求ﾒｯｾｰｼﾞ</param>
    ''' <param name="strMSG_SEND">応答ﾒｯｾｰｼﾞ</param>
    ''' <returns>正常終了：0 異常終了：1</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
        Try
            'Dim intRet As RetCode

            Try


                Dim strSendTel() As String = Split("03_03_fa_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_09_00_09_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_04_00_04_00_00_00_00_00_00_00_04_00_04_00_04_00_04_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00_00", "_")
                Dim strRecvTel(UBound(strSendTel)) As Byte
                Dim bytCRC(1) As Byte
                Dim strMsg As String


                '****************************************************
                '電文をﾊﾞｲﾄ配列にする
                '****************************************************
                For ii As Integer = 0 To UBound(strSendTel)
                    strRecvTel(ii) = Change16To10(strSendTel(ii))
                Next


                '========================================
                'CRCﾁｪｯｸ
                '========================================
                Dim bytCRCRecv(1) As Byte                   'CRC
                Dim bytTemp(strRecvTel.Length - 3) As Byte  'CRC作成用ﾃﾝﾎﾟﾗﾘ
                Array.Copy(strRecvTel, 0, bytTemp, 0, bytTemp.Length)
                Call MakeCRC(bytTemp, bytCRCRecv)
                strMsg = "判定ﾛｸﾞ[正常CRC:" & Change10To16(bytCRCRecv(0), 2) & Change10To16(bytCRCRecv(1), 2) & "]" _
                              & "[受信CRC:" & Change10To16(strRecvTel(UBound(strRecvTel) - 1), 2) & Change10To16(strRecvTel(UBound(strRecvTel) - 0), 2) & "]"
                If Not (bytCRCRecv(0) = strRecvTel(UBound(strRecvTel) - 1) And bytCRCRecv(1) = strRecvTel(UBound(strRecvTel) - 0)) Then
                    Call AddToLog("受信電文CRC異常[正常CRC:" & Change10To16(bytCRCRecv(0), 2) & Change10To16(bytCRCRecv(1), 2) & "]" _
                                               & "[受信CRC:" & Change10To16(strRecvTel(UBound(strRecvTel) - 1), 2) & Change10To16(strRecvTel(UBound(strRecvTel) - 0), 2) & "]", "", "")
                    'blnTelErr = True
                End If


            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Throw ex
            End Try

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Return RetCode.NG
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Return RetCode.NG
        End Try
    End Function
#End Region
#Region "  Dﾃｽﾄ   BC分解                                                                            "
    '''' *******************************************************************************************************************
    '''' <summary>
    '''' てすと
    '''' </summary>
    '''' <param name="strMSG_RECV">要求ﾒｯｾｰｼﾞ</param>
    '''' <param name="strMSG_SEND">応答ﾒｯｾｰｼﾞ</param>
    '''' <returns>正常終了：0 異常終了：1</returns>
    '''' <remarks></remarks>
    '''' *******************************************************************************************************************
    'Public Overrides Function ExecCmd(ByVal strMSG_RECV As String, ByRef strMSG_SEND As String) As RetCode
    '    Try
    '        'Dim intRet As RetCode

    '        Try

    '            Dim strHeader() As String = Nothing
    '            'Dim strMeisai01() As String = Nothing
    '            'Dim strMeisai02() As String = Nothing
    '            'Dim strMeisai03() As String = Nothing
    '            'Dim strMeisai04() As String = Nothing
    '            'Dim strMeisai05() As String = Nothing
    '            'Dim strMeisai06() As String = Nothing
    '            'Dim strXNUMBER As Integer
    '            MsgBox("aaa")



    '        Catch ex As UserException
    '            Call ComUser(ex, MeSyoriID)
    '            Throw ex
    '        End Try

    '    Catch ex As UserException
    '        Call ComUser(ex, MeSyoriID)
    '        Return RetCode.NG
    '    Catch ex As Exception
    '        Call ComError(ex, MeSyoriID)
    '        Return RetCode.NG
    '    End Try
    'End Function
#End Region


#Region "  CRC作成              "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' CRC作成
    ''' </summary>
    ''' <param name="strSendTel">送信電文</param>
    ''' <param name="bytCRC">CRC</param>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Sub MakeCRC(ByVal strSendTel() As Byte _
                     , ByRef bytCRC() As Byte _
                     )
        ReDim bytCRC(1)     '初期化


        '****************************************************
        'CRC        作成
        '****************************************************
        Dim shrKotei As UShort = 40961              '固定値(1010 0000 0000 0001)
        Dim shrCRC As UShort = UShort.MaxValue      'CRC
        For ii As Integer = 0 To UBound(strSendTel)
            '(ﾙｰﾌﾟ:ﾊﾞｲﾄ配列の数だけ)

            '=======================================
            '電文と仮CRCとのXor
            '=======================================
            shrCRC = shrCRC Xor strSendTel(ii)


            For jj As Integer = 1 To 8
                '(ﾙｰﾌﾟ:上位8ﾋﾞｯﾄ(実際には下位8ﾋﾞｯﾄ))


                If Microsoft.VisualBasic.Right(Change10To2(shrCRC, 16), 1) = "0" Then
                    '(0の場合)

                    '=======================================
                    '右ｼﾌﾄ
                    '2で割ると右ｼﾌﾄする
                    '=======================================
                    shrCRC = shrCRC \ 2

                Else
                    '(1の場合)

                    '=======================================
                    '右ｼﾌﾄ
                    '2で割ると右ｼﾌﾄする
                    '=======================================
                    shrCRC = shrCRC \ 2

                    '=======================================
                    '固定値と仮CRCとのXor
                    '=======================================
                    shrCRC = shrCRC Xor shrKotei

                End If


            Next

        Next


        '****************************************************
        '引数にｾｯﾄ
        '****************************************************
        bytCRC(0) = shrCRC Mod 256
        bytCRC(1) = shrCRC \ 256


    End Sub
#End Region

End Class
