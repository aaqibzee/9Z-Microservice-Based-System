using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            Console.WriteLine("Getting Platforms...");
            var platforms = _repository.GetAllPlatforms();
            if (platforms == null)
            {
                return Ok();
            }

            var mappedResult = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return Ok(mappedResult);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<PlatformReadDto>> Get(int id)
        {
            Console.WriteLine("Getting Platform...");
            var platform = _repository.GetPlatform(id);
            if (platform == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<PlatformReadDto>(platform);
            return Ok(mappedResult);
        }

        [HttpPost(Name = "Create")]
        public ActionResult Create(PlatformCreateDto request)
        {
            Console.WriteLine("Creating Platform...");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (request == null)
            {
                return BadRequest();
            }

            var mappedRequet = _mapper.Map<Platform>(request);
            var created = _repository.CreatePlatform(mappedRequet);

            if (created)
            {
                var resource = _mapper.Map<PlatformReadDto>(mappedRequet);
                return Created(nameof(Get), resource);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}