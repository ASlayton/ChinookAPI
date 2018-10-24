using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChinookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeStorage _eStorage;
        public EmployeeController()
        {
            _eStorage = new EmployeeStorage();
        }

        [HttpGet()]
        public IActionResult GetSalesAgents()
        {
            return Ok(_eStorage.GetSalesAgents());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_eStorage.GetById(id));
        }

        [HttpGet]
        public IActionResult GetTable()
        {
            return Ok(_eStorage.Number2());
        }
    }
}
