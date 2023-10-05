using ArtisanAura.Api.Models;
using ErrorOr;

namespace ArtisanAura.Api.Services.Interfaces
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        void UpsertBreakfast(Breakfast breakfast);
        void DeleteBreakfast(Guid id);
    }
}