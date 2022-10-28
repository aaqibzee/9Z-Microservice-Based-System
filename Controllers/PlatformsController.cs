using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

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

        [HttpGet]
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
    }
}