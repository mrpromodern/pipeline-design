namespace PipelineDesign.Forms
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.createButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamePipeline = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridXY = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxPipelines = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXY)).BeginInit();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.createButton.Location = new System.Drawing.Point(13, 360);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(295, 43);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Обновить";
            this.createButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Координаты трубопровода";
            // 
            // txtNamePipeline
            // 
            this.txtNamePipeline.Location = new System.Drawing.Point(12, 99);
            this.txtNamePipeline.Name = "txtNamePipeline";
            this.txtNamePipeline.Size = new System.Drawing.Size(296, 27);
            this.txtNamePipeline.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название трубопровода:";
            // 
            // dataGridXY
            // 
            this.dataGridXY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridXY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridXY.Location = new System.Drawing.Point(14, 162);
            this.dataGridXY.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridXY.Name = "dataGridXY";
            this.dataGridXY.Size = new System.Drawing.Size(294, 191);
            this.dataGridXY.TabIndex = 5;
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
            // comboBoxPipelines
            // 
            this.comboBoxPipelines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPipelines.FormattingEnabled = true;
            this.comboBoxPipelines.Location = new System.Drawing.Point(12, 31);
            this.comboBoxPipelines.Name = "comboBoxPipelines";
            this.comboBoxPipelines.Size = new System.Drawing.Size(296, 27);
            this.comboBoxPipelines.TabIndex = 10;
            this.comboBoxPipelines.SelectedIndexChanged += new System.EventHandler(this.comboBoxPipelines_SelectedIndexChanged);
            this.comboBoxPipelines.TextChanged += new System.EventHandler(this.comboBoxPipelines_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выбор трубопровода";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 412);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPipelines);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamePipeline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridXY);
            this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UpdateForm";
            this.Text = "Обновление трубопровода";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamePipeline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.ComboBox comboBoxPipelines;
        private System.Windows.Forms.Label label3;
    }
}