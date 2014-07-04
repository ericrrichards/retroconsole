using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RetroConsole {
    public partial class frmAddGame : Form {
        public frmAddGame() {
            InitializeComponent();
            var filter = "";
            using (var db = new GameDBDataContext()) {
                foreach (var platform in db.Platforms) {
                    cbPlatform.Items.Add(new Tuple<string, string, int>(platform.Name, platform.Name + "|" + platform.Filter, platform.Id));
                }
            }
            ofdAddGame.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Roms");
        }

        private void btnPickRom_Click(object sender, EventArgs e) {
            if (cbPlatform.SelectedItem == null) {
                return;
            }
            var selectedPlatform = (Tuple<string, string, int>)cbPlatform.SelectedItem;
            ofdAddGame.Filter = selectedPlatform.Item2;
            if (ofdAddGame.ShowDialog() == DialogResult.OK) {
                txtRomPath.Text = ofdAddGame.FileName;

                txtName.Text = Path.GetFileNameWithoutExtension(ofdAddGame.FileName);
            }



        }

        private void btnGetMetaData_Click(object sender, EventArgs e) {
            var name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name)) {
                return;
            }
            if (cbPlatform.SelectedItem == null) {
                return;
            }
            var platform = ((Tuple<string, string, int>)(cbPlatform.SelectedItem)).Item1;
            var metadata = GetMetaData(name, platform);

            pbBanner.Image = metadata.Banner;
            txtReleaseDate.Text = metadata.ReleaseDate;
            txtGenre.Text = metadata.Genre;
            txtDeveloper.Text = metadata.Developer;
            txtPublisher.Text = metadata.Publisher;
            nudRating.Value = (decimal) metadata.Rating;
            txtOverview.Text = metadata.Overview;
        }

        private GameMetaData GetMetaData(string name, string platform) {

            var apiPath = new Uri("http://thegamesdb.net/api/GetGame.php?name=" + name);
            using (var wc = new WebClient()) {
                var data = wc.DownloadString(apiPath);

                var gameList = GetGameList(data);

                string id;
                if (gameList.ContainsKey(name)) {
                    id = gameList[name];
                } else {
                    var pickForm = new PickGame(gameList);
                    if (pickForm.ShowDialog() == DialogResult.OK) {

                        id = pickForm.Selection.Value;
                    } else {
                        return null;
                    }
                }

                var game = GetMetaData(id);
                return game;
            }
        }

        private GameMetaData GetMetaData(string id) {
            var apiPath = new Uri("http://thegamesdb.net/api/GetGame.php?id=" + id);
            using (var wc = new WebClient()) {
                var data = wc.DownloadString(apiPath);
                var game = ExtractMetadata(data);
                return game;
            }

        }

        private Dictionary<string, string> GetGameList(string xml) {
            var doc = XDocument.Parse(xml);
            var ret = new Dictionary<string, string>();
            foreach (var game in doc.Descendants("Game")) {
                ret[game.Descendants("GameTitle").First().Value] = game.Descendants("id").First().Value;
            }
            return ret;
        }

        private GameMetaData ExtractMetadata(string xml) {
            var doc = XDocument.Parse(xml);

            var baseUrl = doc.Descendants("baseImgUrl").FirstOrDefault().Value;
            var game = doc.Descendants("Game").First();
            var data = new GameMetaData();
            data.Name = game.Descendants("GameTitle").First().Value;

            var releaseElem = game.Descendants("ReleaseDate").FirstOrDefault();
            if (releaseElem != null) data.ReleaseDate = releaseElem.Value;

            var overviewElem = game.Descendants("Overview").FirstOrDefault();
            if (overviewElem != null) data.Overview = overviewElem.Value;

            var developerElem = game.Descendants("Developer").FirstOrDefault();
            if (developerElem != null) data.Developer = developerElem.Value;

            var publisherElem = game.Descendants("Publisher").FirstOrDefault();
            if (publisherElem != null) data.Publisher = publisherElem.Value;

            var genreElem = game.Descendants("genre").FirstOrDefault();
            if (genreElem != null) data.Genre = genreElem.Value;

            var ratingElem = game.Descendants("Rating").FirstOrDefault();
            if (ratingElem != null) data.Rating = Convert.ToSingle(ratingElem.Value);

            var images = game.Descendants("Images").FirstOrDefault();
            if (images != null) {
                var boxArtElem = images.Descendants("boxart").FirstOrDefault(b => b.Attribute("side").Value == "front");
                if (boxArtElem != null) {
                    var boxFront = boxArtElem.Attribute("thumb").Value;
                    var bannerUrl = baseUrl + boxFront;

                    using (var wc = new WebClient()) {
                        var imgBytes = wc.DownloadData(bannerUrl);

                        var stream = new MemoryStream(imgBytes);
                        var img = Image.FromStream(stream);
                        data.Banner = img;
                    }
                }
            }
            return data;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            using (var db = new GameDBDataContext()) {
                if (!db.Genres.Any(g => g.Name == txtGenre.Text)) {
                    db.Genres.InsertOnSubmit(new Genre(){Name = txtGenre.Text});
                    db.SubmitChanges();
                }
                
                if (!db.PubDevs.Any(p => p.Name == txtDeveloper.Text)) {
                    db.PubDevs.InsertOnSubmit(new PubDev(){Name = txtDeveloper.Text});
                    db.SubmitChanges();
                }
                if (!db.PubDevs.Any(p => p.Name == txtPublisher.Text)) {
                    db.PubDevs.InsertOnSubmit(new PubDev() { Name = txtPublisher.Text });
                    db.SubmitChanges();
                }

                var ms = new MemoryStream();
                pbBanner.Image.Save(ms, ImageFormat.Png);

                db.Games.InsertOnSubmit(new Game() {
                                                       Banner = ms.ToArray(),
                                                       Developer = db.PubDevs.First(d=>d.Name==txtDeveloper.Text),
                                                       Publisher = db.PubDevs.First(d => d.Name == txtPublisher.Text),
                                                       Genre = db.Genres.First(g=>g.Name == txtGenre.Text),
                                                       Name = txtName.Text,
                                                       Overview = txtOverview.Text,
                                                       PlatformID = ((Tuple<string, string, int>)cbPlatform.SelectedItem).Item3,
                                                       Rating = (double?) nudRating.Value,
                                                       ReleaseDate = Convert.ToDateTime(txtReleaseDate.Text),
                                                       RomPath = txtRomPath.Text
                                                   });
                db.SubmitChanges();

            }

        }
    }

    class GameMetaData {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public float Rating { get; set; }
        public Image Banner { get; set; }
    }
}
