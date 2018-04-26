namespace Migrate.Clients.Contrains
{
    partial class ContraintsOperation
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.constraintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnableConstraint = new System.Windows.Forms.Button();
            this.Disable = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tablespaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteRuleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constraintBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.tablespaceDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.tableNameDataGridViewTextBoxColumn,
            this.refNameDataGridViewTextBoxColumn,
            this.deleteRuleDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.constraintBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(47, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(735, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // constraintBindingSource
            // 
            this.constraintBindingSource.DataSource = typeof(Migrate.Domain.Model.Constraint);
            // 
            // EnableConstraint
            // 
            this.EnableConstraint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EnableConstraint.Location = new System.Drawing.Point(47, 34);
            this.EnableConstraint.Name = "EnableConstraint";
            this.EnableConstraint.Size = new System.Drawing.Size(75, 33);
            this.EnableConstraint.TabIndex = 1;
            this.EnableConstraint.Text = "启用";
            this.EnableConstraint.UseVisualStyleBackColor = true;
            this.EnableConstraint.Click += new System.EventHandler(this.EnableConstraint_Click);
            // 
            // Disable
            // 
            this.Disable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Disable.Location = new System.Drawing.Point(167, 34);
            this.Disable.Name = "Disable";
            this.Disable.Size = new System.Drawing.Size(75, 33);
            this.Disable.TabIndex = 2;
            this.Disable.Text = "禁用";
            this.Disable.UseVisualStyleBackColor = true;
            this.Disable.Click += new System.EventHandler(this.DisableContraint_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(283, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Drop_Click);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // tablespaceDataGridViewTextBoxColumn
            // 
            this.tablespaceDataGridViewTextBoxColumn.DataPropertyName = "Tablespace";
            this.tablespaceDataGridViewTextBoxColumn.HeaderText = "Owner";
            this.tablespaceDataGridViewTextBoxColumn.Name = "tablespaceDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "约束名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "约束类型";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "表名称";
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            // 
            // refNameDataGridViewTextBoxColumn
            // 
            this.refNameDataGridViewTextBoxColumn.DataPropertyName = "RefName";
            this.refNameDataGridViewTextBoxColumn.HeaderText = "R类型约束名称";
            this.refNameDataGridViewTextBoxColumn.Name = "refNameDataGridViewTextBoxColumn";
            this.refNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // deleteRuleDataGridViewTextBoxColumn
            // 
            this.deleteRuleDataGridViewTextBoxColumn.DataPropertyName = "DeleteRule";
            this.deleteRuleDataGridViewTextBoxColumn.HeaderText = "R类型删除规则";
            this.deleteRuleDataGridViewTextBoxColumn.Name = "deleteRuleDataGridViewTextBoxColumn";
            this.deleteRuleDataGridViewTextBoxColumn.Width = 110;
            // 
            // ContraintsOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Disable);
            this.Controls.Add(this.EnableConstraint);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContraintsOperation";
            this.Text = "ContraintsOperation";
            this.Load += new System.EventHandler(this.ContraintsOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constraintBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button EnableConstraint;
        private System.Windows.Forms.Button Disable;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource constraintBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablespaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteRuleDataGridViewTextBoxColumn;
    }
}