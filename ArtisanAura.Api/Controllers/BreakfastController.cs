using ArtisanAura.Api.Models;
using ArtisanAura.Api.ServiceErrors;
using ArtisanAura.Api.Services.Interfaces;
using ArtisanAura.Contracts.Breakfast;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanAura.Api.Controllers
{
    [ApiController]
    [Route("api/breakfast")]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastService _iBreakfastService;

        public BreakfastController(IBreakfastService iBreakfastService)
        {
            _iBreakfastService = iBreakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );
            _iBreakfastService.CreateBreakfast(breakfast);

            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            );

            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: response
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            ErrorOr<Breakfast> getBreakfastResult = _iBreakfastService.GetBreakfast(id);

            if (getBreakfastResult.IsError && getBreakfastResult.FirstError == Errors.Breakfast.NotFound)
            {
                return NotFound();
            }
            var breakfast = getBreakfastResult.Value;

            var response = new BreakfastResponse(
               breakfast.Id,
               breakfast.Name,
               breakfast.Description,
               breakfast.StartDateTime,
               breakfast.EndDateTime,
               breakfast.LastModifiedDateTime,
               breakfast.Savory,
               breakfast.Sweet
           );
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );
            _iBreakfastService.UpsertBreakfast(breakfast);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            _iBreakfastService.DeleteBreakfast(id);
            return NoContent();
        }
    }
}