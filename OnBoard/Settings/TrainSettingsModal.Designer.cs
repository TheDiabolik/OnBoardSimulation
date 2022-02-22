namespace OnBoard
{
    partial class TrainSettingsModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainSettingsModal));
            this.m_groupBoxTrainSettings = new System.Windows.Forms.GroupBox();
            this.m_textBoxTrainDeceleration = new System.Windows.Forms.TextBox();
            this.m_textBoxTrainSpeedLimit = new System.Windows.Forms.TextBox();
            this.m_textBoxTrainAcceleration = new System.Windows.Forms.TextBox();
            this.m_textBoxTrainLength = new System.Windows.Forms.TextBox();
            this.m_labelTrainSpeedLimit = new System.Windows.Forms.Label();
            this.m_labelMaxTrainAcceleration = new System.Windows.Forms.Label();
            this.m_labelMaxTrainDeceleration = new System.Windows.Forms.Label();
            this.m_labelTrainLengthCM = new System.Windows.Forms.Label();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.m_groupBoxTrainSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_groupBoxTrainSettings
            // 
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxTrainDeceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxTrainSpeedLimit);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxTrainAcceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxTrainLength);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelTrainSpeedLimit);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelMaxTrainAcceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelMaxTrainDeceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelTrainLengthCM);
            this.m_groupBoxTrainSettings.Location = new System.Drawing.Point(9, 18);
            this.m_groupBoxTrainSettings.Margin = new System.Windows.Forms.Padding(2);
            this.m_groupBoxTrainSettings.Name = "m_groupBoxTrainSettings";
            this.m_groupBoxTrainSettings.Padding = new System.Windows.Forms.Padding(2);
            this.m_groupBoxTrainSettings.Size = new System.Drawing.Size(720, 94);
            this.m_groupBoxTrainSettings.TabIndex = 2;
            this.m_groupBoxTrainSettings.TabStop = false;
            this.m_groupBoxTrainSettings.Text = "General Train Settings";
            // 
            // m_textBoxTrainDeceleration
            // 
            this.m_textBoxTrainDeceleration.Location = new System.Drawing.Point(561, 55);
            this.m_textBoxTrainDeceleration.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxTrainDeceleration.Name = "m_textBoxTrainDeceleration";
            this.m_textBoxTrainDeceleration.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxTrainDeceleration.TabIndex = 7;
            // 
            // m_textBoxTrainSpeedLimit
            // 
            this.m_textBoxTrainSpeedLimit.Location = new System.Drawing.Point(561, 32);
            this.m_textBoxTrainSpeedLimit.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxTrainSpeedLimit.Name = "m_textBoxTrainSpeedLimit";
            this.m_textBoxTrainSpeedLimit.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxTrainSpeedLimit.TabIndex = 6;
            // 
            // m_textBoxTrainAcceleration
            // 
            this.m_textBoxTrainAcceleration.Location = new System.Drawing.Point(216, 55);
            this.m_textBoxTrainAcceleration.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxTrainAcceleration.Name = "m_textBoxTrainAcceleration";
            this.m_textBoxTrainAcceleration.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxTrainAcceleration.TabIndex = 5;
            // 
            // m_textBoxTrainLength
            // 
            this.m_textBoxTrainLength.Location = new System.Drawing.Point(216, 32);
            this.m_textBoxTrainLength.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxTrainLength.Name = "m_textBoxTrainLength";
            this.m_textBoxTrainLength.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxTrainLength.TabIndex = 4;
            // 
            // m_labelTrainSpeedLimit
            // 
            this.m_labelTrainSpeedLimit.Location = new System.Drawing.Point(380, 32);
            this.m_labelTrainSpeedLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelTrainSpeedLimit.Name = "m_labelTrainSpeedLimit";
            this.m_labelTrainSpeedLimit.Size = new System.Drawing.Size(156, 13);
            this.m_labelTrainSpeedLimit.TabIndex = 3;
            this.m_labelTrainSpeedLimit.Text = "Train Speed Limit (km/h) : ";
            this.m_labelTrainSpeedLimit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelMaxTrainAcceleration
            // 
            this.m_labelMaxTrainAcceleration.Location = new System.Drawing.Point(30, 55);
            this.m_labelMaxTrainAcceleration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelMaxTrainAcceleration.Name = "m_labelMaxTrainAcceleration";
            this.m_labelMaxTrainAcceleration.Size = new System.Drawing.Size(162, 13);
            this.m_labelMaxTrainAcceleration.TabIndex = 2;
            this.m_labelMaxTrainAcceleration.Text = "Max Acceleration (m/s²) : ";
            this.m_labelMaxTrainAcceleration.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelMaxTrainDeceleration
            // 
            this.m_labelMaxTrainDeceleration.Location = new System.Drawing.Point(384, 55);
            this.m_labelMaxTrainDeceleration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelMaxTrainDeceleration.Name = "m_labelMaxTrainDeceleration";
            this.m_labelMaxTrainDeceleration.Size = new System.Drawing.Size(153, 13);
            this.m_labelMaxTrainDeceleration.TabIndex = 1;
            this.m_labelMaxTrainDeceleration.Text = "Max Deceleration (m/s²) : ";
            this.m_labelMaxTrainDeceleration.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelTrainLengthCM
            // 
            this.m_labelTrainLengthCM.Location = new System.Drawing.Point(57, 32);
            this.m_labelTrainLengthCM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelTrainLengthCM.Name = "m_labelTrainLengthCM";
            this.m_labelTrainLengthCM.Size = new System.Drawing.Size(133, 13);
            this.m_labelTrainLengthCM.TabIndex = 0;
            this.m_labelTrainLengthCM.Text = "Train Length (cm) : ";
            this.m_labelTrainLengthCM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::OnBoard.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(610, 138);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 8;
            this.m_buttonApply.Text = "Apply";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::OnBoard.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(523, 138);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 7;
            this.m_buttonSave.Text = "Save";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // TrainSettingsModal
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(746, 195);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Controls.Add(this.m_groupBoxTrainSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrainSettingsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainSettingsModal_FormClosing);
            this.Load += new System.EventHandler(this.TrainSettings_Load);
            this.m_groupBoxTrainSettings.ResumeLayout(false);
            this.m_groupBoxTrainSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox m_groupBoxTrainSettings;
        private System.Windows.Forms.TextBox m_textBoxTrainDeceleration;
        private System.Windows.Forms.TextBox m_textBoxTrainSpeedLimit;
        private System.Windows.Forms.TextBox m_textBoxTrainAcceleration;
        private System.Windows.Forms.TextBox m_textBoxTrainLength;
        private System.Windows.Forms.Label m_labelTrainSpeedLimit;
        private System.Windows.Forms.Label m_labelMaxTrainAcceleration;
        private System.Windows.Forms.Label m_labelMaxTrainDeceleration;
        private System.Windows.Forms.Label m_labelTrainLengthCM;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
    }
}