using Application.Features.Cities.Queries.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.GetAll
{
    public class AddressGetAllQuery : IRequest<List<AddressGetAllDto>>
    {

        public string? UserId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? AddressType { get; set; }
        public bool? IsDeleted { get; set; } //for soft delete 

        public AddressGetAllQuery(string? userId, int? countryId, int? cityId, int? addressType, bool? isDeleted)
        {
            UserId = userId;
            CountryId = countryId;
            CityId = cityId;
            AddressType = addressType;
            IsDeleted = isDeleted;
        }
    }
}