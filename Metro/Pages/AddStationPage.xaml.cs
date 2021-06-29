using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metro.Pages
{
	public partial class AddStationPage : Page
	{
		public int IsAdd { get; set; }
		public string NameStation { get; set; }
		public string GpsCoordinates { get; set; }
		public double PassengerTraffic { get; set; }
		public AddStationPage(string Name)
		{
			InitializeComponent();
			IsAdd = 0;
			this.DataContext = this;
			MetroContext db = new();
			var temp = db.LinesStations.Where(p => p.NameStation == Name);
			LinesStation station = temp.FirstOrDefault();
			this.NameStation = station.NameStation;
			this.GpsCoordinates = station.GpsCoordinates;
			this.PassengerTraffic = (double)station.PassengerTraffic;
			var NameLines = db.Lines.Select(p => p.NameLine);
			NameLineInput.ItemsSource = NameLines.ToList();
			NameLineInput.Text = station.NameStation;

		}
		
		public AddStationPage()
		{
			InitializeComponent();
			IsAdd = 1;
			MetroContext db = new();
			var NameLines = db.Lines.Select(p => p.NameLine);
			NameLineInput.ItemsSource = NameLines.ToList();
		}

		private void SaveInfo(object sender, RoutedEventArgs e)
		{
			MetroContext db = new();
			bool AllCorrect = true;
			if (NameLineInput.SelectedIndex == -1) AllCorrect = false;
			if (!Regex.IsMatch(NameInput.Text, @"^[а-яА-Яa-zA-Z]+$") || NameInput.Text.Length < 3)
				AllCorrect = false;
			if (!Regex.IsMatch(GpsInput.Text, @"^\d\d\.\d\d\d\d\d\d\-\d\d\.\d\d\d\d\d\d"))
				AllCorrect = false;
			if (!Regex.IsMatch(TrafficInput.Text, @"^\d+\,\d+$"))
				AllCorrect = false;
			if (db.Stations.Where(p => p.NameStation == NameStation).ToList().Count != 0)
				AllCorrect = false;
			if (AllCorrect)
			{
				Station station = new();
				if (IsAdd == 0)
				{
					var stations = db.Stations.Where(p => p.NameStation == NameStation).Select(p => p.IdStation);
					station.IdStation = stations.FirstOrDefault();
				}
				var ids = db.Lines.Where(p => p.NameLine == NameLineInput.Text).Select(p => p.IdLine);
				station.IdLine = ids.FirstOrDefault();
				station.NameStation = NameInput.Text;
				station.GpsCoordinates = GpsInput.Text;
				station.PassengerTraffic = double.Parse(TrafficInput.Text);
				if (IsAdd == 1) db.Stations.Add(station);
				db.SaveChanges();
				MessageBox.Show("Данные успешно добавлены");
			}
			else MessageBox.Show("Некорректные данные");
		}
	}
}
