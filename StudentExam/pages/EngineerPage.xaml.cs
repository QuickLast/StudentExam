﻿using StudentExam.db;
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
    /// Логика взаимодействия для EngineerPage.xaml
    /// </summary>
    public partial class EngineerPage : Page
    {
        Employee empToSend = new Employee();
        public EngineerPage(Employee emp)
        {
            InitializeComponent();
            empToSend = emp;
            EmpLV.ItemsSource = DBConn.SEnt.Employee.ToList();
            EngNameTBk.Text += $" {emp.Surname}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void EmpLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = EmpLV.SelectedItem as Employee;
            if (item != null)
            {
                NavigationService.Navigate(new EmployeeInfoPage(item as Employee, empToSend));
            }

        }
    }
}
