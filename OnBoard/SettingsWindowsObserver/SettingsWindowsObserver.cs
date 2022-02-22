using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard 
{
    public class SettingsWindowsObserver : ISettingsWindowsObserver
    {
          private ThreadSafeList<ISettingsWindowsWatcher> m_settingsWindowWatcher = new ThreadSafeList<ISettingsWindowsWatcher>();
        private Enums.SettingsWindowStatus m_settingsWindowStatus;
        private Enums.SettingsWindow m_settingsWindow;

        public void InformSettingsWindowWatcher()
        {
            foreach (ISettingsWindowsWatcher watcher in m_settingsWindowWatcher)
            {
                watcher.SettingsWindowStatus(m_settingsWindowStatus, m_settingsWindow);
            }
        }


        public void AddSettingsWindowWatcher(ISettingsWindowsWatcher watcher)
        {
            m_settingsWindowWatcher.Add(watcher);
        }

        public Enums.SettingsWindowStatus SettingsWindowStatus(Enums.SettingsWindowStatus settingsWindowStatus, Enums.SettingsWindow settingsWindow)
        {
            Enums.SettingsWindowStatus returnSettingsWindowStatus = Enums.SettingsWindowStatus.Cancel;


            m_settingsWindowStatus = settingsWindowStatus;
            m_settingsWindow = settingsWindow;
             


            if (settingsWindowStatus == Enums.SettingsWindowStatus.Open)
            {
                DialogResult dr = MessageBox.Show(Localization.OpenSettingsMessage, "OnBoard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    InformSettingsWindowWatcher();


                    returnSettingsWindowStatus = Enums.SettingsWindowStatus.Open;
                }
                else if (dr == System.Windows.Forms.DialogResult.No)
                {
                    returnSettingsWindowStatus = Enums.SettingsWindowStatus.Close; 
                }
            }
            else if (settingsWindowStatus == Enums.SettingsWindowStatus.Save)
            {
                //DialogResult dr = MessageBox.Show(Localization.CloseSettingsMessage, "OnBoard", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (dr == System.Windows.Forms.DialogResult.OK)
                //{
                    InformSettingsWindowWatcher();
                //}
            }
            //else if (settingsWindowStatus == Enums.SettingsWindowStatus.Close)
            //{
            //    DialogResult dr = MessageBox.Show("Localization.CloseSettingsMessage", "OnBoard", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    if (dr == System.Windows.Forms.DialogResult.OK)
            //    {
            //        InformSettingsWindowWatcher();
            //    }
            //}


            return returnSettingsWindowStatus;
        }
    }
}
