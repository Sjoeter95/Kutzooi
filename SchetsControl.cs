using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace SchetsEditor
{   public class SchetsControl : UserControl
    {   private Schets schets;
        private List<SchetsItem> itemlijst;
        private Color penkleur;

        public Color PenKleur
        { get { return penkleur; } }

        internal List<SchetsItem> Itemlijst
        { get { return itemlijst; } }

        public Schets Schets
        { get { return schets;   }
        }
        public SchetsControl()
        {   this.BorderStyle = BorderStyle.Fixed3D;
            this.schets = new Schets();
            this.itemlijst = new List<SchetsItem>();
            this.Paint += this.teken;
            this.Resize += this.veranderAfmeting;
            this.veranderAfmeting(null, null);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        private void teken(object o, PaintEventArgs pea)
        {   schets.Teken(pea.Graphics);
        }
        private void veranderAfmeting(object o, EventArgs ea)
        {   schets.VeranderAfmeting(this.ClientSize);
            this.Invalidate();
        }
        public Graphics MaakBitmapGraphics()
        {   Graphics g = schets.BitmapGraphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return g;
        }
        public void Schoon(object o, EventArgs ea)
        {   schets.Schoon();
            this.Invalidate();
        }
        public void Roteer(object o, EventArgs ea)
        {   schets.VeranderAfmeting(new Size(this.ClientSize.Height, this.ClientSize.Width));
            schets.Roteer();
            this.Invalidate();
        }
        public void VeranderKleur(object obj, EventArgs ea)
        {   string kleurNaam = ((ComboBox)obj).Text;
            penkleur = Color.FromName(kleurNaam);
        }
        public void VeranderKleurViaMenu(object obj, EventArgs ea)
        {   string kleurNaam = ((ToolStripMenuItem)obj).Text;
            penkleur = Color.FromName(kleurNaam);
        }

        //nieuwe zooi

        public void SchrijfTeskstbestand() // schrijft van de list een Tekstbestand
        {
            TextBox Text = new TextBox();
            foreach (SchetsItem obj in itemlijst)
            { 
                Text.Text = obj.SchetsinTekst() + "\n";

            }


        }

        public void RegelnaarList(string s) // Maakt van een Tekstbestand een list
        {
            char[] splitter = { '|', ';', ':', '?', '.', '-' };  // voor | staat type, voor ? staat char, voor ; X start, , voor : staat Y start, voor . staat kwast
            string[] bestand = s.Split(splitter);


            if (bestand[0] == "TI")
            { }           

            else if (bestand[0] == "RI")
            { }              
               
            else if (bestand[0] == "CI")
            { }               

            else if (bestand[0] == "LI")
            { }

            else { }

            }

        public void ControleRegel(string s) // Maakt van een Tekstbestand een list
        {
            char[] splitter = { '|', ';', ':', '?', '.', '-' };  // voor | staat type, voor ? staat char, voor ; X start, , voor : staat Y start, voor . staat kwast
            string[] bestand = s.Split(splitter);

        }
        private Point StringnaarPunt(string a, string b)
        {
            try { Point p= new Point(int.Parse(a), int.Parse(b));
                return p; }
            catch {
                Point q = new Point(-1, -1);
                return q; }
        }
        private bool Stringnaarbool(string a)
        {
            if (a == "true")
            { return true; }
            else if (a == "false")
                return false;
            else return false; // hier nog naar kijken        
        }


        public void nieuweBitmap(Bitmap b)
        {   schets.MaakBitmap(b, this.ClientSize);
            this.Invalidate();
        }

        public Bitmap GeefBitmap
        {
            get { return schets.GeefBitmap; }
        }
    }   
}
