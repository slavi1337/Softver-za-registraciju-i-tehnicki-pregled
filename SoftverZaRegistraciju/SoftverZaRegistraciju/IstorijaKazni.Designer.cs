namespace SoftverZaRegistraciju
{
    partial class IstorijaKazni
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button4 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 46);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1058, 268);
            dataGridView1.TabIndex = 22;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(360, 9);
            label1.Name = "label1";
            label1.Size = new Size(323, 34);
            label1.TabIndex = 21;
            label1.Text = "Istorija vlastitih kazni";
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(125, 16);
            button1.Name = "button1";
            button1.Size = new Size(127, 66);
            button1.TabIndex = 23;
            button1.Text = "Neplacene kazne";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 16);
            label2.Name = "label2";
            label2.Size = new Size(114, 32);
            label2.TabIndex = 24;
            label2.Text = "FILTER";
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(125, 105);
            button2.Name = "button2";
            button2.Size = new Size(127, 64);
            button2.TabIndex = 25;
            button2.Text = "Sve kazne";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = SystemColors.Highlight;
            button3.Location = new Point(580, 15);
            button3.Name = "button3";
            button3.Size = new Size(112, 64);
            button3.TabIndex = 26;
            button3.Text = "Plati kaznu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(725, 15);
            label3.Name = "label3";
            label3.Size = new Size(315, 20);
            label3.TabIndex = 27;
            label3.Text = "Mozete platiti kaznu na sledeci nacin:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(725, 45);
            label4.Name = "label4";
            label4.Size = new Size(275, 15);
            label4.TabIndex = 28;
            label4.Text = "1. Selektujete red sa neplacenom kaznom";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(725, 64);
            label5.Name = "label5";
            label5.Size = new Size(219, 15);
            label5.TabIndex = 29;
            label5.Text = "2. Pritisnete dugme \"Plati kaznu\"";
            // 
            // label6
            // 
            label6.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(725, 82);
            label6.Name = "label6";
            label6.Size = new Size(285, 38);
            label6.TabIndex = 30;
            label6.Text = "3. Aplikacija ce Vas odvesti na drugu formu      u kojoj unosite podatke o kartici";
            // 
            // label7
            // 
            label7.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(725, 116);
            label7.Name = "label7";
            label7.Size = new Size(297, 56);
            label7.TabIndex = 31;
            label7.Text = "4. Pritisnite dugme \"Plati\", nakon uspjesnog         placanja kazna ce postati placena i iznos          ce Vam biti skinut sa kartice";
            // 
            // button4
            // 
            button4.ForeColor = SystemColors.Highlight;
            button4.Location = new Point(360, 16);
            button4.Name = "button4";
            button4.Size = new Size(112, 66);
            button4.TabIndex = 32;
            button4.Text = "Osvjezi";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 322);
            panel1.Name = "panel1";
            panel1.Size = new Size(1092, 185);
            panel1.TabIndex = 33;
            // 
            // IstorijaKazni
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1082, 503);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "IstorijaKazni";
            Text = "Korisnicki Panel - Istorija kazni";
            FormClosing += IstorijaKazni_FormClosing;
            Load += IstorijaKazni_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button4;
        private Panel panel1;
    }
}