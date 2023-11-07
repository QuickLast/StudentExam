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
    /// Логика взаимодействия для EditCafedraPage.xaml
    /// </summary>
    public partial class EditCafedraPage : Page
    {
        Employee empToSend = new Employee();
        Cafedra cafToSend = new Cafedra();
        public EditCafedraPage(Cafedra caf, Employee emp)
        {
            InitializeComponent();
            AbbrIDCB.ItemsSource = DBConn.SEnt.Faculty.ToList();
            this.DataContext = this;
            empToSend = emp;
            cafToSend = caf;
            NameTBx.Text = caf.Name;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinesPage(cafToSend, empToSend));
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            string cipher = cafToSend.CipherID;
            string name = NameTBx.Text;
            if (AbbrIDCB.SelectedItem == null)
            {
                ErrorTBk.Text = "Выберите факультет!";
            }
            else
            {
                string AbbrID = (AbbrIDCB.SelectedItem as Faculty).AbbrID;
                if (cipher != "" && name != "" && AbbrID != null)
                {
                    cafToSend.CipherID = cipher;
                    cafToSend.Name = name;
                    cafToSend.AbbrID = AbbrID;

                    ErrorTBk.Text = "";
                    DBConn.SEnt.SaveChanges();
                    MessageBox.Show("Данные изменены.");
                    NavigationService.Navigate(new DisciplinesPage(cafToSend, empToSend));
                }
                else ErrorTBk.Text = "Введите данные!";
            }
        }
    }
}
