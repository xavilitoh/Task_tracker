using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services;

public class TaskService
{
    private const string FilePath = "tasks.json";

    public TaskService()
    {
        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }
    }

    public List<TaskModel> GetAllTasks()
    {
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
    }

    public TaskModel? GetTaskById(int id)
    {
        var tasks = GetAllTasks();
        return tasks.FirstOrDefault(t => t.IdTask == id);
    }

    public void AddTask(TaskModel task)
    {
        var tasks = GetAllTasks();
        task.IdTask = tasks.Count != 0 ? tasks.Max(t => t.IdTask) + 1 : 1;
        tasks.Add(task);
        SaveTasks(tasks);
    }

    public void UpdateTask(TaskModel updatedTask)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.IdTask == updatedTask.IdTask);
        if (task == null) return;
        task.Desc = updatedTask.Desc;
        task.Date = updatedTask.Date;
        task.Status = updatedTask.Status;
        task.LastUpdate = DateTime.Now;
        SaveTasks(tasks);
    }

    public void DeleteTask(int id)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.IdTask == id);
        if (task == null) return;
        tasks.Remove(task);
        SaveTasks(tasks);
    }

    private void SaveTasks(List<TaskModel> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}