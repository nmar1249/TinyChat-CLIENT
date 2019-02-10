namespace TinyChat_Client
{
    partial class PrivateChatScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_PrivateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBox_PrivateChat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_PrivateMsg = new System.Windows.Forms.TextBox();
            this.button_PrivateSend = new System.Windows.Forms.Button();
            this.submenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_PrivateChat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_PrivateChat
            // 
            this.menu_PrivateChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenu_Save,
            this.submenu_Exit});
            this.menu_PrivateChat.Name = "menu_PrivateChat";
            this.menu_PrivateChat.Size = new System.Drawing.Size(44, 20);
            this.menu_PrivateChat.Text = "Chat";
            // 
            // txtBox_PrivateChat
            // 
            this.txtBox_PrivateChat.Location = new System.Drawing.Point(12, 27);
            this.txtBox_PrivateChat.Multiline = true;
            this.txtBox_PrivateChat.Name = "txtBox_PrivateChat";
            this.txtBox_PrivateChat.Size = new System.Drawing.Size(350, 404);
            this.txtBox_PrivateChat.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message:";
            // 
            // txtBox_PrivateMsg
            // 
            this.txtBox_PrivateMsg.Location = new System.Drawing.Point(74, 446);
            this.txtBox_PrivateMsg.Name = "txtBox_PrivateMsg";
            this.txtBox_PrivateMsg.Size = new System.Drawing.Size(212, 20);
            this.txtBox_PrivateMsg.TabIndex = 3;
            // 
            // button_PrivateSend
            // 
            this.button_PrivateSend.Location = new System.Drawing.Point(292, 446);
            this.button_PrivateSend.Name = "button_PrivateSend";
            this.button_PrivateSend.Size = new System.Drawing.Size(75, 23);
            this.button_PrivateSend.TabIndex = 4;
            this.button_PrivateSend.Text = "Send";
            this.button_PrivateSend.UseVisualStyleBackColor = true;
            this.button_PrivateSend.Click += new System.EventHandler(this.button_PrivateSend_Click);
            // 
            // submenu_Save
            // 
            this.submenu_Save.Name = "submenu_Save";
            this.submenu_Save.Size = new System.Drawing.Size(152, 22);
            this.submenu_Save.Text = "Save";
            this.submenu_Save.Click += new System.EventHandler(this.submenu_Save_Click);
            // 
            // submenu_Exit
            // 
            this.submenu_Exit.Name = "submenu_Exit";
            this.submenu_Exit.Size = new System.Drawing.Size(152, 22);
            this.submenu_Exit.Text = "Exit";
            this.submenu_Exit.Click += new System.EventHandler(this.submenu_Exit_Click);
            // 
            // PrivateChatScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 478);
            this.Controls.Add(this.button_PrivateSend);
            this.Controls.Add(this.txtBox_PrivateMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_PrivateChat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrivateChatScreen";
            this.Text = "Private Chat";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_PrivateChat;
        private System.Windows.Forms.ToolStripMenuItem submenu_Save;
        private System.Windows.Forms.ToolStripMenuItem submenu_Exit;
        private System.Windows.Forms.TextBox txtBox_PrivateChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_PrivateMsg;
        private System.Windows.Forms.Button button_PrivateSend;
    }
}