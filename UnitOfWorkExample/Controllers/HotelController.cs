using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkExample.Data;
using UnitOfWorkExample.Model;
using UnitOfWorkExample.Repository;

namespace UnitOfWorkExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        [HttpPost]
        public IActionResult Post(HotelDto request)
        {
            var newHotel = new Hotel
            {
                Name = request.Name,
                Address = request.Address,
                Rating = request.Rating,
                CountryId = request.CountryId,
            };
            
            var result = _unitOfWork.Hotels.Add(newHotel);
            _unitOfWork.Complete();
            if (result is not null)
                return Ok("Hotel Created");
            else
                return BadRequest("Error in Creating the Hotel");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Hotels.GetAll());
    }
}
