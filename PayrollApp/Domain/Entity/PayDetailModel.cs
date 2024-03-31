namespace PayrollApp.Domain.Entity
{
    public class PayDetailModel
    {
        public int EmployeeCode { get; set; }
        public required string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public required string Department { get; set; }
        public required string Designation { get; set; }
        public float BasicSalary { get; set; }
        
    }

    public class Employee : PayDetailModel
    {
        public double DearnessAllowance { get; set; }
        public double ConveyanceAllowance { get; set; }
        public double HouseRentAllowance { get; set; }
        public double TotalSalary { get; set; }
        public double ProfessionalTax { get; set; }
    }

}
