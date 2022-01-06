using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOCK
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        SqlConnection GetCon(string server, string username, string pass, string database)
        {
            return new SqlConnection("Data Source=" + server + "; Initial Catalog=" + database + ";User ID=" + username + "; Password=" + pass + ";");
        }
        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetCon(txtServer.Text, txtUserName.Text, txtPassword.Text, txtDatabase.Text);
            try
            {
                con.Open();
                MessageBox.Show("Connect Successfull", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Connect Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String enCrypServ = Encryptor.Encrypt(txtServer.Text, "sblw-3hn8-sqoy19");
            String enCrypPass = Encryptor.Encrypt(txtPassword.Text, "sblw-3hn8-sqoy19");
            String enCrypData = Encryptor.Encrypt(txtDatabase.Text, "sblw-3hn8-sqoy19");
            String enCrypUsername = Encryptor.Encrypt(txtUserName.Text, "sblw-3hn8-sqoy19");
            connect cn = new connect(enCrypServ, enCrypUsername, enCrypPass, enCrypData);
            cn.SaveFile();
            MessageBox.Show("Save Data Success", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            txtDatabase.Items.Clear();
            try
            {
                string Conn = "server=" + txtServer.Text + "; User Id=" + txtUserName.Text + "; password=" + txtPassword.Text + ";";
                SqlConnection con = new SqlConnection(Conn);
                con.Open();
                string sql = "select name from sys.databases WHERE name NOT IN('master','tempdb','model', 'msdb')";
                SqlCommand cmd = new SqlCommand(sql, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtDatabase.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}