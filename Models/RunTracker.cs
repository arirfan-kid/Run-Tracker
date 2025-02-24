using System.ComponentModel.DataAnnotations;

namespace SampleCrudApp.Models
{
    public class RunTracker
    {
        public int Id { get; set; }
        public  string Location { get; set; }
        public required DateTime Date { get; set; }
        public required double Distance { get; set; } 
        public  string Pace { get; set; } 
        public string? Description { get; set; }
    }
}
