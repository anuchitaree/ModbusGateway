using EasyModbus;
using ModbusGateway.Models;
using ModbusGateway.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ModbusGateway
{
    public partial class MainForm : Form
    {
        ModbusClient modbusClient = new ModbusClient();

        ModbusClient modbusServer = new ModbusClient();


        DispatcherTimer timerPollWrite = new DispatcherTimer();
        DispatcherTimer timerPollRead = new DispatcherTimer();


        DispatcherTimer timerPoll = new DispatcherTimer();
        private List<Setting> settings = new List<Setting>();
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


        private void ModbusConnection()
        {
            string clientIp = tbClientIp.Text.Trim();
            int clientPort = int.Parse(tbClientPort.Text.Trim());

            string serverIp = tbServerIp.Text.Trim();
            int serverPort = int.Parse(tbServerPort.Text.Trim());


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
                }
                else
                {
                    modbusClient.Disconnect();
                }

                if (modbusServer.Connected != true)
                {

                    int timeout = 5000;
                    modbusServer.IPAddress = serverIp;
                    modbusServer.Port = serverPort;
                    modbusServer.UnitIdentifier = byte.Parse(tbServerUnit.Text); ;
                    modbusServer.ConnectionTimeout = timeout;
                    modbusServer.Connect();
                }
                else
                {
                    modbusServer.Disconnect();
                }


            }
            catch (EasyModbus.Exceptions.ConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex.Message);
                //lbStatus.Text = "Status : Connection timed out";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




            //Connection(2, true);
            if (modbusClient.Connected == true && modbusServer.Connected == true)
            {
                Console.WriteLine("Connected !");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConn1_Click_1(object sender, EventArgs e)
        {
            if (btnConn1.Text != "Connected")
            {
                btnConn1.BackColor = Color.YellowGreen;
                btnConn1.Text = "Connected";
            }
            else
            {
                btnConn1.Text = "Connect";
                btnConn1.BackColor = SystemColors.Control;
            }
            
        }
    }
}
