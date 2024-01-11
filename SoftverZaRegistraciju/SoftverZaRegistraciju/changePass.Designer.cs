namespace SoftverZaRegistraciju
{
    partial class changePass
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
            textBox3 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 91);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 0;
            label1.Text = "Stara lozinka";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 187);
            label2.Name = "label2";
            label2.Size = new Size(132, 23);
            label2.TabIndex = 1;
            label2.Text = "Nova lozinka";
            // 
            // label3
            // 
            label3.Location = new Point(55, 255);
            label3.Name = "label3";
            label3.Size = new Size(132, 50);
            label3.TabIndex = 2;
            label3.Text = "Potvrda nove lozinke";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(242, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 31);
            textBox1.TabIndex = 3;
            textBox1.UseSystemPasswordChar = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(242, 179);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 31);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(242, 274);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(208, 31);
            textBox3.TabIndex = 5;
            textBox3.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(178, 404);
            button1.Name = "button1";
            button1.Size = new Size(153, 61);
            button1.TabIndex = 6;
            button1.Text = "Promijeni lozinku";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(281, 332);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(169, 27);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Prikazi lozinke";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // changePass
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(513, 539);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "changePass";
            Text = "Promjena lozinke";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private CheckBox checkBox1;
    }
}