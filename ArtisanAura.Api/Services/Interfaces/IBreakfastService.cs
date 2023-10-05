using ArtisanAura.Api.Models;

namespace ArtisanAura.Api.Services.Interfaces
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        Breakfast GetBreakfast(Guid id);
        void UpsertBreakfast(Breakfast breakfast);
        void DeleteBreakfast(Guid id);
    }
}