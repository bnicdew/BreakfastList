namespace BuberBreakfast.Breakfast.CreateBreakfastRequest;

public record CreateBreakfastRequest(
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    List<string> Savory,
    List<string> Sweet
);