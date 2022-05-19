using DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.DeletePost;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.UpdatePost;
using DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetAllPosts;
using DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByUserIdPosts;
using DevSocialMediaCaseProject.Application.Features.Queries.Users.GetByIdUser;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllPostsRequest();
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{:id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdPostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpGet("userPosts/{:userId}")]
        public async Task<IActionResult> GetByUserIdPosts([FromQuery] GetPostsByUserIdRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
