<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>--%>
<%@ Page Language="C#" MasterPageFile="~/Dizajn.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
    <div>
    
    <asp:CreateUserWizard ID="CreateUserWizard" runat="server" 
            AnswerLabelText="Skrivni odgovor:" 
            CancelButtonType="Button" CancelButtonText="Prekliči"
            DisplayCancelButton = "true" CancelDestinationPageUrl = "Default.aspx"   
            CompleteSuccessText="Vaš račun je bil uspešno ustvarjen." 
            ConfirmPasswordLabelText="Potrdite geslo:" CreateUserButtonText="Ustvari račun" 
            DuplicateEmailErrorMessage="E-mail naslov, ki ste ga vnesli je že v uporabi. Prosimo vnesite drug e-mail naslov." 
            DuplicateUserNameErrorMessage="Prosimo vnesite drugo uporabniško ime." 
            FinishCompleteButtonText="Končaj" 
            InvalidAnswerErrorMessage="Prosimo vnesite drug skrivni odgovor." 
            InvalidEmailErrorMessage="Prosimo vnesite veljaven e-mail naslov." 
            InvalidQuestionErrorMessage="Prosimo vnesite drugo skrivno vprašanje." 
            PasswordLabelText="Geslo" QuestionLabelText="Skrivno vprašanje:" 
            UnknownErrorMessage="Vaš račun ni bil ustvarjen. Prosimo poskusite ponovno." 
            UserNameLabelText="Uporabniško ime:" oncreateduser="CreatedUser" 
            oncontinuebuttonclick="ContinueButton_Click">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" >

                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                Ustvari nov uporabniški račun</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Uporabniško 
                                ime:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="Zahtevano je uporabnisko ime." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Geslo</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Zahtevan je vnos gesla." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Potrdite geslo:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" ErrorMessage="Zahtevana je potrditev gesla" 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Naslov</td>
                            <td>
                                <asp:TextBox ID="Naslov" runat="server" Width="128px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredAddress" runat="server" 
                                    ControlToValidate="Naslov" ErrorMessage="RequiredAddress" 
                                    ToolTip="RequiredAddress" ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                EMŠO</td>
                            <td>
                                <asp:TextBox ID="Emso" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredEmso" runat="server" 
                                    ControlToValidate="Emso" ErrorMessage="Required EMSO" ToolTip="Required EMSO" 
                                    ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Davčna</td>
                            <td>
                                <asp:TextBox ID="Davcna" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredDavcna" runat="server" 
                                    ControlToValidate="Davcna" ErrorMessage="Required Davcna" 
                                    ToolTip="Required Davcna" ValidationGroup="CreateUserWizard3">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Vloga:</td>
                            <td>
                                <asp:DropDownList ID="DropDownVloge" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare0" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard3"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Literal ID="ErrorMessage0" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>

            <asp:CompleteWizardStep runat="server" >
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                Končano</td>
                        </tr>
                        <tr>
                            <td>
                                Vaš račun je bil uspešno ustvarjen.</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                    CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    
    
    </div>
    
    
    <p>
        &nbsp;</p>
    
    
    </form>
</asp:Content>
