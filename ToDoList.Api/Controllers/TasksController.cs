using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Models;

namespace ToDoList.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IToDoItemService _todoService;
        public TasksController(ApplicationDbContext db, IToDoItemService todoService)
        {
            _db = db;
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var tasks = _todoService.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var task = _todoService.Detail(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [FromBody] ToDoItem task)
        {
            try
            {
                var newtask = _todoService.AddItemAsync(task,  id);
                return CreatedAtAction(nameof(Details), new { id = task.Id }, newtask);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("{id}")]
        public ActionResult Edit(int id,[FromBody] ToDoItem newTask)
        {
            try
            {
                var task = _todoService.Update(id, newTask);
                return CreatedAtAction(nameof(Details), new { id = id }, task);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("complete")]
        public ActionResult GetCompletedTasks()
        {
            try
            {
                var tasks = _todoService.GetCompleteTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("incomplete")]
        public ActionResult GetIncompletedTasks()
        {
            try
            {
                var tasks = _todoService.GetIncompleteTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var task = _todoService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
