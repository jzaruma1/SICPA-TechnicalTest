using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enterprises.Queries.EnterpriseGetQuery
{
    public class EnterpriseGetQuery : IRequest<EnterpriseDto>
    {
        public int enterpriseId;
        public EnterpriseGetQuery(int idParam)
        {
            enterpriseId = idParam;
        }
    }
}
