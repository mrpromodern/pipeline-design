using PipelineDesign.forms;
using PipelineDesign.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PipelineDesign
{
    public partial class MainForm : Form
    {
        private MenuStrip menuStrip;
        private readonly INodeService _nodeService;
        private readonly IPipelineService _pipelineService;
        private readonly IServiceProvider _serviceProvider;

        private void LoadGraph()
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var nodes = _nodeService.GetAllNodes();
            var pipelines = _pipelineService.GetAllPipelines();

            var nodeSeries = new Series
            {
                Name = "Nodes",
                ChartType = SeriesChartType.Point
            };
            foreach (var node in nodes)
            {
                nodeSeries.Points.AddXY(node.X, node.Y);
            }

            foreach (var pipeline in pipelines)
            {
                var pipelineSeries = new Series
                {
                    Name = pipeline.Name,
                    ChartType = SeriesChartType.Line
                };
                var pipelineNodes = nodes.Where(n => n.PipelineId == pipeline.Id).OrderBy(n => n.Id).ToList();
                foreach (var node in pipelineNodes)
                {
                    pipelineSeries.Points.AddXY(node.X, node.Y);
                }
                chart.Series.Add(pipelineSeries);
            }

            chart.Series.Add(nodeSeries);
        }

        public MainForm(INodeService nodeService, IPipelineService pipelineService, IServiceProvider serviceProvider)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateForm createForm = (CreateForm)_serviceProvider.GetService(typeof(CreateForm)))
            {
                createForm.ShowDialog();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGraph();
        }
    }
}
