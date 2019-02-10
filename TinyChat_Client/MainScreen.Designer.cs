namespace TinyChat_Client
{
    partial class FormMain
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
            this.menu_Chat = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBox_MessageToSend = new System.Windows.Forms.RichTextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.submenu_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_PrivateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.submenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button_PrivateChat = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtBox_Chatroom = new System.Windows.Forms.RichTextBox();
            this.listView_Users = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Chat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_Chat
            // 
            this.menu_Chat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenu_Login,
            this.submenu_PrivateChat,
            this.submenu_Save,
            this.toolStripMenuItem1,
            this.submenu_Exit});
            this.menu_Chat.Name = "menu_Chat";
            this.menu_Chat.Size = new System.Drawing.Size(44, 20);
            this.menu_Chat.Text = "Chat";
            // 
            // txtBox_MessageToSend
            // 
            this.txtBox_MessageToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_MessageToSend.Location = new System.Drawing.Point(107, 495);
            this.txtBox_MessageToSend.Name = "txtBox_MessageToSend";
            this.txtBox_MessageToSend.Size = new System.Drawing.Size(339, 30);
            this.txtBox_MessageToSend.TabIndex = 3;
            this.txtBox_MessageToSend.Text = "";
            // 
            // button_Send
            // 
            this.button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Send.Location = new System.Drawing.Point(13, 498);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 4;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // submenu_Login
            // 
            this.submenu_Login.Name = "submenu_Login";
            this.submenu_Login.Size = new System.Drawing.Size(152, 22);
            this.submenu_Login.Text = "Login";
            this.submenu_Login.Click += new System.EventHandler(this.submenu_Login_Click);
            // 
            // submenu_PrivateChat
            // 
            this.submenu_PrivateChat.Name = "submenu_PrivateChat";
            this.submenu_PrivateChat.Size = new System.Drawing.Size(152, 22);
            this.submenu_PrivateChat.Text = "Private Chat";
            this.submenu_PrivateChat.Click += new System.EventHandler(this.submenu_PrivateChat_Click);
            // 
            // submenu_Save
            // 
            this.submenu_Save.Name = "submenu_Save";
            this.submenu_Save.Size = new System.Drawing.Size(152, 22);
            this.submenu_Save.Text = "Save";
            this.submenu_Save.Click += new System.EventHandler(this.submenu_Save_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // submenu_Exit
            // 
            this.submenu_Exit.Name = "submenu_Exit";
            this.submenu_Exit.Size = new System.Drawing.Size(152, 22);
            this.submenu_Exit.Text = "Exit";
            this.submenu_Exit.Click += new System.EventHandler(this.submenu_Exit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Users Online";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_PrivateChat
            // 
            this.button_PrivateChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_PrivateChat.Location = new System.Drawing.Point(491, 498);
            this.button_PrivateChat.Name = "button_PrivateChat";
            this.button_PrivateChat.Size = new System.Drawing.Size(102, 23);
            this.button_PrivateChat.TabIndex = 6;
            this.button_PrivateChat.Text = "Start Private Chat";
            this.button_PrivateChat.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_Chatroom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView_Users);
            this.splitContainer1.Size = new System.Drawing.Size(630, 449);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 7;
            // 
            // txtBox_Chatroom
            // 
            this.txtBox_Chatroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBox_Chatroom.Location = new System.Drawing.Point(0, 0);
            this.txtBox_Chatroom.Name = "txtBox_Chatroom";
            this.txtBox_Chatroom.Size = new System.Drawing.Size(454, 449);
            this.txtBox_Chatroom.TabIndex = 4;
            this.txtBox_Chatroom.Text = "";
            this.txtBox_Chatroom.TextChanged += new System.EventHandler(this.txtBox_Chatroom_TextChanged);
            // 
            // listView_Users
            // 
            this.listView_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Users.Location = new System.Drawing.Point(0, 0);
            this.listView_Users.Name = "listView_Users";
            this.listView_Users.Size = new System.Drawing.Size(172, 449);
            this.listView_Users.TabIndex = 4;
            this.listView_Users.UseCompatibleStateImageBehavior = false;
            this.listView_Users.SelectedIndexChanged += new System.EventHandler(this.listView_Users_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 541);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button_PrivateChat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.txtBox_MessageToSend);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "TinyChat";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Chat;
        private System.Windows.Forms.ToolStripMenuItem submenu_Login;
        private System.Windows.Forms.ToolStripMenuItem submenu_PrivateChat;
        private System.Windows.Forms.ToolStripMenuItem submenu_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem submenu_Exit;
        private System.Windows.Forms.RichTextBox txtBox_MessageToSend;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_PrivateChat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtBox_Chatroom;
        private System.Windows.Forms.ListView listView_Users;
    }
}

