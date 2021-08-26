using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
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

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }*/

       /** public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

        }
        */
        public List<UserDetailsViewModel> GetAll(string query)
        {
            var users = _dbContext.Users;

            var usersViewModel = users
                .Select(u => new UserDetailsViewModel(u.FullName, u.Email, u.Skills, u.OwnedProjects, u.FreelanceProjects, u.Comments))
                .ToList();

            return usersViewModel;
        }

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

        /*public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.Id == inputModel.Id);
            user.Update(inputModel.FullName, inputModel.Email, inputModel.Skills);
            _dbContext.SaveChanges();
        }*/
    }
}
