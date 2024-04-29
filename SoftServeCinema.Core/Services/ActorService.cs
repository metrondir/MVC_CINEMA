using AutoMapper;
using SoftServeCinema.Core.DTOs.Actors;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ActorEntity> _actorRepository;

        public ActorService(IMapper mapper,
                            IRepository<ActorEntity> actorRepository)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }

        public async Task<List<ActorDTO>> GetAllActorsAsync()
        {
            var result = await _actorRepository.GetAllAsync();
            return _mapper.Map<List<ActorDTO>>(result);
        }

        public async Task<List<ActorDTO>> GetActorsByIdsAsync(ICollection<int> actorIds)
        {
            var result = await _actorRepository.GetListBySpecAsync(new ActorsSpecifications.GetByIds(actorIds));
            return _mapper.Map<List<ActorDTO>>(result);
        }

        public async Task<ActorDTO> GetActorByIdAsync(int actorId)
        {
            var actor = (await _actorRepository.GetByIdAsync(actorId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<ActorDTO>(actor);
        }

        public async Task<ActorWithMoviesDTO> GetActorWithMoviesAsync(int actorId)
        {
            var actor = (await _actorRepository.GetFirstBySpecAsync(new ActorsSpecifications.GetByIdWithMovies(actorId))) ?? throw new EntityNotFoundException();
            return _mapper.Map<ActorWithMoviesDTO>(actor);
        }


        public async Task<bool> IsNameUniqueAsync(string name)
        {
            try
            {
                await _actorRepository.GetFirstBySpecAsync(new ActorsSpecifications.GetByName(name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task<bool> IsNameUniqueWithoutIdAsync(int actorId, string name)
        {
            try
            {
                await _actorRepository.GetFirstBySpecAsync(new ActorsSpecifications.GetByNameWithoutId(actorId, name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateActorAsync(ActorDTO actorDTO)
        {
            var actor = _mapper.Map<ActorEntity>(actorDTO);
            await _actorRepository.InsertAsync(actor);
            await _actorRepository.SaveAsync();
        }

        public async Task UpdateActorAsync(ActorDTO actorDTO)
        {
            var actor = _mapper.Map<ActorEntity>(actorDTO);
            _actorRepository.Update(actor);
            await _actorRepository.SaveAsync();
        }

        public async Task DeleteActorAsync(int actorId)
        {
            _actorRepository.Delete(actorId);
            await _actorRepository.SaveAsync();
        }
    }
}
