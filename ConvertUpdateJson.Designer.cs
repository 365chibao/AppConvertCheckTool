using System.Windows.Forms;

namespace AppConvertCheckTool
{
    partial class ConvertUpdateJson
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
        private DataGridView dgvListRule;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOutput = new Button();
            btnConvert = new Button();
            btnInput = new Button();
            dgvListRule = new DataGridView();
            From = new DataGridViewTextBoxColumn();
            To = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            btnRefesh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListRule).BeginInit();
            SuspendLayout();
            // 
            // btnOutput
            // 
            btnOutput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOutput.Location = new Point(304, 12);
            btnOutput.Name = "btnOutput";
            btnOutput.Size = new Size(118, 32);
            btnOutput.TabIndex = 0;
            btnOutput.Text = "View Output";
            btnOutput.Click += btnOutput_Click;
            // 
            // btnConvert
            // 
            btnConvert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConvert.Location = new Point(216, 12);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(82, 32);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert";
            btnConvert.Click += btnConvert_Click;
            // 
            // btnInput
            // 
            btnInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnInput.Location = new Point(93, 12);
            btnInput.Name = "btnInput";
            btnInput.Size = new Size(117, 32);
            btnInput.TabIndex = 2;
            btnInput.Text = "View Input";
            btnInput.Click += btnInput_Click;
            // 
            // dgvListRule
            // 
            dgvListRule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListRule.Columns.AddRange(new DataGridViewColumn[] { From, To, Type, description });
            dgvListRule.Location = new Point(0, 62);
            dgvListRule.Name = "dgvListRule";
            dgvListRule.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvListRule.Size = new Size(788, 499);
            dgvListRule.TabIndex = 4;
            dgvListRule.CellValueChanged += DataGridView1_CellValueChanged;
            // 
            // From
            // 
            From.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            From.DataPropertyName = "From";
            From.HeaderText = "From";
            From.Name = "From";
            // 
            // To
            // 
            To.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            To.DataPropertyName = "To";
            To.HeaderText = "To";
            To.Name = "To";
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.Width = 120;
            // 
            // description
            // 
            description.DataPropertyName = "Description";
            description.HeaderText = "Description";
            description.Name = "description";
            description.Width = 120;
            // 
            // btnRefesh
            // 
            btnRefesh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefesh.Location = new Point(12, 12);
            btnRefesh.Name = "btnRefesh";
            btnRefesh.Size = new Size(75, 32);
            btnRefesh.TabIndex = 2;
            btnRefesh.Text = "Reload";
            btnRefesh.Click += btnRefesh_Click;
            // 
            // ConvertUpdateJson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 572);
            Controls.Add(dgvListRule);
            Controls.Add(btnOutput);
            Controls.Add(btnConvert);
            Controls.Add(btnRefesh);
            Controls.Add(btnInput);
            Name = "ConvertUpdateJson";
            Text = "Convert File";
            Load += UpdateJson_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListRule).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnOutput;
        private Button btnConvert;
        private Button btnInput;
        private Button btnRefesh;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn To;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn description;
    }
}