<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Login" Title="Untitled Page" Codebehind="Login.aspx.cs" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
	<%--Login<br />--%>
	<asp:TextBox ID="tbxUsername" AutoPostBack="false" runat="server"></asp:TextBox><br />
	<asp:TextBox ID="tbxPassword" AutoPostBack="false" runat="server" TextMode="Password"></asp:TextBox>
	<asp:LinkButton ID="lbSignIn" PostBackUrl="~/Login.aspx?status=signIn" runat="server">Login</asp:LinkButton><br />
    <asp:TextBox ID="errorMessage" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" Width="400"></asp:TextBox>
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>--%>

