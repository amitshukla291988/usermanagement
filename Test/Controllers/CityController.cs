using GG.Data;
using GG.Dtos;
using GG.Helper;
using GG.Interface;
using GG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;
        private readonly ICityRepository repo;
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow) {
            /*this.dc = dc;
            this.repo = repo;*/
            this.uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            //var cities = await dc.Cities.ToListAsync();
            var cities = await uow.CityRepository.GetCitiesAsync();
            var citiesDto = from c in cities
                            select new CityDto()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Country = c.Country,
                            };

            return Ok(new BaseResponse<object>(true,"City List ", citiesDto));
           // return new string[] { "Noida", "Delhi" };
        }

       // [HttpPost("add")]
        [HttpPost("add/{cityName}")]
        public async Task<IActionResult> AddCity(String cityName)
        {
            if (cityName ==null)
            {
                return BadRequest(new BaseResponse<object>(false, "Add City",null));
            }
            City city = new City();
            city.Name = cityName;
            /*await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();*/
           uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return Ok(city);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {



            var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now,
                Country = cityDto.Country
            };
            /* await dc.Cities.AddAsync(city);
             await dc.SaveChangesAsync();  */
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return Ok(new BaseResponse<object>(true, "Successfully Add City ",cityDto));
           // return StatusCode(201);
            //return Ok(city);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            /*var city = await dc.Cities.FindAsync(id);
            dc.Cities.Remove(city);
            await dc.SaveChangesAsync();*/
            uow.CityRepository.DetachCity(id);
            return Ok(id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id,CityDto cityDto)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            cityFromDb.Country = cityDto.Country;
            cityFromDb.Name = cityDto.Name;
            //uow.CityRepository.UpdateCity(cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpGet("{id}")]
        public string Get(int id) {
            return "Noida";
        }
    }
}
