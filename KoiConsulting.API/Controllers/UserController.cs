using Microsoft.AspNetCore.Mvc;
using KoiConsulting.Repository;
using KoiConsulting.Repository.Models;
using System.Data.Entity.Infrastructure;

namespace KoiConsulting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public UsersController(UnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetProducts()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754    
        [HttpPost]
        public async Task<ActionResult<User>> PostProduct(User user)
        {
            try
            {
                await _unitOfWork.UserRepository.CreateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return CreatedAtAction("GetProduct", new { id = user.Id }, user);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, user user)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _unitOfWork.ProductRepository.UpdateAsync(product);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    await _unitOfWork.ProductRepository.RemoveAsync(product);

        //    return NoContent();
        //}

        //private bool ProductExists(int id)
        //{
        //    return _unitOfWork.ProductRepository.GetByIdAsync(id) != null;
        //}
    }
}
