﻿using PipelineDesign.Data;
using PipelineDesign.Repositories;
using System;
using System.Collections.Generic;

namespace PipelineDesign.Services
{
    internal class PipelineService : IPipelineService
    {
        private readonly IPipelineRepository _pipelineRepository;

        public PipelineService(IPipelineRepository pipelineRepository)
        {
            _pipelineRepository = pipelineRepository;
        }

        public IEnumerable<Pipeline> GetAllPipelines()
        {
            return _pipelineRepository.GetPipelines();
        }

        public Pipeline GetPipelineById(string id)
        {
            return _pipelineRepository.GetPipelineById(id);
        }

        public void CreatePipeline(Pipeline pipeline)
        {
            pipeline.Id = Guid.NewGuid().ToString();
            _pipelineRepository.Add(pipeline);
            _pipelineRepository.Save();
        }

        public void UpdatePipeline(Pipeline pipeline)
        {
            _pipelineRepository.Update(pipeline);
            _pipelineRepository.Save();
        }

        public void DeletePipeline(string id)
        {
            _pipelineRepository.DeletePipeline(id);
            _pipelineRepository.Save();
        }
    }
}