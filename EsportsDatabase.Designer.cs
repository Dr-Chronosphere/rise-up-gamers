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
            this.SelectTable = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).BeginInit();
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
            this.gameNameInput.Location = new System.Drawing.Point(119, 158);
            this.gameNameInput.Name = "gameNameInput";
            this.gameNameInput.Size = new System.Drawing.Size(100, 22);
            this.gameNameInput.TabIndex = 2;
            // 
            // SelectTable
            // 
            this.SelectTable.FormattingEnabled = true;
            this.SelectTable.Items.AddRange(new object[] {
            "Team",
            "Game",
            "Player",
            "Roster",
            "Event"});
            this.SelectTable.Location = new System.Drawing.Point(30, 26);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.Size = new System.Drawing.Size(375, 24);
            this.SelectTable.TabIndex = 3;
            this.SelectTable.Text = "--- SELECT TABLE ---";
            this.SelectTable.SelectedValueChanged += new System.EventHandler(this.SelectTable_SelectedValueChanged);
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(27, 158);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(47, 16);
            this.gameLabel.TabIndex = 4;
            this.gameLabel.Text = "Game:";
            // 
            // gameTypeInput
            // 
            this.gameTypeInput.Location = new System.Drawing.Point(119, 217);
            this.gameTypeInput.Name = "gameTypeInput";
            this.gameTypeInput.Size = new System.Drawing.Size(100, 22);
            this.gameTypeInput.TabIndex = 5;
            // 
            // gameNumberOfPlayersPerTeamInput
            // 
            this.gameNumberOfPlayersPerTeamInput.Location = new System.Drawing.Point(169, 258);
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
            this.playersPerTeamLabel.Location = new System.Drawing.Point(27, 261);
            this.playersPerTeamLabel.Name = "playersPerTeamLabel";
            this.playersPerTeamLabel.Size = new System.Drawing.Size(136, 16);
            this.playersPerTeamLabel.TabIndex = 12;
            this.playersPerTeamLabel.Text = "# of Players per team:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(27, 223);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(42, 16);
            this.typeLabel.TabIndex = 13;
            this.typeLabel.Text = "Type:";
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(27, 191);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(53, 16);
            this.deviceLabel.TabIndex = 15;
            this.deviceLabel.Text = "Device:";
            // 
            // gameDeviceInput
            // 
            this.gameDeviceInput.Location = new System.Drawing.Point(119, 188);
            this.gameDeviceInput.Name = "gameDeviceInput";
            this.gameDeviceInput.Size = new System.Drawing.Size(100, 22);
            this.gameDeviceInput.TabIndex = 14;
            // 
            // EsportsDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deviceLabel);
            this.Controls.Add(this.gameDeviceInput);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.playersPerTeamLabel);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.gameNumberOfPlayersPerTeamInput);
            this.Controls.Add(this.gameTypeInput);
            this.Controls.Add(this.gameLabel);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.gameNameInput);
            this.Controls.Add(this.displayTable);
            this.Name = "EsportsDatabase";
            this.Text = "Esports Database";
            this.Load += new System.EventHandler(this.EsportsDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView displayTable;
        private System.Windows.Forms.TextBox gameNameInput;
        private System.Windows.Forms.ComboBox SelectTable;
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
    }
}

