using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
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
    public class CreateCommentCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Aqui jaz um comentário",
                IdProject = 1,
                IdUser = 1
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepository.Object);

            //act
            var content = await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            //Assert
            Assert.True(content.ToString() != null);
            projectRepository.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once());

        }
    }
}
