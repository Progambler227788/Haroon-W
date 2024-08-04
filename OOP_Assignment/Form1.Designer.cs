namespace OOP_Assignment
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataShow = new System.Windows.Forms.DataGridView();
            this.Students = new System.Windows.Forms.ComboBox();
            this.Lecturers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.OrangeRed;
            this.button1.Location = new System.Drawing.Point(939, 273);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Insert Student";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.OrangeRed;
            this.button2.Location = new System.Drawing.Point(939, 361);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Insert Lecturer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.comboBox1.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Red;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1055, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(311, 46);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataShow
            // 
            this.dataShow.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataShow.Location = new System.Drawing.Point(0, 0);
            this.dataShow.Name = "dataShow";
            this.dataShow.RowHeadersWidth = 62;
            this.dataShow.RowTemplate.Height = 28;
            this.dataShow.Size = new System.Drawing.Size(900, 472);
            this.dataShow.TabIndex = 6;
            // 
            // Students
            // 
            this.Students.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Students.BackColor = System.Drawing.Color.DarkCyan;
            this.Students.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Students.ForeColor = System.Drawing.Color.Red;
            this.Students.FormattingEnabled = true;
            this.Students.Items.AddRange(new object[] {
            "Students of Bsc in Computing",
            "Students of Msc in Business",
            "Students of Bsc in Psychology",
            "Students of Diploma in mathematics"});
            this.Students.Location = new System.Drawing.Point(1055, 91);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(311, 46);
            this.Students.TabIndex = 7;
            this.Students.SelectedIndexChanged += new System.EventHandler(this.Students_SelectedIndexChanged);
            // 
            // Lecturers
            // 
            this.Lecturers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lecturers.BackColor = System.Drawing.Color.DarkCyan;
            this.Lecturers.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lecturers.ForeColor = System.Drawing.Color.Red;
            this.Lecturers.FormattingEnabled = true;
            this.Lecturers.Items.AddRange(new object[] {
            "Lecturers in Programming",
            "Lecturers in Business",
            "Lecturers in Psychology",
            "Lecturers in Mathematics"});
            this.Lecturers.Location = new System.Drawing.Point(1055, 163);
            this.Lecturers.Name = "Lecturers";
            this.Lecturers.Size = new System.Drawing.Size(311, 46);
            this.Lecturers.TabIndex = 8;
            this.Lecturers.SelectedIndexChanged += new System.EventHandler(this.Lecturers_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1366, 472);
            this.Controls.Add(this.Lecturers);
            this.Controls.Add(this.Students);
            this.Controls.Add(this.dataShow);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Brown;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataShow;
        private System.Windows.Forms.ComboBox Students;
        private System.Windows.Forms.ComboBox Lecturers;
    }
}

