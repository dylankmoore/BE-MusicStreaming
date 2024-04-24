using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BE_MusicStreaming.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Public = table.Column<bool>(type: "boolean", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.PlaylistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OutKast" },
                    { 2, "Beyoncé" },
                    { 3, "Eminem" },
                    { 4, "The Killers" },
                    { 5, "U2" },
                    { 6, "Coldplay" },
                    { 7, "Shakira" },
                    { 8, "Rihanna" },
                    { 9, "Snow Patrol" },
                    { 10, "The Black Eyed Peas" },
                    { 11, "Gnarls Barkley" },
                    { 12, "Jay-Z" },
                    { 13, "Amy Winehouse" },
                    { 14, "System of a Down" },
                    { 15, "Green Day" },
                    { 16, "Leona Lewis" },
                    { 17, "Katy Perry" },
                    { 18, "Evanescence" },
                    { 19, "Gwen Stefani" },
                    { 20, "The White Stripes" },
                    { 21, "Alicia Keys" },
                    { 22, "Kanye West" },
                    { 23, "Taylor Swift" },
                    { 24, "Justin Timberlake" },
                    { 25, "Linkin Park" },
                    { 26, "M.I.A." },
                    { 27, "Lady Gaga" },
                    { 28, "R. Kelly" },
                    { 29, "Avril Lavigne" },
                    { 30, "Britney Spears" },
                    { 31, "50 Cent" },
                    { 32, "Lil Jon & The East Side Boyz" },
                    { 33, "Usher" },
                    { 34, "Fergie" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Hip Hop" },
                    { 3, "Rock" },
                    { 4, "R&B" },
                    { 5, "Dance" },
                    { 6, "Soul" },
                    { 7, "Nu Metal" },
                    { 8, "Alternative Rock" },
                    { 9, "Country" },
                    { 10, "Pop Punk" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "I like groovy beats.", "-NwC_r-_0kdGvf7zTA09", "Johnny Dough" },
                    { 2, "First lady of Juicy Couture.", "-NwC_t92250bx6_IMTc6", "Janet Smithy" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "DateCreated", "ImageUrl", "IsFavorite", "Name", "Public", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " https://townsquare.media/site/443/files/2013/06/vid1.jpg?w=1200&h=0&zc=1&s=0&a=t&q=89", false, "Y2K Alt Anthems", true, 1 },
                    { 2, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images-na.ssl-images-amazon.com/images/I/81gEr9Kx1LL._AC_SL1417_.jpg", true, "Pop Princesses", true, 1 },
                    { 3, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i2-prod.mirror.co.uk/incoming/article20126256.ece/ALTERNATES/s615b/0_Britney-Spears-07.jpg", true, "Love & Heartbreak", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistId", "Duration", "GenreId", "Name", "Year" },
                values: new object[,]
                {
                    { 1, 1, "3:55", 2, "Hey Ya!", 2003 },
                    { 2, 2, "3:56", 4, "Crazy In Love", 2003 },
                    { 3, 3, "6:44", 2, "Stan", 2000 },
                    { 4, 4, "3:42", 8, "Mr. Brightside", 2003 },
                    { 5, 5, "4:08", 3, "Beautiful Day", 2000 },
                    { 6, 6, "5:07", 3, "Clocks", 2002 },
                    { 7, 7, "3:39", 1, "Hips Don't Lie", 2006 },
                    { 8, 6, "4:01", 3, "Viva La Vida", 2008 },
                    { 9, 8, "4:35", 4, "Umbrella", 2007 },
                    { 10, 3, "5:20", 2, "Lose Yourself", 2002 },
                    { 11, 9, "4:28", 3, "Chasing Cars", 2006 },
                    { 12, 10, "4:49", 1, "I Gotta Feeling", 2009 },
                    { 13, 11, "2:58", 6, "Crazy", 2006 },
                    { 14, 12, "4:36", 2, "Empire State of Mind", 2009 },
                    { 15, 13, "3:35", 6, "Rehab", 2006 },
                    { 16, 14, "3:30", 7, "Chop Suey!", 2001 },
                    { 17, 15, "4:20", 10, "Boulevard of Broken Dreams", 2004 },
                    { 18, 16, "4:23", 1, "Bleeding Love", 2007 },
                    { 19, 2, "3:13", 4, "Single Ladies (Put a Ring on It)", 2008 },
                    { 20, 1, "3:55", 2, "The Way You Move", 2003 },
                    { 21, 17, "3:40", 1, "Hot N Cold", 2008 },
                    { 22, 17, "3:00", 1, "I Kissed a Girl", 2008 },
                    { 23, 18, "3:56", 7, "Bring Me to Life", 2003 },
                    { 24, 18, "4:24", 8, "My Immortal", 2003 },
                    { 25, 19, "3:19", 1, "Hollaback Girl", 2005 },
                    { 26, 20, "3:52", 8, "Seven Nation Army", 2003 },
                    { 27, 21, "3:30", 4, "Fallin'", 2001 },
                    { 28, 22, "5:12", 2, "Stronger", 2007 },
                    { 29, 23, "3:55", 9, "Love Story", 2008 },
                    { 30, 24, "4:48", 4, "Cry Me a River", 2002 },
                    { 31, 25, "2:44", 7, "Bleed It Out", 2007 },
                    { 32, 26, "3:25", 2, "Paper Planes", 2007 },
                    { 33, 8, "3:59", 5, "Disturbia", 2008 },
                    { 34, 27, "3:58", 5, "Poker Face", 2008 },
                    { 35, 28, "3:06", 4, "Ignition (Remix)", 2002 },
                    { 36, 29, "4:04", 10, "Complicated", 2002 },
                    { 37, 29, "3:23", 10, "Sk8er Boi", 2002 },
                    { 38, 29, "3:43", 10, "I'm with You", 2002 },
                    { 39, 30, "3:30", 1, "Oops!... I Did It Again", 2000 },
                    { 40, 30, "3:18", 5, "Toxic", 2003 },
                    { 41, 30, "3:23", 1, "Stronger", 2000 },
                    { 42, 30, "4:11", 5, "Gimme More", 2007 },
                    { 43, 30, "3:44", 5, "Womanizer", 2008 },
                    { 44, 30, "3:32", 1, "Piece of Me", 2007 },
                    { 45, 30, "3:12", 1, "Circus", 2008 },
                    { 46, 30, "3:33", 1, "3", 2009 },
                    { 47, 31, "3:13", 2, "In da Club", 2003 },
                    { 48, 32, "5:34", 2, "Get Low", 2003 },
                    { 49, 32, "4:03", 2, "Get Crunk", 2003 },
                    { 50, 33, "4:10", 2, "Yeah!", 2004 },
                    { 51, 34, "3:28", 4, "London Bridge", 2006 },
                    { 52, 34, "4:52", 5, "Fergalicious", 2006 },
                    { 53, 10, "4:33", 1, "Where Is the Love?", 2003 },
                    { 54, 10, "3:37", 1, "Let's Get It Started", 2004 },
                    { 55, 10, "5:27", 2, "My Humps", 2005 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongsId",
                table: "PlaylistSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
