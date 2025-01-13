using Microsoft.EntityFrameworkCore;
using WorkoutTrackerWebsite.Data;
using WorkoutTrackerWebsite.Models;

namespace WorkoutTrackerWebsite.Services;

public class WorkoutService
{
    private readonly IWorkoutDB _context;
    private WorkoutSortMethod sortMethod = WorkoutSortMethod.date;
    public WorkoutService(WorkoutContext context)
    {
        _context = context;
    }
    public WorkoutService(IWorkoutDB context)
    {
        _context = context;
    }

    public Workout? Get(int id) => _context.Get(id);

    public Workout Add(Workout workout)
    {
        _context.Add(workout);

        return workout;
    }

    public void Detete(int id)
    {
        _context.Delete(id);
    }

    public void Update(Workout workout)
    {
        _context.Update(workout);
    }

    public void UpdateSortMethod(WorkoutSortMethod method)
    {
        sortMethod = method;
    }

    public List<Workout> GetSortedWorkouts()
    {
        List<Workout> workouts = _context.Get();
        QuickSort(workouts, 0, workouts.Count() - 1);

        return workouts;

    }

    /// <summary>
    /// A recursive quicksort algorithm to sort the workout list based on the users prefrence
    /// Based off the quick sort found on https://tutorials.eu/quick-sort-in-c-sharp/
    /// </summary>
    /// <param name="workouts">The list of workouts to sort</param>
    /// <param name="left">The lower bound of the sort</param>
    /// <param name="right">The upper bound of the sort</param>
    private async void QuickSort(List<Workout> workouts, int left, int right)
    {
        int pivot = (sortMethod == WorkoutSortMethod.date) ? await FindPivotUsingDate(workouts, left, right) : await FindPivotUsingName(workouts, left, right);

        QuickSort(workouts, left, pivot - 1);
        QuickSort(workouts, pivot + 1, right);
    }

    private Task<int> FindPivotUsingDate(List<Workout> workouts, int left, int right)
    {
        return Task.Run(() =>
        {
            DateOnly pivot = workouts[right].Date;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (workouts[j].Date <= pivot)
                {
                    i++;
                    Workout temp = workouts[i];
                    workouts[i] = workouts[j];
                    workouts[j] = temp;
                }
            }

            Workout temp1 = workouts[i + 1];
            workouts[i + 1] = workouts[right];
            workouts[right] = temp1;

            return i + 1;
        });
    }

    private Task<int> FindPivotUsingName(List<Workout> workouts, int left, int right)
    {
        return Task.Run(() =>
        {
            string pivot = workouts[right].Name;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (string.Compare(workouts[j].Name, pivot) < 0)
                {
                    i++;
                    Workout temp = workouts[i];
                    workouts[i] = workouts[j];
                    workouts[j] = temp;
                }
            }

            Workout temp1 = workouts[i + 1];
            workouts[i + 1] = workouts[right];
            workouts[right] = temp1;

            return i + 1;
        });
    }
}

public enum WorkoutSortMethod
{
    date,
    workoutType
}
