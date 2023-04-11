using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.GetById
{
    public class AddressGetByIdQueryHandler : IRequestHandler<AddressGetByIdQuery, AddressGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<AddressGetByIdDto> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Addresses.AsQueryable();

            dbQuery = dbQuery.Where(x => x.Id == request.AddressId);

            dbQuery = dbQuery.Include(x => x.Country).Include(x => x.City);

            var address = await dbQuery.FirstOrDefaultAsync(cancellationToken);

            var addressDto = MapAdddresesToGetByIdDtos(address);

            return addressDto.FirstOrDefault();
        }

        private IEnumerable<AddressGetByIdDto> MapAdddresesToGetByIdDtos(Address address)
        {
            yield return new AddressGetByIdDto()
            {
                CityId = address.CityId,
                UserId = address.UserId,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                PostCode = address.PostCode,
                District = address.District,
                CityName = address.City.Name,
                AddressType = address.AddressType.ToString(),
                Name = address.Name,
                CountryId = address.CountryId,
                CountryName = address.Country.Name
            };
        }
    }
}