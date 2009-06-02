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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LabelWarning.Visible = false;
    }
  
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        try
        {
            if (Roles.IsUserInRole(Login1.UserName, "Zdravnik"))
            {
                Response.Redirect("Zdravnik/Default.aspx");
            }
            else
            {
                if (Roles.IsUserInRole(Login1.UserName, "Admin"))
                {
                    Response.Redirect("Administrator/Default.aspx");
                }
                else
                {
                    if (Roles.IsUserInRole(Login1.UserName, "Resevalec"))
                    {
                        Response.Redirect("Resevalec/Default.aspx");
                    }
                    else
                    {
                        Panel1.Visible = true;
                    }

                }
            }
            
        }
        catch
        {
            //TODO
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}
