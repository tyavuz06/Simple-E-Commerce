namespace SimpleLogin.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SimpleData : DbContext
    {
        public SimpleData()
            : base("name=SimpleData")
        {
        }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Error> Errors { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
