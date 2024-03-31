using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PayrollApp.Domain.Entity;
using PayrollApp.Service;
using System.Net;

namespace PayrollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            var response = await _payrollService.GetEmployeeDetails();
            if (!response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("PayDetail/{id}")]
        public async Task<IActionResult> GetPayDetails(int id)
        {
            var res = await _payrollService.GetPayDetails(id)!;
            if(res is null)
            {
                return NotFound(@"For Given "+id+" data not available");
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<HttpStatusCode> SubmitEmployeeDetail([FromBody] PayDetailModel employee)
        {
            var res = await _payrollService.SubmitEmployeeDetail(employee);
            if(res is true)
                return HttpStatusCode.Created;
            return HttpStatusCode.BadRequest;
        }
    }
}
