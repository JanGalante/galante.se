<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="CV" Title="Untitled Page" Codebehind="CV.aspx.cs" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
	CV
	<asp:GridView ID="GridView1" runat="server">
	</asp:GridView>
	<asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>--%>

