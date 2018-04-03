using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SQL_Movies_Database_2016
{
    public partial class Form1 : Form
    {
        //create an instance of the Database class
        Database myDatabase = new Database();

        public Form1()
        {
            InitializeComponent();
            loadDB();
        }

        public void loadDB()
        {
            //just to show the listbox with the genres in it
            DisplayListBox();
            //load the owner dgv
            DisplayDataGridViewOwner();
            //fill the combo box as an example
            comboboxfill();

        }


        //LOAD THE OWNER DATAGRID using the Owner Data Transfer Object
        private void DisplayDataGridViewOwner()
        {
            //clear out the old data
            DGVOwner.DataSource = null;
            try
            {
                DGVOwner.DataSource = myDatabase.FillAllDGVWithData("Owner", "0");
                //pass the datatable data to the DataGridView
                DGVOwner.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowonTitleBar(int Row, int Col)
        {
            // this.Text = "Row " + Row + " and Col " + Col;
            // this.Text =string.Format("Row "+ {1} +" and Col " + {2}:Row,Col);
            this.Text = $@"Row {Row} and show me the Col {Col}";

        }
        //CLICK EVENT FOR THE OWNER CELL
        private void DGVOwner_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            //clear the last data entry
            OwnerDTO.ClearData();
            OwnerDTO.Events = e;
            int OwnerID = 0;
            //these are the cell clicks for the values in the row that you click on
            try
            {
                //pass the datagridview data to the class
                OwnerDTO.OwnerDGV = DGVOwner;
                //extract out the data from the rows
                OwnerDTO.OwnerDGVExtract();
                ShowonTitleBar(e.RowIndex, e.ColumnIndex);
                //OwnerDTO.OwnerID = (int)DGVOwner.Rows[e.RowIndex].Cells[0].Value;
                //OwnerDTO.FirstName = DGVOwner.Rows[e.RowIndex].Cells[1].Value.ToString();
                //OwnerDTO.LastName = DGVOwner.Rows[e.RowIndex].Cells[2].Value.ToString();

                //pass the data to the textboxes
                txtFN.Text = OwnerDTO.FirstName;
                txtLN.Text = OwnerDTO.LastName;

                //if you are clicking on a row and not outside it
                if (e.RowIndex >= 0)
                {
                    //Fill the next CD DGV with the OwnerID
                    DGVCD.DataSource = myDatabase.FillAllDGVWithData("CD", OwnerDTO.OwnerID.ToString());

                    TxtOwnerID.Text = OwnerDTO.OwnerID.ToString();
                    //   Me.Text = OwnerID 'check to see that its working
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" I am very sorry you have an error " + ex.Message + "Don't do that again!   ");
            }
        }

        //ADD NEW OWNER
        private void btnAddOwner_Click(System.Object sender, System.EventArgs e)
        {
            string result = null;
            //hold the success or failure result
            //only run if there is something in the textboxes
            if ((txtFN.Text != string.Empty) && (txtLN.Text != string.Empty))
            {
                try
                {
                    result = myDatabase.InsertOrUpdateOwner(txtFN.Text, txtLN.Text, TxtOwnerID.Text, "Add");
                    MessageBox.Show(txtFN.Text + " " + txtLN.Text + " Updating " + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //update the datagrid view to see new entries
                DisplayDataGridViewOwner();
                txtFN.Text = "";
                txtLN.Text = "";
            }
            else
            {
                MessageBox.Show("Fill First Name and Surname fields");
            }
        }



        //CLICK EVENT FOR THE CD 

        private void DGVCD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string CDID, CDname, CDGenre, CDartist = null;
            //name, artist, genre cdid
            try
            {
                CDID = DGVCD.Rows[e.RowIndex].Cells[3].Value.ToString();
                CDname = DGVCD.Rows[e.RowIndex].Cells[0].Value.ToString();
                CDGenre = DGVCD.Rows[e.RowIndex].Cells[2].Value.ToString();
                CDartist = DGVCD.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (e.RowIndex >= 0)
                {
                    //  DisplayDataGridViewTracks(CDID)
                    DGVtracks.DataSource = myDatabase.FillAllDGVWithData("Track", CDID);
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    txtCDName.Text = CDname.Trim();
                    txtCDArtist.Text = CDartist;
                    txtCDGenre.Text = CDGenre;
                    txtCDID.Text = CDID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //CLICK EVENT FOR TRACKS 
        private void DGVtracks_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txttrackname.Text = DGVtracks.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtduration.Text = DGVtracks.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTrackID.Text = DGVtracks.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCDtrackID.Text = DGVtracks.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //CLEAR ALL TRACKS BEFORE ENTERING NEW DATA
        private void BtnClear_Click(System.Object sender, System.EventArgs e)
        {
            ClearAllTextBoxes(this);
        }

        //Clears all textboxes

        public void ClearAllTextBoxes(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Returns True if a Textbox with the same tag is empty
        /// </summary>
        /// <param name="root">all controls on the form</param>
        /// <param name="Tag">In the control Tag property</param>
        /// <returns>true / false</returns>

        public bool IsTheTextBoxEmpty(Control root, string Tag)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is TextBox) //   If it is a textbox
                {
                    if ((string)(ctrl as TextBox).Tag == Tag) //and it has a tag equal to Tag
                    {
                        if (((TextBox)ctrl).Text == string.Empty)
                        //and the textbox is  empty 
                        {
                            return true; //this should stop on the first empty textbox, which is what we want. 
                        }
                    }
                }
            }
            return false;
        }



        //DELETE ALL 
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            string InputID = string.Empty;
            //hold the ID of the owner, CD, or Track
            string result = null;
            Button fakebutton = null;
            fakebutton = (Button)sender;
            try
            {
                switch (fakebutton.Name)
                {
                    case "btnDeleteOwner":
                        InputID = TxtOwnerID.Text;
                        break;

                    case "btnDeleteCD":
                        InputID = txtCDID.Text;
                        break;
                    case "btnDeleteTracks":
                        InputID = txtTrackID.Text;
                        break;
                }
                //delete the track here and return back success or failure
                result = myDatabase.DeleteOwnerCDTracks(InputID, fakebutton.Tag.ToString());
                MessageBox.Show(fakebutton.Tag + " delete " + result);

                //refresh everything
                DisplayDataGridViewOwner();
                DGVCD.DataSource = myDatabase.FillAllDGVWithData("CD", txtCDID.Text);
                DGVtracks.DataSource = myDatabase.FillAllDGVWithData("Track", txtCDtrackID.Text);

                ClearAllTextBoxes(this); //clear all the textboxes afterwards
            }
            catch (Exception ex)
            {
                MessageBox.Show("First click on the Owner, CD, or Track you want to delete " + ex.Message);
            }
        }

        //ADD CD
        private void btnAddCD_Click(object sender, EventArgs e)
        {//only run if there is something in the textboxes
            if (!IsTheTextBoxEmpty(this, "CD"))
            {
                string result = null;

                try
                {
                    result = myDatabase.AddOrUpdateCD(TxtOwnerID.Text, txtCDName.Text, txtCDArtist.Text, txtCDGenre.Text, txtCDID.Text, "Add");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txtCDName.Text + " Adding " + result);
                    DGVCD.DataSource = myDatabase.FillAllDGVWithData("CD", (TxtOwnerID.Text));
                    //refresh the DGV
                    DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Fill all the fields");
            }
        }

        //ADD TRACKS
        private void btnaddTracks_Click(object sender, EventArgs e)
        {
            //only run if there is something in the textboxes
            if (!IsTheTextBoxEmpty(this, "Track"))
            {
                string result = null;
                try
                {
                    result = myDatabase.AddOrUpdateCDTrack(txtCDID.Text, txtCDtrackID.Text, txttrackname.Text, txtduration.Text, txtTrackID.Text, "Add");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txttrackname.Text + " Adding " + result);
                    DGVtracks.DataSource = myDatabase.FillAllDGVWithData("Track", txtCDID.Text);
                    //refresh the DGV
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Fill all the fields");
            }
        }

        //UPDATE ALL

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update the Owner

            //only run if there is something in the textboxes

            if (!IsTheTextBoxEmpty(this, "Owner"))

            {
                string result = null;
                try
                {

                    result = myDatabase.InsertOrUpdateOwner(txtFN.Text, txtLN.Text, TxtOwnerID.Text, "Update");
                    MessageBox.Show(txtFN.Text + " " + txtLN.Text + " Updating " + result);
                    //update the datagrid view to see new entries 
                    DisplayDataGridViewOwner();
                    DGVOwner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Owner not Updated" + ex.Message);
                }

            }
            else
            {
                //   MsgBox("Fill all the fields")
            }

            //Update the CD
            //only run if there is something in the textboxes
            if (!IsTheTextBoxEmpty(this, "CD"))
            {
                string result = null;
                try
                {
                    result = myDatabase.AddOrUpdateCD(TxtOwnerID.Text, txtCDName.Text, txtCDArtist.Text,
                        txtCDGenre.Text, txtCDID.Text, "Update");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txtCDName.Text + " Updating " + result);
                    DGVCD.DataSource = myDatabase.FillAllDGVWithData("CD", (TxtOwnerID.Text));
                    //refresh the DGV
                    DGVCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CD not Updated" + ex.Message);
                }

            }
            else
            {
                //  MsgBox("Fill all the fields")
            }

            //Update the Tracks
            //only run if there is something in the textboxes And
            if (!IsTheTextBoxEmpty(this, "Track"))
            {
                string result = null;
                try
                {
                    result = myDatabase.AddOrUpdateCDTrack(txtCDID.Text, txtCDtrackID.Text, txttrackname.Text,
                        txtduration.Text, txtTrackID.Text, "Update");
                    // MsgBox(txtCDName.Text & " has been inserted successfully")
                    MessageBox.Show(txttrackname.Text + " Updating " + result);
                    DGVtracks.DataSource = myDatabase.FillAllDGVWithData("Track", txtCDID.Text);
                    //refresh the DGV
                    DGVtracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Track not Updated" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Fill all the fields");
            }


        }


        #region "Stuff not important"



        private void DisplayListBox()
        {
            //clear old data out
            DGVCD.DataSource = null;
            lbgenre.DataSource = null;
            try
            {
                lbgenre.DataSource = myDatabase.FillListBoxWithGenre();
                lbgenre.DisplayMember = "Genre";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void comboboxfill()
        {
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

        private void ComboBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //pass the number to the textbox
            TextBox1.Text = (ComboBox1.SelectedIndex + 1).ToString();
            if (ComboBox1.SelectedIndex != -1)
            {
                // FillWithOwnerCD()
            }
        }

        private void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
        {
            // FillWithOwnerCD()
        }

        #endregion

        private void lbgenre_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtCDGenre.Text = lbgenre.SelectedItem.ToString();
        }




        public void ExtractDataFromNetToJSON(string title, string year, string rated, string released, string genre,
           string plot, string rentalcost)
        {
            //lbmovieDB.Items.Clear();
            ////this runs automatically when you call  mydata.DownloadFromNet
            //lblMovieTitle.Text = title;
            //lbmovieDB.Items.Add(year);
            //txtReleaseDate.Text = year;

            //lbmovieDB.Items.Add(rated);
            //lbmovieDB.Items.Add(released);
            //lbmovieDB.Items.Add(genre);
            //txtRating.Text = rated;
            //txtMovieGenre.Text = genre;
            //txtplot.Text = plot;
            //txtRentalCost.Text = rentalcost;
            ////run to update all movies
            //UpdateMovie(MovieRentedID, rated, title);

        }

        private void txtGoogle_Click(object sender, EventArgs e)
        {
            TestForm mytestform = new TestForm();
            mytestform.Show();
            BridgeToFormTest.DataIn = txtCDName.Text;

            if (!string.IsNullOrEmpty(txtCDName.Text))
            {
                FrmDetails frm = new FrmDetails(this);
                frm.Show();

            }
            else
            {
                MessageBox.Show("Click on a CD first Dimwit");
            }
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

