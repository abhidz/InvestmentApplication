using Investment_App.Context;
using Investment_App.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Investment_App.Commands
{
    public class CreateFund
    {
        public class Command : IRequest<CreateFundOrUpdateResult>
        {
            public CreateOrUpdateFundDetail fundDetails;
        }

        public class Handler : IRequestHandler<Command, CreateFundOrUpdateResult>
        {
            private readonly IApplicationContext _context;
            public Handler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<CreateFundOrUpdateResult> Handle(Command command, CancellationToken cancellationToken)
            {
                var fundDetail = new FundDetail();
                fundDetail.FundName = command.fundDetails.FundName;
                fundDetail.Description = command.fundDetails.Description;
                fundDetail.InvestorName = command.fundDetails.InvestorName;
                fundDetail.CurrentValueOfInvestedAmount = command.fundDetails.CurrentValueOfInvestedAmount;
                fundDetail.InvestedAmount = command.fundDetails.InvestedAmount;
                var entity = _context.FundDetails.Add(fundDetail).Entity;
                await _context.SaveChanges();
                return new CreateFundOrUpdateResult() { Id = entity.ID };
            }
        }
    }
}

