using System.Collections.ObjectModel;

namespace Lesson_6
{
    internal class Model
    {
        private ObservableCollection<Department> _department;

        public Model()
        {
            _department = new ObservableCollection<Department>();
        }

        public ObservableCollection<Department> AddDepAndEmp(
            string departName,
            string empName,
            string empLastName)
        {
            if (!string.IsNullOrEmpty(departName) ||
                !string.IsNullOrEmpty(empName) ||
                !string.IsNullOrEmpty(empLastName))
            {
            }

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
    }
}