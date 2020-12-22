using MediatR;
using PetApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApi.Application.Queries
{
    public class GetPetQuery : IRequest<Pet>
    {
        public GetPetQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
