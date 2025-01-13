using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Data;

public interface IWorkoutDB
{
    public List<Workout> Get();
    public Workout? Get(int id);
    public void Add(Workout workout);
    public void Update(Workout newWorkout);
    public void Delete(int id);
}