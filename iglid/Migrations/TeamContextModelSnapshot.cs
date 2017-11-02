using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using iglid.Data;
using iglid.Models.TournamentsModels;

namespace iglid.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class TeamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iglid.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PSN");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<int>("score");

                    b.Property<long?>("teamID");

                    b.HasKey("Id");

                    b.HasIndex("teamID");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("iglid.Models.Dispute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("link")
                        .IsRequired();

                    b.Property<string>("massage")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("matchid");

                    b.HasKey("Id");

                    b.ToTable("Disputes");
                });

            modelBuilder.Entity("iglid.Models.Massage", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<string>("senderId");

                    b.Property<long?>("teamID");

                    b.HasKey("id");

                    b.HasIndex("senderId");

                    b.HasIndex("teamID");

                    b.ToTable("Massage");
                });

            modelBuilder.Entity("iglid.Models.Requests", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("TeamID");

                    b.Property<string>("massage");

                    b.Property<string>("senderId");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.HasIndex("senderId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("iglid.Models.Team", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanPlay");

                    b.Property<string>("LeaderId");

                    b.Property<string>("TeamName");

                    b.Property<int>("score");

                    b.HasKey("ID");

                    b.HasIndex("LeaderId")
                        .IsUnique();

                    b.ToTable("teams");
                });

            modelBuilder.Entity("iglid.Models.TournamentsModels.tourInv", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("senderId");

                    b.Property<string>("touridid");

                    b.HasKey("id");

                    b.HasIndex("senderId");

                    b.HasIndex("touridid");

                    b.ToTable("tourInv");
                });

            modelBuilder.Entity("iglid.Models.TournamentsModels.tournament", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bestof");

                    b.Property<DateTime>("date");

                    b.Property<int>("gameModes");

                    b.Property<int>("maxteams");

                    b.Property<int>("teamcount");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.ToTable("tournament");
                });

            modelBuilder.Entity("iglid.Models.ApplicationUser", b =>
                {
                    b.HasOne("iglid.Models.Team", "team")
                        .WithMany("players")
                        .HasForeignKey("teamID");
                });

            modelBuilder.Entity("iglid.Models.Massage", b =>
                {
                    b.HasOne("iglid.Models.ApplicationUser", "sender")
                        .WithMany("massages")
                        .HasForeignKey("senderId");

                    b.HasOne("iglid.Models.Team", "team")
                        .WithMany()
                        .HasForeignKey("teamID");
                });

            modelBuilder.Entity("iglid.Models.Requests", b =>
                {
                    b.HasOne("iglid.Models.Team")
                        .WithMany("requests")
                        .HasForeignKey("TeamID");

                    b.HasOne("iglid.Models.ApplicationUser", "sender")
                        .WithMany()
                        .HasForeignKey("senderId");
                });

            modelBuilder.Entity("iglid.Models.Team", b =>
                {
                    b.HasOne("iglid.Models.ApplicationUser", "Leader")
                        .WithOne()
                        .HasForeignKey("iglid.Models.Team", "LeaderId");
                });

            modelBuilder.Entity("iglid.Models.TournamentsModels.tourInv", b =>
                {
                    b.HasOne("iglid.Models.ApplicationUser", "sender")
                        .WithMany("tourinvites")
                        .HasForeignKey("senderId");

                    b.HasOne("iglid.Models.TournamentsModels.tournament", "tourid")
                        .WithMany()
                        .HasForeignKey("touridid");
                });
        }
    }
}
