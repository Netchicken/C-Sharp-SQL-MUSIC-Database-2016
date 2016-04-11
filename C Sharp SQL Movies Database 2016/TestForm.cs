using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SQL_Movies_Database_2016 {
    public partial class TestForm : Form {
 
        Database myDB = new Database();
        public TestForm() {
            InitializeComponent();

         
        }

        private void lblData_Click(object sender, EventArgs e) {

            }

        private void TestForm_Load(object sender, EventArgs e)
        {

          


        }

        private void button1_Click(object sender, EventArgs e) {
   lblData.Text = BridgeToFormTest.DataIn;
            }
        }
    }
