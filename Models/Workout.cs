using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerWebsite.Models;
public class Workout
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }  
    public DateOnly Date { get; set; }
    public int Weight { get; set; }
    public int Reps { get; set; }
}