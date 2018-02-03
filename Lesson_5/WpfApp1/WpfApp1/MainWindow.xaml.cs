using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Department> department = new ObservableCollection<Department>();

        private ChildWindow childWindow = new ChildWindow();

        public MainWindow()
        {
            InitializeComponent();

            department.Add(
                new Department("1", new Employee() { Name = "Вася", LastName = "Пупкин" }));
            department.Add(
                new Department("1", new Employee() { Name = "Петя", LastName = "Голованов" }));
            department.Add(
                new Department("1", new Employee() { Name = "Витя", LastName = "Круглов" }));

            lbEmployees.ItemsSource = department;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            childWindow = new ChildWindow();
            childWindow.Owner = this;
            childWindow.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            department.Add(
                new Department(childWindow.Department, new Employee() { Name = childWindow.EmpName, LastName = childWindow.LastName }));
        }
    }
}