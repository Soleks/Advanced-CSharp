using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Lesson_7
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Model _model = new Model();

        ServiceReference1.Service1Client _service;

        private ActionCommand _addCommand;
        private ActionCommand _addRemoveCommand;
        private ActionCommand _addToDbCommand;
        private ActionCommand _removeToDbCommand;
        private ActionCommand _removeAllDbCommand;

        private ObservableCollection<Department> _department;

        public ViewModel()
        {
            _service = new ServiceReference1.Service1Client();
            _department = new ObservableCollection<Department>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Department> Add(
            string Dep,
            string EmpName,
            string EmpLastName)
        {
            return DepartmentConvertor(
                _service.SetEmployeeData(Dep, EmpName, EmpLastName));
        }

        private ObservableCollection<Department> Delete(
            object o, 
            ObservableCollection<Department> d)
        {
            Lesson_7.ServiceReference1.Department[] list = new ServiceReference1.Department[d.Count];

            for (int i = 0; i < list.Length; i++)
            {
                foreach (var item in d)
                {
                  // list[i].DepartmentName = item.DepartmentName;

                    list[i] = new ServiceReference1.Department();
                    list[i].Employee = new ServiceReference1.Employee[item.Employee.Count];

                    list[i].DepartmentName = item.DepartmentName;

                    foreach (var iE in item.Employee)
                    {
                        for (int j = 0; j < list[i].Employee.Length; j++)
                        {
                            list[i].Employee[j] = new ServiceReference1.Employee { Name = iE.Name };
                            list[i].Employee[j].LastName = iE.LastName;
                        }
                    }
                }
            }

            var list_ = _service.RemoveDepAndEmp(o, list);
            var a = DepartmentConvertor(list_);
            return a;
        }

        private ObservableCollection<Department> DepartmentConvertor(
          Lesson_7.ServiceReference1.Department[] list)
        {
            foreach (var item in list)
            {
                _department.Add(new Department(item.DepartmentName, new Employee()
                        { Name = item.Employee[0].Name, LastName = item.Employee[0].LastName }));
            }

            return _department;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }

        public ICommand Command => _addCommand ?? (
            _addCommand = new ActionCommand(
                ExecuteCommand, CanExecuteCommand));
        private bool CanExecuteCommand(object obj) =>
             !string.IsNullOrEmpty(Dep) &&
             !string.IsNullOrEmpty(EmpName) &&
             !string.IsNullOrEmpty(EmpLastName);

        private void ExecuteCommand(object o) => 
            DepEmp = Add(Dep, EmpName, EmpLastName);
            
        public ICommand RemoveCommand => _addRemoveCommand ?? (
            _addRemoveCommand = new ActionCommand(
                Remove, CanRemoveCommand));
        private bool CanRemoveCommand(object obj) => DepEmp.Count > 0;
        private void Remove(object o) => DepEmp = Delete(o, _department);
        

        //public ICommand RemoveToDbCommand => _removeToDbCommand ?? (
        //    _removeToDbCommand = new ActionCommand(
        //   ExecuteRemoveFromDb, CanRemoveFromDbCommand));
        //private void ExecuteRemoveFromDb(object o) => DepEmp = _model.Delete(o);
        //private bool CanRemoveFromDbCommand(object obj) => DepEmp.Count > 0;

        //public ICommand AddToDbCommand => _addToDbCommand ?? (
        //    _addToDbCommand = new ActionCommand(
        //   ExecuteAddToDb, CanAddToDb));
        //private void ExecuteAddToDb(object obj) => DepEmp = _model.Insert(Dep, EmpName, EmpLastName);
        //private bool CanAddToDb(object obj) => 
        //     !string.IsNullOrEmpty(Dep) &&
        //     !string.IsNullOrEmpty(EmpName) &&
        //     !string.IsNullOrEmpty(EmpLastName);

        //public ICommand RemoveAllDbCommand => _removeAllDbCommand ?? (
        //    _removeAllDbCommand = new ActionCommand(
        //  ExecuteRemoveAllDb, CanRemoveAllDb));

        //private void ExecuteRemoveAllDb(object obj) => DepEmp = _model.Truncate();

        //private bool CanRemoveAllDb(object obj) => DepEmp.Count > 0;

        public ObservableCollection<Department> DepEmp
        {
            get => _department;
            
            set
            {
                _department = value;

                OnPropertyChanged(nameof(DepEmp));
            }
        }

        public string Dep { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
    }
}