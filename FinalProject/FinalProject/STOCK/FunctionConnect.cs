using DataLayer;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace STOCK
{

    public  class FunctionConnect
    {

        public static void check(string servername, string database , string username , string password)
        {       
           BinaryFormatter bf = new BinaryFormatter();
           FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
          connect cp = (connect)bf.Deserialize(fs);
             string _servername = Encryptor.Decrypt(cp.servername, "sblw-3hn8-sqoy19");
          string _username = Encryptor.Decrypt(cp.username, "sblw-3hn8-sqoy19");
          string _password = Encryptor.Decrypt(cp.password, "sblw-3hn8-sqoy19");
          string _database = Encryptor.Decrypt(cp.database, "sblw-3hn8-sqoy19");
            servername = _servername;
            database = _database;
            username = _username;
            password = _password;
        }

       
    }
}
