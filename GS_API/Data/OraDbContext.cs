using GS_API.DTO;
using Microsoft.EntityFrameworkCore;

namespace GS_API.Data
{
    public class OraDbContext : DbContext
    {
        public OraDbContext(DbContextOptions<OraDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<SuplierDTO> SuplierDbSet { get; set; }
        public DbSet<ItemMasterDTO> ItemMasterDbSet { get; set; }
        public DbSet<SupplierMasterDTO> SupplierMasterDbSet { get; set; }
        public DbSet<WarehouseMasterDTO> WarehouseMasterDbSet { get; set; }

        public DbSet<GS1MASTERRECEIPTModel> GS1MASTERRECEIPTModelDbSet { get; set; }


        public DbSet<GsDataDTO> GsDataDTODbSet { get; set; }

        public DbSet<getGsidDTO> getGsidDTODbSet { get; set; }
        public DbSet<WHStockDTO> WHStockDbSet { get; set; }

        public DbSet<Gs1LabelDTO> Gs1LabelDbSet { get; set; }
        public DbSet<UpdateCancellationRequest> UpdateCancellationRequestDbSet { get; set; }
        
























        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<SuplierDTO>().HasNoKey();
            modelBuilder.Entity<ItemMasterDTO>().HasNoKey();
            modelBuilder.Entity<WHStockDTO>().HasNoKey();
            modelBuilder.Entity<Gs1LabelDTO>().HasNoKey();
            modelBuilder.Entity<UpdateCancellationRequest>().HasNoKey();


            // modelBuilder.Entity<GS1MASTERRECEIPTModel>().HasNoKey();







            //  modelBuilder.Entity<MasCgmscNocItems>().ToTable("MasCgmscNocItems");


        }
    }


}
