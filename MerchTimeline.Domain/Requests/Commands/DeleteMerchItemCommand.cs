using MediatR;

namespace MerchTimeline.Domain.Requests.Commands
{
    public class DeleteMerchItemCommand : AuthenticatedRequestBase, IRequest
    {
        public long Id { get; set; }
    }
}
