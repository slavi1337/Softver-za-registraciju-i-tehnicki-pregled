namespace SoftverZaRegistraciju
{
    partial class UserForm
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
            btnCalc = new Button();
            btnNotif = new Button();
            button5 = new Button();
            button3 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(472, 43);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(146, 68);
            button1.TabIndex = 15;
            button1.Text = "Istorija kazni";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCalc
            // 
            btnCalc.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalc.ForeColor = SystemColors.Highlight;
            btnCalc.Location = new Point(688, 43);
            btnCalc.Margin = new Padding(4, 3, 4, 3);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(146, 68);
            btnCalc.TabIndex = 14;
            btnCalc.Text = "Kalkulator registracije";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // btnNotif
            // 
            btnNotif.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNotif.ForeColor = SystemColors.Highlight;
            btnNotif.Location = new Point(904, 43);
            btnNotif.Margin = new Padding(4, 3, 4, 3);
            btnNotif.Name = "btnNotif";
            btnNotif.Size = new Size(146, 68);
            btnNotif.TabIndex = 13;
            btnNotif.Text = "Podesavanje obavjestenja";
            btnNotif.UseVisualStyleBackColor = true;
            btnNotif.Click += btnNotif_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.Highlight;
            button5.Location = new Point(13, 18);
            button5.Name = "button5";
            button5.Size = new Size(94, 57);
            button5.TabIndex = 17;
            button5.Text = "Promijeni sifru";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.Highlight;
            button3.Location = new Point(13, 99);
            button3.Name = "button3";
            button3.Size = new Size(94, 36);
            button3.TabIndex = 16;
            button3.Text = "Odjava";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(237, 9);
            label1.Name = "label1";
            label1.Size = new Size(558, 34);
            label1.TabIndex = 19;
            label1.Text = "Informacije o vlastitim registracijama";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 55);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1058, 268);
            dataGridView1.TabIndex = 20;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnCalc);
            panel1.Controls.Add(btnNotif);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button5);
            panel1.Location = new Point(-1, 356);
            panel1.Name = "panel1";
            panel1.Size = new Size(1086, 152);
            panel1.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(260, 18);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 19;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(126, 18);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 18;
            label2.Text = "Korisnicko ime:";
            // 
            // UserForm
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
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Korisnicki Panel";
            FormClosing += UserForm_FormClosing;
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnCalc;
        private Button btnNotif;
        private Button button5;
        private Button button3;
        private Label label1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label2;
        private Label label3;
    }
}