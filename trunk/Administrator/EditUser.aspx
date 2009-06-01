<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Register" %>
--%><%@ Page Language="C#" MasterPageFile="~/Master/Dizajn.Master" AutoEventWireup="true"
    CodeFile="EditUser.aspx.cs" Inherits="Register" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
    <div>
        <table border="0">
            <tr>
                <td>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                Urejanje uporabnika
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Uporabniško 
                    ime:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="Zahtevano je uporabnisko ime." ToolTip="User Name is required."
                                    ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Naslov
                            </td>
                            <td>
                                <asp:TextBox ID="Naslov" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredAddress" runat="server" ControlToValidate="Naslov"
                                    ErrorMessage="RequiredAddress" ToolTip="RequiredAddress" ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                EMŠO
                            </td>
                            <td>
                                <asp:TextBox ID="Emso" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredEmso" runat="server" ControlToValidate="Emso"
                                    ErrorMessage="Required EMSO" ToolTip="Required EMSO" ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Davčna
                            </td>
                            <td>
                                <asp:TextBox ID="Davcna" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredDavcna" runat="server" ControlToValidate="Davcna"
                                    ErrorMessage="Required Davcna" ToolTip="Required Davcna" ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Vloga:
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownVloge" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" class="style1">
                                <asp:Button ID="ButtonYes" runat="server" Text="Potrdi spremembe" OnClick="ButtonYes_Click" />
                                <asp:Button ID="ButtonNo" runat="server" Text="Nazaj" OnClick="ButtonNo_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2">
                                            Spremeni geslo uporabnika
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Geslo:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                ErrorMessage="New Password is required." ToolTip="New Password is required."
                                                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Potrdi geslo:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="Gesli se morata ujemati."
                                                ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="LabelEnd" runat="server" Text="NOT VISIBLE" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                Text="Spremeni geslo" ValidationGroup="ChangePassword1" OnClick="ChangePasswordPushButton_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%--</div>  --%>
                </td>
                <td>
                    <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" Text="Uporabnik prejme resetirano geslo na email." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" OnClick="ResetPassword_Click" Text="Ponastavi geslo" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</asp:Content>
