using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RetroConsole {
    // ReSharper disable once InconsistentNaming
    public class GameDB {
        private static GameDB _instance;
        private static readonly object SyncRoot = new object();

        public static GameDB Instance {
            get {
                if (_instance == null) {
                    lock (SyncRoot) {
                        if (_instance == null) {
                            _instance = new GameDB("gameDB.xml");
                        }
                    }
                }
                return _instance;
            }
        }


        private readonly List<Platform> _platforms;
        public IEnumerable<Platform> Platforms { get { return _platforms.AsReadOnly(); } }
        private readonly List<Game> _games;
        public IEnumerable<Game> Games { get { return _games.AsReadOnly(); } }

        private GameDB(XDocument doc) {
            _platforms = new List<Platform>();
            var platforms = doc.Descendants("Platform");
            foreach (var platform in platforms) {
                var p = Platform.FromXElement(platform);
                _platforms.Add(p);
            }
            _games = new List<Game>();
            var games = doc.Descendants("Game");
            foreach (var game in games) {
                var g = Game.FromXml(game, _platforms);
                _games.Add(g);
            }
        }

        private GameDB(string filename)
            : this(XDocument.Load(filename)) {
        }

        private void Save() {
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var root = new XElement("DB");
            var platforms = new XElement("Platforms");
            foreach (var platform in _platforms) {
                platforms.Add(platform.ToXElement());
            }
            root.Add(platforms);

            var games = new XElement("Games");
            foreach (var game in _games) {
                games.Add(game.ToXElement());
            }
            root.Add(games);
            doc.Add(root);
            doc.Save("gameDB.xml");
        }

        public void AddGame(Game g) {
            _games.Add(g);
            Save();
        }



    }

    public class Platform {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Filter { get; private set; }
        public string EmulatorPath { get; private set; }

        public static Platform FromXElement(XElement xml) {
            var p = new Platform {
                ID = Convert.ToInt32(xml.Element("ID").Value),
                Name = xml.Element("Name").Value,
                Filter = xml.Element("Filter").Value,
                EmulatorPath = xml.Element("EmulatorPath").Value
            };

            return p;
        }

        public XElement ToXElement() {
            var xml = new XElement("Platform",
                new XElement("ID", ID),
                new XElement("Name", Name),
                new XElement("Filter", Filter),
                new XElement("EmulatorPath", EmulatorPath)
            );
            return xml;
        }
    }

    public class Game {
        public string Name { private get; set; }
        public Platform Platform { get; set; }
        public string ReleaseDate { private get; set; }
        public string Overview { private get; set; }
        public string Genre { private get; set; }
        public string Publisher { private get; set; }
        public string Developer { private get; set; }
        public decimal Rating { private get; set; }
        public Image Banner { get; set; }
        public string RomPath { get; set; }

        public static Game FromXml(XElement game, IEnumerable<Platform> platforms) {
            var platformID = Convert.ToInt32(game.Element("PlatformID").Value);
            var bannerPath = game.Element("Banner").Value;
            var g = new Game {
                Name = game.Element("Name").Value,
                Platform = platforms.FirstOrDefault(p => p.ID == platformID),
                ReleaseDate = game.Element("ReleaseDate").Value,
                Overview = game.Element("Overview").Value,
                Genre = game.Element("Genre").Value,
                Publisher = game.Element("Publisher").Value,
                Developer = game.Element("Developer").Value,
                Rating = Convert.ToDecimal(game.Element("Rating").Value),
                Banner = Image.FromFile(bannerPath),
                RomPath = game.Element("RomPath").Value
            };

            return g;
        }
        public string BannerPath { get { return "Banners/" + Name + ".png"; } }
        public XElement ToXElement() {
            if (!File.Exists(BannerPath)) {
                Banner.Save(BannerPath);
            }
            var xml = new XElement("Game",
                new XElement("Name", Name),
                new XElement("PlatformID", Platform.ID),
                new XElement("ReleaseDate", ReleaseDate),
                new XElement("Overview", Overview),
                new XElement("Genre", Genre),
                new XElement("Publisher", Publisher),
                new XElement("Developer", Developer),
                new XElement("Rating", Rating),
                new XElement("Banner", BannerPath),
                new XElement("RomPath", RomPath)
            );

            return xml;
        }
    }
}
