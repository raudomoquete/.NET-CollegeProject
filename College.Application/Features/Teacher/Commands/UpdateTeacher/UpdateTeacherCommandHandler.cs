using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Teacher.Commands
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, UpdateTeacherResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateTeacherCommandHandler> _logger;

        public UpdateTeacherCommandHandler(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ILogger<UpdateTeacherCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<UpdateTeacherResult> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacherRepository = _unitOfWork.GetRepository<Entity.Teacher>();
                var teacher = await teacherRepository.GetById(request.TeacherId);

                if (teacher == null)
                {
                    return new UpdateTeacherResult
                    {
                        Success = false,
                        Message = "Teacher not found."
                    };
                }

                teacher.Name = request.Name;
                teacher.LastName = request.LastName;
                teacher.Gender = request.Gender;
                teacher.ModifiedDate = DateTime.Now;

                teacherRepository.Update(teacher);
                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    var result = _mapper.Map<UpdateTeacherResult>(teacher);
                    return result;
                }
                else
                {
                    _logger.LogError("Failed to update teacher with ID {TeacherId}", request.TeacherId);
                    return new UpdateTeacherResult
                    {
                        Success = false,
                        Message = "Failed to update the teacher."
                    };
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error updating teacher with ID {TeacherId}", request.TeacherId);
                throw;
            }
        }
    }
}
