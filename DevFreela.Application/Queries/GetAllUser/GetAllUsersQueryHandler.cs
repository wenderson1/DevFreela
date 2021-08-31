using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllUser
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDetailsViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllUsersQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserDetailsViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _dbContext.Users;

            var usersViewModel = await users
                .Select(u => new UserDetailsViewModel(u.FullName, u.Email, u.Skills, u.OwnedProjects, u.FreelanceProjects, u.Comments))
                .ToListAsync();

            return usersViewModel;
        }
    }
}
