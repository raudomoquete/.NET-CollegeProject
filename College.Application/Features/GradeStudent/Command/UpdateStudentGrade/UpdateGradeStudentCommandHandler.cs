using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.GradeStudent.Command
{
    public class UpdateGradeStudentCommandHandler : IRequestHandler<UpdateGradeStudentCommand, UpdateGradeStudentResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGradeStudentCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGradeStudentCommandHandler(
            IMapper mapper,
            ILogger<UpdateGradeStudentCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateGradeStudentResult> Handle(UpdateGradeStudentCommand request, CancellationToken cancellationToken)
        {
            var studentGradeRepository = _unitOfWork.GetRepository<Entity.GradeStudent>();
            var gradeStudent = await studentGradeRepository.GetById(request.Id);

            if (gradeStudent == null)
            {
                _logger.LogError($"GradeStudent with Id {request.Id} not found.");
                return new UpdateGradeStudentResult
                {
                    Success = false,
                    Message = $"GradeStudent with Id {request.Id} not found."
                };
            }

            gradeStudent.StudentId = request.StudentId;
            gradeStudent.GradeId = request.GradeId;
            gradeStudent.SectionGroup = request.SectionGroup;
            gradeStudent.ModifiedDate = DateTime.Now;

            studentGradeRepository.Update(gradeStudent);

            var saveResult = await _unitOfWork.SaveChangesAsync();

            if (saveResult > 0)
            {
                _logger.LogInformation($"GradeStudent with Id {request.Id} successfully updated.");
                return new UpdateGradeStudentResult
                {
                    Success = true,
                    Message = "GradeStudent updated successfully."
                };
            }
            else
            {
                _logger.LogError("An error occurred while updating the GradeStudent.");
                return new UpdateGradeStudentResult
                {
                    Success = false,
                    Message = "Failed to update the entry."
                };
            }
        }
    }
}
