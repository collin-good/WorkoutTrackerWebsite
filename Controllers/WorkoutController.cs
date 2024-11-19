using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerWebsite.Models;
using WorkoutTrackerWebsite.Services;

namespace WorkoutTrackerWebsite.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    public WorkoutController() { }

    //GET
    [HttpGet]
    public ActionResult<List<Workout>> GetAll() => WorkoutService.Instance.GetAll();

    //GET by ID
    [HttpGet("{id}")]
    public ActionResult<Workout> Get(int id)
    {
        var workout = WorkoutService.Instance.Get(id);
        if (workout == null)
            return NotFound();

        return workout;
    }

    //POST
    [HttpPost]
    public IActionResult Create(Workout workout)
    {
        WorkoutService.Instance.Add(workout);
        return CreatedAtAction(nameof(Get), new { id = workout.Id }, workout);
    }

    //PUT
    [HttpPut]
    public IActionResult Update(int id, Workout workout)
    {
        if (id != workout.Id)
            return BadRequest();

        var existingWorkout = WorkoutService.Instance.Get(workout.Id);
        if (existingWorkout is null)
            return NotFound();

        WorkoutService.Instance.Update(workout);
        return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var workout = WorkoutService.Instance.Get(id);
        if (workout is null)
            return NotFound();

        WorkoutService.Instance.Detete(id);
        return NoContent();
    }
}