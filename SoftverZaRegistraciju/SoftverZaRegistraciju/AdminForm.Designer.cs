namespace SoftverZaRegistraciju
{
    partial class AdminForm
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label3 = new Label();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(219, 319);
            button1.Name = "button1";
            button1.Size = new Size(124, 55);
            button1.TabIndex = 0;
            button1.Text = "Kreiraj nalog";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(219, 378);
            button2.Name = "button2";
            button2.Size = new Size(124, 55);
            button2.TabIndex = 1;
            button2.Text = "Brisi nalog";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = SystemColors.Highlight;
            button3.Location = new Point(12, 455);
            button3.Name = "button3";
            button3.Size = new Size(94, 36);
            button3.TabIndex = 2;
            button3.Text = "Odjava";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(347, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(723, 479);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // button4
            // 
            button4.ForeColor = SystemColors.Highlight;
            button4.Location = new Point(219, 436);
            button4.Name = "button4";
            button4.Size = new Size(124, 55);
            button4.TabIndex = 4;
            button4.Text = "Osvjezi";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.Highlight;
            button5.Location = new Point(12, 377);
            button5.Name = "button5";
            button5.Size = new Size(94, 57);
            button5.TabIndex = 5;
            button5.Text = "Promijeni sifru";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 6;
            label1.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(46, 35);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // button6
            // 
            button6.ForeColor = SystemColors.Highlight;
            button6.Location = new Point(219, 38);
            button6.Name = "button6";
            button6.Size = new Size(122, 55);
            button6.TabIndex = 8;
            button6.Text = "Admin";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.ForeColor = SystemColors.Highlight;
            button7.Location = new Point(219, 95);
            button7.Name = "button7";
            button7.Size = new Size(122, 55);
            button7.TabIndex = 9;
            button7.Text = "Radnik";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.ForeColor = SystemColors.Highlight;
            button8.Location = new Point(219, 152);
            button8.Name = "button8";
            button8.Size = new Size(122, 56);
            button8.TabIndex = 10;
            button8.Text = "Obicni korisnik";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(219, 3);
            label3.Name = "label3";
            label3.Size = new Size(114, 32);
            label3.TabIndex = 11;
            label3.Text = "FILTER";
            // 
            // button9
            // 
            button9.ForeColor = SystemColors.Highlight;
            button9.Location = new Point(219, 210);
            button9.Name = "button9";
            button9.Size = new Size(122, 56);
            button9.TabIndex = 12;
            button9.Text = "Svi korisnici";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1082, 503);
            Controls.Add(button9);
            Controls.Add(label3);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Panel";
            FormClosing += AdminForm_FormClosing;
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button5;
        private Label label1;
        private Label label2;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label3;
        private Button button9;
    }
}