namespace SoftverZaRegistraciju
{
    partial class RegistrationForm
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
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            passCheckBox = new CheckBox();
            registerButton = new Button();
            label2 = new Label();
            label1 = new Label();
            txtConPassword = new TextBox();
            label3 = new Label();
            txtJMBG = new TextBox();
            label11 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.ForeColor = SystemColors.Highlight;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 500);
            panel1.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.Desktop;
            label10.Location = new Point(3, 262);
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
            label9.Location = new Point(3, 242);
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
            label8.Location = new Point(75, 101);
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
            label7.Location = new Point(104, 67);
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
            label6.Location = new Point(3, 479);
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
            label5.Location = new Point(109, 32);
            label5.Name = "label5";
            label5.Size = new Size(174, 34);
            label5.TabIndex = 0;
            label5.Text = "Dobrodosli";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(823, 9);
            label4.Name = "label4";
            label4.Size = new Size(257, 46);
            label4.TabIndex = 6;
            label4.Text = "Registracija";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(648, 163);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(324, 31);
            txtPassword.TabIndex = 15;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(648, 91);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(324, 31);
            txtUsername.TabIndex = 14;
            // 
            // passCheckBox
            // 
            passCheckBox.AutoSize = true;
            passCheckBox.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passCheckBox.Location = new Point(833, 348);
            passCheckBox.Margin = new Padding(4, 3, 4, 3);
            passCheckBox.Name = "passCheckBox";
            passCheckBox.Size = new Size(169, 27);
            passCheckBox.TabIndex = 13;
            passCheckBox.Text = "Prikazi lozinku";
            passCheckBox.UseVisualStyleBackColor = true;
            passCheckBox.CheckedChanged += passCheckBox_CheckedChanged;
            // 
            // registerButton
            // 
            registerButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            registerButton.Location = new Point(648, 394);
            registerButton.Margin = new Padding(4, 3, 4, 3);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(200, 64);
            registerButton.TabIndex = 12;
            registerButton.Text = "Registruj se";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(537, 171);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 23);
            label2.TabIndex = 11;
            label2.Text = "Lozinka";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(466, 99);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 10;
            label1.Text = "Korisnicko Ime";
            // 
            // txtConPassword
            // 
            txtConPassword.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConPassword.Location = new Point(648, 232);
            txtConPassword.Margin = new Padding(4, 3, 4, 3);
            txtConPassword.Name = "txtConPassword";
            txtConPassword.Size = new Size(324, 31);
            txtConPassword.TabIndex = 17;
            txtConPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(462, 240);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(159, 23);
            label3.TabIndex = 16;
            label3.Text = "Potvrda lozinke";
            // 
            // txtJMBG
            // 
            txtJMBG.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtJMBG.Location = new Point(648, 300);
            txtJMBG.Margin = new Padding(4, 3, 4, 3);
            txtJMBG.Name = "txtJMBG";
            txtJMBG.Size = new Size(324, 31);
            txtJMBG.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(553, 308);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(68, 23);
            label11.TabIndex = 18;
            label11.Text = "JMBG";
            // 
            // button1
            // 
            button1.Location = new Point(462, 424);
            button1.Name = "button1";
            button1.Size = new Size(94, 34);
            button1.TabIndex = 20;
            button1.Text = "clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Location = new Point(407, 4);
            button2.Name = "button2";
            button2.Size = new Size(100, 46);
            button2.TabIndex = 21;
            button2.Text = "Nazad";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 503);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtJMBG);
            Controls.Add(label11);
            Controls.Add(txtConPassword);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(passCheckBox);
            Controls.Add(registerButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(panel1);
            Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registracija";
            Load += RegistrationForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private CheckBox passCheckBox;
        private Button registerButton;
        private Label label2;
        private Label label1;
        private TextBox txtConPassword;
        private Label label3;
        private TextBox txtJMBG;
        private Label label11;
        private Button button1;
        private Button button2;
    }
}