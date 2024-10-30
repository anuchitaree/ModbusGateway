using EasyModbus;
using ModbusGateway.Models;
using ModbusGateway.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ModbusGateway.Modules
{
    public static class Operations
    {
        public static (bool,List<Setting>) ReadTable(DataGridView Dgv)
        {
            try
            {
                var settings = new List<Setting>();
                int row = Dgv.Rows.Count;
                int col = Dgv.Columns.Count;
                for (int r = 0; r < row; r++)
                {
                    var unit = Dgv.Rows[r].Cells[2].Value.ToString().Remove(0, 1);
                    var intputReg = Dgv.Rows[r].Cells[3].Value.ToString().RemoveWhitespace();
                    var inL = Dgv.Rows[r].Cells[4].Value.ToString();
                    var inH = Dgv.Rows[r].Cells[5].Value.ToString();
                    var outL = Dgv.Rows[r].Cells[6].Value.ToString();
                    var outH = Dgv.Rows[r].Cells[7].Value.ToString();
                    var serverReg = Dgv.Rows[r].Cells[8].Value.ToString().RemoveWhitespace();

                    var setting = new Setting()
                    {
                        No = r,
                        RealTimeValue = null,
                        UnitIdentifier = byte.Parse(unit),
                        InputRegAddr = int.Parse(intputReg),
                        InputL = int.Parse(inL),
                        InputH = int.Parse(inH),
                        OutputL = int.Parse(outL),
                        OutputH = int.Parse(outH),
                        ServerSideInputRegAddr = int.Parse(serverReg),
                    };
                    settings.Add(setting);

                }

                return (true,settings);
            }
            catch
            {
                return (false, new List<Setting>());
            }
        }

        public static void UpdateTable(DataGridView Dgv)
        {
            return;
        }
        public static string RemoveWhitespace(this string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }


        private static void Connection(ModbusClient modbusClient, ModbusClient modbusServer,  SetModbus client, SetModbus server)
        {
            try
            {
                if (client.Connect == true)
                {
                   
                    int timeout = 5000;
                    modbusClient.IPAddress = client.IpAddress;
                    modbusClient.Port = client.Port;
                    modbusClient.UnitIdentifier = client.UnitIdentify;
                    modbusClient.ConnectionTimeout = timeout;
                    modbusClient.Connect();
                }
                else
                {
                    modbusClient.Disconnect();
                }

                if (server.Connect == true)
                {

                    int timeout = 5000;
                    modbusServer.IPAddress = server.IpAddress;
                    modbusServer.Port = server.Port;
                    modbusServer.UnitIdentifier = server.UnitIdentify;
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


        }

    }
}
