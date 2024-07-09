using PipelineDesign.Services;
using System.Windows.Forms;

namespace PipelineDesign.Forms
{
    public partial class BaseForm : Form
    {
        protected readonly INodeService _nodeService;
        protected readonly IPipelineService _pipelineService;

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(INodeService nodeService, IPipelineService pipelineService)
        {
            _nodeService = nodeService;
            _pipelineService = pipelineService;
        }

        protected void LoadComboBox(ComboBox comboBox)
        {
            var _pipelines = _pipelineService.GetAllPipelines();
            if (_pipelines != null)
            {
                comboBox.DataSource = _pipelines;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
            }
        }

        protected bool AreSpecificInputsFilled(TextBox textBox, DataGridView dataGrid)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Заполните поле -Название трубопровода-");
                return false;
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    return true;
                }
            }

            MessageBox.Show("Добавьте хотя бы один узел.");
            return false;
        }
    }
}
