using MediatR;
using PetApi.Contracts.Models;
using PetApi.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetApi.Application.Queries
{
    public class GetPetQueryHandler : IRequestHandler<GetPetQuery, Pet>
    {
        private readonly IPetDatabase _petDatabase;

        public GetPetQueryHandler(IPetDatabase petDatabase)
        {
            _petDatabase = petDatabase;
        }

        public async Task<Pet> Handle(GetPetQuery request, CancellationToken cancellationToken)
        {
            return await _petDatabase.GetPetById(request.Id);
        }
    }
}
