using PipelineDesign.data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PipelineDesign
{
    public partial class MainForm : Form
    {
        private MenuStrip menuStrip;

        public MainForm()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseEntities())
            {
                var pipeline = new Pipelines { Name = 1 };
                db.Pipelines.Add(pipeline);
                db.SaveChanges();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseEntities())
            {
                var pipeline = db.Pipelines.FirstOrDefault(n => n.Name == 1);
                if (pipeline == null)
                {
                    return;
                }
                pipeline.Name = 2;
                db.SaveChanges();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseEntities())
            {
                var pipelines = db.Pipelines;

                foreach (var pipeline in pipelines)
                {
                    MessageBox.Show(pipeline.Name.ToString());
                }
            }
        }
    }
}
