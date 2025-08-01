using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZooApi.DTOs;
using ZooApi.Interfaces;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirdsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BirdsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var birds = await _unitOfWork.Birds.GetAllAsync();
            return Ok(birds);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bird = await _unitOfWork.Birds.GetByIdAsync(id);
            if (bird is null) return NotFound($"{id} not found.");
            var result = _mapper.Map<BirdDto>(bird);
            return Ok(result);
        }
    }
}
