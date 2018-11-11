namespace ContactManager.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this._errors = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._contactList = new System.Windows.Forms.ListBox();
            this._messageList = new System.Windows.Forms.ListBox();
            this._errors.SuspendLayout();
            this.SuspendLayout();
            // 
            // _errors
            // 
            this._errors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._errors.Dock = System.Windows.Forms.DockStyle.None;
            this._errors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItem1});
            this._errors.Location = new System.Drawing.Point(0, 0);
            this._errors.Name = "_errors";
            this._errors.Size = new System.Drawing.Size(155, 24);
            this._errors.TabIndex = 0;
            this._errors.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnFileExit);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.deleteContactToolStripMenuItem});
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.contactsToolStripMenuItem.Text = "Contacts";
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Message";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.OnContactSendMessage);
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addContactToolStripMenuItem.Text = "Add";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.OnContactAdd);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.editContactToolStripMenuItem.Text = "Edit";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.OnContactEdit);
            // 
            // deleteContactToolStripMenuItem
            // 
            this.deleteContactToolStripMenuItem.Name = "deleteContactToolStripMenuItem";
            this.deleteContactToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteContactToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteContactToolStripMenuItem.Text = "Remove";
            this.deleteContactToolStripMenuItem.Click += new System.EventHandler(this.OnContactRemove);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // _contactList
            // 
            this._contactList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._contactList.FormattingEnabled = true;
            this._contactList.Location = new System.Drawing.Point(0, 24);
            this._contactList.Name = "_contactList";
            this._contactList.Size = new System.Drawing.Size(133, 394);
            this._contactList.TabIndex = 1;
            this._contactList.DoubleClick += new System.EventHandler(this.OnContactDoubleClick);
            // 
            // _messageList
            // 
            this._messageList.FormattingEnabled = true;
            this._messageList.Items.AddRange(new object[] {
            "EmailAddress",
            "Subject",
            "Message"});
            this._messageList.Location = new System.Drawing.Point(140, 24);
            this._messageList.Name = "_messageList";
            this._messageList.Size = new System.Drawing.Size(500, 394);
            this._messageList.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 422);
            this.Controls.Add(this._messageList);
            this.Controls.Add(this._contactList);
            this.Controls.Add(this._errors);
            this.MainMenuStrip = this._errors;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Manager";
            this._errors.ResumeLayout(false);
            this._errors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _errors;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContactToolStripMenuItem;
        private System.Windows.Forms.ListBox _contactList;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListBox _messageList;
    }
}

