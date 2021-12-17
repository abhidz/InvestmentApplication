using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Investment_App.Context;
using Investment_App.Model;
using MediatR;

namespace Investment_App.Queries
{
    public class GetAllFundDetailsQuery : IRequest<IEnumerable<FundDetail>>
    {
        public class GetAllFundDetailsQueryHandler : IRequestHandler<GetAllFundDetailsQuery, IEnumerable<FundDetail>>
        {
            private readonly IApplicationContext _context;
            public GetAllFundDetailsQueryHandler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }
            public async Task<IEnumerable<FundDetail>> Handle(GetAllFundDetailsQuery query, CancellationToken cancellationToken)
            {
                var fundList = await _context.FundDetails.ToListAsync();
                if (fundList == null)
                {
                    return null;
                }
                return fundList.AsReadOnly();
            }
        }
    }
}
