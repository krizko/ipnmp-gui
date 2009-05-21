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
    public partial class Kartoteka : System.Web.UI.Page
    {
        protected int _ID;
        protected int _EMSO;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count == 2 &&
                Page.Request.QueryString.GetKey(0) == "a" &&
                Page.Request.QueryString.Get(0) == "iscemKartoteke" &&
                Page.Request.QueryString.GetKey(1) == "iskalniNiz" &&
                Page.Request.QueryString.Get(1) != "")
            {
                /* Tukaj dobimo niz in ga vržemo bazi, da najde kartoteke. */
                iskalniNiz.Text = Page.Request.QueryString.Get(1).ToString();
                infoNiz.Text = "";
                if (int.TryParse(Page.Request.QueryString.Get(1), out _EMSO))
                {
                    /* Iščem po emšu */
                    infoNiz.Text = "EMŠO";
                }
                else
                {
                    /* Iščem po nizu */
                    String niz = Page.Request.QueryString.Get(1).ToString();
                    infoNiz.Text = "Ime/Priimek";
                }
                /* V primeru da je rezultat 0 vrstic lahko prikažemo error */
                //pogledi.SetActiveView(niKartotek);
                /* Sicer pa rezultate */
                pogledi.SetActiveView(rezultati);
            }
            else if (Page.Request.QueryString.Count == 2 &&
                Page.Request.QueryString.GetKey(0) == "a" &&
                Page.Request.QueryString.Get(0) == "prikaziKartoteko" &&
                Page.Request.QueryString.GetKey(1) == "id" &&
                int.TryParse(Page.Request.QueryString.Get(1), out _ID))
            {
                /* Tukaj dobimo kartoteko in jo prikažemo. */
                /* Zaenkrat lahko prikažemo teh nekaj podatkov... kar pripnemo tekst k tem labelam. */
                /*ImePacienta.Text = "";
                PriimekPacienta.Text = "";
                NaslovPacienta.Text = "";
                PostaPacienta.Text = "";
                DatumRojstvaPacienta.Text = "";
                EmsoPacienta.Text = "";
                KrvnaSkupinaPacienta.Text = "";*/

                /* V primeru, da baza vrne da takšne kartoteke ni, lahko prikažemo error */
                //pogledi.SetActiveView(niKartoteke);
                /* Sicer pa kartoteko */
                pogledi.SetActiveView(kratoteka);
            }
            else
            {
                pogledi.SetActiveView(intro);
            }
        }
    }
}
