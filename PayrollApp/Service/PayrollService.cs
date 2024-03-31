using Microsoft.AspNetCore.Mvc;
using PayrollApp.Domain.Entity;
using PayrollApp.Repository;

namespace PayrollApp.Service
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;
        public PayrollService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }
        public async Task<PayDetailModel>? GetPayDetails(int id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid employee ID");
            }

            var result = await _payrollRepository.GetPayDetails(id);

            if (result != null)
            {
                return CalculateEarningsAndDeductions(result)!;
            }
            return result!;
        }

        public async Task<IEnumerable<PayDetailModel>> GetEmployeeDetails()
        {
            var employees = await _payrollRepository.GetEmployeeDetails();
            if (!employees.Any())
            {
                return Enumerable.Empty<PayDetailModel>();
            }
            return employees;
        }
        public async Task<bool> SubmitEmployeeDetail(PayDetailModel employee)
        {
            if(employee.EmployeeCode < 0)
            {
                throw new BadHttpRequestException("invalid Employee code");
            }
            var employees = await _payrollRepository.SubmitEmployeeDetail(employee);
            return employees;
        }

        private static Employee? CalculateEarningsAndDeductions(PayDetailModel employee)
        {
            var obj = new Employee()
            {
                Department = employee.Department,
                Designation = employee.Designation,
                EmployeeName = employee.EmployeeName,
                EmployeeCode = employee.EmployeeCode,
                Gender = employee.Gender,
                BasicSalary = employee.BasicSalary,
                DateOfBirth = employee.DateOfBirth
            };

            //Earnings
            double dearnessAllowance = employee.BasicSalary * 0.4;
            double conveyanceAllowance = Math.Min(dearnessAllowance * 0.1, 250);
            double houseRentAllowance = Math.Max(employee.BasicSalary * 0.25, 1500);
            double grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;//(Do not display Gross Salary)

            //Deductions
            double pt = grossSalary <= 3000 ? 100 : (grossSalary <= 6000 ? 150 : 200);
            double totalSalary = grossSalary - pt;

            // Assign calculated values
            obj.DearnessAllowance = dearnessAllowance;
            obj.ConveyanceAllowance = conveyanceAllowance;
            obj.HouseRentAllowance = houseRentAllowance;
            obj.TotalSalary = totalSalary;
            obj.ProfessionalTax = pt;

            return obj ?? null;
        }

        
    }
}
