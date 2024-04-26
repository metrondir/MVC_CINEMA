using AutoMapper;
using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DirectorEntity> _directorRepository;

        public DirectorService(IMapper mapper,
                            IRepository<DirectorEntity> directorRepository)
        {
            _mapper = mapper;
            _directorRepository = directorRepository;
        }

        public async Task<List<DirectorDTO>> GetAllDirectorsAsync()
        {
            var result = await _directorRepository.GetAllAsync();
            return _mapper.Map<List<DirectorDTO>>(result);
        }

        public async Task<DirectorDTO> GetDirectorByIdAsync(int directorId)
        {
            var director = (await _directorRepository.GetByIdAsync(directorId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<DirectorDTO>(director);
        }

        public async Task<DirectorWithMoviesDTO> GetDirectorWithMoviesAsync(int directorId)
        {
            var director = (await _directorRepository.GetFirstBySpecAsync(new DirectorsSpecifications.GetByIdWithMovies(directorId))) ?? throw new EntityNotFoundException();
            return _mapper.Map<DirectorWithMoviesDTO>(director);
        }


        public async Task<bool> IsNameUniqueAsync(string name)
        {
            try
            {
                await _directorRepository.GetFirstBySpecAsync(new DirectorsSpecifications.GetByName(name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task<bool> IsNameUniqueWithoutIdAsync(int directorId, string name)
        {
            try
            {
                await _directorRepository.GetFirstBySpecAsync(new DirectorsSpecifications.GetByNameWithoutId(directorId, name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateDirectorAsync(DirectorDTO directorDTO)
        {
            var director = _mapper.Map<DirectorEntity>(directorDTO);
            await _directorRepository.InsertAsync(director);
        }

        public async Task UpdateDirectorAsync(DirectorDTO directorDTO)
        {
            var director = _mapper.Map<DirectorEntity>(directorDTO);
            await _directorRepository.UpdateAsync(director);
        }

        public async Task DeleteDirectorAsync(int directorId)
        {
            await _directorRepository.DeleteAsync(directorId);
        }
    }
}
