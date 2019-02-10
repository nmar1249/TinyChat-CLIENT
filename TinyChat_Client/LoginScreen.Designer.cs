namespace TinyChat_Client
{
    partial class LoginScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_Username = new System.Windows.Forms.TextBox();
            this.button_Enter = new System.Windows.Forms.Button();
            this.button_Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // txtbox_Username
            // 
            this.txtbox_Username.Location = new System.Drawing.Point(110, 9);
            this.txtbox_Username.Name = "txtbox_Username";
            this.txtbox_Username.Size = new System.Drawing.Size(162, 20);
            this.txtbox_Username.TabIndex = 1;
            // 
            // button_Enter
            // 
            this.button_Enter.Location = new System.Drawing.Point(66, 40);
            this.button_Enter.Name = "button_Enter";
            this.button_Enter.Size = new System.Drawing.Size(75, 23);
            this.button_Enter.TabIndex = 2;
            this.button_Enter.Text = "Enter";
            this.button_Enter.UseVisualStyleBackColor = true;
            this.button_Enter.Click += new System.EventHandler(this.button_Enter_Click);
            // 
            // button_Quit
            // 
            this.button_Quit.Location = new System.Drawing.Point(147, 40);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(75, 23);
            this.button_Quit.TabIndex = 3;
            this.button_Quit.Text = "Quit";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 75);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.button_Enter);
            this.Controls.Add(this.txtbox_Username);
            this.Controls.Add(this.label1);
            this.Name = "LoginScreen";
            this.Text = "TinyChat Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_Username;
        private System.Windows.Forms.Button button_Enter;
        private System.Windows.Forms.Button button_Quit;
    }
}