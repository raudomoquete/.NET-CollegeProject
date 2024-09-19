using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Student.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateStudentCommandHandler> _logger;

        public UpdateStudentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateStudentCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UpdateStudentResult> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var studentRepository = _unitOfWork.GetRepository<Entity.Student>();
                var student = await studentRepository.GetById(request.StudentId);

                if (student == null)
                {
                    return new UpdateStudentResult
                    {
                        Success = false,
                        Message = "Student not found."
                    };
                }

                student.Name = request.Name;
                student.LastName = request.LastName;
                student.Gender = request.Gender;
                student.BirthDate = request.BirthDate;
                student.ModifiedDate = DateTime.Now;

                studentRepository.Update(student);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    var result = _mapper.Map<UpdateStudentResult>(student);
                    return result;
                }
                else
                {
                    _logger.LogError("Failed to update student with ID {StudentId}", request.StudentId);
                    return new UpdateStudentResult
                    {
                        Success = false,
                        Message = "Failed to update the student."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student with ID {StudentId}", request.StudentId);
                throw;
            }
        }
    }
}
