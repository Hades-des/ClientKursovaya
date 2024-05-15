namespace WinFormsAppKursovaya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFighters = new System.Windows.Forms.Button();
            this.buttonMatch = new System.Windows.Forms.Button();
            this.buttonWeight = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.buttonTournament = new System.Windows.Forms.Button();
            this.buttonTrainer = new System.Windows.Forms.Button();
            this.buttonVictory = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grid.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AutoSize = true;
            this.grid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grid.ColumnCount = 2;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.80428F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.19572F));
            this.grid.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.grid.Controls.Add(this.button4, 0, 0);
            this.grid.Controls.Add(this.button13, 0, 2);
            this.grid.Controls.Add(this.label1, 1, 0);
            this.grid.Controls.Add(this.flowLayoutPanelEdit, 1, 2);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowCount = 3;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.45292F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.54709F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.grid.Size = new System.Drawing.Size(888, 612);
            this.grid.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.flowLayoutPanel1.Controls.Add(this.buttonFighters);
            this.flowLayoutPanel1.Controls.Add(this.buttonMatch);
            this.flowLayoutPanel1.Controls.Add(this.buttonWeight);
            this.flowLayoutPanel1.Controls.Add(this.buttonHistory);
            this.flowLayoutPanel1.Controls.Add(this.buttonTournament);
            this.flowLayoutPanel1.Controls.Add(this.buttonTrainer);
            this.flowLayoutPanel1.Controls.Add(this.buttonVictory);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 77);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 476);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonFighters
            // 
            this.buttonFighters.AutoSize = true;
            this.buttonFighters.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFighters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonFighters.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonFighters.Location = new System.Drawing.Point(3, 3);
            this.buttonFighters.Name = "buttonFighters";
            this.buttonFighters.Size = new System.Drawing.Size(271, 50);
            this.buttonFighters.TabIndex = 1;
            this.buttonFighters.Text = "Спортсмены";
            this.buttonFighters.UseVisualStyleBackColor = false;
            this.buttonFighters.Click += new System.EventHandler(this.buttonFighter_Click);
            // 
            // buttonMatch
            // 
            this.buttonMatch.AutoSize = true;
            this.buttonMatch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonMatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonMatch.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonMatch.Location = new System.Drawing.Point(3, 59);
            this.buttonMatch.Name = "buttonMatch";
            this.buttonMatch.Size = new System.Drawing.Size(271, 53);
            this.buttonMatch.TabIndex = 2;
            this.buttonMatch.Text = "Поединки";
            this.buttonMatch.UseVisualStyleBackColor = false;
            this.buttonMatch.Click += new System.EventHandler(this.buttonMatch_Click);
            // 
            // buttonWeight
            // 
            this.buttonWeight.AutoSize = true;
            this.buttonWeight.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonWeight.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonWeight.Location = new System.Drawing.Point(3, 118);
            this.buttonWeight.Name = "buttonWeight";
            this.buttonWeight.Size = new System.Drawing.Size(271, 47);
            this.buttonWeight.TabIndex = 0;
            this.buttonWeight.Text = "Весовые категории";
            this.buttonWeight.UseVisualStyleBackColor = false;
            this.buttonWeight.Click += new System.EventHandler(this.buttonWeight_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.AutoSize = true;
            this.buttonHistory.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonHistory.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonHistory.Location = new System.Drawing.Point(3, 171);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(271, 51);
            this.buttonHistory.TabIndex = 3;
            this.buttonHistory.Text = "История боев";
            this.buttonHistory.UseVisualStyleBackColor = false;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonTournament
            // 
            this.buttonTournament.AutoSize = true;
            this.buttonTournament.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonTournament.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTournament.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonTournament.Location = new System.Drawing.Point(3, 228);
            this.buttonTournament.Name = "buttonTournament";
            this.buttonTournament.Size = new System.Drawing.Size(271, 53);
            this.buttonTournament.TabIndex = 4;
            this.buttonTournament.Text = "Турнир";
            this.buttonTournament.UseVisualStyleBackColor = false;
            this.buttonTournament.Click += new System.EventHandler(this.buttonTournament_Click);
            // 
            // buttonTrainer
            // 
            this.buttonTrainer.AutoSize = true;
            this.buttonTrainer.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonTrainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTrainer.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonTrainer.Location = new System.Drawing.Point(3, 287);
            this.buttonTrainer.Name = "buttonTrainer";
            this.buttonTrainer.Size = new System.Drawing.Size(271, 51);
            this.buttonTrainer.TabIndex = 5;
            this.buttonTrainer.Text = "Тренер";
            this.buttonTrainer.UseVisualStyleBackColor = false;
            this.buttonTrainer.Click += new System.EventHandler(this.buttonTrainer_Click);
            // 
            // buttonVictory
            // 
            this.buttonVictory.AutoSize = true;
            this.buttonVictory.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonVictory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonVictory.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonVictory.Location = new System.Drawing.Point(3, 344);
            this.buttonVictory.Name = "buttonVictory";
            this.buttonVictory.Size = new System.Drawing.Size(271, 54);
            this.buttonVictory.TabIndex = 6;
            this.buttonVictory.Text = "Методы победы";
            this.buttonVictory.UseVisualStyleBackColor = false;
            this.buttonVictory.Click += new System.EventHandler(this.buttonVictory_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(276, 68);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button13.Location = new System.Drawing.Point(3, 559);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(276, 50);
            this.button13.TabIndex = 8;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(285, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 74);
            this.label1.TabIndex = 9;
            this.label1.Text = "ОРГАНИЗАЦИЯ ТУРНИРОВ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelEdit
            // 
            this.flowLayoutPanelEdit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.flowLayoutPanelEdit.Controls.Add(this.button1);
            this.flowLayoutPanelEdit.Controls.Add(this.button2);
            this.flowLayoutPanelEdit.Location = new System.Drawing.Point(285, 559);
            this.flowLayoutPanelEdit.Name = "flowLayoutPanelEdit";
            this.flowLayoutPanelEdit.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanelEdit.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(888, 612);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grid.ResumeLayout(false);
            this.grid.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonWeight;
        private System.Windows.Forms.Button buttonFighters;
        private System.Windows.Forms.Button buttonMatch;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button buttonTournament;
        private System.Windows.Forms.Button buttonTrainer;
        private System.Windows.Forms.Button buttonVictory;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

