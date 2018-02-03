using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
        }

        public string ViewModel { get; set; }

        public string Department
        {
            get { return _department; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string EmpName
        {
            get { return _name; }
        }

        private string _department;
        private string _lastName;
        private string _name;

        public void ShowViewModel()
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _department = dep.Text;
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Abort(object sender, RoutedEventArgs e)
        {
            _department = string.Empty;
            _name = string.Empty;
            _lastName = string.Empty;

            Close();
        }

        private void TextBox_TextChanged_Name(object sender, TextChangedEventArgs e)
        {
            _name = empName.Text;
        }

        private void TextBox_TextChanged_LastName(object sender, TextChangedEventArgs e)
        {
            _lastName = lastName.Text;
        }
    }
}