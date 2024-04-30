using AutoMapper;
using SoftServeCinema.Core.DTOs.Movies;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MovieEntity> _movieRepository;
        private readonly IRepository<GenreEntity> _genreRepository;
        private readonly IRepository<TagEntity> _tagRepository;
        private readonly IRepository<DirectorEntity> _directorRepository;
        private readonly IRepository<ActorEntity> _actorRepository;

        public MovieService(
            IMapper mapper,
            IRepository<MovieEntity> movieRepository,
            IRepository<GenreEntity> genreRepository,
            IRepository<TagEntity> tagRepository,
            IRepository<DirectorEntity> directorRepository,
            IRepository<ActorEntity> actorRepository
            )
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _tagRepository = tagRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
        }

        public async Task<MovieFullDTO> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            return _mapper.Map<MovieFullDTO>(movie);
        }

        public async Task<MovieFullDTO> GetFullMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetFirstBySpecAsync(new MoviesSpecifications.GetByIdWithRel(movieId));
            return _mapper.Map<MovieFullDTO>(movie);
        }

        public async Task<MovieFormDTO> GetMovieFormByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetFirstBySpecAsync(new MoviesSpecifications.GetByIdForForm(movieId));
            return _mapper.Map<MovieFormDTO>(movie);
        }

        public async Task<List<MovieDTO>> GetActualsAsync()
        {
            var result = await _movieRepository.GetListBySpecAsync(new MoviesSpecifications.GetActuals());
            return _mapper.Map<List<MovieDTO>>(result);
        }

        public async Task<List<MovieDTO>> GetExpectedAsync()
        {
            var result = await _movieRepository.GetListBySpecAsync(new MoviesSpecifications.GetExpected());
            return _mapper.Map<List<MovieDTO>>(result);
        }

        public async Task<List<MovieDTO>> GetAllMoviesAsync()
        {
            var result = await _movieRepository.GetAllAsync();
            return _mapper.Map<List<MovieDTO>>(result);
        }

        public async Task<bool> IsTitleUniqueAsync(string title)
        {
            try
            {
                await _movieRepository.GetFirstBySpecAsync(new MoviesSpecifications.GetByTitle(title));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task<bool> IsTitleUniqueWithoutIdAsync(int movieId, string title)
        {
            try
            {
                await _movieRepository.GetFirstBySpecAsync(new MoviesSpecifications.GetByTitleWithoutId(movieId, title));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateMovieAsync(MovieFormDTO movieFormDTO, string imagePath)
        {
            var movie = _mapper.Map<MovieEntity>(movieFormDTO);
            movie.ImagePath = imagePath;
            movie.Genres = (ICollection<GenreEntity>)await _genreRepository.GetListBySpecAsync(new GenresSpecifications.GetByIds(movieFormDTO.SelectedGenres));
            movie.Tags = (ICollection<TagEntity>)await _tagRepository.GetListBySpecAsync(new TagsSpecifications.GetByIds(movieFormDTO.SelectedTags));
            movie.Directors = (ICollection<DirectorEntity>)await _directorRepository.GetListBySpecAsync(new DirectorsSpecifications.GetByIds(movieFormDTO.SelectedDirectors));
            movie.Actors = (ICollection<ActorEntity>)await _actorRepository.GetListBySpecAsync(new ActorsSpecifications.GetByIds(movieFormDTO.SelectedActors));

            await _movieRepository.InsertAsync(movie);
            
            foreach (var genre in movie.Genres)
            {
                _genreRepository.Attach(genre);
            }
            foreach (var tag in movie.Tags)
            {
                _tagRepository.Attach(tag);
            }
            foreach (var director in movie.Directors)
            {
                _directorRepository.Attach(director);
            }
            foreach (var actor in movie.Actors)
            {
                _actorRepository.Attach(actor);
            }

            await _movieRepository.SaveAsync();
        }

        public async Task UpdateMovieAsync(MovieFormDTO movieFormDTO, string? imagePath)
        {
            await ClearMovieBaseRelations(movieFormDTO.Id);

            var movie = _mapper.Map<MovieEntity>(movieFormDTO);
            if (imagePath != null)
            {
                movie.ImagePath = imagePath;
            }
            else
            {
                movie.ImagePath = (await GetMovieByIdAsync(movie.Id)).ImagePath;
                _movieRepository.CrearTracker();
            }
            movie.Genres = (ICollection<GenreEntity>)await _genreRepository.GetListBySpecAsync(new GenresSpecifications.GetByIds(movieFormDTO.SelectedGenres));
            movie.Tags = (ICollection<TagEntity>)await _tagRepository.GetListBySpecAsync(new TagsSpecifications.GetByIds(movieFormDTO.SelectedTags));
            movie.Directors = (ICollection<DirectorEntity>)await _directorRepository.GetListBySpecAsync(new DirectorsSpecifications.GetByIds(movieFormDTO.SelectedDirectors));
            movie.Actors = (ICollection<ActorEntity>)await _actorRepository.GetListBySpecAsync(new ActorsSpecifications.GetByIds(movieFormDTO.SelectedActors));

            foreach (var genre in movie.Genres)
            {
                _genreRepository.Update(genre);
            }
            foreach (var tag in movie.Tags)
            {
                _tagRepository.Update(tag);
            }
            foreach (var director in movie.Directors)
            {
                _directorRepository.Update(director);
            }
            foreach (var actor in movie.Actors)
            {
                _actorRepository.Update(actor);
            }

            _movieRepository.Update(movie);
            await _movieRepository.SaveAsync();
        }

        public async Task ClearMovieBaseRelations(int movieId)
        {
            var movie = await _movieRepository.GetFirstBySpecAsync(new MoviesSpecifications.GetByIdWithRel(movieId));
            movie.Genres.Clear();
            movie.Tags.Clear();
            movie.Directors.Clear();
            movie.Actors.Clear();
            _movieRepository.Update(movie);
            await _movieRepository.SaveAsync();
            _movieRepository.CrearTracker();
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            _movieRepository.Delete(movieId);
            await _movieRepository.SaveAsync();
        }
    }
}
