using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Library", "Descrição do projeto", 1, 1, 10000),
                new Project("BloodBank", "Descrição do projeto 2", 1, 1, 20000),
                new Project("DevFreela", "Descrição do projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User ("Aline Diani", "alinediani@gmail.com", new DateTime(1999,6,14)),
                new User ("Lucas Isabel", "lucasisabel@gmail.com", new DateTime(2002,4,21)),
                new User ("Ana Julia Diani", "anadiani@gmail.com", new DateTime(2005,1,9)),
                new User ("Edison Batista", "edisonbatista@gmail.com", new DateTime(1971,5,15))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill(".NET Framework"),
                new Skill("C#"),
                new Skill("SQL"),
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> Comments { get; set; }
    }
}
