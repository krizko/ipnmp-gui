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

public partial class Administrator_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelUserName2.Text = HttpContext.Current.User.Identity.Name.ToString();
        napolni();
    }
    // Napolnimo GridView
    private void napolni()
    {
        GridView1.DataSource = Membership.GetAllUsers(); // Vir podatkov v GridView bodo vsi uporabniki
        GridView1.DataBind();  // napolnimo GridView

    }
    // Gumb ki nas vrze na prejsnjo stran
    protected void naPrejsnjoStran(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  // Gumb nas vrne na prejsnjo stran (Default.aspx kjer lahko spret izberemo vnos, uredi, ter brisi)
    }
    // Izbrise danega uporabnika
    protected void RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        int vrstica; // vrstica brisanja
        string userName; // ime uporabnika v vrstici brisanja
        string prijavljenUporabnik = HttpContext.Current.User.Identity.Name.ToString();

        vrstica = e.RowIndex; // ko kliknemo brisi preberemo v kateri vrstici je bil sprozena ta akcija

        userName = GridView1.Rows[vrstica].Cells[1].Text; // dobimo ime usera 

        if (prijavljenUporabnik.Equals(userName))
        {
            Label2.Text = "Prijavljenega uporabnika ni mogoče izbrisati!<br>";

        }
        else
        {
            Label2.Text = "";

            LabelUserName.Text = userName;

            PanelConfirm.Visible = true;
        }
    }
    protected void ButtonYes_Click(object sender, EventArgs e)
    {
        string userName = LabelUserName.Text;
        if (userName != "")
        {
            Membership.DeleteUser(userName); // pobrisemo uporabnika tako da v DeleteUser vnesemo njegovo ime
         //   Roles.AddUserToRole(CreateUserWizard.UserName, ddl.SelectedValue);
            string[] roles = Roles.GetRolesForUser(userName);
            foreach (string role in roles)
            {
                Roles.RemoveUserFromRole(userName, role);
            }
            
        }
        PanelConfirm.Visible = false;
        napolni(); // na novo napolnimo GridView        
    }
    protected void ButtonNo_Click(object sender, EventArgs e)
    {
        PanelConfirm.Visible = false;
    }
    protected void RowEdit(object sender, GridViewEditEventArgs e)
    {        
        int vrstica; // vrstica brisanja
        string uporabnik; // ime uporabnika v vrstici brisanja
        vrstica = e.NewEditIndex;
        uporabnik = GridView1.Rows[vrstica].Cells[1].Text;
        Response.Redirect("EditUser.aspx?up="+uporabnik);        
    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {

    }
    protected void Dodaj_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}
