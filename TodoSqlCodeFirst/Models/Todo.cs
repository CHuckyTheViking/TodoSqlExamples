using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace TodoSqlCodeFirst.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Activity { get; set; }

        [Required]
        public bool Completed { get; set; }


        [Required]
        public DateTime Created { get; set; }

        //var todo = new Todo();
        //      todo.Activity = "activity text"
        //      todo.Completed = false;
        //      todo.Created = DateTime.Now;
        //new Todo()
        //new Todo { Activity = "activity text", Completed = false, Created = DateTime.Now}
        public Todo()
        {
           
        }

        //var todo = new Todo("activity text")
        //new Todo("activity text")
        public Todo(string activity)
        {
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
