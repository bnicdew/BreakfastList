namespace BuberBreakfast.Services.Breakfasts;

using BuberBreakfast.Models;

public class BreakfastService : IBreakfastService {

    private static readonly Dictionary<Guid, BreakfastMake> _breakfasts = new();
    public void CreateBreakfast(BreakfastMake breakfast) {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public BreakfastMake GetBreakfast(Guid id) {
        throw new NotImplementedException();
    }

    public void UpsertBreakfast(BreakfastMake breakfast) {
         _breakfasts[breakfast.Id] = breakfast;
    }

    public void DeleteBreakfast(Guid id) {
        _breakfasts.Remove(id);
    }
 }