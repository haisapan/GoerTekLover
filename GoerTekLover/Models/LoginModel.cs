using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoerTekLover.Models
{
    /// <summary>
    /// 登陆日志
    /// </summary>
    public class LoginLog
    {
        //通过LoginLog可以计算出登录次数

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(100)]
        public string IpAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }

    }

}