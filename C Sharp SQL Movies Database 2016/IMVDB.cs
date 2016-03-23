using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace C_Sharp_SQL_Movies_Database_2016 {
    //https://imvdb.com/developers/api
    //https://imvdb.com/developers/reference/entities
    //XYM3LvIh61dpfN4o8eZuzvRH8kY52nTZmG28cLpi
    // 	Mb3BXOdb3qGanpVzAVeymvkCUqLVB1indlZaadmd
    //IMVDB-APP-KEY: {XYM3LvIh61dpfN4o8eZuzvRH8kY52nTZmG28cLpi}
    //http://imvdb.com/api/v1/search/videos?q=Abba+Mamma+Mia
    //https://imvdb.com/developers/api/searching
    //https://www.google.com/#q=prince&tbm=vid

    //http://www.newtonsoft.com/json/help/html/Introduction.htm
    class IMVDB {
        private string VideoURL = "https://imvdb.com/api/v1/search/videos?q=";
        private string EntityURL = "http://imvdb.com/api/v1/search/entities?q=";  //https://imvdb.com/developers/api/searching


        public void DownloadFromNet(string MusicNameForNet) {

            string stringdownload = null;
            using (WebClient request = new WebClient()) {


                //downloads the string and returns it
                //http://msdn.microsoft.com/en-us/library/system.net.webclient%28v=vs.110%29.aspx
                Uri webaddress = new Uri(VideoURL + MusicNameForNet);

                try {
                    //download the website as a string. 
                    stringdownload = request.DownloadString(webaddress);
                    ParseTheDownload(stringdownload);
                    } catch (Exception e) {
                    // return null;
                    MessageBox.Show(e.ToString());
                    }

                }
            }

        public void ParseTheDownload(string stringdownload) {

            JObject JSONobject = JObject.Parse(stringdownload);

            string rentalcost = null;
            //{    "Response": "False",    "Error": "Must provide more than one character."  }

            if (stringdownload.Contains("Movie not found!") == false && stringdownload.Contains("Must provide more than one character") == false) {
                //parse out the values from the JSON
                //Calculate the rental cost
                int thisyear = DateTime.Today.Date.Year;
                int ReleaseDate = 0;
                try {
                    ReleaseDate = (int)JSONobject["Year"];
                    } catch {
                    ReleaseDate = 2000;
                    }

                if ((thisyear - ReleaseDate) <= 5) {
                    rentalcost = String.Format("0:C", 5.0);
                    } else {
                    rentalcost = String.Format("0:C", 2.0);
                    }

                //pass the extracted data and rental cost back to the main form, so it can be displayed
                Form1 myForm1 = new Form1();
                myForm1.ExtractDataFromNetToJSON(JSONobject["Title"].ToString(), JSONobject["Year"].ToString(), JSONobject["Rated"].ToString(), JSONobject["Released"].ToString(), JSONobject["Genre"].ToString(), JSONobject["Plot"].ToString(), rentalcost);


                } else {
                //  txtReleaseDate.Text = "2000"
                //   txtMovieGenre.Text = "Unknown"
                rentalcost = String.Format("0:C", 2.0);
                // Form1.ExtractDataFromNetToJSON(JSONobject.Item("Title").ToString(), JSONobject.Item("Year").ToString(), JSONobject.Item("Rated").ToString(), "2000", "Unknown", JSONobject.Item("Plot").ToString(), rentalcost)
                }



            }






        }
    }
