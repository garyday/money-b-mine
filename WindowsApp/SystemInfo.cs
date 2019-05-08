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

namespace WindowsApp
{
    public partial class SystemInfo : Form
    {
        public SystemInfo()
        {
            InitializeComponent();
        }

        public float getCPU()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            float initialValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            return cpuCounter.NextValue();
        }
        public float getRAM()
        {
            var ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use", true);
            return ramCounter.NextValue();
        }

        public float getHDD()
        {
            var hddCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
            return hddCounter.NextValue();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();        
        }

        private void UpdateCounter_Tick(object sender, EventArgs e)
        {
            txtHDD.Text = getHDD().ToString() + "%";
            txtCPU.Text = getCPU().ToString() + "%";
            txtRAM.Text = getRAM().ToString() + "%";
        }
    }
}
