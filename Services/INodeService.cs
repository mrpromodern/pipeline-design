using PipelineDesign.Data;
using System.Collections.Generic;

namespace PipelineDesign.Services
{
    public interface INodeService
    {
        IEnumerable<Node> GetAllNodes();
        Node GetNodeById(string id);
        void CreateNode(Node node);
        void CreateNodes(IEnumerable<Node> nodes);
        void UpdateNode(Node node);
        void DeleteNode(string id);
        void DeleteNodes(IEnumerable<Node> nodes);
    }
}
