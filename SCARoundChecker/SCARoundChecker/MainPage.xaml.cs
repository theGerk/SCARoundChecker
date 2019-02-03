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


			// Create a request for the URL. 		
			WebRequest request = WebRequest.Create(link0);
			// If required by the server, set the credentials.
			request.Credentials = CredentialCache.DefaultCredentials;
			// Get the response.
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			// Display the status.
			Console.WriteLine(response.StatusDescription);
			// Get the stream containing content returned by the server.
			Stream dataStream = response.GetResponseStream();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Cleanup the streams and the response.
			reader.Close();
			dataStream.Close();
			response.Close();


			InitializeComponent();
			label.Text = link0;
			stupid.Text = responseFromServer;
		}
	}
}
