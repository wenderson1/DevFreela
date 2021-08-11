using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
   public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, List<UserSkill> skills, List<Project> ownedProjects, List<Project> freelanceProjects, List<ProjectComment> comments)
        {
            FullName = fullName;
            Email = email;
            Skills = skills;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
            Comments = comments;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; } 
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
