using Application.Dtos;
using MediatR;

namespace Application.Features.Enterprises.Commands.EnterpriseInsertCommand
{
    public class EnterpriseInsertCommand : IRequest<bool>
    {
        public EnterpriseDto enterprise;

        public EnterpriseInsertCommand(EnterpriseDto enterpriseParam)
        {
            enterprise = enterpriseParam;
        }
    }
}
