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


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList ddl = (DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DropDownVloge");
            for (int i = 0; i < Roles.GetAllRoles().Count(); i++)
                ddl.Items.Add(Roles.GetAllRoles()[i]);
        }
    }
    protected void CreatedUser(object sender, EventArgs e)
    {
        // dodamo vlogo
        DropDownList ddl = (DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DropDownVloge");
        Roles.AddUserToRole(CreateUserWizard.UserName, ddl.SelectedValue);

        // dodatne lastnosti
        //// Create an empty Profile for the newly created user
        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard.UserName, true);
        //// Populate some Profile properties off of the create user wizard       
        p.Naslov = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Naslov")).Text;
        p.Emso = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Emso")).Text;
        p.Davcna = (((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Davcna")).Text);
        //// Save profile - must be done since we explicitly created it        
        p.Save();
    }
    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
        // Gumb nas vrne na prejsnjo stran (Default.aspx kjer lahko spret izberemo vnos, uredi, ter brisi)
    }
}

