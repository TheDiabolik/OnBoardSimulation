using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface IATS_TO_OBATO_MessageCreate
    {
        void InformWatcher();

        void AddWatcher(IATS_TO_OBATO_MessageWatcher watcher);

        void RemoveWatcher(IATS_TO_OBATO_MessageWatcher watcher);
    }
}
