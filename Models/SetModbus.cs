using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusGateway.Models
{
    public class SetModbus

    {
        public ModbusClient modbusClient { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public byte UnitIdentify { get; set; }
        public bool Connect { get; set; }
    }
}
