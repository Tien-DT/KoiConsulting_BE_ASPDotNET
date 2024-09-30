using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP.KoiConsulting.API.RequestModel;
using SWP.KoiConsulting.API.ResponseModel;
using SWP.KoiConsulting.Repository;
using SWP.KoiConsulting.Repository.Models;
using SWP.KoiConsulting.Service.BusinessModels;
using SWP.KoiConsulting.Service.Services;

namespace SWP.KoiConsulting.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //API login 
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid login request");

            var user = await _userService.LoginAsync(loginModel.Email, loginModel.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            return Ok(user);
        }

        //API registration
        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult> Registraion(UserRequestModel request)
        {
            var userModel = new UserModel
            {
                FullName = request.FullName,
                Email = request.Email,
                Yob = request.Yob,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender
            };

            var rs = await _userService.InsertUserAsync(userModel);
            userModel.Id = rs;
            return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, userModel);
        }


        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            var respone = users.Select(user => new UserResponseModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Yob = user.Yob,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                Gender = user.Gender,
                Role = user.Role
            });

            return Ok(respone);
        }

        [HttpGet]
        [Route("User/{id}")]
        public async Task<ActionResult<UserResponseModel>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if(user == null) return NotFound();

            var respone = new UserResponseModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Yob = user.Yob,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                Gender = user.Gender,
                Role = user.Role
            };

            return Ok(respone); 
        }
        
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id,  UserRequestModel request)
        {
            var userModel = new UserModel
            {
                FullName = request.FullName,
                Email = request.Email,
                Yob = request.Yob,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
            };

            var success = await _userService.UpdateUserAsync(id, userModel);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if(!success) return NotFound();

            return NoContent();
        }

        

    }
}
