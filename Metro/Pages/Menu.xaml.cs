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
using Metro.Pages;

namespace Metro
{
	/// <summary>
	/// Логика взаимодействия для Menu.xaml
	/// </summary>
	public partial class Menu : Page
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void OpenStations(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new StationsPage());
		}

		private void OpenLines(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new LinesPage());
		}

		private void OpenStops(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new StopsPage());
		}
	}
}
