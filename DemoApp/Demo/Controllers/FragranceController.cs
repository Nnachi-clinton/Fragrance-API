using Demo.Core.Services.Contract;
using Demo.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FragranceController : ControllerBase
    {
        private readonly IFragranceServices _fragranceServices;

        public FragranceController(IFragranceServices fragranceServices)
        {
            _fragranceServices = fragranceServices;
        }

        [HttpPost]
        public async Task <IActionResult> AddFragrance(AddFragranceDto addFragranceDto)
        {
           var result = await _fragranceServices.AddFragranceAsync(addFragranceDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFragrance(string Id)
        {
            var result = await _fragranceServices.GetFragranceByIdAsync(Id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFragrance(string Id)
        {
            await _fragranceServices.DeleteFragranceByIdAsync(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFragrance(string Id, AddFragranceDto updateFragranceDto)
        {
            var result = await _fragranceServices.UpdateFragranceByIdAsync(Id, updateFragranceDto);
            return Ok(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllFragrance()
        {
            var result =  await _fragranceServices.GetAllFragranceAsync();        
            return Ok(result);

        }
    }
}
