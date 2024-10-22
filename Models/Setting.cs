namespace ModbusGateway.Models
{
    public class Setting
    {

        public int No { get; set; }
        public string RealTimeValue { get; set; } = null;
        public byte UnitIdentifier { get; set; }
        public int InputRegAddr { get; set; }
        public int InputL { get; set; }
        public int InputH { get; set; }
        public int OutputL { get; set; }
        public int OutputH { get; set; }
        public int ServerSideInputRegAddr { get; set; }


        //{ "#No","Real time data","Client Reg addr" ,"Input L", "Input H", "Output L", "Output H", "Server Reg addr" }
    }
}
