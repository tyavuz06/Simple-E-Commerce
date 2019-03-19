namespace SimpleLogin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        public int ID { get; set; }

        public string TokenKey { get; set; }

        public int? UserID { get; set; }

        public DateTime? ExpireDate { get; set; }

        public DateTime? CreateDate { get; set; }


        public string Ip { get; set; }

        public string OS { get; set; }

        public string Browser { get; set; }

        [ForeignKey("UserID")]
        public virtual Data.User User { get; set; }
    }
}
