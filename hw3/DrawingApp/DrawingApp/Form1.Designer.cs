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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.undoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ghostButton1 = new System.Windows.Forms.ToolStripButton();
            this.ghostButton2 = new System.Windows.Forms.ToolStripButton();
            this.ghostButton3 = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(35, 22);
            this.newButton.Text = "New";
            this.newButton.ToolTipText = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
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
            this.saveToolStripButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripButton.Image")));
            this.loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadToolStripButton.Name = "loadToolStripButton";
            this.loadToolStripButton.Size = new System.Drawing.Size(37, 22);
            this.loadToolStripButton.Text = "Load";
            this.loadToolStripButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.saveToolStripButton,
            this.loadToolStripButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(847, 25);
            this.fileToolStrip.TabIndex = 5;
            this.fileToolStrip.Text = "toolStrip1";

            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(149, 25);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(581, 624);
            this.drawingPanel.TabIndex = 7;
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripButton,
            this.copyToolstripButton,
            this.undoToolstripButton,
            this.redoToolstripButton,
            this.toolStripSeparator1,
            this.ghostButton1,
            this.ghostButton2,
            this.ghostButton3});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 25);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Size = new System.Drawing.Size(59, 636);
            this.drawingToolStrip.TabIndex = 8;
            this.drawingToolStrip.Text = "toolStrip2";
            // 
            // selectToolStripButton
            // 
            this.selectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolStripButton.Image")));
            this.selectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolStripButton.Name = "selectToolStripButton";
            this.selectToolStripButton.Size = new System.Drawing.Size(56, 20);
            this.selectToolStripButton.Text = "Select";
            this.selectToolStripButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // copyToolstripButton
            // 
            this.copyToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolstripButton.Image")));
            this.copyToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolstripButton.Name = "copyToolstripButton";
            this.copyToolstripButton.Size = new System.Drawing.Size(56, 20);
            this.copyToolstripButton.Text = "Copy";
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
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.Location = new System.Drawing.Point(821, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(26, 636);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ghostButton1
            // 
            this.ghostButton1.CheckOnClick = true;
            this.ghostButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostButton1.Image = ((System.Drawing.Image)(resources.GetObject("ghostButton1.Image")));
            this.ghostButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostButton1.Name = "ghostButton1";
            this.ghostButton1.Size = new System.Drawing.Size(56, 34);
            this.ghostButton1.Text = "Ghost1";
            this.ghostButton1.ToolTipText = "ghostButton1";
            this.ghostButton1.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // ghostButton2
            // 
            this.ghostButton2.CheckOnClick = true;
            this.ghostButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostButton2.Image = ((System.Drawing.Image)(resources.GetObject("ghostButton2.Image")));
            this.ghostButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostButton2.Name = "ghostButton2";
            this.ghostButton2.Size = new System.Drawing.Size(56, 34);
            this.ghostButton2.Text = "Ghost2";
            this.ghostButton2.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // ghostButton3
            // 
            this.ghostButton3.CheckOnClick = true;
            this.ghostButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostButton3.Image = ((System.Drawing.Image)(resources.GetObject("ghostButton3.Image")));
            this.ghostButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostButton3.Name = "ghostButton3";
            this.ghostButton3.Size = new System.Drawing.Size(56, 34);
            this.ghostButton3.Text = "Ghost3";
            this.ghostButton3.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 661);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.fileToolStrip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton selectToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolstripButton;
        private System.Windows.Forms.ToolStripButton undoToolstripButton;
        private System.Windows.Forms.ToolStripButton redoToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripButton ghostButton1;
        private System.Windows.Forms.ToolStripButton ghostButton2;
        private System.Windows.Forms.ToolStripButton ghostButton3;
    }
}

