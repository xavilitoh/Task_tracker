using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Services;

public class TaskService
{
    private readonly string _filePath = "tasks.json";

    public TaskService()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    public List<TaskModel> GetAllTasks()
    {
        var json = File.ReadAllText(_filePath);
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
        task.IdTask = tasks.Any() ? tasks.Max(t => t.IdTask) + 1 : 1;
        tasks.Add(task);
        SaveTasks(tasks);
    }

    public void UpdateTask(TaskModel updatedTask)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.IdTask == updatedTask.IdTask);
        if (task != null)
        {
            task.Desc = updatedTask.Desc;
            task.Date = updatedTask.Date;
            task.LastUpdate = DateTime.Now;
            SaveTasks(tasks);
        }
    }

    public void DeleteTask(int id)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.IdTask == id);
        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks(tasks);
        }
    }

    private void SaveTasks(List<TaskModel> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}