<%@ Page Language="C#" MasterPageFile="~/Master/DizajnWithSideBar.Master" AutoEventWireup="true" CodeFile="Porocila.aspx.cs" Inherits="Dizajn.Porocila" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="sidecontent" runat="server">
    <ul>
        <li><strong><a href="Porocila.aspx">Poročila</a></strong></li>
        <li><a href="?a=dodaj">Dodajanje poročila</a></li>
        <li><a href="?a=uredi">Urejanje poročila</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:MultiView ID="MultiView" runat="server">
    <asp:View ID="ViewPregled" runat="server">
    
    <form id="form1" runat="server">
    <h1>Štala ti mala</h1>
    <div>
        <%--<table style="border: 1px solid black; width: 100%;">
            <tr>
                <th>Datum</th>
                <th>Ponesrečenec</th>
                <th>Zdravnik</th>
                <th>Kraj</th>
            </tr>
            <tr>
                <td>1.5.2008</td>
                <td>Sandi Križanič</td>
                <td>Matej Zorko</td>
                <td>MB</td>
            </tr>
            <tr>
                <td>8.7.2008</td>
                <td>Igor Žižek</td>
                <td>Matej Zorko</td>
                <td>FERI</td>
            </tr>
        </table>--%>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1" width="100%">
                    <tr>
                        <th>Datum</th>
                        <th>Ponesrečenec</th>
                        <th>?Zdravnik?</th>
                        <th>Opis nesreče</th>
                        <th>Opcije</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
            <tr>
                <td><%--<%# DataBinder.Eval(Container.DataItem, "Datum") %>--%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Pacient.Ime") %> <%# DataBinder.Eval(Container.DataItem, "Pacient.Priimek") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "ŠtevilkaPoročila") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "OpisDogodka") %></td>
                <td><a href="?stPorocila=<%# DataBinder.Eval(Container.DataItem, "ŠtevilkaPoročila") %>">Uredi</a></td>
            </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
            &nbsp;
        </div>
    </form>
    </asp:View>
    
    
    
    <asp:View ID="NiPorocil" runat="server">
        <asp:Label ID="Label7" runat="server" Text="Žal trenutno ni poročil!"></asp:Label>
    </asp:View>
        <asp:View ID="ViewUrediDodaj" runat="server">
            <h1>
                Poročila</h1>
            <div>
                <form ID="form2" runat="server">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Datum" runat="server" Text="Datum"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediDatumBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Kraj" runat="server" Text="Kraj"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediKrajBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Ponesrecenec" runat="server" Text="Ponesrečenec"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediPonesrecenecBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Zdravnik" runat="server" Text="Zdravnik"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediZdravnikBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Stanje_opr" runat="server" Text="Stanje ob prihodu NMP"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediPrihodBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Stanje_ob_sprejetju" runat="server" Text="Stanje ob sprejemu"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediSprejemBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Datum Sprejema"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediDatumSprejemaBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Opis" runat="server" Text="Opis dogodka:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediOpisBox" runat="server" Height="204px" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Akcije" runat="server" Text="Akcije:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UrediAkcijeBox" runat="server" Height="204px" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </form>
            </div>
        </asp:View>
</asp:MultiView>
</asp:Content>

