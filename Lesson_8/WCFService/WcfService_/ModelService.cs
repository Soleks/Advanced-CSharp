using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WcfService_
{
    internal class ModelService
    {
        private List<Department> _department = new List<Department>();

        private Service1 _service;

        public ModelService()
        {
            //_department = new List<Department>();
            _service = new Service1();
        }

        public List<Department> AddDepAndEmp(
            string departName,
            string empName,
            string empLastName)
        {
            _department.Add(
                new Department(departName, new Employee() { Name = empName, LastName = empLastName }));

            return _department;
        }

        public List<Department> RemoveDepAndEmp(object o, List<Department> d)
        {
            int index;

            if (int.TryParse(o.ToString(), out index) &&
                index >= 0 && index < d.Count)
            {
                d.RemoveAt(index);
            }

            return d;
        }

        //public ObservableCollection<DepartmentService> Insert(
        //    string departName, 
        //    string empName, 
        //    string empLastName)
        //{
        //    //_client.Insert(departName, empName, empLastName);

            //   _department.Add(
            //        new Department(departName, new Employee() { Name = empName, LastName = empLastName }));
            //    return _department;
            //}

            //public ObservableCollection<Department> Delete(object o)
            //{
            //    Department dep = o as Department ;

            //    if (dep != null)
            //    {
            //       _client.Delete(dep);
            //    }

            //    _department.Remove(dep);

            //    return _department;
            //}

            //public ObservableCollection<Department> Select()
            //{
            //    return _client.Select();
            //}

            //public ObservableCollection<Department> Truncate()
            //{
            //    return _client.Truncate();
            //}
        }
}