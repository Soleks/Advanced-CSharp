using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private Department _department;

        public Editor(Department department)
        {
            InitializeComponent();
            _department = department;

            firstName.Text = _department.Employee.First().Name;
            lastName.Text = _department.Employee.First().LastName;
            depart.Text = _department.DepartmentName;
        }

        private void firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _department.Employee.First().Name = firstName.Text;
        }

        private void depart_TextChanged(object sender, TextChangedEventArgs e)
        {
            _department.DepartmentName = depart.Text;
        }

        private void lastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _department.Employee.First().LastName = lastName.Text;
        }
    }
}