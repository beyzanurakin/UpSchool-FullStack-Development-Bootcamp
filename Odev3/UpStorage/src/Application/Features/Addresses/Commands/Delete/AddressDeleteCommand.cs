using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Command.Delete
{
    public class AddressDeleteCommand : IRequest<Response<int>>
    {
        public Guid AddressId { get; set; }
    }
}