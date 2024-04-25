using AutoMapper;
using SoftServeCinema.Core.DTOs.Genres;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GenreEntity> _genreRepository;

        public GenreService(IMapper mapper,
                            IRepository<GenreEntity> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var result = await _genreRepository.GetAllAsync();
            return _mapper.Map<List<GenreDTO>>(result);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int genreId)
        {
            var genre = (await _genreRepository.GetByIdAsync(genreId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<GenreWithMoviesDTO> GetGenreWithMoviesAsync(int genreId)
        {
            var genre = (await _genreRepository.GetFirstBySpecAsync(new GenresSpecifications.GetByIdWithMovies(genreId))) ?? throw new EntityNotFoundException();
            return _mapper.Map<GenreWithMoviesDTO>(genre);
        }


        public async Task<bool> IsNameUniqueAsync(string name)
        {
            try
            {
                await _genreRepository.GetFirstBySpecAsync(new GenresSpecifications.GetByName(name));
                return false;
            }
            catch (EntityNotFoundException) 
            {
                return true;
            }
        }

        public async Task<bool> IsNameUniqueWithoutIdAsync(int genreId, string name)
        {
            try
            {
                await _genreRepository.GetFirstBySpecAsync(new GenresSpecifications.GetByNameWithoutId(genreId, name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateGenreAsync(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<GenreEntity>(genreDTO);
            await _genreRepository.InsertAsync(genre);
        }

        public async Task UpdateGenreAsync(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<GenreEntity>(genreDTO);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            await _genreRepository.DeleteAsync(genreId);
        }
    }
}
