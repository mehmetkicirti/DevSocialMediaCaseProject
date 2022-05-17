using DevSocialMediaCaseProject.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Domain.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
