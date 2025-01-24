using System.ComponentModel.DataAnnotations;

namespace SampleCrudApp.Models
{
    public class RunTracker
    {
        public int Id { get; set; }
        public required string Location { get; set; }
        public required DateTime Date { get; set; }
        public required double Distance { get; set; } 
        public required string Pace { get; set; } 
        public string? Description { get; set; }
    }
}
