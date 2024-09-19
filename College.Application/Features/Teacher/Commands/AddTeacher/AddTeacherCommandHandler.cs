using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Teacher.Command
{
    public class AddTeacherCommandHandler : IRequestHandler<AddTeacherCommand, AddTeacherResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddTeacherCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AddTeacherCommandHandler(
            IMapper mapper,
            ILogger<AddTeacherCommandHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddTeacherResult> Handle(AddTeacherCommand commnand, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = new Entity.Teacher
                {
                    AlternativeId = Guid.NewGuid(),
                    Name = commnand.Name,
                    LastName = commnand.LastName,
                    Gender = commnand.Gender,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                var teacherRepository = _unitOfWork.GetRepository<Entity.Teacher>();
                await teacherRepository.AddAsync(teacher);

                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    var result = _mapper.Map<AddTeacherResult>(teacher);
                    return result;
                }
                else
                {
                    _logger.LogError("An error ocurred while creating the Teacher.");
                    return new AddTeacherResult
                    {
                        Success = false,
                        Message = "Failed to save the teacher."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating grade for command: {@command}", commnand);
                throw;
            }
        }
    }
}
