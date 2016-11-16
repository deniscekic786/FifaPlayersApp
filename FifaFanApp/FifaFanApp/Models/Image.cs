using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FifaFanApp.Models
{
    [Table("Image")]
    public partial class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string PlayerPath { get; set; }

        [Required]
        [StringLength(200)]
        public string NationalityPath { get; set; }

        [Required]
        [StringLength(200)]
        public string ClubPath { get; set; }

        public virtual Player Player { get; set; }
    }
}