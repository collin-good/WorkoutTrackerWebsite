using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Services;

public static class WorkoutService
{
    static List<Workout> workouts { get; } 

    static WorkoutService()
    {
        //TODO get workouts from database
        workouts = new();
    }

    public static List<Workout> GetAll() => workouts;

    public static Workout? Get(int id) => workouts.FirstOrDefault(w => w.Id == id);

    public static void Add(Workout workout) => workouts.Add(workout); 

    public static void Detete(int id)
    {
        var workout = Get(id);
        if (workout is null)
            return;

        //TODO update database as well
        workouts.Remove(workout);
    }

    public static void Update(Workout workout)
    {
        var index = workouts.FindIndex(w => w.Id == workout.Id);
        if (index == -1)
            return;

        //TODO update database as well
        workouts[index] = workout;
    }
}