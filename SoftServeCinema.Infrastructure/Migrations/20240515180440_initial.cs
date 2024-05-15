using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftServeCinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrailerUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Desc = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GraduationYear = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    Duration = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    StartRentalDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndRentalDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActorEntityMovieEntity",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorEntityMovieEntity", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorEntityMovieEntity_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorEntityMovieEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DirectorEntityMovieEntity",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorEntityMovieEntity", x => new { x.DirectorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_DirectorEntityMovieEntity_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorEntityMovieEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreEntityMovieEntity",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEntityMovieEntity", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BasicPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VipPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieEntityTagEntity",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntityTagEntity", x => new { x.MoviesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MovieEntityTagEntity_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityTagEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RowNumber = table.Column<short>(type: "smallint", nullable: false),
                    SeatNumber = table.Column<short>(type: "smallint", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Кірстен Данст" },
                    { 2, "Джессі Племенс" },
                    { 3, "Кейлі Спені" },
                    { 4, "Соноя Мідзуно" },
                    { 5, "Раян Ґослінґ" },
                    { 6, "Емілі Блант" },
                    { 7, "Аарон Тейлор-Джонсон" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Алекс Ґарленд" },
                    { 2, "Девід Літч" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "епічний" },
                    { 2, "екшн" },
                    { 3, "антиутопія" },
                    { 4, "комедія" },
                    { 5, "трилер" },
                    { 6, "жахи" },
                    { 7, "пригоди" },
                    { 8, "аніме" },
                    { 9, "сімейний" },
                    { 10, "драма" },
                    { 11, "спорт" },
                    { 12, "документальний" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Desc", "Duration", "EndRentalDate", "GraduationYear", "ImagePath", "StartRentalDate", "Title", "TrailerUrl" },
                values: new object[,]
                {
<<<<<<<< HEAD:SoftServeCinema.Infrastructure/Migrations/20240515164650_initial.cs
                    { 1, "Події розгортаються у найближчому майбутньому. Сполученими штатами котиться нищівна та всеохоплююча громадянська війна. Почалося із бажання кількох південних штатів відділитися і тепер уся країна охоплена бойовими діями. Група журналістів, серед яких відома репортерка (Кірстен Данст), яка і раніше часто знімала збройні конфлікти, рухаються у напрямку Вашингтона. Стає очевидним, що керівництво країни перетворилося на диктатуру, а повстанські угрупування повсюдно чинять воєнні злочини.", (ushort)108, new DateTime(2024, 6, 14, 16, 46, 48, 376, DateTimeKind.Utc).AddTicks(6099), (ushort)2024, "/movies/sw-vend.jpg", new DateTime(2024, 5, 14, 16, 46, 48, 376, DateTimeKind.Utc).AddTicks(6085), "Повстання Штатів", "https://www.youtube.com/embed/my8iHV3dpNI?si=88h7TyNtTLoGIupq" },
                    { 2, "Джоді Морено (Емілі Блант) знімає свій перший фільм у якості режисера. Вона дуже старається та хвилюється. Добре, що на знімальному майданчику завжди є кому її підбадьорити. Кольт (Раян Ґослінґ) – каскадер. Колись вони зустрічалися з Джоді, а нині просто працюють разом та підтримують одне одного. Кольт дублює актора, який грає головну роль. Якось цей актор безслідно зникає. Ніхто не може знайти його, а це означає, що Джоді не зможе дознімати свій дебютний проект і це зруйнує її кар’єру. Кольт дуже не хоче, щоб так сталося, тож погоджується стати на деякий час детективом та розшукати актора, який невідомо куди подівся.", (ushort)126, new DateTime(2024, 7, 4, 16, 46, 48, 376, DateTimeKind.Utc).AddTicks(6129), (ushort)2024, "/movies/fall_guy-vend.jpg", new DateTime(2024, 5, 20, 16, 46, 48, 376, DateTimeKind.Utc).AddTicks(6127), "Каскадер", "https://www.youtube.com/embed/Xmi7ZsHL6Jg?si=v2CGyMa6CcT2KUUY" }
========
                    { 1, "Події розгортаються у найближчому майбутньому. Сполученими штатами котиться нищівна та всеохоплююча громадянська війна. Почалося із бажання кількох південних штатів відділитися і тепер уся країна охоплена бойовими діями. Група журналістів, серед яких відома репортерка (Кірстен Данст), яка і раніше часто знімала збройні конфлікти, рухаються у напрямку Вашингтона. Стає очевидним, що керівництво країни перетворилося на диктатуру, а повстанські угрупування повсюдно чинять воєнні злочини.", (ushort)108, new DateTime(2024, 6, 14, 18, 4, 39, 829, DateTimeKind.Utc).AddTicks(8525), (ushort)2024, "/movies/sw-vend.jpg", new DateTime(2024, 5, 14, 18, 4, 39, 829, DateTimeKind.Utc).AddTicks(8520), "Повстання Штатів", "https://www.youtube.com/embed/my8iHV3dpNI?si=88h7TyNtTLoGIupq" },
                    { 2, "Джоді Морено (Емілі Блант) знімає свій перший фільм у якості режисера. Вона дуже старається та хвилюється. Добре, що на знімальному майданчику завжди є кому її підбадьорити. Кольт (Раян Ґослінґ) – каскадер. Колись вони зустрічалися з Джоді, а нині просто працюють разом та підтримують одне одного. Кольт дублює актора, який грає головну роль. Якось цей актор безслідно зникає. Ніхто не може знайти його, а це означає, що Джоді не зможе дознімати свій дебютний проект і це зруйнує її кар’єру. Кольт дуже не хоче, щоб так сталося, тож погоджується стати на деякий час детективом та розшукати актора, який невідомо куди подівся.", (ushort)126, new DateTime(2024, 7, 4, 18, 4, 39, 829, DateTimeKind.Utc).AddTicks(8530), (ushort)2024, "/movies/fall_guy-vend.jpg", new DateTime(2024, 5, 20, 18, 4, 39, 829, DateTimeKind.Utc).AddTicks(8529), "Каскадер", "https://www.youtube.com/embed/Xmi7ZsHL6Jg?si=v2CGyMa6CcT2KUUY" }
>>>>>>>> 8d5e6282805b81ecb180088c11a400b87fd73803:SoftServeCinema.Infrastructure/Migrations/20240515180440_initial.cs
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "18+" },
                    { 2, "12+" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "RoleName" },
                values: new object[] { new Guid("551b099b-91de-48ab-bb52-518a67f35e5b"), "romanmedvedev0201@gmail.com", "Roman", "Koval", "User" });

            migrationBuilder.InsertData(
                table: "ActorEntityMovieEntity",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "DirectorEntityMovieEntity",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GenreEntityMovieEntity",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieEntityTagEntity",
                columns: new[] { "MoviesId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "BasicPrice", "MovieId", "StartDate", "VipPrice" },
<<<<<<<< HEAD:SoftServeCinema.Infrastructure/Migrations/20240515164650_initial.cs
                values: new object[] { 1, 200m, 1, new DateTime(2024, 5, 16, 16, 46, 48, 376, DateTimeKind.Utc).AddTicks(7239), 350m });
========
                values: new object[] { 1, 200m, 1, new DateTime(2024, 5, 16, 18, 4, 39, 829, DateTimeKind.Utc).AddTicks(9084), 350m });
>>>>>>>> 8d5e6282805b81ecb180088c11a400b87fd73803:SoftServeCinema.Infrastructure/Migrations/20240515180440_initial.cs

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "ReservationDate", "RowNumber", "SeatNumber", "SessionId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 1, "Available", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 1, "Available", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 1, "Available", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 1, "Available", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 1, "Available", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 1, "Available", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 1, "Available", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 1, "Available", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 1, "Available", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 1, "Available", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 1, "Available", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 1, "Available", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 1, "Available", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 1, "Available", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 1, "Available", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 1, "Available", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 1, "Available", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 1, "Available", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 1, "Available", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 1, "Available", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 1, "Available", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 1, "Available", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 1, "Available", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 1, "Available", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 1, "Available", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 1, "Available", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 1, "Available", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 1, "Available", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 1, "Available", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 1, "Available", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 1, "Available", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 1, "Available", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 1, "Available", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 1, "Available", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 1, "Available", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 1, "Available", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorEntityMovieEntity_MoviesId",
                table: "ActorEntityMovieEntity",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorEntityMovieEntity_MoviesId",
                table: "DirectorEntityMovieEntity",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreEntityMovieEntity_MoviesId",
                table: "GenreEntityMovieEntity",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityTagEntity_TagsId",
                table: "MovieEntityTagEntity",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "DirectorEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "GenreEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "MovieEntityTagEntity");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
