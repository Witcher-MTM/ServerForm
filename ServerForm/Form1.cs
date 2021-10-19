using ServerProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                this.JsonInfo.Visible = true;
                this.DesktopFiles.Visible = true;
            }
        }

        
        public void CreateText(int id)
        {
            this.textBox1.Visible = true;
            this.textBox1.Text = server.GetMsgFromOne(id).ToString();
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
        public void initBtns(Button client)
        {
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
                        Text = Path.GetFileName(item),
                        Name = i.ToString(),
                    });

                    clients_apps_Btn[i].Click += Apps_Click;
                    i++;
                }

            }
        }

      

        private void JsonInfo_Click(object sender, EventArgs e)
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
                btns_Clients.Add(new Button()
                {
                    Size = new Size(100, 50),
                    Location = new Point(x += 100, y),
                    Text = $"<ID>[{i}]" + "-" + $"{server.socketclient.Connected}",
                    Name = i.ToString(),
                });

                btns_Clients[i].Click += JsonClick;
            }
            for (int i = 0; i < btns_Clients.Count; i++)
            {
                Controls.Add(btns_Clients[i]);
            }
            SeeClientsBtn.Visible = false;
            BackBtn.Visible = true;
        }

      

        private void DesktopFiles_Click(object sender, EventArgs e)
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
                btns_Clients.Add(new Button()
                {
                    Size = new Size(100, 50),
                    Location = new Point(x += 100, y),
                    Text = $"<ID>[{i}]" + "-" + $"{server.socketclient.Connected}",
                    Name = i.ToString(),
                });

                btns_Clients[i].Click += DeskTopClick;
            }
            for (int i = 0; i < btns_Clients.Count; i++)
            {
                Controls.Add(btns_Clients[i]);
            }
            SeeClientsBtn.Visible = false;
            BackBtn.Visible = true;
        }
        private void JsonClick(object sender, EventArgs e)
        {
            server.SendCommand(4);
            this.textBox1.Visible = true;
            this.textBox1.Text = server.json.ToString();
        }
        private void DeskTopClick(object sender, EventArgs e)
        {
            clientID = (Button)sender;
            initBtns(clientID);
            Icon ic;
            for (int i = 0; i < clients_apps_Btn.Count(); i++)
            {
                if (!server.tmp_cool[i].EndsWith("desktop.ini"))
                {
                    ic = Icon.ExtractAssociatedIcon(server.tmp_cool[i]);
                    clients_apps_Btn[i].BackgroundImage = ic.ToBitmap();
                    clients_apps_Btn[i].BackgroundImageLayout = ImageLayout.Stretch;
                }

            }
            for (int j = 0; j < clients_apps_Btn.Count; j++)
            {
                Controls.Add(clients_apps_Btn[j]);
            }
        }
    }
}
