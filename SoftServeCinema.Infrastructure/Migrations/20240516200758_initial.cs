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
                    { 1, "Події розгортаються у найближчому майбутньому. Сполученими штатами котиться нищівна та всеохоплююча громадянська війна. Почалося із бажання кількох південних штатів відділитися і тепер уся країна охоплена бойовими діями. Група журналістів, серед яких відома репортерка (Кірстен Данст), яка і раніше часто знімала збройні конфлікти, рухаються у напрямку Вашингтона. Стає очевидним, що керівництво країни перетворилося на диктатуру, а повстанські угрупування повсюдно чинять воєнні злочини.", (ushort)108, new DateTime(2024, 6, 15, 20, 7, 56, 735, DateTimeKind.Utc).AddTicks(7616), (ushort)2024, "/movies/sw-vend.jpg", new DateTime(2024, 5, 15, 20, 7, 56, 735, DateTimeKind.Utc).AddTicks(7594), "Повстання Штатів", "https://www.youtube.com/embed/my8iHV3dpNI?si=88h7TyNtTLoGIupq" },
                    { 2, "Джоді Морено (Емілі Блант) знімає свій перший фільм у якості режисера. Вона дуже старається та хвилюється. Добре, що на знімальному майданчику завжди є кому її підбадьорити. Кольт (Раян Ґослінґ) – каскадер. Колись вони зустрічалися з Джоді, а нині просто працюють разом та підтримують одне одного. Кольт дублює актора, який грає головну роль. Якось цей актор безслідно зникає. Ніхто не може знайти його, а це означає, що Джоді не зможе дознімати свій дебютний проект і це зруйнує її кар’єру. Кольт дуже не хоче, щоб так сталося, тож погоджується стати на деякий час детективом та розшукати актора, який невідомо куди подівся.", (ushort)126, new DateTime(2024, 7, 5, 20, 7, 56, 735, DateTimeKind.Utc).AddTicks(7627), (ushort)2024, "/movies/fall_guy-vend.jpg", new DateTime(2024, 5, 21, 20, 7, 56, 735, DateTimeKind.Utc).AddTicks(7626), "Каскадер", "https://www.youtube.com/embed/Xmi7ZsHL6Jg?si=v2CGyMa6CcT2KUUY" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "18+" },
                    { 2, "12+" },
                    { 3, "VR" },
                    { 4, "Дивитись разом" },
                    { 5, "У темряві" },
                    { 6, "Для підлітків" },
                    { 7, "Фінансовий" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("551b099b-91de-48ab-bb52-518a67f35e5b"), "romanmedvedev0201@gmail.com", "Roman", "Koval", "User" },
                    { new Guid("a4612de6-84ef-454c-bca5-579bea951d02"), "r.medvedev@nltu.lviv.ua", "Roman", "Medvedev", "SuperAdmin" }
                });

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
                values: new object[,]
                {
                    { 1, 142m, 2, new DateTime(2024, 6, 3, 19, 25, 56, 735, DateTimeKind.Utc).AddTicks(8934), 373m },
                    { 2, 185m, 2, new DateTime(2024, 6, 2, 9, 26, 56, 735, DateTimeKind.Utc).AddTicks(9039), 377m },
                    { 3, 193m, 2, new DateTime(2024, 5, 28, 21, 16, 56, 735, DateTimeKind.Utc).AddTicks(9109), 353m },
                    { 4, 102m, 1, new DateTime(2024, 5, 21, 7, 23, 56, 735, DateTimeKind.Utc).AddTicks(9169), 278m },
                    { 5, 119m, 1, new DateTime(2024, 6, 2, 5, 56, 56, 735, DateTimeKind.Utc).AddTicks(9234), 351m },
                    { 6, 170m, 2, new DateTime(2024, 6, 4, 1, 17, 56, 735, DateTimeKind.Utc).AddTicks(9300), 298m },
                    { 7, 123m, 1, new DateTime(2024, 5, 30, 5, 6, 56, 735, DateTimeKind.Utc).AddTicks(9356), 254m },
                    { 8, 137m, 2, new DateTime(2024, 6, 2, 11, 9, 56, 735, DateTimeKind.Utc).AddTicks(9405), 342m },
                    { 9, 186m, 2, new DateTime(2024, 5, 27, 4, 17, 56, 735, DateTimeKind.Utc).AddTicks(9459), 300m },
                    { 10, 112m, 2, new DateTime(2024, 5, 31, 10, 50, 56, 735, DateTimeKind.Utc).AddTicks(9517), 342m },
                    { 11, 131m, 1, new DateTime(2024, 5, 26, 14, 12, 56, 735, DateTimeKind.Utc).AddTicks(9596), 313m },
                    { 12, 175m, 2, new DateTime(2024, 6, 5, 12, 23, 56, 735, DateTimeKind.Utc).AddTicks(9657), 260m },
                    { 13, 151m, 2, new DateTime(2024, 5, 18, 11, 44, 56, 735, DateTimeKind.Utc).AddTicks(9727), 317m },
                    { 14, 179m, 2, new DateTime(2024, 6, 2, 16, 20, 56, 735, DateTimeKind.Utc).AddTicks(9789), 363m },
                    { 15, 193m, 1, new DateTime(2024, 6, 2, 15, 19, 56, 735, DateTimeKind.Utc).AddTicks(9850), 262m },
                    { 16, 173m, 1, new DateTime(2024, 5, 29, 8, 58, 56, 735, DateTimeKind.Utc).AddTicks(9904), 351m },
                    { 17, 107m, 1, new DateTime(2024, 5, 20, 17, 44, 56, 735, DateTimeKind.Utc).AddTicks(9964), 252m },
                    { 18, 176m, 1, new DateTime(2024, 6, 5, 3, 11, 56, 736, DateTimeKind.Utc).AddTicks(5), 275m },
                    { 19, 120m, 2, new DateTime(2024, 6, 5, 17, 57, 56, 736, DateTimeKind.Utc).AddTicks(43), 282m },
                    { 20, 103m, 2, new DateTime(2024, 5, 19, 2, 39, 56, 736, DateTimeKind.Utc).AddTicks(79), 369m }
                });

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
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 1, "Available", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 2, "Available", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 2, "Available", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 2, "Available", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 2, "Available", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 2, "Available", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 2, "Available", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 2, "Available", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 2, "Available", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 2, "Available", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 2, "Available", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 2, "Available", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 2, "Available", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 2, "Available", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 2, "Available", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 2, "Available", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 2, "Available", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 2, "Available", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 2, "Available", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 2, "Available", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 2, "Available", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 2, "Available", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 2, "Available", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 2, "Available", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 2, "Available", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 2, "Available", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 2, "Available", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 2, "Available", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 2, "Available", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 2, "Available", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 2, "Available", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 2, "Available", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 2, "Available", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 2, "Available", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 2, "Available", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 2, "Available", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 2, "Available", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 3, "Available", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 3, "Available", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 3, "Available", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 3, "Available", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 3, "Available", null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 3, "Available", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 3, "Available", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 3, "Available", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 3, "Available", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 3, "Available", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 3, "Available", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 3, "Available", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 3, "Available", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 3, "Available", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 3, "Available", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 3, "Available", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 3, "Available", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 3, "Available", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 3, "Available", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 3, "Available", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 3, "Available", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 3, "Available", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 3, "Available", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 3, "Available", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 3, "Available", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 3, "Available", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 3, "Available", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 3, "Available", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 3, "Available", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 3, "Available", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 3, "Available", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 3, "Available", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 3, "Available", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 3, "Available", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 3, "Available", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 3, "Available", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 4, "Available", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 4, "Available", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 4, "Available", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 4, "Available", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 4, "Available", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 4, "Available", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 4, "Available", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 4, "Available", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 4, "Available", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 4, "Available", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 4, "Available", null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 4, "Available", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 4, "Available", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 4, "Available", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 4, "Available", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 4, "Available", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 4, "Available", null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 4, "Available", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 4, "Available", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 4, "Available", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 4, "Available", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 4, "Available", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 4, "Available", null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 4, "Available", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 4, "Available", null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 4, "Available", null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 4, "Available", null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 4, "Available", null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 4, "Available", null },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 4, "Available", null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 4, "Available", null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 4, "Available", null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 4, "Available", null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 4, "Available", null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 4, "Available", null },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 4, "Available", null },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 5, "Available", null },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 5, "Available", null },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 5, "Available", null },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 5, "Available", null },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 5, "Available", null },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 5, "Available", null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 5, "Available", null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 5, "Available", null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 5, "Available", null },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 5, "Available", null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 5, "Available", null },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 5, "Available", null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 5, "Available", null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 5, "Available", null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 5, "Available", null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 5, "Available", null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 5, "Available", null },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 5, "Available", null },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 5, "Available", null },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 5, "Available", null },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 5, "Available", null },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 5, "Available", null },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 5, "Available", null },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 5, "Available", null },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 5, "Available", null },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 5, "Available", null },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 5, "Available", null },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 5, "Available", null },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 5, "Available", null },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 5, "Available", null },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 5, "Available", null },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 5, "Available", null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 5, "Available", null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 5, "Available", null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 5, "Available", null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 5, "Available", null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 6, "Available", null },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 6, "Available", null },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 6, "Available", null },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 6, "Available", null },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 6, "Available", null },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 6, "Available", null },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 6, "Available", null },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 6, "Available", null },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 6, "Available", null },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 6, "Available", null },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 6, "Available", null },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 6, "Available", null },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 6, "Available", null },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 6, "Available", null },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 6, "Available", null },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 6, "Available", null },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 6, "Available", null },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 6, "Available", null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 6, "Available", null },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 6, "Available", null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 6, "Available", null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 6, "Available", null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 6, "Available", null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 6, "Available", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 6, "Available", null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 6, "Available", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 6, "Available", null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 6, "Available", null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 6, "Available", null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 6, "Available", null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 6, "Available", null },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 6, "Available", null },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 6, "Available", null },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 6, "Available", null },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 6, "Available", null },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 6, "Available", null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 7, "Available", null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 7, "Available", null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 7, "Available", null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 7, "Available", null },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 7, "Available", null },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 7, "Available", null },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 7, "Available", null },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 7, "Available", null },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 7, "Available", null },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 7, "Available", null },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 7, "Available", null },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 7, "Available", null },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 7, "Available", null },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 7, "Available", null },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 7, "Available", null },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 7, "Available", null },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 7, "Available", null },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 7, "Available", null },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 7, "Available", null },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 7, "Available", null },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 7, "Available", null },
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 7, "Available", null },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 7, "Available", null },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 7, "Available", null },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 7, "Available", null },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 7, "Available", null },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 7, "Available", null },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 7, "Available", null },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 7, "Available", null },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 7, "Available", null },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 7, "Available", null },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 7, "Available", null },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 7, "Available", null },
                    { 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 7, "Available", null },
                    { 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 7, "Available", null },
                    { 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 7, "Available", null },
                    { 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 8, "Available", null },
                    { 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 8, "Available", null },
                    { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 8, "Available", null },
                    { 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 8, "Available", null },
                    { 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 8, "Available", null },
                    { 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 8, "Available", null },
                    { 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 8, "Available", null },
                    { 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 8, "Available", null },
                    { 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 8, "Available", null },
                    { 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 8, "Available", null },
                    { 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 8, "Available", null },
                    { 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 8, "Available", null },
                    { 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 8, "Available", null },
                    { 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 8, "Available", null },
                    { 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 8, "Available", null },
                    { 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 8, "Available", null },
                    { 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 8, "Available", null },
                    { 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 8, "Available", null },
                    { 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 8, "Available", null },
                    { 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 8, "Available", null },
                    { 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 8, "Available", null },
                    { 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 8, "Available", null },
                    { 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 8, "Available", null },
                    { 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 8, "Available", null },
                    { 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 8, "Available", null },
                    { 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 8, "Available", null },
                    { 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 8, "Available", null },
                    { 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 8, "Available", null },
                    { 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 8, "Available", null },
                    { 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 8, "Available", null },
                    { 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 8, "Available", null },
                    { 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 8, "Available", null },
                    { 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 8, "Available", null },
                    { 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 8, "Available", null },
                    { 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 8, "Available", null },
                    { 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 8, "Available", null },
                    { 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 9, "Available", null },
                    { 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 9, "Available", null },
                    { 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 9, "Available", null },
                    { 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 9, "Available", null },
                    { 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 9, "Available", null },
                    { 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 9, "Available", null },
                    { 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 9, "Available", null },
                    { 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 9, "Available", null },
                    { 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 9, "Available", null },
                    { 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 9, "Available", null },
                    { 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 9, "Available", null },
                    { 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 9, "Available", null },
                    { 301, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 9, "Available", null },
                    { 302, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 9, "Available", null },
                    { 303, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 9, "Available", null },
                    { 304, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 9, "Available", null },
                    { 305, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 9, "Available", null },
                    { 306, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 9, "Available", null },
                    { 307, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 9, "Available", null },
                    { 308, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 9, "Available", null },
                    { 309, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 9, "Available", null },
                    { 310, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 9, "Available", null },
                    { 311, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 9, "Available", null },
                    { 312, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 9, "Available", null },
                    { 313, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 9, "Available", null },
                    { 314, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 9, "Available", null },
                    { 315, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 9, "Available", null },
                    { 316, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 9, "Available", null },
                    { 317, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 9, "Available", null },
                    { 318, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 9, "Available", null },
                    { 319, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 9, "Available", null },
                    { 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 9, "Available", null },
                    { 321, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 9, "Available", null },
                    { 322, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 9, "Available", null },
                    { 323, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 9, "Available", null },
                    { 324, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 9, "Available", null },
                    { 325, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 10, "Available", null },
                    { 326, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 10, "Available", null },
                    { 327, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 10, "Available", null },
                    { 328, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 10, "Available", null },
                    { 329, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 10, "Available", null },
                    { 330, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 10, "Available", null },
                    { 331, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 10, "Available", null },
                    { 332, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 10, "Available", null },
                    { 333, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 10, "Available", null },
                    { 334, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 10, "Available", null },
                    { 335, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 10, "Available", null },
                    { 336, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 10, "Available", null },
                    { 337, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 10, "Available", null },
                    { 338, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 10, "Available", null },
                    { 339, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 10, "Available", null },
                    { 340, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 10, "Available", null },
                    { 341, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 10, "Available", null },
                    { 342, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 10, "Available", null },
                    { 343, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 10, "Available", null },
                    { 344, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 10, "Available", null },
                    { 345, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 10, "Available", null },
                    { 346, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 10, "Available", null },
                    { 347, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 10, "Available", null },
                    { 348, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 10, "Available", null },
                    { 349, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 10, "Available", null },
                    { 350, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 10, "Available", null },
                    { 351, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 10, "Available", null },
                    { 352, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 10, "Available", null },
                    { 353, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 10, "Available", null },
                    { 354, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 10, "Available", null },
                    { 355, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 10, "Available", null },
                    { 356, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 10, "Available", null },
                    { 357, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 10, "Available", null },
                    { 358, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 10, "Available", null },
                    { 359, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 10, "Available", null },
                    { 360, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 10, "Available", null },
                    { 361, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 11, "Available", null },
                    { 362, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 11, "Available", null },
                    { 363, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 11, "Available", null },
                    { 364, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 11, "Available", null },
                    { 365, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 11, "Available", null },
                    { 366, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 11, "Available", null },
                    { 367, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 11, "Available", null },
                    { 368, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 11, "Available", null },
                    { 369, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 11, "Available", null },
                    { 370, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 11, "Available", null },
                    { 371, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 11, "Available", null },
                    { 372, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 11, "Available", null },
                    { 373, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 11, "Available", null },
                    { 374, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 11, "Available", null },
                    { 375, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 11, "Available", null },
                    { 376, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 11, "Available", null },
                    { 377, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 11, "Available", null },
                    { 378, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 11, "Available", null },
                    { 379, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 11, "Available", null },
                    { 380, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 11, "Available", null },
                    { 381, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 11, "Available", null },
                    { 382, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 11, "Available", null },
                    { 383, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 11, "Available", null },
                    { 384, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 11, "Available", null },
                    { 385, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 11, "Available", null },
                    { 386, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 11, "Available", null },
                    { 387, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 11, "Available", null },
                    { 388, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 11, "Available", null },
                    { 389, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 11, "Available", null },
                    { 390, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 11, "Available", null },
                    { 391, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 11, "Available", null },
                    { 392, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 11, "Available", null },
                    { 393, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 11, "Available", null },
                    { 394, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 11, "Available", null },
                    { 395, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 11, "Available", null },
                    { 396, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 11, "Available", null },
                    { 397, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 12, "Available", null },
                    { 398, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 12, "Available", null },
                    { 399, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 12, "Available", null },
                    { 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 12, "Available", null },
                    { 401, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 12, "Available", null },
                    { 402, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 12, "Available", null },
                    { 403, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 12, "Available", null },
                    { 404, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 12, "Available", null },
                    { 405, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 12, "Available", null },
                    { 406, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 12, "Available", null },
                    { 407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 12, "Available", null },
                    { 408, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 12, "Available", null },
                    { 409, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 12, "Available", null },
                    { 410, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 12, "Available", null },
                    { 411, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 12, "Available", null },
                    { 412, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 12, "Available", null },
                    { 413, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 12, "Available", null },
                    { 414, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 12, "Available", null },
                    { 415, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 12, "Available", null },
                    { 416, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 12, "Available", null },
                    { 417, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 12, "Available", null },
                    { 418, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 12, "Available", null },
                    { 419, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 12, "Available", null },
                    { 420, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 12, "Available", null },
                    { 421, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 12, "Available", null },
                    { 422, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 12, "Available", null },
                    { 423, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 12, "Available", null },
                    { 424, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 12, "Available", null },
                    { 425, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 12, "Available", null },
                    { 426, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 12, "Available", null },
                    { 427, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 12, "Available", null },
                    { 428, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 12, "Available", null },
                    { 429, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 12, "Available", null },
                    { 430, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 12, "Available", null },
                    { 431, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 12, "Available", null },
                    { 432, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 12, "Available", null },
                    { 433, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 13, "Available", null },
                    { 434, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 13, "Available", null },
                    { 435, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 13, "Available", null },
                    { 436, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 13, "Available", null },
                    { 437, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 13, "Available", null },
                    { 438, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 13, "Available", null },
                    { 439, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 13, "Available", null },
                    { 440, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 13, "Available", null },
                    { 441, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 13, "Available", null },
                    { 442, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 13, "Available", null },
                    { 443, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 13, "Available", null },
                    { 444, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 13, "Available", null },
                    { 445, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 13, "Available", null },
                    { 446, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 13, "Available", null },
                    { 447, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 13, "Available", null },
                    { 448, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 13, "Available", null },
                    { 449, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 13, "Available", null },
                    { 450, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 13, "Available", null },
                    { 451, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 13, "Available", null },
                    { 452, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 13, "Available", null },
                    { 453, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 13, "Available", null },
                    { 454, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 13, "Available", null },
                    { 455, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 13, "Available", null },
                    { 456, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 13, "Available", null },
                    { 457, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 13, "Available", null },
                    { 458, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 13, "Available", null },
                    { 459, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 13, "Available", null },
                    { 460, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 13, "Available", null },
                    { 461, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 13, "Available", null },
                    { 462, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 13, "Available", null },
                    { 463, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 13, "Available", null },
                    { 464, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 13, "Available", null },
                    { 465, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 13, "Available", null },
                    { 466, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 13, "Available", null },
                    { 467, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 13, "Available", null },
                    { 468, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 13, "Available", null },
                    { 469, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 14, "Available", null },
                    { 470, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 14, "Available", null },
                    { 471, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 14, "Available", null },
                    { 472, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 14, "Available", null },
                    { 473, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 14, "Available", null },
                    { 474, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 14, "Available", null },
                    { 475, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 14, "Available", null },
                    { 476, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 14, "Available", null },
                    { 477, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 14, "Available", null },
                    { 478, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 14, "Available", null },
                    { 479, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 14, "Available", null },
                    { 480, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 14, "Available", null },
                    { 481, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 14, "Available", null },
                    { 482, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 14, "Available", null },
                    { 483, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 14, "Available", null },
                    { 484, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 14, "Available", null },
                    { 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 14, "Available", null },
                    { 486, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 14, "Available", null },
                    { 487, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 14, "Available", null },
                    { 488, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 14, "Available", null },
                    { 489, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 14, "Available", null },
                    { 490, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 14, "Available", null },
                    { 491, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 14, "Available", null },
                    { 492, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 14, "Available", null },
                    { 493, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 14, "Available", null },
                    { 494, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 14, "Available", null },
                    { 495, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 14, "Available", null },
                    { 496, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 14, "Available", null },
                    { 497, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 14, "Available", null },
                    { 498, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 14, "Available", null },
                    { 499, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 14, "Available", null },
                    { 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 14, "Available", null },
                    { 501, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 14, "Available", null },
                    { 502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 14, "Available", null },
                    { 503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 14, "Available", null },
                    { 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 14, "Available", null },
                    { 505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 15, "Available", null },
                    { 506, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 15, "Available", null },
                    { 507, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 15, "Available", null },
                    { 508, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 15, "Available", null },
                    { 509, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 15, "Available", null },
                    { 510, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 15, "Available", null },
                    { 511, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 15, "Available", null },
                    { 512, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 15, "Available", null },
                    { 513, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 15, "Available", null },
                    { 514, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 15, "Available", null },
                    { 515, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 15, "Available", null },
                    { 516, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 15, "Available", null },
                    { 517, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 15, "Available", null },
                    { 518, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 15, "Available", null },
                    { 519, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 15, "Available", null },
                    { 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 15, "Available", null },
                    { 521, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 15, "Available", null },
                    { 522, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 15, "Available", null },
                    { 523, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 15, "Available", null },
                    { 524, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 15, "Available", null },
                    { 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 15, "Available", null },
                    { 526, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 15, "Available", null },
                    { 527, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 15, "Available", null },
                    { 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 15, "Available", null },
                    { 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 15, "Available", null },
                    { 530, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 15, "Available", null },
                    { 531, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 15, "Available", null },
                    { 532, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 15, "Available", null },
                    { 533, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 15, "Available", null },
                    { 534, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 15, "Available", null },
                    { 535, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 15, "Available", null },
                    { 536, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 15, "Available", null },
                    { 537, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 15, "Available", null },
                    { 538, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 15, "Available", null },
                    { 539, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 15, "Available", null },
                    { 540, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 15, "Available", null },
                    { 541, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 16, "Available", null },
                    { 542, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 16, "Available", null },
                    { 543, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 16, "Available", null },
                    { 544, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 16, "Available", null },
                    { 545, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 16, "Available", null },
                    { 546, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 16, "Available", null },
                    { 547, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 16, "Available", null },
                    { 548, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 16, "Available", null },
                    { 549, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 16, "Available", null },
                    { 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 16, "Available", null },
                    { 551, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 16, "Available", null },
                    { 552, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 16, "Available", null },
                    { 553, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 16, "Available", null },
                    { 554, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 16, "Available", null },
                    { 555, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 16, "Available", null },
                    { 556, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 16, "Available", null },
                    { 557, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 16, "Available", null },
                    { 558, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 16, "Available", null },
                    { 559, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 16, "Available", null },
                    { 560, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 16, "Available", null },
                    { 561, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 16, "Available", null },
                    { 562, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 16, "Available", null },
                    { 563, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 16, "Available", null },
                    { 564, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 16, "Available", null },
                    { 565, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 16, "Available", null },
                    { 566, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 16, "Available", null },
                    { 567, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 16, "Available", null },
                    { 568, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 16, "Available", null },
                    { 569, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 16, "Available", null },
                    { 570, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 16, "Available", null },
                    { 571, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 16, "Available", null },
                    { 572, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 16, "Available", null },
                    { 573, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 16, "Available", null },
                    { 574, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 16, "Available", null },
                    { 575, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 16, "Available", null },
                    { 576, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 16, "Available", null },
                    { 577, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 17, "Available", null },
                    { 578, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 17, "Available", null },
                    { 579, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 17, "Available", null },
                    { 580, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 17, "Available", null },
                    { 581, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 17, "Available", null },
                    { 582, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 17, "Available", null },
                    { 583, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 17, "Available", null },
                    { 584, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 17, "Available", null },
                    { 585, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 17, "Available", null },
                    { 586, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 17, "Available", null },
                    { 587, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 17, "Available", null },
                    { 588, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 17, "Available", null },
                    { 589, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 17, "Available", null },
                    { 590, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 17, "Available", null },
                    { 591, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 17, "Available", null },
                    { 592, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 17, "Available", null },
                    { 593, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 17, "Available", null },
                    { 594, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 17, "Available", null },
                    { 595, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 17, "Available", null },
                    { 596, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 17, "Available", null },
                    { 597, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 17, "Available", null },
                    { 598, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 17, "Available", null },
                    { 599, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 17, "Available", null },
                    { 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 17, "Available", null },
                    { 601, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 17, "Available", null },
                    { 602, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 17, "Available", null },
                    { 603, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 17, "Available", null },
                    { 604, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 17, "Available", null },
                    { 605, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 17, "Available", null },
                    { 606, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 17, "Available", null },
                    { 607, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 17, "Available", null },
                    { 608, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 17, "Available", null },
                    { 609, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 17, "Available", null },
                    { 610, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 17, "Available", null },
                    { 611, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 17, "Available", null },
                    { 612, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 17, "Available", null },
                    { 613, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 18, "Available", null },
                    { 614, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 18, "Available", null },
                    { 615, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 18, "Available", null },
                    { 616, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 18, "Available", null },
                    { 617, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 18, "Available", null },
                    { 618, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 18, "Available", null },
                    { 619, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 18, "Available", null },
                    { 620, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 18, "Available", null },
                    { 621, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 18, "Available", null },
                    { 622, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 18, "Available", null },
                    { 623, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 18, "Available", null },
                    { 624, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 18, "Available", null },
                    { 625, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 18, "Available", null },
                    { 626, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 18, "Available", null },
                    { 627, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 18, "Available", null },
                    { 628, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 18, "Available", null },
                    { 629, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 18, "Available", null },
                    { 630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 18, "Available", null },
                    { 631, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 18, "Available", null },
                    { 632, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 18, "Available", null },
                    { 633, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 18, "Available", null },
                    { 634, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 18, "Available", null },
                    { 635, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 18, "Available", null },
                    { 636, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 18, "Available", null },
                    { 637, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 18, "Available", null },
                    { 638, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 18, "Available", null },
                    { 639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 18, "Available", null },
                    { 640, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 18, "Available", null },
                    { 641, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 18, "Available", null },
                    { 642, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 18, "Available", null },
                    { 643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 18, "Available", null },
                    { 644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 18, "Available", null },
                    { 645, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 18, "Available", null },
                    { 646, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 18, "Available", null },
                    { 647, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 18, "Available", null },
                    { 648, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 18, "Available", null },
                    { 649, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 19, "Available", null },
                    { 650, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 19, "Available", null },
                    { 651, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 19, "Available", null },
                    { 652, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 19, "Available", null },
                    { 653, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 19, "Available", null },
                    { 654, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 19, "Available", null },
                    { 655, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 19, "Available", null },
                    { 656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 19, "Available", null },
                    { 657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 19, "Available", null },
                    { 658, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 19, "Available", null },
                    { 659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 19, "Available", null },
                    { 660, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 19, "Available", null },
                    { 661, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 19, "Available", null },
                    { 662, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 19, "Available", null },
                    { 663, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 19, "Available", null },
                    { 664, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 19, "Available", null },
                    { 665, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 19, "Available", null },
                    { 666, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 19, "Available", null },
                    { 667, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 19, "Available", null },
                    { 668, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 19, "Available", null },
                    { 669, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 19, "Available", null },
                    { 670, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 19, "Available", null },
                    { 671, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 19, "Available", null },
                    { 672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 19, "Available", null },
                    { 673, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 19, "Available", null },
                    { 674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 19, "Available", null },
                    { 675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 19, "Available", null },
                    { 676, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 19, "Available", null },
                    { 677, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 19, "Available", null },
                    { 678, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 19, "Available", null },
                    { 679, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 19, "Available", null },
                    { 680, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 19, "Available", null },
                    { 681, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 19, "Available", null },
                    { 682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 19, "Available", null },
                    { 683, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 19, "Available", null },
                    { 684, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 19, "Available", null },
                    { 685, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)1, 20, "Available", null },
                    { 686, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)2, 20, "Available", null },
                    { 687, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)3, 20, "Available", null },
                    { 688, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)4, 20, "Available", null },
                    { 689, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)5, 20, "Available", null },
                    { 690, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1, (short)6, 20, "Available", null },
                    { 691, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)1, 20, "Available", null },
                    { 692, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)2, 20, "Available", null },
                    { 693, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)3, 20, "Available", null },
                    { 694, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)4, 20, "Available", null },
                    { 695, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)5, 20, "Available", null },
                    { 696, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, (short)6, 20, "Available", null },
                    { 697, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)1, 20, "Available", null },
                    { 698, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)2, 20, "Available", null },
                    { 699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)3, 20, "Available", null },
                    { 700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)4, 20, "Available", null },
                    { 701, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)5, 20, "Available", null },
                    { 702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)3, (short)6, 20, "Available", null },
                    { 703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)1, 20, "Available", null },
                    { 704, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)2, 20, "Available", null },
                    { 705, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)3, 20, "Available", null },
                    { 706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)4, 20, "Available", null },
                    { 707, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)5, 20, "Available", null },
                    { 708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, (short)6, 20, "Available", null },
                    { 709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)1, 20, "Available", null },
                    { 710, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)2, 20, "Available", null },
                    { 711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)3, 20, "Available", null },
                    { 712, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)4, 20, "Available", null },
                    { 713, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)5, 20, "Available", null },
                    { 714, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)5, (short)6, 20, "Available", null },
                    { 715, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)1, 20, "Available", null },
                    { 716, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)2, 20, "Available", null },
                    { 717, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)3, 20, "Available", null },
                    { 718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)4, 20, "Available", null },
                    { 719, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)5, 20, "Available", null },
                    { 720, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)6, (short)6, 20, "Available", null }
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
