namespace EsportsDatabase
{
    partial class EsportsDatabase
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
            this.displayTable = new System.Windows.Forms.DataGridView();
            this.gameNameInput = new System.Windows.Forms.TextBox();
            this.gameLabel = new System.Windows.Forms.Label();
            this.gameTypeInput = new System.Windows.Forms.TextBox();
            this.gameNumberOfPlayersPerTeamInput = new System.Windows.Forms.TextBox();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.playersPerTeamLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.gameDeviceInput = new System.Windows.Forms.TextBox();
            this.SelectTable = new System.Windows.Forms.TabControl();
            this.Teams = new System.Windows.Forms.TabPage();
            this.Games = new System.Windows.Forms.TabPage();
            this.gameIDInput = new System.Windows.Forms.TextBox();
            this.gameIDLabel = new System.Windows.Forms.Label();
            this.Players = new System.Windows.Forms.TabPage();
            this.Rosters = new System.Windows.Forms.TabPage();
            this.Events = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).BeginInit();
            this.SelectTable.SuspendLayout();
            this.Games.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayTable
            // 
            this.displayTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayTable.Location = new System.Drawing.Point(454, 26);
            this.displayTable.Name = "displayTable";
            this.displayTable.RowHeadersWidth = 51;
            this.displayTable.RowTemplate.Height = 24;
            this.displayTable.Size = new System.Drawing.Size(322, 390);
            this.displayTable.TabIndex = 0;
            // 
            // gameNameInput
            // 
            this.gameNameInput.Location = new System.Drawing.Point(158, 58);
            this.gameNameInput.Name = "gameNameInput";
            this.gameNameInput.Size = new System.Drawing.Size(100, 22);
            this.gameNameInput.TabIndex = 2;
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(16, 61);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(47, 16);
            this.gameLabel.TabIndex = 4;
            this.gameLabel.Text = "Game:";
            // 
            // gameTypeInput
            // 
            this.gameTypeInput.Location = new System.Drawing.Point(158, 122);
            this.gameTypeInput.Name = "gameTypeInput";
            this.gameTypeInput.Size = new System.Drawing.Size(100, 22);
            this.gameTypeInput.TabIndex = 5;
            // 
            // gameNumberOfPlayersPerTeamInput
            // 
            this.gameNumberOfPlayersPerTeamInput.Location = new System.Drawing.Point(158, 152);
            this.gameNumberOfPlayersPerTeamInput.Name = "gameNumberOfPlayersPerTeamInput";
            this.gameNumberOfPlayersPerTeamInput.Size = new System.Drawing.Size(100, 22);
            this.gameNumberOfPlayersPerTeamInput.TabIndex = 7;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Location = new System.Drawing.Point(30, 382);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(114, 34);
            this.InsertBtn.TabIndex = 8;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(150, 382);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(114, 34);
            this.UpdateBtn.TabIndex = 9;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(270, 382);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(114, 34);
            this.DeleteBtn.TabIndex = 10;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // playersPerTeamLabel
            // 
            this.playersPerTeamLabel.AutoSize = true;
            this.playersPerTeamLabel.Location = new System.Drawing.Point(16, 158);
            this.playersPerTeamLabel.Name = "playersPerTeamLabel";
            this.playersPerTeamLabel.Size = new System.Drawing.Size(136, 16);
            this.playersPerTeamLabel.TabIndex = 12;
            this.playersPerTeamLabel.Text = "# of Players per team:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(16, 125);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(42, 16);
            this.typeLabel.TabIndex = 13;
            this.typeLabel.Text = "Type:";
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(16, 91);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(53, 16);
            this.deviceLabel.TabIndex = 15;
            this.deviceLabel.Text = "Device:";
            // 
            // gameDeviceInput
            // 
            this.gameDeviceInput.Location = new System.Drawing.Point(158, 88);
            this.gameDeviceInput.Name = "gameDeviceInput";
            this.gameDeviceInput.Size = new System.Drawing.Size(100, 22);
            this.gameDeviceInput.TabIndex = 14;
            // 
            // SelectTable
            // 
            this.SelectTable.Controls.Add(this.Teams);
            this.SelectTable.Controls.Add(this.Games);
            this.SelectTable.Controls.Add(this.Players);
            this.SelectTable.Controls.Add(this.Rosters);
            this.SelectTable.Controls.Add(this.Events);
            this.SelectTable.Location = new System.Drawing.Point(12, 12);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.SelectedIndex = 0;
            this.SelectTable.Size = new System.Drawing.Size(436, 233);
            this.SelectTable.TabIndex = 16;
            // 
            // Teams
            // 
            this.Teams.Location = new System.Drawing.Point(4, 25);
            this.Teams.Name = "Teams";
            this.Teams.Padding = new System.Windows.Forms.Padding(3);
            this.Teams.Size = new System.Drawing.Size(428, 204);
            this.Teams.TabIndex = 0;
            this.Teams.Text = "Teams";
            this.Teams.UseVisualStyleBackColor = true;
            this.Teams.Click += new System.EventHandler(this.Teams_Click);
            // 
            // Games
            // 
            this.Games.Controls.Add(this.gameIDInput);
            this.Games.Controls.Add(this.gameIDLabel);
            this.Games.Controls.Add(this.gameNumberOfPlayersPerTeamInput);
            this.Games.Controls.Add(this.gameLabel);
            this.Games.Controls.Add(this.playersPerTeamLabel);
            this.Games.Controls.Add(this.typeLabel);
            this.Games.Controls.Add(this.gameTypeInput);
            this.Games.Controls.Add(this.gameNameInput);
            this.Games.Controls.Add(this.deviceLabel);
            this.Games.Controls.Add(this.gameDeviceInput);
            this.Games.Location = new System.Drawing.Point(4, 25);
            this.Games.Name = "Games";
            this.Games.Padding = new System.Windows.Forms.Padding(3);
            this.Games.Size = new System.Drawing.Size(428, 204);
            this.Games.TabIndex = 1;
            this.Games.Text = "Games";
            this.Games.UseVisualStyleBackColor = true;
            this.Games.Click += new System.EventHandler(this.Games_Click);
            // 
            // gameIDInput
            // 
            this.gameIDInput.Location = new System.Drawing.Point(158, 27);
            this.gameIDInput.Name = "gameIDInput";
            this.gameIDInput.Size = new System.Drawing.Size(100, 22);
            this.gameIDInput.TabIndex = 17;
            // 
            // gameIDLabel
            // 
            this.gameIDLabel.AutoSize = true;
            this.gameIDLabel.Location = new System.Drawing.Point(16, 34);
            this.gameIDLabel.Name = "gameIDLabel";
            this.gameIDLabel.Size = new System.Drawing.Size(60, 16);
            this.gameIDLabel.TabIndex = 16;
            this.gameIDLabel.Text = "GameID:";
            // 
            // Players
            // 
            this.Players.Location = new System.Drawing.Point(4, 25);
            this.Players.Name = "Players";
            this.Players.Padding = new System.Windows.Forms.Padding(3);
            this.Players.Size = new System.Drawing.Size(428, 204);
            this.Players.TabIndex = 2;
            this.Players.Text = "Players";
            this.Players.UseVisualStyleBackColor = true;
            this.Players.Click += new System.EventHandler(this.Players_Click);
            // 
            // Rosters
            // 
            this.Rosters.Location = new System.Drawing.Point(4, 25);
            this.Rosters.Name = "Rosters";
            this.Rosters.Padding = new System.Windows.Forms.Padding(3);
            this.Rosters.Size = new System.Drawing.Size(428, 204);
            this.Rosters.TabIndex = 3;
            this.Rosters.Text = "Rosters";
            this.Rosters.UseVisualStyleBackColor = true;
            this.Rosters.Click += new System.EventHandler(this.Rosters_Click);
            // 
            // Events
            // 
            this.Events.Location = new System.Drawing.Point(4, 25);
            this.Events.Name = "Events";
            this.Events.Padding = new System.Windows.Forms.Padding(3);
            this.Events.Size = new System.Drawing.Size(428, 204);
            this.Events.TabIndex = 4;
            this.Events.Text = "Events";
            this.Events.UseVisualStyleBackColor = true;
            this.Events.Click += new System.EventHandler(this.Events_Click);
            // 
            // EsportsDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.displayTable);
            this.Name = "EsportsDatabase";
            this.Text = "Esports Database";
            this.Load += new System.EventHandler(this.EsportsDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).EndInit();
            this.SelectTable.ResumeLayout(false);
            this.Games.ResumeLayout(false);
            this.Games.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView displayTable;
        private System.Windows.Forms.TextBox gameNameInput;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.TextBox gameTypeInput;
        private System.Windows.Forms.TextBox gameNumberOfPlayersPerTeamInput;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label playersPerTeamLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.TextBox gameDeviceInput;
        private System.Windows.Forms.TabControl SelectTable;
        private System.Windows.Forms.TabPage Teams;
        private System.Windows.Forms.TabPage Games;
        private System.Windows.Forms.TextBox gameIDInput;
        private System.Windows.Forms.Label gameIDLabel;
        private System.Windows.Forms.TabPage Players;
        private System.Windows.Forms.TabPage Rosters;
        private System.Windows.Forms.TabPage Events;
    }
}

