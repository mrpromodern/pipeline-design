using PipelineDesign.Data;
using PipelineDesign.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PipelineDesign.forms
{
    public partial class CreateForm : Form
    {
        private readonly INodeService _nodeService;
        private readonly IPipelineService _pipelineService;

        public CreateForm(INodeService nodeService, IPipelineService pipelineService)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool AreSpecificInputsFilled()
        {
            if (txtNamePipeline.Text == "")
            {
                MessageBox.Show("Заполните поле -Название трубопровода-");
                return false;
            }

            foreach (DataGridViewRow row in dataGridXY.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    return true;
                }
            }

            return false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (AreSpecificInputsFilled())
            {
                var pipeline = new Pipeline
                {
                    Name = txtNamePipeline.Text
                };

                _pipelineService.CreatePipeline(pipeline);

                var nodes = new List<Node>();
                foreach (DataGridViewRow row in dataGridXY.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        nodes.Add(new Node
                        {
                            X = Convert.ToDouble(row.Cells[0].Value),
                            Y = Convert.ToDouble(row.Cells[1].Value),
                            PipelineId = pipeline.Id
                        });
                    }
                }

                _nodeService.CreateNodes(nodes);

                if (MessageBox.Show("Трубопровод успешно создан. Хотите закончить?", "Успешно", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Close();
                }
                else
                {
                    txtNamePipeline.Text = "";
                    dataGridXY.Rows.Clear();
                }
            }
        }
    }
}
