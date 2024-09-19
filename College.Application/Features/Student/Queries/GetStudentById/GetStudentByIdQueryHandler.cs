using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Student.Queries
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetStudentByIdQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentByIdQueryHandler(
            IMapper mapper,
            ILogger<GetStudentByIdQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var studentRepository = _unitOfWork.GetRepository<Entity.Student>();
            var student = await studentRepository.GetById(request.StudentId);
            if (student == null)
            {
                return null;
            }

            return new StudentQueryResult(
                student.StudentId,
                student.Name,
                student.LastName,
                student.Gender,
                student.BirthDate
            );
        }
    }
}
