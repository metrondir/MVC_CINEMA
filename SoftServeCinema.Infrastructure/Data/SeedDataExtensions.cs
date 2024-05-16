using Microsoft.EntityFrameworkCore;
using SoftServeCinema.Core.Entities;

namespace SoftServeCinema.Infrastructure.Data
{
    public static class SeedDataExtensions
    {
        public static void SeedMoviesWithRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntity>().HasData(new MovieEntity[]
            {
                new MovieEntity()
                {
                    Id = 1,
                    ImagePath = "/movies/sw-vend.jpg",
                    TrailerUrl = @"https://www.youtube.com/embed/my8iHV3dpNI?si=88h7TyNtTLoGIupq",
                    Title = "Повстання Штатів",
                    Desc = "Події розгортаються у найближчому майбутньому. Сполученими штатами котиться нищівна та всеохоплююча громадянська війна. Почалося із бажання кількох південних штатів відділитися і тепер уся країна охоплена бойовими діями. Група журналістів, серед яких відома репортерка (Кірстен Данст), яка і раніше часто знімала збройні конфлікти, рухаються у напрямку Вашингтона. Стає очевидним, що керівництво країни перетворилося на диктатуру, а повстанські угрупування повсюдно чинять воєнні злочини.",
                    GraduationYear = 2024,
                    Duration = 108,
                    StartRentalDate =  DateTime.UtcNow.AddDays(-1),
                    EndRentalDate = DateTime.UtcNow.AddDays(30)
                },
                new MovieEntity()
                {
                    Id = 2,
                    ImagePath = "/movies/fall_guy-vend.jpg",
                    TrailerUrl = @"https://www.youtube.com/embed/Xmi7ZsHL6Jg?si=v2CGyMa6CcT2KUUY",
                    Title = "Каскадер",
                    Desc = "Джоді Морено (Емілі Блант) знімає свій перший фільм у якості режисера. Вона дуже старається та хвилюється. Добре, що на знімальному майданчику завжди є кому її підбадьорити. Кольт (Раян Ґослінґ) – каскадер. Колись вони зустрічалися з Джоді, а нині просто працюють разом та підтримують одне одного. Кольт дублює актора, який грає головну роль. Якось цей актор безслідно зникає. Ніхто не може знайти його, а це означає, що Джоді не зможе дознімати свій дебютний проект і це зруйнує її кар’єру. Кольт дуже не хоче, щоб так сталося, тож погоджується стати на деякий час детективом та розшукати актора, який невідомо куди подівся.",
                    GraduationYear = 2024,
                    Duration = 126,
                    StartRentalDate = DateTime.UtcNow.AddDays(5),
                    EndRentalDate = DateTime.UtcNow.AddDays(50)
                }
            });

            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity[]
            {
                new GenreEntity()
                {
                    Id = 1,
                    Name = "епічний"
                },
                new GenreEntity()
                {
                    Id = 2,
                    Name = "екшн"
                },
                new GenreEntity()
                {
                    Id = 3,
                    Name = "антиутопія"
                },
                new GenreEntity()
                {
                    Id = 4,
                    Name = "комедія"
                },
                new GenreEntity()
                {
                    Id = 5,
                    Name = "трилер"
                },
                new GenreEntity()
                {
                    Id = 6,
                    Name = "жахи"
                },
                new GenreEntity()
                {
                    Id = 7,
                    Name = "пригоди"
                },
                new GenreEntity()
                {
                    Id = 8,
                    Name = "аніме"
                },
                new GenreEntity()
                {
                    Id = 9,
                    Name = "сімейний"
                },
                new GenreEntity()
                {
                    Id = 10,
                    Name = "драма"
                },
                new GenreEntity()
                {
                    Id = 11,
                    Name = "спорт"
                },
                new GenreEntity()
                {
                    Id = 12,
                    Name = "документальний"
                }
            });

            modelBuilder.Entity("GenreEntityMovieEntity").HasData(
                new { GenresId = 1, MoviesId = 1 },
                new { GenresId = 2, MoviesId = 1 },
                new { GenresId = 3, MoviesId = 1 },
                new { GenresId = 2, MoviesId = 2 },
                new { GenresId = 4, MoviesId = 2 }
            );

            modelBuilder.Entity<ActorEntity>().HasData(new ActorEntity[]
            {
                new ActorEntity()
                {
                    Id = 1,
                    Name = "Кірстен Данст"
                },
                new ActorEntity()
                {
                    Id = 2,
                    Name = "Джессі Племенс"
                },
                new ActorEntity()
                {
                    Id = 3,
                    Name = "Кейлі Спені"
                },
                new ActorEntity()
                {
                    Id = 4,
                    Name = "Соноя Мідзуно"
                },
                new ActorEntity()
                {
                    Id = 5,
                    Name = "Раян Ґослінґ"
                },
                new ActorEntity()
                {
                    Id = 6,
                    Name = "Емілі Блант"
                },
                new ActorEntity()
                {
                    Id = 7,
                    Name = "Аарон Тейлор-Джонсон"
                }
            });

            modelBuilder.Entity("ActorEntityMovieEntity").HasData(
                new { ActorsId = 1, MoviesId = 1 },
                new { ActorsId = 2, MoviesId = 1 },
                new { ActorsId = 3, MoviesId = 1 },
                new { ActorsId = 4, MoviesId = 1 },
                new { ActorsId = 5, MoviesId = 2 },
                new { ActorsId = 6, MoviesId = 2 },
                new { ActorsId = 7, MoviesId = 2 }
            );

            modelBuilder.Entity<DirectorEntity>().HasData(new DirectorEntity[]
            {
                new DirectorEntity()
                {
                    Id = 1,
                    Name = "Алекс Ґарленд"
                },
                new DirectorEntity()
                {
                    Id = 2,
                    Name = "Девід Літч"
                },
            });

            modelBuilder.Entity("DirectorEntityMovieEntity").HasData(
                new { DirectorsId = 1, MoviesId = 1 },
                new { DirectorsId = 2, MoviesId = 2 }
            );

            modelBuilder.Entity<TagEntity>().HasData(new TagEntity[]
            {
                new TagEntity()
                {
                    Id = 1,
                    Name = "18+"
                },
                new TagEntity()
                {
                    Id = 2,
                    Name = "12+"
                },
            });

            modelBuilder.Entity("MovieEntityTagEntity").HasData(
                new { MoviesId = 1, TagsId = 1 },
                new { MoviesId = 2, TagsId = 2 }
            );
            modelBuilder.Entity<SessionEntity>().HasData(new SessionEntity[]
           {
                new SessionEntity()
                {
                    Id = 1,
                    MovieId = 1,
                    StartDate =  DateTime.UtcNow.AddDays(1),
                    BasicPrice = 200,
                    VipPrice = 350,

                }

                
           });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity[]
         {
                new UserEntity()
                {
                    Id = Guid.Parse("551b099b-91de-48ab-bb52-518a67f35e5b") ,
                    FirstName="Roman",
                    LastName="Koval",
                    Email="romanmedvedev0201@gmail.com",
                    RoleName = "User"
                },
         });

            for (int i = 1 , countId=1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    modelBuilder.Entity<TicketEntity>().HasData(new TicketEntity[]
                    {
                        new TicketEntity()
                        {
                    
                            Id = countId++,
                            SessionId = 1,
                            RowNumber = i,
                            SeatNumber = j,
                            Status ="Available" ,

                        },

                     });
                }
              
            }
         }

    }
}
