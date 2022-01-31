using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BlogSitesi.Models.Entity
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Etiket> Etiket { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciRol> KullaniciRol { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makale)
                .WithMany(e => e.Etiket)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.KullaniciRol)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Kullanici)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Kullanici1)
                .WithMany(e => e.Kullanici2)
                .Map(m => m.ToTable("YazarTakip").MapLeftKey("YazarID").MapRightKey("KullaniciID"));

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Resim1)
                .WithOptional(e => e.Makale1)
                .HasForeignKey(e => e.MakaleID);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Makale)
                .WithOptional(e => e.Resim)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.KullaniciRol)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);
        }
    }
}
