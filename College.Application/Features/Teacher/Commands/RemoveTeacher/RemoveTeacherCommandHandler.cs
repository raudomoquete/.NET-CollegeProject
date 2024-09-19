using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Teacher.Commands
{
    public class RemoveTeacherCommandHandler : IRequestHandler<RemoveTeacherCommand, RemoveTeacherResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveTeacherCommandHandler> _logger;

        public RemoveTeacherCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveTeacherCommandHandler> logger
        )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RemoveTeacherResult> Handle(RemoveTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacherRepository = _unitOfWork.GetRepository<Entity.Teacher>();
                await teacherRepository.DeleteAsync(request.TeacherId);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    return new RemoveTeacherResult
                    {
                        TeacherId = request.TeacherId,
                        Success = true,
                        Message = "Teacher deleted successfully."
                    };
                }
                else
                {
                    _logger.LogError("Failed to delete student with ID {StudentId}", request.TeacherId);
                    return new RemoveTeacherResult
                    {
                        TeacherId = request.TeacherId,
                        Success = false,
                        Message = "Failed to delete the student."
                    };
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error deleting teacher with ID {TeacherId}", request.TeacherId);
                throw;
            }
        }
    }
}
