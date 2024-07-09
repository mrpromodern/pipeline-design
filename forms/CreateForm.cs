using PipelineDesign.Data;
using PipelineDesign.Forms;
using PipelineDesign.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PipelineDesign.forms
{
    public partial class CreateForm : BaseForm
    {
        private List<Node> CreateNodesFromGrid(DataGridView dataGrid, string pipelineId)
        {
            var nodes = new List<Node>();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    double x, y;
                    if (double.TryParse(row.Cells[0].Value.ToString(), out x) && double.TryParse(row.Cells[1].Value.ToString(), out y))
                    {
                        nodes.Add(new Node
                        {
                            X = x,
                            Y = y,
                            PipelineId = pipelineId
                        });
                    }
                }
            }
            return nodes;
        }

        public CreateForm(INodeService nodeService, IPipelineService pipelineService) : base (nodeService, pipelineService)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (AreSpecificInputsFilled(txtNamePipeline, dataGridXY))
            {
                var pipeline = new Pipeline
                {
                    Name = txtNamePipeline.Text
                };

                _pipelineService.CreatePipeline(pipeline);

                _nodeService.CreateNodes(CreateNodesFromGrid(dataGridXY, pipeline.Id));

                MessageBox.Show("Трубопровод успешно создан.");

                txtNamePipeline.Text = "";
                dataGridXY.Rows.Clear();
            }
        }
    }
}
