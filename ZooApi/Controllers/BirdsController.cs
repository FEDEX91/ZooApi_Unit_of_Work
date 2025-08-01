using Microsoft.AspNetCore.Mvc;
using ZooApi.Interfaces;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirdsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BirdsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var birds = await _unitOfWork.Birds.GetAllAsync();
            return Ok(birds);
        }
    }
}
