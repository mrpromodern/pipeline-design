using PipelineDesign.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PipelineDesign.Repositories
{
    internal class PipelineRepository : Repository<Pipeline>, IPipelineRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Pipeline> _dbSet;
        public PipelineRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Pipeline>();
        }

        public IEnumerable<Pipeline> GetPipelines()
        {
            var pipelines = _dbSet.Include(p => p.Node).OrderBy(n => n.Name).ToList();
            foreach (var pipeline in pipelines)
            {
                pipeline.Node = pipeline.Node.OrderBy(n => n.X).ThenBy(n => n.Y).ToList();
            }

            return pipelines;
        }

        public Pipeline GetPipelineById(string id) {
            return _dbSet.Include(p => p.Node).FirstOrDefault(p => p.Id == id);
        }
    }
}
