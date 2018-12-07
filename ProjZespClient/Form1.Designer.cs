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
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.pswdTextBox = new System.Windows.Forms.TextBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.SkyBlue;
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
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox pswdTextBox;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ToolTip infoToolTip;
    }
}

