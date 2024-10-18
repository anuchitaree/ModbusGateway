using ModbusGateway.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusGateway
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] header = new string[] { "#No","Real time data","Client Reg addr" ,"Input L", "Input H", "Output L", "Output H", "Server Reg addr" };
            int[] width = new int[] { 70,120 ,100, 100, 100, 100, 100, 120 };

            InitDataGridView.Pattern_1(DgvList, header, width);
        }
    }
}
