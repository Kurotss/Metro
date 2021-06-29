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
	/// <summary>
	/// Логика взаимодействия для AddStopPage.xaml
	/// </summary>
	public partial class AddStopPage : Page
	{
		public AddStopPage()
		{
			InitializeComponent();
			MetroContext db = new();
			FirstInput.ItemsSource = db.Stations.Select(p => p.NameStation).ToList();
			SecondInput.ItemsSource = db.Stations.Select(p => p.NameStation).ToList();
		}

		private void SaveInfo(object sender, RoutedEventArgs e)
		{
			MetroContext db = new();
			bool AllCorrect = true;
			if (DateStartInput.SelectedDate is null)
				AllCorrect = false;
			if (DateEndInput.SelectedDate is null)
				AllCorrect = false;
			if (FirstInput.SelectedIndex == -1)
				AllCorrect = false;
			if (SecondInput.SelectedIndex == -1)
				AllCorrect = false;
			if (AllCorrect)
			{
				/*Line line = new();
				line.NameLine = NameInput.Text;
				line.LengthLine = double.Parse(LengthInput.Text);
				line.FirstDateOpenStation = int.Parse(AgeInput.Text);
				db.Lines.Add(line);
				db.SaveChanges();
				MessageBox.Show("Данные успешно добавлены");*/
			}
			else MessageBox.Show("Некорректные данные");
		}
	}
}
