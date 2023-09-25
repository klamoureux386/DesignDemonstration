using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignDemonstration.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingsUsersAndJoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumBand");

            migrationBuilder.DropTable(
                name: "AlbumMusician");

            migrationBuilder.DropTable(
                name: "AlbumSong");

            migrationBuilder.DropTable(
                name: "BandMusician");

            migrationBuilder.DropTable(
                name: "BandSong");

            migrationBuilder.DropTable(
                name: "MusicianSong");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Albums",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Songs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instruments",
                table: "Musicians",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlbumBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumBands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumBands_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMusicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMusicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumMusicians_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMusicians_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    SongId = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumSongs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false),
                    YearsActive = table.Column<string>(type: "TEXT", nullable: false),
                    Instruments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianBands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicianBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianBands_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false),
                    Instruments = table.Column<string>(type: "TEXT", nullable: false),
                    isFeatured = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicianSongs_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongId = table.Column<int>(type: "INTEGER", nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongBands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongBands_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumRatings_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SongId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongRatings_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongRatings_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bands_Name",
                table: "Bands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumBands_AlbumId_BandId",
                table: "AlbumBands",
                columns: new[] { "AlbumId", "BandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumBands_BandId",
                table: "AlbumBands",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusicians_AlbumId",
                table: "AlbumMusicians",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusicians_MusicianId_AlbumId",
                table: "AlbumMusicians",
                columns: new[] { "MusicianId", "AlbumId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumRatings_AlbumId_UserId",
                table: "AlbumRatings",
                columns: new[] { "AlbumId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumRatings_UserId",
                table: "AlbumRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSongs_AlbumId_SongId",
                table: "AlbumSongs",
                columns: new[] { "AlbumId", "SongId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSongs_SongId",
                table: "AlbumSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBands_BandId_MusicianId",
                table: "MusicianBands",
                columns: new[] { "BandId", "MusicianId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBands_MusicianId",
                table: "MusicianBands",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianSongs_MusicianId_SongId",
                table: "MusicianSongs",
                columns: new[] { "MusicianId", "SongId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicianSongs_SongId",
                table: "MusicianSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_SongBands_BandId",
                table: "SongBands",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_SongBands_SongId_BandId",
                table: "SongBands",
                columns: new[] { "SongId", "BandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongRatings_AlbumId",
                table: "SongRatings",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_SongRatings_SongId_AlbumId_UserId",
                table: "SongRatings",
                columns: new[] { "SongId", "AlbumId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongRatings_UserId",
                table: "SongRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumBands");

            migrationBuilder.DropTable(
                name: "AlbumMusicians");

            migrationBuilder.DropTable(
                name: "AlbumRatings");

            migrationBuilder.DropTable(
                name: "AlbumSongs");

            migrationBuilder.DropTable(
                name: "MusicianBands");

            migrationBuilder.DropTable(
                name: "MusicianSongs");

            migrationBuilder.DropTable(
                name: "SongBands");

            migrationBuilder.DropTable(
                name: "SongRatings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Bands_Name",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Instruments",
                table: "Musicians");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Albums",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Songs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlbumBand",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "INTEGER", nullable: false),
                    BandsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumBand", x => new { x.AlbumsId, x.BandsId });
                    table.ForeignKey(
                        name: "FK_AlbumBand_Albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumBand_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMusician",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusiciansId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMusician", x => new { x.AlbumsId, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_AlbumMusician_Albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMusician_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumSong",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SongsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSong", x => new { x.AlbumsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_AlbumSong_Albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandMusician",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusiciansId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMusician", x => new { x.BandsId, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_BandMusician_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandMusician_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandSong",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SongsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandSong", x => new { x.BandsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_BandSong_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianSong",
                columns: table => new
                {
                    MusiciansId = table.Column<int>(type: "INTEGER", nullable: false),
                    SongsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianSong", x => new { x.MusiciansId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_MusicianSong_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumBand_BandsId",
                table: "AlbumBand",
                column: "BandsId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusician_MusiciansId",
                table: "AlbumMusician",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSong_SongsId",
                table: "AlbumSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_BandMusician_MusiciansId",
                table: "BandMusician",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_BandSong_SongsId",
                table: "BandSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianSong_SongsId",
                table: "MusicianSong",
                column: "SongsId");
        }
    }
}
