using MediatR;
using Microsoft.AspNetCore.Mvc;
using College.API.ViewModels.TeacherInputs;
using College.Application.Features.Teacher.Command;
using College.Application.Features.Teacher.Commands;
using College.Application.Features.Teacher.Queries;

namespace College.API.Controllers
{
    [Route("Teacher")]
    public class TeacherController : ApiController
    {
        public TeacherController(
            IMediator mediator,
            ILogger<TeacherController> logger) : base(mediator, logger)
        {
            
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherInput teacherInput)
        {
            if (teacherInput is null)
            {
                return Problem(new List<string> { "Teacher input cannot be null." });

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherCommand = new AddTeacherCommand(
                teacherInput.Name,
                teacherInput.LastName,
                teacherInput.Gender
            );

            var result = await _mediator.Send(teacherCommand);
            if (result is null)
            {
                return Problem(new List<string> { "Failed to create Teacher." });
            }

            return Ok(result);
        }

        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var query = new GetAllTeachersQuery();
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    return NotFound(new List<string> { "No teachers found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving teachers.");
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpDelete("RemoveTeacher/{id}")]
        public async Task<IActionResult> RemoveTeacher(int id)
        {
            try
            {
                var command = new RemoveTeacherCommand(id);
                var result = await _mediator.Send(command);

                if (!result.Success)
                {
                    return Problem(new List<string> { result.Message });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the teacher with ID {TeacherId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpGet("GetTeacherById/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            try
            {
                var query = new GetTeacherByIdQuery(id);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    return NotFound(new List<string> { "Teacher not found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the teacher with ID {TeacherId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherInput updateTeacherInput)
        {
            if (updateTeacherInput is null)
            {
                return Problem(new List<string> { "Teacher input cannot be null." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateCommand = new UpdateTeacherCommand(
                updateTeacherInput.TeacherId,
                updateTeacherInput.Name,
                updateTeacherInput.LastName,
                updateTeacherInput.Gender
            );

            var result = await _mediator.Send(updateCommand);
            if (!result.Success)
            {
                return Problem(new List<string> { result.Message });
            }

            return Ok(result);
        }
    }
}
