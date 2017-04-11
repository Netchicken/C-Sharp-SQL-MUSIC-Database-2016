using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_SQL_Movies_Database_2016
{
    class CD
    {
        public int CDID { get; set; }
        public String Name { get; set; }
        public String Artist { get; set; }
        public String Genre { get; set; }
        public int OwnerIDFK { get; set; }
    }
}
