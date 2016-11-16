using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace FifaFanApp.Models
{
    [Table("Player")]
    public partial class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Nationality { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Club Name")]
        public string ClubName { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        [Display(Name = "Weak Foot Rating")]
        public int WeakFootRating { get; set; }
        [Display(Name = "Skill Moves Rating")]
        public int SkillMovesRating { get; set; }
        [Display(Name = "Min Worth")]
        public decimal MinWorth { get; set; }
        [Display(Name = "Max Worth")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal MaxWorth { get; set; }

        [Required]
        [StringLength(20)]
        public string Foot { get; set; }

        public virtual Image Image { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual Skill Skill { get; set; }
    }
}