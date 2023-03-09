using Application.Dtos;
using Application.Helpers;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enterprises.Queries.EnterpriseListQuery
{
    public class EnterpriseListQueryHandler : IRequestHandler<EnterpriseListQuery, PagedResponseDto<EnterpriseDto>>
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseListQueryHandler(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<PagedResponseDto<EnterpriseDto>> Handle(EnterpriseListQuery request, CancellationToken cancellationToken)
        {
            var enterprises = await _enterpriseRepository.GetAll();
            return await enterprises.GetPagedAsync(request.parameter.PageNumber, request.parameter.PageSize);
        }
    }
}
