using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.GradeStudent.Command
{
    public class AddGradeStudentCommandHandler : IRequestHandler<AddGradeStudentCommand, AddGradeStudentResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddGradeStudentCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AddGradeStudentCommandHandler(
            IMapper mapper,
            ILogger<AddGradeStudentCommandHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddGradeStudentResult> Handle(AddGradeStudentCommand request, CancellationToken cancellationToken)
        {
            var gradeStudent = new Entity.GradeStudent
            {
                AlternativeId = Guid.NewGuid(),
                StudentId = request.StudentId,
                GradeId = request.GradeId,
                SectionGroup = request.SectionGroup,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var studentGradeRepository = _unitOfWork.GetRepository<Entity.GradeStudent>();
            await studentGradeRepository.AddAsync(gradeStudent);

            var saveResult = await _unitOfWork.SaveChangesAsync();

            if (saveResult > 0)
            {
                var result = _mapper.Map<AddGradeStudentResult>(gradeStudent);
                return result;
            }
            else
            {
                _logger.LogError("An error ocurred while creating the GradeStudent.");
                return new AddGradeStudentResult
                {
                    Success = false,
                    Message = "Failed to save the new entry."
                };
            }
        }
    }
}
