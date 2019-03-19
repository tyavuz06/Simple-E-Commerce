namespace SimpleLogin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(650)]
        public string Password { get; set; }

        public bool EmailConfirm { get; set; }

        public int ActiveStatus { get; set; }

        [StringLength(650)]
        public string ValidationKey { get; set; }

        public virtual ICollection<Data.Token> Tokens { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
