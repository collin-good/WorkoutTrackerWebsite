using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WorkoutTrackerWebsite.Models;
public class Workout : EqualityComparer<Workout>
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

    public override bool Equals(object? obj)
    {
        if (obj is Workout)
        {
            var that = obj as Workout;

            return Id == that!.Id &&
                   Name.Equals(that.Name) &&
                   Date == that.Date &&
                   Weight == that.Weight &&
                   Sets == that.Sets &&
                   Reps == that.Reps;
        }

        return false;
    }

    public override bool Equals(Workout? left, Workout? right)
    {
        if (left is null || right is null)
            return false;

        return  left.Id == right.Id &&
                left.Name.Equals(right.Name) &&
                left.Date == right.Date &&
                left.Weight == right.Weight &&
                left.Sets == right.Sets &&
                left.Reps == right.Reps;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override int GetHashCode([DisallowNull] Workout obj)
    {
        return obj.GetHashCode();
    }

    public static bool operator ==(Workout left, Workout right)
    {
        return  left.Id == right.Id &&
                left.Name.Equals(right.Name) &&
                left.Date == right.Date &&
                left.Weight == right.Weight &&
                left.Sets == right.Sets &&
                left.Reps == right.Reps;
    }

    public static bool operator !=(Workout left, Workout right)
    {
        return !(left.Id == right.Id &&
                left.Name.Equals(right.Name) &&
                left.Date == right.Date &&
                left.Weight == right.Weight &&
                left.Sets == right.Sets &&
                left.Reps == right.Reps);
    }
}