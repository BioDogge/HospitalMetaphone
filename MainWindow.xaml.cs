using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace HospitalMetaphone
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Pages.DoctorPatientPage());
            Manager.MainFrame = MainFrame;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tBlockTime.Text = $"Дата: {DateTime.Now.ToShortDateString()}\t" +
                $"Время: {DateTime.Now.ToShortTimeString()}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
                Manager.MainFrame.GoBack();
        }
    }
}
