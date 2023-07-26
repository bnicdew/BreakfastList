using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Breakfast.CreateBreakfastRequest;
using BuberBreakfast.Breakfast.UpsertBreskfastRequest;
using BuberBreakfast.Models;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        //Mapping data in request to application
        var breakfast = new BreakfastMake(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //Save breakfast to database

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
        return CreatedAtAction(nameof(GetBreakfast), new { id = breakfast.Id }, value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        BreakfastMake breakfast = _breakfastService.GetBreakfast(id);

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
         var breakfast = new BreakfastMake(
            id,
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _breakfastService.UpsertBreakfast(breakfast);

        //TODO: return 201 if a new breakfast was created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
}

