using Microsoft.AspNetCore.Mvc;
using CommandsService.Data;
using AutoMapper;
using System.Collections.Generic;
using CommandsService.Dtos;

namespace CommandsService
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
             _mapper = mapper;
        }


      [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from Command Service");
            var platformItems = _repository.GetAllPlatforms();
            Console.WriteLine("--> After getting Platforms from Command Service");

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }


        
        //http://acme.com/api/c/platforms/
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test of from Platforms Controller" );
        }

    }
}