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
            IPNMP.Pacient[] pacienti = new IPNMP.Pacient[1];
            

            if (Page.Request.QueryString["a"] == "iscemKartoteke" && Page.Request.QueryString["iskalniNiz"] != "") {
                /* Tukaj dobimo niz in ga vržemo bazi, da najde kartoteke. */
                iskalniNiz.Text = Page.Request.QueryString["iskalniNiz"].ToString();
                infoNiz.Text = "";
                if (int.TryParse(Page.Request.QueryString["iskalniNiz"], out _EMSO))
                {
                    /* Iščem po emšu */
                    try
                    {
                        infoNiz.Text = "EMŠO";
                        pacienti[0] = IPNMP.Pacient.VrniPoEmšo(_EMSO.ToString());
                    }
                    catch
                    {
                        pacienti[0] = null;
                    }
                }
                else
                {
                    /* Iščem po nizu */
                    String niz = Page.Request.QueryString["iskalniNiz"];
                    infoNiz.Text = "Ime/Priimek";
                    pacienti = IPNMP.Pacient.VrniVsePoImenu(niz, "");

                }
                /* V primeru da je rezultat 0 vrstic lahko prikažemo error */
                if (pacienti.Length == 0)
                {
                    pogledi.SetActiveView(niKartotek);
                }
                else if (pacienti.Length == 1)
                {
                    // Prikazi samo ce je uspesno pridobil pacienta po emsu
                    if (pacienti[0] != null)
                        polniPrikazKartoteke(pacienti[0]);
                    else
                        pogledi.SetActiveView(niKartoteke);
                }
                else
                {
                    /* Sicer pa rezultate */
                    ponavljalec1.DataSource = pacienti;
                    ponavljalec1.DataBind();
                    pogledi.SetActiveView(rezultati);
                }
            }
            else if (Page.Request.QueryString["a"] == "prikaziKartoteko" &&
                int.TryParse(Page.Request.QueryString["EMSO"], out _EMSO))
            {
                pacienti[0] = IPNMP.Pacient.VrniPoEmšo(_EMSO.ToString());
                // Prikazi samo ce je uspesno pridobil pacienta po emsu
                if (pacienti[0] != null)
                    polniPrikazKartoteke(pacienti[0]);
                else
                    pogledi.SetActiveView(niKartoteke);
            }
            else
            {
                pogledi.SetActiveView(intro);
            }
        }
        public void polniPrikazKartoteke(IPNMP.Pacient pacient)
        {
            /* Tukaj dobimo kartoteko in jo prikažemo. */
            /* Zaenkrat lahko prikažemo teh nekaj podatkov... kar pripnemo tekst k tem labelam. */
            ImePacienta.Text = pacient.Ime;
            PriimekPacienta.Text = pacient.Priimek;
            NaslovPacienta.Text = pacient.Naslov.Ulica + " " + pacient.Naslov.HišnaŠtevilka;
            PostaPacienta.Text = pacient.Naslov.PoštnaŠtevilka + " " + pacient.Naslov.Mesto;
            DatumRojstvaPacienta.Text = pacient.DatumRojstva.ToString();
            EmsoPacienta.Text = pacient.EMŠO;
            KrvnaSkupinaPacienta.Text = pacient.KrvnaSkupina;

            /* Sicer pa kartoteko */
            pogledi.SetActiveView(kratoteka);
        }
    }
}
