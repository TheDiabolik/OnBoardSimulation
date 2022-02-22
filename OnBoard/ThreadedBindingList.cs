using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard
{
    public class ThreadedBindingList<T> : BindingList<T>
    {
        private object _sync = new object();
        public SynchronizationContext SynchronizationContext
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

        SynchronizationContext _ctx;
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (_ctx == null)
            {
                BaseAddingNew(e);
            }
            else
            {
                SynchronizationContext.Current.Send(delegate
                {
                    BaseAddingNew(e);
                }, null);
            }
        }
        void BaseAddingNew(AddingNewEventArgs e)
        {
            //lock (_sync)
            {
                base.OnAddingNew(e);
            }

        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_ctx == null)
            {
                BaseListChanged(e);
            }
            else
            {
                _ctx.Send(delegate { BaseListChanged(e); }, null);
            }
        }
        void BaseListChanged(ListChangedEventArgs e)
        {
            //lock (_sync)
            {
                base.OnListChanged(e);
            }
        }
    }
}
