﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesignDemonstration.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("DesignDemonstration.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumBands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BandId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("AlbumId", "BandId")
                        .IsUnique();

                    b.ToTable("AlbumBands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumMusicians", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MusicianId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("MusicianId", "AlbumId")
                        .IsUnique();

                    b.ToTable("AlbumMusicians");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("AlbumId", "UserId")
                        .IsUnique();

                    b.ToTable("AlbumRatings");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumSongs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.HasIndex("AlbumId", "SongId")
                        .IsUnique();

                    b.ToTable("AlbumSongs");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Bands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Musician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Instruments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.MusicianBands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Instruments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MusicianId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("YearsActive")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MusicianId");

                    b.HasIndex("BandId", "MusicianId")
                        .IsUnique();

                    b.ToTable("MusicianBands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.MusicianSongs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Instruments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MusicianId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isFeatured")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.HasIndex("MusicianId", "SongId")
                        .IsUnique();

                    b.ToTable("MusicianSongs");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.SongBands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("SongId", "BandId")
                        .IsUnique();

                    b.ToTable("SongBands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.SongRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<int>("SongId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.HasIndex("SongId", "AlbumId", "UserId")
                        .IsUnique();

                    b.ToTable("SongRatings");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumBands", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Album", "Album")
                        .WithMany("AlbumBands")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Bands", "Band")
                        .WithMany("AlbumBands")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumMusicians", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Album", "Album")
                        .WithMany("AlbumMusicians")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Musician", "Musician")
                        .WithMany("AlbumMusicians")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Musician");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumRating", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Album", "Album")
                        .WithMany("Ratings")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.User", "User")
                        .WithMany("AlbumsRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.AlbumSongs", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Album", "Album")
                        .WithMany("AlbumSongs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Song", "Song")
                        .WithMany("AlbumSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.MusicianBands", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Bands", "Band")
                        .WithMany("BandMusicians")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Musician", "Musician")
                        .WithMany("BandMusicians")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("Musician");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.MusicianSongs", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Musician", "Musician")
                        .WithMany("MusicanSongs")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Song", "Song")
                        .WithMany("MusicianSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.SongBands", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Bands", "Band")
                        .WithMany("SongBands")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Song", "Song")
                        .WithMany("SongBands")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.SongRating", b =>
                {
                    b.HasOne("DesignDemonstration.Entities.Album", null)
                        .WithMany("SongRatings")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.Song", null)
                        .WithMany("Ratings")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesignDemonstration.Entities.User", null)
                        .WithMany("SongRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Album", b =>
                {
                    b.Navigation("AlbumBands");

                    b.Navigation("AlbumMusicians");

                    b.Navigation("AlbumSongs");

                    b.Navigation("Ratings");

                    b.Navigation("SongRatings");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Bands", b =>
                {
                    b.Navigation("AlbumBands");

                    b.Navigation("BandMusicians");

                    b.Navigation("SongBands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Musician", b =>
                {
                    b.Navigation("AlbumMusicians");

                    b.Navigation("BandMusicians");

                    b.Navigation("MusicanSongs");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.Song", b =>
                {
                    b.Navigation("AlbumSongs");

                    b.Navigation("MusicianSongs");

                    b.Navigation("Ratings");

                    b.Navigation("SongBands");
                });

            modelBuilder.Entity("DesignDemonstration.Entities.User", b =>
                {
                    b.Navigation("AlbumsRatings");

                    b.Navigation("SongRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
