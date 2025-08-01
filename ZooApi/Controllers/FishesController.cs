using AutoMapper;
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
        private readonly IMapper _mapper;
        public FishesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fishes = await _unitOfWork.Fishes.GetAllAsync();
            return Ok(fishes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fish = await _unitOfWork.Fishes.GetByIdAsync(id);
            if (fish is null) return NotFound();
            var result = _mapper.Map<FishDto>(fish);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FishDto fish)
        {
            var addFish = _mapper.Map<Fish>(fish);
            await _unitOfWork.Fishes.AddAsync(addFish);
            await _unitOfWork.CompleteAsync();
            return Ok(addFish);
        }
    }
}
