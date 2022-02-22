using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    public partial class TrainSimModal : Form, ITrainMovementCreatedSendMessageWatcher// ITrainObserverWatcher
    {
        private MainForm m_mf;
        XMLSerialization m_settings;
        private Rectangle m_rect;
        private Graphics m_bitmapGraphics; 
       

        static double RouteScaleRatio = 0.005;// 0.005;
        static double TrainLengthCM;
        static double TrainLengthCMReScale;

        const int offsetX = 0;
        int offsetY = 20;

        string trainSpeedKMH = "0";

        Route m_route;


        public TrainSimModal()
        {
            InitializeComponent();

            //ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);


            TrainLengthCM = (double)m_settings.TrainLength;
            TrainLengthCMReScale = (TrainLengthCM * RouteScaleRatio);  
           

            m_rect = new Rectangle(offsetX, 100, Convert.ToInt32(TrainLengthCMReScale), 20);

            m_bitmapGraphics = m_panel.CreateGraphics();// Graphics.FromImage(m_bitmapScreen);
 
            UIOperation.SetDoubleBuffered(m_panel);

            MainForm.m_trainObserver.AddTrainMovementCreatedSendMessageWatcher(this);
        }


        public TrainSimModal(MainForm mf) : this()
        {
            m_mf = mf;
        }

       

        private void TrainSimModal_Load(object sender, EventArgs e)
        {
            //Route route = Route.CreateNewRoute(10103, 10201, allTracks);
            //10107, 10211,
            //m_route = Route.CreateNewRoute(10103, 10301, MainForm.allTracks);
            //m_route = Route.CreateNewRoute(10103, 10305, MainForm.allTracks);
            //m_route = Route.CreateNewRoute(10101, 10103, MainForm.allTracks); 

            //m_route = MainForm.m_route;

          
            //m_panel.Invalidate();
        }


        Enums.DoorStatus asdasd= Enums.DoorStatus.Close;

        #region createdevent


       
        public void TrainMovementCreatedSendMessage(OBATP OBATP)
        {
            //m_rect.Location = new Point(Convert.ToInt32(OBATP.FrontOfTrainLocationWithFootPrintInRoute   * RouteScaleRatio) - Convert.ToInt32(TrainLengthCMReScale) + offsetX, 100);


            //m_rect.Location = new Point(Convert.ToInt32((OBATP.FrontOfTrainLocationWithFootPrintInRoute - TrainLengthCM) * RouteScaleRatio) + offsetX, 100);

            //m_rect.Location = new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_End_Position - OBATP.FrontOfTrainLocationWithFootPrintInRoute) * RouteScaleRatio) + offsetX, 100);
            //m_rect.Location = new Point(Convert.ToInt32((OBATP.FrontOfTrainLocationWithFootPrintInRoute) * RouteScaleRatio) + offsetX, 100);
            m_rect.Location = new Point(Convert.ToInt32((OBATP.FrontOfTrainLocationWithFootPrintInRoute - TrainLengthCM) * RouteScaleRatio) + offsetX, 100);

            //m_rect.Location = new Point(Convert.ToInt32((OBATP.RearOfTrainLocationWithFootPrintInRoute) * RouteScaleRatio) + offsetX, 100);

            asdasd = OBATP.DoorStatus;

            //m_rect.Location = new Point(Convert.ToInt32(OBATP.RearOfTrainLocationWithFootPrintInRoute * RouteScaleRatio) + offsetX, 100);


            trainSpeedKMH = OBATP.Vehicle.CurrentTrainSpeedKMH.ToString("0.##");

            m_bitmapGraphics.DrawString(trainSpeedKMH + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Black), new Point(m_rect.Location.X, m_rect.Location.Y));



            m_panel.Invalidate(Rectangle.Inflate(m_rect, 25, 25));

        }


        #endregion

        //private void m_panel_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    Pen redPen = new Pen(Color.Red, 1);
        //    Pen bluePen = new Pen(Color.Blue, 5);
        //    Pen blueThinPen = new Pen(Color.Blue, 1);
        //    Pen redThinPen = new Pen(Color.Red, 1);
        //    //dikeyçizgi
        //    //g.DrawLine(redThinPen, new Point(offsetX, 50), new Point(offsetX, 60));
        //    g.DrawLine(redThinPen, new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_End_Position) * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_End_Position) * RouteScaleRatio)   + offsetX, 60));

        //    //track çizgisi
        //    //g.DrawLine(redPen, new Point(Convert.ToInt32((m_route.Route_Tracks[0].StartPositionInRoute) * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32((m_route.Route_Tracks[0].StopPositionInRoute ) * RouteScaleRatio) + 100, 55 ));

        //    g.DrawLine(redPen, new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_Start_Position) * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_End_Position) * RouteScaleRatio) + offsetX  , 55));


        //    //g.DrawString(m_route.Route_Tracks[0].Track_ID.ToString() + "\n" + m_route.Route_Tracks[0].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Red), new Point(Convert.ToInt32(((m_route.Route_Tracks[0].StopPositionInRoute) / 2) * RouteScaleRatio) + offsetX, 55));
        //    g.DrawString(m_route.Route_Tracks[0].Track_ID.ToString() + "\n" + m_route.Route_Tracks[0].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Red), 
        //        new Point(Convert.ToInt32((m_route.Route_Tracks[0].Track_Start_Position) * RouteScaleRatio) + Convert.ToInt32((m_route.Route_Tracks[0].Track_Length / 2) * RouteScaleRatio) + offsetX, 55));



        //    for (int i = 1; i < m_route.Route_Tracks.Count; i++)
        //    {
        //        Pen pen;
        //        Pen thinPen;
        //        Color color;


        //        if (i % 2 == 0)
        //        {
        //            pen = redPen;
        //            offsetY = 65;
        //            color = Color.Red;
        //            thinPen = redThinPen;
        //        }

        //        else
        //        {
        //            offsetY = 25;
        //            pen = bluePen;
        //            color = Color.Blue;
        //            thinPen = blueThinPen;
        //        }

        //        //dikeyçizgi
        //        //g.DrawLine(thinPen, new Point(Convert.ToInt32((m_route.Route_Tracks[i]. StartPositionInRoute ) * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32((m_route.Route_Tracks[i].StartPositionInRoute) * RouteScaleRatio) + offsetX, 60));
        //        g.DrawLine(thinPen, new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_Start_Position) * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_Start_Position) * RouteScaleRatio) + offsetX, 60));
        //        //track çizgisi
        //        //g.DrawLine(pen, new Point(Convert.ToInt32((m_route.Route_Tracks[i].StartPositionInRoute) * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32((m_route.Route_Tracks[i].StopPositionInRoute) * RouteScaleRatio) + offsetX, 55));
        //        g.DrawLine(pen, new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_Start_Position) * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_End_Position) * RouteScaleRatio) + offsetX, 55));

        //        //g.DrawString(m_route.Route_Tracks[i].Track_ID.ToString() + "\n" + m_route.Route_Tracks[i].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(color),
        //        //    new Point(Convert.ToInt32((m_route.Route_Tracks[i].StartPositionInRoute ) * RouteScaleRatio) + Convert.ToInt32((m_route.Route_Tracks[i].Track_Length/ 2) * RouteScaleRatio) + offsetX, offsetY));
        //        g.DrawString(m_route.Route_Tracks[i].Track_ID.ToString() + "\n" + m_route.Route_Tracks[i].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(color),
        //           new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_Start_Position) * RouteScaleRatio) + Convert.ToInt32((m_route.Route_Tracks[i].Track_Length / 2) * RouteScaleRatio) + offsetX, offsetY));


        //        if (i == m_route.Route_Tracks.Count - 1)
        //        {
        //            //dikeyçizgi
        //            //track çizgisi
        //            //g.DrawLine(pen, new Point(Convert.ToInt32((m_route.Route_Tracks[i].StopPositionInRoute ) * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32((m_route.Route_Tracks[i].StopPositionInRoute) * RouteScaleRatio) + offsetX, 60));
        //            g.DrawLine(pen, new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_End_Position) * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32((m_route.Route_Tracks[i].Track_End_Position) * RouteScaleRatio) + offsetX, 60));


        //        }
        //    }




        //    if (asdasd == Enums.DoorStatus.Open)
        //        g.FillRectangle(Brushes.Green, m_rect);
        //    else if (asdasd == Enums.DoorStatus.Close)
        //        g.FillRectangle(Brushes.Blue, m_rect);


        //    g.DrawString(trainSpeedKMH + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Black), new Point((m_rect.Width / 2) + m_rect.Location.X , m_rect.Bottom  ));

        //}


        private void m_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redPen = new Pen(Color.Red, 1);
            Pen bluePen = new Pen(Color.Blue, 5);
            Pen blueThinPen = new Pen(Color.Blue, 1);
            Pen redThinPen = new Pen(Color.Red, 1);
            //dikeyçizgi
            g.DrawLine(redThinPen, new Point(offsetX, 50), new Point(offsetX, 60));
            //track çizgisi
            g.DrawLine(redPen, new Point(Convert.ToInt32(m_route.Route_Tracks[0].StartPositionInRoute * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32(m_route.Route_Tracks[0].StopPositionInRoute * RouteScaleRatio) + 100, 55));

            g.DrawString(m_route.Route_Tracks[0].Track_ID.ToString() + "\n" + m_route.Route_Tracks[0].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Red), new Point(Convert.ToInt32((m_route.Route_Tracks[0].StopPositionInRoute / 2) * RouteScaleRatio) + offsetX, 55));



            for (int i = 1; i < m_route.Route_Tracks.Count; i++)
            {
                Pen pen;
                Pen thinPen;
                Color color;


                if (i % 2 == 0)
                {
                    pen = redPen;
                    offsetY = 65;
                    color = Color.Red;
                    thinPen = redThinPen;
                }

                else
                {
                    offsetY = 25;
                    pen = bluePen;
                    color = Color.Blue;
                    thinPen = blueThinPen;
                }

                //dikeyçizgi
                g.DrawLine(thinPen, new Point(Convert.ToInt32(m_route.Route_Tracks[i].StartPositionInRoute * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32(m_route.Route_Tracks[i].StartPositionInRoute * RouteScaleRatio) + offsetX, 60));
                //track çizgisi
                g.DrawLine(pen, new Point(Convert.ToInt32(m_route.Route_Tracks[i].StartPositionInRoute * RouteScaleRatio) + offsetX, 55), new Point(Convert.ToInt32(m_route.Route_Tracks[i].StopPositionInRoute * RouteScaleRatio) + offsetX, 55));

                g.DrawString(m_route.Route_Tracks[i].Track_ID.ToString() + "\n" + m_route.Route_Tracks[i].MaxTrackSpeedKMH.ToString("0.##") + " km/sa", new Font("Arial", 8), new SolidBrush(color),
                    new Point(Convert.ToInt32((m_route.Route_Tracks[i].StartPositionInRoute) * RouteScaleRatio) + Convert.ToInt32((m_route.Route_Tracks[i].Track_Length / 2) * RouteScaleRatio) + offsetX, offsetY));


                if (i == m_route.Route_Tracks.Count - 1)
                {
                    //dikeyçizgi
                    //track çizgisi
                    g.DrawLine(pen, new Point(Convert.ToInt32(m_route.Route_Tracks[i].StopPositionInRoute * RouteScaleRatio) + offsetX, 50), new Point(Convert.ToInt32(m_route.Route_Tracks[i].StopPositionInRoute * RouteScaleRatio) + offsetX, 60));


                }
            }


          //(m_route.Route_Tracks[i].StartPositionInRoute - 19300)

            if (asdasd == Enums.DoorStatus.Open)
                g.FillRectangle(Brushes.Green, m_rect);
            else if (asdasd == Enums.DoorStatus.Close)
                g.FillRectangle(Brushes.Blue, m_rect);


            g.DrawString(trainSpeedKMH + " km/sa", new Font("Arial", 8), new SolidBrush(Color.Black), new Point((m_rect.Width / 2) + m_rect.Location.X, m_rect.Bottom));

        }
    }
}
