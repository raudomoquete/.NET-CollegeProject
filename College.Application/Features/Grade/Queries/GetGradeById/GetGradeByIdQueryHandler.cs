using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Grade.Queries
{
    public class GetGradeByIdQueryHandler : IRequestHandler<GetGradeByIdQuery, GradeDataQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetGradeByIdQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetGradeByIdQueryHandler(
            IMapper mapper,
            ILogger<GetGradeByIdQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GradeDataQueryResult> Handle(GetGradeByIdQuery request, CancellationToken cancellationToken)
        {
            var gradeRepository = _unitOfWork.GetRepository<Entity.Grade>();
            var grade = await gradeRepository.GetById(request.GradeId);
            if (grade == null)
            {
                return null;
            }

            return new GradeDataQueryResult(
                grade.GradeId,
                grade.Name,
                grade.TeacherId,
                grade.Teacher
            );
        }
    }
}
