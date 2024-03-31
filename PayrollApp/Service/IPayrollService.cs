using Microsoft.AspNetCore.Mvc;
using PayrollApp.Domain.Entity;

namespace PayrollApp.Service
{
    public interface IPayrollService
    {
        Task<IEnumerable<PayDetailModel>> GetEmployeeDetails();
        Task<PayDetailModel>? GetPayDetails(int id);
        Task<bool> SubmitEmployeeDetail(PayDetailModel employee);
    }
}
