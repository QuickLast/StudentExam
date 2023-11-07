using StudentExam.db;
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

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для ZavCafPage.xaml
    /// </summary>
    public partial class ZavCafPage : Page
    {
        Employee empToSend = new Employee();
        public static List<Exam> Exam { get; set; }
        public ZavCafPage(Employee emp)
        {
            InitializeComponent();
            empToSend = emp;
            CafLV.ItemsSource = DBConn.SEnt.Cafedra.ToList();
            ZavNameTBk.Text += $" {emp.Surname}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void AddCafBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCafForm(empToSend));
        }

        private void CafLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = CafLV.SelectedItem as Cafedra;
            if (item != null)
            {
                NavigationService.Navigate(new StudentsExamPage(item, empToSend));
            }
        }
    }
    }
}
