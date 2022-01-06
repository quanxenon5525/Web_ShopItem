using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataLayer;
using System.Data.SqlClient;

namespace STOCK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("connectdb.dba"))
            {
                string conStr = "";
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                connect cp =(connect) bf.Deserialize(fs);

                string servername = Encryptor.Decrypt(cp.servername, "sblw-3hn8-sqoy19");
                string username = Encryptor.Decrypt(cp.username, "sblw-3hn8-sqoy19");
                string pass = Encryptor.Decrypt(cp.password, "sblw-3hn8-sqoy19");
                string database = Encryptor.Decrypt(cp.database, "sblw-3hn8-sqoy19");



                conStr += "Data Source=" + servername + ";Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";";
                contmp = conStr;
                SqlConnection con = new SqlConnection(conStr);


                try
                {
                    con.Open();

                }
                catch
                {
                    MessageBox.Show("Connect Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                }
                con.Close();
                fs.Close();
                Application.Run(new MainForm());



            }
            else
            {
                Application.Run(new frmConnect());
            }


        }
        public static string contmp = "";
    }
}
