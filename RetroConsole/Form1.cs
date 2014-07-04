using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RetroConsole {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            if (!Directory.Exists("Roms")) {
                Directory.CreateDirectory("Roms");
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var addGameForm = new frmAddGame();
            if (addGameForm.ShowDialog() == DialogResult.OK) {
                
            }
        }
    }
}
