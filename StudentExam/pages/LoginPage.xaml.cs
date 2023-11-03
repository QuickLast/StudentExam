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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void AuthTBx_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTBx.Text.Trim();
            string password = PasswordTBx.Password.Trim();

            int errCounter = 0;
            if (login.Length == 0 || password.Length == 0)
            {
                errCounter++;
                ErrorTBk.Text = "Введите данные!";
            }
            if (errCounter == 0)
            {
                ErrorTBk.Text = "";
                List<Employee> employees = DBConn.SEnt.Employee.ToList();
                Employee currentEmployee = employees.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (currentEmployee != null)
                {
                    if (currentEmployee.Position == "зав. кафедрой")
                        NavigationService.Navigate(new ZavCafPage(currentEmployee));
                    else if (currentEmployee.Position == "преподаватель")
                        NavigationService.Navigate(new TeacherPage(currentEmployee));
                    else
                        NavigationService.Navigate(new EngineerPage(currentEmployee));
                }
                else
                {
                    ErrorTBk.Text = "Неверный логин или пароль.";
                }
            }
        }
    }
}
