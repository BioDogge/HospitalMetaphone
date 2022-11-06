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
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();

            lViewDoctor.ItemsSource = App.Context.Doctor.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tBoxSearch.Text;
            var doctorsMetaphone = App.Context.Database.SqlQuery<string>
                ("SELECT LastName FROM Doctor " +
                $"WHERE dbo.metaphone(LastName) = dbo.metaphone('{lastName}')").ToList();

            if (doctorsMetaphone.Any())
            {
                var doctors = App.Context.Doctor.ToList();
                var doctorsSorted = doctors.ToList();

                doctorsSorted.Clear();
                var doctorsForSearch = doctors.ToList();

                for (int i = 0; i < doctorsMetaphone.Count(); i++)
                {
                    doctors = doctorsForSearch.Where(p => p.LastName == doctorsMetaphone[i]).ToList();
                    doctorsSorted.Add(doctors.First());
                }

                lViewDoctor.ItemsSource = doctorsSorted;
            }
            else
                MessageBox.Show("Фамилия не найдена.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lViewDoctor.ItemsSource = App.Context.Doctor.ToList();
        }
    }
}
