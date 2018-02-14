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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        private ModelService _model;

        public List<Department> SetEmployeeData(string dep, string name, string lastName)
        {
            _model = new ModelService();

            return _model.AddDepAndEmp(
               dep,
               name,
               lastName);
        }

        public List<Department> RemoveDepAndEmp(
            object o, 
            List<Department> d)
        {
            _model = new ModelService();

            return _model.RemoveDepAndEmp(o, d);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public int Sum()
        {
            return 1 + 1;
        }
    }
}
