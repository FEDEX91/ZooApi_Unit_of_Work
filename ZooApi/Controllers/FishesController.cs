using Microsoft.AspNetCore.Mvc;
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
    }
}
