using PipelineDesign.Data;
using PipelineDesign.Repositories;
using System;
using System.Collections.Generic;

namespace PipelineDesign.Services
{
    internal class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;

        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public IEnumerable<Node> GetAllNodes()
        {
            var nodes = _nodeRepository.GetAll();
            return _nodeRepository.GetAll();
        }

        public Node GetNodeById(string id)
        {
            return _nodeRepository.GetById(id);
        }

        public void CreateNode(Node node)
        {
            node.Id = Guid.NewGuid().ToString();
            _nodeRepository.Add(node);
            _nodeRepository.Save();
        }

        public void CreateNodes(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                node.Id = Guid.NewGuid().ToString();
                _nodeRepository.Add(node);
            }
            _nodeRepository.Save();
        }   

        public void UpdateNode(Node node)
        {
            _nodeRepository.Update(node);
            _nodeRepository.Save();
        }

        public void DeleteNode(string id)
        {
            _nodeRepository.Delete(id);
            _nodeRepository.Save();
        }
    }
}
