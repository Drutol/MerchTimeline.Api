using MediatR;

namespace MerchTimeline.Domain.Requests
{
    public interface IAuthenticatedRequest
    {
        string Token { get; set; }
        long UserId { get; set; }
    }
}
