using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarShop.Models;
using CarShop.Data;


namespace CarShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarRentController : ControllerBase
    {
        private readonly ApiContext _context;

        public CarRentController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(CarRent rent)
        {
            if(rent.Id == 0)
            {
                _context.Rents.Add(rent);

            }else
            {
                var rentInDb = _context.Rents.Find(rent.Id);

                if (rentInDb == null)
                    return new JsonResult(NotFound());

                rentInDb = rent;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(rent));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Rents.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Rents.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Rents.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Rents.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
