using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_OlympicGames.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Max length is 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description max length is 500 characters")]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sprint Number must be positive")]
        public int SprintNumber { get; set; }
        [Range(1, 100, ErrorMessage = "Point Value must be between 1 and 100")]
        public int PointValue { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("to do|in progress|qa|done", ErrorMessage = "Status must be one of: To Do, In Progress, QA, or Done")]
        public string Status { get; set; }
    }
}
