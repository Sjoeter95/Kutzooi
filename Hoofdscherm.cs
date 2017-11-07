﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchetsEditor
{
    public class Hoofdscherm : Form
    {
        MenuStrip menuStrip;

        public Hoofdscherm()
        {   this.ClientSize = new Size(800, 600);
            menuStrip = new MenuStrip();
            this.Controls.Add(menuStrip);
            this.maakFileMenu();
            this.maakHelpMenu();
            this.Text = "Schets editor";
            this.IsMdiContainer = true;
            this.MainMenuStrip = menuStrip;
        }
        private void maakFileMenu()
        {   ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("File");
            menu.DropDownItems.Add("Nieuw", null, this.nieuw);
            menu.DropDownItems.Add("Open Afbeelding", null, this.openAfbeelding);
            menu.DropDownItems.Add("Open Schets", null, this.openSchets);
            menu.DropDownItems.Add("Exit", null, this.afsluiten);
            menuStrip.Items.Add(menu);
        }
        private void maakHelpMenu()
        {   ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("Help");
            menu.DropDownItems.Add("Over \"Schets\"", null, this.about);
            menuStrip.Items.Add(menu);
        }
        private void about(object o, EventArgs ea)
        {   MessageBox.Show("Schets versie 1.0\n(c) UU Informatica 2010"
                           , "Over \"Schets\""
                           , MessageBoxButtons.OK
                           , MessageBoxIcon.Information
                           );
        }

        private void nieuw(object sender, EventArgs e)
        {   SchetsWin s = new SchetsWin();
            s.MdiParent = this;
            s.Show();
        }
        private void afsluiten(object sender, EventArgs e)
        {   this.Close();
        }

        // Openen Toegevoegd

        private void openAfbeelding(object sender, EventArgs e)

        {
            OpenFileDialog dialoog = new OpenFileDialog();
            dialoog.Title = "AFbeelding openen";
            dialoog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";

                if (dialoog.ShowDialog() == DialogResult.OK)
                {

                    SchetsWin s = new SchetsWin();
                    s.MdiParent = this;
                    Bitmap bit = new Bitmap(dialoog.FileName);
                    s.schetscontrol.nieuweBitmap(bit); ;
                    s.Show();
                }

        }

        private void openSchets(object sender, EventArgs e)
        {
            OpenFileDialog dialoog = new OpenFileDialog();
            dialoog.Title = "AFbeelding openen";
            dialoog.Filter = "Tekstfiles|*.txt|Alle files|*.*";
            if (dialoog.ShowDialog() == DialogResult.OK)
            {
                SchetsWin s = new SchetsWin();
                s.MdiParent = this;
                
                s.Show();

            }
        }

    }
}
