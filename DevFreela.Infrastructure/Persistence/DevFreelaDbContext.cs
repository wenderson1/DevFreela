using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descricao do Projeto 1",1,1,1000),
                new Project("Meu projeto ASPNET Core 2", "Minha descricao do Projeto 2",1,1,2000),
                new Project("Meu projeto ASPNET Core 3", "Minha descricao do Projeto 3",1,1,3000)
            };

            Users = new List<User>
            {
                new User("Wenderson Farias", "wenderson.farias10@gmail.com", new DateTime(1998,09,03)),
                new User("Luis Felipe", "luis.felipe@gmail.com", new DateTime(1998,09,03)),
                new User("Bill Gates", "windows@gmail.com", new DateTime(1998,09,03))
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; private set; }
        public List<User> Users { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
