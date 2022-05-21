using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetAllPostDetails
{
    public class GetAllPostDetailsRequest: IRequest<ServiceDataResponse<IEnumerable<UserPostViewDTO>>>
    {
    }
}
