using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
