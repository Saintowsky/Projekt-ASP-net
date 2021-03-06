using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class ImageModel
    {
        [Key]
        public int ImageID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Author { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Title { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [Column(TypeName = "int")]
        [DisplayName("Rating")]
        public int Rating { get; set; }

        [Required]
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
