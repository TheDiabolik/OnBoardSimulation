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
    public partial class CommunicationSettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        private bool xClicked = true;
        public CommunicationSettingsModal()
        {
            InitializeComponent();

            Enums.SettingsWindowStatus returnSettingsWindowStatus = MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Open, Enums.SettingsWindow.Communication);

            if (returnSettingsWindowStatus == Enums.SettingsWindowStatus.Close)
                this.Close();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);


            //ayarları atama
            m_ıpAddressControlPAddressATS.Text = m_settings.ATSIPAddress;
            m_textBoxPortATS.Text = m_settings.ATSPort;

            m_ıpAddressControlIPAddressWSATC.Text = m_settings.WSATCIPAddress;
            m_textBoxPortWSATC.Text = m_settings.WSATCPort;

            if (m_settings.ATSCommunicationType == Enums.CommunicationType.Server)
                m_radioButtonServerATS.Checked = true;
            else
                m_radioButtonClientATS.Checked = true;

            if (m_settings.WSATCCommunicationType == Enums.CommunicationType.Server)
                m_radioButtonServerWSATC.Checked = true;
            else
                m_radioButtonClientWSATC.Checked = true;


            //m_ıpAddressControlATSToOBATP.Text = m_settings.ATSToOBATPIPAddress;
            //m_textBoxATSToOBATPPort.Text = m_settings.ATSToOBATPPort;

            //m_ıpAddressControlOBATPToATS.Text = m_settings.OBATPToATSIPAddress;
            //m_textBoxOBATPToATSPort.Text = m_settings.OBATPToATSPort;

            //m_ıpAddressControlWSATCToOBATP.Text = m_settings.WSATCToOBATPIPAddress;
            //m_textBoxWSATCToOBATPPort.Text = m_settings.WSATCToOBATPPort;

            //m_ıpAddressControlOBATPToWSATC.Text = m_settings.OBATPToWSATCIPAddress;
            //m_textBoxOBATPToWSATCPort.Text = m_settings.OBATPToWSATCPort;

            //if (m_settings.OBATPToWSATCCommunicationType == Enums.CommunicationType.Server)
            //    m_radioButtonOBATPToWSATCServer.Checked = true;
            //else
            //    m_radioButtonOBATPToWSATCClient.Checked = true;

            //if (m_settings.OBATPToATSCommunicationType == Enums.CommunicationType.Server)
            //    m_radioButtonOBATPToATSServer.Checked = true;
            //else
            //    m_radioButtonOBATPToATSClient.Checked = true;

            //if (m_settings.ATSToOBATPCommunicationType == Enums.CommunicationType.Server)
            //    m_radioButtonATSToOBATPServer.Checked = true;
            //else
            //    m_radioButtonATSToOBATPClient.Checked = true;

            //if (m_settings.WSATCToOBATPCommunicationType == Enums.CommunicationType.Server)
            //    m_radioButtonWSATCToOBATPServer.Checked = true;
            //else
            //    m_radioButtonWSATCToOBATPClient.Checked = true;

            #region controls doublebuffered
            UIOperation.SetDoubleBuffered(tabControl2);
            UIOperation.SetDoubleBuffered(m_tabPageATS);
            UIOperation.SetDoubleBuffered(m_ıpAddressControlPAddressATS);
            UIOperation.SetDoubleBuffered(m_textBoxPortATS);
            UIOperation.SetDoubleBuffered(m_radioButtonServerATS);
            UIOperation.SetDoubleBuffered(m_radioButtonClientATS);
            UIOperation.SetDoubleBuffered(m_tabPageWSATC);
            UIOperation.SetDoubleBuffered(m_ıpAddressControlIPAddressWSATC);


            UIOperation.SetDoubleBuffered(m_textBoxPortWSATC);
            UIOperation.SetDoubleBuffered(m_radioButtonServerWSATC);
            UIOperation.SetDoubleBuffered(m_radioButtonClientWSATC); 

            #endregion 
        }


        public CommunicationSettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        }




        public void LocalizationControls()
        {
            this.Text = Localization.CommunicationSettingsModal;

            m_buttonApply.Text = Localization.m_buttonApply;
            m_buttonSave.Text = Localization.m_buttonSave;
        }


        private void m_buttonSave_Click(object sender, EventArgs e)
        { 
            DialogResult dr = MessageBox.Show(Localization.CloseSettingsMessage, "OnBoard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                m_settings.ATSIPAddress = m_ıpAddressControlPAddressATS.Text;
            m_settings.ATSPort = m_textBoxPortATS.Text;

            m_settings.WSATCIPAddress = m_ıpAddressControlIPAddressWSATC.Text;
            m_settings.WSATCPort = m_textBoxPortWSATC.Text;



            if (m_radioButtonServerATS.Checked)
                m_settings.ATSCommunicationType = Enums.CommunicationType.Server;
            else
                m_settings.ATSCommunicationType = Enums.CommunicationType.Client;

            if (m_radioButtonServerWSATC.Checked)
                m_settings.WSATCCommunicationType = Enums.CommunicationType.Server;
            else
                m_settings.WSATCCommunicationType = Enums.CommunicationType.Client;


            //m_settings.ATSToOBATPIPAddress = m_ıpAddressControlATSToOBATP.Text;
            //m_settings.ATSToOBATPPort = m_textBoxATSToOBATPPort.Text;

            //m_settings.OBATPToATSIPAddress = m_ıpAddressControlOBATPToATS.Text;
            //m_settings.OBATPToATSPort = m_textBoxOBATPToATSPort.Text ;

            //m_settings.WSATCToOBATPIPAddress = m_ıpAddressControlWSATCToOBATP.Text;
            //m_settings.WSATCToOBATPPort = m_textBoxWSATCToOBATPPort.Text;

            //m_settings.OBATPToWSATCIPAddress = m_ıpAddressControlOBATPToWSATC.Text;
            //m_settings.OBATPToWSATCPort = m_textBoxOBATPToWSATCPort.Text;


            //if (m_radioButtonOBATPToWSATCServer.Checked)
            //    m_settings.OBATPToWSATCCommunicationType = Enums.CommunicationType.Server;
            //else
            //    m_settings.OBATPToWSATCCommunicationType = Enums.CommunicationType.Client;

            //if (m_radioButtonOBATPToATSServer.Checked)
            //    m_settings.OBATPToATSCommunicationType = Enums.CommunicationType.Server;
            //else
            //    m_settings.OBATPToATSCommunicationType = Enums.CommunicationType.Client; 

            //if (m_radioButtonATSToOBATPServer.Checked)
            //    m_settings.ATSToOBATPCommunicationType = Enums.CommunicationType.Server;
            //else
            //    m_settings.ATSToOBATPCommunicationType = Enums.CommunicationType.Client;


            //if (m_radioButtonWSATCToOBATPServer.Checked)
            //    m_settings.WSATCToOBATPCommunicationType = Enums.CommunicationType.Server;
            //else
            //    m_settings.WSATCToOBATPCommunicationType = Enums.CommunicationType.Client;  


            m_settings.Serialize(m_settings);
            m_settings = m_settings.DeSerialize(m_settings);



                MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Save, Enums.SettingsWindow.Communication);

                if ((Button)sender == m_buttonApply)
                this.Close();

            }


        }

        private void CommunicationSettingsModal_Load(object sender, EventArgs e)
        {
            LocalizationControls();
        }

        private void CommunicationSettingsModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dsfpıj = this.Name;

            if (xClicked)
            {
                // user click the X
            }
            else
            { 
                if (CloseReason.FormOwnerClosing != e.CloseReason)
                    MainForm.m_settingsWindowsObserver.SettingsWindowStatus(Enums.SettingsWindowStatus.Close, Enums.SettingsWindow.Communication);
            }

          
        }
    }
}
