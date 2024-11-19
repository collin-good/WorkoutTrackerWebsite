using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WorkoutTrackerWebsite.Data;
using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Services;

public class WorkoutService
{
    public static WorkoutService Instance;
    private readonly WorkoutContext _context;

    public WorkoutService(WorkoutContext context)
    {
        if(Instance == null)
            Instance = this;

        _context = context;
    }

    public List<Workout> GetAll() => _context.Workouts
                                             .AsNoTracking()
                                             .ToList();

    public Workout? Get(int id) => _context.Workouts
                                           .AsNoTracking()
                                           .SingleOrDefault(w => w.Id == id);

    public Workout Add(Workout workout)
    {
        _context.Workouts.Add(workout);
        _context.SaveChanges();

        return workout;
    }

    public void Detete(int id)
    {
        var workoutToDelete = _context.Workouts.Find(id);
        if(workoutToDelete is not null)
        {
            _context.Workouts.Remove(workoutToDelete);
            _context.SaveChanges();
        }
        
    }

    public void Update(Workout workout)
    {
        var workoutToUpdate = _context.Workouts.Find(workout.Id);
        if (workoutToUpdate is null)
        {
            throw new InvalidOperationException("That workout does not exist");
        }

        workoutToUpdate = workout;
        _context.SaveChanges();
    }

    public enum WorkoutSortMethod
    {
        date,
        workoutType
    }