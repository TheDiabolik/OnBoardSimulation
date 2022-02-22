namespace OnBoard
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_groupBoxTrainSettings = new System.Windows.Forms.GroupBox();
            this.m_labelDoorCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_pictureBoxDoorStatus = new System.Windows.Forms.PictureBox();
            this.m_textBoxDoorTimerCounter = new System.Windows.Forms.TextBox();
            this.m_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_labelDoorTimerCounter = new System.Windows.Forms.Label();
            this.m_comboBoxTrain = new System.Windows.Forms.ComboBox();
            this.m_listViewFootPrintTracks = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_textBoxCurrentLocation = new System.Windows.Forms.TextBox();
            this.m_listViewVirtualOccupation = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_textBoxCurrentAcceleration = new System.Windows.Forms.TextBox();
            this.m_textBoxRearCurrentLocation = new System.Windows.Forms.TextBox();
            this.m_textBoxCurrentTrainSpeedKM = new System.Windows.Forms.TextBox();
            this.m_labelDoorStatus = new System.Windows.Forms.Label();
            this.m_labelCurrentLocation = new System.Windows.Forms.Label();
            this.m_labelCurrentAcceleration = new System.Windows.Forms.Label();
            this.m_labelRearCurrentLocation = new System.Windows.Forms.Label();
            this.m_labelCurrentTrainSpeedKM = new System.Windows.Forms.Label();
            this.m_labelTrains = new System.Windows.Forms.Label();
            this.m_dataGridViewAllTrains = new System.Windows.Forms.DataGridView();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_settingsPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_generalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_trainItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_communicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_trainSimItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_routeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_aboutPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.m_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.m_richTextBoxCommunicationLogs = new System.Windows.Forms.RichTextBox();
            this.m_groupBoxAllTrains = new System.Windows.Forms.GroupBox();
            this.m_buttonStop = new System.Windows.Forms.Button();
            this.m_buttonStart = new System.Windows.Forms.Button();
            this.m_backgroundWorkerCommunicationLogs = new System.ComponentModel.BackgroundWorker();
            this.m_backgroundWorkerUILogs = new System.ComponentModel.BackgroundWorker();
            this.m_richTextBoxTrainsLogs = new System.Windows.Forms.RichTextBox();
            this.m_groupBoxLog = new System.Windows.Forms.GroupBox();
            this.m_tabControlLogs = new System.Windows.Forms.TabControl();
            this.m_tabPageCommunication = new System.Windows.Forms.TabPage();
            this.m_tabPageIncomingMessage = new System.Windows.Forms.TabPage();
            this.m_richTextBoxIncomingMessage = new System.Windows.Forms.RichTextBox();
            this.m_tabPageOutgoingMessage = new System.Windows.Forms.TabPage();
            this.m_richTextBoxOutgoingMessage = new System.Windows.Forms.RichTextBox();
            this.m_tabPageTrain = new System.Windows.Forms.TabPage();
            this.m_backgroundWorkerIncomingMessage = new System.ComponentModel.BackgroundWorker();
            this.m_backgroundWorkerOutcomingMessage = new System.ComponentModel.BackgroundWorker();
            this.m_groupBoxTrainSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxDoorStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewAllTrains)).BeginInit();
            this.m_mainMenu.SuspendLayout();
            this.m_groupBoxAllTrains.SuspendLayout();
            this.m_groupBoxLog.SuspendLayout();
            this.m_tabControlLogs.SuspendLayout();
            this.m_tabPageCommunication.SuspendLayout();
            this.m_tabPageIncomingMessage.SuspendLayout();
            this.m_tabPageOutgoingMessage.SuspendLayout();
            this.m_tabPageTrain.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_groupBoxTrainSettings
            // 
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelDoorCounter);
            this.m_groupBoxTrainSettings.Controls.Add(this.panel1);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxDoorTimerCounter);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_listView);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelDoorTimerCounter);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_comboBoxTrain);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_listViewFootPrintTracks);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxCurrentLocation);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_listViewVirtualOccupation);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxCurrentAcceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxRearCurrentLocation);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_textBoxCurrentTrainSpeedKM);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelDoorStatus);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelCurrentLocation);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelCurrentAcceleration);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelRearCurrentLocation);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelCurrentTrainSpeedKM);
            this.m_groupBoxTrainSettings.Controls.Add(this.m_labelTrains);
            this.m_groupBoxTrainSettings.Location = new System.Drawing.Point(12, 211);
            this.m_groupBoxTrainSettings.Margin = new System.Windows.Forms.Padding(2);
            this.m_groupBoxTrainSettings.Name = "m_groupBoxTrainSettings";
            this.m_groupBoxTrainSettings.Padding = new System.Windows.Forms.Padding(2);
            this.m_groupBoxTrainSettings.Size = new System.Drawing.Size(748, 462);
            this.m_groupBoxTrainSettings.TabIndex = 2;
            this.m_groupBoxTrainSettings.TabStop = false;
            this.m_groupBoxTrainSettings.Text = "Train Parameters";
            // 
            // m_labelDoorCounter
            // 
            this.m_labelDoorCounter.AutoSize = true;
            this.m_labelDoorCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_labelDoorCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.m_labelDoorCounter.Location = new System.Drawing.Point(616, 85);
            this.m_labelDoorCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelDoorCounter.Name = "m_labelDoorCounter";
            this.m_labelDoorCounter.Size = new System.Drawing.Size(24, 33);
            this.m_labelDoorCounter.TabIndex = 30;
            this.m_labelDoorCounter.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_pictureBoxDoorStatus);
            this.panel1.Location = new System.Drawing.Point(561, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 38);
            this.panel1.TabIndex = 31;
            // 
            // m_pictureBoxDoorStatus
            // 
            this.m_pictureBoxDoorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictureBoxDoorStatus.Image = global::OnBoard.Properties.Resources.doorclose;
            this.m_pictureBoxDoorStatus.Location = new System.Drawing.Point(1, 1);
            this.m_pictureBoxDoorStatus.Margin = new System.Windows.Forms.Padding(2);
            this.m_pictureBoxDoorStatus.Name = "m_pictureBoxDoorStatus";
            this.m_pictureBoxDoorStatus.Size = new System.Drawing.Size(38, 35);
            this.m_pictureBoxDoorStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxDoorStatus.TabIndex = 29;
            this.m_pictureBoxDoorStatus.TabStop = false;
            // 
            // m_textBoxDoorTimerCounter
            // 
            this.m_textBoxDoorTimerCounter.Location = new System.Drawing.Point(562, 123);
            this.m_textBoxDoorTimerCounter.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxDoorTimerCounter.Name = "m_textBoxDoorTimerCounter";
            this.m_textBoxDoorTimerCounter.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxDoorTimerCounter.TabIndex = 12;
            this.m_textBoxDoorTimerCounter.Visible = false;
            // 
            // m_listView
            // 
            this.m_listView.BackColor = System.Drawing.Color.White;
            this.m_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.m_listView.ForeColor = System.Drawing.Color.Black;
            this.m_listView.FullRowSelect = true;
            this.m_listView.GridLines = true;
            this.m_listView.HideSelection = false;
            this.m_listView.Location = new System.Drawing.Point(49, 173);
            this.m_listView.Margin = new System.Windows.Forms.Padding(2);
            this.m_listView.MultiSelect = false;
            this.m_listView.Name = "m_listView";
            this.m_listView.Size = new System.Drawing.Size(317, 264);
            this.m_listView.TabIndex = 26;
            this.m_listView.UseCompatibleStateImageBehavior = false;
            this.m_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Route Tracks";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Station";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Speed Limit(km/sa)";
            this.columnHeader5.Width = 110;
            // 
            // m_labelDoorTimerCounter
            // 
            this.m_labelDoorTimerCounter.AutoSize = true;
            this.m_labelDoorTimerCounter.Location = new System.Drawing.Point(399, 123);
            this.m_labelDoorTimerCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelDoorTimerCounter.Name = "m_labelDoorTimerCounter";
            this.m_labelDoorTimerCounter.Size = new System.Drawing.Size(108, 13);
            this.m_labelDoorTimerCounter.TabIndex = 11;
            this.m_labelDoorTimerCounter.Text = "Door Timer Counter : ";
            this.m_labelDoorTimerCounter.Visible = false;
            // 
            // m_comboBoxTrain
            // 
            this.m_comboBoxTrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTrain.FormattingEnabled = true;
            this.m_comboBoxTrain.Location = new System.Drawing.Point(216, 32);
            this.m_comboBoxTrain.Margin = new System.Windows.Forms.Padding(2);
            this.m_comboBoxTrain.Name = "m_comboBoxTrain";
            this.m_comboBoxTrain.Size = new System.Drawing.Size(470, 21);
            this.m_comboBoxTrain.TabIndex = 3;
            this.m_comboBoxTrain.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxTrain_SelectedIndexChanged);
            // 
            // m_listViewFootPrintTracks
            // 
            this.m_listViewFootPrintTracks.BackColor = System.Drawing.Color.White;
            this.m_listViewFootPrintTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.m_listViewFootPrintTracks.ForeColor = System.Drawing.Color.Black;
            this.m_listViewFootPrintTracks.FullRowSelect = true;
            this.m_listViewFootPrintTracks.GridLines = true;
            this.m_listViewFootPrintTracks.HideSelection = false;
            this.m_listViewFootPrintTracks.LabelWrap = false;
            this.m_listViewFootPrintTracks.Location = new System.Drawing.Point(548, 173);
            this.m_listViewFootPrintTracks.Margin = new System.Windows.Forms.Padding(2);
            this.m_listViewFootPrintTracks.MultiSelect = false;
            this.m_listViewFootPrintTracks.Name = "m_listViewFootPrintTracks";
            this.m_listViewFootPrintTracks.Size = new System.Drawing.Size(138, 265);
            this.m_listViewFootPrintTracks.TabIndex = 28;
            this.m_listViewFootPrintTracks.UseCompatibleStateImageBehavior = false;
            this.m_listViewFootPrintTracks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "FootPrint Tracks";
            this.columnHeader4.Width = 105;
            // 
            // m_textBoxCurrentLocation
            // 
            this.m_textBoxCurrentLocation.Location = new System.Drawing.Point(561, 57);
            this.m_textBoxCurrentLocation.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxCurrentLocation.Name = "m_textBoxCurrentLocation";
            this.m_textBoxCurrentLocation.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxCurrentLocation.TabIndex = 10;
            // 
            // m_listViewVirtualOccupation
            // 
            this.m_listViewVirtualOccupation.BackColor = System.Drawing.Color.White;
            this.m_listViewVirtualOccupation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.m_listViewVirtualOccupation.ForeColor = System.Drawing.Color.Black;
            this.m_listViewVirtualOccupation.FullRowSelect = true;
            this.m_listViewVirtualOccupation.GridLines = true;
            this.m_listViewVirtualOccupation.HideSelection = false;
            this.m_listViewVirtualOccupation.Location = new System.Drawing.Point(389, 173);
            this.m_listViewVirtualOccupation.Margin = new System.Windows.Forms.Padding(2);
            this.m_listViewVirtualOccupation.MultiSelect = false;
            this.m_listViewVirtualOccupation.Name = "m_listViewVirtualOccupation";
            this.m_listViewVirtualOccupation.Size = new System.Drawing.Size(138, 265);
            this.m_listViewVirtualOccupation.TabIndex = 27;
            this.m_listViewVirtualOccupation.UseCompatibleStateImageBehavior = false;
            this.m_listViewVirtualOccupation.View = System.Windows.Forms.View.Details;
            this.m_listViewVirtualOccupation.SelectedIndexChanged += new System.EventHandler(this.m_listViewVirtualOccupation_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Virtual Occ. Tracks";
            this.columnHeader3.Width = 105;
            // 
            // m_textBoxCurrentAcceleration
            // 
            this.m_textBoxCurrentAcceleration.Location = new System.Drawing.Point(216, 105);
            this.m_textBoxCurrentAcceleration.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxCurrentAcceleration.Name = "m_textBoxCurrentAcceleration";
            this.m_textBoxCurrentAcceleration.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxCurrentAcceleration.TabIndex = 8;
            // 
            // m_textBoxRearCurrentLocation
            // 
            this.m_textBoxRearCurrentLocation.Location = new System.Drawing.Point(216, 81);
            this.m_textBoxRearCurrentLocation.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxRearCurrentLocation.Name = "m_textBoxRearCurrentLocation";
            this.m_textBoxRearCurrentLocation.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxRearCurrentLocation.TabIndex = 7;
            // 
            // m_textBoxCurrentTrainSpeedKM
            // 
            this.m_textBoxCurrentTrainSpeedKM.Location = new System.Drawing.Point(216, 57);
            this.m_textBoxCurrentTrainSpeedKM.Margin = new System.Windows.Forms.Padding(2);
            this.m_textBoxCurrentTrainSpeedKM.Name = "m_textBoxCurrentTrainSpeedKM";
            this.m_textBoxCurrentTrainSpeedKM.Size = new System.Drawing.Size(125, 20);
            this.m_textBoxCurrentTrainSpeedKM.TabIndex = 6;
            // 
            // m_labelDoorStatus
            // 
            this.m_labelDoorStatus.Location = new System.Drawing.Point(402, 85);
            this.m_labelDoorStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelDoorStatus.Name = "m_labelDoorStatus";
            this.m_labelDoorStatus.Size = new System.Drawing.Size(113, 12);
            this.m_labelDoorStatus.TabIndex = 5;
            this.m_labelDoorStatus.Text = "Door Status : ";
            this.m_labelDoorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_labelCurrentLocation
            // 
            this.m_labelCurrentLocation.Location = new System.Drawing.Point(398, 57);
            this.m_labelCurrentLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelCurrentLocation.Name = "m_labelCurrentLocation";
            this.m_labelCurrentLocation.Size = new System.Drawing.Size(117, 13);
            this.m_labelCurrentLocation.TabIndex = 4;
            this.m_labelCurrentLocation.Text = "Current Location (cm) : ";
            this.m_labelCurrentLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_labelCurrentAcceleration
            // 
            this.m_labelCurrentAcceleration.Location = new System.Drawing.Point(46, 105);
            this.m_labelCurrentAcceleration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelCurrentAcceleration.Name = "m_labelCurrentAcceleration";
            this.m_labelCurrentAcceleration.Size = new System.Drawing.Size(143, 13);
            this.m_labelCurrentAcceleration.TabIndex = 3;
            this.m_labelCurrentAcceleration.Text = "Current Acceleration : ";
            this.m_labelCurrentAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_labelRearCurrentLocation
            // 
            this.m_labelRearCurrentLocation.Location = new System.Drawing.Point(6, 81);
            this.m_labelRearCurrentLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelRearCurrentLocation.Name = "m_labelRearCurrentLocation";
            this.m_labelRearCurrentLocation.Size = new System.Drawing.Size(183, 13);
            this.m_labelRearCurrentLocation.TabIndex = 2;
            this.m_labelRearCurrentLocation.Text = "Rear Current Location (cm) : ";
            this.m_labelRearCurrentLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_labelCurrentTrainSpeedKM
            // 
            this.m_labelCurrentTrainSpeedKM.Location = new System.Drawing.Point(46, 57);
            this.m_labelCurrentTrainSpeedKM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelCurrentTrainSpeedKM.Name = "m_labelCurrentTrainSpeedKM";
            this.m_labelCurrentTrainSpeedKM.Size = new System.Drawing.Size(143, 13);
            this.m_labelCurrentTrainSpeedKM.TabIndex = 1;
            this.m_labelCurrentTrainSpeedKM.Text = "Current Speed (km/h) : ";
            this.m_labelCurrentTrainSpeedKM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_labelTrains
            // 
            this.m_labelTrains.Location = new System.Drawing.Point(46, 32);
            this.m_labelTrains.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_labelTrains.Name = "m_labelTrains";
            this.m_labelTrains.Size = new System.Drawing.Size(143, 13);
            this.m_labelTrains.TabIndex = 0;
            this.m_labelTrains.Text = "Trains : ";
            this.m_labelTrains.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_dataGridViewAllTrains
            // 
            this.m_dataGridViewAllTrains.AllowUserToAddRows = false;
            this.m_dataGridViewAllTrains.AllowUserToResizeColumns = false;
            this.m_dataGridViewAllTrains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dataGridViewAllTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewAllTrains.Location = new System.Drawing.Point(11, 17);
            this.m_dataGridViewAllTrains.Margin = new System.Windows.Forms.Padding(2);
            this.m_dataGridViewAllTrains.MultiSelect = false;
            this.m_dataGridViewAllTrains.Name = "m_dataGridViewAllTrains";
            this.m_dataGridViewAllTrains.ReadOnly = true;
            this.m_dataGridViewAllTrains.RowHeadersVisible = false;
            this.m_dataGridViewAllTrains.RowTemplate.Height = 24;
            this.m_dataGridViewAllTrains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dataGridViewAllTrains.Size = new System.Drawing.Size(1155, 157);
            this.m_dataGridViewAllTrains.TabIndex = 5;
            this.m_dataGridViewAllTrains.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dataGridViewAllTrains_CellContentClick);
            this.m_dataGridViewAllTrains.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dataGridViewAllTrains_CellDoubleClick);
            this.m_dataGridViewAllTrains.SelectionChanged += new System.EventHandler(this.m_dataGridViewAllTrains_SelectionChanged);
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_settingsPopup,
            this.m_aboutPopup});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.m_mainMenu.Size = new System.Drawing.Size(1192, 24);
            this.m_mainMenu.TabIndex = 7;
            this.m_mainMenu.Text = "menuStrip1";
            this.m_mainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.m_mainMenu_ItemClicked);
            // 
            // m_settingsPopup
            // 
            this.m_settingsPopup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_generalItem,
            this.m_trainItem,
            this.m_communicationItem,
            this.m_trainSimItem,
            this.m_routeItem});
            this.m_settingsPopup.Name = "m_settingsPopup";
            this.m_settingsPopup.Size = new System.Drawing.Size(61, 20);
            this.m_settingsPopup.Text = "&Settings";
            // 
            // m_generalItem
            // 
            this.m_generalItem.Name = "m_generalItem";
            this.m_generalItem.Size = new System.Drawing.Size(161, 22);
            this.m_generalItem.Text = "General";
            this.m_generalItem.Click += new System.EventHandler(this.m_generalItem_Click);
            // 
            // m_trainItem
            // 
            this.m_trainItem.Name = "m_trainItem";
            this.m_trainItem.Size = new System.Drawing.Size(161, 22);
            this.m_trainItem.Text = "Train";
            this.m_trainItem.Click += new System.EventHandler(this.m_trainItem_Click);
            // 
            // m_communicationItem
            // 
            this.m_communicationItem.Name = "m_communicationItem";
            this.m_communicationItem.Size = new System.Drawing.Size(161, 22);
            this.m_communicationItem.Text = "Communication";
            this.m_communicationItem.Click += new System.EventHandler(this.m_communicationItem_Click);
            // 
            // m_trainSimItem
            // 
            this.m_trainSimItem.Name = "m_trainSimItem";
            this.m_trainSimItem.Size = new System.Drawing.Size(161, 22);
            this.m_trainSimItem.Text = "Train Sim";
            this.m_trainSimItem.Visible = false;
            this.m_trainSimItem.Click += new System.EventHandler(this.m_trainSimItem_Click);
            // 
            // m_routeItem
            // 
            this.m_routeItem.Name = "m_routeItem";
            this.m_routeItem.Size = new System.Drawing.Size(161, 22);
            this.m_routeItem.Text = "Tracks";
            this.m_routeItem.Visible = false;
            this.m_routeItem.Click += new System.EventHandler(this.m_routeItem_Click);
            // 
            // m_aboutPopup
            // 
            this.m_aboutPopup.Name = "m_aboutPopup";
            this.m_aboutPopup.Size = new System.Drawing.Size(52, 20);
            this.m_aboutPopup.Text = "&About";
            this.m_aboutPopup.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // m_backgroundWorker
            // 
            this.m_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorker_DoWork);
            // 
            // m_richTextBoxCommunicationLogs
            // 
            this.m_richTextBoxCommunicationLogs.Location = new System.Drawing.Point(5, 5);
            this.m_richTextBoxCommunicationLogs.Margin = new System.Windows.Forms.Padding(2);
            this.m_richTextBoxCommunicationLogs.Name = "m_richTextBoxCommunicationLogs";
            this.m_richTextBoxCommunicationLogs.Size = new System.Drawing.Size(387, 362);
            this.m_richTextBoxCommunicationLogs.TabIndex = 8;
            this.m_richTextBoxCommunicationLogs.Text = "";
            this.m_richTextBoxCommunicationLogs.TextChanged += new System.EventHandler(this.m_richTextBox_TextChanged);
            // 
            // m_groupBoxAllTrains
            // 
            this.m_groupBoxAllTrains.Controls.Add(this.m_dataGridViewAllTrains);
            this.m_groupBoxAllTrains.Location = new System.Drawing.Point(7, 26);
            this.m_groupBoxAllTrains.Margin = new System.Windows.Forms.Padding(2);
            this.m_groupBoxAllTrains.Name = "m_groupBoxAllTrains";
            this.m_groupBoxAllTrains.Padding = new System.Windows.Forms.Padding(2);
            this.m_groupBoxAllTrains.Size = new System.Drawing.Size(1174, 181);
            this.m_groupBoxAllTrains.TabIndex = 29;
            this.m_groupBoxAllTrains.TabStop = false;
            this.m_groupBoxAllTrains.Text = "Trains";
            // 
            // m_buttonStop
            // 
            this.m_buttonStop.Enabled = false;
            this.m_buttonStop.Image = global::OnBoard.Properties.Resources._24_DisabledTrain;
            this.m_buttonStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonStop.Location = new System.Drawing.Point(1098, 638);
            this.m_buttonStop.Name = "m_buttonStop";
            this.m_buttonStop.Size = new System.Drawing.Size(75, 35);
            this.m_buttonStop.TabIndex = 31;
            this.m_buttonStop.Text = "Stop";
            this.m_buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonStop.UseVisualStyleBackColor = true;
            this.m_buttonStop.Click += new System.EventHandler(this.m_buttonStop_Click);
            // 
            // m_buttonStart
            // 
            this.m_buttonStart.Enabled = false;
            this.m_buttonStart.Image = global::OnBoard.Properties.Resources._24_HotTrain;
            this.m_buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_buttonStart.Location = new System.Drawing.Point(1017, 638);
            this.m_buttonStart.Name = "m_buttonStart";
            this.m_buttonStart.Size = new System.Drawing.Size(75, 35);
            this.m_buttonStart.TabIndex = 4;
            this.m_buttonStart.Text = "Start";
            this.m_buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_buttonStart.UseVisualStyleBackColor = true;
            this.m_buttonStart.Click += new System.EventHandler(this.m_buttonStart_Click);
            // 
            // m_backgroundWorkerCommunicationLogs
            // 
            this.m_backgroundWorkerCommunicationLogs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerCommunicationLogs_DoWork);
            // 
            // m_backgroundWorkerUILogs
            // 
            this.m_backgroundWorkerUILogs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerUILogs_DoWork);
            // 
            // m_richTextBoxTrainsLogs
            // 
            this.m_richTextBoxTrainsLogs.Location = new System.Drawing.Point(5, 5);
            this.m_richTextBoxTrainsLogs.Margin = new System.Windows.Forms.Padding(2);
            this.m_richTextBoxTrainsLogs.Name = "m_richTextBoxTrainsLogs";
            this.m_richTextBoxTrainsLogs.Size = new System.Drawing.Size(387, 362);
            this.m_richTextBoxTrainsLogs.TabIndex = 8;
            this.m_richTextBoxTrainsLogs.Text = "";
            this.m_richTextBoxTrainsLogs.TextChanged += new System.EventHandler(this.m_richTextBoxTrainsLogs_TextChanged);
            // 
            // m_groupBoxLog
            // 
            this.m_groupBoxLog.Controls.Add(this.m_tabControlLogs);
            this.m_groupBoxLog.Location = new System.Drawing.Point(765, 212);
            this.m_groupBoxLog.Name = "m_groupBoxLog";
            this.m_groupBoxLog.Size = new System.Drawing.Size(416, 420);
            this.m_groupBoxLog.TabIndex = 33;
            this.m_groupBoxLog.TabStop = false;
            this.m_groupBoxLog.Text = "Logs";
            // 
            // m_tabControlLogs
            // 
            this.m_tabControlLogs.Controls.Add(this.m_tabPageCommunication);
            this.m_tabControlLogs.Controls.Add(this.m_tabPageIncomingMessage);
            this.m_tabControlLogs.Controls.Add(this.m_tabPageOutgoingMessage);
            this.m_tabControlLogs.Controls.Add(this.m_tabPageTrain);
            this.m_tabControlLogs.Location = new System.Drawing.Point(3, 16);
            this.m_tabControlLogs.Name = "m_tabControlLogs";
            this.m_tabControlLogs.SelectedIndex = 0;
            this.m_tabControlLogs.Size = new System.Drawing.Size(405, 398);
            this.m_tabControlLogs.TabIndex = 0;
            // 
            // m_tabPageCommunication
            // 
            this.m_tabPageCommunication.Controls.Add(this.m_richTextBoxCommunicationLogs);
            this.m_tabPageCommunication.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageCommunication.Name = "m_tabPageCommunication";
            this.m_tabPageCommunication.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageCommunication.Size = new System.Drawing.Size(397, 372);
            this.m_tabPageCommunication.TabIndex = 0;
            this.m_tabPageCommunication.Text = "Communication";
            this.m_tabPageCommunication.UseVisualStyleBackColor = true;
            // 
            // m_tabPageIncomingMessage
            // 
            this.m_tabPageIncomingMessage.Controls.Add(this.m_richTextBoxIncomingMessage);
            this.m_tabPageIncomingMessage.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageIncomingMessage.Name = "m_tabPageIncomingMessage";
            this.m_tabPageIncomingMessage.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageIncomingMessage.Size = new System.Drawing.Size(397, 372);
            this.m_tabPageIncomingMessage.TabIndex = 2;
            this.m_tabPageIncomingMessage.Text = "Incoming Message";
            this.m_tabPageIncomingMessage.UseVisualStyleBackColor = true;
            // 
            // m_richTextBoxIncomingMessage
            // 
            this.m_richTextBoxIncomingMessage.Location = new System.Drawing.Point(5, 5);
            this.m_richTextBoxIncomingMessage.Margin = new System.Windows.Forms.Padding(2);
            this.m_richTextBoxIncomingMessage.Name = "m_richTextBoxIncomingMessage";
            this.m_richTextBoxIncomingMessage.Size = new System.Drawing.Size(387, 362);
            this.m_richTextBoxIncomingMessage.TabIndex = 9;
            this.m_richTextBoxIncomingMessage.Text = "";
            this.m_richTextBoxIncomingMessage.TextChanged += new System.EventHandler(this.m_richTextBoxIncomingMessage_TextChanged);
            // 
            // m_tabPageOutgoingMessage
            // 
            this.m_tabPageOutgoingMessage.Controls.Add(this.m_richTextBoxOutgoingMessage);
            this.m_tabPageOutgoingMessage.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageOutgoingMessage.Name = "m_tabPageOutgoingMessage";
            this.m_tabPageOutgoingMessage.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageOutgoingMessage.Size = new System.Drawing.Size(397, 372);
            this.m_tabPageOutgoingMessage.TabIndex = 3;
            this.m_tabPageOutgoingMessage.Text = "Outgoing Message";
            this.m_tabPageOutgoingMessage.UseVisualStyleBackColor = true;
            // 
            // m_richTextBoxOutgoingMessage
            // 
            this.m_richTextBoxOutgoingMessage.Location = new System.Drawing.Point(5, 5);
            this.m_richTextBoxOutgoingMessage.Margin = new System.Windows.Forms.Padding(2);
            this.m_richTextBoxOutgoingMessage.Name = "m_richTextBoxOutgoingMessage";
            this.m_richTextBoxOutgoingMessage.Size = new System.Drawing.Size(387, 362);
            this.m_richTextBoxOutgoingMessage.TabIndex = 9;
            this.m_richTextBoxOutgoingMessage.Text = "";
            this.m_richTextBoxOutgoingMessage.TextChanged += new System.EventHandler(this.m_richTextBoxOutgoingMessage_TextChanged);
            // 
            // m_tabPageTrain
            // 
            this.m_tabPageTrain.Controls.Add(this.m_richTextBoxTrainsLogs);
            this.m_tabPageTrain.Location = new System.Drawing.Point(4, 22);
            this.m_tabPageTrain.Name = "m_tabPageTrain";
            this.m_tabPageTrain.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabPageTrain.Size = new System.Drawing.Size(397, 372);
            this.m_tabPageTrain.TabIndex = 1;
            this.m_tabPageTrain.Text = "Train";
            this.m_tabPageTrain.UseVisualStyleBackColor = true;
            // 
            // m_backgroundWorkerIncomingMessage
            // 
            this.m_backgroundWorkerIncomingMessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerIncomingMessage_DoWork);
            // 
            // m_backgroundWorkerOutcomingMessage
            // 
            this.m_backgroundWorkerOutcomingMessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorkerOutcomingMessage_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1192, 680);
            this.Controls.Add(this.m_groupBoxLog);
            this.Controls.Add(this.m_buttonStop);
            this.Controls.Add(this.m_groupBoxAllTrains);
            this.Controls.Add(this.m_groupBoxTrainSettings);
            this.Controls.Add(this.m_buttonStart);
            this.Controls.Add(this.m_mainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnBoard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_groupBoxTrainSettings.ResumeLayout(false);
            this.m_groupBoxTrainSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxDoorStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewAllTrains)).EndInit();
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.m_groupBoxAllTrains.ResumeLayout(false);
            this.m_groupBoxLog.ResumeLayout(false);
            this.m_tabControlLogs.ResumeLayout(false);
            this.m_tabPageCommunication.ResumeLayout(false);
            this.m_tabPageIncomingMessage.ResumeLayout(false);
            this.m_tabPageOutgoingMessage.ResumeLayout(false);
            this.m_tabPageTrain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox m_groupBoxTrainSettings;
        private System.Windows.Forms.TextBox m_textBoxDoorTimerCounter;
        private System.Windows.Forms.Label m_labelDoorTimerCounter;
        private System.Windows.Forms.TextBox m_textBoxCurrentLocation;
        private System.Windows.Forms.TextBox m_textBoxCurrentAcceleration;
        private System.Windows.Forms.TextBox m_textBoxRearCurrentLocation;
        private System.Windows.Forms.TextBox m_textBoxCurrentTrainSpeedKM;
        private System.Windows.Forms.Label m_labelDoorStatus;
        private System.Windows.Forms.Label m_labelCurrentLocation;
        private System.Windows.Forms.Label m_labelCurrentAcceleration;
        private System.Windows.Forms.Label m_labelRearCurrentLocation;
        private System.Windows.Forms.Label m_labelCurrentTrainSpeedKM;
        private System.Windows.Forms.Label m_labelTrains;
        private System.Windows.Forms.Button m_buttonStart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_settingsPopup;
        private System.Windows.Forms.ToolStripMenuItem m_trainItem;
        private System.Windows.Forms.ToolStripMenuItem m_generalItem;
        private System.ComponentModel.BackgroundWorker m_backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem m_communicationItem;
        private System.Windows.Forms.ToolStripMenuItem m_trainSimItem;
        private System.Windows.Forms.ToolStripMenuItem m_routeItem;
        private System.Windows.Forms.ListView m_listViewVirtualOccupation;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.RichTextBox m_richTextBoxCommunicationLogs;
        private System.Windows.Forms.ListView m_listViewFootPrintTracks;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox m_groupBoxAllTrains;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PictureBox m_pictureBoxDoorStatus;
        public System.Windows.Forms.ListView m_listView;
        internal System.Windows.Forms.ComboBox m_comboBoxTrain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_labelDoorCounter;
        private System.Windows.Forms.Button m_buttonStop;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerCommunicationLogs;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerUILogs;
        public System.Windows.Forms.RichTextBox m_richTextBoxTrainsLogs;
        private System.Windows.Forms.GroupBox m_groupBoxLog;
        private System.Windows.Forms.TabPage m_tabPageCommunication;
        private System.Windows.Forms.TabPage m_tabPageTrain;
        private System.Windows.Forms.TabPage m_tabPageIncomingMessage;
        public System.Windows.Forms.RichTextBox m_richTextBoxIncomingMessage;
        private System.Windows.Forms.TabPage m_tabPageOutgoingMessage;
        public System.Windows.Forms.RichTextBox m_richTextBoxOutgoingMessage;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerIncomingMessage;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerOutcomingMessage;
        private System.Windows.Forms.ToolStripMenuItem m_aboutPopup;
        internal System.Windows.Forms.DataGridView m_dataGridViewAllTrains;
        internal System.Windows.Forms.TabControl m_tabControlLogs;
    }
}

