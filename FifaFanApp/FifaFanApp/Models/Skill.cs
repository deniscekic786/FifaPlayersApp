using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FifaFanApp.Models
{

    [Table("Skill")]
    public partial class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Display(Name = "Ball Control")]
        public int BallControl { get; set; }

        public int Crossing { get; set; }

        public int Curve { get; set; }

        public int Dribbling { get; set; }

        public int Finishing { get; set; }

        public int FreeKick { get; set; }
        [Display(Name = "Heading Accuracy")]
        public int HeadingAccuracy { get; set; }
        [Display(Name = "Long Passing")]
        public int LongPassing { get; set; }
        [Display(Name = "Long Shots")]
        public int LongShots { get; set; }

        public int Marking { get; set; }

        public int Penalties { get; set; }
        [Display(Name = "Short Passing")]
        public int ShortPassing { get; set; }
        [Display(Name = "Shot Power")]
        public int ShotPower { get; set; }
        [Display(Name = "Sliding Tackle")]
        public int SlidingTackle { get; set; }
        [Display(Name = "Standing Tackle")]
        public int StandingTackle { get; set; }

        public int Volleys { get; set; }

        public int Acceleration { get; set; }

        public int Agility { get; set; }

        public int Balance { get; set; }

        public int Jumping { get; set; }

        public int Reactions { get; set; }
        [Display(Name = "Sprint Speed")]
        public int SprintSpeed { get; set; }

        public int Strength { get; set; }

        public int Stamina { get; set; }

        public int Aggression { get; set; }
        public int Positioning { get; set; }

        public int Interceptions { get; set; }

        public int Vision { get; set; }

        public virtual Player Player { get; set; }
    }
}
