using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnBoard
{
    public class Serialization
    {
        public static void Serialize(string xmlFilePath, dynamic eaevs)
        {
            //try
            //{

            //kayıt dosyası exe ile aynı yerde olması istendiği için comment yapıldı
            //if (!Directory.Exists(Path.GetDirectoryName(xmlFilePath)))
            //    Directory.CreateDirectory(Path.GetDirectoryName(xmlFilePath)); 

            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer s = new XmlSerializer(eaevs.GetType());
                s.Serialize(fs, eaevs);
            }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ExceptionMessages.SerilizationSettingsExceptionMessage, ex);
            //}
        }


        public static void SerializeBinary(string xmlFilePath, dynamic eaevs)
        {
            //try
            //{

            //kayıt dosyası exe ile aynı yerde olması istendiği için comment yapıldı
            //if (!Directory.Exists(Path.GetDirectoryName(xmlFilePath)))
            //    Directory.CreateDirectory(Path.GetDirectoryName(xmlFilePath));

            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, eaevs);
            }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ExceptionMessages.SerilizationSettingsExceptionMessage, ex);
            //}
        }


        public static dynamic DeSerialize(string xmlFilePath, dynamic eaevs)
        {
            try
            {
                //kayıt dosyası exe ile aynı yerde olması istendiği için comment yapıldı
                //if (!Directory.Exists(Path.GetDirectoryName(xmlFilePath)))
                //    Directory.CreateDirectory(Path.GetDirectoryName(xmlFilePath));

                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer s = new XmlSerializer(eaevs.GetType());
                    eaevs = (dynamic)s.Deserialize(fs);

                    return eaevs;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionMessages.DeSerilizationSettingsExceptionMessage, ex);
            }
        }

        public static dynamic DeSerializeBinary(string xmlFilePath, dynamic eaevs)
        {
            try
            {
                //kayıt dosyası exe ile aynı yerde olması istendiği için comment yapıldı
                //if (!Directory.Exists(Path.GetDirectoryName(xmlFilePath)))
                //    Directory.CreateDirectory(Path.GetDirectoryName(xmlFilePath));

                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    eaevs = (dynamic)bf.Deserialize(fs);

                    return eaevs;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionMessages.DeSerilizationSettingsExceptionMessage, ex);
            }
        }
    }
}
