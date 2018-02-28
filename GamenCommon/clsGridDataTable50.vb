'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】印字用ﾃﾞｰﾀﾃｰﾌﾞﾙ
' 【作成】SIT
'**********************************************************************************************

Public Class clsGridDataTable50
    Inherits DataTable

#Region "  ｺﾝｽﾄﾗｸﾀ      "
    Public Sub New()
        MyBase.new()     '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装

        Me.Columns.Add("Data00")
        Me.Columns.Add("Data01")
        Me.Columns.Add("Data02")
        Me.Columns.Add("Data03")
        Me.Columns.Add("Data04")
        Me.Columns.Add("Data05")
        Me.Columns.Add("Data06")
        Me.Columns.Add("Data07")
        Me.Columns.Add("Data08")
        Me.Columns.Add("Data09")
        Me.Columns.Add("Data10")
        Me.Columns.Add("Data11")
        Me.Columns.Add("Data12")
        Me.Columns.Add("Data13")
        Me.Columns.Add("Data14")
        Me.Columns.Add("Data15")
        Me.Columns.Add("Data16")
        Me.Columns.Add("Data17")
        Me.Columns.Add("Data18")
        Me.Columns.Add("Data19")
        Me.Columns.Add("Data20")
        Me.Columns.Add("Data21")
        Me.Columns.Add("Data22")
        Me.Columns.Add("Data23")
        Me.Columns.Add("Data24")
        Me.Columns.Add("Data25")
        Me.Columns.Add("Data26")
        Me.Columns.Add("Data27")
        Me.Columns.Add("Data28")
        Me.Columns.Add("Data29")
        Me.Columns.Add("Data30")
        Me.Columns.Add("Data31")
        Me.Columns.Add("Data32")
        Me.Columns.Add("Data33")
        Me.Columns.Add("Data34")
        Me.Columns.Add("Data35")
        Me.Columns.Add("Data36")
        Me.Columns.Add("Data37")
        Me.Columns.Add("Data38")
        Me.Columns.Add("Data39")
        Me.Columns.Add("Data40")
        Me.Columns.Add("Data41")
        Me.Columns.Add("Data42")
        Me.Columns.Add("Data43")
        Me.Columns.Add("Data44")
        Me.Columns.Add("Data45")
        Me.Columns.Add("Data46")
        Me.Columns.Add("Data47")
        Me.Columns.Add("Data48")
        Me.Columns.Add("Data49")
        Me.Columns.Add("Data50")

    End Sub
#End Region

#Region "  ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀｾｯﾄへ一行ﾃﾞｰﾀ追加
    ''' </summary>
    ''' <param name="strData00">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ00</param>
    ''' <param name="strData01">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ02</param>
    ''' <param name="strData02">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ03</param>
    ''' <param name="strData03">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ04</param>
    ''' <param name="strData04">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ05</param>
    ''' <param name="strData05">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ06</param>
    ''' <param name="strData06">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ06</param>
    ''' <param name="strData07">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ07</param>
    ''' <param name="strData08">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ08</param>
    ''' <param name="strData09">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ09</param>
    ''' <param name="strData10">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ10</param>
    ''' <param name="strData11">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ11</param>
    ''' <param name="strData12">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ12</param>
    ''' <param name="strData13">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ13</param>
    ''' <param name="strData14">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ14</param>
    ''' <param name="strData15">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ15</param>
    ''' <param name="strData16">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ16</param>
    ''' <param name="strData17">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ17</param>
    ''' <param name="strData18">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ18</param>
    ''' <param name="strData19">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ19</param>
    ''' <param name="strData20">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ20</param>
    ''' <param name="strData21">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ21</param>
    ''' <param name="strData22">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ22</param>
    ''' <param name="strData23">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ23</param>
    ''' <param name="strData24">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ24</param>
    ''' <param name="strData25">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ25</param>
    ''' <param name="strData26">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ26</param>
    ''' <param name="strData27">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ27</param>
    ''' <param name="strData28">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ28</param>
    ''' <param name="strData29">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ29</param>
    ''' <param name="strData30">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ30</param>
    ''' <param name="strData31">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ31</param>
    ''' <param name="strData32">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ32</param>
    ''' <param name="strData33">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ33</param>
    ''' <param name="strData34">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ34</param>
    ''' <param name="strData35">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ35</param>
    ''' <param name="strData36">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ36</param>
    ''' <param name="strData37">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ37</param>
    ''' <param name="strData38">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ38</param>
    ''' <param name="strData39">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ39</param>
    ''' <param name="strData40">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ40</param>
    ''' <param name="strData41">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ41</param>
    ''' <param name="strData42">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ42</param>
    ''' <param name="strData43">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ43</param>
    ''' <param name="strData44">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ44</param>
    ''' <param name="strData45">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ45</param>
    ''' <param name="strData46">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ46</param>
    ''' <param name="strData47">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ47</param>
    ''' <param name="strData48">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ48</param>
    ''' <param name="strData49">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ49</param>
    ''' <param name="strData50">ﾃﾞｰﾀｾｯﾄにｾｯﾄするﾃｷｽﾄﾃﾞｰﾀ50</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub userAddRowDataSet(Optional ByVal strData00 As String = "", _
                                 Optional ByVal strData01 As String = "", _
                                 Optional ByVal strData02 As String = "", _
                                 Optional ByVal strData03 As String = "", _
                                 Optional ByVal strData04 As String = "", _
                                 Optional ByVal strData05 As String = "", _
                                 Optional ByVal strData06 As String = "", _
                                 Optional ByVal strData07 As String = "", _
                                 Optional ByVal strData08 As String = "", _
                                 Optional ByVal strData09 As String = "", _
                                 Optional ByVal strData10 As String = "", _
                                 Optional ByVal strData11 As String = "", _
                                 Optional ByVal strData12 As String = "", _
                                 Optional ByVal strData13 As String = "", _
                                 Optional ByVal strData14 As String = "", _
                                 Optional ByVal strData15 As String = "", _
                                 Optional ByVal strData16 As String = "", _
                                 Optional ByVal strData17 As String = "", _
                                 Optional ByVal strData18 As String = "", _
                                 Optional ByVal strData19 As String = "", _
                                 Optional ByVal strData20 As String = "", _
                                 Optional ByVal strData21 As String = "", _
                                 Optional ByVal strData22 As String = "", _
                                 Optional ByVal strData23 As String = "", _
                                 Optional ByVal strData24 As String = "", _
                                 Optional ByVal strData25 As String = "", _
                                 Optional ByVal strData26 As String = "", _
                                 Optional ByVal strData27 As String = "", _
                                 Optional ByVal strData28 As String = "", _
                                 Optional ByVal strData29 As String = "", _
                                 Optional ByVal strData30 As String = "", _
                                 Optional ByVal strData31 As String = "", _
                                 Optional ByVal strData32 As String = "", _
                                 Optional ByVal strData33 As String = "", _
                                 Optional ByVal strData34 As String = "", _
                                 Optional ByVal strData35 As String = "", _
                                 Optional ByVal strData36 As String = "", _
                                 Optional ByVal strData37 As String = "", _
                                 Optional ByVal strData38 As String = "", _
                                 Optional ByVal strData39 As String = "", _
                                 Optional ByVal strData40 As String = "", _
                                 Optional ByVal strData41 As String = "", _
                                 Optional ByVal strData42 As String = "", _
                                 Optional ByVal strData43 As String = "", _
                                 Optional ByVal strData44 As String = "", _
                                 Optional ByVal strData45 As String = "", _
                                 Optional ByVal strData46 As String = "", _
                                 Optional ByVal strData47 As String = "", _
                                 Optional ByVal strData48 As String = "", _
                                 Optional ByVal strData49 As String = "", _
                                 Optional ByVal strData50 As String = "", _
                                 )

        Dim objDataRow As DataRow = Me.NewRow

        objDataRow.BeginEdit()
        objDataRow("Data00") = strData00
        objDataRow("Data01") = strData01
        objDataRow("Data02") = strData02
        objDataRow("Data03") = strData03
        objDataRow("Data04") = strData04
        objDataRow("Data05") = strData05
        objDataRow("Data06") = strData06
        objDataRow("Data07") = strData07
        objDataRow("Data08") = strData08
        objDataRow("Data09") = strData09
        objDataRow("Data10") = strData10
        objDataRow("Data11") = strData11
        objDataRow("Data12") = strData12
        objDataRow("Data13") = strData13
        objDataRow("Data14") = strData14
        objDataRow("Data15") = strData15
        objDataRow("Data16") = strData16
        objDataRow("Data17") = strData17
        objDataRow("Data18") = strData18
        objDataRow("Data19") = strData19
        objDataRow("Data20") = strData20
        objDataRow("Data21") = strData21
        objDataRow("Data22") = strData22
        objDataRow("Data23") = strData23
        objDataRow("Data24") = strData24
        objDataRow("Data25") = strData25
        objDataRow("Data26") = strData26
        objDataRow("Data27") = strData27
        objDataRow("Data28") = strData28
        objDataRow("Data29") = strData29
        objDataRow("Data30") = strData30
        objDataRow("Data31") = strData31
        objDataRow("Data32") = strData32
        objDataRow("Data33") = strData33
        objDataRow("Data34") = strData34
        objDataRow("Data35") = strData35
        objDataRow("Data36") = strData36
        objDataRow("Data37") = strData37
        objDataRow("Data38") = strData38
        objDataRow("Data39") = strData39
        objDataRow("Data40") = strData40
        objDataRow("Data41") = strData41
        objDataRow("Data42") = strData42
        objDataRow("Data43") = strData43
        objDataRow("Data44") = strData44
        objDataRow("Data45") = strData45
        objDataRow("Data46") = strData46
        objDataRow("Data47") = strData47
        objDataRow("Data48") = strData48
        objDataRow("Data49") = strData49
        objDataRow("Data50") = strData50
        objDataRow.EndEdit()

        Me.Rows.Add(objDataRow)

    End Sub
#End Region

End Class
