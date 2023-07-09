using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
   // [Route("api/platforms")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(
            IPlatformRepo platformRepo,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _repository = platformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [Route("GetPlatforms")]
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> GetPlatforms...");
            
            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        // if name is not passed on only use id, if name is not null then use id and name to find the platform
        //http://localhost:5157/api/Platforms/1    
        //http://localhost:5157/api/Platforms/1?name=dotnet    
        [HttpGet("{id}", Name = "GetPlatformById")]        
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {            
            var name = HttpContext.Request.Query["name"].ToString();
           
            Platform platformItem;

            if (string.IsNullOrEmpty(name))
            {
                platformItem = _repository.GetPlatformById(id);
            }
            else
            {
                platformItem = _repository.GetPlatformByIdAndName(id, name);
            }

            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();            
        }

        
         [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformDto)
        {
            var platformModel = _mapper.Map<Platform>(platformDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id}, platformReadDto );
        }

        // write api to DeletePlatformByID
        [HttpDelete("{Id}")]
        public ActionResult<PlatformReadDto> DeletePlatformByID(int Id)
        {
            var platformItem = _repository.GetPlatformById(Id);
            if(platformItem != null)
            {
                _repository.DeletePlatform(platformItem);
                _repository.SaveChanges();
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        public ActionResult<PlatformReadDto> UpdatePlatform(int id, PlatformUpdateDto platformUpdateDto)
        {
            var platformItem = _repository.GetPlatformById(id);
            platformUpdateDto.Id = id;
            if(platformItem == null)
            {
                return NotFound();
            }

            _mapper.Map(platformUpdateDto, platformItem);
            _repository.UpdatePlatform(platformItem);
            _repository.SaveChanges();

             return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformUpdateDto.Id}, platformUpdateDto );
        }

        int CalculateDaysBetweenDates(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract(start);
            return (int)span.TotalDays;
        }    

    }
}