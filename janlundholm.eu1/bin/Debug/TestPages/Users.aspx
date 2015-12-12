<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="TestPages_Users" Title="Untitled Page" Codebehind="Users.aspx.cs" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">

    <asp:GridView ID="gvUsers" runat="server">
        <PagerTemplate>
            <asp:TextBox runat="server" ID="jdfk" Text="dff"></asp:TextBox>
        </PagerTemplate>
    </asp:GridView>
    
    <asp:GridView ID="gvWines" runat="server" />

</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>--%>

