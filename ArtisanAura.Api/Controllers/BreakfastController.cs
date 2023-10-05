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
            ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet
            );

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;

            ErrorOr<Created> createdBreakfastResult = _iBreakfastService.CreateBreakfast(breakfast);

            return createdBreakfastResult.Match(
                created => CreatedAtGetBreakfast(breakfast),
                Problem
            );
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
            ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet,
                id
            );

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;

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