using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_SQL_Movies_Database_2016 {
    class Database {
        //Create Connection and Command,and an Adapter...
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();



        //THE CONSTRUCTOR SETS THE DEFAULTS UPON LOADING THE CLASS
        public Database() {
            //change the connection string to run from your own music db
            string connectionString =
                @"Data Source=GARY-LAPTOP\sqlexpress;Initial Catalog=Music;Integrated Security=True";
            Connection.ConnectionString = connectionString;
            Command.Connection = Connection;
            }
        public DataTable FillDGVOwnerWithOwner() {

            //   Load the OWner DataGridView
            DataTable dt = new DataTable();
            //create a datatable as we only have one table, the Owner

            using (da = new SqlDataAdapter("select * from Owner ", Connection)) {
                //connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL 
                Connection.Close(); //close the connection
                }
            return dt; //pass the datatable data to the DataGridView
            }
        public DataTable FillDGVCDWithOwnerClick(string OwnerID) {
            string SQL = "select Name, Artist, Genre, CDID from CD where OwnerIDFK = '" + OwnerID + "' ";
            using (da = new SqlDataAdapter(SQL, Connection)) {

                //connect in to the DB and get the SQL
                DataTable dt = new DataTable();
                //create a datatable as we only have one table, the Owner

                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL 
                Connection.Close();
                //close the connection

                return dt;
                }
            }
        public DataTable FillDGVTracksWithCDClick(string CDID) {

            DataTable dt = new DataTable();
            //create a datatable
            string SQL = "select TrackName, TrackDuration, trackID, CDTRackID from CDTracks where CDIDFK = '" + CDID + "' ";

            da = new SqlDataAdapter(SQL, Connection);
            //'connect in to the DB and get the SQL

            Connection.Open();
            //open a connection to the DB
            da.Fill(dt);
            //fill the datatable from the SQL 
            Connection.Close();
            //close the connection

            return dt;
            }
        public string DeleteOwnerCDTracks(string ID, string Table) {
            //only run if there is something in the textbox

            if (!object.ReferenceEquals(ID, string.Empty)) {
                var myCommand = new SqlCommand();
                switch (Table) {
                    case "Owner":
                        myCommand = new SqlCommand("DELETE FROM Owner WHERE OwnerID = @ID");
                        break;
                    case "CD":
                        myCommand = new SqlCommand("DELETE FROM CD WHERE CDID = @ID");
                        break;
                    case "Track":
                        myCommand = new SqlCommand("DELETE FROM CDTracks WHERE TrackID = @ID");
                        break;
                    }

                myCommand.Connection = Connection;
                myCommand.Parameters.AddWithValue("ID", ID);
                //use parameters to prevent SQL injections

                Connection.Open();
                // open connection add in the SQL
                myCommand.ExecuteNonQuery();
                Connection.Close();
                return "Success";
                } else {
                Connection.Close();
                return "Failed";
                }
            }
        //Connection test for the Unit test to see if the connection is working.
        public bool ConnectionUNITTest() {
            DataTable dt = new DataTable();
            //create a datatable can't have it global as it holds all the data
            try {
                string SQL = "select * from Owner";
                using (da = new SqlDataAdapter(SQL, Connection)) ;
                //'connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL via the DataAdapter
                Connection.Close();
                return true;
                //Working!
                } catch {
                Connection.Close();
                return false;
                //Not Working"
                }

            }
        public string InsertOrUpdateOwner(string Firstname, string Lastname, string ID, string AddOrUpdate) {
            try {
                //Added a Stored Procedure with Parameters 
                //  var myCommand = new SqlCommand();
                //   myCommand.Connection = Connection;
                if (AddOrUpdate == "Add") {
                    //Command = New SqlCommand("INSERT INTO Owner (FirstName, LastName) " & "VALUES(@Firstname, @Lastname)")

                    Command.CommandText = "proc_Add_Owner";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("Firstname", Firstname);
                    Command.Parameters.AddWithValue("Lastname", Lastname);


                    } else if (AddOrUpdate == "Update") {
                    Command = new SqlCommand("UPDATE Owner set FirstName = @Firstname, LastName=@Lastname where OwnerID = @ID ");

                    var myParam = Command.Parameters;
                    //use parameters to prevent SQL injections
                    myParam.AddWithValue("Firstname", Firstname);
                    myParam.AddWithValue("Lastname", Lastname);
                    myParam.AddWithValue("ID", ID);
                    }
                Connection.Open();
                // open connection add in the SQL
                Command.ExecuteNonQuery();
                Connection.Close();
                return " is Successful";
                } catch {
                //need to get it to close a second time as it jumps the first connection.close when ExecuteNonQuery fails.
                Connection.Close();
                return " has Failed";
                }
            }

        public string AddOrUpdateCD(string OwnerID, string Name, string Artist, string Genre, string CDID, string AddOrUpdate) {
            Dictionary<string, string> SQLDict = new Dictionary<string, string>();
            SQLDict.Add("Add", "INSERT INTO CD (OwnerIDFK, Name, Artist, Genre) " + "VALUES(@OwnerID, @Name, @Artist, @Genre)");
            SQLDict.Add("Update", "UPDATE CD  set OwnerIDFK=@OwnerID, Name= @Name, Artist=@Artist, Genre=@Genre where CDID = @ID");

            try {
                var myCommand = new SqlCommand(SQLDict[AddOrUpdate]);

                //if (AddOrUpdate == "Add") {
                //    myCommand = new SqlCommand("INSERT INTO CD (OwnerIDFK, Name, Artist, Genre) " + "VALUES(@OwnerID, @Name, @Artist, @Genre)");
                //    } else if (AddOrUpdate == "Update") {
                //    myCommand = new SqlCommand("UPDATE CD  set OwnerIDFK=@OwnerID, Name= @Name, Artist=@Artist, Genre=@Genre where CDID = @ID");
                //    }


                using (myCommand.Connection = Connection) {

                    var myParams = myCommand.Parameters;
                    //use parameters to prevent SQL injections
                    myParams.AddWithValue("OwnerID", OwnerID);
                    myParams.AddWithValue("Name", Name);
                    myParams.AddWithValue("Artist", Artist);
                    myParams.AddWithValue("Genre", Genre);
                    myParams.AddWithValue("ID", CDID);

                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();
                    Connection.Dispose();
                    return " is Successful";
                    }
                } catch {
                Connection.Close();
                return " has Failed";
                }
            }

        public string AddOrUpdateCDTrack(string CDIDFK, string CDTrackID, string TrackName, string TrackDuration, string TrackID, string AddOrUpdate) {
            try {
                var myCommand = new SqlCommand();
                if (AddOrUpdate == "Add") {
                    myCommand = new SqlCommand("INSERT INTO CDTracks (CDIDFK, CDTrackID, TrackName, TrackDuration) " + "VALUES(@CDIDFK, @CDTrackID, @TrackName, @TrackDuration)");
                    } else if (AddOrUpdate == "Update") {
                    myCommand = new SqlCommand("UPDATE CDTracks set CDIDFK=@CDIDFK, CDTrackID=@CDTrackID, TrackName=@TrackName, TrackDuration=@TrackDuration  where TrackID =@TrackID  ");
                    }

                myCommand.Connection = Connection;

                var myParams = myCommand.Parameters;
                //use parameters to prevent SQL injections
                myParams.AddWithValue("CDIDFK", CDIDFK);
                myParams.AddWithValue("CDTrackID", CDTrackID);
                myParams.AddWithValue("TrackName", TrackName);
                myParams.AddWithValue("TrackDuration", TrackDuration);
                myParams.AddWithValue("TrackID", TrackID);

                Connection.Open();
                // open connection add in the SQL
                myCommand.ExecuteNonQuery();
                Connection.Close();

                return " is Successful";
                } catch {
                Connection.Close();
                return " has Failed";
                }
            }





        public DataTable FillListBoxWithGenre() {
            DataTable dt = new DataTable();
            //create a datatable can't have it global as it holds all the data

            string SQL = "select genre from UniqueGenre";
            using (da = new SqlDataAdapter(SQL, Connection)) {
                //'connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL via the DataAdapter
                Connection.Close();

                }
            return dt;

            }

        public DataTable FillComboBoxWithName() {
            string SQL = "SELECT FirstName, LastName, OwnerID FROM Owner";
            da = new SqlDataAdapter(SQL, Connection);
            //'connect in to the DB and get the SQL
            DataSet ds = new DataSet();

            //fill the dataset
            //This code shows how to bind a DataTable to a ComboBox and display column 1 of the DataTable (the "Description" column) in the ComboBox and use column 2 ("Code") to select ComboBox items. 

            Connection.Open();
            da.Fill(ds, "Owner");
            Connection.Close();
            //fill it with the owner table

            return ds.Tables["Owner"];

            }



        }





    }

