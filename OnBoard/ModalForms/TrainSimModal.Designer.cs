namespace OnBoard
{
    partial class TrainSimModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainSimModal));
            this.m_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_panel
            // 
            this.m_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panel.Location = new System.Drawing.Point(4, 12);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(1428, 216);
            this.m_panel.TabIndex = 0;
            this.m_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panel_Paint);
            // 
            // TrainSimModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 240);
            this.Controls.Add(this.m_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainSimModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speed Simulation";
            this.Load += new System.EventHandler(this.TrainSimModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panel;
    }
}