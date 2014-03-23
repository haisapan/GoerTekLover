using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoerTekLover.Models
{
    [Table("DbDictionary")]
    public class DbDictionary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 字典类别（如"紧急程度"）
        /// </summary>
        public string Dict_Name { get; set; }

        /// <summary>
        /// 字典类别的值（如"非常紧急"）
        /// </summary>
        public string Dict_Value { get; set; }

        /// <summary>
        /// 字典类别的值对应的Code（如"非常紧急"的对应Code为1）
        /// </summary>
        public int Dict_Code { get; set; }

        public string Description { get; set; }

       
    }
}