using System.ComponentModel.DataAnnotations;

namespace TripLog.Models
{
    public class Trip
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a destination.")]
        public string Destination { get; set; }
        public string? Accomidations { get; set; }
        [Required(ErrorMessage = "Please enter a start date.")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "Please enter an end date.")]
        public string EndDate { get; set; }
        public string? AccomidationPhone { get; set; }
        public string? AccomidationEmail { get; set; }
        public string? ThingsToDo1 { get; set; }
        public string? ThingsToDo2 { get; set; }
        public string? ThingsToDo3 { get; set; }

    }
}
