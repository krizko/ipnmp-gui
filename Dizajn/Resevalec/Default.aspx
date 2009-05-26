<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Reševalec_Default" %>--%>
<%@ Page Language="C#" MasterPageFile="~/Dizajn.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Reševalec_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <form id="form1" runat="server">
    <div>
    
        Pozdravljen Reševalec<br />
    
    </div>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </form>
</asp:Content>