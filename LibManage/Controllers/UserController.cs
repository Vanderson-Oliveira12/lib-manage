using LibManage.DTOs.User;
using LibManage.Extensions;
using LibManage.Models;
using LibManage.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace LibManage.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ResponseUserDTO>>>> GetAll()
        {

            var response = await _userService.GetAllUsersAsync();

            if ( response.IsSucceeded )
            {
                return Ok(response);
            }
            else if(response.StatusCode == 404)
            {
                return NotFound(response);
            } else
            {
                return BadRequest(response);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ResponseUserDTO>>> GetById(Guid id)
        {

            ApiResponse<ResponseUserDTO> response = await _userService.GetUserByIdAsync(id);

            if ( response.IsSucceeded ) {
                return Ok(response);
            }
            else if ( response.StatusCode == 404 )
            {
                return NotFound(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpPost()]
        public async Task<ActionResult<ApiResponse<CreateUserDTO>>> Create([FromBody] CreateUserDTO userDTO)
        {

            if ( !ModelState.IsValid )
            {

                return BadRequest(new ApiResponse<CreateUserDTO>().FromModelState(ModelState));
            }

            var response = await _userService.CreateUserAsync(userDTO);

            if(response.IsSucceeded)
            {
                return Ok(response);
            } else
            {
                return BadRequest(response);

            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateUserDTO userDTO)
        {
            try
            {
                await _userService.UpdateUserAsync(id, userDTO);

                return Ok();

            }
            catch ( Exception err )
            {

                return BadRequest();
            }


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            
            var response = await _userService.DeleteUserByIdAsync(id);

            if(response.IsSucceeded )
            {
                return Ok(response);
            } else
            {
                return BadRequest(response);
            }
         
        }
    }
}
