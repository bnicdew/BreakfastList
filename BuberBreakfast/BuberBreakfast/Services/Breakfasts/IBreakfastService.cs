using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreateBreakfast(BreakfastMake breakfast);
    BreakfastMake GetBreakfast(Guid id);

    void UpsertBreakfast(BreakfastMake breakfast);

    void DeleteBreakfast(Guid id);
}