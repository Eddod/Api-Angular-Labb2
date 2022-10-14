using Api_AngularTestProject.Interfaces;
using Api_AngularTestProject;
using Microsoft.AspNetCore.Mvc;

namespace Labb2AvanceradSystemUtveckling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private readonly IStaffRepository _IStaff;
        private readonly IDepartmentRepository _IDepartmentrepo;
        public StaffController(IStaffRepository staff, IDepartmentRepository iDepartmentrepo)
        {
            _IStaff = staff;
            _IDepartmentrepo = iDepartmentrepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _IStaff.GetAll();

            return Ok(staff);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetSingle")]
        public async Task<IActionResult> GetStaffById([FromRoute] Guid id)
        {
            var singleStaff = await _IStaff.GetById(id);
            if (singleStaff != null)
            {
                return Ok(singleStaff);
            }
            return NotFound("Could not find staff");
        }


        [HttpPost]
        public async Task<ActionResult<Staff>> AddStaff(Staff personal)
        {

            if (ModelState.IsValid)
            {
                personal.Id = Guid.NewGuid();
                _IStaff.Add(personal);
                await _IStaff.SaveAsync();
                return CreatedAtAction(nameof(GetStaffById), new { ID = personal.Id }, personal);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        //[Route("{id:guid}")]
        public async Task<IActionResult> UpdateStaff(Guid id, Staff person)
        {
            try
            {
                _IStaff.Update(person);
                await _IStaff.SaveAsync();
                return Ok(person);
            }
            catch (Exception)
            {
                return NotFound("Could not find staff with that ID");
            }



        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveStaff([FromRoute] Guid id)
        {
            try
            {

                await _IStaff.Delete(id);
                await _IStaff.SaveAsync();
                return Ok();

            }
            catch (ArgumentNullException)
            {

                return NotFound("Could not find staff with that ID");
            }
        }
    }
}
