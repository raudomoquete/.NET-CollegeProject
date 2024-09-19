using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Grade.Commands
{
    public class RemoveGradeCommandHandler : IRequestHandler<RemoveGradeCommand, RemoveGradeResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveGradeCommandHandler> _logger;

        public RemoveGradeCommandHandler
        (
            IUnitOfWork unitOfWork, 
            ILogger<RemoveGradeCommandHandler> logger
        )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RemoveGradeResult> Handle(RemoveGradeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var gradeRepository = _unitOfWork.GetRepository<Entity.Grade>();
                await gradeRepository.DeleteAsync(request.GradeId);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    return new RemoveGradeResult
                    {
                        GradeId = request.GradeId,
                        Success = true,
                        Message = "Grade deleted successfully."
                    };
                }
                else
                {
                    _logger.LogError("Failed to delete grade with ID {GradeId}", request.GradeId);
                    return new RemoveGradeResult
                    {
                        GradeId = request.GradeId,
                        Success = false,
                        Message = "Failed to delete the grade."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting grade with ID {GradeId}", request.GradeId);
                throw;
            }
        }
    }
}
