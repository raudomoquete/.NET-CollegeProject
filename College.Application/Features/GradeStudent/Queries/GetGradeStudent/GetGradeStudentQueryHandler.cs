using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetGradeStudentQueryHandler : IRequestHandler<GetGradeStudentQuery, GetGradeStudentQuery>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetGradeStudentQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<GetGradeStudentQuery> Handle(GetGradeStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Logged from GetGradeStudentQueryHandler");

                var gradeStudentsRepo = _unitOfWork.GetRepository<Entity.GradeStudent>();

                var gradeStudentInfo = gradeStudentsRepo.GetAllAsync();
                if (gradeStudentInfo is null)
                {
                    _logger.LogError("There is no information in the DB or connection could not be made. Try again.");
                    return new GetGradeStudentQuery();
                }

                var queryResults = _mapper.Map<List<GetGradeStudentQueryResult>>(gradeStudentInfo);
                return new GetGradeStudentQuery
                {
                    GradeStudentQueryResults = queryResults,
                    Count = queryResults.Count
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred fetching the informacion.");
                return new GetGradeStudentQuery();
            }
        }
    }
}
