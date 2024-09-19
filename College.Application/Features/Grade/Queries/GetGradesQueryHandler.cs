using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;

namespace College.Application.Features.Grade.Queries
{
    public class GetGradesQueryHandler : IRequestHandler<GradesQuery, GradesQuery>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetGradesQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetGradesQueryHandler(IMapper mapper, ILogger<GetGradesQueryHandler> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GradesQuery> Handle(GradesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Logged from GetGradesQueryHandler");

                var gradesRepo = _unitOfWork.GetRepository<Domain.Entities.Grade>();

                var gradesInfo = gradesRepo.GetAllAsync();
                if (gradesInfo is null)
                {
                    _logger.LogError("There is no information in the DB or connection could not be made. Try again.");
                    return new GradesQuery();
                }

                var queryResults = _mapper.Map<List<GradeDataQueryResult>>(gradesInfo);

                return new GradesQuery
                {
                    GradeDataQueryResults = queryResults,
                    Count = queryResults.Count
                };

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error ocurred fetching the informacion.");
                return new GradesQuery();
            }
        }
    }
}
