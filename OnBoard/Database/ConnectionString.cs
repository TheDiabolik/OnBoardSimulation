using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    class ConnectionString
    {
        public static SQLiteConnection cnn = new SQLiteConnection("Data Source=E:\\Onboard1.db;Version=3;");

        //Data Source = test.db; Pooling=true;FailIfMissing=false
        public static string CnnString
        {
            get
            {
                //    return "Data Source=E:\\Onboard1.db;Version=3;Pooling=True;Max Pool Size=500;";
                //return "Data Source =E:\\Onboard1.db; Pooling=true;FailIfMissing=true";
                return "Data Source = OnBoard.db; Pooling=true;FailIfMissing=false";
            }
            //}
        }

        public static string PostgreSQLCnnString
        {
            get
            {
                //    return "Data Source=E:\\Onboard1.db;Version=3;Pooling=True;Max Pool Size=500;";
                //return "Data Source =E:\\Onboard1.db; Pooling=true;FailIfMissing=true";

                return "User ID = postgres; Password = gaye; Host = 10.2.6.115; Port = 5432; Database = SimBTC;KeepAlive=1";
               
            }
            //}
        }
    }
}
