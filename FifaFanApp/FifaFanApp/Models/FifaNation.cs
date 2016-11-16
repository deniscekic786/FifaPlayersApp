using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifaFanApp.Models
{
    public partial class FifaNation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FifaNationId { get; set; }

        [Required]
        [StringLength(100)]
        public string NationName { get; set; }

        [Required]
        [StringLength(100)]
        public string NationImagePath { get; set; }
    }
}
