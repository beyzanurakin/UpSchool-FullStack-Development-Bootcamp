using Application.Common.Interfaces;
using Application.Features.Cities.Queries.GetAll;
using Domain.Entities;
using Domain.Enums;
using Domain.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.GetAll
{
    public class AddressGetAllQueryHandler : IRequestHandler<AddressGetAllQuery, List<AddressGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<AddressGetAllDto>> Handle(AddressGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Addresses.AsQueryable();

            if (request.CountryId.HasValue) dbQuery = dbQuery.Where(x => x.CountryId == request.CountryId);
            if (!string.IsNullOrEmpty(request.UserId)) dbQuery = dbQuery.Where(x => x.UserId == request.UserId);
            if (request.CityId.HasValue) dbQuery = dbQuery.Where(x => x.CityId == request.CityId);
            if (request.AddressType.HasValue) dbQuery = dbQuery.Where(x => x.AddressType == (AddressType)request.AddressType);
            if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

            dbQuery = dbQuery.Include(x => x.Country).Include(x => x.City);

            var addresses = await dbQuery.ToListAsync(cancellationToken);

            var addressDtos = MapAdddresesToGetAllDtos(addresses);

            return addressDtos.ToList();
        }

        private IEnumerable<AddressGetAllDto> MapAdddresesToGetAllDtos(List<Address> addresses)
        {
            List<AddressGetAllDto> addressGetAllDtos = new List<AddressGetAllDto>();

            foreach (var address in addresses)
            {

                yield return new AddressGetAllDto()
                {
                    Id = address.Id,
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
}