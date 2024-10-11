using MediatR;
using Microsoft.AspNetCore.Mvc;
using College.API.ViewModels.GradeInputs;
using College.Application.Features.Grade.Commands;
using College.Application.Features.Grade.Queries;

namespace College.API.Controllers
{
    [Route("Grade")]
    public class GradeController : ApiController
    {
        public GradeController(IMediator mediator,ILogger<GradeController> logger) : base(mediator, logger)
        {
            
        }

        [HttpPost("AddGrade")]
        public async Task<IActionResult> AddGrade([FromBody] GradeInput gradeInput)
        {
            if (gradeInput is null)
            {
                return Problem(new List<string> { "Grade input cannot be null." });

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gradeCommand = new AddGradeCommand(
                gradeInput.Name
            );

            var result = await _mediator.Send(gradeCommand);
            if (result is null)
            {
                return Problem(new List<string> { "Failed to create Grade." });
            }

            return Ok(result);
        }

        [HttpGet("GetAllGrades")]
        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                var query = new GetAllGradesQuery();
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    return NotFound(new List<string> { "No grades found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving grades.");
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpDelete("RemoveGrade/{id}")]
        public async Task<IActionResult> RemoveGrade(int id)
        {
            try
            {
                var command = new RemoveGradeCommand(id);
                var result = await _mediator.Send(command);

                if (!result.Success)
                {
                    return Problem(new List<string> { result.Message });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the grade with ID {GradeId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpGet("GetGradeById/{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            try
            {
                var query = new GetGradeByIdQuery(id);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    return NotFound(new List<string> { "Grade not found." });
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the grade with ID {GradeId}", id);
                return StatusCode(500, new List<string> { "An error occurred while processing your request." });
            }
        }

        [HttpPut("UpdateGrade")]
        public async Task<IActionResult> UpdateGrade([FromBody] UpdateGradeInput updateGradeInput)
        {
            if (updateGradeInput is null)
            {
                return Problem(new List<string> { "Grade input cannot be null." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateCommand = new UpdateGradeCommand(
                updateGradeInput.GradeId,
                updateGradeInput.Name,
                updateGradeInput.TeacherId
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
