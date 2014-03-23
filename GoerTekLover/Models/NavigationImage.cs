using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoerTekLover.Models
{
    /// <summary>
    /// Type 枚举过时了，存入字典中
    /// </summary>
    public enum ImageType
    {
        Normal,
        NavigationImage,

    }

    [Table("Images")]
    public class NavigationImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        public UserProfile User { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string ImageDescription { get; set; }
        public string ImageText { get; set; }
        public string ImageType { get; set; }
        public double ImageSize { get; set; }
        public string Md5 { get; set; }
    }
}