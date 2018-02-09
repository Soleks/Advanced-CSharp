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

        public void Select()
        {
            string sqlQuery =
                @"SELECT Department, FirstName, LastName FROM Lesson7";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader =
                command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var LastName = reader["LastName"];
                        var Department = reader["Department"];
                        var FirstName = reader["FirstName"];

                        //привести типы

                        _department.Add(
                                 new Department(departName, new Employee() { Name = empName, LastName = empLastName }));
                    }
                }
                reader.Close();
            }
        }
    
    //public void Truncate()
    //{
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        SqlCommand command = new SqlCommand(sqlExpression, connection);
    //        int number = command.ExecuteNonQuery();
    //    }
    //}
    }
}
