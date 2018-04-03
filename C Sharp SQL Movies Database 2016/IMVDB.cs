using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace C_Sharp_SQL_Movies_Database_2016
{
    //https://imvdb.com/developers/api
    //https://imvdb.com/developers/reference/entities
    //XYM3LvIh61dpfN4o8eZuzvRH8kY52nTZmG28cLpi
    // 	Mb3BXOdb3qGanpVzAVeymvkCUqLVB1indlZaadmd
    //IMVDB-APP-KEY: {XYM3LvIh61dpfN4o8eZuzvRH8kY52nTZmG28cLpi}
    //http://imvdb.com/api/v1/search/videos?q=Abba+Mamma+Mia
    //https://imvdb.com/developers/api/searching
    //https://www.google.com/#q=prince&tbm=vid

    //http://www.newtonsoft.com/json/help/html/Introduction.htm
    class IMVDB
    {
        private string VideoURL = "https://imvdb.com/api/v1/search/videos?q=";
        private string EntityURL = "http://imvdb.com/api/v1/search/entities?q=";  //https://imvdb.com/developers/api/searching


        public void DownloadFromNet(string MusicNameForNet)
        {

            string stringdownload = null;
            using (WebClient request = new WebClient())
            {


                //downloads the string and returns it
                //http://msdn.microsoft.com/en-us/library/system.net.webclient%28v=vs.110%29.aspx
                Uri webaddress = new Uri(VideoURL + MusicNameForNet);

                try
                {
                    //download the website as a string. 
                    stringdownload = request.DownloadString(webaddress);
                    ParseTheDownload(stringdownload);
                }
                catch (Exception e)
                {
                    // return null;
                    MessageBox.Show(e.ToString());
                }

            }
        }
        public class Artist
        {
            public string name { get; set; }
            public string slug { get; set; }
            public string url { get; set; }
        }

        public class Result
        {
            public object id { get; set; }
            public string production_status { get; set; }
            public object song_title { get; set; }
            public object song_slug { get; set; }
            public string url { get; set; }
            public bool multiple_versions { get; set; }
            public object version_name { get; set; }
            public int version_number { get; set; }
            public bool is_imvdb_pick { get; set; }
            public object aspect_ratio { get; set; }
            public int? year { get; set; }
            public bool verified_credits { get; set; }
            public List<Artist> artists { get; set; }
            public object image { get; set; }
        }

        public class RootObject
        {
            public int total_results { get; set; }
            public int current_page { get; set; }
            public int per_page { get; set; }
            public int total_pages { get; set; }
            public List<Result> results { get; set; }
        }

        public void ParseTheDownload(string stringdownload)
        {

            // JObject JSONobject = JObject.Parse(stringdownload);

            string rentalcost = null;
            //{    "Response": "False",    "Error": "Must provide more than one character."  }

            //parse out the values from the JSON
            //Calculate the rental cost


            //   http://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            JObject googleSearch = JObject.Parse(stringdownload);

            // get JSON result objects into a list
            IList<JToken> results = googleSearch["responseData"]["results"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<Result> searchResults = new List<Result>();
            foreach (JToken result in results)
            {
                Result searchResult = JsonConvert.DeserializeObject<Result>(result.ToString());
                searchResults.Add(searchResult);
            }

            //"url": "https:\/\/imvdb.com\/video\/belles-whistles\/princess",
            // ReleaseDate = (string)JSONobject["url"];
            //} catch {
            //ReleaseDate = 2000;
            //}



            //pass the extracted data and rental cost back to the main form, so it can be displayed
            //Form1 myForm1 = new Form1();
            //myForm1.ExtractDataFromNetToJSON(JSONobject["Title"].ToString(), JSONobject["Year"].ToString(), JSONobject["Rated"].ToString(), JSONobject["Released"].ToString(), JSONobject["Genre"].ToString(), JSONobject["Plot"].ToString(), rentalcost);



            //  txtReleaseDate.Text = "2000"
            //   txtMovieGenre.Text = "Unknown"
            rentalcost = String.Format("0:C", 2.0);
            // Form1.ExtractDataFromNetToJSON(JSONobject.Item("Title").ToString(), JSONobject.Item("Year").ToString(), JSONobject.Item("Rated").ToString(), "2000", "Unknown", JSONobject.Item("Plot").ToString(), rentalcost)




        }

        //http://json2csharp.com/ awesome converter

        //      "total_results": 135,
        //"current_page": 1,
        //"per_page": 25,
        //"total_pages": 6,
        //"results": [
        //    {
        //        "id": 122578500383,
        //        "production_status": "r",
        //        "song_title": "Princess",
        //        "song_slug": "princess",
        //        "url": "https:\/\/imvdb.com\/video\/belles-whistles\/princess",
        //        "multiple_versions": false,
        //        "version_name": null,
        //        "version_number": 1,
        //        "is_imvdb_pick": false,
        //        "aspect_ratio": null,
        //        "year": 2014,
        //        "verified_credits": false,
        //        "artists": [
        //            {
        //                "name": "Belles & Whistles",
        //                "slug": "belles-whistles",
        //                "url": "https:\/\/imvdb.com\/n\/belles-whistles"
        //            }
        //        ],
        //        "image": {
        //            "o": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/122578500383-belles-whistles-princess_music_video_ov.jpg?v=2",
        //            "l": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/122578500383-belles-whistles-princess_music_video_lv.jpg?v=2",
        //            "b": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/122578500383-belles-whistles-princess_music_video_bv.jpg?v=2",
        //            "t": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/122578500383-belles-whistles-princess_music_video_tv.jpg?v=2",
        //            "s": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/122578500383-belles-whistles-princess_music_video_sv.jpg?v=2"
        //        }
        //    },
        //    {
        //        "id": 101300311348,
        //        "production_status": "r",
        //        "song_title": "Fresh Prince",
        //        "song_slug": "fresh-prince",
        //        "url": "https:\/\/imvdb.com\/video\/soprano-2\/fresh-prince",
        //        "multiple_versions": false,
        //        "version_name": null,
        //        "version_number": 1,
        //        "is_imvdb_pick": false,
        //        "aspect_ratio": null,
        //        "year": 2014,
        //        "verified_credits": false,
        //        "artists": [
        //            {
        //                "name": "Soprano (2)",
        //                "slug": "soprano-2",
        //                "url": "https:\/\/imvdb.com\/n\/soprano-2"
        //            }
        //        ],
        //        "image": {
        //            "o": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/101300311348-soprano-2-fresh-prince_music_video_ov.jpg?v=2",
        //            "l": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/101300311348-soprano-2-fresh-prince_music_video_lv.jpg?v=2",
        //            "b": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/101300311348-soprano-2-fresh-prince_music_video_bv.jpg?v=2",
        //            "t": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/101300311348-soprano-2-fresh-prince_music_video_tv.jpg?v=2",
        //            "s": "https:\/\/s3.amazonaws.com\/images.imvdb.com\/video\/101300311348-soprano-2-fresh-prince_music_video_sv.jpg?v=2"
        //        }
        //    },


    }
}
