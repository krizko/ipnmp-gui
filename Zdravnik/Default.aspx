<%@ Page Language="C#" MasterPageFile="~/Master/Dizajn.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Zdravnik_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <form id="form1" runat="server">
    Pozdravljen zdravnik.<br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Prijavi" 
        LogoutText="Odjavi" />
    <br />
    </form>
</asp:Content>

