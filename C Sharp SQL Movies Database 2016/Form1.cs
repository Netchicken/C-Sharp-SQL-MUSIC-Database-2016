using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SQL_Movies_Database_2016 {
    public partial class Form1 : Form {
        //create an instance of the Database class
        Database myDatabase = new Database();
        
        public Form1() {
            InitializeComponent();
            loadDB();
        }
        
    public void loadDB() {
            //just to show the listbox with the genres in it
            DisplayListBox();
            //load the owner dgv
            DisplayDataGridViewOwner();
            //fill the combo box as an example
            comboboxfill();
            }


        //LOAD THE OWNER DATAGRID
        private void DisplayDataGridViewOwner() {
            //clear out the old data
            DGVOwner.DataSource = null;
            try {
                DGVOwner.DataSource = myDatabase.FillDGVOwnerWithOwner();
                //pass the datatable data to the DataGridView
                DGVOwner.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                }
            }

        //CLICK EVENT FOR THE OWNER CELL
        private void DGVOwner_CellContentClick(System.Object sender,
            System.Windows.Forms.DataGridViewCellEventArgs e) {
            string OwnerFN = null;
            string OwnerLN = null;
            int OwnerID = 0;
            //these are the cell clicks for the values in the row that you click on
            try {
                OwnerID = (int)DGVOwner.Rows[e.RowIndex].Cells[0].Value;
                OwnerFN = DGVOwner.Rows[e.RowIndex].Cells[1].Value.ToString();
                OwnerLN = DGVOwner.Rows[e.RowIndex].Cells[2].Value.ToString();
                //if you are clicking on a row and not outside it
                if (e.RowIndex >= 0) {
                    //Fill the next CD DGV with the OwnerID
                    DGVCD.DataSource = myDatabase.FillDGVCDWithOwnerClick(OwnerID.ToString());
                    DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    txtFN.Text = OwnerFN;
                    //show it in the text box at the bottom
                    txtLN.Text = OwnerLN;
                    TxtOwnerID.Text = OwnerID.ToString();
                    //   Me.Text = OwnerID 'check to see that its working
                    }

                } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                }
            }

        //ADD NEW OWNER
        private void btnAddOwner_Click(System.Object sender, System.EventArgs e) {
            string result = null;
            //hold the success or failure result
            //only run if there is something in the textboxes
            if ((!object.ReferenceEquals(txtFN.Text, string.Empty)) &&
                (!object.ReferenceEquals(txtLN.Text, string.Empty))) {
                try {
                    result = myDatabase.AddOrUpdateOwner(txtFN.Text, txtLN.Text, TxtOwnerID.Text, "Add");
                    MessageBox.Show(txtFN.Text + " " + txtLN.Text + " Updating " + result);
                    } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    }
                //update the datagrid view to see new entries
                DisplayDataGridViewOwner();
                txtFN.Text = "";
                txtLN.Text = "";
                } else {
                MessageBox.Show("Fill all the fields");
                }
            }


        //CLICK EVENT FOR THE CD 

        private void DGVCD_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            string CDID = null;
            string CDname = null;
            string CDGenre = null;
            string CDartist = null;
            //name, artist, genre cdid
            try {
                CDID = DGVCD.Rows[e.RowIndex].Cells[3].Value.ToString();
                //CDID
                CDname = DGVCD.Rows[e.RowIndex].Cells[0].Value.ToString();
                CDGenre = DGVCD.Rows[e.RowIndex].Cells[2].Value.ToString();
                CDartist = DGVCD.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (e.RowIndex >= 0) {
                    //  DisplayDataGridViewTracks(CDID)
                    DGVtracks.DataSource = myDatabase.FillDGVTracksWithCDClick(CDID);
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    txtCDName.Text = CDname.Trim();
                    txtCDArtist.Text = CDartist;
                    txtCDGenre.Text = CDGenre;
                    txtCDID.Text = CDID;
                    }
                } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                }
            }

        //CLICK EVENT FOR TRACKS 
        private void DGVtracks_CellContentClick(System.Object sender,
            System.Windows.Forms.DataGridViewCellEventArgs e) {
            string Trackname = null;
            string trackduration = null;
            string trackID = null;
            string CDTrackID = null;

            try {
                Trackname = DGVtracks.Rows[e.RowIndex].Cells[0].Value.ToString();
                trackduration = DGVtracks.Rows[e.RowIndex].Cells[1].Value.ToString();
                trackID = DGVtracks.Rows[e.RowIndex].Cells[2].Value.ToString();
                CDTrackID = DGVtracks.Rows[e.RowIndex].Cells[3].Value.ToString();
                txttrackname.Text = Trackname;
                txtduration.Text = trackduration;
                txtTrackID.Text = trackID;
                txtCDtrackID.Text = CDTrackID;
                } catch {
                }

            }

        //CLEAR ALL TRACKS BEFORE ENTERING NEW DATA
        private void BtnClear_Click(System.Object sender, System.EventArgs e) {
            ClearAllTextBoxes(this);
            }

        //Clears all textboxes

        public void ClearAllTextBoxes(Control root) {
            foreach (Control ctrl in root.Controls) {
                if (ctrl is TextBox) {
                    ((TextBox)ctrl).Text = string.Empty;
                    }
                }
            }


        //DELETE ALL 
        private void btnDelete_Click(System.Object sender, System.EventArgs e) {
            string InputID = string.Empty;
            //hold the ID of the owner, CD, or Track
            string result = null;
            Button fakebutton = null;
            fakebutton = (Button)sender;
            try {
                switch (fakebutton.Name) {
                    case "btnDeleteOwner":
                        InputID = TxtOwnerID.Text;
                        DisplayDataGridViewOwner();
                        //refresh the DGV
                        DGVOwner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        //when you delete the owner you want to delete all the CDs and the tracks as well
                        //if you set the delete rule in the relationships property to cascade down then all the CDs and tracks are automatically deleted, so you need to refresh their DGV's
                        DGVCD.DataSource = myDatabase.FillDGVCDWithOwnerClick("0");
                        //refresh the DGV with empty
                        DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        DGVtracks.DataSource = myDatabase.FillDGVTracksWithCDClick("0");
                        //refresh the DGV with empty
                        DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                        break;

                    case "btnDeleteCD":
                        InputID = txtCDID.Text;
                        DGVCD.DataSource = myDatabase.FillDGVCDWithOwnerClick(txtCDID.Text);
                        //refresh the DGV
                        DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        break;
                    case "btnDeleteTracks":
                        InputID = txtTrackID.Text;
                        DGVtracks.DataSource = myDatabase.FillDGVTracksWithCDClick(txtCDtrackID.Text);
                        //refresh the DGV
                        DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        break;
                    }
                //delete the track here and return back success or failure
                result = myDatabase.DeleteOwnerCDTracks(InputID, fakebutton.Tag.ToString());
                MessageBox.Show(fakebutton.Tag + " delete " + result);
                //clear all the textboxes afterwards
                ClearAllTextBoxes(this);
                } catch (Exception ex) {
                MessageBox.Show("First click on the Owner, CD, or Track you want to delete " + ex.Message);
                }
            }

        //ADD CD
        private void btnAddCD_Click(object sender, EventArgs e) {
            //only run if there is something in the textboxes
            if (!object.ReferenceEquals(txtCDName.Text, string.Empty) &&
                !object.ReferenceEquals(txtCDArtist.Text, string.Empty) &&
                (!object.ReferenceEquals(txtCDGenre.Text, string.Empty))) {
                string result = null;

                try {
                    result = myDatabase.AddOrUpdateCD(TxtOwnerID.Text, txtCDName.Text, txtCDArtist.Text,
                        txtCDGenre.Text, txtCDID.Text, "Add");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txtCDName.Text + " Adding " + result);
                    DGVCD.DataSource = myDatabase.FillDGVCDWithOwnerClick(TxtOwnerID.Text);
                    //refresh the DGV
                    DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    }

                } else {
                MessageBox.Show("Fill all the fields");
                }
            }

        //ADD TRACKS
        private void btnaddTracks_Click(object sender, EventArgs e) {
            //only run if there is something in the textboxes And
            if (!object.ReferenceEquals(txttrackname.Text, string.Empty) &&
                !object.ReferenceEquals(txtduration.Text, string.Empty) &&
                !object.ReferenceEquals(txtCDtrackID.Text, string.Empty)) {
                string result = null;

                try {
                    result = myDatabase.AddOrUpdateCDTrack(txtCDID.Text, txtCDtrackID.Text, txttrackname.Text,
                        txtduration.Text, txtTrackID.Text, "Add");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txttrackname.Text + " Adding " + result);
                    DGVtracks.DataSource = myDatabase.FillDGVTracksWithCDClick(txtCDID.Text);
                    //refresh the DGV
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    }

                } else {
                MessageBox.Show("Fill all the fields");
                }
            }

        //UPDATE ALL

        private void btnUpdate_Click(object sender, EventArgs e) {
            //Update the Owner

            //only run if there is something in the textboxes
            if ((!object.ReferenceEquals(txtFN.Text, string.Empty)) &&
                (!object.ReferenceEquals(txtLN.Text, string.Empty)) &&
                !object.ReferenceEquals(TxtOwnerID.Text, string.Empty)) {
                string result = null;
                try {
                    result = myDatabase.AddOrUpdateOwner(txtFN.Text, txtLN.Text, TxtOwnerID.Text, "Update");
                    MessageBox.Show(txtFN.Text + " " + txtLN.Text + " Updating " + result);
                    //update the datagrid view to see new entries 
                    DisplayDataGridViewOwner();
                    DGVOwner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    } catch (Exception ex) {
                    MessageBox.Show("Owner not Updated" + ex.Message);
                    }

                } else {
                //   MsgBox("Fill all the fields")
                }

            //Update the CD
            //only run if there is something in the textboxes
            if (!object.ReferenceEquals(txtCDName.Text, string.Empty) &&
                !object.ReferenceEquals(txtCDArtist.Text, string.Empty) &&
                (!object.ReferenceEquals(txtCDGenre.Text, string.Empty)) &&
                !object.ReferenceEquals(txtCDID.Text, string.Empty)) {
                string result = null;
                try {
                    result = myDatabase.AddOrUpdateCD(TxtOwnerID.Text, txtCDName.Text, txtCDArtist.Text,
                        txtCDGenre.Text, txtCDID.Text, "Update");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txtCDName.Text + " Updating " + result);
                    DGVCD.DataSource = myDatabase.FillDGVCDWithOwnerClick(TxtOwnerID.Text);
                    //refresh the DGV
                    DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    } catch (Exception ex) {
                    MessageBox.Show("CD not Updated" + ex.Message);
                    }

                } else {
                //  MsgBox("Fill all the fields")
                }

            //Update the Tracks
            //only run if there is something in the textboxes And
            if (!object.ReferenceEquals(txttrackname.Text, string.Empty) &&
                !object.ReferenceEquals(txtduration.Text, string.Empty) &&
                !object.ReferenceEquals(txtCDtrackID.Text, string.Empty) &&
                !object.ReferenceEquals(txtTrackID.Text, string.Empty)) {
                string result = null;
                try {
                    result = myDatabase.AddOrUpdateCDTrack(txtCDID.Text, txtCDtrackID.Text, txttrackname.Text,
                        txtduration.Text, txtTrackID.Text, "Update");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txttrackname.Text + " Updating " + result);
                    DGVtracks.DataSource = myDatabase.FillDGVTracksWithCDClick(txtCDID.Text);
                    //refresh the DGV
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    } catch (Exception ex) {
                    MessageBox.Show("Track not Updated" + ex.Message);
                    }

                } else {
                //   MsgBox("Fill all the fields")
                }


            }


        #region "Stuff not important"

        private void lbgenre_SelectedIndexChanged(System.Object sender, System.EventArgs e) {
            TextBox2.Text = lbgenre.SelectedIndex.ToString();
            }

        private void DisplayListBox() {
            //clear old data out
            DGVCD.DataSource = null;
            lbgenre.DataSource = null;
            try {
                lbgenre.DataSource = myDatabase.FillListBoxWithGenre();
                lbgenre.DisplayMember = "Genre";

                } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                }
            }


        public void comboboxfill() {
            var _with1 = ComboBox1;
            //Bind the DataTable to the ComboBox by setting the Combobox's DataSource property to the DataTable. 
            _with1.DataSource = myDatabase.FillComboBoxWithName();
            //To display the "Description" column in the Combobox's list, set the Combobox's DisplayMember property to the name of column. 
            _with1.DisplayMember = "Firstname";
            //& "LastName"
            //Likewise, to use the "Code" column as the value of an item in the Combobox set the ValueMember property. 
            _with1.ValueMember = "OwnerID";
            _with1.SelectedIndex = 0;
            }

        private void ComboBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e) {
            //pass the number to the textbox
            TextBox1.Text = (ComboBox1.SelectedIndex + 1).ToString();
            if (ComboBox1.SelectedIndex != -1) {
                // FillWithOwnerCD()
                }
            }

        private void TextBox1_TextChanged(System.Object sender, System.EventArgs e) {
            // FillWithOwnerCD()
            }

        #endregion





        private void DGVOwner_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {
            }

        private void button1_Click(object sender, EventArgs e) {

            }
        }
    }

