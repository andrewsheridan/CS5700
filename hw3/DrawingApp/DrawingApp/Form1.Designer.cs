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
            this.saveLoadPanel = new System.Windows.Forms.Panel();
            this.loadFileComboBox = new System.Windows.Forms.ComboBox();
            this.saveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveLoadButton = new System.Windows.Forms.Button();
            this.saveLoadLabel = new System.Windows.Forms.Label();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.undoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ghostButton1 = new System.Windows.Forms.ToolStripButton();
            this.catButton = new System.Windows.Forms.ToolStripButton();
            this.ghostButton = new System.Windows.Forms.ToolStripButton();
            this.lanternButton = new System.Windows.Forms.ToolStripButton();
            this.spiderButton = new System.Windows.Forms.ToolStripButton();
            this.witchButton = new System.Windows.Forms.ToolStripButton();
            this.backgroundButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.blankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graveyardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hauntedHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.cancelSaveLoadButton = new System.Windows.Forms.Button();
            this.fileToolStrip.SuspendLayout();
            this.drawingPanel.SuspendLayout();
            this.saveLoadPanel.SuspendLayout();
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
            this.drawingPanel.Controls.Add(this.saveLoadPanel);
            this.drawingPanel.Location = new System.Drawing.Point(102, 28);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(733, 624);
            this.drawingPanel.TabIndex = 7;
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // saveLoadPanel
            // 
            this.saveLoadPanel.Controls.Add(this.cancelSaveLoadButton);
            this.saveLoadPanel.Controls.Add(this.loadFileComboBox);
            this.saveLoadPanel.Controls.Add(this.saveFileNameTextBox);
            this.saveLoadPanel.Controls.Add(this.saveLoadButton);
            this.saveLoadPanel.Controls.Add(this.saveLoadLabel);
            this.saveLoadPanel.Location = new System.Drawing.Point(241, 263);
            this.saveLoadPanel.Name = "saveLoadPanel";
            this.saveLoadPanel.Size = new System.Drawing.Size(232, 103);
            this.saveLoadPanel.TabIndex = 0;
            this.saveLoadPanel.Visible = false;
            // 
            // loadFileComboBox
            // 
            this.loadFileComboBox.FormattingEnabled = true;
            this.loadFileComboBox.Location = new System.Drawing.Point(15, 42);
            this.loadFileComboBox.Name = "loadFileComboBox";
            this.loadFileComboBox.Size = new System.Drawing.Size(200, 21);
            this.loadFileComboBox.TabIndex = 3;
            // 
            // saveFileNameTextBox
            // 
            this.saveFileNameTextBox.Location = new System.Drawing.Point(15, 43);
            this.saveFileNameTextBox.Name = "saveFileNameTextBox";
            this.saveFileNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.saveFileNameTextBox.TabIndex = 2;
            // 
            // saveLoadButton
            // 
            this.saveLoadButton.Location = new System.Drawing.Point(34, 69);
            this.saveLoadButton.Name = "saveLoadButton";
            this.saveLoadButton.Size = new System.Drawing.Size(75, 23);
            this.saveLoadButton.TabIndex = 1;
            this.saveLoadButton.Text = "Save";
            this.saveLoadButton.UseVisualStyleBackColor = true;
            this.saveLoadButton.Click += new System.EventHandler(this.saveLoadButton_Click);
            // 
            // saveLoadLabel
            // 
            this.saveLoadLabel.AutoSize = true;
            this.saveLoadLabel.Location = new System.Drawing.Point(76, 18);
            this.saveLoadLabel.Name = "saveLoadLabel";
            this.saveLoadLabel.Size = new System.Drawing.Size(78, 13);
            this.saveLoadLabel.TabIndex = 0;
            this.saveLoadLabel.Text = "Save To Cloud";
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripButton,
            this.moveButton,
            this.copyToolstripButton,
            this.undoToolstripButton,
            this.redoToolstripButton,
            this.removeButton,
            this.toolStripLabel1,
            this.scale,
            this.toolStripSeparator1,
            this.ghostButton1,
            this.catButton,
            this.ghostButton,
            this.lanternButton,
            this.spiderButton,
            this.witchButton,
            this.backgroundButton});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 25);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Size = new System.Drawing.Size(99, 636);
            this.drawingToolStrip.TabIndex = 8;
            this.drawingToolStrip.Text = "toolStrip2";
            // 
            // selectToolStripButton
            // 
            this.selectToolStripButton.CheckOnClick = true;
            this.selectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolStripButton.Image")));
            this.selectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolStripButton.Name = "selectToolStripButton";
            this.selectToolStripButton.Size = new System.Drawing.Size(96, 34);
            this.selectToolStripButton.Text = "Select";
            this.selectToolStripButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.CheckOnClick = true;
            this.moveButton.Image = ((System.Drawing.Image)(resources.GetObject("moveButton.Image")));
            this.moveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(96, 34);
            this.moveButton.Text = "Move";
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // copyToolstripButton
            // 
            this.copyToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolstripButton.Image")));
            this.copyToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolstripButton.Name = "copyToolstripButton";
            this.copyToolstripButton.Size = new System.Drawing.Size(96, 34);
            this.copyToolstripButton.Text = "Copy";
            this.copyToolstripButton.Click += new System.EventHandler(this.copyToolstripButton_Click);
            // 
            // undoToolstripButton
            // 
            this.undoToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoToolstripButton.Image")));
            this.undoToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolstripButton.Name = "undoToolstripButton";
            this.undoToolstripButton.Size = new System.Drawing.Size(96, 34);
            this.undoToolstripButton.Text = "Undo";
            this.undoToolstripButton.Click += new System.EventHandler(this.undoToolstripButton_Click);
            // 
            // redoToolstripButton
            // 
            this.redoToolstripButton.Enabled = false;
            this.redoToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoToolstripButton.Image")));
            this.redoToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolstripButton.Name = "redoToolstripButton";
            this.redoToolstripButton.Size = new System.Drawing.Size(96, 34);
            this.redoToolstripButton.Text = "Redo";
            this.redoToolstripButton.Visible = false;
            // 
            // removeButton
            // 
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(96, 34);
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 15);
            this.toolStripLabel1.Text = "Scale (0.01 to 10)";
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(96, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scale_KeyPress);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(96, 6);
            // 
            // ghostButton1
            // 
            this.ghostButton1.CheckOnClick = true;
            this.ghostButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostButton1.Image = ((System.Drawing.Image)(resources.GetObject("ghostButton1.Image")));
            this.ghostButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostButton1.Name = "ghostButton1";
            this.ghostButton1.Size = new System.Drawing.Size(96, 34);
            this.ghostButton1.Text = "bat";
            this.ghostButton1.ToolTipText = "batButton";
            this.ghostButton1.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // catButton
            // 
            this.catButton.CheckOnClick = true;
            this.catButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.catButton.Image = ((System.Drawing.Image)(resources.GetObject("catButton.Image")));
            this.catButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.catButton.Name = "catButton";
            this.catButton.Size = new System.Drawing.Size(96, 34);
            this.catButton.Text = "cat";
            this.catButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // ghostButton
            // 
            this.ghostButton.CheckOnClick = true;
            this.ghostButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostButton.Image = ((System.Drawing.Image)(resources.GetObject("ghostButton.Image")));
            this.ghostButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostButton.Name = "ghostButton";
            this.ghostButton.Size = new System.Drawing.Size(96, 34);
            this.ghostButton.Text = "ghost";
            this.ghostButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // lanternButton
            // 
            this.lanternButton.CheckOnClick = true;
            this.lanternButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lanternButton.Image = ((System.Drawing.Image)(resources.GetObject("lanternButton.Image")));
            this.lanternButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lanternButton.Name = "lanternButton";
            this.lanternButton.Size = new System.Drawing.Size(96, 34);
            this.lanternButton.Text = "lantern";
            this.lanternButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // spiderButton
            // 
            this.spiderButton.CheckOnClick = true;
            this.spiderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.spiderButton.Image = ((System.Drawing.Image)(resources.GetObject("spiderButton.Image")));
            this.spiderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spiderButton.Name = "spiderButton";
            this.spiderButton.Size = new System.Drawing.Size(96, 34);
            this.spiderButton.Text = "spider";
            this.spiderButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // witchButton
            // 
            this.witchButton.CheckOnClick = true;
            this.witchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.witchButton.Image = ((System.Drawing.Image)(resources.GetObject("witchButton.Image")));
            this.witchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.witchButton.Name = "witchButton";
            this.witchButton.Size = new System.Drawing.Size(96, 34);
            this.witchButton.Text = "witch";
            this.witchButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // backgroundButton
            // 
            this.backgroundButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.backgroundButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankToolStripMenuItem,
            this.graveyardToolStripMenuItem,
            this.hauntedHouseToolStripMenuItem});
            this.backgroundButton.Image = ((System.Drawing.Image)(resources.GetObject("backgroundButton.Image")));
            this.backgroundButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(96, 19);
            this.backgroundButton.Text = "Background";
            // 
            // blankToolStripMenuItem
            // 
            this.blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            this.blankToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.blankToolStripMenuItem.Text = "Blank";
            this.blankToolStripMenuItem.Click += new System.EventHandler(this.blankToolStripMenuItem_Click);
            // 
            // graveyardToolStripMenuItem
            // 
            this.graveyardToolStripMenuItem.Name = "graveyardToolStripMenuItem";
            this.graveyardToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.graveyardToolStripMenuItem.Text = "Graveyard";
            this.graveyardToolStripMenuItem.Click += new System.EventHandler(this.graveyardToolStripMenuItem_Click);
            // 
            // hauntedHouseToolStripMenuItem
            // 
            this.hauntedHouseToolStripMenuItem.Name = "hauntedHouseToolStripMenuItem";
            this.hauntedHouseToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.hauntedHouseToolStripMenuItem.Text = "Haunted House";
            this.hauntedHouseToolStripMenuItem.Click += new System.EventHandler(this.hauntedHouseToolStripMenuItem_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // cancelSaveLoadButton
            // 
            this.cancelSaveLoadButton.Location = new System.Drawing.Point(128, 69);
            this.cancelSaveLoadButton.Name = "cancelSaveLoadButton";
            this.cancelSaveLoadButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSaveLoadButton.TabIndex = 4;
            this.cancelSaveLoadButton.Text = "Cancel";
            this.cancelSaveLoadButton.UseVisualStyleBackColor = true;
            this.cancelSaveLoadButton.Click += new System.EventHandler(this.cancelSaveLoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 661);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingPanel.ResumeLayout(false);
            this.saveLoadPanel.ResumeLayout(false);
            this.saveLoadPanel.PerformLayout();
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
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripButton ghostButton1;
        private System.Windows.Forms.ToolStripButton catButton;
        private System.Windows.Forms.ToolStripButton ghostButton;
        private System.Windows.Forms.ToolStripButton lanternButton;
        private System.Windows.Forms.ToolStripButton spiderButton;
        private System.Windows.Forms.ToolStripButton witchButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripButton moveButton;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.ToolStripDropDownButton backgroundButton;
        private System.Windows.Forms.ToolStripMenuItem blankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graveyardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hauntedHouseToolStripMenuItem;
        private System.Windows.Forms.Panel saveLoadPanel;
        private System.Windows.Forms.TextBox saveFileNameTextBox;
        private System.Windows.Forms.Button saveLoadButton;
        private System.Windows.Forms.Label saveLoadLabel;
        private System.Windows.Forms.ComboBox loadFileComboBox;
        private System.Windows.Forms.Button cancelSaveLoadButton;
    }
}

