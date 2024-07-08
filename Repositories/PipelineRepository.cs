using PipelineDesign.Data;

namespace PipelineDesign.Repositories
{
    internal class PipelineRepository : Repository<Pipeline>, IPipelineRepository
    {
        public PipelineRepository(AppDbContext context) : base(context)
        {
        }
    }
}
