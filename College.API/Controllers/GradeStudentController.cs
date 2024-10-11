using MediatR;
using Microsoft.AspNetCore.Mvc;
using College.API.ViewModels.GradeStudentInputs;
using College.Application.Features.GradeStudent.Command;
using College.Application.Features.GradeStudent.Queries;

namespace College.API.Controllers
{
    [Route("GradeStudent")]
    public class GradeStudentController: ApiController
    {
        public GradeStudentController(IMediator mediator,
            ILogger<GradeStudentController> logger) : base(mediator, logger)
        {
            
        }

        [HttpPost("AddGradeStudent")]
        public async Task<IActionResult> AddGradeStudent([FromBody] GradeStudentInput gradeStudentInput)
        {
            if (gradeStudentInput is null)
            {
                return Problem(new List<string> { "Grade Student input cannot be null." });

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gradeStudentCommand = new AddGradeStudentCommand(
                gradeStudentInput.StudentId,
                gradeStudentInput.GradeId,
                gradeStudentInput.SectionGroup
            );

            var result = await _mediator.Send(gradeStudentCommand);
            if (result is null)
            {
                return Problem(new List<string> { "Failed to create Grade Student." });
            }

            return Ok(result);
        }

        [HttpGet("GetAllGradeStudents")]
        public async Task<IActionResult> GetAllGradeStudents()
        {
            try
            {
                var query = new GetAllGradeStudentsQuery();
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    return NotFound(new List<string> { "No grades students found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving grades students.");
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpDelete("RemoveGradeStudent/{id}")]
        public async Task<IActionResult> RemoveGradeStudent(int id)
        {
            try
            {
                var command = new RemoveGradeStudentCommand(id);
                var result = await _mediator.Send(command);

                if (!result.Success)
                {
                    return Problem(new List<string> { result.Message });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the grade student with ID {Id}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpGet("GetGradeStudentById/{id}")]
        public async Task<IActionResult> GetGradeStudentById(int id)
        {
            try
            {
                var query = new GetGradeStudentByIdQuery(id);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    return NotFound(new List<string> { "Grade Student not found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the grade student with ID {Id}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpPut("UpdateGradeStudent")]
        public async Task<IActionResult> UpdateGradeStudent([FromBody] UpdateGradeStudentInput updateGradeStudentInput)
        {
            if (updateGradeStudentInput is null)
            {
                return Problem(new List<string> { "Grade Student input cannot be null." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateCommand = new UpdateGradeStudentCommand(
                updateGradeStudentInput.Id,
                updateGradeStudentInput.StudentId,
                updateGradeStudentInput.GradeId,
                updateGradeStudentInput.SectionGroup
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
