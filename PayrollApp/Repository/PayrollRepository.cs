using Microsoft.AspNetCore.Mvc;
using PayrollApp.Database;
using PayrollApp.Domain.Entity;

namespace PayrollApp.Repository
{
    public class PayrollRepository(IDataAccess data) : IPayrollRepository
    {
        public async Task<IEnumerable<PayDetailModel>> GetEmployeeDetails()
        {
            try
            {
                var sql = "SELECT * FROM Employee";
                var parameters = new { }; 
                var result = await data.ExecuteQuery<PayDetailModel>(sql, parameters);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PayDetailModel> GetPayDetails(int id)
        {
            try
            {
                var sql = "SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCode";
                var parameters = new { EmployeeCode = id }; // Assuming 'id' is the value of the requested parameter
                var result = await data.ExecuteQueryFirst<PayDetailModel>(sql, parameters);
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SubmitEmployeeDetail(PayDetailModel employee)
        {
            try
            {
                var sql = "INSERT INTO Employee (EmployeeCode, EmployeeName, DateOfBirth, Gender, Department, Designation, BasicSalary)" +
                    "VALUES (@EmployeeCode, @EmployeeName, @DateOfBirth, @Gender, @Department, @Designation, @BasicSalary)";
                //var parameters = new { 
                //    EmployeeCode = employee.EmployeeCode ,
                //    EmployeeName = employee.EmployeeName
                //};
                await data.ExecuteSubmit(sql, new PayDetailModel
                {
                    EmployeeName = employee.EmployeeName,
                    Department = employee.Department,
                    EmployeeCode = employee.EmployeeCode,
                    BasicSalary = employee.BasicSalary,
                    DateOfBirth = employee.DateOfBirth,
                    Designation = employee.Designation,
                    Gender = employee.Gender
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
