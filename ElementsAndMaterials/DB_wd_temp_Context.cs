using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Utils;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElementsAndMaterials
{
    public partial class DB_wd_temp_Context : DbContext
    {
        public DB_wd_temp_Context()
        {
        }

        public DB_wd_temp_Context(DbContextOptions<DB_wd_temp_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Glasselement> Glasselement { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConfigHandler.GetConnStringEF());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Glasselement>(entity =>
            {
                entity.HasKey(e => e.Idglasselement);

                entity.ToTable("glasselement");

                entity.HasIndex(e => e.Guid)
                    .HasName("UQ__glasselement__5828BB55")
                    .IsUnique();

                entity.HasIndex(e => e.Idglasselementgroup)
                    .HasName("idx_glasselement_idglasselementgroup");

                entity.Property(e => e.Idglasselement)
                    .HasColumnName("idglasselement")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idglasselementgroup).HasColumnName("idglasselementgroup");

                entity.Property(e => e.Marking)
                    .HasColumnName("marking")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Numpos).HasColumnName("numpos");

                entity.Property(e => e.Ramkaoffset).HasColumnName("ramkaoffset");

                entity.Property(e => e.Thick).HasColumnName("thick");

                entity.Property(e => e.Typ).HasColumnName("typ");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.Idgood)
                    .HasName("pk_good");

                entity.ToTable("good");

                entity.HasIndex(e => e.Guid)
                    .HasName("UQ__good__4E9F511B")
                    .IsUnique();

                entity.HasIndex(e => e.Idcolor1)
                    .HasName("idx_good_idcolor1");

                entity.HasIndex(e => e.Idcolor2)
                    .HasName("idx_good_idcolor2");

                entity.HasIndex(e => e.Idcolorgroupcustom)
                    .HasName("idx_good_idcolorgroupcustom");

                entity.HasIndex(e => e.Idgoodgroup)
                    .HasName("idx_good_idgoodgroup");

                entity.HasIndex(e => e.Idgoodoptim)
                    .HasName("idx_good_idgoodoptim");

                entity.HasIndex(e => e.Idgoodpricegroup)
                    .HasName("idx_good_idgoodpricegroup");

                entity.HasIndex(e => e.Idgoodtype)
                    .HasName("idx_good_idgoodtype");

                entity.HasIndex(e => e.Idmeasure)
                    .HasName("idx_good_idmeasure");

                entity.HasIndex(e => e.Idstoragespace)
                    .HasName("idx_good_idstoragespace");

                entity.HasIndex(e => e.Idstoredepart)
                    .HasName("idx_good_idstoredepart");

                entity.HasIndex(e => e.Idsystem)
                    .HasName("idx_good_idsystem");

                entity.HasIndex(e => e.Idvalut)
                    .HasName("idx_good_idvalut");

                entity.HasIndex(e => e.Width)
                    .HasName("idx_good_width");

                entity.Property(e => e.Idgood)
                    .HasColumnName("idgood")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deliverytime).HasColumnName("deliverytime");

                entity.Property(e => e.Extmarking)
                    .HasColumnName("extmarking")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Idcolor1).HasColumnName("idcolor1");

                entity.Property(e => e.Idcolor2).HasColumnName("idcolor2");

                entity.Property(e => e.Idcolorgroupcustom).HasColumnName("idcolorgroupcustom");

                entity.Property(e => e.Idcustomer).HasColumnName("idcustomer");

                entity.Property(e => e.Idgoodgroup).HasColumnName("idgoodgroup");

                entity.Property(e => e.Idgoodoptim).HasColumnName("idgoodoptim");

                entity.Property(e => e.Idgoodpricegroup).HasColumnName("idgoodpricegroup");

                entity.Property(e => e.Idgoodtype).HasColumnName("idgoodtype");

                entity.Property(e => e.Idgoodtype2).HasColumnName("idgoodtype2");

                entity.Property(e => e.Idmeasure).HasColumnName("idmeasure");

                entity.Property(e => e.Idstoragespace).HasColumnName("idstoragespace");

                entity.Property(e => e.Idstoredepart)
                    .HasColumnName("idstoredepart")
                    .HasComment("Ссылка на склад хранения");

                entity.Property(e => e.Idsystem).HasColumnName("idsystem");

                entity.Property(e => e.Idvalut).HasColumnName("idvalut");

                entity.Property(e => e.Idvalut2).HasColumnName("idvalut2");

                entity.Property(e => e.Idvalut3).HasColumnName("idvalut3");

                entity.Property(e => e.Idvalut4).HasColumnName("idvalut4");

                entity.Property(e => e.Idvalut5).HasColumnName("idvalut5");

                entity.Property(e => e.Ismy).HasColumnName("ismy");

                entity.Property(e => e.Marking)
                    .HasColumnName("marking")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Maxost)
                    .HasColumnName("maxost")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Minost)
                    .HasColumnName("minost")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Minost2)
                    .HasColumnName("minost2")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Packing)
                    .HasColumnName("packing")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.Price1)
                    .HasColumnName("price1")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Price1crypt).HasColumnName("price1crypt");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Price4)
                    .HasColumnName("price4")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Price5)
                    .HasColumnName("price5")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Purchase).HasColumnName("purchase");

                entity.Property(e => e.Rank1)
                    .HasColumnName("rank1")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Rank2)
                    .HasColumnName("rank2")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Replenishment).HasColumnName("replenishment");

                entity.Property(e => e.Reserve).HasColumnName("reserve");

                entity.Property(e => e.Showinnopaper)
                    .HasColumnName("showinnopaper")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sqr)
                    .HasColumnName("sqr")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Sqr2)
                    .HasColumnName("sqr2")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Thick).HasColumnName("thick");

                entity.Property(e => e.Thickness).HasColumnName("thickness");

                entity.Property(e => e.Typ).HasColumnName("typ");

                entity.Property(e => e.Usehouse).HasColumnName("usehouse");

                entity.Property(e => e.Waste)
                    .HasColumnName("waste")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Waste2)
                    .HasColumnName("waste2")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Waste3)
                    .HasColumnName("waste3")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Waste4)
                    .HasColumnName("waste4")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Waste5)
                    .HasColumnName("waste5")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Idorder)
                    .HasName("pk_order");

                entity.ToTable("orders");

                entity.HasIndex(e => e.Deleted)
                    .HasName("_dta_index_orders_5_309576141__K4");

                entity.HasIndex(e => e.Guid)
                    .HasName("idx_orders_guid");

                entity.HasIndex(e => e.Idaddress)
                    .HasName("idx_orders_idaddress");

                entity.HasIndex(e => e.Idagree)
                    .HasName("idx_orders_idagree");

                entity.HasIndex(e => e.Idcustomer)
                    .HasName("idx_orders_idcustomer");

                entity.HasIndex(e => e.Idcustomer2)
                    .HasName("idx_orders_idcustomer2");

                entity.HasIndex(e => e.Idcustomer3)
                    .HasName("idx_orders_idcustomer3");

                entity.HasIndex(e => e.Iddepartment)
                    .HasName("idx_orders_iddepartment");

                entity.HasIndex(e => e.Iddestanation)
                    .HasName("idx_orders_iddestanation");

                entity.HasIndex(e => e.Iddiscard)
                    .HasName("idx_orders_iddiscard");

                entity.HasIndex(e => e.Iddocoper)
                    .HasName("idx_orders_iddocoper");

                entity.HasIndex(e => e.Iddocstate)
                    .HasName("idx_orders_iddocstate");

                entity.HasIndex(e => e.Idorder)
                    .HasName("_dta_index_orders_5_309576141__K1");

                entity.HasIndex(e => e.Idordersgroup)
                    .HasName("idx_orders_idordersgroup");

                entity.HasIndex(e => e.Idparent)
                    .HasName("ind_orders_idparent");

                entity.HasIndex(e => e.Idpeople)
                    .HasName("idx_orders_idpeople");

                entity.HasIndex(e => e.Idpeopledesigner)
                    .HasName("idx_orders_idpeopledesigner");

                entity.HasIndex(e => e.Idseller)
                    .HasName("idx_orders_idseller");

                entity.HasIndex(e => e.Idvalut)
                    .HasName("idx_orders_idvalut");

                entity.HasIndex(e => e.Idversion)
                    .HasName("idx_orders_idversion");

                entity.HasIndex(e => new { e.Agreename, e.Idorder })
                    .HasName("_dta_index_orders_5_309576141__K1_16");

                entity.HasIndex(e => new { e.Idorder, e.Deleted })
                    .HasName("_dta_index_orders_5_309576141__K1_K4");

                entity.HasIndex(e => new { e.Agreename, e.Deleted, e.Idorder })
                    .HasName("_dta_index_orders_5_309576141__K4_K1_16");

                entity.HasIndex(e => new { e.Agreename, e.Idorder, e.Deleted })
                    .HasName("_dta_index_orders_5_309576141__K1_K4_16");

                entity.Property(e => e.Idorder)
                    .HasColumnName("idorder")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adddt1)
                    .HasColumnName("adddt1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Adddt2)
                    .HasColumnName("adddt2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Adddt3)
                    .HasColumnName("adddt3")
                    .HasColumnType("datetime");

                entity.Property(e => e.Addinfo)
                    .HasColumnName("addinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Addint1).HasColumnName("addint1");

                entity.Property(e => e.Addint2).HasColumnName("addint2");

                entity.Property(e => e.Addint3).HasColumnName("addint3");

                entity.Property(e => e.Addnum1)
                    .HasColumnName("addnum1")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Addnum2)
                    .HasColumnName("addnum2")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Addnum3)
                    .HasColumnName("addnum3")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Addstr1)
                    .HasColumnName("addstr1")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Addstr2)
                    .HasColumnName("addstr2")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Addstr3)
                    .HasColumnName("addstr3")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Addstr4)
                    .HasColumnName("addstr4")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Addstr5)
                    .HasColumnName("addstr5")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Addtext)
                    .HasColumnName("addtext")
                    .HasColumnType("text");

                entity.Property(e => e.Agreedate)
                    .HasColumnName("agreedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Agreename)
                    .HasColumnName("agreename")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dtcre)
                    .HasColumnName("dtcre")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dtdoc)
                    .HasColumnName("dtdoc")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dtedit)
                    .HasColumnName("dtedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idaddress).HasColumnName("idaddress");

                entity.Property(e => e.Idadvertisingaction).HasColumnName("idadvertisingaction");

                entity.Property(e => e.Idagree).HasColumnName("idagree");

                entity.Property(e => e.Idagreement).HasColumnName("idagreement");

                entity.Property(e => e.Idcustomer).HasColumnName("idcustomer");

                entity.Property(e => e.Idcustomer2).HasColumnName("idcustomer2");

                entity.Property(e => e.Idcustomer3).HasColumnName("idcustomer3");

                entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");

                entity.Property(e => e.Iddestanation).HasColumnName("iddestanation");

                entity.Property(e => e.Iddiscard).HasColumnName("iddiscard");

                entity.Property(e => e.Iddocoper).HasColumnName("iddocoper");

                entity.Property(e => e.Iddocstate).HasColumnName("iddocstate");

                entity.Property(e => e.Idordersgroup).HasColumnName("idordersgroup");

                entity.Property(e => e.Idparent).HasColumnName("idparent");

                entity.Property(e => e.Idpeople).HasColumnName("idpeople");

                entity.Property(e => e.Idpeople2)
                    .HasColumnName("idpeople2")
                    .HasComment("Сотрудник 2");

                entity.Property(e => e.Idpeople3)
                    .HasColumnName("idpeople3")
                    .HasComment("Сотрудник 3");

                entity.Property(e => e.Idpeople4)
                    .HasColumnName("idpeople4")
                    .HasComment("Сотрудник 4");

                entity.Property(e => e.Idpeopledesigner).HasColumnName("idpeopledesigner");

                entity.Property(e => e.Idpeopleedit).HasColumnName("idpeopleedit");

                entity.Property(e => e.Idseller).HasColumnName("idseller");

                entity.Property(e => e.Idsourceinfo).HasColumnName("idsourceinfo");

                entity.Property(e => e.Idvalut).HasColumnName("idvalut");

                entity.Property(e => e.Idversion).HasColumnName("idversion");

                entity.Property(e => e.Installinfo)
                    .HasColumnName("installinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Logincre)
                    .HasColumnName("logincre")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Productinfo)
                    .HasColumnName("productinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Qupos).HasColumnName("qupos");

                entity.Property(e => e.Saved).HasColumnName("saved");

                entity.Property(e => e.Saved2).HasColumnName("saved2");

                entity.Property(e => e.Sizeinfo)
                    .HasColumnName("sizeinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Sm)
                    .HasColumnName("sm")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Smbase)
                    .HasColumnName("smbase")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Supplyinfo)
                    .HasColumnName("supplyinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Transportinfo)
                    .HasColumnName("transportinfo")
                    .IsUnicode(false);

                entity.Property(e => e.Valutrate)
                    .HasColumnName("valutrate")
                    .HasColumnType("numeric(15, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
