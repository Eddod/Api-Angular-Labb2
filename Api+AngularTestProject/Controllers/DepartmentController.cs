using Api_AngularTestProject.Interfaces;
using Api_AngularTestProject;
using Microsoft.AspNetCore.Mvc;

namespace Labb2AvanceradSystemUtveckling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _IDepartment;
        public DepartmentController(IDepartmentRepository iDepartment)
        {
            _IDepartment = iDepartment;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _IDepartment.GetAll();
            return Ok(departments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var department = await _IDepartment.GetById(id);
            if (department != null)
            {
                return Ok(department);
            }
            return NotFound("Could not find department");
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {

                _IDepartment.Add(department);
                await _IDepartment.SaveAsync();
                return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
            }
            return BadRequest("Error adding department");

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateDepartment([FromRoute] int id, Department department)
        {

            if (department.Id == id)
            {
                await _IDepartment.Update(department);
                await _IDepartment.SaveAsync();
                return Ok(department);

            }

            return NotFound("Could not find department to update");

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {

            await _IDepartment.Delete(id);
            await _IDepartment.SaveAsync();
            return Ok();

        }
    }
}
