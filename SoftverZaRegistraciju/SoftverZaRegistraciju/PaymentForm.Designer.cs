namespace SoftverZaRegistraciju
{
    partial class PaymentForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            panel1 = new Panel();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(216, 23);
            label1.TabIndex = 0;
            label1.Text = "Broj kartice-16 cifara";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 165);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 23);
            label2.TabIndex = 1;
            label2.Text = "CVV-3 cifre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 242);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 46);
            label3.TabIndex = 2;
            label3.Text = "Istice \r\nmm/gggg\r\n";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Location = new Point(22, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(483, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Location = new Point(22, 191);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(122, 31);
            textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Window;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            comboBox1.Location = new Point(22, 291);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(63, 31);
            comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.Window;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034" });
            comboBox2.Location = new Point(91, 291);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(90, 31);
            comboBox2.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(22, 387);
            button1.Name = "button1";
            button1.Size = new Size(147, 53);
            button1.TabIndex = 7;
            button1.Text = "Plati";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(678, -11);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 514);
            panel1.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(172, 161);
            label12.Name = "label12";
            label12.Size = new Size(36, 20);
            label12.TabIndex = 8;
            label12.Text = "KM";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(191, 305);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 7;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(115, 227);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 6;
            label10.Text = "label10";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(115, 161);
            label9.Name = "label9";
            label9.Size = new Size(60, 20);
            label9.TabIndex = 5;
            label9.Text = "label9";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(43, 408);
            label8.Name = "label8";
            label8.Size = new Size(329, 90);
            label8.TabIndex = 4;
            label8.Text = "Napomena: \r\nUkoliko se kazna placa u roku od 8 dana,\r\ncijena je duplo jeftinija.\r\nAutomatski se u Iznosu iznad ispisuje cijena kazne\r\ni uzima se u obzir da li se placa u roku od 8 dana.\r\n\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 302);
            label7.Name = "label7";
            label7.Size = new Size(142, 23);
            label7.TabIndex = 3;
            label7.Text = "Datum kazne:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 224);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 2;
            label6.Text = "Opis:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 158);
            label5.Name = "label5";
            label5.Size = new Size(67, 23);
            label5.TabIndex = 1;
            label5.Text = "Iznos:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(8, 86);
            label4.Name = "label4";
            label4.Size = new Size(377, 27);
            label4.TabIndex = 0;
            label4.Text = "Informacije o kazni koja se placa";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1082, 503);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "PaymentForm";
            Text = "Korisnicki Panel - Placanje Kazne";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Panel panel1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label8;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label12;
    }
}