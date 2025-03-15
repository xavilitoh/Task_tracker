using Spectre.Console;
            using TaskTracker.Enums;
            using TaskTracker.Models;
            using TaskTracker.Services;
            using TaskTracker.Utils;
            
            var taskService = new TaskService();
            
            if (args.Length == 0)
            {
                Console.WriteLine("No command provided.");
                return;
            }
            
            var command = args[0].ToLower();
            
            switch (command)
            {
                case "add":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Description is required for adding a task.");
                        return;
                    }
                    var newTask = new TaskModel { Desc = args[1], Date = DateTime.Now, LastUpdate = DateTime.Now };
                    taskService.AddTask(newTask);
                    Console.WriteLine("Task added.");
                    break;
            
                case "update":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("ID and description are required for updating a task.");
                        return;
                    }
                    if (int.TryParse(args[1], out int updateId))
                    {
                        var updatedTask = new TaskModel { IdTask = updateId, Desc = args[2], Date = DateTime.Now, LastUpdate = DateTime.Now };
                        taskService.UpdateTask(updatedTask);
                        Console.WriteLine("Task updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;
            
                case "delete":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("ID is required for deleting a task.");
                        return;
                    }
                    if (int.TryParse(args[1], out int deleteId))
                    {
                        taskService.DeleteTask(deleteId);
                        Console.WriteLine("Task deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;
            
                case "list":
                    var tasks = taskService.GetAllTasks();
                    Utilities.PrintTable(tasks);
                    break;
            
                case "list done":
                    var doneTasks = taskService.GetAllTasks().Where(t => t.Status.ToString() == "done").ToList();
                    Utilities.PrintTable(doneTasks);
                    break;
            
                case "list todo":
                    var todoTasks = taskService.GetAllTasks().Where(t => t.Status.ToString() == "todo").ToList();
                    Utilities.PrintTable(todoTasks);
                    break;
            
                case "list in-progress":
                    var inProgressTasks = taskService.GetAllTasks().Where(t => t.Status.ToString() == "in_progress").ToList();
                    Utilities.PrintTable(inProgressTasks);
                    break;
            
                case "mark-in-progress":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("ID is required for marking a task as in-progress.");
                        return;
                    }
                    if (int.TryParse(args[1], out int inProgressId))
                    {
                        var task = taskService.GetTaskById(inProgressId);
                        if (task != null)
                        {
                            task.Status = StatusEnum.in_progress;
                            task.LastUpdate = DateTime.Now;
                            taskService.UpdateTask(task);
                            Console.WriteLine("Task marked as in-progress.");
                        }
                        else
                        {
                            Console.WriteLine("Task not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;
            
                case "mark-done":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("ID is required for marking a task as done.");
                        return;
                    }
                    if (int.TryParse(args[1], out int doneId))
                    {
                        var task = taskService.GetTaskById(doneId);
                        if (task != null)
                        {
                            task.Status = StatusEnum.done;
                            task.LastUpdate = DateTime.Now;
                            taskService.UpdateTask(task);
                            Console.WriteLine("Task marked as done.");
                        }
                        else
                        {
                            Console.WriteLine("Task not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;
            
                case "help":
                    var table = new Table();
                    table.AddColumn("Command");
                    table.AddColumn("Parameters");
                    table.AddColumn("Description");
                    table.AddColumn("Example");

                    table.AddRow("add", "<description>", "Adds a new task with the given description.", "add \"New Task\"");
                    table.AddRow("update", "<id> <description>", "Updates the task with the given ID and new description.", "update 1 \"Updated Task\"");
                    table.AddRow("delete", "<id>", "Deletes the task with the given ID.", "delete 1");
                    table.AddRow("list", "", "Lists all tasks.", "list");
                    table.AddRow("list done", "", "Lists all tasks marked as done.", "list done");
                    table.AddRow("list todo", "", "Lists all tasks marked as todo.", "list todo");
                    table.AddRow("list in-progress", "", "Lists all tasks marked as in-progress.", "list in-progress");
                    table.AddRow("mark-in-progress", "<id>", "Marks the task with the given ID as in-progress.", "mark-in-progress 1");
                    table.AddRow("mark-done", "<id>", "Marks the task with the given ID as done.", "mark-done 1");

                    AnsiConsole.Write(table);
                    break;
            
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }