using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client1 : Form
    {
        Socket server;
        Socket client;
        IPEndPoint ipe;
        public Client1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(rTB1.Text);
            listBox1.Items.Add("Client: " + rTB1.Text);
            rTB1.Text = "";
            client.Send(data);
            data = new byte[1024];
            client.Receive(data);
            string text = Encoding.ASCII.GetString(data);
            listBox1.Items.Add("Server: " + text);
        }
    }
}
