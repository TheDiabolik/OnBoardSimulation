using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public interface ISettingsWindowsObserver
    {
        void InformSettingsWindowWatcher();


        void AddSettingsWindowWatcher(ISettingsWindowsWatcher watcher);

        //void InformSettingsWindowCloseWatcher();
    }
}
