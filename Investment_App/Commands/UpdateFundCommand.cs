using MediatR;
using System.Threading.Tasks;
using Investment_App.Model;
using Investment_App.Context;
using System.Threading;
using System.Linq;

namespace Investment_App.Commands
{
    public class UpdateFundCommand : IRequest<int>
    {
        public CreateOrUpdateFundDetail fundDetails;

        public class UpdateFundCommandHandler : IRequestHandler<UpdateFundCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateFundCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateFundCommand command, CancellationToken cancellationToken)
            {
                var fundDetail = _context.FundDetails.AsQueryable().Where(u => u.ID == command.fundDetails.ID).FirstOrDefault();
                if (fundDetail == null) return default;
                else
                {
                    fundDetail.FundName = command.fundDetails.FundName;
                    fundDetail.Description = command.fundDetails.Description;
                    await _context.SaveChanges();
                    return fundDetail.ID;
                }
            }
        }
    }
}
