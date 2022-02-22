using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class ATS_TO_OBATO_MessageInComing : IATS_TO_OBATO_MessageCreate
    {
        private ThreadSafeList<IATS_TO_OBATO_MessageWatcher> m_syncFileWatcher = new ThreadSafeList<IATS_TO_OBATO_MessageWatcher>();
        private ATS_TO_OBATOAdapter m_ATS_TO_OBATOAdapter;
        private Enums.Train_ID m_train_ID;
        public void InformWatcher()
        {
            foreach (IATS_TO_OBATO_MessageWatcher watcher in m_syncFileWatcher)
            {
                watcher.ATS_TO_OBATO_MessageInComing(m_train_ID, m_ATS_TO_OBATOAdapter);
            }
        }

        public void AddWatcher(IATS_TO_OBATO_MessageWatcher watcher)
        {
            m_syncFileWatcher.Add(watcher);
        }


        public void RemoveWatcher(IATS_TO_OBATO_MessageWatcher watcher)
        {
            if (m_syncFileWatcher.Contains(watcher))
                m_syncFileWatcher.Remove(watcher);
        }


        public void ATS_TO_OBATO_NewMessageInComing(Enums.Train_ID train_ID, ATS_TO_OBATOAdapter ATS_TO_OBATOAdapter)
        {
            this.m_ATS_TO_OBATOAdapter = ATS_TO_OBATOAdapter;
            this.m_train_ID = train_ID;
            InformWatcher();
        }
    }
}
