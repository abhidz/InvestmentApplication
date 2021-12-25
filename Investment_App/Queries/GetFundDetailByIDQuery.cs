using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Investment_App.Context;
using Investment_App.Model;
using MediatR;

namespace Investment_App.Queries
{
    public class GetFundDetailByIDQuery
    {
        public class Command : IRequest<FundDetail>
        {
            public int ID { get; set; }
        }
        public class Handler : IRequestHandler<Command, FundDetail>
        {
            private readonly IApplicationContext _context;
            public Handler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }
            public async Task<FundDetail> Handle(Command query, CancellationToken cancellationToken)
            {
                var fundList =  _context.FundDetails.AsQueryable().Where(s => s.ID == query.ID).FirstOrDefault();
                if (fundList == null)
                {
                    return null;
                }
                return fundList;
            }
        }
    }
}
