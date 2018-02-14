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
        //Alle globale objecten
        public Point current = new Point();
        public Point old = new Point();
        public Point current_drawing = new Point();
        public Point old_drawing = new Point();
        public Pen p = new Pen(Color.Black, 5);
        public Graphics g;
        List<String> drawingarray = new List<String>();
        
        //Wordt gedraaid wanneer het programma opstart
        public LaserBoi()
        {
            //Maakt het venster gereed
            InitializeComponent();
            //Voegt een Graphics laag toe aan de tekening-paneel
            g = drawpanel.CreateGraphics();
            //Zorgt ervoor dat wat we tekenen een mooie lijn is en er geen gaten tussen zitten
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            
        }
        //Wordt gedraaid wanneer het venster laadt
        private void LaserBoi_Load(object sender, EventArgs e)
        {
            //Zorgt ervoor dat er een verbinding is met de arduino
            IndexPorts();
        }
        //Wordt gedraaid wanneer er op de "Reset Position" knop wordt geklikt
        private void ResetPosition_click(object sender, EventArgs e)
        {
            //Reset de servo naar de middelste positie
            LaserWrite(90, 90, "Reset it for you!");
        }
        //Wordt gedraaid wanneer er op de "Make Square" knop wordt geklikt
        private void MakeSquare_click(object sender, EventArgs e)
        {
            //Maakt een nieuwe lijst aan met coordinaten
            string[] CoordinatesListSquare = new string[] { "110,110", "110,70", "70,70", "70,110" };
            //Stuurt de lijst met coordinaten naar de functie die de coordinaten naar de arduino stuurt
            WriteArrayAsync(CoordinatesListSquare, "Made a square for you!");

        }
        //Wordt gedraaid wanneer er op de "Make Draw" knop wordt geklikt
        private void makedraw_Click(object sender, EventArgs e)
        {
            //Stuurt de lijst met coordinaten van de tekening naar de functie die de coordinaten naar de arduino stuurt
            WriteArrayAsync(drawingarray.ToArray(), "Made the drawing for you!", 250);
        }
        //Wordt gedraaid wanneer er op de "Clear Draw" knop wordt geklikt
        private void cleardraw_Click(object sender, EventArgs e)
        {
            //Zorgt ervoor dat het tekening-paneel gewist wordt en weer wit is
            g.Clear(Color.White);
            //Maakt de lijst met coordinaten van de tekening leeg
            drawingarray.Clear();
        }
        //Wordt gedraaid wanneer er een nieuwe COM poort wordt geselecteerd in het selectie-vakje
        private void COMPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kijkt of de poort al open is en sluit hem dan eerst zodat er geen problemen ontstaan
            if (port.IsOpen)
            {
                //Sluit de poort
                port.Close();
            }
            //Zet de tekst van het selectie-vakje naar de geselecteerde COM poort
            port.PortName = COMPortBox.Text;
            //Probeert de poort te openen een geeft een error als dat niet is gelukt
            try
            {
                //Opent de gesel
                port.Open();
            }
            //Wordt gedraaid wanneer er iets fout is gegaan met het openen van de poort
            catch (System.Exception ex)
            {
                //Laat een pop-up zien met het error-bericht
                MessageBox.Show(ex.ToString());
            }
        }
        //Functie die de coordinaten die die krijgt naar de arduino stuurt
        public void LaserWrite(int X, int Y, String Succes = "null")
        {
            //Kijkt of de poort is open en stuurt dan de coordinaten
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
            //Laat een pop-up zien wanneer de poort nog niet open is
            else
            {
                //Laat een pop-up zien met de tekst "Please select a COM port first."
                MessageBox.Show("Please select a COM port first.");
            }
            
        }
        //Functie die de lijsten met coordinaten om de beurt naar de arduino stuurt met een timeout er tussen zodat de arduino het aankan
        public async void WriteArrayAsync (string[] CoordinateList,String Succes = "null", int Timeout = 500)
        {
            //Kijkt of de poort open is en of de lijst niet leeg is
            if (port.IsOpen && CoordinateList.Length > 0)
            {
                //Zet het variabel CoordinateAmount naar 0 zodat de loop dat kan gebruiken
                int CoordinateAmount = 0;
                //Zet het laadbalkje naar de lengte van de lijst zodat het een accuraate weergave heeft
                LaserProgress.Maximum = CoordinateList.Length;
                //Zet de hoeveelheid van een stap van het laadbalkje 
                LaserProgress.Step = 1;
                //Zet de eerste stap in het laadbalkje
                LaserProgress.PerformStep();
                //De loop die om de beurt de coordinaten stuurt
                foreach (String Coordinates in CoordinateList)
                {
                    //Zet het variabele X naar het goede aantal graden
                    String X = Coordinates.ToString().Remove(Coordinates.IndexOf(","));
                    //Zet het variabele y naar het goede aantal graden
                    String Y = Coordinates.ToString().Remove(0, Coordinates.IndexOf(",") + 1);
                    //Zet de variabelen om naar cijfers en stuurt het naar de arduino
                    LaserWrite(Int32.Parse(X), Int32.Parse(Y));
                    //Zet het variabele "CoordinateAmount" naar CoordinateAmount + 1
                    CoordinateAmount++;
                    //Zet een stap voor het laadbalkje
                    LaserProgress.PerformStep();
                    //Kijkt of de coordinaat het laatste in het lijstje is en of er een eind bericht is ingesteld
                    if(CoordinateAmount == CoordinateList.Length && Succes != "null")
                    {
                        //Laat een pop-up zien met het ingestelde bericht
                        MessageBox.Show(Succes);
                        //Zet het laadbalkje weer terug
                        LaserProgress.Value = 0;
                    }
                    //Wacht de ingestelde tijd voor dat hij weer opnieuw begint
                    await Task.Delay(Timeout);
                }
                
            }
            //Wordt gedraaid wanneer de lijst geen coordinaten heeft
            else if(CoordinateList.Length > 0)
            {
                //Laat een pop-up zien met de tekst "You haven't drawn anything yet"
                MessageBox.Show("You haven't drawn anything yet");
            }

           
        }
        //Functie die ervoor zorgt dat de poort goed work gekozen in het begin en dat de mogelijke poorten worden toegevoegd aan het selectievakje
        private void IndexPorts()
        {
            //Maakt een lijstje "ports" aan met alle namen van de beschikbare poorten
            string[] ports = SerialPort.GetPortNames();
            //Zet elke poort in het selectievakje
            foreach (string port in ports)
            {
                //Zet de poort in het selectievakje als een optie
                COMPortBox.Items.Add(port);
            }
            //Kijkt of er maar 1 beschikbare poort is
            if (COMPortBox.Items.Count == 1)
            {
                //Zet de eerste poort als geselecteerde poort
                COMPortBox.Text = ports.First().ToString();
                //Kijkt of de poort open is
                if (port.IsOpen)
                {
                    //Zet de poort dicht
                    port.Close();
                }
                //Opent de poort
                port.Open();
            }
            //Wordt gedraaid wanneer er meerdere poorten zijn
            else
            {
                //Zet het selectievakje naar de tekst "Select.."
                COMPortBox.Text = "Select..";
            }
        }
        //Wordt gedraaid wanneer de muis beweegt over het tekening-paneel
        private void drawpanel_MouseMove(object sender, MouseEventArgs e)
        {
            //Kijkt of de linker-muisknop wordt ingedrukt
            if(e.Button == MouseButtons.Left)
            {
                //Zet de "current" locatie naar de locatie van de muis
                current = e.Location;
                //Tekent een lijn van het oude punt naar nhet nieuwe
                g.DrawLine(p, old, current);
                //Kijkt of de muis genoeg heeft bewogen om in het coordinaten lijstje te stoppen
                CheckPosition(e);
                //Zet de "old" locatie naar de locatie van de muis
                old = current;

            }
        }
        //Wordt gedraaid wanneer er op de linker-muisknop wordt gedrukt en de cursor op het tekening-paneel is
        private void drawpanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Zet de "old" locatie naar de locatie van de muis
            old = e.Location;
            //Zet de "old_drawing" locatie naar de locatie van de muis
            old_drawing = e.Location;
            //Zet de locatie van de muis in de lijst met coordinaten
            Addtoarray(e);
        }
        //Functie die kijkt of de muis genoeg heeft bewogen om in het coordinaten lijstje te stoppen
        public void CheckPosition(MouseEventArgs e)

        {
            //Zet de "current_drawing" locatie naar de locatie van de muis
            current_drawing = e.Location;
            //Zet de minimale afwijking voor het sturen naar de locatie naar het gekozen getal
            int offset = 20;
            //Kijkt of er een positieve of negatieve afwijking is op beide assen
            if ((old_drawing.X - current_drawing.X) + (old_drawing.Y - current_drawing.Y) > -offset 
                    || (old_drawing.X - current_drawing.X) + (old_drawing.Y - current_drawing.Y) > offset 
                    || old_drawing.X - current_drawing.X > offset 
                    || old_drawing.Y - current_drawing.Y > offset 
                    || old_drawing.Y - current_drawing.Y < -offset 
                    || old_drawing.X - current_drawing.X < -offset)
            {
                //Zet de "old_drawing" locatie naar de "current_drawing" locatie zodat er weer opnieuw een afwijking kan worden gemeten
                old_drawing = current_drawing;
                //Voegt de locatie van de muis toe aan het lijstje van coordinaten
                Addtoarray(e);

            }

        }
        //Voegt het coordinaat toe aan het lijstje met coordinaten
        public void Addtoarray(MouseEventArgs e)
        {
            //Rekent de X coordinaat van het paneel om tot die van de arduino
            int X = 40 - e.Location.X / (drawpanel.Size.Width / 40);
            //Rekent de Y coordinaat van het paneel om tot die van de arduino
            int Y = 40 - e.Location.Y / (drawpanel.Size.Height / 40);
            //Voegt het omgevormde coordinaat toe aan het lijstje
            drawingarray.Add(String.Format("{0},{1}",
                (X + 70),
                (Y + 80)));
            

        }
    }
}

