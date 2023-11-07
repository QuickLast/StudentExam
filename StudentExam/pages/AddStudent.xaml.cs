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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        Exam examToSend = new Exam();
        Employee empToSend = new Employee();
        Exam exam = new Exam();
        public AddStudent(Exam exam, Employee emp)
        {
            InitializeComponent();
            examToSend = exam;
            empToSend = emp;
            ExamInfoTBk.Text += $" {exam.ExamDate}, {(DBConn.SEnt.Discipline.Where(x => x.DisciplineID == exam.DisciplineID).ToList()[0] as Discipline).Name}, {(DBConn.SEnt.Employee.Where(x => x.EmployeeID == exam.EmployeeID).ToList()[0] as Employee).Surname}, Аудитория {exam.Auditorium}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsExamPage(examToSend, empToSend));
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            int errCounter = 0;
            List<Exam> Exams = DBConn.SEnt.Exam.ToList();
            if (RegIDTBx.Text.Trim() == "" || MarkTBx.Text.Trim() == "")
            {
                ErrorTBk.Text = "Введите данные!";
                errCounter++;
            }
            else if (int.Parse(MarkTBx.Text.Trim()) < 2 || int.Parse(MarkTBx.Text.Trim()) > 5)
            {
                ErrorTBk.Text = "Оценка введена неверно!";
                errCounter++;
            }
            else if (!int.TryParse(RegIDTBx.Text, out _))
            {
                ErrorTBk.Text = "Номер должен состоять только из цифр!";
                errCounter++;
            }
            if (errCounter == 0)
            {
                DateTime ExamDate = examToSend.ExamDate;
                int disciplineID = Convert.ToInt32(examToSend.DisciplineID);
                int regID = int.Parse(RegIDTBx.Text.Trim());
                int empID = Convert.ToInt32(examToSend.EmployeeID);
                string audit = examToSend.Auditorium;
                int mark = int.Parse(MarkTBx.Text);

                exam.ExamDate = ExamDate;
                exam.DisciplineID = disciplineID;
                exam.RegID = regID;
                exam.EmployeeID = empID;
                exam.Auditorium = audit;
                exam.Mark = mark;

                DBConn.SEnt.Exam.Add(exam);
                DBConn.SEnt.SaveChanges();

                MessageBox.Show($"Студент успешно добавлен в экзамен по дисциплине {(DBConn.SEnt.Discipline.Where(x => x.DisciplineID == exam.DisciplineID).ToList()[0] as Discipline).Name}!");
                NavigationService.Navigate(new StudentsExamPage(examToSend, empToSend));
            }
        }
    }
}
