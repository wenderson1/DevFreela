using DevFreela.API.Models;
using DevFreela.Application.Queries.GetAllUser;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UsersController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }
        
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdUser = new GetByIdUserQuery(id);
            var user = await _mediator.Send(getByIdUser);
            return Ok(user);
        }

        //api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody]LoginModel login)
        {
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);
            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }
    }
}
