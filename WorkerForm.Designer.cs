namespace SoftverZaRegistraciju
{
    partial class WorkerForm
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
            button5 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel1 = new Panel();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            btnCalc = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(12, 7);
            button5.Name = "button5";
            button5.Size = new Size(94, 57);
            button5.TabIndex = 7;
            button5.Text = "Promijeni sifru";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 85);
            button3.Name = "button3";
            button3.Size = new Size(94, 36);
            button3.TabIndex = 6;
            button3.Text = "Odjava";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 56);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1058, 301);
            dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(361, 9);
            label1.Name = "label1";
            label1.Size = new Size(302, 34);
            label1.TabIndex = 9;
            label1.Text = "Registrovana vozila";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnCalc);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(0, 367);
            panel1.Name = "panel1";
            panel1.Size = new Size(1090, 143);
            panel1.TabIndex = 10;
            // 
            // button8
            // 
            button8.Location = new Point(334, 69);
            button8.Name = "button8";
            button8.Size = new Size(133, 67);
            button8.TabIndex = 30;
            button8.Text = "Izdaj tablice";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(489, 68);
            button7.Name = "button7";
            button7.Size = new Size(146, 68);
            button7.TabIndex = 29;
            button7.Text = "Izdaj potvrdu";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(747, 1);
            button6.Name = "button6";
            button6.Size = new Size(133, 68);
            button6.TabIndex = 28;
            button6.Text = "Upravljaj prekrsajima";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(747, 68);
            button4.Name = "button4";
            button4.Size = new Size(133, 68);
            button4.TabIndex = 27;
            button4.Text = "Upravljaj kaznama";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(945, 69);
            button2.Name = "button2";
            button2.Size = new Size(133, 67);
            button2.TabIndex = 26;
            button2.Text = "Osvjezi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(489, 1);
            button1.Name = "button1";
            button1.Size = new Size(146, 68);
            button1.TabIndex = 25;
            button1.Text = "Registruj vozilo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(247, 10);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 24;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(113, 10);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 23;
            label2.Text = "Korisnicko ime:";
            // 
            // btnCalc
            // 
            btnCalc.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalc.ForeColor = SystemColors.Highlight;
            btnCalc.Location = new Point(945, 1);
            btnCalc.Margin = new Padding(4, 3, 4, 3);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(133, 68);
            btnCalc.TabIndex = 21;
            btnCalc.Text = "Kalkulator registracije";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // button9
            // 
            button9.Location = new Point(334, 3);
            button9.Name = "button9";
            button9.Size = new Size(133, 66);
            button9.TabIndex = 31;
            button9.Text = "Izdaj stiker";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // WorkerForm
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
            Name = "WorkerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Radnicki Panel";
            FormClosing += WorkerForm_FormClosing;
            Load += WorkerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button button3;
        private DataGridView dataGridView1;
        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Button btnCalc;
        private Button button1;
        private Button button2;
        private Button button6;
        private Button button4;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}