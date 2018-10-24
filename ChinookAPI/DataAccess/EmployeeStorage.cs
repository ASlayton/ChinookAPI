using ChinookAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.DataAccess
{
    public class EmployeeStorage
    {
        static List<Employee> _eStorage = new List<Employee>();
        Dictionary<string, int> agents = new Dictionary<string, int>();
        private const string ConnectionString = "Server=(local);Database=Chinook;Trusted_Connection=True;";

        /******************************************************
        Exercise 1:
        Provide an endpoint that shows the invoices associated
        with each sales agent. The result should include the 
        Sales Agent's full name.
        ******************************************************/
        public Dictionary<string, int> GetSalesAgents()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var command = db.CreateCommand();
                command.CommandText = @"select 
                                          FullName = e.FirstName + ' ' + e.LastName,
                                          i.InvoiceId
                                        from Customer c
                                        join Employee e
                                          on c.SupportRepId = e.EmployeeId
                                        join Invoice i
                                          on i.CustomerId = c.CustomerId";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    agents.Add(reader["FullName"].ToString(), (int) reader["InvoiceId"]);
                }
                return agents;
            }
        }

        public Employee GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select *
                                        from Employee
                                        where EmployeeId = @id";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var Employee = new Employee
                    {
                        LastName = reader["LastName"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        Title = reader["Title"].ToString(),
                        ReportsTo = (int)reader["ReportsTo"],
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString(),
                        PostalCode = reader["PostalCode"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Fax = reader["Fax"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    return Employee;
                }
                return null;
            }
        }

        /******************************************************
        Exercise 2:
        Provide an endpoint that shows the Invoice Total, 
        Customer name, Country and Sale Agent name for all
        invoices.
        ******************************************************/
        public DataTable Number2()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select 
                                          i.InvoiceId,
                                          i.Total,
                                          CustomerName = c.FirstName + ' ' + c.LastName,
                                          i.BillingCountry,
                                          SalesAgent = e.FirstName + ' ' + e.LastName
                                        from Invoice i
                                        join Customer c
                                          on i.CustomerId = c.CustomerId
                                        join Employee e
                                          on c.SupportRepId = e.EmployeeId";
                
                var table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
        }

        /******************************************************
        Exercise 3:
        Looking at the InvoiceLine table, provide an endpoint 
        that COUNTs the number of line items for an Invoice 
        with a parameterized Id from user input
        ******************************************************/

        public DataTable Number3()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"";

                var table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
        }
    }
}
