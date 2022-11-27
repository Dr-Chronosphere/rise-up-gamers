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
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTable
            // 
            this.displayTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayTable.Location = new System.Drawing.Point(390, 12);
            this.displayTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.displayTable.Name = "displayTable";
            this.displayTable.RowHeadersWidth = 51;
            this.displayTable.RowTemplate.Height = 24;
            this.displayTable.Size = new System.Drawing.Size(386, 404);
            this.displayTable.TabIndex = 0;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Location = new System.Drawing.Point(29, 382);
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
            this.UpdateBtn.Location = new System.Drawing.Point(149, 382);
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
            this.DeleteBtn.Location = new System.Drawing.Point(269, 382);
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
            this.SelectTable.Location = new System.Drawing.Point(29, 12);
            this.SelectTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.SelectedIndex = 0;
            this.SelectTable.Size = new System.Drawing.Size(355, 304);
            this.SelectTable.TabIndex = 16;
            this.SelectTable.Selected += new System.Windows.Forms.TabControlEventHandler(this.SelectTable_Selected);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EsportsDatabase";
            this.Text = "Esports Database";
            ((System.ComponentModel.ISupportInitialize)(this.displayTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView displayTable;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TabControl SelectTable;
    }
}

