using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace LaserTurret
{
    public partial class LaserBoi : Form
    {
        public Stopwatch watch { get; set; }

        public LaserBoi()
        {
            InitializeComponent();
        }

        private void LaserBoi_Load(object sender, EventArgs e)
        {
            IndexPorts();
        }

        private void ResetPosition_click(object sender, EventArgs e)
        {
            LaserWrite(90, 90, "Reset it for you!");
        }

        private void MakeSquare_click(object sender, EventArgs e)
        {
            string[] CoordinatesListSquare = new string[] { "80,90", "90,80", "80,80", "90,90" };
            WriteArrayAsync(CoordinatesListSquare, "Made a square for you!");

        }

        private void COMPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Close();
            }
            port.PortName = COMPortBox.Text;
            try
            {
                port.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LaserWrite(int X, int Y, String Succes = "null")
        {
            if (port.IsOpen)
            { 
                port.Write(String.Format("X{0}Y{1}",
                (X),
                (Y)));
                if (Succes != "null")
                {
                    MessageBox.Show(Succes);
                }
            }
            else
            {
                MessageBox.Show("Please select a COM port first.");
            }
            
        }
        
        public async void WriteArrayAsync (string[] CoordinateList,String Succes = "null", int Timeout = 500)
        {
            
            if (port.IsOpen)
            {
                int CoordinateAmount = 0;
                LaserProgress.Step = 100 / CoordinateList.Length;
                foreach(String Coordinates in CoordinateList)
                {
                    String X = Coordinates.ToString().Remove(Coordinates.IndexOf(","));
                    String Y = Coordinates.ToString().Remove(0, Coordinates.IndexOf(",") + 1);
                    LaserWrite(Int32.Parse(X), Int32.Parse(Y));
                    CoordinateAmount++;
                    LaserProgress.PerformStep();
                    if(CoordinateAmount == CoordinateList.Length && Succes != "null")
                    {
                        MessageBox.Show(Succes);
                        LaserProgress.Value = 0;
                    }
                    await Task.Delay(Timeout);
                }
                
            }
            else
            {
                LaserWrite(0, 0);
            }

           
        }
        
        private void IndexPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                COMPortBox.Items.Add(port);
            }
            if (COMPortBox.Items.Count == 1)
            {
                COMPortBox.Text = ports.First().ToString();
                if (port.IsOpen)
                {
                    port.Close();
                }
                port.Open();
            }
            else
            {
                COMPortBox.Text = "Select..";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }
    }
}

