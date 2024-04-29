using SoftServeCinema.Core.DTOs.Tags;

namespace SoftServeCinema.Core.Interfaces.Services
{
    public interface ITagService
    {
        Task<List<TagDTO>> GetAllTagsAsync();
        Task<List<TagDTO>> GetTagsByIdsAsync(ICollection<int> tagIds);
        Task<TagDTO> GetTagByIdAsync(int tagId);
        Task<TagWithMoviesDTO> GetTagWithMoviesAsync(int tagId);
        Task<bool> IsNameUniqueAsync(string name);
        Task<bool> IsNameUniqueWithoutIdAsync(int tagId, string name);
        Task CreateTagAsync(TagDTO tagDTO);
        Task UpdateTagAsync(TagDTO tagDTO);
        Task DeleteTagAsync(int tagId);
    }
}
