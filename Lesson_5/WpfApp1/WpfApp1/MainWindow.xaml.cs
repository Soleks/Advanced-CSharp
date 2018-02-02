using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Department> department = new ObservableCollection<Department>();

        List<Employee> list = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();

            //list.Add(new Employee() { Name = "Вася", LastName = "Пупкин" });
            //list.Add(new Employee() { Name = "Петя", LastName = "Головняк" });
            //list.Add(new Employee() { Name = "Витя", LastName = "Круглый" });

            department.Add(
                new Department("1", new Employee() { Name = "Вася", LastName = "Пупкин" }));
            department.Add(
                new Department("1", new Employee() { Name = "Петя", LastName = "Головняк" }));
            department.Add(
                new Department("1", new Employee() { Name = "Витя", LastName = "Круглый" }));

            lbEmployees.ItemsSource = department;           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow childWindow = new ChildWindow();
            childWindow.Owner = this;
            childWindow.ViewModel = "ViewModel";
            childWindow.Show();
            childWindow.ShowViewModel();
        }

        public void Save(string department, string name, string lastName)
        {
            Console.WriteLine($"{department} {name} {lastName}");
        }

        private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }

        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    department.Add(new Department("2", new Employee("Зина", "Иваноdа")));
        //}
    }
}
