using ArtisanAura.Api.Models;
using ArtisanAura.Api.Services;
using ArtisanAura.Api.Services.Interfaces;
using ArtisanAura.Contracts.Breakfast;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanAura.Api.Controllers
{
    public class BreakfastController : ApiController
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

            ErrorOr<Created> createdBreakfastResult = _iBreakfastService.CreateBreakfast(breakfast);

            if (createdBreakfastResult.IsError)
            {
                return Problem(createdBreakfastResult.Errors);
            }
            return CreatedAtGetBreakfast(breakfast);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            ErrorOr<Breakfast> getBreakfastResult = _iBreakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(
             breakfast => Ok(MapBreakfastResponse(breakfast)),
             Problem
            );
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
            ErrorOr<UpsertBreakfastResult> upsertBreakfastResult = _iBreakfastService.UpsertBreakfast(breakfast);

            return upsertBreakfastResult.Match(
                upsert => upsert.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
                Problem
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            ErrorOr<Deleted> deletedBreakfastResult = _iBreakfastService.DeleteBreakfast(id);
            return deletedBreakfastResult.Match(deleted => NoContent(), Problem);
        }

        private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        {
            return new BreakfastResponse(
               breakfast.Id,
               breakfast.Name,
               breakfast.Description,
               breakfast.StartDateTime,
               breakfast.EndDateTime,
               breakfast.LastModifiedDateTime,
               breakfast.Savory,
               breakfast.Sweet
           );
        }

        private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
        {
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: MapBreakfastResponse(breakfast)
            );
        }
    }
}