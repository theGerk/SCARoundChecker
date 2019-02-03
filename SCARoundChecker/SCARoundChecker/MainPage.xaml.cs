using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCARoundChecker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			DateTime now = DateTime.Now;
			int season = now.Year;
			if (now.Month <= 6)
				season--;
			string link0 = $"http://www.schoolchess.org/old/results/ChooseTour.php?season={season}-{season+1}&tourDate={now.ToString("yyyy-MM-dd")}";
			string link1 = "http://www.schoolchess.org/old/results/ChooseTour.php?season=2018-2019&tourDate=2019-02-02";
			InitializeComponent();
			label.Text = link0;
			webView.Source = link0;
		}
	}
}
