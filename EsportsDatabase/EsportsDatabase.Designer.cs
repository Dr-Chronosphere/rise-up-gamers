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
            this.InsertBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.Games = new System.Windows.Forms.TabPage();
            this.gameDeviceInput = new System.Windows.Forms.TextBox();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.gameNameInput = new System.Windows.Forms.TextBox();
            this.gameTypeInput = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.playersPerTeamLabel = new System.Windows.Forms.Label();
            this.gameLabel = new System.Windows.Forms.Label();
            this.gameNumberOfPlayersPerTeamInput = new System.Windows.Forms.TextBox();
            this.gameIDLabel = new System.Windows.Forms.Label();
            this.gameIDInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectTable = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).BeginInit();
            this.Games.SuspendLayout();
            this.SelectTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayTable
            // 
            this.displayTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayTable.Location = new System.Drawing.Point(340, 21);
            this.displayTable.Margin = new System.Windows.Forms.Padding(2);
            this.displayTable.Name = "displayTable";
            this.displayTable.RowHeadersWidth = 51;
            this.displayTable.RowTemplate.Height = 24;
            this.displayTable.Size = new System.Drawing.Size(242, 317);
            this.displayTable.TabIndex = 0;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Location = new System.Drawing.Point(22, 310);
            this.InsertBtn.Margin = new System.Windows.Forms.Padding(2);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(86, 28);
            this.InsertBtn.TabIndex = 8;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(112, 310);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(86, 28);
            this.UpdateBtn.TabIndex = 9;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(202, 310);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(86, 28);
            this.DeleteBtn.TabIndex = 10;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Games
            // 
            this.Games.Controls.Add(this.label1);
            this.Games.Controls.Add(this.gameIDInput);
            this.Games.Controls.Add(this.gameNumberOfPlayersPerTeamInput);
            this.Games.Controls.Add(this.gameTypeInput);
            this.Games.Controls.Add(this.gameNameInput);
            this.Games.Controls.Add(this.gameDeviceInput);
            this.Games.Controls.Add(this.gameIDLabel);
            this.Games.Controls.Add(this.gameLabel);
            this.Games.Controls.Add(this.playersPerTeamLabel);
            this.Games.Controls.Add(this.typeLabel);
            this.Games.Controls.Add(this.deviceLabel);
            this.Games.Location = new System.Drawing.Point(4, 22);
            this.Games.Margin = new System.Windows.Forms.Padding(2);
            this.Games.Name = "Games";
            this.Games.Padding = new System.Windows.Forms.Padding(2);
            this.Games.Size = new System.Drawing.Size(319, 163);
            this.Games.TabIndex = 1;
            this.Games.Text = "Games";
            this.Games.UseVisualStyleBackColor = true;
            // 
            // gameDeviceInput
            // 
            this.gameDeviceInput.Location = new System.Drawing.Point(118, 72);
            this.gameDeviceInput.Margin = new System.Windows.Forms.Padding(2);
            this.gameDeviceInput.Name = "gameDeviceInput";
            this.gameDeviceInput.Size = new System.Drawing.Size(76, 20);
            this.gameDeviceInput.TabIndex = 14;
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(12, 74);
            this.deviceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(44, 13);
            this.deviceLabel.TabIndex = 15;
            this.deviceLabel.Text = "Device:";
            // 
            // gameNameInput
            // 
            this.gameNameInput.Location = new System.Drawing.Point(118, 47);
            this.gameNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.gameNameInput.Name = "gameNameInput";
            this.gameNameInput.Size = new System.Drawing.Size(76, 20);
            this.gameNameInput.TabIndex = 2;
            // 
            // gameTypeInput
            // 
            this.gameTypeInput.Location = new System.Drawing.Point(118, 99);
            this.gameTypeInput.Margin = new System.Windows.Forms.Padding(2);
            this.gameTypeInput.Name = "gameTypeInput";
            this.gameTypeInput.Size = new System.Drawing.Size(76, 20);
            this.gameTypeInput.TabIndex = 5;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(12, 102);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 13;
            this.typeLabel.Text = "Type:";
            // 
            // playersPerTeamLabel
            // 
            this.playersPerTeamLabel.AutoSize = true;
            this.playersPerTeamLabel.Location = new System.Drawing.Point(12, 128);
            this.playersPerTeamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playersPerTeamLabel.Name = "playersPerTeamLabel";
            this.playersPerTeamLabel.Size = new System.Drawing.Size(110, 13);
            this.playersPerTeamLabel.TabIndex = 12;
            this.playersPerTeamLabel.Text = "# of Players per team:";
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(12, 50);
            this.gameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(38, 13);
            this.gameLabel.TabIndex = 4;
            this.gameLabel.Text = "Game:";
            // 
            // gameNumberOfPlayersPerTeamInput
            // 
            this.gameNumberOfPlayersPerTeamInput.Location = new System.Drawing.Point(118, 124);
            this.gameNumberOfPlayersPerTeamInput.Margin = new System.Windows.Forms.Padding(2);
            this.gameNumberOfPlayersPerTeamInput.Name = "gameNumberOfPlayersPerTeamInput";
            this.gameNumberOfPlayersPerTeamInput.Size = new System.Drawing.Size(76, 20);
            this.gameNumberOfPlayersPerTeamInput.TabIndex = 7;
            // 
            // gameIDLabel
            // 
            this.gameIDLabel.AutoSize = true;
            this.gameIDLabel.Location = new System.Drawing.Point(12, 28);
            this.gameIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameIDLabel.Name = "gameIDLabel";
            this.gameIDLabel.Size = new System.Drawing.Size(49, 13);
            this.gameIDLabel.TabIndex = 16;
            this.gameIDLabel.Text = "GameID:";
            // 
            // gameIDInput
            // 
            this.gameIDInput.Location = new System.Drawing.Point(118, 22);
            this.gameIDInput.Margin = new System.Windows.Forms.Padding(2);
            this.gameIDInput.Name = "gameIDInput";
            this.gameIDInput.Size = new System.Drawing.Size(76, 20);
            this.gameIDInput.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "for update and delete";
            // 
            // SelectTable
            // 
            this.SelectTable.Controls.Add(this.Games);
            this.SelectTable.Location = new System.Drawing.Point(9, 10);
            this.SelectTable.Margin = new System.Windows.Forms.Padding(2);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.SelectedIndex = 0;
            this.SelectTable.Size = new System.Drawing.Size(327, 189);
            this.SelectTable.TabIndex = 16;
            this.SelectTable.Selected += new System.Windows.Forms.TabControlEventHandler(this.SelectTable_Selected);
            // 
            // EsportsDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.displayTable);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EsportsDatabase";
            this.Text = "Esports Database";
            this.Load += new System.EventHandler(this.EsportsDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).EndInit();
            this.Games.ResumeLayout(false);
            this.Games.PerformLayout();
            this.SelectTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView displayTable;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TabPage Games;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gameIDInput;
        private System.Windows.Forms.TextBox gameNumberOfPlayersPerTeamInput;
        private System.Windows.Forms.TextBox gameTypeInput;
        private System.Windows.Forms.TextBox gameNameInput;
        private System.Windows.Forms.TextBox gameDeviceInput;
        private System.Windows.Forms.Label gameIDLabel;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.Label playersPerTeamLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.TabControl SelectTable;
    }
}

