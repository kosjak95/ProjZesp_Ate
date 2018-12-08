using CommonTypes;

namespace ProjZespClient
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

        private void FullInitializeComponent()
        {
            InitializeComponent();

            this.loginTextBox.GotFocus += Handle_GotFocus;
            this.loginTextBox.LostFocus += Handle_LostFocus;
            this.loginTextBox.Text = Dict.GetString("login");

            this.loginButton.Text = Dict.GetString("log_in");

            this.pswdTextBox.Text = Dict.GetString("password");
            this.pswdTextBox.LostFocus += Handle_LostFocus;
            this.pswdTextBox.GotFocus += Handle_GotFocus;


            this.welcomeLabel.Text = Dict.GetString("welcome");

            this.createAcountButton.Text = Dict.GetString("createAcount");
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.RegisterPanel = new System.Windows.Forms.Panel();
            this.DataAgreeChb = new System.Windows.Forms.CheckBox();
            this.WeightBt = new System.Windows.Forms.TextBox();
            this.GrowthBt = new System.Windows.Forms.TextBox();
            this.SexBoxes = new System.Windows.Forms.CheckedListBox();
            this.RegisterBt = new System.Windows.Forms.Button();
            this.AdressBt = new System.Windows.Forms.TextBox();
            this.EmailBt = new System.Windows.Forms.TextBox();
            this.PasswordBt = new System.Windows.Forms.TextBox();
            this.LoginBt = new System.Windows.Forms.TextBox();
            this.SurnameBt = new System.Windows.Forms.TextBox();
            this.NameBt = new System.Windows.Forms.TextBox();
            this.createAcountButton = new System.Windows.Forms.Button();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.pswdTextBox = new System.Windows.Forms.TextBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LoginPanel.SuspendLayout();
            this.RegisterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.LoginPanel.Controls.Add(this.RegisterPanel);
            this.LoginPanel.Controls.Add(this.createAcountButton);
            this.LoginPanel.Controls.Add(this.loginTextBox);
            this.LoginPanel.Controls.Add(this.loginButton);
            this.LoginPanel.Controls.Add(this.pswdTextBox);
            this.LoginPanel.Controls.Add(this.welcomeLabel);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(882, 513);
            this.LoginPanel.TabIndex = 0;
            // 
            // RegisterPanel
            // 
            this.RegisterPanel.Controls.Add(this.DataAgreeChb);
            this.RegisterPanel.Controls.Add(this.WeightBt);
            this.RegisterPanel.Controls.Add(this.GrowthBt);
            this.RegisterPanel.Controls.Add(this.SexBoxes);
            this.RegisterPanel.Controls.Add(this.RegisterBt);
            this.RegisterPanel.Controls.Add(this.AdressBt);
            this.RegisterPanel.Controls.Add(this.EmailBt);
            this.RegisterPanel.Controls.Add(this.PasswordBt);
            this.RegisterPanel.Controls.Add(this.LoginBt);
            this.RegisterPanel.Controls.Add(this.SurnameBt);
            this.RegisterPanel.Controls.Add(this.NameBt);
            this.RegisterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterPanel.Location = new System.Drawing.Point(0, 0);
            this.RegisterPanel.Name = "RegisterPanel";
            this.RegisterPanel.Size = new System.Drawing.Size(882, 513);
            this.RegisterPanel.TabIndex = 6;
            this.RegisterPanel.Visible = false;
            // 
            // DataAgreeChb
            // 
            this.DataAgreeChb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataAgreeChb.AutoSize = true;
            this.DataAgreeChb.Location = new System.Drawing.Point(468, 269);
            this.DataAgreeChb.Name = "DataAgreeChb";
            this.DataAgreeChb.Size = new System.Drawing.Size(347, 21);
            this.DataAgreeChb.TabIndex = 10;
            this.DataAgreeChb.Text = "Zgadzam się na przetwarzanie danych osobowych";
            this.DataAgreeChb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DataAgreeChb.UseVisualStyleBackColor = true;
            // 
            // WeightBt
            // 
            this.WeightBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WeightBt.Location = new System.Drawing.Point(468, 130);
            this.WeightBt.Name = "WeightBt";
            this.WeightBt.Size = new System.Drawing.Size(155, 22);
            this.WeightBt.TabIndex = 9;
            // 
            // GrowthBt
            // 
            this.GrowthBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrowthBt.Location = new System.Drawing.Point(468, 85);
            this.GrowthBt.Name = "GrowthBt";
            this.GrowthBt.Size = new System.Drawing.Size(155, 22);
            this.GrowthBt.TabIndex = 8;
            // 
            // SexBoxes
            // 
            this.SexBoxes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SexBoxes.BackColor = System.Drawing.Color.SkyBlue;
            this.SexBoxes.FormattingEnabled = true;
            this.SexBoxes.Items.AddRange(new object[] {
            "Kobieta",
            "Mężczyzna"});
            this.SexBoxes.Location = new System.Drawing.Point(468, 182);
            this.SexBoxes.Name = "SexBoxes";
            this.SexBoxes.Size = new System.Drawing.Size(155, 72);
            this.SexBoxes.TabIndex = 7;
            this.SexBoxes.ThreeDCheckBoxes = true;
            // 
            // RegisterBt
            // 
            this.RegisterBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterBt.Location = new System.Drawing.Point(468, 310);
            this.RegisterBt.Name = "RegisterBt";
            this.RegisterBt.Size = new System.Drawing.Size(155, 25);
            this.RegisterBt.TabIndex = 6;
            this.RegisterBt.Text = "button1";
            this.RegisterBt.UseVisualStyleBackColor = true;
            // 
            // AdressBt
            // 
            this.AdressBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdressBt.Location = new System.Drawing.Point(251, 310);
            this.AdressBt.Name = "AdressBt";
            this.AdressBt.Size = new System.Drawing.Size(155, 22);
            this.AdressBt.TabIndex = 5;
            // 
            // EmailBt
            // 
            this.EmailBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailBt.Location = new System.Drawing.Point(251, 267);
            this.EmailBt.Name = "EmailBt";
            this.EmailBt.Size = new System.Drawing.Size(155, 22);
            this.EmailBt.TabIndex = 4;
            // 
            // PasswordBt
            // 
            this.PasswordBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordBt.Location = new System.Drawing.Point(251, 226);
            this.PasswordBt.Name = "PasswordBt";
            this.PasswordBt.Size = new System.Drawing.Size(155, 22);
            this.PasswordBt.TabIndex = 3;
            // 
            // LoginBt
            // 
            this.LoginBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBt.Location = new System.Drawing.Point(251, 181);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(155, 22);
            this.LoginBt.TabIndex = 2;
            // 
            // SurnameBt
            // 
            this.SurnameBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurnameBt.Location = new System.Drawing.Point(251, 130);
            this.SurnameBt.Name = "SurnameBt";
            this.SurnameBt.Size = new System.Drawing.Size(155, 22);
            this.SurnameBt.TabIndex = 1;
            // 
            // NameBt
            // 
            this.NameBt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameBt.Location = new System.Drawing.Point(251, 85);
            this.NameBt.Name = "NameBt";
            this.NameBt.Size = new System.Drawing.Size(155, 22);
            this.NameBt.TabIndex = 0;
            // 
            // createAcountButton
            // 
            this.createAcountButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createAcountButton.Location = new System.Drawing.Point(410, 312);
            this.createAcountButton.Name = "createAcountButton";
            this.createAcountButton.Size = new System.Drawing.Size(75, 23);
            this.createAcountButton.TabIndex = 5;
            this.createAcountButton.UseVisualStyleBackColor = true;
            this.createAcountButton.Click += new System.EventHandler(this.CreateAcountButton_Click);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginTextBox.Location = new System.Drawing.Point(325, 172);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(243, 22);
            this.loginTextBox.TabIndex = 4;
            this.loginTextBox.MouseHover += new System.EventHandler(this.LoginTextBox_MouseHover);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(390, 256);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(115, 50);
            this.loginButton.TabIndex = 3;
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // pswdTextBox
            // 
            this.pswdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pswdTextBox.Location = new System.Drawing.Point(325, 213);
            this.pswdTextBox.Name = "pswdTextBox";
            this.pswdTextBox.Size = new System.Drawing.Size(243, 22);
            this.pswdTextBox.TabIndex = 2;
            this.pswdTextBox.MouseHover += new System.EventHandler(this.PswdTextBox_MouseHover);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(385, 104);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(0, 48);
            this.welcomeLabel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 513);
            this.Controls.Add(this.LoginPanel);
            this.Name = "Form1";
            this.Text = "FitLife";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.RegisterPanel.ResumeLayout(false);
            this.RegisterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox pswdTextBox;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ToolTip infoToolTip;
        private System.Windows.Forms.Button createAcountButton;
        private System.Windows.Forms.Panel RegisterPanel;
        private System.Windows.Forms.CheckBox DataAgreeChb;
        private System.Windows.Forms.TextBox WeightBt;
        private System.Windows.Forms.TextBox GrowthBt;
        private System.Windows.Forms.CheckedListBox SexBoxes;
        private System.Windows.Forms.Button RegisterBt;
        private System.Windows.Forms.TextBox AdressBt;
        private System.Windows.Forms.TextBox EmailBt;
        private System.Windows.Forms.TextBox PasswordBt;
        private System.Windows.Forms.TextBox LoginBt;
        private System.Windows.Forms.TextBox SurnameBt;
        private System.Windows.Forms.TextBox NameBt;
    }
}

