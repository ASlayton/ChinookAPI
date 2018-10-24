using ChinookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.DataAccess
{
    public class CustomerStorage
    {
        static List<Customer> _cStorage = new List<Customer>();
        private const string ConnectionString = "Server=(local);Database=RabbitAndGeese;Trusted_Connection=True;";
    }
}
