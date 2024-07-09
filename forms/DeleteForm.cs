using PipelineDesign.Data;
using PipelineDesign.Services;
using System;
using System.Windows.Forms;

namespace PipelineDesign.Forms
{
    public partial class DeleteForm : BaseForm
    {
        private void DeleteSelectedPipeline()
        {
            var selectedPipeline = (Pipeline)comboBoxPipelines.SelectedItem;
            _pipelineService.DeletePipeline(selectedPipeline.Id);
        }
        
        public DeleteForm(INodeService nodeService, IPipelineService pipelineService) : base(nodeService, pipelineService)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            LoadComboBox(comboBoxPipelines);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (comboBoxPipelines.SelectedIndex != -1)
            {
                try
                {
                    DeleteSelectedPipeline();
                    MessageBox.Show("Трубопровод успешно удален");
                    LoadComboBox(comboBoxPipelines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}");
                }
            }
            else MessageBox.Show("Выберите трубопровод для удаления");
        }
    }
}
