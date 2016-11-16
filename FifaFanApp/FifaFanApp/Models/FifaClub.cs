using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifaFanApp.Models
{
    public partial class FifaClub
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FifaClubId { get; set; }

        [Required]
        [StringLength(100)]
        public string ClubName { get; set; }

        [Required]
        [StringLength(100)]
        public string ClubImagePath { get; set; }
    }
}
