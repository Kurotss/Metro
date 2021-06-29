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
	/// Логика взаимодействия для AddLinePage.xaml
	/// </summary>
	public partial class AddLinePage : Page
	{
		public int IsAdd { get; set; }
		public int Id { get; set; }
		public string NameLine { get; set; }
		public double LengthLine { get; set; }
		public int FirstDateOpenStation { get; set; }
		public AddLinePage()
		{
			InitializeComponent();
			IsAdd = 1;
		}

		public AddLinePage(int IdLine)
		{
			InitializeComponent();
			MetroContext db = new();
			this.Id = IdLine;
			Line line = db.Lines.Find(IdLine);
			this.DataContext = this;
			this.NameLine = line.NameLine;
			this.LengthLine = (double)line.LengthLine;
			this.FirstDateOpenStation = (int)line.FirstDateOpenStation;
			IsAdd = 0;
		}

		private void SaveInfo(object sender, RoutedEventArgs e)
		{
			MetroContext db = new();
			bool AllCorrect = true;
			if (!Regex.IsMatch(NameInput.Text, @"^[а-яА-Яa-zA-Z]+$") || NameInput.Text.Length < 3)
				AllCorrect = false;
			if (!Regex.IsMatch(LengthInput.Text, @"^\d+\,\d+$"))
				AllCorrect = false;
			if (!Regex.IsMatch(AgeInput.Text, @"^\d\d\d\d+$"))
				AllCorrect = false;
			if (db.Lines.Where(p => p.NameLine == NameInput.Text).ToList().Count != 0)
				AllCorrect = false;
			if (AllCorrect)
			{
				Line line = new();
				if (IsAdd == 0)
				{
					line.IdLine = db.Lines.Find(line.IdLine).IdLine;
				}
				line.NameLine = NameInput.Text;
				line.LengthLine = double.Parse(LengthInput.Text);
				line.FirstDateOpenStation = int.Parse(AgeInput.Text);
				if (IsAdd == 1) db.Lines.Add(line);
				db.SaveChanges();
				MessageBox.Show("Данные успешно добавлены");
			}
			else MessageBox.Show("Некорректные данные");
		}
	}
}
