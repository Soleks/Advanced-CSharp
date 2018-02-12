namespace WcfService_
{
    public class Employee
    {
        private string _name;
        private string _lastName;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Employee()
        {
        }

        public override string ToString()
        {
            return $"{Name}\t{LastName}";
        }
    }
}