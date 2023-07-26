//namespace BuberBreakfast.Breakfast.BreakfastResponse;

public record BreakfastResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet
);