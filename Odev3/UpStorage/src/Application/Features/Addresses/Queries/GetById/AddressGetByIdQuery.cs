using Application.Features.Addresses.Query.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.GetById
{
    public class AddressGetByIdQuery : IRequest<AddressGetByIdDto>
    {

        public Guid AddressId { get; set; }

        public AddressGetByIdQuery(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}