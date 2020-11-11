using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetApi.Contracts.Models;

namespace PetApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PetController : ControllerBase
    {
        private readonly ILogger<PetController> _logger;

        public PetController(ILogger<PetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Pet> GetPetById(long id)
        {
            return new Pet()
            {
                Id = id,
                Name = $"{id}_name",
                DateOfBirth = DateTime.UtcNow
            };
        }
    }
}
