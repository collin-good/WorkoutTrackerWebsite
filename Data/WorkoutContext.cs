using Microsoft.EntityFrameworkCore;
using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Data;

public class WorkoutContext : DbContext, IWorkoutDB
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options)
    : base(options) { }

    public DbSet<Workout> Workouts => Set<Workout>();

    public void Add(Workout workout)
    {
        Workouts.Add(workout);
    }

    public void Delete(int id)
    {
        Workout? workout = Get(id);
        if (workout is not null)
        {
            Workouts.Remove(workout);
            SaveChangesAsync();
        }
    }

    public List<Workout> Get()
    {
        return Workouts.AsNoTracking().ToList();
    }

    public Workout? Get(int id)
    {
        return Workouts.Find(id);
    }

    public void Update(Workout newWorkout)
    {
        Workout? workoutToUpdate = Get(newWorkout.Id);
        if (workoutToUpdate is null)
        {
            throw new InvalidOperationException();
        }

        workoutToUpdate = newWorkout;
        Update(workoutToUpdate);
        SaveChangesAsync();
    }
}
