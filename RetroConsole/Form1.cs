using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RetroConsole {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            menuStrip1.Renderer = new MyRenderer();

            if (!Directory.Exists("Roms")) {
                Directory.CreateDirectory("Roms");
            }
            if (!Directory.Exists("Banners")) {
                Directory.CreateDirectory("Banners");
            }

            SetupGenesisEmulator();


            GetGameList();
        }

        public class MyRenderer : ToolStripProfessionalRenderer {
            public MyRenderer() : base(new MyColors()) {
            }


            public class MyColors : ProfessionalColorTable {
                public override Color MenuItemSelected {
                    get { return Color.Blue; }
                }

                public override Color MenuItemSelectedGradientBegin {
                    get { return Color.Blue; }
                }
                public override Color MenuItemSelectedGradientEnd {
                    get { return Color.Blue; }
                }

                public override Color MenuStripGradientBegin {
                    get { return Color.Gray; }
                }

                public override Color MenuStripGradientEnd {
                    get { return Color.Gray; }
                }

                public override Color MenuItemBorder {
                    get { return Color.Gray; }
                }

                public override Color MenuBorder {
                    get { return Color.Gray; }
                }

                public override Color MenuItemPressedGradientBegin {
                    get { return Color.Blue; }
                }
                public override Color MenuItemPressedGradientEnd {
                    get { return Color.Blue; }
                }

                public override Color MenuItemPressedGradientMiddle {
                    get { return Color.Blue; }
                }
            }
        }

        private void SetupGenesisEmulator() {
            // Fusion doesn't support relative paths, so we need to patch up the
            // ini file with paths that match where we are currently running the emulator
            // from

            var genesisEmulatorPath = Path.Combine(Directory.GetCurrentDirectory(),"Emulators/Genesis");
            var ini = new Ini(Path.Combine(genesisEmulatorPath, "Fusion.ini"));

            ini.Replace("SxMFiles", genesisEmulatorPath);
            ini.Replace("SMSStateFiles", genesisEmulatorPath);
            ini.Replace("SMSPatchFiles", genesisEmulatorPath);
            ini.Replace("GGPatchFiles", genesisEmulatorPath);
            ini.Replace("SRMFiles", genesisEmulatorPath);
            ini.Replace("StateFiles", genesisEmulatorPath);
            ini.Replace("PatchFiles", genesisEmulatorPath);
            ini.Replace("SCDStateFiles", genesisEmulatorPath);
            ini.Replace("BRMFiles", genesisEmulatorPath);
            ini.Replace("ScreenShotPath", genesisEmulatorPath);

            ini.Save();
        }

        private void GetGameList() {
            flowLayoutPanel1.Controls.Clear();
            var width = Screen.PrimaryScreen.WorkingArea.Width;
            foreach (var game in GameDB.Instance.Games) {
                var g = new PictureBox {
                    Image = game.Banner,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = game,
                    Size = new Size(width / 4, width / 4)
                };
                g.Click += GameOnClick;
                flowLayoutPanel1.Controls.Add(g);
            }
        }

        private void GameOnClick(object sender, EventArgs e) {
            var game = (Game) ((PictureBox) sender).Tag ;

            var emulatorPath = Path.Combine(Directory.GetCurrentDirectory(),game.Platform.EmulatorPath);

            var romPath = string.Format("\"{0}\"", Path.Combine(Directory.GetCurrentDirectory(),game.RomPath));
            var proc = new Process {StartInfo = GetProcStart(game.Platform, emulatorPath, romPath)};

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


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var addGameForm = new FrmAddGame();
            if (addGameForm.ShowDialog() == DialogResult.OK) {
                GetGameList();
            }
        }
    }
}
