using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerWebsite.Models;
public class Workout
{
    public Workout() { }

    public Workout(int id, string name, DateOnly date, int weight, int sets, int reps)
    {
        Id = id;
        Name = name;
        Date = date;
        Weight = weight;
        Sets = sets;
        Reps = reps;
    }
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