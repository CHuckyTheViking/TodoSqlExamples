using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoCosmosWithEF.Models
{
    public class Todo
    {   
        public string Id { get; set; }

        public string Activity { get; set; }

        public bool Completed { get; set; }

        public DateTime Created { get; set; }

        public Todo(string activity)
        {
            Id = Guid.NewGuid().ToString();
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
