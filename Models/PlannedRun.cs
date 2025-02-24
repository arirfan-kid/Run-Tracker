using System;
using System.ComponentModel.DataAnnotations;

namespace SampleCrudApp.Models
{
    public class PlannedRun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public double Distance { get; set; }

        [Required]
        public required string RunType { get; set; } // Interval, Recovery, Long, Tempo

        public bool IsCompleted { get; set; } = false;
    }

}
