using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestString
{
    class Model
    {
        private ObservableCollection<Department> _department;

        public Model()
        {
            _department = new ObservableCollection<Department>();
        }

        public string Add(string TextBoxValue)
        {
            return TextBoxValue + Value;
        }

        public ObservableCollection<Department> AddDepAndEmp(
            string departName, 
            string empName, 
            string empLastName)
        {
            _department.Add(
                new Department("1", new Employee() { Name = "Вася", LastName = "Пупкин" }));
            _department.Add(
                new Department("1", new Employee() { Name = "Петя", LastName = "Голованов" }));
            _department.Add(
                new Department("1", new Employee() { Name = "Витя", LastName = "Круглов" }));

            _department.Add(
                new Department(departName, new Employee() { Name = empName, LastName = empLastName }));

            return _department;
        }

        public void RemoveDepAndEmp(object o)
        {
            int index;

            if (int.TryParse(o.ToString(), out index) && 
                index >= 0 && index < _department.Count)
            {
                _department.RemoveAt(index);
            }
        }

        public string Value
        {
            get { return "****"; }
        }
    }
}
