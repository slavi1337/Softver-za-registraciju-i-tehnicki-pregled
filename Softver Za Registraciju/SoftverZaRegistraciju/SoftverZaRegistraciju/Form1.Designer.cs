namespace SoftverZaRegistraciju
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            loginButton = new Button();
            passCheckBox = new CheckBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            panel1 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            regButton = new Button();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(461, 103);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 0;
            label1.Text = "Korisnicko Ime";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(532, 179);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 23);
            label2.TabIndex = 1;
            label2.Text = "Lozinka";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(921, 425);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 23);
            label3.TabIndex = 2;
            label3.Text = "Nemas nalog?";
            label3.Click += label3_Click;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.Location = new Point(643, 272);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(200, 64);
            loginButton.TabIndex = 3;
            loginButton.Text = "Prijavi se";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // passCheckBox
            // 
            passCheckBox.AutoSize = true;
            passCheckBox.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passCheckBox.Location = new Point(798, 222);
            passCheckBox.Margin = new Padding(4, 3, 4, 3);
            passCheckBox.Name = "passCheckBox";
            passCheckBox.Size = new Size(169, 27);
            passCheckBox.TabIndex = 4;
            passCheckBox.Text = "Prikazi lozinku";
            passCheckBox.UseVisualStyleBackColor = true;
            passCheckBox.CheckedChanged += passCheckBox_CheckedChanged;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(643, 95);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(324, 31);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(643, 171);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(324, 31);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.ForeColor = SystemColors.Highlight;
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(400, 500);
            panel1.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.Desktop;
            label10.Location = new Point(4, 263);
            label10.Name = "label10";
            label10.Size = new Size(380, 20);
            label10.TabIndex = 5;
            label10.Text = "Ukoliko nemate nalog, mozete ga registrovati";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Desktop;
            label9.Location = new Point(4, 243);
            label9.Name = "label9";
            label9.Size = new Size(331, 20);
            label9.TabIndex = 4;
            label9.Text = "Ukoliko imate nalog, mozete se prijaviti";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.HighlightText;
            label8.Location = new Point(76, 102);
            label8.Name = "label8";
            label8.Size = new Size(275, 34);
            label8.TabIndex = 3;
            label8.Text = "registraciju vozila";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.HighlightText;
            label7.Location = new Point(105, 68);
            label7.Name = "label7";
            label7.Size = new Size(185, 34);
            label7.TabIndex = 2;
            label7.Text = "u softver za";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.HighlightText;
            label6.Location = new Point(4, 480);
            label6.Name = "label6";
            label6.Size = new Size(216, 15);
            label6.TabIndex = 1;
            label6.Text = "Developed by OSI2023-Grupa-15";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.HighlightText;
            label5.Location = new Point(110, 33);
            label5.Name = "label5";
            label5.Size = new Size(174, 34);
            label5.TabIndex = 0;
            label5.Text = "Dobrodosli";
            // 
            // regButton
            // 
            regButton.Location = new Point(922, 451);
            regButton.Name = "regButton";
            regButton.Size = new Size(148, 40);
            regButton.TabIndex = 9;
            regButton.Text = "Registruj se";
            regButton.UseVisualStyleBackColor = true;
            regButton.Click += regButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(402, 1);
            label4.Name = "label4";
            label4.Size = new Size(157, 46);
            label4.TabIndex = 0;
            label4.Text = "Prijava";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 503);
            Controls.Add(label4);
            Controls.Add(regButton);
            Controls.Add(panel1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(passCheckBox);
            Controls.Add(loginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Prijava";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button loginButton;
        private CheckBox passCheckBox;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Panel panel1;
        private Label label5;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label10;
        private Label label9;
        private Button regButton;
        private Label label4;
    }
}