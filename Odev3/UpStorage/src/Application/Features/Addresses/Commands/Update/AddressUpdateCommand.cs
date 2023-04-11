@@ -0,0 + 1,18 @@
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Command.Update
{
    public class AddressUpdateCommand : IRequest<Response<int>>
    {
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int AddressType { get; set; }
    }
}