namespace Portfolia.Models.DbModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=ApiDb")
        {
        }

        public virtual DbSet<LegitimationList> LegitimationList { get; set; }
        public virtual DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LegitimationList>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
