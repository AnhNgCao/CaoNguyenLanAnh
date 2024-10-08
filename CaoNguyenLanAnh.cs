using System;

namespace CaoNguyenLanAnh
{
    internal class Program
    {
        class Todo
        {
            public string taskName { get; set; }  = "";
            public int priorityLevel { get; set; } = 5;
            public string taskDetail { get; set; } = "";
            public int taskStatus { get; set; } = 2;

            public override string ToString()
            {
                return $"Task: {taskName}, Priority: {priorityLevel}, Details: {taskDetail}, Status: {taskStatus}";
            }

            public void addTask(List<Todo> todoList, string name, int priority, string detail, int status)
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

            public void changeTaskStatus(List<Todo> todoList, int index, int status)
            {
                if(index >= 0 && index <= todoList.Count && status >= 0 && status <=2) {
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

        }
    }
}