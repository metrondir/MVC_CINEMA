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
                    { 5, "Джефферсон Вайт" },
                    { 6, "Вагнер Моура" },
                    { 7, "Раян Ґослінґ" },
                    { 8, "Емілі Блант" },
                    { 9, "Аарон Тейлор-Джонсон" },
                    { 10, "Тереза Палмер" },
                    { 11, "Вінстон Дюк" },
                    { 12, "Овен Тіґ" },
                    { 13, "Фрея Аллан" },
                    { 14, "Кевін Дюранд" },
                    { 15, "Пітер Макон" },
                    { 16, "Вільям Мейсі" },
                    { 17, "Фібі Воллер-Брідж" },
                    { 18, "Раян Рейнольдс" },
                    { 19, "Кейлі Флемінг" },
                    { 20, "Метт Деймон" },
                    { 21, "Андрій Прохоров" },
                    { 22, "Олег Яворський" },
                    { 23, "Олексій Ситянов" },
                    { 24, "Олександр Кохановський" },
                    { 25, "Володимир Корунчак" },
                    { 26, "Олександр Новіков" },
                    { 27, "Олександр Максимчук" },
                    { 28, "Олег Данилов" },
                    { 29, "Дін Шарп" },
                    { 30, "Андрій Римарук" },
                    { 31, "Роман Луцький" },
                    { 32, "Ніка Мислицька" },
                    { 33, "Надія Левченко" },
                    { 34, "Ігор Шульга" },
                    { 35, "Олександр Данилюк" },
                    { 36, "Станіслав Асєєв" },
                    { 37, "Білл Наї" },
                    { 38, "Сімон Ешлі" },
                    { 39, "Софі Оконедо" },
                    { 40, "Зейн Малік" },
                    { 41, "Мо Гілліган" },
                    { 42, "Дмитро Олійник" },
                    { 43, "В'ячеслав Довженко" },
                    { 44, "Станіслав Сукненко" },
                    { 45, "Ніна Набока" },
                    { 46, "Марина Кошкіна" },
                    { 47, "Юрій Одинокий" },
                    { 48, "Борис Георгієвський" },
                    { 49, "Ігор Гнєзділов" },
                    { 50, "Гаррієт Слейтер" },
                    { 51, "Адаїн Бредлі" },
                    { 52, "Джейкоб Баталон" },
                    { 53, "Джош О’Коннор" },
                    { 54, "Майк Файст" },
                    { 55, "Кіану Хем" },
                    { 56, "Анна Плаж" },
                    { 57, "Марія Гофштеттер" },
                    { 58, "Давід Шайд" },
                    { 59, "Єгор Козлов" },
                    { 60, "Дмитро Лінартович" },
                    { 61, "Василь Баша" },
                    { 62, "Ганна Адамович" },
                    { 63, "Владислав Мамчур" },
                    { 64, "Юліан Вальднер" },
                    { 65, "Валері Губер" },
                    { 66, "Отто Янкович" },
                    { 67, "Рафаель Ніколас" },
                    { 68, "Ентоні Гопкінс" },
                    { 69, "Джонні Флінн" },
                    { 70, "Гелена Бонем Картер" },
                    { 71, "Джонатан Прайс" },
                    { 72, "Зіггі Хіт" },
                    { 73, "Марта Келлер" },
                    { 74, "Меделін Петш" },
                    { 75, "Фрой Гутьєррез" },
                    { 76, "Рейчел Шентон" },
                    { 77, "Річард Брейк" },
                    { 78, "Ема Хорват" },
                    { 79, "Матеуш Дамецький" },
                    { 80, "Моніка Пікула" },
                    { 81, "Даріуш Якубовскі" },
                    { 82, "Ліліана Зайберт" },
                    { 83, "Адам Воронович" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Алекс Ґарленд" },
                    { 2, "Девід Літч" },
                    { 3, "Вес Болл" },
                    { 4, "Джон Красінскі" },
                    { 5, "Артем Григорян" },
                    { 6, "Валентин Васянович" },
                    { 7, "Крістофер Дженкінс" },
                    { 8, "Тарас Томенко" },
                    { 9, "Спенсер Коен" },
                    { 10, "Анна Голберґ" },
                    { 11, "Лука Ґуаданьїно" },
                    { 12, "Северін Фіала" },
                    { 13, "Вероніка Франц" },
                    { 14, "Володимир Харченко-Куликовський" },
                    { 15, "Андреас Шмід" },
                    { 16, "Джеймс Хоуз" },
                    { 17, "Ренні Гарлін" },
                    { 18, "Маґдалена Нєц" }
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
                    { 12, "документальний" },
                    { 13, "наукова фантастика" },
                    { 14, "фантастика" },
                    { 15, "воєнна драма" },
                    { 16, "українське" },
                    { 17, "анімація" },
                    { 18, "історія" },
                    { 19, "мелодрама" },
                    { 20, "містика" },
                    { 21, "біографія" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Desc", "Duration", "EndRentalDate", "GraduationYear", "ImagePath", "StartRentalDate", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "Події розгортаються у найближчому майбутньому. Сполученими штатами котиться нищівна та всеохоплююча громадянська війна. Почалося із бажання кількох південних штатів відділитися і тепер уся країна охоплена бойовими діями. Група журналістів, серед яких відома репортерка (Кірстен Данст), яка і раніше часто знімала збройні конфлікти, рухаються у напрямку Вашингтона. Стає очевидним, що керівництво країни перетворилося на диктатуру, а повстанські угрупування повсюдно чинять воєнні злочини.", (ushort)108, new DateTime(2024, 6, 16, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1695), (ushort)2024, "/movies/sw-vend.jpg", new DateTime(2024, 5, 16, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1689), "Повстання Штатів", "https://www.youtube.com/embed/my8iHV3dpNI?si=88h7TyNtTLoGIupq" },
                    { 2, "Джоді Морено (Емілі Блант) знімає свій перший фільм у якості режисера. Вона дуже старається та хвилюється. Добре, що на знімальному майданчику завжди є кому її підбадьорити. Кольт (Раян Ґослінґ) – каскадер. Колись вони зустрічалися з Джоді, а нині просто працюють разом та підтримують одне одного. Кольт дублює актора, який грає головну роль. Якось цей актор безслідно зникає. Ніхто не може знайти його, а це означає, що Джоді не зможе дознімати свій дебютний проект і це зруйнує її кар’єру. Кольт дуже не хоче, щоб так сталося, тож погоджується стати на деякий час детективом та розшукати актора, який невідомо куди подівся.", (ushort)126, new DateTime(2024, 6, 1, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1702), (ushort)2024, "/movies/fall_guy-vend.jpg", new DateTime(2024, 4, 27, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1701), "Каскадер", "https://www.youtube.com/embed/Xmi7ZsHL6Jg?si=v2CGyMa6CcT2KUUY" },
                    { 3, "Минуло кілька поколінь з часів правління Цезаря. Молодий шимпанзе Ноа (Овен Тіґ) уважно слухає усе, що розповідають йому про минуле і про те, як відбувався розвиток тих чи інших технологій. Він починає помічати дедалі більше невідповідностей. Аби пересвідчитись чи правильні його здогадки, він бере з собою людську дівчину на ім’я Мей (Фрея Алан). Люди давно здичавіли, тож не варто очікувати від неї багато. Разом Ноа та Мей вирушають у виснажливу подорож, результати якої визначать подальший розвиток як мавп, так і людей.\r\n\r\nФантастичний бойовик «Королівство планети мавп» є прямим продовженням фільму «Війна за планету мавп», що вийшов у 2017 році та четвертим фільмом перезапуску франшизи «Планета мавп». Про ідею цього фільму говорили ще у 2016 році. У 2019 році компанія Walt Disney оголосила, що у розробці знаходяться нові фільми та їх події розгортатимуться у тому ж всесвіті, що й фільм «Повстання планети мавп» 2011 року . Передбачається, що на екрани вийде ще щонайменше 2 фільми.", (ushort)145, new DateTime(2024, 6, 6, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1705), (ushort)2024, "/movies/kotpota_vend.jpg", new DateTime(2024, 5, 10, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1704), "Королівство планети мавп", "https://www.youtube.com/embed/Ed-rbhWhzTU?si=mIuERJ2K7Q-exaYq" },
                    { 4, "Дівчинка на ім’я Бі (Кейлі Флемінг) раптом починає бачити уявних друзів. Звісно, деякі діти фантазують про таку компанію. Однак Бі нічого не вигадувала. Дівчинка бачить безліч дивних персонажів, яких вигадав хтось інший. Виявляється, що такою самою силою наділений і її сусід (Раян Рейнольдс). Тепер вони удвох даватимуть раду чималій когорті чудернацьких створінь. Справа в тім, що діти, які вигадали цих персонажів, давно виросли та забули про своїх кращих друзів. Було б добре їм знову зустрітися.\r\n\r\nФентезійна комедійна драма «Уявні Друзі (УД)» – це дітище Джона Красінскі, відомого передовсім за роллю у серіалі «Офіс». Він має досвід створення повнометражного кіно («Тихе місце»), однак цього разу вдався до нового для себе жанру, сам займався сценарієм та режисурою. Проект для сімейного перегляду задумав у співпраці з батьком чотирьох дітей Раяном Рейнольдсом. Вони удвох продюсували фільм та знімалися у ньому.", (ushort)104, new DateTime(2024, 6, 16, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1708), (ushort)2024, "/movies/if-vend2.jpg", new DateTime(2024, 5, 16, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1708), "Уявні Друзі", "https://www.youtube.com/embed/EFrEPzxmQjM?si=d-0RtIH00F7L0dg6" },
                    { 5, "У 2001 році молоді київські розробники на чолі з Сергієм Григоровичем вирішують зробити найскладнішу гру в світі з реалістичною графікою, відкритим світом і нетиповим сюжетом довкола Чорнобильської зони.\r\n\r\nЗ початку промокампанії S.T.A.L.K.E.R. чекали сотні тисяч людей по всьому світу, але розробники стали заручниками своїх амбіцій. Вони безкінечно покращували гру та з року в рік переносили дату виходу. Але в один момент американському видавцю увірвався терпець.\r\n\r\nЦе історія про індустрію відеоігор, любов до своєї роботи та проєкт, який перейшов межі екранів і став попкультурним феноменом.\r\n\r\n«ЕПІЗОДИ» — це історії незалежної України. Вони здаються такими різними, але водночас дуже схожі: наївні, сумні, амбітні. Це визначні події, на яких виросли цілі покоління. Розповіді від перших осіб із використанням унікальних архівних матеріалів.", (ushort)77, new DateTime(2024, 6, 8, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1711), (ushort)2024, "/movies/stalker-vend2.jpg", new DateTime(2024, 5, 13, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1711), "ЕПІЗОДИ: Тінь Чорнобиля", "https://www.youtube.com/embed/wkSS8XmDSGc?si=l-lyfNL7pmUzB-ia" },
                    { 6, "Восени 2014 року хірург Сергій (Роман Луцький), який останнім часом оперує багато поранених на російсько-українській війні, вирішує стати військовим лікарем. Майже одразу Сергій потрапляє в полон. Він пережив нелюдські тортури та приниження. Від смерті його врятувало тільки те, що ФСБшникам, які катували полонених, потрібно було радитись з лікарем. Повернувшись додому після обміну Сергій намагається налагодити мирне життя та відновити спілкування з колишньою дружиною та донькою Поліною (Ніка Мислицька).\r\n\r\nВоєнна драма «Відблиск», знята режисером та сценаристом Валентином Васяновичем, є першою українською стрічкою, що брала участь у основній програмі Венеціанського кінофестивалю. Сценарій був готовий у 2019 році, а основні зйомки проходили з літа 2020 року по січень 2021 у Києві та його околицях Серед тих, хто знімався у фільмі – справжній хірург Олександр Данилюк, який зробив в польових умовах понад 70 операцій та журналіст Станіслав Асєєв, який два роки пробув у російському полоні.", (ushort)126, new DateTime(2024, 6, 8, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1715), (ushort)2021, "/movies/reflection-vend.jpg", new DateTime(2024, 5, 13, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1714), "Відблиск", "https://www.youtube.com/embed/voDDciroV1A?si=6tx7HhMJM0hbKrMb" },
                    { 7, "Беккет (Мо Гілліган) був маленьким беззахисним кошеням, коли мало не загинув. Його врятувала Роуз (Сімон Ешлі) та забрала жити до себе. Відтоді Беккет став геть іншим – сміливішим, впевненішим у собі та, звісно, огряднішим. Незмінними лишилися лише його впізнавані різнокольорові очі. Кіт був впевнений у тому, що вся увага та любов Роуз налижить лише йому. Тож коли дівчина почала дбати не лише про нього, Беккет втнув дещо необачне. Як результат він витратив відведені йому 9 життів. Аби повернутися до улюбленої хазяйки він знову потрапить на землю, але це буде зовсім не те життя, до якого він звик.\r\n\r\nКомедійний сімейний мультфільм «10 життя» створено спільно Великою Британією та Канадою на монреальській студії L'Atelier Animation. Режисер та сценарист проекту – Крістофер Дженкінс, кар’єра якого починалася у Walt Disney Pictures. У якості аніматора ефектів він працював над багатьма мультфільмами студії, серед яких «Русалонька» та «Король Лев».", (ushort)88, new DateTime(2024, 6, 12, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1718), (ushort)2024, "/movies/10Lives-vend.jpg", new DateTime(2024, 5, 7, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1717), "10 життя", "https://www.youtube.com/embed/wIQE7rBdr1c?si=XDXbqcIQFyXus8Nk" },
                    { 8, "1927 року у Харкові за наказом Сталіна збудовано особливий будинок. Тут оселилися кращі українські митці – поети, письменники, художники та режисери. Сама лише можливість жити тут вже була для тогочасних творців визнанням. Якось у будинку з’являється новенький. Він працює коректором преси та понад усе мріє влитися в когорту провідних письменників. Аби оселитися тут йому дійсно знадобився талант – талант підслуховувати та переповідати все почуте агенту НКВС.\r\n\r\nІсторична драма «Будинок «Слово». Нескінчений роман» знята Тарасом Томенком за сценарієм, написаним ним спільно з Любов’ю Якимчук. У 2017 році він зняв документальний фільм «Будинок «Слово»», робота над яким надихнула на подальше дослідження епохи та персоналій. Проект художнього фільму став одним з переможців конкурсу від Держкіно та отримав державне фінансування, що покрило половину витрат на виробництво.", (ushort)120, new DateTime(2024, 6, 6, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1721), (ushort)2024, "/movies/BSNR-vend.jpg", new DateTime(2024, 5, 7, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1720), "Будинок «Слово». Нескінчений роман", "https://www.youtube.com/embed/EdwK7LCzw1k?si=7Ms_0kyh7mJKAgLg" },
                    { 9, "Компанія друзів збирається разом. Замість звичних посиденьок вони влаштовують ворожіння на картах Таро, які одна з дівчат випадково знайшла на захаращеному горищі. Головна помилка, якої вони припустились – порушення незмінного правила про те, що не можна брати до рук чужі карти. Вечір довгий, тож поворожити встигли усім присутнім. Такі їхні дії вивільнили древні зли сили, які не прощають тим, хто порушив їхній спокій. Колода карт була проклятою і тепер смерть чекає на кожного, хто насмілився дізнатися свою подальшу долю з їх допомогою. Для кожного, кому ворожили, починаються перегони зі лихою силою, яка не знає ані втоми, ані жалю.\r\n\r\nФільм жахів «Таро» зняли Спенсер Коен та Анна Ройс. Вони спільно написали сценарій, використавши за основу книгу «Жахи», написану Ніколасом Адамсом у 1992 році. Режисурою зайнялися також удвох і для обох цей фільм став дебютним на великому екрані, тоді як у сценарній справі досвід мали обоє.", (ushort)92, new DateTime(2024, 6, 10, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1724), (ushort)2024, "/movies/TAROT-vend.jpg", new DateTime(2024, 5, 16, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1723), "Таро", "https://www.youtube.com/embed/j3wUuh8GJto?si=OrZerBeec68n6Yrv" },
                    { 10, "Чемпіон Турніру Великого шлему Арт Дональдсон (Майк Файст) зазнає серію поразок. Колись він був посереднім гравцем. Чемпіона з нього зробила його дружина Таші (Зендея). Тенісистка у минулому, нині вона присвятила себе тренуванню чоловіка. Аби він повернув собі жагу до перемог, Таші записує його до участі у турнірі Challenger. Зазвичай у ньому беруть участь початківці або гравці другого дивізіону. Однак для ситуації, що склалася у Арта, це буде доречно. Незадовго до змагань чоловік дізнається, що у турнірній сітці його суперником буде Патрік Цвейг (Джош О'Коннор), колишній коханець його дружини та його кращий друг.\r\n\r\nСпортивну мелодраму «Суперники» зняв режисер Лука Ґуаданьїно, чотириразовий володар премій Венеціанського кінофестивалю. Для зйомок у фільмі Зендая впродовж трьох місяців займалася з професійним тенісним тренером. Зйомки розпочалися у травні 2022 року у Бостоні. Цьому передували кастинги, під час яких серед місцевих жителів шукали акторів масовки.", (ushort)132, new DateTime(2024, 6, 11, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1727), (ushort)2024, "/movies/CHLNGRS-vend2.jpg", new DateTime(2024, 5, 2, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1727), "Суперники", "https://www.youtube.com/embed/ckcxzebS5hk?si=ERSDSJqtNnVuBH1n" },
                    { 11, "Дівчина з бідної родини виходить заміж та оселяється у віддаленому будинку її обранця посеред густого лісу. Світ чоловіка для неї геть чужий, а мрії про дитину стають нездійсненним тягарем. З кожним днем важкої рутини та марних сподівань, вона все більше закривається в собі. Допоки не опиняється на темному шляху, що веде до злих думок. Можливо, не лише думок…", (ushort)121, new DateTime(2024, 5, 18, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1730), (ushort)2024, "/movies/vend.jpg", new DateTime(2024, 5, 18, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1730), "Лазня диявола (в рамках фестивалю)", "https://www.youtube.com/embed/vtmo7fplVWo?si=DKOyUUar-Z5cFUwj" },
                    { 12, "Війна, що триває з 2014 року, вплинула на життя багатьох українців. Якось посеред ночі на телефон батька (В'ячеслав Довженко) замість сина з його номера зателефонував невідомий. Так стало відомо, що хлопець, який виконував бойове завдання, потрапив у полон. Аби визволити його батько повинен сам поїхати на лінію розмежування та привезти зазначену суму. Однак на обмін замість сина привезли іншого хлопця. У таких самих або подібних обставинах не лише ці син і батько. З кожним днем число родин, чиє життя докорінно змінила війна, щоразу більшає. Тож чи можна домовитися з ворогом, для якого не існує ніяких правил та етичних норм?\r\n\r\nВоєнна драма «Обмін» створена за підтримки Державного агентства з питань кіно. Режисер проекту Володимир Харченко-Куликовський має великий досвід у виробництві серіалів для українського телебачення. Зйомки велися на території Київської області, у Броварському районі, який на початку повномасштабного вторгнення був частково окупований.", (ushort)90, new DateTime(2024, 5, 24, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1733), (ushort)2024, "/movies/obmin-vend-18.jpg", new DateTime(2024, 5, 15, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1733), "Обмін", "https://www.youtube.com/embed/obiN4-XK7_4?si=Tv8aIjC6LNcY96Nt" },
                    { 13, "Зимова Олімпіада 1976 року. Гірськолижнику Францу Кламмеру тільки 22 роки, а його вже називають майбутньою зіркою. За плечима юнака чимало перемог, тож преса й публіка сподіваються на його нові здобутки. Але тиск очікувань тисяч австрійців — не єдиний виклик у цьому змаганні. Незадовго до перегонів спонсор вирішує змінити звичні форму та спорядження, погодні умови чимдалі гіршають, а траса здається неприступною. Єдине, що не дає герою зламатися — кохання його життя.", (ushort)100, new DateTime(2024, 5, 18, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1736), (ushort)2024, "/movies/vend1.jpg", new DateTime(2024, 5, 18, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1736), "Виходячи за межі (в рамках фестивалю)", "https://www.youtube.com/embed/ecp1xSqaA5c?si=OvYH_CGwjXdqGGNw" },
                    { 14, "1988 року Ніколаса Вінтона (Ентоні Гопкінс) запрошують на телевізійне шоу. Ведуча розповідає про унікальну місію порятунку сотень дітей. Напередодні Другої світової війни з Праги до Великої Британії перевезли спеціальними поїздами дітей, переважно єврейських. Усі вони змушені були шукати новий дім з остраху перед діями нацистів. Координував операцію 29-річний Ніколас Вінтон (Джонні Флінн). Кожному перевезеному потрібно було знайти нове місце проживання та чималу суму грошей. Близько 50 років деталі перевезення не оприлюднювалися і ось, нарешті, настав час оцінити масштаби зробленого.\r\n\r\nБіографічна драма «Одне життя» заснована на книзі Барбари Вінтон, яку жінка написала про свого батька, Ніколаса Вінтона. На початку 1939 року він організував маршрут, яким було перевезено 669 дітей. На зйомках фільму були задіяні нащадки врятованих дітей. Барбара Вінтон особисто попросила Ентоні Хопкінса виконати роль її батька. Знімали фільм у Празі та Лондоні наприкінці 2022 року.", (ushort)108, new DateTime(2024, 5, 29, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1739), (ushort)2023, "/movies/ol-vend3.jpg", new DateTime(2024, 5, 23, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1739), "Одне життя", "https://www.youtube.com/embed/R0qZJggKri0?si=Iu5Rg7eDTJeoF6-q" },
                    { 15, "Закохана пара Майа (Меделін Петш) та Райан (Фрой Гутьєррез) на честь своєї п’ятої річниці подорожують крізь усю країну до Тихоокеанського узбережжя. Дорогою через штат Орегон в них ламається машина. Заночувати доведеться у єдиному доступному місці – старенькому будиночку десь у хащах на околиці маленького непривітного міста. Що люди, що краєвиди не викликали жодної симпатії, але Майа звикла знаходити хороше у всьому, що їх оточує. З настанням ночі всього оптимізму світу не вистачить, аби розгледіти бодай щось хороше у тому, що почало відбуватись. До хатини вдерлося троє незнайомців у масках.\r\n\r\nЖахи «Незнайомці: Частина перша» є продовженням франшизи «Незнайомці», перший фільм якої вийшов на екрани у 2008 році. Продовження презентували 2018 року. Новий фільм стане першим у трилогії, яку знімали одночасно. Передбачається, що сюжет розкриє історію появи людей у масках та покаже що стається з їхніми жертвами. Знімали у столиці Словаччини Братиславі наприкінці 2022 року.", (ushort)91, new DateTime(2024, 6, 6, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1742), (ushort)2024, "/movies/STRNGR1-vend.jpg", new DateTime(2024, 5, 30, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1742), "Незнайомці: Частина перша", "https://www.youtube.com/embed/dUe_Ac4V-R4?si=fxBrFFENDZKs2iPA" },
                    { 16, "Життя милої дівчинки Зузі (Ліліана Зайберт) докорінно змінюється, коли тато (Матеуш Дамецький) приводить з залізничної станції, де він працює, собаку. Песику дали ім’я Лампо та оточили турботою. Цей пес – справжній мандрівник і довго сидіти на місці він не любить. Куди б він не їхав, він зачаровує пасажирів та стає улюбленцем. Само тому мережею шириться безліч світлин з Лампо. Нажаль, є й ті, кому слава милого песика не до вподоби. Заздрісники хочуть назавжди позбавити Лампо дому та можливості подорожувати, а дівчинку Зузі розлучити з кращим другом.\r\n\r\nСімейний фільм «Лампо: Вірний пес» знято польською режисеркою Магдалиною Ніц. У основі сюжету – популярна у Польщі дитяча книга, яка входить до місцевої шкільної програми. Історію написав у 1967 році Роман Писарський, польський письменник, який народився у Івано-Франківську. Пес, про якого йдеться у дитячій історії, справді жив у 1950-х роках та без супроводу людей подорожував Європою на поїздах.", (ushort)120, new DateTime(2024, 6, 9, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1745), (ushort)2023, "/movies/lampo-vend.jpg", new DateTime(2024, 6, 2, 19, 21, 28, 798, DateTimeKind.Utc).AddTicks(1745), "Лампо: Вірний пес", "https://www.youtube.com/embed/iynOv10VcNU?si=YG_3DrY0TLYM4_Qv" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "18+" },
                    { 2, "16+" },
                    { 3, "12+" },
                    { 4, "0+" },
                    { 5, "VR" },
                    { 6, "Дивитись разом" },
                    { 7, "У темряві" },
                    { 8, "Для підлітків" },
                    { 9, "Фінансовий" }
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
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 2 },
                    { 8, 4 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 4 },
                    { 18, 4 },
                    { 19, 4 },
                    { 20, 4 },
                    { 21, 5 },
                    { 22, 5 },
                    { 23, 5 },
                    { 24, 5 },
                    { 25, 5 },
                    { 26, 5 },
                    { 27, 5 },
                    { 28, 5 },
                    { 29, 5 },
                    { 30, 6 },
                    { 31, 6 },
                    { 32, 6 },
                    { 33, 6 },
                    { 34, 6 },
                    { 35, 6 },
                    { 36, 6 },
                    { 37, 7 },
                    { 38, 7 },
                    { 39, 7 },
                    { 40, 7 },
                    { 41, 7 },
                    { 42, 8 },
                    { 43, 8 },
                    { 43, 12 },
                    { 44, 8 },
                    { 45, 8 },
                    { 46, 8 },
                    { 47, 8 },
                    { 48, 8 },
                    { 49, 8 },
                    { 50, 9 },
                    { 51, 9 },
                    { 52, 9 },
                    { 53, 10 },
                    { 54, 10 },
                    { 55, 10 },
                    { 56, 11 },
                    { 57, 11 },
                    { 58, 11 },
                    { 59, 12 },
                    { 60, 12 },
                    { 61, 12 },
                    { 62, 12 },
                    { 63, 12 },
                    { 64, 13 },
                    { 65, 13 },
                    { 66, 13 },
                    { 67, 13 },
                    { 68, 14 },
                    { 69, 14 },
                    { 70, 14 },
                    { 71, 14 },
                    { 72, 14 },
                    { 73, 14 },
                    { 74, 15 },
                    { 75, 15 },
                    { 76, 15 },
                    { 77, 15 },
                    { 78, 15 },
                    { 79, 16 },
                    { 80, 16 },
                    { 81, 16 },
                    { 82, 16 },
                    { 83, 16 }
                });

            migrationBuilder.InsertData(
                table: "DirectorEntityMovieEntity",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 9 },
                    { 11, 10 },
                    { 12, 11 },
                    { 13, 11 },
                    { 14, 12 },
                    { 15, 13 },
                    { 16, 14 },
                    { 17, 15 },
                    { 18, 16 }
                });

            migrationBuilder.InsertData(
                table: "GenreEntityMovieEntity",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 9 },
                    { 6, 11 },
                    { 6, 15 },
                    { 7, 4 },
                    { 7, 7 },
                    { 9, 7 },
                    { 9, 16 },
                    { 10, 5 },
                    { 10, 8 },
                    { 10, 10 },
                    { 10, 11 },
                    { 10, 12 },
                    { 10, 13 },
                    { 10, 14 },
                    { 11, 10 },
                    { 11, 13 },
                    { 12, 5 },
                    { 13, 3 },
                    { 14, 4 },
                    { 15, 6 },
                    { 16, 6 },
                    { 16, 8 },
                    { 17, 7 },
                    { 18, 8 },
                    { 19, 10 },
                    { 20, 11 },
                    { 21, 13 }
                });

            migrationBuilder.InsertData(
                table: "MovieEntityTagEntity",
                columns: new[] { "MoviesId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 2 },
                    { 7, 4 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 1 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 1 },
                    { 16, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "BasicPrice", "MovieId", "StartDate", "VipPrice" },
                values: new object[,]
                {
                    { 1, 162m, 1, new DateTime(2024, 5, 20, 18, 55, 28, 798, DateTimeKind.Utc).AddTicks(3047), 358m },
                    { 2, 123m, 2, new DateTime(2024, 5, 28, 17, 50, 28, 798, DateTimeKind.Utc).AddTicks(3090), 364m },
                    { 3, 170m, 1, new DateTime(2024, 5, 21, 17, 44, 28, 798, DateTimeKind.Utc).AddTicks(3149), 389m },
                    { 4, 142m, 1, new DateTime(2024, 5, 19, 3, 5, 28, 798, DateTimeKind.Utc).AddTicks(3177), 320m },
                    { 5, 167m, 2, new DateTime(2024, 6, 3, 20, 50, 28, 798, DateTimeKind.Utc).AddTicks(3206), 366m },
                    { 6, 185m, 2, new DateTime(2024, 5, 21, 10, 34, 28, 798, DateTimeKind.Utc).AddTicks(3235), 318m },
                    { 7, 195m, 1, new DateTime(2024, 5, 31, 16, 6, 28, 798, DateTimeKind.Utc).AddTicks(3265), 271m },
                    { 8, 178m, 1, new DateTime(2024, 5, 29, 6, 7, 28, 798, DateTimeKind.Utc).AddTicks(3293), 328m },
                    { 9, 167m, 1, new DateTime(2024, 5, 28, 3, 25, 28, 798, DateTimeKind.Utc).AddTicks(3323), 252m },
                    { 10, 170m, 2, new DateTime(2024, 5, 20, 3, 34, 28, 798, DateTimeKind.Utc).AddTicks(3352), 271m },
                    { 11, 149m, 2, new DateTime(2024, 5, 24, 4, 3, 28, 798, DateTimeKind.Utc).AddTicks(3381), 345m },
                    { 12, 145m, 2, new DateTime(2024, 5, 21, 2, 44, 28, 798, DateTimeKind.Utc).AddTicks(3408), 300m },
                    { 13, 133m, 2, new DateTime(2024, 5, 22, 14, 57, 28, 798, DateTimeKind.Utc).AddTicks(3463), 350m },
                    { 14, 113m, 2, new DateTime(2024, 5, 31, 15, 46, 28, 798, DateTimeKind.Utc).AddTicks(3491), 276m },
                    { 15, 161m, 2, new DateTime(2024, 5, 25, 19, 5, 28, 798, DateTimeKind.Utc).AddTicks(3520), 384m },
                    { 16, 117m, 1, new DateTime(2024, 5, 30, 11, 39, 28, 798, DateTimeKind.Utc).AddTicks(3547), 387m },
                    { 17, 126m, 2, new DateTime(2024, 5, 19, 14, 30, 28, 798, DateTimeKind.Utc).AddTicks(3576), 251m },
                    { 18, 164m, 1, new DateTime(2024, 5, 30, 0, 48, 28, 798, DateTimeKind.Utc).AddTicks(3604), 379m },
                    { 19, 114m, 2, new DateTime(2024, 6, 2, 18, 53, 28, 798, DateTimeKind.Utc).AddTicks(3633), 277m },
                    { 20, 155m, 1, new DateTime(2024, 6, 5, 21, 48, 28, 798, DateTimeKind.Utc).AddTicks(3660), 275m }
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
