using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Lesson_7
{
    class DbClient
    {
        private ObservableCollection<Department> _department = new ObservableCollection<Department>();
        private const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Lesson7; Integrated Security = True";

        public void Insert(string depart, string firstName, string lastName)
        {
            string sqlQuery =
                $@"INSERT INTO Lesson7(Department, FirstName, LastName) VALUES('{depart}', '{firstName}', '{lastName}')";

            Connect(sqlQuery);
        }

        private void Connect(string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public void Delete(Department dep)
        {
            string sqlQuery =
               $@"DELETE FROM Lesson7 WHERE Department = '{dep.DepartmentName}' AND 
                FirstName = '{dep.Employee.First().Name}' AND 
                LastName = '{dep.Employee.First().LastName}'";        

            Connect(sqlQuery);
        }

        public ObservableCollection<Department> Select()
        {
            string sqlQuery =
                @"SELECT Department, FirstName, LastName FROM Lesson7";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader =
                command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Department = reader.GetString(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        
                        _department.Add(
                                 new Department(Department, new Employee() { Name = FirstName, LastName = LastName }));
                    }
                }

                reader.Close();

                return _department;
            }
        }

        public ObservableCollection<Department> Truncate()
        {
            string sqlQuery = @"TRUNCATE TABLE Lesson7";

            Connect(sqlQuery);
            _department.Clear();

            return _department;
        }
    }
}
