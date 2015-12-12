<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="EM_2008" Title="Untitled Page" Codebehind="EM_2008.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<script src="JavaScript/Base.js" type="text/javascript"></script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
	<div style="float:left;">
		<%--Aktuell ställning--%>
		<table cellpadding="0" cellspacing="0" style="color:#D3D3D3;" class="emTable">
			<tr style="background-color:#111111;">
				<td>Pacering</td>
				<td>Antal poäng</td>
				<td>Deltagare</td>
				<td>Excel</td>
				<td>Form</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1</td>
				<td>133</td>
				<td>Janne</td><%--Janne--%>
				<td class="excel"><a href="EM/Jan_Lundholm.xls">&radic;</a></td>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2</td>
				<td>125</td>
				<td>Denise</td><%--Denise--%>
				<td class="excel"><a href="EM/Denise_Hansson.xls">&radic;</a></td>
				<td class="excel">&nbsp;</td>
				<%--<td class="excel"><img src="Bilder/Em_2008/arrow-up-small.png" style="height:13px;" alt="form" /></td>--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2</td>
				<td>125</td>
				<td>Gustav & Carmen</td><%--Gustav & Carmen--%>
				<td class="excel"><a href="EM/Gustavs_och_Carmens.xls">&radic;</a></td>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>4</td>
				<td>81</td>
				<td>Rickard</td><%--Rickard--%>
				<td class="excel"><a href="EM/Rickard_Persson.xls">&radic;</a></td>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>5</td>
				<td>80</td>
				<td>Daniel</td><%--Daniel--%>
				<td class="excel"><a href="EM/Daniel_Sagrera.xls">&radic;</a></td>
				<td class="excel">&nbsp;</td>
			</tr>
		</table>
	</div>
	
	<%--<div style="float:left; clear:both; margin-top:30px;">
		<span onclick="$(getElementById('hit')).scrollTo();">ScrollTo</span><br />
		<span onclick="toggle(getElementById('rounds'))">Toggle</span><br />
		<span onclick="$('rounds').toggle();">Toggle rounds</span><br />
	</div>--%>
	
	<div id="rounds" style="float:left; clear:both; margin-top:50px;">
		<table cellpadding="0" cellspacing="0" style="color:#D3D3D3;" class="emTable">
			<tr style="background-color:#111111;">
				<td>Omgång</td>
				<td>Daniel</td>
				<td>Denise</td>
				<td>Gustav</td>
				<td>Janne</td>
				<td>Rickard</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1 - Grupp A</td><%--Omgång--%>
				<td class="points">6 p.</td><%--Daniel--%>
				<td class="points">5 p.</td><%--Denise--%>
				<td class="points">3 p.</td><%--Gustav--%>
				<td class="points">4 p.</td><%--Janne--%>
				<td class="points">3 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1 - Grupp B</td><%--Omgång--%>
				<td class="points">12 p.</td><%--Daniel--%>
				<td class="points">12 p.</td><%--Denise--%>
				<td class="points">10 p.</td><%--Gustav--%>
				<td class="points">12 p.</td><%--Janne--%>
				<td class="points">13 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1 - Grupp C</td><%--Omgång--%>
				<td class="points">14 p.</td><%--Daniel--%>
				<td class="points">13 p.</td><%--Denise--%>
				<td class="points">11 p.</td><%--Gustav--%>
				<td class="points">13 p.</td><%--Janne--%>
				<td class="points">14 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1 - Grupp D</td><%--Omgång--%>
				<td class="points">19 p.</td><%--Daniel--%>
				<td class="points">19 p.</td><%--Denise--%>
				<td class="points">18 p.</td><%--Gustav--%>
				<td class="points">18 p.</td><%--Janne--%>
				<td class="points">20 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2 - Grupp A</td><%--Omgång--%>
				<td class="points">21 p.</td><%--Daniel--%>
				<td class="points">22 p.</td><%--Denise--%>
				<td class="points">21 p.</td><%--Gustav--%>
				<td class="points">20 p.</td><%--Janne--%>
				<td class="points">27 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2 - Grupp B</td><%--Omgång--%>
				<td class="points">23 p.</td><%--Daniel--%>
				<td class="points">22 p.</td><%--Denise--%>
				<td class="points">22 p.</td><%--Gustav--%>
				<td class="points">21 p.</td><%--Janne--%>
				<td class="points">32 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2 - Grupp C</td><%--Omgång--%>
				<td class="points">27 p.</td><%--Daniel--%>
				<td class="points">24 p.</td><%--Denise--%>
				<td class="points">23 p.</td><%--Gustav--%>
				<td class="points">21 p.</td><%--Janne--%>
				<td class="points">40 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2 - Grupp D</td><%--Omgång--%>
				<td class="points">33 p.</td><%--Daniel--%>
				<td class="points">28 p.</td><%--Denise--%>
				<td class="points">28 p.</td><%--Gustav--%>
				<td class="points">27 p.</td><%--Janne--%>
				<td class="points">43 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>3 - Grupp A</td><%--Omgång--%>
				<td class="points">34 p.</td><%--Daniel--%>
				<td class="points">28 p.</td><%--Denise--%>
				<td class="points">28 p.</td><%--Gustav--%>
				<td class="points">27 p.</td><%--Janne--%>
				<td class="points">43 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>3 - Grupp B</td><%--Omgång--%>
				<td class="points">37 p.</td><%--Daniel--%>
				<td class="points">31 p.</td><%--Denise--%>
				<td class="points">30 p.</td><%--Gustav--%>
				<td class="points">35 p.</td><%--Janne--%>
				<td class="points">47 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>3 - Grupp C</td><%--Omgång--%>
				<td class="points">42 p.</td><%--Daniel--%>
				<td class="points">35 p.</td><%--Denise--%>
				<td class="points">34 p.</td><%--Gustav--%>
				<td class="points">41 p.</td><%--Janne--%>
				<td class="points">50 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>3 - Grupp D</td><%--Omgång--%>
				<td class="points">43 p.</td><%--Daniel--%>
				<td class="points">37 p.</td><%--Denise--%>
				<td class="points">37 p.</td><%--Gustav--%>
				<td class="points">44 p.</td><%--Janne--%>
				<td class="points">53 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>Vidare grupp A</td><%--Omgång--%>
				<td class="points">46 p.</td><%--Daniel--%>
				<td class="points">40 p.</td><%--Denise--%>
				<td class="points">38 p.</td><%--Gustav--%>
				<td class="points">47 p.</td><%--Janne--%>
				<td class="points">58 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>Vidare grupp B</td><%--Omgång--%>
				<td class="points">48 p.</td><%--Daniel--%>
				<td class="points">41 p.</td><%--Denise--%>
				<td class="points">39 p.</td><%--Gustav--%>
				<td class="points">49 p.</td><%--Janne--%>
				<td class="points">59 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>Vidare grupp C</td><%--Omgång--%>
				<td class="points">53 p.</td><%--Daniel--%>
				<td class="points">42 p.</td><%--Denise--%>
				<td class="points">42 p.</td><%--Gustav--%>
				<td class="points">50 p.</td><%--Janne--%>
				<td class="points">62 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>Vidare grupp D</td><%--Omgång--%>
				<td class="points">56 p.</td><%--Daniel--%>
				<td class="points">45 p.</td><%--Denise--%>
				<td class="points">45 p.</td><%--Gustav--%>
				<td class="points">53 p.</td><%--Janne--%>
				<td class="points">65 p.</td><%--Rickard--%>
			</tr>
			
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Portugal vs. Tyskland 2-3">Vidare kvartsfinal 1 - Tyskland</td><%--Omgång--%>
				<td class="points">64 p.</td><%--Daniel--%>
				<td class="points">53 p.</td><%--Denise--%>
				<td class="points">53 p.</td><%--Gustav--%>
				<td class="points">61 p.</td><%--Janne--%>
				<td class="points">73 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Kroatien vs. Turkiet 0-0, 1-1(OT), 2-4(AP)">Vidare kvartsfinal 2 - Turkiet</td><%--Omgång--%>
				<td class="points">64 p.</td><%--Daniel--%>
				<td class="points">53 p.</td><%--Denise--%>
				<td class="points">53 p.</td><%--Gustav--%>
				<td class="points">61 p.</td><%--Janne--%>
				<td class="points">73 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Holland vs. Ryssland 1-1, 1-3(OT)">Vidare kvartsfinal 3 - Ryssland</td><%--Omgång--%>
				<td class="points">64 p.</td><%--Daniel--%>
				<td class="points">53 p.</td><%--Denise--%>
				<td class="points">53 p.</td><%--Gustav--%>
				<td class="points">61 p.</td><%--Janne--%>
				<td class="points">73 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Spanien vs. Italien 0-0, 0-0(OT), 4-2(AP)">Vidare kvartsfinal 4 - Spanien</td><%--Omgång--%>
				<td class="points">64 p.</td><%--Daniel--%>
				<td class="points">61 p.</td><%--Denise--%>
				<td class="points">61 p.</td><%--Gustav--%>
				<td class="points">69 p.</td><%--Janne--%>
				<td class="points">81 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Tyskland vs. Turkiet 3-2">Vidare semifinal 1 - Tyskland</td><%--Omgång--%>
				<td class="points">80 p.</td><%--Daniel--%>
				<td class="points">77 p.</td><%--Denise--%>
				<td class="points">77 p.</td><%--Gustav--%>
				<td class="points">85 p.</td><%--Janne--%>
				<td class="points">81 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Ryssland vs. Spanien 0-3">Vidare semifinal 2 - Spanien</td><%--Omgång--%>
				<td class="points">80 p.</td><%--Daniel--%>
				<td class="points">93 p.</td><%--Denise--%>
				<td class="points">93 p.</td><%--Gustav--%>
				<td class="points">101 p.</td><%--Janne--%>
				<td class="points">81 p.</td><%--Rickard--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td title="Tyskland vs. Spanien 0-1">Vinnare EM 2008 - Spanien</td><%--Omgång--%>
				<td class="points">80 p.</td><%--Daniel--%>
				<td class="points">125 p.</td><%--Denise--%>
				<td class="points">125 p.</td><%--Gustav--%>
				<td class="points">133 p.</td><%--Janne--%>
				<td class="points">81 p.</td><%--Rickard--%>
			</tr>
		</table>
		
		<%--Chart--%>
	    <div id="pointChart" style="width:600px; height:300px; margin:40px 0 40px 0;">
	    </div>
	</div>
	
	

</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>--%>

