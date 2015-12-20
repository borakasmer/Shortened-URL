namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UrlContext : DbContext
    {
        public UrlContext()
            : base("name=UrlContext")
        {
        }

        public virtual DbSet<Urls> Urls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urls>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Urls>()
                .Property(e => e.ShortUrl)
                .IsUnicode(false);
        }
    }
}
