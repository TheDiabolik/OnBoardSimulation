namespace OnBoard
{
    partial class TrackSettingsModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackSettingsModal));
            this.m_dataGridViewManuelInputTrack = new System.Windows.Forms.DataGridView();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_tabPageManuelInput = new System.Windows.Forms.TabPage();
            this.m_tabPageFromFile = new System.Windows.Forms.TabPage();
            this.m_dataGridViewFromFileTrack = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewManuelInputTrack)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.m_tabPageManuelInput.SuspendLayout();
            this.m_tabPageFromFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewFromFileTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridViewManuelInputTrack
            // 
            this.m_dataGridViewManuelInputTrack.AllowUserToAddRows = false;
            this.m_dataGridViewManuelInputTrack.AllowUserToDeleteRows = false;
            this.m_dataGridViewManuelInputTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewManuelInputTrack.Location = new System.Drawing.Point(2, 5);
            this.m_dataGridViewManuelInputTrack.Margin = new System.Windows.Forms.Padding(2);
            this.m_dataGridViewManuelInputTrack.MultiSelect = false;
            this.m_dataGridViewManuelInputTrack.Name = "m_dataGridViewManuelInputTrack";
            this.m_dataGridViewManuelInputTrack.RowTemplate.Height = 24;
            this.m_dataGridViewManuelInputTrack.Size = new System.Drawing.Size(950, 387);
            this.m_dataGridViewManuelInputTrack.TabIndex = 27;
            this.m_dataGridViewManuelInputTrack.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dataGridViewTrackRoute_RowsAdded);
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::OnBoard.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(871, 428);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 30;
            this.m_buttonApply.Text = "Apply";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::OnBoard.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(784, 428);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 29;
            this.m_buttonSave.Text = "Save";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.m_tabPageManuelInput);
            this.tabControl1.Controls.Add(this.m_tabPageFromFile);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 423);
            this.tabControl1.TabIndex = 31;
            // 
            // m_tabPageManuelInput
            // 
            this.m_tabPageManuelInput.Controls.Add(this.m_dataGridViewManuelInputTrack);
            this.m_tabPageManuelInput.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageManuelInput.Name = "m_tabPageManuelInput";
            this.m_tabPageManuelInput.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageManuelInput.Size = new System.Drawing.Size(957, 397);
            this.m_tabPageManuelInput.TabIndex = 0;
            this.m_tabPageManuelInput.Text = "Manuel Input";
            this.m_tabPageManuelInput.UseVisualStyleBackColor = true;
            // 
            // m_tabPageFromFile
            // 
            this.m_tabPageFromFile.Controls.Add(this.m_dataGridViewFromFileTrack);
            this.m_tabPageFromFile.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageFromFile.Name = "m_tabPageFromFile";
            this.m_tabPageFromFile.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageFromFile.Size = new System.Drawing.Size(957, 397);
            this.m_tabPageFromFile.TabIndex = 1;
            this.m_tabPageFromFile.Text = "From File";
            this.m_tabPageFromFile.UseVisualStyleBackColor = true;
            // 
            // m_dataGridViewFromFileTrack
            // 
            this.m_dataGridViewFromFileTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewFromFileTrack.Location = new System.Drawing.Point(2, 5);
            this.m_dataGridViewFromFileTrack.Name = "m_dataGridViewFromFileTrack";
            this.m_dataGridViewFromFileTrack.Size = new System.Drawing.Size(954, 391);
            this.m_dataGridViewFromFileTrack.TabIndex = 0;
            this.m_dataGridViewFromFileTrack.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ViewTrackRoute_RowsAdded);
            // 
            // TrackSettingsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(965, 481);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TrackSettingsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Track Settings";
            this.Load += new System.EventHandler(this.TrackSettingsModal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewManuelInputTrack)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.m_tabPageManuelInput.ResumeLayout(false);
            this.m_tabPageFromFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewFromFileTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView m_dataGridViewManuelInputTrack;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage m_tabPageManuelInput;
        private System.Windows.Forms.TabPage m_tabPageFromFile;
        private System.Windows.Forms.DataGridView m_dataGridViewFromFileTrack;
    }
}