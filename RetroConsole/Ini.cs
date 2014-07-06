using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RetroConsole {
    public class Ini {
        private readonly string _filname;
        private readonly List<string> _lines;
        private readonly Dictionary<string, int> _keyIndex = new Dictionary<string, int>(); 


        public Ini(string filename) {
            _filname = filename;
            _lines = File.ReadAllLines(filename).ToList();
            for (int i = 0; i < _lines.Count; i++) {
                var line = _lines[i];
                if (line.StartsWith(";") || string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                var keyVar = line.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                var key = keyVar[0];
                _keyIndex[key] = i;
            }
        }

        public void Save() {
            File.WriteAllLines(_filname, _lines);
        }

        public void Replace(string key, string value) {
            if (_keyIndex.ContainsKey(key)) {
                var line = _lines[_keyIndex[key]];
                var keyVar = line.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var val = keyVar[1];
                line = line.Replace(val, value);
                _lines[_keyIndex[key]] = line;
            }
        }
    }
}
