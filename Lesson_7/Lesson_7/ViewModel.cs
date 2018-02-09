﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Lesson_7
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Model _model = new Model();
        private ActionCommand _addCommand;
        private ActionCommand _addRemoveCommand;
        private ActionCommand _addToDbCommand;
        private ActionCommand _removeToDbCommand;

        private ObservableCollection<Department> _department;

        private string _result;

        public ViewModel()
        {
            Console.WriteLine("qqqqq");

            _model.Select();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            DepEmp = _model.AddDepAndEmp(Dep, EmpName, EmpLastName);


        public ICommand RemoveCommand => _addRemoveCommand ?? (
            _addRemoveCommand = new ActionCommand(
                Remove, CanRemoveCommand));
        private bool CanRemoveCommand(object obj) => ListBoxValue != string.Empty;
        private void Remove(object o) =>
            _model.RemoveDepAndEmp(o);
        

        public ICommand RemoveToDbCommand => _removeToDbCommand ?? (
            _removeToDbCommand = new ActionCommand(
           ExecuteRemoveFromDb, CanRemoveFromDbCommand));
        private void ExecuteRemoveFromDb(object o) => _model.Delete(o);
        private bool CanRemoveFromDbCommand(object obj) => true; //ListBoxValue != string.Empty;


        public ICommand AddToDbCommand => _addToDbCommand ?? (
            _addToDbCommand = new ActionCommand(
           ExecuteAddToDb, CanAddToDb));
        private void ExecuteAddToDb(object obj) => DepEmp = _model.Insert(Dep, EmpName, EmpLastName);
        private bool CanAddToDb(object obj) => 
             !string.IsNullOrEmpty(Dep) &&
             !string.IsNullOrEmpty(EmpName) &&
             !string.IsNullOrEmpty(EmpLastName);

        public ObservableCollection<Department> DepEmp
        {
            get => _department;
            
            set
            {
                _department = value;

                OnPropertyChanged(nameof(DepEmp));
            }
        }

        //public string MyValues
        //{
        //    get => _result;
        //    set
        //    {
        //        _result = value;

        //        OnPropertyChanged(nameof(MyValues));
        //    }
        //}

        public string ListBoxValue { get; set; }
        public string Dep { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
    }
}