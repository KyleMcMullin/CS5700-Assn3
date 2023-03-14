namespace Forests
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scaleLabel = new System.Windows.Forms.ToolStripLabel();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.moveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.resizeStripButton = new System.Windows.Forms.ToolStripButton();
            this.emote01Button = new System.Windows.Forms.ToolStripButton();
            this.emote02Button = new System.Windows.Forms.ToolStripButton();
            this.emote03Button = new System.Windows.Forms.ToolStripButton();
            this.emote04Button = new System.Windows.Forms.ToolStripButton();
            this.emote05Button = new System.Windows.Forms.ToolStripButton();
            this.emote06Button = new System.Windows.Forms.ToolStripButton();
            this.emote07Button = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.labelBoxButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.exportButton = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(96, 67);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(818, 755);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.AutoSize = false;
            this.fileToolStrip.BackColor = System.Drawing.Color.CadetBlue;
            this.fileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fileToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.deleteButton,
            this.undoButton,
            this.redoButton,
            this.exportButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(914, 64);
            this.fileToolStrip.TabIndex = 2;
            this.fileToolStrip.Text = "toolStrip1";
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.PowderBlue;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.moveToolStripButton,
            this.copyButton,
            this.toolStripSeparator2,
            this.scaleLabel,
            this.scale,
            this.resizeStripButton,
            this.toolStripSeparator1,
            this.emote01Button,
            this.emote02Button,
            this.emote03Button,
            this.emote04Button,
            this.emote05Button,
            this.emote06Button,
            this.emote07Button,
            this.lineButton,
            this.labelBoxButton});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 64);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(93, 770);
            this.drawingToolStrip.TabIndex = 3;
            this.drawingToolStrip.Text = "Tools";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(90, 6);
            // 
            // scaleLabel
            // 
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(90, 15);
            this.scaleLabel.Text = "Scale (.01 to 99):";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.scale.Name = "scale";
            this.scale.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.scale.Size = new System.Drawing.Size(70, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
            // 
            // backgroundButton
            // 
            this.backgroundButton.Location = new System.Drawing.Point(396, 12);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(75, 34);
            this.backgroundButton.TabIndex = 4;
            this.backgroundButton.Text = "Change Background";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // pointerButton
            // 
            this.pointerButton.AutoSize = false;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(61, 50);
            this.pointerButton.Text = "pointerButton";
            this.pointerButton.ToolTipText = "Pointer Tool";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // moveToolStripButton
            // 
            this.moveToolStripButton.AutoSize = false;
            this.moveToolStripButton.CheckOnClick = true;
            this.moveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("moveToolStripButton.Image")));
            this.moveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveToolStripButton.Name = "moveToolStripButton";
            this.moveToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.moveToolStripButton.Text = "MoveTool";
            this.moveToolStripButton.ToolTipText = "Move Tool";
            this.moveToolStripButton.Click += new System.EventHandler(this.moveToolStripButton_Click);
            // 
            // resizeStripButton
            // 
            this.resizeStripButton.BackColor = System.Drawing.Color.Silver;
            this.resizeStripButton.CheckOnClick = true;
            this.resizeStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resizeStripButton.Image = ((System.Drawing.Image)(resources.GetObject("resizeStripButton.Image")));
            this.resizeStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resizeStripButton.Name = "resizeStripButton";
            this.resizeStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.resizeStripButton.Size = new System.Drawing.Size(90, 19);
            this.resizeStripButton.Text = "Resize Selected";
            this.resizeStripButton.Click += new System.EventHandler(this.resizeStripButton_Click);
            // 
            // emote01Button
            // 
            this.emote01Button.AutoSize = false;
            this.emote01Button.CheckOnClick = true;
            this.emote01Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote01Button.Image = ((System.Drawing.Image)(resources.GetObject("emote01Button.Image")));
            this.emote01Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote01Button.Name = "emote01Button";
            this.emote01Button.Size = new System.Drawing.Size(61, 61);
            this.emote01Button.Text = "Emote-01";
            this.emote01Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote02Button
            // 
            this.emote02Button.AutoSize = false;
            this.emote02Button.CheckOnClick = true;
            this.emote02Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote02Button.Image = global::Forests.Properties.Resources.Emote_02;
            this.emote02Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote02Button.Name = "emote02Button";
            this.emote02Button.Size = new System.Drawing.Size(61, 61);
            this.emote02Button.Text = "Emote-02";
            this.emote02Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote03Button
            // 
            this.emote03Button.AutoSize = false;
            this.emote03Button.CheckOnClick = true;
            this.emote03Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote03Button.Image = global::Forests.Properties.Resources.Emote_03;
            this.emote03Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote03Button.Name = "emote03Button";
            this.emote03Button.Size = new System.Drawing.Size(61, 61);
            this.emote03Button.Text = "Emote-03";
            this.emote03Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote04Button
            // 
            this.emote04Button.CheckOnClick = true;
            this.emote04Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote04Button.Image = global::Forests.Properties.Resources.Emote_04;
            this.emote04Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote04Button.Name = "emote04Button";
            this.emote04Button.Size = new System.Drawing.Size(90, 68);
            this.emote04Button.Text = "Emote-04";
            this.emote04Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote05Button
            // 
            this.emote05Button.CheckOnClick = true;
            this.emote05Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote05Button.Image = global::Forests.Properties.Resources.Emote_05;
            this.emote05Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote05Button.Name = "emote05Button";
            this.emote05Button.Size = new System.Drawing.Size(90, 68);
            this.emote05Button.Text = "Emote-05";
            this.emote05Button.ToolTipText = "Emote-05";
            this.emote05Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote06Button
            // 
            this.emote06Button.CheckOnClick = true;
            this.emote06Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote06Button.Image = global::Forests.Properties.Resources.Emote_06;
            this.emote06Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote06Button.Name = "emote06Button";
            this.emote06Button.Size = new System.Drawing.Size(90, 68);
            this.emote06Button.Text = "Emote-06";
            this.emote06Button.ToolTipText = "Emote-06";
            this.emote06Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // emote07Button
            // 
            this.emote07Button.CheckOnClick = true;
            this.emote07Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emote07Button.Image = global::Forests.Properties.Resources.Emote_07;
            this.emote07Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emote07Button.Name = "emote07Button";
            this.emote07Button.Size = new System.Drawing.Size(90, 68);
            this.emote07Button.Text = "Emote-07";
            this.emote07Button.ToolTipText = "Emote-07";
            this.emote07Button.Click += new System.EventHandler(this.emoteButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = false;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(90, 24);
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // labelBoxButton
            // 
            this.labelBoxButton.AutoSize = false;
            this.labelBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.labelBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("labelBoxButton.Image")));
            this.labelBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labelBoxButton.Name = "labelBoxButton";
            this.labelBoxButton.Size = new System.Drawing.Size(90, 40);
            this.labelBoxButton.Text = "Label Box";
            this.labelBoxButton.Click += new System.EventHandler(this.labelBoxButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.AutoSize = false;
            this.copyButton.CheckOnClick = true;
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Image = global::Forests.Properties.Resources.copyIcon;
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(61, 50);
            this.copyButton.Text = "copyButton";
            this.copyButton.ToolTipText = "Copy Tool";
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // newButton
            // 
            this.newButton.AutoSize = false;
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(61, 61);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.AutoSize = false;
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(61, 61);
            this.openButton.Text = "Open Drawing";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = false;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 61);
            this.saveButton.Text = "Save Drawing";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 61);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 61);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 61);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportButton.Image = global::Forests.Properties.Resources.exportIcon;
            this.exportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(36, 61);
            this.exportButton.Text = "exportButton";
            this.exportButton.ToolTipText = "Export";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(914, 834);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Forest Drawing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton emote01Button;
        private System.Windows.Forms.ToolStripButton emote02Button;
        private System.Windows.Forms.ToolStripButton emote03Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton emote04Button;
        private System.Windows.Forms.ToolStripButton emote05Button;
        private System.Windows.Forms.ToolStripButton emote06Button;
        private System.Windows.Forms.ToolStripButton emote07Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel scaleLabel;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton labelBoxButton;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.ToolStripButton moveToolStripButton;
        private System.Windows.Forms.ToolStripButton resizeStripButton;
        private System.Windows.Forms.ToolStripButton exportButton;
        private System.Windows.Forms.ToolStripButton copyButton;
    }
}

