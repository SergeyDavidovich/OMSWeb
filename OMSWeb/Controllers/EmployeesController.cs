using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMSWeb.Queries.Interfaces;
using AutoMapper;
using OMSWeb.Api.Models.Employees;
using OMSWeb.Data.Model;

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesQueryProcessor _query;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/employees/2
        [HttpGet]
        public ActionResult<IEnumerable<IndexEmployeeDto>> GetEmployees()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Employee>, List<IndexEmployeeDto>>(result);
            return items;
        }
    }
}
