using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Metro.Classes;

namespace Metro.Pages
{
	/// <summary>
	/// Логика взаимодействия для StationsPage.xaml
	/// </summary>
	public partial class StationsPage : Page
	{
		public StationsPage()
		{
			InitializeComponent();
			MetroContext db = new();
			Datagrid.ItemsSource = db.LinesStations.ToList();
		}

		private void AddStation(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new AddStationPage());
		}

		private void OpenInfo(object sender, DataGridBeginningEditEventArgs e)
		{
			LinesStation row = (LinesStation)e.Row.Item;
			Manager.Main.MainFrame.Navigate(new AddStationPage(row.NameStation));
		}

		private void DeleteStation(object sender, RoutedEventArgs e)
		{
			if (Datagrid.SelectedIndex == -1)
			{
				MessageBox.Show("Не выбраны элементы для удаления");
			}
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить эти элементы?", "Подтверждение", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					MetroContext db = new();
					foreach (var item in Datagrid.SelectedItems)
					{
						LinesStation row = (LinesStation)item;
						var stations = db.Stations.Where(p => p.NameStation == row.NameStation);
						Station station = stations.FirstOrDefault();
						db.Stations.Remove(station);
					}
					db.SaveChanges();
					Datagrid.ItemsSource = db.LinesStations.ToList();
				}
			}
		}
	}
}
