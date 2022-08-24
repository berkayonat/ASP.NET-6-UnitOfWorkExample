using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Data;
using UnitOfWorkExample.Repository;

namespace UnitOfWorkExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(CountryDto request)
        {
            var newCountry = new Country
            {
                Name = request.Name,
            };
            var result = _unitOfWork.Countries.Add(newCountry);
            _unitOfWork.Complete();
            if (result is not null) 
                return Ok("Country Created");
            else 
                return BadRequest("Error in Creating the Country");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Countries.GetAll());
        
    }
}
