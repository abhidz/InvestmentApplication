using MediatR;
using System.Threading.Tasks;
using Investment_App.Model;
using Investment_App.Context;
using System.Threading;
using System.Linq;

namespace Investment_App.Commands
{
    public class UpdateFund
    {
        public class Command : IRequest<CreateFundOrUpdateResult>
        {
            public CreateOrUpdateFundDetail fundDetails;
        }

        public class UpdateFundCommandHandler : IRequestHandler<Command, CreateFundOrUpdateResult>
        {
            private readonly IApplicationContext _context;
            public UpdateFundCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<CreateFundOrUpdateResult> Handle(Command command, CancellationToken cancellationToken)
            {
                var fundDetail = _context.FundDetails.AsQueryable().Where(u => u.ID == command.fundDetails.ID).FirstOrDefault();
                if (fundDetail == null) return null;
                fundDetail.FundName = command.fundDetails.FundName;
                fundDetail.Description = command.fundDetails.Description;
                await _context.SaveChanges();
                return new CreateFundOrUpdateResult() { Id = fundDetail.ID };
            }
        }
    }
}
