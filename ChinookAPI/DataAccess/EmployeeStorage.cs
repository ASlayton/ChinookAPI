using ChinookAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.DataAccess
{
    public class EmployeeStorage
    {
        static List<Employee> _cStorage = new List<Employee>();
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
                command.CommandText = @"select FullName = e.FirstName + ' ' + e.LastName, i.InvoiceId
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
    }
}
