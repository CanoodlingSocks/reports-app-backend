using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reports_app_backend.DAL.Models
{
    public class TemplateData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Fields { get; set; } //Fields to set the data in the db for easy retrival for specific things??
    }
}
