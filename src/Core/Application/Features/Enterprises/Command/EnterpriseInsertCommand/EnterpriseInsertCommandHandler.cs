using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Enterprises.Commands.EnterpriseInsertCommand
{
    public class EnterpriseInsertCommandHandler : IRequestHandler<EnterpriseInsertCommand, bool>
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        public EnterpriseInsertCommandHandler(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }
        public async Task<bool> Handle(EnterpriseInsertCommand request, CancellationToken cancellationToken)
        {
            var execute =  _enterpriseRepository.Insert(request.enterprise);
            execute.Wait();
            return execute.Result;
        }
    }
}
