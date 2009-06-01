<%@ Page Language="C#" MasterPageFile="~/Master/DizajnWithSideBar.Master" AutoEventWireup="true" CodeBehind="Kartoteka.aspx.cs" Inherits="Dizajn.Kartoteka" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="sidecontent" runat="server">
    <ul>
        <li><strong><a href="Kartoteka.aspx">Kartoteka</a></strong></li>
    </ul>
    <div>
        <strong>Iskanje kartoteke</strong>
        <form action="" method="post">
            <input type="text" name="isciKartoteko" /><br />
            <input type="submit" />
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
    <h1>Kartoteka</h1>
    <table style="width: 900px">
        <tr>
            <td colspan="2">
                <table style="width: 100%;">
                    <tr>
                        <td style="border: 1px solid black;">
                            <asp:Label ID="Label7" runat="server" Text="Ime in priimek"></asp:Label><br />
                            <asp:Label ID="Label8" runat="server" Text="Naslov"></asp:Label><br />
                            <asp:Label ID="Label9" runat="server" Text="Pošta"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Datum rojstva"></asp:Label>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
                            <asp:Label ID="Label11" runat="server" Text="Krvna skupina"></asp:Label>
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
                            <asp:Label ID="Label12" runat="server" Text="EMŠO"></asp:Label>
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Kronične bolezni"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Alergije"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Operacije"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Poškodbe"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Pripomočki"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Zgodovina"></asp:Label></td>
        </tr>
        <tr>
            <!-- SEM PRIDE ZGODOVINA -->
            <div>&nbsp;</div>
        </tr>
    </table>
    </form>
</asp:Content>
