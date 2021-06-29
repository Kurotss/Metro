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
	/// Логика взаимодействия для StopsPage.xaml
	/// </summary>
	public partial class StopsPage : Page
	{
		public StopsPage()
		{
			InitializeComponent();
			MetroContext db = new();
			Datagrid.ItemsSource = db.StopsStations.ToList();
		}

		private void AddStop(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new AddStopPage());
		}

		private void OpenInfo(object sender, DataGridBeginningEditEventArgs e)
		{
			Line row = (Line)e.Row.Item;
			//Manager.Main.MainFrame.Navigate((row.IdLine));
		}

		private void DeleteStop(object sender, RoutedEventArgs e)
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
						StopsStation row = (StopsStation)item;
						StopTraffic stop = db.StopTraffics.Find(row.IdStop);
						db.StopTraffics.Remove(stop);
					}
					db.SaveChanges();
					Datagrid.ItemsSource = db.StopsStations.ToList();
				}
			}
		}
	}
}
