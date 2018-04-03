using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SQL_Movies_Database_2016
{
    //this is a Data Transfer Object. Its not a class it exists soley to pass the data from the Form to the Database classes. its a DTO (commonly found in ASP.net) 
    public static class OwnerDTO
    {
        public static int OwnerID { get; set; }
        public static String FirstName { get; set; }
        public static String LastName { get; set; }
        public static DataGridView OwnerDGV { get; set; }

        public static DataGridViewCellEventArgs Events { get; set; }
        public static void OwnerDGVExtract()
        {
            OwnerID = (int)OwnerDGV.Rows[Events.RowIndex].Cells[0].Value;
            FirstName = OwnerDGV.Rows[Events.RowIndex].Cells[1].Value.ToString();
            LastName = OwnerDGV.Rows[Events.RowIndex].Cells[2].Value.ToString();
            }


        //clear out the dto to prevent any data from leaking over
        public static void ClearData()
        {
            OwnerID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }

    }
}
