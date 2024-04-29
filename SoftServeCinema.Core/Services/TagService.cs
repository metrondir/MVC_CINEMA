using AutoMapper;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.Entities;
using SoftServeCinema.Core.Entities.Specifications;
using SoftServeCinema.Core.Exceptions;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Services
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TagEntity> _tagRepository;

        public TagService(IMapper mapper,
                            IRepository<TagEntity> tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<List<TagDTO>> GetAllTagsAsync()
        {
            var result = await _tagRepository.GetAllAsync();
            return _mapper.Map<List<TagDTO>>(result);
        }

        public async Task<List<TagDTO>> GetTagsByIdsAsync(ICollection<int> tagIds)
        {
            var result = await _tagRepository.GetListBySpecAsync(new TagsSpecifications.GetByIds(tagIds));
            return _mapper.Map<List<TagDTO>>(result);
        }

        public async Task<TagDTO> GetTagByIdAsync(int tagId)
        {
            var tag = (await _tagRepository.GetByIdAsync(tagId)) ?? throw new EntityNotFoundException();
            return _mapper.Map<TagDTO>(tag);
        }

        public async Task<TagWithMoviesDTO> GetTagWithMoviesAsync(int tagId)
        {
            var tag = (await _tagRepository.GetFirstBySpecAsync(new TagsSpecifications.GetByIdWithMovies(tagId))) ?? throw new EntityNotFoundException();
            return _mapper.Map<TagWithMoviesDTO>(tag);
        }


        public async Task<bool> IsNameUniqueAsync(string name)
        {
            try
            {
                await _tagRepository.GetFirstBySpecAsync(new TagsSpecifications.GetByName(name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task<bool> IsNameUniqueWithoutIdAsync(int tagId, string name)
        {
            try
            {
                await _tagRepository.GetFirstBySpecAsync(new TagsSpecifications.GetByNameWithoutId(tagId, name));
                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }
        }

        public async Task CreateTagAsync(TagDTO tagDTO)
        {
            var tag = _mapper.Map<TagEntity>(tagDTO);
            await _tagRepository.InsertAsync(tag);
            await _tagRepository.SaveAsync();
        }

        public async Task UpdateTagAsync(TagDTO tagDTO)
        {
            var tag = _mapper.Map<TagEntity>(tagDTO);
            _tagRepository.Update(tag);
            await _tagRepository.SaveAsync();
        }

        public async Task DeleteTagAsync(int tagId)
        {
            _tagRepository.Delete(tagId);
            await _tagRepository.SaveAsync();
        }
    }
}
