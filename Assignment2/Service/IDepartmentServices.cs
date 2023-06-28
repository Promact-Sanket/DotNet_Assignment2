using Assignment2.DTO;
using Assignment2.Model;

namespace Assignment2.Service
{
    public interface IDepartmentServices
    {
        Task<List<ResDepartmentDto>> GetAllDepartmentsAsync();
        Task<bool> CheckDepartmentByIdAsync(int Id);
        Task<List<ResDepartmentDto>?> AddDepartmentAsync(DepartmentDto departmentdto);
        Task<ResDepartmentDto?> UpdateDepartmentAsync(ResDepartmentDto departmentdto);
        Task<List<ResDepartmentDto>?> DaleteDepartmentByIdAsync(int Id);

    }
}