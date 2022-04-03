using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient tcpClient = new TcpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8000);
            MessageBox.Show("successful connection");
        }

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            NetworkStream stream = tcpClient.GetStream();
            var sw = new StreamWriter(stream);
            string message = ClientText.ToString();

            string[] parts = message.Split(':');
            message = parts[1];


            sw.WriteLine(message);
            sw.Flush();
            InfoSctream.Clear();
            InfoSctream.Text = message;
            ClientText.Clear();
            
        }
    }
}
