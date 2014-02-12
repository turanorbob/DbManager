using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbManager
{
    public partial class FormConnect : Form
    {
        private string host = "";
        private int port= 1433;
        private string username = "";
        private string password = "";
        private string database = "";
        private bool isConnect;

        public FormConnect()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string Host {
            get {
                return host;
            }
        }

        public int Port {
            get {
                return port;
            }
        }

        public string Username {
            get {
                return username;
            }
        }

        public string Password {
            get {
                return password;
            }
        }

        public string Database {
            get {
                return database;
            }
        }

        public bool IsConnect {
            get {
                return isConnect;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isConnect = true;
            host = textBoxHost.Text;
            port = Int32.Parse(textBoxPort.Text);
            username = textBoxUsername.Text;
            password = textBoxPassword.Text;
            database = textBoxDb.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
