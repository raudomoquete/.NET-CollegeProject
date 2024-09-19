using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetGradeStudentByIdQueryHandler : IRequestHandler<GetGradeStudentByIdQuery, GetGradeStudentQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetGradeStudentByIdQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetGradeStudentByIdQueryHandler(
            IMapper mapper,
            ILogger<GetGradeStudentByIdQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetGradeStudentQueryResult> Handle(GetGradeStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var gradeStudentRepository = _unitOfWork.GetRepository<Entity.GradeStudent>();
            var gradeStudent = await gradeStudentRepository.GetById(request.Id);
            if (gradeStudent == null)
            {
                return null;
            }

            return new GetGradeStudentQueryResult(
                gradeStudent.Id,
                gradeStudent.StudentId,
                gradeStudent.GradeId,
                gradeStudent.SectionGroup
            );
        }
    }
}
