using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

public partial class Register : System.Web.UI.Page
{
    string imeUporabnika;
    // Napolnimo zacetno stran

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelEnd.Visible = false;
        if (!IsPostBack)
        {
            try
            {
                imeUporabnika = Request.QueryString["up"]; // ime uporabnika pridobimo preko urlja - Pass

                // v textboxe vstavimo ze znane info o uporabniku
                MembershipUser membershipUser = Membership.GetUser(imeUporabnika);
                UserName.Text = membershipUser.UserName.ToString();
                Email.Text = membershipUser.Email.ToString();

                ProfileCommon profile = Profile.GetProfile(imeUporabnika);
                Naslov.Text = profile.GetProfile(imeUporabnika).Naslov;
                Emso.Text = profile.GetProfile(imeUporabnika).Emso;
                Davcna.Text = profile.GetProfile(imeUporabnika).Davcna;

                // Gesla vec ne moremo pridobiti nazaj
                //((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Password")).Text = Membership.GetUser(imeUporabnika).GetPassword().ToString();

                // v dropDownList vstavimo vse role

                DropDownList ddl = DropDownVloge;
                for (int i = 0; i < Roles.GetAllRoles().Count(); i++)
                {
                    ddl.Items.Add(Roles.GetAllRoles()[i]);
                }

                //prikaz njegove Role
                string glVloga = "";
                foreach (string vloga in Roles.GetAllRoles())
                {
                    if (Roles.IsUserInRole(imeUporabnika, vloga) == true)
                    {
                        glVloga = vloga;
                    }
                }
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i].Text == glVloga)
                    {
                        ddl.SelectedIndex = i;
                    }
                }

            }
            catch//v primeru da v seji ostene prevzet naslov ni pa vseh podatkov na voljo
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    // Najprej uporabnika izbrisemo potem ga dodamo
    protected void ButtonYes_Click(object sender, EventArgs e)
    {
        imeUporabnika = Request.QueryString["up"];
        MembershipUser user = Membership.GetUser(imeUporabnika);

        if (user != null)//uprabnik pravilno naložen
        {
            //ROLE
            DropDownList ddl = DropDownVloge;

            if (!Roles.IsUserInRole(imeUporabnika, ddl.SelectedValue)) //v primeru da še uporabnik nima te role 
            {
                foreach (string vloga in Roles.GetAllRoles())//zbrišem vse stare vloge in dodam novo
                {
                    if (Roles.IsUserInRole(imeUporabnika, vloga) == true)
                    {
                        Roles.RemoveUserFromRole(imeUporabnika, vloga);
                    }
                }

                Roles.AddUserToRole(imeUporabnika, ddl.SelectedValue);//dodam novo vlogo
            }


            //PODATKI
            if (!Email.Text.Equals(user.Email))
                user.Email = Email.Text;

            ProfileCommon profile = Profile.GetProfile(imeUporabnika);
            if (!profile.Naslov.Equals(Naslov.Text))
                profile.Naslov = Naslov.Text;

            if (!profile.Emso.Equals(Emso.Text))
                profile.Emso = Emso.Text;

            if (!profile.Davcna.Equals(Davcna.Text))
                profile.Davcna = Davcna.Text;

            profile.Save();

            Response.Redirect("Default.aspx");

        }
        else
            Response.Redirect("Default.aspx");

    }
    protected void ButtonNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");        
    }
    protected void ResetPassword_Click(object sender, EventArgs e)
        {
            imeUporabnika = Request.QueryString["up"];
            MembershipUser user = Membership.GetUser(imeUporabnika);
            if (user != null)//uprabnik pravilno naložen
            {     
                string newPassword = user.ResetPassword();
                string mailSubject = "Novo geslo iz sistema, Intelegentni pomočnik rešilcu";
                string mailBody = "Vaše geslo na sitemu Intelegentni pomočnik rešilcu je bilo resetirano. \n";
                mailBody += "Novo geslo se glasi: " + newPassword;

                MailMessage mailMessage = new MailMessage();
                MailAddress mailAddressFrom = new MailAddress("admin@IP.com", "Admin");
                MailAddress mailAddressTo = new MailAddress(Email.Text, imeUporabnika);

                mailMessage.From = mailAddressFrom;                
                mailMessage.To.Add(mailAddressTo);
                mailMessage.Subject = mailSubject;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.Body = mailBody;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;


                try
                {
                    SmtpClient smtpMailObj = new SmtpClient();
                    //eg:localhost, 192.168.0.x, replace with your server name
                    smtpMailObj.Host = "localhost";
                    smtpMailObj.Send(mailMessage);
                    Response.Write("Geslo je bilo uspešno poslano.");
                }
                catch (Exception ex)
                {
                    Response.Write("Napaka, pri pošiljanju emaila.\n");
                    Response.Write(ex.Message);
                }
            }
            else
            {                
                //Response.Redirect("Default.aspx");
            }
        }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        imeUporabnika = Request.QueryString["up"];
        MembershipUser user = Membership.GetUser(imeUporabnika);
        if (user != null)//uprabnik pravilno naložen
        {
            try
            {
                if (NewPassword.Text != "")
                {
                    if (NewPassword.Text.Equals(ConfirmNewPassword.Text))
                    {
                        string oldPassword = user.ResetPassword();
                        user.ChangePassword(oldPassword, NewPassword.Text);
                        LabelEnd.Visible = true;
                        LabelEnd.Text = "Geslo uspešno zamenjano.";
                    }
                }
            }
            catch
            {
                LabelEnd.Visible = true;
                LabelEnd.Text = "Napaka pri zamenjavi gesla.";
            }
        }
        else
        {
            //Response.Redirect("Default.aspx");
        }
    }
}

