using EasyModbus;
using ModbusGateway.Models;
using ModbusGateway.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
            string[] header = new string[] { "No", "Real time data", "UnitIdentifier", "InputRegAddr", "Input L", "Input H", "Output L", "Output H", "ServerSide InputRegAddr" };
            int[] width = new int[] { 50, 100, 100, 100, 70, 100, 70, 100, 120 };

            //InitDataGridView.Pattern_1(DgvList, header, width);

            //InitDataGridView.InitiSettings(DgvList);

            //Connection(1,true);
        }
        //private void Connection(byte unitIdentifier,bool connect)
        //{
        //    try
        //    {
        //        if (connect == true)
        //        {
        //            string ip = tbClientIp.Text.Trim();
        //            int port = int.Parse(tbClientPort.Text.Trim());
        //            int timeout = 5000;
        //            modbusClient.IPAddress = "192.168.1.1";
        //            modbusClient.Port = port;
        //            modbusClient.UnitIdentifier = unitIdentifier;
        //            modbusClient.ConnectionTimeout = timeout;
        //            modbusClient.Connect();
        //            Thread.Sleep(10);

        //            modbusServer.IPAddress = "192.168.2.1";
        //            modbusServer.Port = port;
        //            modbusServer.UnitIdentifier = unitIdentifier;
        //            modbusServer.ConnectionTimeout = timeout;
        //            modbusServer.Connect();
        //        }
        //        else
        //        {
        //            modbusClient.Disconnect();
        //            modbusServer.Disconnect();
        //        }
        //    }
        //    catch (EasyModbus.Exceptions.ConnectionException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch (System.Net.Sockets.SocketException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //lbStatus.Text = "Status : Connection timed out";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
           

        //}

        private void timerPoll_Tick(object sender, EventArgs e)
        {




        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {

            var result = Operations.ReadTable(DgvList);
            settings = result.Item2;

            if (btnMonitor.BackColor != Color.YellowGreen && result.Item1 == true)
            {
                timerPoll.Interval = TimeSpan.FromSeconds(1000);
                btnMonitor.BackColor = Color.YellowGreen;
                timerPoll.Tick += timerPoll_Tick;
                timerPoll.Start();
                Console.WriteLine("conneted");
            }
            else if (result.Item1 == false || btnMonitor.BackColor == Color.YellowGreen)
            {
                btnMonitor.BackColor = SystemColors.Control;
                timerPoll.Tick -= timerPoll_Tick;
                timerPoll.Stop();
            }

        }

        private void btnConn1_Click(object sender, EventArgs e)
        {

            var clientsetting = new SetModbus() 
            {
                modbusClient=modbusClient,
                IpAddress = tbClientIp.Text.Trim(),
                Port = int.Parse(tbClientPort.Text.Trim()
                
            };
            string serverIp = tbServerIp.Text.Trim();
            int serverPort = int.Parse(tbServerPort.Text.Trim());

            //Connection(2, true);
            if (modbusClient.Connected == true && modbusServer.Connected == true)
            {
                Console.WriteLine("Connected !");
            }
            try
            {
                //int[] vals = modbusClient0.ReadHoldingRegisters(0, 10);
                //Console.WriteLine(vals);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connection(1, false);
            //if (modbusClient.Connected != true && modbusServer.Connected != true)
            //{
            //    Console.WriteLine("Dis-Connected !");
            //}
        }
    }
}
