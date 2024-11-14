using DianaOsipovaKT_42_21.Database;
using DianaOsipovaKT_42_21.Interfaces.WorkloadsInterfaces;
using DianaOsipovaKT_42_21.Models;
using DianaOsipovaKT_42_21.Tests;
using Microsoft.EntityFrameworkCore;

namespace DianaOsipovaKT_42_21
{
    public class AppIntegrationTests
    {
        public readonly DbContextOptions<OsipovaDbContext> _dbContextOptions;

        public AppIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<OsipovaDbContext>()
                .UseInMemoryDatabase(databaseName: "osipova_db")
                .Options;
        }

        [Fact]
        public async Task IsValidAgeProfessor_True()
        {
            var ctx = new OsipovaDbContext(_dbContextOptions);
            var workloadService = new WorkloadService(ctx);

            var professors = new List<Professor>
            {
                new Professor
                {
                    FirstName = "Иванов",
                    LastName = "Иван",
                    MiddleName = "Иванович",
                    Age = 45
                },
                new Professor
                {
                    FirstName = "Петров",
                    LastName = "Петр",
                    MiddleName = "Петрович",
                    Age = 50
                },
                new Professor
                {
                    FirstName = "Кузнецов",
                    LastName = "Алексей",
                    MiddleName = "Александрович",
                    Age = 60
                },
                new Professor
                {
                    FirstName = "Федоров",
                    LastName = "Александр",
                    MiddleName = "Федорович",
                    Age = 35
                },
                new Professor
                {
                    FirstName = "Сидоров",
                    LastName = "Сидор",
                    MiddleName = "Сидорович",
                    Age = 12
                }
            };

            await ctx.Set<Professor>().AddRangeAsync(professors);

            var educationalSubjects = new List<EducationalSubject>
            {
                new EducationalSubject { Name = "Химия" },
                new EducationalSubject { Name = "Физика" },
                new EducationalSubject { Name = "Математика" },
                new EducationalSubject { Name = "Биология" }
            };
            await ctx.Set<EducationalSubject>().AddRangeAsync(educationalSubjects);

            var workloads = new List<Workload>
            {
                new Workload { ProfessorId = 1, EducationalSubjectId = 1, NumberOfHours = 10 },
                new Workload { ProfessorId = 1, EducationalSubjectId = 1, NumberOfHours = 20 },
                new Workload { ProfessorId = 4, EducationalSubjectId = 4, NumberOfHours = 30 },
                new Workload { ProfessorId = 3, EducationalSubjectId = 2, NumberOfHours = 15 }
            };
            await ctx.Set<Workload>().AddRangeAsync(workloads);

            await ctx.SaveChangesAsync();

            // Проверка на допустимый возраст
            var allprofessors = await ctx.Set<Professor>().ToListAsync();
            foreach (var Professor in allprofessors)
            {
                bool isValid = Professor.IsValidAge();
                Assert.True(isValid, $"Профессор {Professor.FirstName} {Professor.LastName} имеет недопустимый для работы возраст: {Professor.Age}");
            }
        }
    }
}