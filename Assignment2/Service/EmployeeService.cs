using Assignment2.Data;
using Assignment2.DTO;
using Assignment2.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDepartmentServices _departmentServices;

        public EmployeeService(AppDbContext dbContext, IMapper mapper, IDepartmentServices departmentServices)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _departmentServices = departmentServices;
        }

        public async Task<List<ResEmployeeDto>> GetAllEmployeesAsync()
        {
            List<Employee> employees = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<List<ResEmployeeDto>>(employees);
        }

        public async Task<ResEmployeeDto?> GetEmployeeByIdAsync(int Id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.ID == Id);
            if (employee == null)
                return null;
            return _mapper.Map<ResEmployeeDto>(employee);
        }

        public async Task<ResEmployeeDto?> AddEmployeeAsync(EmployeeDto employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            var department = _departmentServices.CheckDepartmentByIdAsync(employeeDTO.DepartmentId);
            if (department.Result == false)
            {
                return null;
            }
            var addedEmployee = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ResEmployeeDto>(addedEmployee);
        }

        public async Task<ResEmployeeDto?> UpdateEmployeeAsync(EmployeeDto employeeDto,int Id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.ID == Id);
            if (employee == null)
                return null;
            //Employee employee = _mapper.Map<Employee>(employeeDto);
            //Employee = employee;
            employee.Name = employeeDto.Name;
            employee.Age = employeeDto.Age;
            employee.Salary = employeeDto.Salary;
            employee.DepartmentId =employeeDto.DepartmentId;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ResEmployeeDto>(employee);
        }

        public async Task<List<ResEmployeeDto>?> DaleteEmployeeByIdAsync(int Id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.ID == Id);
            if (employee == null)
                return null;
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return await GetAllEmployeesAsync();
        }

    }
}
