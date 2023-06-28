using Assignment2.Data;
using Assignment2.DTO;
using Assignment2.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Service
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentServices(AppDbContext dbContext,IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ResDepartmentDto>> GetAllDepartmentsAsync()
        {
            List<Department> departments = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<List<ResDepartmentDto>>(departments);
        }

        public async Task<bool> CheckDepartmentByIdAsync(int Id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);
            if (department == null)
                return false;
            return true;
        }

        public async Task<List<ResDepartmentDto>?> AddDepartmentAsync(DepartmentDto departmentdto)
        {
            var DublicateResult = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentName.ToLower() == departmentdto.DepartmentName.ToLower());
           if (DublicateResult != null)
                return null;
            var Departmnet = _mapper.Map<Department>(departmentdto);
            await _dbContext.Departments.AddAsync(Departmnet);
            await _dbContext.SaveChangesAsync();

            return await GetAllDepartmentsAsync();
        }

        public async Task<ResDepartmentDto?> UpdateDepartmentAsync(ResDepartmentDto departmentdto)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == departmentdto.Id);
            if (department == null)
                return null;
            department.DepartmentName= departmentdto.DepartmentName;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ResDepartmentDto>(department);
        }

        public async Task<List<ResDepartmentDto>?> DaleteDepartmentByIdAsync(int Id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);
            if (department == null)            
                return null;                       
             _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();

            return await GetAllDepartmentsAsync();
        }
    }
}
