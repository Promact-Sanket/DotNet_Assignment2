using Assignment2.DTO;

namespace Assignment2.Service
{
    public interface IEmployeeService
    {
        Task<List<ResEmployeeDto>> GetAllEmployeesAsync();
        Task<ResEmployeeDto?> AddEmployeeAsync(EmployeeDto employeeDTO);
        Task<ResEmployeeDto?> GetEmployeeByIdAsync(int Id);
        Task<ResEmployeeDto?> UpdateEmployeeAsync(EmployeeDto employeeDto,int Id);
        Task<List<ResEmployeeDto>?> DaleteEmployeeByIdAsync(int Id);
    }
}