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
    /// Логика взаимодействия для EmployeeInfoPage.xaml
    /// </summary>
    public partial class EmployeeInfoPage : Page
    {
        Employee empToSend = new Employee();
        Employee engToSend = new Employee();
        public EmployeeInfoPage(Employee emp, Employee eng)
        {
            InitializeComponent();
            empToSend = emp;
            engToSend = eng;
            EmployeeIDTBk.Text += $" {emp.EmployeeID}";
            CipherIDTBk.Text += $" {emp.CipherID}";
            SurnameTBk.Text += $" {emp.Surname}";
            PositionTBk.Text += $" {emp.Position}";
            SalaryTBk.Text += $" {emp.Salary}";
            if (emp.Chief == emp.EmployeeID)
                ChiefTBk.Text += " Да";
            else ChiefTBk.Text += " Нет";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineerPage(engToSend));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditEmployeePage(empToSend, engToSend));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBConn.SEnt.Employee.Remove(empToSend);
                DBConn.SEnt.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. Возможно, данный пользователь связан с другими таблицами");
            }
            NavigationService.Navigate(new EngineerPage(engToSend));
        }
    }
}
