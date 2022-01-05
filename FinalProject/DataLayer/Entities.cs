using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace DataLayer
{
    [Serializable]

    public partial class Entities
    {
        private Entities(DbConnection connectionString, bool contextOwnConnection = true)
            : base(connectionString, contextOwnConnection) { }

        public static Entities CreateEntities(bool contextOwnsConnection = true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
            connect cp = (connect)bf.Deserialize(fs);

            string servername = Encryptor.Decrypt(cp.servername, "sblw-3hn8-sqoy19");
            string username = Encryptor.Decrypt(cp.username, "sblw-3hn8-sqoy19");
            string pass = Encryptor.Decrypt(cp.password, "sblw-3hn8-sqoy19");
            string database = Encryptor.Decrypt(cp.database, "sblw-3hn8-sqoy19");


            SqlConnectionStringBuilder sqlBuiler = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder sqlConnectBuiler = new SqlConnectionStringBuilder();
            sqlConnectBuiler.DataSource = servername;
            sqlConnectBuiler.InitialCatalog = database;
            sqlConnectBuiler.UserID = username;
            sqlConnectBuiler.Password = pass;

            string sqlConnectString = sqlConnectBuiler.ConnectionString;

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlConnectString;
            entityBuilder.Metadata = @"res://*/STOCK.csdl|res://*/STOCK.ssdl|res://*/STOCK.msl";
            EntityConnection connection = new EntityConnection(entityBuilder.ConnectionString);

            fs.Close();
            return new Entities(connection);

        }
    }
}
