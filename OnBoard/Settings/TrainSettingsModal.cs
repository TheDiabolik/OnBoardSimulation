using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    public partial class TrainSettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        private bool xClicked = true;
        public TrainSettingsModal()
        {
            InitializeComponent();

            Enums.SettingsWindowStatus returnSettingsWindowStatus = MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Open, Enums.SettingsWindow.Train);


            if (returnSettingsWindowStatus == Enums.SettingsWindowStatus.Close)
                this.Close();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            //ayarları atama
            m_textBoxTrainLength.Text = Convert.ToString(m_settings.TrainLength);
            m_textBoxTrainDeceleration.Text = m_settings.MaxTrainDeceleration.ToString();
            m_textBoxTrainAcceleration.Text = m_settings.MaxTrainAcceleration.ToString();
            m_textBoxTrainSpeedLimit.Text = m_settings.TrainSpeedLimit.ToString();


            if(!this.IsDisposed)
            //focuslama için
                this.ActiveControl = m_labelMaxTrainAcceleration;


            #region controls doublebuffered
            UIOperation.SetDoubleBuffered(m_textBoxTrainLength);
            UIOperation.SetDoubleBuffered(m_textBoxTrainAcceleration);
            UIOperation.SetDoubleBuffered(m_textBoxTrainSpeedLimit);
            UIOperation.SetDoubleBuffered(m_textBoxTrainDeceleration); 
            #endregion
        }

        public TrainSettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        }

        private void TrainSettings_Load(object sender, EventArgs e)
        {

            this.Text = Localization.TrainSettingsModal;


            m_labelTrainLengthCM.Text = Localization.m_labelTrainLengthCM;
            m_groupBoxTrainSettings.Text = Localization.m_groupBoxTrainSettingsModal;

            m_labelTrainLengthCM.Text = Localization.m_labelTrainLengthCM;
            m_labelMaxTrainAcceleration.Text = Localization.m_labelMaxTrainAcceleration;
            m_labelTrainSpeedLimit.Text = Localization.m_labelTrainSpeedLimit;
            m_labelMaxTrainDeceleration.Text = Localization.m_labelMaxTrainDeceleration;








            m_buttonApply.Text = Localization.m_buttonApply;
            m_buttonSave.Text = Localization.m_buttonSave;
        }

        private void m_buttonSave_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show(Localization.CloseSettingsMessage, "OnBoard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                m_settings.TrainLength = Convert.ToInt32(m_textBoxTrainLength.Text);
                m_settings.MaxTrainDeceleration = Convert.ToDouble(m_textBoxTrainDeceleration.Text);
                m_settings.MaxTrainAcceleration = Convert.ToDouble(m_textBoxTrainAcceleration.Text);
                m_settings.TrainSpeedLimit = Convert.ToInt32(m_textBoxTrainSpeedLimit.Text);

                m_settings.Serialize(m_settings);

                m_settings = m_settings.DeSerialize(m_settings);


                MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Save, Enums.SettingsWindow.Train);


                if ((Button)sender == m_buttonApply)
                    this.Close();

            }
        }

        private void TrainSettingsModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xClicked)
            {
                // user click the X
            }
            else
            { 
                if (CloseReason.FormOwnerClosing != e.CloseReason)
                    MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Close, Enums.SettingsWindow.Train);
            }


           

        }
    }
}
