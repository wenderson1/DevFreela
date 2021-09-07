using Dapper;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Start
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly string _connectionString;
        public StartProjectCommandHandler(IProjectRepository projectRepository, IConfiguration configuration)
        {
            _projectRepository = projectRepository;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Start();
           
            await _projectRepository.StartAsync(project);
            return Unit.Value;
        }
    }
}
