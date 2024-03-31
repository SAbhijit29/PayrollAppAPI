using Microsoft.AspNetCore.Mvc;
using PayrollApp.Domain.Entity;

namespace PayrollApp.Repository
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<PayDetailModel>> GetEmployeeDetails();
        Task<PayDetailModel> GetPayDetails(int id);
        Task<bool> SubmitEmployeeDetail(PayDetailModel employee);
    }
}
