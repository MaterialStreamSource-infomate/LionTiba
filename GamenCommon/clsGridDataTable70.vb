'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�󎚗p�ް�ð���
' �y�쐬�zSIT
'**********************************************************************************************

Public Class clsGridDataTable70
    Inherits DataTable

#Region "  �ݽ�׸�      "
    Public Sub New()
        MyBase.new()     '�e�׽�̺ݽ�׸�������

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
        Me.Columns.Add("Data51")
        Me.Columns.Add("Data52")
        Me.Columns.Add("Data53")
        Me.Columns.Add("Data54")
        Me.Columns.Add("Data55")
        Me.Columns.Add("Data56")
        Me.Columns.Add("Data57")
        Me.Columns.Add("Data58")
        Me.Columns.Add("Data59")
        Me.Columns.Add("Data60")
        Me.Columns.Add("Data61")
        Me.Columns.Add("Data62")
        Me.Columns.Add("Data63")
        Me.Columns.Add("Data64")
        Me.Columns.Add("Data65")
        Me.Columns.Add("Data66")
        Me.Columns.Add("Data67")
        Me.Columns.Add("Data68")
        Me.Columns.Add("Data69")
        Me.Columns.Add("Data70")

    End Sub
#End Region

#Region "  �ް���Ăֈ�s�ް��ǉ�"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ް���Ăֈ�s�ް��ǉ�
    ''' </summary>
    ''' <param name="strData00">�ް���Ăɾ�Ă���÷���ް�00</param>
    ''' <param name="strData01">�ް���Ăɾ�Ă���÷���ް�02</param>
    ''' <param name="strData02">�ް���Ăɾ�Ă���÷���ް�03</param>
    ''' <param name="strData03">�ް���Ăɾ�Ă���÷���ް�04</param>
    ''' <param name="strData04">�ް���Ăɾ�Ă���÷���ް�05</param>
    ''' <param name="strData05">�ް���Ăɾ�Ă���÷���ް�06</param>
    ''' <param name="strData06">�ް���Ăɾ�Ă���÷���ް�06</param>
    ''' <param name="strData07">�ް���Ăɾ�Ă���÷���ް�07</param>
    ''' <param name="strData08">�ް���Ăɾ�Ă���÷���ް�08</param>
    ''' <param name="strData09">�ް���Ăɾ�Ă���÷���ް�09</param>
    ''' <param name="strData10">�ް���Ăɾ�Ă���÷���ް�10</param>
    ''' <param name="strData11">�ް���Ăɾ�Ă���÷���ް�11</param>
    ''' <param name="strData12">�ް���Ăɾ�Ă���÷���ް�12</param>
    ''' <param name="strData13">�ް���Ăɾ�Ă���÷���ް�13</param>
    ''' <param name="strData14">�ް���Ăɾ�Ă���÷���ް�14</param>
    ''' <param name="strData15">�ް���Ăɾ�Ă���÷���ް�15</param>
    ''' <param name="strData16">�ް���Ăɾ�Ă���÷���ް�16</param>
    ''' <param name="strData17">�ް���Ăɾ�Ă���÷���ް�17</param>
    ''' <param name="strData18">�ް���Ăɾ�Ă���÷���ް�18</param>
    ''' <param name="strData19">�ް���Ăɾ�Ă���÷���ް�19</param>
    ''' <param name="strData20">�ް���Ăɾ�Ă���÷���ް�20</param>
    ''' <param name="strData21">�ް���Ăɾ�Ă���÷���ް�21</param>
    ''' <param name="strData22">�ް���Ăɾ�Ă���÷���ް�22</param>
    ''' <param name="strData23">�ް���Ăɾ�Ă���÷���ް�23</param>
    ''' <param name="strData24">�ް���Ăɾ�Ă���÷���ް�24</param>
    ''' <param name="strData25">�ް���Ăɾ�Ă���÷���ް�25</param>
    ''' <param name="strData26">�ް���Ăɾ�Ă���÷���ް�26</param>
    ''' <param name="strData27">�ް���Ăɾ�Ă���÷���ް�27</param>
    ''' <param name="strData28">�ް���Ăɾ�Ă���÷���ް�28</param>
    ''' <param name="strData29">�ް���Ăɾ�Ă���÷���ް�29</param>
    ''' <param name="strData30">�ް���Ăɾ�Ă���÷���ް�30</param>
    ''' <param name="strData31">�ް���Ăɾ�Ă���÷���ް�31</param>
    ''' <param name="strData32">�ް���Ăɾ�Ă���÷���ް�32</param>
    ''' <param name="strData33">�ް���Ăɾ�Ă���÷���ް�33</param>
    ''' <param name="strData34">�ް���Ăɾ�Ă���÷���ް�34</param>
    ''' <param name="strData35">�ް���Ăɾ�Ă���÷���ް�35</param>
    ''' <param name="strData36">�ް���Ăɾ�Ă���÷���ް�36</param>
    ''' <param name="strData37">�ް���Ăɾ�Ă���÷���ް�37</param>
    ''' <param name="strData38">�ް���Ăɾ�Ă���÷���ް�38</param>
    ''' <param name="strData39">�ް���Ăɾ�Ă���÷���ް�39</param>
    ''' <param name="strData40">�ް���Ăɾ�Ă���÷���ް�40</param>
    ''' <param name="strData41">�ް���Ăɾ�Ă���÷���ް�41</param>
    ''' <param name="strData42">�ް���Ăɾ�Ă���÷���ް�42</param>
    ''' <param name="strData43">�ް���Ăɾ�Ă���÷���ް�43</param>
    ''' <param name="strData44">�ް���Ăɾ�Ă���÷���ް�44</param>
    ''' <param name="strData45">�ް���Ăɾ�Ă���÷���ް�45</param>
    ''' <param name="strData46">�ް���Ăɾ�Ă���÷���ް�46</param>
    ''' <param name="strData47">�ް���Ăɾ�Ă���÷���ް�47</param>
    ''' <param name="strData48">�ް���Ăɾ�Ă���÷���ް�48</param>
    ''' <param name="strData49">�ް���Ăɾ�Ă���÷���ް�49</param>
    ''' <param name="strData50">�ް���Ăɾ�Ă���÷���ް�50</param>
    ''' <param name="strData51">�ް���Ăɾ�Ă���÷���ް�51</param>
    ''' <param name="strData52">�ް���Ăɾ�Ă���÷���ް�52</param>
    ''' <param name="strData53">�ް���Ăɾ�Ă���÷���ް�53</param>
    ''' <param name="strData54">�ް���Ăɾ�Ă���÷���ް�54</param>
    ''' <param name="strData55">�ް���Ăɾ�Ă���÷���ް�55</param>
    ''' <param name="strData56">�ް���Ăɾ�Ă���÷���ް�56</param>
    ''' <param name="strData57">�ް���Ăɾ�Ă���÷���ް�57</param>
    ''' <param name="strData58">�ް���Ăɾ�Ă���÷���ް�58</param>
    ''' <param name="strData59">�ް���Ăɾ�Ă���÷���ް�59</param>
    ''' <param name="strData60">�ް���Ăɾ�Ă���÷���ް�60</param>
    ''' <param name="strData61">�ް���Ăɾ�Ă���÷���ް�61</param>
    ''' <param name="strData62">�ް���Ăɾ�Ă���÷���ް�62</param>
    ''' <param name="strData63">�ް���Ăɾ�Ă���÷���ް�63</param>
    ''' <param name="strData64">�ް���Ăɾ�Ă���÷���ް�64</param>
    ''' <param name="strData65">�ް���Ăɾ�Ă���÷���ް�65</param>
    ''' <param name="strData66">�ް���Ăɾ�Ă���÷���ް�66</param>
    ''' <param name="strData67">�ް���Ăɾ�Ă���÷���ް�67</param>
    ''' <param name="strData68">�ް���Ăɾ�Ă���÷���ް�68</param>
    ''' <param name="strData69">�ް���Ăɾ�Ă���÷���ް�69</param>
    ''' <param name="strData70">�ް���Ăɾ�Ă���÷���ް�70</param>
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
                                 Optional ByVal strData51 As String = "", _
                                 Optional ByVal strData52 As String = "", _
                                 Optional ByVal strData53 As String = "", _
                                 Optional ByVal strData54 As String = "", _
                                 Optional ByVal strData55 As String = "", _
                                 Optional ByVal strData56 As String = "", _
                                 Optional ByVal strData57 As String = "", _
                                 Optional ByVal strData58 As String = "", _
                                 Optional ByVal strData59 As String = "", _
                                 Optional ByVal strData60 As String = "", _
                                 Optional ByVal strData61 As String = "", _
                                 Optional ByVal strData62 As String = "", _
                                 Optional ByVal strData63 As String = "", _
                                 Optional ByVal strData64 As String = "", _
                                 Optional ByVal strData65 As String = "", _
                                 Optional ByVal strData66 As String = "", _
                                 Optional ByVal strData67 As String = "", _
                                 Optional ByVal strData68 As String = "", _
                                 Optional ByVal strData69 As String = "", _
                                 Optional ByVal strData70 As String = "", _
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
        objDataRow("Data51") = strData51
        objDataRow("Data52") = strData52
        objDataRow("Data53") = strData53
        objDataRow("Data54") = strData54
        objDataRow("Data55") = strData55
        objDataRow("Data56") = strData56
        objDataRow("Data57") = strData57
        objDataRow("Data58") = strData58
        objDataRow("Data59") = strData59
        objDataRow("Data60") = strData60
        objDataRow("Data61") = strData61
        objDataRow("Data62") = strData62
        objDataRow("Data63") = strData63
        objDataRow("Data64") = strData64
        objDataRow("Data65") = strData65
        objDataRow("Data66") = strData66
        objDataRow("Data67") = strData67
        objDataRow("Data68") = strData68
        objDataRow("Data69") = strData69
        objDataRow("Data70") = strData70
        objDataRow.EndEdit()

        Me.Rows.Add(objDataRow)

    End Sub
#End Region

End Class
