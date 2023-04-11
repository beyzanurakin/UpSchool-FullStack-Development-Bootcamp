using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Domain.Extensions;
using MediatR;

namespace Application.Features.Addresses.Command.Add
{
    public class AddressAddCommandHandler : IRequestHandler<AddressAddCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressAddCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                CityId = request.CityId,
                CountryId = request.CountryId,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false,
                District = request.District,
                Name = request.Name,
                UserId = request.UserId,
                PostCode = request.PostCode,
                AddressType = (AddressType)request.AddressType
            };

            await _applicationDbContext.Addresses.AddAsync(address, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The new address named \"{address.Name}\" was successfully added.");
        }
    }
}