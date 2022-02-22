using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 

namespace OnBoard
{
    class FileOperation
    {
        #region singletonpattern
        private static FileOperation m_do;

        public static FileOperation Singleton()
        {
            if (m_do == null)
                m_do = new FileOperation();

            return m_do;
        }
        #endregion


        public  DataTable ReadTrackTableInExcel()
        {
            string dosya = "HatHaritası.xlsx";
            string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1""", dosya);
            //string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=NO;""", dosya);

            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [TrackDatabase$]", conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataColumnCollection dtweqrewr = dt.Columns;
            DataRow sdf = dt.Rows[0];

            return dt;
        }

        public DataTable ReadRouteTableInExcel()
        {
            string dosya = "RotaTablosu.xlsx";
            //string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0", dosya);
            string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=NO;""", dosya);

            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Rota Tablosu$]", conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataColumnCollection dtweqrewr = dt.Columns;
            DataRow sdf = dt.Rows[2];

            return dt;
        }

        public DataTable ReadSimulationRouteTableInExcel()
        {
            string dosya = "simülasyon rota çalışması.xlsx";
            string connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1""", dosya);

            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sayfa1$]", conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            //dt.Rows[0].Delete();

            DataColumnCollection dtweqrewr = dt.Columns;
            DataRow sd33f = dt.Rows[0];
            DataRow sd33333f = dt.Rows[1];
            DataRow sd3333sdf3f = dt.Rows[2];
            DataRow sdf = dt.Rows[4];


            DataRow yedi = dt.Rows[7];

            var seeedf = sd33333f.ItemArray[2].ToString();


            return dt;
        }

        public DataTable EPPlusReadTrackTableInExcel()
        {
            DataTable tbl = new DataTable();

            try
            {

                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    using (var stream = File.OpenRead("HatHaritası.xlsx"))
                    {
                        pck.Load(stream);
                    }
                    var ws = pck.Workbook.Worksheets["TrackDatabase"];

                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {

                        tbl.Columns.Add(true ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = true ? 2 : 1;
                    for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        DataRow row = tbl.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }


                    DataColumnCollection dtweqrewr = tbl.Columns;
                    DataRow sdf = tbl.Rows[0];


                    return tbl;
                }

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "EPPlusReadTrackTableInExcel");
                return tbl;
            }
        }

        public DataTable EPPlusReadRouteTableInExcel()
        {
            DataTable tbl = new DataTable();

            try
            {
                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    using (var stream = File.OpenRead("RotaTablosu.xlsx"))
                    {
                        pck.Load(stream);
                    }
                    var ws = pck.Workbook.Worksheets["Rota Tablosu"];

                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {

                        tbl.Columns.Add(true ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = true ? 2 : 1;
                    for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        DataRow row = tbl.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }


                    DataColumnCollection dtweqrewr = tbl.Columns;
                    DataRow sdf = tbl.Rows[0];
                    return tbl;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "EPPlusReadRouteTableInExcel");
                return tbl;
            }
        }


        

      
        public DataTable EPPlusReadSimulationRouteTableInExcel()
        {
            DataTable tbl = new DataTable();

            try
            { 
                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    using (var stream = File.OpenRead("simülasyon rota çalışması.xlsx"))
                    {
                        pck.Load(stream);
                    }
                    var ws = pck.Workbook.Worksheets["Sayfa1"];
                  
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {

                        tbl.Columns.Add(true ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = true ? 2 : 1;
                    for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        DataRow row = tbl.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    } 
                  
                    return tbl;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "EPPlusReadSimulationRouteTableInExcel");
                return tbl;
            }

        }


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}
