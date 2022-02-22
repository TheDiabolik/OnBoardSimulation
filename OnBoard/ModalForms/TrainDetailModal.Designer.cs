namespace OnBoard
{
    partial class TrainDetailModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainDetailModal));
            this.m_propertyGridTrainDetails = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // m_propertyGridTrainDetails
            // 
            this.m_propertyGridTrainDetails.Location = new System.Drawing.Point(12, 0);
            this.m_propertyGridTrainDetails.Name = "m_propertyGridTrainDetails";
            this.m_propertyGridTrainDetails.Size = new System.Drawing.Size(821, 797);
            this.m_propertyGridTrainDetails.TabIndex = 0;
            // 
            // TrainDetailModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(843, 809);
            this.Controls.Add(this.m_propertyGridTrainDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrainDetailModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrainDetailModal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainDetailModal_FormClosing);
            this.Load += new System.EventHandler(this.TrainDetailModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid m_propertyGridTrainDetails;
    }
}