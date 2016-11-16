using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FifaFanApp.Models
{
        [Table("Rating")]
        public partial class Rating
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int RatingId { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }

            public int Overall { get; set; }

            public int Pace { get; set; }

            public int Shooting { get; set; }

            public int Passing { get; set; }

            public int Dribbling { get; set; }

            public int Defense { get; set; }

            public int Physical { get; set; }

            public int TotalStats { get; set; }

            public virtual Player Player { get; set; }
        }
    }
