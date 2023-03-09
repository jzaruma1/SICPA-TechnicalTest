using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Enterprises.Commands.EnterpriseUpdateCommand
{
    public class EnterpriseUpdateCommandHandler : IRequestHandler<EnterpriseUpdateCommand, bool>
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        public EnterpriseUpdateCommandHandler(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<bool> Handle(EnterpriseUpdateCommand request, CancellationToken cancellationToken)
        {
            var execute = _enterpriseRepository.Update(request.enterprise);
            execute.Wait();
            return execute.Result;
        }
    }
}
