using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Data;

/// <summary>
/// 
/// </summary>
public class TestContext : IWorkoutDB
{
    List<Workout> _testDB = new();
    public void Add(Workout workout)
    {
        _testDB.Add(workout);
    }

    public void Delete(int id)
    {
        _testDB.Remove(Get(id));
    }

    public List<Workout> Get()
    {
        return _testDB;
    }

    public Workout? Get(int id)
    {
        return (Workout)(from t in _testDB where t.Id == id select t);
    }

    public void Update(Workout newWorkout)
    {
        Workout workoutToUpdate = Get(newWorkout.Id);

        if (workoutToUpdate is not null)
        {
            int index = _testDB.IndexOf(workoutToUpdate);
            _testDB[index] = newWorkout;
        }
    }
}