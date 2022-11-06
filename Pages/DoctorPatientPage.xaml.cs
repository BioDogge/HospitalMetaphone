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

namespace HospitalMetaphone.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorPatientPage.xaml
    /// </summary>
    public partial class DoctorPatientPage : Page
    {
        public DoctorPatientPage()
        {
            InitializeComponent();

            lViewDoctorPatient.ItemsSource = App.Context.DoctorPatient.ToList();
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientPage());
        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DoctorPage());
        }
    }
}
