using Application.Dtos;
using Application.Parameters;
using MediatR;

namespace Application.Features.Enterprises.Queries.EnterpriseListQuery
{
    public class EnterpriseListQuery : IRequest<PagedResponseDto<EnterpriseDto>>
    {
        public RequestParameter parameter;
        public EnterpriseListQuery(RequestParameter parameterParams)
        {
            parameter = parameterParams;
        }
    }
}
