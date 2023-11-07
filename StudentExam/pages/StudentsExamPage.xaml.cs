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
    /// Логика взаимодействия для StudentsExamPage.xaml
    /// </summary>
    public partial class StudentsExamPage : Page
    {
        Exam examToSend = new Exam();
        Employee empToSend = new Employee();
        public StudentsExamPage(Exam exam, Employee teacher)
        {
            InitializeComponent();
            examToSend = exam;
            empToSend = teacher;
            DisciplineNameTBk.Text += $" {(DBConn.SEnt.Discipline.Where(x => x.DisciplineID == exam.DisciplineID).ToList()[0] as Discipline).Name}";
            DateTBk.Text += $" {exam.ExamDate}";
            StudentsLV.ItemsSource = DBConn.SEnt.Student.Where(x => x.RegID == exam.RegID).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage(empToSend));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudent(examToSend, empToSend));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = StudentsLV.SelectedItem as Student;
            if (item != null)
            {
                try
                {
                    DBConn.SEnt.Exam.Remove(DBConn.SEnt.Exam.Where(x => x.RegID == item.RegID) as Exam);
                    DBConn.SEnt.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка. Возможно, данная запись экзамена связана с другими таблицами");
                }
                NavigationService.Navigate(new TeacherPage(empToSend));
            }
        }
    }
}
