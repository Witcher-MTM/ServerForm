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
        int client_ID = 0;
        Server server = new Server();
        public Form1()
        {
            InitializeComponent();
            server.StartServer();
            Task.Factory.StartNew(() => server.Connects());
        }

        private void seeClients_Click(object sender, EventArgs e)
        {
          
            if (server.clients.Count == 0)
            {
                MessageBox.Show("No conections!", "Info", MessageBoxButtons.OK);
            }
            else
            {
                int x = 0;
                int y = 0;
                for (int i = 0; i < server.clients.Count; i++)
                {
                   
                    if (i % 3 == 0)
                    {
                        y += 50;
                        x = 20;
                    }
                         btns_Clients.Add(new Button() {
                        Size = new Size(100,50),
                        Location = new Point(x+=100, y),
                        Text = $"<ID>[{i}]" + "-" + $"{server.socketclient.Connected}",
                        Name = i.ToString(),
                });

                    btns_Clients[i].Click += Clients_Click;
                }
                for (int i = 0; i < btns_Clients.Count; i++)
                {
                    Controls.Add(btns_Clients[i]);
                }
                SeeClientsBtn.Visible = false;
                BackBtn.Visible = true;
            }
        }

        private void Clients_Click(object sender, EventArgs e)
        {

            clientID = (Button)sender;
            client_ID = int.Parse(clientID.Name);
            server.SearchFiles(int.Parse(clientID.Name));
            for (int i = 0; i < btns_Clients.Count; i++)
            {
                btns_Clients[i].Visible = false;
            }
            if (server.tmp_cool.Count != 0)
            {
                int x = 0;
                int y = 0;
                int i = 0;
                foreach (var item in server.tmp_cool)
                {
                    
                    if (i % 6 == 0)
                    {
                        y += 50;
                        x = 20;
                    }
                    clients_apps_Btn.Add(new Button()
                    {
                        Size = new Size(100, 50),
                        Location = new Point(x += 100, y),
                        Text = item,
                        Name = i.ToString(),
                    });

                    clients_apps_Btn[i].Click += Apps_Click;
                    i++;
                }
            }

            for (int j = 0; j < clients_apps_Btn.Count; j++)
            {
                Controls.Add(clients_apps_Btn[j]);
            }

        }

        private void Apps_Click(object sender, EventArgs e)
        {
            client_app = (Button)sender;
            server.SendProcess(client_app.Text, client_ID);
        }

        private List<Button> btns_Clients = new List<Button>();
        private List<Button> clients_apps_Btn = new List<Button>();
        private Button clientID = new Button();
        private Button client_app = new Button();
    }
}
