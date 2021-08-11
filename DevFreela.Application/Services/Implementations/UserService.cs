using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.Id == id);

            if (user == null) return null;

            var userDetailsViewModel = new UserDetailsViewModel(
                user.FullName,
                user.Email,
                user.Skills,
                user.FreelanceProjects,
                user.OwnedProjects,
                user.Comments
                );

            return userDetailsViewModel;
        }
    }
}
