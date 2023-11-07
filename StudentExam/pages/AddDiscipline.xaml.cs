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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Page
    {
        Employee empToSend = new Employee();
        Cafedra cafToSend = new Cafedra();
        Discipline discipline = new Discipline();
        public AddDiscipline(Cafedra caf, Employee emp)
        {
            InitializeComponent();
            empToSend = emp;
            cafToSend = caf;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinesPage(cafToSend, empToSend));
        }

        private void AddCafBtn_Click(object sender, RoutedEventArgs e)
        {
            int errCounter = 0;
            if (DiscIDTBx.Text.Trim() == "" || NameTBx.Text.Trim() == "" || NumOfHTBx.Text.Trim() == "")
            {
                ErrorTBk.Text = "Введите данные!";
                errCounter++;
            }
            List<Discipline> Disciplines = DBConn.SEnt.Discipline.ToList();
            if (Disciplines.FirstOrDefault(x => x.DisciplineID == int.Parse(DiscIDTBx.Text.Trim())) != null)
            {
                ErrorTBk.Text = "Введите уникальный номер дисциплины!";
                errCounter++;
            }
            if (errCounter == 0)
            {
                string DiscID = DiscIDTBx.Text.Trim();
                string Name = NameTBx.Text.Trim();
                string NumOfHours = NumOfHTBx.Text.Trim();

                discipline.DisciplineID = int.Parse(DiscID);
                discipline.NumberOfHours = int.Parse(NumOfHours);
                discipline.Name = Name;
                discipline.CipherID = cafToSend.CipherID;

                

                DBConn.SEnt.Discipline.Add(discipline);
                DBConn.SEnt.SaveChanges();

                MessageBox.Show("Дисциплина успешно добавлена!");
                NavigationService.Navigate(new DisciplinesPage(cafToSend, empToSend));
            }
        }
    }
}
