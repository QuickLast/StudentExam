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
    /// Логика взаимодействия для AddCafForm.xaml
    /// </summary>
    public partial class AddCafForm : Page
    {
        public static Cafedra cafedra = new Cafedra();
        Employee empToSend = new Employee();
        public AddCafForm(Employee emp)
        {
            InitializeComponent();
            AbbrIDCB.ItemsSource = DBConn.SEnt.Faculty.ToList();
            this.DataContext = this;
            empToSend = emp;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZavCafPage(empToSend));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int errCounter = 0;
            if (CipherIDTBx.Text.Trim() == "" || NameTBx.Text.Trim() == "" || AbbrIDCB.SelectedItem == null)
            {
                ErrorTBk.Text = "Введите данные!";
                errCounter++;
            }
            else if (CipherIDTBx.Text.Trim().Length == 2  || AbbrIDCB.SelectedItem.ToString().Trim().Length == 2)
            {
                ErrorTBk.Text = "Длина аббревиатур должна быть равна двум символам!";
                errCounter++;
            }
            else
            {
                string CafID = CipherIDTBx.Text.Trim();
                string name = NameTBx.Text.Trim();
                string FacID = AbbrIDCB.SelectedItem.ToString().Trim();

                // вставить сюда

                cafedra.CipherID = CafID;
                cafedra.Name = name;
                cafedra.AbbrID = FacID;

                DBConn.SEnt.Cafedra.Add(cafedra);
                DBConn.SEnt.SaveChanges();

                MessageBox.Show("Кафедра успешно добавлена!");
                NavigationService.Navigate(new ZavCafPage(empToSend));
            }
        }
    }
}
