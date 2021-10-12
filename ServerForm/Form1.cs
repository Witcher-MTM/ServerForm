using ServerProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForm
{
    public partial class Form1 : Form
    {
        Server server = new Server();
        public Form1()
        {
            InitializeComponent();
            server.StartServer();
            Task.Factory.StartNew(() => server.Connects());
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (server.clients.Count == 0)
            {
                MessageBox.Show("No conections!", "Info", MessageBoxButtons.OK);
            }
            else
            {
                int x = button1.Location.X+button1.Width;
                int y = 40;
                for (int i = 0; i < server.clients.Count; i++)
                {
                    btns_Clients.Add(new Button());
                    this.btns_Clients[i] = new Button();
                    this.btns_Clients[i].Size = new Size(x, y);
                    this.btns_Clients[i].Location = new Point(x*i);
                    this.btns_Clients[i].Text = $"{server.Client_ID} - {server.socketclient.Connected}";
                    this.btns_Clients[i].Name = i.ToString();
                    this.btns_Clients[i].Click += Clients_Click;

                }
                for (int i = 0; i < btns_Clients.Count; i++)
                {
                    Controls.Add(btns_Clients[i]);
                }
                button1.Visible = false;
            }
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            clientID = (Button)sender;
            
            server.SearchFiles(int.Parse(clientID.Name));
            if (server.tmp_cool.Count != 0)
            {
                client_apps.Items.Clear();
                foreach (var item in server.tmp_cool)
                {
                    client_apps.Items.Add(item);
                }
               

            }

        }

        private List<Button> btns_Clients = new List<Button>();

        private void StartProcess_Click(object sender, EventArgs e)
        {
            server.SendProcess(this.client_apps.SelectedItem.ToString(), int.Parse(clientID.Name));
        }

        private void client_apps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.client_apps.SelectedIndex >= 0)
            {
                this.StartProcess.Visible = true;
            }
        }
        private Button clientID = new Button();
    }
}
