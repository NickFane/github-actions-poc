using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetApi.Application.Queries;
using PetApi.Contracts.Models;

namespace PetApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PetController> _logger;

        public PetController(IMediator mediator, ILogger<PetController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Pet>> GetPetById(long petId)
        {
            _logger.LogInformation("Received request for Pet {@petId}", petId);

            return Ok(await _mediator.Send(new GetPetQuery(petId)));
        }
    }
}
