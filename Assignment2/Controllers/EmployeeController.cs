using Assignment2.DTO;
using Assignment2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllEmployee()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                if (employees == null)
                    return NotFound();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured :- {ex.Message}" });
            }
        }

        [HttpGet ("{Id}")] 
        public async Task<IActionResult> getEmployeeById(int Id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(Id);
                if (employee == null)
                    return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured :- {ex.Message}" });
            }
        }

        [HttpPost] 
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDTO)
        {
            try
            {
                var employee = await _employeeService.AddEmployeeAsync(employeeDTO);               
                if (employee == null)
                    return Conflict(new { message = "Department Id is not exist" });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an exception occured in adding Employee :- {ex.Message}" });
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDTO, int Id)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeeAsync(employeeDTO,Id);
                if (employee == null)
                    return Conflict(new { message = "You are updating wrong Employee (Employee Id Not Exist)" });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an exception occured in Updating Employee :- {ex.Message}" });
            }
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                var employee = await _employeeService.DaleteEmployeeByIdAsync(Id);
                if (employee == null)
                    return Conflict(new { message = "You are deleting wrong Employee (Employee Id Not Exist)" });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an exception occured in Deleting Employee :- {ex.Message}" });
            }
        }

    }
}
