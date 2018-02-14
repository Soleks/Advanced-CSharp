using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        int Sum();

        [OperationContract]
        List<Department> SetEmployeeData(string dep, string name, string lastName);

        [OperationContract]
        List<Department> RemoveDepAndEmp(object o, List<Department> d);
    }

    [DataContract]
    public class EmployeeData
    {
        private string _departmentName = "";
        private string _employeeFirstName = "";
        private string _employeeLastName = "";

        [DataMember]
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        [DataMember]
        public string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; }
        }
        [DataMember]

        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; }
        }
    }
}
