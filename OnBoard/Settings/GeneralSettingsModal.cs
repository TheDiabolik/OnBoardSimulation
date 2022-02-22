using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    public partial class GeneralSettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        private bool xClicked = true;

        public GeneralSettingsModal()
        {
            InitializeComponent();

            Enums.SettingsWindowStatus returnSettingsWindowStatus =  MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Open, Enums.SettingsWindow.General);



            if (returnSettingsWindowStatus == Enums.SettingsWindowStatus.Close)
                this.Close();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);



            m_textBoxStartRangeTrackID.Text = m_settings.StartTrackID.ToString();
            m_textBoxEndRangeTrackID.Text = m_settings.EndTrackID.ToString();


            if (m_settings.TrackInput == Enums.TrackInput.Manuel)
                m_radioButtonManuelInputTracks.Checked = true;
            else
                m_radioButtonFromFileTracks.Checked = true;



            m_numericUpDownMinute.Value = m_settings.TrainFrequencyMinute;
            m_numericUpDownSecond.Value = m_settings.TrainFrequencySecond;


            m_numericUpDownOperationTime.Value = m_settings.OperationTimeCycle;
            m_numericUpDownWorkingCycleOBATC.Value = m_settings.OBATCWorkingCycle;
            m_numericUpDownWorkingCycleMessageSend.Value = m_settings.MessageSendWorkingCycle;
            m_numericUpDownWorkingCycleUIRefresh.Value = m_settings.UIRefreshWorkingCycle;




            //if (m_checkBoxATS_TO_OBATO.Checked)
            m_checkBoxATS_TO_OBATO.Checked = m_settings.WriteLogATS_TO_OBATO;

            //if (m_checkBoxATS_TO_OBATO_Init.Checked)
            m_checkBoxATS_TO_OBATO_Init.Checked = m_settings.WriteLogATS_TO_OBATO_Init;

            //if (m_checkBoxOBATO_TO_ATS.Checked)
            m_checkBoxOBATO_TO_ATS.Checked = m_settings.WriteLogOBATO_TO_ATS;

            //if (m_checkBoxOBATP_TO_WSATP.Checked)
            m_checkBoxOBATP_TO_WSATP.Checked = m_settings.WriteLogOBATP_TO_WSATP;

            //if (m_checkBoxWSATP_TO_OBATP.Checked)
            m_checkBoxWSATP_TO_OBATP.Checked = m_settings.WriteLogWSATP_TO_OBATP;

            m_checkBoxSQLLogs.Checked = m_settings.WriteLogSQL;

            m_textBoxPersonnelID.Text = m_settings.PersonnelID;

        

            if (m_settings.m_language == Enums.Language.English)
                m_radioButtonEnglish.Checked = true;
            else
                m_radioButtonTurkish.Checked = true;




            m_textBoxPersonnelID.Enabled = m_checkBoxSQLLogs.Checked;



            #region controls doublebuffered
            UIOperation.SetDoubleBuffered(this);
            UIOperation.SetDoubleBuffered(m_checkedListBoxTrains);
            UIOperation.SetDoubleBuffered(m_numericUpDownOperationTime);
            UIOperation.SetDoubleBuffered(m_numericUpDownWorkingCycleOBATC);
            UIOperation.SetDoubleBuffered(m_numericUpDownWorkingCycleMessageSend);
            UIOperation.SetDoubleBuffered(m_numericUpDownWorkingCycleUIRefresh);
            UIOperation.SetDoubleBuffered(tabControl1);
            UIOperation.SetDoubleBuffered(m_tabPageTrain);
            UIOperation.SetDoubleBuffered(m_tabPageLogs);


            UIOperation.SetDoubleBuffered(m_checkBoxATS_TO_OBATO);
            UIOperation.SetDoubleBuffered(m_checkBoxATS_TO_OBATO_Init);
            UIOperation.SetDoubleBuffered(m_checkBoxOBATO_TO_ATS);

            UIOperation.SetDoubleBuffered(m_checkBoxOBATP_TO_WSATP);
            UIOperation.SetDoubleBuffered(m_checkBoxWSATP_TO_OBATP);
            UIOperation.SetDoubleBuffered(m_checkBoxSQLLogs);
            UIOperation.SetDoubleBuffered(m_textBoxPersonnelID);


            UIOperation.SetDoubleBuffered(m_radioButtonEnglish);
            UIOperation.SetDoubleBuffered(m_radioButtonTurkish);


            #endregion 
        }

        public void LocalizationControls()
        {
            if (m_settings.m_language == Enums.Language.English)
                Localization.Culture = new CultureInfo("en-US");
            else if (m_settings.m_language == Enums.Language.Turkish)
                Localization.Culture = new CultureInfo("tr-TR");


            m_buttonApply.Text = Localization.m_buttonApply;
            m_buttonSave.Text = Localization.m_buttonSave;


            this.Text = Localization.GeneralSettingsModal;


            m_groupBoxTrainStart.Text = Localization.m_groupBoxTrainStart;
            m_labelMinute.Text = Localization.m_labelMinute;
            m_labelSecond.Text = Localization.m_labelSecond;
            m_groupBoxWorkingCycle.Text = Localization.m_groupBoxWorkingCycle;
            m_labelWorkingCycleOBATC.Text = Localization.m_labelWorkingCycleOBATC;
            m_labelWorkingCycleMessageSend.Text = Localization.m_labelWorkingCycleMessageSend;
            m_labelWorkingUIRefresh.Text = Localization.m_labelWorkingUIRefresh;
            m_labelOperationTime.Text = Localization.m_labelOperationTime;

            m_tabPageTrain.Text = Localization.m_tabPageTrain;
            m_tabPageRoute.Text = Localization.m_tabPageTrain;
            m_tabPageLogs.Text = Localization.m_tabPageLogsGeneralSettings;


            m_labelStaffID.Text = Localization.m_labelStaffID;
            m_checkBoxSQLLogs.Text = Localization.m_checkBoxSQLLogs;
        }

        public GeneralSettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        }
        private void GeneralSettingsModal_Load(object sender, EventArgs e)
        {


            LocalizationControls();












            tabControl1.TabPages.Remove(m_tabPageRoute);




            for (int i = 1; i < 100; i++)
            {
                m_checkedListBoxTrains.Items.Add("Train" + i.ToString());
            }

            //checklist tablosunu ayarlama
            foreach (int index in m_settings.Trains)
                m_checkedListBoxTrains.SetItemChecked(index, true);
        }

        private void m_buttonSave_Click(object sender, EventArgs e)
        {

            //if ((Button)sender == m_buttonSave)
            //{
            //    MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Save, Enums.SettingsWindow.General);
            //    //this.Close();
            //}

            DialogResult dr = MessageBox.Show(Localization.CloseSettingsMessage, "OnBoard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {

                for (int i = 0; i < m_checkedListBoxTrains.Items.Count; i++)
                {
                    CheckState cs = m_checkedListBoxTrains.GetItemCheckState(i);

                    if (cs == CheckState.Checked)
                        m_settings.Trains.Add(i);
                    else if (cs == CheckState.Unchecked)
                        m_settings.Trains.Remove(i);
                }


                m_settings.TrainFrequencyMinute = m_numericUpDownMinute.Value;
                m_settings.TrainFrequencySecond = m_numericUpDownSecond.Value;

                m_settings.OperationTimeCycle = Convert.ToInt32(m_numericUpDownOperationTime.Value);
                m_settings.OBATCWorkingCycle = Convert.ToInt32(m_numericUpDownWorkingCycleOBATC.Value);
                m_settings.MessageSendWorkingCycle = Convert.ToInt32(m_numericUpDownWorkingCycleMessageSend.Value);
                m_settings.UIRefreshWorkingCycle = Convert.ToInt32(m_numericUpDownWorkingCycleUIRefresh.Value);


                m_settings.StartTrackID = Convert.ToInt32(m_textBoxStartRangeTrackID.Text);
                m_settings.EndTrackID = Convert.ToInt32(m_textBoxEndRangeTrackID.Text);

                if (m_radioButtonManuelInputTracks.Checked)
                    m_settings.TrackInput = Enums.TrackInput.Manuel;

                if (m_radioButtonFromFileTracks.Checked)
                    m_settings.TrackInput = Enums.TrackInput.FromFile;



                //if (m_checkBoxATS_TO_OBATO.Checked)
                m_settings.WriteLogATS_TO_OBATO = m_checkBoxATS_TO_OBATO.Checked;

                //if (m_checkBoxATS_TO_OBATO_Init.Checked)
                m_settings.WriteLogATS_TO_OBATO_Init = m_checkBoxATS_TO_OBATO_Init.Checked;

                //if (m_checkBoxOBATO_TO_ATS.Checked)
                m_settings.WriteLogOBATO_TO_ATS = m_checkBoxOBATO_TO_ATS.Checked;

                //if (m_checkBoxOBATP_TO_WSATP.Checked)
                m_settings.WriteLogOBATP_TO_WSATP = m_checkBoxOBATP_TO_WSATP.Checked;

                //if (m_checkBoxWSATP_TO_OBATP.Checked)
                m_settings.WriteLogWSATP_TO_OBATP = m_checkBoxWSATP_TO_OBATP.Checked;


                m_settings.WriteLogSQL = m_checkBoxSQLLogs.Checked;
                m_settings.PersonnelID = m_textBoxPersonnelID.Text; 
            



                if (m_radioButtonEnglish.Checked)
                    m_settings.m_language = Enums.Language.English;
                else
                    m_settings.m_language = Enums.Language.Turkish;



                m_settings.Serialize(m_settings);

                m_settings = m_settings.DeSerialize(m_settings);

                xClicked = false;


                LocalizationControls();

                //if ((Button)sender == m_buttonSave)
                //{
                //    MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Save, Enums.SettingsWindow.General);
                //    //this.Close();
                //}

                MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Save, Enums.SettingsWindow.General);

                if ((Button)sender == m_buttonApply)
                {

                    this.Close();
                }
            }


             
        } 

        private void GeneralSettingsModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //m_settings = m_settings.DeSerialize(m_settings);
            if (xClicked)
            {
                // user click the X
            }
            else
            {

                if (CloseReason.FormOwnerClosing != e.CloseReason)
                    MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Close, Enums.SettingsWindow.General);
            }
      



            //MainForm.m_allOBATP.Clear();
            //MainForm.m_mf.m_comboBoxTrain.Items.Clear();

            //foreach (int index in m_settings.Trains)
            //{
            //    int trainIndex = index + 1;
            //    Enums.Train_ID train_ID = (Enums.Train_ID)trainIndex;

            //    //OBATP OBATP = new OBATP((Enums.Train_ID)trainIndex, m_settings.MaxTrainAcceleration, m_settings.MaxTrainDeceleration, m_settings.TrainSpeedLimit, m_settings.TrainLength, MainForm.m_route);

            //    //MainForm.m_allOBATP.TryAdd(trainIndex, OBATP);

            //    MainForm.m_mf.m_comboBoxTrain.Items.Add(train_ID.ToString());
            //}

            //if (MainForm.m_mf.m_comboBoxTrain.Items.Count > 0)
            //    MainForm.m_mf.m_comboBoxTrain.SelectedIndex = 0;



            //MainForm.m_mf.m_ATSSocket.Start(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS, m_settings.ATSIPAddress, Convert.ToInt32(m_settings.ATSPort));
            //MainForm.m_mf.m_ATSSocket.Start(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS, m_settings.ATSIPAddress, Convert.ToInt32(m_settings.ATSPort));






        }

        private void m_checkBoxOBATO_TO_ATS_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void GeneralSettingsModal_FormClosed(object sender, FormClosedEventArgs e)
        {


          
        }

        private void m_radioButtonEnglish_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_checkBoxSQLLogs_CheckedChanged(object sender, EventArgs e)
        {
            m_textBoxPersonnelID.Enabled = m_checkBoxSQLLogs.Checked;
        }

        private void m_textBoxPersonnelID_EnabledChanged(object sender, EventArgs e)
        {
            if (!m_textBoxPersonnelID.Enabled)
            {
                m_textBoxPersonnelID.Text = "";
            }
           
        }
    }
}
