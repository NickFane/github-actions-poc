using System;
namespace PetApi.Contracts.Models
{
    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
    }
}
