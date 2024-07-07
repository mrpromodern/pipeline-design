using System.Windows.Forms;

namespace PipelineDesign.forms
{
    internal class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Создание трубопровода";
            this.ResumeLayout(false);
        }
    }
}
