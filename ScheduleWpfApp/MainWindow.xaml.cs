using Microsoft.Win32;
using ScheduleWpfApp.Data;
using ScheduleWpfApp.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace ScheduleWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SessionService _sessionService = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadCinemaInfoAsync();
            //SessionService service = new();
            //var sessions = await service.GetAll();
            //foreach (var session in sessions)
            //    Console.WriteLine($"{session.IdSession} {session.Datetime} {session.IdFilm}");

            //var schedules = await service.GetAllByCinema(new DateTime(2024, 9, 27), "Русь");
            //foreach (var schedule in schedules)
            //    Console.WriteLine($"{schedule.Id} {schedule.FilmName} {schedule.Start:hh\\:mm} {schedule.Price}");
        }


        private async Task LoadCinemaInfoAsync()
        {
            try
            {
                CinemaComboBox.ItemsSource = await _sessionService.GetCinemaHallsAsync();
                DateComboBox.ItemsSource = await _sessionService.GetDateBySession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                InitialDirectory = @"C:\Temp\ispp35\МДК 11.01\LW23Excel",
                Filter = "Excel | *.xlsx;*.csv"
            };

            var excelApp = new Excel.Application();
            excelApp.Visible = true;

            object template = @"C:\Temp\ispp35\МДК 11.01\Temples\Шаблон для фильма (образец).xlsx";
            var workbook = excelApp.Workbooks.Add(template);

            dialog.ShowDialog();
        }
    }
}