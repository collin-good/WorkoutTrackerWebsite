using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WorkoutTrackerWebsite.Models;
public class Workout
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [Required]
    public DateOnly Date { get; set; }
    public int Weight { get; set; }
    [Required]
    public int Sets { get; set; }
    [Required]
    public int Reps { get; set; }
}