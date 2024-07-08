namespace PipelineDesign.forms
{
    partial class CreateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.dataGridXY = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamePipeline = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXY)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridXY
            // 
            this.dataGridXY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridXY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridXY.Location = new System.Drawing.Point(13, 94);
            this.dataGridXY.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridXY.Name = "dataGridXY";
            this.dataGridXY.Size = new System.Drawing.Size(294, 191);
            this.dataGridXY.TabIndex = 0;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название трубопровода:";
            // 
            // txtNamePipeline
            // 
            this.txtNamePipeline.Location = new System.Drawing.Point(12, 31);
            this.txtNamePipeline.Name = "txtNamePipeline";
            this.txtNamePipeline.Size = new System.Drawing.Size(296, 27);
            this.txtNamePipeline.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Координаты трубопровода";
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.createButton.Location = new System.Drawing.Point(12, 295);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(295, 43);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 350);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamePipeline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridXY);
            this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateForm";
            this.Text = "Создание трубопровода";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamePipeline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createButton;
    }
}