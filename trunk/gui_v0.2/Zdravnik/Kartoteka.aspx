<%@ Page Language="C#" MasterPageFile="~/Master/DizajnWithSideBar.Master" AutoEventWireup="true" CodeFile="Kartoteka.aspx.cs" Inherits="Dizajn.Kartoteka" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="sidecontent" runat="server">
    <ul>
        <li><strong><a href="Kartoteka.aspx">Kartoteka</a></strong></li>
    </ul>
    <div>
        <strong>Iskanje kartoteke</strong>
        <form action="Kartoteka.aspx" method="get">
            <input type="hidden" name="a" value="iscemKartoteke" />
            <input type="text" name="iskalniNiz" maxlength="128" />
            <br />
            <input type="submit" value="Išči" />
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form2" runat="server">
        <asp:MultiView ID="pogledi" runat="server">
            <asp:View ID="intro" runat="server">
                <h1>Iskanje kartoteke</h1>
                <p>
                    Sistem za iskanje kartoteke. Preprosto vpišite emšo ali ime in priimek osebe, ki 
                    jo iščete v za to namenjeno okence na levi. Ko ste željen niz vnesli, pritisnite 
                    Išči in sistem vam bo vrnil rezultate.
                </p>
            </asp:View>
            <asp:View ID="rezultati" runat="server">
                <h1>Rezultati: prikaz najdenih kartotek</h1>
                <p><strong>Iskalni niz:</strong> <asp:Label ID="iskalniNiz" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;(<strong><asp:Label
                        ID="infoNiz" runat="server"></asp:Label></strong>)</p>
                <table style="width: 100%;">
                    <tr>
                        <th>&nbsp;</th><th>Ime/Priimek</th><th>EMŠO</th><th>Spol</th>
                    </tr>
                    <asp:Repeater ID="ponavljalec1" runat="server">
                    <ItemTemplate> 
                    <tr style="background: #ffffff;">
                        <td>[<a href="Kartoteka.aspx?a=prikaziKartoteko&id=<%#DataBinder.Eval(Container.DataItem, "IdPacienta")%>">pogled</a>]</td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Ime")%>
                            <%#DataBinder.Eval(Container.DataItem, "Priimek")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "EMŠO")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Spol")%>
                        </td>
                    </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <tr style="background: #fafafa;">
                        <td>[<a href="Kartoteka.aspx?a=prikaziKartoteko&id=<%#DataBinder.Eval(Container.DataItem, "IdPacienta")%>">pogled</a>]</td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Ime")%>
                            <%#DataBinder.Eval(Container.DataItem, "Priimek")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "EMŠO")%>
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Spol")%>
                        </td>
                    </tr>
                    </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
            </asp:View>
            <asp:View ID="niKartotek" runat="server">
                <h1>Rezultati: prikaz najdenih kartotek</h1>
                <p>
                    Iskanje je vrnilo 0 rezultatov.
                </p>
            </asp:View>
            <asp:View ID="niKartoteke" runat="server">
                <h1>Kartoteka</h1>
                <p>
                    Žal takšna kartoteka ne obstaja.
                </p>
                <asp:Label ID="errorInfo" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            </asp:View>
            <asp:View ID="kratoteka" runat="server">
                <h1>
                    Kartoteka</h1>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="ImePacienta" runat="server" Text="Ime pacienta"></asp:Label>
                            <br />
                            <asp:Label ID="PriimekPacienta" runat="server" Text="Priimek pacienta"></asp:Label>
                            <br />
                            <asp:Label ID="NaslovPacienta" runat="server" Text="Naslov pacienta"></asp:Label>
                            <br />
                            <asp:Label ID="PostaPacienta" runat="server" Text="Pošta pacienta"></asp:Label>
                            <br />
                        </td>
                        <td>
                            <asp:Label ID="DatumRojstvaPacienta" runat="server" 
                                Text="Datum rojstva pacienta"></asp:Label>
                            <br />
                            <asp:Label ID="EmsoPacienta" runat="server" Text="Emso pacienta"></asp:Label>
                            <br />
                            <asp:Label ID="KrvnaSkupinaPacienta" runat="server" 
                                Text="Krvna skupina pacienta"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
                <h3>
                    Kratka zgodovina pacienta</h3>
                <div>
                    % TODO %
                </div>
            </asp:View>
        </asp:MultiView>
    </form>
</asp:Content>
