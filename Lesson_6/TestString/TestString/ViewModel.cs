using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TestString
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Model _model = new Model();
        private ActionCommand _addCommand;
        private ActionCommand _addRemoveCommand;

        private ObservableCollection<Department> _department;

        private string _result;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }

        public ICommand Command => _addCommand ?? (
            _addCommand = new ActionCommand(
                ExecuteCommand, CanExecuteCommand));

        private bool CanExecuteCommand(object obj) => TextBoxValue != string.Empty;

        private void ExecuteCommand(object o) =>
            DepEmp = _model.AddDepAndEmp("1", "1", "1");

        public ICommand RemoveCommand => _addRemoveCommand ?? (
            _addRemoveCommand = new ActionCommand(
                Remove, CanRemoveCommand));

        private bool CanRemoveCommand(object obj) => ListBoxValue != string.Empty;

        private void Remove(object o) =>
            _model.RemoveDepAndEmp(o);

        public ObservableCollection<Department> DepEmp
        {
            get => _department;

            set
            {
                _department = value;

                OnPropertyChanged(nameof(DepEmp));
            }
        }

        public string MyValues
        {
            get => _result;
            set
            {
                _result = value;

                OnPropertyChanged(nameof(MyValues));
            }
        }

        public string ListBoxValue { get; set; }
        public string TextBoxValue { get; set; }
    }
}