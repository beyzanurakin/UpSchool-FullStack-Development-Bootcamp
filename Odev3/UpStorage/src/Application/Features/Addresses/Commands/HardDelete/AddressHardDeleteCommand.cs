using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Command.HardDelete
{
    public class AddressHardDeleteCommand : IRequest<Response<int>>
    {
        public Guid AddressId { get; set; }
    }
}