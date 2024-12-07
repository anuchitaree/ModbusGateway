using EasyModbus;
using ModbusGateway.Models;
using ModbusGateway.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ModbusGateway
{
    public partial class MainForm : Form
    {
        ModbusClient modbusClient = new ModbusClient();

        ModbusServer modbusServer;

        DispatcherTimer timerPollWrite = new DispatcherTimer();
        DispatcherTimer timerPollRead = new DispatcherTimer();


        DispatcherTimer timerPoll = new DispatcherTimer();
        private List<Setting> settings = new List<Setting>();


        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] header = new string[] { "No", "Real-time-data", "UnitIdentifier", "InputRegAddr", "Input H", "Input L", "Output H", "Output L", "ServerSide InputRegAddr" };
            int[] width = new int[] { 50, 100, 100, 100, 70, 100, 70, 100, 120 };

            //InitDataGridView.Pattern_1(DgvList, header, width);

            //InitDataGridView.InitiSettings(DgvList);

            //Connection(1,true);
        }


        private void btnMonitor_Click(object sender, EventArgs e)
        {

            var result = Operations.ReadTable(DgvList);
            settings = result.Item2;

            if (btnMonitor.BackColor != Color.YellowGreen && result.Item1 == true)
            {
                timerPoll.Interval = TimeSpan.FromSeconds(1000);
                btnMonitor.BackColor = Color.YellowGreen;
                //timerPoll.Tick += timerPoll_Tick;
                timerPoll.Start();
                Console.WriteLine("conneted");
            }
            else if (result.Item1 == false || btnMonitor.BackColor == Color.YellowGreen)
            {
                btnMonitor.BackColor = SystemColors.Control;
                //timerPoll.Tick -= timerPoll_Tick;
                timerPoll.Stop();
            }

        }


        private void ModbusServerConnection()
        {
            string serverIp = tbServerIp.Text.Trim();
            int serverPort = int.Parse(tbServerPort.Text.Trim());


            try
            {
                if (txtServerStatus.BackColor == SystemColors.Control)
                {

                    modbusServer = new ModbusServer();
                    modbusServer.Port = serverPort;

                    modbusServer.UnitIdentifier = byte.Parse(tbServerUnit.Text); ;
                    txtServerStatus.BackColor = Color.LightGreen;
                    modbusServer.Listen();
                }
                else
                {
                    modbusServer.StopListening();
                    txtServerStatus.BackColor = SystemColors.Control;
                }


            }
            catch (EasyModbus.Exceptions.ConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }

        public void ModbusClientConnection(CancellationToken token)
        {
            Task t1 = Task.Run(() =>
            {
                ModbusClientConnection1();
            }, token);
        }
        private void ModbusClientConnection1()
        {
            string clientIp = "192.168.1.10";//tbClientIp.Text.Trim();
            int clientPort = int.Parse(tbClientPort.Text.Trim());
            try
            {
                if (modbusClient.Connected != true)
                {

                    int timeout = 5000;
                    modbusClient.IPAddress = clientIp;
                    modbusClient.Port = clientPort;
                    modbusClient.UnitIdentifier = byte.Parse(tbClientUnit.Text);
                    modbusClient.ConnectionTimeout = timeout;
                    modbusClient.Connect();
                    txtClientStatus.BackColor = Color.YellowGreen;
                }
                else
                {
                    modbusClient.Disconnect();
                    txtClientStatus.BackColor = SystemColors.Control;

                }
                Console.WriteLine("*");
            }
            catch (EasyModbus.Exceptions.ConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }


        private void btnConn1_Click_1(object sender, EventArgs e)
        {

            ModbusServerConnection();
            if (btnConn1.Text != "Connected")
            {
                btnConn1.BackColor = Color.YellowGreen;
                btnConn1.Text = "Connected";
                token = source.Token;
                ModbusClientConnection(token);
                //Task task = Task.Run(() =>
                //{
                //    ModbusClientConnection();
                //});
            }
            else
            {
                btnConn1.Text = "Connect";
                btnConn1.BackColor = SystemColors.Control;
                if (source != null)
                {
                    source.Cancel();
                    txtClientStatus.BackColor = SystemColors.Control;
                }
                txtServerStatus.BackColor = SystemColors.Control;

            }
            //Task task = Task.Run(() =>
            //{
            //    ModbusClientConnection(con);
            //    // Simulate work with a delay
            //    //await Task.Delay(5000);
            //    Console.WriteLine($"");
            //});




        }
    }
}
