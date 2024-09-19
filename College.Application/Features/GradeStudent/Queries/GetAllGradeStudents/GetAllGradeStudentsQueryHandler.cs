using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetAllGradeStudentsQueryHandler : IRequestHandler<GetAllGradeStudentsQuery, List<GetAllGradeStudentsQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllGradeStudentsQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGradeStudentsQueryHandler(
            IMapper mapper,
            ILogger<GetAllGradeStudentsQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllGradeStudentsQueryResult>> Handle(GetAllGradeStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var gradeStudentRepository = _unitOfWork.GetRepository<Entity.GradeStudent>();
                var gradestudents = await gradeStudentRepository.GetAllAsync();

                var result = _mapper.Map<List<GetAllGradeStudentsQueryResult>>(gradestudents);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving the grade students for query: {@request}", request);
                throw;
            }
        }
    }
}
