using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Investment_App.Context;
using Investment_App.Model;
using MediatR;

namespace Investment_App.Queries
{
    public class GetAllFundDetailsQuery 
    {
        public class Command : IRequest<IEnumerable<FundDetail>>
        {
        }
        public class Handler : IRequestHandler<Command, IEnumerable<FundDetail>>
        {
            private readonly IApplicationContext _context;
            public Handler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }
            public async Task<IEnumerable<FundDetail>> Handle(Command query, CancellationToken cancellationToken)
            {
                var fundList = _context.FundDetails.ToList();
                if (fundList == null)
                {
                    return null;
                }
                return fundList;
            }
        }
    }
}

