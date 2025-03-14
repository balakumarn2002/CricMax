using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IPL.Models;

public partial class CricketContext : DbContext
{
    public CricketContext()
    {
    }

    public CricketContext(DbContextOptions<CricketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ipl> Ipls { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerPurchase> PlayerPurchases { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Cricket;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ipl>(entity =>
        {
            entity.HasKey(e => e.IplSeq).HasName("PK__IPL__5658A2FD128D16F0");

            entity.ToTable("IPL");

            entity.Property(e => e.IplSeq).HasColumnName("Ipl_Seq");
            entity.Property(e => e.CreatedByDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Created_By_DtTm");
            entity.Property(e => e.CreatedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Created_By_Seq");
            entity.Property(e => e.IplName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ipl_Name");
            entity.Property(e => e.IplYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ipl_Year");
            entity.Property(e => e.ModifiedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Modified_By_Seq");
            entity.Property(e => e.ModifiedDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Modified_DtTm");
            entity.Property(e => e.NoOfTeams)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("No_Of_Teams");
            entity.Property(e => e.RecorVer)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Recor_Ver");
            entity.Property(e => e.Sponsor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerSeq).HasName("PK__Player__182F7400C08D71E2");

            entity.ToTable("Player");

            entity.Property(e => e.PlayerSeq).HasColumnName("Player_Seq");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Created_By_DtTm");
            entity.Property(e => e.CreatedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Created_By_Seq");
            entity.Property(e => e.ForeignerFl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Foreigner_Fl");
            entity.Property(e => e.JerseyNo).HasColumnName("Jersey_No");
            entity.Property(e => e.ModifiedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Modified_By_Seq");
            entity.Property(e => e.ModifiedDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Modified_DtTm");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Player_Name");
            entity.Property(e => e.RecorVer)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Recor_Ver");
        });

        modelBuilder.Entity<PlayerPurchase>(entity =>
        {
            entity.HasKey(e => e.PlayerPurchaseSeq).HasName("PK__Player_P__577BD946F615485D");

            entity.ToTable("Player_Purchase");

            entity.Property(e => e.PlayerPurchaseSeq).HasColumnName("Player_Purchase_Seq");
            entity.Property(e => e.PlayerPrice)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Player_Price");
            entity.Property(e => e.PlayerSeq).HasColumnName("Player_Seq");
            entity.Property(e => e.PlayerTeam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Player_Team");
            entity.Property(e => e.TeamSeq).HasColumnName("Team_Seq");

            entity.HasOne(d => d.PlayerSeqNavigation).WithMany(p => p.PlayerPurchases)
                .HasForeignKey(d => d.PlayerSeq)
                .HasConstraintName("FK__Player_Pu__Playe__2B3F6F97");

            entity.HasOne(d => d.TeamSeqNavigation).WithMany(p => p.PlayerPurchases)
                .HasForeignKey(d => d.TeamSeq)
                .HasConstraintName("FK__Player_Pu__Team___2C3393D0");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleSeq).HasName("PK__ROle__3809E4DC364EA446");

            entity.ToTable("ROle");

            entity.Property(e => e.RoleSeq).HasColumnName("Role_seq");
            entity.Property(e => e.CreatedByDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Created_By_DtTm");
            entity.Property(e => e.CreatedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Created_By_Seq");
            entity.Property(e => e.ModifiedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Modified_By_Seq");
            entity.Property(e => e.ModifiedDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Modified_DtTm");
            entity.Property(e => e.RecorVer)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Recor_Ver");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamSeq).HasName("PK__Teams__3109B1C9C621D2CD");

            entity.Property(e => e.TeamSeq).HasColumnName("Team_Seq");
            entity.Property(e => e.CreatedByDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Created_By_DtTm");
            entity.Property(e => e.CreatedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Created_By_Seq");
            entity.Property(e => e.IplSeq).HasColumnName("Ipl_Seq");
            entity.Property(e => e.ModifiedBySeq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Modified_By_Seq");
            entity.Property(e => e.ModifiedDtTm)
                .HasColumnType("datetime")
                .HasColumnName("Modified_DtTm");
            entity.Property(e => e.NoOfPlayers).HasColumnName("No_Of_Players");
            entity.Property(e => e.NoOfTrophy).HasColumnName("No_Of_Trophy");
            entity.Property(e => e.RecorVer)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("Recor_Ver");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Team_Name");
            entity.Property(e => e.TeamSponsor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Team_Sponsor");
            entity.Property(e => e.TeamStadium)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Team_Stadium");

            entity.HasOne(d => d.IplSeqNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.IplSeq)
                .HasConstraintName("FK__Teams__Ipl_Seq__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
