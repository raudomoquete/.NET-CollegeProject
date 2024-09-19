using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Student.Commands
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, RemoveStudentResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveStudentCommandHandler> _logger;

        public RemoveStudentCommandHandler(IUnitOfWork unitOfWork, ILogger<RemoveStudentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RemoveStudentResult> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var studentRepository = _unitOfWork.GetRepository<Entity.Student>();
                await studentRepository.DeleteAsync(request.StudentId);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    return new RemoveStudentResult
                    {
                        StudentId = request.StudentId,
                        Success = true,
                        Message = "Student deleted successfully."
                    };
                }
                else
                {
                    _logger.LogError("Failed to delete student with ID {StudentId}", request.StudentId);
                    return new RemoveStudentResult
                    {
                        StudentId = request.StudentId,
                        Success = false,
                        Message = "Failed to delete the student."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student with ID {StudentId}", request.StudentId);
                throw;
            }
        }
    }
}
