using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Data;

/// <summary>
/// Contains a list that is used to simulate a small database for testing
/// </summary>
public class WorkoutTestContext : IWorkoutDB
{
    private static DateOnly date = new DateOnly(2025, 1, 16);

    public WorkoutTestContext() { }
    public List<Workout> _testDB { get; private set; } = new List<Workout>
    {
        new Workout(0, "Sit Ups", date, 0, 3, 12),
        new Workout(1, "Bicep Curl", date, 20, 3, 12),
        new Workout(2, "Calf Raise", date, 0, 3, 12)
    };

    public void Add(Workout workout)
    {
        _testDB.Add(workout);
    }

    public void Delete(int id)
    {
        Workout? workoutToDelete = Get(id);

        if (workoutToDelete is not null)
            _testDB.Remove(workoutToDelete);
    }

    public List<Workout> Get()
    {
        return _testDB;
    }

    public Workout? Get(int id)
    {
        return _testDB.FirstOrDefault(w => w.Id == id);
    }

    public void Update(Workout newWorkout)
    {
        Workout? workoutToUpdate = Get(newWorkout.Id);

        if (workoutToUpdate is not null)
        {
            int index = _testDB.IndexOf(workoutToUpdate);
            _testDB[index] = newWorkout;
        }
    }
}