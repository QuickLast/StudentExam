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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        public static List<Employee> employees { get; set; }
        Employee empToSend = new Employee();
        Employee engToSend = new Employee();
        Employee employee;
        public EditEmployeePage(Employee emp, Employee eng)
        {
            InitializeComponent();
            employee = new Employee();
            empToSend = emp;
            engToSend = eng;
            CipherIDTBx.Text = emp.CipherID.ToString();
            SurnameTBx.Text = emp.Surname;
            PositionTBx.Text = emp.Position;
            SalaryTBx.Text = emp.Salary.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeInfoPage(empToSend, engToSend));
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            string cipher = CipherIDTBx.Text;
            string surname = SurnameTBx.Text;
            string position = PositionTBx.Text;
            string salary = SalaryTBx.Text;

            if (cipher != "" && surname != "" && position != "" && salary != "")
            {
                empToSend.CipherID = cipher;
                empToSend.Surname = surname;
                empToSend.Position = position;
                empToSend.Salary = Convert.ToDecimal(salary);

                ErrorTBk.Text = "";
                DBConn.SEnt.SaveChanges();
                MessageBox.Show("Данные изменены.");
                NavigationService.Navigate(new EmployeeInfoPage(empToSend, engToSend));
            }
            else ErrorTBk.Text = "Введите данные!";
        }
    }
}
