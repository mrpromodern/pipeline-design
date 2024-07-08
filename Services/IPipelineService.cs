using PipelineDesign.Data;
using System.Collections.Generic;

namespace PipelineDesign.Services
{
    public interface IPipelineService
    {
        IEnumerable<Pipeline> GetAllPipelines();
        Pipeline GetPipelineById(string id);
        void CreatePipeline(Pipeline pipeline);
        void UpdatePipeline(Pipeline pipeline);
        void DeletePipeline(string id);
    }
}
