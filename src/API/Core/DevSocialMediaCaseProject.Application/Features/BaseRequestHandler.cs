using AutoMapper;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features
{
    public class BaseRequestHandler<TRepository, T>
        where TRepository : IRepository<T>
        where T : BaseEntity
    {
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;
        public BaseRequestHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
    }
}
