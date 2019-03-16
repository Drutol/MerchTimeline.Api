using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Commands
{
    public class DeleteUsagePeriodCommandHandler : IRequestHandler<DeleteUsagePeriodCommand>
    {
        private readonly IServiceBase<MerchItemUsagePeriod> _periodService;

        public DeleteUsagePeriodCommandHandler(IServiceBase<MerchItemUsagePeriod> periodService)
        {
            _periodService = periodService;
        }

        public Task<Unit> Handle(DeleteUsagePeriodCommand request, CancellationToken cancellationToken)
        {
            var period = _periodService.CheckOwnership(request, request.Id);

            _periodService.Remove(period);

            return Unit.Task;
        }
    }
}
