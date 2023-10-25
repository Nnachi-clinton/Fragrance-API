using Demo.Core.Services.Contract;
using Demo.Domain.Dto;
using Demo.Domain.Model;
using Demo.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.Services.Implementation
{
    public class FragranceServices : IFragranceServices
    {
        private readonly MyDbContext _dbContext;

        public FragranceServices(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddFragranceAsync(AddFragranceDto addFragranceDto)
        {
            try
            {
                var fragrance = new Fragrance()
                {
                    Name = addFragranceDto.Name,
                    Id = Guid.NewGuid().ToString(),
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Preference = addFragranceDto.Preference,
                    Intensity = addFragranceDto.Intensity,
                    Brand = addFragranceDto.Brand,
                    Price = addFragranceDto.Price,
                    Type = addFragranceDto.Type,

                };
                await _dbContext.Fragrances.AddAsync(fragrance);
                await _dbContext.SaveChangesAsync();
                return $"{addFragranceDto.Name} Order placed successfully";
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);

            }


            
        }

        public async Task<string> DeleteFragranceByIdAsync(string userId)
        {
            try
            {
                var result = await _dbContext.Fragrances.FirstOrDefaultAsync(x => x.Id == userId);
                if (result == null)
                {
                    return $"{userId} not found";
                }
                _dbContext.Fragrances.Remove(result);
                await _dbContext.SaveChangesAsync();
                return $"{userId} deleted successfully";
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<Fragrance>> GetAllFragranceAsync()
        {
            try
            {
                return await _dbContext.Fragrances.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }           
        }

        public async Task<Fragrance> GetFragranceByIdAsync(string userId)
        {
            try
            {
                var fragrance = await _dbContext.Fragrances.FirstOrDefaultAsync(x => x.Id == userId);
                return fragrance ?? throw new InvalidOperationException("user not found");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateFragranceByIdAsync(string userId, AddFragranceDto fragranceDto)
        {
            try
            {
                var fragrance = await _dbContext.Fragrances.FirstOrDefaultAsync(x => x.Id == userId);
                if (fragrance == null)
                {
                    return $"{userId} does not exist";
                }

                fragrance.Name = fragranceDto.Name;
                fragrance.Brand = fragranceDto.Brand;
                fragrance.UpdatedAt = DateTime.UtcNow;
                fragrance.Price = fragranceDto.Price;
                fragrance.Preference = fragranceDto.Preference;
                fragrance.Intensity = fragranceDto.Intensity;
                fragrance.Type = fragranceDto.Type;
                

                _dbContext.Fragrances.Update(fragrance);
                await _dbContext.SaveChangesAsync();
                return "Fragrance updated successfully";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
