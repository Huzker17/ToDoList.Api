using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;

namespace ToDoList.Api.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItem>> GetAllTasks();
        Task<IEnumerable<ToDoItem>> GetIncompleteTasks();
        Task<IEnumerable<ToDoItem>> GetCompleteTasks();
        Task<IEnumerable<ToDoItem>> GetCurrentProjectTasks(int id);
        Task<ToDoItem> AddItemAsync(ToDoItem task, int projectId);
        Task<bool> ChangeSatus(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ToDoItem updatedTask);
        ToDoItem Detail(int id);

    }
}
