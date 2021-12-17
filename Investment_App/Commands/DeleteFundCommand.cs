using MediatR;
using System.Threading.Tasks;
using Investment_App.Context;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Investment_App.Commands
{
    public class DeleteFundCommand : IRequest<int>
    {
        public int ID { get; set; }

        public class DeleteFundCommandHandler : IRequestHandler<DeleteFundCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteFundCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteFundCommand command, CancellationToken cancellationToken)
            {
                var fundDetail =  _context.FundDetails.AsQueryable().Where(u => u.ID == command.ID).FirstOrDefault();
                if (fundDetail == null) return default;
                _context.FundDetails.Remove(fundDetail);
                await _context.SaveChanges();
                return  fundDetail.ID;
            }
        }
    }
}
