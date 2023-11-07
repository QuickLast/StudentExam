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
    /// Логика взаимодействия для DisciplinesPage.xaml
    /// </summary>
    public partial class DisciplinesPage : Page
    {
        Employee empToSend = new Employee();
        Cafedra cafToSend = new Cafedra();
        public DisciplinesPage(Cafedra caf, Employee emp)
        {
            InitializeComponent();
            empToSend = emp;
            cafToSend = caf;
            DiscLV.ItemsSource = DBConn.SEnt.Discipline.Where(x => x.CipherID == caf.CipherID).ToList();
            CafTBk.Text = caf.Name;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZavCafPage(empToSend));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDiscipline(cafToSend, empToSend));
        }

        private void DeleteDiscBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = DiscLV.SelectedItem as Discipline;
            if (item != null)
            {
                try
                {
                    DBConn.SEnt.Discipline.Remove(item);
                    DBConn.SEnt.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка. Возможно, данная дисциплина связана с другими таблицами");
                }
                NavigationService.Navigate(new DisciplinesPage(cafToSend, empToSend));
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditCafedraPage(cafToSend, empToSend));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DBConn.SEnt.Cafedra.Remove(cafToSend);
            DBConn.SEnt.SaveChanges();
            NavigationService.Navigate(new ZavCafPage(empToSend));
        }
    }
}
