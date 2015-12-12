<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="VM_2010" Title="Untitled Page" CodeBehind="VM_2010.aspx.cs" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
	
	<div style="float:left;">
		<%--Aktuell ställning--%>
		<h2 style="font-family:Garamond">Aktuell pängställning</h2>
		<br />
		<table cellpadding="0" cellspacing="0" style="color:#D3D3D3;" class="emTable">
			<tr style="background-color:#111111;">
				<td>Pacering</td>
				<td>Antal poäng</td>
				<td>Deltagare</td>
				<td>Form</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>1</td>
				<td>65</td>
				<td>Peter</td><%--Peter--%>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2</td>
				<td>50</td>
				<td>Daniel</td><%--Daniel--%>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>3</td>
				<td>47</td>
				<td>Janne</td><%--Janne--%>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>4</td>
				<td>44</td>
				<td>Denise</td><%--Denise--%>
				<td class="excel">&nbsp;</td>
				<%--<td class="excel"><img src="Bilder/Em_2008/arrow-up-small.png" style="height:13px;" alt="form" /></td>--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>5</td>
				<td>42</td>
				<td>Gustav</td><%--Gustav--%>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>5</td>
				<td>42</td>
				<td>Markus</td><%--Markus--%>
				<td class="excel">&nbsp;</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>7</td>
				<td>39</td>
				<td>Jonas</td><%--Jonas--%>
				<td class="excel">&nbsp;</td>
			</tr>
		</table>
	</div>
	
	
	
	<%--Historik--%>
	<div id="rounds" style="float:left; clear:both; margin-top:50px;">
		<h2 style="font-family:Garamond">Historik</h2>
		<br />
		<table cellpadding="0" cellspacing="0" style="color:#D3D3D3;" class="emTable">
			<tr style="background-color:#111111;">
				<td>Omgång</td>
				<td>Daniel</td>
				<td>Denise</td>
				<td>Gustav</td>
				<td>Janne</td>
				<td>Jonas</td>
				<td>Markus</td>
				<td>Peter</td>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-19</td><%--Omgång--%>
				<td class="points">50 p.</td><%--Daniel--%>
				<td class="points">44 p.</td><%--Denise--%>
				<td class="points">42 p.</td><%--Gustav--%>
				<td class="points">47 p.</td><%--Janne--%>
				<td class="points">39 p.</td><%--Jonas--%>
				<td class="points">42 p.</td><%--Markus--%>
				<td class="points">65 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-18</td><%--Omgång--%>
				<td class="points">43 p.</td><%--Daniel--%>
				<td class="points">39 p.</td><%--Denise--%>
				<td class="points">32 p.</td><%--Gustav--%>
				<td class="points">41 p.</td><%--Janne--%>
				<td class="points">34 p.</td><%--Jonas--%>
				<td class="points">38 p.</td><%--Markus--%>
				<td class="points">55 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-17</td><%--Omgång--%>
				<td class="points">42 p.</td><%--Daniel--%>
				<td class="points">33 p.</td><%--Denise--%>
				<td class="points">27 p.</td><%--Gustav--%>
				<td class="points">39 p.</td><%--Janne--%>
				<td class="points">29 p.</td><%--Jonas--%>
				<td class="points">34 p.</td><%--Markus--%>
				<td class="points">48 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-16</td><%--Omgång--%>
				<td class="points">39 p.</td><%--Daniel--%>
				<td class="points">29 p.</td><%--Denise--%>
				<td class="points">24 p.</td><%--Gustav--%>
				<td class="points">35 p.</td><%--Janne--%>
				<td class="points">26 p.</td><%--Jonas--%>
				<td class="points">30 p.</td><%--Markus--%>
				<td class="points">44 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-15</td><%--Omgång--%>
				<td class="points">32 p.</td><%--Daniel--%>
				<td class="points">25 p.</td><%--Denise--%>
				<td class="points">23 p.</td><%--Gustav--%>
				<td class="points">31 p.</td><%--Janne--%>
				<td class="points">25 p.</td><%--Jonas--%>
				<td class="points">25 p.</td><%--Markus--%>
				<td class="points">38 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-14</td><%--Omgång--%>
				<td class="points">26 p.</td><%--Daniel--%>
				<td class="points">19 p.</td><%--Denise--%>
				<td class="points">19 p.</td><%--Gustav--%>
				<td class="points">28 p.</td><%--Janne--%>
				<td class="points">19 p.</td><%--Jonas--%>
				<td class="points">22 p.</td><%--Markus--%>
				<td class="points">31 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-13</td><%--Omgång--%>
				<td class="points">19 p.</td><%--Daniel--%>
				<td class="points">12 p.</td><%--Denise--%>
				<td class="points">17 p.</td><%--Gustav--%>
				<td class="points">21 p.</td><%--Janne--%>
				<td class="points">13 p.</td><%--Jonas--%>
				<td class="points">14 p.</td><%--Markus--%>
				<td class="points">21 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-12</td><%--Omgång--%>
				<td class="points">9 p.</td><%--Daniel--%>
				<td class="points">5 p.</td><%--Denise--%>
				<td class="points">7 p.</td><%--Gustav--%>
				<td class="points">16 p.</td><%--Janne--%>
				<td class="points">9 p.</td><%--Jonas--%>
				<td class="points">6 p.</td><%--Markus--%>
				<td class="points">12 p.</td><%--Peter--%>
			</tr>
			<tr onmouseover="this.bgColor = '#111111';" onmouseout="this.bgColor = 'Black';">
				<td>2010-06-11</td><%--Omgång--%>
				<td class="points">5 p.</td><%--Daniel--%>
				<td class="points">1 p.</td><%--Denise--%>
				<td class="points">1 p.</td><%--Gustav--%>
				<td class="points">8 p.</td><%--Janne--%>
				<td class="points">4 p.</td><%--Jonas--%>
				<td class="points">1 p.</td><%--Markus--%>
				<td class="points">5 p.</td><%--Peter--%>
			</tr>
			
		</table>
		
		<%--Chart--%>
	    <div id="pointChart" style="width:600px; height:300px; margin:40px 0 40px 0;">
	    </div>
	</div>
	
</asp:Content>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>--%>
