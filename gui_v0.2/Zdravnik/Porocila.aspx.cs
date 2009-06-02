using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace Dizajn
{
    public partial class Porocila : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            // Seznam poročil
            if(Page.Request.QueryString.Count == 0)
            {
                IPNMP.Poročilo[] porocila = IPNMP.Poročilo.VrniVsaPorocila();
                if (porocila.Length == 0)
                {
                    MultiView.SetActiveView(NiPorocil);
                }
                else
                {
                    Repeater1.DataSource = porocila;
                    Repeater1.DataBind();

                    MultiView.SetActiveView(ViewPregled);
                }
            }
            else
            {
                if (Page.Request.QueryString["a"] != null)
                {
                    IPNMP.Poročilo Porocilo = new IPNMP.Poročilo();

                    //UrediDatumBox.Text = Porocilo.Datum.ToString();
                    UrediKrajBox.Text = "manjka mi"; // Porocilo.Kraj;
                    UrediPonesrecenecBox.Text = "manjka mi";
                    UrediZdravnikBox.Text = "manjka mi";
                    UrediPrihodBox.Text = Porocilo.StanjePacientaObPrispetju;
                    UrediSprejemBox.Text = Porocilo.StanjePacientaObPrispetjuVBolnišnico;
                    UrediDatumSprejemaBox.Text = "manjka mi";
                    UrediOpisBox.Text = Porocilo.OpisDogodka;
                    UrediAkcijeBox.Text = Porocilo.AkcijeReševalcev;
                    
                    MultiView.SetActiveView(ViewUrediDodaj);
                }
            }
        }
    }
}
