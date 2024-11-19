using Microsoft.EntityFrameworkCore;
using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Data;

public class WorkoutContext :DbContext
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options)
    : base(options) { }

    public DbSet<Workout> Workouts => Set<Workout>();
}