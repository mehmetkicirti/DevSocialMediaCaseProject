using DevSocialMediaCaseProject.Application.Features.Commands.Users.DeleteUser;
using DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdatePassword;
using DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdateUserDetails;
using DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByIdPost;
using DevSocialMediaCaseProject.Application.Features.Queries.Users.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserDetailsRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdatePasswordRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllUsersRequest();
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetByIdUserRequest { Id = id}));
        }
    }
}
