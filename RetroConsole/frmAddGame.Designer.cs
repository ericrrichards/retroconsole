namespace RetroConsole {
    partial class FrmAddGame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlatform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRomPath = new System.Windows.Forms.TextBox();
            this.btnPickRom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnGetMetaData = new System.Windows.Forms.Button();
            this.btnSelectBannerImg = new System.Windows.Forms.Button();
            this.txtReleaseDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOverview = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudRating = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofdAddGame = new System.Windows.Forms.OpenFileDialog();
            this.ofdSelectBannerImg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRating)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(12, 12);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(165, 198);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Platform:";
            // 
            // cbPlatform
            // 
            this.cbPlatform.DisplayMember = "Item1";
            this.cbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlatform.FormattingEnabled = true;
            this.cbPlatform.Location = new System.Drawing.Point(244, 9);
            this.cbPlatform.Name = "cbPlatform";
            this.cbPlatform.Size = new System.Drawing.Size(196, 21);
            this.cbPlatform.TabIndex = 2;
            this.cbPlatform.ValueMember = "Item2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rom:";
            // 
            // txtRomPath
            // 
            this.txtRomPath.Location = new System.Drawing.Point(244, 36);
            this.txtRomPath.Name = "txtRomPath";
            this.txtRomPath.ReadOnly = true;
            this.txtRomPath.Size = new System.Drawing.Size(196, 20);
            this.txtRomPath.TabIndex = 4;
            // 
            // btnPickRom
            // 
            this.btnPickRom.Location = new System.Drawing.Point(446, 34);
            this.btnPickRom.Name = "btnPickRom";
            this.btnPickRom.Size = new System.Drawing.Size(85, 23);
            this.btnPickRom.TabIndex = 5;
            this.btnPickRom.Text = "Pick Rom...";
            this.btnPickRom.UseVisualStyleBackColor = true;
            this.btnPickRom.Click += new System.EventHandler(this.btnPickRom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(244, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 7;
            // 
            // btnGetMetaData
            // 
            this.btnGetMetaData.Location = new System.Drawing.Point(446, 61);
            this.btnGetMetaData.Name = "btnGetMetaData";
            this.btnGetMetaData.Size = new System.Drawing.Size(85, 23);
            this.btnGetMetaData.TabIndex = 8;
            this.btnGetMetaData.Text = "Get Metadata";
            this.btnGetMetaData.UseVisualStyleBackColor = true;
            this.btnGetMetaData.Click += new System.EventHandler(this.btnGetMetaData_Click);
            // 
            // btnSelectBannerImg
            // 
            this.btnSelectBannerImg.Location = new System.Drawing.Point(13, 217);
            this.btnSelectBannerImg.Name = "btnSelectBannerImg";
            this.btnSelectBannerImg.Size = new System.Drawing.Size(164, 23);
            this.btnSelectBannerImg.TabIndex = 9;
            this.btnSelectBannerImg.Text = "Select Banner Image...";
            this.btnSelectBannerImg.UseVisualStyleBackColor = true;
            // 
            // txtReleaseDate
            // 
            this.txtReleaseDate.Location = new System.Drawing.Point(244, 90);
            this.txtReleaseDate.Name = "txtReleaseDate";
            this.txtReleaseDate.Size = new System.Drawing.Size(196, 20);
            this.txtReleaseDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Released:";
            // 
            // txtOverview
            // 
            this.txtOverview.Location = new System.Drawing.Point(13, 246);
            this.txtOverview.Multiline = true;
            this.txtOverview.Name = "txtOverview";
            this.txtOverview.Size = new System.Drawing.Size(427, 124);
            this.txtOverview.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Genre:";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(244, 116);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(196, 20);
            this.txtGenre.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Developer:";
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.Location = new System.Drawing.Point(244, 142);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(196, 20);
            this.txtDeveloper.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Publisher:";
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(244, 168);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(196, 20);
            this.txtPublisher.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Rating:";
            // 
            // nudRating
            // 
            this.nudRating.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRating.Location = new System.Drawing.Point(244, 197);
            this.nudRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRating.Name = "nudRating";
            this.nudRating.Size = new System.Drawing.Size(196, 20);
            this.nudRating.TabIndex = 22;
            this.nudRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Overview:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(446, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(446, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofdAddGame
            // 
            this.ofdAddGame.InitialDirectory = "Roms";
            this.ofdAddGame.Title = "Pick Rom";
            // 
            // ofdSelectBannerImg
            // 
            this.ofdSelectBannerImg.FileName = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.ofdSelectBannerImg.Title = "Select Banner Image";
            // 
            // FrmAddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudRating);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDeveloper);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOverview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReleaseDate);
            this.Controls.Add(this.btnSelectBannerImg);
            this.Controls.Add(this.btnGetMetaData);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPickRom);
            this.Controls.Add(this.txtRomPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPlatform);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlatform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRomPath;
        private System.Windows.Forms.Button btnPickRom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnGetMetaData;
        private System.Windows.Forms.Button btnSelectBannerImg;
        private System.Windows.Forms.TextBox txtReleaseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOverview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeveloper;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudRating;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog ofdAddGame;
        private System.Windows.Forms.OpenFileDialog ofdSelectBannerImg;
    }
}