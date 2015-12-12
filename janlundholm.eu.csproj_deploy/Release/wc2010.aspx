<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="wc2010.aspx.cs" Inherits="janlundholm.eu.wc2010" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script src="JavaScript/jquery.js" type="text/javascript"></script>
	<script src="JavaScript/knockout.js" type="text/javascript"></script>
	<script src="JavaScript/jquery.jeditable.js" type="text/javascript"></script>
	<script src="JavaScript/section/wc2010.js" type="text/javascript"></script>
	<%--<script src="JavaScript/json.js" type="text/javascript"></script>--%>
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <h2>VM 2010</h2>
    
	<p>&nbsp;</p>
	<p><asp:Literal ID="litTest" runat="server" /></p>   
    
   <%-- <%--http://sv.wikipedia.org/wiki/National_Hockey_League_2010/2011--%>
    <%--http://sv.wikipedia.org/wiki/V%C3%A4rldsm%C3%A4sterskapet_i_fotboll_2010--%>
    <div id="wrapper" class="finals">
    
    <asp:Label ID="lblExcelValue" runat="server"></asp:Label>
    
		<%--Åttondelsfinaler--%>
		<asp:Repeater ID="rpEightFinals" runat="server">
			<HeaderTemplate>
				<div class="eightfinals">
			</HeaderTemplate>
				
			<ItemTemplate>
			<div id="<%# Eval("Id") %>" class="game">
				<div class="team">
					<div class="leftspace">&nbsp;</div>
					<div class="pairing"><%# Eval("Id") %></div>
					<div class="name"><%# ((BusinessLayer.wcGame)Container.DataItem).HomeTeam.Name %></div>
					<%--<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultHomeTeam %></div>--%>
					<div class="result<%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# this.GetResultHomeTeam(Container.DataItem) %></div>
					<div class="clear"><!-- --></div>
				</div>
				<div class="team">
					<div class="leftspace topline">&nbsp;</div>
					<div class="pairing topline"><%# Eval("Id") %></div>
					<div class="name topline"><%# ((BusinessLayer.wcGame)Container.DataItem).AwayTeam.Name %></div>
					<%--<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultAwayTeam %>--%>
					<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# this.GetResultAwayTeam(Container.DataItem) %></div>
					<div class="clear"><!-- --></div>
				</div>
				<asp:PlaceHolder ID="phGap" runat="server" Visible="<%# ((BusinessLayer.wcGameCollection)rpEightFinals.DataSource).Count - 1 == Container.ItemIndex ? false : true %>">
					<div class="gap <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><!-- --></div>
				</asp:PlaceHolder>
			</div>
			</ItemTemplate>
				
			<FooterTemplate>
				</div>
			</FooterTemplate>
		</asp:Repeater>
		
		<%--Kvartsfinaler--%>
		<asp:Repeater ID="rpQuarterfinals" runat="server">
			<HeaderTemplate>
				<div class="quarterfinals">
			</HeaderTemplate>
				
			<ItemTemplate>
				<div id="<%# Eval("Id") %>" class="game">
					<div class="team">
						<div class="leftspace">&nbsp;</div>
						<div class="pairing"><%# Eval("Id") %></div>
						<div class="name"><%# ((BusinessLayer.wcGame)Container.DataItem).HomeTeam.Name %></div>
						<%--<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultHomeTeam %></div>--%>
						<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# this.GetResultHomeTeam(Container.DataItem) %></div>
						<div class="clear"><!-- --></div>
					</div>
					<div class="team">
						<div class="leftspace topline">&nbsp;</div>
						<div class="pairing topline"><%# Eval("Id") %></div>
						<div class="name topline"><%# ((BusinessLayer.wcGame)Container.DataItem).AwayTeam.Name %></div>
						<%--<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultAwayTeam %>--%>
						<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# this.GetResultAwayTeam(Container.DataItem) %>
						</div>
						<div class="clear"><!-- --></div>
					</div>
					<asp:PlaceHolder ID="phGap" runat="server" Visible="<%# ((BusinessLayer.wcGameCollection)rpQuarterfinals.DataSource).Count - 1 == Container.ItemIndex ? false : true %>">
						<div class="gap <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><!-- --></div>
					</asp:PlaceHolder>
				</div>
			</ItemTemplate>
				
			<FooterTemplate>
				</div>
			</FooterTemplate>
		</asp:Repeater>
		
		<%--Semifinaler--%>
		<asp:Repeater ID="rpSemiFinals" runat="server">
			<HeaderTemplate>
				<div class="semifinals">
			</HeaderTemplate>

			<ItemTemplate>
				<div id="<%# Eval("Id") %>" class="game">
					<div class="team">
						<div class="leftspace">&nbsp;</div>
						<div class="pairing"><%# Eval("Id") %></div>
						<div class="name"><%# ((BusinessLayer.wcGame)Container.DataItem).HomeTeam.Name %></div>
						<%--<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultHomeTeam %></div>--%>
						<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# this.GetResultHomeTeam(Container.DataItem) %></div>
						<div class="clear"><!-- --></div>
					</div>
					<div class="team">
						<div class="leftspace topline">&nbsp;</div>
						<div class="pairing topline"><%# Eval("Id") %></div>
						<div class="name topline"><%# ((BusinessLayer.wcGame)Container.DataItem).AwayTeam.Name %></div>
						<%--<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultAwayTeam %>--%>
						<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# this.GetResultAwayTeam(Container.DataItem) %>
						</div>
						<div class="clear"><!-- --></div>
					</div>
					<asp:PlaceHolder ID="phGap" runat="server" Visible="<%# ((BusinessLayer.wcGameCollection)rpSemiFinals.DataSource).Count - 1 == Container.ItemIndex ? false : true %>">
						<div class="gap <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><!-- --></div>
					</asp:PlaceHolder>
				</div>
			</ItemTemplate>
				
			<FooterTemplate>
				</div>
			</FooterTemplate>
		</asp:Repeater>
		
		<%--final--%>
		<asp:Repeater ID="rpFinal" runat="server">
			<HeaderTemplate>
				<div class="final">
			</HeaderTemplate>
				
			<ItemTemplate>
				<div id="<%# Eval("Id") %>" class="game">
					<div class="team">
						<div class="leftspace">&nbsp;</div>
						<div class="pairing"><%# Eval("Id") %></div>
						<div class="name"><%# ((BusinessLayer.wcGame)Container.DataItem).HomeTeam.Name %></div>
						<%--<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultHomeTeam %></div>--%>
						<div class="result <%# Container.ItemIndex % 2 == 0 ? null : " rightline" %>"><%# this.GetResultHomeTeam(Container.DataItem) %></div>
						<div class="clear"><!-- --></div>
					</div>
					<div class="team">
						<div class="leftspace topline">&nbsp;</div>
						<div class="pairing topline"><%# Eval("Id") %></div>
						<div class="name topline"><%# ((BusinessLayer.wcGame)Container.DataItem).AwayTeam.Name %></div>
						<%--<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# ((BusinessLayer.wcGame)Container.DataItem).FinalResult.ResultAwayTeam %>--%>
						<div class="result topline <%# Container.ItemIndex % 2 == 0 ? " rightline" : null %>"><%# this.GetResultAwayTeam(Container.DataItem) %>
						</div>
						<div class="clear"><!-- --></div>
					</div>
				</div>
			</ItemTemplate>
				
			<FooterTemplate>
				</div>
			</FooterTemplate>
		</asp:Repeater>
		
		
		<div style="clear:both"><!-- --></div>
	    
	    <div style="margin-top:40px;">
			<input type="submit" id="finals" name="finals" value="Spara slutspelsträd" />
			<input type="submit" id="getExcel" name="finals" value="Hämta Excel" />
	    </div>
		<br />
		<hr />
   
    </div>
        
    <br />
    <hr />
   
   <%--Använder Knockout för att presentera json data--%>
   <div>
		Test
		<%--<table data-bind="foreach: teams">
			<tr>
				<td data-bind="text: name"></td>
			</tr>
		</table>--%>
   
		<table>
			<thead>
				<tr>
					<td>&nbsp;</td>
					<td>P</td>
					<td>W</td>
					<td>D</td>
					<td>L</td>
					<td>F</td>
					<td>A</td>
					<td>+-</td>
					<td>P</td>
				</tr>
			</thead>
			<tbody data-bind="foreach: teams">
				<tr>
					<td data-bind="text: name"></td>
					<td data-bind="text: gamesplayed"></td>
					<td data-bind="text: gameswon"></td>
					<td data-bind="text: gamesdraw"></td>
					<td data-bind="text: gameslost"></td>
					<td data-bind="text: goalsmade"></td>
					<td data-bind="text: goalsbackward"></td>
					<td data-bind="text: goaldifference"></td>
					<td data-bind="text: points"></td>
				</tr>    
			</tbody>
		</table>
		
		
		<%--<p>First name: <strong data-bind="text: firstName"></strong></p>
		<p>Last name: <strong data-bind="text: lastName"></strong></p>

		<p>First name: <input data-bind="value: firstName" /></p>
		<p>Last name: <input data-bind="value: lastName" /></p>--%>
   </div>
   
    
    <%--Repeater för alla grupper--%>
    <asp:Repeater ID="rptTournament" runat="server">
         <ItemTemplate>
            <%--Här kommer det ligga en liga<br />--%>
            <asp:Repeater ID="rptTournamentResults" runat="server" DataSource="<%#(BusinessLayer.wcGameCollection)Container.DataItem %>">
                <HeaderTemplate>
					<div class="games" rel="<%# this.GetGroupName(((RepeaterItem)Container.Parent.Parent).DataItem).Replace(" ", "-") %>">
					sjkf
                </HeaderTemplate>
                <ItemTemplate>
					<div class="game">
						<%--<%# Eval("Date") %>--%>
						<%# ((BusinessLayer.wcGame)Container.DataItem).Date.ToString("yyyy-MM-dd") %>
						<%# Eval("Channel") %>
						<img src="<%# this.GetImageUrlHomeTeam(Container.DataItem) %>" style="height:15px; margin-left:10px;" />
						<span class="name-hometeam"><%# this.GetHomeTeamName(Container.DataItem) %></span> - 
						<img src="<%# this.GetImageUrlAwayTeam(Container.DataItem) %>" style="height:15px;" />
						<span class="name-awayteam"><%# this.GetAwayTeamName(Container.DataItem) %></span>
						<%--<span class="result-hometeam editable"><%# this.GetResultHomeTeam(Container.DataItem) %></span> - 
						<span class="result-awayteam editable"><%# this.GetResultAwayTeam(Container.DataItem) %></span>--%>
						<span class="editable" id="<%# Eval("Id") %>" style="margin-left:10px;"><%# this.GetResultHomeTeam(Container.DataItem) %> - <%# this.GetResultAwayTeam(Container.DataItem) %></span>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
					</div>
                </FooterTemplate>  
            </asp:Repeater>            

            Här kommer en tabell att ligga<br />
            <asp:Repeater ID="Repeater1" runat="server" DataSource="<%#((BusinessLayer.wcGameCollection)Container.DataItem).Teams %>">
                <HeaderTemplate>
                    <table id="<%#  this.GetGroupName(((RepeaterItem)Container.Parent.Parent).DataItem).Replace(" ", "-") %>">
                        <tr>
                            <td>&nbsp;</td>
                            <td>P</td>
                            <td>W</td>
                            <td>D</td>
                            <td>L</td>
                            <td>F</td>
                            <td>A</td>
                            <td>+-</td>
                            <td>P</td>
                            <%--<td style="display:none;">posistion</td>--%>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr class="<%# Container.ItemIndex + 1 %>">
                            <td class="name"><%# Eval("Name") %></td>
                            <td><%# Eval("GamesPlayed") %></td>
                            <td><%# Eval("GamesWon")%></td>
                            <td><%# Eval("GamesDraw")%></td>
                            <td><%# Eval("GamesLost")%></td>
                            <td><%# Eval("GoalsMade")%></td>
                            <td><%# Eval("GoalsBackward")%></td>
                            <td><%# ((BusinessLayer.wcTeam)Container.DataItem).GoalsMade - ((BusinessLayer.wcTeam)Container.DataItem).GoalsBackward%></td>
                            <td><%# Eval("Points") %></td>
                            <%--<td style="display:none;"><%# Container.ItemIndex %></td>--%>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <br />
                    <hr />
                    <br />
                </FooterTemplate>
            </asp:Repeater>
            
        </ItemTemplate>            
    </asp:Repeater>
    

    
</asp:Content>
<%--
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>--%>
