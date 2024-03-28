namespace SimulationRobotMovementAppWF
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameMainForm = new System.Windows.Forms.Label();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.EditingMapLabel = new System.Windows.Forms.Label();
            this.hexagonsPanel = new System.Windows.Forms.Panel();
            this.hexagonPanelApp1 = new SimulationRobotMovementAppWF.Classes.HexagonPanelApp();
            this.trackBarColums = new System.Windows.Forms.TrackBar();
            this.trackBarRows = new System.Windows.Forms.TrackBar();
            this.SaveButton = new System.Windows.Forms.Button();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.trackBarDiameter = new System.Windows.Forms.TrackBar();
            this.labelDiameter = new System.Windows.Forms.Label();
            this.labelClear = new System.Windows.Forms.Label();
            this.labelRandomMap = new System.Windows.Forms.Label();
            this.EditingMapButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.labelPathFinding = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelFinish = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.hexagonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDiameter)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.NameMainForm);
            this.headerPanel.Controls.Add(this.buttonMinimize);
            this.headerPanel.Controls.Add(this.buttonQuit);
            this.headerPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.headerPanel.Location = new System.Drawing.Point(-1, -2);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1483, 60);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // NameMainForm
            // 
            this.NameMainForm.AutoSize = true;
            this.NameMainForm.Font = new System.Drawing.Font("Nautilus Pompilius", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameMainForm.ForeColor = System.Drawing.Color.White;
            this.NameMainForm.Location = new System.Drawing.Point(186, 10);
            this.NameMainForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameMainForm.Name = "NameMainForm";
            this.NameMainForm.Size = new System.Drawing.Size(851, 39);
            this.NameMainForm.TabIndex = 1;
            this.NameMainForm.Text = "Моделирование системы планирования движения наземного робота";
            this.NameMainForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(1169, 4);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(50, 50);
            this.buttonMinimize.TabIndex = 2;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
            this.buttonQuit.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuit.Image")));
            this.buttonQuit.Location = new System.Drawing.Point(1223, 4);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(50, 50);
            this.buttonQuit.TabIndex = 1;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // EditingMapLabel
            // 
            this.EditingMapLabel.AutoSize = true;
            this.EditingMapLabel.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditingMapLabel.ForeColor = System.Drawing.Color.White;
            this.EditingMapLabel.Location = new System.Drawing.Point(3, 138);
            this.EditingMapLabel.MaximumSize = new System.Drawing.Size(100, 0);
            this.EditingMapLabel.Name = "EditingMapLabel";
            this.EditingMapLabel.Size = new System.Drawing.Size(97, 50);
            this.EditingMapLabel.TabIndex = 5;
            this.EditingMapLabel.Text = "Изменение карты";
            this.EditingMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hexagonsPanel
            // 
            this.hexagonsPanel.Controls.Add(this.hexagonPanelApp1);
            this.hexagonsPanel.Location = new System.Drawing.Point(98, 88);
            this.hexagonsPanel.Name = "hexagonsPanel";
            this.hexagonsPanel.Size = new System.Drawing.Size(1109, 637);
            this.hexagonsPanel.TabIndex = 8;
            // 
            // hexagonPanelApp1
            // 
            this.hexagonPanelApp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexagonPanelApp1.Location = new System.Drawing.Point(0, 0);
            this.hexagonPanelApp1.Name = "hexagonPanelApp1";
            this.hexagonPanelApp1.Size = new System.Drawing.Size(1109, 637);
            this.hexagonPanelApp1.TabIndex = 0;
            this.hexagonPanelApp1.Tag = "hexagonPanelApp";
            // 
            // trackBarColums
            // 
            this.trackBarColums.LargeChange = 1;
            this.trackBarColums.Location = new System.Drawing.Point(799, 763);
            this.trackBarColums.Maximum = 20;
            this.trackBarColums.Minimum = 1;
            this.trackBarColums.Name = "trackBarColums";
            this.trackBarColums.Size = new System.Drawing.Size(459, 45);
            this.trackBarColums.TabIndex = 9;
            this.trackBarColums.Value = 9;
            this.trackBarColums.Scroll += new System.EventHandler(this.trackBarColums_Scroll);
            // 
            // trackBarRows
            // 
            this.trackBarRows.LargeChange = 1;
            this.trackBarRows.Location = new System.Drawing.Point(1228, 126);
            this.trackBarRows.Maximum = 20;
            this.trackBarRows.Minimum = 1;
            this.trackBarRows.Name = "trackBarRows";
            this.trackBarRows.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarRows.Size = new System.Drawing.Size(45, 599);
            this.trackBarRows.TabIndex = 2;
            this.trackBarRows.Value = 6;
            this.trackBarRows.Scroll += new System.EventHandler(this.trackBarRows_Scroll);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(163)))), ((int)(((byte)(233)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(8)))), ((int)(((byte)(213)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(615, 731);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 31);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRows.ForeColor = System.Drawing.Color.White;
            this.labelRows.Location = new System.Drawing.Point(1204, 98);
            this.labelRows.MaximumSize = new System.Drawing.Size(100, 0);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(54, 25);
            this.labelRows.TabIndex = 11;
            this.labelRows.Text = "Rows";
            this.labelRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCols.ForeColor = System.Drawing.Color.White;
            this.labelCols.Location = new System.Drawing.Point(975, 741);
            this.labelCols.MaximumSize = new System.Drawing.Size(100, 0);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(43, 25);
            this.labelCols.TabIndex = 12;
            this.labelCols.Text = "Cols";
            this.labelCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarDiameter
            // 
            this.trackBarDiameter.LargeChange = 10;
            this.trackBarDiameter.Location = new System.Drawing.Point(260, 763);
            this.trackBarDiameter.Maximum = 100;
            this.trackBarDiameter.Minimum = 50;
            this.trackBarDiameter.Name = "trackBarDiameter";
            this.trackBarDiameter.Size = new System.Drawing.Size(216, 45);
            this.trackBarDiameter.SmallChange = 10;
            this.trackBarDiameter.TabIndex = 13;
            this.trackBarDiameter.TickFrequency = 10;
            this.trackBarDiameter.Value = 70;
            this.trackBarDiameter.Scroll += new System.EventHandler(this.trackBarDiameter_Scroll);
            // 
            // labelDiameter
            // 
            this.labelDiameter.AutoSize = true;
            this.labelDiameter.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiameter.ForeColor = System.Drawing.Color.White;
            this.labelDiameter.Location = new System.Drawing.Point(318, 737);
            this.labelDiameter.MaximumSize = new System.Drawing.Size(150, 0);
            this.labelDiameter.Name = "labelDiameter";
            this.labelDiameter.Size = new System.Drawing.Size(82, 25);
            this.labelDiameter.TabIndex = 14;
            this.labelDiameter.Text = "Diameter";
            this.labelDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClear
            // 
            this.labelClear.AutoSize = true;
            this.labelClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(163)))), ((int)(((byte)(233)))));
            this.labelClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClear.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClear.ForeColor = System.Drawing.Color.White;
            this.labelClear.Location = new System.Drawing.Point(3, 203);
            this.labelClear.MaximumSize = new System.Drawing.Size(100, 57);
            this.labelClear.Name = "labelClear";
            this.labelClear.Size = new System.Drawing.Size(94, 50);
            this.labelClear.TabIndex = 16;
            this.labelClear.Text = "Очистить карту";
            this.labelClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelClear_MouseClick);
            this.labelClear.MouseEnter += new System.EventHandler(this.labelClear_MouseEnter);
            this.labelClear.MouseLeave += new System.EventHandler(this.labelClear_MouseLeave);
            // 
            // labelRandomMap
            // 
            this.labelRandomMap.AutoSize = true;
            this.labelRandomMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(163)))), ((int)(((byte)(233)))));
            this.labelRandomMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRandomMap.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRandomMap.ForeColor = System.Drawing.Color.White;
            this.labelRandomMap.Location = new System.Drawing.Point(0, 274);
            this.labelRandomMap.MaximumSize = new System.Drawing.Size(100, 57);
            this.labelRandomMap.Name = "labelRandomMap";
            this.labelRandomMap.Size = new System.Drawing.Size(97, 50);
            this.labelRandomMap.TabIndex = 17;
            this.labelRandomMap.Text = "Случайная карта";
            this.labelRandomMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRandomMap.Click += new System.EventHandler(this.labelRandomMap_Click);
            this.labelRandomMap.MouseEnter += new System.EventHandler(this.labelRandomMap_MouseEnter);
            this.labelRandomMap.MouseLeave += new System.EventHandler(this.labelRandomMap_MouseLeave);
            // 
            // EditingMapButton
            // 
            this.EditingMapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditingMapButton.FlatAppearance.BorderSize = 0;
            this.EditingMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditingMapButton.Image = ((System.Drawing.Image)(resources.GetObject("EditingMapButton.Image")));
            this.EditingMapButton.Location = new System.Drawing.Point(14, 63);
            this.EditingMapButton.Name = "EditingMapButton";
            this.EditingMapButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EditingMapButton.Size = new System.Drawing.Size(70, 70);
            this.EditingMapButton.TabIndex = 6;
            this.EditingMapButton.UseVisualStyleBackColor = true;
            this.EditingMapButton.Click += new System.EventHandler(this.EditingMapButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(75)))));
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(12, 729);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(50, 50);
            this.BackButton.TabIndex = 3;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(75)))));
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(75)))));
            this.buttonStart.Image = global::SimulationRobotMovementAppWF.Properties.Resources.FlagStart;
            this.buttonStart.Location = new System.Drawing.Point(18, 352);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(70, 70);
            this.buttonStart.TabIndex = 20;
            this.buttonStart.Tag = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonStart_MouseDown);
            this.buttonStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonStart_MouseMove);
            this.buttonStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonStart_MouseUp);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(75)))));
            this.buttonFinish.Image = global::SimulationRobotMovementAppWF.Properties.Resources.FlagFinish;
            this.buttonFinish.Location = new System.Drawing.Point(14, 489);
            this.buttonFinish.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(70, 70);
            this.buttonFinish.TabIndex = 21;
            this.buttonFinish.Tag = "buttonFinish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFinish_MouseDown);
            this.buttonFinish.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonFinish_MouseMove);
            this.buttonFinish.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonFinish_MouseUp);
            // 
            // labelPathFinding
            // 
            this.labelPathFinding.AutoSize = true;
            this.labelPathFinding.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPathFinding.ForeColor = System.Drawing.Color.White;
            this.labelPathFinding.Location = new System.Drawing.Point(470, 63);
            this.labelPathFinding.MaximumSize = new System.Drawing.Size(1000, 0);
            this.labelPathFinding.Name = "labelPathFinding";
            this.labelPathFinding.Size = new System.Drawing.Size(147, 25);
            this.labelPathFinding.TabIndex = 22;
            this.labelPathFinding.Text = "... Поиск пути ...";
            this.labelPathFinding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStart.ForeColor = System.Drawing.Color.White;
            this.labelStart.Location = new System.Drawing.Point(15, 424);
            this.labelStart.MaximumSize = new System.Drawing.Size(1000, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(77, 50);
            this.labelStart.TabIndex = 23;
            this.labelStart.Text = "Флаг\r\nстарта";
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFinish
            // 
            this.labelFinish.AutoSize = true;
            this.labelFinish.Font = new System.Drawing.Font("Nautilus Pompilius", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFinish.ForeColor = System.Drawing.Color.White;
            this.labelFinish.Location = new System.Drawing.Point(13, 563);
            this.labelFinish.MaximumSize = new System.Drawing.Size(1000, 0);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(76, 50);
            this.labelFinish.TabIndex = 24;
            this.labelFinish.Text = "Флаг\r\nфиниша";
            this.labelFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.labelFinish);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelPathFinding);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelRandomMap);
            this.Controls.Add(this.labelClear);
            this.Controls.Add(this.labelDiameter);
            this.Controls.Add(this.trackBarDiameter);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.trackBarRows);
            this.Controls.Add(this.trackBarColums);
            this.Controls.Add(this.hexagonsPanel);
            this.Controls.Add(this.EditingMapButton);
            this.Controls.Add(this.EditingMapLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyUp);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.hexagonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDiameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NameMainForm;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label EditingMapLabel;
        private System.Windows.Forms.Button EditingMapButton;
        private System.Windows.Forms.Panel hexagonsPanel;
        private System.Windows.Forms.TrackBar trackBarColums;
        private System.Windows.Forms.TrackBar trackBarRows;
        private Classes.HexagonPanelApp hexagonPanelApp1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.TrackBar trackBarDiameter;
        private System.Windows.Forms.Label labelDiameter;
        private System.Windows.Forms.Label labelClear;
        private System.Windows.Forms.Label labelRandomMap;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Label labelPathFinding;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelFinish;
    }
}