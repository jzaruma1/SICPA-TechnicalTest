using Application.Dtos;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Enterprises.Queries.EnterpriseGetQuery
{
    public class EnterpriseGetQueryHandler : IRequestHandler<EnterpriseGetQuery, EnterpriseDto>
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseGetQueryHandler(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<EnterpriseDto> Handle(EnterpriseGetQuery request, CancellationToken cancellationToken)
        {
            var execute = _enterpriseRepository.Get(request.enterpriseId);
            execute.Wait();
            return execute.Result;
        }
    }
}
