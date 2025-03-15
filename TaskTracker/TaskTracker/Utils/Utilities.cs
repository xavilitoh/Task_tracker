using Spectre.Console;
using TaskTracker.Models;

namespace TaskTracker.Utils;

public static class Utilities
{
    public static void PrintTable(List<TaskModel> tasks)
    {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Description");
        table.AddColumn("Date");
        table.AddColumn("Last Update");
        table.AddColumn("Status");
            
        foreach (var task in tasks)
        {
            table.AddRow(task.IdTask.ToString(), task.Desc, task.Date.ToShortDateString(), task.LastUpdate.ToShortDateString(), task.Status.ToString());
        }
            
        AnsiConsole.Write(table);
    }
}