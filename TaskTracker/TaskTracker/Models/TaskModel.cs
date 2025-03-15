using TaskTracker.Enums;

namespace TaskTracker.Models;

public class TaskModel
{
    public int IdTask { get; set; }
    public required string Desc { get; set; }
    public StatusEnum StatusEnum { get; set; }
    public DateTime Date { get; set; }
    public DateTime LastUpdate { get; set; }
}