using PipelineDesign.Data;
using PipelineDesign.forms;
using PipelineDesign.Forms;
using PipelineDesign.Services;
using System;
using System.Collections;
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
            var pipelines = _pipelineService.GetAllPipelines().Reverse();

            var nodeSeries = new Series
            {
                ChartType = SeriesChartType.Point,
                IsVisibleInLegend = false
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
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 4
                };

                foreach (var node in pipeline.Node)
                {
                    pipelineSeries.Points.AddXY(node.X, node.Y);
                }
                chart.Series.Add(pipelineSeries);
            }

            chart.ChartAreas[0].AxisX.Minimum = nodes.Any(node => node.X < 0) ? double.NaN : 0;
            
            if (nodes.Any())
            {
                double minX = nodes.Min(node => node.X);
                double maxX = nodes.Max(node => node.X);
                double rangeX = maxX - minX;

                int intervalX = (int)Math.Ceiling(rangeX / 10);
                chart.ChartAreas[0].AxisX.Interval = intervalX;
                chart.ChartAreas[0].AxisY.Interval = intervalX;
            }

            chart.Series.Add(nodeSeries);
        }

        private void LoadDataGrid()
        {
            dataGridPipelines.Rows.Clear();
            dataGridPipelines.Columns.Clear();

            dataGridPipelines.Columns.Add("Name","№");
            dataGridPipelines.Columns.Add("X", "X");
            dataGridPipelines.Columns.Add("Y", "Y");

            var pipelines = _pipelineService.GetAllPipelines().Reverse();

            foreach (var pipeline in pipelines)
            {
                foreach (var node in pipeline.Node)
                {
                    dataGridPipelines.Rows.Add(pipeline.Name, node.X, node.Y);
                }
            }
        }

        public MainForm(INodeService nodeService, IPipelineService pipelineService, IServiceProvider serviceProvider)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadGraph();
            LoadDataGrid();
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
           using (UpdateForm updateForm = (UpdateForm)_serviceProvider.GetService(typeof(UpdateForm)))
            {
                updateForm.ShowDialog();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGraph();
            LoadDataGrid();
        }
    }
}
