using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoerTekLover.Models
{
    [Table("MenuModel")]
    public class MenuModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        //[Display(Name = "Home",ResourceType = typeof(Resources.Resource))]
        public string MenuName { get; set; }

        public string MenuDisplayName { get; set; }

        public string MenuLink { get; set; }

        public int ParentMenuId { get; set; }

        public bool Disabled { get; set; }

        public string Description { get; set; }


    }
}