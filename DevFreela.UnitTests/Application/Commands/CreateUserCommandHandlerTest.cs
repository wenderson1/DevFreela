using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        private static readonly IConfiguration _configuration;

        private static readonly AuthService authService = new(_configuration);

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {

            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var createUserCommand = new CreateUserCommand
            {
                FullName = "Wendersão Fariãos",
                Email = "wendersão@email.com",
                Password = "Cd13123@",
                BirthDate = new DateTime(1998, 09, 03),
                Role = "freelancer",
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object,authService);

            //act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);
            userRepository.Verify(pr => pr.Create(It.IsAny<User>()), Times.Once());

        }
    }
}
