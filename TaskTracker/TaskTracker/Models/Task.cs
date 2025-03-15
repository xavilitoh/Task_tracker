namespace TaskTracker.Models;

public class Task
{
    public int IdTask { get; set; }
    public required string Desc { get; set; }
    public DateTime Date { get; set; }
    public DateTime LastUpdate { get; set; }
}