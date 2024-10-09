using System;
using System.Collections.Generic;

namespace CaoNguyenLanAnh
{
    internal class Program
    {
        enum TaskStatus
        {
            Cancelled = 0,
            Finished = 1,
            InProgress = 2,
        }
        class Todo
        {
            public string taskName { get; set; }  = "";
            public int priorityLevel { get; set; } = 5;
            public string taskDetail { get; set; } = "";
            public TaskStatus taskStatus { get; set; } = TaskStatus.InProgress;

            public override string ToString()
            {
                return $"Task: {taskName}, Priority: {priorityLevel}, Details: {taskDetail}, Status: {taskStatus}";
            }
            public TaskStatus GetTaskStatus(int input)
            {
                TaskStatus newTask = TaskStatus.InProgress;

                if(Enum.IsDefined(typeof(TaskStatus), input)) newTask = (TaskStatus)input;
                else Console.WriteLine("Invalid input");

                return newTask;
            }

            public void addTask(List<Todo> todoList, string name, int priority, string detail, TaskStatus status)
            {
                todoList.Add(new Todo{ taskName = name, priorityLevel = priority, taskDetail = detail, taskStatus = status});
                Console.WriteLine("Task added successfully");
            }

            public void deleteDetails(List<Todo> todoList, int index)
            {
                if(index >= 0 && index <= todoList.Count) {
                    todoList[index].taskDetail = "";
                    Console.WriteLine("Task details deleted successfully");
                }
                else Console.WriteLine("Invalid index");
            }

            public void changeTaskStatus(List<Todo> todoList, int index, TaskStatus status)
            {
                if(index >= 0 && index <= todoList.Count) {
                    todoList[index].taskStatus = status;
                    Console.WriteLine("Task status changed successfully");
                }
                else Console.WriteLine("Invalid input");
            }

            public void searchTasks(List<Todo> todoList, string searchTerm)
            {
                Console.WriteLine($"Searching for tasks whose name contain {searchTerm}");

                bool found = false;

                foreach(var task in todoList) {
                    if(task.taskName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0) { 
                        Console.WriteLine(task);
                        found = true;
                    }
                }

                if(!found) Console.WriteLine("No matching task found");
            }

            public List<Todo> rearrangeList(List<Todo> todoList)
            {
                todoList = todoList.OrderByDescending(x => x.priorityLevel).ToList();
                return todoList;
            }

            public void DisplayTasks(List<Todo> todoList)
            {
                Console.WriteLine("Todo List:");
                for (int i = 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {todoList[i]}");
                }
            }

        }

        static void Main(string[] args)
        {
            List<Todo> todoList = new List<Todo>();
            Todo todo = new Todo();

            // Add 7 tasks to the list
            while(true)
            {
                Console.WriteLine("--------------------MENU--------------------");
                Console.WriteLine("1. Add tasks into the list");
                Console.WriteLine("2. Delete the information of finished task");
                Console.WriteLine("3. Update task status");
                Console.WriteLine("4. Find tasks using keywords");
                Console.WriteLine("5. Display the list in descending priority order");
                Console.WriteLine("6. Display the todo list");
                Console.WriteLine("Press Esc or 'q' to quit.");
                Console.WriteLine("Input your choice: ");

                var choice = Console.ReadKey();
                Console.WriteLine();

                if(choice.Key == ConsoleKey.Escape || choice.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Existing...");
                    break;
                }

                switch(choice.KeyChar) {
                    case '1':
                    Console.Write("Task's name: ");
                    string name = Console.ReadLine() ?? "";
                    if (name == "") {
                        Console.WriteLine("Missed input");
                        break;
                    }
                    Console.Write("Task's priority level: ");
                    int priority;
                    if (!int.TryParse(Console.ReadLine(), out priority)) {
                        Console.WriteLine("Invalid input. Setting priority to default (5).");
                        priority = 5;
                    }
                    Console.Write("Task's details: ");
                    string details = Console.ReadLine() ?? "";
                    Console.Write("Status (0 - Cancelled, 1 - Finished, 2 - In progress): ");
                    int status;
                    if (!int.TryParse(Console.ReadLine(), out status)) {
                        Console.WriteLine("Invalid input. Setting status to default (In progress).");
                        status = 2;
                    }
                    TaskStatus Status = todo.GetTaskStatus(status);
                    todo.addTask(todoList, name, priority, details, Status);
                    break;

                    case '2':
                    if (todoList.Count == 0){
                        Console.WriteLine("No tasks available in the list.");
                        break;
                    }

                    Console.WriteLine("Which task do you want to delete details from the list? ");
                    int index = int.Parse(Console.ReadLine() ?? "0");
                    todo.deleteDetails(todoList, index - 1);
                    todo.DisplayTasks(todoList);
                    break;

                    case '3':
                    if (todoList.Count == 0){
                        Console.WriteLine("No tasks available in the list.");
                        break;
                    }

                    Console.WriteLine("Which task do you want to update status in the list? ");
                    int updateIndex = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Change the status (0 - Cancelled, 1 - Finished, 2 - In progress): ");
                    int newStatusValue = int.Parse(Console.ReadLine() ?? "0");
                    TaskStatus newStatus = todo.GetTaskStatus(newStatusValue);
                    todo.changeTaskStatus(todoList, updateIndex - 1, newStatus);
                    Console.WriteLine($"Task Status Input Result: {newStatus}");
                    break;

                    case '4':
                    if (todoList.Count == 0){
                        Console.WriteLine("No tasks available in the list.");
                        break;
                    }

                    Console.WriteLine("Keyword to search for tasks: ");
                    string keywords = Console.ReadLine() ?? "0";
                    todo.searchTasks(todoList, keywords);
                    break;

                    case '5':
                    if (todoList.Count == 0){
                        Console.WriteLine("No tasks available in the list.");
                        break;
                    }

                    Console.WriteLine("Rearrange tasks by priority (highest to lowest): ");
                    todoList = todo.rearrangeList(todoList);
                    todo.DisplayTasks(todoList);
                    break;

                    case '6':
                    if (todoList.Count == 0){
                        Console.WriteLine("No tasks available in the list.");
                        break;
                    }

                    todo.DisplayTasks(todoList);
                    break;

                    default:
                    Console.WriteLine("Invalid input!");
                    break;
                }

            }
        }
    }
}