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

public partial class Zdravnik_Autocomplete : System.Web.UI.Page
{
	protected const string EOL = "\n";
	
	protected void Page_Load(object sender, EventArgs e)
	{
		string QString = Request.QueryString["q"];
		string Type    = Request.QueryString["type"];
		
		// ne se mantrat, če ni zadost 
		if(QString == null || QString.Length < 1)
		return;
		
		if(Type == null)
		return;
		
		// činkeni
		Type = Type.ToLower();
		
		// vrnemo tu sem
		string Ret = "";
		
		// križišče
		if(Type == "pacient")
		{
			IPNMP.Pacient[] Pacienti = IPNMP.Pacient.VrniVse();
			
			foreach(IPNMP.Pacient P in Pacienti)
			{
				string[] s =
				{
					P.Ime,
					P.Priimek,
					P.EMŠO
				};
				
				//Ret += Delno(s, QString);
				
				foreach(string Polje in s)
				{
					if(Delno(Polje, QString))
					{
						Ret += VrniPredlogo(P);
					}
				}
			}
		}
		else if(Type == "zdravnik")
		{
            IPNMP.Zaposleni[] Zaposleni = IPNMP.Zaposleni.VrniVse();
            foreach (IPNMP.Zaposleni Z in Zaposleni)
            {
                string[] s =
				{
					Z.Ime,
					Z.Priimek,
					Z.EMŠO
				};

                //Ret += Delno(s, QString);

                foreach (string Polje in s)
                {
                    if (Delno(Polje, QString))
                    {
                        Ret += VrniPredlogoZ(Z);
                    }
                }
            }
			// ni ga!
		}
		
		//
		// Ok, pošlji kaj mamo
		Response.Write(Ret);
	}
	
	protected string VrniPredlogo(IPNMP.Pacient P)
	{
		string r;
		
		r  = P.Ime     + " ";
		r += P.Priimek + " ";
		r += P.EMŠO;
		
		r += EOL;
		
		return r;
	}
    protected string VrniPredlogoZ(IPNMP.Zaposleni Z)
    {
        string r;

        r = Z.Ime + " ";
        r += Z.Priimek + " ";
        r += Z.EMŠO;

        r += EOL;

        return r;
    }
	
	protected bool Delno(string Tekst, string Najdi)
	{
		// Zamenjaj z IndexOf() da najde bilokje v tekstu
		if(Tekst.StartsWith(Najdi, StringComparison.CurrentCultureIgnoreCase))
		{
			return true;
		}
		
		return false;
	}
	
	protected string Delno(string[] Tekst, string Najdi)
	{
		string TekstUjemanje = "";
		
		foreach(string s in Tekst)
		{
			if(Delno(s, Najdi))
			{
				TekstUjemanje += s;
				TekstUjemanje += EOL;
			}
		}
		
		return TekstUjemanje;
	}
}
