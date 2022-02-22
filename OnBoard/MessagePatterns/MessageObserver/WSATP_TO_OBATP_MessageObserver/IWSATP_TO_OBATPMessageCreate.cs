using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface IWSATP_TO_OBATPMessageCreate
    {
        void InformWatcher();

        void AddWatcher(IWSATP_TO_OBATPMessageWatcher watcher);
        void RemoveWatcher(IWSATP_TO_OBATPMessageWatcher watcher);

        


    }
}
