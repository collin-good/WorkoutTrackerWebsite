using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkoutTrackerWebsite.Models;
using WorkoutTrackerWebsite.Services;

namespace WorkoutTrackerWebsite.Views;

public class WorkoutsListModel : PageModel
{
    [BindProperty]
    public Workout NewWorkout { get; set; } = default!;
    private readonly WorkoutService _service;
    public IList<Workout> WorkoutList { get; set; } = default!;

    public WorkoutsListModel(WorkoutService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        WorkoutList = _service.GetSortedWorkouts();
    }

    public IActionResult OnPost()
    {
        //makes sure NewWorkout is valid
        if (!ModelState.IsValid || NewWorkout == null)
        {
            //if NewWorkout is not valid rerender the page
            return Page();
        }

        //NewWorkout is valid, rerendering the page with the updated list
        _service.Add(NewWorkout);
        return RedirectToAction("Get");
    }
}