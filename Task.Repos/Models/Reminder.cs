using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repos.Models
{
    public class Reminder
    {
        [Key]
        public Guid ReminderId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        public Reminder()
        {
                ReminderId= Guid.NewGuid();
        }
    }
}
