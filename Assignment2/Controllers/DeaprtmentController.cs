using Assignment2.Data;
using Assignment2.DTO;
using Assignment2.Model;
using Assignment2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeaprtmentController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;

        public DeaprtmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public async Task<IActionResult>getAllDepartment()
        {
            try
            {
                var departments = await _departmentServices.GetAllDepartmentsAsync();
                if (departments == null)
                    return NotFound();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured :- {ex.Message}" });
            }                     
        }


        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto model)
        {
            try
            {
                var departments = await _departmentServices.AddDepartmentAsync(model);
                if (departments == null)
                    return BadRequest();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured in Adding Department :- {ex.Message}" });
            }
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateDepartment(ResDepartmentDto departmentDTO)
        {
            try
            {
                var departments = await _departmentServices.UpdateDepartmentAsync(departmentDTO);
                if (departments == null)
                    return NotFound();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured in Update Department:- {ex.Message}" });
            }

        }

        [HttpDelete ("{Id}")]
        public async Task<IActionResult> DeleteDepartmentByID(int Id)
        {
            try
            {
                var departments = await _departmentServices.DaleteDepartmentByIdAsync(Id);
                if (departments == null)
                    return NotFound();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = $"There is an Exception Occured in Delete Department:- {ex.Message}" });
            }

        }

    }
}
