using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Student.Commands
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddStudentCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentCommandHandler(
            IMapper mapper,
            ILogger<AddStudentCommandHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddStudentResult> Handle(AddStudentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var student = new Entity.Student
                {
                    AlternativeId = Guid.NewGuid(),
                    Name = command.Name,
                    LastName = command.LastName,
                    Gender = command.Gender,
                    BirthDate = command.BirthDate.Date,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                var studentRepository = _unitOfWork.GetRepository<Entity.Student>();
                await studentRepository.AddAsync(student);

                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    var result = _mapper.Map<AddStudentResult>(student);
                    return result;
                }
                else
                {
                    _logger.LogError("An error ocurred while creating the Student.");
                    return new AddStudentResult
                    {
                        Success = false,
                        Message = "Failed to save the student."
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating grade for command: {@command}", command);
                throw;
            }

        }
    }
}
