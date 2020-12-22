using PetApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApi.Persistence.Database
{
    public class SampleDatabase : IPetDatabase
    {
        private readonly List<Pet> _petDatabase;

        public SampleDatabase(List<Pet> samplePets)
        {
            _petDatabase = samplePets;
        }

        public async Task<Pet> GetPetById(long petId)
        {
            var pet = _petDatabase.SingleOrDefault(s => s.Id == petId);
            if(pet != null)
            {
                return pet;
            }

            throw new ArgumentNullException(nameof(petId));
        }
    }

    public interface IPetDatabase
    {
        Task<Pet> GetPetById(long petId);
    }
}
