namespace GTANManager
{
    partial class ManagerForm
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
            this.playerList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kickButton = new System.Windows.Forms.Button();
            this.banButton = new System.Windows.Forms.Button();
            this.stopResourceButton = new System.Windows.Forms.Button();
            this.restartResourceButton = new System.Windows.Forms.Button();
            this.startResourceButton = new System.Windows.Forms.Button();
            this.kickAll = new System.Windows.Forms.Button();
            this.resourceList = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRunning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshResourceListButton = new System.Windows.Forms.Button();
            this.unbanButton = new System.Windows.Forms.Button();
            this.bannedPlayerList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRefreshBan = new System.Windows.Forms.Button();
            this.addBanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player list :";
            // 
            // playerList
            // 
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.playerList.FormattingEnabled = true;
            this.playerList.Location = new System.Drawing.Point(12, 25);
            this.playerList.Name = "playerList";
            this.playerList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.playerList.Size = new System.Drawing.Size(150, 316);
            this.playerList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resource list :";
            // 
            // kickButton
            // 
            this.kickButton.Location = new System.Drawing.Point(168, 25);
            this.kickButton.Name = "kickButton";
            this.kickButton.Size = new System.Drawing.Size(100, 23);
            this.kickButton.TabIndex = 4;
            this.kickButton.Text = "Kick";
            this.kickButton.UseVisualStyleBackColor = true;
            this.kickButton.Click += new System.EventHandler(this.kickButton_Click);
            // 
            // banButton
            // 
            this.banButton.Location = new System.Drawing.Point(168, 54);
            this.banButton.Name = "banButton";
            this.banButton.Size = new System.Drawing.Size(100, 23);
            this.banButton.TabIndex = 5;
            this.banButton.Text = "Ban";
            this.banButton.UseVisualStyleBackColor = true;
            this.banButton.Click += new System.EventHandler(this.banButton_Click);
            // 
            // stopResourceButton
            // 
            this.stopResourceButton.Location = new System.Drawing.Point(788, 54);
            this.stopResourceButton.Name = "stopResourceButton";
            this.stopResourceButton.Size = new System.Drawing.Size(100, 23);
            this.stopResourceButton.TabIndex = 9;
            this.stopResourceButton.Text = "Stop";
            this.stopResourceButton.UseVisualStyleBackColor = true;
            this.stopResourceButton.Click += new System.EventHandler(this.stopResourceButton_Click);
            // 
            // restartResourceButton
            // 
            this.restartResourceButton.Location = new System.Drawing.Point(788, 83);
            this.restartResourceButton.Name = "restartResourceButton";
            this.restartResourceButton.Size = new System.Drawing.Size(100, 23);
            this.restartResourceButton.TabIndex = 8;
            this.restartResourceButton.Text = "Restart";
            this.restartResourceButton.UseVisualStyleBackColor = true;
            this.restartResourceButton.Click += new System.EventHandler(this.restartResourceButton_Click);
            // 
            // startResourceButton
            // 
            this.startResourceButton.Location = new System.Drawing.Point(788, 25);
            this.startResourceButton.Name = "startResourceButton";
            this.startResourceButton.Size = new System.Drawing.Size(100, 23);
            this.startResourceButton.TabIndex = 10;
            this.startResourceButton.Text = "Start";
            this.startResourceButton.UseVisualStyleBackColor = true;
            this.startResourceButton.Click += new System.EventHandler(this.startResourceButton_Click);
            // 
            // kickAll
            // 
            this.kickAll.Location = new System.Drawing.Point(168, 83);
            this.kickAll.Name = "kickAll";
            this.kickAll.Size = new System.Drawing.Size(100, 23);
            this.kickAll.TabIndex = 11;
            this.kickAll.Text = "Kick All";
            this.kickAll.UseVisualStyleBackColor = true;
            this.kickAll.Click += new System.EventHandler(this.kickAll_Click);
            // 
            // resourceList
            // 
            this.resourceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.resourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnRunning});
            this.resourceList.Location = new System.Drawing.Point(532, 25);
            this.resourceList.Name = "resourceList";
            this.resourceList.Size = new System.Drawing.Size(250, 316);
            this.resourceList.TabIndex = 12;
            this.resourceList.UseCompatibleStateImageBehavior = false;
            this.resourceList.View = System.Windows.Forms.View.Details;
            this.resourceList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.resourceList_ColumnClick);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 160;
            // 
            // columnRunning
            // 
            this.columnRunning.Text = "Running";
            this.columnRunning.Width = 70;
            // 
            // refreshResourceListButton
            // 
            this.refreshResourceListButton.Location = new System.Drawing.Point(788, 112);
            this.refreshResourceListButton.Name = "refreshResourceListButton";
            this.refreshResourceListButton.Size = new System.Drawing.Size(100, 23);
            this.refreshResourceListButton.TabIndex = 13;
            this.refreshResourceListButton.Text = "Refresh";
            this.refreshResourceListButton.UseVisualStyleBackColor = true;
            this.refreshResourceListButton.Click += new System.EventHandler(this.refreshResourceListButton_Click);
            // 
            // unbanButton
            // 
            this.unbanButton.Location = new System.Drawing.Point(430, 25);
            this.unbanButton.Name = "unbanButton";
            this.unbanButton.Size = new System.Drawing.Size(96, 23);
            this.unbanButton.TabIndex = 16;
            this.unbanButton.Text = "Unban";
            this.unbanButton.UseVisualStyleBackColor = true;
            this.unbanButton.Click += new System.EventHandler(this.unbanButton_Click);
            // 
            // bannedPlayerList
            // 
            this.bannedPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bannedPlayerList.FormattingEnabled = true;
            this.bannedPlayerList.Location = new System.Drawing.Point(274, 25);
            this.bannedPlayerList.Name = "bannedPlayerList";
            this.bannedPlayerList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.bannedPlayerList.Size = new System.Drawing.Size(150, 316);
            this.bannedPlayerList.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Banned player list :";
            // 
            // buttonRefreshBan
            // 
            this.buttonRefreshBan.Location = new System.Drawing.Point(430, 83);
            this.buttonRefreshBan.Name = "buttonRefreshBan";
            this.buttonRefreshBan.Size = new System.Drawing.Size(96, 23);
            this.buttonRefreshBan.TabIndex = 17;
            this.buttonRefreshBan.Text = "Refresh";
            this.buttonRefreshBan.UseVisualStyleBackColor = true;
            this.buttonRefreshBan.Click += new System.EventHandler(this.buttonRefreshBan_Click);
            // 
            // addBanButton
            // 
            this.addBanButton.Location = new System.Drawing.Point(430, 54);
            this.addBanButton.Name = "addBanButton";
            this.addBanButton.Size = new System.Drawing.Size(96, 23);
            this.addBanButton.TabIndex = 18;
            this.addBanButton.Text = "Add ban";
            this.addBanButton.UseVisualStyleBackColor = true;
            this.addBanButton.Click += new System.EventHandler(this.addBanButton_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 361);
            this.Controls.Add(this.addBanButton);
            this.Controls.Add(this.buttonRefreshBan);
            this.Controls.Add(this.unbanButton);
            this.Controls.Add(this.bannedPlayerList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.refreshResourceListButton);
            this.Controls.Add(this.resourceList);
            this.Controls.Add(this.kickAll);
            this.Controls.Add(this.startResourceButton);
            this.Controls.Add(this.stopResourceButton);
            this.Controls.Add(this.restartResourceButton);
            this.Controls.Add(this.banButton);
            this.Controls.Add(this.kickButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(916, 1080);
            this.MinimumSize = new System.Drawing.Size(916, 39);
            this.Name = "ManagerForm";
            this.ShowIcon = false;
            this.Text = "ManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button kickButton;
        private System.Windows.Forms.Button banButton;
        private System.Windows.Forms.Button stopResourceButton;
        private System.Windows.Forms.Button restartResourceButton;
        private System.Windows.Forms.Button startResourceButton;
        private System.Windows.Forms.Button kickAll;
        private System.Windows.Forms.ListView resourceList;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnRunning;
        private System.Windows.Forms.Button refreshResourceListButton;
        private System.Windows.Forms.Button unbanButton;
        private System.Windows.Forms.ListBox bannedPlayerList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRefreshBan;
        private System.Windows.Forms.Button addBanButton;
    }
}