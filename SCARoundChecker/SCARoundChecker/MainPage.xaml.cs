using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCARoundChecker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			//DateTime now = DateTime.Now;
			DateTime now = new DateTime(2019, 2, 2);
			int season = now.Year;
			if (now.Month <= 6)
				season--;
			string link0 = $"http://www.schoolchess.org/old/results/ChooseTour.php?season={season}-{season+1}&tourDate={now.ToString("yyyy-MM-dd")}";
			
			var web = new HtmlWeb();
			var doc = web.Load(link0);

			//Get all links from the first table in doc
			var relitiveLinks = doc.DocumentNode.Descendants("table").FirstOrDefault().Descendants("a").Select(a => a.GetAttributeValue("href", "")).Distinct();
			var tournamentNames = relitiveLinks.Select(s => s.Split('/')[3]);

			InitializeComponent();


			label.Text = tournamentNames.Aggregate((a, b) => a + "\n" + b);
			foreach (var tournament in tournamentNames)
			{
				Button btn = new Button();
				btn.Text = tournament;
				buttons.Children.Add(btn);
			}

		}
	}
}
