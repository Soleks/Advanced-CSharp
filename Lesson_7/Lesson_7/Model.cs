using System.Collections.ObjectModel;

namespace Lesson_7
{
    internal class Model
    {
        private ObservableCollection<Department> _department;

        private DbClient _client;

        public Model()
        {
            _department = new ObservableCollection<Department>();
            _client = new DbClient();
        }

        public ObservableCollection<Department> AddDepAndEmp(
            string departName,
            string empName,
            string empLastName)
        {
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

        public ObservableCollection<Department> Insert(
            string departName, 
            string empName, 
            string empLastName)
        {
            _client.Insert(departName, empName, empLastName);

           _department.Add(
                new Department(departName, new Employee() { Name = empName, LastName = empLastName }));
            return _department;
        }



        public ObservableCollection<Department> Delete(object o)
        {
            Department dep = o as Department ;

            if (dep != null)
            {
               _client.Delete(dep);
            }

            _department.Remove(dep);

            return _department;
        }

        public ObservableCollection<Department> Select()
        {
            return _client.Select();
        }

        public ObservableCollection<Department> Truncate()
        {
            return _client.Truncate();
        }

    }
}