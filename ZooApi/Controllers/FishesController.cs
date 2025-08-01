using Microsoft.AspNetCore.Mvc;
using ZooApi.DTOs;
using ZooApi.Entities;
using ZooApi.Interfaces;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FishesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fishes = await _unitOfWork.Fishes.GetAllAsync();
            return Ok(fishes);
        }

        [HttpPost]
        public async Task<IActionResult> AddBird([FromBody] FishDto fish)
        {
            await _unitOfWork.Fishes.AddAsync(new Fish { Name = fish.Name, Description = fish.Description, PhotoUrl = fish.PhotoUrl });
            await _unitOfWork.CompleteAsync();
            return Ok(fish);
        }
    }
}
