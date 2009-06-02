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
					P.EMŠO,
					P.Naslov.Mesto,
					P.Naslov.Ulica,
					P.Naslov.PoštnaŠtevilka.ToString()
				};
				
				Ret += Delno(s, QString);
			}
		}
		else if(Type == "zdravnik")
		{
			// ni ga!
		}
		
		//
		// Ok, pošlji kaj mamo
		Response.Write(Ret);
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
