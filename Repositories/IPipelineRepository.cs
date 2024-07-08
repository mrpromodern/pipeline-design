using PipelineDesign.Data;
using System.Collections.Generic;

namespace PipelineDesign.Repositories
{
    internal interface IPipelineRepository : IRepository<Pipeline>
    {
        IEnumerable<Pipeline> GetPipelines();
        Pipeline GetPipelineById(string id);
    }
}
