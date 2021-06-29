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
	/// Логика взаимодействия для LinesPage.xaml
	/// </summary>
	public partial class LinesPage : Page
	{
		public LinesPage()
		{
			InitializeComponent();
			MetroContext db = new();
			Datagrid.ItemsSource = db.Lines.ToList();
		}

		private void AddLine(object sender, RoutedEventArgs e)
		{
			Manager.Main.MainFrame.Navigate(new AddLinePage());
		}

		private void OpenInfo(object sender, DataGridBeginningEditEventArgs e)
		{
			Line row = (Line)e.Row.Item;
			Manager.Main.MainFrame.Navigate(new AddLinePage(row.IdLine));
		}

		private void DeleteLine(object sender, RoutedEventArgs e)
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
						Line row = (Line)item;
						db.Lines.Remove(row);
					}
					db.SaveChanges();
					Datagrid.ItemsSource = db.Lines.ToList();
				}
			}
		}
	}
}
