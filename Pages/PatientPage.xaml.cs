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
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        public PatientPage()
        {
            InitializeComponent();

            lViewPatient.ItemsSource = App.Context.Patient.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tBoxSearch.Text;
            var patientsMetaphone = App.Context.Database.SqlQuery<string>
                ("SELECT LastName FROM Patient " +
                $"WHERE dbo.metaphone(LastName) = dbo.metaphone('{lastName}')").ToList();

            if (patientsMetaphone.Any())
            {
                var patients = App.Context.Patient.ToList();
                var patientSorted = patients.ToList();

                patientSorted.Clear();
                var patientsForSearch = patients.ToList();

                for (int i = 0; i < patientsMetaphone.Count(); i++)
                {
                    patients = patientsForSearch.Where(p => p.LastName == patientsMetaphone[i]).ToList();
                    patientSorted.Add(patients.First());
                }

                lViewPatient.ItemsSource = patientSorted;
            }
            else
                MessageBox.Show("Фамилия не найдена.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lViewPatient.ItemsSource = App.Context.Patient.ToList();
        }
    }
}
