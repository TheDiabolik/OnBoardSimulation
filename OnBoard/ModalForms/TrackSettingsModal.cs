using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    public partial class TrackSettingsModal : Form
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        DataTable rou;

        public TrackSettingsModal()
        {
            InitializeComponent();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);

            //m_dataGridViewTrackRoute.Columns.Clear();

            if (m_settings.RouteTrack.TableName == "")
                m_dataGridViewManuelInputTrack.DataSource = TempDataTable();
            else
                m_dataGridViewManuelInputTrack.DataSource = m_settings.RouteTrack;

            m_dataGridViewManuelInputTrack.Columns[0].Width = 50; 

            UIOperation.SetDoubleBuffered(m_dataGridViewManuelInputTrack);
            UIOperation.SetDoubleBuffered(m_dataGridViewFromFileTrack);



            //m_dataGridViewFromFileTrack.DataSource = MainForm.m_fromFileTracks;

            m_dataGridViewFromFileTrack.Columns[0].Width = 50;
        }


        public TrackSettingsModal(MainForm mf) : this()
        {
            m_mf = mf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
 

        private void m_buttonSave_Click(object sender, EventArgs e)
        {

            DataTable dT = (DataTable)m_dataGridViewManuelInputTrack.DataSource;
          
            m_settings.RouteTrack = dT;

            m_settings.Serialize(m_settings);

            m_settings = m_settings.DeSerialize(m_settings); 
         


            if ((Button)sender == m_buttonApply)
                this.Close();
        }

        private void TrackSettingsModal_Load(object sender, EventArgs e)
        {

        }


        public DataTable TempDataTable()
        {
            //DataTable dt = new DataTable("RouteTrack");
            DataTable routeTrack = new DataTable("RouteTrack");

            routeTrack.Columns.Add("ID");
            routeTrack.Columns.Add("Track ID");
            routeTrack.Columns.Add("Start Position");
            routeTrack.Columns.Add("End Position");
            routeTrack.Columns.Add("Length (cm)");
            routeTrack.Columns.Add("Speed Limit (km/sa)");

            //routeTrack.Columns.Add("Station Start Position");
            //routeTrack.Columns.Add("Station End Position");
            //routeTrack.Columns.Add("Station Name"); 

            //routeTrack.Columns.Add("Stopping Point Position 1");
            //routeTrack.Columns.Add("Stopping Point Position_2");
            //routeTrack.Columns.Add("Connection Entry 1");
            //routeTrack.Columns.Add("Connection Entry 2");
            routeTrack.Columns.Add("Connection Exit 1");
            //routeTrack.Columns.Add("Connection Exit 2");

            routeTrack.Columns["ID"].AutoIncrement = true;
            routeTrack.Columns["ID"].AutoIncrementSeed = 1;
            routeTrack.Columns["ID"].AutoIncrementStep = 1; 


            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();

            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();

            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();

            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add();
            routeTrack.Rows.Add(); 

            return routeTrack;


        }

        private void m_dataGridViewTrackRoute_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            foreach (DataGridViewRow row in m_dataGridViewManuelInputTrack.Rows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());

                if (id % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkBlue;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void ViewTrackRoute_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //foreach (DataGridViewRow row in m_dataGridViewFromFileTrack.Rows)
            //{
            //    int id = int.Parse(row.Cells[0].Value.ToString());

            //    if (id % 2 == 0)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.DarkBlue;
            //        row.DefaultCellStyle.ForeColor = Color.White;
            //    }
            //    else
            //    {
            //        row.DefaultCellStyle.BackColor = Color.White;
            //        row.DefaultCellStyle.ForeColor = Color.Black;
            //    }

            //}
        }
    }
}
