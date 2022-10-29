using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CommandService.Data;
using commandService.Dtos;
using commandService.Models;
using Microsoft.AspNetCore.Http;

namespace CommandService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            Console.WriteLine("Getting Commands...");
            var Commands = _repository.GetAllCommands();
            if (Commands == null)
            {
                return Ok();
            }

            var mappedResult = _mapper.Map<IEnumerable<CommandReadDto>>(Commands);
            return Ok(mappedResult);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<CommandReadDto>> Get(int id)
        {
            Console.WriteLine("Getting Command...");
            var Command = _repository.GetCommand(id);
            if (Command == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<CommandReadDto>(Command);
            return Ok(mappedResult);
        }

        [HttpPost(Name = "Create")]
        public ActionResult Create(CommandCreateDto request)
        {
            Console.WriteLine("Creating Command...");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (request == null)
            {
                return BadRequest();
            }

            var mappedRequet = _mapper.Map<Command>(request);
            var created = _repository.CreateCommand(mappedRequet);

            if (created)
            {
                var resource = _mapper.Map<CommandReadDto>(mappedRequet);
                return Created(nameof(Get), resource);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}