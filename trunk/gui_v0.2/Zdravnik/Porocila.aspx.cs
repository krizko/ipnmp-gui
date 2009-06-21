using System;
using System.Collections;
using System.Collections.Generic;
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
                if (Page.IsPostBack)
                {
                    Boolean okSaveIt = true;
                    // ČAS DOGODKA
                    try
                    {
                        Porocilo.ČasDogodka = DateTime.Parse(UrediDatumBox.Text);
                        UrediDatumBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        UrediDatumBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // ČAS KLICANJA REŠEVALCEV
                    try
                    {
                        Porocilo.ČasKlicanjaReševalcev = DateTime.Parse(CasKlicaBox.Text);
                        CasKlicaBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        CasKlicaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // ČAS PRISPETJA REŠEVALCEV
                    try
                    {
                        Porocilo.ČasPrispetjaReševalcev = DateTime.Parse(CasNMPBox.Text);
                        CasNMPBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        CasNMPBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // ČAS PRISPETJA V BOLNIŠNICO
                    try
                    {
                        Porocilo.ČasPrispetjaVBolnišnico = DateTime.Parse(CasBolnisnicaBox.Text);
                        CasBolnisnicaBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        CasBolnisnicaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }
                    IPNMP.Naslov naslov = new IPNMP.Naslov();
                    // HIŠNA ŠTEVILKA
                    try
                    {
                        naslov.HišnaŠtevilka = UrediHisnaStevilkaBox.Text;
                        UrediHisnaStevilkaBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        UrediHisnaStevilkaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // ULICA
                    try
                    {
                        naslov.Ulica = UrediUlicaBox.Text;
                        UrediUlicaBox.Style["background"] = "#FFFFFF";
                        
                    }
                    catch (Exception ex)
                    {
                        UrediUlicaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // MESTO
                    try
                    {
                        naslov.Mesto = UrediPostaBox.Text;
                        UrediPostaBox.Style["background"] = "#FFFFFF";
                        
                    }
                    catch (Exception ex)
                    {
                        UrediPostaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }

                    // POŠTNA ŠTEVILKA
                    try
                    {
                        naslov.PoštnaŠtevilka = int.Parse(UrediPostnaStevilkaBox.Text);
                        UrediPostnaStevilkaBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        UrediPostnaStevilkaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }
                    Porocilo.Naslov = naslov;
                    // PONESRECENEC
                    try
                    {
                        String ponesrecenec = UrediPonesrecenecBox.Text;
                        String []pon = ponesrecenec.Split(' ');
                        String ime = pon[0];
                        String priimek = pon[1];
                        String emso = pon[2];
                        IPNMP.Pacient pacient = IPNMP.Pacient.VrniPoEmšo(emso);
                        if (pacient != null)
                        {
                            Porocilo.Pacient = pacient;
                        }
                        else
                        {
                            IPNMP.Oseba ludek = new IPNMP.Oseba();
                            ludek.Ime = ime;
                            ludek.Priimek = priimek;
                            ludek.EMŠO = emso;
                            ludek.Ustvari();

                            pacient.IDOseba = ludek.IDOseba;
                            pacient.Ime = ime;
                            pacient.Priimek = priimek;
                            pacient.EMŠO = emso;
                            pacient.Ustvari();
                            Porocilo.Pacient = pacient;
                        }
                        UrediPonesrecenecBox.Style["background"] = "#FFFFFF";
                    } catch (Exception ex)
                    {
                        UrediPonesrecenecBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }
                    try
                    {
                        String[] ekipa = UrediEkipaBox.Text.Split(',');
                        List<IPNMP.Zaposleni> clani = new List<IPNMP.Zaposleni>(ekipa.Length);
                        foreach (String clan in ekipa)
                        {
                            String[] delci = clan.Split(' ');
                            if (delci.Length < 3) continue;
                            String ime = delci[0];
                            String priimek = delci[1];
                            String emso = delci[2];
                            try
                            {
                                IPNMP.Zaposleni zaposlen = IPNMP.Zaposleni.VrniPoEmšo(emso);
                                if (zaposlen != null) clani.Add(zaposlen);
                            }
                            catch (Exception exp)
                            {
                            }
                        }
                        if (clani.Count == 0) throw new Exception();
                        Porocilo.Ekipa = clani.ToArray();
                        UrediEkipaBox.Style["background"] = "#FFFFFF";
                    }
                    catch (Exception ex)
                    {
                        UrediEkipaBox.Style["background"] = "#FF9966";
                        okSaveIt = false;
                    }
                    Porocilo.StanjePacientaObPrispetju = UrediPrihodBox.Text;
                    Porocilo.StanjePacientaObPrispetjuVBolnišnico = UrediSprejemBox.Text;
                    Porocilo.OpisDogodka = UrediOpisBox.Text;
                    Porocilo.AkcijeReševalcev = UrediAkcijeBox.Text;
                    if (okSaveIt)
                    {
                        naslov.IDNaslova = naslov.Ustvari();
                        Porocilo.UstvariPorocilo();
                        MultiView.SetActiveView(redirect);
                        return;
                    }
                }
                
                MultiView.SetActiveView(ViewUrediDodaj);
            }
                // UREJANJE POROČILA
            else if (Page.Request.QueryString["a"] == "uredi" && int.TryParse(Page.Request.QueryString["stPorocila"], out _ID))
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
                    else if (Page.IsPostBack)
                    {
                        Boolean okCreateIt = false;
                        if (Porocilo == null)
                        {
                            Porocilo = new IPNMP.Poročilo();
                            okCreateIt = true;
                        }
                        Boolean okSaveIt = true;
                        // ČAS DOGODKA
                        try
                        {
                            Porocilo.ČasDogodka = DateTime.Parse(UrediDatumBox.Text);
                            UrediDatumBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            UrediDatumBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // ČAS KLICANJA REŠEVALCEV
                        try
                        {
                            Porocilo.ČasKlicanjaReševalcev = DateTime.Parse(CasKlicaBox.Text);
                            CasKlicaBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            CasKlicaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // ČAS PRISPETJA REŠEVALCEV
                        try
                        {
                            Porocilo.ČasPrispetjaReševalcev = DateTime.Parse(CasNMPBox.Text);
                            CasNMPBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            CasNMPBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // ČAS PRISPETJA V BOLNIŠNICO
                        try
                        {
                            Porocilo.ČasPrispetjaVBolnišnico = DateTime.Parse(CasBolnisnicaBox.Text);
                            CasBolnisnicaBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            CasBolnisnicaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }
                        IPNMP.Naslov naslov = new IPNMP.Naslov();
                        // HIŠNA ŠTEVILKA
                        try
                        {
                            naslov.HišnaŠtevilka = UrediHisnaStevilkaBox.Text;
                            UrediHisnaStevilkaBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            UrediHisnaStevilkaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // ULICA
                        try
                        {
                            naslov.Ulica = UrediUlicaBox.Text;
                            UrediUlicaBox.Style["background"] = "#FFFFFF";

                        }
                        catch (Exception ex)
                        {
                            UrediUlicaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // MESTO
                        try
                        {
                            naslov.Mesto = UrediPostaBox.Text;
                            UrediPostaBox.Style["background"] = "#FFFFFF";

                        }
                        catch (Exception ex)
                        {
                            UrediPostaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }

                        // POŠTNA ŠTEVILKA
                        try
                        {
                            naslov.PoštnaŠtevilka = int.Parse(UrediPostnaStevilkaBox.Text);
                            UrediPostnaStevilkaBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            UrediPostnaStevilkaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }
                        Porocilo.Naslov = naslov;
                        // PONESRECENEC
                        try
                        {
                            String ponesrecenec = UrediPonesrecenecBox.Text;
                            String[] pon = ponesrecenec.Split(' ');
                            String ime = pon[0];
                            String priimek = pon[1];
                            String emso = pon[2];
                            IPNMP.Pacient pacient = IPNMP.Pacient.VrniPoEmšo(emso);
                            if (pacient != null)
                            {
                                Porocilo.Pacient = pacient;
                            }
                            else
                            {
                                IPNMP.Oseba ludek = new IPNMP.Oseba();
                                ludek.Ime = ime;
                                ludek.Priimek = priimek;
                                ludek.EMŠO = emso;
                                ludek.Ustvari();

                                pacient.IDOseba = ludek.IDOseba;
                                pacient.Ime = ime;
                                pacient.Priimek = priimek;
                                pacient.EMŠO = emso;
                                pacient.Ustvari();
                                Porocilo.Pacient = pacient;
                            }
                            UrediPonesrecenecBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            UrediPonesrecenecBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }
                        try
                        {
                            String[] ekipa = UrediEkipaBox.Text.Split(',');
                            List<IPNMP.Zaposleni> clani = new List<IPNMP.Zaposleni>(ekipa.Length);
                            foreach (String clan in ekipa)
                            {
                                String[] delci = clan.Split(' ');
                                if (delci.Length < 3) continue;
                                String ime = delci[0];
                                String priimek = delci[1];
                                String emso = delci[2];
                                try
                                {
                                    IPNMP.Zaposleni zaposlen = IPNMP.Zaposleni.VrniPoEmšo(emso);
                                    if (zaposlen != null) clani.Add(zaposlen);
                                }
                                catch (Exception exp)
                                {
                                }
                            }
                            if (clani.Count == 0) throw new Exception();
                            Porocilo.Ekipa = clani.ToArray();
                            UrediEkipaBox.Style["background"] = "#FFFFFF";
                        }
                        catch (Exception ex)
                        {
                            UrediEkipaBox.Style["background"] = "#FF9966";
                            okSaveIt = false;
                        }
                        Porocilo.StanjePacientaObPrispetju = UrediPrihodBox.Text;
                        Porocilo.StanjePacientaObPrispetjuVBolnišnico = UrediSprejemBox.Text;
                        Porocilo.OpisDogodka = UrediOpisBox.Text;
                        Porocilo.AkcijeReševalcev = UrediAkcijeBox.Text;
                        if (okSaveIt)
                        {
                            naslov.IDNaslova = naslov.Ustvari();
                            if (okCreateIt) Porocilo.UstvariPorocilo();
                            else Porocilo.PosodobiPorocilo();
                            MultiView.SetActiveView(redirect);
                            return;
                        }
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
                IPNMP.Poročilo[] porocila;
                try
                {
                    porocila = IPNMP.Poročilo.VrniVsaPorocila();

                }
                catch (Exception ex)
                {
                    MultiView.SetActiveView(NiPorocil);
                    return;
                }
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
