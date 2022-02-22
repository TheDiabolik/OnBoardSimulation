using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface ITrainObserver
    {
        void InformTrainCreatedWatcher();

        void InformTrainMovementCreatedSendMessageWatcher();
        void InformTrainMovementRouteCreatedWatcher();
        void InformTrainNewMovementAuthorityCreatedWatcher();
        void InformTrainMovementUITracksListWatcher();
        void InformTrainMovementUIAllTrainListWatcher();


        void InformTrainDetailsWindowWatcher(); 

        void AddTrainDetailsWindowWatcher(ITrainDetailsWindowWatcher watcher);

        void RemoveTrainDetailsWindowWatcher(ITrainDetailsWindowWatcher watcher);



        void AddTrainCreatedWatcher(ITrainCreatedWatcher watcher);

        void RemoveTrainCreatedWatcher(ITrainCreatedWatcher watcher);



        void AddTrainMovementCreatedSendMessageWatcher(ITrainMovementCreatedSendMessageWatcher watcher);
        void RemoveTrainMovementCreatedSendMessageWatcher(ITrainMovementCreatedSendMessageWatcher watcher);

        //
        void AddTrainNewMovementAuthorityCreatedWatcher(ITrainNewMovementAuthorityCreatedWatcher watcher);
        void RemoveTrainNewMovementAuthorityCreatedWatcher(ITrainNewMovementAuthorityCreatedWatcher watcher);


        void AddTrainMovementRouteCreatedWatcher(ITrainMovementRouteCreatedWatcher watcher);

        void RemoveTrainMovementRouteCreatedWatcher(ITrainMovementRouteCreatedWatcher watcher);


        void AddTrainMovementUIWatcher(ITrainMovementUIWatcher watcher);
        void RemoveTrainMovementUIWatcher(ITrainMovementUIWatcher watcher);


        //void AddTrainMovementUITracksListWatcher(ITrainMovementUIWatcher watcher);
        //void RemoveTrainMovementUITracksListWatcher(ITrainMovementUIWatcher watcher);
    }
}
