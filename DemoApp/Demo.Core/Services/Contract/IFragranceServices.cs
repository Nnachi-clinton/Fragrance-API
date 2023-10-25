using Demo.Domain.Dto;
using Demo.Domain.Model;

namespace Demo.Core.Services.Contract
{
    public interface IFragranceServices
    {
        Task <string> AddFragranceAsync(AddFragranceDto addFragranceDto);
        Task <Fragrance> GetFragranceByIdAsync(string userId);
        Task <string> DeleteFragranceByIdAsync(string userId);
        Task <string> UpdateFragranceByIdAsync(string userId, AddFragranceDto fragranceDto);
        Task <List<Fragrance>> GetAllFragranceAsync();
    }
}
