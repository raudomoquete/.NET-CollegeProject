using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Teacher.Queries
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<GetAllTeachersQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllTeachersQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeachersQueryHandler(
            IMapper mapper,
            ILogger<GetAllTeachersQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllTeachersQueryResult>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teacherRepository = _unitOfWork.GetRepository<Entity.Teacher>();
                var teacher = await teacherRepository.GetAllAsync();

                var result = _mapper.Map<List<GetAllTeachersQueryResult>>(teacher);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving teachers for query: {@request}", request);
                throw;
            }
        }
    }
}
