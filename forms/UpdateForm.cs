using PipelineDesign.Data;
using PipelineDesign.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PipelineDesign.Forms
{
    public partial class UpdateForm : Form
    {
        private readonly INodeService _nodeService;
        private readonly IPipelineService _pipelineService;
        private IEnumerable<Pipeline> _pipelines;
        private void LoadComboBox()
        {
            comboBoxPipelines.DataSource = _pipelines;
            comboBoxPipelines.DisplayMember = "Name";
            comboBoxPipelines.ValueMember = "Id";
        }

        public UpdateForm(INodeService nodeService, IPipelineService pipelineService)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
            _pipelines = _pipelineService.GetAllPipelines();
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            LoadComboBox();
        }

        private void comboBoxPipelines_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void comboBoxPipelines_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxPipelines.SelectedIndex != -1)
            {
                dataGridXY.Rows.Clear();
                
                var selectedPipeline = (Pipeline) comboBoxPipelines.SelectedValue;

                txtNamePipeline.Text = selectedPipeline.Name;
                foreach (var node in selectedPipeline.Node)
                {
                    dataGridXY.Rows.Add(node.X, node.Y);
                }
            }
        }
    }
}
