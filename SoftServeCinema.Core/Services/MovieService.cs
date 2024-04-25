using AutoMapper;
using SoftServeCinema.Core.DTOs.Movies;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MovieEntity> _movieRepository;

        public MovieService(IMapper mapper,
                            IRepository<MovieEntity> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieFullDTO> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            return _mapper.Map<MovieFullDTO>(movie);
        }

        public async Task<List<MovieDTO>> GetActualsAsync()
        {
            var result = await _movieRepository.GetListBySpecAsync(new MoviesSpecifications.GetActuals());
            return _mapper.Map<List<MovieDTO>>(result);
        }

        public async Task CreateMovieAsync(MovieFullDTO movieFullDTO)
        {
            var movie = _mapper.Map<MovieEntity>(movieFullDTO);
            await _movieRepository.InsertAsync(movie);
        }

        public async Task UpdateMovieAsync(MovieFullDTO movieFullDTO)
        {
            var movie = _mapper.Map<MovieEntity>(movieFullDTO);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            await _movieRepository.DeleteAsync(movieId);
        }
    }
}
