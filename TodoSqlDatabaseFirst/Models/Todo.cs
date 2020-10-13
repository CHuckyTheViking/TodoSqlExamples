using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace TodoSqlDatabaseFirst.Models
{
    public class Todo
    {
        public Todo(string activity)
        {
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Activity { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }
    }
}


