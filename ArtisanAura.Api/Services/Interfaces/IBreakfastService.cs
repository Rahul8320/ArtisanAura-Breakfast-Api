using ArtisanAura.Api.Models;
using ErrorOr;

namespace ArtisanAura.Api.Services.Interfaces
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        ErrorOr<UpsertBreakfastResult> UpsertBreakfast(Breakfast breakfast);
        ErrorOr<Deleted> DeleteBreakfast(Guid id);
    }
}