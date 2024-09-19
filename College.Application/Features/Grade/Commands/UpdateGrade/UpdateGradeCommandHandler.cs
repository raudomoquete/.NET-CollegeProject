using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Grade.Commands
{
    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, UpdateGradeResult>
    {
        private readonly ILogger<UpdateGradeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGradeCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<UpdateGradeCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UpdateGradeResult> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var gradeRepository = _unitOfWork.GetRepository<Entity.Grade>();
                var grade = await gradeRepository.GetById(request.GradeId);

                if (grade == null)
                {
                    return new UpdateGradeResult
                    {
                        Success = false,
                        Message = "Student not found."
                    };
                }

                grade.Name = request.Name;
                grade.ModifiedDate = DateTime.Now;

                gradeRepository.Update(grade);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    var result = _mapper.Map<UpdateGradeResult>(grade);
                    return result;
                }
                else
                {
                    _logger.LogError("Failed to update grade with ID {GradeId}", request.GradeId);
                    return new UpdateGradeResult
                    {
                        Success = false,
                        Message = "Failed to update the grade."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating grade with ID {GradeId}", request.GradeId);
                throw;
            }
        }
    }
}
