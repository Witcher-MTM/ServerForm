using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClientConsole;
namespace ClientProject
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
          
            Client client = new Client();
            JsonData json = new JsonData();

            client.json = JsonSerializer.Serialize<JsonData>(json);
            client.Connect();
          




            while (true)
            {
                client.GetServerCommand(client.GetMsg());
            }




        }
    }
}
