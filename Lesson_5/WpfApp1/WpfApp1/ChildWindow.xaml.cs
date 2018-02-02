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
using System.Windows.Shapes;

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

        public string ViewModel{ get; set; }

        private string _department;
        private string _lastName;
        private string _name;

        public void ShowViewModel()
        {

        }

        private void TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _department = e.Source.ToString();
            Console.WriteLine(e.Source.ToString());
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            
            
            Console.WriteLine( "Ok " + e.Source.ToString());
        }

        private void Button_Click_Abort(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Abort " + e.Source.ToString());
            
            Close();
        }

        private void TextBox_TextChanged_Name(object sender, TextChangedEventArgs e)
        {
            _name = e.Source.ToString();
        }

        private void TextBox_TextChanged_LastName(object sender, TextChangedEventArgs e)
        {
            _lastName = e.Source.ToString();
        }
    }
}
