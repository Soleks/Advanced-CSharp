using System.Collections.Generic;
using System.Linq;

namespace Lesson_7
{
    public class Department
    {
        private string _name;
        private List<Employee> _employee;

        public string DepartmentName
        {
            get { return _name; }
            set { _name = value; }
        }

        public IEnumerable<Employee> Employee => _employee;

        public Department()
        {
        }

        public Department(
             string name,
             Employee employee)
        {
            _name = name;
            _employee = new List<Employee>();
            _employee.Add(employee);
        }

        public override string ToString()
        {
            return $"{DepartmentName} {Employee.First().ToString()}";
        }
    }
}