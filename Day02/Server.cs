﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Day02
{
    public partial class Server : Form
    {
        Socket server;
        Socket client;
        IPEndPoint ipe;
        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1234);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(10);
            client = server.Accept();
            tbIP.Text = (client.RemoteEndPoint).ToString();
            byte[] data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client: " + Encoding.ASCII.GetString(data));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = rTB1.Text;
            listBox1.Items.Add("Server :" + text);
            rTB1.Text = "";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(text);
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client:" + Encoding.ASCII.GetString(data));
        }
    }
}
