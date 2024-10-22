using ModbusGateway.Models;
using ModbusGateway.Properties;
using System;
using System.Collections.Generic;
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
    }
}
