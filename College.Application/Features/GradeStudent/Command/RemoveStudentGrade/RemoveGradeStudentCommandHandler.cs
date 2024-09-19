using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.GradeStudent.Command
{
    public class RemoveGradeStudentCommandHandler : IRequestHandler<RemoveGradeStudentCommand, RemoveGradeStudentResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveGradeStudentCommandHandler> _logger;

        public RemoveGradeStudentCommandHandler(
            IUnitOfWork unitOfWork, 
            ILogger<RemoveGradeStudentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RemoveGradeStudentResult> Handle(RemoveGradeStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var gradeStudentRepository = _unitOfWork.GetRepository<Entity.GradeStudent>();
                await gradeStudentRepository.DeleteAsync(request.Id);

                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    return new RemoveGradeStudentResult
                    {
                        Id = request.Id,
                        Success = true,
                        Message = "Register deleted successfully."
                    };
                }
                else
                {
                    _logger.LogError("Failed to delete Grade Student with ID {Id}", request.Id);
                    return new RemoveGradeStudentResult
                    {
                        Id = request.Id,
                        Success = false,
                        Message = "Failed to delete the Grade Student."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student grade with ID {Id}", request.Id);
                throw;
            }
        }
    }
}
