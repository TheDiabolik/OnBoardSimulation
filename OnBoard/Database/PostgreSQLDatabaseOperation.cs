using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace OnBoard 
{
    partial class DatabaseOperation
    {
        public async Task<int> AsyncPOSTInsert(string UserId, int PlayId, DateTime SoftwareDate, byte[] PacketData, string messageType)
        {
            int result = 0;


            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString.PostgreSQLCnnString))
                {
                    await conn.OpenAsync();

                    string tableName = TableName(messageType);

                    NpgsqlCommand command = new NpgsqlCommand("insert into \"" + tableName + "\"" +
                        " (\"UserId\", \"PlayId\", \"SoftwareDate\", \"PacketData\") values (@UserId, @PlayId, @SoftwareDate, @PacketData)",
                       conn);


                    command.Parameters.AddWithValue("@UserId", Convert.ToInt32(UserId));
                    command.Parameters.AddWithValue("@PlayId", PlayId);
                    command.Parameters.AddWithValue("@SoftwareDate", SoftwareDate);
                    command.Parameters.AddWithValue("@PacketData", PacketData);

                    result = await command.ExecuteNonQueryAsync();

                    command.Dispose();

                    return result;
                }

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsyncPOSTInsert(List<string> value)");
                return result;
            }


        }

        public int POSTInsert(string UserId, int PlayId, DateTime SoftwareDate, byte[] PacketData, string messageType)
        {
            int result = 0;


            try
            {

                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString.PostgreSQLCnnString))
                {
                      conn.Open();

                    string tableName = TableName(messageType);

                    NpgsqlCommand command = new NpgsqlCommand("insert into \"" + tableName + "\"" +
                        " (\"UserId\", \"PlayId\", \"SoftwareDate\", \"PacketData\") values (@UserId, @PlayId, @SoftwareDate, @PacketData)",
                       conn);


                    command.Parameters.AddWithValue("@UserId", Convert.ToInt32(UserId));
                    command.Parameters.AddWithValue("@PlayId", PlayId);
                    command.Parameters.AddWithValue("@SoftwareDate", SoftwareDate);
                    command.Parameters.AddWithValue("@PacketData", PacketData);

                    result =  command.ExecuteNonQuery();

                    command.Dispose();

                    return result;
                }

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "POSTInsert(List<string> value)");
                return result;
            }


        }


        public string TableName(string messageType)
        {
            lock(messageType)
            {
                string tableName = "";

                switch (messageType)
                {
                    case "OBATO_TO_WSATO":
                        {
                            break;
                        }
                    case "OBATP_TO_WSATP":
                        {
                            tableName = "OnboardObatcToWsatcDataPackets";

                            break;
                        }
                    case "WSATO_TO_OBATO":
                        {
                            break;
                        }
                    case "WSATP_TO_OBATP":
                        {
                            tableName = "OnboardWsatcToObatcDataPackets";


                            break;
                        }
                    case "ATS_SERVER_TO_OBATO":
                        {
                            tableName = "OnboardAtsToObatcDataPackets";


                            break;
                        }
                    case "ATS_SERVER_TO_OBATO_Init":
                        {
                            tableName = "OnboardAtsToObatcDataPackets";

                            break;
                        }
                    case "OBATO_TO_ATS_SERVER":
                        {
                            tableName = "OnboardObatcToAtsDataPackets";

                            break;
                        }
                }

                return tableName;
            }
      
        }


 

    }
}
