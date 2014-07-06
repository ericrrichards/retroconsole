using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RetroConsole {
    public partial class PickGame : Form {
        public KeyValuePair<string, string> Selection { get; private set; } 
        public PickGame(Dictionary<string, string> options ) {
            InitializeComponent();
            foreach (var option in options) {
                lbOptions.Items.Add(option);
            }
            
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            if (lbOptions.SelectedItem == null) {
                
            } else {
                Selection = (KeyValuePair<string, string>) lbOptions.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
