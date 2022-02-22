using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class WSATP_TO_OBATPMessageInComing : IWSATP_TO_OBATPMessageCreate
    {
        private ThreadSafeList<IWSATP_TO_OBATPMessageWatcher> m_syncFileWatcher = new ThreadSafeList<IWSATP_TO_OBATPMessageWatcher>();
        private WSATP_TO_OBATPAdapter m_WSATP_TO_OBATPAdapter;
        private Enums.Train_ID m_train_ID;
        public void InformWatcher()
        {
            foreach (IWSATP_TO_OBATPMessageWatcher watcher in m_syncFileWatcher)
            {
                watcher.WSATP_TO_OBATPMessageInComing(m_train_ID, m_WSATP_TO_OBATPAdapter);
            }
        }

        public void AddWatcher(IWSATP_TO_OBATPMessageWatcher watcher)
        {
            m_syncFileWatcher.Add(watcher);
        }

        public void RemoveWatcher(IWSATP_TO_OBATPMessageWatcher watcher)
        {
            if (m_syncFileWatcher.Contains(watcher))
                  m_syncFileWatcher.Remove(watcher); 
        }


        public void WSATP_TO_OBATPNewMessageInComing(Enums.Train_ID train_ID, WSATP_TO_OBATPAdapter WSATP_TO_OBATPAdapter)
        {
            this.m_WSATP_TO_OBATPAdapter = WSATP_TO_OBATPAdapter;
            this.m_train_ID = train_ID;
            InformWatcher();
        }
    }
}
