using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromTxt
{
    public partial class TxtForm : Form
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();

        public TxtForm()
        {
            InitializeComponent();

            //string path = @"Resources\UserInfo.txt";
            //string[] lines = File.ReadAllLines(path);

            string s = string.Empty;

            using (WebClient client = new WebClient())
                s = client.DownloadString("https://srv-file6.gofile.io/downloadStore/srv-store4/8HApOo/UserInfo.txt");

            string[] lines = s.Split(Environment.NewLine);


            foreach (string line in lines)
            {
                string[] userInfo = line.Split(':');
                string userName = userInfo[0];
                string password = userInfo[1];

                if (users.ContainsKey(userName))
                    users[userName] = password;
                else
                    users.Add(userName, password);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            bool authentication = users.ContainsKey(userName) && users[userName] == password;

            string message = authentication ? "Giriş Başarılı." : "Giriş başarısız!";

            MessageBox.Show(message);
        }
    }
}
