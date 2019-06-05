using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server_Tutorial
{
    class Server
    {
        //static void Main(string[] args)
        //{
        //    IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
        //    TcpListener server = new TcpListener(ip, 8000);
        //    TcpClient client = default(TcpClient);
        //    try
        //    {
        //        server.Start();
        //        Console.WriteLine("Server started...");

        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        Console.Read();
        //    }
        //    while(true)
        //    {
        //        client = server.AcceptTcpClient();
        //        byte[] receiveBuffer = new byte[100];
        //        NetworkStream stream = client.GetStream();

        //        stream.Read(receiveBuffer, 0 , receiveBuffer.Length);
        //        string msg = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length);
        //        Console.WriteLine(msg);


        //    }
        //}

        static void Main(string[] args)
        {
            int port = 13000;
            string IpAddress = "127.0.0.1";

            //var myprotocol = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

            Socket ServerListener = new Socket(AddressFamily
                .InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            ServerListener.Bind(ep);
            ServerListener.Listen(100);
            Console.WriteLine("Server is Listening...");
            Socket ClientSocket = default(Socket);
            int counter = 0;
            Server p = new Server();
            while (true)
            {
                counter++;
                ClientSocket = ServerListener.Accept();
                Console.WriteLine(counter + "Client connected");
                Thread UserThread = new Thread(new ThreadStart(() => p.User(ClientSocket)));
                UserThread.Start();
            }
        }
        public void User(Socket client)
        {
            while (true)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                client.Send(msg, 0, size, SocketFlags.None);
            }
        }

    }
}
