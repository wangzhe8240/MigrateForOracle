namespace Migrate.Clients
{
    partial class DeteleTableSpaceForm
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
            this.detelebutton = new System.Windows.Forms.Button();
            this.tablespaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablespaceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // detelebutton
            // 
            this.detelebutton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.detelebutton.Location = new System.Drawing.Point(477, 22);
            this.detelebutton.Name = "detelebutton";
            this.detelebutton.Size = new System.Drawing.Size(75, 30);
            this.detelebutton.TabIndex = 0;
            this.detelebutton.Text = "删除";
            this.detelebutton.UseVisualStyleBackColor = true;
            this.detelebutton.Click += new System.EventHandler(this.Detele_Click);
            // 
            // tablespaceBindingSource
            // 
            this.tablespaceBindingSource.DataSource = typeof(Migrate.Domain.Model.Tablespace);
            // 
            // DeteleTableSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 353);
            this.Controls.Add(this.detelebutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeteleTableSpaceForm";
            this.Text = "DeteleTableSpaceForm";
            this.Load += new System.EventHandler(this.DeteleTableSpace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablespaceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button detelebutton;
        private System.Windows.Forms.BindingSource tablespaceBindingSource;
    }
}