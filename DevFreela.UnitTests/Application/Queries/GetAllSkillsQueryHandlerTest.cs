using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTest
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkilViewModels()
        {
            //Arrange
            var skillsDTO = new List<SkillDTO>
            {
                new SkillDTO(1,"C#"),
                new SkillDTO(2,"SQL"),
                new SkillDTO(3,"Git")
            };

            var skillRepositoryMock = new Mock<SkillRepository>();
            skillRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(skillsDTO);

            var getAllSkillsDTOQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            //Act
            var skillViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsDTOQuery, new CancellationToken());

            //Assert
            Assert.NotNull(skillViewModelList);
            Assert.NotEmpty(skillViewModelList);
            Assert.Equal(skillsDTO.Count, skillViewModelList.Count);

            skillRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
