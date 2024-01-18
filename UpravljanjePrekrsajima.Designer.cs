namespace SoftverZaRegistraciju
{
    partial class UpravljanjePrekrsajima
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
            panel1 = new Panel();
            label3 = new Label();
            textBox1 = new TextBox();
            button5 = new Button();
            button7 = new Button();
            button1 = new Button();
            button6 = new Button();
            label2 = new Label();
            button3 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(0, 320);
            panel1.Name = "panel1";
            panel1.Size = new Size(1092, 185);
            panel1.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(406, 27);
            label3.Name = "label3";
            label3.Size = new Size(68, 23);
            label3.TabIndex = 43;
            label3.Text = "JMBG";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(357, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 31);
            textBox1.TabIndex = 42;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ControlLight;
            button5.ForeColor = SystemColors.Highlight;
            button5.Location = new Point(11, 127);
            button5.Name = "button5";
            button5.Size = new Size(100, 46);
            button5.TabIndex = 41;
            button5.Text = "Nazad";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(755, 20);
            button7.Name = "button7";
            button7.Size = new Size(112, 66);
            button7.TabIndex = 36;
            button7.Text = "Izbrisi prekrsaj";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(755, 107);
            button1.Name = "button1";
            button1.Size = new Size(112, 66);
            button1.TabIndex = 40;
            button1.Text = "Osvjezi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button6
            // 
            button6.Location = new Point(883, 20);
            button6.Name = "button6";
            button6.Size = new Size(112, 66);
            button6.TabIndex = 35;
            button6.Text = "Dodaj prekrsaj";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(91, 20);
            label2.Name = "label2";
            label2.Size = new Size(114, 32);
            label2.TabIndex = 38;
            label2.Text = "FILTER";
            // 
            // button3
            // 
            button3.ForeColor = SystemColors.Highlight;
            button3.Location = new Point(211, 20);
            button3.Name = "button3";
            button3.Size = new Size(127, 66);
            button3.TabIndex = 37;
            button3.Text = "Filtriraj po JMBG";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(406, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 34);
            label1.TabIndex = 39;
            label1.Text = "Pregled prekrsaja";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 46);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1058, 268);
            dataGridView1.TabIndex = 38;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // UpravljanjePrekrsajima
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1082, 503);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "UpravljanjePrekrsajima";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpravljanjePrekrsajima";
            FormClosing += UpravljanjePrekrsajima_FormClosing_1;
            Load += UpravljanjePrekrsajima_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private TextBox textBox1;
        private Button button5;
        private Button button7;
        private Button button1;
        private Button button6;
        private Label label2;
        private Button button3;
        private Label label1;
        private DataGridView dataGridView1;
    }
}