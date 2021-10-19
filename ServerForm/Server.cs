using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using ClientProject;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using ServerForm;
namespace ServerProject
{
    class Server
    {
       
        public int Client_ID;
        private string ipAddr;
        private int port;
        private IPEndPoint ipPoint;
        public Socket socket;
        public Socket socketclient;
        public List<Client> clients;
        public List<string> tmp_cool;
        public JsonData json;

       

        public Server()
        {
            this.Client_ID = -1;
            this.ipAddr = "127.0.0.1";
            this.port = 8000;
            this.ipPoint = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.clients = new List<Client>();
            this.tmp_cool = new List<string>();
            this.json = new JsonData();

        }
        public void StartServer()
        {
            try
            {

                this.socket.Bind(ipPoint);
                this.socket.Listen(10);

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                throw;
            }


        }
        public void ConnectOne()
        {
            bool check = true;
            while (check)
            {
                this.socketclient = this.socket.Accept();
                clients.Add(new Client(socketclient));

                if (clients.Count > 0)
                {
                    check = false;
                }
            }

        }
        public void Connects()
        {
            while (true)
            {

                this.socketclient = this.socket.Accept();
                clients.Add(new Client(socketclient));
                this.Client_ID++;
                clients[clients.Count - 1].ID = this.Client_ID;
                
            }

        }
        public StringBuilder GetMsgAll()
        {

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256];
            foreach (var item in clients)
            {
                do
                {

                    bytes = item.socket.Receive(data);

                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (item.socket.Available > 0);
            }

            return builder;
        }
        public StringBuilder GetMsgFromOne(int ClientID)
        {

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256];
              do
              {

                    bytes = clients[ClientID].socket.Receive(data);

                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
              } while (clients[ClientID].socket.Available > 0);

            json = JsonSerializer.Deserialize<JsonData>(builder.ToString());
            return builder;
        }
        public void SendMsg(string message)
        {
            byte[] data = new byte[256];
            foreach (var item in clients)
            {
                if (File.Exists(message) && Path.GetFileName(message).Contains(".txt") || Path.GetFileName(message).Contains(".rtf"))
                {
                    item.socket.Send(Encoding.Unicode.GetBytes(File.ReadAllText(message)));
                }
                else
                {
                    item.socket.Send(Encoding.Unicode.GetBytes(message));
                }
            }

        }
        public void SendMsg(string message, int user)
        {
           
            clients[user].socket.Send(Encoding.Unicode.GetBytes(message));

        }
        public void SendCommand(int choice)
        {
            int ID_choice = 0;

           
               
                switch (choice)
                {

                    case 1:
                        {
                            StartBrowser(ID_choice);
                            break;
                        }
                    case 2:
                        {

                            ThrowDisconnect(ID_choice);

                            break;
                        }
                    case 3:
                        {
                            SearchFiles(ID_choice);


                            break;
                        }
                    case 4:
                        {
                            Json(ID_choice);
                            break;
                        }
                    default:
                       
                        break;
                }
           
        }
        public void SendBrowser(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        SendMsg("Start Opera");
                        break;
                    }
                case 2:
                    {
                        SendMsg("Start Chrome");
                        break;
                    }
                case 3:
                    {
                        SendMsg("Start Mozilla");
                        break;
                    }
                case 4:
                    {
                        SendMsg("Start Edge");
                        break;
                    }
                default:
                    break;
            }
        }
        public void SendBrowser(int choice, int user)
        {
            switch (choice)
            {
                case 1:
                    {
                        SendMsg("Start Opera", user);
                        break;
                    }
                case 2:
                    {
                        SendMsg("Start Chrome", user);
                        break;
                    }
                case 3:
                    {
                        SendMsg("Start Mozilla", user);
                        break;
                    }
                case 4:
                    {
                        SendMsg("Start Edge", user);
                        break;
                    }
                default:
                    break;
            }
        }
        public void Json(int ID_choice)
        {
            SendMsg("json\n", ID_choice);
            GetMsgFromOne(ID_choice);
        }
        public void SearchFiles(int ID_choice)
        {
            this.tmp_cool = new List<string>();
            string tmp = String.Empty;
            lock (clients)
            {
                try
                {
                    SendMsg("search\n", ID_choice);
                    tmp = GetMsgFromOne(ID_choice).ToString();
                }
                catch (Exception)
                {


                }
               
                tmp_cool = tmp.Split('\n').ToList();
                for (int i = 0; i < tmp_cool.Count; i++)
                {
                    if (tmp_cool[i] == "")
                    {
                        tmp_cool.Remove(tmp_cool[i]);
                    }
                }

                //try
                //{
                //    SendProcess(words[int.Parse(Console.ReadLine())], ID_choice);
                //    //Console.WriteLine(GetMsg().ToString());
                //}
                //catch (Exception ex)
                //{
                //    //Console.WriteLine(ex.Message);
                //}

            }
        }
        public void ThrowDisconnect(int ID_choice)
        {
            lock (clients)
            {
                for (int i = 0; i < clients.Count; i++)
                {

                    if (clients[i].ID == ID_choice)
                    {
                        SendMsg("Exit", i);
                        clients[i].socket.Disconnect(false);

                        clients.RemoveAt(i);
                    }

                }

            }
        }
        public void StartBrowser(int ID_choice)
        {
            int server_choice = 0;
            lock (clients)
            {

                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].ID == ID_choice)
                    {
                       // Console.WriteLine("Choice a Browser\nOpera: 1\nChrome: 2\nMozilla FireFox: 3\n Edge: 4");
                        try
                        {
                            server_choice = int.Parse(Console.ReadLine());
                            if (server_choice > 4)
                            {
                                throw new Exception();
                            }
                            SendBrowser(server_choice, i);
                        }
                        catch (Exception)
                        {
                            //Console.WriteLine("You can entry only numbs");
                            i = 0;
                        }

                    }

                }
            }
        }
        public void CheckClient()
        {
            foreach (var item in clients)
            {
                if (item.socket.Connected == false)
                {
                    clients.Remove(item);
                }
            }
        }
        public void SendProcess(string app, int ID_choice)
        {
            SendMsg("start\n" + $"{app}", ID_choice);
        }


    }
}
