namespace Case.ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CaseDbContext : DbContext
    {
        public CaseDbContext()
            : base("name=Case")
        {
        }

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<RssPage> RssPage { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
