<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>--%>
<%@ Page Language="C#" MasterPageFile="~/Dizajn.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" Height="160px" PasswordLabelText="Geslo:" 
            PasswordRequiredErrorMessage="Geslo je obvezno." TitleText="Prijava" 
            UserNameLabelText="Uporabniško ime:" 
            UserNameRequiredErrorMessage="Uporabniško ime je obvezno." Width="320px" 
            RememberMeText="Zapomni si me na tem računalniku." 
            FailureText="Vaša prijava ni bila uspešna. Prosimo poskusite ponovno." 
            LoginButtonText="Prijava" onloggedin="Login1_LoggedIn">
        </asp:Login>
    
    </div>
    
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" 
    Text="Ni definirane vloge za tega uporabnika."></asp:Label>
    </asp:Panel>
    <br />
    </form>
</asp:Content>
