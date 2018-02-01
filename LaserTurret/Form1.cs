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
        public Point current = new Point();
        public Point old = new Point();
        public Point current_drawing = new Point();
        public Point old_drawing = new Point();
        public Pen p = new Pen(Color.Black, 5);
        public Graphics g;
        List<String> drawingarray = new List<String>();

        public LaserBoi()
        {
            InitializeComponent();
            g = drawpanel.CreateGraphics();
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            
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
        private void makedraw_Click(object sender, EventArgs e)
        {
            WriteArrayAsync(drawingarray.ToArray(), "Made the drawing for you!", 250);
        }

        private void cleardraw_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            drawingarray.Clear();
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
                label1.Text = String.Format("X{0}Y{1}",
                (X),
                (Y));
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
            
            if (port.IsOpen && CoordinateList.Length > 0)
            {
                int CoordinateAmount = 0;
                LaserProgress.Step = 100 / CoordinateList.Length;
                LaserProgress.PerformStep();
                foreach (String Coordinates in CoordinateList)
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
            else if(CoordinateList.Length > 0)
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

        private void drawpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                current = e.Location;
                g.DrawLine(p, old, current);
                CheckPosition(e);
                old = current;

            }
        }

        private void drawpanel_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            old_drawing = e.Location;
            Addtoarray(e);
        }
        public void CheckPosition(MouseEventArgs e)

        {
            current_drawing = e.Location;
            int offset = 40;
            if (old_drawing.X - current_drawing.X > offset || old_drawing.Y - current_drawing.Y > offset || old_drawing.Y - current_drawing.Y < -offset || old_drawing.X - current_drawing.X < -offset)
            {
                old_drawing = current_drawing;
                Addtoarray(e);

            }
            else return;

        }

        public void Addtoarray(MouseEventArgs e)
        {
    
                int X = e.Location.X / (drawpanel.Size.Width / 40);
                int Y = e.Location.Y / (drawpanel.Size.Height / 40);
                
                drawingarray.Add(String.Format("{0},{1}",
                (X + 70),
                (Y + 70)));
            

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

