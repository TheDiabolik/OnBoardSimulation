namespace OnBoard
{
    partial class GeneralSettingsModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettingsModal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_tabPageTrain = new System.Windows.Forms.TabPage();
            this.m_groupBoxWorkingCycle = new System.Windows.Forms.GroupBox();
            this.m_labelOperationTime = new System.Windows.Forms.Label();
            this.m_numericUpDownOperationTime = new System.Windows.Forms.NumericUpDown();
            this.m_labelWorkingUIRefresh = new System.Windows.Forms.Label();
            this.m_numericUpDownWorkingCycleUIRefresh = new System.Windows.Forms.NumericUpDown();
            this.m_labelWorkingCycleMessageSend = new System.Windows.Forms.Label();
            this.m_numericUpDownWorkingCycleMessageSend = new System.Windows.Forms.NumericUpDown();
            this.m_labelWorkingCycleOBATC = new System.Windows.Forms.Label();
            this.m_numericUpDownWorkingCycleOBATC = new System.Windows.Forms.NumericUpDown();
            this.m_checkedListBoxTrains = new System.Windows.Forms.CheckedListBox();
            this.m_groupBoxTrainStart = new System.Windows.Forms.GroupBox();
            this.m_numericUpDownMinute = new System.Windows.Forms.NumericUpDown();
            this.m_labelMinute = new System.Windows.Forms.Label();
            this.m_labelSecond = new System.Windows.Forms.Label();
            this.m_numericUpDownSecond = new System.Windows.Forms.NumericUpDown();
            this.m_tabPageRoute = new System.Windows.Forms.TabPage();
            this.m_textBoxEndRangeTrackID = new System.Windows.Forms.TextBox();
            this.m_textBoxStartRangeTrackID = new System.Windows.Forms.TextBox();
            this.m_labelEndTrackID = new System.Windows.Forms.Label();
            this.m_labelStartTrackID = new System.Windows.Forms.Label();
            this.m_radioButtonFromFileTracks = new System.Windows.Forms.RadioButton();
            this.m_radioButtonManuelInputTracks = new System.Windows.Forms.RadioButton();
            this.m_tabPageLogs = new System.Windows.Forms.TabPage();
            this.m_groupBoxSQLLog = new System.Windows.Forms.GroupBox();
            this.m_checkBoxSQLLogs = new System.Windows.Forms.CheckBox();
            this.m_textBoxPersonnelID = new System.Windows.Forms.TextBox();
            this.m_labelStaffID = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.m_checkBoxOBATP_TO_WSATP = new System.Windows.Forms.CheckBox();
            this.m_checkBoxWSATP_TO_OBATP = new System.Windows.Forms.CheckBox();
            this.m_groupBoxATS = new System.Windows.Forms.GroupBox();
            this.m_checkBoxATS_TO_OBATO = new System.Windows.Forms.CheckBox();
            this.m_checkBoxATS_TO_OBATO_Init = new System.Windows.Forms.CheckBox();
            this.m_checkBoxOBATO_TO_ATS = new System.Windows.Forms.CheckBox();
            this.m_radioButtonEnglish = new System.Windows.Forms.RadioButton();
            this.m_radioButtonTurkish = new System.Windows.Forms.RadioButton();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.m_tabPageTrain.SuspendLayout();
            this.m_groupBoxWorkingCycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownOperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleUIRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleMessageSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleOBATC)).BeginInit();
            this.m_groupBoxTrainStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownSecond)).BeginInit();
            this.m_tabPageRoute.SuspendLayout();
            this.m_tabPageLogs.SuspendLayout();
            this.m_groupBoxSQLLog.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.m_groupBoxATS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.m_tabPageTrain);
            this.tabControl1.Controls.Add(this.m_tabPageRoute);
            this.tabControl1.Controls.Add(this.m_tabPageLogs);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 277);
            this.tabControl1.TabIndex = 16;
            // 
            // m_tabPageTrain
            // 
            this.m_tabPageTrain.Controls.Add(this.m_groupBoxWorkingCycle);
            this.m_tabPageTrain.Controls.Add(this.m_checkedListBoxTrains);
            this.m_tabPageTrain.Controls.Add(this.m_groupBoxTrainStart);
            this.m_tabPageTrain.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageTrain.Name = "m_tabPageTrain";
            this.m_tabPageTrain.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageTrain.Size = new System.Drawing.Size(466, 251);
            this.m_tabPageTrain.TabIndex = 0;
            this.m_tabPageTrain.Text = "Train Start";
            this.m_tabPageTrain.UseVisualStyleBackColor = true;
            // 
            // m_groupBoxWorkingCycle
            // 
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_labelOperationTime);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_numericUpDownOperationTime);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_labelWorkingUIRefresh);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_numericUpDownWorkingCycleUIRefresh);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_labelWorkingCycleMessageSend);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_numericUpDownWorkingCycleMessageSend);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_labelWorkingCycleOBATC);
            this.m_groupBoxWorkingCycle.Controls.Add(this.m_numericUpDownWorkingCycleOBATC);
            this.m_groupBoxWorkingCycle.Location = new System.Drawing.Point(6, 111);
            this.m_groupBoxWorkingCycle.Name = "m_groupBoxWorkingCycle";
            this.m_groupBoxWorkingCycle.Size = new System.Drawing.Size(239, 134);
            this.m_groupBoxWorkingCycle.TabIndex = 22;
            this.m_groupBoxWorkingCycle.TabStop = false;
            this.m_groupBoxWorkingCycle.Text = "Working Cycle";
            // 
            // m_labelOperationTime
            // 
            this.m_labelOperationTime.Location = new System.Drawing.Point(-4, 30);
            this.m_labelOperationTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelOperationTime.Name = "m_labelOperationTime";
            this.m_labelOperationTime.Size = new System.Drawing.Size(118, 13);
            this.m_labelOperationTime.TabIndex = 23;
            this.m_labelOperationTime.Text = "Operation Time (ms) : ";
            this.m_labelOperationTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numericUpDownOperationTime
            // 
            this.m_numericUpDownOperationTime.Location = new System.Drawing.Point(126, 30);
            this.m_numericUpDownOperationTime.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownOperationTime.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.m_numericUpDownOperationTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericUpDownOperationTime.Name = "m_numericUpDownOperationTime";
            this.m_numericUpDownOperationTime.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownOperationTime.TabIndex = 24;
            this.m_numericUpDownOperationTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_labelWorkingUIRefresh
            // 
            this.m_labelWorkingUIRefresh.Location = new System.Drawing.Point(9, 101);
            this.m_labelWorkingUIRefresh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelWorkingUIRefresh.Name = "m_labelWorkingUIRefresh";
            this.m_labelWorkingUIRefresh.Size = new System.Drawing.Size(106, 13);
            this.m_labelWorkingUIRefresh.TabIndex = 21;
            this.m_labelWorkingUIRefresh.Text = "UI Refresh (ms) : ";
            this.m_labelWorkingUIRefresh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numericUpDownWorkingCycleUIRefresh
            // 
            this.m_numericUpDownWorkingCycleUIRefresh.Location = new System.Drawing.Point(126, 101);
            this.m_numericUpDownWorkingCycleUIRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownWorkingCycleUIRefresh.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleUIRefresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleUIRefresh.Name = "m_numericUpDownWorkingCycleUIRefresh";
            this.m_numericUpDownWorkingCycleUIRefresh.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownWorkingCycleUIRefresh.TabIndex = 22;
            this.m_numericUpDownWorkingCycleUIRefresh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_labelWorkingCycleMessageSend
            // 
            this.m_labelWorkingCycleMessageSend.Location = new System.Drawing.Point(6, 77);
            this.m_labelWorkingCycleMessageSend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelWorkingCycleMessageSend.Name = "m_labelWorkingCycleMessageSend";
            this.m_labelWorkingCycleMessageSend.Size = new System.Drawing.Size(109, 13);
            this.m_labelWorkingCycleMessageSend.TabIndex = 19;
            this.m_labelWorkingCycleMessageSend.Text = "Message Send (ms) : ";
            this.m_labelWorkingCycleMessageSend.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numericUpDownWorkingCycleMessageSend
            // 
            this.m_numericUpDownWorkingCycleMessageSend.Location = new System.Drawing.Point(126, 77);
            this.m_numericUpDownWorkingCycleMessageSend.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownWorkingCycleMessageSend.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleMessageSend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleMessageSend.Name = "m_numericUpDownWorkingCycleMessageSend";
            this.m_numericUpDownWorkingCycleMessageSend.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownWorkingCycleMessageSend.TabIndex = 20;
            this.m_numericUpDownWorkingCycleMessageSend.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_labelWorkingCycleOBATC
            // 
            this.m_labelWorkingCycleOBATC.Location = new System.Drawing.Point(12, 53);
            this.m_labelWorkingCycleOBATC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelWorkingCycleOBATC.Name = "m_labelWorkingCycleOBATC";
            this.m_labelWorkingCycleOBATC.Size = new System.Drawing.Size(103, 13);
            this.m_labelWorkingCycleOBATC.TabIndex = 17;
            this.m_labelWorkingCycleOBATC.Text = "OBATC (ms) : ";
            this.m_labelWorkingCycleOBATC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numericUpDownWorkingCycleOBATC
            // 
            this.m_numericUpDownWorkingCycleOBATC.Location = new System.Drawing.Point(126, 53);
            this.m_numericUpDownWorkingCycleOBATC.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownWorkingCycleOBATC.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleOBATC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericUpDownWorkingCycleOBATC.Name = "m_numericUpDownWorkingCycleOBATC";
            this.m_numericUpDownWorkingCycleOBATC.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownWorkingCycleOBATC.TabIndex = 18;
            this.m_numericUpDownWorkingCycleOBATC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_checkedListBoxTrains
            // 
            this.m_checkedListBoxTrains.FormattingEnabled = true;
            this.m_checkedListBoxTrains.Location = new System.Drawing.Point(251, 16);
            this.m_checkedListBoxTrains.Name = "m_checkedListBoxTrains";
            this.m_checkedListBoxTrains.Size = new System.Drawing.Size(203, 229);
            this.m_checkedListBoxTrains.TabIndex = 14;
            // 
            // m_groupBoxTrainStart
            // 
            this.m_groupBoxTrainStart.Controls.Add(this.m_numericUpDownMinute);
            this.m_groupBoxTrainStart.Controls.Add(this.m_labelMinute);
            this.m_groupBoxTrainStart.Controls.Add(this.m_labelSecond);
            this.m_groupBoxTrainStart.Controls.Add(this.m_numericUpDownSecond);
            this.m_groupBoxTrainStart.Location = new System.Drawing.Point(6, 16);
            this.m_groupBoxTrainStart.Name = "m_groupBoxTrainStart";
            this.m_groupBoxTrainStart.Size = new System.Drawing.Size(239, 89);
            this.m_groupBoxTrainStart.TabIndex = 21;
            this.m_groupBoxTrainStart.TabStop = false;
            this.m_groupBoxTrainStart.Text = "Frequency";
            // 
            // m_numericUpDownMinute
            // 
            this.m_numericUpDownMinute.Location = new System.Drawing.Point(126, 28);
            this.m_numericUpDownMinute.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownMinute.Name = "m_numericUpDownMinute";
            this.m_numericUpDownMinute.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownMinute.TabIndex = 16;
            // 
            // m_labelMinute
            // 
            this.m_labelMinute.Location = new System.Drawing.Point(49, 28);
            this.m_labelMinute.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelMinute.Name = "m_labelMinute";
            this.m_labelMinute.Size = new System.Drawing.Size(66, 13);
            this.m_labelMinute.TabIndex = 15;
            this.m_labelMinute.Text = "Minute : ";
            this.m_labelMinute.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelSecond
            // 
            this.m_labelSecond.Location = new System.Drawing.Point(44, 52);
            this.m_labelSecond.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelSecond.Name = "m_labelSecond";
            this.m_labelSecond.Size = new System.Drawing.Size(71, 13);
            this.m_labelSecond.TabIndex = 17;
            this.m_labelSecond.Text = "Second : ";
            this.m_labelSecond.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numericUpDownSecond
            // 
            this.m_numericUpDownSecond.Location = new System.Drawing.Point(126, 52);
            this.m_numericUpDownSecond.Margin = new System.Windows.Forms.Padding(2);
            this.m_numericUpDownSecond.Name = "m_numericUpDownSecond";
            this.m_numericUpDownSecond.Size = new System.Drawing.Size(90, 20);
            this.m_numericUpDownSecond.TabIndex = 18;
            // 
            // m_tabPageRoute
            // 
            this.m_tabPageRoute.Controls.Add(this.m_textBoxEndRangeTrackID);
            this.m_tabPageRoute.Controls.Add(this.m_textBoxStartRangeTrackID);
            this.m_tabPageRoute.Controls.Add(this.m_labelEndTrackID);
            this.m_tabPageRoute.Controls.Add(this.m_labelStartTrackID);
            this.m_tabPageRoute.Controls.Add(this.m_radioButtonFromFileTracks);
            this.m_tabPageRoute.Controls.Add(this.m_radioButtonManuelInputTracks);
            this.m_tabPageRoute.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageRoute.Name = "m_tabPageRoute";
            this.m_tabPageRoute.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageRoute.Size = new System.Drawing.Size(466, 251);
            this.m_tabPageRoute.TabIndex = 1;
            this.m_tabPageRoute.Text = "Route";
            this.m_tabPageRoute.UseVisualStyleBackColor = true;
            // 
            // m_textBoxEndRangeTrackID
            // 
            this.m_textBoxEndRangeTrackID.Location = new System.Drawing.Point(219, 101);
            this.m_textBoxEndRangeTrackID.Name = "m_textBoxEndRangeTrackID";
            this.m_textBoxEndRangeTrackID.Size = new System.Drawing.Size(147, 20);
            this.m_textBoxEndRangeTrackID.TabIndex = 11;
            // 
            // m_textBoxStartRangeTrackID
            // 
            this.m_textBoxStartRangeTrackID.Location = new System.Drawing.Point(219, 75);
            this.m_textBoxStartRangeTrackID.Name = "m_textBoxStartRangeTrackID";
            this.m_textBoxStartRangeTrackID.Size = new System.Drawing.Size(147, 20);
            this.m_textBoxStartRangeTrackID.TabIndex = 10;
            // 
            // m_labelEndTrackID
            // 
            this.m_labelEndTrackID.AutoSize = true;
            this.m_labelEndTrackID.Location = new System.Drawing.Point(103, 104);
            this.m_labelEndTrackID.Name = "m_labelEndTrackID";
            this.m_labelEndTrackID.Size = new System.Drawing.Size(80, 13);
            this.m_labelEndTrackID.TabIndex = 9;
            this.m_labelEndTrackID.Text = "End Track ID : ";
            // 
            // m_labelStartTrackID
            // 
            this.m_labelStartTrackID.AutoSize = true;
            this.m_labelStartTrackID.Location = new System.Drawing.Point(100, 78);
            this.m_labelStartTrackID.Name = "m_labelStartTrackID";
            this.m_labelStartTrackID.Size = new System.Drawing.Size(83, 13);
            this.m_labelStartTrackID.TabIndex = 8;
            this.m_labelStartTrackID.Text = "Start Track ID : ";
            // 
            // m_radioButtonFromFileTracks
            // 
            this.m_radioButtonFromFileTracks.AutoSize = true;
            this.m_radioButtonFromFileTracks.Location = new System.Drawing.Point(267, 145);
            this.m_radioButtonFromFileTracks.Name = "m_radioButtonFromFileTracks";
            this.m_radioButtonFromFileTracks.Size = new System.Drawing.Size(99, 17);
            this.m_radioButtonFromFileTracks.TabIndex = 7;
            this.m_radioButtonFromFileTracks.TabStop = true;
            this.m_radioButtonFromFileTracks.Text = "From File Tracls";
            this.m_radioButtonFromFileTracks.UseVisualStyleBackColor = true;
            // 
            // m_radioButtonManuelInputTracks
            // 
            this.m_radioButtonManuelInputTracks.AutoSize = true;
            this.m_radioButtonManuelInputTracks.Location = new System.Drawing.Point(103, 145);
            this.m_radioButtonManuelInputTracks.Name = "m_radioButtonManuelInputTracks";
            this.m_radioButtonManuelInputTracks.Size = new System.Drawing.Size(123, 17);
            this.m_radioButtonManuelInputTracks.TabIndex = 6;
            this.m_radioButtonManuelInputTracks.TabStop = true;
            this.m_radioButtonManuelInputTracks.Text = "Manuel Input Tracks";
            this.m_radioButtonManuelInputTracks.UseVisualStyleBackColor = true;
            // 
            // m_tabPageLogs
            // 
            this.m_tabPageLogs.Controls.Add(this.m_groupBoxSQLLog);
            this.m_tabPageLogs.Controls.Add(this.groupBox);
            this.m_tabPageLogs.Controls.Add(this.m_groupBoxATS);
            this.m_tabPageLogs.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageLogs.Name = "m_tabPageLogs";
            this.m_tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageLogs.Size = new System.Drawing.Size(466, 251);
            this.m_tabPageLogs.TabIndex = 2;
            this.m_tabPageLogs.Text = "Logs";
            this.m_tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // m_groupBoxSQLLog
            // 
            this.m_groupBoxSQLLog.Controls.Add(this.m_checkBoxSQLLogs);
            this.m_groupBoxSQLLog.Controls.Add(this.m_textBoxPersonnelID);
            this.m_groupBoxSQLLog.Controls.Add(this.m_labelStaffID);
            this.m_groupBoxSQLLog.Location = new System.Drawing.Point(6, 143);
            this.m_groupBoxSQLLog.Name = "m_groupBoxSQLLog";
            this.m_groupBoxSQLLog.Size = new System.Drawing.Size(444, 88);
            this.m_groupBoxSQLLog.TabIndex = 7;
            this.m_groupBoxSQLLog.TabStop = false;
            this.m_groupBoxSQLLog.Text = "SQL";
            // 
            // m_checkBoxSQLLogs
            // 
            this.m_checkBoxSQLLogs.AutoSize = true;
            this.m_checkBoxSQLLogs.Location = new System.Drawing.Point(261, 36);
            this.m_checkBoxSQLLogs.Name = "m_checkBoxSQLLogs";
            this.m_checkBoxSQLLogs.Size = new System.Drawing.Size(117, 17);
            this.m_checkBoxSQLLogs.TabIndex = 21;
            this.m_checkBoxSQLLogs.Text = "Write Logs To SQL";
            this.m_checkBoxSQLLogs.UseVisualStyleBackColor = true;
            this.m_checkBoxSQLLogs.CheckedChanged += new System.EventHandler(this.m_checkBoxSQLLogs_CheckedChanged);
            // 
            // m_textBoxPersonnelID
            // 
            this.m_textBoxPersonnelID.Location = new System.Drawing.Point(119, 33);
            this.m_textBoxPersonnelID.Name = "m_textBoxPersonnelID";
            this.m_textBoxPersonnelID.Size = new System.Drawing.Size(100, 20);
            this.m_textBoxPersonnelID.TabIndex = 20;
            this.m_textBoxPersonnelID.EnabledChanged += new System.EventHandler(this.m_textBoxPersonnelID_EnabledChanged);
            // 
            // m_labelStaffID
            // 
            this.m_labelStaffID.AutoSize = true;
            this.m_labelStaffID.Location = new System.Drawing.Point(16, 36);
            this.m_labelStaffID.Name = "m_labelStaffID";
            this.m_labelStaffID.Size = new System.Drawing.Size(77, 13);
            this.m_labelStaffID.TabIndex = 19;
            this.m_labelStaffID.Text = "Personnel ID : ";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.m_checkBoxOBATP_TO_WSATP);
            this.groupBox.Controls.Add(this.m_checkBoxWSATP_TO_OBATP);
            this.groupBox.Location = new System.Drawing.Point(231, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(219, 131);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "WSATC";
            // 
            // m_checkBoxOBATP_TO_WSATP
            // 
            this.m_checkBoxOBATP_TO_WSATP.AutoSize = true;
            this.m_checkBoxOBATP_TO_WSATP.Location = new System.Drawing.Point(25, 45);
            this.m_checkBoxOBATP_TO_WSATP.Name = "m_checkBoxOBATP_TO_WSATP";
            this.m_checkBoxOBATP_TO_WSATP.Size = new System.Drawing.Size(128, 17);
            this.m_checkBoxOBATP_TO_WSATP.TabIndex = 3;
            this.m_checkBoxOBATP_TO_WSATP.Text = "OBATP_TO_WSATP";
            this.m_checkBoxOBATP_TO_WSATP.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxWSATP_TO_OBATP
            // 
            this.m_checkBoxWSATP_TO_OBATP.AutoSize = true;
            this.m_checkBoxWSATP_TO_OBATP.Location = new System.Drawing.Point(25, 68);
            this.m_checkBoxWSATP_TO_OBATP.Name = "m_checkBoxWSATP_TO_OBATP";
            this.m_checkBoxWSATP_TO_OBATP.Size = new System.Drawing.Size(128, 17);
            this.m_checkBoxWSATP_TO_OBATP.TabIndex = 4;
            this.m_checkBoxWSATP_TO_OBATP.Text = "WSATP_TO_OBATP";
            this.m_checkBoxWSATP_TO_OBATP.UseVisualStyleBackColor = true;
            // 
            // m_groupBoxATS
            // 
            this.m_groupBoxATS.Controls.Add(this.m_checkBoxATS_TO_OBATO);
            this.m_groupBoxATS.Controls.Add(this.m_checkBoxATS_TO_OBATO_Init);
            this.m_groupBoxATS.Controls.Add(this.m_checkBoxOBATO_TO_ATS);
            this.m_groupBoxATS.Location = new System.Drawing.Point(6, 6);
            this.m_groupBoxATS.Name = "m_groupBoxATS";
            this.m_groupBoxATS.Size = new System.Drawing.Size(219, 131);
            this.m_groupBoxATS.TabIndex = 5;
            this.m_groupBoxATS.TabStop = false;
            this.m_groupBoxATS.Text = "ATS";
            // 
            // m_checkBoxATS_TO_OBATO
            // 
            this.m_checkBoxATS_TO_OBATO.AutoSize = true;
            this.m_checkBoxATS_TO_OBATO.Location = new System.Drawing.Point(19, 36);
            this.m_checkBoxATS_TO_OBATO.Name = "m_checkBoxATS_TO_OBATO";
            this.m_checkBoxATS_TO_OBATO.Size = new System.Drawing.Size(111, 17);
            this.m_checkBoxATS_TO_OBATO.TabIndex = 0;
            this.m_checkBoxATS_TO_OBATO.Text = "ATS_TO_OBATO";
            this.m_checkBoxATS_TO_OBATO.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxATS_TO_OBATO_Init
            // 
            this.m_checkBoxATS_TO_OBATO_Init.AutoSize = true;
            this.m_checkBoxATS_TO_OBATO_Init.Location = new System.Drawing.Point(19, 59);
            this.m_checkBoxATS_TO_OBATO_Init.Name = "m_checkBoxATS_TO_OBATO_Init";
            this.m_checkBoxATS_TO_OBATO_Init.Size = new System.Drawing.Size(131, 17);
            this.m_checkBoxATS_TO_OBATO_Init.TabIndex = 1;
            this.m_checkBoxATS_TO_OBATO_Init.Text = "ATS_TO_OBATO_Init";
            this.m_checkBoxATS_TO_OBATO_Init.UseVisualStyleBackColor = true;
            // 
            // m_checkBoxOBATO_TO_ATS
            // 
            this.m_checkBoxOBATO_TO_ATS.AutoSize = true;
            this.m_checkBoxOBATO_TO_ATS.Location = new System.Drawing.Point(19, 82);
            this.m_checkBoxOBATO_TO_ATS.Name = "m_checkBoxOBATO_TO_ATS";
            this.m_checkBoxOBATO_TO_ATS.Size = new System.Drawing.Size(111, 17);
            this.m_checkBoxOBATO_TO_ATS.TabIndex = 2;
            this.m_checkBoxOBATO_TO_ATS.Text = "OBATO_TO_ATS";
            this.m_checkBoxOBATO_TO_ATS.UseVisualStyleBackColor = true;
            this.m_checkBoxOBATO_TO_ATS.CheckedChanged += new System.EventHandler(this.m_checkBoxOBATO_TO_ATS_CheckedChanged);
            // 
            // m_radioButtonEnglish
            // 
            this.m_radioButtonEnglish.Checked = true;
            this.m_radioButtonEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioButtonEnglish.Image = global::OnBoard.Properties.Resources.england;
            this.m_radioButtonEnglish.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_radioButtonEnglish.Location = new System.Drawing.Point(66, 319);
            this.m_radioButtonEnglish.Name = "m_radioButtonEnglish";
            this.m_radioButtonEnglish.Size = new System.Drawing.Size(40, 23);
            this.m_radioButtonEnglish.TabIndex = 17;
            this.m_radioButtonEnglish.TabStop = true;
            this.m_radioButtonEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_radioButtonEnglish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_radioButtonEnglish.UseVisualStyleBackColor = true;
            this.m_radioButtonEnglish.CheckedChanged += new System.EventHandler(this.m_radioButtonEnglish_CheckedChanged);
            // 
            // m_radioButtonTurkish
            // 
            this.m_radioButtonTurkish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioButtonTurkish.Image = global::OnBoard.Properties.Resources.turkey;
            this.m_radioButtonTurkish.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_radioButtonTurkish.Location = new System.Drawing.Point(16, 319);
            this.m_radioButtonTurkish.Name = "m_radioButtonTurkish";
            this.m_radioButtonTurkish.Size = new System.Drawing.Size(40, 23);
            this.m_radioButtonTurkish.TabIndex = 18;
            this.m_radioButtonTurkish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_radioButtonTurkish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_radioButtonTurkish.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Image = global::OnBoard.Properties.Resources.apply;
            this.m_buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonApply.Location = new System.Drawing.Point(387, 294);
            this.m_buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(83, 48);
            this.m_buttonApply.TabIndex = 10;
            this.m_buttonApply.Text = "Apply";
            this.m_buttonApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Image = global::OnBoard.Properties.Resources.save;
            this.m_buttonSave.Location = new System.Drawing.Point(299, 294);
            this.m_buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(83, 48);
            this.m_buttonSave.TabIndex = 9;
            this.m_buttonSave.Text = "Save";
            this.m_buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // GeneralSettingsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(493, 346);
            this.Controls.Add(this.m_radioButtonTurkish);
            this.Controls.Add(this.m_radioButtonEnglish);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GeneralSettingsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralSettingsModal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralSettingsModal_FormClosed);
            this.Load += new System.EventHandler(this.GeneralSettingsModal_Load);
            this.tabControl1.ResumeLayout(false);
            this.m_tabPageTrain.ResumeLayout(false);
            this.m_groupBoxWorkingCycle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownOperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleUIRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleMessageSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownWorkingCycleOBATC)).EndInit();
            this.m_groupBoxTrainStart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownSecond)).EndInit();
            this.m_tabPageRoute.ResumeLayout(false);
            this.m_tabPageRoute.PerformLayout();
            this.m_tabPageLogs.ResumeLayout(false);
            this.m_groupBoxSQLLog.ResumeLayout(false);
            this.m_groupBoxSQLLog.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.m_groupBoxATS.ResumeLayout(false);
            this.m_groupBoxATS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage m_tabPageTrain;
        private System.Windows.Forms.GroupBox m_groupBoxTrainStart;
        private System.Windows.Forms.NumericUpDown m_numericUpDownMinute;
        private System.Windows.Forms.Label m_labelMinute;
        private System.Windows.Forms.Label m_labelSecond;
        private System.Windows.Forms.NumericUpDown m_numericUpDownSecond;
        private System.Windows.Forms.TabPage m_tabPageRoute;
        private System.Windows.Forms.TextBox m_textBoxEndRangeTrackID;
        private System.Windows.Forms.TextBox m_textBoxStartRangeTrackID;
        private System.Windows.Forms.Label m_labelEndTrackID;
        private System.Windows.Forms.Label m_labelStartTrackID;
        private System.Windows.Forms.RadioButton m_radioButtonFromFileTracks;
        private System.Windows.Forms.RadioButton m_radioButtonManuelInputTracks;
        private System.Windows.Forms.TabPage m_tabPageLogs;
        private System.Windows.Forms.CheckedListBox m_checkedListBoxTrains;
        private System.Windows.Forms.GroupBox m_groupBoxWorkingCycle;
        private System.Windows.Forms.Label m_labelWorkingCycleOBATC;
        private System.Windows.Forms.NumericUpDown m_numericUpDownWorkingCycleOBATC;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox m_checkBoxOBATP_TO_WSATP;
        private System.Windows.Forms.CheckBox m_checkBoxWSATP_TO_OBATP;
        private System.Windows.Forms.GroupBox m_groupBoxATS;
        private System.Windows.Forms.CheckBox m_checkBoxATS_TO_OBATO;
        private System.Windows.Forms.CheckBox m_checkBoxATS_TO_OBATO_Init;
        private System.Windows.Forms.CheckBox m_checkBoxOBATO_TO_ATS;
        private System.Windows.Forms.Label m_labelWorkingUIRefresh;
        private System.Windows.Forms.NumericUpDown m_numericUpDownWorkingCycleUIRefresh;
        private System.Windows.Forms.Label m_labelWorkingCycleMessageSend;
        private System.Windows.Forms.NumericUpDown m_numericUpDownWorkingCycleMessageSend;
        private System.Windows.Forms.RadioButton m_radioButtonEnglish;
        private System.Windows.Forms.RadioButton m_radioButtonTurkish;
        private System.Windows.Forms.GroupBox m_groupBoxSQLLog;
        private System.Windows.Forms.CheckBox m_checkBoxSQLLogs;
        private System.Windows.Forms.TextBox m_textBoxPersonnelID;
        private System.Windows.Forms.Label m_labelStaffID;
        private System.Windows.Forms.Label m_labelOperationTime;
        private System.Windows.Forms.NumericUpDown m_numericUpDownOperationTime;
    }
}