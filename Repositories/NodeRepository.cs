using PipelineDesign.Data;

namespace PipelineDesign.Repositories
{
    internal class NodeRepository : Repository<Node>, INodeRepository
    {
        public NodeRepository(AppDbContext context) : base(context)
        {
        }
    }
}