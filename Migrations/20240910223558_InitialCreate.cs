using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true)
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
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 35, "Hailing from Nashville, Jackson Ridge blends traditional country sounds with a modern twist. Known for his deep, gravelly voice and heartfelt ballads, Jackson's songs about love, heartache, and small-town life have made him a fan favorite in the country music scene.", "Jackson Ridge" },
                    { 2, 27, "Texas native Sadie Mae Walker is a rising star in the country music scene. Her energetic performances and relatable lyrics about southern life have propelled her to the top of country charts. She brings a youthful, modern edge to traditional country sounds.\r\n", "Sadie Mae Walker" },
                    { 3, 29, "An indie rock artist from Portland, Milo Rivers combines raw guitar riffs with introspective lyrics. His music is known for its emotional depth and unique sound, making him a standout in the underground indie scene.", "Milo River" },
                    { 4, 24, "A pop sensation from Los Angeles, Layla Sky's catchy melodies and upbeat dance tracks have made her a household name. Her infectious energy and glittering stage presence have won over fans around the world, making her one of pop music’s brightest stars.", "Layla Sky" },
                    { 5, 42, "Ezra Cole is a seasoned blues artist from Memphis, known for his soulful voice and masterful guitar skills. With roots in traditional Delta blues, his music explores themes of hardship and resilience, capturing the heart of the blues genre.", "Ezra Cole" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Country" },
                    { 2, "Indie Rock" },
                    { 3, "Pop" },
                    { 4, "Blues" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Highway to Home", 1, 225, "Whiskey on the Wind" },
                    { 2, "American Dreamer", 1, 242, "Small Town Sundown" },
                    { 3, "Texas Heart", 2, 230, "Lone Star Night" },
                    { 4, "Honky-Tonk Heartbeat", 2, 250, "Dust on My Boots" },
                    { 5, "Broken Horizons", 3, 260, "Echoes in the Rain" },
                    { 6, "Under the Bridge", 3, 238, "Neon Nights" },
                    { 7, "Neon Glow", 4, 210, "Shimmering Lights" },
                    { 8, "Cosmic Beat", 4, 220, "Starlight City" },
                    { 9, "Midnight Blues", 5, 315, "River of Sorrow" },
                    { 10, "Deep Waters", 5, 365, "Broken Strings" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsId",
                table: "GenreSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
