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
            this.SelectTable = new System.Windows.Forms.TabControl();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.JoinTables = new System.Windows.Forms.CheckedListBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.JoinLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTable
            // 
            this.displayTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.displayTable.Location = new System.Drawing.Point(414, 0);
            this.displayTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.displayTable.Name = "displayTable";
            this.displayTable.ReadOnly = true;
            this.displayTable.RowHeadersWidth = 51;
            this.displayTable.RowTemplate.Height = 24;
            this.displayTable.Size = new System.Drawing.Size(386, 450);
            this.displayTable.TabIndex = 0;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InsertBtn.Location = new System.Drawing.Point(29, 405);
            this.InsertBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(115, 34);
            this.InsertBtn.TabIndex = 8;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateBtn.Location = new System.Drawing.Point(148, 405);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(115, 34);
            this.UpdateBtn.TabIndex = 9;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteBtn.Location = new System.Drawing.Point(269, 405);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(115, 34);
            this.DeleteBtn.TabIndex = 10;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // SelectTable
            // 
            this.SelectTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectTable.Location = new System.Drawing.Point(0, 0);
            this.SelectTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.SelectedIndex = 0;
            this.SelectTable.Size = new System.Drawing.Size(414, 225);
            this.SelectTable.TabIndex = 16;
            this.SelectTable.Selected += new System.Windows.Forms.TabControlEventHandler(this.SelectTable_Selected);
            // 
            // JoinBtn
            // 
            this.JoinBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JoinBtn.Location = new System.Drawing.Point(269, 261);
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.Size = new System.Drawing.Size(115, 34);
            this.JoinBtn.TabIndex = 17;
            this.JoinBtn.Text = "Join";
            this.JoinBtn.UseVisualStyleBackColor = true;
            this.JoinBtn.Click += new System.EventHandler(this.JoinBtn_Click);
            // 
            // JoinTables
            // 
            this.JoinTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JoinTables.FormattingEnabled = true;
            this.JoinTables.Items.AddRange(new object[] {
            "Teams",
            "Games",
            "Players",
            "Rosters",
            "Events"});
            this.JoinTables.Location = new System.Drawing.Point(157, 261);
            this.JoinTables.Name = "JoinTables";
            this.JoinTables.Size = new System.Drawing.Size(106, 106);
            this.JoinTables.TabIndex = 18;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBtn.Location = new System.Drawing.Point(29, 261);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(115, 34);
            this.SearchBtn.TabIndex = 19;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(26, 227);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 16);
            this.ErrorLabel.TabIndex = 20;
            // 
            // SearchLabel
            // 
            this.SearchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(26, 298);
            this.SearchLabel.MaximumSize = new System.Drawing.Size(120, 0);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(111, 48);
            this.SearchLabel.TabIndex = 21;
            this.SearchLabel.Text = "Searches current table based on input values";
            // 
            // JoinLabel
            // 
            this.JoinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JoinLabel.AutoSize = true;
            this.JoinLabel.Location = new System.Drawing.Point(269, 298);
            this.JoinLabel.MaximumSize = new System.Drawing.Size(120, 0);
            this.JoinLabel.Name = "JoinLabel";
            this.JoinLabel.Size = new System.Drawing.Size(119, 80);
            this.JoinLabel.TabIndex = 22;
            this.JoinLabel.Text = "Joins current table with tables selected in checklist based on matching GameID";
            // 
            // EsportsDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JoinLabel);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.JoinTables);
            this.Controls.Add(this.JoinBtn);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.displayTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EsportsDatabase";
            this.Text = "Esports Database";
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView displayTable;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TabControl SelectTable;
        private System.Windows.Forms.Button JoinBtn;
        private System.Windows.Forms.CheckedListBox JoinTables;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label JoinLabel;
    }
}

