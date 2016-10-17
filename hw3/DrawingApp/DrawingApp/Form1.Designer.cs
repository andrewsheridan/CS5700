namespace DrawingApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.selectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.undoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.ToolTipText = "New";
            this.newToolStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.ToolTipText = "Save your current drawing.";
            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripButton.Image")));
            this.loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadToolStripButton.Name = "loadToolStripButton";
            this.loadToolStripButton.Size = new System.Drawing.Size(37, 22);
            this.loadToolStripButton.Text = "Load";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.loadToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(847, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(149, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 624);
            this.panel1.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripButton,
            this.copyToolstripButton,
            this.undoToolstripButton,
            this.redoToolstripButton,
            this.toolStripSeparator1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(59, 636);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // selectToolStripButton
            // 
            this.selectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolStripButton.Image")));
            this.selectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolStripButton.Name = "selectToolStripButton";
            this.selectToolStripButton.Size = new System.Drawing.Size(56, 20);
            this.selectToolStripButton.Text = "Select";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.Location = new System.Drawing.Point(821, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(26, 636);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // undoToolstripButton
            // 
            this.undoToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoToolstripButton.Image")));
            this.undoToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolstripButton.Name = "undoToolstripButton";
            this.undoToolstripButton.Size = new System.Drawing.Size(56, 20);
            this.undoToolstripButton.Text = "Undo";
            // 
            // redoToolstripButton
            // 
            this.redoToolstripButton.Enabled = false;
            this.redoToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoToolstripButton.Image")));
            this.redoToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolstripButton.Name = "redoToolstripButton";
            this.redoToolstripButton.Size = new System.Drawing.Size(56, 20);
            this.redoToolstripButton.Text = "Redo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(56, 6);
            // 
            // copyToolstripButton
            // 
            this.copyToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolstripButton.Image")));
            this.copyToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolstripButton.Name = "copyToolstripButton";
            this.copyToolstripButton.Size = new System.Drawing.Size(56, 20);
            this.copyToolstripButton.Text = "Copy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 661);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton selectToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolstripButton;
        private System.Windows.Forms.ToolStripButton undoToolstripButton;
        private System.Windows.Forms.ToolStripButton redoToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip3;
    }
}

