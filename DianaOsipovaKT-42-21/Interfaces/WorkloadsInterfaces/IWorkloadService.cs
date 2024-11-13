using DianaOsipovaKT_42_21.Database;
using DianaOsipovaKT_42_21.Filters;
using DianaOsipovaKT_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DianaOsipovaKT_42_21.Interfaces.WorkloadsInterfaces
{
        public interface IWorkloadService
    {
        public Task<Workload[]> GetWorkloadByProfessorAsync(WorkloadProfessorFilter filter, CancellationToken cancellationToken);
        //public Task<Workload[]> GetWorkloadsByProfessorNameAsync(string firstName, string lastName, string middleName, CancellationToken cancellationToken);
        //public Task<Workload> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        //public Task<Professor> CreateProfessor(Professor professor, CancellationToken cancellationToken);
    }
    public class WorkloadService : IWorkloadService
    {
        private readonly OsipovaDbContext _dbContext;
        //private  OsipovaDbContext _dbContext;
        public WorkloadService(OsipovaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Workload[]> GetWorkloadByProfessorAsync(WorkloadProfessorFilter filter, CancellationToken cancellationToken = default)
        {
            var professors = _dbContext.Set<Workload>().Where(w => (w.Professor.LastName == filter.LastName) || (w.Professor.FirstName == filter.FirstName) || (w.Professor.MiddleName == filter.MiddleName)).ToArrayAsync(cancellationToken); //Заменять w.ProfessorId и filter.professor_id на необходимые
            return professors;
        }

        //public async Task<Workload[]> GetWorkloadsByProfessorNameAsync(string firstName, string lastName, string middleName, CancellationToken cancellationToken = default)
        //{
        //    var professor = await _dbContext.Set<Professor>()
        //        .FirstOrDefaultAsync(p =>
        //            p.FirstName.Contains(firstName) ||
        //            p.LastName.Contains(lastName) ||
        //            p.MiddleName.Contains(middleName), cancellationToken);

        //    if (professor == null)
        //    {
        //        return Array.Empty<Workload>(); // Или выбросьте исключение
        //    }

        //    return await _dbContext.Workloads
        //        .Where(w => w.ProfessorId == professor.Id)
        //        .ToArrayAsync(cancellationToken);
        //}

        //public async Task<Professor> CreateProfessor(Professor professor, CancellationToken cancellationToken = default)
        //{
        //    _dbContext.Professors.Add(professor);
        //    await _dbContext.SaveChangesAsync();
        //    return professor;

        //}        
    }
}
