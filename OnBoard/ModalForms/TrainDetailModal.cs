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
    public partial class TrainDetailModal : Form, ITrainDetailsWindowWatcher
    {
        private MainForm m_mf;
        XMLSerialization m_settings;

        public TrainDetailModal()
        {
            InitializeComponent();

            MainForm.m_trainObserver.AddTrainDetailsWindowWatcher(this);

            #region controls doublebuffered
            UIOperation.SetDoubleBuffered(this);
            UIOperation.SetDoubleBuffered(m_propertyGridTrainDetails); 
            #endregion 
        }


        public TrainDetailModal(MainForm mf) : this()
        {
            m_mf = mf;
        }
        private void TrainDetailModal_Load(object sender, EventArgs e)
        { 
            //OBATP osman = MainForm.m_mf.m_allTrains[0];


            //TrainDetailsProperties asdasdasd = new TrainDetailsProperties(MainForm.m_mf.m_allTrains[0]);
            


            //propertyGrid1.SelectedObject = asdasdasd;
        }

        TrainDetailsProperties asdasdasd = new TrainDetailsProperties();
        public void TrainDetailsWindowCreated(OBATP OBATP)
        {
            //TrainDetailsProperties asdasdasd = new TrainDetailsProperties(MainForm.m_mf.m_allTrains[0]);

            m_propertyGridTrainDetails.Invoke((Action)(() =>
            {
                OBATP myOBATP = OBATP;
                 asdasdasd = asdasdasd.ConvertThis(myOBATP);

                if (m_propertyGridTrainDetails.SelectedObject == null)
                    m_propertyGridTrainDetails.SelectedObject = asdasdasd;
                else
                {
                    m_propertyGridTrainDetails.Refresh();
                }
            }));
           
        }

        private void TrainDetailModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.m_mf.m_doubleClickTrainID = 0;
            MainForm.m_trainObserver.RemoveTrainDetailsWindowWatcher(this);
        }
    }


    


}
