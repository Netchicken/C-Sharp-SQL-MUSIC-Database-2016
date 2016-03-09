namespace C_Sharp_SQL_Movies_Database_2016 {
    partial class Form1 {
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
            this.Label5 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTrackID = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtCDID = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.TxtOwnerID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnDeleteTracks = new System.Windows.Forms.Button();
            this.btnDeleteCD = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCDtrackID = new System.Windows.Forms.TextBox();
            this.txtduration = new System.Windows.Forms.TextBox();
            this.txttrackname = new System.Windows.Forms.TextBox();
            this.btnaddTracks = new System.Windows.Forms.Button();
            this.txtCDGenre = new System.Windows.Forms.TextBox();
            this.txtCDArtist = new System.Windows.Forms.TextBox();
            this.txtCDName = new System.Windows.Forms.TextBox();
            this.btnAddCD = new System.Windows.Forms.Button();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Owners = new System.Windows.Forms.Label();
            this.DGVOwner = new System.Windows.Forms.DataGridView();
            this.DGVtracks = new System.Windows.Forms.DataGridView();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.lbgenre = new System.Windows.Forms.ListBox();
            this.DGVCD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVtracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCD)).BeginInit();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(983, 480);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 17);
            this.Label5.TabIndex = 68;
            this.Label5.Text = "ID Fields";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(131, 518);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(68, 17);
            this.Label9.TabIndex = 72;
            this.Label9.Text = "CD Name";
            // 
            // txtTrackID
            // 
            this.txtTrackID.Location = new System.Drawing.Point(986, 568);
            this.txtTrackID.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrackID.Name = "txtTrackID";
            this.txtTrackID.Size = new System.Drawing.Size(55, 22);
            this.txtTrackID.TabIndex = 65;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(424, 515);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 17);
            this.Label8.TabIndex = 71;
            this.Label8.Text = "Artist";
            // 
            // txtCDID
            // 
            this.txtCDID.Location = new System.Drawing.Point(986, 534);
            this.txtCDID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCDID.Name = "txtCDID";
            this.txtCDID.Size = new System.Drawing.Size(55, 22);
            this.txtCDID.TabIndex = 55;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(574, 515);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(48, 17);
            this.Label7.TabIndex = 70;
            this.Label7.Text = "Genre";
            // 
            // TxtOwnerID
            // 
            this.TxtOwnerID.Location = new System.Drawing.Point(986, 501);
            this.TxtOwnerID.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOwnerID.Name = "TxtOwnerID";
            this.TxtOwnerID.Size = new System.Drawing.Size(55, 22);
            this.TxtOwnerID.TabIndex = 50;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(424, 562);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(102, 17);
            this.Label6.TabIndex = 69;
            this.Label6.Text = "Track Duration";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(574, 562);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(116, 17);
            this.Label4.TabIndex = 67;
            this.Label4.Text = "Track CDTrackID";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(134, 562);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(85, 17);
            this.Label3.TabIndex = 66;
            this.Label3.Text = "Track Name";
            // 
            // btnDeleteTracks
            // 
            this.btnDeleteTracks.Location = new System.Drawing.Point(841, 565);
            this.btnDeleteTracks.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTracks.Name = "btnDeleteTracks";
            this.btnDeleteTracks.Size = new System.Drawing.Size(120, 28);
            this.btnDeleteTracks.TabIndex = 64;
            this.btnDeleteTracks.Tag = "Track";
            this.btnDeleteTracks.Text = "Delete Track";
            this.btnDeleteTracks.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCD
            // 
            this.btnDeleteCD.Location = new System.Drawing.Point(841, 529);
            this.btnDeleteCD.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteCD.Name = "btnDeleteCD";
            this.btnDeleteCD.Size = new System.Drawing.Size(120, 28);
            this.btnDeleteCD.TabIndex = 63;
            this.btnDeleteCD.Tag = "CD";
            this.btnDeleteCD.Text = "Delete CD";
            this.btnDeleteCD.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.Location = new System.Drawing.Point(841, 493);
            this.btnDeleteOwner.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Size = new System.Drawing.Size(120, 28);
            this.btnDeleteOwner.TabIndex = 62;
            this.btnDeleteOwner.Tag = "Owner";
            this.btnDeleteOwner.Text = "Delete Owner";
            this.btnDeleteOwner.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(24, 463);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(99, 26);
            this.BtnClear.TabIndex = 61;
            this.BtnClear.Text = "Clear All";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(132, 463);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 60;
            this.btnUpdate.Text = "Update All";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtCDtrackID
            // 
            this.txtCDtrackID.Location = new System.Drawing.Point(577, 579);
            this.txtCDtrackID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCDtrackID.Name = "txtCDtrackID";
            this.txtCDtrackID.Size = new System.Drawing.Size(99, 22);
            this.txtCDtrackID.TabIndex = 59;
            // 
            // txtduration
            // 
            this.txtduration.Location = new System.Drawing.Point(426, 580);
            this.txtduration.Margin = new System.Windows.Forms.Padding(4);
            this.txtduration.Name = "txtduration";
            this.txtduration.Size = new System.Drawing.Size(132, 22);
            this.txtduration.TabIndex = 58;
            // 
            // txttrackname
            // 
            this.txttrackname.Location = new System.Drawing.Point(135, 580);
            this.txttrackname.Margin = new System.Windows.Forms.Padding(4);
            this.txttrackname.Name = "txttrackname";
            this.txttrackname.Size = new System.Drawing.Size(273, 22);
            this.txttrackname.TabIndex = 57;
            // 
            // btnaddTracks
            // 
            this.btnaddTracks.Location = new System.Drawing.Point(27, 577);
            this.btnaddTracks.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddTracks.Name = "btnaddTracks";
            this.btnaddTracks.Size = new System.Drawing.Size(100, 28);
            this.btnaddTracks.TabIndex = 56;
            this.btnaddTracks.Text = "Add Tracks";
            this.btnaddTracks.UseVisualStyleBackColor = true;
            // 
            // txtCDGenre
            // 
            this.txtCDGenre.Location = new System.Drawing.Point(577, 536);
            this.txtCDGenre.Margin = new System.Windows.Forms.Padding(4);
            this.txtCDGenre.Name = "txtCDGenre";
            this.txtCDGenre.Size = new System.Drawing.Size(132, 22);
            this.txtCDGenre.TabIndex = 54;
            // 
            // txtCDArtist
            // 
            this.txtCDArtist.Location = new System.Drawing.Point(427, 536);
            this.txtCDArtist.Margin = new System.Windows.Forms.Padding(4);
            this.txtCDArtist.Name = "txtCDArtist";
            this.txtCDArtist.Size = new System.Drawing.Size(132, 22);
            this.txtCDArtist.TabIndex = 53;
            // 
            // txtCDName
            // 
            this.txtCDName.Location = new System.Drawing.Point(135, 536);
            this.txtCDName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCDName.Multiline = true;
            this.txtCDName.Name = "txtCDName";
            this.txtCDName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCDName.Size = new System.Drawing.Size(273, 22);
            this.txtCDName.TabIndex = 52;
            // 
            // btnAddCD
            // 
            this.btnAddCD.Location = new System.Drawing.Point(27, 533);
            this.btnAddCD.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCD.Name = "btnAddCD";
            this.btnAddCD.Size = new System.Drawing.Size(100, 28);
            this.btnAddCD.TabIndex = 51;
            this.btnAddCD.Text = "Add CD";
            this.btnAddCD.UseVisualStyleBackColor = true;
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(273, 492);
            this.txtLN.Margin = new System.Windows.Forms.Padding(4);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(132, 22);
            this.txtLN.TabIndex = 49;
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(132, 492);
            this.txtFN.Margin = new System.Windows.Forms.Padding(4);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(132, 22);
            this.txtFN.TabIndex = 48;
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Location = new System.Drawing.Point(24, 489);
            this.btnAddOwner.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(100, 28);
            this.btnAddOwner.TabIndex = 47;
            this.btnAddOwner.Text = "Add Owner";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label2.Location = new System.Drawing.Point(644, 101);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(78, 25);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "Tracks";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label1.Location = new System.Drawing.Point(83, 278);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 25);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "CD\'s";
            // 
            // Owners
            // 
            this.Owners.AutoSize = true;
            this.Owners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Owners.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Owners.Location = new System.Drawing.Point(95, 97);
            this.Owners.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Owners.Name = "Owners";
            this.Owners.Size = new System.Drawing.Size(86, 25);
            this.Owners.TabIndex = 44;
            this.Owners.Text = "Owners";
            // 
            // DGVOwner
            // 
            this.DGVOwner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOwner.Location = new System.Drawing.Point(64, 126);
            this.DGVOwner.Margin = new System.Windows.Forms.Padding(4);
            this.DGVOwner.Name = "DGVOwner";
            this.DGVOwner.Size = new System.Drawing.Size(492, 153);
            this.DGVOwner.TabIndex = 43;
            // 
            // DGVtracks
            // 
            this.DGVtracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVtracks.Location = new System.Drawing.Point(581, 129);
            this.DGVtracks.Margin = new System.Windows.Forms.Padding(4);
            this.DGVtracks.Name = "DGVtracks";
            this.DGVtracks.Size = new System.Drawing.Size(415, 327);
            this.DGVtracks.TabIndex = 42;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(1148, 169);
            this.TextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(100, 22);
            this.TextBox2.TabIndex = 41;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(1145, 129);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 22);
            this.TextBox1.TabIndex = 40;
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(1004, 255);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(124, 24);
            this.ComboBox1.TabIndex = 39;
            // 
            // lbgenre
            // 
            this.lbgenre.FormattingEnabled = true;
            this.lbgenre.ItemHeight = 16;
            this.lbgenre.Location = new System.Drawing.Point(1004, 129);
            this.lbgenre.Margin = new System.Windows.Forms.Padding(4);
            this.lbgenre.Name = "lbgenre";
            this.lbgenre.Size = new System.Drawing.Size(135, 100);
            this.lbgenre.TabIndex = 38;
            // 
            // DGVCD
            // 
            this.DGVCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCD.Location = new System.Drawing.Point(64, 307);
            this.DGVCD.Margin = new System.Windows.Forms.Padding(4);
            this.DGVCD.Name = "DGVCD";
            this.DGVCD.Size = new System.Drawing.Size(497, 149);
            this.DGVCD.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 702);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtTrackID);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtCDID);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.TxtOwnerID);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnDeleteTracks);
            this.Controls.Add(this.btnDeleteCD);
            this.Controls.Add(this.btnDeleteOwner);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCDtrackID);
            this.Controls.Add(this.txtduration);
            this.Controls.Add(this.txttrackname);
            this.Controls.Add(this.btnaddTracks);
            this.Controls.Add(this.txtCDGenre);
            this.Controls.Add(this.txtCDArtist);
            this.Controls.Add(this.txtCDName);
            this.Controls.Add(this.btnAddCD);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.btnAddOwner);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Owners);
            this.Controls.Add(this.DGVOwner);
            this.Controls.Add(this.DGVtracks);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.lbgenre);
            this.Controls.Add(this.DGVCD);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGVOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVtracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        internal System.Windows.Forms.Button btnDeleteTracks;
        internal System.Windows.Forms.Button btnDeleteCD;
        internal System.Windows.Forms.Button btnDeleteOwner;
        internal System.Windows.Forms.Button BtnClear;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnaddTracks;
        internal System.Windows.Forms.Button btnAddCD;
        internal System.Windows.Forms.Button btnAddOwner;
        internal System.Windows.Forms.DataGridView DGVOwner;
        internal System.Windows.Forms.DataGridView DGVtracks;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.ListBox lbgenre;
        internal System.Windows.Forms.DataGridView DGVCD;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Owners;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtFN;
        internal System.Windows.Forms.TextBox txtLN;
        internal System.Windows.Forms.TextBox txtCDName;
        internal System.Windows.Forms.TextBox txtCDArtist;
        internal System.Windows.Forms.TextBox txtCDGenre;
        internal System.Windows.Forms.TextBox txttrackname;
        internal System.Windows.Forms.TextBox txtduration;
        internal System.Windows.Forms.TextBox txtCDtrackID;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox TxtOwnerID;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtCDID;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtTrackID;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label5;
        }
    }

