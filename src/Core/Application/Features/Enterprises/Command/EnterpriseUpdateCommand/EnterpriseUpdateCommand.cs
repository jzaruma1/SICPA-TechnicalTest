using Application.Dtos;
using MediatR;

namespace Application.Features.Enterprises.Commands.EnterpriseUpdateCommand
{
    public class EnterpriseUpdateCommand : IRequest<bool>
    {
        public EnterpriseDto enterprise;
        public int enterpriseId;
        public EnterpriseUpdateCommand(EnterpriseDto enterpriseParam, int idParam)
        {
            enterprise = enterpriseParam;
            enterpriseId = idParam;
        }
    }
}
