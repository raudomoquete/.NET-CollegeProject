using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;
using College.Application.Common;
using College.Application.Features.Grade.Errors;

namespace College.Application.Features.Grade.Commands
{
    public class AddGradeCommandHandler : IRequestHandler<AddGradeCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddGradeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AddGradeCommandHandler(
            IMapper mapper,
            ILogger<AddGradeCommandHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddGradeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingGrade = await _unitOfWork.GetRepository<Entity.Grade>().FirstOrDefaultAsync(g => g.Name == command.Name);
                if (existingGrade != null)
                {
                    return Result.Failure(GradeErrors.NameAlreadyExists);
                }

                var grade = new Entity.Grade
                {
                    AlternativeId = Guid.NewGuid(),
                    Name = command.Name,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                var gradeRepository = _unitOfWork.GetRepository<Entity.Grade>();
                await gradeRepository.AddAsync(grade);

                var saveResult = await _unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    //var result = _mapper.Map<AddGradeResult>(grade);
                    //return result;
                    return Result.Success(); // Sin datos adicionales, solo éxito
                }
                else
                {
                    _logger.LogError("An error ocurred while creating the grade.");
                    //return null;
                    //return Result.Failure(new Error("GRADE_CREATION_FAILED", "Failed to create the grade."));
                    return Result.Failure(GradeErrors.CreationFailed);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating grade for command: {@command}", command);
                return Result.Failure(new Error("GRADE_CREATION_ERROR", "An unexpected error occurred while creating the grade."));

                //return new AddGradeResult
                //{
                //    Success = false,
                //    Message = "An error occurred while creating the Grade"
                //};
            }

        }
    }
}
