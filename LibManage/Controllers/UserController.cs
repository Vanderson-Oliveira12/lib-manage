using LibManage.DTOs.User;
using LibManage.Models;
using LibManage.Repositories.Users;
using LibManage.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibManage.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        public async Task<ActionResult> Create([FromBody] CreateUserDTO userDTO)
        {

            if ( !ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateUserAsync(userDTO);

            return Ok("Usuário criado com sucesso");

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

            try
            {
                await _userService.DeleteUserAsync(id);

                return Ok("Usuário deletado com sucesso!");
            }
            catch ( Exception ex )
            {
                return BadRequest();
            }
        }
    }
}
