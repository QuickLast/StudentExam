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
using StudentExam.db;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        Employee empToSend = new Employee();
        public static List<Exam> Exam { get; set; }
        public TeacherPage(Employee emp)
        {
            InitializeComponent();
            empToSend = emp;
            ExamLV.ItemsSource = DBConn.SEnt.Exam.ToList();
            PrepNameTBk.Text += $" {emp.Surname}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
