using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime DueTime { get; set; }
    }
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
