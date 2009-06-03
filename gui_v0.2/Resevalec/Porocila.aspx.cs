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
            int _ID;
            if (Page.Request.QueryString["a"] == "dodaj") // DODAJANJE POROČILA
            {
                IPNMP.Poročilo Porocilo = new IPNMP.Poročilo();

                //UrediDatumBox.Text = Porocilo.Datum.ToString();

                // KRAJ
                //UrediHisnaStevilkaBox.Text = "manjka";
                //UrediUlicaBox.Text = "manjka";
                //UrediPostaBox.Text = "manjka";
                //UrediPostnaStevilkaBox.Text = "manjka";

                //// PONESRECENEC
                //UrediPonesrecenecBox.Text = "manjka mi";
                //UrediEkipaBox.Text = "manjka mi";
                //UrediPrihodBox.Text = Porocilo.StanjePacientaObPrispetju;
                //UrediSprejemBox.Text = Porocilo.StanjePacientaObPrispetjuVBolnišnico;
                //UrediOpisBox.Text = Porocilo.OpisDogodka;
                //UrediAkcijeBox.Text = Porocilo.AkcijeReševalcev;
                
                MultiView.SetActiveView(ViewUrediDodaj);
            }
            else if (Page.Request.QueryString["a"] == "uredi" && int.TryParse(Page.Request.QueryString["stPorocila"], out _ID)) // UREJANJE POROČILA
            {
                IPNMP.Poročilo Porocilo = null;
                try
                {
                    Porocilo = IPNMP.Poročilo.VrniPorociloPoID(_ID);
                }
                catch (Exception ex)
                {
                    // GRRR
                }
                if (Porocilo != null)
                {
                    //UrediDatumBox.Text = Porocilo.Datum.ToString();
                    // KRAJ
                    if (!Page.IsPostBack)
                    {
                        UrediDatumBox.Text = Porocilo.ČasDogodka.ToString();
                        CasKlicaBox.Text = Porocilo.ČasKlicanjaReševalcev.ToString();
                        CasNMPBox.Text = Porocilo.ČasPrispetjaReševalcev.ToString();
                        CasBolnisnicaBox.Text = Porocilo.ČasPrispetjaVBolnišnico.ToString();
                        UrediHisnaStevilkaBox.Text = Porocilo.Naslov.HišnaŠtevilka;
                        UrediUlicaBox.Text = Porocilo.Naslov.Ulica;
                        UrediPostaBox.Text = Porocilo.Naslov.Mesto;
                        UrediPostnaStevilkaBox.Text = Porocilo.Naslov.PoštnaŠtevilka.ToString();
                        // PONESRECENEC
                        UrediPonesrecenecBox.Text = Porocilo.Pacient.Ime + " " + Porocilo.Pacient.Priimek + " (" + Porocilo.Pacient.EMŠO + ")";
                        string zdravniki = "";
                        bool prvic = true;
                        foreach(IPNMP.Zaposleni prisoten in Porocilo.Ekipa)
                        {
                            if(prvic)
                            {
                                zdravniki = prisoten.Ime + " " + prisoten.Priimek;
                                prvic = false;
                            }
                            zdravniki = zdravniki + ", " + prisoten.Ime + " " + prisoten.Priimek;
                        }
                        UrediEkipaBox.Text = zdravniki;
                        UrediPrihodBox.Text = Porocilo.StanjePacientaObPrispetju;
                        UrediSprejemBox.Text = Porocilo.StanjePacientaObPrispetjuVBolnišnico;
                        UrediOpisBox.Text = Porocilo.OpisDogodka;
                        UrediAkcijeBox.Text = Porocilo.AkcijeReševalcev;
                    }
                    else
                    {

                    }
                    MultiView.SetActiveView(ViewUrediDodaj);
                }
                else
                {
                    MultiView.SetActiveView(niPorocila);
                }
            }
            else // SEZNAM POROČIL
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
        }
        protected void UrediPonesrecenecBox_TextChanged(object sender, EventArgs e)
        {

        }
}
}
