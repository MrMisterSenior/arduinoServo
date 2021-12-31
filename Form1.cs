using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoLight
{
    public partial class ABOBA : Form
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        public ABOBA()
        {
            InitializeComponent();
        }
        private void ABOBA_Load(object sender, EventArgs e)
        {
            serialPort.Open();
        }
        private void ABOBA_MouseMove(object sender, MouseEventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > 50)
            {
                serialPort.Write($"{180 - e.X / (Size.Width / 180)},{180 - e.Y / (Size.Height / 180)}");
                stopwatch.Restart();
            }
        }

        private void ABOBA_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Write("90,90");
            serialPort.Close();
        }
    }
}