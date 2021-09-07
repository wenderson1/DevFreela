using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDetailsViewModel> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

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
