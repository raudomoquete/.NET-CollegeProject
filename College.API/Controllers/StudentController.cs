using MediatR;
using Microsoft.AspNetCore.Mvc;
using College.API.ViewModels.StudentInputs;
using College.Application.Features.Student.Commands;
using College.Application.Features.Student.Queries;

namespace College.API.Controllers
{
    [Route("Student")]
    public class StudentController : ApiController
    {
        public StudentController(IMediator mediator,
            ILogger<StudentController> logger) : base (mediator, logger)
        {
            
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentInput studentInput)
        {
            if (studentInput is null)
            {
                return Problem(new List<string> { "Student input cannot be null." });

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentCommand = new AddStudentCommand(
                studentInput.StudentName,
                studentInput.StudentLastName,
                studentInput.StudentGender,
                studentInput.StudentBirthDate.Date
            );

            var result = await _mediator.Send(studentCommand);
            if (result is null)
            {
                return Problem(new List<string> { "Failed to create Student." });
            }

            return Ok(result);
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var query = new GetAllStudentsQuery();
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    return NotFound(new List<string> { "No students found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving students.");
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpDelete("RemoveStudent/{id}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            try
            {
                var command = new RemoveStudentCommand(id);
                var result = await _mediator.Send(command);

                if (!result.Success)
                {
                    return Problem(new List<string> { result.Message });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the student with ID {StudentId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var query = new GetStudentByIdQuery(id);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    return NotFound(new List<string> { "Student not found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the student with ID {StudentId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentInput updateStudentInput)
        {
            if (updateStudentInput is null)
            {
                return Problem(new List<string> { "Student input cannot be null." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateCommand = new UpdateStudentCommand(
                updateStudentInput.StudentId,
                updateStudentInput.Name,
                updateStudentInput.LastName,
                updateStudentInput.Gender,
                updateStudentInput.BirthDate
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
