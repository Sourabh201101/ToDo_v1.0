using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models.Models;

namespace ToDo.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Display(Name ="Due Date")]
        [Required]
        public DateTime? Duedate{get;set;}
        public Priority Priority { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
