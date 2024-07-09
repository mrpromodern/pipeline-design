using PipelineDesign.Data;
using PipelineDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PipelineDesign.Forms
{
    public partial class UpdateForm : BaseForm
    {
        private void UpdatePipelineName(Pipeline selectedPipeline)
        {
            if (selectedPipeline.Name != txtNamePipeline.Text)
            {
                selectedPipeline.Name = txtNamePipeline.Text;
                _pipelineService.UpdatePipeline(selectedPipeline);
            }
        }

        private void UpdateNodes(DataGridView dataGridView, Pipeline selectedPipeline)
        {
            var updatedNodes = GetUpdatedNodes(dataGridView, selectedPipeline);
            var existingNodes = selectedPipeline.Node.ToList();

            _nodeService.DeleteNodes(existingNodes);
            _nodeService.CreateNodes(updatedNodes);
        }

        private List<Node> GetUpdatedNodes(DataGridView dataGridView, Pipeline selectedPipeline) 
        {
            return dataGridView.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["X"].Value != null && row.Cells["Y"].Value != null)
                .Select(row => new Node
                {
                    X = Convert.ToDouble(row.Cells["X"].Value),
                    Y = Convert.ToDouble(row.Cells["Y"].Value),
                    PipelineId = selectedPipeline.Id
                })
                .ToList();
        }

        public UpdateForm(INodeService nodeService, IPipelineService pipelineService) : base(nodeService, pipelineService)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            LoadComboBox(comboBoxPipelines);
        }

        private void comboBoxPipelines_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxPipelines.SelectedIndex != -1)
            {
                dataGridXY.Rows.Clear();
                var selectedPipeline = (Pipeline) comboBoxPipelines.SelectedItem;
                txtNamePipeline.Text = selectedPipeline.Name;
                foreach (var node in selectedPipeline.Node)
                {
                    dataGridXY.Rows.Add(node.X, node.Y);
                }
            }
        }

        private void updateButton_Click(object sender, System.EventArgs e)
        {
            if (comboBoxPipelines.SelectedIndex != -1 && AreSpecificInputsFilled(txtNamePipeline, dataGridXY))
            {
                var selectedPipeline = (Pipeline)comboBoxPipelines.SelectedItem;
                UpdatePipelineName(selectedPipeline);
                UpdateNodes(dataGridXY, selectedPipeline);

                MessageBox.Show("Трубопровод успешно обновлен.");
                LoadComboBox(comboBoxPipelines);
            }
        }
    }
}
