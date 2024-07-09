using PipelineDesign.Data;
using PipelineDesign.forms;
using PipelineDesign.Forms;
using PipelineDesign.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PipelineDesign
{
    public partial class MainForm : Form
    {
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

            var pipelines = _pipelineService.GetAllPipelines();

            foreach (var pipeline in pipelines)
            {
                foreach (var node in pipeline.Node)
                {
                    dataGridPipelines.Rows.Add(pipeline.Name, node.X, node.Y);
                }
            }
        }

        private void CheckCollisions()
        {
            dataGridPipelines.Rows.Clear();
            var pipelines = _pipelineService.GetAllPipelines().ToArray();

            for (int i = 0; i < pipelines.Length; i++)
            {
                for (int j = i + 1; j < pipelines.Length; j++)
                {
                    var pipeline1 = pipelines[i];
                    var pipeline2 = pipelines[j];
                    var nodes1 = pipeline1.Node.ToArray();
                    var nodes2 = pipeline2.Node.ToArray();

                    for (int k = 0; k < pipeline1.Node.Count - 1; k++)
                    {
                        for (int l = 0; l < pipeline2.Node.Count - 1; l++)
                        {
                            if (LinesIntersect(nodes1[k], nodes1[k + 1], nodes2[l], nodes2[l + 1]))
                            {
                                MessageBox.Show($"Коллизия между трубопроводами {pipeline1.Name} и {pipeline2.Name}.");
                                var pipelineCollisions = new List<Pipeline>();

                                pipelineCollisions.Add(new Pipeline
                                {
                                    Name = pipeline1.Name,
                                    Node = new List<Node> { nodes1[k], nodes1[k + 1] }
                                });
                                pipelineCollisions.Add(new Pipeline
                                {
                                    Name = pipeline2.Name,
                                    Node = new List<Node> { nodes2[l], nodes2[l + 1] }
                                });

                                LoadDataGridCollisions(pipelineCollisions);
                            }
                        }
                    }
                }
            }
        }

        private bool LinesIntersect(Node a, Node b, Node c, Node d)
        {
            var a1 = b.Y - a.Y;
            var b1 = a.X - b.X;
            var c1 = b.X * a.Y - a.X * b.Y;

            var a2 = d.Y - c.Y;
            var b2 = c.X - d.X;
            var c2 = d.X * c.Y - c.X * d.Y;

            var delta = a1 * b2 - a2 * b1;

            if (delta == 0)
            {
                return false;
            }

            var x = (b1 * c2 - b2 * c1) / delta;
            var y = (a2 * c1 - a1 * c2) / delta;

            return x >= Math.Min(a.X, b.X) && x <= Math.Max(a.X, b.X) && y >= Math.Min(a.Y, b.Y) && y <= Math.Max(a.Y, b.Y) &&
                x >= Math.Min(c.X, d.X) && x <= Math.Max(c.X, d.X) && y >= Math.Min(c.Y, d.Y) && y <= Math.Max(c.Y, d.Y);
        }

        private void ShowDialogAndRefreshUI<T>() where T : Form
        {
            if (_serviceProvider.GetService(typeof(T)) is T form)
            {
                form.FormClosed += OnFormClosed;
                form.ShowDialog();
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            LoadGraph();
            LoadDataGrid();
        }

        private void LoadDataGridCollisions(List<Pipeline> pipelines)
        {
            var color = Color.FromArgb(new Random().Next(200, 256), new Random().Next(150, 205), 0);

            foreach (var pipeline in pipelines)
            {
                foreach (var node in pipeline.Node)
                {
                    var row = dataGridPipelines.Rows.Add(pipeline.Name, node.X, node.Y);
                    dataGridPipelines.Rows[row].DefaultCellStyle.BackColor = color;
                }
            }
        }

        public MainForm(INodeService nodeService, IPipelineService pipelineService, IServiceProvider serviceProvider)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
            _serviceProvider = serviceProvider;

            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            InitializeDataGridView();

            RefreshUI();
        }

        private void InitializeDataGridView()
        {
            dataGridPipelines.Columns.Add("Name", "№");
            dataGridPipelines.Columns.Add("X", "X");
            dataGridPipelines.Columns.Add("Y", "Y");
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogAndRefreshUI<CreateForm>();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogAndRefreshUI<UpdateForm>();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCollisions();
            if (dataGridPipelines.Rows.Count < 1)
            {
                MessageBox.Show("Коллизий не найдено.");
                LoadDataGrid();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogAndRefreshUI<DeleteForm>();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
    }
}
