using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RetroConsole {
    public partial class Form1 : Form {
        public List<Game> Games { get; set; }
        public Form1() {
            InitializeComponent();

            if (!Directory.Exists("Roms")) {
                Directory.CreateDirectory("Roms");
            }
            GetGameList();
        }

        private void GetGameList() {
            using (var db = GetContext()) {
                Games = db.Games.ToList();
            }
            flowLayoutPanel1.Controls.Clear();
            foreach (var game in Games) {
                var g = new PictureBox() {
                    Image = Image.FromStream(new MemoryStream(game.Banner.ToArray())),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = game,
                    Size = new Size(ClientSize.Width / 4, ClientSize.Width / 4)
                };
                g.Click += GameOnClick;
                flowLayoutPanel1.Controls.Add(g);
            }
        }

        private void GameOnClick(object sender, EventArgs e) {
            Game game = (Game) ((PictureBox) sender).Tag ;

            var emulatorPath = Path.Combine(Directory.GetCurrentDirectory(),game.Platform.EmulatorPath);

            var romPath = string.Format("\"{0}\"", Path.Combine(Directory.GetCurrentDirectory(),game.RomPath));
            var proc = new Process() {
                
            };
            proc.StartInfo  = GetProcStart( game.Platform, emulatorPath, romPath);
            
            proc.Start();
        }

        private ProcessStartInfo GetProcStart(Platform platform, string emulatorPath, string romPath) {
            switch (platform.Name) {
                case "Sega Genesis":
                    return new ProcessStartInfo(emulatorPath, romPath);
                default:
                    return new ProcessStartInfo(emulatorPath,  romPath);
            }
        }

        private GameDBDataContext GetContext() {
            var db = new GameDBDataContext() { DeferredLoadingEnabled = false };
            var ds = new DataLoadOptions();
            ds.LoadWith<Game>(g => g.Genre);
            ds.LoadWith<Game>(g => g.Developer);
            ds.LoadWith<Game>(g => g.Publisher);
            ds.LoadWith<Game>(g => g.Platform);

            db.LoadOptions = ds;
            return db;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var addGameForm = new frmAddGame();
            if (addGameForm.ShowDialog() == DialogResult.OK) {
                GetGameList();
            }
        }
    }
}
