using MediatR;
using System.Threading.Tasks;
using Investment_App.Model;
using Investment_App.Context;
using System.Threading;

namespace Investment_App.Commands
{
    public class CreateFundCommand : IRequest<int>
    {
        public CreateOrUpdateFundDetail fundDetails;

        public class CreateFundCommandHandler : IRequestHandler<CreateFundCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateFundCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateFundCommand command, CancellationToken cancellationToken)
            {
                var fundDetail = new FundDetail();
                fundDetail.FundName = command.fundDetails.FundName;
                fundDetail.Description = command.fundDetails.Description;
                _context.FundDetails.Add(fundDetail);
                 await _context.SaveChanges();
                return fundDetail.ID;
            }
        }
    }
}
